using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;
namespace Main_System.DataAccess.Operators;

public class ReceivedDeckRemover
{
    // Based off of 'Deleter.cs', which was programmed using the reference below:
    // https://stackoverflow.com/questions/9946287/correct-method-of-deleting-over-2100-rows-by-id-with-dapper

    public void RemoveDecksSharedToUser(ReadOnlySpan<int> decksToRemove, int user)
    {
        var connectionString = Environment.GetEnvironmentVariable("NewConnectionString");
        var connection = new SqlConnection(connectionString);

        connection.Open();

        try
        {
            connection.Execute("CREATE TABLE ItemsToDelete(Id INT PRIMARY KEY)");

            using (var bulkCopy = new SqlBulkCopy(connection))
            {
                bulkCopy.BatchSize = decksToRemove.Length;
                bulkCopy.DestinationTableName = "ItemsToDelete";

                var table = new DataTable();
                table.Columns.Add("Id", typeof(int));
                bulkCopy.ColumnMappings.Add("Id", "Id");

                foreach (var deck in decksToRemove)
                {
                    table.Rows.Add(deck);
                }

                bulkCopy.WriteToServer(table);
            }


            // Here, the DecksToShare table is deleted from specifically.
            // The deleter class cannot be used, as 'DecksToShare.Deck_Id' does not abide by the generic DELETE statement used in that code.
            // With more time for this project, I could have generalised the deleter class further and perhaps made this class inherit from the deleter class.

            connection.Execute($@"
DELETE FROM DecksToShare
WHERE DecksToShare.Receiver_Id = @userId
AND DecksToShare.Deck_Id IN (SELECT Id FROM ItemsToDelete)",
            new { @userId = user });
        }
        finally
        {
            connection.Execute("DROP TABLE ItemsToDelete");
            
            connection.Close();
            connection.Dispose();
        }
    }
}

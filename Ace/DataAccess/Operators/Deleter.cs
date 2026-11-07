using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;
namespace Main_System.DataAccess.Operators;

public enum DeletionType
{
    Card,
    Tag,
    Card_Has_Tag,
    Deck
}

public class Deleter
{
    // Recommendation for a more efficient method of removing records from a table by 'Chris Smith' and 'Chris Marisic'
    // https://stackoverflow.com/questions/9946287/correct-method-of-deleting-over-2100-rows-by-id-with-dapper
    
    public void DeleteData(int[] itemsToDelete, DeletionType target)
    {
        // Gets the string required to make an SQL connection to the database
        var connectionString = Environment.GetEnvironmentVariable("NewConnectionString");
        var connection = new SqlConnection(connectionString);

        // Connection is opened
        connection.Open();

        try
        {

            // A temporary table is created solely for deleting a certain type of items
            connection.Execute("CREATE TABLE ItemsToDelete(Id INT PRIMARY KEY)");

            // This is used to bulk load all the ids of items to delete into a table in the database
            using (var bulkCopy = new SqlBulkCopy(connection))
            {
                bulkCopy.BatchSize = itemsToDelete.Length;
                bulkCopy.DestinationTableName = "ItemsToDelete";

                // A table is constructed of all the items to delete and their respective ids
                var table = new DataTable();
                table.Columns.Add("Id", typeof(int));
                bulkCopy.ColumnMappings.Add("Id", "Id");

                foreach (var item in itemsToDelete)
                {
                    table.Rows.Add(item);
                }

                // table is added to the database
                bulkCopy.WriteToServer(table);
            }

            // Every record relating to an item in that created table is deleted
            connection.Execute($@"
DELETE FROM {target.ToString()}
WHERE {target.ToString()}.{target.ToString()}_Id IN (SELECT Id FROM ItemsToDelete)");

        }
        
        finally
        {            
            // Created table is then dropped (deleted)
            connection.Execute("DROP TABLE ItemsToDelete");

            // Connection is closed and disposed of
            connection.Close();
            connection.Dispose();
        }
    }
}

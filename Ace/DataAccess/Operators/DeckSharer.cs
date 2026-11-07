using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;

namespace Main_System.DataAccess.Operators
{
	public class DeckSharer
	{
		// Based off of 'Deleter.cs', which was programmed using the reference below:
		// https://stackoverflow.com/questions/9946287/correct-method-of-deleting-over-2100-rows-by-id-with-dapper

		public void ShareDecks(int[] decksToShare, int senderId, int[] receiverIds)
		{
			var connectionString = Environment.GetEnvironmentVariable("NewConnectionString");
			var connection = new SqlConnection(connectionString);

			connection.Open();

			try
			{
				// The constraint in the statement is to denote a composite primary key
				connection.Execute(@"
CREATE TABLE DecksToShare(
	Deck_Id INT FOREIGN KEY REFERENCES Deck(Deck_Id) ON DELETE NO ACTION,
	Sender_Id INT FOREIGN KEY REFERENCES Account(Account_Id) ON DELETE NO ACTION,
	Receiver_Id INT FOREIGN KEY REFERENCES Account(Account_Id) ON DELETE NO ACTION,
	CONSTRAINT PK_DecksToShare PRIMARY KEY (Deck_Id, Sender_Id, Receiver_Id)
  )");
				using (var bulkCopy = new SqlBulkCopy(connection))
				{
					bulkCopy.BatchSize = decksToShare.Length;
					bulkCopy.DestinationTableName = "DecksToShare";

					var table = new DataTable();
					table.Columns.Add("Deck_Id", typeof(int));
					table.Columns.Add("Sender_Id", typeof(int));
					table.Columns.Add("Receiver_Id", typeof(int));

					bulkCopy.ColumnMappings.Add("Deck_Id", "Deck_Id");
					bulkCopy.ColumnMappings.Add("Sender_Id", "Sender_Id");
					bulkCopy.ColumnMappings.Add("Receiver_Id", "Receiver_Id");

					foreach (var deck in decksToShare)
					{
						foreach (var receiver in receiverIds)
						{
							table.Rows.Add(deck, senderId, receiver);
						}
					}

					bulkCopy.WriteToServer(table);
				}
			}
			// If the DecksToShare table already exists, then we insert into the table rather than creating and then inserting
			catch
			{
				foreach (var deck in decksToShare)
				{
					foreach (var receiver in receiverIds)
					{
						try
						{
							connection.Execute(@"
INSERT INTO DecksToShare(Deck_Id, Sender_Id, Receiver_Id)
VALUES (@deck_Id, @sender_Id, @receiver_Id)",
							new
							{
								@deck_Id = deck,
								@sender_Id = senderId,
								@receiver_Id = receiver
							});
						}
						// Prevents the same deck from being shared to the same user multiple times
						// i.e. prevents spamming
						catch { }
					}
				}
			}
			finally
			{
				connection.Close();
				connection.Dispose();
			}
		}
	}
}

using System.Data;
using Dapper;
using Main_System.Objects;
namespace Main_System.DataAccess.Repositories;

public class DeckRepository : IDisposable
{
    private readonly IDbConnection _db;

    public DeckRepository(IDbConnection db)
    {
        _db = db;
    }

    public void Dispose()
    {
        _db.Close();
        GC.SuppressFinalize(this);
    }

    // Retrieves decks based on their owner
    public IEnumerable<Deck> GetDecksByUserId(int ownerId)
    {
        try
        {
            return _db.Query<Deck>(@"
SELECT Deck.Deck_Id AS Id, Deck.Deck_Name AS Name, Deck.Deck_Description AS Description, Deck.Deck_Owner AS OwnerId
FROM Deck
JOIN Account
ON Deck.Deck_Owner = Account.Account_Id
WHERE Account.Account_Id = @userId",
            new { @userId = ownerId });
        }
        catch
        {
            return Enumerable.Empty<Deck>();
        }
    }

    // Retrieves only the names of decks based on their owner
    public IEnumerable<string> GetDeckNamesByUserId(int ownerId)
    {
        try
        {
            return _db.Query<string>(@"
SELECT Deck.Deck_Name
FROM Deck
JOIN Account
ON Deck.Deck_Owner = Account.Account_Id
WHERE Account.Account_Id = @userId",
            new { @userId = ownerId });
        }
        catch
        {
            return Enumerable.Empty<string>();
        }
    }

    // Retrieves the decks that were sent to a specific user (i.e. a specific account id)
    public IEnumerable<SharedDeck> GetDecksSharedToUserId(int receiverId)
    {
        try
        {
            return _db.Query<SharedDeck>(@"
SELECT Deck.Deck_Id AS Id, Deck.Deck_Name AS Name, Deck.Deck_Description AS Description, Deck.Deck_Owner AS OwnerId, DecksToShare.Sender_Id AS SenderId
FROM Deck
JOIN DecksToShare
ON Deck.Deck_Id = DecksToShare.Deck_Id
WHERE Receiver_Id = @userId",
            new { @userId = receiverId });
        }
        catch
        {
            return Enumerable.Empty<SharedDeck>();
        }
    }


    // Retrieves the name of a deck from a card's id
    public string GetDeckNameByCardId(int cardId)
    {
        try
        {
            return _db.QuerySingle<string>(@"
SELECT Deck.Deck_Name
FROM Deck
JOIN Card
ON Card.Card_Deck = Deck.Deck_Id
WHERE Card.Card_Id = @cardId",
            new { @cardId = cardId });
        }
        catch
        {
            return string.Empty;
        }
        
    }

    // Retrieves the id of a deck from its name
    public int? GetIdByDeckName(ReadOnlySpan<char> deckName, int userId)
    {
        try
        {
            return _db.QuerySingle<int>(@"
SELECT Deck.Deck_Id
FROM Deck
WHERE Deck.Deck_Name = @deckName
AND Deck.Deck_Owner = @userId",
            new { @deckName = deckName.ToString(), @userId = userId });
        }
        catch
        {
            return null;
        }
    }

    // Checks if the database already contains a record with a specified deck name
    public bool? CheckIfDeckNameTaken(ReadOnlySpan<char> name, int userId)
    {
        try
        {
            return _db.ExecuteScalar<bool>($@"
SELECT COUNT(DISTINCT 1)
FROM Deck
WHERE Deck.Deck_Name = @name
AND Deck.Deck_Owner = @userId", new { @name = name.ToString(), @userId = userId });
        }
        catch
        {
            return null;
        }
    }

    // Stores deck credentials in the database
    public int? StoreDeck(ReadOnlySpan<char> name, string description, int owner)
    {
        try
        {
            return _db.QuerySingle<int>(@"
INSERT INTO Deck(Deck_Name, Deck_Description, Deck_Owner)
VALUES (@deckName, @deckDescription, @deckOwner)
SELECT CAST(SCOPE_IDENTITY() as int)",
            new {
                @deckName = name.ToString(),
                @deckDescription = description,
                @deckOwner = owner
            });
        }
        catch
        {
            return null;
        }
    }
}

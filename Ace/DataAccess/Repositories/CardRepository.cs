using System.Data;
using Dapper;
using Main_System.Objects;
namespace Main_System.DataAccess.Repositories;

public class CardRepository : IDisposable
{
    private readonly IDbConnection _db;

    public CardRepository(IDbConnection db)
    {
        _db = db;
    }

    public void Dispose()
    {
        _db.Close();
        GC.SuppressFinalize(this);
    }

    // Retrieves cards based on their owner (i.e. an account id)
    public IEnumerable<Card> GetCardsByUserId(int ownerId)
    {
        try
        {
            return _db.Query<Card, CardSchedule, Card>(@"
SELECT Card_Id AS Id, Card_Front AS Front, Card_Back AS Back, Card_State AS State, Card_DueDate AS DueDate
FROM Card
JOIN Account
ON Card.Card_Owner = Account.Account_Id
WHERE Account.Account_Id = @userId",
            (card, cardSchedule) => {
                card.Schedule = cardSchedule;
                return card;
            },
            new { @userId = ownerId },
            splitOn: "DueDate");
        }
        catch
        {
            return Enumerable.Empty<Card>();
        }
    }

    // Retrieves cards from a specific deck
    public IEnumerable<Card> GetCardsByDeck(int ownerId, ReadOnlySpan<char> deck)
    {
        try
        {
            return _db.Query<Card, CardSchedule, Card>(@"
SELECT Card_Id AS Id, Card_Front AS Front, Card_Back AS Back, Card_State AS State, Card_DueDate AS DueDate
FROM Card
JOIN Account
ON Card.Card_Owner = Account.Account_Id
JOIN Deck
ON Deck.Deck_Id = Card.Card_Deck
WHERE Account.Account_Id = @userId AND Deck.Deck_Name = @deckId",
            (card, cardSchedule) => {
                card.Schedule = cardSchedule;
                return card;
            },
            new { @userId = ownerId, @deckId = deck.ToString() },
            splitOn: "DueDate");
        }
        catch
        {
            return Enumerable.Empty<Card>();
        }
    }

    // Retrieves cards based on the tags attached to them
    public IEnumerable<Card> GetCardsByTags(int ownerId, ReadOnlySpan<string> tags)
    {
        try
        {
            return _db.Query<Card, CardSchedule, Card>(@"
SELECT Card_Id AS Id, Card_Front AS Front, Card_Back AS Back, Card_State AS State, Card_DueDate AS DueDate
FROM Card
JOIN Account
ON Card.Card_Owner = Account.Account_Id
WHERE Account.Account_Id = @userId AND Card.Card_Id IN (
    SELECT Card_Id
    FROM Card_Has_Tag, Tag
    WHERE Card_Has_Tag.Tag_Id = Tag.Tag_Id AND Tag.Tag_Name IN @tagNames
    GROUP BY Card_Id
    HAVING COUNT(Card_Id) = @numberOfTags )",
            (card, cardSchedule) => {
                card.Schedule = cardSchedule;
                return card;
            },
            new {
                @userId = ownerId,
                @tagNames = tags.ToArray(),
                @numberOfTags = tags.ToArray().Length
            },
            splitOn: "DueDate");
        }
        catch
        {
            return Enumerable.Empty<Card>();
        }
        
    }

    // Retrieves cards from a specific deck based on the tags attached to them
    public IEnumerable<Card> GetCardsFromDeckByTags(int ownerId, ReadOnlySpan<char> deck, ReadOnlySpan<string> tags)
    {
        try
        {
            return _db.Query<Card, CardSchedule, Card>(@"
SELECT Card_Id AS Id, Card_Front AS Front, Card_Back AS Back, Card_State AS State, Card_DueDate AS DueDate
FROM Card
JOIN Account
ON Account.Account_Id = Card.Card_Owner
JOIN Deck
ON Deck.Deck_Id = Card.Card_Deck
WHERE Account.Account_Id = @cardOwner AND Deck_Name = @cardDeck AND Card.Card_Id IN (
SELECT Card_Id
FROM Card_Has_Tag, Tag
WHERE Card_Has_Tag.Tag_Id = Tag.Tag_Id AND Tag.Tag_Name IN @tagNames
GROUP BY Card_Id
HAVING COUNT(Card_Id) = @numberOfTags)",
            (card, cardSchedule) => {
                card.Schedule = cardSchedule;
                return card;
            }, 
            new {
                @cardOwner = ownerId,
                @cardDeck = deck.ToString(),
                @tagNames = tags.ToArray(),
                @numberOfTags = tags.ToArray().Length
            },
            splitOn: "DueDate");
        }
        catch
        {
            return Enumerable.Empty<Card>();
        }
    }

    // Stores card credentials in the database
    public int? StoreCard(Card card, int ownerId, int deckId)
    {
        try
        {
            return _db.QuerySingle<int>(@"
INSERT INTO Card (Card_Front, Card_Back, Card_DueDate, Card_ReviewInterval, Card_State, Card_Type, Card_Owner, Card_Deck)
VALUES (@front, @back, @dueDate, @reviewInterval, @state, @type, @cardOwner, @deck)
SELECT CAST(SCOPE_IDENTITY() as int)",
        new
        {
            @front = card.Front,
            @back = card.Back,
            @dueDate = card.Schedule.DueDate,
            @reviewInterval = card.Schedule.ReviewInterval,
            @state = card.State,
            @type = "Normal",
            @cardOwner = ownerId,
            @deck = deckId
        });
        }
        catch
        {
            return null;
        }
    }

    // Changes the front, back and/or deck of a single card record in the database
    public bool UpdateCardDetails(Card newCardDetails, int newDeck)
    {
        try
        {
            _db.Execute(@"
UPDATE Card
SET Card.Card_Front = @front, Card.Card_Back = @back, Card.Card_Deck = @deck
WHERE Card.Card_Id = @id",
            new
            {
                @front = newCardDetails.Front,
                @back = newCardDetails.Back,
                @deck = newDeck,
                @id = newCardDetails.Id
            });

            return true;
        }
        catch
        {
            return false;
        }
    }

    // Changes the schedule (review interval and due date) of a single card record in the database
    public bool UpdateCardSchedule(int cardId, double reviewInterval, ReadOnlySpan<char> dueDate)
    {
        try
        {
            _db.Execute(@"
UPDATE Card
SET Card.Card_DueDate = @dueDate, Card.Card_ReviewInterval = @reviewInterval
WHERE Card.Card_Id = @id",
            new
            {
                @dueDate = dueDate.ToString(),
                @reviewInterval = reviewInterval,
                @id = cardId
            });

            return true;
        }
        catch
        {
            return false;
        }
        
    }
}

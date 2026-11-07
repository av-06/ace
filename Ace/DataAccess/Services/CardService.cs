using System.Data;
using Microsoft.Data.SqlClient;
using Main_System.DataAccess.Repositories;
using Main_System.DataAccess.Operators;
using Main_System.Objects;
namespace Main_System.DataAccess.Services;

public class CardService
{
    
    // This method and its overloads gets cards based on certain conditions.
    // These conditions can be seen by the name of the repo's method: repo.GetCards[conditions]
    public Card[] GetCards(int ownerId)
    {
        using (var repo = GetRepo())
        {
            return repo.GetCardsByUserId(ownerId).ToArray();
        }
    }

    public Card[] GetCards(int ownerId, ReadOnlySpan<char> deck)
    {
        using (var repo = GetRepo())
        {
            return repo.GetCardsByDeck(ownerId, deck).ToArray();
        }
    }

    public Card[] GetCards(int ownerId, ReadOnlySpan<string> tags)
    {
        using (var repo = GetRepo())
        {
            return repo.GetCardsByTags(ownerId, tags).ToArray();
        }
    }
    public Card[] GetCards(int ownerId, ReadOnlySpan<char> deck, ReadOnlySpan<string> tags)
    {
        using (var repo = GetRepo())
        {
            return repo.GetCardsFromDeckByTags(ownerId, deck, tags).ToArray();
        }
    }

    
    // Deletes cards that have a specified id
    public void DeleteCards(ReadOnlySpan<int> cardIds)
    {
        GetDeleter().DeleteData(cardIds.ToArray(), DeletionType.Card);
    }

    // Returns an array of cards based on the filters specified by the user.
    // This is explained more in detail in the Filterer class.
    public Card[] FilterCards(FilterFrame filterFrame)
    {
        return new CardFilterer(filterFrame).Filter();
    }


    // Schedules a card based on its difficulty
    public void ScheduleCard(Card card, byte difficulty)
    {
        var schedule = new CardScheduler().CalculateNewSchedule(card, difficulty);
        
        // Formats the due date to SQL server's format
        var dueDateElements = schedule.DueDate.Split('/');
        var dueDate = string.Join('/', new string[]{ dueDateElements[1], dueDateElements[0], dueDateElements[2] });

        // Used to ensure that the card is scheduled
        var isCardScheduled = false;

        do
        {
            using (var repo = GetRepo())
            {
                // Updates the card's schedule in the database
                isCardScheduled = repo.UpdateCardSchedule(card.Id, schedule.ReviewInterval, dueDate);
            }
        } while (isCardScheduled is false);
    }

    // Adds a card to the database
    public int? AddCard(Card card, int ownerId, int deckId)
    {
        using (var repo = GetRepo())
        {
            var insertedCardId = repo.StoreCard(card, ownerId, deckId);
            return insertedCardId;
        }
    }

    // Changes the front, back and/or deck of the card to the details specified in the card edit
    public bool FinishCardEdit(Card cardEdit, int deckId)
    {
        using (var repo = GetRepo())
        {
            var isEditDone = repo.UpdateCardDetails(cardEdit, deckId);
            return isEditDone;
        }
    }

    private CardRepository GetRepo()
    {
        return new CardRepository(GetConnection());
    }

    private IDbConnection GetConnection()
    {
        var connectionString = Environment.GetEnvironmentVariable("NewConnectionString");
        return new SqlConnection(connectionString);
    }

    // Returns a deleter object for use in card deletion
    private Deleter GetDeleter()
    {
        return new Deleter();
    }
}
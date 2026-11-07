using Microsoft.Data.SqlClient;
using Main_System.Objects;
using Main_System.DataAccess.Repositories;
using Main_System.DataAccess.Operators;
namespace Main_System.DataAccess.Services;

public class DeckService
{

    // Gets all decks owned by a specified account
    public Deck[] GetDecks(int ownerId)
    {
        using (var repo = GetRepo())
        {
            return repo.GetDecksByUserId(ownerId).ToArray();
        }
    }

    // Gets the name of the deck that a specified card is in
    public string GetDeckName(int cardId)
    {
        using (var repo = GetRepo())
        {
            return repo.GetDeckNameByCardId(cardId);
        }
    }

    // Gets only the names of the decks owned by a specified account
    public string[] GetDeckNames(int ownerId)
    {
        using (var repo = GetRepo())
        {
            return repo.GetDeckNamesByUserId(ownerId).ToArray();
        }
    }

    // Gets the decks shared to a specified account
    public SharedDeck[] GetDecksSharedToUser(int receiverId)
    {
        using (var repo = GetRepo())
        {
            return repo.GetDecksSharedToUserId(receiverId).ToArray();
        }
    }

    // Gets the id of a deck from its name
    public int GetId(ReadOnlySpan<char> deckName, int userId)
    {
        int? id;
        do
        {
            using (var repo = GetRepo())
            {
                id = repo.GetIdByDeckName(deckName, userId);
            }
        } while (id.HasValue is false);

        return id.Value;
    }

    // Adds a new deck to the database
    public int AddNewDeck(ReadOnlySpan<char> name, string description, int ownerId)
    {
        int? addedDeckId;

        do
        {
            using (var repo = GetRepo())
            {
                addedDeckId = repo.StoreDeck(name, description, ownerId);
            }
        } while (addedDeckId.HasValue is false);

        return addedDeckId.Value;
    }


    // Deletes decks that have a specified id
    public void DeleteDecks(ReadOnlySpan<int> deckIds)
    {
        GetDeleter().DeleteData(deckIds.ToArray(), DeletionType.Deck);
    }

    // Removes decks sent to a specified user from the database
    public void RemoveReceivedDecks(ReadOnlySpan<int> deckIds, int receiverId)
    {
        GetRemover().RemoveDecksSharedToUser(deckIds, receiverId);
    }

    // Checks if a deck of the same name is in the database
    public bool CheckIfDeckNameTaken(ReadOnlySpan<char> deckName, int userId)
    {
        bool? isDeckNameTaken;
        do
        {
            using (var repo = GetRepo())
            {
                isDeckNameTaken = repo.CheckIfDeckNameTaken(deckName, userId);
            }
        } while (isDeckNameTaken.HasValue is false);

        return isDeckNameTaken.Value;
    }

    public void ShareDecks(ReadOnlySpan<int> decksToShare, int senderId, ReadOnlySpan<int> receiverIds)
    {
        GetSharer().ShareDecks(decksToShare.ToArray(), senderId, receiverIds.ToArray());
    }

    private DeckRepository GetRepo()
    {
        var connectionString = Environment.GetEnvironmentVariable("NewConnectionString");
        return new DeckRepository(new SqlConnection(connectionString));
    }

    private Deleter GetDeleter()
    {
        return new Deleter();
    }

    // Returns a remover object for use in removing received decks
    // This is used to remove listings from the decks received by the current user when they accept or reject those decks
    private ReceivedDeckRemover GetRemover()
    {
        return new ReceivedDeckRemover();
    }

    // Returns a sharer object for use in sharing decks
    private DeckSharer GetSharer()
    {
        return new DeckSharer();
    }
}

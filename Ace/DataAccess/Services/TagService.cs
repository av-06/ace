using Microsoft.Data.SqlClient;
using Main_System.DataAccess.Operators;
using Main_System.DataAccess.Repositories;
namespace Main_System.DataAccess.Services;

public class TagService
{
    // This method and its overloads gets tags based on certain conditions.
    // These conditions can be seen by the name of the repo's method: repo.GetTags[conditions]
    public string[] GetTags(int ownerId)
    {
        return GetRepo().GetTagsByUserId(ownerId).ToArray();
    }

    public string[] GetTags(int ownerId, int cardId)
    {
        return GetRepo().GetTagsByCardId(ownerId, cardId).ToArray();
    }


    // Gets the ids of specific tags owned and specified by a specific account
    public int[] GetTagIds(int ownerId, ReadOnlySpan<string> selectedTags)
    {
        return GetRepo().GetTagIds(ownerId, selectedTags).ToArray();
    }

    // Adds new tags to the database and applies them to existing cards
    public void StoreTags(ReadOnlySpan<string> tags, ReadOnlySpan<int> cards)
    {
        var tagRepo = GetRepo();
        int? insertedTagId;
        bool isTagAdded;

        foreach (var tag in tags)
        {
            do
            {
                insertedTagId = tagRepo.AddTag(tag);
            } while (insertedTagId.HasValue is false);
            
            foreach (var card in cards)
            {
                do
                {
                    isTagAdded = tagRepo.AddTagToCard(card, insertedTagId.Value);
                } while (isTagAdded is false);
            }
        }
    }

    // Applies tags to existing cards
    public void ApplyTags(ReadOnlySpan<int> tags, int card)
    {
        bool isTagApplied;
        
        foreach (var tag in tags)
        {
            do
            {
                isTagApplied = GetRepo().AddTagToCard(card, tag);
            } while (isTagApplied is false);
        }
    }

    // Deletes tags that have a specified id
    public void DeleteTags(ReadOnlySpan<int> tagsIds)
    {
        GetDeleter().DeleteData(tagsIds.ToArray(), DeletionType.Tag);
    }

    // Removes all tags from specified cards - i.e. those cards will no longer have any tags attached to them
    public void RemoveTags(int[] selectedCards)
    {
        GetDeleter().DeleteData(selectedCards, DeletionType.Card_Has_Tag);
    }


    // This validates tags against certain requirements.
    // This is explained in more detail in the validator class
    public (bool, string) ValidateTags(int ownerId, ReadOnlySpan<string> tags)
    {
        return GetValidator().ValidateTags(ownerId, tags);
    }

    private TagRepository GetRepo()
    {
        var connectionString = Environment.GetEnvironmentVariable("NewConnectionString");
        return new TagRepository(new SqlConnection(connectionString));
    }

    private TagValidator GetValidator()
    {
        return new TagValidator(GetRepo());
    }

    private Deleter GetDeleter()
    {
        return new Deleter();
    }
}

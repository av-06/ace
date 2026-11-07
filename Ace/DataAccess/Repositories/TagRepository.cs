using System.Data;
using Dapper;
namespace Main_System.DataAccess.Repositories;

public class TagRepository : IDisposable
{
    private readonly IDbConnection _db;
    public TagRepository(IDbConnection db)
    {
        _db = db;
    }

    public void Dispose()
    {
        _db.Close();
        GC.SuppressFinalize(this);
    }

    // Retrieves tags based on their creator
    public IEnumerable<string> GetTagsByUserId(int ownerId)
    {
        try
        {
            return _db.Query<string>(@"
SELECT Tag.Tag_Name, COUNT(Tag.Tag_Id)
FROM Tag
JOIN Card_Has_Tag
ON Tag.Tag_Id = Card_Has_Tag.Tag_id
JOIN Card
ON Card.Card_Id = Card_Has_Tag.Card_Id
JOIN Account
ON Account.Account_Id = Card.Card_Owner
WHERE Account.Account_Id = @userId
GROUP BY Tag.Tag_Name
ORDER BY COUNT(Tag.Tag_Id) DESC",
        new { @userId = ownerId });
        }
        catch
        {
            return Enumerable.Empty<string>();
        }
    }

    // Retrieves the tags attached to a specific card
    public IEnumerable<string> GetTagsByCardId(int ownerId, int cardId)
    {
        try
        {
            return _db.Query<string>(@"
SELECT Tag.Tag_Name AS Name
FROM Tag
JOIN Card_Has_Tag
ON Tag.Tag_Id = Card_Has_Tag.Tag_id
JOIN Card
ON Card.Card_Id = Card_Has_Tag.Card_Id
JOIN Account
ON Account.Account_Id = Card.Card_Owner
WHERE Account.Account_Id = @userId
AND Card.Card_Id = @cardId",
            new { @userId = ownerId, @cardId = cardId });
        }
        catch
        {
            return Enumerable.Empty<string>();
        }
    }


    // Retrieves from the database the id of each tag in a provided list of tags
    public IEnumerable<int> GetTagIds(int ownerId, ReadOnlySpan<string> tags)
    {
        try
        {
            return _db.Query<int>(@"
SELECT DISTINCT Tag.Tag_Id
FROM Tag
JOIN Card_Has_Tag
ON Tag.Tag_Id = Card_Has_Tag.Tag_id
JOIN Card
ON Card.Card_Id = Card_Has_Tag.Card_Id
JOIN Account
ON Account.Account_Id = Card.Card_Owner
WHERE Account.Account_Id = @userId
AND Tag.Tag_Name IN @tagNames",
            new { @userId = ownerId, @tagNames = tags.ToArray() });
        }
        catch
        {
            return Enumerable.Empty<int>();
        }
    }

    // Stores tag credentials in the database
    public int? AddTag(ReadOnlySpan<char> tag)
    {
        try
        {
            return _db.QuerySingle<int>(@"
INSERT INTO Tag VALUES (@tagName) 
SELECT CAST(SCOPE_IDENTITY() as int)", 
            new { @tagName = tag.ToString() });
        }
        catch
        {
            return null;
        }
    }


    // Applies a tag to a card
    public bool AddTagToCard(int cardId, int tagId)
    {
        try
        {
            _db.Execute("INSERT INTO Card_Has_Tag VALUES (@card_Id, @tag_Id)", 
                new { @card_Id = cardId, @tag_Id = tagId });

            return true;
        }
        catch 
        {
            return false;
        }
    }

    // Checks if any tag of a list of tags has already been created by a user
    // i.e. Detects duplicate tags
    public IEnumerable<string> GetTagsAlreadyTaken(ReadOnlySpan<string> tags, int ownerId)
    {
        try
        {
            return _db.Query<string>(@"
SELECT Tag.Tag_Name
FROM Tag
JOIN Card_Has_Tag
ON Tag.Tag_Id = Card_Has_Tag.Tag_id
JOIN Card
ON Card.Card_Id = Card_Has_Tag.Card_Id
JOIN Account
ON Account.Account_Id = Card.Card_Owner
WHERE Account.Account_Id = @userId AND Tag.Tag_Name IN @tagNames
GROUP BY Tag.Tag_Name",
            new { @userId = ownerId, @tagNames = tags.ToArray() } );
        }
        catch
        {
            return Enumerable.Empty<string>();
        }
    }
}

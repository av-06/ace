using Main_System.DataAccess.Repositories;
namespace Main_System.DataAccess.Operators;

public class TagValidator
{
    private readonly TagRepository _repo;
    public TagValidator(TagRepository repo)
    {
        _repo = repo;
    }

    public (bool, string) ValidateTags(int ownerId, ReadOnlySpan<string> tags)
    {
        // This is used rather than a FOREACH statement to allow for line numbers to be referenced in the error message
        for (int i = 0; i < tags.Length; i++)
        {
            // If a blank tag has been inputted by the user
            if (string.IsNullOrWhiteSpace(tags[i]))
            {
                return (false, $"Blank tag detected at line {i + 1}. Tag name must not be blank!");
            }

            // If a tag is longer than 15 characters
            if (tags[i].Length > 15)
            {
                return (false, $"Tag detected at line {i + 1} is longer than 15 characters. Tag name must be 15 characters or less!");
            }
        }

        // Retrieves the tags inputted by the user that are also present in the database
        var duplicateTagLines = TryFindDuplicateTags(ownerId, tags);

        // If there are duplicate tags present
        if (duplicateTagLines is not null)
        {
            return (false, $"Duplicate tags detected at lines: {string.Join(", ", duplicateTagLines)}");
        }
        else
        {
            return (true, string.Empty);
        }
    }

    private int[]? TryFindDuplicateTags(int ownerId, ReadOnlySpan<string> tags)
    {
        var sameTagsFound = _repo.GetTagsAlreadyTaken(tags, ownerId).ToArray();

        // sameTagsFound.Length will not be 0 only if at least 1 tag inputted by the user is found in the database
        if (sameTagsFound.Length is not 0)
        {
            // Returns the line locations of each duplicate tag found
            return FindAllDuplicateLines(tags, sameTagsFound);
        }
        else
        {
            return null;
        }
    }

    private int[] FindAllDuplicateLines(ReadOnlySpan<string> tags, ReadOnlySpan<string> sameTagsFound)
    {
        var tagLineNumbers = new List<int>();

        for (int i = 0; i < tags.Length; i++)
        {
            // If the tag inputted by the user is also a tag found in the database
            if (sameTagsFound.Contains(tags[i]))
            {
                tagLineNumbers.Add(i + 1);
            }
        }

        return tagLineNumbers.ToArray();
    }
}
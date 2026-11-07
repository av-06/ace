using Main_System.Objects;
using Main_System.DataAccess.Services;
namespace Main_System;

public class TagAdderMethods
{
    /* This class exists to reuse these methods in other forms 
     * e.g. TagSelectionForm, CardMakerForm
     */


    // Sets the tag choices (datasource of tag listbox) to all tags owned by the users
    public void RefreshTagChoices(ListBox tagChoices, Account currentUser)
    {
        tagChoices.DataSource = new TagService().GetTags(currentUser.Id);
    }

    // Validates tags, outputting an error message if there are any invalid tags present
    public bool RunTagValidation(Account currentUser, ReadOnlySpan<string> tags)
    {
        var (isValid, errorMessage) = new TagService().ValidateTags(currentUser.Id, tags);

        if (isValid is false)
        {
            MessageBox.Show(errorMessage, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        return isValid;
    }

    // Gets the names of the tags selected by the user from the tag listbox
    public ReadOnlySpan<string> ExtractSelectedTags(ListBox tagChoices)
    {
        // An empty array is created of length equal to the number of tags selected by the user
        var tags = new string[tagChoices.SelectedItems.Count];

        for (int i = 0; i < tagChoices.SelectedItems.Count; i++)
        {
            // The name of each tag is inserted into a separate index in the array
            tags[i] = tagChoices.SelectedItems[i].ToString();
        }

        return tags;
    }


    // Adds new tags and applies them to the cards selected by the current user
    public void AddNewTags(string[] tags, ReadOnlySpan<int> cardIDs)
    {
        // Distinct() ensures that no duplicate tags are inserted into the database
        new TagService().StoreTags(tags.Distinct().ToArray(), cardIDs);
    }

    // Applies tags selected by the user to cards selected by the user
    public void AddSelectedTags(ReadOnlySpan<string> selectedTags, Account currentUser, ReadOnlySpan<int> cardIDs)
    {
        // Gets the ids of the tags selected by the user
        var selectedTagIDs = new TagService().GetTagIds(currentUser.Id, selectedTags);
        ApplyTagsToCards(selectedTagIDs, cardIDs);
    }

    public void ApplyTagsToCards(ReadOnlySpan<int> selectedTagIDs, ReadOnlySpan<int> selectedCardIDs)
    {
        foreach (var card in selectedCardIDs)
        {
           new TagService().ApplyTags(selectedTagIDs, card);
        }
    }
}

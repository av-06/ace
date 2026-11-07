using Main_System.Objects;
using Main_System.DataAccess.Services;
using Microsoft.IdentityModel.Tokens;
namespace Main_System;

public partial class TagSelectionForm : Form
{
    private readonly Account _currentUser;
    private readonly TagAdderMethods _tagAdderMethods = new TagAdderMethods(); // Recycling code from the TagAdder form
    private bool _isFiltering; // Used to distinguish between the 2 use cases of this form: tag filtering and tag deletion

    public TagSelectionForm(Account currentUser, bool isFiltering)
    {
        InitializeComponent();
        _currentUser = currentUser;
        _isFiltering = isFiltering;
    }

    private void TagSelectionForm_Load(object sender, EventArgs e)
    {
        // Gets all tags created by the user to populate the listbox
        var tags = new TagService().GetTags(_currentUser.Id).ToArray();
        listBoxTags.DataSource = tags;
        
        // If no tags have been created by the user, the form closes
        if (listBoxTags.Items.Count is 0)
        {
            MessageBox.Show("No tags found!", "Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }


        // This automatically selects tags that the user is already using to filter cards
        if (DeckBrowserForm.selectedTags.IsNullOrEmpty() is false)
        {
            // Ensures the 1st index is not selected by default
            listBoxTags.SetSelected(0, false);
            foreach (var tag in DeckBrowserForm.selectedTags)
            {
                // Employs a binary search to find the index of a tag in the collection of all tags.
                // The corresponding index is selected for listBoxTags
                listBoxTags.SetSelected(Array.BinarySearch(tags, tag), true);
            }
        }
    }

    private void btnSelect_Click(object sender, EventArgs e)
    {
        // Gets the names of the tags selected by the user
        var tags = _tagAdderMethods.ExtractSelectedTags(listBoxTags).ToArray();

        // This is used to distinguish between the 2 use cases of this form: tag filtering and tag deletion
        if (_isFiltering)
        {
            DeckBrowserForm.selectedTags = tags;
        }
        else
        {
            // This is concerning tag DELETION
            DeckBrowserForm.tagsToDelete = tags;
        }

        this.Close();
    }
}

using Main_System.Objects;
namespace Main_System;

public partial class TagAdderForm : Form
{
    private readonly Account _currentUser;
    private readonly int[] _selectedCards;
    private readonly TagAdderMethods _tagAdderMethods = new TagAdderMethods(); // All the methods used by the TagAdderForm

    public TagAdderForm(Account currentUser, ReadOnlySpan<int> selectedCards)
    {
        InitializeComponent();
        _currentUser = currentUser;
        _selectedCards = selectedCards.ToArray();
    }

    private void TagAdderForm_Load(object sender, EventArgs e)
    {
        // Populates the tag listbox with all tags owned by the user
        _tagAdderMethods.RefreshTagChoices(listBoxTags, _currentUser);
        
        boxNewTag.PlaceholderText = "Tag 1\nTag 2\n...";
    }

    private void btnAddNewTag_Click(object sender, EventArgs e)
    {
        var areTagsValid = _tagAdderMethods.RunTagValidation(_currentUser, boxNewTag.Lines);

        if (areTagsValid)
        {
            // Stores new tags in the database and applies them to selected cards.
            // Distinct() is used here as well as in 'TagAdderMethods', to once again ensure that no duplicate tags are added
            _tagAdderMethods.AddNewTags(boxNewTag.Lines.Distinct().ToArray(), _selectedCards);

            // Updates the tag listbox to include the new tags
            _tagAdderMethods.RefreshTagChoices(listBoxTags, _currentUser);
            
            MessageBox.Show($"Tags '{string.Join(',', boxNewTag.Lines.Distinct())}' were applied to selected cards!");

            // Indicates to the DeckBrowserForm that the deck display needs refreshing.
            // This is because, in this case, the tags attached to a card(s) has changed
            DeckBrowserForm.doesDeckDisplayNeedRefreshing = true;
        }
    }

    private void btnApplySelectedTags_Click(object sender, EventArgs e)
    {
        // Gets the tags selected by the user
        var selectedTags = _tagAdderMethods.ExtractSelectedTags(listBoxTags);

        // The selected tags are applied to the selected cards
        _tagAdderMethods.AddSelectedTags(selectedTags, _currentUser, _selectedCards);

        MessageBox.Show($"Tags '{string.Join(", ", selectedTags.ToArray())}' were applied to selected cards!");
        DeckBrowserForm.doesDeckDisplayNeedRefreshing = true;
    }
}

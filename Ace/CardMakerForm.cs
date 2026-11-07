using Microsoft.IdentityModel.Tokens;
using Main_System.Objects;
using Main_System.DataAccess.Services;
namespace Main_System;

public partial class CardMakerForm : Form
{
    public static string[] tags;
    private Account _currentUser;
    private readonly Deck[] _decks;
    private readonly TagAdderMethods _tagAdderMethods; // Methods used by the TagAdderForm can be reused for this form

    public CardMakerForm(Account currentUser)
    {
        InitializeComponent();
        _tagAdderMethods = new TagAdderMethods();
        _currentUser = currentUser;
        
        _decks = new DeckService().GetDecks(_currentUser.Id);
    }

    private void CardMakerForm_Load(object sender, EventArgs e)
    {
        // Adds the names of every deck owned by the user to the deck selection combobox
        cmbBoxDeck.Items.AddRange(new DeckService().GetDeckNames(_currentUser.Id));

        // Adds the names of every tag owned by the user to the tag selection listbox
        listBoxTags.DataSource = new TagService().GetTags(_currentUser.Id).ToArray();
        
        // Ensures that no tags are selected when the form is opened
        listBoxTags.ClearSelected();

        boxNewTag.PlaceholderText = "Tag 1\nTag 2\n...";
    }

    private void btnAddCard_Click(object sender, EventArgs e)
    {
        // 1. Validates card to ensure all details have been provided
        var (isAllDetailsGiven, errorMessage) = CheckIfAllDetailsGiven();

        if (isAllDetailsGiven)
        {
            // 2. If new tags have been entered, the system validates tags to ensure they are proper
            if (!boxNewTag.Text.IsNullOrEmpty())
            {
                var areTagsValid = _tagAdderMethods.RunTagValidation(_currentUser, boxNewTag.Lines);

                if (areTagsValid)
                {
                    // All details are stored in the database, including the new tags
                    StoreAllDetails(true);
                }
            }

            // All details are stored in the database, excluding any new tags
            StoreAllDetails(false);

            MessageBox.Show("Card was successfully created!", "Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        else
        {
            MessageBox.Show(errorMessage, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void boxCardFront_KeyDown(object sender, KeyEventArgs e)
    {
        FormatIfNeeded(boxCardFront, e);
    }

    private void boxCardBack_KeyDown(object sender, KeyEventArgs e)
    {
        FormatIfNeeded(boxCardBack, e);
    }

    private (bool, string) CheckIfAllDetailsGiven()
    {
        // If the front of the card is left blank
        if (boxCardFront.Text.IsNullOrEmpty())
        {
            return (false, "Text not provided for the front of the card!");
        }

        // If the back of the card is left blank
        if (boxCardBack.Text.IsNullOrEmpty())
        {
            return (false, "Text not provided for the back of the card!");
        }

        // If no deck is selected
        if (cmbBoxDeck.Text.IsNullOrEmpty())
        {
            return (false, "Deck not selected");
        }

        // If none of the above cases are true, then the card must be valid
        return (true, string.Empty);
    }

    private void StoreAllDetails(bool areNewTagsIncluded)
    {
        // 3. System stores the card details in the database
        Card card = new Card(0, boxCardFront.Rtf, boxCardBack.Rtf, "NEW", 
            new CardSchedule(0, null));

        var insertedCardId = new CardService().AddCard(card,
                _currentUser.Id, _decks[cmbBoxDeck.SelectedIndex].Id);

        if (insertedCardId.HasValue)
        {
            // (optional) 4. System adds tags already made by the user and selected to that card
            if (listBoxTags.SelectedItems.Count is not 0)
            {
                var selectedTags = _tagAdderMethods.ExtractSelectedTags(listBoxTags);
                _tagAdderMethods.AddSelectedTags(selectedTags, _currentUser, new int[] { insertedCardId.Value });
            }

            // (optional) 5. System adds new tags made by the user to that card
            if (areNewTagsIncluded)
            {
                _tagAdderMethods.AddNewTags(boxNewTag.Lines.Distinct().ToArray(), new int[] { insertedCardId.Value });
            }
        }
        else
        {
            MessageBox.Show("System failed to add card. Please try again.");
        }
    }
   
    private void FormatIfNeeded(RichTextBox box, KeyEventArgs e)
    {
        if (Control.ModifierKeys == Keys.Control)
        {
            switch (e.KeyCode)
            {
                // Bold text
                case Keys.B:
                    box.SelectionFont = new Font(box.SelectionFont,
                        box.SelectionFont.Style ^ FontStyle.Bold);
                    e.SuppressKeyPress = true;
                    break;

                // Italic text
                case Keys.I:
                    box.SelectionFont = new Font(box.SelectionFont,
                        box.SelectionFont.Style ^ FontStyle.Italic);
                    e.SuppressKeyPress = true;
                    break;

                // Underlined text
                case Keys.U:
                    box.SelectionFont = new Font(box.SelectionFont,
                        box.SelectionFont.Style ^ FontStyle.Underline);
                    e.SuppressKeyPress = true;
                    break;
            }
        }
    }
}

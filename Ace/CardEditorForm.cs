using Main_System.DataAccess.Services;
using Main_System.Objects;
using Microsoft.IdentityModel.Tokens;

namespace Main_System
{
    public partial class CardEditorForm : Form
    {
        private readonly Account _currentUser;
        private readonly Card _editingCard; // The card to be edited
        private readonly string _originalDeck; // The original deck of the card

        public CardEditorForm(Card editingCard, ReadOnlySpan<char> originalDeck, Account currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
            _editingCard = editingCard;
            _originalDeck = originalDeck.ToString();
        }

        private void CardEditorForm_Load(object sender, EventArgs e)
        {
            cmbBoxDeck.Items.AddRange(new DeckService().GetDeckNames(_currentUser.Id));
            
            boxCardFront.Rtf = _editingCard.Front;
            boxCardBack.Rtf = _editingCard.Back;

            // Ensures that the selected deck is initially the original deck of the card
            cmbBoxDeck.SelectedItem = new DeckService().GetDeckName(_editingCard.Id);
        }

        private void btnFinishEdit_Click(object sender, EventArgs e)
        {
            var (isAllDetailsGiven, errorMessage) = CheckIfAllDetailsGiven();

            if (isAllDetailsGiven)
            {
                _editingCard.Front = boxCardFront.Rtf;
                _editingCard.Back = boxCardBack.Rtf;

                // Gets the id of the deck selected by the user
                var selectedDeckId = new DeckService().GetId(cmbBoxDeck.Text, _currentUser.Id);

                // Card details are updated in the database to reflect the edit made
                var isEditDone = new CardService().FinishCardEdit(_editingCard, selectedDeckId);

                // If this edit is successfully performed
                if (isEditDone)
                {
                    MessageBox.Show("Changes have successfully been made to the selected card", "Note", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Indicates to the DeckBrowserForm that the deck display needs refreshing.
                    // This is because a card's details have been changed
                    DeckBrowserForm.doesDeckDisplayNeedRefreshing = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("System was unable to edit the card. Please try again.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(errorMessage, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Each keypress is detected when the card front or card back textbox is selected.
        // This is done to detect when the user wants to change the formatting of their text
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
            // If front of the card is left blank
            if (boxCardFront.Text.IsNullOrEmpty())
            {
                return (false, "Text not provided for the front of the card!");
            }

            // If back of the card is left blank
            if (boxCardBack.Text.IsNullOrEmpty())
            {
                return (false, "Text not provided for the back of the card!");
            }

            // If no deck is selected by the user
            if (cmbBoxDeck.Text.IsNullOrEmpty())
            {
                return (false, "Deck not selected");
            }

            // If all of the above are not true, then the card edit must be a valid edit
            return (true, string.Empty);
        }

        // Used to format text in a rich textbox
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
}

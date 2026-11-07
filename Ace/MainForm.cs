using Main_System.Objects;
using Main_System.DataAccess.Services;
using System.Globalization;
namespace Main_System;

public partial class MainForm : Form
{
    private readonly Account _currentUser;
    private Deck[] _deckChoices;
    public static bool hasDeckBeenAdded = false;

    public MainForm(Account currentUser)
    {
        InitializeComponent();

        _currentUser = currentUser;
        
        // retrieves all decks owned by the current user
        _deckChoices = new DeckService().GetDecks(_currentUser.Id);

        // Student manager should only be available to Teachers
        btnManageStudents.Visible = (currentUser.Type is accountType.Teacher) ? true : false;

        UpdateDeckDisplay();
    }

    // Opens the card maker form to allow the user to create a new card
    private void btnAddCard_Click(object sender, EventArgs e)
    {
        using (var cmf = new CardMakerForm(_currentUser))
        {
            cmf.ShowDialog();
        }
    }

    private void btnCreateDeck_Click(object sender, EventArgs e)
    {
        using (var dmf = new DeckMakerForm(_currentUser))
        {
            dmf.ShowDialog();
        }

        // If a deck has been added, then the selection of deck choices needs to be updated to reflect this change
        if (hasDeckBeenAdded)
        {
            // All decks owned by the current user are retrieved once again.
            // This will include the new deck added
            _deckChoices = new DeckService().GetDecks(_currentUser.Id);
            UpdateDeckDisplay();
        }
    }

    private void btnBrowseCards_Click(object sender, EventArgs e)
    {
        using (var dbf = new DeckBrowserForm(_currentUser))
        {
            dbf.ShowDialog();
        }
    }

    private void btnShareDecks_Click(object sender, EventArgs e)
    {
        // If the user does have decks to share
        if (_deckChoices.Length is not 0)
        {
            using (var dsf = new DeckSharerForm(_currentUser, _deckChoices))
            {
                dsf.ShowDialog();
            }
        }
        else
        {
            MessageBox.Show("No decks have been created!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnReceiveDecks_Click(object sender, EventArgs e)
    {
        using (var drf = new DeckReceiverForm(_currentUser))
        {
            drf.ShowDialog();
        }

        if (hasDeckBeenAdded)
        {
            _deckChoices = new DeckService().GetDecks(_currentUser.Id);
            UpdateDeckDisplay();
        }
    }

    private void btnDeleteSelectedDecks_Click(object sender, EventArgs e)
    {
        var selectedDecks = dataGridDecks.SelectedCells;

        if (selectedDecks.Count is not 0)
        {
            // An empty array of length equivalent to the number of decks selected by the user
            var decksToDelete = new int[selectedDecks.Count];
            
            // This is the index of the last item in the decksToDelete array
            var maxIndex = selectedDecks.Count - 1;

            foreach (DataGridViewCell deck in selectedDecks)
            {
                // _deckChoices is searched for a single deck with the same name as the deck selected by the user.
                // The id of the deck found is stored in the decksToDelete array
                decksToDelete[maxIndex] = 
                    _deckChoices.Where(deckChoice => deckChoice.Name == deck.Value)
                    .Single<Deck>()
                    .Id;

                // This deck is then removed from _deckChoices as it is no longer an option for the the user to select
                _deckChoices = _deckChoices.ToList().Where(deck => deck.Id != decksToDelete[maxIndex]).ToArray();
                
                // max index is decremented to move onto the next left position along the array
                maxIndex--;
            }

            // Decks are then deleted from the database using the deck ids collected via the previous subroutine
            new DeckService().DeleteDecks(decksToDelete);
            
            MessageBox.Show("Selected decks were successfuly deleted!", "Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
            UpdateDeckDisplay();
        }
        else
        {
            MessageBox.Show("No decks are selected to delete!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }


    private void dataGridDecks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        // Gets the string in the cell selected by the current user - this will be the deck name
        var chosenDeck = dataGridDecks.CurrentCell.Value.ToString();

        // Gets the cards in the deck with that deck name from the database
        var extractedCards = new CardService().GetCards(_currentUser.Id, chosenDeck);
        

        // If the deck is empty, then a session cannot be performed
        if (extractedCards.Length is 0)
        {
            MessageBox.Show($"'{chosenDeck}' is empty!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        else
        {
            // Gets all cards in the cards retrieved that are due on or were due before the date when the program is running
            extractedCards = extractedCards.Where(card =>
            DateTime.ParseExact(card.ScheduleDueDate, "MM/dd/yyyy", CultureInfo.InvariantCulture) <= DateTime.Today.Date)
            .ToArray();

            // If no more cards are due, then a session cannot be performed
            if (extractedCards.Length is 0)
            {
                MessageBox.Show("No cards in this deck are due for today!", "Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Cards are reversed beforehand, since session code involves storing cards in a stack
                extractedCards.Reverse();

                using (var sf = new SessionForm(extractedCards, chosenDeck, _currentUser))
                {
                    sf.ShowDialog();
                }
            }
        }
    }

    // Updates display to include all decks owned by current user
    private void UpdateDeckDisplay()
    {
        dataGridDecks.DataSource = _deckChoices;

        dataGridDecks.Columns["Id"].Visible = false;
        dataGridDecks.Columns["Description"].Visible = false;
        dataGridDecks.Columns["OwnerId"].Visible = false;
    }
}
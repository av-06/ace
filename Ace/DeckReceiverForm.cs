using System.Data;
using Main_System.Objects;
using Main_System.DataAccess.Services;
namespace Main_System;

public partial class DeckReceiverForm : Form
{
    private readonly Account _currentUser;
    private readonly List<SharedDeck> _decksReceived; // Decks sent to the current user

    public DeckReceiverForm(Account currentUser)
    {
        InitializeComponent();
        _currentUser = currentUser;
        _decksReceived = new DeckService().GetDecksSharedToUser(_currentUser.Id).ToList();
    }

    private void DeckReceiverForm_Load(object sender, EventArgs e)
    {
        // If no decks have been received
        if (_decksReceived.Count is 0)
        {
            MessageBox.Show("No decks have been sent to you!", "Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        RefreshDeckSelection();
    }

    private void listBoxDecks_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Gets the deck in _decksReceived whose index corresponds with the listbox selected index
        var selectedDeck = _decksReceived[listBoxDecks.SelectedIndex];

        boxDescription.Text = selectedDeck.Description;
        boxSender.Text = new AccountService().GetUsernameByUserId(selectedDeck.SenderId);
    }

    private void btnAccept_Click(object sender, EventArgs e)
    {
        // Gets the decks to remove by getting the decks in _decksReceived, each with an index corresponding to a listbox selected index
        var selectedDecks = listBoxDecks.SelectedIndices.Cast<int>();
        var decksToRemove = selectedDecks.Select(i => _decksReceived[i]).ToArray();

        foreach (var deck in decksToRemove)
        {
            // 1. Add the accepted deck to the Decks table, with their owner being the current user
            new DeckService().AddNewDeck(deck.Name, deck.Description, _currentUser.Id);

            // 2. Get the cards from this accepted deck
            var cards = new CardService().GetCards(deck.SenderId, deck.Name);

            // 3. Add the accepted cards to the Cards table, with the owner being the current user
            foreach (var card in cards)
            {
                new CardService().AddCard(card, _currentUser.Id, deck.Id);
            }
        }

        // 4. Remove selected decks from the collection of decks received, which is stored in the database
        new DeckService().RemoveReceivedDecks(decksToRemove.Select(deck => deck.Id).ToArray(),
                        _currentUser.Id);
        
        // 5. Remove selected decks from received deck choices in listbox
        RemoveDeckListings(selectedDecks);
    }

    private void btnReject_Click(object sender, EventArgs e)
    {
        var selectedDecks = listBoxDecks.SelectedIndices.Cast<int>();
        var decksToRemove = selectedDecks.Select(i => _decksReceived[i].Id).ToArray();

        // Remove cards from decksToShare table
        new DeckService().RemoveReceivedDecks(decksToRemove, _currentUser.Id);
        RemoveDeckListings(selectedDecks);
    }

    private void RefreshDeckSelection()
    {
        // Only the names of each deck is displayed in the listbox
        listBoxDecks.DataSource = _decksReceived.Select(deck => deck.Name).ToArray();
    }

    private void RemoveDeckListings(IEnumerable<int> selectedDecks)
    {
        foreach (var deck in selectedDecks)
        {
            _decksReceived.RemoveAt(deck);
        }

        if (_decksReceived.Count is 0)
        {
            MessageBox.Show("No more decks received!", "Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            // Indicates to the main form to update the deck listings.
            // This is because there is the chance of a new deck being accepted
            MainForm.hasDeckBeenAdded = true;
            this.Close();
        }
        else
        {
            RefreshDeckSelection();
        }
    }
}
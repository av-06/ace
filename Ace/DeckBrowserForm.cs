using System.Data;
using System.Buffers;
using System.Collections.Immutable;
using Microsoft.IdentityModel.Tokens;
using Main_System.Objects;
using Main_System.DataAccess.Services;
namespace Main_System;

public partial class DeckBrowserForm : Form
{
    private readonly Account _currentUser;
    private Card[] _rtfCards; // all cards stored in rtf format
    private List<string> _activeFilters = new List<string>(5); // all filters selected by the user
    public static string[] selectedTags = Array.Empty<string>(); // all tags selected by the user
    public static string[] tagsToDelete = Array.Empty<string>(); // all tags to be deleted
    public static bool doesDeckDisplayNeedRefreshing = false; // Used to trigger a deck display refresh if necessary

    public DeckBrowserForm(Account currentUser)
    {
        InitializeComponent();
        _currentUser = currentUser;
    }

    private void DeckBrowserForm_Load(object sender, EventArgs e)
    {
        // Populates the combobox with a selection of decks owned by the current user
        // This restricts the user to only select from decks that they have created
        InitiateDeckList();

        // User should not be able to disable filters if no filters have been enabled yet
        btnRemoveFilters.Enabled = false;

        // Triggers the combobox to get all cards owned by the current user
        cmbBoxCurrentDeck.SelectedItem = "All";
    }

    private void cmbBoxCurrentDeck_TextChanged(object sender, EventArgs e)
    {
        if (string.Equals(cmbBoxCurrentDeck.Text, "All", StringComparison.OrdinalIgnoreCase))
        {
            // Gets all the user's cards with their rtf front and back
            _rtfCards = new CardService().GetCards(_currentUser.Id);
        }
        else
        {
            // Gets cards with their rtf front and back in a specific deck owned by the user
            new CardService().GetCards(_currentUser.Id, cmbBoxCurrentDeck.Text);
        }

        // Applies any selected filters to the card collection
        _rtfCards = FilterCardChoices(_rtfCards);

        // Applies a search term to the card collection
        _rtfCards = SearchCardChoices(_rtfCards);

        UpdateDeckDisplay(_rtfCards);
    }

    private void dataGridDecks_SelectionChanged(object sender, EventArgs e)
    {
        // Updates the GUI to display the front and back of the card currently selected by the user
        UpdateCardDisplay();
    }

    private void btnNew_Click(object sender, EventArgs e)
    {
        SelectFilter(btnNew, "NEW");
        ProcessFilter();
    }

    private void btnLearning_Click(object sender, EventArgs e)
    {
        SelectFilter(btnLearning, "LEARNING");
        ProcessFilter();
    }
    private void btnReview_Click(object sender, EventArgs e)
    {
        SelectFilter(btnReview, "REVIEW");
        ProcessFilter();
    }
    private void btnDue_Click(object sender, EventArgs e)
    {
        SelectFilter(btnDue, "DUE");
        ProcessFilter();
    }

    private void btnTags_Click(object sender, EventArgs e)
    {
        // A new form is opened to allow the user to select the tags to filter for
        using (var tsf = new TagSelectionForm(_currentUser, true))
        {
            tsf.ShowDialog();
        }

        // Ensures that the tag filter is only applied if the user selects at least 1 tag
        if (selectedTags.Length is not 0)
        {
            SelectFilter(new Button(), "TAG");
            ProcessFilter();
        }
    }

    private void btnRemoveFilters_Click(object sender, EventArgs e)
    {
        // Clears the tag selection
        selectedTags = Array.Empty<string>();
        _activeFilters.Clear();

        // Resets all button controls related to filtering
        btnNew.Enabled = true;
        btnLearning.Enabled = true;
        btnReview.Enabled = true;
        btnDue.Enabled = true;
        btnRemoveFilters.Enabled = false;

        // Triggers the combobox to get all cards in the deck chosen by the current user
        cmbBoxCurrentDeck_TextChanged(null, EventArgs.Empty);
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        var selectedCards = dataGridDecks.SelectedRows;

        // Ensures that at least 1 deck is selected to delete
        if (selectedCards.Count is not 0)
        {
            var cardsToDelete = new int[selectedCards.Count];
            var maxIndex = selectedCards.Count - 1;

            foreach (DataGridViewRow card in selectedCards)
            {
                // Gets the id of the card selected by the user from the invisible id column in the datagrid
                cardsToDelete[maxIndex] = 
                    (int)card.Cells[dataGridDecks.Columns["id"].Index].Value;

                // Removes the card with the corresponding id from the card selection
                _rtfCards = 
                    _rtfCards.ToList().Where(card => card.Id != cardsToDelete[maxIndex]).ToArray();

                maxIndex--;
            }

            new CardService().DeleteCards(cardsToDelete);
            
            UpdateDeckDisplay(_rtfCards);
        }
        else
        {
            MessageBox.Show("No cards are selected!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnTagCards_Click(object sender, EventArgs e)
    {
        var selectedCards = dataGridDecks.SelectedRows;

        if (selectedCards.Count is not 0)
        {
            var cardsToTag = new int[selectedCards.Count];
            var maxIndex = selectedCards.Count - 1;


            foreach (DataGridViewRow card in selectedCards)
            {
                cardsToTag[maxIndex] = (int)card.Cells[dataGridDecks.Columns["Id"].Index].Value;
                _rtfCards = _rtfCards.ToList().Where(card => card.Id != cardsToTag[maxIndex]).ToArray();
                maxIndex--;
            }

            // Opens form that allows the user to apply existing tags to cards or add their own new tags to cards
            using (var ta = new TagAdderForm(_currentUser, cardsToTag))
            {
                ta.ShowDialog();
            }

            // If a tag has been added, then the selection of deck choices needs to be updated to reflect this change
            if (doesDeckDisplayNeedRefreshing)
            {
                cmbBoxCurrentDeck_TextChanged(null, EventArgs.Empty);
                doesDeckDisplayNeedRefreshing = false;
            }
        }
        else
        {
            MessageBox.Show("Action cannot be performed! No cards are selected!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }

    private void btnDeleteTags_Click(object sender, EventArgs e)
    {
        using (var tfs = new TagSelectionForm(_currentUser, false))
        {
            tfs.ShowDialog();
        }

        if (tagsToDelete.IsNullOrEmpty() is false)
        {
            // Gets the ids of tags selected by the user
            var selectedTagIDs = new TagService().GetTagIds(_currentUser.Id, tagsToDelete);

            // These ids are used to delete tag records in the database
            new TagService().DeleteTags(selectedTagIDs);

            MessageBox.Show($" Tags '{string.Join(", ", tagsToDelete)}' have been deleted!");
            tagsToDelete = Array.Empty<string>();
            cmbBoxCurrentDeck_TextChanged(null, EventArgs.Empty);
        }

    }

    private void btnRemoveTags_Click(object sender, EventArgs e)
    {
        var selectedCards = dataGridDecks.SelectedRows;

        if (selectedCards.Count is not 0)
        {
            var cards = new int[selectedCards.Count];
            var maxIndex = selectedCards.Count - 1;


            foreach (DataGridViewRow card in selectedCards)
            {
                cards[maxIndex] = (int)card.Cells[dataGridDecks.Columns["Id"].Index].Value;
                _rtfCards = _rtfCards.ToList().Where(card => card.Id != cards[maxIndex]).ToArray();
                maxIndex--;
            }

            // Removes all tags attached to each card
            new TagService().RemoveTags(cards);
            MessageBox.Show("All tags removed from selected cards!");

            cmbBoxCurrentDeck_TextChanged(null, EventArgs.Empty);
        }
        else
        {
            MessageBox.Show("No cards are selected!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void InitiateDeckList()
    {
        // Adds the names of decks owned by the user to filter cards by deck
        cmbBoxCurrentDeck.Items.AddRange(new DeckService().GetDeckNames(_currentUser.Id));
    }

    private void UpdateDeckDisplay(Card[] cards)
    {
        dataGridDecks.Columns.Clear();
        boxCardFront.Clear();
        boxCardBack.Clear();

        // Prevents an error from occuring if an empty array of cards is provided
        if (!cards.IsNullOrEmpty())
        {
            // Sets the data source of the data grid to the rtf-free version of the cards
            dataGridDecks.DataSource = TranslateRtf(cards).ToArray();

            // These columns are hidden, as the user does not need to see them
            dataGridDecks.Columns["Schedule"].Visible = false;
            dataGridDecks.Columns["ScheduleReviewInterval"].Visible = false;
            dataGridDecks.Columns["Id"].Visible = false;

            // 'ScheduleDueDate' column is given a more approriate heading
            dataGridDecks.Columns["ScheduleDueDate"].HeaderText = "Due date";

            // Selects the 1st row of the deck selection automatically
            dataGridDecks.CurrentCell = dataGridDecks.Rows[0].Cells[1];
        }
    }

    private Card[] TranslateRtf(ReadOnlySpan<Card> cards)
    {
        // A span of Card objects is created to store each translated card
        var temp = new Span<Card>(new Card[cards.Length]);

        using (RichTextBox rtb = new RichTextBox())
        {
            for (int i = 0; i < cards.Length; i++)
            {
                // Converts the rtf code into plaintext using a RichTextBox
                rtb.Rtf = cards[i].Front;
                var front = rtb.Text;
                rtb.Rtf = cards[i].Back;
                var back = rtb.Text;

                // A new card object is created and stored in the temporary span
                temp[i] = new Card(cards[i].Id, front, back, cards[i].State)
                {
                    Schedule = cards[i].Schedule
                };
            }
        }

        return temp.ToArray();
    }

    private void UpdateCardDisplay()
    {
        // Index of the selected row is used to find the front and back of the corresponding card in the list of rtfCards
        if (dataGridDecks.CurrentRow is not null)
        {
            // Used to allow images to render properly
            boxCardFront.ReadOnly = false;
            boxCardBack.ReadOnly = false;

            var selectedCardId = (int)dataGridDecks.CurrentRow.Cells[dataGridDecks.Columns["Id"].Index].Value;
            
            // Gets the first card with the selected card id.
            // This will only be 1 card, as each card has its own unique id.
            // Default is set to null for error-handling purposes
            var card = _rtfCards.FirstOrDefault<Card>(card => card.Id == selectedCardId, null);

            if (card is not null)
            {
                (boxCardFront.Rtf, boxCardBack.Rtf) = (card.Front, card.Back);

                boxTags.Text =
                    string.Join("; ",
                    new TagService().GetTags(_currentUser.Id, card.Id));
            }
            else
            {
                // Ensures errors are handled by making the display blank by default
                boxCardFront.Clear();
                boxCardBack.Clear();
            }

            // Used to allow images to render properly
            boxCardFront.ReadOnly = true;
            boxCardBack.ReadOnly = true;
        }
    }


    // Filters the deck display based on state ('NEW', 'LEARNING', 'REVIEW', 'DUE') and/or tags.
    // Then the deck display is filtered based on a search term
    private Card[] FilterCardChoices(ReadOnlySpan<Card> cardChoices)
    {
        if (_activeFilters.Count is not 0)
        {
            var Fframe = new FilterFrame(cardChoices, _activeFilters.ToArray(),
                _currentUser.Id, cmbBoxCurrentDeck.Text, selectedTags);
            cardChoices = new CardService().FilterCards(Fframe);
        }

        return SearchCardChoices(cardChoices);
    }

    private Card[] SearchCardChoices(ReadOnlySpan<Card> cardChoices)
    {
        // If a search term has been provided
        if (boxSearch.Text.Length is not 0)
        {
            var temp = TranslateRtf(cardChoices).Where(
                card => card.Front.ToLowerInvariant().Contains(boxSearch.Text.ToLowerInvariant())
                || card.Back.ToLowerInvariant().Contains(boxSearch.Text.ToLowerInvariant()))
                .Select(card => card.Id)
                .ToArray();

            // Since arrays are reference types, creating a copy of the array helps to stop potential logic errors that might unfold from accidentally changin the array's value
            return CopyCardsFrom(cardChoices).Where(card => temp.Contains(card.Id)).ToArray();
        }

        return cardChoices.ToArray();
    }

    private void SelectFilter(Button filterButton, ReadOnlySpan<char> filter)
    {
        filterButton.Enabled = false;
        btnRemoveFilters.Enabled = true;
        _activeFilters.Add(filter.ToString());
    }

    private void ProcessFilter()
    {
        _rtfCards = FilterCardChoices(_rtfCards);
        UpdateDeckDisplay(_rtfCards);
    }

    private Card[] CopyCardsFrom(ReadOnlySpan<Card> cards)
    {
        // A temporary span of card objects is created to act as the copy array
        var temp = new Span<Card>(new Card[cards.Length]);

        using (RichTextBox rtb = new RichTextBox())
        {
            for (int i = 0; i < cards.Length; i++)
            {
                // A new card object is created and stored in the temporary span
                temp[i] = new Card(cards[i].Id, cards[i].Front, cards[i].Back, cards[i].State)
                {
                    Schedule = cards[i].Schedule
                };
            }
        }

        return temp.ToArray();
    }

    private void boxSearch_KeyUp(object sender, KeyEventArgs e)
    {
        // If the search box is left empty
        if (boxSearch.Text.Length is not 0)
        {
            var searchResult = SearchCardChoices(_rtfCards);
            UpdateDeckDisplay(searchResult);
        }
        else
        {
            // Deck display is refreshed to ensure the deck choices are correct
            cmbBoxCurrentDeck_TextChanged(null, EventArgs.Empty);
        }
    }

    private void btnEditCard_Click(object sender, EventArgs e)
    {
        if (dataGridDecks.CurrentRow is not null)
        {
            var selectedCardId = (int)dataGridDecks.CurrentRow.Cells[dataGridDecks.Columns["Id"].Index].Value;
            var card = _rtfCards.FirstOrDefault<Card>(card => card.Id == selectedCardId, null);

            // Opens a form to allow users to edit 1 of their existing cards
            using (var cef = new CardEditorForm(card, cmbBoxCurrentDeck.Text, _currentUser))
            {
                cef.ShowDialog();
            }

            // Deck display is refreshed if a card has been edited
            if (doesDeckDisplayNeedRefreshing)
            {
                cmbBoxCurrentDeck_TextChanged(null, EventArgs.Empty);
                doesDeckDisplayNeedRefreshing = false;
            }
        }
    }
}
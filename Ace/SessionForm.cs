using Main_System.DataAccess.Services;
using Main_System.Objects;
namespace Main_System;

public partial class SessionForm : Form
{
    // These data structures are used to store cards throughout the session.
    // Which contains what depends on the difficulty of the card, which the user states through button presses.
    private Stack<Card> _cards, _learningCards = new Stack<Card>();
    private PriorityQueue<Card, int> _trickyCards = new PriorityQueue<Card, int>();

    public SessionForm(ReadOnlySpan<Card> cards, ReadOnlySpan<char> deck, Account currentUser)
    {
        InitializeComponent();
        _cards = new Stack<Card>(cards.ToArray()); // all due cards from a certain deck
        this.Text = deck.ToString();
    }

    private void SessionForm_Load(object sender, EventArgs e)
    {
        GetNextCard();
    }

    private void btnRevealAnswer_Click(object sender, EventArgs e)
    {
        boxCardBack.Rtf = _cards.Peek().Back;
        btnRevealAnswer.Hide();
        ShowDifficultyScale();
    }
    private void btn1_Click(object sender, EventArgs e)
    {
        /* Too easy
         * - if the card is a new card, then the card is set to a learning card
         * - if the card is not a new card, then the card is scheduled
         */

        if (_cards.Peek().State is "NEW")
        {
            var card = _cards.Pop();
            card.State = "LEARNING";
            _learningCards.Push(card);
        }
        else
        {
            new CardService().ScheduleCard(_cards.Pop(), 1);
        }

        GetNextCard();
    }

    private void btn2_Click(object sender, EventArgs e)
    {
        /* Easy
         * - if the card is a new card, then the card is set to a learning card
         * - if the card is not a new card, then the card is scheduled
         */

        if (_cards.Peek().State is "NEW")
        {
            var card = _cards.Pop();
            card.State = "LEARNING";
            _learningCards.Push(card);
        }
        else
        {
            new CardService().ScheduleCard(_cards.Pop(), 2);
        }

        GetNextCard();
    }

    private void btn3_Click(object sender, EventArgs e)
    {
        /* Hard
         * - the card is placed on a priority queue and given a low priority
         */

        _trickyCards.Enqueue(_cards.Pop(), 2);
        GetNextCard();
    }

    private void btn4_Click(object sender, EventArgs e)
    {
        /* Difficult
         * - the card is placed on a priority queue and given a high priority
         */

        _trickyCards.Enqueue(_cards.Pop(), 1);
        GetNextCard();
    }

    // Displays the front of the card to the user (the back is revealed once the user presses the 'Reveal answer' button)
    private void DisplayCard(Card card)
    {
        (boxCardFront.Rtf, boxCardBack.Rtf) = (card.Front, string.Empty);
        label5.Text = $"Normal: {_cards.Count} + Difficult: {_trickyCards.Count} + Learning: {_learningCards.Count}";
    }

    // Shows difficulty ranking buttons to user
    private void ShowDifficultyScale()
    {
        btn1.Show();
        btn2.Show();
        btn3.Show();
        btn4.Show();
    }

    // Hides difficulty ranking buttons from user
    private void HideDifficultyScale()
    {
        btn1.Hide();
        btn2.Hide();
        btn3.Hide();
        btn4.Hide();
    }

    // Loads the next card in the deck if possible
    private void GetNextCard()
    {
        var rng = new Random().Next(0, 101);
        label6.Text = $"RNG value: {rng.ToString()}";

        // 75% chance of getting a tricky cards
        if (rng >= 15 && rng <= 90 && _trickyCards.Count is not 0)
        {
            _cards.Push(_trickyCards.Dequeue());
        }

        // 10% chance of getting a learning card
        else if (rng > 90 && _learningCards.Count is not 0)
        {
            _cards.Push(_learningCards.Pop());
        }

        if (_cards.Count is not 0)
        {
            DisplayCard(_cards.Peek());
            label1.Text = $"{_cards.Peek().State}";
            btnRevealAnswer.Show();
            HideDifficultyScale();
        }
        else
        {
            if (_trickyCards.Count is not 0)
            {
                _cards.Push(_trickyCards.Dequeue());
                DisplayCard(_cards.Peek());
                label1.Text = $"{_cards.Peek().State}";
                btnRevealAnswer.Show();
                HideDifficultyScale();
            }
            else if (_learningCards.Count is not 0)
            {
                _cards.Push(_learningCards.Pop());
                DisplayCard(_cards.Peek());
                label1.Text = $"{_cards.Peek().State}";
                btnRevealAnswer.Show();
                HideDifficultyScale();
            }
            else
            {
                MessageBox.Show("Session Completed!", "Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
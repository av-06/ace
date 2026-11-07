using Main_System.Objects;
using Main_System.DataAccess.Services;
namespace Main_System.DataAccess.Operators;

public class CardFilterer
{    
    private readonly FilterFrame _Fframe;

    public CardFilterer(FilterFrame Fframe)
    {
        _Fframe = Fframe;
    }

    public Card[] Filter()
    {
        // If any tags have been applied
        if (_Fframe.ActiveFilters.Contains("TAG"))
        {
            _Fframe.Cards = FilterTags(_Fframe.OwnerId, _Fframe.Deck, _Fframe.Tags);
        }

        // If the card is in the 'NEW' state (i.e. a fresh card)
        if (_Fframe.ActiveFilters.Contains("NEW"))
        {
            _Fframe.Cards = ExtractCardsByState(_Fframe.Cards, "NEW");
        }

        // If the card is in the 'LEARNING' state (i.e. a card that has yet to be completed)
        if (_Fframe.ActiveFilters.Contains("LEARNING"))
        {
            _Fframe.Cards = ExtractCardsByState(_Fframe.Cards, "LEARNING");
        }

        // If the card is in the 'REVIEW' state (i.e. a card that is not due yet but has been completed)
        if (_Fframe.ActiveFilters.Contains("REVIEW"))
        {
            _Fframe.Cards = ExtractCardsByState(_Fframe.Cards, "REVIEW");
        }

        // If the card is in the 'DUE' state (i.e. a card that is due OR was due before a certain date)
        if (_Fframe.ActiveFilters.Contains("DUE"))
        {
            _Fframe.Cards = ExtractCardsByState(_Fframe.Cards, "REVIEW");
        }

        return _Fframe.Cards.ToArray();
    }

    // Filters the array to only contain cards with TAGS CHOSEN BY THE USER
    private Card[] FilterTags(int ownerId, ReadOnlySpan<char> deck, ReadOnlySpan<string> tags)
    {
        if (string.Equals(deck.ToString(), "All", StringComparison.OrdinalIgnoreCase))
        {
            // Gets all cards owned by the user with the specified tags
            return new CardService().GetCards(ownerId, tags);
        }
        else
        {
            // Gets cards from a specific deck owned by the user with the specified tags
            return new CardService().GetCards(ownerId, deck, tags);
        }
    }

    // Extracts the cards in a specific state from a collection of cards
    private Card[] ExtractCardsByState(IEnumerable<Card> cards, ReadOnlySpan<char> aState)
    {
        var state = aState.ToString();

        // Returns an array of cards, each of which has a state that is equal to the state given
        return cards.Where(card => string.Equals(card.State, state, StringComparison.OrdinalIgnoreCase))
            .ToArray();
    }
}
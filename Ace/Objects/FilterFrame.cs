namespace Main_System.Objects;

public class FilterFrame
{
    public Card[] Cards { get; set; }
    public string[] ActiveFilters { get; private set; }
    public string[] Tags { get; private set; }
    public int OwnerId { get; private set; }
    public string Deck { get; private set; }

    public FilterFrame(ReadOnlySpan<Card> cards, ReadOnlySpan<string> activeFilters,
        int ownerId, ReadOnlySpan<char> deckName,
        ReadOnlySpan<string> aTags)
    {
        this.Cards = cards.ToArray();
        this.ActiveFilters = activeFilters.ToArray();
        this.OwnerId = ownerId;
        this.Deck = deckName.ToString();
        this.Tags = aTags.ToArray();
    }
}

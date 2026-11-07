using System.ComponentModel.DataAnnotations.Schema;
namespace Main_System.Objects;

public class SharedDeck : Deck
{
    [Column("Sender_Id")]
    public int SenderId { get; private set; } 

    public SharedDeck(int aSenderId)
    {
        this.SenderId = aSenderId;
    }

    public SharedDeck() { } // Needed for Dapper to work
}
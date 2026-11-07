using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Main_System.Objects;

public class Deck
{
    [Key]
    [Column("Deck_Id")]
    public int Id { get; private set; }

    [Column("Deck_Name")]
    public string Name { get; private set; }

    [Column("Deck_Description")]
    public string Description { get; private set; }

    [Column("Deck_Owner")]
    public int OwnerId { get; private set; }

    public Deck(ReadOnlySpan<char> name, ReadOnlySpan<char> description, int ownerId)
    {
        this.Name = name.ToString();
        this.Description = description.ToString();
        this.OwnerId = ownerId;
    }
    
    public Deck() { } // Needed for dapper to work
}
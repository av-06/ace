using System.ComponentModel.DataAnnotations.Schema;
namespace Main_System.Objects;

public class CardSchedule
{
    [Column("Card_ReviewInterval")]
    public double ReviewInterval { get; private set; }

    [Column("Card_DueDate")]
    public string DueDate { get; private set; }

    public CardSchedule(double reviewInterval, string dueDate) 
    { 
        this.ReviewInterval = reviewInterval;
        this.DueDate = dueDate;
    }

    public CardSchedule() { } // Needed for Dapper to work
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Main_System.Objects;

public class Card
{
    [Key]
    [Column("Card_Id")]
    public int Id { get; set; }

    [Column("Card_Front")]
    public string Front { get; set; }

    [Column("Card_Back")]
    public string Back { get; set; }

    [Column("Card_State")]
    public string State { get; set; }

    public CardSchedule Schedule { get; set; }

    public string ScheduleDueDate 
    { 
        get {
            return (Schedule.DueDate is null) ?
                string.Empty
                : Schedule.DueDate.Substring(0, 10); }
    }

    public double ScheduleReviewInterval { get { return Schedule.ReviewInterval; } }

    public Card(int id, ReadOnlySpan<char> front, ReadOnlySpan<char> back, ReadOnlySpan<char> state)
    {
        this.Id = id;
        this.Front = front.ToString();
        this.Back = back.ToString();
        this.State = state.ToString();
    }

    // This overload can be used to create a card with its schedule rather than assigning its schedule later on
    public Card(int id, ReadOnlySpan<char> front, ReadOnlySpan<char> back, ReadOnlySpan<char> state,
        CardSchedule schedule)
    {
        this.Id = id;
        this.Front = front.ToString();
        this.Back = back.ToString();
        this.State = state.ToString();
        this.Schedule = schedule;
    }

    public Card() { } // Needed for Dapper to work
}

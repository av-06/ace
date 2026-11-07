using System.Globalization;
using Main_System.Objects;
namespace Main_System.DataAccess.Operators;

public class CardScheduler
{
    /* The new schedule mainly depends on the following factors:
     * 1. The difficulty inputted by the user
     * 2. The old review interval of the card (how long before the next review of the card)
     * 3. The old due date of the card
     * 4. The card state (NEW, LEARNING, DUE, REVIEW)
     * 5. How overdue the card is
     */

    // Factor 4 involves preventing new cards from being scheduled.
    // Only completed learning and review cards can be scheduled.

    public CardSchedule CalculateNewSchedule(Card card, byte difficulty)
    {
        var newReviewInterval = CalculateNewReviewInterval(card.ScheduleReviewInterval, difficulty);
        var newDueDate = CalculateNewDueDate(card.ScheduleDueDate, newReviewInterval, difficulty);

        return new CardSchedule(newReviewInterval, newDueDate);
    }

    // New review interval depends on factors 1 and 2
    private double CalculateNewReviewInterval(double oldReviewInterval, byte difficulty)
    {
        return difficulty switch
        {
            1 => oldReviewInterval * 1.5, // Too easy - interval increased by 50%
            2 => oldReviewInterval * 1.1, // Easy - increase its interval by 10%
            _ => 0 // Hard/Difficult - reset interval (this is a default in case a different difficulty is passed to this subroutine)
        };
    }


    // New due date depends on the new review interval and factors 1, 3 and 5
    private string CalculateNewDueDate(string oldDueDate, double newReviewInterval, byte difficulty)
    {
        // New review interval is added onto the current date
        var newDueDate = DateTime.Today.AddDays(newReviewInterval);
        var overdueFactor = 0.0;

        // If the card's due date is not null (card has not been completed before), the overdue factor must be calculated
        if (oldDueDate is not null)
        {
            overdueFactor = CalculateOverdueFactor(
                DateTime.ParseExact(oldDueDate, "MM/dd/yyyy", CultureInfo.InvariantCulture),
                newDueDate, difficulty);
        }

        // Overdue factor is added to the new due date calculated
        return newDueDate.AddDays(overdueFactor).ToString();
    }

    private double CalculateOverdueFactor(DateTime oldDueDate, DateTime newDueDate, byte difficulty)
    {
        // If the card is overdue
        if (oldDueDate.Date < DateTime.Today.Date)
        {
            var numOfDaysMissed = (DateTime.Today.Date - oldDueDate.Date).TotalDays;

            return difficulty switch
            {
                1 => numOfDaysMissed * 2, // Too easy
                2 => numOfDaysMissed * 3, // Easy
                _ => 0.0 // Hard/Difficult - this is a default in case a different difficulty is passed to this subroutine
            };

        }

        // If the card is not actually overdue
        return 0.0;
    }
}

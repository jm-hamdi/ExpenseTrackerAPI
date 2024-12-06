namespace ExpenseTrackerAPI.Models
{
    public class Budget
    {
        public int Id { get; set; }
        public decimal MonthlyBudget { get; set; }
        public int UserId { get; set; } // Optional for multi-user support
    }
}

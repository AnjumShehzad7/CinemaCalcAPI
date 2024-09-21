namespace CinemaCalcAPI.Models
{
    public class Expense
    {
        public int Id { get; set; }  // Unique identifier for the expense
        public string Name { get; set; } = string.Empty;  // Name of the expense
        public decimal Price { get; set; }  // Base price of the expense
        public decimal PercentageMarkup { get; set; }  // Markup percentage applied to the base price
        
        // Total price after applying the percentage markup
        public decimal TotalPrice 
        { 
            get 
            { 
                return Price + (Price * PercentageMarkup / 100); 
            }
        }
    }
}

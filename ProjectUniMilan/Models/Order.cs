namespace ProjectUniMilan.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public List<FoodItem> Items { get; set; }
        
    }
}

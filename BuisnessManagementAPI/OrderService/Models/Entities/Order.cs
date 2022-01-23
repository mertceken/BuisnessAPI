namespace OrderService.Models.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public int CustomerID { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public string Status { get; set; }

        public string Address { get; set; }

        public string Product { get; set; }

        public string CreatedTime { get; set; }

        public string UpdatedTime { get; set; }
    }
}

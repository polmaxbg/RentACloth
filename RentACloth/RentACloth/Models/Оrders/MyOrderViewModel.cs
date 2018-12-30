namespace RentACloth.Models.Оrders
{
    public class MyOrderViewModel
    {
        public int Id { get; set; }

        public decimal TotalPrice { get; set; }

        public int Quantity { get; set; }

        public string ProductPrice { get; set; }
        public int ProductId { get; set; }

        public string ProductName { get; set; }
    }
}
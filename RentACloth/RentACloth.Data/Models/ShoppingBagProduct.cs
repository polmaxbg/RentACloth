namespace RentACloth.Data.Models
{
    public class ShoppingBagProduct
    {
        public ShoppingBag ShoppingBag { get; set; }
        public int ShoppingBagId{ get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
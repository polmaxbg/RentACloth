namespace RentACloth.Controllers
{
    public class ConfirmOrderViewModel
    {
        public decimal TotalPrice { get; set; }

        public decimal DeliveryPrice { get; set; }

        public string Recipient { get; set; }

        public string PhoneNumber { get; set; }

        public string DeliveryAddressDescription { get; set; }

        public string DeliveryAddressStreet { get; set; }

        public string DeliveryAddressCityName { get; set; }
    }
}
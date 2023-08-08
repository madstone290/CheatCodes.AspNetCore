namespace CheatCodes.AspNetCore.DevReport.Models
{
    public class Receipt
    {
        public Receipt() { }
        public Receipt(int id, string customer, string item, int quantity, int unitPrice, int totalPrice)
        {
            Id = id;
            Customer = customer;
            Item = item;
            Quantity = quantity;
            UnitPrice = unitPrice;
            TotalPrice = totalPrice;
        }

        public int Id { get; set; }
        public string Customer { get; set; }
        public string Item { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
        public int TotalPrice { get; set; }
    }
}

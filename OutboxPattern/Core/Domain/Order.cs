namespace OutboxPattern.Core.Domain
{
    public class Order
    {
        public int Id { get; private set; }
        public string CustomerName { get; private set; }
        public string Address { get; private set; }
        public string Product { get; private set; }

        public static Order Create(string customerName, string address, string product)
        {
            return new Order()
            {
                CustomerName = customerName,
                Address = address,
                Product = product
            };
        }

        protected Order()
        {
        }
    }
}

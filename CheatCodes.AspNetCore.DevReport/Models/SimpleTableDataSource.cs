namespace CheatCodes.AspNetCore.DevReport.Models
{
    public class SimpleTableDataSource
    {

        public SimpleTableDataSource()
        {
            Orders = new List<Order>();
            Orders.AddRange(new OrderDataSource());

            ReportDate = System.DateTime.Now;
            Reporter = "John Doe";
            ReportName = "Simple Table Report";

            OrderTitle = "Order List";
        }

        public DateTime ReportDate { get; set; }
        public string Reporter { get; set; }
        public string ReportName { get; set; }

        
        public string OrderTitle { get; set; }
        public List<Order> Orders { get; set; }
        
    }
}

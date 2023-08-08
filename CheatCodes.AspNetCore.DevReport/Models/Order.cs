using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheatCodes.AspNetCore.DevReport.Models
{
    public class Order
    {
        public Order()
        {
            Price = new Random().Next(100, 1000);
        }
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string ShipCountry { get; set; }
        public string ShipCity { get; set; }
        public int Price { get; set; }
    }
}

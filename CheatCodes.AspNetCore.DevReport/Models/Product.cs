using System.Drawing;

namespace CheatCodes.AspNetCore.DevReport.Models
{
    public class Product
    {
        public Product() { }
        public Product(int categoryID, bool discontinued, string ean13, int supplierID, int productID, string productName, double unitPrice, string quantityPerUnit, int reorderLevel, int unitsInStock, int unitsOnOrder)
        {
            this.CategoryID = categoryID;
            this.Discontinued = discontinued;
            this.EAN13 = ean13;
            this.SupplierID = supplierID;
            this.ProductID = productID;
            this.ProductName = productName;
            this.UnitPrice = unitPrice;
            this.QuantityPerUnit = quantityPerUnit;
            this.ReorderLevel = reorderLevel;
            this.UnitsInStock = unitsInStock;
            this.UnitsOnOrder = unitsOnOrder;

            if(CategoryID % 2 == 0)
            {
                ProductColor = Color.FromArgb(214, 63, 60);
            }
            else if(CategoryID == 0 || CategoryID % 3 == 0)
            {
                ProductColor = Color.FromArgb(100, 150, 194);
            }
            else
            {
                ProductColor = Color.FromArgb(230, 138, 60);
            }
        }
        public int CategoryID { get; set; }
        public bool Discontinued { get; set; }
        public string EAN13 { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        public int ReorderLevel { get; set; }
        public int SupplierID { get; set; }
        public double UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitsOnOrder { get; set; }
        public Color ProductColor { get; set; } = Color.AliceBlue;
    }
}

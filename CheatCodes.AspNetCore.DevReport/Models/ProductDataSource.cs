namespace CheatCodes.AspNetCore.DevReport.Models
{
    public class ProductDataSource : List<Product>
    {
        public ProductDataSource()
        {
            List<Product> products = new List<Product>() {
                new Product(1,false,"070684900070",1,1,"Outback Lager",15.00,"",0,0,0),
                new Product(1,false,"070684900064",2,2,"Wimmers gute Semmelknödel",33.25,"",0,0,0),
                new Product(1,false,"070684900056",3,3,"Gnocchi di nonna Alice",38.00,"",0,0,0),
                new Product(3,false,"070684900050",4,4,"Valkoinen suklaa",16.25,"",0,0,0),
                new Product(2,false,"070684900040",5,5,"Boston Crab Meat",18.40,"",0,0,0),
                new Product(3,false,"070684900027",6,6,"Schoggi Schokolade",43.90,"",0,0,0),
                new Product(3,false,"070684900025",7,7,"NuNuCa Nuß-Nougat-Creme",14.00,"",0,0,0),
                new Product(2,false,"070684900011",8,8,"Queso Cabrales",21.00,"",0,0,0),
                new Product(1,false,"070684900075",9,9,"Rhönbräu Klosterbier",7.75,"",0,0,0),
                new Product(2,false,"070684900061",10,10,"Sirop d'érable",28.50,"",0,0,0),
                new Product(1,false,"070684900052",11,11,"Filo Mix",7.00,"",0,0,0),
                new Product(3,false,"070684900048",12,12,"Chocolade",12.75,"",0,0,0),
                new Product(1,false,"070684900043",13,13,"Ipoh Coffee",46.00,"",0,0,0),
                new Product(2,false,"070684900037",14,14,"Gravad Iax",26.00,"",0,0,0),
                new Product(2,false,"070684900032",15,15,"Mascarpone Fabioli",32.00,"",0,0,0),
                new Product(1,false,"070684900023",16,16,"Tunnbröd",9.00,"",0,0,0),
                new Product(1,false,"070684900022",17,17,"Gustaf's Knäckebröd",21.00,"",0,0,0),
                new Product(2,false,"070684900006",17,17,"Grandma's Boysenberry Spread",25.00,"",0,0,0),
                new Product(2,false,"070684900003",18,18,"Aniseed Syrup",10.00,"",0,0,0),
                new Product(1,false,"070684900002",19,19,"Chang",19.00,"",0,0,0),
            };
            this.AddRange(products);
        }
    }
}

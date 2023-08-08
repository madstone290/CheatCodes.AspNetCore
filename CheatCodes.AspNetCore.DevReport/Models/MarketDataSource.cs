namespace CheatCodes.AspNetCore.DevReport.Models
{
    public class MarketDataSource : List<Market>
    {
        public MarketDataSource()
        {
            List<Market> sales = new() {
                new Market(0, -1, "Eastern Europe", 22500,21224.25,24580,22697.172,0.62),
                new Market(1, 0, "Belarus", 7315,8240.3475,18800,17480.24,0.34),
                new Market(2, 0, "Bulgaria", 6300,5200.02,2821,4880.0479,0.80),
                new Market(3, 0, "Croatia", 4200,3879.96,3890,4429.932,0.29),
                new Market(4, 0, "Czech Republic", 19500,16229.85,15340,14979.51,0.13),
                new Market(5, 0, "Hungary", 13495,10245.404,13900,9560.42,0.14),
                new Market(6, 0, "Poland", 8930,12200.166,9440,12150.224,0.52),
                new Market(7, 0, "Romania", 4900,5241.04,5100,6284.22,0.3),
                new Market(8, 0, "Russia", 22500,21224.25,24580,22697.172,0.85),

                new Market(18, -1, "North America", 31400,30301,32800,31940.64,0.84),
                new Market(19, 18, "Canada", 25390,5199.872,27000,6879.6,0.64),
                new Market(20, 18, "USA", 31400,30301,32800,31940.64,0.87),

                new Market(30, -1, "Asia", 20388,22500.1968,22547,25755.4381,0.52),
                new Market(31, 30, "China",20388,22500.1968,22547,25755.4381,0.82 ),
                new Market(32, 30, "India", 4642,4200.0816,5320,6470.184,0.44),
                new Market(33, 30, "Japan", 9457,8300.4089,12859,8732.5469,0.7),

                new Market(43, -1, "South America", 16380,15400.476,17590,16680.597,0.32),
                new Market(44, 43, "Argentina", 16380,15400.476,17590,16680.597,0.88),
                new Market(45, 43, "Brazil", 4560,3900.168,9480,6100.38,0.1),

                new Market(55, -1, "Western Europe", 30540, 32219.7,33000, 35501.4,0.7),
                new Market(56, 55, "Austria", 22000, 26120.6, 28000, 28501.2,0.92),
                new Market(57, 55, "Belgium", 13000, 14500.2, 9640, 11199.752,0.16),
                new Market(58, 55, "Denmark", 21000, 17119.2, 18100, 15500.84,0.56),
                new Market(59, 55, "Finland", 17000, 18120.3, 17420, 19200.34,0.44),
                new Market(60, 55, "France", 23020, 20119.48, 27000, 24200.1,0.51),
                new Market(61, 55, "Germany", 30540, 32219.7,33000, 35501.4,0.93),
                new Market(62, 55, "Greece", 15600, 11500.32,13200 ,10999.56 ,0.11),
                new Market(63, 55, "Ireland", 9530, 12619.626, 10939, 12990.0625,0.34),
                new Market(64, 55, "Italy", 17299, 14119.4438,19321 ,15945.6213 ,0.22),
                new Market(65, 55, "Netherlands", 8902, 7400.2326, 9214,9600.0666,0.85),
                new Market(66, 55, "Norway", 5400,5200.2 , 7310,6880.172 ,0.7),
                new Market(67, 55, "Portugal", 9220, 4100.134, 4271,3880.2035 ,0.5),
                new Market(68, 55, "Spain", 12900,14299.65 , 10300,14899.98 ,0.82),
                new Market(69, 55, "Switzerland", 9323, 7273.971, 10730, 9399.48,0.14),
                new Market(70, 55, "United Kingdom", 14580,15199.65 , 13967, 16900.07,0.91),
            };
            this.AddRange(sales);
        }
    }
}

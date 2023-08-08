namespace CheatCodes.AspNetCore.DevReport.Models
{
    public class ReceiptSummaryDataSource
    {

        public static ReceiptSummaryDataSource Demo()
        {
            ReceiptSummaryDataSource ds = new ReceiptSummaryDataSource();
            ds.ReceiptSummaries = new List<ReceiptSummary>()
            {
                new ReceiptSummary(2019, 1, new List<Receipt>()
                {
                    new Receipt(1, "Jack Doe", "Apple", 10, 100, 1000),
                    new Receipt(2, "John Doe", "Orange", 20, 200, 4000),
                    new Receipt(3, "Bruce waine", "Apple", 10, 100, 1000),
                    new Receipt(4, "John Doe", "Orange", 20, 200, 4000),
                }),
                new ReceiptSummary(2019, 2, new List<Receipt>()
                {
                    new Receipt(11, "John Doe", "Apple", 10, 100, 1000),
                    new Receipt(12, "Acv Jik", "Orange", 20, 200, 4000),
                    new Receipt(13, "John Doe", "Apple", 10, 100, 1000),
                    new Receipt(14, "Kilm Doe", "Orange", 20, 200, 4000),
                }),
                new ReceiptSummary(2020, 3, new List<Receipt>()
                {
                    new Receipt(21, "John Doe", "Apple", 10, 100, 1000),
                    new Receipt(22, "John Doe", "Orange", 20, 200, 4000),
                    new Receipt(23, "John Doe", "Apple", 10, 100, 1000),
                    new Receipt(24, "John Doe", "Orange", 20, 200, 4000),
                }),
                new ReceiptSummary(2020, 4, new List<Receipt>()
                {
                    new Receipt(31, "John Doe", "Apple", 10, 100, 1000),
                    new Receipt(32, "John Doe", "Orange", 20, 200, 4000),
                    new Receipt(33, "John Doe", "Apple", 10, 100, 1000),
                    new Receipt(34, "John Doe", "Orange", 20, 200, 4000),
                }),
            };

            return ds;
        }

        public List<ReceiptSummary> ReceiptSummaries { get; set; }
    }
}

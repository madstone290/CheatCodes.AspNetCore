namespace CheatCodes.AspNetCore.DevReport.Models
{
    public class ReceiptSummary
    {
        public ReceiptSummary() { }
        public ReceiptSummary(int year, int month, List<Receipt> receipts)
        {
            Year = year;
            Month = month;
            Receipts = receipts;
        }
        public int Year { get; set; }
        public int Month { get; set; }
        public List<Receipt> Receipts { get; set; }
    }
}

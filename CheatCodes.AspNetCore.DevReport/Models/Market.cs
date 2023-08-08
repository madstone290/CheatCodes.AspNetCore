namespace CheatCodes.AspNetCore.DevReport.Models
{
    public class Market
    {
        public Market(int id,int parentId, string region, double marchSales, double marchSalesPrev, double septemberSales, double septemberSalesPrev, double marketShare)
        {
            RegionID = id;
            ParentID = parentId;
            Region = region;
            MarchSales = marchSales;
            MarchSalesPrev = marchSalesPrev;
            SeptemberSales = septemberSales;
            SeptemberSalesPrev = septemberSalesPrev;
            MarketShare = marketShare;
        }

        public int RegionID { get; set; }
        public int ParentID { get; set; }
        public string Region { get; set; }
        public double MarchSales { get; set; }
        public double MarchSalesPrev { get; set; }
        public double SeptemberSales { get; set; }
        public double SeptemberSalesPrev { get; set; }
        public double MarketShare { get; set; }

        /// <summary>
        /// 첫번째 컬럼의 좌측 패딩값
        /// </summary>
        public int FirstColumnPaddingLeft => ParentID == -1 ? 10 : 50;
    }
}

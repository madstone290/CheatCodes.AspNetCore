namespace CheatCodes.AspNetCore.DevReport.Reports
{
    /**
     * DatailBand.HierarchyPrintOptions 속성을 사용해 계층형 데이터를 출력할 수 있다.
     * Expression을 이용해 계층별로 레이아웃을 조정할 수 있다.
     * ex) 계층별 들여쓰기 Expression. Padding.Left에서
     *  1) Iif([DataSource.CurrentRowHierarchyLevel]== 0, 0, 30)
     *  2) [FirstColumnPaddingLeft]
     * */
    public partial class HierarchyReport : DevExpress.XtraReports.UI.XtraReport
    {
        public HierarchyReport()
        {
            InitializeComponent();
        }
    }
}

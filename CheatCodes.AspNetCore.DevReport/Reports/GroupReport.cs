using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace CheatCodes.AspNetCore.DevReport.Reports
{
    /**
     * DetailReport를 이용해서 DetailBand에 하위 Report를 추가할 수 있다.
     * MasterDetail에 그룹속성을 맵핑하고 SubDetail에 컬렉션 속성을 맵핑한다.
     * ex) MasterDetail에 년/월/일을 맵핑하고 SubDetail에 해당 날짜의 주문 목록을 맵핑한다.
     * */

    public partial class GroupReport : DevExpress.XtraReports.UI.XtraReport
    {
        public GroupReport()
        {
            InitializeComponent();
        }
    }
}

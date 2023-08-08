using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace CheatCodes.AspNetCore.DevReport.Reports
{
    /**
     * DetailBand.MultiColumn 속성을 사용해 라벨 개수를 설정할 수 있다.
     * 텍스트 뿐 아니라 이미지/색상도 바인딩이 가능하다.
     * */

    public partial class LabelReport : DevExpress.XtraReports.UI.XtraReport
    {
        public LabelReport()
        {
            InitializeComponent();
        }
    }
}

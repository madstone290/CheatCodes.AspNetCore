using CheatCodes.AspNetCore.DevReport.Reports;
using DevExpress.XtraReports.UI;
using Microsoft.AspNetCore.Mvc;

namespace CheatCodes.AspNetCore.DevReport.Controllers
{

    [Route("api/[controller]")]
    public class ReportController : Controller {

        [NonAction]
        async Task<IActionResult> ExportToPdfAsync(XtraReport report)
        {
            using var ms = new MemoryStream();
            await report.ExportToPdfAsync(ms);
            return File(ms.ToArray(), System.Net.Mime.MediaTypeNames.Application.Pdf);
        }

        [HttpGet]
        [Route("Label")]
        public async Task<IActionResult> Label()
        {
           return await ExportToPdfAsync(new LabelReport());
        }

        [HttpGet]
        [Route("Hierarchy")]
        public async Task<IActionResult> Hierarchy()
        {
            return await ExportToPdfAsync(new HierarchyReport());
        }

        [HttpGet]
        [Route("Group")]
        public async Task<IActionResult> Group()
        {
            return await ExportToPdfAsync(new GroupReport());
        }



    }
}
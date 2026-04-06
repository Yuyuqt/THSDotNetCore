using Microsoft.AspNetCore.Mvc;
using THSDotNetCore.ChartWebApp.Models;

namespace THSDotNetCore.ChartWebApp.Controllers
{
    public class ApexChartController : Controller
    {
        public IActionResult PieChart()
        {
            ApexChartPieChartModel  model = new ApexChartPieChartModel();
            model.Series= new int[] { 44, 55, 13, 43, 22 };
            model.Labels= new string[] { "Team A", "Team B", "Team C", "Team D", "Team E" };

            return View(model);
        }

        public IActionResult MixedChart()
        {
            MixedChartModel model = new MixedChartModel
            {
                WebsiteBlog = new int[] { 440, 505, 414, 671, 227, 413, 201, 352, 752, 320, 257, 160 },
                SocialMedia = new int[] { 23, 42, 35, 27, 43, 22, 17, 31, 22, 22, 12, 16 },
                Labels = new string[] { "01 Jan 2001", "02 Jan 2001", "03 Jan 2001", "04 Jan 2001", "05 Jan 2001", "06 Jan 2001", "07 Jan 2001", "08 Jan 2001", "09 Jan 2001", "10 Jan 2001", "11 Jan 2001", "12 Jan 2001" }
            };

            return View(model);
        }
    }
}

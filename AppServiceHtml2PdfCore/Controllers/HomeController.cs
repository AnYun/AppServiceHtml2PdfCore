using AppServiceHtml2PdfCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Wkhtmltopdf.NetCore;

namespace AppServiceHtml2PdfCore.Controllers
{
    public class HomeController : Controller
    {
        readonly IGeneratePdf _generatePdf;

        public HomeController(IGeneratePdf generatePdf)
        {
            _generatePdf = generatePdf;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Pdf()
        {
            return await _generatePdf.GetPdf("Views/Home/Pdf.cshtml");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

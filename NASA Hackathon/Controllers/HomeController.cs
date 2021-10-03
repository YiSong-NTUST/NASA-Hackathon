using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NASA_Hackathon.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NASA_Hackathon.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Level1()
        {
            return View();
        }

        public IActionResult Level2()
        {            
            return View(new Level2Model());
        }
        
        [HttpPost]
        public IActionResult Level2(Level2Model model)
        {
            Nuel2Efficacy nuel2Efficacy = new Nuel2Efficacy();
            model.efficacy = nuel2Efficacy.Convert_GMT_to_Efficacy(Convert.ToDouble(model.NeutralizingAntibodies));
            return View(model);
        }

        public IActionResult Level3()
        {
            return View(new Level3Model());
        }

        [HttpPost]
        public IActionResult Level3(string base64image,bool crop)
        {
            double concentration = 0;//濃度
            //影像數組
            string Base64String = base64image.Replace("data:image/jpeg;base64,", String.Empty).Replace("data:image/png;base64,", String.Empty);
            
            byte[] imageBytes = Convert.FromBase64String(Base64String);
            Bitmap bmp;
            using (var ms = new System.IO.MemoryStream(imageBytes))
            {
                bmp = new Bitmap(ms);
            }

            Bitmap target;
            if (crop)
            {
                //截圖試紙部分
                Rectangle cropRect = new Rectangle(60, 160, 80, 15);
                target = new Bitmap(cropRect.Width, cropRect.Height);
                using (Graphics g = Graphics.FromImage(target))
                {
                    g.DrawImage(bmp, new Rectangle(0, 0, target.Width, target.Height),
                                     cropRect,
                                     GraphicsUnit.Pixel);
                }
            }
            else
            {
                target = bmp;
            }

            Level3Model model = new Level3Model();
            
            Antibody antibody = new Antibody(target);
            if (antibody.PeakIntensity.Count >= 2)
            { 
                concentration = antibody.CaculateConcentration(antibody.PeakIntensity[1]);

                model.concentration = concentration.ToString();

                Nuel2Efficacy nuel2Efficacy = new Nuel2Efficacy();
                double efficacy = nuel2Efficacy.Convert_GMT_to_Efficacy(concentration/200.0);

                return Json(new { success = true, responseText = "保護力為: " + efficacy.ToString() + " %" });
            }
            else
            {
                model.concentration = "無抗體濃度";
                return Json(new { success = true, responseText = "無抗體濃度" });
            }     
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

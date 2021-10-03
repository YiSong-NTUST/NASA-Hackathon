using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using NASA_Hackathon.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
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
            Level1Model model = new Level1Model();

            model.date = DateTime.Now;

            List<SelectListItem> brandList = new List<SelectListItem>();
            brandList.Add(new SelectListItem() { Text = "Moderna", Value = "Moderna", Selected = false });
            brandList.Add(new SelectListItem() { Text = "BNT", Value = "BNT", Selected = false });
            brandList.Add(new SelectListItem() { Text = "NOVAVAX", Value = "NOVAVAX", Selected = false });
            brandList.Add(new SelectListItem() { Text = "JandJ", Value = "JandJ", Selected = false });
            brandList.Add(new SelectListItem() { Text = "AZ", Value = "AZ", Selected = false });
            model.brandList = brandList;

            List<SelectListItem> locationList = new List<SelectListItem>();
            locationList.Add(new SelectListItem() { Text = "United States", Value = "美國", Selected = false });
            locationList.Add(new SelectListItem() { Text = "Keelung", Value = "基隆市", Selected = false });
            locationList.Add(new SelectListItem() { Text = "Taipei", Value = "台北市", Selected = false });
            locationList.Add(new SelectListItem() { Text = "NewTaipei", Value = "新北市", Selected = false });
            locationList.Add(new SelectListItem() { Text = "Taoyuan", Value = "桃園市", Selected = false });
            locationList.Add(new SelectListItem() { Text = "Hsinchu County", Value = "新竹縣", Selected = false });
            locationList.Add(new SelectListItem() { Text = "Hsinchu City", Value = "新竹市", Selected = false });
            locationList.Add(new SelectListItem() { Text = "Miaoli County", Value = "苗栗縣", Selected = false });
            locationList.Add(new SelectListItem() { Text = "Miaoli City", Value = "苗栗市", Selected = false });
            locationList.Add(new SelectListItem() { Text = "Taichung", Value = "台中市", Selected = false });
            locationList.Add(new SelectListItem() { Text = "Nantou County", Value = "南投縣", Selected = false });
            locationList.Add(new SelectListItem() { Text = "Nantou City", Value = "南投市", Selected = false });
            locationList.Add(new SelectListItem() { Text = "Changhua County", Value = "彰化縣", Selected = false });
            locationList.Add(new SelectListItem() { Text = "Changhua City", Value = "彰化市", Selected = false });
            locationList.Add(new SelectListItem() { Text = "Yunlin County", Value = "雲林縣", Selected = false });
            locationList.Add(new SelectListItem() { Text = "Chiayi County", Value = "嘉義縣", Selected = false });
            locationList.Add(new SelectListItem() { Text = "Chiayi City", Value = "嘉義市", Selected = false });
            locationList.Add(new SelectListItem() { Text = "Tainan City", Value = "台南市", Selected = false });
            locationList.Add(new SelectListItem() { Text = "Kaohsiung City", Value = "高雄市", Selected = false });
            locationList.Add(new SelectListItem() { Text = "Pingtung County", Value = "屏東縣", Selected = false });
            locationList.Add(new SelectListItem() { Text = "Pingtung City", Value = "屏東市", Selected = false });
            locationList.Add(new SelectListItem() { Text = "Yilan County", Value = "宜蘭縣", Selected = false });
            locationList.Add(new SelectListItem() { Text = "Yilan City", Value = "宜蘭市", Selected = false });
            locationList.Add(new SelectListItem() { Text = "Hualien County", Value = "花蓮縣", Selected = false });
            locationList.Add(new SelectListItem() { Text = "Hualien City", Value = "花蓮市", Selected = false });
            locationList.Add(new SelectListItem() { Text = "Taitung County", Value = "台東縣", Selected = false });
            locationList.Add(new SelectListItem() { Text = "Taitung City", Value = "台東市", Selected = false });
            locationList.Add(new SelectListItem() { Text = "Penghu County", Value = "澎湖縣", Selected = false });
            locationList.Add(new SelectListItem() { Text = "Green Island", Value = "綠島", Selected = false });
            locationList.Add(new SelectListItem() { Text = "Orchid Island", Value = "蘭嶼", Selected = false });
            locationList.Add(new SelectListItem() { Text = "Kinmen County", Value = "金門縣", Selected = false });
            locationList.Add(new SelectListItem() { Text = "Matsu", Value = "馬祖", Selected = false });
            locationList.Add(new SelectListItem() { Text = "Lienchiang County", Value = "連江縣", Selected = false });
            model.locationList = locationList;

            return View(model);
        }

        [HttpPost]
        public IActionResult Level1(Level1Model model)
        {
            DateTime date_1 = model.date;
            DateTime date_2 = DateTime.Now;
            int days = (date_2 - date_1).Days;

            VaccineFactory vaccineFactory = new VaccineFactory(model.vaccineBrand, days);
            Protected protectedpercentage = vaccineFactory.GetProtected();
            double percentage = protectedpercentage.PotectPercentage;

            if(model.vaccinDoses == 1)
            {
                percentage *= 0.6;
            }
            else if(model.vaccinDoses == 3)
            {
                percentage *= 1.2;
            }

            if(percentage > 0.9999)
            {
                percentage = 0.9999;
            }

            percentage = 1.0 - percentage;

            double value = 0.0;
            int count;
            if (model.location == "美國")
            {
                var jsonString = new WebClient().DownloadString("https://sedac.ciesin.columbia.edu/arcgis/rest/services/ciesin/COVID19_Prevalence/MapServer/identify?sr=4326&layers=top&tolerance=3&returnGeometry=true&imageDisplay=975%2C644%2C96&mapExtent=-258.39843750000006%2C-77.2350736549247%2C84.37500000000001%2C70.49557354093137&geometry=%7B%22x%22%3A-89.3315575023633%2C%22y%22%3A40.286230916104216%2C%22spatialReference%22%3A%7B%22wkid%22%3A4326%7D%7D&geometryType=esriGeometryPoint&maxAllowableOffset=0.5322568905279504&f=json");
                JObject jo = JObject.Parse(jsonString);
                value = 1.0 / double.Parse(jo["results"][0]["attributes"]["Cases Per Capita in the last 7 Days"].ToString());                
            }
            else
            {
                ConfirmJsonRead confirmJsonRead = new ConfirmJsonRead("https://od.cdc.gov.tw/eic/Weekly_Age_County_Gender_19CoV.json", true);
                CaseCount caseCount = confirmJsonRead.CaseCount;
                AbroadCaseCount abroadCaseCount = confirmJsonRead.AbroadCaseCount;
                switch (model.location)
                {
                    case "基隆市":
                        count = caseCount.Keelung + abroadCaseCount.Keelung;
                        value = Convert.ToDouble(count) / 365591.0;
                        break;
                    case "台北市":
                        count = caseCount.Taipei + abroadCaseCount.Taipei;
                        value = Convert.ToDouble(count) / 2553798.0;
                        break;
                    case "新北市":
                        count = caseCount.NewTaipei + abroadCaseCount.NewTaipei;
                        value = Convert.ToDouble(count) / 4019898.0;
                        break;
                    case "桃園市":
                        count = caseCount.Taoyuan + abroadCaseCount.Taoyuan;
                        value = Convert.ToDouble(count) / 2272976.0;
                        break;
                    case "新竹縣":
                        count = caseCount.Hsinchu_County + abroadCaseCount.Hsinchu_County;
                        value = Convert.ToDouble(count) / 573858.0;
                        break;
                    case "新竹市":
                        count = caseCount.Hsinchu_City + abroadCaseCount.Hsinchu_City;
                        value = Convert.ToDouble(count) / 452781.0;
                        break;
                    case "苗栗縣":
                        count = caseCount.Miaoli_County + abroadCaseCount.Miaoli_County;
                        value = Convert.ToDouble(count) / 539879.0;
                        break;
                    case "苗栗市":
                        count = caseCount.Miaoli_City + abroadCaseCount.Miaoli_City;
                        value = Convert.ToDouble(count) / 87671.0;
                        break;
                    case "台中市":
                        count = caseCount.Taichung + abroadCaseCount.Taichung;
                        value = Convert.ToDouble(count) / 2818139.0;
                        break;
                    case "南投縣":
                        count = caseCount.Nantou_County + abroadCaseCount.Nantou_County;
                        value = Convert.ToDouble(count) / 487185.0;
                        break;
                    case "南投市":
                        count = caseCount.Nantou_City + abroadCaseCount.Nantou_City;
                        value = Convert.ToDouble(count) / 105173.0;
                        break;
                    case "彰化縣":
                        count = caseCount.Changhua_County + abroadCaseCount.Changhua_County;
                        value = Convert.ToDouble(count) / 1259246.0;
                        break;
                    case "彰化市":
                        count = caseCount.Changhua_City + abroadCaseCount.Changhua_City;
                        value = Convert.ToDouble(count) / 232259.0;
                        break;
                    case "雲林縣":
                        count = caseCount.Yunlin_County + abroadCaseCount.Yunlin_County;
                        value = Convert.ToDouble(count) / 672557.0;
                        break;
                    case "嘉義縣":
                        count = caseCount.Chiayi_County + abroadCaseCount.Chiayi_County;
                        value = Convert.ToDouble(count) / 495662.0;
                        break;
                    case "嘉義市":
                        count = caseCount.Chiayi_City + abroadCaseCount.Chiayi_City;
                        value = Convert.ToDouble(count) / 266005.0;
                        break;
                    case "台南市":
                        count = caseCount.Tainan_City + abroadCaseCount.Tainan_City;
                        value = Convert.ToDouble(count) / 1867554.0;
                        break;
                    case "高雄市":
                        count = caseCount.Kaohsiung_City + abroadCaseCount.Kaohsiung_City;
                        value = Convert.ToDouble(count) / 2753530.0;
                        break;
                    case "屏東縣":
                        count = caseCount.Pingtung_County + abroadCaseCount.Pingtung_County;
                        value = Convert.ToDouble(count) / 807159.0;
                        break;
                    case "屏東市":
                        count = caseCount.Pingtung_City + abroadCaseCount.Pingtung_City;
                        value = Convert.ToDouble(count) / 201125.0;
                        break;
                    case "宜蘭縣":
                        count = caseCount.Yilan_County + abroadCaseCount.Yilan_County;
                        value = Convert.ToDouble(count) / 451635.0;
                        break;
                    case "宜蘭市":
                        count = caseCount.Yilan_City + abroadCaseCount.Yilan_City;
                        value = Convert.ToDouble(count) / 95900.0;
                        break;
                    case "花蓮縣":
                        count = caseCount.Hualien_County + abroadCaseCount.Hualien_County;
                        value = Convert.ToDouble(count) / 322506.0;
                        break;
                    case "花蓮市":
                        count = caseCount.Hualien_City + abroadCaseCount.Hualien_City;
                        value = Convert.ToDouble(count) / 101444.0;
                        break;
                    case "台東縣":
                        count = caseCount.Taitung_County + abroadCaseCount.Taitung_County;
                        value = Convert.ToDouble(count) / 213956.0;
                        break;
                    case "台東市":
                        count = caseCount.Taitung_City + abroadCaseCount.Taitung_City;
                        value = Convert.ToDouble(count) / 104759.0;
                        break;
                    case "澎湖縣":
                        count = caseCount.Penghu_County + abroadCaseCount.Penghu_County;
                        value = Convert.ToDouble(count) / 105645.0;
                        break;
                    case "綠島":
                        count = caseCount.Green_Island + abroadCaseCount.Green_Island; 
                        value = Convert.ToDouble(count) / 4029.0;
                        break;
                    case "蘭嶼":
                        count = caseCount.Orchid_Island + abroadCaseCount.Orchid_Island;
                        value = Convert.ToDouble(count) / 5242.0;
                        break;
                    case "金門縣":
                        count = caseCount.Kinmen_County + abroadCaseCount.Kinmen_County;
                        value = Convert.ToDouble(count) / 140004.0;
                        break;
                    case "馬祖":
                        count = caseCount.Matsu + abroadCaseCount.Matsu;
                        value = Convert.ToDouble(count) / 13420.0;
                        break;
                    case "連江縣":
                        count = caseCount.Lienchiang_County + abroadCaseCount.Lienchiang_County;
                        value = Convert.ToDouble(count) / 13420.0;
                        break;
                }                
            }

            percentage *= value;
            ViewBag.Message = "Risk: " + (percentage * 100.0).ToString("#0.000") + " %" + "      It is " + ((percentage*100.0) / 0.03189).ToString("#0.000") + " times more serious than the peak of the Wuhan epidemic";

            model = new Level1Model();

            List<SelectListItem> brandList = new List<SelectListItem>();
            brandList.Add(new SelectListItem() { Text = "Moderna", Value = "Moderna", Selected = false });
            brandList.Add(new SelectListItem() { Text = "BNT", Value = "BNT", Selected = false });
            brandList.Add(new SelectListItem() { Text = "NOVAVAX", Value = "NOVAVAX", Selected = false });
            brandList.Add(new SelectListItem() { Text = "JandJ", Value = "JandJ", Selected = false });
            brandList.Add(new SelectListItem() { Text = "AZ", Value = "AZ", Selected = false });
            model.brandList = brandList;

            List<SelectListItem> locationList = new List<SelectListItem>();
            locationList.Add(new SelectListItem() { Text = "United States", Value = "美國", Selected = false });
            locationList.Add(new SelectListItem() { Text = "Keelung", Value = "基隆市", Selected = false });
            locationList.Add(new SelectListItem() { Text = "Taipei", Value = "台北市", Selected = false });
            locationList.Add(new SelectListItem() { Text = "NewTaipei", Value = "新北市", Selected = false });
            locationList.Add(new SelectListItem() { Text = "Taoyuan", Value = "桃園市", Selected = false });
            locationList.Add(new SelectListItem() { Text = "Hsinchu County", Value = "新竹縣", Selected = false });
            locationList.Add(new SelectListItem() { Text = "Hsinchu City", Value = "新竹市", Selected = false });
            locationList.Add(new SelectListItem() { Text = "Miaoli County", Value = "苗栗縣", Selected = false });
            locationList.Add(new SelectListItem() { Text = "Miaoli City", Value = "苗栗市", Selected = false });
            locationList.Add(new SelectListItem() { Text = "Taichung", Value = "台中市", Selected = false });
            locationList.Add(new SelectListItem() { Text = "Nantou County", Value = "南投縣", Selected = false });
            locationList.Add(new SelectListItem() { Text = "Nantou City", Value = "南投市", Selected = false });
            locationList.Add(new SelectListItem() { Text = "Changhua County", Value = "彰化縣", Selected = false });
            locationList.Add(new SelectListItem() { Text = "Changhua City", Value = "彰化市", Selected = false });
            locationList.Add(new SelectListItem() { Text = "Yunlin County", Value = "雲林縣", Selected = false });
            locationList.Add(new SelectListItem() { Text = "Chiayi County", Value = "嘉義縣", Selected = false });
            locationList.Add(new SelectListItem() { Text = "Chiayi City", Value = "嘉義市", Selected = false });
            locationList.Add(new SelectListItem() { Text = "Tainan City", Value = "台南市", Selected = false });
            locationList.Add(new SelectListItem() { Text = "Kaohsiung City", Value = "高雄市", Selected = false });
            locationList.Add(new SelectListItem() { Text = "Pingtung County", Value = "屏東縣", Selected = false });
            locationList.Add(new SelectListItem() { Text = "Pingtung City", Value = "屏東市", Selected = false });
            locationList.Add(new SelectListItem() { Text = "Yilan County", Value = "宜蘭縣", Selected = false });
            locationList.Add(new SelectListItem() { Text = "Yilan City", Value = "宜蘭市", Selected = false });
            locationList.Add(new SelectListItem() { Text = "Hualien County", Value = "花蓮縣", Selected = false });
            locationList.Add(new SelectListItem() { Text = "Hualien City", Value = "花蓮市", Selected = false });
            locationList.Add(new SelectListItem() { Text = "Taitung County", Value = "台東縣", Selected = false });
            locationList.Add(new SelectListItem() { Text = "Taitung City", Value = "台東市", Selected = false });
            locationList.Add(new SelectListItem() { Text = "Penghu County", Value = "澎湖縣", Selected = false });
            locationList.Add(new SelectListItem() { Text = "Green Island", Value = "綠島", Selected = false });
            locationList.Add(new SelectListItem() { Text = "Orchid Island", Value = "蘭嶼", Selected = false });
            locationList.Add(new SelectListItem() { Text = "Kinmen County", Value = "金門縣", Selected = false });
            locationList.Add(new SelectListItem() { Text = "Matsu", Value = "馬祖", Selected = false });
            locationList.Add(new SelectListItem() { Text = "Lienchiang County", Value = "連江縣", Selected = false });
            model.locationList = locationList;

            
            

            return View(model);
        }

        public IActionResult Level2()
        {            
            return View(new Level2Model());
        }
        
        [HttpPost]
        public IActionResult Level2(Level2Model model)
        {
            Nuel2Efficacy nuel2Efficacy = new Nuel2Efficacy();
            double normalized_convalerate_value = 700.0;
            model.efficacy = Math.Round(nuel2Efficacy.Convert_GMT_to_Efficacy(Convert.ToDouble(model.NeutralizingAntibodies) / normalized_convalerate_value), 3);
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

                return Json(new { success = true, responseText = "Protection Value: " + efficacy.ToString("#0.000") + " %" });
            }
            else
            {
                model.concentration = "No antibody concentration";
                return Json(new { success = true, responseText = "No antibody concentration" });
            }     
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

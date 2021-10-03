using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NASA_Hackathon.Controllers
{
    class ConfirmJsonRead
    {
        private AbroadCaseCount abroadCaseCount;
        private CaseCount caseCount;
        private List<string[]> everyCase;
        private string[] jsonSlipt;
        public AbroadCaseCount AbroadCaseCount {
            get { return this.abroadCaseCount; }
        }
        public CaseCount CaseCount
        {
            get { return this.caseCount; }
        }
        public ConfirmJsonRead(string jsonpath) {
            var jsonString = new WebClient().DownloadString(jsonpath);
            //StreamReader r = new StreamReader(jsonpath);
            //string jsonString = r.ReadToEnd();
            jsonSlipt = jsonString.Split('{');
            everyCase = new List<string[]>();
            abroadCaseCount = new AbroadCaseCount();
            caseCount = new CaseCount();
            ReadJson();
        }
        public ConfirmJsonRead(string jsonpath,bool isOnly2021LastWeek)
        {
            var jsonString = new WebClient().DownloadString(jsonpath);
            //StreamReader r = new StreamReader(jsonpath);
            //string jsonString = r.ReadToEnd();
            jsonSlipt = jsonString.Split('{');
            everyCase = new List<string[]>();
            abroadCaseCount = new AbroadCaseCount();
            caseCount = new CaseCount();
            if (isOnly2021LastWeek) LastWeekJsonRead();
            else ReadJson();
        }
        public void LastWeekJsonRead()
        {
            foreach (string s in jsonSlipt)
            {
                everyCase.Add(s.Split('"'));
            }
            string city = "";
            bool isAbroad = false;
            bool is2021 = false;
            bool isLastWeek = false;
            foreach (string[] s in everyCase)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == "發病年份" && s[i+2] == "2021")
                    {
                        is2021 = true;
                    }
                    if (s[i] == "發病週別" && s[i+2] == "39")
                    {
                        isLastWeek = true;
                    }
                    if (is2021 && isLastWeek)
                    {
                        if (s[i] == "縣市")
                        {
                            city = s[i + 2];
                        }
                        else if (s[i] == "是否為境外移入")
                        {
                            if (s[i + 2] == "是")
                            { isAbroad = true; }

                            switch (city)
                            {
                                case "基隆市":
                                    if (isAbroad) { isAbroad = false; abroadCaseCount.Keelung++; }
                                    else caseCount.Keelung++;
                                    break;
                                case "台北市":
                                    if (isAbroad) { isAbroad = false; abroadCaseCount.Taipei++; }
                                    else caseCount.Taipei++;
                                    break;
                                case "新北市":
                                    if (isAbroad) { isAbroad = false; abroadCaseCount.NewTaipei++; }
                                    else caseCount.NewTaipei++;
                                    break;
                                case "桃園市":
                                    if (isAbroad) { isAbroad = false; abroadCaseCount.Taoyuan++; }
                                    else caseCount.Taoyuan++;
                                    break;
                                case "新竹縣":
                                    if (isAbroad) { isAbroad = false; abroadCaseCount.Hsinchu_County++; }
                                    else caseCount.Hsinchu_County++;
                                    break;
                                case "新竹市":
                                    if (isAbroad) { isAbroad = false; abroadCaseCount.Hsinchu_City++; }
                                    else caseCount.Hsinchu_City++;
                                    break;
                                case "苗栗縣":
                                    if (isAbroad) { isAbroad = false; abroadCaseCount.Miaoli_County++; }
                                    else caseCount.Miaoli_County++;
                                    break;
                                case "苗栗市":
                                    if (isAbroad) { isAbroad = false; abroadCaseCount.Miaoli_City++; }
                                    else caseCount.Miaoli_City++;
                                    break;
                                case "台中市":
                                    if (isAbroad) { isAbroad = false; abroadCaseCount.Taichung++; }
                                    else caseCount.Taichung++;
                                    break;
                                case "南投縣":
                                    if (isAbroad) { isAbroad = false; abroadCaseCount.Nantou_County++; }
                                    else caseCount.Nantou_County++;
                                    break;
                                case "南投市":
                                    if (isAbroad) { isAbroad = false; abroadCaseCount.Nantou_City++; }
                                    else caseCount.Nantou_City++;
                                    break;
                                case "彰化縣":
                                    if (isAbroad) { isAbroad = false; abroadCaseCount.Changhua_County++; }
                                    else caseCount.Changhua_County++;
                                    break;
                                case "彰化市":
                                    if (isAbroad) { isAbroad = false; abroadCaseCount.Changhua_City++; }
                                    else caseCount.Changhua_City++;
                                    break;
                                case "雲林縣":
                                    if (isAbroad) { isAbroad = false; abroadCaseCount.Yunlin_County++; }
                                    else caseCount.Yunlin_County++;
                                    break;
                                case "嘉義縣":
                                    if (isAbroad) { isAbroad = false; abroadCaseCount.Chiayi_County++; }
                                    else caseCount.Chiayi_County++;
                                    break;
                                case "嘉義市":
                                    if (isAbroad) { isAbroad = false; abroadCaseCount.Chiayi_City++; }
                                    else caseCount.Chiayi_City++;
                                    break;
                                case "台南市":
                                    if (isAbroad) { isAbroad = false; abroadCaseCount.Tainan_City++; }
                                    else caseCount.Tainan_City++;
                                    break;
                                case "高雄市":
                                    if (isAbroad) { isAbroad = false; abroadCaseCount.Kaohsiung_City++; }
                                    else caseCount.Kaohsiung_City++;
                                    break;
                                case "屏東縣":
                                    if (isAbroad) { isAbroad = false; abroadCaseCount.Pingtung_County++; }
                                    else caseCount.Pingtung_County++;
                                    break;
                                case "屏東市":
                                    if (isAbroad) { isAbroad = false; abroadCaseCount.Pingtung_City++; }
                                    else caseCount.Pingtung_City++;
                                    break;
                                case "宜蘭縣":
                                    if (isAbroad) { isAbroad = false; abroadCaseCount.Yilan_County++; }
                                    else caseCount.Yilan_County++;
                                    break;
                                case "宜蘭市":
                                    if (isAbroad) { isAbroad = false; abroadCaseCount.Yilan_City++; }
                                    else caseCount.Yilan_City++;
                                    break;
                                case "花蓮縣":
                                    if (isAbroad) { isAbroad = false; abroadCaseCount.Hualien_County++; }
                                    else caseCount.Hualien_County++;
                                    break;
                                case "花蓮市":
                                    if (isAbroad) { isAbroad = false; abroadCaseCount.Hualien_City++; }
                                    else caseCount.Hualien_City++;
                                    break;
                                case "台東縣":
                                    if (isAbroad) { isAbroad = false; abroadCaseCount.Taitung_County++; }
                                    else caseCount.Taitung_County++;
                                    break;
                                case "台東市":
                                    if (isAbroad) { isAbroad = false; abroadCaseCount.Taitung_City++; }
                                    else caseCount.Taitung_City++;
                                    break;
                                case "澎湖縣":
                                    if (isAbroad) { isAbroad = false; abroadCaseCount.Penghu_County++; }
                                    else caseCount.Penghu_County++;
                                    break;
                                case "綠島":
                                    if (isAbroad) { isAbroad = false; abroadCaseCount.Green_Island++; }
                                    else caseCount.Green_Island++;
                                    break;
                                case "蘭嶼":
                                    if (isAbroad) { isAbroad = false; abroadCaseCount.Orchid_Island++; }
                                    else caseCount.Orchid_Island++;
                                    break;
                                case "金門縣":
                                    if (isAbroad) { isAbroad = false; abroadCaseCount.Kinmen_County++; }
                                    else caseCount.Kinmen_County++;
                                    break;
                                case "馬祖":
                                    if (isAbroad) { isAbroad = false; abroadCaseCount.Matsu++; }
                                    else caseCount.Matsu++;
                                    break;
                                case "連江縣":
                                    if (isAbroad) { isAbroad = false; abroadCaseCount.Lienchiang_County++; }
                                    else caseCount.Lienchiang_County++;
                                    break;
                            }
                            isLastWeek = false;
                            is2021 = false;
                        }
                    }
                    
                }
            }
        }
        private void ReadJson()
        {
            foreach (string s in jsonSlipt)
            {
                everyCase.Add(s.Split('"'));
            }
            string city = "";
            bool isAbroad = false;
            foreach (string[] s in everyCase)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == "縣市")
                    {
                        city = s[i + 2];
                    }                   
                    else if (s[i] == "是否為境外移入")
                    {
                        if (s[i + 2] == "是")
                        { isAbroad = true; }

                        switch (city)
                        {
                            case "基隆市":
                                if (isAbroad) { isAbroad = false; abroadCaseCount.Keelung++; }
                                else caseCount.Keelung++;
                                break;
                            case "台北市":
                                if (isAbroad) { isAbroad = false; abroadCaseCount.Taipei++; }
                                else caseCount.Taipei++;
                                break;
                            case "新北市":
                                if (isAbroad) { isAbroad = false; abroadCaseCount.NewTaipei++; }
                                else caseCount.NewTaipei++;
                                break;
                            case "桃園市":
                                if (isAbroad) { isAbroad = false; abroadCaseCount.Taoyuan++; }
                                else caseCount.Taoyuan++;
                                break;
                            case "新竹縣":
                                if (isAbroad) { isAbroad = false; abroadCaseCount.Hsinchu_County++; }
                                else caseCount.Hsinchu_County++;
                                break;
                            case "新竹市":
                                if (isAbroad) { isAbroad = false; abroadCaseCount.Hsinchu_City++; }
                                else caseCount.Hsinchu_City++;
                                break;
                            case "苗栗縣":
                                if (isAbroad) { isAbroad = false; abroadCaseCount.Miaoli_County++; }
                                else caseCount.Miaoli_County++;
                                break;
                            case "苗栗市":
                                if (isAbroad) { isAbroad = false; abroadCaseCount.Miaoli_City++; }
                                else caseCount.Miaoli_City++;
                                break;
                            case "台中市":
                                if (isAbroad) { isAbroad = false; abroadCaseCount.Taichung++; }
                                else caseCount.Taichung++;
                                break;
                            case "南投縣":
                                if (isAbroad) { isAbroad = false; abroadCaseCount.Nantou_County++; }
                                else caseCount.Nantou_County++;
                                break;
                            case "南投市":
                                if (isAbroad) { isAbroad = false; abroadCaseCount.Nantou_City++; }
                                else caseCount.Nantou_City++;
                                break;
                            case "彰化縣":
                                if (isAbroad) { isAbroad = false; abroadCaseCount.Changhua_County++; }
                                else caseCount.Changhua_County++;
                                break;
                            case "彰化市":
                                if (isAbroad) { isAbroad = false; abroadCaseCount.Changhua_City++; }
                                else caseCount.Changhua_City++;
                                break;
                            case "雲林縣":
                                if (isAbroad) { isAbroad = false; abroadCaseCount.Yunlin_County++; }
                                else caseCount.Yunlin_County++;
                                break;
                            case "嘉義縣":
                                if (isAbroad) { isAbroad = false; abroadCaseCount.Chiayi_County++; }
                                else caseCount.Chiayi_County++;
                                break;
                            case "嘉義市":
                                if (isAbroad) { isAbroad = false; abroadCaseCount.Chiayi_City++; }
                                else caseCount.Chiayi_City++;
                                break;
                            case "台南市":
                                if (isAbroad) { isAbroad = false; abroadCaseCount.Tainan_City++; }
                                else caseCount.Tainan_City++;
                                break;
                            case "高雄市":
                                if (isAbroad) { isAbroad = false; abroadCaseCount.Kaohsiung_City++; }
                                else caseCount.Kaohsiung_City++;
                                break;
                            case "屏東縣":
                                if (isAbroad) { isAbroad = false; abroadCaseCount.Pingtung_County++; }
                                else caseCount.Pingtung_County++;
                                break;
                            case "屏東市":
                                if (isAbroad) { isAbroad = false; abroadCaseCount.Pingtung_City++; }
                                else caseCount.Pingtung_City++;
                                break;
                            case "宜蘭縣":
                                if (isAbroad) { isAbroad = false; abroadCaseCount.Yilan_County++; }
                                else caseCount.Yilan_County++;
                                break;
                            case "宜蘭市":
                                if (isAbroad) { isAbroad = false; abroadCaseCount.Yilan_City++; }
                                else caseCount.Yilan_City++;
                                break;
                            case "花蓮縣":
                                if (isAbroad) { isAbroad = false; abroadCaseCount.Hualien_County++; }
                                else caseCount.Hualien_County++;
                                break;
                            case "花蓮市":
                                if (isAbroad) { isAbroad = false; abroadCaseCount.Hualien_City++; }
                                else caseCount.Hualien_City++;
                                break;
                            case "台東縣":
                                if (isAbroad) { isAbroad = false; abroadCaseCount.Taitung_County++; }
                                else caseCount.Taitung_County++;
                                break;
                            case "台東市":
                                if (isAbroad) { isAbroad = false; abroadCaseCount.Taitung_City++; }
                                else caseCount.Taitung_City++;
                                break;
                            case "澎湖縣":
                                if (isAbroad) { isAbroad = false; abroadCaseCount.Penghu_County++; }
                                else caseCount.Penghu_County++;
                                break;
                            case "綠島":
                                if (isAbroad) { isAbroad = false; abroadCaseCount.Green_Island++; }
                                else caseCount.Green_Island++;
                                break;
                            case "蘭嶼":
                                if (isAbroad) { isAbroad = false; abroadCaseCount.Orchid_Island++; }
                                else caseCount.Orchid_Island++;
                                break;
                            case "金門縣":
                                if (isAbroad) { isAbroad = false; abroadCaseCount.Kinmen_County++; }
                                else caseCount.Kinmen_County++;
                                break;
                            case "馬祖":
                                if (isAbroad) { isAbroad = false; abroadCaseCount.Matsu++; }
                                else caseCount.Matsu++;
                                break;
                            case "連江縣":
                                if (isAbroad) { isAbroad = false; abroadCaseCount.Lienchiang_County++; }
                                else caseCount.Lienchiang_County++;
                                break;
                        }

                    }
                }
            }
        }
    }
    class AbroadCaseCount
    {
        public int Keelung = 0;
        public int Taipei = 0;
        public int NewTaipei = 0;
        public int Taoyuan = 0;
        public int Hsinchu_County = 0;
        public int Hsinchu_City = 0;
        public int Miaoli_County = 0;
        public int Miaoli_City = 0;
        public int Taichung = 0;
        public int Changhua_County = 0;
        public int Changhua_City = 0;
        public int Nantou_County = 0;
        public int Nantou_City = 0;
        public int Yunlin_County = 0;
        public int Chiayi_County = 0;
        public int Chiayi_City = 0;
        public int Tainan_City = 0;
        public int Kaohsiung_City = 0;
        public int Pingtung_County = 0;
        public int Pingtung_City = 0;
        public int Yilan_County = 0;
        public int Yilan_City = 0;
        public int Hualien_County = 0;
        public int Hualien_City = 0;
        public int Taitung_County = 0;
        public int Taitung_City = 0;
        public int Penghu_County = 0;
        public int Green_Island = 0;
        public int Orchid_Island = 0;
        public int Kinmen_County = 0;
        public int Matsu = 0;
        public int Lienchiang_County = 0;
    }
    class CaseCount
    {
        public int Keelung = 0;
        public int Taipei = 0;
        public int NewTaipei = 0;
        public int Taoyuan = 0;
        public int Hsinchu_County = 0;
        public int Hsinchu_City = 0;
        public int Miaoli_County = 0;
        public int Miaoli_City = 0;
        public int Taichung = 0;
        public int Changhua_County = 0;
        public int Changhua_City = 0;
        public int Nantou_County = 0;
        public int Nantou_City = 0;
        public int Yunlin_County = 0;
        public int Chiayi_County = 0;
        public int Chiayi_City = 0;
        public int Tainan_City = 0;
        public int Kaohsiung_City = 0;
        public int Pingtung_County = 0;
        public int Pingtung_City = 0;
        public int Yilan_County = 0;
        public int Yilan_City = 0;
        public int Hualien_County = 0;
        public int Hualien_City = 0;
        public int Taitung_County = 0;
        public int Taitung_City = 0;
        public int Penghu_County = 0;
        public int Green_Island = 0;
        public int Orchid_Island = 0;
        public int Kinmen_County = 0;
        public int Matsu = 0;
        public int Lienchiang_County = 0;
    }

}

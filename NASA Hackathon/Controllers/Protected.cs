using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASA_Hackathon.Controllers
{
    public abstract class Protected
    {
        protected double potectPercentage;
        protected int vaccinationDays;
        public double PotectPercentage
        {
            get { return this.potectPercentage; }
        }
        public Protected(int vaccinationDays)
        {
            this.vaccinationDays = vaccinationDays;
            GetpotectPercentage();
        }
        protected abstract void GetpotectPercentage();
    }
    class VaccineFactory {
        private Moderna moderna;
        private BNT bNT;
        private NOVAVAX nOVAVAX;
        private JandJ jandJ;
        private AZ aZ;
        private string vaccineCompany;
        private int vaccinationDays;
        /// <summary>
        /// 輸入廠牌名稱(Moderna,BNT,NOVAVAX,JandJ,AZ)，與接種天數
        /// </summary>
        /// <param name="VaccineCompany"></param>
        /// <param name="vaccinationDays"></param>
        public VaccineFactory(string VaccineCompany , int vaccinationDays)
        {
            this.vaccinationDays = vaccinationDays;
            this.vaccineCompany = VaccineCompany;
        }
        public Protected GetProtected()
        {
            switch (this.vaccineCompany)
            {
                case "Moderna":
                    this.moderna = new Moderna(this.vaccinationDays);
                    return this.moderna;

                case "BNT":
                    this.bNT = new BNT(this.vaccinationDays);
                    return this.bNT;
                case "NOVAVAX":
                    this.nOVAVAX = new NOVAVAX(this.vaccinationDays);
                    return this.nOVAVAX;
                case "JandJ":
                    this.jandJ = new JandJ(this.vaccinationDays);
                    return this.jandJ;
                case "AZ":
                    this.aZ = new AZ(this.vaccinationDays);
                    return this.aZ;
            }
            return null;
        }
    }
    class Moderna : Protected {
        public Moderna(int vaccinationDays) : base(vaccinationDays) {           
        }
        protected override void GetpotectPercentage() {
            string Level = "T1";
            if (this.vaccinationDays > 14 && this.vaccinationDays < 57) Level = "T2";
            else if(this.vaccinationDays >= 57 && this.vaccinationDays < 85) Level = "T3";
            else if (this.vaccinationDays >= 85) Level = "T4";
            switch (Level)
            {
                    case "T1":
                        this.potectPercentage = 0;
                        break;
                    case "T2":
                        this.potectPercentage = 0.918;
                        break;
                    case "T3":
                        this.potectPercentage = 0.94;
                        break;
                    case "T4":
                        this.potectPercentage = 0.924;
                        break;
            }
        }
    }
    class BNT : Protected
    {
        public BNT(int vaccinationDays) : base(vaccinationDays)
        {
        }
        protected override void GetpotectPercentage()
        {
            string Level = "T1";
            if (this.vaccinationDays > 14 ) Level = "T2";          
            switch (Level)
            {
                case "T1":
                    this.potectPercentage = 0;
                    break;
                case "T2":
                    this.potectPercentage = 0.95;
                    break;            
            }
        }
    }
    class NOVAVAX : Protected
    {
        public NOVAVAX(int vaccinationDays) : base(vaccinationDays)
        {
        }
        protected override void GetpotectPercentage()
        {
            string Level = "T1";
            if (this.vaccinationDays > 14) Level = "T2";
            switch (Level)
            {
                case "T1":
                    this.potectPercentage = 0;
                    break;
                case "T2":
                    this.potectPercentage = 0.95;
                    break;
            }
        }
    }
    class JandJ : Protected
    {
        public JandJ(int vaccinationDays) : base(vaccinationDays)
        {
        }
        protected override void GetpotectPercentage()
        {
            string Level = "T1";
            if (this.vaccinationDays > 14) Level = "T2";
            switch (Level)
            {
                case "T1":
                    this.potectPercentage = 0;
                    break;
                case "T2":
                    this.potectPercentage = 0.66;
                    break;
            }
        }
    }
    class AZ : Protected
    {
        public AZ(int vaccinationDays) : base(vaccinationDays)
        {
        }
        protected override void GetpotectPercentage()
        {
            string Level = "T1";
            if (this.vaccinationDays > 14) Level = "T2";
            switch (Level)
            {
                case "T1":
                    this.potectPercentage = 0;
                    break;
                case "T2":
                    this.potectPercentage = 0.81;
                    break;
            }
        }
    }
}

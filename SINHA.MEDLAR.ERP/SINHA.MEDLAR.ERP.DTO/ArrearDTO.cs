using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO
{
    public class ArrearDTO
    {
        private string strUnitId;
        private string strCatagoryId;
        private string strSectionId;
        private string strYear;
        private string strMonth;
        private string strFromMonthId;
        private string strToMonthId;
        private string strOfficeId;


        private string strHeadOfficeId;
        private string strBranchOfficeId;
        private string strUpdateBy;

        //p_arrear_year_to
        //p_arrear_from_month_id_to
        //p_arrear_to_month_id_to

        public string ArrearYearTo { get; set; }
        public string ArrearFromMonthTo { get; set; }
        public string ArrearToMonthTo { get; set; }

        public string EffectDate { get; set; }
        public string LimitDate { get; set; }

        public string CarryPreArrear { get; set; }

        public string OfficeId
        {
            get { return strOfficeId; }
            set { strOfficeId = value; }

        }

        public string FromMonthId
        {
            get { return strFromMonthId; }
            set { strFromMonthId = value; }

        }

        public string ToMonthId
        {
            get { return strToMonthId; }
            set { strToMonthId = value; }

        }
        public string UnitId
        {
            get { return strUnitId; }
            set { strUnitId = value; }

        }
        public string CatagoryId
        {
            get { return strCatagoryId; }
            set { strCatagoryId = value; }

        }

        public string SectionId
        {
            get { return strSectionId; }
            set { strSectionId = value; }

        }

        public string Year
        {
            get { return strYear; }
            set { strYear = value; }

        }

        public string Month
        {
            get { return strMonth; }
            set { strMonth = value; }

        }

        public string HeadOfficeId
        {
            get { return strHeadOfficeId; }
            set { strHeadOfficeId = value; }

        }

        public string BranchOfficeId
        {
            get { return strBranchOfficeId; }
            set { strBranchOfficeId = value; }

        }

        public string UpdateBy
        {
            get { return strUpdateBy; }
            set { strUpdateBy = value; }

        }
    }
}

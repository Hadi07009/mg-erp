using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO
{
    public class TiffinDTO
    {
        private string strUnitId;
        private string strCatagoryId;
        private string strSectionId;
        private string strYear;
        private string strMonth;
        private string strTiffinTypeId;
        private string strHeadOfficeId;
        private string strBranchOfficeId;
        private string strUpdateBy;

        private string strTiffinDay;
        private string strEmployeeId;
        private string strCardNo;
        private string strFromDate;
        private string strToDate;
        private string strIncrementAmount;
        public string AllowGeneralIncrement { get; set; }
        public string TiffinDayAdditional { get; set; }
        public string IncrementAmount
        {
            get { return strIncrementAmount; }
            set { strIncrementAmount = value; }

        }

        public string FromDate
        {
            get { return strFromDate; }
            set { strFromDate = value; }

        }


        public string ToDate
        {
            get { return strToDate; }
            set { strToDate = value; }

        }


        public string TiffinDay
        {
            get { return strTiffinDay; }
            set { strTiffinDay = value; }

        }
        public string EmployeeId
        {
            get { return strEmployeeId; }
            set { strEmployeeId = value; }

        }

        public string CardNo
        {
            get { return strCardNo; }
            set { strCardNo = value; }

        }

        public string TiffinTypeId
        {
            get { return strTiffinTypeId; }
            set { strTiffinTypeId = value; }

        }


        public string UnitId
        {
            get { return strUnitId;}
            set { strUnitId = value ;}

        }
        public string CatagoryId
        {
            get { return strCatagoryId;}
            set { strCatagoryId = value ;}

        }

        public string SectionId
        {
            get { return strSectionId;}
            set { strSectionId = value ;}

        }

        public string Year
        {
            get { return strYear;}
            set { strYear = value ;}

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

        public string UnitGroupId { get; set; }
    }
}

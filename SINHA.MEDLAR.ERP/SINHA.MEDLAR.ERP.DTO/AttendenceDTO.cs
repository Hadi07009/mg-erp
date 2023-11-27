using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO
{
    public class AttendenceDTO
    {

        private string strEmployeeId;
        private string strEmployeeCardNo;
        private string strLoginDate;
        private string strLogiDay;
        private string strLoginMonth;
        private string strLoginYear;
        private string strInTime;
        private string strOutTime;
        private string strOverTime;
        private string strUpdateBY;
        private string strHeadOfficeId;
        private string strBranchOffiecId;



        public string EmployeeId
        {
            get { return strEmployeeId; }
            set { strEmployeeId = value; } 

        }
        public string EmployeeCardNo
        {
            get { return strEmployeeCardNo; }
            set { strEmployeeCardNo = value; }

        }

        public string LoginDate
        {
            get { return strLoginDate; }
            set { strLoginDate = value; }

        }

        public string LogiDay
        {
            get { return strLogiDay; }
            set { strLogiDay = value; }

        }

        public string LoginMonth
        {
            get { return strLoginMonth; }
            set { strLoginMonth = value; }

        }

        public string LoginYear
        {
            get { return strLoginYear; }
            set { strLoginYear = value; }

        }

        public string InTime
        {
            get { return strInTime; }
            set { strInTime = value; }

        }

        public string OutTime
        {
            get { return strOutTime; }
            set { strOutTime = value; }

        }

        public string OverTime
        {
            get { return strOverTime; }
            set { strOverTime = value; }

        }

        public string UpdateBY
        {
            get { return strUpdateBY; }
            set { strUpdateBY = value; }

        }

        public string HeadOfficeId
        {
            get { return strHeadOfficeId; }
            set { strHeadOfficeId = value; }

        }


        public string BranchOffiecId
        {
            get { return strBranchOffiecId; }
            set { strBranchOffiecId = value; }

        }

    }
}

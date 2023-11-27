using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO
{
   public class DigitalBoardDTO
    {
        private string strUpdateBy;
        private string strHeadOfficeId;
        private string strBranchOfficeId;

        private string strDigitalBoardInputId;
        private string strInputDate;
        private string strBuyerId;
        private string strStyleNo;
        private string strSMV;
        private string strManPower;
        private string strTargetEfficiency;
        private string strTargetPerHour;
        private string strDayTarget;
        private string strLineId;
        private string strDHULimit;

        private string strHour;
        private string strAchieve;
        private string strDefect;
        private string strInputFromDate;
        private string strInputToDate;

        public string InputFromDate
        {
            get { return strInputFromDate; }
            set { strInputFromDate = value; }
        }
        public string InputToDate
        {
            get { return strInputToDate; }
            set { strInputToDate = value; }
        } 
        public string Defect
        {
            get { return strDefect; }
            set { strDefect = value; }
        } 

        public string Achieve
        {
            get { return strAchieve; }
            set { strAchieve = value; }
        } 
       
       public string Hour
        {
            get { return strHour; }
            set { strHour = value; }
        }

        public string DHULimit
        {
            get { return strDHULimit; }
            set { strDHULimit = value; }
        }

        public string LineId
        {
            get { return strLineId; }
            set { strLineId = value; }
        }

        public string DayTarget
        {
            get { return strDayTarget; }
            set { strDayTarget = value; }
        }

        public string TargetPerHour
        {
            get { return strTargetPerHour; }
            set { strTargetPerHour = value; }
        }

        public string TargetEfficiency
        {
            get { return strTargetEfficiency; }
            set { strTargetEfficiency = value; }
        }
        public string ManPower
        {
            get { return strManPower; }
            set { strManPower = value; }
        }

        public string SMV
        {
            get { return strSMV; }
            set { strSMV = value; }
        }

        public string StyleNo
        {
            get { return strStyleNo; }
            set { strStyleNo = value; }
        }
        public string BuyerId
        {
            get { return strBuyerId; }
            set { strBuyerId = value; }
        }

        public string InputDate
        {
            get { return strInputDate; }
            set { strInputDate = value; }
        }

        public string DigitalBoardInputId
        {
            get { return strDigitalBoardInputId; }
            set { strDigitalBoardInputId = value; }
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

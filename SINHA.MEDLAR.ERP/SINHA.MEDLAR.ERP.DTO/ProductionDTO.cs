using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO
{
    public class ProductionDTO
    {


        private string strProductionDate;
        private string strOrderQuantity;
        private string strPONo;
        private string strStyleId;
        private string strLineId;
        private string strBuyerId;
        private string strColorId;
        private string strCuttingQuantity;
        private string strCuttingDelivery;
        private string strSewingInput;
        private string strSewingOutput;
        private string strWashingSent;
        private string strWashingReceived;
        private string strPolyQuantity;
        private string strCartonQuantity;
        private string strReamininigQuantity;
        private string strFinazlizedYn;


        private string strFromDate;
        private string strToDate;

        private string strUpdateBy;
        private string strHeadOfficeId;
        private string strBranchOfficeId;

        public string ProductionDate
        {
            get { return strProductionDate; }
            set { strProductionDate = value;} 
        }
        public string OrderQuantity
        {
            get { return strOrderQuantity; }
            set { strOrderQuantity = value; }
        }

        public string PONo
        {
            get { return strPONo; }
            set { strPONo = value; }
        }

        public string StyleId
        {
            get { return strStyleId; }
            set { strStyleId = value; }
        }



        public string LineId
        {
            get { return strLineId; }
            set { strLineId = value; }
        }

        public string BuyerId
        {
            get { return strBuyerId; }
            set { strBuyerId = value; }
        }


        public string ColorId
        {
            get { return strColorId; }
            set { strColorId = value; }
        }

        public string CuttingQuantity
        {
            get { return strCuttingQuantity; }
            set { strCuttingQuantity = value; }
        }

        public string CuttingDelivery
        {
            get { return strCuttingDelivery; }
            set { strCuttingDelivery = value; }
        }

        public string SewingInput
        {
            get { return strSewingInput; }
            set { strSewingInput = value; }
        }

        public string SewingOutput
        {
            get { return strSewingOutput; }
            set { strSewingOutput = value; }
        }

        public string WashingSent
        {
            get { return strWashingSent; }
            set { strWashingSent = value; }
        }

        public string WashingReceived
        {
            get { return strWashingReceived; }
            set { strWashingReceived = value; }
        }


        public string PolyQuantity
        {
            get { return strPolyQuantity; }
            set { strPolyQuantity = value; }
        }

        public string CartonQuantity
        {
            get { return strCartonQuantity; }
            set { strCartonQuantity = value; }
        }

        public string ReamininigQuantity
        {
            get { return strReamininigQuantity; }
            set { strReamininigQuantity = value; }
        }

        public string FinazlizedYn
        {
            get { return strFinazlizedYn; }
            set { strFinazlizedYn = value; }
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

        public string UpdateBy
        {
            get { return strUpdateBy; }
            set { strUpdateBy = value; }

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

    }
}

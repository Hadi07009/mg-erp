using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO
{
    public class DailyProductionDTO
    {
        private string strUpdateBy;
        private string strHeadOfficeId;
        private string strBranchOfficeId;

        private string strPONo;
        private string strProductionDate;
        private string strBuyerId;
        private string strStyleNo;
        private string strTranId;
        private string strFactoryId;

        private string strOrderQty;
        private string strCuttingIssuedQty;
        private string strCuttingDeliveyQty;
        private string strSewingInputQty;
        private string strSewingOutputQty;
        private string strWashSentQty;
        private string strWashReceivedQty;
        private string strFinishingPolyQty;
        private string strFinishingCartonQty;
        private string strLineId;
        private string strBuyerName;

        public string BuyerName
        {
            get { return strBuyerName; }
            set { strBuyerName = value; }
        }
        public string LineId
        {
            get { return strLineId; }
            set { strLineId = value; }
        }
        public string OrderQty
        {
            get { return strOrderQty; }
            set { strOrderQty = value; }
        }
        public string CuttingIssuedQty
        {
            get { return strCuttingIssuedQty; }
            set { strCuttingIssuedQty = value; }
        }
        public string CuttingDeliveyQty
        {
            get { return strCuttingDeliveyQty; }
            set { strCuttingDeliveyQty = value; }
        }
        public string SewingInputQty
        {
            get { return strSewingInputQty; }
            set { strSewingInputQty = value; }
        }
        public string SewingOutputQty
        {
            get { return strSewingOutputQty; }
            set { strSewingOutputQty = value; }
        }
        public string WashSentQty
        {
            get { return strWashSentQty; }
            set { strWashSentQty = value; }
        }
        public string WashReceivedQty
        {
            get { return strWashReceivedQty; }
            set { strWashReceivedQty = value; }
        }
        public string FinishingPolyQty
        {
            get { return strFinishingPolyQty; }
            set { strFinishingPolyQty = value; }
        }
        public string FinishingCartonQty
        {
            get { return strFinishingCartonQty; }
            set { strFinishingCartonQty = value; }
        }


        public string FactoryId
        {
            get { return strFactoryId; }
            set { strFactoryId = value; }
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
        public string TranId
        {
            get { return strTranId; }
            set { strTranId = value; }
        }

        public string PONo
        {
            get { return strPONo; }
            set { strPONo = value; }
        }
        public string ProductionDate
        {
            get { return strProductionDate; }
            set { strProductionDate = value; }
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
 
    }
}

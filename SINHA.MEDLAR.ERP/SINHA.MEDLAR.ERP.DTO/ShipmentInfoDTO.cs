using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO
{
    public class ShipmentInfoDTO
    {
        private string strUpdateBy;
        private string strHeadOfficeId;
        private string strBranchOfficeId;

        private string strPONo;       
        private string strBuyerId;
        private string strBuyerFullName;
        private string strStyleNo;
        private string strStyleId;
        private string strRate;
        private string strQuantity;
        private string strTranId;
        private string strRemarks;
        private string strAmount;

        private string strInvoiceNo;
        private string strInvoiceDate;
        private string strShipDate;
        private string strFactoryId;
        private string strPOId;
        private string strChkYN;

        public string ChkYN
        {
            get { return strChkYN; }
            set { strChkYN = value; }
        }
        public string POId
        {
            get { return strPOId; }
            set { strPOId = value; }
        }
        public string BuyerFullName
        {
            get { return strBuyerFullName; }
            set { strBuyerFullName = value; }
        }
        public string InvoiceNo
        {
            get { return strInvoiceNo; }
            set { strInvoiceNo = value; }
        }
        public string InvoiceDate
        {
            get { return strInvoiceDate; }
            set { strInvoiceDate = value; }
        }
        public string ShipDate
        {
            get { return strShipDate; }
            set { strShipDate = value; }
        }
        public string FactoryId
        {
            get { return strFactoryId; }
            set { strFactoryId = value; }
        }


        public string Amount
        {
            get { return strAmount; }
            set { strAmount = value; }
        }
        public string Remarks
        {
            get { return strRemarks; }
            set { strRemarks = value; }
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

        public string Rate
        {
            get { return strRate; }
            set { strRate = value; }
        }
        public string Quantity
        {
            get { return strQuantity; }
            set { strQuantity = value; }
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
        public string StyleId
        {
            get { return strStyleId; }
            set { strStyleId = value; }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO
{
    public class PoTrackingDTO
    {

        public string strUpdateBy;
        public string strHeadOfficeId;
        public string strBranchOfficeId;

        private string strProductDescription;
        private string strPartNo;
        private string strPiNo;
        private string strApprovedQty;
        private string strPrice;
        private string strAdvanceAmount;
        private string strTotalPrice;
        private string strPaymentDate;
        private string strShipmentDate;

        private string strPoNumber;
        private string strIssueDate;
        private string strOfferNo;
        private string strDeliveryDate;
        private string strTradeTerms;
        private string strPortOfLoading;
        private string strPortOfDischarges;
        private string strPurchaserId;
        private string strSupplierId;
        private string strDeliverToId;
        private string strPaymentModeId;
        private string strTranshipmentId;
        private string strPartshipmentId;
        private string strTranId;
        private string strFreight;
        private string strPoRequisitionNo;
        private string strCurrencyId;
        private string strShipmentModeId;

        private string strReminingBalance;
        private string strShipQuantity;
        private string strPoUnitName;
        private string strDiscount;
        private string strTotalAmount;
        private string strReminingQuantity;
        private string strBalance;

        private string strBlNo;
        private string strEtaDate;
        private string strDocRecevingDate;
        private string strDocHandoverDate;
        private string strShipDeliveryDate;
        private string strTrackingChargeFee;

        public string TrackingChargeFee
        {
            get { return strTrackingChargeFee; }
            set { strTrackingChargeFee = value; }
        }
        public string BlNo
        {
            get { return strBlNo; }
            set { strBlNo = value; }
        }
        public string EtaDate
        {
            get { return strEtaDate; }
            set { strEtaDate = value; }
        }
        public string DocRecevingDate
        {
            get { return strDocRecevingDate; }
            set { strDocRecevingDate = value; }
        }
        public string DocHandoverDate
        {
            get { return strDocHandoverDate; }
            set { strDocHandoverDate = value; }
        }
        public string ShipDeliveryDate
        {
            get { return strShipDeliveryDate; }
            set { strShipDeliveryDate = value; }
        }
        public string Balance
        {
            get { return strBalance; }
            set { strBalance = value; }
        }
        public string ReminingQuantity
        {
            get { return strReminingQuantity; }
            set { strReminingQuantity = value; }
        }
        public string TotalAmount
        {
            get { return strTotalAmount; }
            set { strTotalAmount = value; }
        }
        public string Discount
        {
            get { return strDiscount; }
            set { strDiscount = value; }
        }
        public string PoUnitName
        {
            get { return strPoUnitName; }
            set { strPoUnitName = value; }
        }
        public string ShipQuantity
        {
            get { return strShipQuantity; }
            set { strShipQuantity = value; }
        }
        public string ReminingBalance
        {
            get { return strReminingBalance; }
            set { strReminingBalance = value; }
        }
        public string ShipmentModeId
        {
            get { return strShipmentModeId; }
            set { strShipmentModeId = value; }
        }
        public string CurrencyId
        {
            get { return strCurrencyId; }
            set { strCurrencyId = value; }
        }
        public string PoRequisitionNo
        {
            get { return strPoRequisitionNo; }
            set { strPoRequisitionNo = value; }
        }
        public string ShipmentDate
        {
            get { return strShipmentDate; }
            set { strShipmentDate = value; }
        }
        public string PaymentDate
        {
            get { return strPaymentDate; }
            set { strPaymentDate = value; }
        }
        public string AdvanceAmount
        {
            get { return strAdvanceAmount; }
            set { strAdvanceAmount = value; }
        }
        public string PiNo
        {
            get { return strPiNo; }
            set { strPiNo = value; }
        }
        public string Freight
        {
            get { return strFreight; }
            set { strFreight = value; }
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

        public string ProductDescription
        {
            get { return strProductDescription; }
            set { strProductDescription = value; }
        }
        public string PartNo
        {
            get { return strPartNo; }
            set { strPartNo = value; }
        }
        public string ApprovedQty
        {
            get { return strApprovedQty; }
            set { strApprovedQty = value; }
        }
        public string Price
        {
            get { return strPrice; }
            set { strPrice = value; }
        }
        public string TotalPrice
        {
            get { return strTotalPrice; }
            set { strTotalPrice = value; }
        }




        public string PoNumber
        {
            get { return strPoNumber; }
            set { strPoNumber = value; }
        }
        public string IssueDate
        {
            get { return strIssueDate; }
            set { strIssueDate = value; }
        }
        public string OfferNo
        {
            get { return strOfferNo; }
            set { strOfferNo = value; }
        }
        public string DeliveryDate
        {
            get { return strDeliveryDate; }
            set { strDeliveryDate = value; }
        }
        public string TradeTerms
        {
            get { return strTradeTerms; }
            set { strTradeTerms = value; }
        }
        public string PortOfLoading
        {
            get { return strPortOfLoading; }
            set { strPortOfLoading = value; }
        }
        public string PortOfDischarges
        {
            get { return strPortOfDischarges; }
            set { strPortOfDischarges = value; }
        }
        public string PurchaserId
        {
            get { return strPurchaserId; }
            set { strPurchaserId = value; }
        }
        public string SupplierId
        {
            get { return strSupplierId; }
            set { strSupplierId = value; }
        }
        public string DeliverToId
        {
            get { return strDeliverToId; }
            set { strDeliverToId = value; }
        }
        public string PaymentModeId
        {
            get { return strPaymentModeId; }
            set { strPaymentModeId = value; }
        }
        public string TranshipmentId
        {
            get { return strTranshipmentId; }
            set { strTranshipmentId = value; }
        }
        public string PartshipmentId
        {
            get { return strPartshipmentId; }
            set { strPartshipmentId = value; }
        }
        public string TranId
        {
            get { return strTranId; }
            set { strTranId = value; }
        }
        
        

       

    }
}

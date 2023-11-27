﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO
{
    public class POEntryDTO
    {
        private string strUpdateBy;
        private string strHeadOfficeId;
        private string strBranchOfficeId;

        private string strPONo;
        private string strPODate;
        private string strPOTypeId;
        private string strBuyerId;
        private string strStyleNo;
        private string strStyleId;
        private string strColorId;
        private string strUnitRate;
        private string strQuantity;
        private string strTranId;
        private string strRemarks;
        private string strAmount;
        private string strPoType;
        private string strColorFullName;
        private string strChkYN;
        //private string strInvoiceNo;
        //private string strInvoiceDate;

        //public string InvoiceDate
        //{
        //    get { return strInvoiceDate; }
        //    set { strInvoiceDate = value; }
        //}
        //public string InvoiceNo
        //{
        //    get { return strInvoiceNo; }
        //    set { strInvoiceNo = value; }
        //}
        public string ChkYN
        {
            get { return strChkYN; }
            set { strChkYN = value; }
        }
        public string ColorFullName
        {
            get { return strColorFullName; }
            set { strColorFullName = value; }
        }
        public string PoType
        {
            get { return strPoType; }
            set { strPoType = value; }
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

        public string UnitRate
        {
            get { return strUnitRate; }
            set { strUnitRate = value; }
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
        public string PODate
        {
            get { return strPODate; }
            set { strPODate = value; }
        }
        public string POTypeId
        {
            get { return strPOTypeId; }
            set { strPOTypeId = value; }
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
       
         public string ColorId
        {
            get { return strColorId; }
            set { strColorId = value; }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO
{
    public class ShipmentEntryDTO
    {

        private string strPOId;
        private string strPONo;
        private string strPODate;
        private string strPOTypeId;
        private string strBuyerId;
        private string strStyleNo;
        private string strColorId;
        private string strUnitRate;
        private string strQuantity;
        private string strRemarks;
        private string strPOFromDate;
        private string strPOToDate;
        private string strLineId;
        private string strPOAssignOfficeId;
        private string strPOTypeName;
        private string strBuyerName;
        private string strInvoiceFromDate;
        private string strInvoiceToDate;
        private string strInvoiceNo;
        private string strInvoiceDate;
        private string strShipmentDate;
        private string strAmount;
        private string strBranchOfficeIdAll;

        private string strUpdateBy;
        private string strHeadOfficeId;
        private string strBranchOfficeId;


        public string BranchOfficeIdAll
        {

            get { return strBranchOfficeIdAll; }
            set { strBranchOfficeIdAll = value; }

        }
        public string InvoiceNo
        {

            get { return strInvoiceNo; }
            set { strInvoiceNo = value; }

        }
        public string Amount
        {

            get { return strAmount; }
            set { strAmount = value; }

        }

        public string InvoiceDate
        {

            get { return strInvoiceDate; }
            set { strInvoiceDate = value; }

        }

        public string ShipmentDate
        {

            get { return strShipmentDate; }
            set { strShipmentDate = value; }

        }

        public string POId
        {

            get { return strPOId; }
            set { strPOId = value; }

        }

        public string InvoiceFromDate
        {

            get { return strInvoiceFromDate; }
            set { strInvoiceFromDate = value; }

        }

        public string InvoiceToDate
        {

            get { return strInvoiceToDate; }
            set { strInvoiceToDate = value; }

        }

        public string BuyerName
        {

            get { return strBuyerName; }
            set { strBuyerName = value; }

        }

        public string POTypeName
        {

            get { return strPOTypeName; }
            set { strPOTypeName = value; }

        }

        public string LineId
        {

            get { return strLineId; }
            set { strLineId = value; }

        }

        public string POFromDate
        {

            get { return strPOFromDate; }
            set { strPOFromDate = value; }

        }

        public string POToDate
        {

            get { return strPOToDate; }
            set { strPOToDate = value; }

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

        public string POAssignOfficeId
        {

            get { return strPOAssignOfficeId; }
            set { strPOAssignOfficeId = value; }

        }

        public string POTypeId
        {

            get { return strPOTypeId; }
            set { strPOTypeId = value; }

        }

        public string BuyerId
        {

            get { return strBuyerId; }
            set { strBuyerId = value; }

        }


        public string StyleNo
        {

            get { return strStyleNo; }
            set { strStyleNo = value; }

        }

        public string ColorId
        {

            get { return strColorId; }
            set { strColorId = value; }

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


    }
}

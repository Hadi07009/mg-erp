using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO
{
    public class PurchaseOrderDTO
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
        private string strPOTypeName;
        private string strPOOpenYn;
        private string strPOCloseYn;
        private string strStyleId;
        private string strSizeIdForQuantity;
        private string strSizeIdForPOPrice;
        private string strDeliveryDate;
        private string strPrice;
        private string strHangerCost;
        private string strUnitCost;
        private string strUpdateBy;
        private string strHeadOfficeId;
        private string strBranchOfficeId;
        private string strAmount;
        private string strItemsDescription;
        private string strShipingAddress;
        private string strItemDesciptionId;
        private string strShippingAddressId;





        public string ItemDesciptionId
        {

            get { return strItemDesciptionId; }
            set { strItemDesciptionId = value; }

        }

        public string ShippingAddressId
        {

            get { return strShippingAddressId; }
            set { strShippingAddressId = value; }

        }

        public string ShipingAddress
        {

            get { return strShipingAddress; }
            set { strShipingAddress = value; }

        }
        public string ItemsDescription
        {

            get { return strItemsDescription; }
            set { strItemsDescription = value; }

        }

        public string Amount
        {

            get { return strAmount; }
            set { strAmount = value; }

        }
        public string UnitCost
        {

            get { return strUnitCost; }
            set { strUnitCost = value; }

        }
        public string HangerCost
        {

            get { return strHangerCost; }
            set { strHangerCost = value; }

        }
        public string sizeIdForQuantity
        {

            get { return strSizeIdForQuantity; }
            set { strSizeIdForQuantity = value; }

        }

        public string SizeIdForPOPrice
        {

            get { return strSizeIdForPOPrice; }
            set { strSizeIdForPOPrice = value; }

        }

        public string POId
        {

            get { return strPOId; }
            set { strPOId = value; }

        }

        public string Price
        {

            get { return strPrice; }
            set { strPrice = value; }

        }

        public string DeliveryDate
        {

            get { return strDeliveryDate; }
            set { strDeliveryDate = value; }

        }

        public string StyleId
        {

            get { return strStyleId; }
            set { strStyleId = value; }

        }


        public string POOpenYn
        {

            get { return strPOOpenYn; }
            set { strPOOpenYn = value; }

        }
        public string POCloseYn
        {

            get { return strPOCloseYn; }
            set { strPOCloseYn = value; }

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

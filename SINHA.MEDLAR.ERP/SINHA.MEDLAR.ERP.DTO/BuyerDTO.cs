using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO
{
    public class BuyerDTO
    {

        private string strBuyerID;
        private string strBuyerCode;
        private string strBuyerName;
        private string strBuyerShortName;
        private string strBuyerFullName;
        private string strEmailAddress;
        private string strContactNo;
        private string strActiveYn;
        private string strAddress;
        private string strUpdateBy;
        private string strHeadOfficeId;
        private string strBranchOfficeId;

        private string strSupplierId;
        private string strSupplierName;
        private string strSupplierTypeId;

        public string SupplierId
        {
            get { return strSupplierId; }
            set { strSupplierId = value; }

        }

        public string SupplierName
        {
            get { return strSupplierName; }
            set { strSupplierName = value; }

        }

        public string SupplierTypeId
        {
            get { return strSupplierTypeId; }
            set { strSupplierTypeId = value; }

        }

        public string BuyerId
        {
            get { return strBuyerID; }
            set { strBuyerID = value;} 

        }

        public string BuyerCode
        {
            get { return strBuyerCode; }
            set { strBuyerCode = value; }

        }

        public string BuyerName
        {
            get { return strBuyerName; }
            set { strBuyerName = value; }

        }

        public string BuyerShortName
        {
            get { return strBuyerShortName; }
            set { strBuyerShortName = value; }

        }

        public string BuyerFullName
        {
            get { return strBuyerFullName; }
            set { strBuyerFullName = value; }

        }

        public string EmailAddress
        {
            get { return strEmailAddress; }
            set { strEmailAddress = value; }

        }

        public string ContactNo
        {
            get { return strContactNo; }
            set { strContactNo = value; }

        }

        public string ActiveYn
        {
            get { return strActiveYn; }
            set { strActiveYn = value; }

        }

        public string Address
        {
            get { return strAddress; }
            set { strAddress = value; }

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

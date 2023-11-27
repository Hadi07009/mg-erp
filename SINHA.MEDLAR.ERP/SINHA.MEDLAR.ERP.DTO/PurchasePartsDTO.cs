using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO
{
    public class PurchasePartsDTO
    {
        private string strTranId;
        private string strPONo;
        private string strMachineId;
        private string strSupplierId;
        private string strPartNo;
        private string strParticularName;
        private string strPurchaseQuantity;
        private string strUnitPrice;
        private string strTotalPrice;
        private string strRemarks;
        private string strCurrencyId;
        private string strEquipmentId;

        private string strHeadOfficeId;
        private string strBranchOfficeId;
        private string strUpdateBy;
        private string strRefNo;
        public string RequisitionNo { get; set; }

        public string EquipmentId
        {
            get { return strEquipmentId; }
            set { strEquipmentId = value; }

        }

        public string RefNo
        {
            get { return strRefNo; }
            set { strRefNo = value; }

        }
        public string CurrencyId
        {
            get { return strCurrencyId; }
            set { strCurrencyId = value; }

        }

        public string Remarks
        {
            get { return strRemarks; }
            set { strRemarks = value; }

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


        public string MachineId
        {
            get { return strMachineId; }
            set { strMachineId = value; }

        }



        public string SupplierId
        {
            get { return strSupplierId; }
            set { strSupplierId = value; }

        }


        public string PartNo
        {
            get { return strPartNo; }
            set { strPartNo = value; }

        }



        public string ParticularName
        {
            get { return strParticularName; }
            set { strParticularName = value; }

        }

        public string PurchaseQuantity
        {
            get { return strPurchaseQuantity; }
            set { strPurchaseQuantity = value; }

        }

        public string UnitPrice
        {
            get { return strUnitPrice; }
            set { strUnitPrice = value; }

        }

        public string TotalPrice
        {
            get { return strTotalPrice; }
            set { strTotalPrice = value; }

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

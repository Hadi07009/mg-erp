using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO
{
    public class FabricsImportRatioDTO
    {
        public string strUpdateBy;
        public string strHeadOfficeId;
        public string strBranchOfficeId;

        public string strContactNo;
        public string strIssueDate;
        public string strPONo;
        public string strStyleNo;
        public string strSizeId;
        public string strBuyerId;
        public string strSeasonId;
        public string strOrderQuantity;
        public string strYY;
        public string strQuantity;
        public string strTranId;
        public string strAmendmentDate;
        private string strFobDate;
        private string strFobOrginalDate;
        private string strFabricYard;
        private string strTotalQty;


        public string TotalQty
        {
            get { return strTotalQty; }
            set { strTotalQty = value; }
        }
        public string FabricYard
        {
            get { return strFabricYard; }
            set { strFabricYard = value; }
        }

        public string FobOrginalDate
        {
            get { return strFobOrginalDate; }
            set { strFobOrginalDate = value; }
        }

        public string FobDate
        {
            get { return strFobDate; }
            set { strFobDate = value; }
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

        public string ContactNo 
        {
            get { return strContactNo; }
            set { strContactNo = value; }
        }
        public string IssueDate
        {
            get { return strIssueDate; }
            set { strIssueDate = value; }
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
        public string SizeId
        {
            get { return strSizeId; }
            set { strSizeId = value; }
        }
        public string BuyerId
        {
            get { return strBuyerId; }
            set { strBuyerId = value; }
        }
        public string SeasonId
        {
            get { return strSeasonId; }
            set { strSeasonId = value; }
        }
        public string OrderQuantity
        {
            get { return strOrderQuantity; }
            set { strOrderQuantity = value; }
        }
        public string YY
        {
            get { return strYY; }
            set { strYY = value; }
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

        public string AmendmentDate
        {
            get { return strAmendmentDate; }
            set { strAmendmentDate = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO
{
    public class ForeignFabricLcIssueDTO
    {

        private string strIssueDate;
        private string strChallanNo;
        private string strSupplierId;
        private string strProgrammeId;
        private string strColorId;
        private string strFabricId;
        private string strConstructionId;
        private string strQuantity;
        private string strRemainingQuantity;
        private string strUnitId;
        private string strStyleId;
        private string strStoreLocationId;
        private string strChallanNoSearch;
        private string strYearSearch;
        private string strLotSearch;
        private string strBalance;
        private string strBalanceQuantity;
        private string strArtId;
        private string strCurrencyRate;
      
        private string strTranId;
        private string strHeadOfficeId;
        private string strBranchOfficeId;
        private string strUpdateBy;
        private string strUpdateDate;
        private string strYear;
        private string strFabricConstructionId;


        private string strReceiveQty;
       
        private string strIssueQty;


        public string ReceiveQty
        {
            get { return strReceiveQty; }
            set { strReceiveQty = value; }
        }

        public string IssueQty
        {
            get { return strIssueQty; }
            set { strIssueQty = value; }
        }

        public string RemainingQuantity
        {
            get { return strRemainingQuantity; }
            set { strRemainingQuantity = value; }
        }

        public string Year
        {
            get { return strYear; }
            set { strYear = value; }
        }
        public string FabricConstructionId
        {
            get { return strFabricConstructionId; }
            set { strFabricConstructionId = value; }
        }
        public string TranId
        {
            get { return strTranId; }
            set { strTranId = value; }
        }
        public string IssueDate
        {
            get { return strIssueDate; }
            set { strIssueDate = value; }
        }
        public string ChallanNo
        {
            get { return strChallanNo; }
            set { strChallanNo = value; }
        }
        public string SupplierId
        {
            get { return strSupplierId; }
            set { strSupplierId = value; }
        }
        public string ProgrammeId
        {
            get { return strProgrammeId; }
            set { strProgrammeId = value; }
        }
        public string ColorId
        {
            get { return strColorId; }
            set { strColorId = value; }
        }
        public string FabricId
        {
            get { return strFabricId; }
            set { strFabricId = value; }
        }
        public string ConstructionId
        {
            get { return strConstructionId; }
            set { strConstructionId = value; }
        }
        public string Quantity
        {
            get { return strQuantity; }
            set { strQuantity = value; }
        }
        public string UnitId
        {
            get { return strUnitId; }
            set { strUnitId = value; }
        }
        public string Balance
        {
            get { return strBalance; }
            set { strBalance = value; }
        }
        public string BalanceQuantity
        {
            get { return strBalanceQuantity; }
            set { strBalanceQuantity = value; }
        }
        public string StyleId
        {
            get { return strStyleId; }
            set { strStyleId = value; }
        }
        public string StoreLocationId
        {
            get { return strStoreLocationId; }
            set { strStoreLocationId = value; }
        }
        public string ChallanNoSearch
        {
            get { return strChallanNoSearch; }
            set { strChallanNoSearch = value; }
        }
        public string YearSearch
        {
            get { return strYearSearch; }
            set { strYearSearch = value; }
        }
        public string LotSearch
        {
            get { return strLotSearch; }
            set { strLotSearch = value; }
        }

        public string ArtId
        {
            get { return strArtId; }
            set { strArtId = value; }
        }
        public string CurrencyRate
        {
            get { return strCurrencyRate; }
            set { strCurrencyRate = value; }
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
        public string UpdateDate
        {
            get { return strUpdateDate; }
            set { strUpdateDate = value; }
        }

    }
}

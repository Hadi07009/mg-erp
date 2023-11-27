using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO
{
    public class CartoonPriceListDTO
    {
        private string strCartoonPriceId;
        private string strSupplierId;
        private string strPlyId;
        private string strLength;
        private string strWidth;
        private string strHeight;
        private string strPerticulars;
        private string strMesurementUnit;
        private string strRateId;
        private string strHeadOfficeId;
        private string strBranchOfficeId;
        private string strUpdateBy;
        private string strUpdateDate;

        public string SupplierId
        {
            get { return strSupplierId; }
            set { strSupplierId = value; }
        }
        public string CartoonPriceId
        {
            get { return strCartoonPriceId; }
            set { strCartoonPriceId = value; }
        }
        public string PlyId
        {
            get { return strPlyId; }
            set { strPlyId = value; }
        }
        public string Length
        {
            get { return strLength; }
            set { strLength = value; }
        }
        public string Width
        {
            get { return strWidth; }
            set { strWidth = value; }
        }
        public string Height
        {
            get { return strHeight; }
            set { strHeight = value; }
        }
        public string Perticulars
        {
            get { return strPerticulars; }
            set { strPerticulars = value; }
        }
        public string MesurementUnit
        {
            get { return strMesurementUnit; }
            set { strMesurementUnit = value; }
        }
        public string RateId
        {
            get { return strRateId; }
            set { strRateId = value; }
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
            get { return UpdateDate; }
            set { UpdateDate = value; }
        }
    }
}

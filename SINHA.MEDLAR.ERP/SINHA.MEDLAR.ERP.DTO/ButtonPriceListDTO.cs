using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO
{
   public class ButtonPriceListDTO
    {
        private string strParticulars;
        private string strColorId;
        private string strLineId;
        private string strArtId;
        private string strMUnit;
        private string strRateUS;
        private string strButtonPriceListId;
        private string strSupplierId;
        private string strHeadOfficeId;
        private string strBranchOfficeId;
        private string strUpdateBy;


        public string SupplierId
        {
            get { return strSupplierId; }
            set { strSupplierId = value; }

        }
        public string Particulars
        {
            get { return strParticulars; }
            set { strParticulars = value; }

        }
        public string ColorId
        {
            get { return strColorId; }
            set { strColorId = value; }

        }

        public string LineId
        {
            get { return strLineId; }
            set { strLineId = value; }

        }
        public string ArtId
        {
            get { return strArtId; }
            set { strArtId = value; }

        }

        public string MUnit
        {
            get { return strMUnit; }
            set { strMUnit = value; }

        }
        public string RateUS
        {
            get { return strRateUS; }
            set { strRateUS = value; }

        }
        public string ButtonPriceListId
        {
            get { return strButtonPriceListId; }
            set { strButtonPriceListId = value; }

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

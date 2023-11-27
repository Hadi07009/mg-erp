using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO
{
    public class HangerPriceDTO
    {

        private string strHangerId;
        private string strSupplierId;
        private string strCurrencyId;
        private string strBuyerId;
        private string strBrandId;
        private string strHangerSize;
        private string strPriceRate;
        private string strThreadCount;
        private string strParticulars;
        private string strStyleId;
        private string strColorId;

        private string strUpdateBy;
        private string strHeadOfficeId;
        private string strBranchOfficeId;


        public string ColorId
        {

            get { return strColorId; }
            set { strColorId = value; }

        }
        public string StyleId
        {

            get { return strStyleId; }
            set { strStyleId = value; }

        }
        public string Particulars
        {

            get { return strParticulars; }
            set { strParticulars = value; }

        }
        public string HangerId
        {

            get { return strHangerId; }
            set { strHangerId = value; }

        }


        public string SupplierId
        {

            get { return strSupplierId; }
            set { strSupplierId = value; }

        }


        public string CurrencyId
        {

            get { return strCurrencyId; }
            set { strCurrencyId = value; }

        }


        public string BuyerId
        {

            get { return strBuyerId; }
            set { strBuyerId = value; }

        }

        public string BrandId
        {

            get { return strBrandId; }
            set { strBrandId = value; }

        }

        public string HangerSize
        {

            get { return strHangerSize; }
            set { strHangerSize = value; }

        }


        public string PriceRate
        {

            get { return strPriceRate; }
            set { strPriceRate = value; }

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

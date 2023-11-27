using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO
{
    public class FactoryDTO
    {

        private string strFactoryId;
        private string strFactoryName;
        private string strBankAddress;
        private string strContactNo;
        private string strMobileNo;
        private string strPhoneNo;
        private string strFaxNo;
        private string strEmailAddress;
        private string strFactoryAddress;
        private string strActiveYn;
        private string strOfficeAddress;


        private string strUpdateBy;
        private string strHeadOfficeId;
        private string strBranchOfficeId;


        public string FactoryId
        {
            get { return strFactoryId;}
            set { strFactoryId = value;} 

        }

        public string FactoryName
        {
            get { return strFactoryName; }
            set { strFactoryName = value; }

        }

        public string BankAddress
        {
            get { return strBankAddress; }
            set { strBankAddress = value; }

        }

        public string ContactNo
        {
            get { return strContactNo; }
            set { strContactNo = value; }

        }
        public string MobileNo
        {
            get { return strMobileNo; }
            set { strMobileNo = value; }

        }
        public string PhoneNo
        {
            get { return strPhoneNo; }
            set { strPhoneNo = value; }

        }

        public string FaxNo
        {
            get { return strFaxNo; }
            set { strFaxNo = value; }

        }

        public string EmailAddress
        {
            get { return strEmailAddress; }
            set { strEmailAddress = value; }

        }

        public string FactoryAddress
        {
            get { return strFactoryAddress; }
            set { strFactoryAddress = value; }

        }

        public string OfficeAddress
        {
            get { return strOfficeAddress; }
            set { strOfficeAddress = value; }

        }

        public string ActiveYn
        {
            get { return strActiveYn; }
            set { strActiveYn = value; }

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

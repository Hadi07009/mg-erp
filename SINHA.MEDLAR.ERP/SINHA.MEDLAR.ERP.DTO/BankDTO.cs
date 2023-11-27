using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO
{
    public class BankDTO
    {

        private string strBankId;
        private string strBankName;
        private string strBankAddress;
        private string strContactNo;
        private string strMobileNo;
        private string strPhoneNo;
        private string strFaxNo;
        private string strEmailAddress;
        private string strFactoryAddress;
        private string strActiveYn;
        private string strOfficeAddress;
        private string strAccountNo;
        private string strSwiftCode;

        private string strUpdateBy;
        private string strHeadOfficeId;
        private string strBranchOfficeId;


        public string BankId
        {
            get { return strBankId; }
            set { strBankId = value; }

        }

        public string AccountNo
        {
            get { return strAccountNo; }
            set { strAccountNo = value; }

        }

        public string SwiftCode
        {
            get { return strSwiftCode; }
            set { strSwiftCode = value; }

        }

        public string BankName
        {
            get { return strBankName; }
            set { strBankName = value; }

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

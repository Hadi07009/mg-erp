using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO
{
    public class EidBonusDTO
    {

        private string strEmployeeId;
        private string strDepartmentId;
        private string strUnitId;
        private string strSectionId;
        private string strCatagoryId;
        private string strEidId;
        private string strBonusYear;
        private string strBonusMonth;
        private string strBonusTypeId;
        private string strEidTypeId;
        private string strCardNo;
        private string strTotalYear;
        private string strTotalMonth;


        private string strUpdateBy;
        private string strUpdateDate;
        private string strHeadOfficeId;
        private string strBranchOfficeId;




        public string TotalYear
        {
            get { return strTotalYear; }
            set { strTotalYear = value; }

        }

        public string TotalMonth
        {
            get { return strTotalMonth; }
            set { strTotalMonth = value; }

        }

        public string BonusTypeId
        {
            get { return strBonusTypeId; }
            set { strBonusTypeId = value; }

        }

        public string CardNo
        {
            get { return strCardNo; }
            set { strCardNo = value; }

        }

        public string EmployeeId
        {
            get { return strEmployeeId; }
            set { strEmployeeId = value; }

        }

        public string BonusYear
        {
            get { return strBonusYear; }
            set { strBonusYear = value; }

        }

        public string EidId
        {
            get { return strEidId; }
            set { strEidId = value; }

        }

        public string BonusMonth
        {
            get { return strBonusMonth; }
            set { strBonusMonth = value; }

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

        public string DepartmentId
        {
            get { return strDepartmentId; }
            set { strDepartmentId = value; }

        }
        public string UnitId
        {
            get { return strUnitId; }
            set { strUnitId = value; }

        }
        public string SectionId
        {
            get { return strSectionId; }
            set { strSectionId = value; }

        }
        public string CatagoryId
        {
            get { return strCatagoryId; }
            set { strCatagoryId = value; }

        }

        public string EidTypeId
        {
            get { return strEidTypeId; }
            set { strEidTypeId = value; }

        }








    }
}

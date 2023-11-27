using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO
{
    public class AprovedEmployeeDTO
    {
        private string strHeadOfficeId;
        private string strBranchOfficeId;
        private string strUpdateBy;

        private string strEmployeeId;
        private string strEmployeeName;
        private string strCardNo;
        private string strUnitId;
        private string strSectionId;

        private string strAprovedYear;
        private string strMonth;

        private string strDesignationId;
        private string strDesignationName;

        private string strAprovedMonth;
        private string strEmpId;

        public string EmpId
        {
            get { return strEmpId; }
            set { strEmpId = value; }

        }
        public string DesignationId
        {
            get { return strDesignationId; }
            set { strDesignationId = value; }

        }
        public string SectionId
        {
            get { return strSectionId; }
            set { strSectionId = value; }

        }
        public string UnitId
        {
            get { return strUnitId; }
            set { strUnitId = value; }

        }
        public string AprovedMonth
        {
            get { return strAprovedMonth; }
            set { strAprovedMonth = value; }

        }
        public string AprovedYear
        {
            get { return strAprovedYear; }
            set { strAprovedYear = value; }

        }

        public string Month
        {
            get { return strMonth; }
            set { strMonth = value; }

        }


        public string EmployeeId
        {
            get { return strEmployeeId; }
            set { strEmployeeId = value; }

        }
        public string EmployeeName
        {
            get { return strEmployeeName; }
            set { strEmployeeName = value; }

        }
        public string CardNo
        {
            get { return strCardNo; }
            set { strCardNo = value; }

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

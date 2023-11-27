using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO
{
    public class TransferDTO
    {
        private string strTransferId;
        private string strEmployeeId;
        private string strEmployeeName;
        private string strTransferDate;
        private string strEffectiveDate;
        private string strOrderDate;
        private string strApprovedBy;
        private string strRemarks;

        private string strDepartmentId;
        private string strUnitId;
        private string strSectionId;
        private string strDesignationId;
        private string strCatagoryId;

        private string strUpdateBy;
        private string strHeadOfficeId;
        private string strBranchOfficeId;


        private string strUnitIdTo;
        private string strSectionIdTo;
        private string strCatagoryIdTo;

        private string strUnitIdFrom;
        private string strSectionIdFrom;
        private string strCatagoryIdFrom;


        private string strYear;
        private string strMonth;

        private string strHeadOfficeIdFrom;
        private string strHeadOfficeIdTo;

        private string strBranchOfficeIdFrom;
        private string strBranchOfficeIdTo;


        public string BranchOfficeIdFrom
        {
            get { return strBranchOfficeIdFrom; }
            set { strBranchOfficeIdFrom = value; }
        }
        public string BranchOfficeIdTo
        {
            get { return strBranchOfficeIdTo; }
            set { strBranchOfficeIdTo = value; }
        }

        public string TransferId
        {
            get { return strTransferId; }
            set { strTransferId = value; }
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


        public string UnitIdTo
        {
            get { return strUnitIdTo; }
            set { strUnitIdTo = value; }
        }

        public string SectionIdTo
        {
            get { return strSectionIdTo; }
            set { strSectionIdTo = value; }
        }

        public string CatagoryIdTo
        {
            get { return strCatagoryIdTo; }
            set { strCatagoryIdTo = value; }
        }



        public string UnitIdFrom
        {
            get { return strUnitIdFrom; }
            set { strUnitIdFrom = value; }
        }

        public string SectionIdFrom
        {
            get { return strSectionIdFrom; }
            set { strSectionIdFrom = value; }
        }

        public string CatagoryIdFrom
        {
            get { return strCatagoryIdFrom; }
            set { strCatagoryIdFrom = value; }
        }

        public string OrderDate
        {
            get { return strOrderDate; }
            set { strOrderDate = value; }
        }

        public string ApprovedBy
        {
            get { return strApprovedBy; }
            set { strApprovedBy = value; }
        }
        public string TransferDate
        {
            get { return strTransferDate; }
            set { strTransferDate = value; }
        }

        public string EffectiveDate
        {
            get { return strEffectiveDate; }
            set { strEffectiveDate = value; }
        }


        public string Remarks
        {
            get { return strRemarks; }
            set { strRemarks = value; }
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

        public string DesignationId
        {
            get { return strDesignationId; }
            set { strDesignationId = value; }
        }


        public string CatagoryId
        {
            get { return strCatagoryId; }
            set { strCatagoryId = value; }
        }


        public string HeadOfficeIdFrom
        {
            get { return strHeadOfficeIdFrom; }
            set { strHeadOfficeIdFrom = value; }
        }

        public string HeadOfficeIdTo
        {
            get { return strHeadOfficeIdTo; }
            set { strHeadOfficeIdTo = value; }
        }


        public string Year
        {
            get { return strYear; }
            set { strYear = value; }
        }

        public string Month
        {
            get { return strMonth; }
            set { strMonth = value; }
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

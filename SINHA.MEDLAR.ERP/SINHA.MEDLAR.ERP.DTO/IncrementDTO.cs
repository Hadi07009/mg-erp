using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO
{
    public class IncrementDTO
    {
        private string strUnitId;
        private string strCatagoryId;
        private string strSectionId;
        private string strYear;
        private string strMonth;
        private string strEmployeeId;

        private string strHeadOfficeId;
        private string strBranchOfficeId;
        private string strIncrementTypeId;
        private string strIncrementAmount;
        private string strUpdateBy;
        private string strEmployeeName;
        private string strCardNo;
        private string strDesignationName;

        private string strFirstSalary;
        private string strLimitDate;
        private string strEffectDateFrom;
        private string strEffectDateTo;
        private string strOfficeId;
        private string strOrderDate;
        private string strEffectDate;
        private string strMonthId;
        private string strScore;
        private string strRemarks;
        private string strSupervisorId;
        private string strGrossSalary;
        private string strEmployeeTypeId;

        public string proposal_id { get; set; }
        public string LockYn { get; set; }
        public int increment_type_id { get; set; }

        public string FirstSalaryCurrent { get; set; }
        public string PreIncrementYear { get; set; }
        public string PreIncrementMonth { get; set; }
        public int as_first_salary { get; set; }
        public string Is_Increment { get; set; }
        public string EmployeeTypeId
        {
            get { return strEmployeeTypeId; }
            set { strEmployeeTypeId = value; }

        }
        public string GrossSalary
        {
            get { return strGrossSalary; }
            set { strGrossSalary = value; }

        }

        public string SupervisorId
        {
            get { return strSupervisorId; }
            set { strSupervisorId = value; }

        }

        public string Remarks
        {
            get { return strRemarks; }
            set { strRemarks = value; }

        }

        public string Score
        {
            get { return strScore; }
            set { strScore = value; }

        }

        public string MonthId
        {
            get { return strMonthId; }
            set { strMonthId = value; }

        }

        public string OrderDate
        {
            get { return strOrderDate; }
            set { strOrderDate = value; }

        }
        public string EffectDate
        {
            get { return strEffectDate; }
            set { strEffectDate = value; }

        }

        public string LimitDate
        {
            get { return strLimitDate; }
            set { strLimitDate = value; }

        }

        public string FirstSalary
        {
            get { return strFirstSalary; }
            set { strFirstSalary = value; }

        }

        public string OfficeId
        {
            get { return strOfficeId; }
            set { strOfficeId = value; }

        }

        public string EffectDateFrom
        {
            get { return strEffectDateFrom; }
            set { strEffectDateFrom = value; }

        }

        public string EffectDateTo
        {
            get { return strEffectDateTo; }
            set { strEffectDateTo = value; }

        }


        public string EmployeeId
        {
            get { return strEmployeeId; }
            set { strEmployeeId = value; }

        }
        public string DesignationName
        {
            get { return strDesignationName; }
            set { strDesignationName = value; }

        }

        public string CardNo
        {
            get { return strCardNo; }
            set { strCardNo = value; }

        }
        public string EmployeeName
        {
            get { return strEmployeeName; }
            set { strEmployeeName = value; }

        }


        public string IncrementAmount
        {
            get { return strIncrementAmount; }
            set { strIncrementAmount = value; }

        }

        public string UnitId
        {
            get { return strUnitId; }
            set { strUnitId = value; }

        }
        public string CatagoryId
        {
            get { return strCatagoryId; }
            set { strCatagoryId = value; }

        }

        public string SectionId
        {
            get { return strSectionId; }
            set { strSectionId = value; }

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

        public string IncrementTypeId
        {
            get { return strIncrementTypeId; }
            set { strIncrementTypeId = value; }

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO
{
    public class SalaryUnitDTO
    {

        private string strSalaryUnitId;
        private string strSalaryUnitCode;
        private string strSalaryUnitName;
        private string strActiveYn;
        private string strUpdateBy;
        private string strHeadOfficeId;
        private string strBranchOfficeId;



        public string SalaryUnitId
        {
            get { return strSalaryUnitId; }
            set { strSalaryUnitId = value; }

        }

        public string SalaryUnitCode
        {
            get { return strSalaryUnitCode; }
            set { strSalaryUnitCode = value; }

        }

        public string SalaryUnitName
        {
            get { return strSalaryUnitName; }
            set { strSalaryUnitName = value; }

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

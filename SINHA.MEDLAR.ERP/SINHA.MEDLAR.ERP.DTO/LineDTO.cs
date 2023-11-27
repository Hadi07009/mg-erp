using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO
{
    public class LineDTO
    {



        private string strLineId;
        private string strLineCode;
        private string strLineName;
        private string strProductionUnitId;
        private string strProductionUnitCode;
        private string strSalaryUnitId;

        private string strActvieYn;
        private string strUpdateBy;
        private string strHeadOfficeId;
        private string strBranchOfficeId;




        public string LineId
        {
            get { return strLineId; }
            set { strLineId = value;} 
        }

        public string LineCode
        {
            get { return strLineCode; }
            set { strLineCode = value; }
        }

        public string LineName
        {
            get { return strLineName; }
            set { strLineName = value; }
        }

        public string ProductionUnitId
        {
            get { return strProductionUnitId; }
            set { strProductionUnitId = value; }
        }

        public string ProductionUnitCode
        {
            get { return strProductionUnitCode; }
            set { strProductionUnitCode = value; }
        }

       

        public string SalaryUnitId
        {
            get { return strSalaryUnitId; }
            set { strSalaryUnitId = value; }
        }

        public string ActvieYn
        {
            get { return strActvieYn; }
            set { strActvieYn = value; }
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

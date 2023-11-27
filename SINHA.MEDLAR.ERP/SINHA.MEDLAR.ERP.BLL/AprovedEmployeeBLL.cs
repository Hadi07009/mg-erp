using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;

namespace SINHA.MEDLAR.ERP.BLL
{
    public class AprovedEmployeeBLL
    {

        public DataTable getMonthId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            AprovedEmployeeDAL objAprovedEmployeeDAL = new AprovedEmployeeDAL();


            dt = objAprovedEmployeeDAL.getMonthId(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }
        public DataTable searchAprovedEmployee(AprovedEmployeeDTO objAprovedEmployeeDTO)
        {

            DataTable dt = new DataTable();
            AprovedEmployeeDAL objAprovedEmployeeDAL = new AprovedEmployeeDAL();


            dt = objAprovedEmployeeDAL.searchAprovedEmployee(objAprovedEmployeeDTO);
            return dt;

        }
        public DataTable searchAprovedEmployeeEntry(AprovedEmployeeDTO objAprovedEmployeeDTO)
        {

            DataTable dt = new DataTable();
            AprovedEmployeeDAL objAprovedEmployeeDAL = new AprovedEmployeeDAL();


            dt = objAprovedEmployeeDAL.searchAprovedEmployeeEntry(objAprovedEmployeeDTO);
            return dt;

        }
        public string addAprovedEmployee(AprovedEmployeeDTO objAprovedEmployeeDTO)
        {

            AprovedEmployeeDAL objAprovedEmployeeDAL = new AprovedEmployeeDAL();
            string strMsg = objAprovedEmployeeDAL.addAprovedEmployee(objAprovedEmployeeDTO);
            return strMsg;
        }

        public string deleteAprovedEmployeeRecord(AprovedEmployeeDTO objAprovedEmployeeDTO)
        {

            AprovedEmployeeDAL objAprovedEmployeeDAL = new AprovedEmployeeDAL();
            string strMsg = objAprovedEmployeeDAL.deleteAprovedEmployeeRecord(objAprovedEmployeeDTO);
            return strMsg;
        }

    }
}

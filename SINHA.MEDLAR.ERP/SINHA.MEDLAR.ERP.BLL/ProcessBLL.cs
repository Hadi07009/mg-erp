using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Data;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;

namespace SINHA.MEDLAR.ERP.BLL
{
    public class ProcessBLL
    {

        public string saveEmployeeProcess(ProcessDTO objProcessDTO)
        {

            ProcessDAL objProcessDAL = new ProcessDAL();
            string strMsg = objProcessDAL.saveEmployeeProcess(objProcessDTO);
            return strMsg;
        }
        public string DeleteEmployeeProcess(ProcessDTO objProcessDTO)
        {

            ProcessDAL objProcessDAL = new ProcessDAL();
            string strMsg = objProcessDAL.DeleteEmployeeProcess(objProcessDTO);
            return strMsg;
        }

        public string saveProductionDefect(ProcessDTO objProcessDTO)
        {

            ProcessDAL objProcessDAL = new ProcessDAL();
            string strMsg = objProcessDAL.saveProductionDefect(objProcessDTO);
            return strMsg;
        }

        public string deleteProductionDefect(ProcessDTO objProcessDTO)
        {

            ProcessDAL objProcessDAL = new ProcessDAL();
            string strMsg = objProcessDAL.deleteProductionDefect(objProcessDTO);
            return strMsg;
        }


        public string saveEfficiencyInfo(ProcessDTO objProcessDTO)
        {

            ProcessDAL objProcessDAL = new ProcessDAL();
            string strMsg = objProcessDAL.saveEfficiencyInfo(objProcessDTO);
            return strMsg;
        }

        public string deleteEfficiencyRecord(ProcessDTO objProcessDTO)
        {

            ProcessDAL objProcessDAL = new ProcessDAL();
            string strMsg = objProcessDAL.deleteEfficiencyRecord(objProcessDTO);
            return strMsg;
        }


        public DataTable showProcessEntry(ProcessDTO objProcessDTO)
        {

            ProcessDAL objProcessDAL = new ProcessDAL();
            DataTable dt = new DataTable();

            dt = objProcessDAL.showProcessEntry(objProcessDTO);
            return dt;

        }

        public DataTable searchProductionDefectEntry(ProcessDTO objProcessDTO)
        {

            ProcessDAL objProcessDAL = new ProcessDAL();
            DataTable dt = new DataTable();

            dt = objProcessDAL.searchProductionDefectEntry(objProcessDTO);
            return dt;

        }

        public DataTable searchEfficiencyEntry(ProcessDTO objProcessDTO)
        {

            ProcessDAL objProcessDAL = new ProcessDAL();
            DataTable dt = new DataTable();

            dt = objProcessDAL.searchEfficiencyEntry(objProcessDTO);
            return dt;

        }


        public ProcessDTO getDefectDays(string strEmployeeId,  string strHeadOfficeId, string strBranchOfficeId, string strFromDate, string strToDate)
        {

            ProcessDTO objProcessDTO = new ProcessDTO();
            ProcessDAL objProcessDAL = new ProcessDAL();

            objProcessDTO = objProcessDAL.getDefectDays(strEmployeeId, strHeadOfficeId, strBranchOfficeId, strFromDate, strToDate);
            return objProcessDTO;

        }

        public ProcessDTO searchEmployeeProcessEntry(string strEmployeeId, string strProcessId, string strEfficencyId, string strHeadOfficeId, string strBranchOfficeId)
        {

            ProcessDTO objProcessDTO = new ProcessDTO();
            ProcessDAL objProcessDAL = new ProcessDAL();

            objProcessDTO = objProcessDAL.searchEmployeeProcessEntry(strEmployeeId, strProcessId, strEfficencyId, strHeadOfficeId, strBranchOfficeId);
            return objProcessDTO;

        }


    }
}

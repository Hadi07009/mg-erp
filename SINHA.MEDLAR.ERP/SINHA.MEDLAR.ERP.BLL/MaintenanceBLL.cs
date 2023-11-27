using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SINHA.MEDLAR.ERP.DAL;
using SINHA.MEDLAR.ERP.DTO;

using System.Data; 

namespace SINHA.MEDLAR.ERP.BLL
{
 public  class MaintenanceBLL
 {

     #region DML


     public string saveMachineInfo(MaintenanceDTO objMaintenanceDTO)
     {
         string strMsg = "";
         MaintenanceDAL objMaintenanceDAL = new MaintenanceDAL();


         strMsg = objMaintenanceDAL.saveMachineInfo(objMaintenanceDTO);
         return strMsg;


     }

     public string saveMachineModelInfo(MaintenanceDTO objMaintenanceDTO)
     {

         MaintenanceDAL objMaintenanceDAL = new MaintenanceDAL();
         string strMsg = "";

         strMsg = objMaintenanceDAL.saveMachineModelInfo(objMaintenanceDTO);
         return strMsg;
     }

     public string saveMAchinePartsInfo(MaintenanceDTO objMaintenanceDTO)
     {

         MaintenanceDAL objMaintenanceDAL = new MaintenanceDAL();
         string strMsg = "";

         strMsg = objMaintenanceDAL.saveMAchinePartsInfo(objMaintenanceDTO);
         return strMsg;
     }

     public string saveMachinePartsReceiveInfo(MaintenanceDTO objMaintenanceDTO)
     {

         MaintenanceDAL objMaintenanceDAL = new MaintenanceDAL();
         string strMsg = "";

         strMsg = objMaintenanceDAL.saveMachinePartsReceiveInfo(objMaintenanceDTO);
         return strMsg;
     }

     public string saveMachinePartsIssueInfo(MaintenanceDTO objMaintenanceDTO)
     {

         MaintenanceDAL objMaintenanceDAL = new MaintenanceDAL();
         string strMsg = "";

         strMsg = objMaintenanceDAL.saveMachinePartsIssueInfo(objMaintenanceDTO);
         return strMsg;
     }

     #endregion

     #region getMethod

     public DataTable getDepartmentId(string strHeadOfficeId, string strBranchOfficeId)
     {

         DataTable dt = new DataTable();
         LookUpDAL objLookUpDAL = new LookUpDAL();


         dt = objLookUpDAL.getDepartmentId(strHeadOfficeId, strBranchOfficeId);
         return dt;

     }

     public DataTable getMachineId(string strHeadOfficeId, string strBranchOfficeId)
     {

         DataTable dt = new DataTable();
         MaintenanceDAL objMaintenanceDAL = new MaintenanceDAL();


         dt = objMaintenanceDAL.getMachineId(strHeadOfficeId, strBranchOfficeId);
         return dt;

     }

     public DataTable getMachineIdSearch(string strHeadOfficeId, string strBranchOfficeId)
     {

         DataTable dt = new DataTable();
         MaintenanceDAL objMaintenanceDAL = new MaintenanceDAL();


         dt = objMaintenanceDAL.getMachineIdSearch(strHeadOfficeId, strBranchOfficeId);
         return dt;

     }
     
     public DataTable getMachineModelId(string strMachineIdId, string strHeadOfficeId, string strBranchOfficeId)
     {

         DataTable dt = new DataTable();
         MaintenanceDAL objMaintenanceDAL = new MaintenanceDAL();


         dt = objMaintenanceDAL.getMachineModelId(strMachineIdId, strHeadOfficeId, strBranchOfficeId);
         return dt;

     }

     public DataTable getMachineModelIdSearch(string strMachineIdIdSearch, string strHeadOfficeId, string strBranchOfficeId)
     {

         DataTable dt = new DataTable();
         MaintenanceDAL objMaintenanceDAL = new MaintenanceDAL();


         dt = objMaintenanceDAL.getMachineModelIdSearch(strMachineIdIdSearch, strHeadOfficeId, strBranchOfficeId);
         return dt;

     }

     public DataTable getMachinePartsId(string strMachineModelId, string strHeadOfficeId, string strBranchOfficeId)
     {

         DataTable dt = new DataTable();
         MaintenanceDAL objMaintenanceDAL = new MaintenanceDAL();


         dt = objMaintenanceDAL.getMachinePartsId(strMachineModelId, strHeadOfficeId, strBranchOfficeId);
         return dt;

     }

     public DataTable getMachinePartsIdSearch(string strMachineModelIdSearch, string strHeadOfficeId, string strBranchOfficeId)
     {

         DataTable dt = new DataTable();
         MaintenanceDAL objMaintenanceDAL = new MaintenanceDAL();


         dt = objMaintenanceDAL.getMachinePartsIdSearch(strMachineModelIdSearch, strHeadOfficeId, strBranchOfficeId);
         return dt;

     }

     #endregion

     #region SearchMethod

     public MaintenanceDTO searchMachineModelEntry(string strMachineModeltNameId, string strHeadOfficeId, string strBranchOfficeId)
     {

         MaintenanceDTO objMaintenanceDTO = new MaintenanceDTO();
         MaintenanceDAL objMaintenanceDAL = new MaintenanceDAL();

         objMaintenanceDTO = objMaintenanceDAL.searchMachineModelEntry(strMachineModeltNameId, strHeadOfficeId, strBranchOfficeId);
         return objMaintenanceDTO;

     }

     public MaintenanceDTO searchMachinePartsEntry(string strMachinePartsId, string strHeadOfficeId, string strBranchOfficeId)
     {

         MaintenanceDTO objMaintenanceDTO = new MaintenanceDTO();
         MaintenanceDAL objMaintenanceDAL = new MaintenanceDAL();

         objMaintenanceDTO = objMaintenanceDAL.searchMachinePartsEntry(strMachinePartsId, strHeadOfficeId, strBranchOfficeId);
         return objMaintenanceDTO;

     }

     public MaintenanceDTO searchMachinePartsReceivedEntry(string strMachinePartsReceiveId,string strReceivedate, string strHeadOfficeId, string strBranchOfficeId)
     {

         MaintenanceDTO objMaintenanceDTO = new MaintenanceDTO();
         MaintenanceDAL objMaintenanceDAL = new MaintenanceDAL();

         objMaintenanceDTO = objMaintenanceDAL.searchMachinePartsReceivedEntry(strMachinePartsReceiveId,strReceivedate, strHeadOfficeId, strBranchOfficeId);
         return objMaintenanceDTO;

     }

     public MaintenanceDTO searchMachinePartsIssueEntry(string strMachinePartsIssueId, string strHeadOfficeId, string strBranchOfficeId)
     {

         MaintenanceDTO objMaintenanceDTO = new MaintenanceDTO();
         MaintenanceDAL objMaintenanceDAL = new MaintenanceDAL();

         objMaintenanceDTO = objMaintenanceDAL.searchMachinePartsIssueEntry(strMachinePartsIssueId, strHeadOfficeId, strBranchOfficeId);
         return objMaintenanceDTO;

     }

     public DataTable MachinePartsEntrySearch(MaintenanceDTO objMaintenanceDTO)
     {

         MaintenanceDAL objMaintenanceDAL = new MaintenanceDAL();
         DataTable dt = new DataTable();

         dt = objMaintenanceDAL.MachinePartsEntrySearch(objMaintenanceDTO);
         return dt;

     }


     public DataTable MachinePartsReceivedSearch(MaintenanceDTO objMaintenanceDTO)
     {

         MaintenanceDAL objMaintenanceDAL = new MaintenanceDAL();
         DataTable dt = new DataTable();

         dt = objMaintenanceDAL.MachinePartsReceivedSearch(objMaintenanceDTO);
         return dt;

     }

     #endregion


     #region loadMethod

     public DataTable loadMachinPartsInfo(string strHeadOffieId, string strBranchOffieId)
     {

         MaintenanceDTO objMaintenanceDTO = new MaintenanceDTO();
         MaintenanceDAL objMaintenanceDAL = new MaintenanceDAL();
         DataTable dt = new DataTable();

         dt = objMaintenanceDAL.loadMachinPartsInfo(strHeadOffieId, strBranchOffieId);
         return dt;

     }

     public DataTable loadMachineNameInfo(string strHeadOffieId, string strBranchOfficeId)
     {

         MaintenanceDTO objMaintenanceDTO = new MaintenanceDTO();
         MaintenanceDAL objMaintenanceDAL = new MaintenanceDAL();
         DataTable dt = new DataTable();

         dt = objMaintenanceDAL.loadMachineNameInfo(strHeadOffieId, strBranchOfficeId);
         return dt;

     }

     public DataTable loadMachineModelInfo(string strHeadOffieId, string strBranchOfficeId)
     {

         MaintenanceDTO objMaintenanceDTO = new MaintenanceDTO();
         MaintenanceDAL objMaintenanceDAL = new MaintenanceDAL();
         DataTable dt = new DataTable();

         dt = objMaintenanceDAL.loadMachineModelInfo(strHeadOffieId, strBranchOfficeId);
         return dt;

     }

     public DataTable loadMachinePartsReceiveRecord(string strHeadOffieId, string strBranchOffieId)
     {

         MaintenanceDTO objMaintenanceDTO = new MaintenanceDTO();
         MaintenanceDAL objMaintenanceDAL = new MaintenanceDAL();
         DataTable dt = new DataTable();

         dt = objMaintenanceDAL.loadMachinePartsReceiveRecord(strHeadOffieId, strBranchOffieId);
         return dt;

     }

     public DataTable loadMachinePartsIssueRecord(MaintenanceDTO objMaintenanceDTO)
     {

       
         MaintenanceDAL objMaintenanceDAL = new MaintenanceDAL();
         DataTable dt = new DataTable();

         dt = objMaintenanceDAL.loadMachinePartsIssueRecord(objMaintenanceDTO);
         return dt;

     }

     #endregion
    }
}

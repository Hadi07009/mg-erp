using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;

namespace SINHA.MEDLAR.ERP.BLL
{
    public class WorkerProcessBLL
    {

        public string saveWorkerSkillProcess(WokerProcessDTO objWokerProcessDTO)
        {

            string strMsg = "";
            WorkerProcessDAL objWorkerProcessDAL = new WorkerProcessDAL();
            strMsg = objWorkerProcessDAL.saveWorkerSkillProcess(objWokerProcessDTO);
            return strMsg;

        }

        public string deleteWorkerProcess(WokerProcessDTO objWokerProcessDTO)
        {

            string strMsg = "";
            WorkerProcessDAL objWorkerProcessDAL = new WorkerProcessDAL();
            strMsg = objWorkerProcessDAL.deleteWorkerProcess(objWokerProcessDTO);
            return strMsg;

        }

        public string saveMachineDetailInformation(WokerProcessDTO objWokerProcessDTO)
        {

            string strMsg = "";
            WorkerProcessDAL objWorkerProcessDAL = new WorkerProcessDAL();
            strMsg = objWorkerProcessDAL.saveMachineDetailInformation(objWokerProcessDTO);
            return strMsg;

        }

        public string saveMachineTypeInfo(WokerProcessDTO objWokerProcessDTO)
        {

            string strMsg = "";
            WorkerProcessDAL objWorkerProcessDAL = new WorkerProcessDAL();
            strMsg = objWorkerProcessDAL.saveMachineTypeInfo(objWokerProcessDTO);
            return strMsg;

        }

        public string saveMachineRegionInfo(WokerProcessDTO objWokerProcessDTO)
        {

            string strMsg = "";
            WorkerProcessDAL objWorkerProcessDAL = new WorkerProcessDAL();
            strMsg = objWorkerProcessDAL.saveMachineRegionInfo(objWokerProcessDTO);
            return strMsg;

        }

        public string saveMachineModel(WokerProcessDTO objWokerProcessDTO)
        {

            string strMsg = "";
            WorkerProcessDAL objWorkerProcessDAL = new WorkerProcessDAL();
            strMsg = objWorkerProcessDAL.saveMachineModel(objWokerProcessDTO);
            return strMsg;

        }

        public string saveMachineBrand(WokerProcessDTO objWokerProcessDTO)
        {

            string strMsg = "";
            WorkerProcessDAL objWorkerProcessDAL = new WorkerProcessDAL();
            strMsg = objWorkerProcessDAL.saveMachineBrand(objWokerProcessDTO);
            return strMsg;

        }

        public string saveIESize(WokerProcessDTO objWokerProcessDTO)
        {

            string strMsg = "";
            WorkerProcessDAL objWorkerProcessDAL = new WorkerProcessDAL();
            strMsg = objWorkerProcessDAL.saveIESize(objWokerProcessDTO);
            return strMsg;

        }

        public string saveWorkerSkill(WokerProcessDTO objWokerProcessDTO)
        {

            string strMsg = "";
            WorkerProcessDAL objWorkerProcessDAL = new WorkerProcessDAL();
            strMsg = objWorkerProcessDAL.saveWorkerSkill(objWokerProcessDTO);
            return strMsg;

        }

        public DataTable searchMachineEntryResult(WokerProcessDTO objWokerProcessDTO)
        {

            WorkerProcessDAL objWorkerProcessDAL = new WorkerProcessDAL();
            DataTable dt = new DataTable();

            dt = objWorkerProcessDAL.searchMachineEntryResult(objWokerProcessDTO);
            return dt;

        }

        public string deleteWorkerSize(WokerProcessDTO objWokerProcessDTO)
        {

            string strMsg = "";
            WorkerProcessDAL objWorkerProcessDAL = new WorkerProcessDAL();
            strMsg = objWorkerProcessDAL.deleteWorkerSize(objWokerProcessDTO);
            return strMsg;

        }


        public string saveTBInformation(WokerProcessDTO objWokerProcessDTO)
        {

            string strMsg = "";
            WorkerProcessDAL objWorkerProcessDAL = new WorkerProcessDAL();
            strMsg = objWorkerProcessDAL.saveTBInformation(objWokerProcessDTO);
            return strMsg;

        }


    }

}

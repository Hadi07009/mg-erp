using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;

namespace SINHA.MEDLAR.ERP.BLL
{
    public class DailyProductionBLL
    {

        public string saveDailyProductionInfo(DailyProductionDTO objDailyProductionDTO)
        {

            DailyProductionDAL objDailyProductionDAL = new DailyProductionDAL();
            string strMsg = objDailyProductionDAL.saveDailyProductionInfo(objDailyProductionDTO);
            return strMsg;
        }

        public string addPORecord(DailyProductionDTO objDailyProductionDTO)
        {

            DailyProductionDAL objDailyProductionDAL = new DailyProductionDAL();
            string strMsg = objDailyProductionDAL.addPORecord(objDailyProductionDTO);
            return strMsg;
        }

        public DataTable LoadDailyProductionInfoSub(DailyProductionDTO objDailyProductionDTO)
        {

            DataTable dt = new DataTable();
            DailyProductionDAL objDailyProductionDAL = new DailyProductionDAL();


            dt = objDailyProductionDAL.LoadDailyProductionInfoSub(objDailyProductionDTO);
            return dt;

        }

        public DataTable LoadDailyProductionFinalizedRecord(DailyProductionDTO objDailyProductionDTO)
        {

            DataTable dt = new DataTable();
            DailyProductionDAL objDailyProductionDAL = new DailyProductionDAL();


            dt = objDailyProductionDAL.LoadDailyProductionFinalizedRecord(objDailyProductionDTO);
            return dt;

        }

        public DailyProductionDTO searcDailyProductionInfoMain(string strLineId, string strProductionDate,string strHeadOfficeId,string strBranchOfficeId)
        {


            DailyProductionDTO objDailyProductionDTO = new DailyProductionDTO();
            DailyProductionDAL objDailyProductionDAL = new DailyProductionDAL();

            objDailyProductionDTO = objDailyProductionDAL.searcDailyProductionInfoMain( strLineId, strProductionDate, strHeadOfficeId, strBranchOfficeId);

            return objDailyProductionDTO;


        }
    }
}

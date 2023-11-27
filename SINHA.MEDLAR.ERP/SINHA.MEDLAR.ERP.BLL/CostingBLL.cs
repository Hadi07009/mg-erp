using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;


namespace SINHA.MEDLAR.ERP.BLL
{
    public class CostingBLL
    {


        public string saveCostingInfo(CostingDTO objCostingDTO)
        {

            CostingDAL objCostingDAL = new CostingDAL();
            string strMsg = objCostingDAL.saveCostingInfo(objCostingDTO);
            return strMsg;
        }

        public string saveFOBActualCost(FOBDTO objFOBDTO)
        {

            FOBDAL objFOBDAL = new FOBDAL();
            string strMsg = objFOBDAL.saveFOBActualCost(objFOBDTO);
            return strMsg;
        }






        public string deleteFOBActualCostRecord(FOBDTO objFOBDTO)
        {

            FOBDAL objFOBDAL = new FOBDAL();
            string strMsg = objFOBDAL.deleteFOBActualCostRecord(objFOBDTO);
            return strMsg;
        }

        public string processFOBActualCostFromFOBBudget(FOBDTO objFOBDTO)
        {

            FOBDAL objFOBDAL = new FOBDAL();
            string strMsg = objFOBDAL.processFOBActualCostFromFOBBudget(objFOBDTO);
            return strMsg;
        }


        public DataTable searchCostingSubRecord(CostingDTO objCostingDTO)
        {

            DataTable dt = new DataTable();
           CostingDAL objCostingDAL=new CostingDAL();


            dt = objCostingDAL.searchCostingSubRecord(objCostingDTO);
            return dt;

        }

        public DataTable searchFOBActualCostSheetRecord(FOBDTO objFOBDTO)
        {

            DataTable dt = new DataTable();
            FOBDAL objFOBDAL = new FOBDAL();


            dt = objFOBDAL.searchFOBActualCostSheetRecord(objFOBDTO);
            return dt;

        }

        public DataTable FOBActualCostSub(FOBDTO objFOBDTO)
        {

            DataTable dt = new DataTable();
            FOBDAL objFOBDAL = new FOBDAL();


            dt = objFOBDAL.FOBActualCostSub(objFOBDTO);
            return dt;

        }


        public CostingDTO searchCostingMain(string strContactId, string strFOBDate,string strAmendmentDate,  string strPONo, string strStyleNo, string strBuyerId, string strSeasonId, string strHeadOfficeId, string strBranchOfficeId)
        {
            CostingDTO objCostingDTO = new CostingDTO();

            CostingDAL objCostingDAL = new CostingDAL();

            objCostingDTO = objCostingDAL.searchCostingMain(strContactId, strFOBDate, strAmendmentDate,  strPONo, strStyleNo, strBuyerId, strSeasonId, strHeadOfficeId, strBranchOfficeId);

            return objCostingDTO;


        }

        public CostingDTO searchCostingMainRecord(string strContractNo, string strFOBDate, string strAmmendmentDate, string strPONo, string strStyleNo, string strBuyerName, string strSeasonName, string strHeadOfficeId, string strBranchOfficeId)
        {
            CostingDTO objCostingDTO = new CostingDTO();

            CostingDAL objCostingDAL = new CostingDAL();

            objCostingDTO = objCostingDAL.searchCostingMainRecord(strContractNo, strFOBDate, strAmmendmentDate, strPONo, strStyleNo, strBuyerName, strSeasonName, strHeadOfficeId, strBranchOfficeId);

            return objCostingDTO;


        }

        public CostingDTO searchBudgetCostMainRecord(string strContractNo, string strFOBDate, string strAmmendmentDate, string strPONo, string strStyleNo, string strBuyerName, string strSeasonName, string strHeadOfficeId, string strBranchOfficeId)
        {
            CostingDTO objCostingDTO = new CostingDTO();

            CostingDAL objCostingDAL = new CostingDAL();

            objCostingDTO = objCostingDAL.searchBudgetCostMainRecord(strContractNo, strFOBDate, strAmmendmentDate, strPONo, strStyleNo, strBuyerName, strSeasonName, strHeadOfficeId, strBranchOfficeId);

            return objCostingDTO;


        }

        public CostingDTO searchActualCostMainRecord(string strContractNo, string strFOBDate, string strAmmendmentDate, string strPONo, string strStyleNo, string strBuyerName, string strSeasonName, string strHeadOfficeId, string strBranchOfficeId)
        {
            CostingDTO objCostingDTO = new CostingDTO();

            CostingDAL objCostingDAL = new CostingDAL();

            objCostingDTO = objCostingDAL.searchActualCostMainRecord(strContractNo, strFOBDate, strAmmendmentDate, strPONo, strStyleNo, strBuyerName, strSeasonName, strHeadOfficeId, strBranchOfficeId);

            return objCostingDTO;


        }


        public FOBDTO searcPOId(string strContactNo, string strHeadOfficeId, string strBranchOfficeId)
        {


            FOBDTO objFOBDTO = new FOBDTO();
            FOBDAL objFOBDAL = new FOBDAL();

            objFOBDTO = objFOBDAL.searcPOId(strContactNo, strHeadOfficeId, strBranchOfficeId);

            return objFOBDTO;


        }



        public FOBDTO searcStyleId(string strContactNo, string strPOId, string strHeadOfficeId, string strBranchOfficeId)
        {


            FOBDTO objFOBDTO = new FOBDTO();
            FOBDAL objFOBDAL = new FOBDAL();

            objFOBDTO = objFOBDAL.searcStyleId(strContactNo, strPOId, strHeadOfficeId, strBranchOfficeId);

            return objFOBDTO;


        }

        public FOBDTO searcFOBDate(string strBuyerId,  string strContactId, string strPOId,string strStyleId, string strHeadOfficeId, string strBranchOfficeId)
        {


            FOBDTO objFOBDTO = new FOBDTO();
            FOBDAL objFOBDAL = new FOBDAL();

            objFOBDTO = objFOBDAL.searcFOBDate(strBuyerId, strContactId, strPOId, strStyleId, strHeadOfficeId, strBranchOfficeId);

            return objFOBDTO;


        }

        public FOBDTO searcOrderQuantityBYPOStyle(string strBuyerId, string strContactId, string strPOId, string strStyleId, string strHeadOfficeId, string strBranchOfficeId)
        {


            FOBDTO objFOBDTO = new FOBDTO();
            FOBDAL objFOBDAL = new FOBDAL();

            objFOBDTO = objFOBDAL.searcOrderQuantityBYPOStyle(strBuyerId, strContactId, strPOId, strStyleId, strHeadOfficeId, strBranchOfficeId);

            return objFOBDTO;


        }

        public FOBDTO searcIssueDate(string strBuyerId, string strContactId,  string strHeadOfficeId, string strBranchOfficeId)
        {


            FOBDTO objFOBDTO = new FOBDTO();
            FOBDAL objFOBDAL = new FOBDAL();

            objFOBDTO = objFOBDAL.searcIssueDate(strBuyerId, strContactId, strHeadOfficeId, strBranchOfficeId);

            return objFOBDTO;


        }

        public FOBDTO searcAmendmentDate(string strContractId, string strAmendmentId, string strHeadOfficeId, string strBranchOfficeId)
        {


            FOBDTO objFOBDTO = new FOBDTO();
            FOBDAL objFOBDAL = new FOBDAL();

            objFOBDTO = objFOBDAL.searcAmendmentDate(strContractId, strAmendmentId, strHeadOfficeId, strBranchOfficeId);

            return objFOBDTO;


        }


        public FOBDTO searchFOBActualCostMain(string strContactId, string strFOBDate, string strPONo, string strStyleNo, string strBuyerId, string strSeasonId, string strHeadOfficeId, string strBranchOfficeId)
        {


            FOBDTO objFOBDTO = new FOBDTO();
            FOBDAL objFOBDAL = new FOBDAL();

            objFOBDTO = objFOBDAL.searchFOBActualCostMain(strContactId, strFOBDate, strPONo, strStyleNo, strBuyerId, strSeasonId, strHeadOfficeId, strBranchOfficeId);

            return objFOBDTO;


        }

        public FOBDTO FOBActualCostMain(string strBuyerId, string strContactNo, string strFOBDate,  string strHeadOfficeId, string strBranchOfficeId)
        {


            FOBDTO objFOBDTO = new FOBDTO();
            FOBDAL objFOBDAL = new FOBDAL();

            objFOBDTO = objFOBDAL.FOBActualCostMain(strBuyerId, strContactNo, strFOBDate, strHeadOfficeId, strBranchOfficeId);

            return objFOBDTO;


        }



        public DataTable searchFOBActualCost(FOBDTO objFOBDTO)
        {

            DataTable dt = new DataTable();
            FOBDAL objFOBDAL = new FOBDAL();


            dt = objFOBDAL.searchFOBActualCost(objFOBDTO);
            return dt;

        }



        public DataTable searchCostingInfo(CostingDTO objCostingDTO)
        {

            DataTable dt = new DataTable();
            CostingDAL objCostingDAL = new CostingDAL();


            dt = objCostingDAL.searchCostingInfo(objCostingDTO);
            return dt;

        }


        public string deletePerCostingRecord(CostingDTO objCostingDTO)
        {

            CostingDAL objCostingDAL = new CostingDAL();
            string strMsg = objCostingDAL.deletePerCostingRecord(objCostingDTO);
            return strMsg;
        }


    }
}

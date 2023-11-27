using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;

namespace SINHA.MEDLAR.ERP.BLL
{
    public class ProductionBLL
    {
        public string saveDailyProduction(ProductionDTO objProductionDTO)
        {
          
            ProductionDAL objProductionDAL = new ProductionDAL();


            string strMsg = objProductionDAL.saveDailyProduction(objProductionDTO);
            return strMsg;




        }


        public DataTable searchDailyProductionEntry(ProductionDTO objProductionDTO)
        {

            ProductionDAL objProductionDAL = new ProductionDAL();
            DataTable dt = new DataTable();

            dt = objProductionDAL.searchDailyProductionEntry(objProductionDTO);
            return dt;

        }

        public DataTable searchDailyProduction(ProductionDTO objProductionDTO)
        {

            ProductionDAL objProductionDAL = new ProductionDAL();
            DataTable dt = new DataTable();

            dt = objProductionDAL.searchDailyProduction(objProductionDTO);
            return dt;

        }

        public ProductionDTO getOrderQuantity(string strPOId, string strStyleId, string strHeadOfficeId, string strBranchOfficeId)
        {

            ProductionDTO objProductionDTO = new ProductionDTO();
            ProductionDAL objProductionDAL = new ProductionDAL();


            objProductionDTO = objProductionDAL.getOrderQuantity(strPOId, strStyleId, strHeadOfficeId, strBranchOfficeId);
            return objProductionDTO;

        }


    }
}

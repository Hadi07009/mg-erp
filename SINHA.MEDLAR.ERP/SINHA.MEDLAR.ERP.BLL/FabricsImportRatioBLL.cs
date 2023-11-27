using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;
using System.Data;

namespace SINHA.MEDLAR.ERP.BLL
{
    public class FabricsImportRatioBLL
    {
        public string saveFabricsImportRatioInfo(FabricsImportRatioDTO objFabricsRatioDTO)
        {

            FabricsImportRatioDAL objFabricsImportRatioDAL = new FabricsImportRatioDAL();
            string strMsg = objFabricsImportRatioDAL.saveFabricsImportRatioInfo(objFabricsRatioDTO);
            return strMsg;
        }
        public string deleteFabricsImportRatioInfo(FabricsImportRatioDTO objFabricsRatioDTO)
        {

            FabricsImportRatioDAL objFabricsRatioDAL = new FabricsImportRatioDAL();
            string strMsg = objFabricsRatioDAL.deleteFabricsImportRatioInfo(objFabricsRatioDTO);
            return strMsg;
        }
        public DataTable searchFabricsImportRatioRecord(FabricsImportRatioDTO objFabricsRatioDTO)
        {

            DataTable dt = new DataTable();
            FabricsImportRatioDAL objFabricsImportRatioDAL = new FabricsImportRatioDAL();


            dt = objFabricsImportRatioDAL.searchFabricsImportRatioRecord(objFabricsRatioDTO);
            return dt;

        }
        public string deleteFabImportInfoRecord(FabricsImportRatioDTO objFabricsImportRatioDTO)
        {

            FabricsImportRatioDAL objFabricsImportRatioDAL = new FabricsImportRatioDAL();
            string strMsg = objFabricsImportRatioDAL.deleteFabImportInfoRecord(objFabricsImportRatioDTO);
            return strMsg;
        }
        public FabricsImportRatioDTO searchFabImportRatioMain(string strContactNo,string strPONo, string strStyleNo, string strFOBDate, string strFOBOrginalDate, string strHeadOfficeId, string strBranchOfficeId)
        {


            FabricsImportRatioDTO objFabricsImportRatioDTO = new FabricsImportRatioDTO();
            FabricsImportRatioDAL objFabricsImportRatioDAL = new FabricsImportRatioDAL();

            objFabricsImportRatioDTO = objFabricsImportRatioDAL.searchFabImportRatioMain(strContactNo, strPONo, strStyleNo, strFOBDate,strFOBOrginalDate, strHeadOfficeId, strBranchOfficeId);

            return objFabricsImportRatioDTO;


        }

    }
}

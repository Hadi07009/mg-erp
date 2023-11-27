using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;
using System.Data;

namespace SINHA.MEDLAR.ERP.BLL
{
    public class FabricsDetailsBLL
    {
        //public string deleteFabricsDetailsInfo(FabricsDetailsDTO objFabricsDetailsDTO)
        //{

        //    FabricsDetailsDAL objFabricsDetailsDAL = new FabricsDetailsDAL();
        //    string strMsg = objFabricsDetailsDAL.deleteFabricsDetailsInfo(objFabricsDetailsDTO);
        //    return strMsg;
        //}
        public string saveFabricsDetailsInfo(FabricsDetailsDTO objFabricsDetailsDTO)
        {

            FabricsDetailsDAL objFabricsDetailsDAL = new FabricsDetailsDAL();
            string strMsg = objFabricsDetailsDAL.saveFabricsDetailsInfo(objFabricsDetailsDTO);
            return strMsg;
        }
        public DataTable searchFabricsDetailsRecord(FabricsDetailsDTO objFabricsDetailsDTO)
        {

            DataTable dt = new DataTable();
            FabricsDetailsDAL objFabricsDetailsDAL = new FabricsDetailsDAL();


            dt = objFabricsDetailsDAL.searchFabricsDetailsRecord(objFabricsDetailsDTO);
            return dt;

        }
        public FabricsDetailsDTO searchFabricsDetailsRecordMain(string strContactNo, string strPONo, string strStyleNo, string strFobDate, string strHeadOfficeId, string strBranchOfficeId)
        {


            FabricsDetailsDTO objFabricsDetailsDTO = new FabricsDetailsDTO();
            FabricsDetailsDAL objFabricsDetailsDAL = new FabricsDetailsDAL();

            objFabricsDetailsDTO = objFabricsDetailsDAL.searchFabricsDetailsRecordMain(strContactNo, strPONo, strStyleNo, strFobDate, strHeadOfficeId, strBranchOfficeId);

            return objFabricsDetailsDTO;


        }
        public FabricsDetailsDTO getFobDateAndOrderQty(FabricsDetailsDTO objFabricsDetailsDTO)
        {



            FabricsDetailsDAL objFabricsDetailsDAL = new FabricsDetailsDAL();

            objFabricsDetailsDTO = objFabricsDetailsDAL.getFobDateAndOrderQty(objFabricsDetailsDTO);

            return objFabricsDetailsDTO;


        }
    }
}

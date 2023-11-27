using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;

namespace SINHA.MEDLAR.ERP.BLL
{
    public class IssuedProductBLL
    {



        public string saveIssuedProductInfo(IssuedProductDTO objIssuedProductDTO)
        {

            IssuedProductDAL objIssuedProductDAL = new IssuedProductDAL();
            string strMsg = objIssuedProductDAL.saveIssuedProductInfo(objIssuedProductDTO);
            return strMsg;
        }

        public DataTable loadIssuedProductInfo(IssuedProductDTO objIssuedProductDTO)
        {

            DataTable dt = new DataTable();
            IssuedProductDAL objIssuedProductDAL = new IssuedProductDAL();


            dt = objIssuedProductDAL.loadIssuedProductInfo(objIssuedProductDTO);
            return dt;

        }

        public IssuedProductDTO searchIssuedProductInfo(IssuedProductDTO objIssuedProductDTO)
        {

            IssuedProductDAL objIssuedProductDAL = new IssuedProductDAL();

            objIssuedProductDTO = objIssuedProductDAL.searchIssuedProductInfo(objIssuedProductDTO);
            return objIssuedProductDTO;
        }
        public IssuedProductDTO searchSectionId(string strTranId,string strHeadOfficeId,string strBranchOfficeId)
        {
            IssuedProductDTO objIssuedProductDTO = new IssuedProductDTO();
            IssuedProductDAL objIssuedProductDAL = new IssuedProductDAL();

            objIssuedProductDTO = objIssuedProductDAL.searchSectionId(strTranId, strHeadOfficeId, strBranchOfficeId);
            return objIssuedProductDTO;
        }

        //public IssuedProductDTO CheckSavedData(string strPartNo, string strHeadOfficeId, string strBranchOfficeId)
        //{

        //    IssuedProductDTO objIssuedProductDTO = new IssuedProductDTO();
        //    IssuedProductDAL objIssuedProductDAL = new IssuedProductDAL();

        //    objIssuedProductDTO = objIssuedProductDAL.CheckSavedData(strPartNo,strHeadOfficeId, strBranchOfficeId);
        //    return objIssuedProductDTO;
        //}
        public string deleteIssuedProductRecord(IssuedProductDTO objIssuedProductDTO)
        {

            IssuedProductDAL objIssuedProductDAL = new IssuedProductDAL();
            string strMsg = objIssuedProductDAL.deleteIssuedProductRecord(objIssuedProductDTO);
            return strMsg;
        }

    }
}

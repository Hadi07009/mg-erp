using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;


namespace SINHA.MEDLAR.ERP.BLL
{
    public class OfficeTimeBLL
    {

        public string addOfficeTime(OfficeTimeDTO objOfficeTimeDTO)
        {
            string strMsg = "";
            OfficeTimeDAL objOfficeTimeDAL = new OfficeTimeDAL();


            strMsg = objOfficeTimeDAL.addOfficeTime(objOfficeTimeDTO);
            return strMsg;


        }



        public OfficeTimeDTO searchOfficeTime(string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {
            string strMsg = "";
            OfficeTimeDTO objOfficeTimeDTO = new OfficeTimeDTO();
            OfficeTimeDAL objOfficeTimeDAL = new OfficeTimeDAL();


            objOfficeTimeDTO = objOfficeTimeDAL.searchOfficeTime(strUnitId, strSectionId, strHeadOfficeId, strBranchOfficeId);

            return objOfficeTimeDTO;


        }
        public string SaveTimeSetup(OfficeTimeDTO objOfficeTimeDTO)
        {
            string strMsg = "";
            OfficeTimeDAL objOfficeTimeDAL = new OfficeTimeDAL();

            strMsg = objOfficeTimeDAL.SaveTimeSetup(objOfficeTimeDTO);
            return strMsg;
        }
        public string SaveShiftMapping(OfficeTimeDTO objOfficeTimeDTO)
        {
            string strMsg = "";
            OfficeTimeDAL objOfficeTimeDAL = new OfficeTimeDAL();

            strMsg = objOfficeTimeDAL.SaveShiftMapping(objOfficeTimeDTO);
            return strMsg;
        }
        public string SaveShiftTimeMapping(OfficeTimeDTO objOfficeTimeDTO)
        {
            string strMsg = "";
            OfficeTimeDAL objOfficeTimeDAL = new OfficeTimeDAL();

            strMsg = objOfficeTimeDAL.SaveShiftTimeMapping(objOfficeTimeDTO);
            return strMsg;
        }
        public string SaveOTDeductionSetup(OfficeTimeDTO objOfficeTimeDTO)
        {
            string strMsg = "";
            OfficeTimeDAL objOfficeTimeDAL = new OfficeTimeDAL();

            strMsg = objOfficeTimeDAL.SaveOTDeductionSetup(objOfficeTimeDTO);
            return strMsg;
        }






    }
}

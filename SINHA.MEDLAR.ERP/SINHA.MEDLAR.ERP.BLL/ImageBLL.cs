using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;


namespace SINHA.MEDLAR.ERP.BLL
{
    public class ImageBLL
    {

        public string saveEmployeeImage(ImageDTO objImageDTO)
        {
           
            ImageDAL objImageDAL = new ImageDAL();

            string strMsg = objImageDAL.saveEmployeeImage(objImageDTO);
            return strMsg;

        }

        public string deleteEmployeeImage(ImageDTO objImageDTO)
        {

            ImageDAL objImageDAL = new ImageDAL();

            string strMsg = objImageDAL.deleteEmployeeImage(objImageDTO);
            return strMsg;

        }

        public ImageDTO searchEmployeeImage(string strEmployeeId, string strHeadOfficeId, string strBranchOfficeId)
        {
            ImageDTO objImageDTO = new ImageDTO();
            ImageDAL objImageDAL = new ImageDAL();

            objImageDTO = objImageDAL.searchEmployeeImage(strEmployeeId, strHeadOfficeId, strBranchOfficeId);
            return objImageDTO;

        }

    }
}

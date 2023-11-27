using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;

namespace SINHA.MEDLAR.ERP.BLL
{
    public class ContactSheetBLL
    {

        public string saveContactSheetInformation(ContactSheetDTO objContactSheetDTO)
        {
            ContactSheetDAL objContactSheetDAL = new ContactSheetDAL();
            string strMsg = "";


            strMsg = objContactSheetDAL.saveContactSheetInformation(objContactSheetDTO);
            return strMsg;

        }

    }
}

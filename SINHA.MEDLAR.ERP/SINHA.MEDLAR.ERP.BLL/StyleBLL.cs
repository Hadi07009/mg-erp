using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;


namespace SINHA.MEDLAR.ERP.BLL
{
    public class StyleBLL
    {

        public string saveStyleInformation(StyleDTO objStyleDTO)
        {
            StyleDAL objStyleDAL = new StyleDAL();
            string strMsg = "";


            strMsg = objStyleDAL.saveStyleInformation(objStyleDTO);
            return strMsg;

        }


    }
}

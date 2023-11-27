using SINHA.MEDLAR.ERP.DAL;
using SINHA.MEDLAR.ERP.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.BLL
{
   public class PolyBagBLL
    {
        public string savePolybagSentupInfo(PolyBagDTO objPolyBagDTO)
        {
            string strMsg = "";
            PolyBagDAL objPolyBagDAL = new PolyBagDAL();


            strMsg = objPolyBagDAL.savePolybagSentupInfo(objPolyBagDTO);
            return strMsg;


        }

        public DataTable GetPolyBagStyleId()
        {
            DataTable dt = new DataTable();

            
            PolyBagDAL objPolyBagDAL = new PolyBagDAL();

            dt = objPolyBagDAL.GetPolyBagStyleId();
            return dt;
        }
        public DataTable loadPolyBagRecord(PolyBagDTO objPolyBagDTO)
        {
            PolyBagDAL objPolyBagDAL = new PolyBagDAL();
           
            DataTable dt = new DataTable();

            dt = objPolyBagDAL.loadPolyBagRecord(objPolyBagDTO);
            return dt;
        }

        public string deletePolybagSetupEntry(PolyBagDTO objPolyBagDTO)
        {
            string strMsg = "";
            PolyBagDAL objPolyBagDAL = new PolyBagDAL();


            strMsg = objPolyBagDAL.deletePolybagSetupEntry(objPolyBagDTO);
            return strMsg;
        }
    }
}

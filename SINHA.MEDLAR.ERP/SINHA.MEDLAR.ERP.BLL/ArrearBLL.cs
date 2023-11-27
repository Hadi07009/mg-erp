using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Data;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;

namespace SINHA.MEDLAR.ERP.BLL
{
    public class ArrearBLL
    {

        public string processArrear(ArrearDTO objArrearDTO)
        {

            ArrearDAL objArrearDAL = new ArrearDAL();
            string strMsg = objArrearDAL.processArrear(objArrearDTO);
            return strMsg;

        }

        public string saveArrearSetup(ArrearDTO objArrearDTO)
        {

            ArrearDAL objArrearDAL = new ArrearDAL();
            string strMsg = objArrearDAL.saveArrearSetup(objArrearDTO);
            return strMsg;

        }
        public string DiscardUnpaidIncrementArrear(ArrearDTO objArrearDTO)
        {
            ArrearDAL objArrearDAL = new ArrearDAL();
            string strMsg = objArrearDAL.DiscardUnpaidIncrementArrear(objArrearDTO);
            return strMsg;
        }

        public string SyncAdvanceWithIncrementArrear(ArrearDTO objArrearDTO)
        {
            ArrearDAL objArrearDAL = new ArrearDAL();
            string strMsg = objArrearDAL.SyncAdvanceWithIncrementArrear(objArrearDTO);
            return strMsg;
        }
        

        public string processArrearSpecial(ArrearDTO objArrearDTO)
        {

            ArrearDAL objArrearDAL = new ArrearDAL();
            string strMsg = objArrearDAL.processArrearSpecial(objArrearDTO);
            return strMsg;

        }
    }
}

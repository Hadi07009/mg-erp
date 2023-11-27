using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;


namespace SINHA.MEDLAR.ERP.BLL
{
    public class EidBonusBLL
    {
        public string bonusPreparation(EidBonusDTO objEidBonusDTO)
        {

            EidBonusDAL objEidBonusDAL = new EidBonusDAL();
            string strMsg = objEidBonusDAL.bonusPreparation(objEidBonusDTO);
            return strMsg;
        }

        public string saveEidBonusBasicInfo(EidBonusDTO objEidBonusDTO)
        {

            EidBonusDAL objEidBonusDAL = new EidBonusDAL();
            string strMsg = objEidBonusDAL.saveEidBonusBasicInfo(objEidBonusDTO);
            return strMsg;
        }

        public string processBonusOption(EidBonusDTO objEidBonusDTO)
        {

            EidBonusDAL objEidBonusDAL = new EidBonusDAL();
            string strMsg = objEidBonusDAL.processBonusOption(objEidBonusDTO);
            return strMsg;
        }


        public DataTable searchEidBonusBasicInfo(EidBonusDTO objEidBonusDTO)
        {

            DataTable dt = new DataTable();
            EidBonusDAL objEidBonusDAL = new EidBonusDAL();


            dt = objEidBonusDAL.searchEidBonusBasicInfo(objEidBonusDTO);
            return dt;

        }

        public DataTable searchEidBonusAmountInfo(EidBonusDTO objEidBonusDTO)
        {

            DataTable dt = new DataTable();
            EidBonusDAL objEidBonusDAL = new EidBonusDAL();


            dt = objEidBonusDAL.searchEidBonusAmountInfo(objEidBonusDTO);
            return dt;

        }
    }
}

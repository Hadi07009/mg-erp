using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;
using System.Data;

namespace SINHA.MEDLAR.ERP.BLL
{
    public class ShareDistributionBLL
    {
        public string SaveShareDistribution(ShareDistributionDTO objShareDistributionDTO)
        {
            ShareDistributionDAL objShareDistributionDAL = new ShareDistributionDAL();
            string strMsg = "";
            strMsg = objShareDistributionDAL.SaveShareDistribution(objShareDistributionDTO);
            return strMsg;
        }
        public string CalculateShare(ShareDistributionDTO objShareDistributionDTO)
        {
            ShareDistributionDAL objShareDistributionDAL = new ShareDistributionDAL();
            string strMsg = "";
            strMsg = objShareDistributionDAL.CalculateShare(objShareDistributionDTO);
            return strMsg;
        }
        public DataTable GetShareDistribution()
        {
            ShareDistributionDAL objShareDistributionDAL = new ShareDistributionDAL();

            DataTable dt = new DataTable();

            dt = objShareDistributionDAL.GetShareDistribution();
            return dt;
        }
        public string DeleteShare(ShareDistributionDTO objShareDistributionDTO)
        {

            ShareDistributionDAL objShareDistributionDAL = new ShareDistributionDAL();
            string strMsg = objShareDistributionDAL.DeleteShare(objShareDistributionDTO);
            return strMsg;
        }
    }
}

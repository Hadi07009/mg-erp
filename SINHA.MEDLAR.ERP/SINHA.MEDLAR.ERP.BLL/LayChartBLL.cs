using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;
using System.Data;

namespace SINHA.MEDLAR.ERP.BLL
{
    public class LayChartBLL
    {

        public string saveLayChart(LayChartDTO objLayChartDTO)
        {
            string strMsg = "";
            LayChartDAL objLayChartDAL = new LayChartDAL();

            strMsg = objLayChartDAL.saveLayChart(objLayChartDTO);

            return strMsg;
        }

        public string deleteLayChart(LayChartDTO objLayChartDTO)
        {
            string strMsg = "";
            LayChartDAL objLayChartDAL = new LayChartDAL();

            strMsg = objLayChartDAL.deleteLayChart(objLayChartDTO);

            return strMsg;
        }


        public DataTable searchLayChartEntry(LayChartDTO objLayChartDTO)
        {

            DataTable dt = new DataTable();
            LayChartDAL objLayChartDAL = new LayChartDAL();


            dt = objLayChartDAL.searchLayChartEntry(objLayChartDTO);
            return dt;

        }


    }
}

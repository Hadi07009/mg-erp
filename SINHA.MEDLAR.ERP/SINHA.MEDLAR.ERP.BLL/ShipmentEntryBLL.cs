using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;

namespace SINHA.MEDLAR.ERP.BLL
{
    public class ShipmentEntryBLL
    {

        public DataTable searchShipmentInfo(ShipmentEntryDTO objShipmentEntryDTO)
        {

            ShipmentEntryDAL objShipmentEntryDAL = new ShipmentEntryDAL();
            DataTable dt = new DataTable();

            dt = objShipmentEntryDAL.searchShipmentInfo(objShipmentEntryDTO);
            return dt;

        }


        public DataTable searchShipmentEntry(ShipmentEntryDTO objShipmentEntryDTO)
        {

            ShipmentEntryDAL objShipmentEntryDAL = new ShipmentEntryDAL();
            DataTable dt = new DataTable();

            dt = objShipmentEntryDAL.searchShipmentEntry(objShipmentEntryDTO);
            return dt;

        }

        public string saveShipmentEntry(ShipmentEntryDTO objShipmentEntryDTO)
        {
            ShipmentEntryDAL objShipmentEntryDAL = new ShipmentEntryDAL();
            string strMsg = "";

            strMsg = objShipmentEntryDAL.saveShipmentEntry(objShipmentEntryDTO);
            return strMsg;

        }

    }
}

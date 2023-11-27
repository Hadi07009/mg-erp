using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO.ViewModels
{
   public class PackingMaster: BaseModel
    {
         public string packing_master_id { get; set; }
         public string po_no { get; set; }
         public string style_no { get; set; }
         public int buyer_id { get; set; }
         public string buyer_short_name { get; set; }
         public int packing_type_id { get; set; }
         public string packing_type_name { get; set; }
         public int shipment_mode_id { get; set; }
         public string shipment_type_name { get; set; }
         public int season_id { get; set; }
         public string season_name { get; set; }
         public int manufacturer_id { get; set; }
         public string MANUFACTURE_NAME { get; set; }
        
         public int order_quantity { get; set; }
         public int shipment_quantity { get; set; }
         public int cartoon_quantity { get; set; }
         public string c_meas { get; set; }
         public DateTime? delivery_date { get; set; }
         public string description { get; set; }
         public string delivery_date_formate { get; set; }

    }
}

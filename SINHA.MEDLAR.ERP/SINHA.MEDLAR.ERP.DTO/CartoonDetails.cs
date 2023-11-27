using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO
{
    public class CartoonDetails : BaseModel
    {
        public string packing_master_id { get; set; }
        public string cartoon_detail_id { get; set; }
        public string cartoon_id { get; set; }
        public string cartoon_size { get; set; }
        public string po_no { get; set; }
        public string style_no { get; set; }
        public int cartoon_quantity { get; set; }
        public int product_quantity { get; set; }
        public int product_quantity_per_cartoon { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO
{
    public class CartoonMapping : BaseModel
    {
        public string po_no { get; set; }

        public string style_no { get; set; }
        public string mapping_id { get; set; }
        public string packing_master_id { get; set; }
        public string size_id { get; set; }
        public string size_name { get; set; }
        public string cartoon_detail_id { get; set; }
        public string cartoon_size { get; set; }

        public int quantity { get; set; }
    }
}

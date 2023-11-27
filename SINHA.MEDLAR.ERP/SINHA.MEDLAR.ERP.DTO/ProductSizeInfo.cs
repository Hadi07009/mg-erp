using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO
{
    public class ProductSizeInfo : BaseModel
    {

        public decimal size_id { get; set; }
        public decimal packing_master_id { get; set; }
        public string size_name { get; set; }
        public string po_no { get; set; }
        public string style_no { get; set; }
        public string barcode { get; set; }
        public int quantity { get; set; }
        public decimal? create_by { get; set; }
        public DateTime? create_date { get; set; }
        public decimal? update_by { get; set; }
        public DateTime? update_date { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO.ViewModels
{
    public class CartoonSummary
    {
        public string CARTOON_ID { get; set; }
        public string po_no { get; set; }
        public string style_no { get; set; }
        public string CARTOON_SIZE { get; set; }
        public string product_size { get; set; }

       // public static List<CartoonSummary> GetCartoonSummary(string poNo, string styleNo)
      //  {
        //    // var objCartoonSummaries = new List<>
        //    var objCartoonSummaries = new List<CartoonSummary>
        //        {
        //        new CartoonSummary() { CARTOON_ID = "1", po_no="1", style_no="1", CARTOON_SIZE="10x10x10", product_size= "S[5] M[3] L[2]" },
        //        new CartoonSummary() { CARTOON_ID = "1", po_no="1", style_no="1", CARTOON_SIZE="12x12x12", product_size= "S[7] M[5] L[3]" },
        //        new CartoonSummary() { CARTOON_ID = "2", po_no="2", style_no="2", CARTOON_SIZE="15x15x15", product_size= "S[10] M[7] L[13]" },
        //        new CartoonSummary() { CARTOON_ID = "2", po_no="2", style_no="2", CARTOON_SIZE="17x17x17", product_size= "S[12] M[6] L[3]" },
        //        new CartoonSummary() { CARTOON_ID = "3", po_no="3", style_no="3", CARTOON_SIZE="20x20x20", product_size= "S[30] M[5] L[2]" },
        //        };

        //    var objResult = new List<CartoonSummary>();

        //    foreach (var item in objCartoonSummaries)
        //    {
        //        if (item.po_no == poNo && item.style_no == styleNo)
        //        {
        //            objResult.Add(item);
        //        }
        //    }

        //   return objResult;
       // }
    }
}

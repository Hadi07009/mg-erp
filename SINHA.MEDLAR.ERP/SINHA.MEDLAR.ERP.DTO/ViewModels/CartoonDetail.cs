using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO.ViewModels
{
   public  class CartoonDetail
    {
        public string CARTOON_ID { get; set; }
        public string po_no { get; set; }
        public string style_no { get; set; }
        public string size_name { get; set; }
        public string capacity { get; set; }
        public string scan_quantity { get; set; }
        public string remaining { get; set; }
        public string cartoon_number { get; set; }

        //public static List<CartoonDetail> GetCartoonDetail(string cartoonId, string poNo, string styleNo, string headOfficeId, string branchOfficeId)
        //{

        //    var objCartoonDetail = new List<CartoonDetail>
        //{
        //    new CartoonDetail() {po_no = "1", style_no = "1",  CARTOON_ID = "1", size_name="S",capacity="25",scan_quantity="10",remaining="15"},
        //    new CartoonDetail() {po_no = "1", style_no = "1",  CARTOON_ID = "1", size_name="M",capacity="30",scan_quantity="25",remaining="5"},
        //    new CartoonDetail() {po_no = "1", style_no = "1",  CARTOON_ID = "1", size_name="N",capacity="20",scan_quantity="15",remaining="5"},
        //    new CartoonDetail() {po_no = "1", style_no = "1",  CARTOON_ID = "1", size_name="L",capacity="40",scan_quantity="30",remaining="10"},
        //    new CartoonDetail() {po_no = "2", style_no = "2",  CARTOON_ID = "2", size_name="N",capacity="20",scan_quantity="15",remaining="5"},
        //    new CartoonDetail() {po_no = "2", style_no = "2",  CARTOON_ID = "2", size_name="L",capacity="40",scan_quantity="30",remaining="10"},
        //    new CartoonDetail() {po_no = "3", style_no = "3",  CARTOON_ID = "3", size_name="N",capacity="20",scan_quantity="15",remaining="5"},
        //    new CartoonDetail() {po_no = "3", style_no = "3",  CARTOON_ID = "3", size_name="L",capacity="40",scan_quantity="30",remaining="10"},
        //};
        //    var objResult = new List<CartoonDetail>();
        //    foreach (var item in objCartoonDetail)
        //    {
        //        if (item.CARTOON_ID == cartoonId && item.po_no == poNo && item.style_no == styleNo)
        //        {
        //            objResult.Add(item);
        //        }
        //    }
        //    return objResult;
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO
{
   public class MfsTemplate
    {   
        public string subject { get; set; }
        public string head_office_name { get; set; }
        public string branch_office_name { get; set; }

        public string logged_in_user { get; set; }
        public string salary_year { get; set; }
        public string salary_month { get; set; }
        
        public string month_year { get; set; }
        public string employee_id { get; set; }
        public string card_no { get; set; }
        
        public string employee_name { get; set; }
        public string designation_name { get; set; }
        public string bkash_no { get; set; }

        public decimal payment_amount { get; set; }
        public decimal employee_type_id { get; set; }
        public decimal unit_group_id { get; set; }
        
        public decimal unit_id { get; set; }
        public decimal section_id { get; set; }
        public string unit_name { get; set; }
        
        public string section_name { get; set; }
        public string payment_amount_in_word { get; set; }
        
    }
}

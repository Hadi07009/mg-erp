using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;


namespace SINHA.MEDLAR.ERP.BLL
{
    public class AddApprovedByBLL
    {
        public string addApprovedByEmp(AddApprovedByDTO objAddApprovedByDTO)
        {

            AddApprovedByDAL objAddApprovedByDAL = new AddApprovedByDAL();
            string strMsg = objAddApprovedByDAL.addApprovedByEmp(objAddApprovedByDTO);
            return strMsg;
        }

        public string deleteApprovedEmployee(AddApprovedByDTO objAddApprovedByDTO)
        {

            AddApprovedByDAL objAddApprovedByDAL = new AddApprovedByDAL();
            string strMsg = objAddApprovedByDAL.deleteApprovedEmployee(objAddApprovedByDTO);
            return strMsg;
        }

        public DataTable searchApprovedByEmpEntry(AddApprovedByDTO objAddApprovedByDTO)
        {

           

            DataTable dt = new DataTable();
            AddApprovedByDAL objAddApprovedByDAL = new AddApprovedByDAL();


            dt = objAddApprovedByDAL.searchApprovedByEmpEntry(objAddApprovedByDTO);
            return dt;

        }

        public DataTable searchApprovedByEmp(AddApprovedByDTO objAddApprovedByDTO)
        {

            DataTable dt = new DataTable();
            AddApprovedByDAL objAddApprovedByDAL = new AddApprovedByDAL();


            dt = objAddApprovedByDAL.searchApprovedByEmp(objAddApprovedByDTO);
            return dt;

        }      
    }
}

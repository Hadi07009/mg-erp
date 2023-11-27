using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;

namespace SINHA.MEDLAR.ERP.BLL
{
    public class SalaryUnitBLL
    {

        public string saveSalaryUnitInformation(SalaryUnitDTO objSalaryUnitDTO)
        {

            SalaryUnitDAL objSalaryUnitDAL = new SalaryUnitDAL();
            string strMsg = "";


            strMsg = objSalaryUnitDAL.saveSalaryUnitInformation(objSalaryUnitDTO);
            return strMsg;

        }
                


    }
}

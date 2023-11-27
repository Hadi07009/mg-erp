using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;

namespace SINHA.MEDLAR.ERP.BLL
{
    public class LoginBLL
    {

        public LoginDTO checkValidUser(string strEmployeeName, string strEmployeePass, string strIpAddress)
        {

            LoginDTO objLoginDTO = new LoginDTO();
            LoginDAL objLoginDAL = new LoginDAL ();

            objLoginDTO = objLoginDAL.checkValidUser(strEmployeeName, strEmployeePass, strIpAddress);
            return objLoginDTO;



        }

        public string updateEmployeePassWord(LoginDTO objLoginDTO)
        {

            
            LoginDAL objLoginDAL = new LoginDAL();

            string strMsg = objLoginDAL.updateEmployeePassWord(objLoginDTO);

            return strMsg;



        }

        public string submitPassword(LoginDTO objLoginDTO)
        {


            LoginDAL objLoginDAL = new LoginDAL();

            string strMsg = objLoginDAL.submitPassword(objLoginDTO);

            return strMsg;



        }


        public LoginDTO searchEmployeePassword(string strEmployeeId, string strHeadOfficeId)
        {

            LoginDTO objLoginDTO = new LoginDTO();
            LoginDAL objLoginDAL = new LoginDAL();

            objLoginDTO = objLoginDAL.searchEmployeePassword(strEmployeeId, strHeadOfficeId);
            return objLoginDTO;



        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;

using Oracle.ManagedDataAccess.Client;

using System.Configuration;



namespace SINHA.MEDLAR.ERP.DAL
{
    public class LoginDAL
    {
        OracleTransaction trans = null;

        #region "Oracle Connection Function"

        private OracleConnection GetConnection()
        {
            var conString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConString"];
            string strConnString = conString.ConnectionString;
            return new OracleConnection(strConnString);
        }

        #endregion

        #region "DML"
        public string saveUnitInfo(LookUpDTO objLookUpDTO)
        {
                    
            OracleTransaction trans = null;
            LoginDTO objLoginDTO = new LoginDTO();
            string strMsg = "";


            OracleCommand objOracleCommand = new OracleCommand("pro_unit_save");

            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objLookUpDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLookUpDTO.UnitId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            if (objLookUpDTO.UnitName != "")
            {
                objOracleCommand.Parameters.Add("P_UNIT_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLookUpDTO.UnitName;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_UNIT_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objLookUpDTO.UnitNameBangla != "")
            {
                objOracleCommand.Parameters.Add("P_UNIT_NAME_BANGLA", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLookUpDTO.UnitNameBangla;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_UNIT_NAME_BANGLA", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLookUpDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLookUpDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLookUpDTO.UpdateBy;

            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    trans = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    trans.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
                }

                catch (Exception ex)
                {
                    trans.Rollback();
                    throw new Exception("Error : " + ex.Message);
                }

                finally
                {

                    strConn.Close();
                    trans.Rollback();
                }

            }

            return strMsg;


        }

        public LoginDTO checkValidUser(string strEmployeeName, string strEmployeePass, string strIpAddress)
        {

            LoginDTO objLoginDTO = new LoginDTO();


            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("pro_check_valid_user");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            objOracleCommand.Parameters.Add("p_employee_name", OracleDbType.Varchar2, ParameterDirection.Input).Value = strEmployeeName;
            objOracleCommand.Parameters.Add("p_employee_pass", OracleDbType.Varchar2, ParameterDirection.Input).Value = strEmployeePass;
            objOracleCommand.Parameters.Add("p_ip_address", OracleDbType.Varchar2, ParameterDirection.Input).Value = strIpAddress;


            objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Int32, 50, ParameterDirection.Output).Value = objLoginDTO.EmployeeId;
            objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Int32, 50, ParameterDirection.Output).Value = objLoginDTO.SectionId;
            
            objOracleCommand.Parameters.Add("p_designation_id", OracleDbType.Int32, 50, ParameterDirection.Output).Value = objLoginDTO.DesignationId;
            objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Int32, 50, ParameterDirection.Output).Value = objLoginDTO.UnitId;
            objOracleCommand.Parameters.Add("p_catagory_id", OracleDbType.Int32, 50, ParameterDirection.Output).Value = objLoginDTO.CatagoryId;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Int32, 50, ParameterDirection.Output).Value = objLoginDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Int32, 50, ParameterDirection.Output).Value = objLoginDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("p_employee_type_id", OracleDbType.Int32, 50, ParameterDirection.Output).Value = objLoginDTO.EmployeeTypeId;
            objOracleCommand.Parameters.Add("p_login_day", OracleDbType.Int32, 50, ParameterDirection.Output).Value = objLoginDTO.LoginDay;
            objOracleCommand.Parameters.Add("p_login_month", OracleDbType.Int32, 50, ParameterDirection.Output).Value = objLoginDTO.LoginMonth;
            objOracleCommand.Parameters.Add("p_login_year", OracleDbType.Int32, 50, ParameterDirection.Output).Value = objLoginDTO.LoginYear;
            objOracleCommand.Parameters.Add("p_login_date", OracleDbType.Date, 50, ParameterDirection.Output).Value = objLoginDTO.LoginDate;

            objOracleCommand.Parameters.Add("p_head_office_name", OracleDbType.Varchar2, 2000, ParameterDirection.Output).Value = objLoginDTO.HeadOfficeName;
            objOracleCommand.Parameters.Add("p_branch_office_name", OracleDbType.Varchar2, 2000, ParameterDirection.Output).Value = objLoginDTO.BranchOfficeName;
            objOracleCommand.Parameters.Add("p_soft_id", OracleDbType.Int32, 50, ParameterDirection.Output).Value = objLoginDTO.SoftId;


            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 1000).Direction = ParameterDirection.Output;

            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    trans = strConn.BeginTransaction();
                    
                    //strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();

                    objLoginDTO.EmployeeId = objOracleCommand.Parameters["p_employee_id"].Value.ToString();
                    objLoginDTO.SectionId = objOracleCommand.Parameters["p_section_id"].Value.ToString();
                    
                    objLoginDTO.DesignationId = objOracleCommand.Parameters["p_designation_id"].Value.ToString();
                    objLoginDTO.UnitId = objOracleCommand.Parameters["p_unit_id"].Value.ToString();
                    objLoginDTO.CatagoryId = objOracleCommand.Parameters["p_catagory_id"].Value.ToString();
                    objLoginDTO.HeadOfficeId = objOracleCommand.Parameters["p_head_office_id"].Value.ToString();
                    objLoginDTO.BranchOfficeId = objOracleCommand.Parameters["p_branch_office_id"].Value.ToString();
                    objLoginDTO.UserTypeId = objOracleCommand.Parameters["p_employee_type_id"].Value.ToString();
                    objLoginDTO.LoginDay = objOracleCommand.Parameters["p_login_day"].Value.ToString();
                    objLoginDTO.LoginMonth = objOracleCommand.Parameters["p_login_month"].Value.ToString();
                    objLoginDTO.LoginYear = objOracleCommand.Parameters["p_login_year"].Value.ToString();
                    objLoginDTO.LoginDate = objOracleCommand.Parameters["p_login_date"].Value.ToString();
                    objLoginDTO.HeadOfficeName = objOracleCommand.Parameters["p_head_office_name"].Value.ToString();
                    objLoginDTO.BranchOfficeName = objOracleCommand.Parameters["p_branch_office_name"].Value.ToString();
                    objLoginDTO.SoftId = objOracleCommand.Parameters["p_soft_id"].Value.ToString();

                    objLoginDTO.Message = objOracleCommand.Parameters["p_message"].Value.ToString();
                    trans.Commit();
                    strConn.Close();
                }

                catch (Exception ex)
                {
                    trans.Rollback();
                    throw new Exception("Error : " + ex.Message);
                }

                finally
                {

                    strConn.Close();

                }

            }



            return objLoginDTO;



        }

        public string updateEmployeePassWord(LoginDTO objLoginDTO)
        {


            string strMsg = "";

            OracleCommand objOracleCommand = new OracleCommand("pro_update_employee_password");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLoginDTO.EmployeeId;
            objOracleCommand.Parameters.Add("p_employee_name", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLoginDTO.EmployeeName;
            objOracleCommand.Parameters.Add("p_employee_pass", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLoginDTO.OldPassword;
            objOracleCommand.Parameters.Add("p_employee_new_pass", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLoginDTO.NewPassword;
            objOracleCommand.Parameters.Add("p_employee_confirm_pass", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLoginDTO.ConfirmPassword;


            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLoginDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLoginDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLoginDTO.UpdateBy;

            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    trans = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    trans.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
                }

                catch (Exception ex)
                {
                    trans.Rollback();
                    throw new Exception("Error : " + ex.Message);
                }

                finally
                {

                    strConn.Close();
                }

            }




            return strMsg;



        }

        public string submitPassword(LoginDTO objLoginDTO)
        {


            string strMsg = "";
            OracleTransaction trans = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_update_password");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLoginDTO.EmployeeId;
            objOracleCommand.Parameters.Add("p_employee_pass", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLoginDTO.EmployeePass;

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLoginDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLoginDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLoginDTO.BranchOfficeId;
            

            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    trans = strConn.BeginTransaction();
                    //strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
                }

                catch (Exception ex)
                {
                    trans.Rollback();
                    throw new Exception("Error : " + ex.Message);
                }

                finally
                {

                    strConn.Close();
                }

            }




            return strMsg;



        }
        #endregion
        #region "Search"
        public LoginDTO searchEmployeePassword(string strEmployeeId,string strHeadOfficeId)
        {
           

            LoginDTO objLoginDTO = new LoginDTO();

            string sql = "";
            sql = "SELECT " +
                  "EMPLOYEE_NAME, " +
                  "EMPLOYEE_PASS " +

                  "FROM LOGIN WHERE EMPLOYEE_ID = '" + strEmployeeId + "' and HEAD_OFFICE_ID = '" + strHeadOfficeId + "'";




            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                try
                {
                    while (objDataReader.Read())
                    {

                        objLoginDTO.EmployeeName = objDataReader.GetString(0);
                        objLoginDTO.EmployeePass = objDataReader.GetString(1);

                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error : " + ex.Message);

                }

                finally
                {

                    strConn.Close();
                }

            }


            return objLoginDTO;

        }

            #endregion

    }
}

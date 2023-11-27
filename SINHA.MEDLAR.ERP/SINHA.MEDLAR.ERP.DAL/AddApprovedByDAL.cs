using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Data;


using SINHA.MEDLAR.ERP.DTO;
using Oracle.ManagedDataAccess.Client;

using System.Configuration;

namespace SINHA.MEDLAR.ERP.DAL
{
    public class AddApprovedByDAL
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
        public string addApprovedByEmp(AddApprovedByDTO objAddApprovedByDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("PRO_APPROVED_BY_EMP_SAVE");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objAddApprovedByDTO.EmployeeId != "")
            {
            objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objAddApprovedByDTO.EmployeeId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }            

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objAddApprovedByDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objAddApprovedByDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objAddApprovedByDTO.BranchOfficeId;


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
        public string deleteApprovedEmployee(AddApprovedByDTO objAddApprovedByDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("PRO_DELETE_APPROVED_EMPLOYEE");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objAddApprovedByDTO.EmployeeId != "")
            {
                objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objAddApprovedByDTO.EmployeeId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objAddApprovedByDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objAddApprovedByDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objAddApprovedByDTO.BranchOfficeId;


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
        public DataTable searchApprovedByEmpEntry(AddApprovedByDTO objAddApprovedByDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

          

                sql = "SELECT " +
                       
                        "CARD_NO, " +
                        "EMPLOYEE_ID, " +
                        "EMPLOYEE_NAME, " +
                        "designation_name " +


                       "FROM vew_search_approved_entry WHERE head_office_id = '" + objAddApprovedByDTO.HeadOfficeId + "'  ";

                if (objAddApprovedByDTO.SectionId.Length > 0)
                {

                    sql = sql + " and section_id = '" + objAddApprovedByDTO.SectionId + "'";
                }

                if (objAddApprovedByDTO.UnitId.Length > 0)
                {

                    sql = sql + " and unit_id = '" + objAddApprovedByDTO.UnitId + "'";
                }

            
           //ql = sql + "order by SL ";

            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataAdapter.Fill(dt);

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



            return dt;

        }
        public DataTable searchApprovedByEmp(AddApprovedByDTO objAddApprovedByDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

    

                sql = "SELECT " +
                           "EMPLOYEE_ID, " +
                           "CARD_NO, " +
                           "EMPLOYEE_NAME, " +
                           "designation_name " +


                          "FROM VEW_BASIC_INFO WHERE head_office_id = '" + objAddApprovedByDTO.HeadOfficeId + "' ";



                if (objAddApprovedByDTO.UnitId.Length > 0)
                {

                    sql = sql + " and unit_id = '" + objAddApprovedByDTO.UnitId + "'";
                }

                if (objAddApprovedByDTO.SectionId.Length > 0)
                {

                    sql = sql + " and section_id = '" + objAddApprovedByDTO.SectionId + "'";
                }

               //ql = sql + "order by SL ";


            

            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataAdapter.Fill(dt);

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



            return dt;

        }
    }
}

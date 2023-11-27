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
    public class AprovedEmployeeDAL
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

        public string addAprovedEmployee(AprovedEmployeeDTO objAprovedEmployeeDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("PRO_APPROVED_EMPLOYEE_SAVE");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            if (objAprovedEmployeeDTO.EmployeeId != "")
            {
                objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objAprovedEmployeeDTO.EmployeeId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objAprovedEmployeeDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objAprovedEmployeeDTO.UnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objAprovedEmployeeDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("P_SECTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objAprovedEmployeeDTO.SectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SECTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objAprovedEmployeeDTO.AprovedYear != "")
            {
                objOracleCommand.Parameters.Add("P_APPROVED_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objAprovedEmployeeDTO.AprovedYear;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_APPROVED_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objAprovedEmployeeDTO.AprovedMonth != "")
            {
                objOracleCommand.Parameters.Add("P_APPROVED_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objAprovedEmployeeDTO.AprovedMonth;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_APPROVED_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objAprovedEmployeeDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objAprovedEmployeeDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objAprovedEmployeeDTO.BranchOfficeId;


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
                    throw new Exception("Error : " + ex.Message);
                    objOracleTransaction.Rollback();
                }

                finally
                {

                    strConn.Close();
                }

            }
            return strMsg;

        }
        public DataTable getMonthId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            string sql = "";
            sql = "select 0 MONTH_ID, 'Please Select One ' MONTH_NAME from dual " +
                    "union " +

                "SELECT " +
                  "MONTH_ID, " +
                  "to_char(MONTH_NAME) " +
                  "FROM L_MONTH_NAME ORDER BY  MONTH_ID";

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
        public DataTable searchAprovedEmployee(AprovedEmployeeDTO objAprovedEmployeeDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";
              
                    sql = "SELECT " +
                           "CARD_NO, " +
                           "EMPLOYEE_ID, " +
                           "EMPLOYEE_NAME, " +
                           "designation_name_new, " +
                           "GRADE_NO, " +
                           "FIRST_SALARY, " +
                           "GROSS_SALARY " +

                          "FROM VEW_NEW_EMPLOYEE_LIST_BY_JD WHERE head_office_id = '" + objAprovedEmployeeDTO.HeadOfficeId + "' AND branch_office_id = '" + objAprovedEmployeeDTO.BranchOfficeId + "' AND joining_year = '" + objAprovedEmployeeDTO.AprovedYear + "' AND joining_month = TO_NUMBER('" + objAprovedEmployeeDTO.AprovedMonth + "')  ";


                    if (objAprovedEmployeeDTO.UnitId.Length > 0)
                    {

                        sql = sql + " and UNIT_ID = '" + objAprovedEmployeeDTO.UnitId + "'";
                    }
                    if (objAprovedEmployeeDTO.SectionId.Length > 0)
                    {

                        sql = sql + " and section_id = '" + objAprovedEmployeeDTO.SectionId + "'";
                    }


                    sql = sql + "order by CARD_NO ";
                             

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
        public DataTable searchAprovedEmployeeEntry(AprovedEmployeeDTO objAprovedEmployeeDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

                sql = "SELECT " +
                       "EMPLOYEE_ID, " +
                       "EMPLOYEE_NAME, " +
                       "DESIGNATION_ID, " +
                       "designation_name_new, " +
                       "joining_year, " +
                       "joining_month, " +
                       "MONTH_NAME, "+
                       "GRADE_NO, " +
                       "GROSS_SALARY, " +
                       "FIRST_SALARY, " +
                       "CARD_NO " +

                       "FROM VEW_NEW_EMPLOYEE_LIST_BY_JD WHERE head_office_id = '" + objAprovedEmployeeDTO.HeadOfficeId + "' AND branch_office_id = '" + objAprovedEmployeeDTO.BranchOfficeId + "' AND APPROVED_YN= 'Y' and joining_year= '" + objAprovedEmployeeDTO.AprovedYear + "' and to_number(joining_month)= '" + objAprovedEmployeeDTO.AprovedMonth + "'";

                if (objAprovedEmployeeDTO.UnitId.Length > 0)
                {

                    sql = sql + " and unit_id = '" + objAprovedEmployeeDTO.UnitId + "'";
                }
                if (objAprovedEmployeeDTO.SectionId.Length > 0)
                {

                    sql = sql + " and section_id = '" + objAprovedEmployeeDTO.SectionId + "'";
                }


                sql = sql + "order by EMPLOYEE_ID ";

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
        public string deleteAprovedEmployeeRecord(AprovedEmployeeDTO objAprovedEmployeeDTO)
        {

            AprovedEmployeeDAL objAprovedEmployeeDAL = new AprovedEmployeeDAL();

            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("PRO_DELETE_APPROVED_EMPLOYEE");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objAprovedEmployeeDTO.EmpId != "")
            {

                objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objAprovedEmployeeDTO.EmpId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objAprovedEmployeeDTO.AprovedYear != "")
            {

                objOracleCommand.Parameters.Add("P_APPROVED_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objAprovedEmployeeDTO.AprovedYear;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_APPROVED_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objAprovedEmployeeDTO.AprovedMonth != "")
            {

                objOracleCommand.Parameters.Add("P_APPROVED_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objAprovedEmployeeDTO.AprovedMonth;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_APPROVED_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }



            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objAprovedEmployeeDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objAprovedEmployeeDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objAprovedEmployeeDTO.BranchOfficeId;


            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 1000).Direction = ParameterDirection.Output;

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
                    throw new Exception("Error : " + ex.Message);
                    trans.Rollback();
                }

                finally
                {

                    strConn.Close();

                }

            }



            return strMsg;
        }

    }
}

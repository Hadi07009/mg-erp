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
    public class GazetteDAL
    {
        OracleTransaction trans = null;

        private OracleConnection GetConnection()
        {
            var conString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConString"];
            string strConnString = conString.ConnectionString;
            return new OracleConnection(strConnString);
        }

        public string AnalyzeIncrementPlusGazetteAdjustment(GazetteDTO objGazetteDTO)
        {

            DataSet ds = null;
            DataTable myTable = new DataTable();
            //try
            //{
                string strMsg = "";
                OracleTransaction objOracleTransaction;
            //OracleCommand objOracleCommand = new OracleCommand("pro_incr_plus_gazet_adjustment");
            //sp_gazette_adjustment_analysis
            OracleCommand objOracleCommand = new OracleCommand("sp_analyze_incr_plus_gazet_adj");
            
              objOracleCommand.CommandType = CommandType.StoredProcedure;
            if (objGazetteDTO.Year != "")
            {
                objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.Year;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objGazetteDTO.Month != "")
            {
                objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.Month;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            objOracleCommand.Parameters.Add("p_increment_yn", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.IncrementYn;

            if (objGazetteDTO.UnitGroupId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_group_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.UnitGroupId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_group_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objGazetteDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.UnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objGazetteDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.SectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("p_logged_in_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.UpdateBy;
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
        public string AnalyzeIncrementPlusGazetteAdjustmentForSingleEmp(GazetteDTO objGazetteDTO)
        {

            DataSet ds = null;
            DataTable myTable = new DataTable();
            //try
            //{
            string strMsg = "";
            OracleTransaction objOracleTransaction;
            //OracleCommand objOracleCommand = new OracleCommand("pro_incr_plus_gazet_adjustment");
            //sp_gazette_adjustment_analysis
            OracleCommand objOracleCommand = new OracleCommand("sp_analyz_sin_incr_pls_gzt_adj");

            objOracleCommand.CommandType = CommandType.StoredProcedure;
            objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.EmployeeId;

            if (objGazetteDTO.Year != "")
            {
                objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.Year;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objGazetteDTO.Month != "")
            {
                objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.Month;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            objOracleCommand.Parameters.Add("p_increment_yn", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.IncrementYn;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("p_logged_in_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.UpdateBy;
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
        public DataTable GetIncrementPlusGazetAdjSheet(GazetteDTO objGazetteDTO)
        {

            DataSet ds = null;
            DataTable myTable = new DataTable();
            try
            {
                string strMsg = "";
                OracleTransaction objOracleTransaction;
                OracleCommand objOracleCommand = new OracleCommand("SP_GET_INCR_PLUS_GAZET_ADJ_SHT");
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.Year;
                if (objGazetteDTO.Month != "")
                {
                    objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.Month;
                }
                else
                {
                    objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
                }

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.UnitId;
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.SectionId;
                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.BranchOfficeId;
                
                objOracleCommand.Parameters.Add("p_unit_group_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.UnitGroupId;
                objOracleCommand.Parameters.Add("p_logged_in_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = Convert.ToInt32(objGazetteDTO.UpdateBy);
                objOracleCommand.Parameters.Add("p_dbcursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                string VALUE = string.Empty;

                using (OracleConnection strConn = GetConnection())
                {
                    try
                    {
                        objOracleCommand.Connection = strConn;
                        strConn.Open();
                        trans = strConn.BeginTransaction();
                        myTable.Load(objOracleCommand.ExecuteReader());
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return myTable;
        }
        public DataTable GetIncrementPlusGazetAdjForSingleEmpSheet(GazetteDTO objGazetteDTO)
        {

            DataSet ds = null;
            DataTable myTable = new DataTable();
            try
            {
                string strMsg = "";
                OracleTransaction objOracleTransaction;
                OracleCommand objOracleCommand = new OracleCommand("SP_GET_SIN_INCR_PLS_GZT_ADJ_SH");
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.Year;
                if (objGazetteDTO.Month != "")
                {
                    objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.Month;
                }
                else
                {
                    objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
                }
                objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.EmployeeId;
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.UnitId;
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.SectionId;
                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.BranchOfficeId;

                objOracleCommand.Parameters.Add("p_unit_group_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
                objOracleCommand.Parameters.Add("p_logged_in_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = Convert.ToInt32(objGazetteDTO.UpdateBy);
                objOracleCommand.Parameters.Add("p_dbcursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                string VALUE = string.Empty;

                using (OracleConnection strConn = GetConnection())
                {
                    try
                    {
                        objOracleCommand.Connection = strConn;
                        strConn.Open();
                        trans = strConn.BeginTransaction();
                        myTable.Load(objOracleCommand.ExecuteReader());
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return myTable;
        }
        public DataTable GetIncrementPlusGazetAdjRequisition(GazetteDTO objGazetteDTO)
        {

            DataSet ds = null;
            DataTable myTable = new DataTable();
            try
            {
                string strMsg = "";
                OracleTransaction objOracleTransaction;
                //pro_salary_adjustment_req
                OracleCommand objOracleCommand = new OracleCommand("SP_GET_INCR_PLUS_GAZET_ADJ_REQ");
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                if (objGazetteDTO.Year != "")
                {
                    objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.Year;
                }
                else
                {
                    objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
                }

                if (objGazetteDTO.Month != "")
                {
                    objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.Month;
                }
                else
                {
                    objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
                }
                objOracleCommand.Parameters.Add("p_increment_yn", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.IncrementYn;

                if (objGazetteDTO.UnitGroupId != "")
                {
                    objOracleCommand.Parameters.Add("p_unit_group_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.UnitGroupId;
                }
                else
                {
                    objOracleCommand.Parameters.Add("p_unit_group_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
                }
                if (objGazetteDTO.UnitId != "")
                {
                    objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.UnitId;
                }
                else
                {
                    objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
                }
                if (objGazetteDTO.SectionId != "")
                {
                    objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.SectionId;
                }
                else
                {
                    objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
                }

                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.BranchOfficeId;
                objOracleCommand.Parameters.Add("p_logged_in_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.UpdateBy;
                objOracleCommand.Parameters.Add("p_dbcursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                string VALUE = string.Empty;

                using (OracleConnection strConn = GetConnection())
                {
                    try
                    {
                        objOracleCommand.Connection = strConn;
                        strConn.Open();
                        trans = strConn.BeginTransaction();
                        //var tbl = objOracleCommand.ExecuteReader();
                        myTable.Load(objOracleCommand.ExecuteReader());
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return myTable;
        }
        public DataTable GetIncrementPlusGazetAdjSummary(GazetteDTO objGazetteDTO)
        {

            DataSet ds = null;
            DataTable myTable = new DataTable();
            try
            {
                string strMsg = "";
                OracleTransaction objOracleTransaction;
                //pro_salary_adjustment_summary
                OracleCommand objOracleCommand = new OracleCommand("SP_GET_INCR_PLUS_GAZET_ADJ_SUM");
                objOracleCommand.CommandType = CommandType.StoredProcedure;
                objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.Year;
                if (objGazetteDTO.Month != "")
                {
                    objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.Month;
                }
                else
                {
                    objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
                }
                objOracleCommand.Parameters.Add("p_increment_yn", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.IncrementYn;
                objOracleCommand.Parameters.Add("p_unit_group_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.UnitGroupId;
                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.BranchOfficeId;
                objOracleCommand.Parameters.Add("p_logged_in_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = Convert.ToInt32(objGazetteDTO.UpdateBy);
                objOracleCommand.Parameters.Add("p_dbcursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                string VALUE = string.Empty;

                using (OracleConnection strConn = GetConnection())
                {
                    try
                    {
                        objOracleCommand.Connection = strConn;
                        strConn.Open();
                        trans = strConn.BeginTransaction();
                        myTable.Load(objOracleCommand.ExecuteReader());
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return myTable;
        }
        public string ProcessIncrementPlusGazetteAdjustment(GazetteDTO objGazetteDTO)
        {

            DataSet ds = null;
            DataTable myTable = new DataTable();
            //try
            //{
                string strMsg = "";
                OracleTransaction objOracleTransaction;
                //pro_incr_plus_gazet_adjustment
                OracleCommand objOracleCommand = new OracleCommand("sp_process_incr_plus_gazet_adj");
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                if (objGazetteDTO.Year != "")
                {
                    objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.Year;
                }
                else
                {
                    objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
                }

                if (objGazetteDTO.Month != "")
                {
                    objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.Month;
                }
                else
                {
                    objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
                }
                objOracleCommand.Parameters.Add("p_increment_yn", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.IncrementYn;

                if (objGazetteDTO.UnitGroupId != "")
                {
                    objOracleCommand.Parameters.Add("p_unit_group_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.UnitGroupId;
                }
                else
                {
                    objOracleCommand.Parameters.Add("p_unit_group_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
                }
                if (objGazetteDTO.UnitId != "")
                {
                    objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.UnitId;
                }
                else
                {
                    objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
                }
                if (objGazetteDTO.SectionId != "")
                {
                    objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.SectionId;
                }
                else
                {
                    objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
                }

                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.BranchOfficeId;
                objOracleCommand.Parameters.Add("p_logged_in_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.UpdateBy;
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
        public string ProcessIncrementPlusGazetteAdjustmentForSingleEmp(GazetteDTO objGazetteDTO)
        {

            DataSet ds = null;
            DataTable myTable = new DataTable();
            //try
            //{
            string strMsg = "";
            OracleTransaction objOracleTransaction;
            //pro_incr_plus_gazet_adjustment
            OracleCommand objOracleCommand = new OracleCommand("sp_proces_sin_incr_pls_gzt_adj");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.EmployeeId;
            if (objGazetteDTO.Year != "")
            {
                objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.Year;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objGazetteDTO.Month != "")
            {
                objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.Month;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            objOracleCommand.Parameters.Add("p_increment_yn", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.IncrementYn;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("p_logged_in_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.UpdateBy;
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

        public string SaveGazetteSetup(GazetteDTO objGazetteDTO)
        {

            DataSet ds = null;
            DataTable myTable = new DataTable();
            //try
            //{
            string strMsg = "";
            OracleTransaction objOracleTransaction;
            //OracleCommand objOracleCommand = new OracleCommand("pro_incr_plus_gazet_adjustment");
            OracleCommand objOracleCommand = new OracleCommand("sp_gazette_setup_save");

            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objGazetteDTO.Year != "")
            {
                objOracleCommand.Parameters.Add("P_GAZETTE_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.Year;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_GAZETTE_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objGazetteDTO.Month != "")
            {
                objOracleCommand.Parameters.Add("P_GAZETTE_MONTH_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.Month;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_GAZETTE_MONTH_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            objOracleCommand.Parameters.Add("P_FINALIZED_YN", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.FinalizedYn;
            objOracleCommand.Parameters.Add("P_FINALIZED_LOCK", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.FinalizedLock;
            objOracleCommand.Parameters.Add("P_ANALYSIS_YN", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.AnalysisYn;
            objOracleCommand.Parameters.Add("P_ANALYSIS_LOCK", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.AnalysisLock;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("p_logged_in_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.UpdateBy;
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
        public DataTable LoadGazetteSetup(string year, string month, string headOffieId, string branchOffieId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            DataTable dt = new DataTable();

            string sql = "";
            sql = "SELECT " +
                "GAZETTE_YEAR, " +
                "MONTH_NAME, " +
                "GAZETTE_MONTH_ID, " +
                "ANALYSIS_YN, " +
                "ANALYSIS_LOCK, " +
                "FINALIZED_YN, " +
                "FINALIZED_LOCK, " +
                "UPDATE_BY, " +
                "UPDATE_DATE, " +
                "HEAD_OFFICE_ID, " +
                "BRANCH_OFFICE_ID " +
                "FROM VEW_GAZETTE_SETUP where head_office_id =" + headOffieId + " and branch_office_id=" + branchOffieId + " ORDER BY GAZETTE_YEAR, GAZETTE_MONTH_ID";

            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataAdapter.Fill(dt);
                    dt.AcceptChanges();
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
            return dt;
        }

        public string SaveSalaryGazetteMapping(GazetteDTO objGazetteDTO)
        {

            DataSet ds = null;
            DataTable myTable = new DataTable();
            //try
            //{
            string strMsg = "";
            OracleTransaction objOracleTransaction;
           
            OracleCommand objOracleCommand = new OracleCommand("sp_salary_gazette_mapping_save");

            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objGazetteDTO.Id != "")
            {
                objOracleCommand.Parameters.Add("P_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.Id;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objGazetteDTO.Year != "")
            {
                objOracleCommand.Parameters.Add("P_SALARY_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.Year;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SALARY_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objGazetteDTO.Month != "")
            {
                objOracleCommand.Parameters.Add("P_SALARY_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.Month;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SALARY_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objGazetteDTO.GazetteYear != "")
            {
                objOracleCommand.Parameters.Add("P_GAZETTE_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.GazetteYear;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_GAZETTE_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            objOracleCommand.Parameters.Add("P_ACTIVE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.ActiveYn;
            objOracleCommand.Parameters.Add("p_logged_in_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.UpdateBy;
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
        public DataTable LoadSalaryGazetteMapping()
        {

            GazetteDTO objGazetteDTO = new GazetteDTO();
            DataTable dt = new DataTable();

            string sql = "";
            sql = "SELECT " +
                  "ID, " +
                 "SALARY_YEAR, " +
                 "MONTH_NAME, " +
                "SALARY_MONTH, " +
                "GAZETTE_TRACER_NO, " +
                "GAZETTE_YEAR, " +
                "ACTIVE_YN " +
                " FROM VEW_SALARY_GAZETTE_MAPPING ";
            //VEW_SALARY_GAZETTE_MAPPING

            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataAdapter.Fill(dt);
                    dt.AcceptChanges();
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
        public DataTable GetGazetteYear()
        {

            DataTable dt = new DataTable();
            string sql = "";
            sql = "select distinct t.tracer_no, t.gazette_year " +
           "from " +
            "( " +
           "select " +
           "tracer_no, " +
           //"to_char(publish_year) || ' (' || to_char(publish_date, 'dd/mm/yyyy') || ')' gazette_year " +

           "to_char(publish_year) gazette_year " +

           "FROM GAZETTE " +
           ") t " +
           "order by gazette_year";

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

        public string ProcessWorkerExtendedSalary(GazetteDTO objGazetteDTO)
        {
  
            DataSet ds = null;
            DataTable myTable = new DataTable();
            //try
            //{
            string strMsg = "";
            OracleTransaction objOracleTransaction;
            //new sp for 2nd gazette
            //sp_process_incr_arrear_adj
            OracleCommand objOracleCommand = new OracleCommand("sp_process_exttended_salary_w");
            //OracleCommand objOracleCommand = new OracleCommand("");

            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objGazetteDTO.UnitGroupId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_group_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.UnitGroupId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_group_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objGazetteDTO.Year != "")
            {
                objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.Year;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objGazetteDTO.Month != "")
            {
                objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.Month;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objGazetteDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.UnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objGazetteDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.SectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("p_logged_in_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.UpdateBy;
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

        
        public string ProcessIncrementArrearAdj(GazetteDTO objGazetteDTO)
        {
            DataSet ds = null;
            DataTable myTable = new DataTable();
            //try
            //{
            string strMsg = "";
            OracleTransaction objOracleTransaction;
            OracleCommand objOracleCommand;
            //new sp for 2nd gazette
            //sp_process_incr_arrear_adj
            if (objGazetteDTO.BranchOfficeId == "110")
            {
                objOracleCommand = new OracleCommand("sp_process_incr_arrear_adj_bp");
            }
            else
            {
                objOracleCommand = new OracleCommand("sp_process_incr_arrear_adj");
            }
            //OracleCommand objOracleCommand = new OracleCommand("");

            objOracleCommand.CommandType = CommandType.StoredProcedure;
                                    
            if (objGazetteDTO.ArrearYear != "")
            {
                objOracleCommand.Parameters.Add("p_arrear_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.ArrearYear;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_arrear_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objGazetteDTO.ArrearMonth != "")
            {
                objOracleCommand.Parameters.Add("P_arrear_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.ArrearMonth;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_arrear_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objGazetteDTO.IncrementYear != "")
            {
                objOracleCommand.Parameters.Add("p_increment_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.IncrementYear;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_increment_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objGazetteDTO.IncrementMonth != "")
            {
                objOracleCommand.Parameters.Add("P_increment_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.IncrementMonth;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_increment_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objGazetteDTO.UnitGroupId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_group_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.UnitGroupId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_group_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objGazetteDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.UnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objGazetteDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.SectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("p_logged_in_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.UpdateBy;
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

        public DataTable GetIncrementPlusReGazetAdjSheet(GazetteDTO objGazetteDTO)
        {

            DataSet ds = null;
            DataTable myTable = new DataTable();
            try
            {
                string strMsg = "";
                OracleTransaction objOracleTransaction;
                OracleCommand objOracleCommand = new OracleCommand("");
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.Year;
                if (objGazetteDTO.Month != "")
                {
                    objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.Month;
                }
                else
                {
                    objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
                }

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.UnitId;
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.SectionId;
                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.BranchOfficeId;

                objOracleCommand.Parameters.Add("p_unit_group_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.UnitGroupId;
                objOracleCommand.Parameters.Add("p_logged_in_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = Convert.ToInt32(objGazetteDTO.UpdateBy);
                objOracleCommand.Parameters.Add("p_dbcursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                string VALUE = string.Empty;

                using (OracleConnection strConn = GetConnection())
                {
                    try
                    {
                        objOracleCommand.Connection = strConn;
                        strConn.Open();
                        trans = strConn.BeginTransaction();
                        myTable.Load(objOracleCommand.ExecuteReader());
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return myTable;
        }

        public DataTable GetIncrementDetailSheet(GazetteDTO objGazetteDTO)
        {
            DataSet ds = null;
            DataTable myTable = new DataTable();
            try
            {
                string strMsg = "";
                OracleTransaction objOracleTransaction;
                OracleCommand objOracleCommand = new OracleCommand("SP_GET_PERIODIC_INC_HISTORY");
                objOracleCommand.CommandType = CommandType.StoredProcedure;
                objOracleCommand.Parameters.Add("p_increment_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.Year;
                if (objGazetteDTO.Month != "")
                {
                    objOracleCommand.Parameters.Add("p_increment_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.Month;
                }
                else
                {
                    objOracleCommand.Parameters.Add("p_increment_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
                }
                if (objGazetteDTO.UnitId != "")
                {
                    objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.UnitId;
                }
                else
                {
                    objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
                }
                if (objGazetteDTO.SectionId != "")
                {
                    objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.SectionId;
                }
                else
                {
                    objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
                }
                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.BranchOfficeId;
                if (objGazetteDTO.UnitGroupId != "")
                {
                    objOracleCommand.Parameters.Add("p_unit_group_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.UnitGroupId;
                }
                else
                {

                    objOracleCommand.Parameters.Add("p_unit_group_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
                }
                objOracleCommand.Parameters.Add("p_logged_in_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = Convert.ToInt32(objGazetteDTO.UpdateBy);
                objOracleCommand.Parameters.Add("p_dbcursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                string VALUE = string.Empty;

                using (OracleConnection strConn = GetConnection())
                {
                    try
                    {
                        objOracleCommand.Connection = strConn;
                        strConn.Open();
                        trans = strConn.BeginTransaction();
                        myTable.Load(objOracleCommand.ExecuteReader());
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return myTable;

        }

        public DataTable GetPeriodicIncrementHistorySummary(GazetteDTO objGazetteDTO)
        {
            DataSet ds = null;
            DataTable myTable = new DataTable();
            try
            {
               // p_increment_year varchar2,
               //p_increment_month           varchar2,
               //p_head_office_id varchar2,
               //p_branch_office_id          varchar2,
               //p_unit_group_id varchar2,
               //p_logged_in_employee_id     varchar2,

                string strMsg = "";
                OracleTransaction objOracleTransaction;
                OracleCommand objOracleCommand = new OracleCommand("SP_GET_PERIODIC_INC_HIST_SUM");
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                objOracleCommand.Parameters.Add("p_increment_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.Year;
                if (objGazetteDTO.Month != "")
                {
                    objOracleCommand.Parameters.Add("p_increment_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.Month;
                }
                else
                {
                    objOracleCommand.Parameters.Add("p_increment_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
                }
                
                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.BranchOfficeId;
                if (objGazetteDTO.UnitGroupId != "")
                {
                    objOracleCommand.Parameters.Add("p_unit_group_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objGazetteDTO.UnitGroupId;
                }
                else
                {
                    objOracleCommand.Parameters.Add("p_unit_group_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
                }

                objOracleCommand.Parameters.Add("p_logged_in_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = Convert.ToInt32(objGazetteDTO.UpdateBy);
                objOracleCommand.Parameters.Add("p_dbcursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                string VALUE = string.Empty;

                using (OracleConnection strConn = GetConnection())
                {
                    try
                    {
                        objOracleCommand.Connection = strConn;
                        strConn.Open();
                        trans = strConn.BeginTransaction();
                        myTable.Load(objOracleCommand.ExecuteReader());
                        trans.Commit();
                        strConn.Close();
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return myTable;

        }

        
    }
}

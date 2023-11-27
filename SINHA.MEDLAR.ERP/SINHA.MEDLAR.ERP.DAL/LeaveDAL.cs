using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

using SINHA.MEDLAR.ERP.DTO;

using SINHA.MEDLAR.ERP.DTO;
using Oracle.ManagedDataAccess.Client;

using System.Configuration;

namespace SINHA.MEDLAR.ERP.DAL
{
    public class LeaveDAL
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
        public string processEmployeeLeaveSummery(LeaveDTO objEmployeeLeaveDTO)
        {

            LoginDTO objLoginDTO = new LoginDTO();
            string strMsg = "";


            OracleCommand objOracleCommand = new OracleCommand("pro_employee_leave_summery");

            objOracleCommand.CommandType = CommandType.StoredProcedure;



            if (objEmployeeLeaveDTO.Year != "")
            {
                objOracleCommand.Parameters.Add("p_leave_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeLeaveDTO.Year;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_leave_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }




            if (objEmployeeLeaveDTO.StartDate != "")
            {
                objOracleCommand.Parameters.Add("p_start_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeLeaveDTO.StartDate;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_start_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeLeaveDTO.EndDate != "")
            {
                objOracleCommand.Parameters.Add("p_end_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeLeaveDTO.EndDate;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_end_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeLeaveDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeLeaveDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeLeaveDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeLeaveDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeLeaveDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeLeaveDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeLeaveDTO.BranchOfficeId;


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
        public string saveEmployeeLeave(LeaveDTO objEmployeeLeaveDTO)
        {

            LoginDTO objLoginDTO = new LoginDTO();
            string strMsg = "";

            //new
            OracleCommand objOracleCommand = new OracleCommand("sp_save_employee_leave");
            //old
            //OracleCommand objOracleCommand = new OracleCommand("pro_employee_leave_save");

            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objEmployeeLeaveDTO.EmployeeId != "")
            {
                objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeLeaveDTO.EmployeeId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objEmployeeLeaveDTO.Year != "")
            {
                objOracleCommand.Parameters.Add("p_leave_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeLeaveDTO.Year;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_leave_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            if (objEmployeeLeaveDTO.LeaveTypeId != "")
            {
                objOracleCommand.Parameters.Add("p_leave_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeLeaveDTO.LeaveTypeId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_leave_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeLeaveDTO.StartDate != "")
            {
                objOracleCommand.Parameters.Add("p_start_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeLeaveDTO.StartDate;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_start_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeLeaveDTO.EndDate != "")
            {
                objOracleCommand.Parameters.Add("p_end_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeLeaveDTO.EndDate;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_end_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeLeaveDTO.ApprovedBy != "")
            {
                objOracleCommand.Parameters.Add("p_approved_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeLeaveDTO.ApprovedBy;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_approved_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeLeaveDTO.Remarks != "")
            {
                objOracleCommand.Parameters.Add("p_remarks", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeLeaveDTO.Remarks;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_remarks", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeLeaveDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeLeaveDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeLeaveDTO.BranchOfficeId;
           

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

        //SaveShiftEmployeeLeave
        public string SaveShiftEmployeeLeave(LeaveDTO objEmployeeLeaveDTO)
        {

            LoginDTO objLoginDTO = new LoginDTO();
            string strMsg = "";

            OracleCommand objOracleCommand = new OracleCommand("pro_shift_employee_leave_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objEmployeeLeaveDTO.EmployeeId != "")
            {
                objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeLeaveDTO.EmployeeId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeLeaveDTO.Year != "")
            {
                objOracleCommand.Parameters.Add("p_leave_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeLeaveDTO.Year;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_leave_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeLeaveDTO.LeaveTypeId != "")
            {
                objOracleCommand.Parameters.Add("p_leave_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeLeaveDTO.LeaveTypeId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_leave_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeLeaveDTO.StartDate != "")
            {
                objOracleCommand.Parameters.Add("p_start_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeLeaveDTO.StartDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_start_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeLeaveDTO.EndDate != "")
            {
                objOracleCommand.Parameters.Add("p_end_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeLeaveDTO.EndDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_end_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeLeaveDTO.ApprovedBy != "")
            {
                objOracleCommand.Parameters.Add("p_approved_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeLeaveDTO.ApprovedBy;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_approved_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeLeaveDTO.Remarks != "")
            {
                objOracleCommand.Parameters.Add("p_remarks", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeLeaveDTO.Remarks;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_remarks", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeLeaveDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeLeaveDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeLeaveDTO.BranchOfficeId;
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
        public string DeleteEmployeeLeave(LeaveDTO objEmployeeLeaveDTO)
        {

            LoginDTO objLoginDTO = new LoginDTO();
            string strMsg = "";


            OracleCommand objOracleCommand = new OracleCommand("pro_delete_emp_leave");

            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objEmployeeLeaveDTO.EmployeeId != "")
            {
                objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeLeaveDTO.EmployeeId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objEmployeeLeaveDTO.Year != "")
            {
                objOracleCommand.Parameters.Add("p_leave_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeLeaveDTO.Year;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_leave_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objEmployeeLeaveDTO.StartDate != "")
            {
                objOracleCommand.Parameters.Add("p_start_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeLeaveDTO.StartDate;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_start_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeLeaveDTO.EndDate != "")
            {
                objOracleCommand.Parameters.Add("p_end_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeLeaveDTO.EndDate;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_end_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

          


            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeLeaveDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeLeaveDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeLeaveDTO.BranchOfficeId;


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

        public DataTable loadLeaveEntry()
        {

            LeaveDTO objEmployeeLeaveDTO = new LeaveDTO();


            DataTable dt = new DataTable();

            string sql = "";
            sql = "SELECT " +
                  "EMPLOYEE_ID, "+
                  "EMPLOYEE_NAME, "+
                  "LEAVE_TYPE_ID, "+
                  "LEAVE_START_DATE, "+
                  "LEAVE_END_DATE, "+
                  "TOTAL_LEAVE, "+
                  "APPROVED_BY "+


                  "FROM EMPLOYEE_LEAVE ORDER BY EMPLOYEE_ID";

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
      

        public DataTable loadEmployeeIncrement()
        {

            LeaveDTO objEmployeeLeaveDTO = new LeaveDTO();


            DataTable dt = new DataTable();

            string sql = "";
            sql = "SELECT " +
                  "EMPLOYEE_ID, " +
                  "(SELECT EMPLOYEE_NAME FROM EMPLOYEE_BASIC_INFORMATION WHERE EMPLOYEE_CODE = T.EMPLOYEE_CODE)EMPLOYEE_NAME, " +
                  "INCREMENT_YEAR, " +
                  "INCREMENT_MONTH, " +
                  "INCREMENT_DATE, " +
                  "EFECTIVE_DATE, " +
                  "APPROVED_BY " +


                  "FROM EMPLOYEE_INCREMENT T ORDER BY EMPLOYEE_ID";

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
        public string SaveEarnLeaveConsume(LeaveDTO objEmployeeLeaveDTO)
        {

            LoginDTO objLoginDTO = new LoginDTO();
            string strMsg = "";


            OracleCommand objOracleCommand = new OracleCommand("sp_earn_leave_consume_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objEmployeeLeaveDTO.EmployeeId != "")
            {
                objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeLeaveDTO.EmployeeId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeLeaveDTO.Year != "")
            {
                objOracleCommand.Parameters.Add("p_leave_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeLeaveDTO.Year;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_leave_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeLeaveDTO.ConsumeYear != "")
            {
                objOracleCommand.Parameters.Add("p_consume_leave_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeLeaveDTO.ConsumeYear;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_consume_leave_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeLeaveDTO.LeaveTypeId != "")
            {
                objOracleCommand.Parameters.Add("p_leave_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeLeaveDTO.LeaveTypeId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_leave_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeLeaveDTO.StartDate != "")
            {
                objOracleCommand.Parameters.Add("p_start_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeLeaveDTO.StartDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_start_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeLeaveDTO.EndDate != "")
            {
                objOracleCommand.Parameters.Add("p_end_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeLeaveDTO.EndDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_end_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeLeaveDTO.ApprovedBy != "")
            {
                objOracleCommand.Parameters.Add("p_approved_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeLeaveDTO.ApprovedBy;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_approved_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeLeaveDTO.Remarks != "")
            {
                objOracleCommand.Parameters.Add("p_remarks", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeLeaveDTO.Remarks;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_remarks", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            objOracleCommand.Parameters.Add("P_CREATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeLeaveDTO.CreateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeLeaveDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeLeaveDTO.BranchOfficeId;


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
        public string DeleteEmployeeEarnLeave(LeaveDTO objEmployeeLeaveDTO)
        {

            LoginDTO objLoginDTO = new LoginDTO();
            string strMsg = "";


            OracleCommand objOracleCommand = new OracleCommand("pro_delete_emp_earn_leave");

            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objEmployeeLeaveDTO.EmployeeId != "")
            {
                objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeLeaveDTO.EmployeeId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objEmployeeLeaveDTO.Year != "")
            {
                objOracleCommand.Parameters.Add("p_leave_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeLeaveDTO.Year;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_leave_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objEmployeeLeaveDTO.StartDate != "")
            {
                objOracleCommand.Parameters.Add("p_start_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeLeaveDTO.StartDate;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_start_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeLeaveDTO.EndDate != "")
            {
                objOracleCommand.Parameters.Add("p_end_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeLeaveDTO.EndDate;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_end_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }




            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeLeaveDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeLeaveDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeLeaveDTO.BranchOfficeId;


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
        #endregion

        public string SaveEmployeeSuspension(LeaveDTO objEmployeeLeaveDTO)
        {

            LoginDTO objLoginDTO = new LoginDTO();
            string strMsg = "";


            OracleCommand objOracleCommand = new OracleCommand("sp_save_employee_suspension");

            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objEmployeeLeaveDTO.SuspensionId != "")
            {
                objOracleCommand.Parameters.Add("p_suspension_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeLeaveDTO.SuspensionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_suspension_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeLeaveDTO.EmployeeId != "")
            {
                objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeLeaveDTO.EmployeeId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeLeaveDTO.StartDate != "")
            {
                objOracleCommand.Parameters.Add("p_start_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeLeaveDTO.StartDate;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_start_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeLeaveDTO.EndDate != "")
            {
                objOracleCommand.Parameters.Add("p_end_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeLeaveDTO.EndDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_end_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeLeaveDTO.ApprovedBy != "")
            {
                objOracleCommand.Parameters.Add("p_approved_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeLeaveDTO.ApprovedBy;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_approved_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeLeaveDTO.Remarks != "")
            {
                objOracleCommand.Parameters.Add("p_remarks", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeLeaveDTO.Remarks;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_remarks", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("P_CREATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeLeaveDTO.CreateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeLeaveDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeLeaveDTO.BranchOfficeId;


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

    }
}

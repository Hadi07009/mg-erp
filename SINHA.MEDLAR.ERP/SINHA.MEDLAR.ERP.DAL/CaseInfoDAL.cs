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
    public class CaseInfoDAL
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
        public string SaveCaseInfo(CaseInfoDTO objCaseInfoDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("sp_save_case_information_new");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("P_CASE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.CaseId;
            objOracleCommand.Parameters.Add("P_CASE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.CaseNo;
            objOracleCommand.Parameters.Add("P_ISSUE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.IssueDate;
            objOracleCommand.Parameters.Add("P_CASE_TYPE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.CaseTypeId;
            objOracleCommand.Parameters.Add("P_DEFENDANT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.DefendantId;
            objOracleCommand.Parameters.Add("P_COMPLAINTANT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.ComplaintantId;
            objOracleCommand.Parameters.Add("P_COURT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.CourtId;
            objOracleCommand.Parameters.Add("P_CASE_MODE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.Mode;
            objOracleCommand.Parameters.Add("P_AMOUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.Amount;
            objOracleCommand.Parameters.Add("P_REMARKS", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.Remarks;
            objOracleCommand.Parameters.Add("p_create_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.CreateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    objOracleTransaction = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    objOracleTransaction.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
                }

                catch (Exception ex)
                {
                    objOracleTransaction.Rollback();
                    throw new Exception("Error : " + ex.Message);
                }
                finally
                {
                    strConn.Close();
                }
            }
            return strMsg;
        }
        public string SaveCaseHistory(CaseInfoDTO objCaseInfoDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("sp_save_case_history");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("P_CASE_HISTORY_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.CaseHistoryId;
            objOracleCommand.Parameters.Add("P_ACTIVITY_TYPE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.ActivityTypeId;
            objOracleCommand.Parameters.Add("P_CASE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.CaseId;
            objOracleCommand.Parameters.Add("P_HISTORY_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.Date;
            objOracleCommand.Parameters.Add("P_CASE_STATUS_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.CaseStatusId;
            objOracleCommand.Parameters.Add("P_APPRARED_YN", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.ChkAppearedYn;
            objOracleCommand.Parameters.Add("P_MODE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.Mode;
            objOracleCommand.Parameters.Add("P_REMARKS", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.Remarks;
            objOracleCommand.Parameters.Add("p_create_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.CreateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    objOracleTransaction = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    objOracleTransaction.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
                }

                catch (Exception ex)
                {
                    objOracleTransaction.Rollback();
                    throw new Exception("Error : " + ex.Message);
                }
                finally
                {
                    strConn.Close();
                }
            }
            return strMsg;
        }
        public string SaveTransferCaseInfo(CaseInfoDTO objCaseInfoDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("sp_save_case_transfer_info");
            objOracleCommand.CommandType = CommandType.StoredProcedure;
            objOracleCommand.Parameters.Add("P_SOURCE_CASE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.SourseCaseNo;
            objOracleCommand.Parameters.Add("P_CASE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.CaseId;
            objOracleCommand.Parameters.Add("P_CASE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.CaseNo;
            objOracleCommand.Parameters.Add("P_ISSUE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.IssueDate;
            objOracleCommand.Parameters.Add("P_CASE_TYPE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.CaseTypeId;
            objOracleCommand.Parameters.Add("P_COURT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.CourtId;
            objOracleCommand.Parameters.Add("P_AMOUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.Amount;
            objOracleCommand.Parameters.Add("P_REMARKS", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.Remarks;
            objOracleCommand.Parameters.Add("p_create_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.CreateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    objOracleTransaction = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    objOracleTransaction.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
                }

                catch (Exception ex)
                {
                    objOracleTransaction.Rollback();
                    throw new Exception("Error : " + ex.Message);
                }
                finally
                {
                    strConn.Close();
                }
            }
            return strMsg;
        }
        public string SaveHearingInfo(CaseInfoDTO objCaseInfoDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("sp_save_hearing_info");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("P_HEARING_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.HearingId;
            objOracleCommand.Parameters.Add("P_CASE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.CaseId;
            objOracleCommand.Parameters.Add("P_ISSUE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.IssueDate;
            objOracleCommand.Parameters.Add("P_CASE_STATUS_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.CaseStatusId;
            objOracleCommand.Parameters.Add("P_REMARKS", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.Remarks;
            objOracleCommand.Parameters.Add("p_create_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.CreateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    objOracleTransaction = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    objOracleTransaction.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
                }

                catch (Exception ex)
                {
                    objOracleTransaction.Rollback();
                    throw new Exception("Error : " + ex.Message);
                }
                finally
                {
                    strConn.Close();
                }
            }
            return strMsg;
        }
        public string SaveWarrantInfo(CaseInfoDTO objCaseInfoDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("sp_save_warrant_info");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("P_WARRANT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.WarrantId;
            objOracleCommand.Parameters.Add("P_CASE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.CaseId;
            objOracleCommand.Parameters.Add("P_ISSUE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.IssueDate;
            objOracleCommand.Parameters.Add("p_create_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.CreateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    objOracleTransaction = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    objOracleTransaction.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
                }

                catch (Exception ex)
                {
                    objOracleTransaction.Rollback();
                    throw new Exception("Error : " + ex.Message);
                }
                finally
                {
                    strConn.Close();
                }
            }
            return strMsg;
        }
        public string SaveDefendant(CaseInfoDTO objCaseInfoDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("sp_save_defendant");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("p_defendant_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.DefendantId;
            objOracleCommand.Parameters.Add("p_defendant_name", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.Defendant;
            objOracleCommand.Parameters.Add("p_create_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.CreateBy;
            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    objOracleTransaction = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    objOracleTransaction.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
                }

                catch (Exception ex)
                {
                    objOracleTransaction.Rollback();
                    throw new Exception("Error : " + ex.Message);
                }
                finally
                {
                    strConn.Close();
                }
            }
            return strMsg;
        }
        public string SaveComplaintant(CaseInfoDTO objCaseInfoDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("sp_save_complaintant");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("p_complaintant_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.ComplaintantId;
            objOracleCommand.Parameters.Add("p_complaintant_name", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.Complaintant;
            objOracleCommand.Parameters.Add("p_create_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.CreateBy;
            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    objOracleTransaction = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    objOracleTransaction.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
                }

                catch (Exception ex)
                {
                    objOracleTransaction.Rollback();
                    throw new Exception("Error : " + ex.Message);
                }
                finally
                {
                    strConn.Close();
                }
            }
            return strMsg;
        }
        public string SaveCaseStatus(CaseInfoDTO objCaseInfoDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("sp_save_case_status");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("p_case_status_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.CaseStatusId;
            objOracleCommand.Parameters.Add("p_case_status", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.CaseStatus;
            objOracleCommand.Parameters.Add("p_create_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.CreateBy;
            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    objOracleTransaction = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    objOracleTransaction.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
                }

                catch (Exception ex)
                {
                    objOracleTransaction.Rollback();
                    throw new Exception("Error : " + ex.Message);
                }
                finally
                {
                    strConn.Close();
                }
            }
            return strMsg;
        }
        public string SaveCaseType(CaseInfoDTO objCaseInfoDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("SP_SAVE_CASE_TYPE");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("p_case_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.CaseTypeId;
            objOracleCommand.Parameters.Add("p_case_type_name", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.CaseTypeName;
            objOracleCommand.Parameters.Add("p_create_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.CreateBy;
            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    objOracleTransaction = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    objOracleTransaction.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
                }

                catch (Exception ex)
                {
                    objOracleTransaction.Rollback();
                    throw new Exception("Error : " + ex.Message);
                }
                finally
                {
                    strConn.Close();
                }
            }
            return strMsg;
        }
        public string SaveCourtInfo(CaseInfoDTO objCaseInfoDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("SP_SAVE_COURT_INFO");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("p_court_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.CourtId;
            objOracleCommand.Parameters.Add("p_court_name", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.CourtName;
            objOracleCommand.Parameters.Add("p_create_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.CreateBy;
            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    objOracleTransaction = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    objOracleTransaction.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
                }

                catch (Exception ex)
                {
                    objOracleTransaction.Rollback();
                    throw new Exception("Error : " + ex.Message);
                }
                finally
                {
                    strConn.Close();
                }
            }
            return strMsg;
        }
        public DataTable GetCaseStatus()
        {

            DataTable dt = new DataTable();

            string sql = "";
            sql = "SELECT " +

                  "* FROM CASE_STATUS   ORDER BY CASE_STATUS";

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
        public DataTable GetCaseType()
        {

            DataTable dt = new DataTable();

            string sql = "";
            sql = "SELECT " +

                  "* FROM CASE_TYPE   ORDER BY CASE_TYPE_NAME";

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
        public DataTable GetCourtInfo()
        {

            DataTable dt = new DataTable();

            string sql = "";
            sql = "SELECT " +

                  "* FROM COURT_INFO   ORDER BY COURT_NAME";

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
        public DataTable LoadCaseInfoGrid(CaseInfoDTO objCaseInfoDTO)
        {
            DataTable myTable = new DataTable();
            try
            {
                OracleCommand objOracleCommand = new OracleCommand("sp_get_case_info");
                objOracleCommand.CommandType = CommandType.StoredProcedure;
                objOracleCommand.Parameters.Add("p_case_no", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.CaseNo;
                objOracleCommand.Parameters.Add("p_case_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.CaseTypeId;
                objOracleCommand.Parameters.Add("p_defendant_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.DefendantId;
                objOracleCommand.Parameters.Add("p_complaintant_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.ComplaintantId;
                objOracleCommand.Parameters.Add("p_from_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.FromDate;
                objOracleCommand.Parameters.Add("p_to_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.Todate;
                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.BranchOfficeId;
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
                        // OracleDataReader dr = objOracleCommand.ExecuteReader();
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

        public DataTable GetTransferCaseInfo(CaseInfoDTO objCaseInfoDTO)
        {
            DataTable myTable = new DataTable();
            try
            {
                OracleCommand objOracleCommand = new OracleCommand("sp_get_transfer_case_info");
                objOracleCommand.CommandType = CommandType.StoredProcedure;
                objOracleCommand.Parameters.Add("p_source_case_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.SourseCaseId;
                objOracleCommand.Parameters.Add("p_source_case_no", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.SourseCaseNo;
                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.BranchOfficeId;
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
                        // OracleDataReader dr = objOracleCommand.ExecuteReader();
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
        public DataTable GetSourseCaseInfo(CaseInfoDTO objCaseInfoDTO)
        {
            DataTable myTable = new DataTable();
            try
            {
                OracleCommand objOracleCommand = new OracleCommand("sp_get_clossed_source_case");
                objOracleCommand.CommandType = CommandType.StoredProcedure;
                objOracleCommand.Parameters.Add("p_defendant_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.DefendantId;
                objOracleCommand.Parameters.Add("p_complaintant_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.ComplaintantId;
                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.BranchOfficeId;
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
                        // OracleDataReader dr = objOracleCommand.ExecuteReader();
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


        //public DataTable LoadCaseInfoGrid(CaseInfoDTO objCaseInfoDTO)
        //{
        //    DataTable myTable = new DataTable();
        //    try
        //    {
        //        OracleCommand objOracleCommand = new OracleCommand("sp_get_case_info");
        //        objOracleCommand.CommandType = CommandType.StoredProcedure;
        //        objOracleCommand.Parameters.Add("p_case_no", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.CaseNo;
        //        objOracleCommand.Parameters.Add("p_case_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.CaseTypeId;
        //        objOracleCommand.Parameters.Add("p_defendant_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.DefendantId;
        //        objOracleCommand.Parameters.Add("p_complaintant_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.ComplaintantId;
        //        objOracleCommand.Parameters.Add("p_from_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.FromDate;
        //        objOracleCommand.Parameters.Add("p_to_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.Todate;
        //        objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.HeadOfficeId;
        //        objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.BranchOfficeId;
        //        objOracleCommand.Parameters.Add("p_dbcursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

        //        string VALUE = string.Empty;

        //        using (OracleConnection strConn = GetConnection())
        //        {
        //            try
        //            {
        //                objOracleCommand.Connection = strConn;
        //                strConn.Open();
        //                trans = strConn.BeginTransaction();

        //                myTable.Load(objOracleCommand.ExecuteReader());
        //                // OracleDataReader dr = objOracleCommand.ExecuteReader();
        //                trans.Commit();
        //                strConn.Close();
        //            }
        //            catch (Exception ex)
        //            {
        //                throw new Exception("Error : " + ex.Message);
        //            }
        //            finally
        //            {
        //                strConn.Close();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return myTable;
        //}
        public DataTable GetHearingInfo(CaseInfoDTO objCaseInfoDTO)
        {
            DataTable myTable = new DataTable();
            try
            {
                OracleCommand objOracleCommand = new OracleCommand("sp_get_hearing_info");
                objOracleCommand.CommandType = CommandType.StoredProcedure;
                objOracleCommand.Parameters.Add("p_case_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.CaseId;
                objOracleCommand.Parameters.Add("p_defendant_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.DefendantId;
                objOracleCommand.Parameters.Add("p_complaintant_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.ComplaintantId;
                objOracleCommand.Parameters.Add("p_from_hearing_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.FromDate;
                objOracleCommand.Parameters.Add("p_to_hearing_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.Todate;
                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.BranchOfficeId;
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
        public DataTable GetWarrantInfo(CaseInfoDTO objCaseInfoDTO)
        {

            DataSet ds = null;
            DataTable myTable = new DataTable();
            try
            {
                OracleCommand objOracleCommand = new OracleCommand("sp_get_warrant_info");
                objOracleCommand.CommandType = CommandType.StoredProcedure;
                objOracleCommand.Parameters.Add("p_case_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.CaseId;
                objOracleCommand.Parameters.Add("p_defendant_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.DefendantId;
                objOracleCommand.Parameters.Add("p_complaintant_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.ComplaintantId;
                objOracleCommand.Parameters.Add("p_from_warrant_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.FromDate;
                objOracleCommand.Parameters.Add("p_to_warrant_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.Todate;
                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.BranchOfficeId;
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
                        // OracleDataReader dr = objOracleCommand.ExecuteReader();
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
        public CaseInfoDTO GetComplaintatnDefendantNameByCaseNo(CaseInfoDTO objCaseInfoDTO)
        {
            CaseInfoDTO objCaseInfo = new CaseInfoDTO();
            DataTable dt = new DataTable();
            try
            {
                OracleCommand objOracleCommand = new OracleCommand("sp_get_complaintant_defendant");
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                objOracleCommand.Parameters.Add("p_case_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.CaseId;
                objOracleCommand.Parameters.Add("p_dbcursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                string VALUE = string.Empty;
                using (OracleConnection strConn = GetConnection())
                {
                    try
                    {
                        objOracleCommand.Connection = strConn;
                        strConn.Open();
                        trans = strConn.BeginTransaction();
                        dt.Load(objOracleCommand.ExecuteReader());
                        trans.Commit();
                        strConn.Close();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            objCaseInfo.Complaintant = Convert.ToString(dt.Rows[i]["complaintant_name"]);
                            objCaseInfo.Defendant = Convert.ToString(dt.Rows[i]["defendant_name"]);
                        }
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
            return objCaseInfo;
        }
        public CaseInfoDTO GetSourceCaseInformationBySourceCase(CaseInfoDTO objCaseInfoDTO)
        {
            CaseInfoDTO objCaseInfo = new CaseInfoDTO();
            DataTable dt = new DataTable();
            try
            {
                OracleCommand objOracleCommand = new OracleCommand("sp_get_source_case_info");
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                objOracleCommand.Parameters.Add("p_source_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.SourseCaseId;
                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.BranchOfficeId;
                objOracleCommand.Parameters.Add("p_dbcursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                string VALUE = string.Empty;
                using (OracleConnection strConn = GetConnection())
                {
                    try
                    {
                        objOracleCommand.Connection = strConn;
                        strConn.Open();
                        trans = strConn.BeginTransaction();
                        dt.Load(objOracleCommand.ExecuteReader());
                        trans.Commit();
                        strConn.Close();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            objCaseInfo.SourseCaseNo = Convert.ToString(dt.Rows[i]["case_no"]);
                            objCaseInfo.Complaintant = Convert.ToString(dt.Rows[i]["complaintant_name"]);
                            objCaseInfo.Defendant = Convert.ToString(dt.Rows[i]["defendant_name"]);
                            objCaseInfo.CaseTypeName = Convert.ToString(dt.Rows[i]["case_type_name"]);
                            objCaseInfo.IssueDate = Convert.ToString(dt.Rows[i]["issue_date"]);
                            objCaseInfo.Amount = Convert.ToString(dt.Rows[i]["amount"]);
                        }
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
            return objCaseInfo;
        }
        public DataTable GetDefendant()
        {

            DataTable dt = new DataTable();

            string sql = "";
            sql = "SELECT " +

                  "* FROM DEFENDANT   ORDER BY DEFENDANT_NAME";

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
        public DataTable GetComplaintant()
        {

            DataTable dt = new DataTable();

            string sql = "";
            sql = "SELECT " +

                  "* FROM COMPLAINTANT   ORDER BY COMPLAINTANT_NAME";

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
        public List<CaseInfornation> GetCaseNoByCaseID(string caseNo)
        {
            List<CaseInfornation> objCaseInfornations = new List<CaseInfornation>();
            DataTable dt = new DataTable();
            try
            {
                OracleCommand objOracleCommand = new OracleCommand("sp_get_case_id_by_case_no");
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                objOracleCommand.Parameters.Add("p_case_no", OracleDbType.Varchar2, ParameterDirection.Input).Value = caseNo;
                objOracleCommand.Parameters.Add("p_dbcursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                string VALUE = string.Empty;

                using (OracleConnection strConn = GetConnection())
                {
                    try
                    {
                        objOracleCommand.Connection = strConn;
                        strConn.Open();
                        trans = strConn.BeginTransaction();

                        dt.Load(objOracleCommand.ExecuteReader());
                        trans.Commit();
                        strConn.Close();

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            CaseInfornation objCaseInfo = new CaseInfornation();
                            objCaseInfo.CASE_ID = dt.Rows[i]["CASE_ID"].ToString();
                            objCaseInfo.CASE_NO = dt.Rows[i]["CASE_NO"].ToString();
                            objCaseInfornations.Add(objCaseInfo);
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objCaseInfornations;
        }
        public DataTable GetDefendantId()
        {
            DataTable dt = new DataTable();
            string sql = "";
            sql = "select '' DEFENDANT_ID, ' Please Select One ' DEFENDANT_NAME from dual " +
                    "union " +

                "SELECT " +
                  "to_char(DEFENDANT_ID), " +
                  "to_char(DEFENDANT_NAME) " +
                  "FROM DEFENDANT order by DEFENDANT_NAME ASC";

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
        public DataTable GetComplaintantId()
        {

            DataTable dt = new DataTable();
            string sql = "";
            sql = "select '' COMPLAINTANT_ID, ' Please Select One ' COMPLAINTANT_NAME from dual " +
                    "union " +

                "SELECT " +
                  "to_char(COMPLAINTANT_ID), " +
                  "to_char(COMPLAINTANT_NAME) " +
                  "FROM COMPLAINTANT order by COMPLAINTANT_NAME ASC";
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
        public DataTable GetCaseStatusId()
        {

            DataTable dt = new DataTable();
            string sql = "";
            sql = "select '' CASE_STATUS_ID, ' Please Select One ' CASE_STATUS from dual " +
                    "union " +

                "SELECT " +
                  "to_char(CASE_STATUS_ID), " +
                  "to_char(CASE_STATUS) " +
                  "FROM CASE_STATUS order by CASE_STATUS ASC";
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

        public string DeleteCaseHistory(CaseInfoDTO objCaseInfoDTO)
        {
            string strMsg = "";
            OracleCommand objOracleCommand = new OracleCommand("SP_DELETE_CASE_HISTORY");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("P_HISTORY_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.CaseHistoryId;
            objOracleCommand.Parameters.Add("P_CASE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.CaseId;
            objOracleCommand.Parameters.Add("p_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("p_CREATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.CreateBy;
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
        public DataTable GetCaseId(string HeadOfficeId, string BranchOfficeId)
        {

            DataTable dt = new DataTable();
            string sql = "";
            sql = "select '' CASE_ID, ' Please Select One ' CASE_NO from dual " +
                    "union " +

                "SELECT " +
                  "to_char(CASE_ID), " +
                  "to_char(CASE_NO) " +
                  "FROM CASE_INFO where head_office_id = '" + HeadOfficeId +"' and branch_office_id = '" + BranchOfficeId + "' order by CASE_NO ASC";
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


        public DataTable GetSourceCase(string caseId)
        {

            DataTable dt = new DataTable();
            string sql = "";
            sql = "select '' CASE_ID, ' Please Select One ' CASE_NO from dual " +
                  "union " +
                  "SELECT to_char(CASE_ID), to_char(CASE_NO) FROM CASE_INFO " +
                  " where case_mode = 'O' and case_id not in ('" + caseId + "') order by CASE_NO ASC";
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

        public DataTable GetInactiveSourceCase(string defendantId, string complainantId)
        {

            DataTable dt = new DataTable();
            string sql = "";
            sql = "select '' CASE_ID, ' Please Select One ' CASE_NO from dual " +
                  "union " +
                  "SELECT to_char(CASE_ID), to_char(CASE_NO) FROM CASE_INFO " +
                  " where case_mode = 'C' and defendant_id = " + defendantId + " and complaintant_id=" + complainantId + " order by CASE_NO ASC";
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


        public DataTable GetCaseTypeId()
        {
            DataTable dt = new DataTable();
            string sql = "";
            sql = "select '' CASE_TYPE_ID, ' Please Select One ' CASE_TYPE_NAME from dual " +
                    "union " +

                "SELECT " +
                  "to_char(CASE_TYPE_ID), " +
                  "to_char(CASE_TYPE_NAME) " +
                  "FROM CASE_TYPE order by CASE_TYPE_NAME asc";

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
        public DataTable GetActivityType()
        {

            DataTable dt = new DataTable();
            string sql = "";
            sql = "select '' activity_type_id, ' Please Select One ' activity_name from dual " +
                    "union " +

                "SELECT " +
                  "to_char(activity_type_id), " +
                  "to_char(activity_name) " +
                  "FROM activity_type order by activity_name ASC";
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
        public DataTable GetCourtId()
        {
            DataTable dt = new DataTable();
            string sql = "";
            sql = "select '' COURT_ID, ' Please Select One ' COURT_NAME from dual " +
                    "union " +

                "SELECT " +
                  "to_char(COURT_ID), " +
                  "to_char(COURT_NAME) " +
                  "FROM COURT_INFO order by COURT_NAME asc";

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
        public string DeleteSourceCaseInfo(CaseInfoDTO objCaseInfoDTO)
        {
            string strMsg = "";
            OracleCommand objOracleCommand = new OracleCommand("SP_DELETE_SOURCE_CASE_INFO");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("P_SOURCE_CASE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.SourseCaseId;
            objOracleCommand.Parameters.Add("P_CASE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.CaseId;
            objOracleCommand.Parameters.Add("p_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.BranchOfficeId;
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
        public DataTable GetCaseHistory(CaseInfoDTO objCaseInfoDTO)
        {
            DataTable myTable = new DataTable();
            try
            {
                OracleCommand objOracleCommand = new OracleCommand("sp_get_case_history");
                objOracleCommand.CommandType = CommandType.StoredProcedure;
                objOracleCommand.Parameters.Add("p_case_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.CaseId;
                objOracleCommand.Parameters.Add("p_from_history_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.FromDate;
                objOracleCommand.Parameters.Add("p_to_history_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.Todate;
                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCaseInfoDTO.BranchOfficeId;
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

        #region Reminder
        
        public List<CaseInfoDTO> GetCaseReminder(string inquiryDate)
        {
            CaseInfoDTO objCaseInfo = new CaseInfoDTO();
            List<CaseInfoDTO> objCaseInfoList = new List<CaseInfoDTO>();
            DataTable dt = new DataTable();
            try
            {
                OracleCommand objOracleCommand = new OracleCommand("sp_get_case_reminder");
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                objOracleCommand.Parameters.Add("p_inquiry_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = inquiryDate;
                objOracleCommand.Parameters.Add("p_dbcursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                string VALUE = string.Empty;
                using (OracleConnection strConn = GetConnection())
                {
                    try
                    {
                        objOracleCommand.Connection = strConn;
                        strConn.Open();
                        trans = strConn.BeginTransaction();
                        dt.Load(objOracleCommand.ExecuteReader());
                        trans.Commit();
                        strConn.Close();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            objCaseInfo = new CaseInfoDTO();
                            objCaseInfo.SerialNo = Convert.ToString(dt.Rows[i]["serial_no"]);
                            objCaseInfo.CaseNo = Convert.ToString(dt.Rows[i]["case_no"]);
                            objCaseInfo.Complaintant = Convert.ToString(dt.Rows[i]["complaintant_name"]);
                            objCaseInfo.Defendant = Convert.ToString(dt.Rows[i]["defendant_name"]);
                            objCaseInfo.HistoryDate = Convert.ToString(dt.Rows[i]["history_date"]);
                            objCaseInfo.CaseStatus = Convert.ToString(dt.Rows[i]["case_status"]);
                            objCaseInfo.Remarks = Convert.ToString(dt.Rows[i]["remarks"]);
                            objCaseInfo.ActivityName = Convert.ToString(dt.Rows[i]["activity_name"]);
                            
                            objCaseInfoList.Add(objCaseInfo);
                        }
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
                //throw ex;
            }
            return objCaseInfoList;
        }

        public List<CaseInfoDTO> GetHearingReminder(string hearingDate)
        {
            CaseInfoDTO objCaseInfo = new CaseInfoDTO();
            List<CaseInfoDTO> objCaseInfoList = new List<CaseInfoDTO>();
            DataTable dt = new DataTable();
            try
            {
                OracleCommand objOracleCommand = new OracleCommand("sp_get_hearing_reminder");
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                objOracleCommand.Parameters.Add("p_hearing_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = hearingDate;
                objOracleCommand.Parameters.Add("p_dbcursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                string VALUE = string.Empty;
                using (OracleConnection strConn = GetConnection())
                {
                    try
                    {
                        objOracleCommand.Connection = strConn;
                        strConn.Open();
                        trans = strConn.BeginTransaction();
                        dt.Load(objOracleCommand.ExecuteReader());
                        trans.Commit();
                        strConn.Close();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            objCaseInfo = new CaseInfoDTO();
                            objCaseInfo.SerialNo = Convert.ToString(dt.Rows[i]["serial_no"]);
                            objCaseInfo.CaseNo = Convert.ToString(dt.Rows[i]["case_no"]);
                            objCaseInfo.Complaintant = Convert.ToString(dt.Rows[i]["complaintant_name"]);
                            objCaseInfo.Defendant = Convert.ToString(dt.Rows[i]["defendant_name"]);
                            objCaseInfo.HearingDate = Convert.ToString(dt.Rows[i]["hearing_date"]);
                            objCaseInfo.CaseStatus = Convert.ToString(dt.Rows[i]["case_status"]);
                            objCaseInfo.Remarks = Convert.ToString(dt.Rows[i]["remarks"]);
                            objCaseInfoList.Add(objCaseInfo);
                        }
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
                //throw ex;
            }
            return objCaseInfoList;
        }
        
        #endregion
    }
}

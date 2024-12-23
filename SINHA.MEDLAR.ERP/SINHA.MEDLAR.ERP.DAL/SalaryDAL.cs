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
    public class SalaryDAL
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

        public string addWorkerIncrementCasual(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_increment_casual_add");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;

            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            objOracleCommand.Parameters.Add("P_INCREMENT_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("P_INCREMENT_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;




            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string saveIncrementWorkerCasual(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_increment_casual_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;
            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("P_INCREMENT_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("P_INCREMENT_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;
            if (objSalaryDTO.IncrementAmount != "")
            {
                objOracleCommand.Parameters.Add("P_INCREMENT_AMOUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.IncrementAmount;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_INCREMENT_AMOUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public SalaryDTO searchWorkerIncrementEntryCasual(string strEmployeeId, string strIncrementYear, string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();


            string sql = "";

            sql = "SELECT " +

                  "to_char(NVL(INCREMENT_AMOUNT, '0' )), " +
                  "to_char(NVL(GROSS_SALARY, '0' )), " +
                  "NVL (TO_CHAR (JOINING_DATE, 'dd/mm/yyyy'), ' ') " +

                  "FROM VEW_INCREMENT_SHEET_CASUAL WHERE employee_id = '" + strEmployeeId + "' AND increment_year = '" + strIncrementYear + "'  AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "'";

            if (strUnitId.Length > 0)
            {
                sql = sql + " AND unit_id = '" + strUnitId + "'";

            }
            if (strSectionId.Length > 0)
            {
                sql = sql + " AND section_id = '" + strSectionId + "'";

            }



            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {



                    objSalaryDTO.IncrementAmount = objDataReader.GetString(0);
                    objSalaryDTO.GrossSalary = objDataReader.GetString(1);
                    objSalaryDTO.JoiningDate = objDataReader.GetString(2);

                }



            }

            return objSalaryDTO;
        }
        public string processSalaryStaff(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_salary_process_staff");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

          

            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

          
            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;
            

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
        public string BankSheetUpload(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("PRO_BANK_SHEET_UPLOAD");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objSalaryDTO.TranId != "")
            {

                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.TranId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;

            if (objSalaryDTO.FileName != "")
            {

                objOracleCommand.Parameters.Add("P_FILE_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.FileName;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_FILE_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSalaryDTO.FileType != "")
            {

                objOracleCommand.Parameters.Add("P_FILE_TYPE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.FileType;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_FILE_TYPE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSalaryDTO.FileSize != "")
            {

                byte[] array = System.Convert.FromBase64String(objSalaryDTO.FileSize);
                objOracleCommand.Parameters.Add("P_DATA_FILE", OracleDbType.Blob, ParameterDirection.Input).Value = array;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_DATA_FILE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string DeleteBankSheet(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("PRO_DELETE_BANK_SHEET");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objSalaryDTO.TranId != "")
            {

                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.TranId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;

            

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string HalfSalaryStaff(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_half_salary_staff");
            objOracleCommand.CommandType = CommandType.StoredProcedure;
            

            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;
            
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
        public string deleteHalfSalaryStaff(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("PRO_DELETE_HALF_SAL_ADD_STAFF");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;



            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string deleteHalfSalaryAddWorker(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("PRO_DELETE_HALF_SAL_ADD_WORKER");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;



            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string deleteHalfSalaryAddHO(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("PRO_DELETE_HALF_SAL_ADD_HO");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;



            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string saveHalfSalaryAddStaff(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("PRO_SAVE_HALF_SAL_ADD_STAFF");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;
            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;



            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string saveHalfSalaryAddWorker(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("PRO_SAVE_HALF_SAL_ADD_WORKER");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;
            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;



            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string saveHalfSalaryAddHO(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("PRO_SAVE_HALF_SAL_ADD_HO");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;
            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;



            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string processSalaryMiscStaff(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_salary_process_staff_misc");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string halfSheetStaffMisc(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_half_salary_staff_misc");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string halfSheetStaffSummery(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_half_salary_sum_staff");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string monthlyStaffSalarySummeryProcess(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_monthly_sal_summery_staff");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string saveBankSalary(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_bank_salary_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;



            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;
            if (objSalaryDTO.FirstSalary != "")
            {
                objOracleCommand.Parameters.Add("p_first_salary", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.FirstSalary;

            }
            else
            {

                objOracleCommand.Parameters.Add("p_first_salary", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string procesFirstSalaryForBank(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_bank_salary_process");
            objOracleCommand.CommandType = CommandType.StoredProcedure;




            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;
           
            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string saveSalaryMiscEntry(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_salary_entry_ho_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;
            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;


            if (objSalaryDTO.AdvanceFee != "")
            {
                objOracleCommand.Parameters.Add("P_ADVANCE_FEE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.AdvanceFee;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_ADVANCE_FEE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

           
            if (objSalaryDTO.ArrearFee != "")
            {
                objOracleCommand.Parameters.Add("P_ARREAR_FEE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.ArrearFee;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_ARREAR_FEE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objSalaryDTO.FoodAllowance != "")
            {
                objOracleCommand.Parameters.Add("P_FOOD_ALLOWANCE_FEE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.FoodAllowance;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_FOOD_ALLOWANCE_FEE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSalaryDTO.FoodDeductFee != "")
            {
                objOracleCommand.Parameters.Add("P_FOOD_DEDUCT_FEE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.FoodDeductFee;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_FOOD_DEDUCT_FEE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSalaryDTO.WorkingDay != "")
            {
                objOracleCommand.Parameters.Add("P_WORKING_DAY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.WorkingDay;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_WORKING_DAY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }



            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string saveSalaryEntryHOMISC(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_salary_entry_ho_misc_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;
            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;


            if (objSalaryDTO.AdvanceFee != "")
            {
                objOracleCommand.Parameters.Add("P_ADVANCE_FEE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.AdvanceFee;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_ADVANCE_FEE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objSalaryDTO.ArrearFee != "")
            {
                objOracleCommand.Parameters.Add("P_ARREAR_FEE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.ArrearFee;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_ARREAR_FEE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSalaryDTO.FoodAllowance != "")
            {
                objOracleCommand.Parameters.Add("P_FOOD_ALLOWANCE_FEE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.FoodAllowance;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_FOOD_ALLOWANCE_FEE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objSalaryDTO.FoodDeductFee != "")
            {
                objOracleCommand.Parameters.Add("P_FOOD_DEDUCT_FEE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.FoodDeductFee;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_FOOD_DEDUCT_FEE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSalaryDTO.WorkingDay != "")
            {
                objOracleCommand.Parameters.Add("P_WORKING_DAY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.WorkingDay;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_WORKING_DAY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string processSalaryCertificate(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_salary_certificate_process");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objSalaryDTO.EmployeeId != "")
            {

                objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

         
            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("p_certificate_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_certificate_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;

            if (objSalaryDTO.ApprovedById != "")
            {
                objOracleCommand.Parameters.Add("p_approved_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.ApprovedById;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_approved_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
           




            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string deleteSalaryCertificate(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_delete_salary_certificate");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objSalaryDTO.EmployeeId != "")
            {

                objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


           

            objOracleCommand.Parameters.Add("p_certificate_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_certificate_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;

           


            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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

        public string saveSalaryMiscEntryCash(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_salary_misc_save_cash");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;
            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;



            if (objSalaryDTO.FoodAllowance != "")
            {
                objOracleCommand.Parameters.Add("p_food_allowance_fee", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.FoodAllowance;

            }
            else
            {
                objOracleCommand.Parameters.Add("p_food_allowance_fee", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSalaryDTO.ArrearFee != "")
            {
                objOracleCommand.Parameters.Add("p_arrear_fee", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.ArrearFee;

            }
            else
            {
                objOracleCommand.Parameters.Add("p_arrear_fee", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSalaryDTO.AdvanceFee != "")
            {
                objOracleCommand.Parameters.Add("p_advance_fee", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.AdvanceFee;

            }
            else
            {
                objOracleCommand.Parameters.Add("p_advance_fee", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }




            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string savePunchCode(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_update_punch_code");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;
            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            if (objSalaryDTO.PunchingCode != "")
            {
                objOracleCommand.Parameters.Add("p_punch_code", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.PunchingCode;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_punch_code", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string saveSalaryMiscEntryWoker(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
                                    
            OracleCommand objOracleCommand = new OracleCommand("pro_salary_entry_worker_save");

            //new: FOR TEST
            //OracleCommand objOracleCommand = new OracleCommand("pro_salary_entry_worker");
                        
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;
            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            
            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;   

            if (objSalaryDTO.AdvanceFee != "")
            {
                objOracleCommand.Parameters.Add("p_advance_fee", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.AdvanceFee;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_advance_fee", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.ArrearFee != "")
            {
                objOracleCommand.Parameters.Add("p_arrear_fee", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.ArrearFee;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_arrear_fee", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }          

            if (objSalaryDTO.WorkingDay != "")
            {
                objOracleCommand.Parameters.Add("p_working_day", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.WorkingDay;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_working_day", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
                        
            objOracleCommand.Parameters.Add("P_BKASH_YN", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BkashYn;

            if (objSalaryDTO.OverTimeHour != "")
            {
                objOracleCommand.Parameters.Add("P_OVER_TIME_HOUR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.OverTimeHour;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_OVER_TIME_HOUR", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            //added 9.02.2020
            if (objSalaryDTO.EarlyDptHour != "")
            {
                objOracleCommand.Parameters.Add("P_EARLY_PEPURATURE_HOUR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EarlyDptHour;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_EARLY_PEPURATURE_HOUR", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            //end
            if (objSalaryDTO.Bonus != "")
            {
                objOracleCommand.Parameters.Add("P_ATTENDENCE_FEE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Bonus;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_ATTENDENCE_FEE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.Remarks != "")
            {
                objOracleCommand.Parameters.Add("p_remarks", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Remarks;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_remarks", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;
            
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
        public string saveSalaryMiscEntryResign(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_salary_entry_resign_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;
            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;





            if (objSalaryDTO.AdvanceFee != "")
            {
                objOracleCommand.Parameters.Add("p_advance_fee", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.AdvanceFee;

            }
            else
            {
                objOracleCommand.Parameters.Add("p_advance_fee", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSalaryDTO.ArrearFee != "")
            {
                objOracleCommand.Parameters.Add("p_arrear_fee", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.ArrearFee;

            }
            else
            {
                objOracleCommand.Parameters.Add("p_arrear_fee", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }



            if (objSalaryDTO.WorkingDay != "")
            {
                objOracleCommand.Parameters.Add("p_working_day", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.WorkingDay;

            }
            else
            {
                objOracleCommand.Parameters.Add("p_working_day", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSalaryDTO.OverTimeHour != "")
            {
                objOracleCommand.Parameters.Add("P_OVER_TIME_HOUR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.OverTimeHour;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_OVER_TIME_HOUR", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSalaryDTO.Bonus != "")
            {
                objOracleCommand.Parameters.Add("P_ATTENDENCE_FEE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Bonus;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_ATTENDENCE_FEE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string saveHalfSalaryWorker(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_half_salary_worker_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;
            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;

            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

           
            if (objSalaryDTO.WorkingDay != "")
            {
                objOracleCommand.Parameters.Add("p_working_day", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.WorkingDay;

            }
            else
            {
                objOracleCommand.Parameters.Add("p_working_day", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSalaryDTO.OverTimeHour != "")
            {
                objOracleCommand.Parameters.Add("P_OVER_TIME_HOUR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.OverTimeHour;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_OVER_TIME_HOUR", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }




            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string saveHalfSalaryHO(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_half_salary_ho_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;
            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;

            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objSalaryDTO.WorkingDay != "")
            {
                objOracleCommand.Parameters.Add("p_working_day", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.WorkingDay;

            }
            else
            {
                objOracleCommand.Parameters.Add("p_working_day", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSalaryDTO.AdvanceFee != "")
            {
                objOracleCommand.Parameters.Add("P_ADVANCE_FEE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.AdvanceFee;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_ADVANCE_FEE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objSalaryDTO.SalaryPercentage != "")
            {
                objOracleCommand.Parameters.Add("P_SALARY_PERCENTAGE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SalaryPercentage;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_SALARY_PERCENTAGE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string saveHalfSalaryStaff(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_half_salary_staff_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;
            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;

            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objSalaryDTO.WorkingDay != "")
            {
                objOracleCommand.Parameters.Add("p_working_day", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.WorkingDay;

            }
            else
            {
                objOracleCommand.Parameters.Add("p_working_day", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }



            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string saveIncrementWorker(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_increment_worker_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;
            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("P_INCREMENT_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("P_INCREMENT_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;
            if (objSalaryDTO.IncrementAmount != "")
            {
                objOracleCommand.Parameters.Add("P_INCREMENT_AMOUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.IncrementAmount;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_INCREMENT_AMOUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            objOracleCommand.Parameters.Add("p_five_percent_yn", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.AutoIncrementYn;
            objOracleCommand.Parameters.Add("P_MONTHLY_INCREMENT_YN", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.MonthlyIncrementYn;
            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string saveArrearWorkerEntry(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_arrear_worker_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;
            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("P_ARREAR_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("P_ARREAR_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;
            if (objSalaryDTO.ManualIncrement != "")
            {
                objOracleCommand.Parameters.Add("P_INCREMENT_AMOUNT_MANUAL", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.ManualIncrement;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_INCREMENT_AMOUNT_MANUAL", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string saveIncrementWorkerAnnual(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_inc_worker_annual_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;
            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("P_INCREMENT_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("P_INCREMENT_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;
            objOracleCommand.Parameters.Add("P_BATCH_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BatchNo;

            if (objSalaryDTO.IncrementAmount != "")
            {
                objOracleCommand.Parameters.Add("P_INCREMENT_AMOUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.IncrementAmount;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_INCREMENT_AMOUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.IncrementAmount2ndTerm != "")
            {
                objOracleCommand.Parameters.Add("p_increment_amount_2nd_term", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.IncrementAmount2ndTerm;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_increment_amount_2nd_term", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string saveIncrementWorkerNonProposal(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_inc_worker_non_propos_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;
            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("P_INCREMENT_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;

            if (objSalaryDTO.IncrementAmount != "")
            {
                objOracleCommand.Parameters.Add("P_INCREMENT_AMOUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.IncrementAmount;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_INCREMENT_AMOUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        //public string saveIncrementStaffNonProposal(SalaryDTO objSalaryDTO)
        //{
        //    string strMsg = "";
        //    OracleTransaction objOracleTransaction = null;
        //    OracleCommand objOracleCommand = new OracleCommand("pro_inc_staff_non_propos_save");
        //    objOracleCommand.CommandType = CommandType.StoredProcedure;


        //    objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;
        //    if (objSalaryDTO.UnitId != "")
        //    {
        //        objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
        //    }
        //    else
        //    {

        //        objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
        //    }

        //    if (objSalaryDTO.SectionId != "")
        //    {
        //        objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
        //    }
        //    else
        //    {

        //        objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
        //    }


        //    objOracleCommand.Parameters.Add("P_INCREMENT_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;

        //    if (objSalaryDTO.IncrementAmount != "")
        //    {
        //        objOracleCommand.Parameters.Add("P_INCREMENT_AMOUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.IncrementAmount;
        //    }
        //    else
        //    {

        //        objOracleCommand.Parameters.Add("P_INCREMENT_AMOUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
        //    }


        //    objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
        //    objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
        //    objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


        //    objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;


        //    using (OracleConnection strConn = GetConnection())
        //    {
        //        try
        //        {

        //            objOracleCommand.Connection = strConn;
        //            strConn.Open();
        //            trans = strConn.BeginTransaction();
        //            objOracleCommand.ExecuteNonQuery();
        //            trans.Commit();
        //            strConn.Close();
        //            strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
        //        }

        //        catch (Exception ex)
        //        {
        //            trans.Rollback();
        //            throw new Exception("Error : " + ex.Message);

        //        }

        //        finally
        //        {

        //            strConn.Close();
        //        }

        //    }
        //    return strMsg;

        //}

        public string saveIncrementStaffNonProposal(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_inc_staff_non_propos_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;
            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("P_INCREMENT_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;

            if (objSalaryDTO.IncrementAmount != "")
            {
                objOracleCommand.Parameters.Add("P_INCREMENT_AMOUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.IncrementAmount;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_INCREMENT_AMOUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objSalaryDTO.GrossSalary != "")
            {
                objOracleCommand.Parameters.Add("P_GROSS_SALARY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.GrossSalary;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_GROSS_SALARY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string saveIncrementStaff(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_increment_staff_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;

            //if (objSalaryDTO.UnitId != "")
            //{
            //    objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            //}
            //else
            //{
            //    objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            //}
            //if (objSalaryDTO.SectionId != "")
            //{
            //    objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            //}
            //else
            //{
            //    objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            //}


            objOracleCommand.Parameters.Add("P_INCREMENT_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("P_INCREMENT_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;
            objOracleCommand.Parameters.Add("P_BATCH_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BatchNo;

            if (objSalaryDTO.IncrementAmount != "")
            {
                objOracleCommand.Parameters.Add("P_INCREMENT_AMOUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.IncrementAmount;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_INCREMENT_AMOUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;
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
        public string saveIncrementStaffMonthly(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_inc_staff_monthly_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;
            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("P_INCREMENT_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("P_INCREMENT_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;


            if (objSalaryDTO.IncrementAmount != "")
            {
                objOracleCommand.Parameters.Add("P_INCREMENT_AMOUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.IncrementAmount;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_INCREMENT_AMOUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            if (objSalaryDTO.EffectiveDate != "")
            {
                objOracleCommand.Parameters.Add("P_YEARLY_INC_EFFECT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EffectiveDate;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_YEARLY_INC_EFFECT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objSalaryDTO.YearlyIncYesOrNot != "")
            {
                objOracleCommand.Parameters.Add("P_YEARLY_INCREMENT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.YearlyIncYesOrNot;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_YEARLY_INCREMENT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string processWorkerAttendence(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_attendence_process_worker");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


        
            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;






            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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

        public string saveOverTimeEntryWoker(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_over_time_worker_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;
            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            objOracleCommand.Parameters.Add("P_OT_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("P_OT_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;

            if (objSalaryDTO.OverTimeHour != "")
            {
                objOracleCommand.Parameters.Add("p_over_time_hour", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.OverTimeHour;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_over_time_hour", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.AdvanceDeductFee != "")
            {
                objOracleCommand.Parameters.Add("p_ot_advance_amount", OracleDbType.Int32, ParameterDirection.Input).Value = objSalaryDTO.OtAdvanceAmount;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_ot_advance_amount", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

                        
            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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

        public string saveArrearAdvance(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_arrear_advance_ho_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;

            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("P_ARREAR_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;


            if (objSalaryDTO.FromMonth != "")
            {
                objOracleCommand.Parameters.Add("p_from_month_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.FromMonth;

            }
            else
            {
                objOracleCommand.Parameters.Add("p_from_month_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSalaryDTO.ToMonth != "")
            {
                objOracleCommand.Parameters.Add("p_to_month_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.ToMonth;

            }
            else
            {
                objOracleCommand.Parameters.Add("p_to_month_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objSalaryDTO.AdvanceFee != "")
            {
                objOracleCommand.Parameters.Add("p_advance_fee", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.AdvanceFee;

            }
            else
            {
                objOracleCommand.Parameters.Add("p_advance_fee", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSalaryDTO.WithoutArrearYes != "")
            {
                objOracleCommand.Parameters.Add("P_WITHOUT_ARREAR_YES", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.WithoutArrearYes;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_WITHOUT_ARREAR_YES", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }



            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string overTimeProcess(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_ot_process_worker");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            objOracleCommand.Parameters.Add("P_OT_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("P_OT_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;

           
            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string overTimeSummeryProcessMonthly(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_ot_summery_monthly");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;


           


            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string OverTimeRequisitionSummery(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_ot_process_worker");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            objOracleCommand.Parameters.Add("P_OT_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("P_OT_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;


            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string saveLeaveEntryWoker(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_leave_save_worker");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;
            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
         



          
            if (objSalaryDTO.LeaveDay != "")
            {
                objOracleCommand.Parameters.Add("P_LEAVE_DAY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.LeaveDay;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_LEAVE_DAY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

           


            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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


        public string staffleaveProcessByPunching(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_leave_process_staff_atten");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("p_leave_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;

            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }










            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string workerleaveProcessByPunching(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_leave_process_worker_atten");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("p_leave_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;

            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            
            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;
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
        public string processLeaveWorker(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_leave_process_worker");
            objOracleCommand.CommandType = CommandType.StoredProcedure;
                       
            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            
            objOracleCommand.Parameters.Add("p_leave_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;

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

        //public string processLeaveStaff(SalaryDTO objSalaryDTO)
        //{
        //    string strMsg = "";
        //    OracleTransaction objOracleTransaction = null;
        //    OracleCommand objOracleCommand = new OracleCommand("pro_leave_process_staff");
        //    objOracleCommand.CommandType = CommandType.StoredProcedure;



        //    if (objSalaryDTO.UnitId != "")
        //    {
        //        objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
        //    }
        //    else
        //    {

        //        objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
        //    }

        //    if (objSalaryDTO.SectionId != "")
        //    {
        //        objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
        //    }
        //    else
        //    {

        //        objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
        //    }


        //    objOracleCommand.Parameters.Add("p_leave_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;







        //    objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
        //    objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
        //    objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


        //    objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;


        //    using (OracleConnection strConn = GetConnection())
        //    {
        //        try
        //        {

        //            objOracleCommand.Connection = strConn;
        //            strConn.Open();
        //            trans = strConn.BeginTransaction();
        //            objOracleCommand.ExecuteNonQuery();
        //            trans.Commit();
        //            strConn.Close();
        //            strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
        //        }

        //        catch (Exception ex)
        //        {
        //            objOracleTransaction.Rollback();
        //            throw new Exception("Error : " + ex.Message);

        //        }

        //        finally
        //        {

        //            strConn.Close();
        //        }

        //    }
        //    return strMsg;

        //}
        //public string processLeaveStaffMisc(SalaryDTO objSalaryDTO)
        //{
        //    string strMsg = "";
        //    OracleTransaction objOracleTransaction = null;
        //    OracleCommand objOracleCommand = new OracleCommand("pro_leave_process_staff_misc");
        //    objOracleCommand.CommandType = CommandType.StoredProcedure;



        //    if (objSalaryDTO.UnitId != "")
        //    {
        //        objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
        //    }
        //    else
        //    {

        //        objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
        //    }

        //    if (objSalaryDTO.SectionId != "")
        //    {
        //        objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
        //    }
        //    else
        //    {

        //        objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
        //    }


        //    objOracleCommand.Parameters.Add("p_leave_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;







        //    objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
        //    objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
        //    objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


        //    objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;


        //    using (OracleConnection strConn = GetConnection())
        //    {
        //        try
        //        {
        //            objOracleCommand.Connection = strConn;
        //            strConn.Open();
        //            trans = strConn.BeginTransaction();
        //            objOracleCommand.ExecuteNonQuery();
        //            trans.Commit();
        //            strConn.Close();
        //            strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
        //        }

        //        catch (Exception ex)
        //        {
        //            objOracleTransaction.Rollback();
        //            throw new Exception("Error : " + ex.Message);

        //        }

        //        finally
        //        {

        //            strConn.Close();
        //        }

        //    }
        //    return strMsg;

        //}


        public string processLeaveStaff(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_leave_process_staff");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objSalaryDTO.UnitGroupId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_group_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitGroupId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_group_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("p_leave_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;







            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string processLeaveStaffMisc(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_leave_process_staff_misc");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.UnitGroupId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_group_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitGroupId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_group_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("p_leave_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;







            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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


        public string saveLeaveEntryStaff(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_leave_save_staff");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;
            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
          




            if (objSalaryDTO.LeaveDay != "")
            {
                objOracleCommand.Parameters.Add("P_LEAVE_DAY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.LeaveDay;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_LEAVE_DAY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }




            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        //public string processLeaveStaffSummery(SalaryDTO objSalaryDTO)
        //{
        //    string strMsg = "";
        //    OracleTransaction objOracleTransaction = null;
        //    OracleCommand objOracleCommand = new OracleCommand("pro_leave_summery_staff");
        //    objOracleCommand.CommandType = CommandType.StoredProcedure;



        //    if (objSalaryDTO.UnitId != "")
        //    {
        //        objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
        //    }
        //    else
        //    {

        //        objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
        //    }

        //    if (objSalaryDTO.SectionId != "")
        //    {
        //        objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
        //    }
        //    else
        //    {

        //        objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
        //    }


        //    objOracleCommand.Parameters.Add("p_leave_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;







        //    objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
        //    objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
        //    objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


        //    objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;



        //    using (OracleConnection strConn = GetConnection())
        //    {
        //        try
        //        {

        //            objOracleCommand.Connection = strConn;
        //            strConn.Open();
        //            trans = strConn.BeginTransaction();
        //            objOracleCommand.ExecuteNonQuery();
        //            trans.Commit();
        //            strConn.Close();
        //            strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
        //        }

        //        catch (Exception ex)
        //        {
        //            objOracleTransaction.Rollback();
        //            throw new Exception("Error : " + ex.Message);

        //        }

        //        finally
        //        {

        //            strConn.Close();
        //        }

        //    }
        //    return strMsg;

        //}

        public string processLeaveStaffSummery(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_leave_summery_staff");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.UnitGroupId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_group_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitGroupId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_group_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("p_leave_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;







            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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

        public string saveSalaryEntryStaff(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_salary_entry_staff_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;
            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;



            if (objSalaryDTO.FoodAllowance != "")
            {
                objOracleCommand.Parameters.Add("P_FOOD_ALLOWANCE_FEE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.FoodAllowance;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_FOOD_ALLOWANCE_FEE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSalaryDTO.FoodDeductFee != "")
            {
                objOracleCommand.Parameters.Add("FOOD_DEDUCT_FEE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.FoodDeductFee;

            }
            else
            {
                objOracleCommand.Parameters.Add("FOOD_DEDUCT_FEE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }



            if (objSalaryDTO.ArrearFee != "")
            {
                objOracleCommand.Parameters.Add("p_arrear_fee", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.ArrearFee;

            }
            else
            {
                objOracleCommand.Parameters.Add("p_arrear_fee", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSalaryDTO.AdvanceFee != "")
            {
                objOracleCommand.Parameters.Add("p_advance_fee", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.AdvanceFee;

            }
            else
            {
                objOracleCommand.Parameters.Add("p_advance_fee", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSalaryDTO.WorkingDay != "")
            {
                objOracleCommand.Parameters.Add("P_WORKING_DAY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.WorkingDay;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_WORKING_DAY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.Remarks != "")
            {
                objOracleCommand.Parameters.Add("p_remarks", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Remarks;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_remarks", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string saveMiscSalaryEntryStaff(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_salary_entry_staff_misc");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;
            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;



            if (objSalaryDTO.FoodAllowance != "")
            {
                objOracleCommand.Parameters.Add("P_FOOD_ALLOWANCE_FEE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.FoodAllowance;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_FOOD_ALLOWANCE_FEE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSalaryDTO.FoodDeductFee != "")
            {
                objOracleCommand.Parameters.Add("FOOD_DEDUCT_FEE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.FoodDeductFee;

            }
            else
            {
                objOracleCommand.Parameters.Add("FOOD_DEDUCT_FEE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }



            if (objSalaryDTO.ArrearFee != "")
            {
                objOracleCommand.Parameters.Add("p_arrear_fee", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.ArrearFee;

            }
            else
            {
                objOracleCommand.Parameters.Add("p_arrear_fee", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSalaryDTO.AdvanceFee != "")
            {
                objOracleCommand.Parameters.Add("p_advance_fee", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.AdvanceFee;

            }
            else
            {
                objOracleCommand.Parameters.Add("p_advance_fee", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }




            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string processMISCSalaryHO(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_salary_process_ho_misc");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string processMonthlyLunch(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_lunch_process_ho");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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


        public string processSalaryStaffMisc(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_salary_process_staff_misc");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.CatagoryId != "")
            {
                objOracleCommand.Parameters.Add("p_catagory_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.CatagoryId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_catagory_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;
            

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
        public string processSalaryHO(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction ;
            OracleCommand objOracleCommand = new OracleCommand("pro_salary_process_ho");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

        
            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

          
            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;
            

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


        public string processSalaryHOMisc(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_salary_processy_ho_misc");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.CatagoryId != "")
            {
                objOracleCommand.Parameters.Add("p_catagory_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.CatagoryId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_catagory_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;
            

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

        public string processSalaryWorker(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction;
            OracleCommand objOracleCommand = new OracleCommand("pro_salary_process_worker");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;
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
        //public string processSalaryWorkerTest(SalaryDTO objSalaryDTO)
        //{
        //    string strMsg = "";
        //    OracleTransaction objOracleTransaction;
        //    OracleCommand objOracleCommand = new OracleCommand("pro_salary_process_worker_test");
        //    objOracleCommand.CommandType = CommandType.StoredProcedure;


        //    if (objSalaryDTO.UnitId != "")
        //    {
        //        objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
        //    }
        //    else
        //    {

        //        objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
        //    }


        //    if (objSalaryDTO.SectionId != "")
        //    {
        //        objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
        //    }
        //    else
        //    {

        //        objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
        //    }


        //    objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
        //    objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;

        //    objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
        //    objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
        //    objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


        //    objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

        //    using (OracleConnection strConn = GetConnection())
        //    {
        //        try
        //        {
        //            objOracleCommand.Connection = strConn;
        //            strConn.Open();
        //            objOracleTransaction = strConn.BeginTransaction();
        //            objOracleCommand.ExecuteNonQuery();
        //            objOracleTransaction.Commit();
        //            strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
        //        }

        //        catch (Exception ex)
        //        {
        //            trans.Rollback();
        //            throw new Exception("Error : " + ex.Message);
                   
        //        }

        //        finally
        //        {

        //            strConn.Close();
        //        }

        //    }
        //    return strMsg;

        //}

        public string processWorkingDayWorker(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction;
            OracleCommand objOracleCommand = new OracleCommand("pro_monthly_wday_calc_worker");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string processWorkingDayStaff(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction;
            OracleCommand objOracleCommand = new OracleCommand("pro_monthly_wday_calc_staff");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string halfSalaryProcess(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction;
            OracleCommand objOracleCommand = new OracleCommand("pro_half_salary_worker");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string halfSalaryProcessHO(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction;
            OracleCommand objOracleCommand = new OracleCommand("pro_half_salary_ho");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string halfSalaryProcessHOMisc(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction;
            OracleCommand objOracleCommand = new OracleCommand("pro_half_salary_ho_misc");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string halfSalaryRequisition(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction;
            OracleCommand objOracleCommand = new OracleCommand("pro_half_salary_requisition");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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

        public string processBonusWorkerTest(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction;
            OracleCommand objOracleCommand = new OracleCommand("pro_bonus_process_test");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("p_eid_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_eid_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EidTypeId;

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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

        public string BonusProcessWorker(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction;
            OracleCommand objOracleCommand = new OracleCommand("pro_bonus_process_worker");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objSalaryDTO.UnitGroupId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_group_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitGroupId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_group_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("p_eid_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_eid_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EidTypeId;

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string saveBonusWorker(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction;
            OracleCommand objOracleCommand = new OracleCommand("pro_bonus_save_worker");
            objOracleCommand.CommandType = CommandType.StoredProcedure;
            

            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;
            objOracleCommand.Parameters.Add("P_EID_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            if (objSalaryDTO.EidTypeId != "")
            {
                objOracleCommand.Parameters.Add("P_EID_TYPE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EidTypeId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_EID_TYPE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            if (objSalaryDTO.Bonus != "")
            {
                objOracleCommand.Parameters.Add("P_BONUS_AMOUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Bonus;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_BONUS_AMOUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string saveBonusHO(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction;
            OracleCommand objOracleCommand = new OracleCommand("pro_bonus_save_ho");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;




            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            objOracleCommand.Parameters.Add("P_EID_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            if (objSalaryDTO.EidTypeId != "")
            {
                objOracleCommand.Parameters.Add("P_EID_TYPE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EidTypeId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_EID_TYPE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.Bonus != "")
            {
                objOracleCommand.Parameters.Add("P_BONUS_AMOUNT_FIRST", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Bonus;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_BONUS_AMOUNT_FIRST", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SecondBonus != "")
            {
                objOracleCommand.Parameters.Add("P_BONUS_AMOUNT_SECOND", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SecondBonus;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_BONUS_AMOUNT_SECOND", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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

        public string BonusProcessStaff(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction;
            OracleCommand objOracleCommand = new OracleCommand("pro_bonus_process_staff");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objSalaryDTO.UnitGroupId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_group_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitGroupId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_group_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("p_eid_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_eid_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EidTypeId;

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string saveBonusStaff(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction;
            OracleCommand objOracleCommand = new OracleCommand("pro_bonus_add_staff");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            //if (objSalaryDTO.UnitGroupId != "")
            //{
            //    objOracleCommand.Parameters.Add("p_unit_group_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitGroupId;
            //}
            //else
            //{
            //    objOracleCommand.Parameters.Add("p_unit_group_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            //}
            //if (objSalaryDTO.UnitId != "")
            //{
            //    objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            //}
            //else
            //{

            //    objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            //}
            //if (objSalaryDTO.SectionId != "")
            //{
            //    objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            //}
            //else
            //{

            //    objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            //}


            objOracleCommand.Parameters.Add("p_eid_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_eid_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EidTypeId;

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string saveBonusAddWorker(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction;
            OracleCommand objOracleCommand = new OracleCommand("pro_bonus_add_worker");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            //if (objSalaryDTO.UnitGroupId != "")
            //{
            //    objOracleCommand.Parameters.Add("p_unit_group_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitGroupId;
            //}
            //else
            //{
            //    objOracleCommand.Parameters.Add("p_unit_group_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            //}
            //if (objSalaryDTO.UnitId != "")
            //{
            //    objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            //}
            //else
            //{
            //    objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            //}
            //if (objSalaryDTO.SectionId != "")
            //{
            //    objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            //}
            //else
            //{
            //    objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            //}


            objOracleCommand.Parameters.Add("p_eid_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_eid_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EidTypeId;

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string saveBonusAddHO(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
           
          
            OracleCommand objOracleCommand = new OracleCommand("pro_bonus_add_ho");
            objOracleCommand.CommandType = CommandType.StoredProcedure;        

            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            
            objOracleCommand.Parameters.Add("p_eid_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_eid_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EidTypeId;

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;
            
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
        public string BonusProcessHO(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction;
            OracleCommand objOracleCommand = new OracleCommand("pro_bonus_process_ho");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("p_eid_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_eid_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EidTypeId;

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string bonusSummeryStaff(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction;
            OracleCommand objOracleCommand = new OracleCommand("pro_bonus_summery_staff");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("p_eid_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_eid_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EidTypeId;

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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

        public string addBonusManual(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction;
            OracleCommand objOracleCommand = new OracleCommand("pro_bonus_process_manual");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



          

            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("p_eid_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_eid_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EidTypeId;


            if (objSalaryDTO.FromMonth != "")
            {
                objOracleCommand.Parameters.Add("p_from_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.FromMonth;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_from_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objSalaryDTO.ToMonth != "")
            {
                objOracleCommand.Parameters.Add("p_to_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.ToMonth;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_to_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string saveBonusProcessStaff(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction;
            OracleCommand objOracleCommand = new OracleCommand("pro_bonus_save_staff");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;

            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("p_eid_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_eid_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EidTypeId;


            if (objSalaryDTO.Bonus != "")
            {
                objOracleCommand.Parameters.Add("P_BONUS_AMOUNT_FIRST", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Bonus;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_BONUS_AMOUNT_FIRST", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objSalaryDTO.SecondBonus != "")
            {
                objOracleCommand.Parameters.Add("P_BONUS_AMOUNT_SECOND", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SecondBonus;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_BONUS_AMOUNT_SECOND", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string saveBonusProcessManual(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction;
            OracleCommand objOracleCommand = new OracleCommand("pro_bonus_save_manual");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;

            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("p_eid_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_eid_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EidTypeId;


            if (objSalaryDTO.Bonus != "")
            {
                objOracleCommand.Parameters.Add("P_BONUS_AMOUNT_FIRST", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Bonus;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_BONUS_AMOUNT_FIRST", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objSalaryDTO.SecondBonus != "")
            {
                objOracleCommand.Parameters.Add("P_BONUS_AMOUNT_SECOND", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SecondBonus;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_BONUS_AMOUNT_SECOND", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objSalaryDTO.FromMonth != "")
            {
                objOracleCommand.Parameters.Add("p_FROM_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.FromMonth;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_FROM_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            if (objSalaryDTO.ToMonth != "")
            {
                objOracleCommand.Parameters.Add("p_to_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.ToMonth;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_to_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string saveStaffSalary(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_salary_process_staff_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objSalaryDTO.EmployeeId != "")
            {
                objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

          


            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objSalaryDTO.TaxFee != "")
            {
                objOracleCommand.Parameters.Add("p_tax_fee", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.TaxFee;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_tax_fee", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;

            if (objSalaryDTO.WorkingDay != "")
            {
                objOracleCommand.Parameters.Add("p_working_day", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.WorkingDay;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_working_day", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objSalaryDTO.AllowenceAmount != "")
            {
                objOracleCommand.Parameters.Add("p_allowance_amount", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.AllowenceAmount;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_allowance_amount", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            if (objSalaryDTO.AdvanceFee != "")
            {
                objOracleCommand.Parameters.Add("p_advnace_fee", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.AdvanceFee;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_advnace_fee", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.ArrearFee != "")
            {
                objOracleCommand.Parameters.Add("p_arrear_fee", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.ArrearFee;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_arrear_fee", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }




            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;
            

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
        public DataTable searchSalaryInfoStaff(SalaryDTO objSalaryDTO)
        {

           

           
            DataTable dt = new DataTable();
            string strYes = "";
            string sql = "";
            sql = "SELECT 'Y' from monthly_salary where salary_year = '" + objSalaryDTO.Year + "' and salary_month = '" + objSalaryDTO.Month + "' "+
            " and unit_id = '" + objSalaryDTO .UnitId+ "' and section_id = '"+objSalaryDTO.SectionId+"'";




            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {
                     strYes = "Y";
                }



            }

            if (strYes == "Y")
            {
                string sql1 = "SELECT " +

                       " rownum sl, " +
                       "EMPLOYEE_ID, " +
                       "card_no, " +
                       "EMPLOYEE_NAME, " +
                       "DESIGNATION_NAME, " +

                       "WORKING_DAY, " +
                       "ALLOWANCE_AMOUNT, " +
                       "TAX_FEE, " +
                       "ADVANCE_FEE, " +
                       "ARREAR_FEE, " +
                       "OVER_TIME_AMOUNT, " +
                       "UNIT_ID, " +
                       "UNIT_NAME, " +
                       "SECTION_ID, " +
                       "SECTION_NAME, " +
                       "CATAGORY_ID, " +
                       "CATAGORY_NAME, " +
                        "first_salary " +

                       "from VEW_SEARCH_SALARY_STAFF where unit_id = '" + objSalaryDTO.UnitId + "'  and salary_year = '" + objSalaryDTO.Year + "'" +
                       "and salary_month = '" + objSalaryDTO.Month + "' ";

                if (objSalaryDTO.SectionId.Length > 0)
                {

                    sql1 = sql1 + "and section_id = '" + objSalaryDTO.SectionId + "'";
                }

                if (objSalaryDTO.CatagoryId.Length > 0)
                {

                    sql1 = sql1 + "and catagory_id = '" + objSalaryDTO.CatagoryId + "'";
                }
                //if (objSalaryDTO.Year.Length > 0)
                //{

                //    sql = sql + "and year = '" + objSalaryDTO.Year + "'";
                //}
                //if (objSalaryDTO.Month.Length > 0)
                //{

                //    sql = sql + "and month = '" + objSalaryDTO.Month + "' ";
                //}

                sql = sql + " order by sl ";

                OracleCommand objCommand1 = new OracleCommand(sql1);
                OracleDataAdapter objDataAdapter1 = new OracleDataAdapter(objCommand1);
                using (OracleConnection strConn = GetConnection())
                {
                    try
                    {
                        objCommand1.Connection = strConn;
                        strConn.Open();
                        objDataAdapter1.Fill(dt);
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


            }

            else
            {

                string sql2 = "SELECT " +

                       " rownum sl, " +
                       "EMPLOYEE_ID, " +
                       "card_no, " +
                       "EMPLOYEE_NAME, " +
                       "DESIGNATION_NAME, " +

                       "'0' WORKING_DAY, " +
                       "'0' ALLOWANCE_AMOUNT, " +
                       "'0' TAX_FEE, " +
                       "'0' ADVANCE_FEE, " +
                       "'0' ARREAR_FEE, " +
                       "'0' OVER_TIME_AMOUNT, " +
                       "UNIT_ID, " +
                       "UNIT_NAME, " +
                       "SECTION_ID, " +
                       "SECTION_NAME, " +
                       "CATAGORY_ID, " +
                       "CATAGORY_NAME, " +
                        "first_salary " +

                       "from VEW_SEARCH_SALARY_STAFF_BASIC where unit_id = '" + objSalaryDTO.UnitId + "' ";

                if (objSalaryDTO.SectionId.Length > 0)
                {

                    sql2 = sql2 + "and section_id = '" + objSalaryDTO.SectionId + "'";
                }

                if (objSalaryDTO.CatagoryId.Length > 0)
                {

                    sql2 = sql2 + "and catagory_id = '" + objSalaryDTO.CatagoryId + "'";
                }
                //if (objSalaryDTO.Year.Length > 0)
                //{

                //    sql2 = sql2 + "and year = '" + objSalaryDTO.Year + "'";
                //}
                //if (objSalaryDTO.Month.Length > 0)
                //{

                //    sql2 = sql2 + "and month = '" + objSalaryDTO.Month + "' ";
                //}


                sql2 = sql2 + " order by sl ";

                OracleCommand objCommand2 = new OracleCommand(sql2);
                OracleDataAdapter objDataAdapter2 = new OracleDataAdapter(objCommand2);
                using (OracleConnection strConn = GetConnection())
                {
                    try
                    {
                        objCommand2.Connection = strConn;
                        strConn.Open();
                        objDataAdapter2.Fill(dt);
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



            }


            return dt;

        }
        public DataTable searchSalaryInfoWorker(SalaryDTO objSalaryDTO)
        {




            DataTable dt = new DataTable();
            string strYes = "";
            string sql = "";
            sql = "SELECT 'Y' from monthly_salary where salary_year = '" + objSalaryDTO.Year + "' and salary_month = '" + objSalaryDTO.Month + "' and unit_id = '" + objSalaryDTO.UnitId + "' " +
                "and section_id = '" + objSalaryDTO.SectionId + "'";




            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {
                    strYes = "Y";
                }



            }

            if (strYes == "Y")
            {
                string sql1 = "SELECT " +

                       " rownum sl, " +
                       "EMPLOYEE_ID, " +
                       "card_no, " +
                       "EMPLOYEE_NAME, " +
                       "DESIGNATION_NAME, " +

                       "WORKING_DAY, " +
                       "TOTAL_OT, " +
                       "ARREAR_FEE, " +
                       "advance_Fee, " +
                       "attendence_fee, " +
                       "ALLOWANCE_AMOUNT, " +
                       "TAX_FEE, " +


                       "OVER_TIME_AMOUNT, " +
                       "UNIT_ID, " +
                       "UNIT_NAME, " +
                       "SECTION_ID, " +
                       "SECTION_NAME, " +
                       "CATAGORY_ID, " +
                       "CATAGORY_NAME, " +
                        "first_salary " +

                       "from vew_search_salary_worker where salary_year = '" + objSalaryDTO.Year + "' and  unit_id = '" + objSalaryDTO.UnitId + "'   " +
                       "and salary_month = '" + objSalaryDTO.Month + "' ";

                if (objSalaryDTO.SectionId.Length > 0)
                {

                    sql1 = sql1 + "and section_id = '" + objSalaryDTO.SectionId + "'";
                }

                if (objSalaryDTO.CatagoryId.Length > 0)
                {

                    sql1 = sql1 + "and catagory_id = '" + objSalaryDTO.CatagoryId + "'";
                }


                sql1 = sql1 + "  order by sl ";

                OracleCommand objCommand1 = new OracleCommand(sql1);
                OracleDataAdapter objDataAdapter1 = new OracleDataAdapter(objCommand1);
                using (OracleConnection strConn = GetConnection())
                {
                    try
                    {
                        objCommand1.Connection = strConn;
                        strConn.Open();
                        objDataAdapter1.Fill(dt);
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


            }

            else
            {

                string sql2 = "SELECT " +

                       " rownum sl, " +
                       "EMPLOYEE_ID, " +
                       "card_no, " +
                       "EMPLOYEE_NAME, " +
                       "DESIGNATION_NAME, " +

                       "WORKING_DAY, " +
                       "TOTAL_OT, " +
                       "ARREAR_FEE, " +
                       "advance_Fee, " +
                       "attendence_fee, " +
                       "ALLOWANCE_AMOUNT, " +
                       "TAX_FEE, " +
                       "OVER_TIME_AMOUNT, " +
                       "UNIT_ID, " +
                       "UNIT_NAME, " +
                       "SECTION_ID, " +
                       "SECTION_NAME, " +
                       "CATAGORY_ID, " +
                       "CATAGORY_NAME, " +
                        "first_salary " +


                       "from VEW_SEARCH_SALARY_WORKER_BASIC where unit_id = '" + objSalaryDTO.UnitId + "'  ";

                if (objSalaryDTO.SectionId.Length > 0)
                {

                    sql2 = sql2 + "and section_id = '" + objSalaryDTO.SectionId + "'";
                }


                sql2 = sql2 + "  order by sl, card_no ";

                OracleCommand objCommand2 = new OracleCommand(sql2);
                OracleDataAdapter objDataAdapter2 = new OracleDataAdapter(objCommand2);
                using (OracleConnection strConn = GetConnection())
                {
                    try
                    {
                        objCommand2.Connection = strConn;
                        strConn.Open();
                        objDataAdapter2.Fill(dt);
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



            }


            return dt;

        }
        public DataTable searchSalaryInfoStaffMisc(SalaryDTO objSalaryDTO)
        {




            DataTable dt = new DataTable();
            string strYes = "";
            string sql = "";
            sql = "SELECT 'Y' from monthly_salary where salary_year = '" + objSalaryDTO.Year + "' and salary_month = '" + objSalaryDTO.Month + "' " +
                "and unit_id = '" + objSalaryDTO.UnitId + "' ";



            if (objSalaryDTO.SectionId.Length > 0)
            {

                sql = sql + "and section_id = '" + objSalaryDTO.SectionId + "'";
            }

            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {
                    strYes = "Y";
                }



            }

            if (strYes == "Y")
            {
                string sql1 = "SELECT " +

                       " rownum sl, " +
                       "EMPLOYEE_ID, " +
                       "card_no, " +
                       "EMPLOYEE_NAME, " +
                       "DESIGNATION_NAME, " +

                       "WORKING_DAY, " +
                       "TAX_FEE, " +
                       "ADVANCE_FEE, " +
                       "ARREAR_FEE, " +
                       "OVER_TIME_AMOUNT, " +
                       "UNIT_ID, " +
                       "UNIT_NAME, " +
                       "SECTION_ID, " +
                       "SECTION_NAME, " +
                       "CATAGORY_ID, " +
                       "CATAGORY_NAME, " +
                        "first_salary " +

                       "from VEW_SEARCH_SALARY_HO_MISC where unit_id = '" + objSalaryDTO.UnitId + "' and year = '" + objSalaryDTO.Year + "' and month = '" + objSalaryDTO.Month + "' ";

                if (objSalaryDTO.SectionId.Length > 0)
                {

                    sql1 = sql1 + "and section_id = '" + objSalaryDTO.SectionId + "'";
                }

                if (objSalaryDTO.CatagoryId.Length > 0)
                {

                    sql1 = sql1 + "and catagory_id = '" + objSalaryDTO.CatagoryId + "'";
                }
                //if (objSalaryDTO.Year.Length > 0)
                //{

                //    sql1 = sql1 + "and year = '" + objSalaryDTO.Year + "'";
                //}
                //if (objSalaryDTO.Month.Length > 0)
                //{

                //    sql1 = sql1 + "and month = '" + objSalaryDTO.Month + "'";
                //}

                sql = sql + " order by sl ";

                OracleCommand objCommand1 = new OracleCommand(sql1);
                OracleDataAdapter objDataAdapter1 = new OracleDataAdapter(objCommand1);
                using (OracleConnection strConn = GetConnection())
                {
                    try
                    {
                        objCommand1.Connection = strConn;
                        strConn.Open();
                        objDataAdapter1.Fill(dt);
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


            }

            else
            {

                string sql2 = "SELECT " +

                       " rownum sl, " +
                       "EMPLOYEE_ID, " +
                       "card_no, " +
                       "EMPLOYEE_NAME, " +
                       "DESIGNATION_NAME, " +

                       "WORKING_DAY, " +
                       "TAX_FEE, " +
                       "ADVANCE_FEE, " +
                       "ARREAR_FEE, " +
                       "OVER_TIME_AMOUNT, " +
                       "UNIT_ID, " +
                       "UNIT_NAME, " +
                       "SECTION_ID, " +
                       "SECTION_NAME, " +
                       "CATAGORY_ID, " +
                       "CATAGORY_NAME, " +
                       "first_salary " +
                       "from VEW_SEARCH_SALARY_HO_MIS_BASIC where unit_id = '" + objSalaryDTO.UnitId + "'  ";

                if (objSalaryDTO.SectionId.Length > 0)
                {

                    sql2 = sql2 + "and section_id = '" + objSalaryDTO.SectionId + "'";
                }


                sql2 = sql2 + " order by sl ";

                OracleCommand objCommand2 = new OracleCommand(sql2);
                OracleDataAdapter objDataAdapter2 = new OracleDataAdapter(objCommand2);
                using (OracleConnection strConn = GetConnection())
                {
                    try
                    {
                        objCommand2.Connection = strConn;
                        strConn.Open();
                        objDataAdapter2.Fill(dt);
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



            }


            return dt;

        }
        public DataTable searchSalaryHOMisc(SalaryDTO objSalaryDTO)
        {




            DataTable dt = new DataTable();
            string strYes = "";
            string sql = "";
            sql = "SELECT 'Y' from monthly_salary where salary_year = '" + objSalaryDTO.Year + "' and salary_month = '" + objSalaryDTO.Month + "' " +
                "and unit_id = '" + objSalaryDTO.UnitId + "' ";



            if (objSalaryDTO.SectionId.Length > 0)
            {

                sql = sql + "and section_id = '" + objSalaryDTO.SectionId + "'";
            }

            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {
                    strYes = "Y";
                }



            }

            if (strYes == "Y")
            {
                string sql1 = "SELECT " +

                       " rownum sl, " +
                       "EMPLOYEE_ID, " +
                       "card_no, " +
                       "EMPLOYEE_NAME, " +
                       "DESIGNATION_NAME, " +

                       "WORKING_DAY, " +
                       "TAX_FEE, " +
                       "ADVANCE_FEE, " +
                       "ARREAR_FEE, " +
                       "OVER_TIME_AMOUNT, " +
                       "UNIT_ID, " +
                       "UNIT_NAME, " +
                       "SECTION_ID, " +
                       "SECTION_NAME, " +
                       "CATAGORY_ID, " +
                       "CATAGORY_NAME, " +
                        "first_salary " +

                       "from VEW_SEARCH_SALARY_HO_MISC where unit_id = '" + objSalaryDTO.UnitId + "' and salary_year = '" + objSalaryDTO.Year + "' and salary_month = '" + objSalaryDTO.Month + "' ";

                if (objSalaryDTO.SectionId.Length > 0)
                {

                    sql1 = sql1 + "and section_id = '" + objSalaryDTO.SectionId + "'";
                }

                if (objSalaryDTO.CatagoryId.Length > 0)
                {

                    sql1 = sql1 + "and catagory_id = '" + objSalaryDTO.CatagoryId + "'";
                }
                //if (objSalaryDTO.Year.Length > 0)
                //{

                //    sql1 = sql1 + "and year = '" + objSalaryDTO.Year + "'";
                //}
                //if (objSalaryDTO.Month.Length > 0)
                //{

                //    sql1 = sql1 + "and month = '" + objSalaryDTO.Month + "'";
                //}

                sql = sql + " order by sl ";

                OracleCommand objCommand1 = new OracleCommand(sql1);
                OracleDataAdapter objDataAdapter1 = new OracleDataAdapter(objCommand1);
                using (OracleConnection strConn = GetConnection())
                {
                    try
                    {
                        objCommand1.Connection = strConn;
                        strConn.Open();
                        objDataAdapter1.Fill(dt);
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


            }

            else
            {

                string sql2 = "SELECT " +

                       " rownum sl, " +
                       "EMPLOYEE_ID, " +
                       "card_no, " +
                       "EMPLOYEE_NAME, " +
                       "DESIGNATION_NAME, " +

                       "WORKING_DAY, " +
                       "TAX_FEE, " +
                       "ADVANCE_FEE, " +
                       "ARREAR_FEE, " +
                       "OVER_TIME_AMOUNT, " +
                       "UNIT_ID, " +
                       "UNIT_NAME, " +
                       "SECTION_ID, " +
                       "SECTION_NAME, " +
                       "CATAGORY_ID, " +
                       "CATAGORY_NAME, " +
                       "first_salary " +
                       "from VEW_SEARCH_SALARY_HO_MIS_BASIC where unit_id = '" + objSalaryDTO.UnitId + "'  ";

                if (objSalaryDTO.SectionId.Length > 0)
                {

                    sql2 = sql2 + "and section_id = '" + objSalaryDTO.SectionId + "'";
                }


                sql2 = sql2 + " order by sl ";

                OracleCommand objCommand2 = new OracleCommand(sql2);
                OracleDataAdapter objDataAdapter2 = new OracleDataAdapter(objCommand2);
                using (OracleConnection strConn = GetConnection())
                {
                    try
                    {
                        objCommand2.Connection = strConn;
                        strConn.Open();
                        objDataAdapter2.Fill(dt);
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



            }


            return dt;

        }
        public DataTable searchSalaryRecordHO(SalaryDTO objSalaryDTO)
        {
            DataTable dt = new DataTable();

            string sql = "SELECT " +

                   " rownum sl, " +
                   "EMPLOYEE_ID, " +
                   "card_no, " +
                   "EMPLOYEE_NAME, " +
                   "DESIGNATION_NAME, " +

                   "WORKING_DAY, " +
                   "TAX_FEE, " +
                   "ADVANCE_FEE, " +
                   "ARREAR_FEE, " +
                   "OVER_TIME_AMOUNT, " +
                   "UNIT_ID, " +
                   "UNIT_NAME, " +
                   "SECTION_ID, " +
                   "SECTION_NAME, " +
                   "CATAGORY_ID, " +
                   "CATAGORY_NAME, " +
                   "first_salary, " +
                   "total_ot, " +
                   "ATTENDENCE_FEE " +

                   "from VEW_SEARCH_SALARY_HO_BASIC where head_office_id = '" + objSalaryDTO.HeadOfficeId + "' AND branch_office_id = '" + objSalaryDTO.BranchOfficeId + "' ";



            if (objSalaryDTO.UnitId.Length > 0)
            {

                sql = sql + "and unit_id = '" + objSalaryDTO.UnitId + "'";
            }

            if (objSalaryDTO.SectionId.Length > 0)
            {

                sql = sql + "and section_id = '" + objSalaryDTO.SectionId + "'";
            }


            sql = sql + " order by sl ";

            OracleCommand objCommand1 = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter1 = new OracleDataAdapter(objCommand1);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand1.Connection = strConn;
                    strConn.Open();
                    objDataAdapter1.Fill(dt);
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

        public DataTable searchSalaryRecordWorker(SalaryDTO objSalaryDTO)
        {
            DataTable dt = new DataTable();

            string sql = "SELECT " +

                   " rownum sl, " +
                   "EMPLOYEE_ID, " +
                   "card_no, " +
                   "EMPLOYEE_NAME, " +
                   "DESIGNATION_NAME, " +

                   "WORKING_DAY, " +
                   "TAX_FEE, " +
                   "ADVANCE_FEE, " +
                   "ARREAR_FEE, " +
                   "OVER_TIME_AMOUNT, " +
                   "UNIT_ID, " +
                   "UNIT_NAME, " +
                   "SECTION_ID, " +
                   "SECTION_NAME, " +
                   "CATAGORY_ID, " +
                   "CATAGORY_NAME, " +
                   "first_salary, " +
                   "total_ot, " +
                   "ATTENDENCE_FEE " +

                   "from VEW_SEARCH_SALARY_WORKER_BASIC where head_office_id = '" + objSalaryDTO.HeadOfficeId + "' AND branch_office_id = '" + objSalaryDTO.BranchOfficeId + "' ";



            if (objSalaryDTO.UnitId.Length > 0)
            {

                sql = sql + "and unit_id = '" + objSalaryDTO.UnitId + "'";
            }

            if (objSalaryDTO.SectionId.Length > 0)
            {

                sql = sql + "and section_id = '" + objSalaryDTO.SectionId + "'";
            }


            sql = sql + " order by sl ";

            OracleCommand objCommand1 = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter1 = new OracleDataAdapter(objCommand1);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand1.Connection = strConn;
                    strConn.Open();
                    objDataAdapter1.Fill(dt);
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

        public DataTable searchSalaryRecordStaff(SalaryDTO objSalaryDTO)
        {
            DataTable dt = new DataTable();

            string sql = "SELECT " +

                   " rownum sl, " +
                   "EMPLOYEE_ID, " +
                   "card_no, " +
                   "EMPLOYEE_NAME, " +
                   "DESIGNATION_NAME, " +

                   "WORKING_DAY, " +
                   "TAX_FEE, " +
                   "ADVANCE_FEE, " +
                   "ARREAR_FEE, " +
                   "OVER_TIME_AMOUNT, " +
                   "UNIT_ID, " +
                   "UNIT_NAME, " +
                   "SECTION_ID, " +
                   "SECTION_NAME, " +
                   "CATAGORY_ID, " +
                   "CATAGORY_NAME, " +
                   "first_salary, " +
                   "total_ot, " +
                   "ATTENDENCE_FEE " +

                   "from VEW_SEARCH_SALARY_STAFF_BASIC where head_office_id = '" + objSalaryDTO.HeadOfficeId + "' AND branch_office_id = '" + objSalaryDTO.BranchOfficeId + "' ";



            if (objSalaryDTO.UnitId.Length > 0)
            {

                sql = sql + "and unit_id = '" + objSalaryDTO.UnitId + "'";
            }

            if (objSalaryDTO.SectionId.Length > 0)
            {

                sql = sql + "and section_id = '" + objSalaryDTO.SectionId + "'";
            }


            sql = sql + " order by sl ";

            OracleCommand objCommand1 = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter1 = new OracleDataAdapter(objCommand1);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand1.Connection = strConn;
                    strConn.Open();
                    objDataAdapter1.Fill(dt);
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

        
        public DataTable searchSalaryInfoHO(SalaryDTO objSalaryDTO)
        {




            DataTable dt = new DataTable();
            string strYes = "";
            string sql = "";
            sql = "SELECT 'Y' from monthly_salary where salary_year = '" + objSalaryDTO.Year + "' and salary_month = '" + objSalaryDTO.Month + "' and unit_id = '" + objSalaryDTO.UnitId + "' ";

            if (objSalaryDTO.SectionId.Length > 0)
            {

                sql = sql + "and section_id = '" + objSalaryDTO.SectionId + "'";
            }


            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {
                    strYes = "Y";
                }



            }

            if (strYes == "Y")
            {
                string sql1 = "SELECT " +

                       " rownum sl, " +
                       "EMPLOYEE_ID, " +
                       "card_no, " +
                       "EMPLOYEE_NAME, " +
                       "DESIGNATION_NAME, " +

                       "WORKING_DAY, " +
                       "TAX_FEE, " +
                       "ADVANCE_FEE, " +
                       "ARREAR_FEE, " +
                       "OVER_TIME_AMOUNT, " +
                       "UNIT_ID, " +
                       "UNIT_NAME, " +
                       "SECTION_ID, " +
                       "SECTION_NAME, " +
                       "CATAGORY_ID, " +
                       "CATAGORY_NAME, " +
                        "first_salary " +

                       "from vew_search_salary_ho where unit_id = '" + objSalaryDTO.UnitId + "' AND salary_year = '" + objSalaryDTO.Year + "'  and salary_month = '" + objSalaryDTO.Month + "' ";

                if (objSalaryDTO.SectionId.Length > 0)
                {

                    sql1 = sql1 + "and section_id = '" + objSalaryDTO.SectionId + "'";
                }

              
                //if (objSalaryDTO.Year.Length > 0)
                //{

                //    sql1 = sql1 + "and salary_year = '" + objSalaryDTO.Year + "'";
                //}
                //if (objSalaryDTO.Month.Length > 0)
                //{

                //    sql1 = sql1 + "and salary_month = '" + objSalaryDTO.Month + "'";
                //}

                sql1 = sql1 + " order by sl ";

                OracleCommand objCommand1 = new OracleCommand(sql1);
                OracleDataAdapter objDataAdapter1 = new OracleDataAdapter(objCommand1);
                using (OracleConnection strConn = GetConnection())
                {
                    try
                    {
                        objCommand1.Connection = strConn;
                        strConn.Open();
                        objDataAdapter1.Fill(dt);
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


            }

            else
            {

                string sql2 = "SELECT " +

                       " rownum sl, " +
                       "EMPLOYEE_ID, " +
                       "card_no, " +
                       "EMPLOYEE_NAME, " +
                       "DESIGNATION_NAME, " +

                       "WORKING_DAY, " +
                       "TAX_FEE, " +
                       "ADVANCE_FEE, " +
                       "ARREAR_FEE, " +
                       "OVER_TIME_AMOUNT, " +
                       "UNIT_ID, " +
                       "UNIT_NAME, " +
                       "SECTION_ID, " +
                       "SECTION_NAME, " +
                       "CATAGORY_ID, " +
                       "CATAGORY_NAME, " +
                       "first_salary " +
                       "from vew_search_salary_ho_basic where unit_id = '" + objSalaryDTO.UnitId + "'  ";

                if (objSalaryDTO.SectionId.Length > 0)
                {

                    sql2 = sql2 + "and section_id = '" + objSalaryDTO.SectionId + "'";
                }


                sql2 = sql2 + "and status = 'E' and occurence_type_id <> '4' order by sl ";

                OracleCommand objCommand2 = new OracleCommand(sql2);
                OracleDataAdapter objDataAdapter2 = new OracleDataAdapter(objCommand2);
                using (OracleConnection strConn = GetConnection())
                {
                    try
                    {
                        objCommand2.Connection = strConn;
                        strConn.Open();
                        objDataAdapter2.Fill(dt);
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



            }


            return dt;

        }

        public DataTable searchSalaryInfoHOMisc(SalaryDTO objSalaryDTO)
        {




            DataTable dt = new DataTable();
            string strYes = "";
            string sql = "";
            sql = "SELECT 'Y' from monthly_salary where salary_year = '" + objSalaryDTO.Year + "' and salary_month = '" + objSalaryDTO.Month + "' ";




            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {
                    strYes = "Y";
                }



            }

            if (strYes == "Y")
            {
                string sql1 = "SELECT " +

                       " rownum sl, " +
                       "EMPLOYEE_ID, " +
                       "card_no, " +
                       "EMPLOYEE_NAME, " +
                       "DESIGNATION_NAME, " +

                       "WORKING_DAY, " +
                       "TAX_FEE, " +
                       "ADVANCE_FEE, " +
                       "ARREAR_FEE, " +
                       "OVER_TIME_AMOUNT, " +
                       "UNIT_ID, " +
                       "UNIT_NAME, " +
                       "SECTION_ID, " +
                       "SECTION_NAME, " +
                       "CATAGORY_ID, " +
                       "CATAGORY_NAME, " +
                        "first_salary " +

                       "from vew_salary_monthly_ho_misc where unit_id = '" + objSalaryDTO.UnitId + "' ";

                if (objSalaryDTO.SectionId.Length > 0)
                {

                    sql = sql + "and section_id = '" + objSalaryDTO.SectionId + "'";
                }

                if (objSalaryDTO.CatagoryId.Length > 0)
                {

                    sql = sql + "and catagory_id = '" + objSalaryDTO.CatagoryId + "'";
                }
                if (objSalaryDTO.Year.Length > 0)
                {

                    sql = sql + "and year = '" + objSalaryDTO.Year + "'";
                }
                if (objSalaryDTO.Month.Length > 0)
                {

                    sql = sql + "and month = '" + objSalaryDTO.Month + "'";
                }

                sql = sql + "and status = 'E' and occurence_type_id <> '4' order by sl ";

                OracleCommand objCommand1 = new OracleCommand(sql1);
                OracleDataAdapter objDataAdapter1 = new OracleDataAdapter(objCommand1);
                using (OracleConnection strConn = GetConnection())
                {
                    try
                    {
                        objCommand1.Connection = strConn;
                        strConn.Open();
                        objDataAdapter1.Fill(dt);
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


            }

            else
            {

                string sql2 = "SELECT " +

                       " rownum sl, " +
                       "EMPLOYEE_ID, " +
                       "card_no, " +
                       "EMPLOYEE_NAME, " +
                       "DESIGNATION_NAME, " +

                       "WORKING_DAY, " +
                       "TAX_FEE, " +
                       "ADVANCE_FEE, " +
                       "ARREAR_FEE, " +
                       "OVER_TIME_AMOUNT, " +
                       "UNIT_ID, " +
                       "UNIT_NAME, " +
                       "SECTION_ID, " +
                       "SECTION_NAME, " +
                       "CATAGORY_ID, " +
                       "CATAGORY_NAME, " +
                       "first_salary " +
                       "from vew_salary_monthly_ho_misc where unit_id = '" + objSalaryDTO.UnitId + "'  ";

                if (objSalaryDTO.SectionId.Length > 0)
                {

                    sql2 = sql2 + "and section_id = '" + objSalaryDTO.SectionId + "'";
                }


                sql2 = sql2 + "and status = 'E' and occurence_type_id <> '4' order by sl ";

                OracleCommand objCommand2 = new OracleCommand(sql2);
                OracleDataAdapter objDataAdapter2 = new OracleDataAdapter(objCommand2);
                using (OracleConnection strConn = GetConnection())
                {
                    try
                    {
                        objCommand2.Connection = strConn;
                        strConn.Open();
                        objDataAdapter2.Fill(dt);
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



            }


            return dt;

        }


        public string saveAdvanceAmount(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction;
            OracleCommand objOracleCommand = new OracleCommand("pro_advance_info_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


          
            objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;

            objOracleCommand.Parameters.Add("P_ADVANCE_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("P_ADVANCE_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;

            if (objSalaryDTO.UnitId != " ")
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;

            }
            else
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            
           



            if (objSalaryDTO.AdvanceFee != "")
            {
                objOracleCommand.Parameters.Add("p_advance_fee", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.AdvanceFee;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_advance_fee", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.AdvanceDeductFee != "")
            {
                objOracleCommand.Parameters.Add("p_advance_deduct_fee", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.AdvanceDeductFee;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_advance_deduct_fee", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objSalaryDTO.DeductDate.Length > 6)
            {
                objOracleCommand.Parameters.Add("p_deduct_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.DeductDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_deduct_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.RecivedDate != "")
            {
                objOracleCommand.Parameters.Add("P_RECEIVE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.RecivedDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_RECEIVE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.DeductYn != "")
            {
                objOracleCommand.Parameters.Add("p_deduct_yn", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.DeductYn;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_deduct_yn", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


           


            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;
            

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

        public string processMonthlyResignSalary(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction;
            OracleCommand objOracleCommand = new OracleCommand("pro_salary_process_resign");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objSalaryDTO.UnitId != " ")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;

            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != " ")
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }



            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;


            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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

        public string ProcessMonthlyResignSalaryStaff(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction;
            OracleCommand objOracleCommand = new OracleCommand("pro_salary_process_resgn_staff");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objSalaryDTO.UnitId != " ")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != " ")
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }



            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;


            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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

        public string processMonthlySalaryTemp(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction;
            OracleCommand objOracleCommand = new OracleCommand("pro_salary_process_temp");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objSalaryDTO.UnitId != " ")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;

            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != " ")
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }



            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;


            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string processMonthlyResignOT(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction;
            OracleCommand objOracleCommand = new OracleCommand("pro_ot_process_resign");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objSalaryDTO.UnitId != " ")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;

            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != " ")
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }



            objOracleCommand.Parameters.Add("p_ot_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_ot_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;


            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string saveTaxInfo(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction;
            OracleCommand objOracleCommand = new OracleCommand("pro_tax_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;
            objOracleCommand.Parameters.Add("P_TAX_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("P_TAX_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;


            if (objSalaryDTO.UnitId != " ")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;

            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value =  null;
            }

            if (objSalaryDTO.SectionId != " ")
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSalaryDTO.TotalTaxFee != " ")
            {
                objOracleCommand.Parameters.Add("P_TOTAL_TAX_FEE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.TotalTaxFee;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_TOTAL_TAX_FEE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.TaxDeductFee != " ")
            {
                objOracleCommand.Parameters.Add("P_TAX_DEDUCT_FEE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.TaxDeductFee;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_TAX_DEDUCT_FEE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objSalaryDTO.DeductDate.Length > 6)
            {
                objOracleCommand.Parameters.Add("p_deduct_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.DeductDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_deduct_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.DeductYn != " ")
            {
                objOracleCommand.Parameters.Add("p_deduct_yn", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.DeductYn;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_deduct_yn", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


         

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string saveWorkerTransfer(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction;
            OracleCommand objOracleCommand = new OracleCommand("pro_worker_trans_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;
            objOracleCommand.Parameters.Add("p_transfer_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_transfer_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;


            if (objSalaryDTO.UnitIdFrom != " ")
            {
                objOracleCommand.Parameters.Add("p_unit_id_from", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitIdFrom;

            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id_from", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionIdFrom != " ")
            {

                objOracleCommand.Parameters.Add("p_section_id_from", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionIdFrom;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_section_id_from", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objSalaryDTO.UnitIdTo != " ")
            {
                objOracleCommand.Parameters.Add("p_unit_id_to", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitIdTo;

            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id_to", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionIdTo != " ")
            {

                objOracleCommand.Parameters.Add("p_section_id_to", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionIdTo;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_section_id_to", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objSalaryDTO.EffectiveDate.Length > 0 )
            {

                objOracleCommand.Parameters.Add("p_effective_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EffectiveDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_effective_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }




            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string saveYearlyWorkerPromotion(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction;
            OracleCommand objOracleCommand = new OracleCommand("pro_yearly_worker_promt_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;

            if (objSalaryDTO.DesginationId != "")
            {
                objOracleCommand.Parameters.Add("P_DESIGNATION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.DesginationId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_DESIGNATION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objSalaryDTO.GradeId != " ")
            {
                objOracleCommand.Parameters.Add("P_GRADE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.GradeId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_GRADE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            objOracleCommand.Parameters.Add("p_promotion_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
          


            if (objSalaryDTO.UnitIdFrom != " ")
            {
                objOracleCommand.Parameters.Add("p_unit_id_from", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitIdFrom;

            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id_from", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionIdFrom != " ")
            {

                objOracleCommand.Parameters.Add("p_section_id_from", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionIdFrom;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_section_id_from", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objSalaryDTO.UnitIdTo != " ")
            {
                objOracleCommand.Parameters.Add("p_unit_id_to", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitIdTo;

            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id_to", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionIdTo != " ")
            {

                objOracleCommand.Parameters.Add("p_section_id_to", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionIdTo;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_section_id_to", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objSalaryDTO.EffectiveDate.Length > 0)
            {

                objOracleCommand.Parameters.Add("p_effective_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EffectiveDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_effective_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }




            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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

        //public string SavePromotionDetail(SalaryDTO objSalaryDTO)
        public string AddPromotionInfo(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction;
            OracleCommand objOracleCommand = new OracleCommand("SP_PROMOTION_QUEUE_SAVE");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;
            objOracleCommand.Parameters.Add("p_occurence_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.OccurrenceTypeId;

            if (objSalaryDTO.UnitIdFrom != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id_from", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitIdFrom;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_id_from", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.UnitIdTo != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id_to", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitIdTo;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_id_to", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionIdFrom != "")
            {
                objOracleCommand.Parameters.Add("p_section_id_from", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionIdFrom;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_section_id_from", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionIdTo != "")
            {
                objOracleCommand.Parameters.Add("p_section_id_to", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionIdTo;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_section_id_to", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.DesignationIdFrom != "")
            {
                objOracleCommand.Parameters.Add("P_DESIGNATION_ID_FROM", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.DesignationIdFrom;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_DESIGNATION_ID_FROM", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objSalaryDTO.DesignationIdTo != "")
            {
                objOracleCommand.Parameters.Add("P_DESIGNATION_ID_TO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.DesignationIdTo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_DESIGNATION_ID_TO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.GradeIdFrom != "")
            {
                objOracleCommand.Parameters.Add("P_GRADE_ID_FROM", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.GradeIdFrom;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_GRADE_ID_FROM", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.GradeIdTo != "")
            {
                objOracleCommand.Parameters.Add("P_GRADE_ID_TO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.GradeIdTo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_GRADE_ID_TO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.GrossSalaryFrom != " ")
            {
                objOracleCommand.Parameters.Add("p_gross_salary_from", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.GrossSalaryFrom;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_gross_salary_from", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objSalaryDTO.GrossSalaryTo != "")
            {
                objOracleCommand.Parameters.Add("p_gross_salary_to", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.GrossSalaryTo;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_gross_salary_to", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.FirstSalaryFrom != "")
            {
                objOracleCommand.Parameters.Add("p_first_salary_from", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.FirstSalaryFrom;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_first_salary_from", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objSalaryDTO.FirstSalaryTo != "")
            {
                objOracleCommand.Parameters.Add("p_first_salary_to", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.FirstSalaryTo;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_first_salary_to", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            objOracleCommand.Parameters.Add("p_promotion_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;

            if (objSalaryDTO.Month != "")
            {
                objOracleCommand.Parameters.Add("p_promotion_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_promotion_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.EffectiveDate.Length > 0)
            {
                objOracleCommand.Parameters.Add("p_effective_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EffectiveDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_effective_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            objOracleCommand.Parameters.Add("p_employee_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeTypeId;

            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("p_create_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;

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

        public string AddGradeChangeInfo(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction;
            OracleCommand objOracleCommand = new OracleCommand("SP_GRADE_CHANGE_SAVE");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;
            objOracleCommand.Parameters.Add("p_occurence_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.OccurrenceTypeId;

            if (objSalaryDTO.UnitIdFrom != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id_from", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitIdFrom;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_id_from", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.UnitIdTo != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id_to", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitIdTo;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_id_to", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionIdFrom != "")
            {
                objOracleCommand.Parameters.Add("p_section_id_from", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionIdFrom;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_section_id_from", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionIdTo != "")
            {
                objOracleCommand.Parameters.Add("p_section_id_to", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionIdTo;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_section_id_to", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.DesignationIdFrom != "")
            {
                objOracleCommand.Parameters.Add("P_DESIGNATION_ID_FROM", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.DesignationIdFrom;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_DESIGNATION_ID_FROM", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objSalaryDTO.DesignationIdTo != "")
            {
                objOracleCommand.Parameters.Add("P_DESIGNATION_ID_TO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.DesignationIdTo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_DESIGNATION_ID_TO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.GradeIdFrom != "")
            {
                objOracleCommand.Parameters.Add("P_GRADE_ID_FROM", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.GradeIdFrom;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_GRADE_ID_FROM", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.GradeIdTo != "")
            {
                objOracleCommand.Parameters.Add("P_GRADE_ID_TO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.GradeIdTo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_GRADE_ID_TO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.GrossSalaryFrom != " ")
            {
                objOracleCommand.Parameters.Add("p_gross_salary_from", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.GrossSalaryFrom;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_gross_salary_from", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objSalaryDTO.GrossSalaryTo != "")
            {
                objOracleCommand.Parameters.Add("p_gross_salary_to", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.GrossSalaryTo;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_gross_salary_to", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.FirstSalaryFrom != "")
            {
                objOracleCommand.Parameters.Add("p_first_salary_from", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.FirstSalaryFrom;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_first_salary_from", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objSalaryDTO.FirstSalaryTo != "")
            {
                objOracleCommand.Parameters.Add("p_first_salary_to", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.FirstSalaryTo;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_first_salary_to", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            objOracleCommand.Parameters.Add("p_promotion_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;

            if (objSalaryDTO.Month != "")
            {
                objOracleCommand.Parameters.Add("p_promotion_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_promotion_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.EffectiveDate.Length > 0)
            {
                objOracleCommand.Parameters.Add("p_effective_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EffectiveDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_effective_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            objOracleCommand.Parameters.Add("p_employee_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeTypeId;

            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("p_create_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;

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
        public string saveTax(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction;
            OracleCommand objOracleCommand = new OracleCommand("pro_tax_fee_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;
            objOracleCommand.Parameters.Add("P_SALARY_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("P_SALARY_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;


            if (objSalaryDTO.UnitId != " ")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;

            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != " ")
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSalaryDTO.TaxFee != " ")
            {
                objOracleCommand.Parameters.Add("P_TAX_FEE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.TaxFee;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_TAX_FEE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

           



            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string saveAdvance(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction;
            OracleCommand objOracleCommand = new OracleCommand("pro_advance_basic_info_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;
            objOracleCommand.Parameters.Add("P_ADVANCE_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("P_ADVANCE_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;


            if (objSalaryDTO.UnitId != " ")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;

            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != " ")
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSalaryDTO.AdvanceFee != " ")
            {
                objOracleCommand.Parameters.Add("P_ADVANCE_FEE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.AdvanceFee;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_ADVANCE_FEE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.AdvanceDeductFee != " ")
            {
                objOracleCommand.Parameters.Add("P_ADVANCE_DEDUCT_FEE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.AdvanceDeductFee;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_ADVANCE_DEDUCT_FEE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

           

            if (objSalaryDTO.DeductYn != " ")
            {
                objOracleCommand.Parameters.Add("P_DEDUCT_YN", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.DeductYn;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_DEDUCT_YN", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objSalaryDTO.LedgerPageNo != " ")
            {
                objOracleCommand.Parameters.Add("P_LEDGER_PAGE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.LedgerPageNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_LEDGER_PAGE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string deleteAdvanceEntry(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction;
            OracleCommand objOracleCommand = new OracleCommand("pro_delete_advance");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;
            objOracleCommand.Parameters.Add("P_ADVANCE_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("P_ADVANCE_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;


          

            if (objSalaryDTO.AdvanceFee != " ")
            {
                objOracleCommand.Parameters.Add("P_ADVANCE_FEE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.AdvanceFee;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_ADVANCE_FEE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.AdvanceDeductFee != " ")
            {
                objOracleCommand.Parameters.Add("P_ADVANCE_DEDUCT_FEE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.AdvanceDeductFee;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_ADVANCE_DEDUCT_FEE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }




            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string saveIncrementHoldInfo(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction;
            OracleCommand objOracleCommand = new OracleCommand("pro_increment_hold_info_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;
            objOracleCommand.Parameters.Add("P_INCREMENT_HOLD_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
          

            if (objSalaryDTO.UnitId != "")
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;

            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value =  null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;

            }
            else
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            
            if (objSalaryDTO.HoldYn != "")
            {
                objOracleCommand.Parameters.Add("p_hold_yn", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HoldYn;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_hold_yn", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }




            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public DataTable getStaffIdForSalary(SalaryDTO objSalaryDTO)
        {
            
            DataTable dt = new DataTable();

            string strYes = "";
            string sql = "";

            sql = "SELECT 'Y' from monthly_salary where salary_year = '" + objSalaryDTO.Year + "' and salary_month = '" + objSalaryDTO.Month + "' " +
                  "and unit_id = '" + objSalaryDTO.UnitId + "' and section_id = '" + objSalaryDTO.SectionId + "'";




            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {
                    strYes = "Y";
                }



            }


            if (strYes == "Y")
            {
                string sql2 = "";
                sql2 = 
                      "SELECT " +
                      "EMPLOYEE_ID, " +
                      "EMPLOYEE_NAME " +
                      "FROM vew_get_id_month_salary " +
                      " where salary_year = '" + objSalaryDTO.Year + "' and salary_month = '" + objSalaryDTO.Month + "' " +
                      " and unit_id = '" + objSalaryDTO.UnitId + "' ";

                if (objSalaryDTO.SectionId.Length > 0)
                {

                    sql2 = sql2 + "and section_id = '" + objSalaryDTO.SectionId + "' ";
                }

                sql2 = sql2 + " order by EMPLOYEE_ID";

                OracleCommand objCommand2 = new OracleCommand(sql2);
                OracleDataAdapter objDataAdapter2 = new OracleDataAdapter(objCommand2);
                using (OracleConnection strConn = GetConnection())
                {
                    try
                    {
                        objCommand2.Connection = strConn;
                        strConn.Open();
                        objDataAdapter2.Fill(dt);

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
            else
            {

                string sql3 = "";
                sql3 = "SELECT "+
                      "EMPLOYEE_ID, " +
                      "EMPLOYEE_NAME " +
                      "FROM vew_get_id_job_detail " +
                      " where unit_id = '" + objSalaryDTO.UnitId + "' ";



                if (objSalaryDTO.SectionId.Length > 0)
                {

                    sql3 = sql3 + "and section_id = '" + objSalaryDTO.SectionId + "' ";
                }

                sql3 = sql3 + " order by EMPLOYEE_ID";

                OracleCommand objCommand3 = new OracleCommand(sql3);
                OracleDataAdapter objDataAdapter3 = new OracleDataAdapter(objCommand3);
                using (OracleConnection strConn = GetConnection())
                {
                    try
                    {
                        objCommand3.Connection = strConn;
                        strConn.Open();
                        objDataAdapter3.Fill(dt);

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


            return dt;

        }


        public SalaryDTO showStaffSalayInfo(string strUnitId, string strSectionId, string strCatagoryId, string strYear, string strMonth, string strHeadOfficeId, string strBranchOfficeId, string strUpdateBy)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            string strYes = "";
            string sql = "";

            sql = "SELECT 'Y' from monthly_salary where salary_year = '" + strYear + "' and salary_month = '" + strMonth + "' " +
            " and unit_id = '" + strUnitId + "' and section_id = '" + strSectionId + "'";




            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {
                    strYes = "Y";
                }



            }




            if (strYes == "Y")
            {
                string sql2 = "";
                sql2 = "SELECT " +
                      "to_char(nvl(card_no, '0')), " +
                      "to_char(nvl(designation_name, 'N/A')), " +
                      "to_char(nvl(working_day, '0')), " +
                      "to_char(nvl(allowance_amount, '0')), " +
                      "to_char(nvl(advance_fee, '0')), " +
                      "to_char(nvl(arrear_fee, '0')) " +

                      "from VEW_SEARCH_SALARY_STAFF " +

                       " where salary_year = '" + strYear + "' and salary_month = '" + strMonth + "' " +
                      " and unit_id = '" + strUnitId + "' and section_id = '" + strSectionId + "'";



                if (strCatagoryId.Length > 0)
                {

                    sql2 = sql2 + "and catagory_id = '" + strCatagoryId + "' ";
                }


                OracleCommand objCommand2 = new OracleCommand(sql2);
                OracleDataReader objDataReader2;

                using (OracleConnection strConn = GetConnection())
                {

                    objCommand2.Connection = strConn;
                    strConn.Open();
                    objDataReader2 = objCommand2.ExecuteReader();
                    try
                    {
                        while (objDataReader2.Read())
                        {

                            objSalaryDTO.CardNo = objDataReader2.GetString(0);
                            objSalaryDTO.DesginationName = objDataReader2.GetString(1);
                            objSalaryDTO.WorkingDay = objDataReader2.GetString(2);
                            objSalaryDTO.AllowenceAmount = objDataReader2.GetString(3);
                            objSalaryDTO.AdvanceFee = objDataReader2.GetString(4);
                            objSalaryDTO.ArrearFee = objDataReader2.GetString(5);

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
            
            
            
            else

            {
                string sql3 = "";
                sql3 = "SELECT " +
                      "to_char(nvl(card_no, '0')), " +
                      "to_char(nvl(designation_name, 'N/A')), " +
                      "to_char(nvl(working_day, '0')), " +
                      "to_char(nvl(allowance_amount, '0')), " +
                      "to_char(nvl(advance_fee, '0')), " +
                      "to_char(nvl(arrear_fee, '0')) " +

                      "from VEW_SEARCH_SALARY_STAFF " +

                       " where salary_year = '" + strYear + "' and salary_month = ('" + strMonth + "') - 1 " +
                      " and unit_id = '" + strUnitId + "' and section_id = '" + strSectionId + "'";



                if (strCatagoryId.Length > 0)
                {

                    sql3 = sql3 + "and catagory_id = '" + strCatagoryId + "' ";
                }


                OracleCommand objCommand3 = new OracleCommand(sql3);
                OracleDataReader objDataReader3;

                using (OracleConnection strConn = GetConnection())
                {

                    objCommand3.Connection = strConn;
                    strConn.Open();
                    objDataReader3 = objCommand3.ExecuteReader();
                    try
                    {
                        while (objDataReader3.Read())
                        {

                            objSalaryDTO.CardNo = objDataReader3.GetString(0);
                            objSalaryDTO.DesginationName = objDataReader3.GetString(1);
                            objSalaryDTO.WorkingDay = objDataReader3.GetString(2);
                            objSalaryDTO.AllowenceAmount = objDataReader3.GetString(3);
                            objSalaryDTO.AdvanceFee = objDataReader3.GetString(4);
                            objSalaryDTO.ArrearFee = objDataReader3.GetString(5);

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

            return objSalaryDTO;
        }



        public string processSalaryOption(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_salary_process_select");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SalaryProcessTypeId != "")
            {
                objOracleCommand.Parameters.Add("p_salary_process_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SalaryProcessTypeId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_salary_process_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            if (objSalaryDTO.Month != "")
            {
                objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string addMonthlySalary(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_monthly_salary_add");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SalaryProcessTypeId != "")
            {
                objOracleCommand.Parameters.Add("p_salary_process_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SalaryProcessTypeId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_salary_process_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            if (objSalaryDTO.Month != "")
            {
                objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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

        public DataTable getSalaryBasicInfo(SalaryDTO objSalaryDTO)
        {




            DataTable dt = new DataTable();
          
            string sql = "";
          

                        sql = "SELECT " +

                               "SL, "+
                               "HEAD_OFFICE_ID, "+
                               "HEAD_OFFICE_NAME, "+
                               "BRANCH_OFFICE_ID, "+
                               "BRANCH_OFFICE_NAME, "+
                               "HEAD_OFFICE_ADDRESS, "+
                               "EMPLOYEE_ID, "+
                               "CARD_NO, "+
                               "EMPLOYEE_NAME, "+
                               "EMPLOYEE_NAME_BANGLA, "+
                               "SALARY_YEAR, "+
                               "SALARY_MONTH, "+
                               "SECTION_ID, "+
                               "SECTION_NAME, "+
                               "SECTION_NAME_BANGLA, "+
                               "UNIT_ID, "+
                               "UNIT_NAME, "+
                               "UNIT_NAME_BANGLA, "+
                               "CATAGORY_ID, "+
                               "CATAGORY_NAME, "+
                               "BASIC_SALARY, "+
                               "HOUSE_RENT_FEE, "+
                               "MEDICAL_FEE, "+
                               "CONVENCE_FEE, "+
                               "ADVANCE_FEE, "+
                               "ADVANCE_DEDUCT_FEE, "+
                               "ALLOWANCE_AMOUNT, "+
                               "ARREAR_FEE, "+
                               "TAX_FEE, "+
                               "DEDUCT_DATE, "+
                               "DEDUCT_YN, "+
                               "FINALIZED_YN, "+
                               "UPDATE_DATE, "+
                               "UPDATE_BY, "+
                               "OVER_TIME_HOUR, " +
                               "designation_name, "+
                               "working_day "+

                       "from vew_search_salary_basic_info where 1 = 1  ";

                if (objSalaryDTO.SectionId.Length > 0)
                {

                    sql = sql + "and section_id = '" + objSalaryDTO.SectionId + "'";
                }

               if (objSalaryDTO.UnitId.Length > 0)
                {

                    sql = sql + "and unit_id = '" + objSalaryDTO.UnitId + "'";
                }
                if (objSalaryDTO.Year.Length > 0)
                {

                    sql = sql + "and salary_year = '" + objSalaryDTO.Year + "'";
                }
                if (objSalaryDTO.Month.Length > 0)
                {

                    sql = sql + "and salary_month = '" + objSalaryDTO.Month + "'";
                }

                sql = sql + " order by sl ";

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

        public SalaryDTO getEmployeeInformation(string strCardNo, string strHeadOfficeId, string strUnitId, string strSectionId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
           
            string sql = "";

            sql = "SELECT " +
                  "CARD_NO, " +
                  "EMPLOYEE_ID, " +
                  "EMPLOYEE_NAME, " +
                  "DESIGNATION_NAME "+


                  "FROM vew_advance_info WHERE CARD_NO = '" + strCardNo + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND UNIT_ID = '" + strUnitId + "' " +
                  "AND SECTION_ID = '" + strSectionId + "'";



            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {
                    objSalaryDTO.CardNo = objDataReader.GetString(0);
                    objSalaryDTO.EmployeeId = objDataReader.GetString(1);
                    objSalaryDTO.EmployeeName = objDataReader.GetString(2);
                    objSalaryDTO.DesginationName = objDataReader.GetString(3);

                }



            }


            return objSalaryDTO;
        }
        public SalaryDTO searchWorkerIncrementEntryAnnual(string strEmployeeId, string strIncrementYear, string strHeadOfficeId, string strBranchOffieId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();

            string sql = "";

            sql = "SELECT " +
                  "TO_CHAR (NVL (increment_amount, '0')) "+
                  "FROM vew_search_worker_annual_inc WHERE EMPLOYEE_ID = '" + strEmployeeId + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOffieId + "' " +
                  "AND INCREMENT_YEAR = '" + strIncrementYear + "'";
            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {
                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {
                    objSalaryDTO.IncrementAmount = objDataReader.GetString(0);
                }
            }
            return objSalaryDTO;
        }
        //GetIncrementAmount(employeeId, incrementYear, incrementMonth, batchNo, strHeadOfficeId, strBranchOffieId);
        public SalaryDTO GetIncrementAmount(string employeeId, string incrementYear, string incrementMonth, string batchNo, string strHeadOfficeId, string strBranchOffieId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();

            string sql = "";

            sql = "SELECT " +
                  "TO_CHAR (NVL (increment_amount, '0')), " +
                  "TO_CHAR (NVL (increment_amount_2nd_term, '0')), " +
                  " finalized_yn " +
                  "FROM vew_search_worker_annual_inc WHERE EMPLOYEE_ID = '" + employeeId + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOffieId + "' " +
                  " AND INCREMENT_YEAR = '" + incrementYear + "' AND INCREMENT_MONTH = '" + incrementMonth + "' AND BATCH_NO = '" + batchNo + "' ";
            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {
                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {
                    objSalaryDTO.IncrementAmount = objDataReader.GetString(0);
                    objSalaryDTO.IncrementAmount2ndTerm = objDataReader.GetString(1);
                    objSalaryDTO.Finalized_Yn = objDataReader.GetString(2);
                }
            }
            return objSalaryDTO;
        }

        //SP_GET_PROP_GRS_AT_YRLY_INCR_W
        public SalaryDTO GetPropGrossAtYearlyIncrement(string employeeId, string incrementYear, string incrementMonth, string strHeadOfficeId, string strBranchOffieId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();

            try {
                string sql = "";
                sql = " select " +
                      " TO_CHAR(nvl(t.gross_salary, 0) + ROUND(NVL(HOUSE_RENT_5_PERCENT, 0) + NVL(BASIC_SALARY_5_PERCENT, 0))) prop_gross_salary " +
                      " from " +
                      " INCREMENT_PROPOSAL_WORKER t " +
                      " where " +
                      " t.employee_id = '" + employeeId + "' " +
                      " and t.increment_year = '" + incrementYear + "' " +
                      " and t.increment_month = '" + incrementMonth + "' " +
                      " and t.head_office_id = '" + strHeadOfficeId + "' " +
                      " and t.branch_office_id = '" + strBranchOffieId + "' ";

                OracleCommand objCommand = new OracleCommand(sql);
                OracleDataReader objDataReader;

                using (OracleConnection strConn = GetConnection())
                {
                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataReader = objCommand.ExecuteReader();
                    if (objDataReader.Read())
                    {
                        objSalaryDTO.ProposedGrossSalary = objDataReader.GetString(0);
                    }
                }
            }
            catch(Exception e)
            {
            }
                
            return objSalaryDTO;
        }

        public SalaryDTO searchWorkerIncrementEntryNonProposal(string strEmployeeId, string strIncrementYear, string strHeadOfficeId, string strBranchOffieId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();

            string sql = "";

            sql = "SELECT " +
                  "TO_CHAR (NVL (MANUAL_INCREMENT_AMOUNT, '0')) " +



                  "FROM VEW_WORKER_INC_NON_PROPOSAL WHERE EMPLOYEE_ID = '" + strEmployeeId + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOffieId + "' " +
                  "AND INCREMENT_YEAR = '" + strIncrementYear + "'";



            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {
                    objSalaryDTO.IncrementAmount = objDataReader.GetString(0);


                }



            }


            return objSalaryDTO;
        }
        //public SalaryDTO searchStaffIncrementEntryNonProposal(string strEmployeeId, string strIncrementYear, string strHeadOfficeId, string strBranchOffieId)
        //{

        //    SalaryDTO objSalaryDTO = new SalaryDTO();

        //    string sql = "";

        //    sql = "SELECT " +
        //          "TO_CHAR (NVL (MANUAL_INCREMENT_AMOUNT, '0')) " +



        //          "FROM VEW_STAFF_INC_NON_PROPOSAL WHERE EMPLOYEE_ID = '" + strEmployeeId + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOffieId + "' " +
        //          "AND INCREMENT_YEAR = '" + strIncrementYear + "'";



        //    OracleCommand objCommand = new OracleCommand(sql);
        //    OracleDataReader objDataReader;

        //    using (OracleConnection strConn = GetConnection())
        //    {

        //        objCommand.Connection = strConn;
        //        strConn.Open();
        //        objDataReader = objCommand.ExecuteReader();
        //        if (objDataReader.Read())
        //        {
        //            objSalaryDTO.IncrementAmount = objDataReader.GetString(0);


        //        }



        //    }


        //    return objSalaryDTO;
        //}


        public SalaryDTO searchStaffIncrementEntryNonProposal(string strEmployeeId, string strIncrementYear, string strHeadOfficeId, string strBranchOffieId)
        {
            SalaryDTO objSalaryDTO = new SalaryDTO();
            string sql = "";

            sql = "SELECT " +
            "TO_CHAR (NVL (MANUAL_INCREMENT_AMOUNT, '0')) " +
            "FROM VEW_STAFF_INC_NON_PROPOSAL WHERE EMPLOYEE_ID = '" + strEmployeeId + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOffieId + "' " +
            "AND INCREMENT_YEAR = '" + strIncrementYear + "'";
            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {
                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {
                    objSalaryDTO.IncrementAmount = objDataReader.GetString(0);
                }
            }
            return objSalaryDTO;
        }

        public SalaryDTO searchTaxFee(string strEmployeeId,string strSalaryYear, string strSalaryMonth, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();

            string sql = "";

            sql = "SELECT " +
                  "to_char(nvl(tax_fee, '0')) " +


                  "FROM vew_search_tax_entry WHERE employee_id = '" + strEmployeeId + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "'  " +
                  " AND salary_year = '" + strSalaryYear + "' AND SALARY_MONTH = '" + strSalaryMonth + "' ";




            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {
                    objSalaryDTO.TaxFee = Convert.ToString(objDataReader.GetString(0));


                }



            }


            return objSalaryDTO;
        }
        public SalaryDTO searchAdvanceFee(string strEmployeeId, string strSalaryYear, string strSalaryMonth, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();

            string sql = "";

            sql = "SELECT " +
                  "to_char(nvl(ADVANCE_FEE, '0'))ADVANCE_FEE, " +
                  "to_char(nvl(ADVANCE_DEDUCT_FEE, '0'))ADVANCE_DEDUCT_FEE, " +
                  "to_char(nvl(LEDGER_PAGE_NO, '0'))LEDGER_PAGE_NO " +

                  "FROM vew_search_advance_entry WHERE employee_id = '" + strEmployeeId + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "'  " +
                  " AND ADVANCE_YEAR = '" + strSalaryYear + "' AND ADVANCE_MONTH = '" + strSalaryMonth + "' ";




            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {
                    objSalaryDTO.AdvanceFee = objDataReader.GetString(0);
                    objSalaryDTO.AdvanceDeductFee = objDataReader.GetString(1);
                    objSalaryDTO.LedgerPageNo = objDataReader.GetString(2);
                }



            }


            return objSalaryDTO;
        }
        public SalaryDTO searchTaxInfo(string strEmployeeId, string strSalaryFromYear, string strSalaryToYear, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();


            string sql = "";

            sql = "SELECT " +
                  "TO_CHAR(NVL(TAX_MONTH, '0')), " +
                  "TO_CHAR(NVL(TOTAL_TAX_FEE,'0')), " +
                  "TO_CHAR(NVL(TAX_DEDUCT_FEE,'0')), " +
                  "NVL (TO_CHAR (DEDUCT_DATE, 'dd/mm/yyyy'), ''), " +
                  "TO_CHAR(NVL(DEDUCT_YN,'N')) " +


                  "FROM VEW_SEARCH_TAX_INFO WHERE employee_id = '" + strEmployeeId + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "' " +
                  "AND TAX_FROM_YEAR = '" + strSalaryFromYear + "' AND TAX_TO_YEAR = '" + strSalaryToYear + "' ";



            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {
                    objSalaryDTO.Month = objDataReader.GetString(0);
                    objSalaryDTO.TaxFee = objDataReader.GetString(1);
                    objSalaryDTO.TaxDeductFee = objDataReader.GetString(2);
                    objSalaryDTO.DeductDate = objDataReader.GetString(3);
                    objSalaryDTO.DeductYn = objDataReader.GetString(4);
                }



            }


            return objSalaryDTO;
        }

        public DataTable loadSalaryEntry(SalaryDTO objSalaryDTO)
        {



            DataTable dt = new DataTable();

            string sql = "";
            sql = "SELECT " +

                "EMPLOYEE_ID, " +
                "EMPLOYEE_NAME, " +
                "CARD_NO, " +
                "DESIGNATION_NAME, " +
                "UNIT_ID, " +
                "UNIT_NAME, " +
                "SECTION_ID, " +
                "SECTION_NAME, " +
                "CATAGORY_ID, " +
                "CATAGORY_NAME " +


                "from VEW_EMPLOYEE_TEST where head_office_id = '" + objSalaryDTO.HeadOfficeId + "'";

            if (objSalaryDTO.UnitId.Length > 0 )
            {

                sql = sql + "and unit_id = '" + objSalaryDTO.UnitId + "'";
            }


            if (objSalaryDTO.SectionId.Length > 0 )
            {

                sql = sql + "and section_id = '" + objSalaryDTO.SectionId + "'";
            }

            if (objSalaryDTO.CatagoryId.Length > 0)
            {

                sql = sql + "and catagory_id = '" + objSalaryDTO.CatagoryId + "'";
            }

            //if (objSalaryDTO.Year.Length > 0)
            //{

            //    sql = sql + "and salary_year = '" + objSalaryDTO.Year + "'";
            //}

            //if (objSalaryDTO.Month.Length > 0)
            //{

            //    sql = sql + "and salary_month = '" + objSalaryDTO.Month + "'";
            //}


            sql = sql + " order by to_number(card_no) ";

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
        public string saveSalaryBasicInfoHO(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_salary_basic_info_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


           
             objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;
           
            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


          
            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;
            objOracleCommand.Parameters.Add("p_working_day", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.WorkingDay;


           
            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string addWorkerPromotion(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_worker_promotion_basic");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;

            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            objOracleCommand.Parameters.Add("p_promotion_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("P_PROMOTION_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;



            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string addWorkerYearlyIncrementNonProposal(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("PRO_NON_PROPOSAL_WORKER_ADD");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;

            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            objOracleCommand.Parameters.Add("P_INCREMENT_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
           



            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string addStaffYearlyIncrementNonProposal(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_NON_PROPOSAL_STAFF_ADD");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;

            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            objOracleCommand.Parameters.Add("P_INCREMENT_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;




            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string employeeTransferAdd(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("PRO_EMP_TRANSFER_ADD");
            objOracleCommand.CommandType = CommandType.StoredProcedure;
                                 
            objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;

            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
                                 

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("P_SECTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SECTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("P_TRANSFER_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("P_TRANSFER_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;



            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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

        public string TransferVirtually(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            
            OracleCommand objOracleCommand = new OracleCommand("SP_TRANSFER_VIRTUALLY");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;

              
            //if (objSalaryDTO.HomeOfficeId != "")
            //{
            //    objOracleCommand.Parameters.Add("p_home_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HomeOfficeId;
            //}
            //else
            //{
            //    objOracleCommand.Parameters.Add("home_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            //}

            //if (objSalaryDTO.HomeUnitId != "")
            //{
            //    objOracleCommand.Parameters.Add("p_home_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HomeUnitId;
            //}
            //else
            //{
            //    objOracleCommand.Parameters.Add("p_home_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            //}

            //if (objSalaryDTO.HomeSectionId != "")
            //{
            //    objOracleCommand.Parameters.Add("p_home_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HomeSectionId;
            //}
            //else
            //{
            //    objOracleCommand.Parameters.Add("p_home_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            //}


            if (objSalaryDTO.VirtualOfficeId != "")
            {
                objOracleCommand.Parameters.Add("p_virtual_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.VirtualOfficeId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_virtual_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.VirtualUnitId != "")
            {
                objOracleCommand.Parameters.Add("p_virtual_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.VirtualUnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_virtual_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.VirtualSectionId != "")
            {
                objOracleCommand.Parameters.Add("p_virtual_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.VirtualSectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_virtual_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            objOracleCommand.Parameters.Add("p_from_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.FromDate;
            objOracleCommand.Parameters.Add("p_to_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.ToDate;

           
            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;
            
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

        //
        public string UpdateVirtualTransfer(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";

            OracleCommand objOracleCommand = new OracleCommand("SP_UPDATE_VIRTUAL_TRANSFER");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("P_transfer_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.TransferId;
                        
            if (objSalaryDTO.VirtualOfficeId != "")
            {
                objOracleCommand.Parameters.Add("p_virtual_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.VirtualOfficeId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_virtual_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.VirtualUnitId != "")
            {
                objOracleCommand.Parameters.Add("p_virtual_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.VirtualUnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_virtual_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.VirtualSectionId != "")
            {
                objOracleCommand.Parameters.Add("p_virtual_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.VirtualSectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_virtual_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            objOracleCommand.Parameters.Add("p_from_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.FromDate;
            objOracleCommand.Parameters.Add("p_to_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.ToDate;
            
            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            //objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            //objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;

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
        public string addWorkerIncrement(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_increment_worker_add");
            objOracleCommand.CommandType = CommandType.StoredProcedure;
            
            objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;

            //if (objSalaryDTO.UnitId != "")
            //{
            //    objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            //}
            //else
            //{
            //    objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            //}

            //if (objSalaryDTO.SectionId != "")
            //{
            //    objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            //}
            //else
            //{
            //    objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            //}
                        
            objOracleCommand.Parameters.Add("P_INCREMENT_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("P_INCREMENT_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;

            objOracleCommand.Parameters.Add("P_FIVE_PERCENT_YN", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.AutoIncrementYn;
            objOracleCommand.Parameters.Add("P_MONTHLY_INCREMENT_YN", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.MonthlyIncrementYn;
            


            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
    
        public string addWorkerIncrementAnnual(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_inc_worker_annual_add");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;
            objOracleCommand.Parameters.Add("P_INCREMENT_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
          

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string addWorkerSalary(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_monthly_gross_salary_add");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;
            objOracleCommand.Parameters.Add("P_SALARY_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("P_SALARY_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;

        


            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string addWorkerArrear(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_worker_arrer_add");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;
            objOracleCommand.Parameters.Add("P_ARREAR_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("P_ARREAR_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;


            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string ProcessWorkerArrear(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_arrear_process_worker");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            objOracleCommand.Parameters.Add("P_ARREAR_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("P_ARREAR_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;






            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string ProcessWorkerArrearRequisition(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_arrear_requisition_worker");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            objOracleCommand.Parameters.Add("P_ARREAR_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("P_ARREAR_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;






            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string addStaffIncrement(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_increment_staff_add");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;

            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            objOracleCommand.Parameters.Add("P_INCREMENT_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
           




            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string addStaffIncrementMonthly(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_inc_staff_add_monthly");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;

            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            objOracleCommand.Parameters.Add("P_INCREMENT_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("P_INCREMENT_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;




            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string addIncrementHO(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_increment_ho_add");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;

            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            objOracleCommand.Parameters.Add("P_INCREMENT_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;





            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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

        //
        public string IncrementHOAddUpdate(SalaryDTO objSalaryDTO)
        {

           //P_EMPLOYEE_ID varchar2,
           //P_INCREMENT_YEAR         varchar2,
           //P_HEAD_OFFICE_ID varchar2,
           //P_BRANCH_OFFICE_ID       varchar2,
           //P_GROSS_SALARY NUMBER,
           //P_FIRST_SALARY_CURRENT   NUMBER,
           //P_UPDATE_BY varchar2,


            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("sp_increment_ho_add_update");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;
            objOracleCommand.Parameters.Add("P_INCREMENT_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;

            objOracleCommand.Parameters.Add("P_GROSS_SALARY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.GrossSalary;
            objOracleCommand.Parameters.Add("P_FIRST_SALARY_CURRENT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.FirstSalaryCurrent;

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            
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

        //NEW: ADDED ON 30.12.2021
        
        public string CreateIncrementProposalHO(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            //NEW: ADDED ON 30.12.2021
            OracleCommand objOracleCommand = new OracleCommand("pro_inc_proposal_ho_add_1");
            //OLD: COMMENTED ON 30.12.2021
            //OracleCommand objOracleCommand = new OracleCommand("pro_inc_proposal_ho_add");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;

            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            
            objOracleCommand.Parameters.Add("P_INCREMENT_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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



        //OLD: 
        public string AddIncrementProposalHO(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_inc_proposal_ho_add");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;

            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            objOracleCommand.Parameters.Add("P_INCREMENT_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;





            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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




        public string addWorkerIncrementProposal(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_inc_proposal_worker_add");
            objOracleCommand.CommandType = CommandType.StoredProcedure;
                       
            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.UnitGroupId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_group_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitGroupId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_group_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("P_INCREMENT_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("P_INCREMENT_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;
            objOracleCommand.Parameters.Add("p_allow_general_incr", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.AllowGeneralIncrement;

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;
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

        public string addWorkerIncrementProposalLessOne(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_inc_proposal_worker_L_ONE");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.UnitGroupId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_group_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitGroupId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_group_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("P_INCREMENT_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("P_INCREMENT_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;
            objOracleCommand.Parameters.Add("p_allow_general_incr", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.AllowGeneralIncrement;

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;
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

        public string ApplyIndividualWorkerAutoIncr(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            //pro_inc_proposal_worker_add
            OracleCommand objOracleCommand = new OracleCommand("sp_apply_indv_worker_auto_incr");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objSalaryDTO.EmployeeId != "")
            {
                objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
                       
            objOracleCommand.Parameters.Add("P_INCREMENT_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("P_INCREMENT_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;
            objOracleCommand.Parameters.Add("p_ind_auto_incr_yn", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.IndividualAutoIncrYn;
            

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;
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

        //pro_get_worker_auto_incr_amt
        public string GetWorkerAutoIncrementAmount(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            //pro_inc_proposal_worker_add
            OracleCommand objOracleCommand = new OracleCommand("pro_get_worker_auto_incr_amt");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objSalaryDTO.EmployeeId != "")
            {
                objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            
            objOracleCommand.Parameters.Add("P_INCREMENT_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("P_INCREMENT_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;

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


        public string addWorkerIncrementProposalStaff(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_inc_proposal_staff_add");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            //objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;

            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.UnitGroupId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_group_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitGroupId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_group_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("P_INCREMENT_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("P_INCREMENT_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;
                        

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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

        public string addWorkerIncrementProposalStaffLessOne(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_inc_pro_staff_add_l_one");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            //objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;

            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.UnitGroupId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_group_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitGroupId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_group_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("P_INCREMENT_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("P_INCREMENT_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;


            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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

        public string addEmployeePromotion(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_employee_promotion_basic");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;

            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            objOracleCommand.Parameters.Add("p_promotion_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_promotion_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;


            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        
        public string deleteSalaryBasicInfoHO(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_delete_salary_basic_ho");
            objOracleCommand.CommandType = CommandType.StoredProcedure;




            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;

            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


        
            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string saveSalaryBasicInfoWorker(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_salary_basic_info_worker");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;

            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


         
            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;

            //objOracleCommand.Parameters.Add("p_working_day", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.WorkingDay;
            //objOracleCommand.Parameters.Add("p_over_time_hour", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.OverTimeHour;
           

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string deleteSalaryBasicInfoWorker(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_delete_salary_basic_worker");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;

            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }







            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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

        public string saveSalaryBasicInfoStaff(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_salary_basic_info_staff");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;

            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;
            objOracleCommand.Parameters.Add("p_working_day", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.WorkingDay;
          


            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public string deleteSalaryBasicInfoStaff(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_delete_salary_basic_staff");
            objOracleCommand.CommandType = CommandType.StoredProcedure;





            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;

            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }






            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public SalaryDTO searchMiscEntry(string strEmployeeId, string strSalaryYear, string strSalaryMonth, string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();


            string sql = "";

            sql = "SELECT " +
                  "to_char(NVL(ADVANCE_FEE, '0' )), " +
                  "to_char(NVL(ARREAR_FEE, '0')), " +
                  "to_char(NVL(FOOD_ALLOWANCE_FEE, '0')), " +
                  "to_char(NVL(FOOD_DEDUCT_FEE, '0')), " +
                  "to_char(NVL(WORKING_DAY, '-32')) " +

                  "FROM vew_search_salary_entry_ho WHERE employee_id = '" + strEmployeeId + "' AND salary_year = '" + strSalaryYear + "' AND salary_month = '" + strSalaryMonth + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "'";

            if (strUnitId.Length > 0)
            {
                sql = sql + " AND unit_id = '" + strUnitId + "'";

            }
            if (strSectionId.Length > 0)
            {
                sql = sql + " AND section_id = '" + strSectionId + "'";

            }
 


            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {
                    objSalaryDTO.AdvanceFee = objDataReader.GetString(0);
                    objSalaryDTO.ArrearFee = objDataReader.GetString(1);
                    objSalaryDTO.FoodAllowance = objDataReader.GetString(2);
                    objSalaryDTO.FoodDeductFee = objDataReader.GetString(3);
                    objSalaryDTO.WorkingDay = objDataReader.GetString(4);
                    

                }



            }
          
            return objSalaryDTO;
        }
        public SalaryDTO searchPunchingCode(string strEmployeeId,  string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();


            string sql = "";

            sql = "SELECT " +
                  "to_char(NVL(punch_code, '0' )) " +


                  "FROM VEW_BASIC_INFO WHERE employee_id = '" + strEmployeeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "'";

            if (strUnitId.Length > 0)
            {
                sql = sql + " AND unit_id = '" + strUnitId + "'";

            }
            if (strSectionId.Length > 0)
            {
                sql = sql + " AND section_id = '" + strSectionId + "'";

            }



            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {
                    objSalaryDTO.PunchingCode = objDataReader.GetString(0);
                    

                }



            }

            return objSalaryDTO;
        }
        public SalaryDTO searchWorkingDay(string strEmployeeId, string strSalaryYear, string strSalaryMonth, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();


            string sql = "";

            sql = "SELECT " +

                    "to_char(NVL(WORKING_DAY, '-32')) " +

                  "FROM VEW_SALARY_SHEET_HO WHERE employee_id = '" + strEmployeeId + "' AND salary_year = '" + strSalaryYear + "' AND salary_month = '" + strSalaryMonth + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "'";

           


            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {
                    
                    objSalaryDTO.WorkingDay = objDataReader.GetString(0);


                }



            }

            return objSalaryDTO;
        }
        public SalaryDTO searchWorkingDayMisc(string strEmployeeId, string strSalaryYear, string strSalaryMonth, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();


            string sql = "";

            sql = "SELECT " +

                    "to_char(NVL(WORKING_DAY, '-32')) " +

                  "FROM VEW_SALARY_SHEET_HO_MISC WHERE employee_id = '" + strEmployeeId + "' AND salary_year = '" + strSalaryYear + "' AND salary_month = '" + strSalaryMonth + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "'";




            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {

                    objSalaryDTO.WorkingDay = objDataReader.GetString(0);


                }



            }

            return objSalaryDTO;
        }
       
        public SalaryDTO checkHoldYn(string strEmployeeId, string strSalaryYear, string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();


            string sql = "";

            sql = "SELECT " +
                  " to_char(NVl('Y', 'N')) " +


                  "FROM VEW_SEARCH_INCREMENT_HOLD_INFO WHERE employee_id = '" + strEmployeeId + "' AND INCREMENT_HOLD_YEAR = '" + strSalaryYear + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "' and hold_yn = 'Y' ";

            if (strUnitId.Length > 0)
            {
                sql = sql + " AND unit_id = '" + strUnitId + "'";

            }
            if (strSectionId.Length > 0)
            {
                sql = sql + " AND section_id = '" + strSectionId + "'";

            }



            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {
                    objSalaryDTO.HoldYn = objDataReader.GetString(0);
                 
                  

                }



            }

            return objSalaryDTO;
        }
        public SalaryDTO searchSalaryEntryHOMISC(string strEmployeeId, string strSalaryYear, string strSalaryMonth, string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();


            string sql = "";

            sql = "SELECT " +
                  "to_char(NVL(ADVANCE_FEE, '0' )), " +
                  "to_char(NVL(ARREAR_FEE, '0')), " +
                  "to_char(NVL(FOOD_ALLOWANCE_FEE, '0')), " +
                  "to_char(NVL(FOOD_DEDUCT_FEE, '0')), " +
                   "to_char(NVL(WORKING_DAY, '-32')) " +


                  "FROM vew_search_sal_entry_ho_misc WHERE employee_id = '" + strEmployeeId + "' AND salary_year = '" + strSalaryYear + "' AND salary_month = '" + strSalaryMonth + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "'";

            if (strUnitId.Length > 0)
            {
                sql = sql + " AND unit_id = '" + strUnitId + "'";

            }
            if (strSectionId.Length > 0)
            {
                sql = sql + " AND section_id = '" + strSectionId + "'";

            }



            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {
                    objSalaryDTO.AdvanceFee = objDataReader.GetString(0);
                    objSalaryDTO.ArrearFee = objDataReader.GetString(1);
                    objSalaryDTO.FoodAllowance = objDataReader.GetString(2);
                    objSalaryDTO.FoodDeductFee = objDataReader.GetString(3);
                   
                    objSalaryDTO.WorkingDay = objDataReader.GetString(4);
                    
                }



            }

            return objSalaryDTO;
        }
        public SalaryDTO searchMiscEntryCash(string strEmployeeId, string strSalaryYear, string strSalaryMonth, string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();


            string sql = "";

            sql = "SELECT " +
                  "to_char(NVL(ADVANCE_FEE, '0' )), " +
                  "to_char(NVL(ALLOWANCE_AMOUNT,'0')), " +
                  "to_char(NVL(ARREAR_FEE, '0')) " +



                  "FROM VEW_SEARCH_MISC_ENTRY_CASH WHERE employee_id = '" + strEmployeeId + "' AND salary_year = '" + strSalaryYear + "' AND salary_month = '" + strSalaryMonth + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "'";

            if (strUnitId.Length > 0)
            {
                sql = sql + " AND unit_id = '" + strUnitId + "'";

            }
            if (strSectionId.Length > 0)
            {
                sql = sql + " AND section_id = '" + strUnitId + "'";

            }



            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {
                    objSalaryDTO.AdvanceFee = objDataReader.GetString(0);
                    objSalaryDTO.FoodAllowance = objDataReader.GetString(1);
                    objSalaryDTO.ArrearFee = objDataReader.GetString(2);


                }



            }

            return objSalaryDTO;
        }
        public SalaryDTO searchMiscEntryWorker(string strEmployeeId, string strSalaryYear, string strSalaryMonth, string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();


            string sql = "";
            
            sql = "SELECT " +
                  "to_char(NVL(ADVANCE_FEE, '0' )), " +
                  "to_char(NVL(OVER_TIME_HOUR,'0')), " +
                   "to_char(NVL(EARLY_DEPTR_HOUR,'0')), " +
                  "to_char(NVL(ARREAR_FEE, '0')), " +
                  "to_char(NVL(WORKING_DAY, '0')), " +
                  "to_char(NVL(ATTENDENCE_FEE, '0')), " +
                  "to_char(NVL(NUMBER_OF_LATE, '0')), " +
                  "to_char(NVL(NUMBER_OF_LEAVE, '0')), " +
                  "to_char(NVL(PARTIAL_DAY, '0')), " +
                  "BKASH_YN, " +
                  "to_char(NVL(remarks, '0')) " +

                  "FROM VEW_SEARCH_MISC_ENTRY_WORKER WHERE employee_id = '" + strEmployeeId + "' AND salary_year = '" + strSalaryYear + "' AND salary_month = '" + strSalaryMonth + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "'";

            if (strUnitId.Length > 0)
            {
                sql = sql + " AND unit_id = '" + strUnitId + "'";

            }
            if (strSectionId.Length > 0)
            {
                sql = sql + " AND section_id = '" + strSectionId + "'";

            }



            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {
                    objSalaryDTO.AdvanceFee = objDataReader.GetString(0);
                    objSalaryDTO.OverTimeHour = objDataReader.GetString(1);
                    objSalaryDTO.EarlyDptHour = objDataReader.GetString(2);
                    objSalaryDTO.ArrearFee = objDataReader.GetString(3);
                    objSalaryDTO.WorkingDay = objDataReader.GetString(4);
                    objSalaryDTO.Bonus = objDataReader.GetString(5);
                    objSalaryDTO.TotalLate = objDataReader.GetString(6);
                    objSalaryDTO.TotalLeave = objDataReader.GetString(7);

                    objSalaryDTO.PartialWorkingDay = objDataReader.GetString(8);
                    objSalaryDTO.BkashYn = objDataReader.GetString(9);
                    objSalaryDTO.Remarks = objDataReader.GetString(10);
                }
            }

            return objSalaryDTO;
        }
        public SalaryDTO searchResignEntryWorker(string strEmployeeId, string strSalaryYear, string strSalaryMonth, string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();


            string sql = "";

            sql = "SELECT " +
                  "to_char(NVL(ADVANCE_FEE, '0' )), " +
                  "to_char(NVL(OVER_TIME_HOUR,'0')), " +
                  "to_char(NVL(ARREAR_FEE, '0')), " +
                  "to_char(NVL(WORKING_DAY, '0')), " +
                  "to_char(NVL(ATTENDENCE_FEE, '0')) " +



                  "FROM VEW_SEARCH_MISC_ENTRY_RESIGN WHERE employee_id = '" + strEmployeeId + "' AND salary_year = '" + strSalaryYear + "' AND salary_month = '" + strSalaryMonth + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "'";

            if (strUnitId.Length > 0)
            {
                sql = sql + " AND unit_id = '" + strUnitId + "'";

            }
            if (strSectionId.Length > 0)
            {
                sql = sql + " AND section_id = '" + strSectionId + "'";

            }



            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {
                    objSalaryDTO.AdvanceFee = objDataReader.GetString(0);
                    objSalaryDTO.OverTimeHour = objDataReader.GetString(1);
                    objSalaryDTO.ArrearFee = objDataReader.GetString(2);
                    objSalaryDTO.WorkingDay = objDataReader.GetString(3);
                    objSalaryDTO.Bonus = objDataReader.GetString(4);

                }



            }

            return objSalaryDTO;
        }
        public SalaryDTO searchMonthLoanEntryWorker(string strEmployeeId, string strSalaryYear, string strSalaryMonth, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();


            string sql = "";

            sql = "SELECT " +
                  "to_char(NVL(ADVANCE_DEDUCT_FEE, '0' )) " +




                  "FROM vew_search_monthly_loan_worker WHERE employee_id = '" + strEmployeeId + "' AND advance_year = '" + strSalaryYear + "' AND advance_month = '" + strSalaryMonth + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "'";

          


            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {
                    objSalaryDTO.LoanAmount = objDataReader.GetString(0);


                }



            }

            return objSalaryDTO;
        }
        public SalaryDTO searchMonthLoanEntryResign(string strEmployeeId, string strSalaryYear, string strSalaryMonth, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();


            string sql = "";

            sql = "SELECT " +
                  "to_char(NVL(ADVANCE_DEDUCT_FEE, '0' )) " +




                  "FROM VEW_SEARCH_MONTHLY_LOAN_RESIGN WHERE employee_id = '" + strEmployeeId + "' AND advance_year = '" + strSalaryYear + "' AND advance_month = '" + strSalaryMonth + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "'";




            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {
                    objSalaryDTO.LoanAmount = objDataReader.GetString(0);


                }



            }

            return objSalaryDTO;
        }
        public SalaryDTO searchMonthLoanEntryStaff(string strEmployeeId, string strSalaryYear, string strSalaryMonth, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();


            string sql = "";

            sql = "SELECT " +
                  "to_char(NVL(ADVANCE_DEDUCT_FEE, '0' )) " +




                  "FROM vew_search_monthly_loan_staff WHERE employee_id = '" + strEmployeeId + "' AND advance_year = '" + strSalaryYear + "' AND advance_month = '" + strSalaryMonth + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "'";




            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {
                    objSalaryDTO.LoanAmount = objDataReader.GetString(0);


                }



            }

            return objSalaryDTO;
        }
        public SalaryDTO searcHalfSalaryEntryWorker(string strEmployeeId, string strSalaryYear, string strSalaryMonth, string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();


            string sql = "";

            sql = "SELECT " +
                "to_char(NVL(PAYMENT_AMOUNT, '0' )), " +
                "to_char(NVL(WORKING_DAY, '0' )), " +
                "to_char(NVL(OVER_TIME_HOUR, '0' )), " +
                "to_char(NVL(OVER_TIME_AMOUNT, '0' )) " +


                  "FROM  VEW_HALF_SHEET_WORKER WHERE employee_id = '" + strEmployeeId + "' AND salary_year = '" + strSalaryYear + "' AND salary_month = '" + strSalaryMonth + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "'";

            if (strUnitId.Length > 0)
            {
                sql = sql + " AND unit_id = '" + strUnitId + "'";

            }
            if (strSectionId.Length > 0)
            {
                sql = sql + " AND section_id = '" + strSectionId + "'";

            }



            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {
                    objSalaryDTO.AdvanceFee = objDataReader.GetString(0);
                    objSalaryDTO.WorkingDay = objDataReader.GetString(1);
                    objSalaryDTO.OverTimeHour = objDataReader.GetString(2);
                    objSalaryDTO.OverTimeAmount = objDataReader.GetString(3);

                }



            }

            return objSalaryDTO;
        }
        public SalaryDTO searcHalfSalaryEntryHO(string strEmployeeId, string strSalaryYear, string strSalaryMonth, string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();


            string sql = "";

            sql = "SELECT " +
                "to_char(NVL(PAYMENT_AMOUNT, '0' )), " +
                  "to_char(NVL(WORKING_DAY, '0' )), " +
                  "to_char(NVL(payment_amount_second, '0' )),  " +
                  "to_char(NVL(ADVANCE_FEE, '0' )),  " +
                   "to_char(NVL(SALARY_PERCENTAGE, '0' ))  " +



                  "FROM  VEW_HALF_SHEET_HO WHERE employee_id = '" + strEmployeeId + "' AND salary_year = '" + strSalaryYear + "' AND salary_month = '" + strSalaryMonth + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "'";

            if (strUnitId.Length > 0)
            {
                sql = sql + " AND unit_id = '" + strUnitId + "'";

            }
            if (strSectionId.Length > 0)
            {
                sql = sql + " AND section_id = '" + strSectionId + "'";

            }



            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {
                    objSalaryDTO.AdvanceFee = objDataReader.GetString(0);
                    objSalaryDTO.WorkingDay = objDataReader.GetString(1);
                    objSalaryDTO.SecondSalary = objDataReader.GetString(2);
                    objSalaryDTO.AdvanceFeeCash = objDataReader.GetString(3);
                    objSalaryDTO.SalaryPercentage = objDataReader.GetString(4);

                }



            }

            return objSalaryDTO;
        }
        public SalaryDTO searcHalfSalaryEntryStaff(string strEmployeeId, string strSalaryYear, string strSalaryMonth, string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();


            string sql = "";

            sql = "SELECT " +
                "to_char(NVL(PAYMENT_AMOUNT, '0' )), " +
                "to_char(NVL(payment_amount_second, '0' )), " +
                "to_char(NVL(WORKING_DAY, '0' )) " +




                  "FROM  VEW_HALF_SHEET_STAFF WHERE employee_id = '" + strEmployeeId + "' AND salary_year = '" + strSalaryYear + "' AND salary_month = '" + strSalaryMonth + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "'";

            if (strUnitId.Length > 0)
            {
                sql = sql + " AND unit_id = '" + strUnitId + "'";

            }
            if (strSectionId.Length > 0)
            {
                sql = sql + " AND section_id = '" + strSectionId + "'";

            }



            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {
                    objSalaryDTO.FirstSalary = objDataReader.GetString(0);
                    objSalaryDTO.SecondSalary = objDataReader.GetString(1);
                    objSalaryDTO.WorkingDay = objDataReader.GetString(2);


                }



            }

            return objSalaryDTO;
        }
        public SalaryDTO searchWorkerIncProposalEntry(string strEmployeeId, string strIncrementYear, string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();


            string sql = "";

            sql = "SELECT " +
                 
                  "to_char(NVL(INCREMENT_AMOUNT, '0' )) " +


                  "FROM VEW_SEARCH_INC_PROPOSAL_ENTRY WHERE employee_id = '" + strEmployeeId + "' AND increment_year = '" + strIncrementYear + "'AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "'";

            if (strUnitId.Length > 0)
            {
                sql = sql + " AND unit_id = '" + strUnitId + "'";

            }
            if (strSectionId.Length > 0)
            {
                sql = sql + " AND section_id = '" + strSectionId + "'";

            }



            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {


                   
                    objSalaryDTO.IncrementAmount = objDataReader.GetString(0);


                }



            }

            return objSalaryDTO;
        }
        public SalaryDTO searchWorkerIncrementEntry(string strEmployeeId, string strIncrementYear, string strIncrementMonth, string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();


            string sql = "";

            if (strHeadOfficeId == "331" && strBranchOfficeId == "103")
            {

                if (strUnitId == "37")
                {

                    sql = "SELECT " +
                          "to_char(NVL(manual_increment_amount, '0' )), " +
                          "to_char(NVL(INCREMENT_AMOUNT, '0' )), " +
                          "to_char(NVL(GROSS_SALARY, '0' )), " +
                          "NVL (TO_CHAR (JOINING_DATE, 'dd/mm/yyyy'), ' ') " +

                          "FROM VEW_INCREMENT_SHEET_WORKER WHERE employee_id = '" + strEmployeeId + "' AND increment_year = '" + strIncrementYear + "' AND INCREMENT_MONTH = '" + strIncrementMonth + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "' AND  unit_id in  ('37', '38', '39', '40', '41', '42', '49', '93', '130')";
                }

                if (strUnitId == "43")
                {


                    sql = "SELECT " +
                          "to_char(NVL(manual_increment_amount, '0' )), " +
                          "to_char(NVL(INCREMENT_AMOUNT, '0' )), " +
                          "to_char(NVL(GROSS_SALARY, '0' )), " +
                          "NVL (TO_CHAR (JOINING_DATE, 'dd/mm/yyyy'), ' ') " +

                          "FROM VEW_INCREMENT_SHEET_WORKER WHERE employee_id = '" + strEmployeeId + "' AND increment_year = '" + strIncrementYear + "' AND INCREMENT_MONTH = '" + strIncrementMonth + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "' AND  unit_id in  ('43', '44',  '45', '46', '47', '48','50','90','94')";


                }

                if (strUnitId == "52")
                {

                    sql = "SELECT " +
                        "to_char(NVL(manual_increment_amount, '0' )), " +
                        "to_char(NVL(INCREMENT_AMOUNT, '0' )), " +
                        "to_char(NVL(GROSS_SALARY, '0' )), " +
                        "NVL (TO_CHAR (JOINING_DATE, 'dd/mm/yyyy'), ' ') " +

                        "FROM VEW_INCREMENT_SHEET_WORKER WHERE employee_id = '" + strEmployeeId + "' AND increment_year = '" + strIncrementYear + "' AND INCREMENT_MONTH = '" + strIncrementMonth + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "' AND  unit_id in  ('52', '53', '54', '55', '56', '57', '51', '95')";
                }


                if (strUnitId == "58")
                {

                    sql = "SELECT " +
                      "to_char(NVL(manual_increment_amount, '0' )), " +
                      "to_char(NVL(INCREMENT_AMOUNT, '0' )), " +
                      "to_char(NVL(GROSS_SALARY, '0' )), " +
                      "NVL (TO_CHAR (JOINING_DATE, 'dd/mm/yyyy'), ' ') " +

                      "FROM VEW_INCREMENT_SHEET_WORKER WHERE employee_id = '" + strEmployeeId + "' AND increment_year = '" + strIncrementYear + "' AND INCREMENT_MONTH = '" + strIncrementMonth + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "' AND  unit_id in  ('58', '59')";
                }


                if (strUnitId == "102")
                {


                    sql = "SELECT " +
                      "to_char(NVL(manual_increment_amount, '0' )), " +
                      "to_char(NVL(INCREMENT_AMOUNT, '0' )), " +
                      "to_char(NVL(GROSS_SALARY, '0' )), " +
                      "NVL (TO_CHAR (JOINING_DATE, 'dd/mm/yyyy'), ' ') " +

                      "FROM VEW_INCREMENT_SHEET_WORKER WHERE employee_id = '" + strEmployeeId + "' AND increment_year = '" + strIncrementYear + "' AND INCREMENT_MONTH = '" + strIncrementMonth + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "' AND  unit_id in  ('96', '97', '98', '99', '100', '101', '102', '103', '131')";
                }

            }

            else if (strHeadOfficeId == "331" && strBranchOfficeId == "102")
            {

                if (strUnitId == "1")
                {


                    sql = "SELECT " +
                     "to_char(NVL(manual_increment_amount, '0' )), " +
                     "to_char(NVL(INCREMENT_AMOUNT, '0' )), " +
                     "to_char(NVL(GROSS_SALARY, '0' )), " +
                     "NVL (TO_CHAR (JOINING_DATE, 'dd/mm/yyyy'), ' ') " +

                     "FROM VEW_INCREMENT_SHEET_WORKER WHERE employee_id = '" + strEmployeeId + "' AND increment_year = '" + strIncrementYear + "' AND INCREMENT_MONTH = '" + strIncrementMonth + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "' AND  unit_id in ('1', '2','3', '4','5','69','70','71', '72', '74','75','76','77')";




                }

                if (strUnitId == "6")
                {
                    sql = "SELECT " +
                     "to_char(NVL(manual_increment_amount, '0' )), " +
                     "to_char(NVL(INCREMENT_AMOUNT, '0' )), " +
                     "to_char(NVL(GROSS_SALARY, '0' )), " +
                     "NVL (TO_CHAR (JOINING_DATE, 'dd/mm/yyyy'), ' ') " +

                     "FROM VEW_INCREMENT_SHEET_WORKER WHERE employee_id = '" + strEmployeeId + "' AND increment_year = '" + strIncrementYear + "' AND INCREMENT_MONTH = '" + strIncrementMonth + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "' AND  unit_id in ('6','7','8','9','10','11','78','79','80','81','82','83', '84', '85','86','87','88','89')";





                }

            }


            else if (strHeadOfficeId == "331" && strBranchOfficeId == "101")
            {

                if (strUnitId == "17")
                {

                    sql = "SELECT " +
                     "to_char(NVL(manual_increment_amount, '0' )), " +
                     "to_char(NVL(INCREMENT_AMOUNT, '0' )), " +
                     "to_char(NVL(GROSS_SALARY, '0' )), " +
                     "NVL (TO_CHAR (JOINING_DATE, 'dd/mm/yyyy'), ' ') " +

                     "FROM VEW_INCREMENT_SHEET_WORKER WHERE employee_id = '" + strEmployeeId + "' AND increment_year = '" + strIncrementYear + "' AND INCREMENT_MONTH = '" + strIncrementMonth + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "' AND  unit_id in ('17', '18', '22')";



                }

                if (strUnitId == "19")
                {
                    sql = "SELECT " +
                     "to_char(NVL(manual_increment_amount, '0' )), " +
                     "to_char(NVL(INCREMENT_AMOUNT, '0' )), " +
                     "to_char(NVL(GROSS_SALARY, '0' )), " +
                     "NVL (TO_CHAR (JOINING_DATE, 'dd/mm/yyyy'), ' ') " +

                     "FROM VEW_INCREMENT_SHEET_WORKER WHERE employee_id = '" + strEmployeeId + "' AND increment_year = '" + strIncrementYear + "' AND INCREMENT_MONTH = '" + strIncrementMonth + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "' AND  unit_id in('19', '24', '25', '23')";




                }


                if (strUnitId == "26")
                {


                    sql = "SELECT " +
                       "to_char(NVL(manual_increment_amount, '0' )), " +
                       "to_char(NVL(INCREMENT_AMOUNT, '0' )), " +
                       "to_char(NVL(GROSS_SALARY, '0' )), " +
                       "NVL (TO_CHAR (JOINING_DATE, 'dd/mm/yyyy'), ' ') " +

                       "FROM VEW_INCREMENT_SHEET_WORKER WHERE employee_id = '" + strEmployeeId + "' AND increment_year = '" + strIncrementYear + "' AND INCREMENT_MONTH = '" + strIncrementMonth + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "' AND  unit_id in('26', '27', '28')";



                }


                if (strUnitId == "12")
                {

                    sql = "SELECT " +
                      "to_char(NVL(manual_increment_amount, '0' )), " +
                      "to_char(NVL(INCREMENT_AMOUNT, '0' )), " +
                      "to_char(NVL(GROSS_SALARY, '0' )), " +
                      "NVL (TO_CHAR (JOINING_DATE, 'dd/mm/yyyy'), ' ') " +

                      "FROM VEW_INCREMENT_SHEET_WORKER WHERE employee_id = '" + strEmployeeId + "' AND increment_year = '" + strIncrementYear + "' AND INCREMENT_MONTH = '" + strIncrementMonth + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "' AND  unit_id in('12', '13')";

                    
                }

                if (strUnitId == "15")
                {


                    sql = "SELECT " +
                      "to_char(NVL(manual_increment_amount, '0' )), " +
                      "to_char(NVL(INCREMENT_AMOUNT, '0' )), " +
                      "to_char(NVL(GROSS_SALARY, '0' )), " +
                      "NVL (TO_CHAR (JOINING_DATE, 'dd/mm/yyyy'), ' ') " +

                      "FROM VEW_INCREMENT_SHEET_WORKER WHERE employee_id = '" + strEmployeeId + "' AND increment_year = '" + strIncrementYear + "' AND INCREMENT_MONTH = '" + strIncrementMonth + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "' AND  unit_id in('15', '16', '20', '21', '30', '31')";




                }

                if (strUnitId == "14")
                {
                    sql = "SELECT " +
                       "to_char(NVL(manual_increment_amount, '0' )), " +
                       "to_char(NVL(INCREMENT_AMOUNT, '0' )), " +
                       "to_char(NVL(GROSS_SALARY, '0' )), " +
                       "NVL (TO_CHAR (JOINING_DATE, 'dd/mm/yyyy'), ' ') " +

                       "FROM VEW_INCREMENT_SHEET_WORKER WHERE employee_id = '" + strEmployeeId + "' AND increment_year = '" + strIncrementYear + "' AND INCREMENT_MONTH = '" + strIncrementMonth + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "' AND  unit_id in('14', '29', '32', '33', '34', '35', '36', '60')";


                }


            }

            else
            {

                sql = "SELECT " +
       "to_char(NVL(manual_increment_amount, '0' )), " +
       "to_char(NVL(INCREMENT_AMOUNT, '0' )), " +
       "to_char(NVL(GROSS_SALARY, '0' )), " +
       "NVL (TO_CHAR (JOINING_DATE, 'dd/mm/yyyy'), ' ') " +

       "FROM VEW_INCREMENT_SHEET_WORKER WHERE employee_id = '" + strEmployeeId + "' AND increment_year = '" + strIncrementYear + "' AND INCREMENT_MONTH = '" + strIncrementMonth + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "'" + " AND unit_id in  ('113', '114', '126', '115', '117', '118', '119', '120', '121', '116', '122', '123', '124', '125') " ;

                //if (strUnitId.Length > 0)
                //{
                //    sql = sql + " AND unit_id = '" + strUnitId + "'";

                //}
                //if (strSectionId.Length > 0)
                //{
                //    sql = sql + " AND section_id = '" + strSectionId + "'";
                //}
            }
            

            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {

                 
                    objSalaryDTO.ManualIncrement = objDataReader.GetString(0);
                    objSalaryDTO.IncrementAmount = objDataReader.GetString(1);
                    objSalaryDTO.GrossSalary = objDataReader.GetString(2);
                    objSalaryDTO.JoiningDate = objDataReader.GetString(3);

                }



            }

            return objSalaryDTO;
        }
        public SalaryDTO searchWorkerArrearEntry(string strEmployeeId, string strIncrementYear, string strIncrementMonth, string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();


            string sql = "";

            sql = "SELECT " +
                  "to_char(NVL(INCREMENT_AMOUNT_MANUAL, '0' )) " +


                  "FROM vew_search_arrear_entry WHERE employee_id = '" + strEmployeeId + "' AND arrear_year = '" + strIncrementYear + "' AND arrear_month = '" + strIncrementMonth + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "'";

            if (strUnitId.Length > 0)
            {
                sql = sql + " AND unit_id = '" + strUnitId + "'";

            }
            if (strSectionId.Length > 0)
            {
                sql = sql + " AND section_id = '" + strSectionId + "'";

            }



            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {


                    objSalaryDTO.ManualIncrement = objDataReader.GetString(0);
                  

                }



            }

            return objSalaryDTO;
        }
        public SalaryDTO searchWorkerArrearSalary(string strEmployeeId, string strIncrementYear, string strIncrementMonth, string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();


            string sql = "";

            sql = "SELECT " +
                  "to_char(NVL(over_time_hour, '0' )), " +
                  "to_char(NVL(working_day, '0' )) " +

                  "FROM vew_search_worker_sal_arrear WHERE employee_id = '" + strEmployeeId + "' AND salary_year = '" + strIncrementYear + "' AND salary_month = '" + strIncrementMonth + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "'";

            if (strUnitId.Length > 0)
            {
                sql = sql + " AND unit_id = '" + strUnitId + "'";

            }
            if (strSectionId.Length > 0)
            {
                sql = sql + " AND section_id = '" + strSectionId + "'";

            }



            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {


                    objSalaryDTO.OverTimeHour = objDataReader.GetString(0);
                    objSalaryDTO.WorkingDay = objDataReader.GetString(1);

                }



            }

            return objSalaryDTO;
        }
        public SalaryDTO searchStaffIncrementEntry(string strEmployeeId, string strIncrementYear,  string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();


            string sql = "";

            sql = "SELECT " +
                  "to_char(NVL(INCREMENT_AMOUNT, '0' )), " +
                  "to_char(NVL(GROSS_SALARY, '0' )), " +
                  "NVL (TO_CHAR (JOINING_DATE, 'dd/mm/yyyy'), ' ') " +

                  "FROM VEW_INCREMENT_SHEET_STAFF WHERE employee_id = '" + strEmployeeId + "' AND increment_year = '" + strIncrementYear + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "'";

            if (strUnitId.Length > 0)
            {
                sql = sql + " AND unit_id = '" + strUnitId + "'";

            }
            if (strSectionId.Length > 0)
            {
                sql = sql + " AND section_id = '" + strSectionId + "'";

            }



            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {


                    objSalaryDTO.ManualIncrement = objDataReader.GetString(0);
                    objSalaryDTO.GrossSalary = objDataReader.GetString(1);
                    objSalaryDTO.JoiningDate = objDataReader.GetString(2);

                }
            }
            return objSalaryDTO;
        }

        //new 05.01.2018
        public SalaryDTO GetIncrementAmountStaff(string strEmployeeId, string strIncrementYear, string incrementMonth, string batchNo, string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();

            string sql = "";

            sql = "SELECT " +
                  "to_char(NVL(INCREMENT_AMOUNT, '0' )), " +
                  "to_char(NVL(GROSS_SALARY, '0' )), " +
                  "NVL (TO_CHAR (JOINING_DATE, 'dd/mm/yyyy'), ' ') " +
                  "FROM VEW_INCREMENT_SHEET_STAFF WHERE employee_id = '" + strEmployeeId + "' AND increment_year = '" + strIncrementYear + "' AND increment_month = '" + incrementMonth + "' AND batch_no = '" + batchNo + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "'";

            if (strUnitId.Length > 0)
            {
                sql = sql + " AND unit_id = '" + strUnitId + "'";
            }
            if (strSectionId.Length > 0)
            {
                sql = sql + " AND section_id = '" + strSectionId + "'";
            }

            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {
                    objSalaryDTO.ManualIncrement = objDataReader.GetString(0);
                    objSalaryDTO.GrossSalary = objDataReader.GetString(1);
                    objSalaryDTO.JoiningDate = objDataReader.GetString(2);

                }
            }
            return objSalaryDTO;
        }

        public SalaryDTO searchStaffIncrementEntryMonthly(string strEmployeeId, string strIncrementYear, string strIncrementMonth, string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();


            string sql = "";

            sql = "SELECT " +
                  "to_char(NVL(INCREMENT_AMOUNT, '0' )), " +
                  "to_char(NVL(GROSS_SALARY, '0' )), " +
                  "NVL (TO_CHAR (JOINING_DATE, 'dd/mm/yyyy'), ' ') " +

                  "FROM VEW_INC_SEARCH_STAFF_MONTHLY WHERE employee_id = '" + strEmployeeId + "' AND increment_year = '" + strIncrementYear + "' AND increment_month = '" + strIncrementMonth + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "'";

            if (strUnitId.Length > 0)
            {
                sql = sql + " AND unit_id = '" + strUnitId + "'";

            }
            if (strSectionId.Length > 0)
            {
                sql = sql + " AND section_id = '" + strSectionId + "'";

            }



            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {


                    objSalaryDTO.ManualIncrement = objDataReader.GetString(0);
                    objSalaryDTO.GrossSalary = objDataReader.GetString(1);
                    objSalaryDTO.JoiningDate = objDataReader.GetString(2);

                }



            }

            return objSalaryDTO;
        }
        public SalaryDTO searchBonusEntryWorker(string strEmployeeId,  string strEidBonusTypeId, string strSalaryYear, string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();


            string sql = "";

            sql = "SELECT " +
                  "to_char(NVL(BONUS_AMOUNT, '0' )) " +



                  "FROM VEW_SEARCH_BONUS_BASIC_WORKER WHERE employee_id = '" + strEmployeeId + "' AND EID_YEAR = '" + strSalaryYear + "'  AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "'";

            if (strUnitId.Length > 0)
            {
                sql = sql + " AND unit_id = '" + strUnitId + "'";

            }
            if (strSectionId.Length > 0)
            {
                sql = sql + " AND section_id = '" + strSectionId + "'";

            }

            if (strEidBonusTypeId.Length > 0)
            {
                sql = sql + " AND EID_TYPE_ID = '" + strEidBonusTypeId + "'";

            }



            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {
                    objSalaryDTO.Bonus = objDataReader.GetString(0);


                }



            }

            return objSalaryDTO;
        }
        public SalaryDTO searchBonusEntryHO(string strEmployeeId, string strEidBonusTypeId, string strSalaryYear, string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();


            string sql = "";

            sql = "SELECT " +
                  "to_char(NVL(first_salary, '0' )), " +
                  "to_char(NVL(second_salary, '0' )) " +


                  "FROM VEW_SEARCH_STAFF_BONUS WHERE employee_id = '" + strEmployeeId + "' AND EID_YEAR = '" + strSalaryYear + "'  AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "'";

            if (strUnitId.Length > 0)
            {
                sql = sql + " AND unit_id = '" + strUnitId + "'";

            }
            if (strSectionId.Length > 0)
            {
                sql = sql + " AND section_id = '" + strSectionId + "'";

            }

            if (strEidBonusTypeId.Length > 0)
            {
                sql = sql + " AND EID_TYPE_ID = '" + strEidBonusTypeId + "'";

            }



            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {
                    objSalaryDTO.Bonus = objDataReader.GetString(0);
                    objSalaryDTO.SecondBonus = objDataReader.GetString(1);

                }



            }

            return objSalaryDTO;
        }

        public SalaryDTO searchBonusManualEntry(string strEmployeeId, string strEidBonusTypeId, string strSalaryYear, string strFromMonth, string strToMonth, string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();


            string sql = "";

            sql = "SELECT " +
                  "to_char(NVL(BONUS_AMOUNT_FIRST, '0' )), " +
                  "to_char(NVL(BONUS_AMOUNT_SECOND, '0' )) " +



                  "FROM VEW_BONUS_MANUAL_ENTRY WHERE employee_id = '" + strEmployeeId + "' AND EID_YEAR = '" + strSalaryYear + "'  and EID_MONTH_FROM = '" + strFromMonth + "' and EID_MONTH_TO = '"+strToMonth+"' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "'";

            if (strUnitId.Length > 0)
            {
                sql = sql + " AND unit_id = '" + strUnitId + "'";

            }
            if (strSectionId.Length > 0)
            {
                sql = sql + " AND section_id = '" + strSectionId + "'";

            }

            if (strEidBonusTypeId.Length > 0)
            {
                sql = sql + " AND EID_TYPE_ID = '" + strEidBonusTypeId + "'";

            }



            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {
                    objSalaryDTO.Bonus = objDataReader.GetString(0);
                    objSalaryDTO.SecondBonus = objDataReader.GetString(1);

                }



            }

            return objSalaryDTO;
        }
        public SalaryDTO searchBonusEntryStaff(string strEmployeeId, string strEidBonusTypeId, string strSalaryYear, string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();


            string sql = "";

            sql = "SELECT " +
                  "to_char(NVL(BONUS_AMOUNT_FIRST, '0' )), " +
                  "to_char(NVL(BONUS_AMOUNT_SECOND, '0' )) " +



                  "FROM VEW_SEARCH_STAFF_BONUS_ENTRY WHERE employee_id = '" + strEmployeeId + "' AND EID_YEAR = '" + strSalaryYear + "'  AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "'";

            if (strUnitId.Length > 0)
            {
                sql = sql + " AND unit_id = '" + strUnitId + "'";

            }
            if (strSectionId.Length > 0)
            {
                sql = sql + " AND section_id = '" + strSectionId + "'";

            }

            if (strEidBonusTypeId.Length > 0)
            {
                sql = sql + " AND EID_TYPE_ID = '" + strEidBonusTypeId + "'";

            }



            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {
                    objSalaryDTO.Bonus = objDataReader.GetString(0);
                    objSalaryDTO.SecondBonus = objDataReader.GetString(1);

                }



            }

            return objSalaryDTO;
        }
        public SalaryDTO searchLeaveEntryWorker(string strEmployeeId, string strSalaryYear, string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();


            string sql = "";

            sql = "SELECT " +
                  "to_char(NVL(LEAVE_DAY, '0' )) " +
                



                  "FROM vew_search_leave_entry_worker WHERE employee_id = '" + strEmployeeId + "' AND leave_year = '" + strSalaryYear + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "'";

            if (strUnitId.Length > 0)
            {
                sql = sql + " AND unit_id = '" + strUnitId + "'";

            }
            if (strSectionId.Length > 0)
            {
                sql = sql + " AND section_id = '" + strSectionId + "'";

            }



            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {
                    objSalaryDTO.LeaveDay = objDataReader.GetString(0);
                  

                }



            }

            return objSalaryDTO;
        }
        public SalaryDTO searchLeaveEntryStaff(string strEmployeeId, string strSalaryYear, string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();


            string sql = "";

            sql = "SELECT " +
                  "to_char(NVL(LEAVE_DAY, '0' )) " +
                


                  "FROM VEW_SEARCH_LEAVE_ENTRY_STAFF WHERE employee_id = '" + strEmployeeId + "' AND leave_year = '" + strSalaryYear + "'  AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "'";

            if (strUnitId.Length > 0)
            {
                sql = sql + " AND unit_id = '" + strUnitId + "'";

            }
            if (strSectionId.Length > 0)
            {
                sql = sql + " AND section_id = '" + strSectionId + "'";

            }



            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {
                    objSalaryDTO.LeaveDay = objDataReader.GetString(0);
                   

                }



            }

            return objSalaryDTO;
        }
        public SalaryDTO searchOverTimeEntryWorker(string strEmployeeId, string strSalaryYear, string strSalaryMonth, string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();


            string sql = "";

            sql = "SELECT " +
                
                  "to_char(NVL(OVER_TIME_HOUR,'0')), " +
                   "to_char(NVL(ot_advance_amount,'0')) " +


                  "FROM vew_search_over_time_entry WHERE employee_id = '" + strEmployeeId + "' AND OT_YEAR = '" + strSalaryYear + "' AND OT_MONTH = '" + strSalaryMonth + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "'";

            if (strUnitId.Length > 0)
            {
                sql = sql + " AND unit_id = '" + strUnitId + "'";

            }
            if (strSectionId.Length > 0)
            {
                sql = sql + " AND section_id = '" + strSectionId + "'";

            }



            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {
                    objSalaryDTO.OverTimeHour = objDataReader.GetString(0);
                    objSalaryDTO.OtAdvanceAmount = objDataReader.GetString(1) == string.Empty ? 0 : Convert.ToInt32(objDataReader.GetString(1));
                }
            }
            return objSalaryDTO;
        }
        public SalaryDTO searchArrearAdavanceEntryHO(string strEmployeeId, string strArrearYear, string strFromMonthId, string strToMonthId, string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();


            string sql = "";

            sql = "SELECT " +

                 
                 "to_char(NVL(ADVANCE_FEE, '0')), " +
                 "to_char(NVL(WITHOUT_ARREAR_YES, '0')) " +


                  "FROM vew_search_arrear_advan_entry WHERE employee_id = '" + strEmployeeId + "' AND ARREAR_YEAR = '" + strArrearYear + "' AND arrear_from_month_id = '" + strFromMonthId + "' AND arrear_to_month_id = '" + strToMonthId + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "'";

            if (strUnitId.Length > 0)
            {
                sql = sql + " AND unit_id = '" + strUnitId + "'";

            }
            if (strSectionId.Length > 0)
            {
                sql = sql + " AND section_id = '" + strSectionId + "'";

            }



            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {

                    objSalaryDTO.AdvanceFee = objDataReader.GetString(0);
                    objSalaryDTO.WithoutArrearYes = objDataReader.GetString(1);


                }



            }

            return objSalaryDTO;
        }
        public SalaryDTO searchSalaryEntryStaff(string strEmployeeId, string strSalaryYear, string strSalaryMonth, string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();


            string sql = "";

            sql = "SELECT " +
                  "to_char(NVL(ADVANCE_FEE, '0' )), " +
                   "to_char(NVL(ARREAR_FEE, '0')), " +
                  "to_char(NVL(FOOD_ALLOWANCE_FEE,'0')), " +
                  "to_char(NVL(FOOD_DEDUCT_FEE,'0')), " +
                  "to_char(NVL(WORKING_DAY,'0')), " +
                  "to_char(NVL(remarks,'0')) " +

                  "FROM VEW_SEARCH_SALARY_ENTRY_STAFF WHERE employee_id = '" + strEmployeeId + "' AND salary_year = '" + strSalaryYear + "' AND salary_month = '" + strSalaryMonth + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "'";

            if (strUnitId.Length > 0)
            {
                sql = sql + " AND unit_id = '" + strUnitId + "'";

            }
            if (strSectionId.Length > 0)
            {
                sql = sql + " AND section_id = '" + strSectionId + "'";

            }



            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {
                    objSalaryDTO.AdvanceFee = objDataReader.GetString(0);
                    objSalaryDTO.ArrearFee = objDataReader.GetString(1);
                    objSalaryDTO.FoodAllowance = objDataReader.GetString(2);
                    objSalaryDTO.FoodDeductFee = objDataReader.GetString(3);
                    objSalaryDTO.WorkingDay = objDataReader.GetString(4);
                    objSalaryDTO.Remarks = objDataReader.GetString(5);
                }



            }

            return objSalaryDTO;
        }
        public SalaryDTO searchMiscSalaryEntryStaff(string strEmployeeId, string strSalaryYear, string strSalaryMonth, string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();


            string sql = "";

            sql = "SELECT " +
                  "to_char(NVL(ADVANCE_FEE, '0' )), " +
                  "to_char(NVL(FOOD_ALLOWANCE_FEE,'0')), " +
                  "to_char(NVL(FOOD_DEDUCT_FEE,'0')), " +
                  "to_char(NVL(ARREAR_FEE, '0')) " +



                  "FROM VEW_SEARCH_SALARY_ENTRY_SM WHERE employee_id = '" + strEmployeeId + "' AND salary_year = '" + strSalaryYear + "' AND salary_month = '" + strSalaryMonth + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "'";

            if (strUnitId.Length > 0)
            {
                sql = sql + " AND unit_id = '" + strUnitId + "'";

            }
            if (strSectionId.Length > 0)
            {
                sql = sql + " AND section_id = '" + strSectionId + "'";

            }



            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {
                    objSalaryDTO.AdvanceFee = objDataReader.GetString(0);
                    objSalaryDTO.AllowenceAmount = objDataReader.GetString(1);
                    objSalaryDTO.ArrearFee = objDataReader.GetString(2);


                }



            }

            return objSalaryDTO;
        }

        public SalaryDTO searchAdvanceInfo(string strEmployeeId, string strYear, string strMonth, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();



            string sql = "";

            sql = "SELECT " +
                  "to_char(NVL(ADVANCE_FEE, '0' )), " +
                  "to_char(NVL(ADVANCE_DEDUCT_FEE,'0')), " +
                  "NVL (TO_CHAR (RECEIVE_DATE, 'dd/mm/yyyy'), ''), " +
                  "NVL (TO_CHAR (DEDUCT_DATE, 'dd/mm/yyyy'), ''), " +
                  "to_char(NVL(DEDUCT_YN, '0')) " +

                  "FROM vew_searh_advance_info WHERE employee_id = '" + strEmployeeId + "' AND advance_year = '" + strYear + "' AND advane_month = '" + strMonth + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "'";

          



            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {
                    objSalaryDTO.AdvanceFee = objDataReader.GetString(0);
                    objSalaryDTO.FoodAllowance = objDataReader.GetString(1);
                    objSalaryDTO.ArrearFee = objDataReader.GetString(2);


                }



            }

           
           
            return objSalaryDTO;
        }


        public string updateTax(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_update_tax_amount");
            objOracleCommand.CommandType = CommandType.StoredProcedure;
            string strMsg = "";


            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;
            

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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


        public SalaryDTO getFirstSalary(string strYear, string strMonth, string strEmployeeId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();

            string sql = "";

            sql = "SELECT " +
                  "to_char(NVL(FIRST_SALARY, '0' )) " +


                  "FROM vew_search_bank_salary_entry WHERE employee_id = '" + strEmployeeId + "' AND salary_year = '" + strYear + "' AND salary_month = '" + strMonth + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "'";


            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {
                    objSalaryDTO.FirstSalary = objDataReader.GetString(0);
                   

                }



            }
            return objSalaryDTO;
        }
        public SalaryDTO searcReamingLoan(string strEmployeeId, string strYear, string strMonth,  string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();

            string sql = "";

            sql = "SELECT " +
                  "to_char(NVL(REAMING_BLANCE, '0' )) " +


                  "FROM VEW_RPT_ADVANCE_AMOUNT WHERE employee_id = '" + strEmployeeId + "' AND ADVANCE_YEAR = '" + strYear + "' AND ADVANCE_MONTH = '" + strMonth + "'  AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "'";


            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {
                    objSalaryDTO.LoanAmount = objDataReader.GetString(0);


                }



            }
            return objSalaryDTO;
        }


        public string employeeLogDataProcess(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
                        
            //new: 09.02.2021
            OracleCommand objOracleCommand = new OracleCommand("sp_process_auto_attendance");

            //old: 09.02.2021
            //OracleCommand objOracleCommand = new OracleCommand("sp_process_attendence");

            //Old: 2 sp_summarize_attendance
            //OracleCommand objOracleCommand = new OracleCommand("sp_summarize_attendance");
            //Old: 1
            //OracleCommand objOracleCommand = new OracleCommand("pro_select_attendence_process");

            //OracleCommand objOracleCommand = new OracleCommand("sp_process_attendence");

            objOracleCommand.CommandType = CommandType.StoredProcedure;
                     

            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.FromDate.Length  > 6)
            {
                objOracleCommand.Parameters.Add("p_from_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.FromDate;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_from_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objSalaryDTO.ToDate.Length > 6)
            {
                objOracleCommand.Parameters.Add("p_to_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.ToDate;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_to_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

           

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;
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
        public string attendenceProcess(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            
            //Old
            OracleCommand objOracleCommand = new OracleCommand("pro_worker_attendence_process");
            //New
            //OracleCommand objOracleCommand = new OracleCommand("sp_upload_attendance");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objSalaryDTO.FileName != "")
            {
                objOracleCommand.Parameters.Add("p_file_name", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.FileName;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_file_name", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            //if (objSalaryDTO.MediaTypeId != "")
            //{
            //    objOracleCommand.Parameters.Add("p_file_name", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.MediaTypeId;
            //}
            //else
            //{
            //    objOracleCommand.Parameters.Add("p_file_name", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            //}

            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.FromDate.Length > 6)
            {
                objOracleCommand.Parameters.Add("p_from_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.FromDate;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_from_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objSalaryDTO.ToDate.Length > 6)
            {
                objOracleCommand.Parameters.Add("p_to_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.ToDate;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_to_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;
            if (objSalaryDTO.MediaTypeId != "")
            {
                objOracleCommand.Parameters.Add("p_media_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.MediaTypeId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_media_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
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

        public DataTable searchExcelFile(SalaryDTO objSalaryDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
                   "TRAN_ID, " +
                   "FILE_NAME, " +
                   "FILE_TYPE " +


                  "FROM vew_bank_sheet_download WHERE salary_year = '" + objSalaryDTO.Year + "' and salary_month = '" + objSalaryDTO.Month + "' and head_office_id = '" + objSalaryDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objSalaryDTO.BranchOfficeId + "'";




            sql = sql + "order by TRAN_ID ";

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


        public SalaryDTO DownloadMonthlyBankSheet(string strId, string strHeadOfficeId, string strBranchOfficeId)
        {
            SalaryDTO objSalaryDTO = new SalaryDTO();

            string sql = "";
            sql = "SELECT " +
                 "FILE_NAME, " +
                 "FILE_TYPE, " +
                 "DATA_FILE " +

                "FROM BANK_SHEET_UPLOAD WHERE TRAN_ID = '" + strId + "' and head_office_id = '" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "' ";

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

                        objSalaryDTO.FileName = objDataReader["FILE_NAME"].ToString();
                        objSalaryDTO.FileType = objDataReader["FILE_TYPE"].ToString();
                        objSalaryDTO.FileDocuments = (byte[])objDataReader["DATA_FILE"];

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

            return objSalaryDTO;
        }



        public string saveMonthlyLunchEntryHO(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_monthly_lunch_entry_ho");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;
            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;


            if (objSalaryDTO.LunchDay != "")
            {
                objOracleCommand.Parameters.Add("P_LUNCH_DAY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.LunchDay;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_LUNCH_DAY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSalaryDTO.AbsentDay != "")
            {
                objOracleCommand.Parameters.Add("P_ABSENT_DAY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.AbsentDay;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_ABSENT_DAY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }




            if (objSalaryDTO.FoodAllowance != "")
            {
                objOracleCommand.Parameters.Add("P_FOOD_ALLOWANCE_FEE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.FoodAllowance;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_FOOD_ALLOWANCE_FEE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objSalaryDTO.FoodDeductFee != "")
            {
                objOracleCommand.Parameters.Add("P_FOOD_DEDUCT_FEE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.FoodDeductFee;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_FOOD_DEDUCT_FEE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSalaryDTO.MonthDay != "")
            {
                objOracleCommand.Parameters.Add("P_MONTH_DAY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.MonthDay;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_MONTH_DAY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSalaryDTO.WorkingDay != "")
            {
                objOracleCommand.Parameters.Add("P_WORKING_DAY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.WorkingDay;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_WORKING_DAY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }



            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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

        public SalaryDTO searchLunchEntryHO(string strEmployeeId, string strSalaryYear, string strSalaryMonth, string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();


            string sql = "";

            sql = "SELECT " +
                  "to_char(NVL(LUNCH_DAY, '0' )), " +
                    "to_char(NVL(ABSENT_DAY, '0' )), " +

                  "to_char(NVL(FOOD_ALLOWANCE_FEE, '0')), " +
                  "to_char(NVL(FOOD_DEDUCT_FEE, '0')), " +
                   "to_char(NVL(MONTH_DAY, '0')), " +
                    "to_char(NVL(WORKING_DAY, '0')) " +

                  "FROM VEW_SEARCH_LUNCH_ENTRY_HO WHERE employee_id = '" + strEmployeeId + "' AND salary_year = '" + strSalaryYear + "' AND salary_month = '" + strSalaryMonth + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "'";

            if (strUnitId.Length > 0)
            {
                sql = sql + " AND unit_id = '" + strUnitId + "'";

            }
            if (strSectionId.Length > 0)
            {
                sql = sql + " AND section_id = '" + strSectionId + "'";

            }



            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {
                    objSalaryDTO.LunchDay = objDataReader.GetString(0);
                    objSalaryDTO.AbsentDay = objDataReader.GetString(1);

                    objSalaryDTO.FoodAllowance = objDataReader.GetString(2);
                    objSalaryDTO.FoodDeductFee = objDataReader.GetString(3);
                    objSalaryDTO.MonthDay = objDataReader.GetString(4);
                    objSalaryDTO.WorkingDay = objDataReader.GetString(5);

                }



            }

            return objSalaryDTO;
        }




        ////////////////////////////////////Salary Monthly OT Entry///////////////////////////////
        public string saveSalaryMiscOTEntryResign(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_worker_ot_save_for_resign");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;
            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("p_ot_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_ot_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;



            if (objSalaryDTO.OverTimeHour != "")
            {
                objOracleCommand.Parameters.Add("P_OT_HOUR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.OverTimeHour;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_OT_HOUR", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }



            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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


        public SalaryDTO searchResignOTEntryWorker(string strEmployeeId, string strSalaryYear, string strSalaryMonth, string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();


            string sql = "";

            sql = "SELECT " +

                  "to_char(NVL(OT_HOUR,'0')) " +


                  " FROM VEW_SEARCH_OT_ENTRY_RESIGN WHERE employee_id = '" + strEmployeeId + "' AND ot_year = '" + strSalaryYear + "' AND ot_month = '" + strSalaryMonth + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "'";

            if (strUnitId.Length > 0)
            {
                sql = sql + " AND unit_id = '" + strUnitId + "'";

            }
            if (strSectionId.Length > 0)
            {
                sql = sql + " AND section_id = '" + strSectionId + "'";

            }



            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {

                    objSalaryDTO.OverTimeHour = objDataReader.GetString(0);

              

                }



            }

            return objSalaryDTO;
        }




        public SalaryDTO searchSalaryEntryTemp(string strEmployeeId, string strSalaryYear, string strSalaryMonth, string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();


            string sql = "";

            sql = "SELECT " +
                  "to_char(NVL(ADVANCE_FEE, '0' )), " +
                  "to_char(NVL(OVER_TIME_HOUR,'0')), " +
                  "to_char(NVL(ARREAR_FEE, '0')), " +
                  "to_char(NVL(WORKING_DAY, '0')), " +
                  "to_char(NVL(ATTENDENCE_FEE, '0')) " +



                  "FROM VEW_SEARCH_MONTHLY_SALARY_TEMP WHERE employee_id = '" + strEmployeeId + "' AND salary_year = '" + strSalaryYear + "' AND salary_month = '" + strSalaryMonth + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "'";

            if (strUnitId.Length > 0)
            {
                sql = sql + " AND unit_id = '" + strUnitId + "'";

            }
            if (strSectionId.Length > 0)
            {
                sql = sql + " AND section_id = '" + strSectionId + "'";

            }



            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {
                    objSalaryDTO.AdvanceFee = objDataReader.GetString(0);
                    objSalaryDTO.OverTimeHour = objDataReader.GetString(1);
                    objSalaryDTO.ArrearFee = objDataReader.GetString(2);
                    objSalaryDTO.WorkingDay = objDataReader.GetString(3);
                    objSalaryDTO.Bonus = objDataReader.GetString(4);

                }



            }

            return objSalaryDTO;
        }



        public string saveSalaryEntryTempSave(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_monthly_salary_temp_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;
            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;





            if (objSalaryDTO.AdvanceFee != "")
            {
                objOracleCommand.Parameters.Add("p_advance_fee", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.AdvanceFee;

            }
            else
            {
                objOracleCommand.Parameters.Add("p_advance_fee", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSalaryDTO.ArrearFee != "")
            {
                objOracleCommand.Parameters.Add("p_arrear_fee", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.ArrearFee;

            }
            else
            {
                objOracleCommand.Parameters.Add("p_arrear_fee", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }



            if (objSalaryDTO.WorkingDay != "")
            {
                objOracleCommand.Parameters.Add("p_working_day", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.WorkingDay;

            }
            else
            {
                objOracleCommand.Parameters.Add("p_working_day", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSalaryDTO.OverTimeHour != "")
            {
                objOracleCommand.Parameters.Add("P_OVER_TIME_HOUR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.OverTimeHour;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_OVER_TIME_HOUR", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSalaryDTO.Bonus != "")
            {
                objOracleCommand.Parameters.Add("P_ATTENDENCE_FEE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Bonus;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_ATTENDENCE_FEE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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


        public SalaryDTO searchSalaryEmployee(string strEmployeeId, string strUnitId, string strCardNo, string strSectionId, string strYear, string strMonth, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();

            string sql = "", sql1 = "", strYes="";



            sql = "SELECT 'Y' from VEW_SALARY_PENDING_LIST where APPROVE_YEAR = '" + strYear + "' and APPROVE_MONTH = '" + strMonth + "' and employee_id = '" + strEmployeeId + "' AND head_office_id = '"+strHeadOfficeId+"' AND branch_office_id = '"+strBranchOfficeId+ "' AND MANUAL_YN = 'Y' ";




            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {
                    strYes = "Y";
                }



            }






            if (strYes == "Y")
            {


                sql1 = "SELECT " +
                      "to_char(NVL(FIRST_SALARY, '0' )), " +
                       "to_char(NVL(GROSS_SALARY, '0')), " +
                        "to_char(NVL(FIRST_SALARY_PRE, '0')), " +
                         "to_char(NVL(GROSS_SALARY_PRE, '0')) " +


                      "FROM VEW_SALARY_PENDING_LIST where  HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "' AND APPROVE_YEAR = '" + strYear + "' and APPROVE_MONTH = '" + strMonth + "'  AND MANUAL_YN = 'Y' ";

                if (strEmployeeId.Length > 0)
                {

                    sql1 = sql1 + "and employee_id = '" + strEmployeeId + "'";
                }


                if (strUnitId.Length > 0)
                {
                    sql1 = sql1 + " AND unit_id = '" + strUnitId + "'";

                }
                if (strSectionId.Length > 0)
                {
                    sql1 = sql1 + " AND section_id = '" + strSectionId + "'";

                }



                OracleCommand objCommand1 = new OracleCommand(sql1);
                OracleDataReader objDataReader1;

                using (OracleConnection strConn = GetConnection())
                {

                    objCommand1.Connection = strConn;
                    strConn.Open();
                    objDataReader1 = objCommand1.ExecuteReader();
                    if (objDataReader1.Read())
                    {
                        objSalaryDTO.FirstSalary = objDataReader1.GetString(0);
                        objSalaryDTO.GrossSalary = objDataReader1.GetString(1);
                        objSalaryDTO.PreviousFirstSalary = objDataReader1.GetString(2);
                        objSalaryDTO.PreviousGrossSalary = objDataReader1.GetString(3);

                    }



                }

            }


            else
            {


                sql1 = "SELECT " +
                      "to_char(NVL(0, '0' )), " +
                       "to_char(NVL(0, '0')), " +
                        "to_char(NVL(FIRST_SALARY, '0')), " +
                         "to_char(NVL(GROSS_SALARY, '0')) " +


                      "FROM VEW_SEARCH_EMP_FOR_SAL_APPROVE where  HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "' and employee_id = '" + strEmployeeId + "'";






                OracleCommand objCommand1 = new OracleCommand(sql1);
                OracleDataReader objDataReader1;

                using (OracleConnection strConn = GetConnection())
                {

                    objCommand1.Connection = strConn;
                    strConn.Open();
                    objDataReader1 = objCommand1.ExecuteReader();
                    if (objDataReader1.Read())
                    {
                        objSalaryDTO.FirstSalary = objDataReader1.GetString(0);
                        objSalaryDTO.GrossSalary = objDataReader1.GetString(1);
                        objSalaryDTO.PreviousFirstSalary = objDataReader1.GetString(2);
                        objSalaryDTO.PreviousGrossSalary = objDataReader1.GetString(3);

                    }



                }

            }









            return objSalaryDTO;
        }


        public string saveSalaryApproveEntry(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_salary_approve_entry_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            //Added by assd and shahin
            objOracleCommand.Parameters.Add("P_occurrence_type_id", OracleDbType.Int32, ParameterDirection.Input).Value = objSalaryDTO.OccurrenceTypeId;

            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;
            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;



            if (objSalaryDTO.FirstSalary != "")
            {
                objOracleCommand.Parameters.Add("P_FIRST_SALARY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.FirstSalary;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_FIRST_SALARY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objSalaryDTO.GrossSalary != "")
            {
                objOracleCommand.Parameters.Add("P_GROSS_SALARY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.GrossSalary;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_GROSS_SALARY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSalaryDTO.PreviousFirstSalary != "")
            {
                objOracleCommand.Parameters.Add("P_FIRST_SALARY_PRE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.PreviousFirstSalary;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_FIRST_SALARY_PRE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objSalaryDTO.PreviousGrossSalary != "")
            {
                objOracleCommand.Parameters.Add("P_GROSS_SALARY_PRE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.PreviousGrossSalary;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_GROSS_SALARY_PRE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }



            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
       
        public string AppoinmentApprovalRequest(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_appoinment_approval_entry");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            //Added by assd and shahin
            objOracleCommand.Parameters.Add("P_occurrence_type_id", OracleDbType.Int32, ParameterDirection.Input).Value = objSalaryDTO.OccurrenceTypeId;

            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;
            if (objSalaryDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;



            if (objSalaryDTO.FirstSalary != "")
            {
                objOracleCommand.Parameters.Add("P_FIRST_SALARY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.FirstSalary;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_FIRST_SALARY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objSalaryDTO.GrossSalary != "")
            {
                objOracleCommand.Parameters.Add("P_GROSS_SALARY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.GrossSalary;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_GROSS_SALARY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSalaryDTO.PreviousFirstSalary != "")
            {
                objOracleCommand.Parameters.Add("P_FIRST_SALARY_PRE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.PreviousFirstSalary;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_FIRST_SALARY_PRE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objSalaryDTO.PreviousGrossSalary != "")
            {
                objOracleCommand.Parameters.Add("P_GROSS_SALARY_PRE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.PreviousGrossSalary;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_GROSS_SALARY_PRE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }



            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;


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
        public SalaryDTO loadSalaryEmployee(string strEmployeeId, string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();


            string sql = "";

            sql = "SELECT " +
                  "to_char(NVL(FIRST_SALARY, '0' )), " +
                   "to_char(NVL(GROSS_SALARY, '0')) " +




                  "FROM VEW_SALARY_PENDING_LIST WHERE employee_id = '" + strEmployeeId + strBranchOfficeId + "'";

            if (strUnitId.Length > 0)
            {
                sql = sql + " AND unit_id = '" + strUnitId + "'";

            }
            if (strSectionId.Length > 0)
            {
                sql = sql + " AND section_id = '" + strSectionId + "'";

            }



            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {
                    objSalaryDTO.FirstSalary = objDataReader.GetString(0);
                    objSalaryDTO.GrossSalary = objDataReader.GetString(1);

                }



            }

            return objSalaryDTO;
        }

        public string SaveGazetteInfo(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("sp_gazette_info_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;
            if (objSalaryDTO.GazetteId != "")
            {
                objOracleCommand.Parameters.Add("P_GAZETTE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.GazetteId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_GAZETTE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objSalaryDTO.ScheduleId != "")
            {
                objOracleCommand.Parameters.Add("P_SCHEDULE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.ScheduleId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SCHEDULE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.GradeId != "")
            {
                objOracleCommand.Parameters.Add("P_GRADE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.GradeId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_GRADE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.Year != "")
            {
                objOracleCommand.Parameters.Add("P_PUBLISH_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PUBLISH_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objSalaryDTO.GrossSalary != "")
            {
                objOracleCommand.Parameters.Add("P_GROSS_SALARY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.GrossSalary;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_GROSS_SALARY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objSalaryDTO.MedicalFee != "")
            {
                objOracleCommand.Parameters.Add("P_MEDICAL_FEE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.MedicalFee;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_MEDICAL_FEE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.ConvenceFee != "")
            {
                objOracleCommand.Parameters.Add("P_CONVENCE_FEE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.ConvenceFee;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_CONVENCE_FEE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objSalaryDTO.FoodAllowance != "")
            {
                objOracleCommand.Parameters.Add("P_FOOD_FEE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.FoodAllowance;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_FOOD_FEE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objSalaryDTO.ExtraFoodFee != "")
            {
                objOracleCommand.Parameters.Add("P_EXTRA_FOOD_FEE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.ExtraFoodFee;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_EXTRA_FOOD_FEE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objSalaryDTO.ChkActive != "")
            {
                objOracleCommand.Parameters.Add("P_ACTIVE_YN", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.ChkActive;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_ACTIVE_YN", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
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

        public string DeleteDiscardAnnualIncrement(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("SP_DISCARD_ANNUAL_INCREMENT");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objSalaryDTO.Year != "")
            {
                objOracleCommand.Parameters.Add("p_increment_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_increment_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objSalaryDTO.Month != "")
            {
                objOracleCommand.Parameters.Add("p_increment_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_increment_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.EmployeeId != "")
            {
                objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            objOracleCommand.Parameters.Add("P_DETAIL_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.DetailId;
            
            if (objSalaryDTO.BatchNo != "")
            {
                objOracleCommand.Parameters.Add("p_batch_no", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BatchNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_batch_no", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            objOracleCommand.Parameters.Add("p_manual_increment_amount", OracleDbType.Int32, ParameterDirection.Input).Value = objSalaryDTO.ManualIncrementAmount;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("p_logged_in_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
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

        public string ProcessPromotionQueue(SalaryDTO SalaryDTO)
        {

            string strMsg = "";
            OracleCommand objOracleCommand = new OracleCommand("process_promotion_queue");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (SalaryDTO.UnitId.Length > 0)
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = SalaryDTO.UnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (SalaryDTO.SectionId.Length > 0)
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = SalaryDTO.SectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            objOracleCommand.Parameters.Add("p_promotion_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = SalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_promotion_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = SalaryDTO.Month;

            //objOracleCommand.Parameters.Add("p_employee_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = SalaryDTO.EmployeeTypeId;

            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = SalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = SalaryDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("p_logged_in_employee", OracleDbType.Varchar2, ParameterDirection.Input).Value = SalaryDTO.UpdateBy;
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

        public string SavePermanentInfo(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction;
            OracleCommand objOracleCommand = new OracleCommand("SP_PERMANENT_QUEUE_SAVE");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;
            objOracleCommand.Parameters.Add("P_OCCURANCE_TYPE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.OccurrenceTypeId;

            if (objSalaryDTO.UnitIdFrom != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id_from", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitIdFrom;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_id_from", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.UnitIdTo != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id_to", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitIdTo;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_id_to", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionIdFrom != "")
            {
                objOracleCommand.Parameters.Add("p_section_id_from", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionIdFrom;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_section_id_from", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.SectionIdTo != "")
            {
                objOracleCommand.Parameters.Add("p_section_id_to", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionIdTo;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_section_id_to", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.DesignationIdFrom != "")
            {
                objOracleCommand.Parameters.Add("P_DESIGNATION_ID_FROM", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.DesignationIdFrom;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_DESIGNATION_ID_FROM", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objSalaryDTO.DesignationIdTo != "")
            {
                objOracleCommand.Parameters.Add("P_DESIGNATION_ID_TO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.DesignationIdTo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_DESIGNATION_ID_TO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.GradeIdFrom != "")
            {
                objOracleCommand.Parameters.Add("P_GRADE_ID_FROM", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.GradeIdFrom;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_GRADE_ID_FROM", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.GradeIdTo != "")
            {
                objOracleCommand.Parameters.Add("P_GRADE_ID_TO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.GradeIdTo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_GRADE_ID_TO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.GrossSalaryFrom != " ")
            {
                objOracleCommand.Parameters.Add("p_gross_salary_from", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.GrossSalaryFrom;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_gross_salary_from", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objSalaryDTO.GrossSalaryTo != "")
            {
                objOracleCommand.Parameters.Add("p_gross_salary_to", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.GrossSalaryTo;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_gross_salary_to", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.FirstSalaryFrom != "")
            {
                objOracleCommand.Parameters.Add("p_first_salary_from", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.FirstSalaryFrom;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_first_salary_from", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objSalaryDTO.FirstSalaryTo != "")
            {
                objOracleCommand.Parameters.Add("p_first_salary_to", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.FirstSalaryTo;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_first_salary_to", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            objOracleCommand.Parameters.Add("p_permanent_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;

            if (objSalaryDTO.Month != "")
            {
                objOracleCommand.Parameters.Add("p_permanent_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_permanent_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.EffectiveDate.Length > 0)
            {
                objOracleCommand.Parameters.Add("p_effective_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EffectiveDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_effective_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("p_create_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;

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
        public string ProcessPermanentQueue(SalaryDTO SalaryDTO)
        {

            string strMsg = "";
            OracleCommand objOracleCommand = new OracleCommand("process_permanent_queue");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            //if (SalaryDTO.UnitId.Length > 0)
            //{
            //    objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = SalaryDTO.UnitId;
            //}
            //else
            //{
            //    objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            //}
            //if (SalaryDTO.SectionId.Length > 0)
            //{
            //    objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = SalaryDTO.SectionId;
            //}
            //else
            //{
            //    objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            //}

            objOracleCommand.Parameters.Add("p_permanent_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = SalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_permanent_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = SalaryDTO.Month;

            objOracleCommand.Parameters.Add("p_logged_in_employee", OracleDbType.Varchar2, ParameterDirection.Input).Value = SalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = SalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = SalaryDTO.BranchOfficeId;
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

        public string ProcessSpecialIncrementProposal(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("sp_pro_special_incr_proposal");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("p_increment_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_increment_month  ", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;
            objOracleCommand.Parameters.Add("p_employee_type_id  ", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeTypeId;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("p_create_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
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
        public string SaveSpecialIncrement(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("sp_save_special_increment ");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;
            objOracleCommand.Parameters.Add("P_INCREMENT_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("P_INCREMENT_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;
            objOracleCommand.Parameters.Add("P_EMPLOYEE_TYPE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeTypeId;
            objOracleCommand.Parameters.Add("P_INCREMENT_AMOUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.IncrementAmount;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("P_CREATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
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

        public string ProcessSpecialIncrement(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleCommand objOracleCommand = new OracleCommand("sp_process_special_increment");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("p_increment_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_increment_month  ", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;
            objOracleCommand.Parameters.Add("p_employee_type_id  ", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeTypeId;
            objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("p_create_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
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

        public decimal GetSpecialIncrementAmountByEmployeeId(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            decimal incrementAmount = 0;

            OracleCommand objOracleCommand = new OracleCommand("SP_GET_SPECIAL_INCR_BY_EMP_ID");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("p_increment_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_increment_month  ", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;
            objOracleCommand.Parameters.Add("p_employee_id  ", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;

            objOracleCommand.Parameters.Add("p_increment_amount", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;
            //objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;


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
                    incrementAmount = Convert.ToDecimal(objOracleCommand.Parameters["p_increment_amount"].Value.ToString());
                    //strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
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
            return incrementAmount;
        }


        public DataTable GetEmployeeBasic(SalaryDTO objSalaryDTO)
        {
            DataTable myTable = new DataTable();
            try
            {
                                
                OracleCommand objOracleCommand = new OracleCommand("sp_get_employee_basic");

                objOracleCommand.CommandType = CommandType.StoredProcedure;
                                
                objOracleCommand.Parameters.Add("p_active_yn", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.ChkActive;
                objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;
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

        public DataTable GetSalaryHistory(SalaryDTO objSalaryDTO)
        {
            DataTable myTable = new DataTable();
            try
            {

                OracleCommand objOracleCommand = new OracleCommand("sp_get_salary_history");

                objOracleCommand.CommandType = CommandType.StoredProcedure;
                                
                objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;
                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;
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


        public string DeleteWorkerSalaryInfo(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleCommand objOracleCommand = new OracleCommand("SP_DELETE_WORKER_SALARY_INFO");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;
            objOracleCommand.Parameters.Add("p_SALARY_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_SALARY_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;
            objOracleCommand.Parameters.Add("p_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
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

        
        public string DeleteLunchHO(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleCommand objOracleCommand = new OracleCommand("SP_DELETE_LUNCH");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;
            objOracleCommand.Parameters.Add("p_SALARY_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_SALARY_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;
            objOracleCommand.Parameters.Add("p_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;
            
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

        public string DeleteVirtualTransfer(string transferId, string branchId, string headOfficeId)
        {
            string strMsg = "";
            OracleCommand objOracleCommand = new OracleCommand("SP_DELETE_VIRTUAL_TRANSFER");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("P_TRANSFER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = transferId;
            objOracleCommand.Parameters.Add("p_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = branchId;
            objOracleCommand.Parameters.Add("p_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = headOfficeId;
            
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


        public SalaryDTO GetWorkerIncrementList(string strEmployeeId, string strIncrementYear, string strIncrementMonth, string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();

            string sql = "";
            sql = "SELECT " +
                  "to_char(NVL(manual_increment_amount, '0' )), " +
                  "to_char(NVL(INCREMENT_AMOUNT, '0' )), " +
                  "to_char(NVL(GROSS_SALARY, '0' )), " +
                  "NVL (TO_CHAR (JOINING_DATE, 'dd/mm/yyyy'), ' ') " +

                  "FROM VEW_INCREMENT_SHEET_WORKER WHERE employee_id = '" + strEmployeeId + "' AND increment_year = '" + strIncrementYear + "' AND INCREMENT_MONTH = '" + strIncrementMonth + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "' ";

            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {
                    objSalaryDTO.ManualIncrement = objDataReader.GetString(0);
                    objSalaryDTO.IncrementAmount = objDataReader.GetString(1);
                    objSalaryDTO.GrossSalary = objDataReader.GetString(2);
                    objSalaryDTO.JoiningDate = objDataReader.GetString(3);

                }
            }
            return objSalaryDTO;
        }
        //public string SaveEmployeeConfirmationBasicInfo(SalaryDTO objSalaryDTO)
        //{
        //    string strMsg = "";
        //    OracleTransaction objOracleTransaction = null;
        //    OracleCommand objOracleCommand = new OracleCommand("sp_add_emp_confirmation_basic");
        //    objOracleCommand.CommandType = CommandType.StoredProcedure;

        //    objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;
        //    objOracleCommand.Parameters.Add("p_confirmation_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
        //    objOracleCommand.Parameters.Add("p_confirmation_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;
        //    objOracleCommand.Parameters.Add("P_DESIGNATION_ID_TO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.DesignationIdTo;
        //    objOracleCommand.Parameters.Add("P_INCREMENT_AMOUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.IncrementAmount;
        //    objOracleCommand.Parameters.Add("P_EFFECT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EffectiveDate;
        //    objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
        //    objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;
        //    objOracleCommand.Parameters.Add("P_CREATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
        //    objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

        //    using (OracleConnection strConn = GetConnection())
        //    {
        //        try
        //        {
        //            objOracleCommand.Connection = strConn;
        //            strConn.Open();
        //            trans = strConn.BeginTransaction();
        //            objOracleCommand.ExecuteNonQuery();
        //            trans.Commit();
        //            strConn.Close();
        //            strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
        //        }
        //        catch (Exception ex)
        //        {
        //            trans.Rollback();
        //            throw new Exception("Error : " + ex.Message);
        //        }
        //        finally
        //        {
        //            strConn.Close();
        //        }

        //    }
        //    return strMsg;
        //}
        public string SaveEmployeeConfirmationBasicInfo(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("sp_add_emp_confirmation_basic");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;
            objOracleCommand.Parameters.Add("p_confirmation_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_confirmation_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;
            objOracleCommand.Parameters.Add("P_DESIGNATION_ID_TO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.DesignationIdTo;
            objOracleCommand.Parameters.Add("P_INCREMENT_AMOUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.IncrementAmount;
            objOracleCommand.Parameters.Add("P_EFFECT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EffectiveDate;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("p_appvoved_by_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.ApprovedById;
            objOracleCommand.Parameters.Add("P_CREATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
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
        public string ProcessEmployeeConfirmation(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";
            OracleCommand objOracleCommand = new OracleCommand("sp_process_emp_confirmation");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;
            objOracleCommand.Parameters.Add("p_confirmation_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Year;
            objOracleCommand.Parameters.Add("p_confirmation_month  ", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Month;
            objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UnitId;
            objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SectionId;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("p_create_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
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
        public string DeleteSuspensionEmployee(SalaryDTO objSalaryDTO)//SP_DELETE_WORKER_SALARY_INFO
        {
            string strMsg = "";
            OracleCommand objOracleCommand = new OracleCommand("SP_DELETE_SUSPENSION_EMP");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("P_SUSPENSION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.SuspensionId;
            //objOracleCommand.Parameters.Add("p_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;
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
        public string TransferVirtuallyNew(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";

            OracleCommand objOracleCommand = new OracleCommand("SP_TRANSFER_VIRTUALLY_NEW");
            objOracleCommand.CommandType = CommandType.StoredProcedure;
            objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;
                       
          
            if (objSalaryDTO.VirtualOfficeId != "")
            {
                objOracleCommand.Parameters.Add("p_virtual_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.VirtualOfficeId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_virtual_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.TimeId != "")
            {
                objOracleCommand.Parameters.Add("p_virtual_time_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.TimeId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_virtual_time_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            //if (objSalaryDTO.ShiftId != "")
            //{
            //    objOracleCommand.Parameters.Add("p_virtual_shift_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.ShiftId;
            //}
            //else
            //{
            //    objOracleCommand.Parameters.Add("p_virtual_shift_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            //}

            if (objSalaryDTO.FloorId != "")
            {
                objOracleCommand.Parameters.Add("p_virtual_floor_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.FloorId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_virtual_floor_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            objOracleCommand.Parameters.Add("p_from_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.FromDate;
            objOracleCommand.Parameters.Add("p_to_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.ToDate;


            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;

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
        public string UpdateVirtualTransferNew(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";

            OracleCommand objOracleCommand = new OracleCommand("SP_UPDATE_VIRTUAL_TRANSFER_new");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("P_transfer_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.TransferId;

            if (objSalaryDTO.VirtualOfficeId != "")
            {
                objOracleCommand.Parameters.Add("p_virtual_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.VirtualOfficeId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_virtual_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            //if (objSalaryDTO.ShiftId != "")
            //{
            //    objOracleCommand.Parameters.Add("p_virtual_shift_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.ShiftId;
            //}
            //else
            //{
            //    objOracleCommand.Parameters.Add("p_virtual_shift_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            //}



            if (objSalaryDTO.TimeId != "")
            {
                objOracleCommand.Parameters.Add("p_virtual_time_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.TimeId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_virtual_time_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSalaryDTO.FloorId != "")
            {
                objOracleCommand.Parameters.Add("p_virtual_floor_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.FloorId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_virtual_floor_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            objOracleCommand.Parameters.Add("p_from_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.FromDate;
            objOracleCommand.Parameters.Add("p_to_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.ToDate;

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.UpdateBy;
            //objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            //objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;

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
        public string SaveRoamingEmployee(SalaryDTO objSalaryDTO)
        {
            string strMsg = "";

            OracleCommand objOracleCommand = new OracleCommand("SP_SAVE_ROAMING_EMPLOYEE");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("p_roaming_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.RoamingId;
            objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.EmployeeId;
            if (objSalaryDTO.RoamingTypeId != "")
            {
                objOracleCommand.Parameters.Add("p_roaming_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.RoamingTypeId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_roaming_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            objOracleCommand.Parameters.Add("p_roaming_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.Date;
            objOracleCommand.Parameters.Add("p_create_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.LoginEmployee;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryDTO.BranchOfficeId;
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

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
    public class IncrementDAL
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

        public string processIncrement(IncrementDTO objIncrementDTO)
        {

            string strMsg = "";

            OracleCommand objOracleCommand = new OracleCommand("pro_increment_process_ho");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objIncrementDTO.UnitId != "")
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.UnitId;

            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;


            }
            

            if (objIncrementDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("p_increment_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.Year;

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.BranchOfficeId;
           

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
        public string incrementSetupSave(IncrementDTO objIncrementDTO)
        {

            string strMsg = "";

            OracleCommand objOracleCommand = new OracleCommand("pro_increment_setup_yearly");
            objOracleCommand.CommandType = CommandType.StoredProcedure;
            
            objOracleCommand.Parameters.Add("p_proposal_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.proposal_id;
            objOracleCommand.Parameters.Add("P_INCREMENT_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.Year;
            objOracleCommand.Parameters.Add("P_INCREMENT_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.Month;
            objOracleCommand.Parameters.Add("P_PRE_INCREMENT_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.PreIncrementYear;
            objOracleCommand.Parameters.Add("P_PRE_INCREMENT_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.PreIncrementMonth;
            objOracleCommand.Parameters.Add("P_EMPLOYEE_TYPE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.EmployeeTypeId;

            objOracleCommand.Parameters.Add("P_EFFECT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.EffectDate;
            objOracleCommand.Parameters.Add("P_LIMIT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.LimitDate;
            objOracleCommand.Parameters.Add("p_as_first_salary", OracleDbType.Int32, ParameterDirection.Input).Value = objIncrementDTO.as_first_salary;
            objOracleCommand.Parameters.Add("p_is_increment", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.Is_Increment;

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.BranchOfficeId;

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
        public string addIncrementSetupSave(IncrementDTO objIncrementDTO)
        {

            string strMsg = "";

            OracleCommand objOracleCommand = new OracleCommand("pro_inc_setup_worker_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            objOracleCommand.Parameters.Add("P_INCREMENT_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.Year;
            objOracleCommand.Parameters.Add("P_INCREMENT_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.Month;


            objOracleCommand.Parameters.Add("P_EFFECT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.EffectDate;
            objOracleCommand.Parameters.Add("P_LIMIT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.LimitDate;
            objOracleCommand.Parameters.Add("P_LOCK_YN", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.LockYn;


            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.BranchOfficeId;


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

        //public string addIncrementSetupSave(IncrementDTO objIncrementDTO)
        //{

        //    string strMsg = "";

        //    OracleCommand objOracleCommand = new OracleCommand("pro_inc_setup_worker_save");
        //    objOracleCommand.CommandType = CommandType.StoredProcedure;


        //    objOracleCommand.Parameters.Add("P_INCREMENT_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.Year;
        //    objOracleCommand.Parameters.Add("P_INCREMENT_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.Month;


        //    objOracleCommand.Parameters.Add("P_EFFECT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.EffectDate;
        //    objOracleCommand.Parameters.Add("P_LIMIT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.LimitDate;


        //    objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.UpdateBy;
        //    objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.HeadOfficeId;
        //    objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.BranchOfficeId;


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


        public string saveIncrementHO(IncrementDTO objIncrementDTO)
        {

            string strMsg = "";

            OracleCommand objOracleCommand = new OracleCommand("pro_increment_basic_info_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.EmployeeId;
            objOracleCommand.Parameters.Add("p_increment_amount", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.IncrementAmount;
            objOracleCommand.Parameters.Add("p_increment_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.Year;
          
            if (objIncrementDTO.FirstSalary != "")
            {
                objOracleCommand.Parameters.Add("P_FIRST_SALARY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.FirstSalary;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_FIRST_SALARY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objIncrementDTO.GrossSalary != "")
            {
                objOracleCommand.Parameters.Add("p_gross_salary", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.GrossSalary;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_gross_salary", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objIncrementDTO.EffectDate.Length > 6)
            {
                objOracleCommand.Parameters.Add("p_effect_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.EffectDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_effect_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.BranchOfficeId;
           
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
        public string saveIncrementProposalHO(IncrementDTO objIncrementDTO)
        {

            string strMsg = "";

            OracleCommand objOracleCommand = new OracleCommand("pro_inc_proposal_ho_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            //p_increment_type_id

            objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.EmployeeId;
            objOracleCommand.Parameters.Add("p_increment_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = Convert.ToInt32(objIncrementDTO.IncrementTypeId);

            objOracleCommand.Parameters.Add("p_increment_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.Year;

            if (objIncrementDTO.Score != "")
            {
                objOracleCommand.Parameters.Add("p_score", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.Score;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_score", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objIncrementDTO.Remarks !="")
            {
                objOracleCommand.Parameters.Add("p_remarks", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.Remarks;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_remarks", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            
            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.BranchOfficeId;
            
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
        public string saveEmployeePerformance(IncrementDTO objIncrementDTO)
        {

            string strMsg = "";

            OracleCommand objOracleCommand = new OracleCommand("pro_employee_performance_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.EmployeeId;
            objOracleCommand.Parameters.Add("p_increment_amount", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.IncrementAmount;
            objOracleCommand.Parameters.Add("p_increment_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.Year;

           
            if (objIncrementDTO.EffectDate.Length > 6)
            {
                objOracleCommand.Parameters.Add("p_effect_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.EffectDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_effect_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objIncrementDTO.Score.Length > 0)
            {
                objOracleCommand.Parameters.Add("p_performance_score", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.Score;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_performance_score", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objIncrementDTO.Remarks.Length > 0)
            {
                objOracleCommand.Parameters.Add("p_remarks", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.Remarks;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_remarks", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.BranchOfficeId;


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
        public string processIncrementOption(IncrementDTO objIncrementDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_increment_process_select");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.UnitId;

            if (objIncrementDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objIncrementDTO.IncrementTypeId != "")
            {
                objOracleCommand.Parameters.Add("p_increment_process_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.IncrementTypeId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_tiffin_process_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if(objIncrementDTO.Year != "")
            {

            objOracleCommand.Parameters.Add("p_increment_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.Year;
            }

            else
            {
                objOracleCommand.Parameters.Add("p_increment_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objIncrementDTO.Month != "")
            {
                objOracleCommand.Parameters.Add("p_increment_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.Month;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_increment_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.BranchOfficeId;


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

        public string saveIncrememntAmount(IncrementDTO objIncrementDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_increment_basic_info_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.EmployeeId;
            objOracleCommand.Parameters.Add("p_increment_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.Year;

            objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.UnitId;

            if (objIncrementDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            objOracleCommand.Parameters.Add("p_increment_amount", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.IncrementAmount;

          

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIncrementDTO.BranchOfficeId;


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


        public DataTable searchEmployeeForPerformance(IncrementDTO objIncrementDTO)
        {
            DataTable dt = new DataTable();

            string sql = "SELECT " +

                       "rownum SL, " +
                       "EMPLOYEE_ID, " +
                       "CARD_NO, " +
                       "EMPLOYEE_NAME, " +
                       "DESIGNATION_NAME, " +
                       "To_CHAR(JOINING_DATE,'dd/mm/yyyy')JOINING_DATE, " +
                       "CURR_SALARY, " +
                       "UNIT_ID, " +
                       "SECTION_ID " +


                       "from VEW_SEARCH_INCRMENT_HO where head_office_id = '" + objIncrementDTO.HeadOfficeId + "' AND branch_office_id = '" + objIncrementDTO.BranchOfficeId + "' ";


            if (objIncrementDTO.UnitId.Length > 0)
            {

                sql = sql + "and unit_id = '" + objIncrementDTO.UnitId + "'";
            }


            if (objIncrementDTO.SectionId.Length > 0)
            {

                sql = sql + "and section_id = '" + objIncrementDTO.SectionId + "'";
            }
            if (objIncrementDTO.EmployeeId.Length > 0)
            {

                sql = sql + "and employee_id = '" + objIncrementDTO.EmployeeId + "'";
            }

            if (objIncrementDTO.CardNo.Length > 0)
            {

                sql = sql + "and card_no = '" + objIncrementDTO.CardNo + "'";
            }


            sql = sql + " order by SL ";

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

        ////added on: 14.02.2022: replacing searchIncrementRecord 
        public DataTable GetIncrementProposalHO(IncrementDTO objIncrementDTO)
        {
            DataTable dt = new DataTable();

            string sql = "SELECT " +

                       "rownum SL, "+
                       "EMPLOYEE_ID, "+
                       "CARD_NO, "+
                       "EMPLOYEE_NAME, "+
                       "DESIGNATION_NAME, "+
                       "To_CHAR(JOINING_DATE,'dd/mm/yyyy')JOINING_DATE, " +
                       "CURR_SALARY, "+
                       "UNIT_ID, "+
                       "SECTION_ID " +
            "from VEW_INC_PROPOSAL_HO where head_office_id = '" + objIncrementDTO.HeadOfficeId + "' AND branch_office_id = '" + objIncrementDTO.BranchOfficeId + "' ";

            if (objIncrementDTO.Year.Length > 0)
            {
                sql = sql + " and INCREMENT_YEAR = '" + objIncrementDTO.Year + "'";
            }

            if (objIncrementDTO.UnitId.Length > 0)
            {
                sql = sql + "and unit_id = '" + objIncrementDTO.UnitId + "'";
            }
            
            if (objIncrementDTO.SectionId.Length > 0)
            {
                sql = sql + "and section_id = '" + objIncrementDTO.SectionId + "'";
            }
            if (objIncrementDTO.EmployeeId.Length > 0)
            {
                sql = sql + "and employee_id = '" + objIncrementDTO.EmployeeId + "'";
            }

            if (objIncrementDTO.CardNo.Length > 0)
            {
                sql = sql + "and card_no = '" + objIncrementDTO.CardNo + "'";
            }
            
            if (objIncrementDTO.SupervisorId.Length > 0)
            {
                sql = sql + "and SUPERVISOR_ID = '" + objIncrementDTO.SupervisorId + "'";
            }

                    sql = sql + " order by SL ";

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

        //Old- Commented on 14.02.2022
        //ENHANCE: 14.02.2022: VEW_INC_PROPOSAL_HO
        public DataTable searchIncrementRecord(IncrementDTO objIncrementDTO)
        {
            DataTable dt = new DataTable();

            string sql = "SELECT " +

                       "rownum SL, " +
                       "EMPLOYEE_ID, " +
                       "CARD_NO, " +
                       "EMPLOYEE_NAME, " +
                       "DESIGNATION_NAME, " +
                       "To_CHAR(JOINING_DATE,'dd/mm/yyyy')JOINING_DATE, " +
                       "CURR_SALARY, " +
                       "UNIT_ID, " +
                       "SECTION_ID " +


                       "from VEW_BASIC_INFO where head_office_id = '" + objIncrementDTO.HeadOfficeId + "' AND branch_office_id = '" + objIncrementDTO.BranchOfficeId + "' ";


            if (objIncrementDTO.UnitId.Length > 0)
            {

                sql = sql + "and unit_id = '" + objIncrementDTO.UnitId + "'";
            }


            if (objIncrementDTO.SectionId.Length > 0)
            {

                sql = sql + "and section_id = '" + objIncrementDTO.SectionId + "'";
            }
            if (objIncrementDTO.EmployeeId.Length > 0)
            {

                sql = sql + "and employee_id = '" + objIncrementDTO.EmployeeId + "'";
            }

            if (objIncrementDTO.CardNo.Length > 0)
            {

                sql = sql + "and card_no = '" + objIncrementDTO.CardNo + "'";
            }


            if (objIncrementDTO.SupervisorId.Length > 0)
            {

                sql = sql + "and SUPERVISOR_ID = '" + objIncrementDTO.SupervisorId + "'";
            }


            sql = sql + " order by SL ";

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

        public DataTable searchIncrementRecordWorker(IncrementDTO objIncrementDTO)
        {
            DataTable dt = new DataTable();

            string sql = "SELECT " +

                       "rownum SL, " +
                       "EMPLOYEE_ID, " +
                       "CARD_NO, " +
                       "EMPLOYEE_NAME, " +
                       "DESIGNATION_NAME, " +
                       "To_CHAR(JOINING_DATE,'dd/mm/yyyy')JOINING_DATE, " +
                       "CURR_SALARY, " +
                       "UNIT_ID, " +
                       "SECTION_ID " +


                       "from VEW_BASIC_INFO_WORKER where head_office_id = '" + objIncrementDTO.HeadOfficeId + "' AND branch_office_id = '" + objIncrementDTO.BranchOfficeId + "' ";


            if (objIncrementDTO.UnitId.Length > 0)
            {

                sql = sql + "and unit_id = '" + objIncrementDTO.UnitId + "'";
            }


            if (objIncrementDTO.SectionId.Length > 0)
            {

                sql = sql + "and section_id = '" + objIncrementDTO.SectionId + "'";
            }
            if (objIncrementDTO.EmployeeId.Length > 0)
            {

                sql = sql + "and employee_id = '" + objIncrementDTO.EmployeeId + "'";
            }

            if (objIncrementDTO.CardNo.Length > 0)
            {

                sql = sql + "and card_no = '" + objIncrementDTO.CardNo + "'";
            }


            sql = sql + " order by SL ";

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
        public DataTable searchBankSalaryEntry(IncrementDTO objIncrementDTO)
        {
            DataTable dt = new DataTable();

            string sql = "SELECT " +

                       "rownum SL, " +
                       "EMPLOYEE_ID, " +
                       "CARD_NO, " +
                       "EMPLOYEE_NAME, " +
                       "DESIGNATION_NAME, " +
                       "JOINING_DATE, " +
                       "curr_salary, "+
                       "FIRST_SALARY " +
                     

                       "from vew_search_bank_salary_entry where head_office_id = '" + objIncrementDTO.HeadOfficeId + "' AND branch_office_id = '" + objIncrementDTO.BranchOfficeId + "' and salary_year = '" + objIncrementDTO.Year + "' ";


            if (objIncrementDTO.Month.Length > 0)
            {

                sql = sql + "and salary_month = '" + objIncrementDTO.Month + "'";
            }


            if (objIncrementDTO.EmployeeId.Length > 0)
            {

                sql = sql + "and employee_id = '" + objIncrementDTO.EmployeeId + "'";
            }


            if (objIncrementDTO.UnitId.Length > 0)
            {

                sql = sql + "and unit_id = '" + objIncrementDTO.UnitId + "'";
            }

            if (objIncrementDTO.SectionId.Length > 0)
            {

                sql = sql + "and section_id = '" + objIncrementDTO.SectionId + "'";
            }
           

            sql = sql + " order by SL ";

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
        public DataTable searchEmployeeBankSalary(IncrementDTO objIncrementDTO)
        {
            DataTable dt = new DataTable();

            string sql = "SELECT " +

                       "rownum SL, " +
                       "EMPLOYEE_ID, " +
                       "CARD_NO, " +
                       "EMPLOYEE_NAME, " +
                       "DESIGNATION_NAME, " +
                       "JOINING_DATE, " +
                       "CURR_SALARY, " +
                       "FIRST_SALARY, "+
                       "UNIT_ID, " +
                       "SECTION_ID " +


                       "from VEW_SEARCH_FIRST_SALARY where head_office_id = '" + objIncrementDTO.HeadOfficeId + "' AND branch_office_id = '" + objIncrementDTO.BranchOfficeId + "' ";


            if (objIncrementDTO.UnitId.Length > 0)
            {

                sql = sql + "and unit_id = '" + objIncrementDTO.UnitId + "'";
            }


            if (objIncrementDTO.SectionId.Length > 0)
            {

                sql = sql + "and section_id = '" + objIncrementDTO.SectionId + "'";
            }
            if (objIncrementDTO.EmployeeId.Length > 0)
            {

                sql = sql + "and employee_id = '" + objIncrementDTO.EmployeeId + "'";
            }

            if (objIncrementDTO.CardNo.Length > 0)
            {

                sql = sql + "and card_no = '" + objIncrementDTO.CardNo + "'";
            }


            sql = sql + " order by SL ";

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
        public DataTable searchEmployeePerformanceEntry(IncrementDTO objIncrementDTO)
        {
            DataTable dt = new DataTable();

            string sql = "SELECT " +

                       "rownum SL, " +
                       "EMPLOYEE_ID, " +
                       "CARD_NO, " +
                       "EMPLOYEE_NAME, " +
                       "DESIGNATION_NAME, " +
                       "PERFORMANCE_SCORE, "+
                       "INCREMENT_AMOUNT, " +
                       "TO_CHAR(EFFECT_DATE, 'DD/MM/YYYY')EFFECT_DATE, " +
                       "TO_CHAR(JOINING_DATE, 'DD/MM/YYYY')JOINING_DATE, " +
                       "REMARKS "+



                       "from VEW_SEARCH_PERFORMANCE_ENTRY where head_office_id = '" + objIncrementDTO.HeadOfficeId + "' AND branch_office_id = '" + objIncrementDTO.BranchOfficeId + "' AND increment_year = '" + objIncrementDTO.Year + "'  ";


            if (objIncrementDTO.UnitId.Length > 0)
            {

                sql = sql + "and unit_id = '" + objIncrementDTO.UnitId + "'";
            }


            if (objIncrementDTO.SectionId.Length > 0)
            {

                sql = sql + "and section_id = '" + objIncrementDTO.SectionId + "'";
            }


            sql = sql + " order by SL ";

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
        public DataTable searchIncrementEntryHO(IncrementDTO objIncrementDTO)
        {
            DataTable dt = new DataTable();

            string sql = "SELECT " +

                       "rownum SL, " +
                       "EMPLOYEE_ID, " +
                       "CARD_NO, " +
                       "EMPLOYEE_NAME, " +
                       "DESIGNATION_NAME, " +
                       "INCREMENT_AMOUNT, "+
                       "FIRST_SALARY, "+
                       "TO_CHAR(JOINING_DATE, 'DD/MM/YYYY') JOINING_DATE, " +
                       "TO_CHAR(EFFECT_DATE, 'DD/MM/YYYY') EFFECT_DATE " +
                       "from vew_search_increment_amount where head_office_id = '" + objIncrementDTO.HeadOfficeId + "' AND branch_office_id = '" + objIncrementDTO.BranchOfficeId + "' AND increment_year = '" + objIncrementDTO .Year+ "'  ";
            
            if (objIncrementDTO.UnitId.Length > 0)
            {

                sql = sql + "and unit_id = '" + objIncrementDTO.UnitId + "'";
            }


            if (objIncrementDTO.SectionId.Length > 0)
            {

                sql = sql + "and section_id = '" + objIncrementDTO.SectionId + "'";
            }

            if (objIncrementDTO.EmployeeId.Length > 0)
            {

                sql = sql + "and employee_id = '" + objIncrementDTO.EmployeeId + "'";
            }

            if (objIncrementDTO.CardNo.Length > 0)
            {

                sql = sql + "and card_no = '" + objIncrementDTO.CardNo + "'";
            }

           

            sql = sql + " order by SL ";

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
        public DataTable searchIncrementProposalHO(IncrementDTO objIncrementDTO)
        {
            DataTable dt = new DataTable();

            string sql = "SELECT " +

                       "rownum SL, " +
                       "EMPLOYEE_ID, " +
                       "CARD_NO, " +
                       "EMPLOYEE_NAME, " +
                       "DESIGNATION_NAME, " +
                       "SCORE, " +
                       "REMARKS, " +
                       "GROSS_SALARY, " +
                       "increment_type_id, " +
                       "increment_type_name " +
                       //"from vew_search_inc_proposal_ho where head_office_id = '" + objIncrementDTO.HeadOfficeId + "' AND branch_office_id = '" + objIncrementDTO.BranchOfficeId + "' AND increment_year = '" + objIncrementDTO.Year + "' AND increment_type_id = nvl('" + objIncrementDTO.IncrementTypeId + "', increment_type_id) ";
                       "from vew_search_inc_proposal_ho where head_office_id = '" + objIncrementDTO.HeadOfficeId + "' AND branch_office_id = '" + objIncrementDTO.BranchOfficeId + "' AND increment_year = '" + objIncrementDTO.Year + "'"; // AND increment_type_id = nvl('" + objIncrementDTO.IncrementTypeId + "', increment_type_id) ";

            if(!string.IsNullOrEmpty(objIncrementDTO.IncrementTypeId))
            {
                sql = sql + " AND increment_type_id = '" + objIncrementDTO.IncrementTypeId + "'";
            }

            if (objIncrementDTO.UnitId.Length > 0)
            {
                sql = sql + " and unit_id = '" + objIncrementDTO.UnitId + "'";
            }
            if (objIncrementDTO.SectionId.Length > 0)
            {
                sql = sql + "and section_id = '" + objIncrementDTO.SectionId + "'";
            }
            if (objIncrementDTO.EmployeeId.Length > 0)
            {
                sql = sql + "and employee_id = '" + objIncrementDTO.EmployeeId + "'";
            }
            if (objIncrementDTO.CardNo.Length > 0)
            {
                sql = sql + "and card_no = '" + objIncrementDTO.CardNo + "'";
            }
            sql = sql + " order by SL ";
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

        public DataTable searchIncrementProposalHO2(IncrementDTO objIncrementDTO)
        {
            DataTable dt = new DataTable();

            string sql = "SELECT " +

                       "rownum SL, " +
                       "EMPLOYEE_ID, " +
                       "CARD_NO, " +
                       "EMPLOYEE_NAME, " +
                       "DESIGNATION_NAME, " +
                       "SCORE, " +
                       "REMARKS, " +
                       "GROSS_SALARY, " +
                       "increment_type_id, " +
                       "increment_type_name " +
                       //"from vew_search_inc_proposal_ho where head_office_id = '" + objIncrementDTO.HeadOfficeId + "' AND branch_office_id = '" + objIncrementDTO.BranchOfficeId + "' AND increment_year = '" + objIncrementDTO.Year + "' AND increment_type_id = nvl('" + objIncrementDTO.IncrementTypeId + "', increment_type_id) ";
                       "from vew_search_inc_proposal_ho where head_office_id = '" + objIncrementDTO.HeadOfficeId + "' AND branch_office_id = '" + objIncrementDTO.BranchOfficeId + "' AND increment_year = '" + objIncrementDTO.Year + "'";
            if (objIncrementDTO.UnitId.Length > 0)
            {
                sql = sql + "and unit_id = '" + objIncrementDTO.UnitId + "'";
            }
            if (objIncrementDTO.SectionId.Length > 0)
            {
                sql = sql + "and section_id = '" + objIncrementDTO.SectionId + "'";
            }
            if (objIncrementDTO.EmployeeId.Length > 0)
            {
                sql = sql + "and employee_id = '" + objIncrementDTO.EmployeeId + "'";
            }

            if (objIncrementDTO.CardNo.Length > 0)
            {
                sql = sql + "and card_no = '" + objIncrementDTO.CardNo + "'";
            }
            sql = sql + " order by SL ";

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

        public IncrementDTO searchIncrementInfo(string strEmployeeId, string strHeadOfficeId)
        {
            IncrementDTO objIncrementDTO = new IncrementDTO();
            string sql = "SELECT " +
                         "EMPLOYEE_NAME, " +
                         "CARD_NO, " +
                         "DESIGNATION_NAME, " +
                         "EMPLOYEE_ID " +

                         "FROM vew_search_increment_worker " +
                         "WHERE EMPLOYEE_ID = '" + strEmployeeId + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "'";


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

                        objIncrementDTO.EmployeeName = objDataReader.GetString(0);
                        objIncrementDTO.CardNo = objDataReader.GetString(1);
                        objIncrementDTO.DesignationName = objDataReader.GetString(2);
                        objIncrementDTO.EmployeeId = objDataReader.GetString(3);

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

            return objIncrementDTO;
        }


        public IncrementDTO searchMaxGrossSalary(string strEmployeeId, string strIncrementYear, string strHeadOfficeId, string strBranchOfficeId)
        {
            IncrementDTO objIncrementDTO = new IncrementDTO();


            string sql = "SELECT " +
                        "to_char(nvl(TOTAL_SALARY, '0')) " +

                        "FROM EMPLOYEE_INCREMENT " +
                        "WHERE EMPLOYEE_ID = '" + strEmployeeId + "' AND INCREMENT_YEAR = '"+strIncrementYear+"' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "' ";


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

                        objIncrementDTO.GrossSalary = objDataReader.GetString(0);


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


            return objIncrementDTO;
        }
        public IncrementDTO searchGrossSalaryForIncrement(string strEmployeeId, string strIncrementYear, string strHeadOfficeId, string strBranchOfficeId)
        {
            IncrementDTO objIncrementDTO = new IncrementDTO();


            string sql = "SELECT " +
                        "to_char(nvl(GROSS_SALARY, '0')), " +
                         "to_char(nvl(first_salary_current, '0'))" +
                         
                        "FROM INCREMENT_BASIC_INFO_ADD_HO " +
                        "WHERE EMPLOYEE_ID = '" + strEmployeeId + "' AND INCREMENT_YEAR = '" + strIncrementYear + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "'";


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
                        objIncrementDTO.GrossSalary = objDataReader.GetString(0);
                        objIncrementDTO.FirstSalaryCurrent = objDataReader.GetString(1);
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


            return objIncrementDTO;
        }
        public IncrementDTO searchIncrementAmountInfo(string strEmployeeId, string strIncrementYear, string strHeadOfficeId, string strBranchOfficeId)
        {
            IncrementDTO objIncrementDTO = new IncrementDTO();
          

            string sql = "SELECT " +
                        "to_char(nvl(INCREMENT_AMOUNT, '0')), " +
                        "to_char(nvl(FIRST_SALARY, '0')), " +
                        "NVL (TO_CHAR (EFFECT_DATE, 'dd/mm/yyyy'), ' ') " +
                      


                        "FROM VEW_SEARCH_INCREMENT_AMOUNT " +
                        "WHERE EMPLOYEE_ID = '" + strEmployeeId + "' AND INCREMENT_YEAR = '" + strIncrementYear + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "'";


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

                        objIncrementDTO.IncrementAmount = objDataReader.GetString(0);
                        objIncrementDTO.FirstSalary = objDataReader.GetString(1);
                        objIncrementDTO.EffectDate = objDataReader.GetString(2);
                       
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

           
            return objIncrementDTO;
        }
        public IncrementDTO searchIncrementProposalInfoHO(string strEmployeeId, string strIncrementYear, string strHeadOfficeId, string strBranchOfficeId)
        {
            IncrementDTO objIncrementDTO = new IncrementDTO();


            string sql = "SELECT " +
                        "to_char(nvl(SCORE, '0')), " +
                        "to_char(nvl(REMARKS, 'N/A')), " +
                        "to_char(nvl(GROSS_SALARY, '0')), " +
                        "to_char(nvl(increment_type_id, '0')) " +
                        "FROM vew_search_inc_proposal_ho " +
                        "WHERE EMPLOYEE_ID = '" + strEmployeeId + "' AND INCREMENT_YEAR = '" + strIncrementYear + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "'";


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

                        objIncrementDTO.Score = objDataReader.GetString(0);
                        objIncrementDTO.Remarks = objDataReader.GetString(1);
                        objIncrementDTO.GrossSalary = objDataReader.GetString(2);
                        objIncrementDTO.IncrementTypeId = objDataReader.GetString(3);
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


            return objIncrementDTO;
        }
        public IncrementDTO searchPerformanceRecord(string strEmployeeId, string strIncrementYear, string strHeadOfficeId, string strBranchOfficeId)
        {
            IncrementDTO objIncrementDTO = new IncrementDTO();


            string sql = "SELECT " +
                        "to_char(nvl(INCREMENT_AMOUNT, '0')), " +
                        "to_char(nvl(PERFORMANCE_SCORE, '0')), " +
                        "NVL (TO_CHAR (EFFECT_DATE, 'dd/mm/yyyy'), ' '), " +
                        "to_char(nvl(REMARKS, 'N/A')) " +

                        "FROM VEW_SEARCH_PERFORMANCE_ENTRY " +
                        "WHERE EMPLOYEE_ID = '" + strEmployeeId + "' AND INCREMENT_YEAR = '" + strIncrementYear + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "'";


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

                        objIncrementDTO.IncrementAmount = objDataReader.GetString(0);
                        objIncrementDTO.Score = objDataReader.GetString(1);
                        objIncrementDTO.EffectDate = objDataReader.GetString(2);
                        objIncrementDTO.Remarks = objDataReader.GetString(3);
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


            return objIncrementDTO;
        }

    }
}

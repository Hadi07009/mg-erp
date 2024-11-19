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
    public class TiffinDAL
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

        public string procesTiffin(TiffinDTO objTiffinDTO)
        {
            string strMsg = "";

            OracleCommand objOracleCommand = new OracleCommand("pro_tiffin_process");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.UnitId;

            if (objTiffinDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
                
           
            objOracleCommand.Parameters.Add("p_bonus_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.Year;
            objOracleCommand.Parameters.Add("p_bonus_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.Month;
          
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.UpdateBy;

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

                }

                finally
                {

                    strConn.Close();
                }

            }
            return strMsg;
        

        }
        public string saveTiffinInfo(TiffinDTO objTiffinDTO)
        {
            string strMsg = "";

            OracleCommand objOracleCommand = new OracleCommand("PRO_TIFFIN_BASIC_INFO_WORKER");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.EmployeeId;

            if (objTiffinDTO.UnitId != "")
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.UnitId;

            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objTiffinDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            objOracleCommand.Parameters.Add("P_TIFFIN_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.Year;
            objOracleCommand.Parameters.Add("P_TIFFIN_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.Month;
            if (objTiffinDTO.TiffinDay != "")
            {
                objOracleCommand.Parameters.Add("P_TIFFIN_DAY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.TiffinDay;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_TIFFIN_DAY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objTiffinDTO.TiffinAmount != "")
            {
                objOracleCommand.Parameters.Add("P_TIFFIN_AMOUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.TiffinAmount;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_TIFFIN_AMOUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objTiffinDTO.T_Day != "")
            {
                objOracleCommand.Parameters.Add("P_T_TIFFIN_DAY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.T_Day;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_T_TIFFIN_DAY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objTiffinDTO.I_Day != "")
            {
                objOracleCommand.Parameters.Add("P_I_TIFFIN_DAY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.I_Day;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_I_TIFFIN_DAY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            //if (objTiffinDTO.TiffinDayAdditional != "")
            //{
            //    objOracleCommand.Parameters.Add("p_tiffin_day_additional", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.TiffinDayAdditional;
            //}
            //else
            //{
            //    objOracleCommand.Parameters.Add("p_tiffin_day_additional", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            //}

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.BranchOfficeId;
           

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

        public string saveNightInfo(TiffinDTO objTiffinDTO)
        {
            string strMsg = "";

            OracleCommand objOracleCommand = new OracleCommand("PRO_TIFFIN_BASIC_INFO_WORKER");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.EmployeeId;

            if (objTiffinDTO.UnitId != "")
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.UnitId;

            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objTiffinDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            objOracleCommand.Parameters.Add("P_TIFFIN_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.Year;
            objOracleCommand.Parameters.Add("P_TIFFIN_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.Month;
            if (objTiffinDTO.FromDate.Length > 6)
            {
                objOracleCommand.Parameters.Add("p_from_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.FromDate;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_from_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objTiffinDTO.TiffinDay != "")
            {
                objOracleCommand.Parameters.Add("P_TIFFIN_DAY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.TiffinDay;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_TIFFIN_DAY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objTiffinDTO.TiffinAmount != "")
            {
                objOracleCommand.Parameters.Add("P_TIFFIN_AMOUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.TiffinAmount;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_TIFFIN_AMOUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objTiffinDTO.T_Day != "")
            {
                objOracleCommand.Parameters.Add("P_T_TIFFIN_DAY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.T_Day;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_T_TIFFIN_DAY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objTiffinDTO.I_Day != "")
            {
                objOracleCommand.Parameters.Add("P_I_TIFFIN_DAY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.I_Day;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_I_TIFFIN_DAY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            //if (objTiffinDTO.TiffinDayAdditional != "")
            //{
            //    objOracleCommand.Parameters.Add("p_tiffin_day_additional", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.TiffinDayAdditional;
            //}
            //else
            //{
            //    objOracleCommand.Parameters.Add("p_tiffin_day_additional", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            //}

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.BranchOfficeId;


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
        public string monthlyDayForTiffin(TiffinDTO objTiffinDTO)
        {
            string strMsg = "";

            OracleCommand objOracleCommand = new OracleCommand("pro_monthly_wday_calc_tiffin");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objTiffinDTO.UnitGroupId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_group_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.UnitGroupId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_group_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objTiffinDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.UnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objTiffinDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.Year;
            objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.Month;
           

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.BranchOfficeId;


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

        public string monthlyDayForNightBill(TiffinDTO objTiffinDTO)
        {
            string strMsg = "";

            OracleCommand objOracleCommand = new OracleCommand("pro_monthly_wday_calc_night");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objTiffinDTO.UnitGroupId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_group_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.UnitGroupId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_group_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objTiffinDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.UnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objTiffinDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.Year;
            objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.Month;
            if (objTiffinDTO.FromDate.Length > 6)
            {
                objOracleCommand.Parameters.Add("p_from_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.FromDate;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_from_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.BranchOfficeId;


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

        public string monthlyDayForTiffinStaff(TiffinDTO objTiffinDTO)
        {
            string strMsg = "";

            OracleCommand objOracleCommand = new OracleCommand("pro_monthly_wday_calc_t_n_s_f");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objTiffinDTO.UnitGroupId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_group_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.UnitGroupId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_group_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objTiffinDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.UnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objTiffinDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.Year;
            objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.Month;


            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.BranchOfficeId;


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

        public string monthlyDayForNightBillStaff(TiffinDTO objTiffinDTO)
        {
            string strMsg = "";

            OracleCommand objOracleCommand = new OracleCommand("pro_monthly_wday_calc_n_b_s");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objTiffinDTO.UnitGroupId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_group_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.UnitGroupId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_group_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objTiffinDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.UnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objTiffinDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.Year;
            objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.Month;
            if (objTiffinDTO.FromDate.Length > 6)
            {
                objOracleCommand.Parameters.Add("p_from_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.FromDate;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_from_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.BranchOfficeId;


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
        public string saveWorkerIncrementProposal(TiffinDTO objTiffinDTO)
        {
            string strMsg = "";

            OracleCommand objOracleCommand = new OracleCommand("pro_inc_proposal_worker_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.EmployeeId;

            if (objTiffinDTO.UnitId != "")
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.UnitId;

            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objTiffinDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            objOracleCommand.Parameters.Add("P_INCREMENT_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.Year;
            objOracleCommand.Parameters.Add("P_INCREMENT_AMOUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.IncrementAmount;
            

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.BranchOfficeId;


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

                }

                finally
                {

                    strConn.Close();
                }

            }
            return strMsg;


        }
        public string processIncrementProposal(TiffinDTO objTiffinDTO)
        {
            string strMsg = "";

            OracleCommand objOracleCommand = new OracleCommand("pro_increment_proposal_worker");
            objOracleCommand.CommandType = CommandType.StoredProcedure;
         
            if (objTiffinDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.UnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objTiffinDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.SectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objTiffinDTO.UnitGroupId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_group_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.UnitGroupId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_group_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            objOracleCommand.Parameters.Add("P_INCREMENT_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.Year;
            objOracleCommand.Parameters.Add("P_INCREMENT_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.Month;
            objOracleCommand.Parameters.Add("p_allow_general_incr", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.AllowGeneralIncrement;
            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.BranchOfficeId;
                      

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
        public string processIncrementProposalAll(TiffinDTO objTiffinDTO)
        {
            string strMsg = "";

            OracleCommand objOracleCommand = new OracleCommand("pro_inc_proposal_worker_all");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            if (objTiffinDTO.UnitId != "")
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.UnitId;

            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objTiffinDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            objOracleCommand.Parameters.Add("P_INCREMENT_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.Year;



            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.BranchOfficeId;


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
        public string processIncrementProposalStaff(TiffinDTO objTiffinDTO)
        {
            string strMsg = "";

            OracleCommand objOracleCommand = new OracleCommand("pro_increment_proposal_staff");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            if (objTiffinDTO.UnitId != "")
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.UnitId;

            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objTiffinDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objTiffinDTO.UnitGroupId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_group_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.UnitGroupId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_group_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            objOracleCommand.Parameters.Add("P_INCREMENT_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.Year;
            objOracleCommand.Parameters.Add("P_INCREMENT_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.Month;
            objOracleCommand.Parameters.Add("p_allow_general_incr", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.AllowGeneralIncrement;


            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.BranchOfficeId;


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
        public string processIncrementProposalSummery(TiffinDTO objTiffinDTO)
        {
            string strMsg = "";

            OracleCommand objOracleCommand = new OracleCommand("pro_inc_proposal_summery");
            objOracleCommand.CommandType = CommandType.StoredProcedure;
            

            if (objTiffinDTO.UnitId != "")
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.UnitId;

            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objTiffinDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            objOracleCommand.Parameters.Add("P_INCREMENT_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.Year;



            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.BranchOfficeId;


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
        public string processMonthlyIncrementProposalWorkerSummery(TiffinDTO objTiffinDTO)
        {
            string strMsg = "";

            OracleCommand objOracleCommand = new OracleCommand("pro_inc_monthly_process_worker");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            if (objTiffinDTO.UnitId != "")
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.UnitId;

            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objTiffinDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            objOracleCommand.Parameters.Add("P_INCREMENT_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.Year;
            if (objTiffinDTO.Month != "")
            {
                objOracleCommand.Parameters.Add("p_increment_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.Month;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_increment_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.BranchOfficeId;


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
        public string processIncrementProposalSummeryStaff(TiffinDTO objTiffinDTO)
        {
            string strMsg = "";

            OracleCommand objOracleCommand = new OracleCommand("pro_inc_proposal_summery_staff");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            if (objTiffinDTO.UnitId != "")
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.UnitId;

            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objTiffinDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            objOracleCommand.Parameters.Add("P_INCREMENT_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.Year;



            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.BranchOfficeId;


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
        public string processTiffinOption(TiffinDTO objTiffinDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_tiffin_process_select");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.UnitId;

            if (objTiffinDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

           
            objOracleCommand.Parameters.Add("p_tiffin_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.Year;
            if (objTiffinDTO.Month != "")
            {
                objOracleCommand.Parameters.Add("p_tiffin_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.Month;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.BranchOfficeId;


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
        public DataTable searchEmployeeRecordforTiffin(TiffinDTO objTiffinDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
                   "rownum sl, " +
                   "CARD_NO, " +
                   "EMPLOYEE_ID, " +
                   "EMPLOYEE_NAME, " +
                   "DESIGNATION_NAME " +


                  "FROM VEW_SEARCH_WORKER_INFO J WHERE head_office_id = '" + objTiffinDTO.HeadOfficeId + "' AND branch_office_id = '" + objTiffinDTO.BranchOfficeId + "' ";

            if (objTiffinDTO.EmployeeId.Length > 0)
            {
                sql = sql + "and employee_id = '" + objTiffinDTO.EmployeeId + "'";
            }

            if (objTiffinDTO.CardNo.Length > 0)
            {
                sql = sql + "and card_no = '" + objTiffinDTO.CardNo + "'";
            }

            if (objTiffinDTO.SectionId.Length > 0)
            {
                sql = sql + "and section_id = '" + objTiffinDTO.SectionId + "'";
            }

            if (objTiffinDTO.UnitId.Length > 0)
            {
                sql = sql + "and unit_id = '" + objTiffinDTO.UnitId + "'";
            }
            //Asad added on 07.08.2022
            //sql = sql +
            //" AND EXISTS(SELECT 1 FROM MONTHLY_SALARY M WHERE M.EMPLOYEE_ID = J.EMPLOYEE_ID AND M.SALARY_YEAR ='" + objTiffinDTO.Year + "' " +
            //" AND M.SALARY_MONTH = '" + objTiffinDTO.Month + "' " +
            //" AND M.BRANCH_OFFICE_ID = '" + objTiffinDTO.BranchOfficeId + "') ";

            sql = sql + "order by SL ";

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
        public DataTable searchEmployeeRecordforIncrementProposal(TiffinDTO objTiffinDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
                   "rownum sl, " +
                   "CARD_NO, " +
                   "EMPLOYEE_ID, " +
                   "EMPLOYEE_NAME, " +
                   "DESIGNATION_NAME " +


                  "FROM VEW_SEARCH_WORKER_PROPOSAL WHERE head_office_id = '" + objTiffinDTO.HeadOfficeId + "' AND branch_office_id = '" + objTiffinDTO.BranchOfficeId + "' ";

            if (objTiffinDTO.EmployeeId.Length > 0)
            {

                sql = sql + "and employee_id = '" + objTiffinDTO.EmployeeId + "'";
            }

            if (objTiffinDTO.CardNo.Length > 0)
            {

                sql = sql + "and card_no = '" + objTiffinDTO.CardNo + "'";
            }


            if (objTiffinDTO.SectionId.Length > 0)
            {

                sql = sql + "and section_id = '" + objTiffinDTO.SectionId + "'";
            }

            if (objTiffinDTO.UnitId.Length > 0)
            {

                sql = sql + "and unit_id = '" + objTiffinDTO.UnitId + "'";
            }

            sql = sql + "order by SL ";

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
        public DataTable searchEmployeeRecordforIncrementProposalStaff(TiffinDTO objTiffinDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
                   "rownum sl, " +
                   "CARD_NO, " +
                   "EMPLOYEE_ID, " +
                   "EMPLOYEE_NAME, " +
                   "DESIGNATION_NAME " +
                  "FROM VEW_SEARCH_STAFF_PROPOSAL WHERE head_office_id = '" + objTiffinDTO.HeadOfficeId + "' AND branch_office_id = '" + objTiffinDTO.BranchOfficeId + "' ";
            //Asad added this condition
            if (objTiffinDTO.BranchOfficeId == "110")
            {
                sql = sql + " and joining_date <= to_date( '31/12/" + (Convert.ToInt32(objTiffinDTO.Year) - 1).ToString() + "'," + "'dd/mm/yyyy') ";
            }

            if (objTiffinDTO.EmployeeId.Length > 0)
            {
                sql = sql + " and employee_id = '" + objTiffinDTO.EmployeeId + "'";
            }

            if (objTiffinDTO.CardNo.Length > 0)
            {
                sql = sql + "and card_no = '" + objTiffinDTO.CardNo + "'";
            }
            if (objTiffinDTO.SectionId.Length > 0)
            {
                sql = sql + "and section_id = '" + objTiffinDTO.SectionId + "'";
            }

            if (objTiffinDTO.UnitId.Length > 0)
            {
                sql = sql + "and unit_id = '" + objTiffinDTO.UnitId + "'";
            }
            sql = sql + "order by SL ";
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
        public DataTable searchTiffinEntry(TiffinDTO objTiffinDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
                   "rownum sl, " +
                   "CARD_NO, " +
                   "EMPLOYEE_ID, " +
                   "EMPLOYEE_NAME, " +
                   "DESIGNATION_NAME, " +
                   "TIFFIN_DAY "+
                   //'"tiffin_day_additional " +

                  "FROM vew_search_tiffin_entry WHERE head_office_id = '" + objTiffinDTO.HeadOfficeId + "' AND branch_office_id = '" + objTiffinDTO.BranchOfficeId + "' AND tiffin_year = '" + objTiffinDTO.Year + "'  AND tiffin_month = '" + objTiffinDTO.Month + "' ";

            if (objTiffinDTO.UnitGroupId.Length > 0)
            {

                sql = sql + " and unit_group_id = '" + objTiffinDTO.UnitGroupId + "'";
            }

            if (objTiffinDTO.SectionId.Length > 0)
            {

                sql = sql + " and section_id = '" + objTiffinDTO.SectionId + "'";
            }

            if (objTiffinDTO.UnitId.Length > 0)
            {

                sql = sql + " and unit_id = '" + objTiffinDTO.UnitId + "'";
            }

            sql = sql + "order by SL ";

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

        public DataTable searchNightBillEntry(TiffinDTO objTiffinDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
                   "rownum sl, " +
                   "CARD_NO, " +
                   "EMPLOYEE_ID, " +
                   "EMPLOYEE_NAME, " +
                   "DESIGNATION_NAME, " +
                   "TIFFIN_DAY " +
                  //'"tiffin_day_additional " +

                  "FROM VEW_SEARCH_NIGHT_BILL_ENTRY WHERE head_office_id = '" + objTiffinDTO.HeadOfficeId + "' AND branch_office_id = '" + objTiffinDTO.BranchOfficeId + "' AND tiffin_year = '" + objTiffinDTO.Year + "'  AND tiffin_month = '" + objTiffinDTO.Month + "' " + " AND LOG_DATE = TO_DATE('"+ objTiffinDTO .FromDate+ "', 'DD/MM/YYYY')";

            if (objTiffinDTO.UnitGroupId.Length > 0)
            {

                sql = sql + " and unit_group_id = '" + objTiffinDTO.UnitGroupId + "'";
            }

            if (objTiffinDTO.SectionId.Length > 0)
            {

                sql = sql + " and section_id = '" + objTiffinDTO.SectionId + "'";
            }

            if (objTiffinDTO.UnitId.Length > 0)
            {

                sql = sql + " and unit_id = '" + objTiffinDTO.UnitId + "'";
            }

            sql = sql + "order by SL ";

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
        public DataTable searchIncrementProposalEntry(TiffinDTO objTiffinDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
                   "rownum sl, " +
                   "CARD_NO, " +
                   "EMPLOYEE_ID, " +
                   "EMPLOYEE_NAME, " +
                   "DESIGNATION_NAME, " +
                   "TO_CHAR(JOINING_DATE, 'dd/mm/yyyy')JOINING_DATE, "+
                   "TOTAL_YEAR, " +
                   "TOTAL_MONTH, "+
                   "GROSS_SALARY, "+
                   "TOTAL_5_PERCENT " +
                  //FINALIZED_YN
                  "FROM VEW_SEARCH_INC_PROSAL_WORKER WHERE head_office_id = '" + objTiffinDTO.HeadOfficeId + "' AND branch_office_id = '" + objTiffinDTO.BranchOfficeId + "' AND INCREMENT_YEAR = '" + objTiffinDTO.Year + "'  ";
                        
            //COMMENTED ON 21.12.2021
            ////added on 29.12.2019: actually should be: TOTAL_MONTH >= 12
            //if (objTiffinDTO.BranchOfficeId == "110")
            //{
            //    sql = sql + "and TOTAL_MONTH >= 12 ";
            //}
            //else
            //{
            //    sql = sql + "and TOTAL_MONTH > 12 ";
            //}

            if (objTiffinDTO.SectionId.Length > 0)
            {

                sql = sql + " and section_id = '" + objTiffinDTO.SectionId + "'";
            }

            if (objTiffinDTO.UnitId.Length > 0)
            {

                sql = sql + " and unit_id = '" + objTiffinDTO.UnitId + "'";
            }

            sql = sql + "order by SL ";

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
        public DataTable searchIncrementProposalEntryAll(TiffinDTO objTiffinDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
                   "rownum sl, " +
                   "CARD_NO, " +
                   "EMPLOYEE_ID, " +
                   "EMPLOYEE_NAME, " +
                   "DESIGNATION_NAME, " +
                   "TO_CHAR(JOINING_DATE, 'dd/mm/yyyy')JOINING_DATE, " +
                   "TOTAL_YEAR, " +
                   "TOTAL_MONTH, " +
                   "GROSS_SALARY " +

                  "FROM VEW_INC_PROSAL_WORKER_ALL WHERE head_office_id = '" + objTiffinDTO.HeadOfficeId + "' AND branch_office_id = '" + objTiffinDTO.BranchOfficeId + "' AND INCREMENT_YEAR = '" + objTiffinDTO.Year + "'  ";




            //if (objTiffinDTO.EmployeeId.Length > 0)
            //{

            //    sql = sql + "and employee_id = '" + objTiffinDTO.EmployeeId + "'";
            //}

            //if (objTiffinDTO.CardNo.Length > 0)
            //{

            //    sql = sql + "and card_no = '" + objTiffinDTO.CardNo + "'";
            //}

            if (objTiffinDTO.SectionId.Length > 0)
            {

                sql = sql + " and section_id = '" + objTiffinDTO.SectionId + "'";
            }

            if (objTiffinDTO.UnitId.Length > 0)
            {

                sql = sql + " and unit_id = '" + objTiffinDTO.UnitId + "'";
            }

            sql = sql + "order by SL ";

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
        public DataTable searchIncrementProposalEntryStaff(TiffinDTO objTiffinDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
                   "rownum sl, " +
                   "CARD_NO, " +
                   "EMPLOYEE_ID, " +
                   "EMPLOYEE_NAME, " +
                   "DESIGNATION_NAME, " +
                   "TO_CHAR(JOINING_DATE, 'dd/mm/yyyy')JOINING_DATE, " +
                   "TOTAL_YEAR, "+
                   "TOTAL_MONTH, "+
                   "GROSS_SALARY "+

                  "FROM VEW_SEARCH_INC_PROSAL_STAFF WHERE head_office_id = '" + objTiffinDTO.HeadOfficeId + "' AND branch_office_id = '" + objTiffinDTO.BranchOfficeId + "' AND INCREMENT_YEAR = '" + objTiffinDTO.Year + "'  ";
            
            if (objTiffinDTO.SectionId.Length > 0)
            {

                sql = sql + " and section_id = '" + objTiffinDTO.SectionId + "'";
            }

            if (objTiffinDTO.UnitId.Length > 0)
            {

                sql = sql + " and unit_id = '" + objTiffinDTO.UnitId + "'";
            }

            sql = sql + "order by SL ";

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
        public DataTable searchWorkerPromotionEntry(TiffinDTO objTiffinDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            if (objTiffinDTO.HeadOfficeId == "331" || objTiffinDTO.BranchOfficeId == "103")
            {


                if (objTiffinDTO.UnitId == "37")
                {

                    sql = "SELECT " +
                           "rownum sl, " +
                           "CARD_NO, " +
                           "EMPLOYEE_ID, " +
                           "EMPLOYEE_NAME, " +
                           "designation_name, " +
                           "GROSS_SALARY, " +
                           "GRADE_NO " +

                          "FROM vew_worker_promotion WHERE head_office_id = '" + objTiffinDTO.HeadOfficeId + "' AND branch_office_id = '" + objTiffinDTO.BranchOfficeId + "' AND PROMOTION_YEAR = '" + objTiffinDTO.Year + "'  and unit_id in  ('37', '38', '39', '40', '41', '42', '49', '93', '130') and promotion_month = '" + objTiffinDTO.Month + "' ";

                }

                if (objTiffinDTO.UnitId == "43")
                {

                    sql = "SELECT " +
                           "rownum sl, " +
                           "CARD_NO, " +
                           "EMPLOYEE_ID, " +
                           "EMPLOYEE_NAME, " +
                           "designation_name, " +
                           "GROSS_SALARY, " +
                           "GRADE_NO " +

                          "FROM vew_worker_promotion WHERE head_office_id = '" + objTiffinDTO.HeadOfficeId + "' AND branch_office_id = '" + objTiffinDTO.BranchOfficeId + "' AND PROMOTION_YEAR = '" + objTiffinDTO.Year + "'  and unit_id IN('43', '44',  '45', '46', '47', '48','50','90','94') and promotion_month = '" + objTiffinDTO.Month + "'";

                }

                if (objTiffinDTO.UnitId == "52")
                {

                    sql = "SELECT " +
                           "rownum sl, " +
                           "CARD_NO, " +
                           "EMPLOYEE_ID, " +
                           "EMPLOYEE_NAME, " +
                           "designation_name, " +
                           "GROSS_SALARY, " +
                           "GRADE_NO " +

                          "FROM vew_worker_promotion WHERE head_office_id = '" + objTiffinDTO.HeadOfficeId + "' AND branch_office_id = '" + objTiffinDTO.BranchOfficeId + "' AND PROMOTION_YEAR = '" + objTiffinDTO.Year + "'  and unit_id IN ('52', '53', '54', '55', '56', '57', '51', '95') and promotion_month = '" + objTiffinDTO.Month + "' ";

                }

                if (objTiffinDTO.UnitId == "58")
                {

                    sql = "SELECT " +
                           "rownum sl, " +
                           "CARD_NO, " +
                           "EMPLOYEE_ID, " +
                           "EMPLOYEE_NAME, " +
                           "designation_name, " +
                           "GROSS_SALARY, " +
                           "GRADE_NO " +

                          "FROM vew_worker_promotion WHERE head_office_id = '" + objTiffinDTO.HeadOfficeId + "' AND branch_office_id = '" + objTiffinDTO.BranchOfficeId + "' AND PROMOTION_YEAR = '" + objTiffinDTO.Year + "'  and unit_id IN ('58', '59') and promotion_month = '" + objTiffinDTO.Month + "'";

                }

                if (objTiffinDTO.UnitId == "102")
                {

                    sql = "SELECT " +
                           "rownum sl, " +
                           "CARD_NO, " +
                           "EMPLOYEE_ID, " +
                           "EMPLOYEE_NAME, " +
                           "designation_name, " +
                           "GROSS_SALARY, " +
                           "GRADE_NO " +

                          "FROM vew_worker_promotion WHERE head_office_id = '" + objTiffinDTO.HeadOfficeId + "' AND branch_office_id = '" + objTiffinDTO.BranchOfficeId + "' AND PROMOTION_YEAR = '" + objTiffinDTO.Year + "'  and unit_id IN ('96', '97', '98', '99', '100', '101', '102', '103', '131') and promotion_month = '" + objTiffinDTO.Month + "'";

                }



                //if (objTiffinDTO.EmployeeId.Length > 0)
                //{

                //    sql = sql + "and employee_id = '" + objTiffinDTO.EmployeeId + "'";
                //}

                //if (objTiffinDTO.CardNo.Length > 0)
                //{

                //    sql = sql + "and card_no = '" + objTiffinDTO.CardNo + "'";
                //}

                //if (objTiffinDTO.SectionId.Length > 0)
                //{

                //    sql = sql + " and section_id = '" + objTiffinDTO.SectionId + "'";
                //}

                //if (objTiffinDTO.UnitId.Length > 0)
                //{

                //    sql = sql + " and unit_id = '" + objTiffinDTO.UnitId + "'";
                //}


            }
            else if(objTiffinDTO.HeadOfficeId == "331" && objTiffinDTO.BranchOfficeId == "102")
            {

                if (objTiffinDTO.UnitId == "1")
                {

                    sql = "SELECT " +
                           "rownum sl, " +
                           "CARD_NO, " +
                           "EMPLOYEE_ID, " +
                           "EMPLOYEE_NAME, " +
                           "designation_name, " +
                           "GROSS_SALARY, " +
                           "GRADE_NO " +

                          "FROM vew_worker_promotion WHERE head_office_id = '" + objTiffinDTO.HeadOfficeId + "' AND branch_office_id = '" + objTiffinDTO.BranchOfficeId + "' AND PROMOTION_YEAR = '" + objTiffinDTO.Year + "'  and unit_id IN ('96', '97', '98', '99', '100', '101', '102', '103', '131') and promotion_month = '" + objTiffinDTO.Month + "'";

                }

                if (objTiffinDTO.UnitId == "6")
                {

                    sql = "SELECT " +
                           "rownum sl, " +
                           "CARD_NO, " +
                           "EMPLOYEE_ID, " +
                           "EMPLOYEE_NAME, " +
                           "designation_name, " +
                           "GROSS_SALARY, " +
                           "GRADE_NO " +

                          "FROM vew_worker_promotion WHERE head_office_id = '" + objTiffinDTO.HeadOfficeId + "' AND branch_office_id = '" + objTiffinDTO.BranchOfficeId + "' AND PROMOTION_YEAR = '" + objTiffinDTO.Year + "'  and unit_id IN('6','7','8','9','10','11','78','79','80','81','82','83', '84', '85','86','87','88','89')  and promotion_month = '" + objTiffinDTO.Month + "'";

                }

            }

            else
            {

                sql = "SELECT " +
                        "rownum sl, " +
                        "CARD_NO, " +
                        "EMPLOYEE_ID, " +
                        "EMPLOYEE_NAME, " +
                        "designation_name, " +
                        "GROSS_SALARY, " +
                        "GRADE_NO " +

                       "FROM vew_worker_promotion WHERE head_office_id = '" + objTiffinDTO.HeadOfficeId + "' AND branch_office_id = '" + objTiffinDTO.BranchOfficeId + "' AND PROMOTION_YEAR = '" + objTiffinDTO.Year + "'  and promotion_month = '" + objTiffinDTO.Month + "'";

                if (objTiffinDTO.SectionId.Length > 0)
                {

                    sql = sql + " and section_id = '" + objTiffinDTO.SectionId + "'";
                }

                if (objTiffinDTO.UnitId.Length > 0)
                {

                    sql = sql + " and unit_id = '" + objTiffinDTO.UnitId + "'";
                }

            }
            sql = sql + "order by SL ";

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
        public DataTable searchEmployeePromotionEntry(TiffinDTO objTiffinDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";


            if (objTiffinDTO.HeadOfficeId == "331" && objTiffinDTO.BranchOfficeId == "103")
            {

                if (objTiffinDTO.UnitId == "37")
                {

                    sql = "SELECT " +
                           "rownum sl, " +
                           "CARD_NO, " +
                           "EMPLOYEE_ID, " +
                           "EMPLOYEE_NAME, " +
                           "designation_name, " +
                           "GROSS_SALARY, " +
                           "GRADE_NO " +

                          "FROM VEW_EMPLOYEE_PROMOTION WHERE head_office_id = '" + objTiffinDTO.HeadOfficeId + "' AND branch_office_id = '" + objTiffinDTO.BranchOfficeId + "' AND PROMOTION_YEAR = '" + objTiffinDTO.Year + "'  and unit_id in  ('37', '38', '39', '40', '41', '42', '49', '93', '130') and promotion_month = '" + objTiffinDTO.Month + "' ";

                }

                if (objTiffinDTO.UnitId == "43")
                {

                    sql = "SELECT " +
                           "rownum sl, " +
                           "CARD_NO, " +
                           "EMPLOYEE_ID, " +
                           "EMPLOYEE_NAME, " +
                           "designation_name, " +
                           "GROSS_SALARY, " +
                           "GRADE_NO " +

                          "FROM VEW_EMPLOYEE_PROMOTION WHERE head_office_id = '" + objTiffinDTO.HeadOfficeId + "' AND branch_office_id = '" + objTiffinDTO.BranchOfficeId + "' AND PROMOTION_YEAR = '" + objTiffinDTO.Year + "'  and unit_id IN('43', '44',  '45', '46', '47', '48','50','90','94') and promotion_month = '" + objTiffinDTO.Month + "'";

                }

                if (objTiffinDTO.UnitId == "52")
                {

                    sql = "SELECT " +
                           "rownum sl, " +
                           "CARD_NO, " +
                           "EMPLOYEE_ID, " +
                           "EMPLOYEE_NAME, " +
                           "designation_name, " +
                           "GROSS_SALARY, " +
                           "GRADE_NO " +

                          "FROM VEW_EMPLOYEE_PROMOTION WHERE head_office_id = '" + objTiffinDTO.HeadOfficeId + "' AND branch_office_id = '" + objTiffinDTO.BranchOfficeId + "' AND PROMOTION_YEAR = '" + objTiffinDTO.Year + "'  and unit_id IN ('52', '53', '54', '55', '56', '57', '51', '95') and promotion_month = '" + objTiffinDTO.Month + "' ";

                }

                if (objTiffinDTO.UnitId == "58")
                {

                    sql = "SELECT " +
                           "rownum sl, " +
                           "CARD_NO, " +
                           "EMPLOYEE_ID, " +
                           "EMPLOYEE_NAME, " +
                           "designation_name, " +
                           "GROSS_SALARY, " +
                           "GRADE_NO " +

                          "FROM VEW_EMPLOYEE_PROMOTION WHERE head_office_id = '" + objTiffinDTO.HeadOfficeId + "' AND branch_office_id = '" + objTiffinDTO.BranchOfficeId + "' AND PROMOTION_YEAR = '" + objTiffinDTO.Year + "'  and unit_id IN ('58', '59') and promotion_month = '" + objTiffinDTO.Month + "'";

                }

                if (objTiffinDTO.UnitId == "102")
                {

                    sql = "SELECT " +
                           "rownum sl, " +
                           "CARD_NO, " +
                           "EMPLOYEE_ID, " +
                           "EMPLOYEE_NAME, " +
                           "designation_name, " +
                           "GROSS_SALARY, " +
                           "GRADE_NO " +

                          "FROM VEW_EMPLOYEE_PROMOTION WHERE head_office_id = '" + objTiffinDTO.HeadOfficeId + "' AND branch_office_id = '" + objTiffinDTO.BranchOfficeId + "' AND PROMOTION_YEAR = '" + objTiffinDTO.Year + "'  and unit_id IN ('96', '97', '98', '99', '100', '101', '102', '103', '131') and promotion_month = '" + objTiffinDTO.Month + "'";

                }



                //if (objTiffinDTO.EmployeeId.Length > 0)
                //{

                //    sql = sql + "and employee_id = '" + objTiffinDTO.EmployeeId + "'";
                //}

                //if (objTiffinDTO.CardNo.Length > 0)
                //{

                //    sql = sql + "and card_no = '" + objTiffinDTO.CardNo + "'";
                //}

                //if (objTiffinDTO.SectionId.Length > 0)
                //{

                //    sql = sql + " and section_id = '" + objTiffinDTO.SectionId + "'";
                //}

                //if (objTiffinDTO.UnitId.Length > 0)
                //{

                //    sql = sql + " and unit_id = '" + objTiffinDTO.UnitId + "'";
                //}


            }

            else if (objTiffinDTO.HeadOfficeId == "331" || objTiffinDTO.BranchOfficeId == "101")
            {


                if (objTiffinDTO.UnitId == "1")
                {

                    sql = "SELECT " +
                           "rownum sl, " +
                           "CARD_NO, " +
                           "EMPLOYEE_ID, " +
                           "EMPLOYEE_NAME, " +
                           "designation_name, " +
                           "GROSS_SALARY, " +
                           "GRADE_NO " +

                          "FROM VEW_EMPLOYEE_PROMOTION WHERE head_office_id = '" + objTiffinDTO.HeadOfficeId + "' AND branch_office_id = '" + objTiffinDTO.BranchOfficeId + "' AND PROMOTION_YEAR = '" + objTiffinDTO.Year + "'  and unit_id IN ('1', '2','3', '4','5','69','70','71', '72', '74','75','76','77') and promotion_month = '" + objTiffinDTO.Month + "'";

                }

                if (objTiffinDTO.UnitId == "6")
                {

                    sql = "SELECT " +
                           "rownum sl, " +
                           "CARD_NO, " +
                           "EMPLOYEE_ID, " +
                           "EMPLOYEE_NAME, " +
                           "designation_name, " +
                           "GROSS_SALARY, " +
                           "GRADE_NO " +

                          "FROM VEW_EMPLOYEE_PROMOTION WHERE head_office_id = '" + objTiffinDTO.HeadOfficeId + "' AND branch_office_id = '" + objTiffinDTO.BranchOfficeId + "' AND PROMOTION_YEAR = '" + objTiffinDTO.Year + "'  and  unit_id IN ('6','7','8','9','10','11','78','79','80','81','82','83', '84', '85','86','87','88','89') and promotion_month = '" + objTiffinDTO.Month + "'";

                }






            }

            else
            {


                sql = "SELECT " +
                          "rownum sl, " +
                          "CARD_NO, " +
                          "EMPLOYEE_ID, " +
                          "EMPLOYEE_NAME, " +
                          "designation_name, " +
                          "GROSS_SALARY, " +
                          "GRADE_NO " +

                         "FROM VEW_EMPLOYEE_PROMOTION WHERE head_office_id = '" + objTiffinDTO.HeadOfficeId + "' AND branch_office_id = '" + objTiffinDTO.BranchOfficeId + "' AND PROMOTION_YEAR = '" + objTiffinDTO.Year + "'  and promotion_month = '" + objTiffinDTO.Month + "'";

                if (objTiffinDTO.SectionId.Length > 0)
                {

                    sql = sql + " and section_id = '" + objTiffinDTO.SectionId + "'";
                }

                if (objTiffinDTO.UnitId.Length > 0)
                {

                    sql = sql + " and unit_id = '" + objTiffinDTO.UnitId + "'";
                }

            }
            sql = sql + "order by SL ";

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
        public DataTable searchWorkerPromotion(TiffinDTO objTiffinDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            if (objTiffinDTO.HeadOfficeId == "331" && objTiffinDTO.BranchOfficeId == "103")
            {

                if (objTiffinDTO.UnitId == "37")
                {

                    sql = "SELECT " +
                           "rownum sl, " +
                           "CARD_NO, " +
                           "EMPLOYEE_ID, " +
                           "EMPLOYEE_NAME, " +
                           "designation_name " +


                          "FROM VEW_DESIGNATION_PROMOTION WHERE head_office_id = '" + objTiffinDTO.HeadOfficeId + "' AND branch_office_id = '" + objTiffinDTO.BranchOfficeId + "' AND TOTAL_MONTH = '6' and unit_id in  ('37', '38', '39', '40', '41', '42', '49', '93', '130')";


                    //if (objTiffinDTO.SectionId.Length > 0)
                    //{

                    //    sql = sql + " and section_id = '" + objTiffinDTO.SectionId + "'";
                    //}


                    sql = sql + "order by SL ";
                }

                if (objTiffinDTO.UnitId == "43")
                {

                    sql = "SELECT " +
                           "rownum sl, " +
                           "CARD_NO, " +
                           "EMPLOYEE_ID, " +
                           "EMPLOYEE_NAME, " +
                           "designation_name " +


                          "FROM VEW_DESIGNATION_PROMOTION WHERE head_office_id = '" + objTiffinDTO.HeadOfficeId + "' AND branch_office_id = '" + objTiffinDTO.BranchOfficeId + "' AND TOTAL_MONTH = '6' and unit_id IN('43', '44',  '45', '46', '47', '48','50','90','94') ";


                    //if (objTiffinDTO.SectionId.Length > 0)
                    //{

                    //    sql = sql + " and section_id = '" + objTiffinDTO.SectionId + "'";
                    //}

                    sql = sql + "order by SL ";

                }

                if (objTiffinDTO.UnitId == "52")
                {

                    sql = "SELECT " +
                           "rownum sl, " +
                           "CARD_NO, " +
                           "EMPLOYEE_ID, " +
                           "EMPLOYEE_NAME, " +
                           "designation_name " +


                          "FROM VEW_DESIGNATION_PROMOTION WHERE head_office_id = '" + objTiffinDTO.HeadOfficeId + "' AND branch_office_id = '" + objTiffinDTO.BranchOfficeId + "' AND TOTAL_MONTH = '6' and  unit_id IN ('52', '53', '54', '55', '56', '57', '51', '95')";


                    //if (objTiffinDTO.SectionId.Length > 0)
                    //{

                    //    sql = sql + " and section_id = '" + objTiffinDTO.SectionId + "'";
                    //}
                    sql = sql + "order by SL ";
                }


                if (objTiffinDTO.UnitId == "58")
                {

                    sql = "SELECT " +
                           "rownum sl, " +
                           "CARD_NO, " +
                           "EMPLOYEE_ID, " +
                           "EMPLOYEE_NAME, " +
                           "designation_name " +


                          "FROM VEW_DESIGNATION_PROMOTION WHERE head_office_id = '" + objTiffinDTO.HeadOfficeId + "' AND branch_office_id = '" + objTiffinDTO.BranchOfficeId + "' AND TOTAL_MONTH = '6' and   unit_id IN ('58', '59') ";


                    //if (objTiffinDTO.SectionId.Length > 0)
                    //{

                    //    sql = sql + " and section_id = '" + objTiffinDTO.SectionId + "'";
                    //}
                    sql = sql + "order by SL ";

                }


                if (objTiffinDTO.UnitId == "102")
                {

                    sql = "SELECT " +
                           "rownum sl, " +
                           "CARD_NO, " +
                           "EMPLOYEE_ID, " +
                           "EMPLOYEE_NAME, " +
                           "designation_name " +


                          "FROM VEW_DESIGNATION_PROMOTION WHERE head_office_id = '" + objTiffinDTO.HeadOfficeId + "' AND branch_office_id = '" + objTiffinDTO.BranchOfficeId + "' AND TOTAL_MONTH = '6' and    unit_id IN ('96', '97', '98', '99', '100', '101', '102', '103', '131') ";


                    //if (objTiffinDTO.SectionId.Length > 0)
                    //{

                    //    sql = sql + " and section_id = '" + objTiffinDTO.SectionId + "'";
                    //}

                    sql = sql + "order by SL ";
                }





            }

            else if (objTiffinDTO.HeadOfficeId == "331" && objTiffinDTO.BranchOfficeId == "102")
            {
                if (objTiffinDTO.UnitId == "1")
                {

                    sql = "SELECT " +
                           "rownum sl, " +
                           "CARD_NO, " +
                           "EMPLOYEE_ID, " +
                           "EMPLOYEE_NAME, " +
                           "designation_name " +


                          "FROM VEW_DESIGNATION_PROMOTION WHERE head_office_id = '" + objTiffinDTO.HeadOfficeId + "' AND branch_office_id = '" + objTiffinDTO.BranchOfficeId + "' AND TOTAL_MONTH = '6' and    unit_id IN ('1', '2','3', '4','5','69','70','71', '72', '74','75','76','77') ";


                    //if (objTiffinDTO.SectionId.Length > 0)
                    //{

                    //    sql = sql + " and section_id = '" + objTiffinDTO.SectionId + "'";
                    //}

                    sql = sql + "order by SL ";
                }


                if (objTiffinDTO.UnitId == "6")
                {

                    sql = "SELECT " +
                           "rownum sl, " +
                           "CARD_NO, " +
                           "EMPLOYEE_ID, " +
                           "EMPLOYEE_NAME, " +
                           "designation_name " +


                          "FROM VEW_DESIGNATION_PROMOTION WHERE head_office_id = '" + objTiffinDTO.HeadOfficeId + "' AND branch_office_id = '" + objTiffinDTO.BranchOfficeId + "' AND TOTAL_MONTH = '6' and   unit_id IN('6','7','8','9','10','11','78','79','80','81','82','83', '84', '85','86','87','88','89') ";


                    //if (objTiffinDTO.SectionId.Length > 0)
                    //{

                    //    sql = sql + " and section_id = '" + objTiffinDTO.SectionId + "'";
                    //}

                    sql = sql + "order by SL ";
                }

            }

            else if (objTiffinDTO.HeadOfficeId == "331" && objTiffinDTO.BranchOfficeId == "101")
            {
                if (objTiffinDTO.UnitId == "17")
                {

                    sql = "SELECT " +
                           "rownum sl, " +
                           "CARD_NO, " +
                           "EMPLOYEE_ID, " +
                           "EMPLOYEE_NAME, " +
                           "designation_name " +


                          "FROM VEW_DESIGNATION_PROMOTION WHERE head_office_id = '" + objTiffinDTO.HeadOfficeId + "' AND branch_office_id = '" + objTiffinDTO.BranchOfficeId + "' AND TOTAL_MONTH = '6' and  UNIT_ID IN ('17', '18', '22') ";


                    //if (objTiffinDTO.SectionId.Length > 0)
                    //{

                    //    sql = sql + " and section_id = '" + objTiffinDTO.SectionId + "'";
                    //}

                    sql = sql + "order by SL ";
                }


                if (objTiffinDTO.UnitId == "19")
                {

                    sql = "SELECT " +
                           "rownum sl, " +
                           "CARD_NO, " +
                           "EMPLOYEE_ID, " +
                           "EMPLOYEE_NAME, " +
                           "designation_name " +


                          "FROM VEW_DESIGNATION_PROMOTION WHERE head_office_id = '" + objTiffinDTO.HeadOfficeId + "' AND branch_office_id = '" + objTiffinDTO.BranchOfficeId + "' AND TOTAL_MONTH = '6' and UNIT_ID IN ('19', '24', '25', '23') ";


                    //if (objTiffinDTO.SectionId.Length > 0)
                    //{

                    //    sql = sql + " and section_id = '" + objTiffinDTO.SectionId + "'";
                    //}

                    sql = sql + "order by SL ";
                }

                if (objTiffinDTO.UnitId == "26")
                {

                    sql = "SELECT " +
                           "rownum sl, " +
                           "CARD_NO, " +
                           "EMPLOYEE_ID, " +
                           "EMPLOYEE_NAME, " +
                           "designation_name " +


                          "FROM VEW_DESIGNATION_PROMOTION WHERE head_office_id = '" + objTiffinDTO.HeadOfficeId + "' AND branch_office_id = '" + objTiffinDTO.BranchOfficeId + "' AND TOTAL_MONTH = '6' and UNIT_ID IN ('26', '27', '28') ";


                    //if (objTiffinDTO.SectionId.Length > 0)
                    //{

                    //    sql = sql + " and section_id = '" + objTiffinDTO.SectionId + "'";
                    //}

                    sql = sql + "order by SL ";
                }


                if (objTiffinDTO.UnitId == "12")
                {

                    sql = "SELECT " +
                           "rownum sl, " +
                           "CARD_NO, " +
                           "EMPLOYEE_ID, " +
                           "EMPLOYEE_NAME, " +
                           "designation_name " +


                          "FROM VEW_DESIGNATION_PROMOTION WHERE head_office_id = '" + objTiffinDTO.HeadOfficeId + "' AND branch_office_id = '" + objTiffinDTO.BranchOfficeId + "' AND TOTAL_MONTH = '6' and UNIT_ID IN ('12', '13') ";


                    //if (objTiffinDTO.SectionId.Length > 0)
                    //{

                    //    sql = sql + " and section_id = '" + objTiffinDTO.SectionId + "'";
                    //}

                    sql = sql + "order by SL ";
                }


                if (objTiffinDTO.UnitId == "15")
                {

                    sql = "SELECT " +
                           "rownum sl, " +
                           "CARD_NO, " +
                           "EMPLOYEE_ID, " +
                           "EMPLOYEE_NAME, " +
                           "designation_name " +


                          "FROM VEW_DESIGNATION_PROMOTION WHERE head_office_id = '" + objTiffinDTO.HeadOfficeId + "' AND branch_office_id = '" + objTiffinDTO.BranchOfficeId + "' AND TOTAL_MONTH = '6' and  UNIT_ID IN ('15', '16', '20', '21', '30', '31')";


                    //if (objTiffinDTO.SectionId.Length > 0)
                    //{

                    //    sql = sql + " and section_id = '" + objTiffinDTO.SectionId + "'";
                    //}

                    sql = sql + "order by SL ";
                }


                if (objTiffinDTO.UnitId == "14")
                {

                    sql = "SELECT " +
                           "rownum sl, " +
                           "CARD_NO, " +
                           "EMPLOYEE_ID, " +
                           "EMPLOYEE_NAME, " +
                           "designation_name " +


                          "FROM VEW_DESIGNATION_PROMOTION WHERE head_office_id = '" + objTiffinDTO.HeadOfficeId + "' AND branch_office_id = '" + objTiffinDTO.BranchOfficeId + "' AND TOTAL_MONTH = '6' and   UNIT_ID IN ('14', '29', '32', '33', '34', '35', '36', '60') ";


                    //if (objTiffinDTO.SectionId.Length > 0)
                    //{

                    //    sql = sql + " and section_id = '" + objTiffinDTO.SectionId + "'";
                    //}

                    sql = sql + "order by SL ";
                }





            }


            else
            {

                sql = "SELECT " +
                           "rownum sl, " +
                           "CARD_NO, " +
                           "EMPLOYEE_ID, " +
                           "EMPLOYEE_NAME, " +
                           "designation_name " +


                          "FROM VEW_DESIGNATION_PROMOTION WHERE head_office_id = '" + objTiffinDTO.HeadOfficeId + "' AND branch_office_id = '" + objTiffinDTO.BranchOfficeId + "' AND TOTAL_MONTH = '6' ";



                if (objTiffinDTO.UnitId.Length > 0)
                {

                    sql = sql + " and unit_id = '" + objTiffinDTO.UnitId + "'";
                }

                if (objTiffinDTO.SectionId.Length > 0)
                {

                    sql = sql + " and section_id = '" + objTiffinDTO.SectionId + "'";
                }

                sql = sql + "order by SL ";


            }

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
        public DataTable searchEmployeePromotion(TiffinDTO objTiffinDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            if (objTiffinDTO.HeadOfficeId == "331" && objTiffinDTO.BranchOfficeId == "103")
            {

                if (objTiffinDTO.UnitId == "37")
                {

                    sql = "SELECT " +
                           "rownum sl, " +
                           "CARD_NO, " +
                           "EMPLOYEE_ID, " +
                           "EMPLOYEE_NAME, " +
                           "designation_name " +


                          "FROM VEW_EMPLOYEE_PROMOTION_BY_DATE WHERE head_office_id = '" + objTiffinDTO.HeadOfficeId + "' AND branch_office_id = '" + objTiffinDTO.BranchOfficeId + "' AND  unit_id in  ('37', '38', '39', '40', '41', '42', '49', '93', '130') AND joining_date between to_date('" + objTiffinDTO.FromDate + "', 'dd/mm/yyyy') and  to_date('" + objTiffinDTO.ToDate + "', 'dd/mm/yyyy') ";


                    //if (objTiffinDTO.SectionId.Length > 0)
                    //{

                    //    sql = sql + " and section_id = '" + objTiffinDTO.SectionId + "'";
                    //}


                    sql = sql + "order by SL ";
                }

                if (objTiffinDTO.UnitId == "43")
                {

                    sql = "SELECT " +
                           "rownum sl, " +
                           "CARD_NO, " +
                           "EMPLOYEE_ID, " +
                           "EMPLOYEE_NAME, " +
                           "designation_name " +


                          "FROM VEW_EMPLOYEE_PROMOTION_BY_DATE WHERE head_office_id = '" + objTiffinDTO.HeadOfficeId + "' AND branch_office_id = '" + objTiffinDTO.BranchOfficeId + "' AND  unit_id IN('43', '44',  '45', '46', '47', '48','50','90','94') AND joining_date between to_date('" + objTiffinDTO.FromDate + "', 'dd/mm/yyyy') and  to_date('" + objTiffinDTO.ToDate + "', 'dd/mm/yyyy') ";


                    //if (objTiffinDTO.SectionId.Length > 0)
                    //{

                    //    sql = sql + " and section_id = '" + objTiffinDTO.SectionId + "'";
                    //}

                    sql = sql + "order by SL ";

                }

                if (objTiffinDTO.UnitId == "52")
                {

                    sql = "SELECT " +
                           "rownum sl, " +
                           "CARD_NO, " +
                           "EMPLOYEE_ID, " +
                           "EMPLOYEE_NAME, " +
                           "designation_name " +


                          "FROM VEW_EMPLOYEE_PROMOTION_BY_DATE WHERE head_office_id = '" + objTiffinDTO.HeadOfficeId + "' AND branch_office_id = '" + objTiffinDTO.BranchOfficeId + "' AND   unit_id IN ('52', '53', '54', '55', '56', '57', '51', '95') AND joining_date between to_date('" + objTiffinDTO.FromDate + "', 'dd/mm/yyyy') and  to_date('" + objTiffinDTO.ToDate + "', 'dd/mm/yyyy') ";


                    //if (objTiffinDTO.SectionId.Length > 0)
                    //{

                    //    sql = sql + " and section_id = '" + objTiffinDTO.SectionId + "'";
                    //}
                    sql = sql + "order by SL ";
                }


                if (objTiffinDTO.UnitId == "58")
                {

                    sql = "SELECT " +
                           "rownum sl, " +
                           "CARD_NO, " +
                           "EMPLOYEE_ID, " +
                           "EMPLOYEE_NAME, " +
                           "designation_name " +


                          "FROM VEW_EMPLOYEE_PROMOTION_BY_DATE WHERE head_office_id = '" + objTiffinDTO.HeadOfficeId + "' AND branch_office_id = '" + objTiffinDTO.BranchOfficeId + "' AND   unit_id IN ('58', '59') AND joining_date between to_date('" + objTiffinDTO.FromDate + "', 'dd/mm/yyyy') and  to_date('" + objTiffinDTO.ToDate + "', 'dd/mm/yyyy')";


                    //if (objTiffinDTO.SectionId.Length > 0)
                    //{

                    //    sql = sql + " and section_id = '" + objTiffinDTO.SectionId + "'";
                    //}
                    sql = sql + "order by SL ";

                }


                if (objTiffinDTO.UnitId == "102")
                {

                    sql = "SELECT " +
                           "rownum sl, " +
                           "CARD_NO, " +
                           "EMPLOYEE_ID, " +
                           "EMPLOYEE_NAME, " +
                           "designation_name " +


                          "FROM VEW_EMPLOYEE_PROMOTION_BY_DATE WHERE head_office_id = '" + objTiffinDTO.HeadOfficeId + "' AND branch_office_id = '" + objTiffinDTO.BranchOfficeId + "' AND unit_id IN ('96', '97', '98', '99', '100', '101', '102', '103', '131') AND joining_date between to_date('" + objTiffinDTO.FromDate + "', 'dd/mm/yyyy') and  to_date('" + objTiffinDTO.ToDate + "', 'dd/mm/yyyy') ";


                    //if (objTiffinDTO.SectionId.Length > 0)
                    //{

                    //    sql = sql + " and section_id = '" + objTiffinDTO.SectionId + "'";
                    //}

                    sql = sql + "order by SL ";
                }





            }

            else if (objTiffinDTO.HeadOfficeId == "331" && objTiffinDTO.BranchOfficeId == "102")
            {

                if (objTiffinDTO.UnitId == "1")
                {

                    sql = "SELECT " +
                              "rownum sl, " +
                              "CARD_NO, " +
                              "EMPLOYEE_ID, " +
                              "EMPLOYEE_NAME, " +
                              "designation_name " +


                             "FROM VEW_EMPLOYEE_PROMOTION_BY_DATE WHERE head_office_id = '" + objTiffinDTO.HeadOfficeId + "' AND branch_office_id = '" + objTiffinDTO.BranchOfficeId + "' AND  unit_id IN ('1', '2','3', '4','5','69','70','71', '72', '74','75','76','77') AND joining_date between to_date('" + objTiffinDTO.FromDate + "', 'dd/mm/yyyy') and  to_date('" + objTiffinDTO.ToDate + "', 'dd/mm/yyyy') ";



                }

                if (objTiffinDTO.UnitId == "6")
                {

                    sql = "SELECT " +
                              "rownum sl, " +
                              "CARD_NO, " +
                              "EMPLOYEE_ID, " +
                              "EMPLOYEE_NAME, " +
                              "designation_name " +


                             "FROM VEW_EMPLOYEE_PROMOTION_BY_DATE WHERE head_office_id = '" + objTiffinDTO.HeadOfficeId + "' AND branch_office_id = '" + objTiffinDTO.BranchOfficeId + "' AND  unit_id IN('6','7','8','9','10','11','78','79','80','81','82','83', '84', '85','86','87','88','89') AND joining_date between to_date('" + objTiffinDTO.FromDate + "', 'dd/mm/yyyy') and  to_date('" + objTiffinDTO.ToDate + "', 'dd/mm/yyyy') ";



                }

            }


            else if (objTiffinDTO.HeadOfficeId == "331" && objTiffinDTO.BranchOfficeId == "101")
            {

                if (objTiffinDTO.UnitId == "17")
                {

                    sql = "SELECT " +
                              "rownum sl, " +
                              "CARD_NO, " +
                              "EMPLOYEE_ID, " +
                              "EMPLOYEE_NAME, " +
                              "designation_name " +


                             "FROM VEW_EMPLOYEE_PROMOTION_BY_DATE WHERE head_office_id = '" + objTiffinDTO.HeadOfficeId + "' AND branch_office_id = '" + objTiffinDTO.BranchOfficeId + "' AND  UNIT_ID IN ('17', '18', '22') AND joining_date between to_date('" + objTiffinDTO.FromDate + "', 'dd/mm/yyyy') and  to_date('" + objTiffinDTO.ToDate + "', 'dd/mm/yyyy') ";



                }

                if (objTiffinDTO.UnitId == "19")
                {

                    sql = "SELECT " +
                              "rownum sl, " +
                              "CARD_NO, " +
                              "EMPLOYEE_ID, " +
                              "EMPLOYEE_NAME, " +
                              "designation_name " +


                             "FROM VEW_EMPLOYEE_PROMOTION_BY_DATE WHERE head_office_id = '" + objTiffinDTO.HeadOfficeId + "' AND branch_office_id = '" + objTiffinDTO.BranchOfficeId + "' AND   UNIT_ID IN ('19', '24', '25', '23') AND joining_date between to_date('" + objTiffinDTO.FromDate + "', 'dd/mm/yyyy') and  to_date('" + objTiffinDTO.ToDate + "', 'dd/mm/yyyy') ";



                }


                if (objTiffinDTO.UnitId == "26")
                {

                    sql = "SELECT " +
                              "rownum sl, " +
                              "CARD_NO, " +
                              "EMPLOYEE_ID, " +
                              "EMPLOYEE_NAME, " +
                              "designation_name " +


                             "FROM VEW_EMPLOYEE_PROMOTION_BY_DATE WHERE head_office_id = '" + objTiffinDTO.HeadOfficeId + "' AND branch_office_id = '" + objTiffinDTO.BranchOfficeId + "' AND    UNIT_ID IN ('26', '27', '28') AND joining_date between to_date('" + objTiffinDTO.FromDate + "', 'dd/mm/yyyy') and  to_date('" + objTiffinDTO.ToDate + "', 'dd/mm/yyyy') ";



                }


                if (objTiffinDTO.UnitId == "12")
                {

                    sql = "SELECT " +
                              "rownum sl, " +
                              "CARD_NO, " +
                              "EMPLOYEE_ID, " +
                              "EMPLOYEE_NAME, " +
                              "designation_name " +


                             "FROM VEW_EMPLOYEE_PROMOTION_BY_DATE WHERE head_office_id = '" + objTiffinDTO.HeadOfficeId + "' AND branch_office_id = '" + objTiffinDTO.BranchOfficeId + "' AND  UNIT_ID IN ('12', '13') AND joining_date between to_date('" + objTiffinDTO.FromDate + "', 'dd/mm/yyyy') and  to_date('" + objTiffinDTO.ToDate + "', 'dd/mm/yyyy') ";



                }

                if (objTiffinDTO.UnitId == "15")
                {

                    sql = "SELECT " +
                              "rownum sl, " +
                              "CARD_NO, " +
                              "EMPLOYEE_ID, " +
                              "EMPLOYEE_NAME, " +
                              "designation_name " +


                             "FROM VEW_EMPLOYEE_PROMOTION_BY_DATE WHERE head_office_id = '" + objTiffinDTO.HeadOfficeId + "' AND branch_office_id = '" + objTiffinDTO.BranchOfficeId + "' AND  UNIT_ID IN ('15', '16', '20', '21', '30', '31') AND joining_date between to_date('" + objTiffinDTO.FromDate + "', 'dd/mm/yyyy') and  to_date('" + objTiffinDTO.ToDate + "', 'dd/mm/yyyy') ";



                }


                if (objTiffinDTO.UnitId == "14")
                {

                    sql = "SELECT " +
                              "rownum sl, " +
                              "CARD_NO, " +
                              "EMPLOYEE_ID, " +
                              "EMPLOYEE_NAME, " +
                              "designation_name " +


                             "FROM VEW_EMPLOYEE_PROMOTION_BY_DATE WHERE head_office_id = '" + objTiffinDTO.HeadOfficeId + "' AND branch_office_id = '" + objTiffinDTO.BranchOfficeId + "' AND  UNIT_ID IN  ('14', '29', '32', '33', '34', '35', '36', '60') AND joining_date between to_date('" + objTiffinDTO.FromDate + "', 'dd/mm/yyyy') and  to_date('" + objTiffinDTO.ToDate + "', 'dd/mm/yyyy') ";



                }


            }

            else
            {

                sql = "SELECT " +
                          "rownum sl, " +
                          "CARD_NO, " +
                          "EMPLOYEE_ID, " +
                          "EMPLOYEE_NAME, " +
                          "designation_name " +


                         "FROM VEW_EMPLOYEE_PROMOTION_BY_DATE WHERE head_office_id = '" + objTiffinDTO.HeadOfficeId + "' AND branch_office_id = '" + objTiffinDTO.BranchOfficeId + "' AND joining_date between to_date('" + objTiffinDTO.FromDate + "', 'dd/mm/yyyy') and  to_date('" + objTiffinDTO.ToDate + "', 'dd/mm/yyyy') ";



                if (objTiffinDTO.UnitId.Length > 0)
                {

                    sql = sql + " and unit_id = '" + objTiffinDTO.UnitId + "'";
                }

                if (objTiffinDTO.SectionId.Length > 0)
                {

                    sql = sql + " and section_id = '" + objTiffinDTO.SectionId + "'";
                }

                sql = sql + "order by SL ";


            }

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
        public TiffinDTO getTiffinDay(string strEmployeeId, string strYear, string strMonth, string strHeadOfficeId, string strBranchOfficeId)
        {

            TiffinDTO objTiffinDTO = new TiffinDTO();
            string sql = "";
            sql = "SELECT " +

                  "to_char(nvl(TIFFIN_DAY, '')) " +


                  "FROM vew_search_tiffin_entry WHERE HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID ='" + strBranchOfficeId + "' AND employee_id = '" + strEmployeeId + "' " +
                  " AND tiffin_year = '"+strYear+"' AND tiffin_month = '"+strMonth+"' ";




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

                        objTiffinDTO.TiffinDay = objDataReader.GetString(0);


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



          
            return objTiffinDTO;

        }

        public TiffinDTO getNightDay(string strEmployeeId, string strYear, string strMonth, string strHeadOfficeId, string strBranchOfficeId, string nightDate)
        {

            TiffinDTO objTiffinDTO = new TiffinDTO();
            string sql = "";
            sql = "SELECT " +

                  "to_char(nvl(TIFFIN_DAY, '')) " +


                  "FROM VEW_SEARCH_NIGHT_BILL_ENTRY WHERE HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID ='" + strBranchOfficeId + "' AND employee_id = '" + strEmployeeId + "' " +
                  " AND tiffin_year = '" + strYear + "' AND tiffin_month = '" + strMonth + "' " + " AND LOG_DATE = TO_DATE("+ nightDate + ", 'DD/MM/YYYY')";




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

                        objTiffinDTO.TiffinDay = objDataReader.GetString(0);


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




            return objTiffinDTO;

        }

        public TiffinDTO getTiffinAmount(string strEmployeeId, string strYear, string strMonth, string strHeadOfficeId, string strBranchOfficeId)
        {

            TiffinDTO objTiffinDTO = new TiffinDTO();
            string sql = "";
            sql = "SELECT " +

                  "to_char(nvl(PAYMENT_AMOUNT, '')) " +


                  "FROM vew_search_tiffin_entry WHERE HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID ='" + strBranchOfficeId + "' AND employee_id = '" + strEmployeeId + "' " +
                  " AND tiffin_year = '" + strYear + "' AND tiffin_month = '" + strMonth + "' ";




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

                        objTiffinDTO.TiffinAmount = objDataReader.GetString(0);


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




            return objTiffinDTO;

        }

        public TiffinDTO getNightBillAmount(string strEmployeeId, string strYear, string strMonth, string strHeadOfficeId, string strBranchOfficeId, string nightDate)
        {

            TiffinDTO objTiffinDTO = new TiffinDTO();
            string sql = "";
            sql = "SELECT " +

                  "to_char(nvl(PAYMENT_AMOUNT, '')) " +


                  "FROM VEW_SEARCH_NIGHT_BILL_ENTRY WHERE HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID ='" + strBranchOfficeId + "' AND employee_id = '" + strEmployeeId + "' " +
                  " AND tiffin_year = '" + strYear + "' AND tiffin_month = '" + strMonth + "' "+ " AND LOG_DATE = TO_DATE("+nightDate+", 'DD/MM/YYYY')";




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

                        objTiffinDTO.TiffinAmount = objDataReader.GetString(0);


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




            return objTiffinDTO;

        }

        public TiffinDTO getIftarDayOnly(string strEmployeeId, string strYear, string strMonth, string strHeadOfficeId, string strBranchOfficeId)
        {

            TiffinDTO objTiffinDTO = new TiffinDTO();
            string sql = "";
            sql = "SELECT " +

                  "to_char(nvl(I_DAY, '0')) " +


                  "FROM vew_search_tiffin_entry WHERE HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID ='" + strBranchOfficeId + "' AND employee_id = '" + strEmployeeId + "' " +
                  " AND tiffin_year = '" + strYear + "' AND tiffin_month = '" + strMonth + "' ";




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

                        objTiffinDTO.I_Day = objDataReader.GetString(0);


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




            return objTiffinDTO;

        }

        public TiffinDTO getTiffinDayOnly(string strEmployeeId, string strYear, string strMonth, string strHeadOfficeId, string strBranchOfficeId)
        {

            TiffinDTO objTiffinDTO = new TiffinDTO();
            string sql = "";
            sql = "SELECT " +

                  "to_char(nvl(T_DAY, '0')) " +


                  "FROM vew_search_tiffin_entry WHERE HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID ='" + strBranchOfficeId + "' AND employee_id = '" + strEmployeeId + "' " +
                  " AND tiffin_year = '" + strYear + "' AND tiffin_month = '" + strMonth + "' ";




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

                        objTiffinDTO.T_Day = objDataReader.GetString(0);


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




            return objTiffinDTO;

        }

        public string ProcessIncrementProposalReqSummary(TiffinDTO objTiffinDTO)
        {
            string strMsg = "";

            OracleCommand objOracleCommand = new OracleCommand("sp_yearly_inc_proposal_req");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objTiffinDTO.UnitGroupId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_group__id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.UnitGroupId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_group__id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objTiffinDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.UnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objTiffinDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            objOracleCommand.Parameters.Add("P_INCREMENT_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.Year;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objTiffinDTO.UpdateBy;
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

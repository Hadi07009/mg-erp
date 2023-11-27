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
    public class ArrearDAL
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

        public string processArrear(ArrearDTO objArrearDTO)
        {

            string strMsg = "";
            OracleTransaction trans = null;
           
            OracleCommand objOracleCommand = new OracleCommand("pro_arrear_process");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objArrearDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objArrearDTO.UnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            
            if (objArrearDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objArrearDTO.SectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            objOracleCommand.Parameters.Add("p_arrear_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objArrearDTO.Year;
            objOracleCommand.Parameters.Add("p_arrear_from_month_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objArrearDTO.FromMonthId;
            objOracleCommand.Parameters.Add("p_arrear_to_month_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objArrearDTO.ToMonthId;

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objArrearDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objArrearDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objArrearDTO.BranchOfficeId;
            
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
        public string saveArrearSetup(ArrearDTO objArrearDTO)
        {

            string strMsg = "";
            OracleTransaction trans = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_arrear_setup_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;
            objOracleCommand.Parameters.Add("p_arrear_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objArrearDTO.Year;

            if (objArrearDTO.FromMonthId != "")
            {
                objOracleCommand.Parameters.Add("P_ARREAR_FROM_MONTH_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objArrearDTO.FromMonthId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_ARREAR_FROM_MONTH_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            
            if (objArrearDTO.ToMonthId != "")
            {
                objOracleCommand.Parameters.Add("P_ARREAR_TO_MONTH_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objArrearDTO.ToMonthId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_ARREAR_TO_MONTH_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objArrearDTO.EffectDate != "")
            {
                objOracleCommand.Parameters.Add("P_EFFECT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objArrearDTO.EffectDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_EFFECT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objArrearDTO.LimitDate != "")
            {
                objOracleCommand.Parameters.Add("P_LIMIT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objArrearDTO.LimitDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_LIMIT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objArrearDTO.CarryPreArrear != "")
            {
                objOracleCommand.Parameters.Add("P_CARRY_PRE_ARREAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objArrearDTO.CarryPreArrear;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_CARRY_PRE_ARREAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
                        
            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objArrearDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objArrearDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objArrearDTO.BranchOfficeId;
            
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

        //Added On 15.04.2019
        public string DiscardUnpaidIncrementArrear(ArrearDTO objArrearDTO)
        {

            string strMsg = "";
            OracleTransaction trans = null;
            OracleCommand objOracleCommand = new OracleCommand("sp_discard_unpaid_incr_arrear");
            objOracleCommand.CommandType = CommandType.StoredProcedure;
            objOracleCommand.Parameters.Add("p_arrear_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objArrearDTO.Year;

            if (objArrearDTO.FromMonthId != "")
            {
                objOracleCommand.Parameters.Add("P_ARREAR_FROM_MONTH_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objArrearDTO.FromMonthId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_ARREAR_FROM_MONTH_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objArrearDTO.ToMonthId != "")
            {
                objOracleCommand.Parameters.Add("P_ARREAR_TO_MONTH_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objArrearDTO.ToMonthId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_ARREAR_TO_MONTH_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            objOracleCommand.Parameters.Add("p_logged_in_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objArrearDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objArrearDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objArrearDTO.BranchOfficeId;

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

        public string SyncAdvanceWithIncrementArrear(ArrearDTO objArrearDTO)
        {

            string strMsg = "";
            OracleTransaction trans = null;
            OracleCommand objOracleCommand = new OracleCommand("sp_sync_advance_with_incr_arr");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("p_arrear_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objArrearDTO.Year;

            if (objArrearDTO.FromMonthId != "")
            {
                objOracleCommand.Parameters.Add("P_ARREAR_FROM_MONTH_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objArrearDTO.FromMonthId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_ARREAR_FROM_MONTH_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objArrearDTO.ToMonthId != "")
            {
                objOracleCommand.Parameters.Add("P_ARREAR_TO_MONTH_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objArrearDTO.ToMonthId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_ARREAR_TO_MONTH_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            //p_arrear_year_to
            //p_arrear_from_month_id_to
            //p_arrear_to_month_id_to

            objOracleCommand.Parameters.Add("p_arrear_year_to", OracleDbType.Varchar2, ParameterDirection.Input).Value = objArrearDTO.ArrearYearTo;

            if (objArrearDTO.ArrearFromMonthTo != "")
            {
                objOracleCommand.Parameters.Add("p_arrear_from_month_id_to", OracleDbType.Varchar2, ParameterDirection.Input).Value = objArrearDTO.ArrearFromMonthTo;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_arrear_from_month_id_to", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objArrearDTO.ArrearToMonthTo != "")
            {
                objOracleCommand.Parameters.Add("p_arrear_to_month_id_to", OracleDbType.Varchar2, ParameterDirection.Input).Value = objArrearDTO.ArrearToMonthTo;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_arrear_to_month_id_to", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            objOracleCommand.Parameters.Add("p_logged_in_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objArrearDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objArrearDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objArrearDTO.BranchOfficeId;

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


        public string processArrearSpecial(ArrearDTO objArrearDTO)
        {

            string strMsg = "";
            OracleTransaction trans = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_arrear_process_ho");
            objOracleCommand.CommandType = CommandType.StoredProcedure;
            
            if (objArrearDTO.UnitId != " ")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objArrearDTO.UnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objArrearDTO.SectionId != " ")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objArrearDTO.SectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            
            objOracleCommand.Parameters.Add("p_arrear_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objArrearDTO.Year;
            objOracleCommand.Parameters.Add("p_arrear_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objArrearDTO.Month;

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objArrearDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objArrearDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objArrearDTO.BranchOfficeId;
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

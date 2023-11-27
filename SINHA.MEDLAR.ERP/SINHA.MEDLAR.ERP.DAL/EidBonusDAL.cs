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
    public class EidBonusDAL
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

        public string bonusPreparation(EidBonusDTO objEidBonusDTO)
        {
            string strMsg = "";
            OracleTransaction trans = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_eid_bonus_process_ho");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("p_bonus_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEidBonusDTO.BonusYear;
            objOracleCommand.Parameters.Add("p_bonus_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEidBonusDTO.BonusMonth;

            if (objEidBonusDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEidBonusDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEidBonusDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEidBonusDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objEidBonusDTO.EidTypeId != "")
            {
                objOracleCommand.Parameters.Add("p_eid_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEidBonusDTO.EidTypeId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_eid_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEidBonusDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEidBonusDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEidBonusDTO.BranchOfficeId;
           

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
        public string saveEidBonusBasicInfo(EidBonusDTO objEidBonusDTO)
        {
            string strMsg = "";
            OracleTransaction trans = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_eid_bonus_basic_ho_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEidBonusDTO.EmployeeId;
            objOracleCommand.Parameters.Add("p_bonus_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEidBonusDTO.BonusYear;
            objOracleCommand.Parameters.Add("p_bonus_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEidBonusDTO.BonusMonth;

            objOracleCommand.Parameters.Add("P_TOTAL_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEidBonusDTO.TotalYear;
            objOracleCommand.Parameters.Add("P_TOTAL_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEidBonusDTO.TotalMonth;


            if (objEidBonusDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEidBonusDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEidBonusDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEidBonusDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

         

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEidBonusDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEidBonusDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEidBonusDTO.BranchOfficeId;


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

        public string processBonusOption(EidBonusDTO objEidBonusDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_bonus_process_select");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEidBonusDTO.UnitId;

            if (objEidBonusDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEidBonusDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

          
            if (objEidBonusDTO.BonusYear != "")
            {

                objOracleCommand.Parameters.Add("p_bonus_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEidBonusDTO.BonusYear;

            }
            else
            {
                objOracleCommand.Parameters.Add("p_bonus_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objEidBonusDTO.BonusMonth != "")
            {
                objOracleCommand.Parameters.Add("p_bonus_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEidBonusDTO.BonusMonth;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_bonus_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEidBonusDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEidBonusDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEidBonusDTO.BranchOfficeId;


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



        public DataTable searchEidBonusBasicInfo(EidBonusDTO objEidBonusDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
                   "rownum sl, " +
                   "CARD_NO, " +
                   "EMPLOYEE_ID, " +
                   "EMPLOYEE_NAME, " +
                   "DESIGNATION_NAME, " +
                   "TOTAL_MONTH, "+
                   "TOTAL_YEAR "+


                  "FROM VEW_SEARCH_EID_BONUS_INFO_HO WHERE head_office_id = '" + objEidBonusDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEidBonusDTO.BranchOfficeId + "'";



            if (objEidBonusDTO.EmployeeId.Length > 0)
            {

                sql = sql + "and employee_id = '" + objEidBonusDTO.EmployeeId + "'";
            }

            if (objEidBonusDTO.CardNo.Length > 0)
            {

                sql = sql + "and card_no = '" + objEidBonusDTO.CardNo + "'";
            }


            if (objEidBonusDTO.SectionId.Length > 0)
            {

                sql = sql + "and section_id = '" + objEidBonusDTO.SectionId + "'";
            }

            if (objEidBonusDTO.UnitId.Length > 0)
            {

                sql = sql + "and unit_id = '" + objEidBonusDTO.UnitId + "'";
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

        public DataTable searchEidBonusAmountInfo(EidBonusDTO objEidBonusDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
                   "rownum sl, " +
                   "CARD_NO, " +
                   "EMPLOYEE_ID, " +
                   "EMPLOYEE_NAME, " +
                   "DESIGNATION_NAME, " +
                   "TOTAL_MONTH, "+
                   "BONUS_AMOUNT "+

                  "FROM vew_search_eid_bonus_amount WHERE head_office_id = '" + objEidBonusDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEidBonusDTO.BranchOfficeId + "' and bonus_year = '" + objEidBonusDTO.BonusYear + "'  and bonus_month = '" + objEidBonusDTO.BonusMonth + "' ";



           

            if (objEidBonusDTO.SectionId.Length > 0)
            {

                sql = sql + "and section_id = '" + objEidBonusDTO.SectionId + "'";
            }

            if (objEidBonusDTO.UnitId.Length > 0)
            {

                sql = sql + "and unit_id = '" + objEidBonusDTO.UnitId + "'";
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

    }
}

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
    public class OfficeTimeDAL
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

        //public string addOfficeTime(OfficeTimeDTO objOfficeTimeDTO)
        //{

        //    string strMsg = "";
        //    OracleCommand objOracleCommand = new OracleCommand("pro_office_time_save");
        //    objOracleCommand.CommandType = CommandType.StoredProcedure;

        //    if (objOfficeTimeDTO.UnitId != "")
        //    {
        //        objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objOfficeTimeDTO.UnitId;
        //    }
        //    else
        //    {
        //        objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
        //    }

        //    if (objOfficeTimeDTO.SectionId != "")
        //    {
        //        objOracleCommand.Parameters.Add("P_SECTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objOfficeTimeDTO.SectionId;
        //    }
        //    else
        //    {
        //        objOracleCommand.Parameters.Add("P_SECTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
        //    }

        //    if (objOfficeTimeDTO.EffectDate.Length > 6)
        //    {
        //        objOracleCommand.Parameters.Add("P_EFFECTIVE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objOfficeTimeDTO.EffectDate;
        //    }
        //    else
        //    {
        //        objOracleCommand.Parameters.Add("P_EFFECTIVE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
        //    }

        //    if (objOfficeTimeDTO.LogInTime != "")
        //    {
        //        objOracleCommand.Parameters.Add("P_LOG_IN_TIME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objOfficeTimeDTO.LogInTime;
        //    }
        //    else
        //    {
        //        objOracleCommand.Parameters.Add("P_LOG_IN_TIME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
        //    }

        //    if (objOfficeTimeDTO.LogOutTime != "")
        //    {
        //        objOracleCommand.Parameters.Add("P_LOG_OUT_TIME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objOfficeTimeDTO.LogOutTime;
        //    }
        //    else
        //    {
        //        objOracleCommand.Parameters.Add("P_LOG_OUT_TIME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
        //    }

        //    if (objOfficeTimeDTO.LunchOutTime != "")
        //    {
        //        objOracleCommand.Parameters.Add("P_LUNCH_OUT_TIME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objOfficeTimeDTO.LunchOutTime;
        //    }
        //    else
        //    {
        //        objOracleCommand.Parameters.Add("P_LUNCH_OUT_TIME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
        //    }

        //    if (objOfficeTimeDTO.LunchInTime != "")
        //    {
        //        objOracleCommand.Parameters.Add("P_LUNCH_IN_TIME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objOfficeTimeDTO.LunchInTime;
        //    }
        //    else
        //    {
        //        objOracleCommand.Parameters.Add("P_LUNCH_IN_TIME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
        //    }

        //    objOracleCommand.Parameters.Add("P_ALL_UNIT_YN", OracleDbType.Varchar2, ParameterDirection.Input).Value = objOfficeTimeDTO.AllUnit;

        //    objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objOfficeTimeDTO.UpdateBy;
        //    objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objOfficeTimeDTO.HeadOfficeId;
        //    objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objOfficeTimeDTO.BranchOfficeId;

        //    objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

        //    using (OracleConnection strConn = GetConnection())
        //    {
        //        try
        //        {
        //            objOracleCommand.Connection = strConn;
        //            strConn.Open();
        //            //strConn.BeginTransaction();
        //            objOracleCommand.ExecuteNonQuery();

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
        public string addOfficeTime(OfficeTimeDTO objOfficeTimeDTO)
        {

            string strMsg = "";
            OracleCommand objOracleCommand = new OracleCommand("pro_office_time_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objOfficeTimeDTO.TimeId != "")
            {
                objOracleCommand.Parameters.Add("P_TIME_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objOfficeTimeDTO.TimeId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_TIME_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objOfficeTimeDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objOfficeTimeDTO.UnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objOfficeTimeDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("P_SECTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objOfficeTimeDTO.SectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SECTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objOfficeTimeDTO.EffectDate.Length > 6)
            {
                objOracleCommand.Parameters.Add("P_EFFECTIVE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objOfficeTimeDTO.EffectDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_EFFECTIVE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objOfficeTimeDTO.LogInTime != "")
            {
                objOracleCommand.Parameters.Add("P_LOG_IN_TIME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objOfficeTimeDTO.LogInTime;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_LOG_IN_TIME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objOfficeTimeDTO.LogOutTime != "")
            {
                objOracleCommand.Parameters.Add("P_LOG_OUT_TIME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objOfficeTimeDTO.LogOutTime;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_LOG_OUT_TIME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objOfficeTimeDTO.LunchOutTime != "")
            {
                objOracleCommand.Parameters.Add("P_LUNCH_OUT_TIME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objOfficeTimeDTO.LunchOutTime;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_LUNCH_OUT_TIME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objOfficeTimeDTO.LunchInTime != "")
            {
                objOracleCommand.Parameters.Add("P_LUNCH_IN_TIME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objOfficeTimeDTO.LunchInTime;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_LUNCH_IN_TIME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            objOracleCommand.Parameters.Add("P_punch_start_time", OracleDbType.Varchar2, ParameterDirection.Input).Value = objOfficeTimeDTO.PunchStartTime;
            objOracleCommand.Parameters.Add("P_punch_end_time", OracleDbType.Varchar2, ParameterDirection.Input).Value = objOfficeTimeDTO.PunchEndTime;
           
            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objOfficeTimeDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objOfficeTimeDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objOfficeTimeDTO.BranchOfficeId;

            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    //strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();

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


        public OfficeTimeDTO searchOfficeTime(string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {
            string strMsg = "";
            string sql = "";
            OfficeTimeDTO objOfficeTimeDTO = new OfficeTimeDTO();

            sql = "SELECT " +

                 "NVL (TO_CHAR (EFFECTIVE_DATE, 'dd/mm/yyyy'), ' '), " +
                 "TO_CHAR (NVL (LOG_IN_TIME, '0')), " +
                 "TO_CHAR (NVL (LOG_OUT_TIME, '0')), " +
                 "TO_CHAR (NVL (LUNCH_OUT_TIME, '0')), " +
                 "TO_CHAR (NVL (LUNCH_IN_TIME, '0')) " +


                 "from vew_search_office_time where head_office_id = '" + strHeadOfficeId + "' and branch_office_id = '" + strBranchOfficeId + "' ";


            if (strUnitId.Length > 0)
            {

                sql = sql + " AND unit_id = '" + strUnitId + "' ";
            }

            if (strUnitId.Length > 0)
            {

                sql = sql + " AND section_id = '" + strSectionId + "' ";
            }



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

                        objOfficeTimeDTO.EffectDate = objDataReader.GetString(0);
                        objOfficeTimeDTO.LogInTime = objDataReader.GetString(1);
                        objOfficeTimeDTO.LogOutTime = objDataReader.GetString(2);
                        objOfficeTimeDTO.LunchOutTime = objDataReader.GetString(3);
                        objOfficeTimeDTO.LunchInTime = objDataReader.GetString(4);

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

            return objOfficeTimeDTO;


        }
        public string SaveTimeSetup(OfficeTimeDTO objOfficeTimeDTO)
        {

            string strMsg = "";
            OracleCommand objOracleCommand = new OracleCommand("sp_save_time_setup");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objOfficeTimeDTO.TimeId != "")
            {
                objOracleCommand.Parameters.Add("P_TIME_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objOfficeTimeDTO.TimeId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_TIME_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objOfficeTimeDTO.ShiftId != "")
            {
                objOracleCommand.Parameters.Add("P_DUTY_TYPE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objOfficeTimeDTO.DutyTypeId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_DUTY_TYPE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objOfficeTimeDTO.LogInTime != "")
            {
                objOracleCommand.Parameters.Add("P_LOG_IN_TIME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objOfficeTimeDTO.LogInTime;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_LOG_IN_TIME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objOfficeTimeDTO.LogOutTime != "")
            {
                objOracleCommand.Parameters.Add("P_LOG_OUT_TIME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objOfficeTimeDTO.LogOutTime;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_LOG_OUT_TIME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objOfficeTimeDTO.LunchOutTime != "")
            {
                objOracleCommand.Parameters.Add("P_LUNCH_OUT_TIME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objOfficeTimeDTO.LunchOutTime;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_LUNCH_OUT_TIME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objOfficeTimeDTO.LunchInTime != "")
            {
                objOracleCommand.Parameters.Add("P_LUNCH_IN_TIME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objOfficeTimeDTO.LunchInTime;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_LUNCH_IN_TIME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            objOracleCommand.Parameters.Add("P_punch_start_time", OracleDbType.Varchar2, ParameterDirection.Input).Value = objOfficeTimeDTO.PunchStartTime;
            objOracleCommand.Parameters.Add("P_punch_end_time", OracleDbType.Varchar2, ParameterDirection.Input).Value = objOfficeTimeDTO.PunchEndTime;

            objOracleCommand.Parameters.Add("P_CREATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objOfficeTimeDTO.CreateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objOfficeTimeDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objOfficeTimeDTO.BranchOfficeId;

            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    //strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();

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
        public string SaveShiftMapping(OfficeTimeDTO objOfficeTimeDTO)
        {

            string strMsg = "";
            OracleCommand objOracleCommand = new OracleCommand("sp_save_shift_mapping");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objOfficeTimeDTO.MappingId != "")
            {
                objOracleCommand.Parameters.Add("P_MAPPING_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objOfficeTimeDTO.MappingId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_MAPPING_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objOfficeTimeDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objOfficeTimeDTO.UnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objOfficeTimeDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("P_SECTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objOfficeTimeDTO.SectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SECTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objOfficeTimeDTO.ShiftId != "")
            {
                objOracleCommand.Parameters.Add("P_SHIFT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objOfficeTimeDTO.ShiftId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SHIFT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objOfficeTimeDTO.EffectDate.Length > 6)
            {
                objOracleCommand.Parameters.Add("P_EFFECT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objOfficeTimeDTO.EffectDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_EFFECT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            objOracleCommand.Parameters.Add("P_CREATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objOfficeTimeDTO.CreateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objOfficeTimeDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objOfficeTimeDTO.BranchOfficeId;

            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    //strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();

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
        public string SaveShiftTimeMapping(OfficeTimeDTO objOfficeTimeDTO)
        {

            string strMsg = "";
            OracleCommand objOracleCommand = new OracleCommand("sp_save_shift_time_mapping");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objOfficeTimeDTO.MappingId != "")
            {
                objOracleCommand.Parameters.Add("P_MAPPING_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objOfficeTimeDTO.MappingId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_MAPPING_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objOfficeTimeDTO.ShiftId != "")
            {
                objOracleCommand.Parameters.Add("P_SHIFT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objOfficeTimeDTO.ShiftId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SHIFT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objOfficeTimeDTO.TimeId != "")
            {
                objOracleCommand.Parameters.Add("P_TIME_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objOfficeTimeDTO.TimeId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_TIME_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objOfficeTimeDTO.EffectDate.Length > 6)
            {
                objOracleCommand.Parameters.Add("P_EFFECT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objOfficeTimeDTO.EffectDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_EFFECT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            objOracleCommand.Parameters.Add("P_CREATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objOfficeTimeDTO.CreateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objOfficeTimeDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objOfficeTimeDTO.BranchOfficeId;

            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    objOracleCommand.ExecuteNonQuery();
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
        public string SaveOTDeductionSetup(OfficeTimeDTO objOfficeTimeDTO)
        {

            string strMsg = "";
            OracleCommand objOracleCommand = new OracleCommand("sp_save_ot_deduction_setup");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objOfficeTimeDTO.SetupId != "")
            {
                objOracleCommand.Parameters.Add("P_SETUP_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objOfficeTimeDTO.SetupId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SETUP_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objOfficeTimeDTO.LogDate != "")
            {
                objOracleCommand.Parameters.Add("P_LOG_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objOfficeTimeDTO.LogDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_LOG_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objOfficeTimeDTO.OTDeductionStartTime != "")
            {
                objOracleCommand.Parameters.Add("P_OT_DEDUCTION_START_TIME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objOfficeTimeDTO.OTDeductionStartTime;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_OT_DEDUCTION_START_TIME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objOfficeTimeDTO.OTDeductionEndTime != "")
            {
                objOracleCommand.Parameters.Add("P_OT_DEDUCTION_END_TIME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objOfficeTimeDTO.OTDeductionEndTime;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_OT_DEDUCTION_END_TIME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objOfficeTimeDTO.PurposeId != "")
            {
                objOracleCommand.Parameters.Add("P_PURPOSE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objOfficeTimeDTO.PurposeId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PURPOSE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("P_CREATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objOfficeTimeDTO.CreateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objOfficeTimeDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objOfficeTimeDTO.BranchOfficeId;

            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    //strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();

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

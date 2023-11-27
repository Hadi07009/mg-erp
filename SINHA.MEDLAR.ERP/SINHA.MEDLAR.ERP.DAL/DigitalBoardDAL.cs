using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using SINHA.MEDLAR.ERP.DTO;

namespace SINHA.MEDLAR.ERP.DAL
{
    public class DigitalBoardDAL
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
        public DataTable getBuyerId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            string sql = "";
            sql = "select ' ' BUYER_ID, ' Please Select One ' BUYER_NAME from dual " +
                    "union " +

                "SELECT " +
                  "to_char(BUYER_ID), " +
                  "to_char(BUYER_SHORT_NAME)BUYER_NAME " +
                  "FROM L_BUYER order by BUYER_NAME ";

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

        public DataTable getBuyerIdSearch(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            string sql = "";
            sql = "select ' ' BUYER_ID, ' Please Select One ' BUYER_NAME from dual " +
                    "union " +

                "SELECT " +
                  "to_char(BUYER_ID), " +
                  "to_char(BUYER_SHORT_NAME)BUYER_NAME " +
                  "FROM L_BUYER  order by BUYER_NAME ";

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

        public DataTable getLineIdSearch(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            string sql = "";
            sql = "select ' ' LINE_ID, ' Please Select One ' LINE_NAME from dual " +
                    "union " +

                "SELECT " +
                  "to_char(LINE_ID), " +
                  "to_char(LINE_NAME) " +
                  "FROM L_LINE where head_office_id = '" + strHeadOfficeId + "' and branch_office_id = '" + strBranchOfficeId + "' order by LINE_NAME ";




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
        public DataTable loadDigitalBoardInputRecord(string strHeadOffieId, string strBranchOffieId)
        {

            DigitalBoardDTO objDigitalBoardDTO = new DigitalBoardDTO();
            DigitalBoardDAL objDigitalBoardDAL = new DigitalBoardDAL();
            DataTable dt = new DataTable();

            string sql = "";
            sql = "SELECT " +

                    "DIGITAL_BOARD_INPUT_ENTRY_ID, " +

                    "TO_CHAR(INPUT_DATE,'dd/mm/yyyy')INPUT_DATE," +
                    "BUYER_NAME," +
                    "STYLE_NO," +
                    " SMV," +
                    "MANPOWER," +
                    "TARGET_EFFICIENCY," +
                    "TARGET_PER_HOUR," +
                    "DAY_TARGET," +
                    "LINE_NAME," +
                    "DHU_LIMIT," +
                    "HOUR_NO," +
                    "ACHIVE," +
                    "DEFECT" +

                " FROM VEW_SEARCH_DIGITALBOARD_INPUT ORDER BY DIGITAL_BOARD_INPUT_ENTRY_ID ";

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

        public string saveDigitalBoardInputInfo(DigitalBoardDTO objDigitalBoardDTO)
        {


            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("pro_digital_board_input_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objDigitalBoardDTO.DigitalBoardInputId != "")
            {

                objOracleCommand.Parameters.Add("P_DIGITAL_BOARD_INPUT_ENTRY_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objDigitalBoardDTO.DigitalBoardInputId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_DIGITAL_BOARD_INPUT_ENTRY_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objDigitalBoardDTO.InputDate.Length > 6)
            {

                objOracleCommand.Parameters.Add("P_INPUT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objDigitalBoardDTO.InputDate;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_INPUT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objDigitalBoardDTO.BuyerId != "")
            {

                objOracleCommand.Parameters.Add("P_BUYER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objDigitalBoardDTO.BuyerId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_BUYER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objDigitalBoardDTO.StyleNo != "")
            {

                objOracleCommand.Parameters.Add("P_STYLE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objDigitalBoardDTO.StyleNo;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_STYLE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objDigitalBoardDTO.SMV != "")
            {

                objOracleCommand.Parameters.Add("P_SMV", OracleDbType.Varchar2, ParameterDirection.Input).Value = objDigitalBoardDTO.SMV;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_SMV", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objDigitalBoardDTO.ManPower != "")
            {

                objOracleCommand.Parameters.Add("P_MANPOWER", OracleDbType.Varchar2, ParameterDirection.Input).Value = objDigitalBoardDTO.ManPower;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_MANPOWER", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objDigitalBoardDTO.TargetEfficiency != "")
            {

                objOracleCommand.Parameters.Add("P_TARGET_EFFICIENCY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objDigitalBoardDTO.TargetEfficiency;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_TARGET_EFFICIENCY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objDigitalBoardDTO.TargetPerHour != "")
            {

                objOracleCommand.Parameters.Add("P_TARGET_PER_HOUR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objDigitalBoardDTO.TargetPerHour;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_TARGET_PER_HOUR", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            //
            if (objDigitalBoardDTO.DayTarget != "")
            {

                objOracleCommand.Parameters.Add("P_DAY_TARGET", OracleDbType.Varchar2, ParameterDirection.Input).Value = objDigitalBoardDTO.DayTarget;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_DAY_TARGET", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objDigitalBoardDTO.LineId != "")
            {

                objOracleCommand.Parameters.Add("P_LINE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objDigitalBoardDTO.LineId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_LINE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objDigitalBoardDTO.DHULimit != "")
            {

                objOracleCommand.Parameters.Add("P_DHU_LIMIT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objDigitalBoardDTO.DHULimit;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_DHU_LIMIT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objDigitalBoardDTO.Hour != "")
            {

                objOracleCommand.Parameters.Add("P_HOUR_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objDigitalBoardDTO.Hour;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_HOUR_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objDigitalBoardDTO.Achieve != "")
            {

                objOracleCommand.Parameters.Add("P_ACHIVE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objDigitalBoardDTO.Achieve;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_ACHIVE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objDigitalBoardDTO.Defect != "")
            {

                objOracleCommand.Parameters.Add("P_DEFECT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objDigitalBoardDTO.Defect;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_DEFECT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }



            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objDigitalBoardDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objDigitalBoardDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objDigitalBoardDTO.BranchOfficeId;


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

        public DigitalBoardDTO searchDigitalBoardInputEntry(string strDigitalInputEntryId, string strHeadOfficeId, string strBranchOfficeId)
        {

            DigitalBoardDTO objDigitalBoardDTO = new DigitalBoardDTO();
            string sql = "";
            sql = "SELECT " +
                  "TO_CHAR(INPUT_DATE,'dd/mm/yyyy')INPUT_DATE," +
                 "to_char(nvl(BUYER_ID, '0')), " +

                    "to_char(nvl(STYLE_NO, '0')), " +
                    "to_char(nvl(SMV, '0')), " +
                    "to_char(nvl(MANPOWER, '0')), " +
                    "to_char(nvl(TARGET_EFFICIENCY, '0')), " +
                    "to_char(nvl(TARGET_PER_HOUR, '0')), " +
                    "to_char(nvl(DAY_TARGET, '0')), " +
                    "to_char(nvl(LINE_ID, '0')), " +
                    "to_char(nvl(DHU_LIMIT, '0')), " +
                    "to_char(nvl(HOUR_NO, '0')), " +

                  "to_char(nvl(ACHIVE, '0')) ," +
                   "to_char(nvl(DEFECT, '0')) " +

                 "FROM VEW_SEARCH_DIGITALBOARD_INPUT WHERE DIGITAL_BOARD_INPUT_ENTRY_ID = '" + strDigitalInputEntryId + "' and head_office_id = '" + strHeadOfficeId + "' and branch_office_id ='" + strBranchOfficeId + "' ";


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
                        objDigitalBoardDTO.InputDate = objDataReader.GetString(0);
                        objDigitalBoardDTO.BuyerId = objDataReader.GetString(1);


                        objDigitalBoardDTO.StyleNo = objDataReader.GetString(2);
                        objDigitalBoardDTO.SMV = objDataReader.GetString(3);
                        objDigitalBoardDTO.ManPower = objDataReader.GetString(4);
                        objDigitalBoardDTO.TargetEfficiency = objDataReader.GetString(5);
                        objDigitalBoardDTO.TargetPerHour = objDataReader.GetString(6);
                        objDigitalBoardDTO.DayTarget = objDataReader.GetString(7);
                        objDigitalBoardDTO.LineId = objDataReader.GetString(8);
                        objDigitalBoardDTO.DHULimit = objDataReader.GetString(9);
                        objDigitalBoardDTO.Hour = objDataReader.GetString(10);
                        objDigitalBoardDTO.Achieve = objDataReader.GetString(11);
                        objDigitalBoardDTO.Defect = objDataReader.GetString(12);

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


            return objDigitalBoardDTO;

        }

        public DataTable getLineId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            string sql = "";
            sql = "select ' ' LINE_ID, ' Please Select One ' LINE_NAME from dual " +
                    "union " +

                "SELECT " +
                  "to_char(LINE_ID), " +
                  "to_char(LINE_NAME) " +
                  "FROM L_LINE where head_office_id = '" + strHeadOfficeId + "' and branch_office_id = '" + strBranchOfficeId + "' order by LINE_NAME ";




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


        public DataTable DigitalBoardEntrySearch(DigitalBoardDTO objDigitalBoardDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
                "DIGITAL_BOARD_INPUT_ENTRY_ID," +
                  "TO_CHAR(INPUT_DATE,'dd/mm/yyyy')INPUT_DATE," +
                 "BUYER_NAME, " +

                    "STYLE_NO, " +
                    "SMV, " +
                    "MANPOWER, " +
                    "TARGET_EFFICIENCY, " +
                    "TARGET_PER_HOUR, " +
                    "DAY_TARGET, " +
                    "LINE_NAME, " +
                    "DHU_LIMIT, " +
                    "HOUR_NO, " +

                  "ACHIVE ," +
                   "DEFECT " +
                  " FROM VEW_SEARCH_DIGITALBOARD_INPUT WHERE head_office_id = '" + objDigitalBoardDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objDigitalBoardDTO.BranchOfficeId + "' ";

            if (objDigitalBoardDTO.BuyerId.Length > 0)
            {

                sql = sql + "and BUYER_ID = '" + objDigitalBoardDTO.BuyerId + "'";
            }

            if (objDigitalBoardDTO.LineId.Length > 0)
            {

                sql = sql + "and LINE_ID = '" + objDigitalBoardDTO.LineId + "'";
            }




            if (objDigitalBoardDTO.InputFromDate.Length > 6 && objDigitalBoardDTO.InputToDate.Length > 6)
            {

                sql = sql + "and INPUT_DATE between to_date('" + objDigitalBoardDTO.InputFromDate + "', 'dd/mm/yyyy') and to_date('" + objDigitalBoardDTO.InputToDate + "', 'dd/mm/yyyy') ";
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
    }
}

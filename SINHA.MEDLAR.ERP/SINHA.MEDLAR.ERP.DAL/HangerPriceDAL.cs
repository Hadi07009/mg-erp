using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SINHA.MEDLAR.ERP.DTO;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Configuration;

namespace SINHA.MEDLAR.ERP.DAL
{
    public class HangerPriceDAL
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


        public string saveHangerPriceInfo(HangerPriceDTO objHangerPriceDTO)
        {
          

            OracleTransaction trans = null;
            string strMsg = "";
            OracleCommand objOracleCommand = new OracleCommand("pro_hanger_price_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objHangerPriceDTO.HangerId != "")
            {
                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objHangerPriceDTO.HangerId;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objHangerPriceDTO.SupplierId != "")
            {
                objOracleCommand.Parameters.Add("P_SUPPLIER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objHangerPriceDTO.SupplierId;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_SUPPLIER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objHangerPriceDTO.CurrencyId != "")
            {
                objOracleCommand.Parameters.Add("P_CURRENCY_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objHangerPriceDTO.CurrencyId;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_CURRENCY_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objHangerPriceDTO.ColorId != "")
            {
                objOracleCommand.Parameters.Add("P_COLOR_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objHangerPriceDTO.ColorId;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_COLOR_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objHangerPriceDTO.StyleId != "")
            {
                objOracleCommand.Parameters.Add("P_STYLE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objHangerPriceDTO.StyleId;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_STYLE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }



            if (objHangerPriceDTO.HangerSize != "")
            {
                objOracleCommand.Parameters.Add("P_HANGER_SIZE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objHangerPriceDTO.HangerSize;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_HANGER_SIZE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objHangerPriceDTO.Particulars != "")
            {
                objOracleCommand.Parameters.Add("P_PARTICULARS", OracleDbType.Varchar2, ParameterDirection.Input).Value = objHangerPriceDTO.Particulars;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_PARTICULARS", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objHangerPriceDTO.PriceRate != "")
            {
                objOracleCommand.Parameters.Add("P_RATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objHangerPriceDTO.PriceRate;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_RATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }



            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objHangerPriceDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objHangerPriceDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objHangerPriceDTO.BranchOfficeId;

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
        public DataTable LoadHangerPriceRecord(HangerPriceDTO objHangerPriceDTO)
        {


            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +


                               "to_char(NVL(TRAN_ID,'0'))TRAN_ID, " +
                               "to_char(NVL(SUPPLIER_ID,'0'))SUPPLIER_ID, " +
                               "to_char(NVL(SUPPLIER_NAME,'0'))SUPPLIER_NAME, " +
                               "to_char(NVL(CURRENCY_ID,'0'))CURRENCY_ID, " +
                                "to_char(NVL(CURRENCY_NAME,'0'))CURRENCY_NAME, " +
                                 "to_char(NVL(COLOR_ID,'0'))COLOR_ID, " +
                                 "to_char(NVL(COLOR_NAME,'0'))COLOR_NAME, " +
                                 "to_char(NVL(STYLE_ID,'0'))STYLE_ID, " +
                                  "to_char(NVL(STYLE_NO,'0'))STYLE_NO, " +
                                  "to_char(NVL(HANGER_SIZE,'0'))HANGER_SIZE, " +
                                  "to_char(NVL(PARTICULARS,'0'))PARTICULARS, " +
                                    "to_char(NVL(RATE,'0'))RATE " +


                               " FROM  VEW_HANGER_PRICE_SUB where head_office_id = '" + objHangerPriceDTO.HeadOfficeId + "' AND branch_office_id = '" + objHangerPriceDTO.BranchOfficeId + "' ";

            if (objHangerPriceDTO.SupplierId.Length > 0)
            {

                sql = sql + "and supplier_id = '" + objHangerPriceDTO.SupplierId + "'";
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


        public string deleteHangerRecord(HangerPriceDTO objHangerPriceDTO)
        {
           
            OracleTransaction trans = null;
            string strMsg = "";
            OracleCommand objOracleCommand = new OracleCommand("pro_hanger_price_delete_all");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            if (objHangerPriceDTO.SupplierId != "")
            {
                objOracleCommand.Parameters.Add("P_SUPPLIER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objHangerPriceDTO.SupplierId;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_SUPPLIER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }





            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objHangerPriceDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objHangerPriceDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objHangerPriceDTO.BranchOfficeId;

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

        public string deleteHangerRecordById(HangerPriceDTO objHangerPriceDTO)
        {

            OracleTransaction trans = null;
            string strMsg = "";
            OracleCommand objOracleCommand = new OracleCommand("pro_hanger_price_delete");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            if (objHangerPriceDTO.HangerId != "")
            {
                objOracleCommand.Parameters.Add("P_HANGER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objHangerPriceDTO.HangerId;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_HANGER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objHangerPriceDTO.SupplierId != "")
            {
                objOracleCommand.Parameters.Add("P_SUPPLIER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objHangerPriceDTO.SupplierId;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_SUPPLIER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }



            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objHangerPriceDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objHangerPriceDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objHangerPriceDTO.BranchOfficeId;

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

        public DataTable getCurrencyId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            string sql = "";
            sql = "select ' ' CURRENCY_ID, ' Please Select One ' currency_name from dual " +
                    "union " +

                "SELECT " +
                  "to_char(CURRENCY_ID), " +
                  "to_char(currency_name) " +
                  "FROM L_CURRENCY ORDER BY  currency_name";

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


        public DataTable getStyleId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            string sql = "";
            sql = "select ' ' STYLE_ID, ' Please Select One ' STYLE_NO from dual " +
                    "union " +

                "SELECT " +
                  "to_char(STYLE_ID), " +
                  "to_char(STYLE_NO) " +
                  "FROM L_STYLE_STORE ORDER BY  STYLE_NO";

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


        public DataTable getColorId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            string sql = "";
            sql = "select ' ' COLOR_ID, ' Please Select One ' COLOR_NAME from dual " +
                    "union " +

                "SELECT " +
                  "to_char(COLOR_ID), " +
                  "to_char(COLOR_NAME) " +
                  "FROM L_COLOR_STORE ORDER BY  COLOR_NAME";

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

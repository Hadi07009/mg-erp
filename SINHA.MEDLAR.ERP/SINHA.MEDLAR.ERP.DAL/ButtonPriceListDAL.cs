using Oracle.ManagedDataAccess.Client;
using SINHA.MEDLAR.ERP.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DAL
{
    public class ButtonPriceListDAL
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

        public string saveButtonPriceList(ButtonPriceListDTO objButtonPriceListDTO)
        {

            string strMsg = "";


            OracleCommand objOracleCommand = new OracleCommand("pro_button_price_list_save");

            objOracleCommand.CommandType = CommandType.StoredProcedure;



            objOracleCommand.Parameters.Add("P_BUTTON_PRICE_LIST_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objButtonPriceListDTO.ButtonPriceListId;
            if (objButtonPriceListDTO.SupplierId != " ")
            {
                objOracleCommand.Parameters.Add("P_SUPPLIER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objButtonPriceListDTO.SupplierId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_SUPPLIER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objButtonPriceListDTO.Particulars != " ")
            {
                objOracleCommand.Parameters.Add("P_PARTICULARS", OracleDbType.Varchar2, ParameterDirection.Input).Value = objButtonPriceListDTO.Particulars;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_PARTICULARS", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objButtonPriceListDTO.ColorId != " ")
            {
                objOracleCommand.Parameters.Add("P_COLOR_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objButtonPriceListDTO.ColorId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_COLOR_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objButtonPriceListDTO.LineId != " ")
            {
                objOracleCommand.Parameters.Add("P_LINE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objButtonPriceListDTO.LineId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_LINE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            if (objButtonPriceListDTO.ArtId != " ")
            {
                objOracleCommand.Parameters.Add("P_ART_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objButtonPriceListDTO.ArtId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_ART_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objButtonPriceListDTO.MUnit != " ")
            {
                objOracleCommand.Parameters.Add("P_M_UNIT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objButtonPriceListDTO.MUnit;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_M_UNIT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objButtonPriceListDTO.RateUS != " ")
            {
                objOracleCommand.Parameters.Add("P_RATE_US", OracleDbType.Varchar2, ParameterDirection.Input).Value = objButtonPriceListDTO.RateUS;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_RATE_US", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }








            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objButtonPriceListDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objButtonPriceListDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objButtonPriceListDTO.BranchOfficeId;

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

        public DataTable GetSupplierId()
        {
            DataTable dt = new DataTable();
            string sql = "";
            sql = "select ' ' SUPPLIER_ID, ' Please Select One ' SUPPLIER_NAME from dual " +
                    "union " +

                "SELECT " +
                  "to_char(SUPPLIER_ID), " +
                 "to_char(SUPPLIER_NAME) " +
                  "FROM L_SUPPLIER order by SUPPLIER_NAME ";

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
        public DataTable GetThreadSupplierId()
        {
            DataTable dt = new DataTable();
            string sql = "";
            sql = "select ' ' SUPPLIER_ID, ' Please Select One ' SUPPLIER_NAME from dual " +
                    "union " +

                "SELECT " +
                  "to_char(SUPPLIER_ID), " +
                 "to_char(SUPPLIER_NAME) " +
                  "FROM L_THREAD_SUPPLIER order by SUPPLIER_NAME ";

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


        public DataTable GetColorId()
        {
            DataTable dt = new DataTable();
            string sql = "";
            sql = "select ' ' COLOR_ID, ' Please Select One ' COLOR_NAME from dual " +
                    "union " +

                "SELECT " +
                  "to_char(COLOR_ID), " +
                 "to_char(COLOR_NAME) " +
                  "FROM L_COLOR_STORE order by COLOR_NAME ";

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
        public DataTable GetLineId()
        {
            DataTable dt = new DataTable();
            string sql = "";
            sql = "select ' ' LINE_ID, ' Please Select One ' LINE_NAME from dual " +
                    "union " +

                "SELECT " +
                  "to_char(LINE_ID), " +
                 "to_char(LINE_NAME) " +
                  "FROM L_LINE order by LINE_NAME ";

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
        public DataTable GetArtId()
        {
            DataTable dt = new DataTable();
            string sql = "";
            sql = "select ' ' ART_ID, ' Please Select One ' ART_NO from dual " +
                    "union " +

                "SELECT " +
                  "to_char(ART_ID), " +
                 "to_char(ART_NO) " +
                  "FROM L_ART_NO order by ART_NO ";

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
        public DataTable loadButtonPriceListRecord(ButtonPriceListDTO objButtonPriceListDTO)
        {


            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
                             "to_char(nvl(PARTICULARS, '0'))PARTICULARS, " +
                             "to_char(nvl(COLOR_ID, '0'))COLOR_ID, " +
                             "to_char(nvl(LINE_ID, '0'))LINE_ID, " +
                             "to_char(nvl(ART_ID, '0'))ART_ID, " +
                             "to_char(nvl(MESUREMENT_ID,'0'))MESUREMENT_ID, " +
                             "to_char(nvl(PRICE_RATE,'0'))PRICE_RATE, " +
                             "to_char(nvl(BUTTON_PRICE_LIST_ID,'0'))BUTTON_PRICE_LIST_ID " +

                             " FROM  VEW_LOAD_BUTTON_PRICE_LIST where head_office_id = '" + objButtonPriceListDTO.HeadOfficeId + "' AND branch_office_id = '" + objButtonPriceListDTO.BranchOfficeId + "' AND supplier_id = '" + objButtonPriceListDTO.SupplierId + "'  ";




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
        public DataTable searchButtonPriceList(ButtonPriceListDTO objButtonPriceListDTO)
        {


            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
                             "to_char(nvl(PARTICULARS,'0'))PARTICULARS, " +
                             "to_char(nvl(COLOR_ID, '0'))COLOR_ID, " +
                             "to_char(nvl(LINE_ID, '0'))LINE_ID, " +
                             "to_char(nvl(ART_ID, '0'))ART_ID, " +
                               //"STYLE_NAME," +
                               "M_UNIT," +
                               "RATE_US," +

                                "BUTTON_PRICE_LIST_ID " +

                               " FROM  BUTTON_PRICE_LIST where head_office_id = '" + objButtonPriceListDTO.HeadOfficeId + "' AND branch_office_id = '" + objButtonPriceListDTO.BranchOfficeId + "' ";

            if (objButtonPriceListDTO.SupplierId.Length > 0)
            {

                sql = sql + "and supplier_id = '" + objButtonPriceListDTO.SupplierId + "'";
            }
           // " order by BUTTON_PRICE_LIST_ID";
            //if (objSewingDTO.SewingProgrammeId.Length > 0)
            //{

            //    sql = sql + "and programme_id = '" + objSewingDTO.SewingProgrammeId + "'";
            //}




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

        public string deleteButtonPriceListRecord(ButtonPriceListDTO objButtonPriceListDTO)
        {
            LoginDTO objLoginDTO = new LoginDTO();
            string strMsg = "";


            OracleCommand objOracleCommand = new OracleCommand("pro_button_price_list");

            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objButtonPriceListDTO.ButtonPriceListId != "")
            {
                objOracleCommand.Parameters.Add(" P_BUTTON_PRICE_LIST_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objButtonPriceListDTO.ButtonPriceListId;

            }
            else
            {

                objOracleCommand.Parameters.Add(" P_BUTTON_PRICE_LIST_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }






            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objButtonPriceListDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objButtonPriceListDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objButtonPriceListDTO.BranchOfficeId;


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


        public DataTable GetMesurementUnitId()
        {
            DataTable dt = new DataTable();
            string sql = "";
            sql = "select ' ' MEASUREMENT_ID, ' Please Select ' MEASUREMENT_NAME from dual " +
                    "union " +

                "SELECT " +
                  "to_char(MEASUREMENT_ID), " +
                 "to_char(MEASUREMENT_NAME) " +
                  "FROM L_MEASUREMENT order by MEASUREMENT_NAME ";

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


        public DataTable getProgrammeId()
        {
            DataTable dt = new DataTable();
            string sql = "";
            sql = "select ' ' PROGRAMME_ID, ' Please Select One ' PROGRAMME_NAME from dual " +
                    "union " +

                "SELECT " +
                  "to_char(PROGRAMME_ID), " +
                 "to_char(PROGRAMME_NAME) " +
                  "FROM L_PROGRAMME order by PROGRAMME_NAME ";

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

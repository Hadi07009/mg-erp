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
    public class SewingThreadPriceDAL
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


        public string deleteSewingThreadRecord(SewingThreadPriceDTO objSewingThreadPriceDTO)
        {

            OracleTransaction trans = null;
            string strMsg = "";
            OracleCommand objOracleCommand = new OracleCommand("pro_sewing_thread_delete_all");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


          
            if (objSewingThreadPriceDTO.SupplierId != "")
            {
                objOracleCommand.Parameters.Add("P_SUPPLIER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingThreadPriceDTO.SupplierId;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_SUPPLIER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }





            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingThreadPriceDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingThreadPriceDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingThreadPriceDTO.BranchOfficeId;

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

        public DataTable getBrandId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            string sql = "";
            sql = "select ' ' BRAND_ID, ' Please Select One ' brand_name from dual " +
                    "union " +

                "SELECT " +
                  "to_char(BRAND_ID), " +
                  "to_char(brand_name) " +
                  "FROM L_BRAND ORDER BY  brand_name";

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



        public string saveSewingThreadOpeninigBalance(SewingThreadPriceDTO objSewingThreadPriceDTO)
        {

            OracleTransaction trans = null;
            string strMsg = "";
            OracleCommand objOracleCommand = new OracleCommand("pro_sewing_thread_ob_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objSewingThreadPriceDTO.ThreadId != "")
            {
                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingThreadPriceDTO.ThreadId;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingThreadPriceDTO.SupplierId != "")
            {
                objOracleCommand.Parameters.Add("P_SUPPLIER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingThreadPriceDTO.SupplierId;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_SUPPLIER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingThreadPriceDTO.ProgrammeId != "")
            {
                objOracleCommand.Parameters.Add("P_PROGRAMME_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingThreadPriceDTO.ProgrammeId;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_PROGRAMME_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingThreadPriceDTO.ArtNo != "")
            {
                objOracleCommand.Parameters.Add("P_ART_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingThreadPriceDTO.ArtNo;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_ART_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingThreadPriceDTO.ThreadCount != "")
            {
                objOracleCommand.Parameters.Add("P_THREAD_COUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingThreadPriceDTO.ThreadCount;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_THREAD_COUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objSewingThreadPriceDTO.BalanceQuantity != "")
            {
                objOracleCommand.Parameters.Add("P_BALANCE_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingThreadPriceDTO.BalanceQuantity;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_BALANCE_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }







            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingThreadPriceDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingThreadPriceDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingThreadPriceDTO.BranchOfficeId;

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

        public DataTable searchSewingThreadOpeningBalance(SewingThreadPriceDTO objSewingThreadPriceDTO)
        {


            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +



                               "to_char(NVL(ART_NO,'0'))ART_NO, " +
                               "to_char(NVL(THREAD_COUNT,'0'))THREAD_COUNT, " +
                               "to_char(NVL(QUANTITY,'0'))QUANTITY, " +
                               "to_char(NVL(TRAN_ID,'0'))TRAN_ID " +



                               " FROM  VEW_SEWING_THREAD_OB_SUB where head_office_id = '" + objSewingThreadPriceDTO.HeadOfficeId + "' AND branch_office_id = '" + objSewingThreadPriceDTO.BranchOfficeId + "' ";

            if (objSewingThreadPriceDTO.SupplierId.Length > 0)
            {

                sql = sql + "and supplier_id = '" + objSewingThreadPriceDTO.SupplierId + "'";
            }

            if (objSewingThreadPriceDTO.ProgrammeId.Length > 0)
            {

                sql = sql + "and programme_id = '" + objSewingThreadPriceDTO.ProgrammeId + "'";
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


        public string deleteSewingThreadOpeningBalanceRecord(SewingThreadPriceDTO objSewingThreadPriceDTO)
        {

            OracleTransaction trans = null;
            string strMsg = "";
            OracleCommand objOracleCommand = new OracleCommand("pro_sewing_thread_delete_all");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            if (objSewingThreadPriceDTO.SupplierId != "")
            {
                objOracleCommand.Parameters.Add("P_SUPPLIER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingThreadPriceDTO.SupplierId;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_SUPPLIER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingThreadPriceDTO.ProgrammeId != "")
            {
                objOracleCommand.Parameters.Add("P_PROGRAMME_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingThreadPriceDTO.ProgrammeId;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_PROGRAMME_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            
            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingThreadPriceDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingThreadPriceDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingThreadPriceDTO.BranchOfficeId;

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

        public string deleteSewingThreadOpeninigBalanceRecordById(SewingThreadPriceDTO objSewingThreadPriceDTO)
        {

            OracleTransaction trans = null;
            string strMsg = "";
            OracleCommand objOracleCommand = new OracleCommand("pro_sewing_thread_ob_delete");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objSewingThreadPriceDTO.ThreadId != "")
            {
                objOracleCommand.Parameters.Add("P_THREAD_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingThreadPriceDTO.ThreadId;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_THREAD_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingThreadPriceDTO.SupplierId != "")
            {
                objOracleCommand.Parameters.Add("P_SUPPLIER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingThreadPriceDTO.SupplierId;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_SUPPLIER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingThreadPriceDTO.ProgrammeId != "")
            {
                objOracleCommand.Parameters.Add("P_PROGRAMME_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingThreadPriceDTO.ProgrammeId;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_PROGRAMME_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }





            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingThreadPriceDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingThreadPriceDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingThreadPriceDTO.BranchOfficeId;

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

        public string saveSewingThreadPriceInfo(SewingThreadPriceDTO objSewingThreadPriceDTO)
        {

            OracleTransaction trans = null;
            string strMsg = "";
            OracleCommand objOracleCommand = new OracleCommand("PRO_SEWING_THREAD_PRICE_SAVE");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objSewingThreadPriceDTO.TranId != "")
            {
                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingThreadPriceDTO.TranId;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingThreadPriceDTO.SupplierId != "")
            {
                objOracleCommand.Parameters.Add("P_SUPPLIER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingThreadPriceDTO.SupplierId;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_SUPPLIER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingThreadPriceDTO.ThreadCount != "")
            {
                objOracleCommand.Parameters.Add("P_THREAD_COUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingThreadPriceDTO.ThreadCount;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_THREAD_COUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }




            if (objSewingThreadPriceDTO.PriceRate != "")
            {
                objOracleCommand.Parameters.Add("P_RATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingThreadPriceDTO.PriceRate;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_RATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objSewingThreadPriceDTO.ColorId != "")
            {
                objOracleCommand.Parameters.Add("P_COLOR_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingThreadPriceDTO.ColorId;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_COLOR_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objSewingThreadPriceDTO.CurrencyId != "")
            {
                objOracleCommand.Parameters.Add("P_CURRENCY_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingThreadPriceDTO.CurrencyId;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_CURRENCY_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objSewingThreadPriceDTO.BrandId != "")
            {
                objOracleCommand.Parameters.Add("P_BRAND_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingThreadPriceDTO.BrandId;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_BRAND_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }



            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingThreadPriceDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingThreadPriceDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingThreadPriceDTO.BranchOfficeId;

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


        public DataTable LoadSewingThreadRecord(SewingThreadPriceDTO objSewingThreadPriceDTO)
        {


            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +


                               "to_char(NVL(TRAN_ID,'0'))TRAN_ID, " +

                               "to_char(NVL(THREAD_COUNT,'0'))THREAD_COUNT, " +
                              
                               "to_char(NVL(RATE,'0'))RATE, " +
                                "to_char(NVL(COLOR_ID,'0'))COLOR_ID, " +
                                "to_char(NVL(CURRENCY_ID,'0'))CURRENCY_ID, " +
                                 "to_char(NVL(CURRENCY_NAME,'0'))CURRENCY_NAME, " +
                                 "to_char(NVL(BRAND_ID,'0'))BRAND_ID, " +
                                 "to_char(NVL(BRAND_NAME,'0'))BRAND_NAME " +


                               " FROM  VEW_SEARCH_SEWING_PRICE_SUB where head_office_id = '" + objSewingThreadPriceDTO.HeadOfficeId + "' AND branch_office_id = '" + objSewingThreadPriceDTO.BranchOfficeId + "' ";

            if (objSewingThreadPriceDTO.SupplierId.Length > 0)
            {

                sql = sql + "and supplier_id = '" + objSewingThreadPriceDTO.SupplierId + "'";
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

        public string deleteSewingThreadRecordById(SewingThreadPriceDTO objSewingThreadPriceDTO)
        {

            OracleTransaction trans = null;
            string strMsg = "";
            OracleCommand objOracleCommand = new OracleCommand("PRO_DELET_SEWING_THREAD_RECORD");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objSewingThreadPriceDTO.TranId != "")
            {
                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingThreadPriceDTO.TranId;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingThreadPriceDTO.SupplierId != "")
            {
                objOracleCommand.Parameters.Add("P_SUPPLIER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingThreadPriceDTO.SupplierId;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_SUPPLIER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }





            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingThreadPriceDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingThreadPriceDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingThreadPriceDTO.BranchOfficeId;

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

        public string saveSewingThreadReceiveInfo(SewingThreadPriceDTO objSewingThreadPriceDTO)
        {




            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("PRO_SEWING_THREAD_RECEIVE_SAVE");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objSewingThreadPriceDTO.TranId != "")
            {

                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingThreadPriceDTO.TranId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }



            if (objSewingThreadPriceDTO.SupplierId != "")
            {

                objOracleCommand.Parameters.Add("P_SUPPLIER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingThreadPriceDTO.SupplierId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SUPPLIER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objSewingThreadPriceDTO.ReceiveDate != "")
            {

                objOracleCommand.Parameters.Add("P_RECEIVE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingThreadPriceDTO.ReceiveDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_RECEIVE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objSewingThreadPriceDTO.ChallanNo != "")
            {

                objOracleCommand.Parameters.Add("P_CHALLAN_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingThreadPriceDTO.ChallanNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_CHALLAN_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingThreadPriceDTO.ProgrammeId != "")
            {

                objOracleCommand.Parameters.Add("P_PROGRAMME_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingThreadPriceDTO.ProgrammeId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PROGRAMME_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingThreadPriceDTO.ColorId != "")
            {

                objOracleCommand.Parameters.Add("P_COLOR_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingThreadPriceDTO.ColorId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_COLOR_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objSewingThreadPriceDTO.DollarToTaka != "")
            {

                objOracleCommand.Parameters.Add("P_DOLLAR_TO_TK", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingThreadPriceDTO.DollarToTaka;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_DOLLAR_TO_TK", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }




            if (objSewingThreadPriceDTO.BrandId != "")
            {

                objOracleCommand.Parameters.Add("P_BRAND_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingThreadPriceDTO.BrandId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_BRAND_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objSewingThreadPriceDTO.ThreadCount != "")
            {

                objOracleCommand.Parameters.Add("P_THREAD_COUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingThreadPriceDTO.ThreadCount;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_THREAD_COUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objSewingThreadPriceDTO.ArtId != "")
            {

                objOracleCommand.Parameters.Add("P_ART_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingThreadPriceDTO.ArtId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_ART_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }




            if (objSewingThreadPriceDTO.Quantity != "")
            {

                objOracleCommand.Parameters.Add("P_RECEIVE_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingThreadPriceDTO.Quantity;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_RECEIVE_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objSewingThreadPriceDTO.Rate != "")
            {

                objOracleCommand.Parameters.Add("P_RATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingThreadPriceDTO.Rate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_RATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingThreadPriceDTO.CurrencyId != "")
            {

                objOracleCommand.Parameters.Add("P_CURRENCY_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingThreadPriceDTO.CurrencyId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_CURRENCY_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objSewingThreadPriceDTO.TotalAmount != "")
            {

                objOracleCommand.Parameters.Add("P_TOTAL_AMOUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingThreadPriceDTO.TotalAmount;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_TOTAL_AMOUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingThreadPriceDTO.DollarToTaka != "")
            {

                objOracleCommand.Parameters.Add("P_TOTAL_AMOUNT_USD", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingThreadPriceDTO.DollarToTaka;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_TOTAL_AMOUNT_USD", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingThreadPriceDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingThreadPriceDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingThreadPriceDTO.BranchOfficeId;


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

        public DataTable searchSewingThreadReceiveRecord(SewingThreadPriceDTO objSewingThreadPriceDTO)
        {


            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
                   "to_char(NVL(TRAN_ID,'0'))TRAN_ID, " +
                   "to_char(NVL(THREAD_COUNT,0))THREAD_COUNT, " +
                   "to_char(NVL(ART_ID,'0'))ART_ID, " +
                   "to_char(NVL(RECEIVE_QUANTITY,'0'))RECEIVE_QUANTITY, " +
                   "to_char(NVL(RATE,'0'))RATE, " +
                   "to_char(NVL(CURRENCY_ID, '0'))CURRENCY_ID, " +
                   "to_char(NVL(TOTAL_AMOUNT, '0'))TOTAL_AMOUNT, " +
                     "to_char(NVL(TOTAL_AMOUNT_USD, '0'))TOTAL_AMOUNT_USD " +


                  " FROM VEW_SEARCH_SEWING_RECEIVE_SUB WHERE head_office_id = '" + objSewingThreadPriceDTO.HeadOfficeId + "' and  branch_office_id = '" + objSewingThreadPriceDTO.BranchOfficeId + "'  ";



            if (objSewingThreadPriceDTO.ReceiveDate.Length > 6)
            {

                sql = sql + "and RECEIVE_DATE = TO_DATE('" + objSewingThreadPriceDTO.ReceiveDate + "', 'dd/mm/yyyy') ";
            }


            if (objSewingThreadPriceDTO.ChallanNo.Length > 0)
            {

                sql = sql + "and CHALLAN_NO = '" + objSewingThreadPriceDTO.ChallanNo + "' ";
            }



            if (objSewingThreadPriceDTO.SupplierId.Length > 0)
            {

                sql = sql + "and SUPPLIER_ID = '" + objSewingThreadPriceDTO.SupplierId + "'";
            }


            if (objSewingThreadPriceDTO.ColorId.Length > 0)
            {

                sql = sql + "and color_id = '" + objSewingThreadPriceDTO.ColorId + "'";
            }

            if (objSewingThreadPriceDTO.BrandId.Length > 0)
            {

                sql = sql + "and brand_id = '" + objSewingThreadPriceDTO.BrandId + "'";
            }


            if (objSewingThreadPriceDTO.ProgrammeId.Length > 0)
            {

                sql = sql + "and programme_id = '" + objSewingThreadPriceDTO.ProgrammeId + "'";
            }


            //sql = sql + "order by SL ";

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
        public string deleteSewingThreadReceiveRecord(SewingThreadPriceDTO objSewingThreadPriceDTO)
        {

            OracleTransaction trans = null;
            string strMsg = "";
            OracleCommand objOracleCommand = new OracleCommand("PRO_DELETE_SEWING_RECEIVE");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objSewingThreadPriceDTO.TranId != "")
            {
                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingThreadPriceDTO.TranId;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingThreadPriceDTO.ChallanNo != "")
            {
                objOracleCommand.Parameters.Add("P_CHALLAN_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingThreadPriceDTO.ChallanNo;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_CHALLAN_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingThreadPriceDTO.ReceiveDate != "")
            {
                objOracleCommand.Parameters.Add("P_RECEIVE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingThreadPriceDTO.ReceiveDate;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_RECEIVE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }





            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingThreadPriceDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingThreadPriceDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingThreadPriceDTO.BranchOfficeId;

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

        public SewingThreadPriceDTO searchSewingThreadReceiveMain(string strReceiveDate, string strSupplierId, string strHeadOfficeId, string strBranchOfficeId)
        {
            SewingThreadPriceDTO objSewingThreadPriceDTO = new SewingThreadPriceDTO();
            string sql = "";

            sql = "SELECT " +



                               "to_char(NVL(CHALLAN_NO,'0'))CHALLAN_NO, " +
                               "to_char(NVL(COLOR_ID,'0'))COLOR_ID, " +
                               "to_char(NVL(BRAND_ID,'0'))BRAND_ID, " +
                               "to_char(NVL(PROGRAMME_ID,'0'))PROGRAMME_ID, " +
                               "to_char(NVL(DOLLAR_TO_TK,'0'))DOLLAR_TO_TK " +


                               " FROM  VEW_SEARCH_SEWING_RECEIVE_MAIN where head_office_id = '" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "' ";

            if (strSupplierId.Length > 0)
            {

                sql = sql + "and supplier_id = '"+ strSupplierId + "' ";
            }

            if (strReceiveDate.Length > 0)
            {

                sql = sql + "and RECEIVE_DATE = to_Date('" + strReceiveDate + "', 'dd/mm/yyyy') ";
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

                        objSewingThreadPriceDTO.ChallanNo = objDataReader.GetString(0); ;
                        objSewingThreadPriceDTO.ColorId = objDataReader.GetString(1);
                        objSewingThreadPriceDTO.BrandId = objDataReader.GetString(2);
                        objSewingThreadPriceDTO.ProgrammeId = objDataReader.GetString(3);
                        objSewingThreadPriceDTO.DollarToTaka = objDataReader.GetString(4);
                      
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
            return objSewingThreadPriceDTO;
        }
    }
}

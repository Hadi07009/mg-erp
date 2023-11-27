using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;

using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Configuration;

namespace SINHA.MEDLAR.ERP.DAL
{
    public class BuyerDAL
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

        public string saveBuyerInformation(BuyerDTO objBuyerDTO)
        {

           
            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("pro_buyer_information_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objBuyerDTO.BuyerId != "")
            {

                objOracleCommand.Parameters.Add("P_BUYER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objBuyerDTO.BuyerId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_BUYER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objBuyerDTO.BuyerShortName != "")
            {

                objOracleCommand.Parameters.Add("P_BUYER_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objBuyerDTO.BuyerShortName;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_BUYER_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }



            if (objBuyerDTO.ContactNo != "")
            {

                objOracleCommand.Parameters.Add("P_CONTACT_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objBuyerDTO.ContactNo;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_CONTACT_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objBuyerDTO.EmailAddress != "")
            {

                objOracleCommand.Parameters.Add("P_EMAIL_ADDRESS", OracleDbType.Varchar2, ParameterDirection.Input).Value = objBuyerDTO.EmailAddress;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_EMAIL_ADDRESS", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objBuyerDTO.Address != "")
            {

                objOracleCommand.Parameters.Add("P_ADDRESS", OracleDbType.Varchar2, ParameterDirection.Input).Value = objBuyerDTO.Address;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_ADDRESS", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            objOracleCommand.Parameters.Add("P_ACTIVE_YN", OracleDbType.Varchar2, ParameterDirection.Input).Value = objBuyerDTO.ActiveYn;


            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objBuyerDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objBuyerDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objBuyerDTO.BranchOfficeId;
         

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
       
        public string saveBuyerEntryRecord(BuyerDTO objBuyerDTO)
        {



            string strMsg = "";


            OracleCommand objOracleCommand = new OracleCommand("pro_buyer_save_store");

            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objBuyerDTO.BuyerId != "")
            {
                objOracleCommand.Parameters.Add("P_BUYER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objBuyerDTO.BuyerId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_BUYER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            if (objBuyerDTO.BuyerName != "")
            {
                objOracleCommand.Parameters.Add("P_BUYER_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objBuyerDTO.BuyerName;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_BUYER_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objBuyerDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objBuyerDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objBuyerDTO.BranchOfficeId;


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
        public string saveSupplierInfo(BuyerDTO objBuyerDTO)
        {


            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("pro_supplier_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objBuyerDTO.SupplierId != "")
            {

                objOracleCommand.Parameters.Add("P_SUPPLIER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objBuyerDTO.SupplierId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_SUPPLIER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objBuyerDTO.SupplierName != "")
            {

                objOracleCommand.Parameters.Add("P_SUPPLIER_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objBuyerDTO.SupplierName;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_SUPPLIER_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


           


            if (objBuyerDTO.ContactNo != "")
            {

                objOracleCommand.Parameters.Add("P_CONTACT_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objBuyerDTO.ContactNo;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_CONTACT_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objBuyerDTO.EmailAddress != "")
            {

                objOracleCommand.Parameters.Add("P_EMAIL_ADDRESS", OracleDbType.Varchar2, ParameterDirection.Input).Value = objBuyerDTO.EmailAddress;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_EMAIL_ADDRESS", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objBuyerDTO.Address != "")
            {

                objOracleCommand.Parameters.Add("P_ADDRESS", OracleDbType.Varchar2, ParameterDirection.Input).Value = objBuyerDTO.Address;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_ADDRESS", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


         

            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objBuyerDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objBuyerDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objBuyerDTO.BranchOfficeId;


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


        public BuyerDTO searchBuyerRecord(string strBuyerID)
        {

            BuyerDTO objBuyerDTO = new BuyerDTO();

            string sql = "";
            sql = "SELECT " +

                  "BUYER_FULL_NAME " +


                  "FROM L_BUYER_STORE WHERE BUYER_ID = '" + strBuyerID + "'";




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


                        objBuyerDTO.BuyerName = objDataReader.GetString(0);

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


            return objBuyerDTO;

        }


        public DataTable loadBuyerEntry(string strHeadOfficeId, string strBranchOfficeId)
        {



            DataTable dt = new DataTable();

            string sql = "";
            sql = "SELECT " +

                  "* FROM L_BUYER_STORE where head_office_id = '" + strHeadOfficeId + "' and branch_office_id = '" + strBranchOfficeId + "'  ORDER BY BUYER_NAME";

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


    }
}

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
    public class ShipmentInfoDAL
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
        public string saveShipmentInfo(ShipmentInfoDTO objShipmentInfoDTO)
        {

            ShipmentInfoDAL objShipmentInfoDAL = new ShipmentInfoDAL();

            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("pro_shipment_info_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objShipmentInfoDTO.TranId != "")
            {

                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objShipmentInfoDTO.TranId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objShipmentInfoDTO.InvoiceNo != "")
            {

                objOracleCommand.Parameters.Add("P_INVOICE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objShipmentInfoDTO.InvoiceNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_INVOICE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objShipmentInfoDTO.InvoiceDate.Length > 6)
            {

                objOracleCommand.Parameters.Add("P_INVOICE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objShipmentInfoDTO.InvoiceDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_INVOICE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            
            if (objShipmentInfoDTO.ShipDate.Length > 6)
            {

                objOracleCommand.Parameters.Add("P_SHIPMENT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objShipmentInfoDTO.ShipDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SHIPMENT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objShipmentInfoDTO.BuyerId != "")
            {

                objOracleCommand.Parameters.Add("P_BUYER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objShipmentInfoDTO.BuyerId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_BUYER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objShipmentInfoDTO.Remarks != "")
            {

                objOracleCommand.Parameters.Add("P_REMARKS", OracleDbType.Varchar2, ParameterDirection.Input).Value = objShipmentInfoDTO.Remarks;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_REMARKS", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objShipmentInfoDTO.PONo != "")
            {

                objOracleCommand.Parameters.Add("P_PO_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objShipmentInfoDTO.PONo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PO_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objShipmentInfoDTO.StyleId != "")
            {

                objOracleCommand.Parameters.Add("P_STYLE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objShipmentInfoDTO.StyleId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_STYLE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objShipmentInfoDTO.Rate != "")
            {

                objOracleCommand.Parameters.Add("P_RATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objShipmentInfoDTO.Rate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_RATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objShipmentInfoDTO.Quantity != "")
            {

                objOracleCommand.Parameters.Add("P_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objShipmentInfoDTO.Quantity;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            
            if (objShipmentInfoDTO.Amount != "")
            {

                objOracleCommand.Parameters.Add("P_AMOUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objShipmentInfoDTO.Amount;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_AMOUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }



            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objShipmentInfoDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objShipmentInfoDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objShipmentInfoDTO.BranchOfficeId;


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


        public DataTable LoadShipmentInfoSub(ShipmentInfoDTO objShipmentInfoDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +

                    "TO_CHAR(NVL(TRAN_ID,''))TRAN_ID, " +
                     "TO_CHAR(NVL(PO_NO,''))PO_NO, " +
                     "TO_CHAR(NVL(STYLE_ID,''))STYLE_ID, " +
                     "TO_CHAR(NVL(STYLE_NO,''))STYLE_NO, " +
                     "TO_CHAR(NVL(RATE,''))RATE, " +
                     "TO_CHAR(NVL(QUANTITY,''))QUANTITY, " +
                     "TO_CHAR(NVL(AMOUNT,''))AMOUNT " +

                  "FROM VEW_SHIPMENT_SUB WHERE INVOICE_NO ='" + objShipmentInfoDTO.InvoiceNo + "' AND head_office_id = '" + objShipmentInfoDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objShipmentInfoDTO.BranchOfficeId + "' ";

            if (objShipmentInfoDTO.InvoiceDate.Length > 0)
            {
                sql = sql + " and INVOICE_DATE = TO_DATE('" + objShipmentInfoDTO.InvoiceDate + "','dd/mm/yyyy') ";

            }
            if (objShipmentInfoDTO.ShipDate.Length > 0)
            {
                sql = sql + " and SHIPMENT_DATE = TO_DATE('" + objShipmentInfoDTO.ShipDate + "','dd/mm/yyyy') ";

            }
            sql = sql + " ORDER BY  TRAN_ID ";

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


        public ShipmentInfoDTO searchShipmentInfoMain(string strInvoiceNo, string strHeadOfficeId, string strBranchOfficeId)
        {


            ShipmentInfoDTO objShipmentInfoDTO = new ShipmentInfoDTO();
            ShipmentInfoDAL objShipmentInfoDAL = new ShipmentInfoDAL();

            string sql = "";
            sql = "SELECT " +

                   "TO_CHAR (NVL (INVOICE_NO,'0'))INVOICE_NO, " +
                   "TO_CHAR (NVL (INVOICE_DATE,'0'))INVOICE_DATE, " +
                   "TO_CHAR (NVL (SHIPMENT_DATE,'0'))SHIPMENT_DATE, " +
                   "TO_CHAR (NVL (BUYER_ID,'0'))BUYER_ID, " +
                   "TO_CHAR (NVL (BUYER_FULL_NAME,'0'))BUYER_FULL_NAME, " +
                   "TO_CHAR (NVL (REMARKS,'0'))REMARKS " +


                    "from VEW_SHIPMENT_MAIN where INVOICE_NO = '" + strInvoiceNo + "' AND head_office_id = '" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "'";


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


                        objShipmentInfoDTO.InvoiceNo = objDataReader.GetString(0);
                        objShipmentInfoDTO.InvoiceDate = objDataReader.GetString(1);
                        objShipmentInfoDTO.ShipDate = objDataReader.GetString(2);
                        objShipmentInfoDTO.BuyerId = objDataReader.GetString(3);
                        objShipmentInfoDTO.BuyerFullName = objDataReader.GetString(4);
                        objShipmentInfoDTO.Remarks = objDataReader.GetString(5);
                       
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



            return objShipmentInfoDTO;


        }
        public List<string> SearchInvoiceNo(string strInvoiceNo, string strBuyerId)
        {

            List<string> allInvoiceNo = new List<string>();

            string sql = "";

            sql = "SELECT " +

                     "TO_CHAR(NVL(INVOICE_NO,''))INVOICE_NO " +

               "FROM SHIPMENT_MAIN WHERE (lower(INVOICE_NO) like lower( '%" + strInvoiceNo + "%')  or upper(INVOICE_NO)like upper('%" + strInvoiceNo + "%'))";

            if (strBuyerId.Length > 0)
            {
                sql = sql + "and BUYER_ID = '" + strBuyerId + "'";

            }
            sql = sql + "ORDER BY INVOICE_NO";

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
                        allInvoiceNo.Add(objDataReader.GetString(0));

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




            return allInvoiceNo;

        }

        public string deleteShipmentInfoSubRecord(ShipmentInfoDTO objShipmentInfoDTO)
        {

            ShipmentInfoDAL objShipmentInfoDAL = new ShipmentInfoDAL();

            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("PRO_DELETE_SHIPMENT_SUB");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objShipmentInfoDTO.TranId != "")
            {

                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objShipmentInfoDTO.TranId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objShipmentInfoDTO.InvoiceNo != "")
            {

                objOracleCommand.Parameters.Add("P_INVOICE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objShipmentInfoDTO.InvoiceNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_INVOICE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objShipmentInfoDTO.InvoiceDate.Length > 6)
            {

                objOracleCommand.Parameters.Add("P_INVOICE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objShipmentInfoDTO.InvoiceDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_INVOICE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objShipmentInfoDTO.BuyerId != "")
            {

                objOracleCommand.Parameters.Add("P_BUYER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objShipmentInfoDTO.BuyerId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_BUYER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objShipmentInfoDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objShipmentInfoDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objShipmentInfoDTO.BranchOfficeId;


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
        public string deleteShipmentInfoRecord(ShipmentInfoDTO objShipmentInfoDTO)
        {

            ShipmentInfoDAL objShipmentInfoDAL = new ShipmentInfoDAL();

            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("PRO_DELETE_SHIPMENT_INFO");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objShipmentInfoDTO.InvoiceNo != "")
            {

                objOracleCommand.Parameters.Add("P_INVOICE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objShipmentInfoDTO.InvoiceNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_INVOICE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objShipmentInfoDTO.InvoiceDate.Length > 6)
            {

                objOracleCommand.Parameters.Add("P_INVOICE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objShipmentInfoDTO.InvoiceDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_INVOICE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objShipmentInfoDTO.BuyerId != "")
            {

                objOracleCommand.Parameters.Add("P_BUYER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objShipmentInfoDTO.BuyerId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_BUYER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objShipmentInfoDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objShipmentInfoDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objShipmentInfoDTO.BranchOfficeId;


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
        public ShipmentInfoDTO chkPONo(string strPONo, string strBuyerId, string strHeadOfficeId, string strBranchOfficeId)
        {


            ShipmentInfoDTO objShipmentInfoDTO = new ShipmentInfoDTO();
            ShipmentInfoDAL objShipmentInfoDAL = new ShipmentInfoDAL();

            string sql = "";
            sql = "SELECT " +

                     "'Y' " +

                    "from PO_ASSIGN where PO_NO = '" + strPONo + "' AND BUYER_ID= '" + strBuyerId + "' AND head_office_id = '" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "' ";


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


                        objShipmentInfoDTO.ChkYN = objDataReader.GetString(0);

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



            return objShipmentInfoDTO;


        }

        public ShipmentInfoDTO chkStyleNo(string strStyleNo, string strBuyerId, string strHeadOfficeId, string strBranchOfficeId)
        {


            ShipmentInfoDTO objShipmentInfoDTO = new ShipmentInfoDTO();
            ShipmentInfoDAL objShipmentInfoDAL = new ShipmentInfoDAL();

            string sql = "";
            sql = "SELECT " +

                     "'Y' " +

                    "from L_STYLE where STYLE_NO = '" + strStyleNo + "' AND BUYER_ID= '" + strBuyerId + "' AND head_office_id = '" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "' ";


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


                        objShipmentInfoDTO.ChkYN = objDataReader.GetString(0);

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



            return objShipmentInfoDTO;


        }

    }
}

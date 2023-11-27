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
    public class ShipmentEntryDAL
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


        public string saveShipmentEntry(ShipmentEntryDTO objShipmentEntryDTO)
        {
            
            OracleTransaction trans = null;
            string strMsg = "";
            OracleCommand objOracleCommand = new OracleCommand("pro_shipment_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objShipmentEntryDTO.InvoiceNo != "")
            {
                objOracleCommand.Parameters.Add("P_PO_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objShipmentEntryDTO.InvoiceNo;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_PO_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objShipmentEntryDTO.InvoiceDate != "")
            {
                objOracleCommand.Parameters.Add("P_INVOICE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objShipmentEntryDTO.InvoiceDate;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_INVOICE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objShipmentEntryDTO.ShipmentDate != "")
            {
                objOracleCommand.Parameters.Add("P_SHIPMENT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objShipmentEntryDTO.ShipmentDate;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_SHIPMENT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objShipmentEntryDTO.BuyerId != "")
            {
                objOracleCommand.Parameters.Add("P_BUYER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objShipmentEntryDTO.BuyerId;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_BUYER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objShipmentEntryDTO.Remarks != "")
            {
                objOracleCommand.Parameters.Add("P_REMARKS", OracleDbType.Varchar2, ParameterDirection.Input).Value = objShipmentEntryDTO.Remarks;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_REMARKS", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }



            if (objShipmentEntryDTO.POId != "")
            {
                objOracleCommand.Parameters.Add("P_NO_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objShipmentEntryDTO.POId;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_NO_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objShipmentEntryDTO.StyleNo != "")
            {
                objOracleCommand.Parameters.Add("P_STYLE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objShipmentEntryDTO.StyleNo;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_STYLE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objShipmentEntryDTO.UnitRate != "")
            {
                objOracleCommand.Parameters.Add("P_UNIT_RATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objShipmentEntryDTO.UnitRate;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_UNIT_RATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objShipmentEntryDTO.Quantity != "")
            {
                objOracleCommand.Parameters.Add("P_SHIPMENT_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objShipmentEntryDTO.Quantity;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_SHIPMENT_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objShipmentEntryDTO.Amount != "")
            {
                objOracleCommand.Parameters.Add("P_AMOUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objShipmentEntryDTO.Amount;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_AMOUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objShipmentEntryDTO.BranchOfficeIdAll != "")
            {
                objOracleCommand.Parameters.Add("P_SHIPMENT_ASSIGN_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objShipmentEntryDTO.BranchOfficeIdAll;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_SHIPMENT_ASSIGN_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objShipmentEntryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objShipmentEntryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objShipmentEntryDTO.BranchOfficeId;

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


        public DataTable searchShipmentInfo(ShipmentEntryDTO objShipmentEntryDTO)
        {


            DataTable dt = new DataTable();

            string sql = "";
            sql = "SELECT " +
                   "rownum sl, " +
                   "INVOICE_NO, "+
                   "BRANCH_OFFICE_NAME, "+
                   "PO_NO, " +
                   "STYLE_NO, " +
                   "UNIT_RATE, " +
                   "QUANTITY, " +
                   "AMOUNT "+



                  " FROM VEW_SEARCH_SHIPMENT_ENTRY where head_office_id = '" + objShipmentEntryDTO.HeadOfficeId + "' and branch_office_id = '" + objShipmentEntryDTO.BranchOfficeId + "' ";


            if (objShipmentEntryDTO.InvoiceFromDate.Length > 6 && objShipmentEntryDTO.InvoiceToDate.Length > 6)
            {
                sql = sql + " and INVOICE_DATE between  to_date ( '" + objShipmentEntryDTO.InvoiceFromDate + "', 'dd/mm/yyyy') and  to_date('" + objShipmentEntryDTO.InvoiceToDate + "', 'dd/mm/yyyy') ";

            }

            if (objShipmentEntryDTO.PONo.Length > 0)
            {

                sql = sql + " and PO_NO = '" + objShipmentEntryDTO.PONo + "' ";
            }

            if (objShipmentEntryDTO.BuyerId.Length > 0)
            {

                sql = sql + " and BUYER_ID = '" + objShipmentEntryDTO.BuyerId + "' ";
            }

            if (objShipmentEntryDTO.StyleNo.Length > 0)
            {

                sql = sql + " and style_no = '" + objShipmentEntryDTO.StyleNo + "' ";
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
        public DataTable searchShipmentEntry(ShipmentEntryDTO objShipmentEntryDTO)
        {


            DataTable dt = new DataTable();

            string sql = "";
            sql = "SELECT " +
                   "rownum sl, " +
                   "INVOICE_NO, " +
                   "to_char(INVOICE_DATE, 'dd/mm/yyyy')INVOICE_DATE, "+
                   "to_char(SHIPMENT_DATE, 'dd/mm/yyyy')SHIPMENT_DATE, " +
                   "BUYER_NAME, "+
                   "REMARKS, "+
                   "PO_NO, " +
                   "style_no, " +
                   "UNIT_RATE, " +
                   "QUANTITY, " +
                   "AMOUNT, " +
                   "SHIPMENT_ASSIGN_OFFICE_NAME "+



                  " FROM VEW_SEARCH_SHIPMENT_ENTRY where head_office_id = '" + objShipmentEntryDTO.HeadOfficeId + "' and branch_office_id = '" + objShipmentEntryDTO.BranchOfficeId + "' ";


            if (objShipmentEntryDTO.InvoiceNo.Length > 0)
            {

                sql = sql + " and INVOICE_NO = '" + objShipmentEntryDTO.InvoiceNo + "' ";
            }

            //if (objShipmentEntryDTO.InvoiceFromDate.Length > 6 && objShipmentEntryDTO.InvoiceToDate.Length > 6)
            //{
            //    sql = sql + " and INVOICE_DATE between  to_date ( '" + objShipmentEntryDTO.InvoiceFromDate + "', 'dd/mm/yyyy') and  to_date('" + objShipmentEntryDTO.InvoiceToDate + "', 'dd/mm/yyyy') ";

            //}

            //if (objShipmentEntryDTO.PONo.Length > 0)
            //{

            //    sql = sql + " and PO_NO = '" + objShipmentEntryDTO.PONo + "' ";
            //}

            //if (objShipmentEntryDTO.BuyerId.Length > 0)
            //{

            //    sql = sql + " and BUYER_ID = '" + objShipmentEntryDTO.BuyerId + "' ";
            //}

            //if (objShipmentEntryDTO.StyleNo.Length > 0)
            //{

            //    sql = sql + " and style_no = '" + objShipmentEntryDTO.StyleNo + "' ";
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
    }
}

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
    public class PurchaseOrderDAL
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

        public string purchasOrderSave(PurchaseOrderDTO objPurchaseOrderDTO)
        {

            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("pro_contact_sheet_save");

            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objPurchaseOrderDTO.PONo != "")
            {

                objOracleCommand.Parameters.Add("P_PO_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchaseOrderDTO.PONo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PO_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objPurchaseOrderDTO.StyleNo != "")
            {

                objOracleCommand.Parameters.Add("P_STYLE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchaseOrderDTO.StyleNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_STYLE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objPurchaseOrderDTO.DeliveryDate != "")
            {

                objOracleCommand.Parameters.Add("p_delivery_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchaseOrderDTO.DeliveryDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_delivery_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objPurchaseOrderDTO.Quantity != "")
            {

                objOracleCommand.Parameters.Add("p_order_quantity", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchaseOrderDTO.Quantity;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_order_quantity", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objPurchaseOrderDTO.sizeIdForQuantity != "")
            {

                objOracleCommand.Parameters.Add("p_size_id_for_quantity", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchaseOrderDTO.sizeIdForQuantity;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_size_id_for_quantity", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objPurchaseOrderDTO.SizeIdForPOPrice != "")
            {

                objOracleCommand.Parameters.Add("p_size_id_for_po_price", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchaseOrderDTO.SizeIdForPOPrice;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_size_id_for_po_price", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objPurchaseOrderDTO.Price != "")
            {

                objOracleCommand.Parameters.Add("p_po_price", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchaseOrderDTO.Price;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_po_price", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objPurchaseOrderDTO.HangerCost != "")
            {

                objOracleCommand.Parameters.Add("p_hanger_cost_price", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchaseOrderDTO.HangerCost;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_hanger_cost_price", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objPurchaseOrderDTO.UnitCost != "")
            {

                objOracleCommand.Parameters.Add("p_unit_cost", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchaseOrderDTO.UnitCost;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_unit_cost", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objPurchaseOrderDTO.Amount != "")
            {

                objOracleCommand.Parameters.Add("p_total_amount", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchaseOrderDTO.Amount;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_total_amount", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objPurchaseOrderDTO.ItemDesciptionId != "")
            {

                objOracleCommand.Parameters.Add("p_item_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchaseOrderDTO.ItemDesciptionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_item_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objPurchaseOrderDTO.ShippingAddressId != "")
            {

                objOracleCommand.Parameters.Add("p_shipping_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchaseOrderDTO.ShippingAddressId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_shipping_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }



            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchaseOrderDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchaseOrderDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchaseOrderDTO.BranchOfficeId;

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

        public DataTable searchPurchaseOrderEntry(PurchaseOrderDTO objPurchaseOrderDTO)
        {


            DataTable dt = new DataTable();

            string sql = "";
            sql = "SELECT " +
                   "rownum sl, " +
                   "PO_NO, " +
                   "STYLE_NO, "+
                   "to_char(DELIVERY_DATE, 'dd/mm/yyyy')DELIVERY_DATE, " +
                   "ORDER_QUANTITY, " +
                   "size_name, " +
                   "PO_PRICE, " +
                   "HANGER_COST_PRICE, " +
                   "UNIT_COST, " +
                   "TOTAL_AMOUNT, " +
                   "SHIPING_ADDRESS " +



                  " FROM vew_search_contact_sheet where head_office_id = '" + objPurchaseOrderDTO.HeadOfficeId + "' and branch_office_id = '" + objPurchaseOrderDTO.BranchOfficeId + "' ";


            //if (objShipmentEntryDTO.InvoiceNo.Length > 0)
            //{

            //    sql = sql + " and INVOICE_NO = '" + objShipmentEntryDTO.InvoiceNo + "' ";
            //}

            //if (objShipmentEntryDTO.InvoiceFromDate.Length > 6 && objShipmentEntryDTO.InvoiceToDate.Length > 6)
            //{
            //    sql = sql + " and INVOICE_DATE between  to_date ( '" + objShipmentEntryDTO.InvoiceFromDate + "', 'dd/mm/yyyy') and  to_date('" + objShipmentEntryDTO.InvoiceToDate + "', 'dd/mm/yyyy') ";

            //}

            if (objPurchaseOrderDTO.PONo.Length > 0)
            {

                sql = sql + " and PO_NO = '" + objPurchaseOrderDTO.PONo + "' ";
            }

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

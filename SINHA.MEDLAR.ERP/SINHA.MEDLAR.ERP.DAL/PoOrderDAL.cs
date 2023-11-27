using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SINHA.MEDLAR.ERP.DTO;

using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Configuration;

namespace SINHA.MEDLAR.ERP.DAL
{
    public class PoOrderDAL
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


        public string savePoOrderInfo(PoOrderDTO objPoOrderDTO)
        {

            ContractDAL objContractDAL = new ContractDAL();

            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("PRO_PO_ORDER_SAVE");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objPoOrderDTO.PoNumber != "")
            {

                objOracleCommand.Parameters.Add("P_PO_NUMBER", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoOrderDTO.PoNumber;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PO_NUMBER", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objPoOrderDTO.PoRequisitionNo != "")
            {

                objOracleCommand.Parameters.Add("P_REQUISITION_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoOrderDTO.PoRequisitionNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_REQUISITION_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objPoOrderDTO.IssueDate.Length > 6)
            {

                objOracleCommand.Parameters.Add("P_ISSUE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoOrderDTO.IssueDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_ISSUE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objPoOrderDTO.OfferNo != "")
            {

                objOracleCommand.Parameters.Add("P_OFFER_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoOrderDTO.OfferNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_OFFER_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objPoOrderDTO.DeliveryDate.Length > 6)
            {

                objOracleCommand.Parameters.Add("P_DELIVERY_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoOrderDTO.DeliveryDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_DELIVERY_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objPoOrderDTO.CurrencyId != "")
            {

                objOracleCommand.Parameters.Add("P_CURRENCY_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoOrderDTO.CurrencyId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_CURRENCY_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objPoOrderDTO.ShipmentModeId != "")
            {

                objOracleCommand.Parameters.Add("P_SHIPMENT_TYPE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoOrderDTO.ShipmentModeId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SHIPMENT_TYPE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objPoOrderDTO.PaymentModeId != "")
            {

                objOracleCommand.Parameters.Add("P_PAYMENT_MODOE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoOrderDTO.PaymentModeId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PAYMENT_MODOE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objPoOrderDTO.PartshipmentId != "")
            {

                objOracleCommand.Parameters.Add("P_PART_SHIPMENT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoOrderDTO.PartshipmentId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PART_SHIPMENT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objPoOrderDTO.TranshipmentId != "")
            {

                objOracleCommand.Parameters.Add("P_TRAN_SHIPMENT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoOrderDTO.TranshipmentId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_TRAN_SHIPMENT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objPoOrderDTO.TradeTerms != "")
            {

                objOracleCommand.Parameters.Add("P_TRADE_TERMS", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoOrderDTO.TradeTerms;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_TRADE_TERMS", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objPoOrderDTO.PortOfLoading != "")
            {

                objOracleCommand.Parameters.Add("P_PORT_OF_LOADING", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoOrderDTO.PortOfLoading;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PORT_OF_LOADING", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objPoOrderDTO.PortOfDischarges != "")
            {

                objOracleCommand.Parameters.Add("P_PORT_OF_DISCHARGE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoOrderDTO.PortOfDischarges;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PORT_OF_DISCHARGE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objPoOrderDTO.SupplierId != "")
            {

                objOracleCommand.Parameters.Add("P_SUPPLIER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoOrderDTO.SupplierId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SUPPLIER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            //new
            if (objPoOrderDTO.PurchaserId != "")
            {

                objOracleCommand.Parameters.Add("P_PURCHASER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoOrderDTO.PurchaserId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PURCHASER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objPoOrderDTO.Discount != "")
            {

                objOracleCommand.Parameters.Add("P_DISCOUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoOrderDTO.Discount;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_DISCOUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objPoOrderDTO.TotalAmount != "")
            {

                objOracleCommand.Parameters.Add("P_TOTAL_AMOUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoOrderDTO.TotalAmount;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_TOTAL_AMOUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objPoOrderDTO.ProductDescription != "")
            {

                objOracleCommand.Parameters.Add("P_PARTICULAR_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoOrderDTO.ProductDescription;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PARTICULAR_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

           

            if (objPoOrderDTO.PartNo != "")
            {

                objOracleCommand.Parameters.Add("P_PART_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoOrderDTO.PartNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PART_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objPoOrderDTO.PoUnitName != "")
            {

                objOracleCommand.Parameters.Add("P_PO_UNIT_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoOrderDTO.PoUnitName;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PO_UNIT_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objPoOrderDTO.ApprovedQty != "")
            {

                objOracleCommand.Parameters.Add("P_APPROVED_QTY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoOrderDTO.ApprovedQty;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_APPROVED_QTY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objPoOrderDTO.Rate != "")
            {

                objOracleCommand.Parameters.Add("P_RATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoOrderDTO.Rate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_RATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objPoOrderDTO.Price != "")
            {

                objOracleCommand.Parameters.Add("P_PRICE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoOrderDTO.Price;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PRICE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
           
            if (objPoOrderDTO.TranId != "")
            {

                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoOrderDTO.TranId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            
            if (objPoOrderDTO.Freight != "")
            {

                objOracleCommand.Parameters.Add("P_FREIGHT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoOrderDTO.Freight;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_FREIGHT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objPoOrderDTO.TrackingChargeFee != "")
            {

                objOracleCommand.Parameters.Add("P_TRACKING_CHARGE_FEE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoOrderDTO.TrackingChargeFee;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_TRACKING_CHARGE_FEE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objPoOrderDTO.PurchaseDate.Length > 6)
            {

                objOracleCommand.Parameters.Add("P_PURCHASE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoOrderDTO.PurchaseDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PURCHASE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objPoOrderDTO.Note.Length > 6)
            {

                objOracleCommand.Parameters.Add("P_NOTE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoOrderDTO.Note;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_NOTE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }




            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoOrderDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoOrderDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoOrderDTO.BranchOfficeId;


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
        public DataTable searchPoRequisitionInfo(string strPoRequisitionNo, string strPurchaseDate, string strEmployeeId, string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            string sql = "";
            string msg = "";
            string strCount1 = "", strCount2 = "";

            sql = "SELECT 'Y' " +


                "FROM PO_ORDER_MAIN WHERE head_office_id = '" + strHeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "' and requisition_no = '" + strPoRequisitionNo + "' and exists(select 1 from po_order_sub where  head_office_id = '" + strHeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "' and requisition_no = '" + strPoRequisitionNo + "') ";


            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {
                    msg = objDataReader.GetString(0);


                }
                strConn.Close();


            }


            if (msg == "Y")
            {



                string strMsg1 = "SELECT TO_CHAR (NVL (total_row,'0'))total_row " +
                      " FROM vew_count_reqisition_no WHERE head_office_id = '" + strHeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "' and requisition_no = '" + strPoRequisitionNo + "' and PURCHASE_DATE = to_Date('" + strPurchaseDate + "', 'dd/mm/yyyy') ";
                OracleCommand objComman3 = new OracleCommand(strMsg1);
                OracleDataReader objDataReader3;

                using (OracleConnection strConn = GetConnection())
                {

                    objComman3.Connection = strConn;
                    strConn.Open();
                    objDataReader3 = objComman3.ExecuteReader();
                    if (objDataReader3.Read())
                    {
                        strCount1 = objDataReader3.GetString(0);


                    }
                    strConn.Close();


                }




                string strMsg2 = "SELECT TO_CHAR (NVL (total_row,'0'))total_row " +
                      "FROM vew_count_po_order_sub WHERE head_office_id = '" + strHeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "' and requisition_no = '" + strPoRequisitionNo + "'  and PURCHASE_DATE = to_Date('" + strPurchaseDate + "', 'dd/mm/yyyy')   ";


                OracleCommand objCommand4 = new OracleCommand(strMsg2);
                OracleDataReader objDataReader4;

                using (OracleConnection strConn = GetConnection())
                {

                    objCommand4.Connection = strConn;
                    strConn.Open();
                    objDataReader4 = objCommand4.ExecuteReader();
                    if (objDataReader4.Read())
                    {
                        strCount2 = objDataReader4.GetString(0);


                    }
                    strConn.Close();


                }



                if (strCount1 != strCount2)
                {

                    ContractDAL objContractDAL = new ContractDAL();

                    string strMsg = "";
                    OracleTransaction trans = null;

                    OracleCommand objOracleCommand = new OracleCommand("pro_po_save_from_requisition");
                    objOracleCommand.CommandType = CommandType.StoredProcedure;


                    if (strPoRequisitionNo.Length > 0)
                    {

                        objOracleCommand.Parameters.Add("P_REQUISITION_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = strPoRequisitionNo;
                    }
                    else
                    {
                        objOracleCommand.Parameters.Add("P_REQUISITION_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

                    }



                    if (strPurchaseDate.Length > 6)
                    {

                        objOracleCommand.Parameters.Add("P_PURCHASE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = strPurchaseDate;
                    }
                    else
                    {
                        objOracleCommand.Parameters.Add("P_PURCHASE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

                    }



                    objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = strEmployeeId;
                    objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = strHeadOfficeId;
                    objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = strBranchOfficeId;


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



                    sql = "SELECT " +
                    "TO_CHAR (NVL (PO_NUMBER, ''))PO_NUMBER, " +
                    "TO_CHAR(ISSUE_DATE,'dd/mm/yyyy')ISSUE_DATE, " +
                    "TO_CHAR(DELIVERY_DATE,'dd/mm/yyyy')DELIVERY_DATE, " +
                    "TO_CHAR(NVL(PARTICULAR_NAME,''))PARTICULAR_NAME, " +
                    "TO_CHAR(NVL(PART_NO,''))PART_NO, " +

           //           " CASE  " +
           //   "WHEN v.po_unit_id IS NOT NULL  " +
           //   "THEN  " +
           //    "  (SELECT   TO_CHAR (NVL (PO_UNIT_NAME, ''))  " +
           //     "    FROM   l_PO_UNIT  " +
           //      "  WHERE   PO_UNIT_ID = v.PO_UNIT_ID)  " +
           //   "ELSE  " +
           //    "  (SELECT   TO_CHAR (NVL (PO_UNIT_NAME, ''))  " +
           //     "    FROM   l_PO_UNIT  " +
           //      "  WHERE   PO_UNIT_ID =  " +
           //       "            (SELECT   PO_UNIT_ID  " +
           //        "              FROM   po_requisition_sub  " +
           //         "            WHERE   part_no = v.part_no  " +
           //          "                   AND requisition_no = v.requisition_no))  " +
           //" END  " +
           //"  PO_UNIT_NAME, " +

           "TO_CHAR (NVL (PO_UNIT_NAME,''))PO_UNIT_NAME, " +

                    "TO_CHAR (NVL (APPROVED_QTY,'0'))APPROVED_QTY, " +
                    "TO_CHAR (NVL (RATE,'0'))RATE, " +
                    "TO_CHAR (NVL (PRICE,'0'))PRICE, " +
                    "TO_CHAR (NVL (TRAN_ID,''))TRAN_ID " +

                 " FROM VEW_PO_ORDER_SUB v WHERE  head_office_id = '" + strHeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "'  and requisition_no = '" + strPoRequisitionNo + "' order by TO_NUMBER(tran_id) ";

                }
                else
                {

                    sql = "SELECT " +
                    "TO_CHAR (NVL (PO_NUMBER, ''))PO_NUMBER, " +
                    "TO_CHAR(ISSUE_DATE,'dd/mm/yyyy')ISSUE_DATE, " +
                    "TO_CHAR(DELIVERY_DATE,'dd/mm/yyyy')DELIVERY_DATE, " +
                    "TO_CHAR(NVL(PARTICULAR_NAME,''))PARTICULAR_NAME, " +
                    "TO_CHAR(NVL(PART_NO,''))PART_NO, " +

           //         " CASE  "+
           //   "WHEN v.po_unit_id IS NOT NULL  "+
           //   "THEN  "+
           //    "  (SELECT   TO_CHAR (NVL (PO_UNIT_NAME, ''))  "+
           //     "    FROM   l_PO_UNIT  "+
           //      "  WHERE   PO_UNIT_ID = v.PO_UNIT_ID)  "+
           //   "ELSE  "+
           //    "  (SELECT   TO_CHAR (NVL (PO_UNIT_NAME, ''))  "+
           //     "    FROM   l_PO_UNIT  "+
           //      "  WHERE   PO_UNIT_ID =  "+
           //       "            (SELECT   PO_UNIT_ID  "+
           //        "              FROM   po_requisition_sub  "+
           //         "            WHERE   part_no = v.part_no  "+
           //          "                   AND requisition_no = v.requisition_no))  "+
           //" END  "+
           //"  PO_UNIT_NAME, "+



           "TO_CHAR (NVL (PO_UNIT_NAME,''))PO_UNIT_NAME, " +
                    "TO_CHAR (NVL (APPROVED_QTY,'0'))APPROVED_QTY, " +
                    "TO_CHAR (NVL (RATE,'0'))RATE, " +
                    "TO_CHAR (NVL (PRICE,'0'))PRICE, " +   
                    "TO_CHAR (NVL (TRAN_ID,''))TRAN_ID " +
                    

                    " FROM VEW_PO_ORDER_SUB v WHERE  head_office_id = '" + strHeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "'  and requisition_no = '" + strPoRequisitionNo + "' order by TO_NUMBER(tran_id) ";
                }
            }

            else
            {

                sql = "SELECT " +
                  "TO_CHAR (NVL (PARTICULAR_NAME, ''))PARTICULAR_NAME, " +
                  "TO_CHAR (NVL (PART_NO, ''))PART_NO, " +
                  "TO_CHAR (NVL (PO_UNIT_NAME,''))PO_UNIT_NAME, " +
                  "TO_CHAR (NVL (APPROVED_QTY, '0'))APPROVED_QTY, " +
                  "TO_CHAR (NVL (RATE, '0'))RATE, " +
                  "TO_CHAR (NVL (PRICE, ''))PRICE, " +
                  "TO_CHAR (NVL (TRAN_ID, ''))TRAN_ID " +
                 

                  " FROM VEW_PO_REQUISITION   WHERE REQUISITION_NO='" + strPoRequisitionNo + "' AND head_office_id = '" + strHeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "' and requisition_no = '" + strPoRequisitionNo + "'  order by TO_NUMBER(TRAN_ID) ";

            }



            OracleCommand objCommand2 = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand2);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand2.Connection = strConn;
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

        public DataTable GetRequisitionInfo(string requisitionNo, string employeeId, string headOfficeId, string branchOfficeId)
        {
            DataTable dt = new DataTable();
            string sql = "";
            string msg = "";

            //From PO
            sql = "SELECT " +
            "rownum, " +
            "TO_CHAR (NVL (PO_NUMBER, '')) PO_NO, " +
            "TO_CHAR (NVL (REQUISITION_NO, '')) REQUISITION_NO, " +
            
            "TO_CHAR(ISSUE_DATE,'dd/mm/yyyy') ISSUE_DATE, " +
            "TO_CHAR(DELIVERY_DATE,'dd/mm/yyyy') DELIVERY_DATE, " +
            "TO_CHAR(NVL(PARTICULAR_NAME,'')) PARTICULAR_NAME, " +
            "TO_CHAR(NVL(PART_NO,'')) PART_NO, " +

            //"TO_CHAR (NVL (PO_UNIT_NAME,'')) PO_UNIT_NAME, " +
            "TO_CHAR (NVL (PO_UNIT_NAME,'')) PO_UNIT_NAME, " +
            "TO_CHAR (NVL (currency_id,'')) currency_id, " +
            "TO_CHAR (NVL (CURRENCY_NAME,'')) CURRENCY_NAME, " +
            //"TO_CHAR (NVL (APPROVED_QTY,'0'))APPROVED_QTY, " +
            "TO_CHAR (NVL (APPROVED_QTY,'0')) purchase_quantity, " +


            "TO_CHAR (NVL (RATE,'0')) unit_price , " +
            "TO_CHAR (NVL (PRICE,'0')) total_price, " +
            "TO_CHAR (NVL (TRAN_ID,'')) TRAN_ID " +
            " FROM VEW_PO_ORDER_SUB v WHERE  head_office_id = '" + headOfficeId + "'  AND BRANCH_OFFICE_ID = '" + branchOfficeId + "'  and requisition_no = '" + requisitionNo + "' order by TO_NUMBER(tran_id) ";

            //From Requisition
            //    sql = "SELECT " +
            //      "TO_CHAR (NVL (PARTICULAR_NAME, ''))PARTICULAR_NAME, " +
            //      "TO_CHAR (NVL (PART_NO, ''))PART_NO, " +
            //      "TO_CHAR (NVL (PO_UNIT_NAME,''))PO_UNIT_NAME, " +
            //      "TO_CHAR (NVL (APPROVED_QTY, '0'))APPROVED_QTY, " +
            //      "TO_CHAR (NVL (RATE, '0'))RATE, " +
            //      "TO_CHAR (NVL (PRICE, ''))PRICE, " +
            //      "TO_CHAR (NVL (TRAN_ID, ''))TRAN_ID " +
            //      " FROM VEW_PO_REQUISITION   WHERE REQUISITION_NO='" + requisitionNo + "' AND head_office_id = '" + headOfficeId + "'  AND BRANCH_OFFICE_ID = '" + branchOfficeId + "' and requisition_no = '" + requisitionNo + "'  order by TO_NUMBER(TRAN_ID) ";
            
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

        public DataTable LoadPoNo(PoOrderDTO objPoOrderDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +


                "TO_CHAR(NVL(PO_NUMBER,'0'))PO_NUMBER " +


                "FROM PO_ORDER_MAIN WHERE (lower(PO_NUMBER) like lower( '%" + objPoOrderDTO.PoNumber + "%')  or upper(PO_NUMBER)like upper('%" + objPoOrderDTO.PoNumber + "%')) AND  head_office_id = '" + objPoOrderDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objPoOrderDTO.BranchOfficeId + "' ORDER BY TRAN_ID ";


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
        public DataTable searchPoOrderRecord(string PoRequisitionNo, string strPoNumber, string strIssueDate, string strDeliveryDate, string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
                "TO_CHAR (NVL (PO_NUMBER, ''))PO_NUMBER, " +
                "TO_CHAR(ISSUE_DATE,'dd/mm/yyyy')ISSUE_DATE, " +
                "TO_CHAR(DELIVERY_DATE,'dd/mm/yyyy')DELIVERY_DATE, " +
                "TO_CHAR(NVL(PARTICULAR_NAME,''))PARTICULAR_NAME, " +
                "TO_CHAR(NVL(PART_NO,''))PART_NO, " +
                "TO_CHAR (NVL (APPROVED_QTY,'0'))APPROVED_QTY, " +
                "TO_CHAR (NVL (RATE,'0'))RATE, " +
                "TO_CHAR (NVL (PRICE,'0'))PRICE, " +
                "TO_CHAR (NVL (TRAN_ID,''))TRAN_ID, " +
                "TO_CHAR (NVL (PO_UNIT_NAME,''))PO_UNIT_NAME " +

                " FROM VEW_PO_ORDER_SUB WHERE  head_office_id = '" + strHeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "'  ";

            if (PoRequisitionNo != "")
            {

                sql = sql + "and REQUISITION_NO = '" + PoRequisitionNo + "' ";
            }
            if (strPoNumber != "")
            {

                sql = sql + "and PO_NUMBER = '" + strPoNumber + "' ";
            }

            if (strIssueDate.Length > 6)
            {

                sql = sql + "and ISSUE_DATE = TO_CHAR(TO_DATE('" + strIssueDate + "','dd/mm/yyyy' ))";
            }
            if (strDeliveryDate.Length > 6)
            {

                sql = sql + "and DELIVERY_DATE = TO_CHAR(TO_DATE('" + strDeliveryDate + "','dd/mm/yyyy' ))";
            }

            sql = sql + "order by TO_NUMBER(TRAN_ID) ";

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


        public DataTable GetOrderByOrderId(string poNo, string employeeId, string headOfficeId, string branchOfficeId)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
            "rownum, " +
            "TO_CHAR (NVL (PO_NUMBER, '')) PO_NO, " +
            "TO_CHAR (NVL (REQUISITION_NO, '')) REQUISITION_NO, " +
            "TO_CHAR(ISSUE_DATE,'dd/mm/yyyy') ISSUE_DATE, " +
            "TO_CHAR(DELIVERY_DATE,'dd/mm/yyyy') DELIVERY_DATE, " +
            "TO_CHAR(NVL(PARTICULAR_NAME,'')) PARTICULAR_NAME, " +
            "TO_CHAR(NVL(PART_NO,'')) PART_NO, " +
            "TO_CHAR (NVL (APPROVED_QTY,'0')) purchase_quantity, " +
            "TO_CHAR (NVL (RATE,'0')) unit_price, " +
            "TO_CHAR (NVL (PRICE,'0')) total_price, " +
            "TO_CHAR (NVL (TRAN_ID,'')) TRAN_ID, " +
            "TO_CHAR (NVL (PO_UNIT_NAME,'')) PO_UNIT_NAME, " +
            "TO_CHAR (NVL (currency_id,'')) currency_id, " +
            "TO_CHAR (NVL (CURRENCY_NAME,'')) CURRENCY_NAME " +
            " FROM VEW_PO_ORDER_SUB WHERE  head_office_id = '" + headOfficeId + "'  AND BRANCH_OFFICE_ID = '" + branchOfficeId + "'  ";

            //if (requisitionNo != "")
            //{
            //    sql = sql + "and REQUISITION_NO = '" + requisitionNo + "' ";
            //}
            if (poNo != "")
            {
                sql = sql + "and PO_NUMBER = '" + poNo + "' ";
            }

            sql = sql + "order by TO_NUMBER(TRAN_ID) ";

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
        public DataTable SearchPoRequisitionNo(string strPoRequisitionNo, string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();

            string sql = "";

            sql = "SELECT " +

                  "TO_CHAR(NVL(REQUISITION_NO,''))REQUISITION_NO " +

            "FROM PO_REQUISITION_MAIN WHERE (lower(REQUISITION_NO) like lower( '%" + strPoRequisitionNo + "%')  or upper(REQUISITION_NO)like upper('%" + strPoRequisitionNo + "%')) AND head_office_id = '" + strHeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "' ORDER BY TRAN_ID DESC ";


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
        public DataTable SearchPoNo(string strPoNumber, string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();

            string sql = "";

            sql = "SELECT " +

                  "TO_CHAR(NVL(PO_NUMBER,''))PO_NUMBER " +

            "FROM PO_ORDER_MAIN WHERE (lower(PO_NUMBER) like lower( '%" + strPoNumber + "%')  or upper(PO_NUMBER)like upper('%" + strPoNumber + "%')) AND head_office_id = '" + strHeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "' ORDER BY TRAN_ID DESC";


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
        public PoOrderDTO searchPoOrderRecordMain(string strRequisitionNo, string strPoNumber, string strIssueDate, string strDeliveryDate, string strHeadOfficeId, string strBranchOfficeId)
        {


            PoOrderDTO objPoOrderDTO = new PoOrderDTO();
            PoOrderDAL objPoOrderDAL = new PoOrderDAL();

            string msg="";
            string sql = "";
            //string discount = "";
            //string total_amount = "";

            sql = "SELECT 'Y' " +


                "FROM PO_ORDER_MAIN WHERE head_office_id = '" + strHeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "' and requisition_no = '" + strRequisitionNo + "' and exists(select 1 from po_order_sub where  head_office_id = '" + strHeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "' and requisition_no = '" + strRequisitionNo + "') ";


            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {
                    msg = objDataReader.GetString(0);


                }
                strConn.Close();


            }


            if (msg == "Y")
            {
                sql = "SELECT  " +

                     "TO_CHAR (NVL (REQUISITION_NO, '0'))REQUISITION_NO, " +
                     "TO_CHAR (NVL (PO_NUMBER, '0'))PO_NUMBER, " +
                     "NVL (TO_CHAR (ISSUE_DATE, 'dd/mm/yyyy'), '0')ISSUE_DATE, " +
                     "NVL (TO_CHAR (DELIVERY_DATE, 'dd/mm/yyyy'), '0')DELIVERY_DATE, " +
                     "TO_CHAR (NVL (OFFER_NO, '0'))OFFER_NO, " +
                     "TO_CHAR (NVL (TRADE_TERMS, '0'))TRADE_TERMS, " +
                     "TO_CHAR (NVL (PORT_OF_LOADING, '0'))PORT_OF_LOADING, " +
                     "TO_CHAR (NVL (PORT_OF_DISCHARGE, '0'))PORT_OF_DISCHARGE, " +
                     "TO_CHAR (NVL (CURRENCY_ID, '0'))CURRENCY_ID, " +
                     "TO_CHAR (NVL (SHIPMENT_TYPE_ID, '0'))SHIPMENT_TYPE_ID, " +
                     "TO_CHAR (NVL (PAYMENT_MODOE_ID, '0'))PAYMENT_MODOE_ID, " +
                     "TO_CHAR (NVL (PART_SHIPMENT_ID, '0'))PART_SHIPMENT_ID, " +
                     "TO_CHAR (NVL (TRAN_SHIPMENT_ID, '0'))TRAN_SHIPMENT_ID, " +
                     "TO_CHAR (NVL (SUPPLIER_ID, '0'))SUPPLIER_ID, " +
                     "TO_CHAR (NVL (PURCHASER_ID, '0')) PURCHASER_ID, " +
                     "TO_CHAR (NVL (FREIGHT, '0'))FREIGHT, " +
                     "TO_CHAR (NVL (TRACKING_CHARGE_FEE, '0'))TRACKING_CHARGE_FEE, " +
                     "NVL (TO_CHAR (PURCHASE_DATE, 'dd/mm/yyyy'), '0')PURCHASE_DATE, " +
                     "TO_CHAR (NVL (DISCOUNT, '0'))DISCOUNT, " +
                     "TO_CHAR (NVL (TOTAL_AMOUNT, '0'))TOTAL_AMOUNT, " +
                     "TO_CHAR (NVL (NOTE, '0'))NOTE " +


                        "from VEW_PO_ORDER_MAIN where  head_office_id = '" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "' ";

                if (strRequisitionNo.Length > 0)
                {

                    sql = sql + "and REQUISITION_NO =  '" + strRequisitionNo + "' ";
                }
                if (strPoNumber.Length > 0)
                {

                    sql = sql + "and PO_NUMBER =  '" + strPoNumber + "' ";
                }

                if (strIssueDate.Length > 6)
                {

                    sql = sql + "and ISSUE_DATE = TO_DATE(  '" + strIssueDate + "','dd/mm/yyyy') ";
                }
                if (strDeliveryDate.Length > 6)
                {

                    sql = sql + "and DELIVERY_DATE = TO_DATE(  '" + strDeliveryDate + "','dd/mm/yyyy') ";
                }


                OracleCommand objCommand2 = new OracleCommand(sql);
                OracleDataReader objDataReader2;

                using (OracleConnection strConn = GetConnection())
                {

                    objCommand2.Connection = strConn;
                    strConn.Open();
                    objDataReader2 = objCommand2.ExecuteReader();
                    try
                    {
                        while (objDataReader2.Read())
                        {
                            objPoOrderDTO.PoRequisitionNo = objDataReader2.GetString(0);
                            objPoOrderDTO.PoNumber = objDataReader2.GetString(1);
                            objPoOrderDTO.IssueDate = objDataReader2.GetString(2);
                            objPoOrderDTO.DeliveryDate = objDataReader2.GetString(3);
                            objPoOrderDTO.OfferNo = objDataReader2.GetString(4);
                            objPoOrderDTO.TradeTerms = objDataReader2.GetString(5);
                            objPoOrderDTO.PortOfLoading = objDataReader2.GetString(6);
                            objPoOrderDTO.PortOfDischarges = objDataReader2.GetString(7);
                            objPoOrderDTO.CurrencyId = objDataReader2.GetString(8);
                            objPoOrderDTO.ShipmentModeId = objDataReader2.GetString(9);
                            objPoOrderDTO.PaymentModeId = objDataReader2.GetString(10);
                            objPoOrderDTO.PartshipmentId = objDataReader2.GetString(11);
                            objPoOrderDTO.TranshipmentId = objDataReader2.GetString(12);
                            objPoOrderDTO.SupplierId = objDataReader2.GetString(13);
                            objPoOrderDTO.PurchaserId = objDataReader2.GetString(14); //Added by Asad
                            objPoOrderDTO.Freight = objDataReader2.GetString(15);
                            objPoOrderDTO.TrackingChargeFee = objDataReader2.GetString(16);
                            objPoOrderDTO.PurchaseDate = objDataReader2.GetString(17);
                            objPoOrderDTO.Discount = objDataReader2.GetString(18);
                            objPoOrderDTO.TotalAmount = objDataReader2.GetString(19);
                            objPoOrderDTO.Note = objDataReader2.GetString(20);

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


            }
            else
            {
                sql = "SELECT  " +

                  "TO_CHAR (NVL (FREIGHT, '0'))FREIGHT, " +
                  "TO_CHAR (NVL (TRACKING_CHARGE_FEE, '0'))TRACKING_CHARGE_FEE, " +
                  "TO_CHAR (NVL (DISCOUNT, '0'))DISCOUNT, " +
                  "TO_CHAR (NVL (TOTAL_AMOUNT, '0'))TOTAL_AMOUNT " +

                   "from PO_REQUISITION_MAIN where REQUISITION_NO='" + strRequisitionNo + "' AND head_office_id = '" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "' ";




                OracleCommand objCommand3 = new OracleCommand(sql);
                OracleDataReader objDataReader3;

                using (OracleConnection strConn = GetConnection())
                {

                    objCommand3.Connection = strConn;
                    strConn.Open();
                    objDataReader3 = objCommand3.ExecuteReader();
                    try
                    {
                        while (objDataReader3.Read())
                        {
                            objPoOrderDTO.Freight = objDataReader3.GetString(0);
                            objPoOrderDTO.TrackingChargeFee = objDataReader3.GetString(1);
                            objPoOrderDTO.Discount = objDataReader3.GetString(2);
                            objPoOrderDTO.TotalAmount = objDataReader3.GetString(3);

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
            }



            return objPoOrderDTO;


        }
        public PoOrderDTO searchPoOrderRecordFinalMain(string strPoNumber, string strIssueDate, string strDeliveryDate, string strHeadOfficeId, string strBranchOfficeId)
        {


            PoOrderDTO objPoOrderDTO = new PoOrderDTO();
            PoOrderDAL objPoOrderDAL = new PoOrderDAL();

            string msg = "";
            string sql = "";



            sql = "SELECT  " +

                 "TO_CHAR (NVL (REQUISITION_NO, '0'))REQUISITION_NO, " +
                 "TO_CHAR (NVL (PO_NUMBER, '0'))PO_NUMBER, " +
                 "NVL (TO_CHAR (ISSUE_DATE, 'dd/mm/yyyy'), '0')ISSUE_DATE, " +
                 "NVL (TO_CHAR (DELIVERY_DATE, 'dd/mm/yyyy'), '0')DELIVERY_DATE, " +
                 "TO_CHAR (NVL (OFFER_NO, '0'))OFFER_NO, " +
                 "TO_CHAR (NVL (TRADE_TERMS, '0'))TRADE_TERMS, " +
                 "TO_CHAR (NVL (PORT_OF_LOADING, '0'))PORT_OF_LOADING, " +
                 "TO_CHAR (NVL (PORT_OF_DISCHARGE, '0'))PORT_OF_DISCHARGE, " +
                 "TO_CHAR (NVL (CURRENCY_ID, '0'))CURRENCY_ID, " +
                 "TO_CHAR (NVL (SHIPMENT_TYPE_ID, '0'))SHIPMENT_TYPE_ID, " +
                 "TO_CHAR (NVL (PAYMENT_MODOE_ID, '0'))PAYMENT_MODOE_ID, " +
                 "TO_CHAR (NVL (PART_SHIPMENT_ID, '0'))PART_SHIPMENT_ID, " +
                 "TO_CHAR (NVL (TRAN_SHIPMENT_ID, '0'))TRAN_SHIPMENT_ID, " +
                 "TO_CHAR (NVL (SUPPLIER_ID, '0'))SUPPLIER_ID, " +
                 "TO_CHAR (NVL (FREIGHT, '0'))FREIGHT, " +
                 "NVL (TO_CHAR (PURCHASE_DATE, 'dd/mm/yyyy'), '0')PURCHASE_DATE, " +
                 "TO_CHAR (NVL (DISCOUNT, '0'))DISCOUNT, " +
                 "TO_CHAR (NVL (TOTAL_AMOUNT, '0'))TOTAL_AMOUNT " +

                 "from VEW_PO_ORDER_MAIN where PO_NUMBER='" + strPoNumber + "' AND  head_office_id = '" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "' ";


            if (strIssueDate.Length > 6)
            {

                sql = sql + "and ISSUE_DATE = TO_DATE(  '" + strIssueDate + "','dd/mm/yyyy') ";
            }
            if (strDeliveryDate.Length > 6)
            {

                sql = sql + "and DELIVERY_DATE = TO_DATE(  '" + strDeliveryDate + "','dd/mm/yyyy') ";
            }


            OracleCommand objCommand2 = new OracleCommand(sql);
            OracleDataReader objDataReader2;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand2.Connection = strConn;
                strConn.Open();
                objDataReader2 = objCommand2.ExecuteReader();
                try
                {
                    while (objDataReader2.Read())
                    {
                        objPoOrderDTO.PoRequisitionNo = objDataReader2.GetString(0);
                        objPoOrderDTO.PoNumber = objDataReader2.GetString(1);
                        objPoOrderDTO.IssueDate = objDataReader2.GetString(2);
                        objPoOrderDTO.DeliveryDate = objDataReader2.GetString(3);
                        objPoOrderDTO.OfferNo = objDataReader2.GetString(4);
                        objPoOrderDTO.TradeTerms = objDataReader2.GetString(5);
                        objPoOrderDTO.PortOfLoading = objDataReader2.GetString(6);
                        objPoOrderDTO.PortOfDischarges = objDataReader2.GetString(7);
                        objPoOrderDTO.CurrencyId = objDataReader2.GetString(8);
                        objPoOrderDTO.ShipmentModeId = objDataReader2.GetString(9);
                        objPoOrderDTO.PaymentModeId = objDataReader2.GetString(10);
                        objPoOrderDTO.PartshipmentId = objDataReader2.GetString(11);
                        objPoOrderDTO.TranshipmentId = objDataReader2.GetString(12);
                        objPoOrderDTO.SupplierId = objDataReader2.GetString(13);
                        objPoOrderDTO.Freight = objDataReader2.GetString(14);
                        objPoOrderDTO.PurchaseDate = objDataReader2.GetString(15);
                        objPoOrderDTO.Discount = objDataReader2.GetString(16);
                        objPoOrderDTO.TotalAmount = objDataReader2.GetString(17);

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







            return objPoOrderDTO;


        }
    }
}
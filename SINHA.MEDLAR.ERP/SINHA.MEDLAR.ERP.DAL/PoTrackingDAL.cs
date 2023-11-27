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
    public class PoTrackingDAL
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

        public string savePoTrackingInfo(PoTrackingDTO objPoTrackingDTO)
        {

            ContractDAL objContractDAL = new ContractDAL();

            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("PRO_PO_TRACKING_SAVE");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objPoTrackingDTO.PoNumber != "")
            {

                objOracleCommand.Parameters.Add("P_PO_NUMBER", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoTrackingDTO.PoNumber;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PO_NUMBER", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            
            if (objPoTrackingDTO.ProductDescription != "")
            {

                objOracleCommand.Parameters.Add("P_PARTICULAR_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoTrackingDTO.ProductDescription;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PARTICULAR_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objPoTrackingDTO.PartNo != "")
            {

                objOracleCommand.Parameters.Add("P_PART_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoTrackingDTO.PartNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PART_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objPoTrackingDTO.PoUnitName != "")
            {

                objOracleCommand.Parameters.Add("P_PART_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoTrackingDTO.PoUnitName;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PART_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
           
            if (objPoTrackingDTO.ApprovedQty != "")
            {

                objOracleCommand.Parameters.Add("P_APPROVED_QTY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoTrackingDTO.ApprovedQty;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_APPROVED_QTY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
 
           
            if (objPoTrackingDTO.Price != "")
            {

                objOracleCommand.Parameters.Add("P_PRICE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoTrackingDTO.Price;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PRICE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objPoTrackingDTO.ReminingQuantity != "")
            {

                objOracleCommand.Parameters.Add("P_REMAINING_QTY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoTrackingDTO.ReminingQuantity;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_REMAINING_QTY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objPoTrackingDTO.ShipQuantity != "")
            {

                objOracleCommand.Parameters.Add("P_SHIP_QTY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoTrackingDTO.ShipQuantity;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SHIP_QTY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objPoTrackingDTO.ShipmentDate.Length > 6)
            {

                objOracleCommand.Parameters.Add("P_SHIPMENT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoTrackingDTO.ShipmentDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SHIPMENT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objPoTrackingDTO.TranId != "")
            {

                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoTrackingDTO.TranId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objPoTrackingDTO.Discount != "")
            {

                objOracleCommand.Parameters.Add("P_DISCOUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoTrackingDTO.Discount;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_DISCOUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objPoTrackingDTO.TotalAmount != "")
            {

                objOracleCommand.Parameters.Add("P_TOTAL_AMOUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoTrackingDTO.TotalAmount;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_TOTAL_AMOUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objPoTrackingDTO.Balance != "")
            {

                objOracleCommand.Parameters.Add("P_BALANCE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoTrackingDTO.Balance;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_BALANCE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }





            if (objPoTrackingDTO.BlNo != "")
            {

                objOracleCommand.Parameters.Add("P_BL_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoTrackingDTO.BlNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_BL_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objPoTrackingDTO.EtaDate.Length > 6)
            {

                objOracleCommand.Parameters.Add("P_ETA_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoTrackingDTO.EtaDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_ETA_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objPoTrackingDTO.DocRecevingDate.Length > 6)
            {

                objOracleCommand.Parameters.Add("P_DOC_RECEVING_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoTrackingDTO.DocRecevingDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_DOC_RECEVING_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objPoTrackingDTO.DocHandoverDate.Length > 6)
            {

                objOracleCommand.Parameters.Add("P_DOC_HANDOVER_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoTrackingDTO.DocHandoverDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_DOC_HANDOVER_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objPoTrackingDTO.ShipDeliveryDate.Length > 6)
            {

                objOracleCommand.Parameters.Add("P_SHIP_DELIVERY_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoTrackingDTO.ShipDeliveryDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SHIP_DELIVERY_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoTrackingDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoTrackingDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoTrackingDTO.BranchOfficeId;


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
        public string savePoTrackingAdvanceInfo(PoTrackingDTO objPoTrackingDTO)
        {

            ContractDAL objContractDAL = new ContractDAL();

            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("PRO_PO_TRACKING_ADVANCE_SAVE");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objPoTrackingDTO.TranId != "")
            {

                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoTrackingDTO.TranId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objPoTrackingDTO.PoNumber != "")
            {

                objOracleCommand.Parameters.Add("P_PO_NUMBER", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoTrackingDTO.PoNumber;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PO_NUMBER", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objPoTrackingDTO.AdvanceAmount != "")
            {

                objOracleCommand.Parameters.Add("P_BALANCE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoTrackingDTO.AdvanceAmount;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_BALANCE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objPoTrackingDTO.PaymentDate.Length > 6)
            {

                objOracleCommand.Parameters.Add("P_PAYMENT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoTrackingDTO.PaymentDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PAYMENT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            



            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoTrackingDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoTrackingDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoTrackingDTO.BranchOfficeId;


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
        public PoTrackingDTO searchPoTotalAmount(string strPoNumber, string strHeadOfficeId, string strBranchOfficeId)
        {

            PoTrackingDTO objPoTrackingDTO = new PoTrackingDTO();
            PoTrackingDAL objPoTrackingDAL = new PoTrackingDAL();

            string sql = "";
             string msg = "";

            sql = "SELECT 'Y' " +

            "FROM PO_TRACKING_MAIN WHERE PO_NUMBER='" + strPoNumber + "' AND head_office_id = '" + strHeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "' ";


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
                sql = "SELECT " +

                      "TO_CHAR (NVL (FREIGHT, '0'))FREIGHT, " +
                      "TO_CHAR (NVL (TRACKING_CHARGE_FEE, '0'))TRACKING_CHARGE_FEE, " +
                      "TO_CHAR (NVL (DISCOUNT, '0'))DISCOUNT, " +
                      "TO_CHAR (NVL (TOTAL_AMOUNT, '0'))TOTAL_AMOUNT, " +
                      "TO_CHAR (NVL (BALANCE, '0'))BALANCE " +
                      


                      " FROM VEW_PO_TRACKING_MAIN WHERE   head_office_id = '" + strHeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "' and PO_NUMBER = '" + strPoNumber + "'  ";

            }
            else 
            {
                sql = "SELECT " +

                      "TO_CHAR (NVL (FREIGHT, '0'))FREIGHT, " +
                      "TO_CHAR (NVL (TRACKING_CHARGE_FEE, '0'))TRACKING_CHARGE_FEE, " +
                      "TO_CHAR (NVL (DISCOUNT, '0'))DISCOUNT, " +
                      "TO_CHAR (NVL (TOTAL_AMOUNT, '0'))TOTAL_AMOUNT, " +
                      "TO_CHAR (NVL ('', ''))BALANCE" +


                      " FROM PO_ORDER_MAIN WHERE   head_office_id = '" + strHeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "' and PO_NUMBER = '" + strPoNumber + "'  ";
            }
            OracleCommand objCommand1 = new OracleCommand(sql);
            OracleDataReader objDataReader1;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand1.Connection = strConn;
                strConn.Open();
                objDataReader1 = objCommand1.ExecuteReader();
                try
                {
                    while (objDataReader1.Read())
                    {

                        objPoTrackingDTO.Freight = objDataReader1["FREIGHT"].ToString();
                        objPoTrackingDTO.TrackingChargeFee = objDataReader1["TRACKING_CHARGE_FEE"].ToString();
                        objPoTrackingDTO.Discount = objDataReader1["DISCOUNT"].ToString();
                        objPoTrackingDTO.TotalAmount = objDataReader1["TOTAL_AMOUNT"].ToString();
                        objPoTrackingDTO.Balance = objDataReader1["BALANCE"].ToString();

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
            return objPoTrackingDTO;
        }
        public DataTable LoadPoTrackingAdvanceInfo(string strPoNumber, string strHeadOfficeId, string strBranchOfficeId)
        {
            DataTable dt = new DataTable();
            PoTrackingDAL objPoTrackingDAL = new PoTrackingDAL();

            string sql = "";
            string msg = "";

            sql = "SELECT " +

                "TO_CHAR(NVL(TRAN_ID,'0'))TRAN_ID, " +
                "TO_CHAR(NVL(ADVANCE_AMOUNT,'0'))ADVANCE_AMOUNT, " +
                "TO_CHAR(PAYMENT_DATE,'dd/mm/yyyy')PAYMENT_DATE " +


                    " FROM PO_TRACKING_SUB_ADVANCE WHERE PO_NUMBER='" + strPoNumber + "' AND head_office_id = '" + strHeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "' ORDER BY TRAN_ID ";

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

            "FROM PO_ORDER_MAIN WHERE (lower(PO_NUMBER) like lower( '%" + strPoNumber + "%')  or upper(PO_NUMBER)like upper('%" + strPoNumber + "%')) AND head_office_id = '" + strHeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "' ORDER BY TO_NUMBER(TRAN_ID) DESC ";


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
        public DataTable LoadPoTrackingRecord(string strPoNumber, string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();

            string sql = "";
            string msg = "";

            sql = "SELECT 'Y' " +

            "FROM PO_TRACKING_MAIN WHERE PO_NUMBER='" + strPoNumber + "' AND head_office_id = '" + strHeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "' ";


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
                sql = "SELECT " +

                    "TO_CHAR(NVL(PARTICULAR_NAME,''))PARTICULAR_NAME, " +
                    "TO_CHAR(NVL(PART_NO,''))PART_NO, " +
                    "TO_CHAR(NVL(PO_UNIT_NAME,''))PO_UNIT_NAME, " +
                    "TO_CHAR (NVL (APPROVED_QTY,''))APPROVED_QTY, " +
                    "TO_CHAR (NVL (PRICE,''))PRICE, " +
                    "TO_CHAR (NVL (REMAINING_QTY,''))REMAINING_QTY, " +
                    "TO_CHAR(NVL(SHIP_QTY,''))SHIP_QTY, " +
                    "TO_CHAR(SHIPMENT_DATE,'dd/mm/yyyy')SHIPMENT_DATE, " +
                    "TO_CHAR (NVL(BL_NO,'')) BL_NO, " +
                    "TO_CHAR(ETA_DATE,'dd/mm/yyyy')ETA_DATE, " +
                    "TO_CHAR(DOC_RECEVING_DATE,'dd/mm/yyyy')DOC_RECEVING_DATE, " +
                    "TO_CHAR(DOC_HANDOVER_DATE,'dd/mm/yyyy')DOC_HANDOVER_DATE, " +
                    "TO_CHAR(SHIP_DELIVERY_DATE,'dd/mm/yyyy')SHIP_DELIVERY_DATE, " +
                    "TO_NUMBER(NVL(TRAN_ID,''))TRAN_ID " +


                    " FROM VEW_PO_TRACKING_SUB WHERE PO_NUMBER='" + strPoNumber + "' AND head_office_id = '" + strHeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "' ORDER BY PART_NO ";
            }
            else
            {
                sql = "SELECT " +

                   "TO_CHAR(NVL(PARTICULAR_NAME,''))PARTICULAR_NAME, " +
                   "TO_CHAR(NVL(PART_NO,''))PART_NO, " +
                   "TO_CHAR(NVL(PO_UNIT_NAME,''))PO_UNIT_NAME, " +
                   "TO_CHAR (NVL (APPROVED_QTY,''))APPROVED_QTY, " +
                   "TO_CHAR (NVL (PRICE,''))PRICE, " +
                   "TO_CHAR (NVL ('', ''))REMAINING_QTY, " +
                   "TO_CHAR(NVL('',''))SHIP_QTY, " +
                   "TO_CHAR('','')SHIPMENT_DATE, " +
                   "TO_CHAR (NVL('','')) BL_NO, " +
                   "TO_CHAR('','')ETA_DATE, " +
                   "TO_CHAR('','')DOC_RECEVING_DATE, " +
                   "TO_CHAR('','')DOC_HANDOVER_DATE, " +
                   "TO_CHAR('','')SHIP_DELIVERY_DATE, " +
                   "TO_NUMBER(NVL('',''))TRAN_ID " +


                   " FROM VEW_PO_ORDER_SUB WHERE PO_NUMBER='" + strPoNumber + "' AND head_office_id = '" + strHeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "' ORDER BY PO_NUMBER ";
            }
            OracleCommand objCommand2 = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter2 = new OracleDataAdapter(objCommand2);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand2.Connection = strConn;
                    strConn.Open();
                    objDataAdapter2.Fill(dt);

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
        public DataTable searchPoTrackingMainOne(string strPoNo, string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            string sql = "";

            string msg = "";

            sql = "SELECT 'Y' " +

            "FROM PO_TRACKING_MAIN WHERE PO_NUMBER='" + strPoNo + "' AND head_office_id = '" + strHeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "' ";


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

                      "NVL (TO_CHAR (ISSUE_DATE, 'dd/mm/yyyy'), '')ISSUE_DATE, " +
                      "NVL (TO_CHAR (DELIVERY_DATE, 'dd/mm/yyyy'), '')DELIVERY_DATE, " +
                      "TO_CHAR (NVL (OFFER_NO, ''))OFFER_NO, " +
                      "TO_CHAR (NVL (TRADE_TERMS, ''))TRADE_TERMS, " +
                      "TO_CHAR (NVL (PORT_OF_LOADING, ''))PORT_OF_LOADING, " +
                      "TO_CHAR (NVL (PORT_OF_DISCHARGE, ''))PORT_OF_DISCHARGE " +
                     


                    " FROM PO_TRACKING_MAIN WHERE   head_office_id = '" + strHeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "' and  PO_NUMBER = '" + strPoNo + "' order by PO_NUMBER ";


            }
            else
            {
                sql = "SELECT  " +

                      "NVL (TO_CHAR (ISSUE_DATE, 'dd/mm/yyyy'), '')ISSUE_DATE, " +
                      "NVL (TO_CHAR (DELIVERY_DATE, 'dd/mm/yyyy'), '')DELIVERY_DATE, " +
                      "TO_CHAR (NVL (OFFER_NO, ''))OFFER_NO, " +
                      "TO_CHAR (NVL (TRADE_TERMS, ''))TRADE_TERMS, " +
                      "TO_CHAR (NVL (PORT_OF_LOADING, ''))PORT_OF_LOADING, " +
                      "TO_CHAR (NVL (PORT_OF_DISCHARGE, ''))PORT_OF_DISCHARGE " +
                     


                    " FROM VEW_PO_ORDER_MAIN WHERE   head_office_id = '" + strHeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "' and  PO_NUMBER = '" + strPoNo + "' order by PO_NUMBER ";

            
            }

                OracleCommand objCommand1 = new OracleCommand(sql);
                OracleDataAdapter objDataAdapter1 = new OracleDataAdapter(objCommand1);
                using (OracleConnection strConn = GetConnection())
                {
                    try
                    {
                        objCommand1.Connection = strConn;
                        strConn.Open();
                        objDataAdapter1.Fill(dt);

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
        public DataTable searchPoTrackingMainTwo(string strPoNo, string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            string sql = "";
             string msg = "";

            sql = "SELECT 'Y' " +

            "FROM PO_TRACKING_MAIN WHERE PO_NUMBER='" + strPoNo + "' AND head_office_id = '" + strHeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "' ";


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

                     "TO_CHAR (NVL (CURRENCY_NAME, ''))CURRENCY_NAME, " +
                     "TO_CHAR (NVL (SHIPMENT_TYPE_NAME, ''))SHIPMENT_TYPE_NAME, " +
                     "TO_CHAR (NVL (PAYMENT_MODE_NAME, ''))PAYMENT_MODE_NAME, " +
                     "TO_CHAR (NVL (PART_SHIPMENT_NAME, ''))PART_SHIPMENT_NAME, " +
                     "TO_CHAR (NVL (TRAN_SHIPMENT_NAME, ''))TRAN_SHIPMENT_NAME, " +
                     "TO_CHAR (NVL (PURCHASE_NAME, ''))PURCHASE_NAME, " +
                     "TO_CHAR (NVL (SUPPLIER_NAME, ''))SUPPLIER_NAME " +



                    " FROM VEW_PO_TRACKING_MAIN WHERE   head_office_id = '" + strHeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "' and  PO_NUMBER = '" + strPoNo + "' order by PO_NUMBER  ";

            }
            else
            {
                sql = "SELECT  " +

                     "TO_CHAR (NVL (CURRENCY_NAME, ''))CURRENCY_NAME, " +
                     "TO_CHAR (NVL (SHIPMENT_TYPE_NAME, ''))SHIPMENT_TYPE_NAME, " +
                     "TO_CHAR (NVL (PAYMENT_MODE_NAME, ''))PAYMENT_MODE_NAME, " +
                     "TO_CHAR (NVL (PART_SHIPMENT_NAME, ''))PART_SHIPMENT_NAME, " +
                     "TO_CHAR (NVL (TRAN_SHIPMENT_NAME, ''))TRAN_SHIPMENT_NAME, " +
                     "TO_CHAR (NVL (PURCHASE_NAME, ''))PURCHASE_NAME, " +
                     "TO_CHAR (NVL (SUPPLIER_NAME, ''))SUPPLIER_NAME " +



                    " FROM  VEW_PO_ORDER_MAIN WHERE   head_office_id = '" + strHeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "' and  PO_NUMBER = '" + strPoNo + "' order by PO_NUMBER  ";

            }


            OracleCommand objCommand1 = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter1 = new OracleDataAdapter(objCommand1);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand1.Connection = strConn;
                    strConn.Open();
                    objDataAdapter1.Fill(dt);

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


        public string deletePoTrackingSubAdvancedRecord(PoTrackingDTO objPoTrackingDTO)
        {

            PoTrackingDAL objPoTrackingDAL = new PoTrackingDAL();

            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("PRO_DEL_PO_TRACKING_SUB_AD");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objPoTrackingDTO.TranId != "")
            {

                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoTrackingDTO.TranId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }



            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoTrackingDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoTrackingDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoTrackingDTO.BranchOfficeId;


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
    }
}
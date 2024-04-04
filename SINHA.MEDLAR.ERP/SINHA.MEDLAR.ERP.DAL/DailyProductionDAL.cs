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
    public class DailyProductionDAL
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
        public string saveDailyProductionInfo(DailyProductionDTO objDailyProductionDTO)
        {

            DailyProductionDAL objDailyProductionDAL = new DailyProductionDAL();

            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("pro_daily_production_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objDailyProductionDTO.TranId != "")
            {

                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objDailyProductionDTO.TranId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
           

            if (objDailyProductionDTO.LineId != "")
            {

                objOracleCommand.Parameters.Add("P_LINE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objDailyProductionDTO.LineId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_LINE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objDailyProductionDTO.ProductionDate.Length > 6)
            {

                objOracleCommand.Parameters.Add("P_PRODUCTION_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objDailyProductionDTO.ProductionDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PRODUCTION_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objDailyProductionDTO.PONo != "")
            {

                objOracleCommand.Parameters.Add("P_PO_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objDailyProductionDTO.PONo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PO_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objDailyProductionDTO.StyleNo != "")
            {

                objOracleCommand.Parameters.Add("P_STYLE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objDailyProductionDTO.StyleNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_STYLE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objDailyProductionDTO.OrderQty != "")
            {

                objOracleCommand.Parameters.Add("P_ORDER_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objDailyProductionDTO.OrderQty;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_ORDER_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objDailyProductionDTO.CuttingIssuedQty != "")
            {

                objOracleCommand.Parameters.Add("P_CUTTING_ISSUED_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objDailyProductionDTO.CuttingIssuedQty;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_CUTTING_ISSUED_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objDailyProductionDTO.CuttingDeliveyQty != "")
            {

                objOracleCommand.Parameters.Add("P_CUTTING_DELIVERY_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objDailyProductionDTO.CuttingDeliveyQty;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_CUTTING_DELIVERY_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objDailyProductionDTO.SewingInputQty != "")
            {

                objOracleCommand.Parameters.Add("P_SEWING_INPUT_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objDailyProductionDTO.SewingInputQty;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SEWING_INPUT_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objDailyProductionDTO.SewingOutputQty != "")
            {

                objOracleCommand.Parameters.Add("P_SEWING_OUTPUT_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objDailyProductionDTO.SewingOutputQty;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SEWING_OUTPUT_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            
            if (objDailyProductionDTO.WashSentQty != "")
            {

                objOracleCommand.Parameters.Add("P_WASH_SEND_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objDailyProductionDTO.WashSentQty;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_WASH_SEND_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objDailyProductionDTO.WashReceivedQty != "")
            {

                objOracleCommand.Parameters.Add("P_WASH_RECEIVED_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objDailyProductionDTO.WashReceivedQty;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_WASH_RECEIVED_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objDailyProductionDTO.FinishingPolyQty != "")
            {

                objOracleCommand.Parameters.Add("P_FINISHING_POLY_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objDailyProductionDTO.FinishingPolyQty;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_FINISHING_POLY_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objDailyProductionDTO.FinishingCartonQty != "")
            {

                objOracleCommand.Parameters.Add("P_FINISHING_CARTON_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objDailyProductionDTO.FinishingCartonQty;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_FINISHING_CARTON_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objDailyProductionDTO.BuyerName != "")
            {

                objOracleCommand.Parameters.Add("P_BUYER_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objDailyProductionDTO.BuyerName;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_BUYER_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objDailyProductionDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objDailyProductionDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objDailyProductionDTO.BranchOfficeId;


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

        public string addPORecord(DailyProductionDTO objDailyProductionDTO)
        {

            DailyProductionDAL objDailyProductionDAL = new DailyProductionDAL();

            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("pro_po_add");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

           

            if (objDailyProductionDTO.LineId != "")
            {

                objOracleCommand.Parameters.Add("P_LINE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objDailyProductionDTO.LineId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_LINE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objDailyProductionDTO.ProductionDate.Length > 6)
            {

                objOracleCommand.Parameters.Add("P_PRODUCTION_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objDailyProductionDTO.ProductionDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PRODUCTION_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

    

            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objDailyProductionDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objDailyProductionDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objDailyProductionDTO.BranchOfficeId;


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
        public DataTable LoadDailyProductionInfoSub(DailyProductionDTO objDailyProductionDTO)
        {
            DataTable dt = new DataTable();
            string msg = "";

            string sql = "";   
              
            sql = "SELECT " +
            "TO_CHAR (NVL (TRAN_ID, ''))TRAN_ID, " +
            "TO_CHAR (NVL (PO_NO, ''))PO_NO, " +
            "TO_CHAR (NVL (STYLE_NO, ''))STYLE_NO, " +
            "TO_CHAR (NVL (ORDER_QUANTITY, ''))ORDER_QUANTITY, " +
            "TO_CHAR (NVL (CUTTING_ISSUED_QUANTITY, ''))CUTTING_ISSUED_QUANTITY, " +
            "TO_CHAR (NVL (CUTTING_DELIVERY_QUANTITY, ''))CUTTING_DELIVERY_QUANTITY, " +
            "TO_CHAR (NVL (SEWING_INPUT_QUANTITY, ''))SEWING_INPUT_QUANTITY, " +
            "TO_CHAR (NVL (SEWING_OUTPUT_QUANTITY, ''))SEWING_OUTPUT_QUANTITY, " +
            "TO_CHAR (NVL (WASH_SEND_QUANTITY, ''))WASH_SEND_QUANTITY, " +
            "TO_CHAR (NVL (WASH_RECEIVED_QUANTITY, ''))WASH_RECEIVED_QUANTITY, " +
            "TO_CHAR (NVL (FINISHING_POLY_QUANTITY, ''))FINISHING_POLY_QUANTITY, " +
            "TO_CHAR (NVL (FINISHING_CARTON_QUANTITY, ''))FINISHING_CARTON_QUANTITY, " +
            "TO_CHAR (NVL (BUYER_NAME, ''))BUYER_NAME " +         
            "FROM vew_daily_production_temp WHERE head_office_id = '" + objDailyProductionDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objDailyProductionDTO.BranchOfficeId + "'  and LINE_ID ='" + objDailyProductionDTO.LineId + "' and   PRODUCTION_DATE =TO_DATE('" + objDailyProductionDTO.ProductionDate + "','dd/mm/yyyy') ";
                    
            OracleCommand objCommand2 = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter2 = new OracleDataAdapter(objCommand2);
            using (OracleConnection strConn2 = GetConnection())
            {
                try
                {
                    objCommand2.Connection = strConn2;
                    strConn2.Open();
                    objDataAdapter2.Fill(dt);

                }
                catch (Exception ex)
                {

                    throw new Exception("Error : " + ex.Message);
                }

                finally
                {

                    strConn2.Close();
                }

            }


            return dt;

        }
        public DataTable LoadDailyProductionFinalizedRecord(DailyProductionDTO objDailyProductionDTO)
        {
            DataTable dt = new DataTable();
            string msg = "";

              string   sql = "";
                sql = "SELECT   " +

                    "TO_CHAR (NVL (TRAN_ID, ''))TRAN_ID, " +
                    "TO_CHAR (NVL (PO_NO, ''))PO_NO, " +
                    "TO_CHAR (NVL (STYLE_NO, ''))STYLE_NO, " +
                    "TO_CHAR (NVL (ORDER_QUANTITY, ''))ORDER_QUANTITY, " +
                    "TO_CHAR (NVL (CUTTING_ISSUED_QUANTITY, ''))CUTTING_ISSUED_QUANTITY, " +
                    "TO_CHAR (NVL (CUTTING_DELIVERY_QUANTITY, ''))CUTTING_DELIVERY_QUANTITY, " +
                    "TO_CHAR (NVL (SEWING_INPUT_QUANTITY, ''))SEWING_INPUT_QUANTITY, " +
                    "TO_CHAR (NVL (SEWING_OUTPUT_QUANTITY, ''))SEWING_OUTPUT_QUANTITY, " +
                    "TO_CHAR (NVL (WASH_SEND_QUANTITY, ''))WASH_SEND_QUANTITY, " +
                    "TO_CHAR (NVL (WASH_RECEIVED_QUANTITY, ''))WASH_RECEIVED_QUANTITY, " +
                    "TO_CHAR (NVL (FINISHING_POLY_QUANTITY, ''))FINISHING_POLY_QUANTITY, " +
                    "TO_CHAR (NVL (FINISHING_CARTON_QUANTITY, ''))FINISHING_CARTON_QUANTITY, " +
                    "TO_CHAR (NVL (BUYER_NAME, ''))BUYER_NAME " +

                "FROM VEW_DAILY_PRODUCTION WHERE head_office_id = '" + objDailyProductionDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objDailyProductionDTO.BranchOfficeId + "'  and  LINE_ID ='" + objDailyProductionDTO.LineId + "' ";

                if (objDailyProductionDTO.ProductionDate.Length > 0)
                {
                    sql = sql + " and PRODUCTION_DATE =TO_DATE('" + objDailyProductionDTO.ProductionDate + "','dd/mm/yyyy') ";

                }
                sql = sql + " ORDER BY PO_NO,STYLE_NO ";
          
            

            OracleCommand objCommand2 = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter2 = new OracleDataAdapter(objCommand2);
            using (OracleConnection strConn2 = GetConnection())
            {
                try
                {
                    objCommand2.Connection = strConn2;
                    strConn2.Open();
                    objDataAdapter2.Fill(dt);

                }
                catch (Exception ex)
                {

                    throw new Exception("Error : " + ex.Message);
                }

                finally
                {

                    strConn2.Close();
                }

            }


            return dt;

        }

        public DailyProductionDTO searcDailyProductionInfoMain(string strLineId, string strProductionDate, string strHeadOfficeId, string strBranchOfficeId)
        {


            DailyProductionDTO objDailyProductionDTO = new DailyProductionDTO();
            DailyProductionDAL objDailyProductionDAL = new DailyProductionDAL();

            string sql = "";

            sql = "SELECT  " +

                      "TO_CHAR (PRODUCTION_DATE, 'dd/mm/yyyy') " +


                 "FROM DAILY_PRODUCTION WHERE head_office_id = '" + strHeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "'  ";

            if (objDailyProductionDTO.LineId != "")
            {
                sql = sql + " and LINE_ID ='" + objDailyProductionDTO.LineId + "' ";

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
                        objDailyProductionDTO.ProductionDate = objDataReader.GetString(0);
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

            return objDailyProductionDTO;


        }



    }
}

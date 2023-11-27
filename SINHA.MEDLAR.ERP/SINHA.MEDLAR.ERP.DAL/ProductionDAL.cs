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
    public class ProductionDAL
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


        public string saveDailyProduction(ProductionDTO objProductionDTO)
        {
            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("pro_daily_production_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            if (objProductionDTO.ProductionDate.Length > 6)
            {

                objOracleCommand.Parameters.Add("P_PRODUCTION_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProductionDTO.ProductionDate;


            }
            else
            {

                objOracleCommand.Parameters.Add("P_PRODUCTION_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objProductionDTO.OrderQuantity != "")
            {

                objOracleCommand.Parameters.Add("P_ORDER_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProductionDTO.OrderQuantity;


            }
            else
            {

                objOracleCommand.Parameters.Add("P_ORDER_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objProductionDTO.PONo != "")
            {

                objOracleCommand.Parameters.Add("P_PO_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProductionDTO.PONo;


            }
            else
            {

                objOracleCommand.Parameters.Add("P_PO_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objProductionDTO.StyleId != "")
            {

                objOracleCommand.Parameters.Add("P_STYLE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProductionDTO.StyleId;


            }
            else
            {

                objOracleCommand.Parameters.Add("P_STYLE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objProductionDTO.LineId != "")
            {

                objOracleCommand.Parameters.Add("P_LINE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProductionDTO.LineId;


            }
            else
            {

                objOracleCommand.Parameters.Add("P_LINE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objProductionDTO.BuyerId != "")
            {

                objOracleCommand.Parameters.Add("P_BUYER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProductionDTO.BuyerId;


            }
            else
            {

                objOracleCommand.Parameters.Add("P_BUYER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objProductionDTO.ColorId != "")
            {

                objOracleCommand.Parameters.Add("P_COLOR_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProductionDTO.ColorId;


            }
            else
            {

                objOracleCommand.Parameters.Add("P_COLOR_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objProductionDTO.CuttingQuantity != "")
            {

                objOracleCommand.Parameters.Add("P_CUTTING_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProductionDTO.CuttingQuantity;


            }
            else
            {

                objOracleCommand.Parameters.Add("P_CUTTING_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objProductionDTO.CuttingDelivery != "")
            {

                objOracleCommand.Parameters.Add("P_CUTTING_DELIVERY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProductionDTO.CuttingDelivery;


            }
            else
            {

                objOracleCommand.Parameters.Add("P_CUTTING_DELIVERY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objProductionDTO.SewingInput != "")
            {

                objOracleCommand.Parameters.Add("P_SEWING_INPUT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProductionDTO.SewingInput;


            }
            else
            {

                objOracleCommand.Parameters.Add("P_SEWING_INPUT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objProductionDTO.SewingOutput != "")
            {

                objOracleCommand.Parameters.Add("P_SEWING_OUTPUT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProductionDTO.SewingOutput;


            }
            else
            {

                objOracleCommand.Parameters.Add("P_SEWING_OUTPUT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objProductionDTO.WashingSent != "")
            {

                objOracleCommand.Parameters.Add("P_WASHING_SENT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProductionDTO.WashingSent;


            }
            else
            {

                objOracleCommand.Parameters.Add("P_WASHING_SENT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objProductionDTO.WashingReceived != "")
            {

                objOracleCommand.Parameters.Add("P_WASHING_RECEIVED", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProductionDTO.WashingReceived;


            }
            else
            {

                objOracleCommand.Parameters.Add("P_WASHING_RECEIVED", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objProductionDTO.PolyQuantity != "")
            {

                objOracleCommand.Parameters.Add("P_POLY_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProductionDTO.PolyQuantity;


            }
            else
            {

                objOracleCommand.Parameters.Add("P_POLY_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objProductionDTO.CartonQuantity != "")
            {

                objOracleCommand.Parameters.Add("P_CARTON_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProductionDTO.CartonQuantity;


            }
            else
            {

                objOracleCommand.Parameters.Add("P_CARTON_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }



            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProductionDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProductionDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProductionDTO.BranchOfficeId;


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



        public DataTable searchDailyProductionEntry(ProductionDTO objProductionDTO)
        {


            DataTable dt = new DataTable();

            string sql = "";
            sql = "SELECT " +
                   "rownum sl, " +
                   "TO_DATE(PRODUCTION_DATE,'dd/mm/yyyy')PRODUCTION_DATE,  " +
                   "ORDER_QUANTITY, " +
                   "PO_NO, " +
                   "STYLE_NO, " +
                   "LINE_NO, " +
                   "BUYER_NAME, "+
                   "COLOR_NAME "+

                  " FROM VEW_SEARCH_DAILY_PRODUCT_ENTRY where head_office_id = '" + objProductionDTO.HeadOfficeId + "' and branch_office_id = '" + objProductionDTO.BranchOfficeId + "' ";




            //if (objProductionDTO.ProductionDate.Length > 0)
            //{

            //    sql = sql + " and PRODUCTION_DATE = TO_DATE('" + objProductionDTO.ProductionDate + "', 'dd/mm/yyyy')  ";
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
        public DataTable searchDailyProduction(ProductionDTO objProductionDTO)
        {


            DataTable dt = new DataTable();

            string sql = "";
            sql = "SELECT " +
                   "rownum sl, " +
                   "TO_DATE(PRODUCTION_DATE,'dd/mm/yyyy')PRODUCTION_DATE,  " +
                   "ORDER_QUANTITY, " +
                   "PO_NO, " +
                   "STYLE_NO, " +
                   "LINE_NO, " +
                   "BUYER_NAME, " +
                   "COLOR_NAME " +

                  " FROM VEW_SEARCH_DAILY_PRODUCT where head_office_id = '" + objProductionDTO.HeadOfficeId + "' and branch_office_id = '" + objProductionDTO.BranchOfficeId + "' ";




            if (objProductionDTO.FromDate.Length > 6 && objProductionDTO.ToDate.Length > 6)
            {

                sql = sql + " and PRODUCTION_DATE BETWEEN TO_DATE('" + objProductionDTO.ProductionDate + "', 'dd/mm/yyyy') AND TO_DATE('" + objProductionDTO.ProductionDate + "', 'dd/mm/yyyy')  ";
            }

            if (objProductionDTO.LineId.Length > 0)
            {

                sql = sql + " and LINE_ID = '" + objProductionDTO .LineId+ "' ";
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


        public ProductionDTO getOrderQuantity(string strPOId, string strStyleId, string strHeadOfficeId, string strBranchOfficeId)
        {

            ProductionDTO objProductionDTO = new ProductionDTO();
            ProductionDAL objProductionDAL = new ProductionDAL();

            string sql = "";
            sql = "SELECT " +
                  "order_quantity " +


                  "FROM vew_get_order_by_po_style where po_id = '" + strPOId + "' AND head_office_id = '"+strHeadOfficeId+"' and branch_office_id = '"+strBranchOfficeId+"' ";

            if (strStyleId.Length > 0)
            {
                sql = sql + " and style_id = '"+strStyleId+"' ";

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

                        objProductionDTO.OrderQuantity = Convert.ToString(objDataReader.GetInt32(0));


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
           
            return objProductionDTO;

        }


    }
}

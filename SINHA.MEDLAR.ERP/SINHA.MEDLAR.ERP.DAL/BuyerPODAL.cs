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

    public class BuyerPODAL
    {
        #region "Oracle Connection Function"

        private OracleConnection GetConnection()
        {
            var conString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConString"];
            string strConnString = conString.ConnectionString;
            return new OracleConnection(strConnString);
        }

        #endregion


        public string buyerPOsave(BuyerPODTO objBuyerPODTO)
        {

            BuyerDAL objBuyerDAL = new BuyerDAL();
            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("PRO_BUYER_PO_SAVE");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objBuyerPODTO.PONo != "")
            {

                objOracleCommand.Parameters.Add("P_PO_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objBuyerPODTO.PONo;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_PO_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objBuyerPODTO.BuyerId != "")
            {

                objOracleCommand.Parameters.Add("P_BUYER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objBuyerPODTO.BuyerId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_BUYER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objBuyerPODTO.StyleId != "")
            {

                objOracleCommand.Parameters.Add("P_STYLE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objBuyerPODTO.StyleId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_STYLE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objBuyerPODTO.ColorId != "")
            {

                objOracleCommand.Parameters.Add("P_COLOR_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objBuyerPODTO.ColorId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_COLOR_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objBuyerPODTO.OrderDate != "")
            {

                objOracleCommand.Parameters.Add("P_ORDER_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objBuyerPODTO.OrderDate;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_ORDER_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objBuyerPODTO.DeliveryDate != "")
            {

                objOracleCommand.Parameters.Add("P_DELIVERY_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objBuyerPODTO.DeliveryDate;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_DELIVERY_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objBuyerPODTO.OrderQuantity != "")
            {

                objOracleCommand.Parameters.Add("P_ORDER_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objBuyerPODTO.OrderQuantity;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_ORDER_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


          


            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objBuyerPODTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objBuyerPODTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objBuyerPODTO.BranchOfficeId;


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
        public string saveBuyerMeasurement(BuyerPODTO objBuyerPODTO)
        {

            BuyerDAL objBuyerDAL = new BuyerDAL();
            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("pro_buyer_measurement_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objBuyerPODTO.PONo != "")
            {

                objOracleCommand.Parameters.Add("P_PO_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objBuyerPODTO.PONo;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_PO_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objBuyerPODTO.Size != "")
            {

                objOracleCommand.Parameters.Add("P_PO_SIZE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objBuyerPODTO.Size;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_PO_SIZE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }




            if (objBuyerPODTO.Quantity != "")
            {

                objOracleCommand.Parameters.Add("P_ORDER_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objBuyerPODTO.Quantity;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_ORDER_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }




            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objBuyerPODTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objBuyerPODTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objBuyerPODTO.BranchOfficeId;


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
        public DataTable searchBuyerPO(BuyerPODTO objBuyerPODTO)
        {

            DataTable dt = new DataTable();
            BuyerPODAL objBuyerPODALL = new BuyerPODAL();

            string sql = "";

            sql = "SELECT " +
                  "SL, "+
                   "PO_NO, "+
                   "BUYER_ID, "+
                   "BUYER_NAME, "+
                   "STYLE_ID, "+
                   "STYLE_NAME, "+
                   "COLOR_ID, "+
                   "COLOR_NAME, "+
                   "TO_CHAR(ORDER_DATE, 'dd/mm/yyyy')ORDER_DATE, " +
                   "TO_CHAR(DELIVERY_DATE,'dd/mm/yyyy')DELIVERY_DATE, " +
                   "ORDER_QUANTITY, "+
                   "UPDATE_BY, "+
                   "UPDATE_DATE, "+
                   "HEAD_OFFICE_ID, "+
                   "BRANCH_OFFICE_ID " +

                  "FROM VEW_SEARCH_BUYER_PO WHERE head_office_id = '" + objBuyerPODTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objBuyerPODTO.BranchOfficeId + "'";


            if (objBuyerPODTO.PONo.Length > 0)
            {

                sql = sql + "and PO_NO = '" + objBuyerPODTO.PONo + "'";
            }

            if (objBuyerPODTO.BuyerId.Length > 0)
            {

                sql = sql + "and BUYER_ID = '" + objBuyerPODTO.BuyerId + "'";
            }


            if (objBuyerPODTO.StyleId.Length > 0)
            {

                sql = sql + "and STYLE_ID = '" + objBuyerPODTO.StyleId + "'";
            }


            if (objBuyerPODTO.FromDate.Length > 6 && objBuyerPODTO.ToDate.Length > 6)
            {

                sql = sql + "and ORDER_DATE BETWEEN to_date( '" + objBuyerPODTO.FromDate + "', 'dd/mm/yyyy') AND to_date( '" + objBuyerPODTO.ToDate + "', 'dd/mm/yyyy') ";
            }

            sql = sql + "order by SL ";

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
        public DataTable searchBuyerMeasurement(BuyerPODTO objBuyerPODTO)
        {

            DataTable dt = new DataTable();
            BuyerPODAL objBuyerPODALL = new BuyerPODAL();

            string sql = "";

            sql = "SELECT " +
                  "ROWNUM SL, " +
                   "PO_NO, " +
                   "PO_SIZE, " +
                   "ORDER_QUANTITY " +


                  "FROM VEW_SEARCH_BUYER_MEASUREMENT WHERE head_office_id = '" + objBuyerPODTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objBuyerPODTO.BranchOfficeId + "'";


            if (objBuyerPODTO.PONo.Length > 0)
            {

                sql = sql + "and PO_NO = '" + objBuyerPODTO.PONo + "'";
            }

            if (objBuyerPODTO.POSearchNo.Length > 0)
            {

                sql = sql + "and PO_NO = '" + objBuyerPODTO.POSearchNo + "'";
            }

            //if (objBuyerPODTO.BuyerId.Length > 0)
            //{

            //    sql = sql + "and BUYER_ID = '" + objBuyerPODTO.BuyerId + "'";
            //}


            //if (objBuyerPODTO.StyleId.Length > 0)
            //{

            //    sql = sql + "and STYLE_ID = '" + objBuyerPODTO.StyleId + "'";
            //}


            //if (objBuyerPODTO.FromDate.Length > 6 && objBuyerPODTO.ToDate.Length > 6)
            //{

            //    sql = sql + "and ORDER_DATE BETWEEN to_date( '" + objBuyerPODTO.FromDate + "', 'dd/mm/yyyy') AND to_date( '" + objBuyerPODTO.ToDate + "', 'dd/mm/yyyy') ";
            //}

            sql = sql + "order by SL ";

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
        public BuyerPODTO searchPoEntry(string strPONo, string strHeadOfficeId, string strBranchOffiecId)
        {
            BuyerPODTO objBuyerPODTO = new BuyerPODTO();
            

            string sql = "";

            sql = "SELECT " +
                  "TO_CHAR (NVL (buyer_name,'N/A')), " +
                  "TO_CHAR (NVL (color_name,'N/A')), " +
                  "TO_CHAR (NVL (style_name, 'N/A'))," +
                  "TO_CHAR (NVL (ORDER_QUANTITY, '0')) " +


                  "FROM vew_search_buyer_po WHERE PO_NO = '" + strPONo + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOffiecId + "' ";
                  



            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {
                    objBuyerPODTO.BuyerId = objDataReader.GetString(0);
                    objBuyerPODTO.ColorId = objDataReader.GetString(1);
                    objBuyerPODTO.StyleId = objDataReader.GetString(2);
                    objBuyerPODTO.OrderQuantity = objDataReader.GetString(3);

                }



            }
            return objBuyerPODTO;
        }
    }
}

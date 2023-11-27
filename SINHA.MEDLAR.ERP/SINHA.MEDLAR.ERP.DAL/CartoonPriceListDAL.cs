using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;


using SINHA.MEDLAR.ERP.DTO;
using Oracle.ManagedDataAccess.Client;


namespace SINHA.MEDLAR.ERP.DAL
{
    public class CartoonPriceListDAL
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

        //Save CartoonPriceList
        public string saveCartoonPriceList(CartoonPriceListDTO objCartoonPriceListDTO)
        {
            string strMsg = "";
            OracleCommand objOracleCommand = new OracleCommand("pro_Cartoon_Price_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objCartoonPriceListDTO.CartoonPriceId != "")
            {
                objOracleCommand.Parameters.Add("P_CARTOON_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCartoonPriceListDTO.CartoonPriceId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_CARTOON_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objCartoonPriceListDTO.PlyId != "")
            {
                objOracleCommand.Parameters.Add("P_CARTOON_PLY_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCartoonPriceListDTO.PlyId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_CARTOON_PLY_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objCartoonPriceListDTO.SupplierId != "0")
            {
                objOracleCommand.Parameters.Add("P_SUPPLIER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCartoonPriceListDTO.SupplierId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SUPPLIER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objCartoonPriceListDTO.MesurementUnit != "0")
            {
                objOracleCommand.Parameters.Add("P_MESUREMENT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCartoonPriceListDTO.MesurementUnit;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_MESUREMENT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objCartoonPriceListDTO.Length != "")
            {
                objOracleCommand.Parameters.Add("P_CARTOON_LENGTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCartoonPriceListDTO.Length;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_CARTOON_LENGTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objCartoonPriceListDTO.Width != "")
            {
                objOracleCommand.Parameters.Add("P_CARTOON_WIDTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCartoonPriceListDTO.Width;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_CARTOON_WIDTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objCartoonPriceListDTO.Height != "")
            {
                objOracleCommand.Parameters.Add("P_CARTOON_HEIGHT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCartoonPriceListDTO.Height;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_CARTOON_HEIGHT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objCartoonPriceListDTO.Perticulars != "")
            {
                objOracleCommand.Parameters.Add("P_CARTOON_PERTICULAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCartoonPriceListDTO.Perticulars;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_CARTOON_PERTICULAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

           
            if (objCartoonPriceListDTO.RateId != "")
            {
                objOracleCommand.Parameters.Add("P_CARTOON_RATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCartoonPriceListDTO.RateId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_CARTOON_RATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCartoonPriceListDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCartoonPriceListDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCartoonPriceListDTO.BranchOfficeId;
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
        //Serch CartoonPriceList
        public DataTable SearchCartoonPriceRecord(CartoonPriceListDTO objCartoonPriceListDTO)
        {
            DataTable dt = new DataTable();
            string sql = "";
            sql = "SELECT " +
                "CARTOON_PLY_ID," +
                " CARTOON_LENGTH," +
                " CARTOON_WIDTH," +
                " CARTOON_HEIGHT," +
                 " CARTOON_PERTICULAR," +
                 " MEASUREMENT_ID," +
                 " CARTOON_RATE," +
                 " CARTOON_ID" +
                  " FROM VEW_CARTOON_PRICE_LIST where SUPPLIER_ID = '" + objCartoonPriceListDTO.SupplierId + "' and HEAD_OFFICE_ID= '" + objCartoonPriceListDTO.HeadOfficeId + "' and BRANCH_OFFICE_ID= '" + objCartoonPriceListDTO.BranchOfficeId + "' ";
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
        //Load Cartoon Price Record All
        public DataTable loadCartoonPriceList(string strHeadOfficeId, string strBranchOfficeId)
        {
            CartoonPriceListDTO objCartoonPriceListDTO = new CartoonPriceListDTO();
            DataTable dt = new DataTable();
            string sql = "";
            sql = "SELECT " +
                " CARTOON_ID," +
                "CARTOON_PLY_ID," +
                " CARTOON_LENGTH," +
                " CARTOON_WIDTH," +
                " CARTOON_HEIGHT," +
                 " CARTOON_PERTICULAR," +
                 " MEASUREMENT_NAME," +
                 " CARTOON_RATE," +
                  " SUPPLIER_NAME" +

                  " FROM VEW_CARTOON_PRICE_LIST where head_office_id = '" + strHeadOfficeId + "' and branch_office_id = '" + strBranchOfficeId + "'  ORDER BY CARTOON_ID";
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
        //GridView Delete button
        public string deleteCartoonPriceRecord(CartoonPriceListDTO objCartoonPriceListDTO)
        {

            string strMsg = "";
            OracleCommand objOracleCommand = new OracleCommand("pro_Cartoon_Price_Delete");
            objOracleCommand.CommandType = CommandType.StoredProcedure;
            if (objCartoonPriceListDTO.CartoonPriceId != "")
            {
                objOracleCommand.Parameters.Add("P_CARTOON_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCartoonPriceListDTO.CartoonPriceId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_CARTOON_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCartoonPriceListDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objCartoonPriceListDTO.BranchOfficeId;
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

        public DataTable GetMesurementUnitId()
        {
            DataTable dt = new DataTable();
            string sql = "";
            sql = "select ' ' MEASUREMENT_ID, ' Please Select ' MEASUREMENT_NAME from dual " +
                    "union " +

                "SELECT " +
                  "to_char(MEASUREMENT_ID), " +
                 "to_char(MEASUREMENT_NAME) " +
                  "FROM L_MEASUREMENT order by MEASUREMENT_NAME ";

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

    }
}

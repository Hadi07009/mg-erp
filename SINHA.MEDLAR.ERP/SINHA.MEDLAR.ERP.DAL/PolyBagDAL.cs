using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SINHA.MEDLAR.ERP.DTO;

namespace SINHA.MEDLAR.ERP.DAL
{
   public class PolyBagDAL
    {
        private OracleTransaction trans;
        #region "Oracle Connection Function"

        private OracleConnection GetConnection()
        {
            var conString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConString"];
            string strConnString = conString.ConnectionString;
            return new OracleConnection(strConnString);
        }

        #endregion

        public DataTable GetPolyBagStyleId()
        {
            DataTable dt = new DataTable();
            string sql = "";
            sql = "select ' ' STYLE_ID, ' Please Select One ' STYLE_NO from dual " +
                    "union " +

                "SELECT " +
                  "to_char(STYLE_ID), " +
                 "to_char(STYLE_NO) " +
                  "FROM L_STYLE_STORE order by STYLE_NO ";

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

        public string savePolybagSentupInfo(PolyBagDTO objPolyBagDTO)
        {

            string strMsg = "";


            OracleCommand objOracleCommand = new OracleCommand("pro_polybag_setup_save");

            objOracleCommand.CommandType = CommandType.StoredProcedure;



            objOracleCommand.Parameters.Add("P_POLYBAG_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPolyBagDTO.PolybagId;

            if (objPolyBagDTO.StyleId != " ")
            {
                objOracleCommand.Parameters.Add("P_STYLE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPolyBagDTO.StyleId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_STYLE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objPolyBagDTO.PolybagLenght != " ")
            {
                objOracleCommand.Parameters.Add("P_POLY_BAG_LENGTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPolyBagDTO.PolybagLenght;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_POLY_BAG_LENGTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            if (objPolyBagDTO.PolybagWidth != " ")
            {
                objOracleCommand.Parameters.Add("P_POLY_BAG_WIDTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPolyBagDTO.PolybagWidth;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_POLY_BAG_WIDTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objPolyBagDTO.PolybagHeight != " ")
            {
                objOracleCommand.Parameters.Add("P_POLY_BAG_WIDTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPolyBagDTO.PolybagHeight;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_POLY_BAG_WIDTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            
            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPolyBagDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPolyBagDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPolyBagDTO.BranchOfficeId;

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


        public DataTable loadPolyBagRecord(PolyBagDTO objPolyBagDTO)
        {


            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +

                             "to_char(nvl(STYLE_ID, '0'))STYLE_ID, " +
                             
                               "to_char(nvl(POLY_BAG_LENGHT,'0'))POLY_BAG_LENGHT, " +
                               "to_char(nvl(POLY_BAG_WIDTH,'0'))POLY_BAG_WIDTH, " +
                               "to_char(nvl(POLY_BAG_HEIGHT,'0'))POLY_BAG_HEIGHT, " +
                                "to_char(nvl(TRAN_ID, '0'))TRAN_ID " +

                               " FROM  VEW_POLYBAG_SETUP where head_office_id = '" + objPolyBagDTO.HeadOfficeId + "' AND branch_office_id = '" + objPolyBagDTO.BranchOfficeId + "' ";





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

        public string deletePolybagSetupEntry(PolyBagDTO objPolyBagDTO)
        {
            LoginDTO objLoginDTO = new LoginDTO();
            string strMsg = "";


            OracleCommand objOracleCommand = new OracleCommand("pro_delete_polybag");

            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objPolyBagDTO.PolybagId != "")
            {
                objOracleCommand.Parameters.Add(" P_POLYBAG_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPolyBagDTO.PolybagId;

            }
            else
            {

                objOracleCommand.Parameters.Add(" P_POLYBAG_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPolyBagDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPolyBagDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPolyBagDTO.BranchOfficeId;


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
    }
}

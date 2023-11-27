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
    public class POOpenDAL
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


        public string addPOOpenInfo(POOpenDTO objPOOpenDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("PRO_PO_OPEN_SAVE");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objPOOpenDTO.BuyerId != "")
            {
                objOracleCommand.Parameters.Add("P_BUYER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOOpenDTO.BuyerId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_BUYER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objPOOpenDTO.PONo != "")
            {
                objOracleCommand.Parameters.Add("P_PO_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOOpenDTO.PONo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PO_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objPOOpenDTO.PODate.Length > 6 )
            {
                objOracleCommand.Parameters.Add("P_PO_OPEN_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOOpenDTO.PODate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PO_OPEN_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOOpenDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOOpenDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOOpenDTO.BranchOfficeId;


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
        public DataTable searchBuyerInfoFromPOMain(POOpenDTO objPOOpenDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

                sql = "SELECT " +

                           "PO_NO, " +
                           "PO_OPEN_DATE " +


                          "FROM VEW_SEARCH_PO_OPEN_RECORD WHERE head_office_id = '" + objPOOpenDTO.HeadOfficeId + "' AND branch_office_id = '" + objPOOpenDTO.BranchOfficeId + "' ";


            if (objPOOpenDTO.PONo.Length > 0)
            {
                sql = sql + "and PO_NO  =  '" + objPOOpenDTO.PONo + "' ";

            }
            if (objPOOpenDTO.BuyerId.Length > 0)
            {
                sql = sql + "and BUYER_ID='" + objPOOpenDTO.BuyerId + "' ";

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

        public DataTable loadPOOpenRecord(string strBuyerId, string strHeadOfficeId, string strBranchOfficeId)
        {

            POOpenDTO objPOOpenDTO = new POOpenDTO();
            POOpenDAL objPOOpenDAL = new POOpenDAL();

            DataTable dt = new DataTable();

            string sql = "";
            sql = "SELECT " +

                   "TO_CHAR(NVL(PO_NO,''))PO_NO, " +
                   "TO_CHAR(PO_OPEN_DATE,'dd/mm/yyyy')PO_OPEN_DATE, " +
                   "TO_CHAR(NVL(STATUS,''))STATUS " +

                  "FROM VEW_PO_OPEN where buyer_id ='" + strBuyerId + "' AND head_office_id = '" + strHeadOfficeId + "'  AND branch_office_id ='"+ strBranchOfficeId + "' ";

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

        public string deletePOOpenRecord(POOpenDTO objPOOpenDTO)
        {

            POOpenDAL objPOOpenDAL = new POOpenDAL();

            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("PRO_DELETE_PO_OPEN");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objPOOpenDTO.PONo != "")
            {

                objOracleCommand.Parameters.Add("P_PO_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOOpenDTO.PONo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PO_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objPOOpenDTO.BuyerId != "")
            {

                objOracleCommand.Parameters.Add("P_BUYER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOOpenDTO.BuyerId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_BUYER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objPOOpenDTO.PODate.Length > 6)
            {

                objOracleCommand.Parameters.Add("P_PO_OPEN_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOOpenDTO.PODate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PO_OPEN_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }



            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOOpenDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOOpenDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOOpenDTO.BranchOfficeId;


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

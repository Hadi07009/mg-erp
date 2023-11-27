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
    public class POCloseDAL
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


        public string addPOCloseInfo(POCloseDTO objPOCloseDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("PRO_PO_CLOSE_SAVE");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objPOCloseDTO.BuyerId != "")
            {
                objOracleCommand.Parameters.Add("P_BUYER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOCloseDTO.BuyerId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_BUYER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objPOCloseDTO.PONo != "")
            {
                objOracleCommand.Parameters.Add("P_PO_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOCloseDTO.PONo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PO_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objPOCloseDTO.PODate.Length > 6 )
            {
                objOracleCommand.Parameters.Add("P_PO_CLOSE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOCloseDTO.PODate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PO_CLOSE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objPOCloseDTO.FinalizedYN !="")
            {
                objOracleCommand.Parameters.Add("P_CLOSE_YN", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOCloseDTO.FinalizedYN;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_CLOSE_YN", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOCloseDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOCloseDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOCloseDTO.BranchOfficeId;


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
        public DataTable searchBuyerInfoFromPOMain(POCloseDTO objPOCloseDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

                sql = "SELECT " +

                           "PO_NO, " +
                           "PO_CLOSE_DATE " +


                          "FROM vew_search_po_close_record WHERE  head_office_id = '" + objPOCloseDTO.HeadOfficeId + "' AND branch_office_id = '" + objPOCloseDTO.BranchOfficeId + "' ";


            if (objPOCloseDTO.PONo.Length > 0)
            {
                sql = sql + "and PO_NO  =  '" + objPOCloseDTO.PONo + "' ";

            }
            if (objPOCloseDTO.BuyerId.Length > 0)
            {
                sql = sql + "and BUYER_ID='" + objPOCloseDTO.BuyerId + "' ";

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

        public DataTable loadPOCloseRecord(string strBuyerId, string strHeadOfficeId, string strBranchOfficeId)
        {

            POCloseDTO objPOCloseDTO = new POCloseDTO();
            POCloseDAL objPOCloseDAL = new POCloseDAL();

            DataTable dt = new DataTable();

            string sql = "";
            sql = "SELECT " +

                   "TO_CHAR(NVL(PO_NO,''))PO_NO, " +
                   "TO_CHAR(PO_CLOSE_DATE,'dd/mm/yyyy')PO_CLOSE_DATE, " +
                   "TO_CHAR(NVL(STATUS,''))STATUS " +

                  "FROM VEW_PO_CLOSE where buyer_id ='" + strBuyerId + "' AND  head_office_id = '" + strHeadOfficeId + "'  AND branch_office_id ='"+ strBranchOfficeId + "' ";

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

        public string deletePOCloseRecord(POCloseDTO objPOCloseDTO)
        {

            POCloseDAL objPOCloseDAL = new POCloseDAL();

            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("PRO_DELETE_PO_CLOSE");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objPOCloseDTO.PONo != "")
            {

                objOracleCommand.Parameters.Add("P_PO_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOCloseDTO.PONo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PO_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objPOCloseDTO.BuyerId != "")
            {

                objOracleCommand.Parameters.Add("P_BUYER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOCloseDTO.BuyerId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_BUYER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objPOCloseDTO.PODate.Length > 6)
            {

                objOracleCommand.Parameters.Add("P_PO_CLOSE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOCloseDTO.PODate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PO_CLOSE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }



            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOCloseDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOCloseDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOCloseDTO.BranchOfficeId;


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

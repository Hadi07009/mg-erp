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
    public class PoDocumentsDAL
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

        public string savePoDocumentsSave(PoDocumentsDTO objPoDocumentsDTO)
        {

            PoDocumentsDAL objPoPoDocumentsnDAL = new PoDocumentsDAL();

            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("pro_po_documents_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;
            
            if (objPoDocumentsDTO.PoNumber != "")
            {

                objOracleCommand.Parameters.Add("P_PO_NUMBER", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoDocumentsDTO.PoNumber;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PO_NUMBER", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objPoDocumentsDTO.DocumentName != "")
            {

                objOracleCommand.Parameters.Add("P_DOCUMENT_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoDocumentsDTO.DocumentName;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_DOCUMENT_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoDocumentsDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoDocumentsDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoDocumentsDTO.BranchOfficeId;


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


        public string deletePoDocumentsRecordRecord(PoDocumentsDTO objPoDocumentsDTO)
        {

            PoDocumentsDAL objPoDocumentsDAL = new PoDocumentsDAL();

            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("PRO_DELETE_PO_DOCUMENTS");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objPoDocumentsDTO.TranId != "")
            {

                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoDocumentsDTO.TranId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objPoDocumentsDTO.PoNumber != "")
            {

                objOracleCommand.Parameters.Add("P_PO_NUMBER", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoDocumentsDTO.PoNumber;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PO_NUMBER", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }



            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoDocumentsDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoDocumentsDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoDocumentsDTO.BranchOfficeId;


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
        public DataTable LoadPoNumber(PoDocumentsDTO objPoDocumentsDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +


                "TO_CHAR(NVL(PO_NUMBER,'0'))PO_NUMBER " +


                "FROM PO_ORDER_MAIN WHERE (lower(PO_NUMBER) like lower( '%" + objPoDocumentsDTO.PoNumber + "%')  or upper(PO_NUMBER)like upper('%" + objPoDocumentsDTO.PoNumber + "%')) AND  head_office_id = '" + objPoDocumentsDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objPoDocumentsDTO.BranchOfficeId + "' ORDER BY TRAN_ID ";


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
     
        public PoDocumentsDTO LoadPoDocumentsRecord(string strPoNumber, string strHeadOfficeId, string strBranchOfficeId)
        {

            PoDocumentsDTO objPoDocumentsDTO = new PoDocumentsDTO();
            PoDocumentsDAL objPoDocumentsDAL = new PoDocumentsDAL();

            string sql = "";
                sql = "SELECT " +

                      "TO_CHAR (NVL (DOCUMENT_NAME, '0'))DOCUMENT_NAME " +



                      " FROM PO_DOCUMENTS WHERE   head_office_id = '" + strHeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "' and PO_NUMBER = '" + strPoNumber + "'  ";
           
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

                        objPoDocumentsDTO.DocumentName = objDataReader1["DOCUMENT_NAME"].ToString();

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
           
            return objPoDocumentsDTO;
        }

    }
}
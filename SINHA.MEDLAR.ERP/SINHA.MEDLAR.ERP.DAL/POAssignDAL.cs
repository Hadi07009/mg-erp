using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;

using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace SINHA.MEDLAR.ERP.DAL
{
    public class POAssignDAL
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


        public DataTable ShowPOAssignRecord(POAssignDTO objPOAssignDTO)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            DataTable dt = new DataTable();

            string sql = "";
            sql = "SELECT " +
                   "PO_ID, " +
                   "PO_NO, " +
                   "STYLE_NO, " +
                   "BRANCH_OFFICE_NAME, " +
                   "line_name, " +
                   "TRAN_ID "+


                  "FROM vew_po_assign where head_office_id = '" + objPOAssignDTO.HeadOfficeId + "' AND branch_office_id = '" + objPOAssignDTO.BranchOfficeId + "' ";

            //if (objPOAssignDTO.POId !="")
            //{
            //    sql = sql + " and PO_ID = '" + objPOAssignDTO.POId + "' ";
            //}
            if (objPOAssignDTO.PONo != "")
            {
                sql = sql + " and PO_NO = '" + objPOAssignDTO.PONo + "' ";
            }
            //if (objPOAssignDTO.StyleId.Length > 0)
            //{
            //    sql = sql + " and STYLE_ID = '" + objPOAssignDTO.StyleId + "' ";
            //}

            if (objPOAssignDTO.LineId.Length > 0)
            {
                sql = sql + " and LINE_ID = '" + objPOAssignDTO.LineId + "' ";
            }

            sql = sql + "ORDER BY PO_ID";

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
        public DataTable loadPOAssignRecord(POAssignDTO objPOAssignDTO)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            DataTable dt = new DataTable();

            string sql = "";
            sql = "SELECT " + 
                   "PO_ID, " +
                   "PO_NO, " +
                   "STYLE_NO, " +
                   "BRANCH_OFFICE_NAME, " +
                   "line_name, " +
                   "TRAN_ID "+


                  "FROM vew_po_assign where head_office_id = '" + objPOAssignDTO.HeadOfficeId + "' AND branch_office_id = '"+ objPOAssignDTO .BranchOfficeId+ "' ";

            if (objPOAssignDTO.PONo != "")
            {
                sql = sql + " and PO_NO = '" + objPOAssignDTO.PONo + "' ";
            }
            sql = sql + "ORDER BY PO_ID";

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




        public POAssignDTO searchPOAssignnfo(string strPOIdId)
        {

            POAssignDTO objPOAssignDTO = new POAssignDTO();

            string sql = "";
            sql = "SELECT " +
                  "to_char(nvl(PO_NO,'0'))PO_NO, " +
                  "to_char(nvl(STYLE_ID,'0'))STYLE_ID, " +
                 
                  "to_char(nvl(LINE_ID,'0'))LINE_ID " +


                  "FROM vew_po_assign WHERE PO_ID = '" + strPOIdId + "'";




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
                        objPOAssignDTO.PONo = objDataReader.GetString(0);
                        objPOAssignDTO.StyleId = objDataReader.GetString(1);
                        objPOAssignDTO.FactoryId = objDataReader.GetString(2);
                        objPOAssignDTO.LineId = objDataReader.GetString(3);
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


            return objPOAssignDTO;

        }
        public POAssignDTO searchLineName(string strPoId, string strHeadOfficeId, string strBranchOfficeId)
        {

            POAssignDTO objPOAssignDTO = new POAssignDTO();

            string sql = "";
            sql = "SELECT " +
                  "to_char(nvl(LINE_ID,'0'))LINE_ID, " +
                  "to_char(nvl(STYLE_ID,'0'))STYLE_ID " +

                  "FROM vew_po_assign WHERE PO_ID = '" + strPoId + "' and head_office_id='"+ strHeadOfficeId + "' and branch_office_id='"+ strBranchOfficeId + "' ";

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
                        objPOAssignDTO.LineId = objDataReader.GetString(0);
                        objPOAssignDTO.StyleId = objDataReader.GetString(1);
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


            return objPOAssignDTO;

        }


        public string SavePOAssignInfo(POAssignDTO objPOAssignDTO)
        {

            
            string strMsg = "";


            OracleCommand objOracleCommand = new OracleCommand("pro_po_assign_save");

            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objPOAssignDTO.POId != "")
            {
                objOracleCommand.Parameters.Add("P_PO_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOAssignDTO.POId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_PO_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objPOAssignDTO.PONo != "")
            {
                objOracleCommand.Parameters.Add("P_PO_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOAssignDTO.PONo;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_PO_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objPOAssignDTO.StyleId != "")
            {
                objOracleCommand.Parameters.Add("P_STYLE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOAssignDTO.StyleId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_STYLE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            if (objPOAssignDTO.LineId != "")
            {
                objOracleCommand.Parameters.Add("P_LINE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOAssignDTO.LineId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_LINE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }




            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOAssignDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOAssignDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOAssignDTO.BranchOfficeId;


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
        public string deletePOAssignRecord(POAssignDTO objPOAssignDTO)
        {


            string strMsg = "";


            OracleCommand objOracleCommand = new OracleCommand("PRO_DELETE_PO_ASSIGN");

            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objPOAssignDTO.TranId != "")
            {
                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOAssignDTO.TranId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objPOAssignDTO.PONo != "")
            {
                objOracleCommand.Parameters.Add("P_PO_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOAssignDTO.PONo;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_PO_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objPOAssignDTO.StyleId != "")
            {
                objOracleCommand.Parameters.Add("P_STYLE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOAssignDTO.StyleId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_STYLE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
           
            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOAssignDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOAssignDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOAssignDTO.BranchOfficeId;


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

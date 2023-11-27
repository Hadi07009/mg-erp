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
    public class POEntryDAL
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
        public string savePOEntryInfo(POEntryDTO objPOEntryDTO)
        {

            POEntryDAL objPOEntryDAL = new POEntryDAL();

            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("pro_po_info_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objPOEntryDTO.TranId != "")
            {

                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOEntryDTO.TranId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objPOEntryDTO.PONo != "")
            {

                objOracleCommand.Parameters.Add("P_PO_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOEntryDTO.PONo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PO_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objPOEntryDTO.PODate.Length > 6)
            {

                objOracleCommand.Parameters.Add("P_PO_ISSUE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOEntryDTO.PODate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PO_ISSUE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }



            if (objPOEntryDTO.POTypeId != "")
            {

                objOracleCommand.Parameters.Add("P_PO_TYPE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOEntryDTO.POTypeId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PO_TYPE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objPOEntryDTO.BuyerId != "")
            {

                objOracleCommand.Parameters.Add("P_BUYER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOEntryDTO.BuyerId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_BUYER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objPOEntryDTO.Remarks != "")
            {

                objOracleCommand.Parameters.Add("P_REMARKS", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOEntryDTO.Remarks;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_REMARKS", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objPOEntryDTO.StyleNo != "")
            {

                objOracleCommand.Parameters.Add("P_STYLE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOEntryDTO.StyleNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_STYLE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objPOEntryDTO.ColorFullName != "")
            {

                objOracleCommand.Parameters.Add("P_COLOR_FULL_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOEntryDTO.ColorFullName;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_COLOR_FULL_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objPOEntryDTO.UnitRate != "")
            {

                objOracleCommand.Parameters.Add("P_UNIT_RATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOEntryDTO.UnitRate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_UNIT_RATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objPOEntryDTO.Quantity != "")
            {

                objOracleCommand.Parameters.Add("P_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOEntryDTO.Quantity;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            
            if (objPOEntryDTO.Amount != "")
            {

                objOracleCommand.Parameters.Add("P_AMOUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOEntryDTO.Amount;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_AMOUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }



            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOEntryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOEntryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOEntryDTO.BranchOfficeId;


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
        public string deletePoEntryRecord(POEntryDTO objPOEntryDTO)
        {

            POEntryDAL objPOEntryDAL = new POEntryDAL();

            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("PRO_DELETE_PO_INFO");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objPOEntryDTO.PONo != "")
            {

                objOracleCommand.Parameters.Add("P_PO_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOEntryDTO.PONo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PO_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objPOEntryDTO.PODate.Length > 6)
            {

                objOracleCommand.Parameters.Add("P_PO_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOEntryDTO.PODate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PO_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objPOEntryDTO.BuyerId != "")
            {

                objOracleCommand.Parameters.Add("P_BUYER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOEntryDTO.BuyerId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_BUYER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOEntryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOEntryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOEntryDTO.BranchOfficeId;


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
        public string deletePoEntrySubRecord(POEntryDTO objPOEntryDTO)
        {

            POEntryDAL objPOEntryDAL = new POEntryDAL();

            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("PRO_DELETE_PO_SUB");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objPOEntryDTO.TranId != "")
            {

                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOEntryDTO.TranId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objPOEntryDTO.PONo != "")
            {

                objOracleCommand.Parameters.Add("P_PO_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOEntryDTO.PONo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PO_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objPOEntryDTO.PODate.Length > 6)
            {

                objOracleCommand.Parameters.Add("P_PO_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOEntryDTO.PODate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PO_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objPOEntryDTO.BuyerId != "")
            {

                objOracleCommand.Parameters.Add("P_BUYER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOEntryDTO.BuyerId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_BUYER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOEntryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOEntryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPOEntryDTO.BranchOfficeId;


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
        public DataTable LoadPOEntryInfoSub(POEntryDTO objPOEntryDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

                sql = "SELECT " +

                      "TO_CHAR(NVL(TRAN_ID,''))TRAN_ID, " +
                       //"TO_CHAR(NVL(STYLE_ID,''))STYLE_ID, " +
                       //"TO_CHAR(NVL(COLOR_ID,''))COLOR_ID, " +
                       "TO_CHAR(NVL(STYLE_NO,''))STYLE_NO, " +
                       "TO_CHAR(NVL(COLOR_FULL_NAME,''))COLOR_FULL_NAME, " +
                       "TO_CHAR(NVL(UNIT_RATE,''))UNIT_RATE, " +
                       "TO_CHAR(NVL(QUANTITY,''))QUANTITY, " +
                       "TO_CHAR(NVL(AMOUNT,''))AMOUNT " +


                      "FROM VEW_PO_SUB WHERE head_office_id = '" + objPOEntryDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objPOEntryDTO.BranchOfficeId + "' and po_no ='"+ objPOEntryDTO.PONo+ "' AND po_date = TO_DATE('"+ objPOEntryDTO .PODate+ "','dd/mm/yyyy') and buyer_id = '"+ objPOEntryDTO.BuyerId+ "' and PO_TYPE_ID = '" + objPOEntryDTO.POTypeId + "' ORDER BY TO_NUMBER(TRAN_ID) ";



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


        public POEntryDTO searchPOInfoMain(string strPONo, string strHeadOfficeId, string strBranchOfficeId)
        {


            POEntryDTO objPOEntryDTO = new POEntryDTO();
            POEntryDAL objPOEntryDAL = new POEntryDAL();

            string sql = "";
            sql = "SELECT " +

                    "TO_CHAR (NVL (PO_NO,'0'))PO_NO, " +
                    "nvl(to_char(PO_ISSUE_DATE,'dd/mm/yyyy'),''), " +
                    "TO_CHAR (NVL (PO_TYPE_ID,'0'))PO_TYPE_ID, " +
                    "TO_CHAR (NVL (BUYER_ID,'0'))BUYER_ID, " +
                    "TO_CHAR (NVL (REMARKS,'0'))REMARKS " +


                    "from VEW_PO_MAIN where PO_NO = '" + strPONo + "' AND head_office_id = '" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "'  ";


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


                        objPOEntryDTO.PONo = objDataReader.GetString(0);
                        objPOEntryDTO.PODate = objDataReader.GetString(1);
                        objPOEntryDTO.POTypeId = objDataReader.GetString(2);
                        objPOEntryDTO.BuyerId = objDataReader.GetString(3);
                        objPOEntryDTO.Remarks = objDataReader.GetString(4);
                       
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



            return objPOEntryDTO;


        }
        public POEntryDTO chkPOExists(string strPONo, string strHeadOfficeId, string strBranchOfficeId)
        {


            POEntryDTO objPOEntryDTO = new POEntryDTO();
            POEntryDAL objPOEntryDAL = new POEntryDAL();

            string strCount="";
            string sql = "";
            sql = "SELECT " +

                    " count(*)  " +


                    " from VEW_PO_MAIN where PO_NO = '" + strPONo + "' AND head_office_id = '" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "'  ";


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


                        strCount =  objDataReader.GetString(0);
                       

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



            if(Convert.ToInt32(strCount) > 1)

            {

                string sql2 = "";
                sql2 = "SELECT " +

                    " to_char(po_issue_date, 'dd/mm/yyyy') " +


                    "from VEW_PO_MAIN where PO_NO = '" + strPONo + "' AND head_office_id = '" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "'  ";


                OracleCommand objCommand2 = new OracleCommand(sql2);
                OracleDataReader objDataReader2;

                using (OracleConnection strConn = GetConnection())
                {

                    objCommand2.Connection = strConn;
                    strConn.Open();
                    objDataReader2 = objCommand2.ExecuteReader();
                    try
                    {
                        while (objDataReader2.Read())
                        {


                            objPOEntryDTO.PODate = objDataReader2.GetString(0);


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

            }



            return objPOEntryDTO;


        }

        public POEntryDTO chkStyleNo(string strStyleNo,string strBuyerId, string strHeadOfficeId, string strBranchOfficeId)
        {


            POEntryDTO objPOEntryDTO = new POEntryDTO();
            POEntryDAL objPOEntryDAL = new POEntryDAL();

            string sql = "";
            sql = "SELECT " +

                     "'Y' " +

                    "from L_STYLE where STYLE_NO = '" + strStyleNo + "' AND BUYER_ID= '" + strBuyerId + "' AND head_office_id = '" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "' ";


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


                        objPOEntryDTO.ChkYN = objDataReader.GetString(0);                      

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



            return objPOEntryDTO;


        }
        public POEntryDTO chkColorName(string strColorFullName,string strBuyerId, string strHeadOfficeId, string strBranchOfficeId)
        {


            POEntryDTO objPOEntryDTO = new POEntryDTO();
            POEntryDAL objPOEntryDAL = new POEntryDAL();

            string sql = "";
            sql = "SELECT " +

                     "'Y' " +

                    "from L_COLOR where COLOR_FULL_NAME = '" + strColorFullName + "' AND BUYER_ID= '"+ strBuyerId + "' AND head_office_id = '" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "' ";


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


                        objPOEntryDTO.ChkYN = objDataReader.GetString(0);

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



            return objPOEntryDTO;


        }

    }
}

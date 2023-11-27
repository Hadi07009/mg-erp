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
    public class FabricsImportRatioDAL
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
        public string saveFabricsImportRatioInfo(FabricsImportRatioDTO objFabricsRatioDTO)
        {

            ContractDAL objContractDAL = new ContractDAL();

            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("PRO_FABRICS_IMPORT_RATIO_SAVE");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objFabricsRatioDTO.TranId != "")
            {

                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricsRatioDTO.TranId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objFabricsRatioDTO.ContactNo != "")
            {

                objOracleCommand.Parameters.Add("P_CONTRACT_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricsRatioDTO.ContactNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_CONTRACT_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objFabricsRatioDTO.FobDate != "")
            {

                objOracleCommand.Parameters.Add("P_FOB_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricsRatioDTO.FobDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_FOB_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objFabricsRatioDTO.AmendmentDate != "")
            {

                objOracleCommand.Parameters.Add("P_FOB_ORGINAL_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricsRatioDTO.FobOrginalDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_FOB_ORGINAL_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objFabricsRatioDTO.PONo != "")
            {

                objOracleCommand.Parameters.Add("P_PO_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricsRatioDTO.PONo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PO_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objFabricsRatioDTO.StyleNo != "")
            {

                objOracleCommand.Parameters.Add("P_STYLE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricsRatioDTO.StyleNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_STYLE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objFabricsRatioDTO.SizeId != "")
            {

                objOracleCommand.Parameters.Add("P_SIZE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricsRatioDTO.SizeId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SIZE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objFabricsRatioDTO.OrderQuantity != "")
            {

                objOracleCommand.Parameters.Add("P_ORDER_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricsRatioDTO.OrderQuantity;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_ORDER_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objFabricsRatioDTO.BuyerId != "")
            {

                objOracleCommand.Parameters.Add("P_BUYER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricsRatioDTO.BuyerId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_BUYER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objFabricsRatioDTO.FabricYard != "")
            {

                objOracleCommand.Parameters.Add("P_FABRIC_YARD", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricsRatioDTO.FabricYard;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_FABRIC_YARD", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objFabricsRatioDTO.TotalQty != "")
            {

                objOracleCommand.Parameters.Add("P_TOTAL_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricsRatioDTO.TotalQty;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_TOTAL_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objFabricsRatioDTO.SeasonId !="")
            {

                objOracleCommand.Parameters.Add("P_SEASON_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricsRatioDTO.SeasonId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SEASON_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
           

            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricsRatioDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricsRatioDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricsRatioDTO.BranchOfficeId;


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


        public string deleteFabricsImportRatioInfo(FabricsImportRatioDTO objFabricsRatioDTO)
        {

            FabricsImportRatioDAL objFabricsImportRatioDAL = new FabricsImportRatioDAL();

            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("PRO_DELETE_FAB_IMPORT_RATIO");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objFabricsRatioDTO.ContactNo != "")
            {

                objOracleCommand.Parameters.Add("P_CONTRACT_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricsRatioDTO.ContactNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_CONTRACT_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objFabricsRatioDTO.IssueDate.Length > 6)
            {

                objOracleCommand.Parameters.Add("P_CONTRACT_ISSUE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricsRatioDTO.IssueDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_CONTRACT_ISSUE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objFabricsRatioDTO.AmendmentDate.Length > 6)
            {

                objOracleCommand.Parameters.Add("P_AMENDMENT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricsRatioDTO.AmendmentDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_AMENDMENT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }



            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricsRatioDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricsRatioDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricsRatioDTO.BranchOfficeId;


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
        public DataTable searchFabricsImportRatioRecord(FabricsImportRatioDTO objFabricsRatioDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";




                sql = "SELECT " +

                      "TO_CHAR(NVL(TRAN_ID,'0'))TRAN_ID, " +
                      "TO_CHAR(NVL(SIZE_ID,'0'))SIZE_ID, " +
                      "TO_CHAR(NVL(ORDER_QUANTITY,'0'))ORDER_QUANTITY, " +
                      "TO_CHAR(NVL(FABRIC_YARD,'0'))FABRIC_YARD, " +
                      "TO_CHAR(NVL(TOTAL_QUANTITY,'0'))TOTAL_QUANTITY " +



                     "FROM vew_fabrics_import_ratio_sub WHERE CONTRACT_NO = '" + objFabricsRatioDTO.ContactNo + "' AND head_office_id = '" + objFabricsRatioDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objFabricsRatioDTO.BranchOfficeId + "'  ";




                if (objFabricsRatioDTO.PONo.Length > 0)
                {

                    sql = sql + "and PO_NO = '" + objFabricsRatioDTO.PONo + "' ";
                }

                if (objFabricsRatioDTO.StyleNo.Length > 0)
                {

                    sql = sql + "and STYLE_NO = '" + objFabricsRatioDTO.StyleNo + "' ";
                }


                if (objFabricsRatioDTO.FobDate.Length > 6)
                {

                    sql = sql + "and FOB_DATE = TO_DATE('" + objFabricsRatioDTO.FobDate + "','dd/mm/yyyy' )";
                }

                if (objFabricsRatioDTO.FobOrginalDate.Length > 6)
                {

                    sql = sql + "and FOB_ORGINAL_DATE = TO_DATE('" + objFabricsRatioDTO.FobOrginalDate + "','dd/mm/yyyy' )";
                }


            

            sql = sql + "order by TRAN_ID ";

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
        public string deleteFabImportInfoRecord(FabricsImportRatioDTO objFabricsImportRatioDTO)
        {

            ContractDAL objContractDAL = new ContractDAL();

            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("PRO_DELETE_FABRICS_SUB");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            if (objFabricsImportRatioDTO.TranId != "")
            {

                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricsImportRatioDTO.TranId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objFabricsImportRatioDTO.ContactNo != "")
            {

                objOracleCommand.Parameters.Add("P_CONTRACT_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricsImportRatioDTO.ContactNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_CONTRACT_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objFabricsImportRatioDTO.FobDate.Length > 6)
            {

                objOracleCommand.Parameters.Add("P_FOB_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricsImportRatioDTO.FobDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_FOB_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objFabricsImportRatioDTO.FobOrginalDate.Length > 6)
            {

                objOracleCommand.Parameters.Add("P_FOB_ORGINAL_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricsImportRatioDTO.FobOrginalDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_FOB_ORGINAL_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objFabricsImportRatioDTO.PONo != "")
            {

                objOracleCommand.Parameters.Add("P_PO_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricsImportRatioDTO.PONo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PO_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objFabricsImportRatioDTO.StyleNo != "")
            {

                objOracleCommand.Parameters.Add("P_STYLE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricsImportRatioDTO.StyleNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_STYLE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricsImportRatioDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricsImportRatioDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricsImportRatioDTO.BranchOfficeId;


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
        public FabricsImportRatioDTO searchFabImportRatioMain(string strContactNo, string strPONo, string strStyleNo, string strFOBDate, string strFOBOrginalDate, string strHeadOfficeId, string strBranchOfficeId)
        {


            FabricsImportRatioDTO objFabricsImportRatioDTO = new FabricsImportRatioDTO();
           
            string sql = "";
            sql = "SELECT " +

                    "NVL (TO_CHAR (FOB_DATE, 'dd/mm/yyyy'), '0'), " +
                    "NVL (TO_CHAR (FOB_ORGINAL_DATE, 'dd/mm/yyyy'), '0'), " +
                    "TO_CHAR (NVL (PO_NO, '0')), " +
                    "TO_CHAR (NVL (STYLE_NO, '0')), " +
                    "TO_CHAR (NVL (BUYER_ID, '0')), " +
                    "TO_CHAR (NVL (SEASON_ID, '0')) " +



                    "from VEW_FABRICS_IMPORT_RATIO_MAIN where CONTRACT_NO = '" + strContactNo + "'  AND head_office_id = '" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "' ";


            if (strFOBDate.Length > 0)
            {

                sql = sql + "and FOB_DATE = TO_DATE(  '" + strFOBDate + "','dd/mm/yyyy') ";
            }

            if (strFOBOrginalDate.Length > 0)
            {

                sql = sql + "and FOB_ORGINAL_DATE = TO_DATE(  '" + strFOBOrginalDate + "','dd/mm/yyyy') ";
            }

            if (strPONo.Length > 0)
            {

                sql = sql + "and PO_NO = '" + strPONo + "' ";
            }


            if (strStyleNo.Length > 0)
            {

                sql = sql + "and STYLE_NO = '"+strStyleNo+"'  ";
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


                        objFabricsImportRatioDTO.FobDate = objDataReader.GetString(0);
                        objFabricsImportRatioDTO.FobOrginalDate = objDataReader.GetString(1);
                        objFabricsImportRatioDTO.PONo = objDataReader.GetString(2);
                        objFabricsImportRatioDTO.StyleNo = objDataReader.GetString(3);
                        objFabricsImportRatioDTO.BuyerId = objDataReader.GetString(4);
                        objFabricsImportRatioDTO.SeasonId = objDataReader.GetString(5);


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



            return objFabricsImportRatioDTO;


        }

    }
}
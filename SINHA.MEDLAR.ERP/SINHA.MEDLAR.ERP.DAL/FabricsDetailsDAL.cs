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
    public class FabricsDetailsDAL
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

        public string saveFabricsDetailsInfo(FabricsDetailsDTO objFabricsDetailsDTO)
        {

            ContractDAL objContractDAL = new ContractDAL();

            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("PRO_FABRICS_DETAIL_SAVE");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objFabricsDetailsDTO.TranId != "")
            {

                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricsDetailsDTO.TranId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objFabricsDetailsDTO.ContactNo != "")
            {

                objOracleCommand.Parameters.Add("P_CONTRACT_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricsDetailsDTO.ContactNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_CONTRACT_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objFabricsDetailsDTO.FobDate != "")
            {

                objOracleCommand.Parameters.Add("P_FOB_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricsDetailsDTO.FobDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_FOB_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objFabricsDetailsDTO.OrderQuantity != "")
            {

                objOracleCommand.Parameters.Add("P_ORDER_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricsDetailsDTO.OrderQuantity;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_ORDER_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objFabricsDetailsDTO.PONo != "")
            {

                objOracleCommand.Parameters.Add("P_PO_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricsDetailsDTO.PONo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PO_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objFabricsDetailsDTO.StyleNo != "")
            {

                objOracleCommand.Parameters.Add("P_STYLE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricsDetailsDTO.StyleNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_STYLE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objFabricsDetailsDTO.FebricsDescrition != "")
            {

                objOracleCommand.Parameters.Add("P_FABRICS_DESCRIPTION", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricsDetailsDTO.FebricsDescrition;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_FABRICS_DESCRIPTION", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objFabricsDetailsDTO.Supplier != "")
            {

                objOracleCommand.Parameters.Add("P_SUPPLIER", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricsDetailsDTO.Supplier;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SUPPLIER", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objFabricsDetailsDTO.SizeId != "")
            {

                objOracleCommand.Parameters.Add("P_SIZE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricsDetailsDTO.SizeId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SIZE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objFabricsDetailsDTO.Consumtion != "")
            {

                objOracleCommand.Parameters.Add("P_CONSUMTION", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricsDetailsDTO.Consumtion;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_CONSUMTION", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objFabricsDetailsDTO.Price != "")
            {

                objOracleCommand.Parameters.Add("P_PRICE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricsDetailsDTO.Price;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PRICE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objFabricsDetailsDTO.TotalPrice != "")
            {

                objOracleCommand.Parameters.Add("P_TOTAL_PRICE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricsDetailsDTO.TotalPrice;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_TOTAL_PRICE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objFabricsDetailsDTO.BudgetQtyInYds != "")
            {

                objOracleCommand.Parameters.Add("P_BUDGET_QTY_IN_YDS", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricsDetailsDTO.BudgetQtyInYds;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_BUDGET_QTY_IN_YDS", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objFabricsDetailsDTO.BudgetValue != "")
            {

                objOracleCommand.Parameters.Add("P_BUDGET_VALUE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricsDetailsDTO.BudgetValue;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_BUDGET_VALUE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objFabricsDetailsDTO.ActualQtyInYds != "")
            {

                objOracleCommand.Parameters.Add("P_ACTUAL_QTY_IN_YDS", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricsDetailsDTO.ActualQtyInYds;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_ACTUAL_QTY_IN_YDS", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objFabricsDetailsDTO.ActualPrice != "")
            {

                objOracleCommand.Parameters.Add("P_ACTUAL_PRICE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricsDetailsDTO.ActualPrice;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_ACTUAL_PRICE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objFabricsDetailsDTO.ActualValue != "")
            {

                objOracleCommand.Parameters.Add("P_ACTUAL_VALUE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricsDetailsDTO.ActualValue;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_ACTUAL_VALUE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objFabricsDetailsDTO.ActualPerGmts != "")
            {

                objOracleCommand.Parameters.Add("P_ACTUAL_PER_GMT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricsDetailsDTO.ActualPerGmts;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_ACTUAL_PER_GMT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objFabricsDetailsDTO.Variance != "")
            {

                objOracleCommand.Parameters.Add("P_VARIANCE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricsDetailsDTO.Variance;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_VARIANCE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objFabricsDetailsDTO.ImportPINo != "")
            {

                objOracleCommand.Parameters.Add("P_IMPORT_PI_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricsDetailsDTO.ImportPINo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_IMPORT_PI_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objFabricsDetailsDTO.ImportDate != "")
            {

                objOracleCommand.Parameters.Add("P_IMPORT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricsDetailsDTO.ImportDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_IMPORT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objFabricsDetailsDTO.ImportSupplier != "")
            {

                objOracleCommand.Parameters.Add("P_IMPORT_SUPPLIER", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricsDetailsDTO.ImportSupplier;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_IMPORT_SUPPLIER", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objFabricsDetailsDTO.BuyerId != "")
            {

                objOracleCommand.Parameters.Add("P_BUYER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricsDetailsDTO.BuyerId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_BUYER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objFabricsDetailsDTO.SeasonId != "")
            {

                objOracleCommand.Parameters.Add("P_SEASON_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricsDetailsDTO.SeasonId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SEASON_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricsDetailsDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricsDetailsDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricsDetailsDTO.BranchOfficeId;


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
        public DataTable searchFabricsDetailsRecord(FabricsDetailsDTO objFabricsDetailsDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";


            sql = "SELECT " +

                 "TO_CHAR(NVL(TRAN_ID,'0'))TRAN_ID, " +
     "CONTRACT_NO, " +
     "TO_CHAR(FOB_DATE,'dd/mm/yyyy')FOB_DATE, " +
     "ORDER_QUANTITY, " +
     "PO_NO, " +
     "STYLE_NO, " +
     "TO_CHAR(NVL(FABRICS_DESCRIPTION,'0'))FABRICS_DESCRIPTION, " +
     "TO_CHAR(NVL(SUPPLIER,'0'))SUPPLIER, " +
     "TO_CHAR(NVL(SIZE_ID,'0'))SIZE_ID, " +
     "TO_CHAR(NVL(CONSUMPTION,'0'))CONSUMPTION, " +
     "TO_CHAR(NVL(PRICE,'0'))PRICE, " +
     "TO_CHAR(NVL(TOTAL_PRICE,'0'))TOTAL_PRICE, " +
     "TO_CHAR(NVL(BUDGET_QTY_IN_YDS,'0'))BUDGET_QTY_IN_YDS, " +
     "TO_CHAR(NVL(BUDGET_VALUE,'0'))BUDGET_VALUE, " +
     "TO_CHAR(NVL(ACTUAL_QTY_IN_YDS,'0'))ACTUAL_QTY_IN_YDS, " +
     "TO_CHAR(NVL(ACTUAL_PRICE,'0')) ACTUAL_PRICE, " +
     "TO_CHAR(NVL(ACTUAL_VALUE,'0')) ACTUAL_VALUE, " +
     "TO_CHAR(NVL(ACTUAL_PER_GMT,'0'))ACTUAL_PER_GMT, " +
     "TO_CHAR(NVL(VARIANCE,'0'))VARIANCE, " +
     "TO_CHAR(NVL(IMPORT_PI_NO,'0'))IMPORT_PI_NO, " +
     "TO_CHAR(IMPORT_DATE,'dd/mm/yyyy')IMPORT_DATE, " +
     "TO_CHAR(NVL(IMPORT_SUPPLIER,'N/A'))IMPORT_SUPPLIER " +


    "FROM VEW_FABRICS_DETAIL_SUB WHERE CONTRACT_NO = '" + objFabricsDetailsDTO.ContactNo + "' AND head_office_id = '" + objFabricsDetailsDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objFabricsDetailsDTO.BranchOfficeId + "'  ";






            if (objFabricsDetailsDTO.PONo.Length > 0)
            {

                sql = sql + "and PO_NO = '" + objFabricsDetailsDTO.PONo + "' ";
            }

            if (objFabricsDetailsDTO.StyleNo.Length > 0)
            {

                sql = sql + "and STYLE_NO = '" + objFabricsDetailsDTO.StyleNo + "' ";
            }


            if (objFabricsDetailsDTO.FobDate.Length > 6)
            {

                sql = sql + "and FOB_DATE = TO_CHAR(TO_DATE('" + objFabricsDetailsDTO.FobDate + "','dd/mm/yyyy' ))";
            }

            //sql = sql + "order by CONTRACT_DELIVERY_DATE ";

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
        public FabricsDetailsDTO searchFabricsDetailsRecordMain(string strContactNo, string strPONo, string strStyleNo, string strFobDate, string strHeadOfficeId, string strBranchOfficeId)
        {


            FabricsDetailsDTO objFabricsDetailsDTO = new FabricsDetailsDTO();
            FabricsDetailsDAL objFabricsDetailsDAL = new FabricsDetailsDAL();

            string sql = "";
            sql = "SELECT distinct " +

                 "TO_CHAR (NVL (CONTRACT_NO, '')), " +
                 "TO_CHAR (NVL (PO_NO, '')), " +
                 "TO_CHAR (NVL (STYLE_NO, '')), " +
                 "NVL (TO_CHAR (FOB_DATE, 'dd/mm/yyyy'), '0')FOB_DATE, " +
                 "TO_CHAR (NVL (ORDER_QUANTITY, '')), " +
                 "TO_CHAR (NVL (BUYER_ID, '')), " +
                 "TO_CHAR (NVL (SEASON_ID, '')) " +



                    "from WEW_FABRICS_DETAIL_MAIN where CONTRACT_NO = '" + strContactNo + "'  AND head_office_id = '" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "' ";


            if (strPONo.Length > 0)
            {

                sql = sql + "and PO_NO =  '" + strPONo + "' ";
            }

            if (strStyleNo.Length > 0)
            {

                sql = sql + "and STYLE_NO = '" + strStyleNo + "' ";
            }

            if (strFobDate.Length > 6)
            {

                sql = sql + "and FOB_Date = TO_DATE(  '" + strFobDate + "','dd/mm/yyyy') ";
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
                        objFabricsDetailsDTO.ContactNo = objDataReader.GetString(0);
                        objFabricsDetailsDTO.PONo = objDataReader.GetString(1);
                        objFabricsDetailsDTO.strStyleNo = objDataReader.GetString(2);
                        objFabricsDetailsDTO.FobDate = objDataReader.GetString(3);
                        objFabricsDetailsDTO.OrderQuantity = objDataReader.GetString(4);
                        objFabricsDetailsDTO.BuyerId = objDataReader.GetString(5);
                        objFabricsDetailsDTO.SeasonId = objDataReader.GetString(6);


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



            return objFabricsDetailsDTO;


        }
        public FabricsDetailsDTO getFobDateAndOrderQty(FabricsDetailsDTO objFabricsDetailsDTO)
        {



            FabricsDetailsDAL objFabricsDetailsDAL = new FabricsDetailsDAL();

            string sql = "";
            sql = "SELECT " +

                 "NVL (TO_CHAR (CONTRACT_DELIVERY_DATE, 'dd/mm/yyyy'), '0')CONTRACT_DELIVERY_DATE, " +
                 "TO_CHAR (NVL (ORDER_QUANTITY, '0')) " +



                    "from CONTRACT_SUB where CONTRACT_NO = '" + objFabricsDetailsDTO.ContactNo + "' AND PO_NO='" + objFabricsDetailsDTO.PONo + "' AND STYLE_NO='" + objFabricsDetailsDTO.StyleNo + "' AND head_office_id = '" + objFabricsDetailsDTO.HeadOfficeId + "' AND branch_office_id = '" + objFabricsDetailsDTO.BranchOfficeId + "' ";


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
                        objFabricsDetailsDTO.FobDate = objDataReader.GetString(0);
                        objFabricsDetailsDTO.OrderQuantity = objDataReader.GetString(1);


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



            return objFabricsDetailsDTO;


        }
    }
}
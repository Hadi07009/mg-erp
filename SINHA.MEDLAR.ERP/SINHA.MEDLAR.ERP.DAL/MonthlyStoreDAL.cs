using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;


using SINHA.MEDLAR.ERP.DTO;
using Oracle.ManagedDataAccess.Client;

using System.Configuration;

namespace SINHA.MEDLAR.ERP.DAL
{
    public class MonthlyStoreDAL
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

        public string saveMonthlyStoreInfo(MonthlyStoreDTO objMonthlyStoreDTO)
        {

            string strMsg = "";

            OracleCommand objOracleCommand = new OracleCommand("pro_monthly_store_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objMonthlyStoreDTO.TranId != "")
            {

                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMonthlyStoreDTO.TranId;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;


            }


            if (objMonthlyStoreDTO.Year != "")
            {

                objOracleCommand.Parameters.Add("P_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMonthlyStoreDTO.Year;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;


            }

            if (objMonthlyStoreDTO.Month != "")
            {

                objOracleCommand.Parameters.Add("P_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMonthlyStoreDTO.Month;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;


            }

            if (objMonthlyStoreDTO.PartNo != "")
            {
                objOracleCommand.Parameters.Add("P_PART_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMonthlyStoreDTO.PartNo;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_PART_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objMonthlyStoreDTO.BeginingStock != "")
            {
                objOracleCommand.Parameters.Add("P_BEGINING_STOCK", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMonthlyStoreDTO.BeginingStock;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_BEGINING_STOCK", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objMonthlyStoreDTO.OpeningStock != "")
            {
                objOracleCommand.Parameters.Add("P_OPENING_STOCK", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMonthlyStoreDTO.OpeningStock;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_OPENING_STOCK", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objMonthlyStoreDTO.ClosingBlance != "")
            {
                objOracleCommand.Parameters.Add("P_CLOSING_BLANCE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMonthlyStoreDTO.ClosingBlance;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_CLOSING_BLANCE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objMonthlyStoreDTO.EquipementId != "")
            {
                objOracleCommand.Parameters.Add("P_EQUIPMENT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMonthlyStoreDTO.EquipementId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_EQUIPMENT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objMonthlyStoreDTO.SparePartId != "")
            {
                objOracleCommand.Parameters.Add("P_SPARE_PART_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMonthlyStoreDTO.SparePartId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_SPARE_PART_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMonthlyStoreDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMonthlyStoreDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMonthlyStoreDTO.BranchOfficeId;


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
        public string MonthlyClosingBlance(MonthlyStoreDTO objMonthlyStoreDTO)
        {

            string strMsg = "";

            OracleCommand objOracleCommand = new OracleCommand("pro_monthly_closing_blance");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            if (objMonthlyStoreDTO.PartNo != "")
            {
                objOracleCommand.Parameters.Add("P_PART_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMonthlyStoreDTO.PartNo;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_PART_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objMonthlyStoreDTO.EquipementId != "")
            {
                objOracleCommand.Parameters.Add("p_EQUIPMENT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMonthlyStoreDTO.EquipementId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_EQUIPMENT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objMonthlyStoreDTO.PartId != "")
            {
                objOracleCommand.Parameters.Add("p_SPARE_PART_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMonthlyStoreDTO.PartId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_SPARE_PART_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            if (objMonthlyStoreDTO.Year != "")
            {
                objOracleCommand.Parameters.Add("P_TRAN_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMonthlyStoreDTO.Year;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_TRAN_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objMonthlyStoreDTO.Month != "")
            {
                objOracleCommand.Parameters.Add("P_TRAN_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMonthlyStoreDTO.Month;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_TRAN_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMonthlyStoreDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMonthlyStoreDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMonthlyStoreDTO.BranchOfficeId;


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
        public string deleteMonthlyRecord(MonthlyStoreDTO objMonthlyStoreDTO)
        {

            string strMsg = "";

            OracleCommand objOracleCommand = new OracleCommand("pro_delete_monthly_store_info");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objMonthlyStoreDTO.TranId != "")
            {

                objOracleCommand.Parameters.Add("p_tran_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMonthlyStoreDTO.TranId;

            }
            else
            {
                objOracleCommand.Parameters.Add("p_tran_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;


            }

            if (objMonthlyStoreDTO.Year !="" )
            {

                objOracleCommand.Parameters.Add("P_TRAN_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMonthlyStoreDTO.Year;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_TRAN_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;


            }
            if (objMonthlyStoreDTO.Month != "")
            {

                objOracleCommand.Parameters.Add("P_TRAN_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMonthlyStoreDTO.Month;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_TRAN_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;


            }




            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMonthlyStoreDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMonthlyStoreDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMonthlyStoreDTO.BranchOfficeId;


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


        public DataTable loadMonthlyStoreRecord(string strSparePartId, string strEquipementId, string strPartNo, string strYear, string strMonth, string strHeadOfficeId, string strBranchOfficeId)
        {

            MonthlyStoreDTO objMonthlyStoreDTO = new MonthlyStoreDTO();
            MonthlyStoreDAL objMonthlyStoreDAL = new MonthlyStoreDAL();

            DataTable dt = new DataTable();

            string sql = "";
            sql = "SELECT " +

                  "TO_CHAR (NVL (TRAN_ID,''))TRAN_ID, " +
                  "TO_CHAR(NVL(TRAN_YEAR,''))TRAN_YEAR, " +
                  "TO_CHAR(NVL(TRAN_MONTH,''))TRAN_MONTH, " +
                  "TO_CHAR (NVL (PART_NO,''))PART_NO, " +
                  "TO_CHAR (NVL (BEGINING_STOCK,''))BEGINING_STOCK, " +
                  "TO_CHAR (NVL (OPENING_STOCK,''))OPENING_STOCK, " +
                  "TO_CHAR (NVL (CLOSING_BLANCE,''))CLOSING_BLANCE, " +
                  "TO_CHAR (NVL (EQUIPEMENT_NAME,''))EQUIPEMENT_NAME, " +
                  "TO_CHAR (NVL (SPARE_PART_NAME,''))SPARE_PART_NAME " +


                  " FROM vew_search_monthly_store where head_office_id = '" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "' AND TRAN_YEAR= '" + strYear + "' and TRAN_MONTH = '"+strMonth+"'   ";

            if (strSparePartId.Length > 0)
            {

                sql = sql + " and spare_part_id ='" + strSparePartId + "' ";
            }

            if (strEquipementId.Length > 0)
            {

                sql = sql + " and EQUIPMENT_ID ='" + strEquipementId + "' ";
            }

            if (strPartNo.Length > 0)
            {

                sql = sql + " and PART_NO ='" + strPartNo + "' ";
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
        public MonthlyStoreDTO searchEquipementAndSparePartId(string strTranId,  string strHeadOfficeId, string strBranchOfficeId)
        {

            MonthlyStoreDTO objMonthlyStoreDTO = new MonthlyStoreDTO();
            MonthlyStoreDAL objMonthlyStoreDAL = new MonthlyStoreDAL();


            string sql = "";
            sql = "SELECT " +
                  "TO_CHAR (NVL (EQUIPMENT_ID, '0'))EQUIPMENT_ID, " +
                  "TO_CHAR (NVL (SPARE_PART_ID, '0'))SPARE_PART_ID " +

                 "FROM vew_search_monthly_store WHERE  tran_id ='" + strTranId + "'  AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "' ";

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

                        objMonthlyStoreDTO.EquipementId = objDataReader.GetString(0);
                        objMonthlyStoreDTO.SparePartId = objDataReader.GetString(1);                      

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
            return objMonthlyStoreDTO;

        }
        public MonthlyStoreDTO chkBeginingStock(string strTranId, string strPartNo, string strPartNoSearch, string strYear, string strMonth, string strHeadOfficeId, string strBranchOfficeId)
        {

            MonthlyStoreDTO objMonthlyStoreDTO = new MonthlyStoreDTO();
            MonthlyStoreDAL objMonthlyStoreDAL = new MonthlyStoreDAL();


            string sql = "";
            sql = "SELECT " +

                   "TO_CHAR (NVL (BEGINING_STOCK, '0'))BEGINING_STOCK, " +
                   "TO_CHAR (NVL (START_TRAN_MONTH, '0'))START_TRAN_MONTH, " +
                   "TO_CHAR (NVL (START_TRAN_YEAR, '0'))START_TRAN_YEAR " +

                  "FROM vew_search_monthly_store WHERE   TRAN_YEAR = '" + strYear + "' AND TRAN_MONTH='" + strMonth + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "' ";

            if (strTranId.Length > 0)
            {

                sql = sql + " and tran_id ='" + strTranId + "' ";
            }

            if (strPartNo.Length > 0)
            {

                sql = sql + " and PART_NO ='" + strPartNo + "' ";
            }


            if (strPartNoSearch.Length > 0)
            {

                sql = sql + " and PART_NO ='" + strPartNoSearch + "' ";
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
                        
                        objMonthlyStoreDTO.BeginingStock = objDataReader.GetString(0);
                        objMonthlyStoreDTO.StartTranMonth = objDataReader.GetString(1);
                        objMonthlyStoreDTO.StartTranYear = objDataReader.GetString(2);


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
            return objMonthlyStoreDTO;

        }

        public MonthlyStoreDTO searchMonthlyStoreRecord(string strTranId, string strPartNo, string strPartNoSearch, string strYear, string strMonth, string strHeadOfficeId, string strBranchOfficeId)
        {

            MonthlyStoreDTO objMonthlyStoreDTO = new MonthlyStoreDTO();
            MonthlyStoreDAL objMonthlyStoreDAL = new MonthlyStoreDAL();


            string sql = "";
            sql = "SELECT " +

                   "TO_CHAR (NVL (TRAN_ID, '0'))TRAN_ID, " +
                   "TO_CHAR (NVL (PART_NO, '0'))PART_NO, " +
                   "TO_CHAR (NVL (BEGINING_STOCK, '0'))BEGINING_STOCK, " +
                   "TO_CHAR (NVL (OPENING_STOCK, '0'))OPENING_STOCK, " +
                   "TO_CHAR (NVL (CLOSING_BLANCE, '0'))CLOSING_BLANCE, " +
                   "TO_CHAR (NVL (EQUIPMENT_ID, '0'))EQUIPMENT_ID, " +
                   "TO_CHAR (NVL (SPARE_PART_ID, '0'))PART_SPARE_PART_ID " +



                  "FROM vew_search_monthly_store WHERE   TRAN_YEAR = '"+strYear+"' AND TRAN_MONTH='"+ strMonth + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "' ";

            if (strTranId.Length > 0)
            {

                sql = sql + " and tran_id ='" + strTranId + "' ";
            }

            if (strPartNo.Length > 0)
            {

                sql = sql + " and PART_NO ='" + strPartNo + "' ";
            }


            if (strPartNoSearch.Length > 0)
            {

                sql = sql + " and PART_NO ='" + strPartNoSearch + "' ";
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
                        objMonthlyStoreDTO.TranId = objDataReader.GetString(0);
                        objMonthlyStoreDTO.PartNo = objDataReader.GetString(1);
                        objMonthlyStoreDTO.BeginingStock = objDataReader.GetString(2);
                        objMonthlyStoreDTO.OpeningStock = objDataReader.GetString(3);                      
                        objMonthlyStoreDTO.ClosingBlance = objDataReader.GetString(4);
                        objMonthlyStoreDTO.EquipementId = objDataReader.GetString(5);
                        objMonthlyStoreDTO.SparePartId = objDataReader.GetString(6);

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
            return objMonthlyStoreDTO;

        }
        public MonthlyStoreDTO chkStockYn(string strTranId, string strPartNo, string strPartNoSearch,  string strYear,string strMonth, string strHeadOfficeId, string strBranchOfficeId)
        {

            MonthlyStoreDTO objMonthlyStoreDTO = new MonthlyStoreDTO();
            MonthlyStoreDAL objMonthlyStoreDAL = new MonthlyStoreDAL();


            string sql = "";
            sql = "SELECT " +
                  "'Y' " +


                  "FROM vew_search_monthly_store WHERE   TRAN_YEAR = '"+ strYear + "' AND TRAN_MONTH ='"+ strMonth + "'   AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "' AND (BEGINING_STOCK <> 0 OR OPENING_STOCK <> 0OR CLOSING_BLANCE <> 0)  ";

            if (strTranId.Length > 0)
            {

                sql = sql + " and tran_id ='" + strTranId + "' ";
            }

            if (strPartNo.Length > 0)
            {

                sql = sql + " and PART_NO ='" + strPartNo + "' ";
            }

            if (strPartNoSearch.Length > 0)
            {

                sql = sql + " and PART_NO ='" + strPartNoSearch + "' ";
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

                        objMonthlyStoreDTO.StockYn = objDataReader.GetString(0);
                        

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
            return objMonthlyStoreDTO;

        }

        public MonthlyStoreDTO searchBeginingStoreRecord(string strTranId, string strPartNo, string strPartNoSearch, string strYear, string strMonth, string strHeadOfficeId, string strBranchOfficeId)
        {

            MonthlyStoreDTO objMonthlyStoreDTO = new MonthlyStoreDTO();
            MonthlyStoreDAL objMonthlyStoreDAL = new MonthlyStoreDAL();


            string sql = "";
            sql = "SELECT " +
                  "TO_CHAR (NVL (BEGINING_STOCK, '0'))BEGINING_STOCK, " +
                   "TO_CHAR (NVL (OPENING_STOCK, '0'))OPENING_STOCK, " +
                   "TO_CHAR (NVL (CLOSING_BLANCE, '0'))CLOSING_BLANCE, " +
                   "TO_CHAR (NVL (PART_NO, '0'))PART_NO " +



                  "FROM MONTHLY_STORE_TEMP WHERE   TRAN_YEAR ='"+strYear+"' AND TRAN_MONTH = '"+ strMonth + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "' ";

            if (strTranId.Length > 0)
            {

                sql = sql + " and tran_id ='" + strTranId + "' ";
            }

            if (strPartNo.Length > 0)
            {

                sql = sql + " and PART_NO ='" + strPartNo + "' ";
            }

            if (strPartNoSearch.Length > 0)
            {

                sql = sql + " and PART_NO ='" + strPartNoSearch + "' ";
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

                        objMonthlyStoreDTO.BeginingStock = objDataReader.GetString(0);
                        objMonthlyStoreDTO.OpeningStock = objDataReader.GetString(1);
                        objMonthlyStoreDTO.ClosingBlance = objDataReader.GetString(2);
                        objMonthlyStoreDTO.PartNo = objDataReader.GetString(3);
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
            return objMonthlyStoreDTO;

        }

    }
}

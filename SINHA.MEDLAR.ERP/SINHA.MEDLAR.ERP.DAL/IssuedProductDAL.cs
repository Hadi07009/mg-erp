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
    public class IssuedProductDAL
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

        public string saveIssuedProductInfo(IssuedProductDTO objIssuedProductDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_issued_product_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure; 

            if (objIssuedProductDTO.TranId != "")
            {
                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIssuedProductDTO.TranId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objIssuedProductDTO.PartNo != "")
            {
                objOracleCommand.Parameters.Add("P_PART_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIssuedProductDTO.PartNo;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_PART_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objIssuedProductDTO.OpeningBlance != "")
            {
                objOracleCommand.Parameters.Add("P_OPENING_BLANCE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIssuedProductDTO.OpeningBlance;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_OPENING_BLANCE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            
            if (objIssuedProductDTO.IssuedQty != "")
            {
                objOracleCommand.Parameters.Add("P_ISSUED_QTY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIssuedProductDTO.IssuedQty;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_ISSUED_QTY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objIssuedProductDTO.IssuedDate.Length > 6)
            {
                objOracleCommand.Parameters.Add("P_ISSUED_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIssuedProductDTO.IssuedDate;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_ISSUED_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objIssuedProductDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("P_SECTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIssuedProductDTO.SectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SECTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objIssuedProductDTO.IssuedInFavor != "")
            {
                objOracleCommand.Parameters.Add("P_ISSUED_IN_FAVOR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIssuedProductDTO.IssuedInFavor;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_ISSUED_IN_FAVOR", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objIssuedProductDTO.Remarks != "")
            {
                objOracleCommand.Parameters.Add("P_REMARKS", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIssuedProductDTO.Remarks;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_REMARKS", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            


            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIssuedProductDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIssuedProductDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIssuedProductDTO.BranchOfficeId;


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

        public DataTable loadIssuedProductInfo(IssuedProductDTO objIssuedProductDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +

                 "TO_CHAR (NVL (TRAN_ID, ''))TRAN_ID, " +
                 "TO_CHAR (NVL (PART_NO, ''))PART_NO, " +
                 "TO_CHAR (NVL  (OPENING_BLANCE, ''))OPENING_BLANCE, " +
                 "TO_CHAR (NVL (ISSUED_QTY, ''))ISSUED_QTY, " +
                 "TO_CHAR (ISSUED_DATE, 'dd/mm/yyyy')ISSUED_DATE, " +
                 "TO_CHAR (NVL (SECTION_NAME , ''))SECTION_NAME, " +
                 "TO_CHAR (NVL (ISSUED_IN_FAVOR , ''))ISSUED_IN_FAVOR, " +
                 "TO_CHAR (NVL (REMARKS , ''))REMARKS " +


                " FROM VEW_ISSUED_PRODUCT WHERE   head_office_id = '" + objIssuedProductDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objIssuedProductDTO.BranchOfficeId + "'   ";


            if(objIssuedProductDTO.PartNo.Length > 0)
            {

                sql = sql + " and PART_NO = '"+ objIssuedProductDTO.PartNo + "' ";

            }

            sql = sql + " ORDER BY TRAN_ID ";        


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
        public IssuedProductDTO searchIssuedProductInfo(IssuedProductDTO objIssuedProductDTO)
        {

            string sql = "";
            sql = "SELECT " +
                  "'Y' " +


                  "FROM vew_search_monthly_store WHERE  PART_NO ='" + objIssuedProductDTO.PartNo + "' and  TRAN_YEAR = '" + objIssuedProductDTO.TranYear + "' AND TRAN_MONTH ='" + objIssuedProductDTO.TranMonth + "'   AND HEAD_OFFICE_ID = '" + objIssuedProductDTO.HeadOfficeId + "' AND BRANCH_OFFICE_ID = '" + objIssuedProductDTO.BranchOfficeId + "' AND CLOSING_BLANCE <> 0  ";

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

                        objIssuedProductDTO.StockYn = objDataReader.GetString(0);


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

            if (objIssuedProductDTO.StockYn == "Y")
            {

                sql = "SELECT " +

                      "TO_CHAR(NVL(CLOSING_BLANCE,'0'))CLOSING_BLANCE " +


                      "FROM MONTHLY_STORE WHERE TRAN_YEAR = '" + objIssuedProductDTO.TranYear + "' and TRAN_MONTH ='" + objIssuedProductDTO.TranMonth + "' and HEAD_OFFICE_ID = '" + objIssuedProductDTO.HeadOfficeId + "' AND BRANCH_OFFICE_ID ='" + objIssuedProductDTO.BranchOfficeId + "' AND PART_NO = '" + objIssuedProductDTO.PartNo + "' ";

            }
            else
            {
                sql = "SELECT " +

                     "TO_CHAR(NVL(CLOSING_BLANCE,'0'))CLOSING_BLANCE " +


                     "FROM VEW_SEARCH_MONTHLY_STORE WHERE HEAD_OFFICE_ID = '" + objIssuedProductDTO.HeadOfficeId + "' AND BRANCH_OFFICE_ID ='" + objIssuedProductDTO.BranchOfficeId + "' AND PART_NO = '" + objIssuedProductDTO.PartNo + "' and TRAN_MONTH <= LAST_TRAN_MONTH and TRAN_YEAR <= LAST_TRAN_YEAR ";

            }



            OracleCommand objCommand1 = new OracleCommand(sql);
            OracleDataReader objDataReader1;

            using (OracleConnection strConn1 = GetConnection()){

                objCommand1.Connection = strConn1;
                strConn1.Open();
                objDataReader1 = objCommand1.ExecuteReader();
                try
                {
                    while (objDataReader1.Read())
                    {

                        objIssuedProductDTO.OpeningBlance = objDataReader1.GetString(0);

                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error : " + ex.Message);

                }

                finally
                {

                    strConn1.Close();
                }

            }


            return objIssuedProductDTO;

        }
        public IssuedProductDTO searchSectionId(string strTranId, string strHeadOfficeId, string strBranchOfficeId)
        {
            IssuedProductDTO objIssuedProductDTO = new IssuedProductDTO();
            string sql = "";
            sql = "SELECT " +

                  "TO_CHAR(NVL(SECTION_ID,''))SECTION_ID " +


                  "FROM ISSUED_PRODUCT WHERE HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID ='" + strBranchOfficeId + "' AND TRAN_ID = '" + strTranId + "' ";


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

                        objIssuedProductDTO.SectionId = objDataReader.GetString(0);

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


            return objIssuedProductDTO;

        }

        //public IssuedProductDTO CheckSavedData(string strPartNo, string strHeadOfficeId, string strBranchOfficeId)
        //{

        //    IssuedProductDTO objIssuedProductDTO = new IssuedProductDTO();

        //    string sql = "";
        //    sql = "SELECT " +

        //          "TO_CHAR(NVL(MRR_NO,''))MRR_NO, " +
        //          "TO_CHAR(NVL(RECEIVED_QTY,'0'))RECEIVED_QTY, " +
        //          "TO_CHAR(RECEIVED_DATE,'dd/mm/yyyy')RECEIVED_DATE " +


        //          "FROM VEW_PRODUCT_RECEIVED_SUB WHERE HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID ='" + strBranchOfficeId + "' AND PART_NO = '"+ strPartNo + "' ";




        //    OracleCommand objCommand = new OracleCommand(sql);
        //    OracleDataReader objDataReader;

        //    using (OracleConnection strConn = GetConnection())
        //    {

        //        objCommand.Connection = strConn;
        //        strConn.Open();
        //        objDataReader = objCommand.ExecuteReader();
        //        try
        //        {
        //            while (objDataReader.Read())
        //            {

        //                objIssuedProductDTO.MRRNo = objDataReader.GetString(0);
        //                objIssuedProductDTO.ReceivedQty = objDataReader.GetString(1);
        //                objIssuedProductDTO.ReceivedDate = objDataReader.GetString(2);

        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception("Error : " + ex.Message);

        //        }

        //        finally
        //        {

        //            strConn.Close();
        //        }

        //    }


        //    return objIssuedProductDTO;

        //}

        public string deleteIssuedProductRecord(IssuedProductDTO objIssuedProductDTO)
        {

            IssuedProductDAL objIssuedProductDAL = new IssuedProductDAL();

            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("PRO_DELETE_ISSUED_PRODUCT");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objIssuedProductDTO.TranId != "")
            {

                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIssuedProductDTO.TranId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objIssuedProductDTO.PartNo != "")
            {

                objOracleCommand.Parameters.Add("P_PART_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIssuedProductDTO.PartNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PART_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIssuedProductDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIssuedProductDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objIssuedProductDTO.BranchOfficeId;


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

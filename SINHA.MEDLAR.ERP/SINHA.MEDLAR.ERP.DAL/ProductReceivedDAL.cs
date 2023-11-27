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
    public class ProductReceivedDAL
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

        public string saveProductReceivedInfo(ProductReceivedDTO objProductReceivedDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_Product_Received_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objProductReceivedDTO.TranId != "")
            {
                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProductReceivedDTO.TranId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objProductReceivedDTO.MRRNo != "")
            {
                objOracleCommand.Parameters.Add("P_MRR_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProductReceivedDTO.MRRNo;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_MRR_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            
            if (objProductReceivedDTO.RequisitionNo != "")
            {
                objOracleCommand.Parameters.Add("P_REQUISITION_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProductReceivedDTO.RequisitionNo;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_REQUISITION_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objProductReceivedDTO.PartNo != "")
            {
                objOracleCommand.Parameters.Add("P_PART_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProductReceivedDTO.PartNo;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_PART_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objProductReceivedDTO.RequiredQty != "")
            {
                objOracleCommand.Parameters.Add("P_REQUIRED_QTY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProductReceivedDTO.RequiredQty;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_REQUIRED_QTY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objProductReceivedDTO.ApprovedQty != "")
            {
                objOracleCommand.Parameters.Add("P_APPROVED_QTY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProductReceivedDTO.ApprovedQty;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_APPROVED_QTY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objProductReceivedDTO.ReceivedQty != "")
            {
                objOracleCommand.Parameters.Add("P_RECEIVED_QTY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProductReceivedDTO.ReceivedQty;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_RECEIVED_QTY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objProductReceivedDTO.ReceivedDate.Length > 6)
            {
                objOracleCommand.Parameters.Add("P_RECEIVED_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProductReceivedDTO.ReceivedDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_RECEIVED_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            


            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProductReceivedDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProductReceivedDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProductReceivedDTO.BranchOfficeId;


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

        public DataTable loadProductReceivedInfo(ProductReceivedDTO objProductReceivedDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +

                 "TO_CHAR (NVL (TRAN_ID, ''))TRAN_ID, " +
                 "TO_CHAR (NVL (MRR_NO, ''))MRR_NO, " +
                 "TO_CHAR (NVL (REQUISITION_NO, ''))REQUISITION_NO, " +
                 "TO_CHAR (RECEIVED_DATE, 'dd/mm/yyyy')RECEIVED_DATE, " +
                 "TO_CHAR (NVL (PART_NO, ''))PART_NO, " +
                 "TO_CHAR (NVL (REQUIRED_QTY, ''))REQUIRED_QTY, " +
                 "TO_CHAR (NVL (APPROVED_QTY, ''))APPROVED_QTY, " +
                 "TO_CHAR (NVL (RECEIVED_QTY, ''))RECEIVED_QTY, " +
                 "TO_CHAR (NVL (RATE, ''))RATE, " +
                 "TO_CHAR (NVL (PRICE, ''))PRICE " +

                " FROM VEW_PRODUCT_RECEIVED_SUB WHERE   head_office_id = '" + objProductReceivedDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objProductReceivedDTO.BranchOfficeId + "'   ";


            if(objProductReceivedDTO.RequisitionNo.Length > 0)
            {

                sql = sql + " and REQUISITION_NO = '"+ objProductReceivedDTO.RequisitionNo + "' ";

            }


           

            sql = sql + " ORDER BY RECEIVED_DATE DESC ";

            //and REQUISITION_NO = '" + objProductReceivedDTO.RequisitionNo + "' AND PART_NO = '"+ objProductReceivedDTO.PartNo + "'  and RECEIVED_DATE = TO_DATE('" + objProductReceivedDTO.ReceivedDate + "', 'dd/mm/yyyy')


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
        public DataTable searchProductReceivedInfo(ProductReceivedDTO objProductReceivedDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +

                   "TO_CHAR (NVL (PART_NO,''))PART_NO, " +
                   "TO_CHAR (NVL (PARTICULAR_NAME,''))PARTICULAR_NAME, " +
                   "TO_CHAR (NVL (PO_UNIT_NAME,''))PO_UNIT_NAME, " +
                   "TO_CHAR (NVL (REQUIRED_QTY,''))REQUIRED_QTY, " +
                   "TO_CHAR (NVL (APPROVED_QTY,''))APPROVED_QTY, " +
                   "TO_CHAR (NVL (RATE,''))RATE, " +
                   "TO_CHAR (NVL (PRICE,''))PRICE  " +


                  "FROM VEW_PO_TRACKING WHERE head_office_id = '" + objProductReceivedDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objProductReceivedDTO.BranchOfficeId + "' AND REQUISITION_NO= '"+ objProductReceivedDTO .RequisitionNo+ "' ";


            if (objProductReceivedDTO.PartNoSrc.Length > 0)
            {

                sql = sql + "and PART_NO = '" + objProductReceivedDTO.PartNoSrc + "'";
            }    

            sql = sql + "order by PART_NO ";

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

        public ProductReceivedDTO CheckSavedData(string strPartNo, string strHeadOfficeId, string strBranchOfficeId)
        {

            ProductReceivedDTO objProductReceivedDTO = new ProductReceivedDTO();

            string sql = "";
            sql = "SELECT " +

                  "TO_CHAR(NVL(MRR_NO,''))MRR_NO, " +
                  "TO_CHAR(NVL(RECEIVED_QTY,'0'))RECEIVED_QTY, " +
                  "TO_CHAR(RECEIVED_DATE,'dd/mm/yyyy')RECEIVED_DATE, " +
                  "TO_CHAR(NVL(TRAN_ID,'0'))TRAN_ID " +

                  "FROM VEW_PRODUCT_RECEIVED_SUB WHERE HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID ='" + strBranchOfficeId + "' AND PART_NO = '"+ strPartNo + "' ";




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

                        objProductReceivedDTO.MRRNo = objDataReader.GetString(0);
                        objProductReceivedDTO.ReceivedQty = objDataReader.GetString(1);
                        objProductReceivedDTO.ReceivedDate = objDataReader.GetString(2);
                        objProductReceivedDTO.TranId = objDataReader.GetString(3);
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


            return objProductReceivedDTO;

        }

        public string deleteProductReceivedRecord(ProductReceivedDTO objProductReceivedDTO)
        {

            ProductReceivedDAL objProductReceivedDAL = new ProductReceivedDAL();

            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("PRO_DEL_PRODUCT_RECEIVED_SUB");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            if (objProductReceivedDTO.MRRNo != "")
            {

                objOracleCommand.Parameters.Add("P_MRR_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProductReceivedDTO.MRRNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_MRR_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objProductReceivedDTO.TranId != "")
            {

                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProductReceivedDTO.TranId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objProductReceivedDTO.RequisitionNo != "")
            {

                objOracleCommand.Parameters.Add("P_REQUISITION_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProductReceivedDTO.RequisitionNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_REQUISITION_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objProductReceivedDTO.ReceivedDate != "")
            {

                objOracleCommand.Parameters.Add("P_RECEIVED_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProductReceivedDTO.ReceivedDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_RECEIVED_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objProductReceivedDTO.PartNo != "")
            {

                objOracleCommand.Parameters.Add("P_PART_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProductReceivedDTO.PartNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PART_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }



            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProductReceivedDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProductReceivedDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProductReceivedDTO.BranchOfficeId;


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

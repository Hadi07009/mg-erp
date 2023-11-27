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
    public class PurchaseDAL
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

        public string savePurchaseInfo(PurchaseDTO objPurchaseDTO)
        {

            

            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("pro_purchase_info_save");

            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objPurchaseDTO.TranId != "")
            {
                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchaseDTO.TranId;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            objOracleCommand.Parameters.Add("P_INVOICE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchaseDTO.InvoiceNo;
            if (objPurchaseDTO.LedgerNo != "")
            {
                objOracleCommand.Parameters.Add("P_LEDGER_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchaseDTO.LedgerNo;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_LEDGER_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objPurchaseDTO.EmployeeId != "")
            {
                objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchaseDTO.EmployeeId;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objPurchaseDTO.SLNo != "")
            {
                objOracleCommand.Parameters.Add("P_SL_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchaseDTO.SLNo;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_SL_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objPurchaseDTO.RequisitionNo != "")
            {
                objOracleCommand.Parameters.Add("P_REQUISITION_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchaseDTO.RequisitionNo;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_REQUISITION_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objPurchaseDTO.RequisitionDate != "")
            {
                objOracleCommand.Parameters.Add("P_REQUISITION_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchaseDTO.RequisitionDate;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_REQUISITION_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objPurchaseDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchaseDTO.UnitId;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objPurchaseDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("P_SECTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchaseDTO.SectionId;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_SECTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objPurchaseDTO.MRRNo != "")
            {
                objOracleCommand.Parameters.Add("P_MRR_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchaseDTO.MRRNo;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_MRR_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objPurchaseDTO.MRRDate != "")
            {
                objOracleCommand.Parameters.Add("P_MRR_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchaseDTO.MRRDate;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_MRR_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objPurchaseDTO.PurchaseDate != "")
            {
                objOracleCommand.Parameters.Add("P_PURCHASE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchaseDTO.PurchaseDate;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_PURCHASE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objPurchaseDTO.Quantity != "")
            {
                objOracleCommand.Parameters.Add("P_PURCHASE_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchaseDTO.Quantity;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_PURCHASE_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objPurchaseDTO.Price != "")
            {
                objOracleCommand.Parameters.Add("P_PRICE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchaseDTO.Price;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_PRICE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objPurchaseDTO.WarrantyPeriod != "")
            {
                objOracleCommand.Parameters.Add("P_WARRANTY_PERIOD", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchaseDTO.WarrantyPeriod;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_WARRANTY_PERIOD", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objPurchaseDTO.ProductionDescription != "")
            {
                objOracleCommand.Parameters.Add("P_PRODUCT_DESCRIPTION", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchaseDTO.ProductionDescription;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_PRODUCT_DESCRIPTION", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objPurchaseDTO.SupplierName != "")
            {
                objOracleCommand.Parameters.Add("P_SUPPLIER_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchaseDTO.SupplierName;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_SUPPLIER_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }



            if (objPurchaseDTO.Remarks != "")
            {
                objOracleCommand.Parameters.Add("P_REMARKS", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchaseDTO.Remarks;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_REMARKS", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objPurchaseDTO.ProductId != "")
            {
                objOracleCommand.Parameters.Add("P_PRODUCT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchaseDTO.ProductId;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_PRODUCT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objPurchaseDTO.EmployeeName != "")
            {
                objOracleCommand.Parameters.Add("P_EMPLOYEE_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchaseDTO.EmployeeName;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_EMPLOYEE_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }






            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchaseDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchaseDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchaseDTO.BranchOfficeId;


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
        public string PurchaseFileSave(PurchaseDTO objPurchaseDTO)
        {



            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("PRO_PURCHASE_FILE_UPLOAD");

            objOracleCommand.CommandType = CommandType.StoredProcedure;


           
            objOracleCommand.Parameters.Add("P_INVOICE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchaseDTO.InvoiceNo;
            if (objPurchaseDTO.RequisitionNo != "")
            {
                objOracleCommand.Parameters.Add("P_REQUISITION_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchaseDTO.RequisitionNo;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_REQUISITION_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }



            if (objPurchaseDTO.EmployeeId != "")
            {
                objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchaseDTO.EmployeeId;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

           

           
            if (objPurchaseDTO.FileName != "")
            {
                objOracleCommand.Parameters.Add("P_FILE_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchaseDTO.FileName;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_FILE_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objPurchaseDTO.FileSize != "")
            {
                byte[] array = System.Convert.FromBase64String(objPurchaseDTO.FileSize);
                objOracleCommand.Parameters.Add("P_FILE_SIZE", OracleDbType.Blob, ParameterDirection.Input).Value = array;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_FILE_SIZE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }



            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchaseDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchaseDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchaseDTO.BranchOfficeId;


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
        public PurchaseDTO searchInvoiceInfo(string strInvoiceNo, string strTranId)
        {

            DataTable dt = new DataTable();
            PurchaseDTO objPurchaseDTO = new PurchaseDTO();


            string sql = "";
            sql = "SELECT " +

                    "TO_CHAR (NVL (PRODUCT_SL_NO, '0')), " +
                    "TO_CHAR (NVL (REQUISITION_NO, '0')), " +
                    "NVL (TO_CHAR (REQUISITION_DATE, 'dd/mm/yyyy'), ' '), " +
                    "TO_CHAR (NVL (MRR_NO, '0')), " +
                    "NVL (TO_CHAR (MRR_DATE, 'dd/mm/yyyy'), ' '), " +
                    "NVL (TO_CHAR (PURCHASE_DATE, 'dd/mm/yyyy'), ' '), " +
                    "TO_CHAR (NVL (PRICE, '0')), " +
                    "TO_CHAR (NVL (WARRANTY_PERIOD, '0')), " +
                    "TO_CHAR (NVL (PRODUCT_DESCRIPTION, 'N/A')), " +
                    "TO_CHAR (NVL (SUPPLIER_NAME, 'N/A')), " +
                    "TO_CHAR (NVL (REMARKS, 'N/A')), " +
                    "TO_CHAR (NVL (PURCHASE_QUANTITY, '0')), " +
                    "TO_CHAR (NVL (EMPLOYEE_ID, '0')), " +
                    "TO_CHAR (NVL (EMPLOYEE_NAME, 'N/A')), " +
                    "TO_CHAR (NVL (CARD_NO, '0')), " +
                    "TO_CHAR (NVL (DESIGNATION_NAME, 'N/A')), " +

                    "TO_CHAR (NVL (LEDGER_NO, '0')), " +
                    "TO_CHAR (NVL (PRODUCT_ID, '0')), " +
                    "TO_CHAR (NVL (EMP_NAME, '0')) " +

                    "from VEW_SEARCH_PURCHASE_INFO where INVOICE_NO = '" + strInvoiceNo + "' AND TRAN_ID = '" + strTranId + "'  ";




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


                        objPurchaseDTO.SLNo = objDataReader.GetString(0);
                        objPurchaseDTO.RequisitionNo = objDataReader.GetString(1);
                        objPurchaseDTO.RequisitionDate = objDataReader.GetString(2);
                        objPurchaseDTO.MRRNo = objDataReader.GetString(3);
                        objPurchaseDTO.MRRDate = objDataReader.GetString(4);
                        objPurchaseDTO.PurchaseDate = objDataReader.GetString(5);
                        objPurchaseDTO.Price = objDataReader.GetString(6);
                        objPurchaseDTO.WarrantyPeriod = objDataReader.GetString(7);
                        objPurchaseDTO.ProductionDescription = objDataReader.GetString(8);
                        objPurchaseDTO.SupplierName = objDataReader.GetString(9);
                        objPurchaseDTO.Remarks = objDataReader.GetString(10);
                        objPurchaseDTO.Quantity = objDataReader.GetString(11);

                        objPurchaseDTO.EmployeeId = objDataReader.GetString(12);
                        objPurchaseDTO.EmployeeName = objDataReader.GetString(13);
                        objPurchaseDTO.CardNo = objDataReader.GetString(14);
                        objPurchaseDTO.DesignationName = objDataReader.GetString(15);

                        objPurchaseDTO.LedgerNo = objDataReader.GetString(16);
                        objPurchaseDTO.ProductId = objDataReader.GetString(17);
                        objPurchaseDTO.EmpName = objDataReader.GetString(18);

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


            return objPurchaseDTO;

        }
        public PurchaseDTO chkPDFFileExist(string strInvoiceNo, string strRequisitionNo)
        {

            DataTable dt = new DataTable();
            PurchaseDTO objPurchaseDTO = new PurchaseDTO();


            string sql = "";
            sql = "SELECT " +

                    " 'Y' "+


                    "from PURCHASE_FILE_UPLOAD where REQUISITION_NO = '" + strRequisitionNo + "'  ";




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

                        objPurchaseDTO.FileExistsYn = objDataReader.GetString(0);

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


            return objPurchaseDTO;

        }

    }
}

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
    public class ContractDAL
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
        public string saveContractInfo(ContractDTO objContractDTO)
        {

            ContractDAL objContractDAL = new ContractDAL();

            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("pro_contact_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objContractDTO.TranId != "")
            {

                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.TranId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objContractDTO.ContactNo != "")
            {

                objOracleCommand.Parameters.Add("P_CONTRACT_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.ContactNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_CONTRACT_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objContractDTO.IssueDate.Length > 6)
            {

                objOracleCommand.Parameters.Add("P_ISSUE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.IssueDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_ISSUE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }



            if (objContractDTO.VendorId != "")
            {

                objOracleCommand.Parameters.Add("P_VENDOR_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.VendorId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_VENDOR_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objContractDTO.VendorBankId != "")
            {

                objOracleCommand.Parameters.Add("P_VENDOR_BANK_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.VendorBankId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_VENDOR_BANK_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objContractDTO.ManufactureId != "")
            {

                objOracleCommand.Parameters.Add("P_MANUFACTURE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.ManufactureId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_MANUFACTURE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objContractDTO.ManufactureBankId != "")
            {

                objOracleCommand.Parameters.Add("P_MANUFACTURE_BANK_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.ManufactureBankId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_MANUFACTURE_BANK_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objContractDTO.ShipId != "")
            {

                objOracleCommand.Parameters.Add("P_SHIP_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.ShipId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SHIP_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objContractDTO.ShipTypeId != "")
            {

                objOracleCommand.Parameters.Add("P_SHIPMENT_TYPE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.ShipTypeId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SHIPMENT_TYPE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objContractDTO.PaymentTermId != "")
            {

                objOracleCommand.Parameters.Add("P_PAYMENT_TERM_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.PaymentTermId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PAYMENT_TERM_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objContractDTO.UltimateConsigneeId != "")
            {

                objOracleCommand.Parameters.Add("P_ULTIMATE_CONSIGNEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.UltimateConsigneeId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_ULTIMATE_CONSIGNEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objContractDTO.ShippingDate.Length > 6)
            {

                objOracleCommand.Parameters.Add("P_SHIPPING_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.ShippingDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SHIPPING_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

          

            if (objContractDTO.PONo != "")
            {

                objOracleCommand.Parameters.Add("P_PO_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.PONo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PO_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objContractDTO.StyleNo != "")
            {

                objOracleCommand.Parameters.Add("P_STYLE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.StyleNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_STYLE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objContractDTO.ItemName != "")
            {

                objOracleCommand.Parameters.Add("P_ITEM_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.ItemName;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_ITEM_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objContractDTO.SizeId != "")
            {

                objOracleCommand.Parameters.Add("P_SIZE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.SizeId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SIZE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objContractDTO.OrderQty != "")
            {

                objOracleCommand.Parameters.Add("P_ORDER_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.OrderQty;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_ORDER_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objContractDTO.POPrice != "")
            {

                objOracleCommand.Parameters.Add("P_PO_PRICE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.POPrice;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PO_PRICE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objContractDTO.HangerCostPerUnit != "")
            {

                objOracleCommand.Parameters.Add("P_HANGER_COST_PER_UNIT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.HangerCostPerUnit;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_HANGER_COST_PER_UNIT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objContractDTO.UnitCost != "")
            {

                objOracleCommand.Parameters.Add("P_UNIT_COST", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.UnitCost;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_UNIT_COST", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objContractDTO.TotalAmountInUSD != "")
            {

                objOracleCommand.Parameters.Add("P_TOTAL_AMOUNT_IN_USD", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.TotalAmountInUSD;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_TOTAL_AMOUNT_IN_USD", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objContractDTO.ShippingAddress != "")
            {

                objOracleCommand.Parameters.Add("P_SHIPPING_ADDRESS", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.ShippingAddress;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SHIPPING_ADDRESS", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objContractDTO.AmendMentDate != "")
            {

                objOracleCommand.Parameters.Add("P_AMENDMENT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.AmendMentDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_AMENDMENT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objContractDTO.BuyerId != "")
            {

                objOracleCommand.Parameters.Add("P_BUYER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.BuyerId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_BUYER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objContractDTO.HSCode != "")
            {

                objOracleCommand.Parameters.Add("P_HS_CODE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.HSCode;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_HS_CODE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objContractDTO.Rate != "")
            {

                objOracleCommand.Parameters.Add("P_RATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.Rate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_RATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objContractDTO.SeasonId != "")
            {

                objOracleCommand.Parameters.Add("P_SEASON_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.SeasonId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SEASON_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }




            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.BranchOfficeId;


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
        public string saveContractInfoPre(ContractDTO objContractDTO)
        {

            ContractDAL objContractDAL = new ContractDAL();

            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("pro_contract_sheet_process");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


          

            if (objContractDTO.ContactNo != "")
            {

                objOracleCommand.Parameters.Add("P_CONTRACT_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.ContactNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_CONTRACT_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objContractDTO.IssueDate.Length > 6)
            {

                objOracleCommand.Parameters.Add("P_ISSUE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.IssueDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_ISSUE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }



          

            if (objContractDTO.AmendMentDate != "")
            {

                objOracleCommand.Parameters.Add("P_AMENDMENT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.AmendMentDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_AMENDMENT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objContractDTO.BuyerId != "")
            {

                objOracleCommand.Parameters.Add("P_BUYER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.BuyerId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_BUYER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }





            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.BranchOfficeId;


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
        public string saveContractInfoNull(ContractDTO objContractDTO)
        {

            ContractDAL objContractDAL = new ContractDAL();

            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("pro_contract_process_null");
            objOracleCommand.CommandType = CommandType.StoredProcedure;




            if (objContractDTO.ContactNo != "")
            {

                objOracleCommand.Parameters.Add("P_CONTRACT_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.ContactNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_CONTRACT_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objContractDTO.IssueDate.Length > 6)
            {

                objOracleCommand.Parameters.Add("P_ISSUE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.IssueDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_ISSUE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }





            if (objContractDTO.AmendMentDate != "")
            {

                objOracleCommand.Parameters.Add("P_AMENDMENT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.AmendMentDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_AMENDMENT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objContractDTO.BuyerId != "")
            {

                objOracleCommand.Parameters.Add("P_BUYER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.BuyerId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_BUYER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }





            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.BranchOfficeId;


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
        public string saveContractInfoTemp(ContractDTO objContractDTO)
        {

            ContractDAL objContractDAL = new ContractDAL();

            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("pro_contact_temp_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


           

            if (objContractDTO.ContactNo != "")
            {

                objOracleCommand.Parameters.Add("P_CONTRACT_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.ContactNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_CONTRACT_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objContractDTO.IssueDate.Length > 6)
            {

                objOracleCommand.Parameters.Add("P_CONTRACT_ISSUE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.IssueDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_CONTRACT_ISSUE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objContractDTO.PONo != "")
            {

                objOracleCommand.Parameters.Add("P_PO_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.PONo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PO_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objContractDTO.StyleNo != "")
            {

                objOracleCommand.Parameters.Add("P_STYLE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.StyleNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_STYLE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


           

            if (objContractDTO.AmendMentDate != "")
            {

                objOracleCommand.Parameters.Add("P_AMENDMENT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.AmendMentDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_AMENDMENT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }



            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.BranchOfficeId;


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
        public string deleteContractInfo(ContractDTO objContractDTO)
        {

            ContractDAL objContractDAL = new ContractDAL();

            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("PRO_DELETE_CONTACT");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objContractDTO.ContactNo != "")
            {

                objOracleCommand.Parameters.Add("P_CONTRACT_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.ContactNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_CONTRACT_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objContractDTO.IssueDate.Length > 6)
            {

                objOracleCommand.Parameters.Add("P_CONTRACT_ISSUE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.IssueDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_CONTRACT_ISSUE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objContractDTO.AmendMentDate.Length > 6)
            {

                objOracleCommand.Parameters.Add("P_AMENDMENT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.AmendMentDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_AMENDMENT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objContractDTO.PONo != "")
            {

                objOracleCommand.Parameters.Add("P_PO_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.PONo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PO_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objContractDTO.StyleNo != "")
            {

                objOracleCommand.Parameters.Add("P_STYLE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.StyleNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_STYLE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.BranchOfficeId;


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
        public string deleteContractInfoRecord(ContractDTO objContractDTO)
        {

            ContractDAL objContractDAL = new ContractDAL();

            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("PRO_DELETE_CONTACT_RECORD");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objContractDTO.TranId != "")
            {

                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.TranId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objContractDTO.ContactNo != "")
            {

                objOracleCommand.Parameters.Add("P_CONTRACT_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.ContactNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_CONTRACT_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objContractDTO.IssueDate.Length > 6)
            {

                objOracleCommand.Parameters.Add("P_ISSUE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.IssueDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_ISSUE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objContractDTO.AmendMentDate.Length > 6)
            {

                objOracleCommand.Parameters.Add("P_AMENDMENT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.AmendMentDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_AMENDMENT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.BranchOfficeId;


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
        public string updateContractInfo(ContractDTO objContractDTO)
        {

            ContractDAL objContractDAL = new ContractDAL();

            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("PRO_UPDATE_CONTACT_RECORD");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


           


            if (objContractDTO.ContactNo != "")
            {

                objOracleCommand.Parameters.Add("P_CONTRACT_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.ContactNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_CONTRACT_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objContractDTO.IssueDate.Length > 6)
            {

                objOracleCommand.Parameters.Add("P_CONTRACT_ISSUE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.IssueDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_CONTRACT_ISSUE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objContractDTO.AmendMentDate.Length > 6)
            {

                objOracleCommand.Parameters.Add("P_AMENDMENT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.AmendMentDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_AMENDMENT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.BranchOfficeId;


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
        public DataTable searchContactRecord(ContractDTO objContractDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";


            if (objContractDTO.AmendMentDate.Length > 6)
            {

                sql = "SELECT " +
       "ROWNUM SL, " +
       "TO_CHAR(ISSUE_DATE,'dd/mm/yyyy')ISSUE_DATE, " +
       "CONTRACT_NO, " +
       "to_char(NVL(TRAN_ID,'0'))TRAN_ID, " +
       "TO_CHAR(SHIPPING_DATE,'dd/mm/yyyy')SHIPPING_DATE, " +
       "TO_CHAR(CONTRACT_EXPIRE_DATE,'dd/mm/yyyy')CONTRACT_EXPIRE_DATE, " +
       "PO_NO, " +
       "STYLE_NO, " +
       "ITEM_NAME, " +
       "to_char(NVL(SIZE_ID,'0'))SIZE_ID, " +
       "SIZE_NAME, " +
       "to_char(NVL(ORDER_QUANTITY,'0'))ORDER_QUANTITY, " +
       "to_char(NVL(PO_PRICE,'0'))PO_PRICE, " +
       "to_char(NVL(HANGER_COST_PER_UNIT,'0'))HANGER_COST_PER_UNIT, " +
       "to_char(NVL(UNIT_COST,'0'))UNIT_COST, " +
       "to_char(NVL(TOTAL_AMOUNT_IN_USD,'0'))TOTAL_AMOUNT_IN_USD, " +
       "SHIPPING_ADDRESS, " +
       "TO_CHAR(AMENDMENT_DATE,'dd/mm/yyyy')AMENDMENT_DATE, " +
       "to_char(NVL(HS_CODE,'0'))HS_CODE, " +
       "to_char(NVL(RATE,'0'))RATE, " +
       "to_char(NVL(season_id,'0'))season_id " +



      "FROM vew_contact_sub WHERE   head_office_id = '" + objContractDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objContractDTO.BranchOfficeId + "'  ";




                if (objContractDTO.ContactNo.Length > 0)
                {

                    sql = sql + "and CONTRACT_NO = '" + objContractDTO.ContactNo + "' ";
                }

                if (objContractDTO.IssueDate.Length > 6)
                {

                    sql = sql + "and ISSUE_DATE = TO_DATE('" + objContractDTO.IssueDate + "','dd/mm/yyyy' )";
                }

                if (objContractDTO.AmendMentDate.Length > 6)
                {

                    sql = sql + "and AMENDMENT_DATE = TO_DATE('" + objContractDTO.AmendMentDate + "','dd/mm/yyyy' )";
                }


                if (objContractDTO.BuyerId.Length > 6)
                {

                    sql = sql + "and buyer_id = '" + objContractDTO.BuyerId + "' ";
                }



            }
            else
            {


                sql = "SELECT " +
                      "ROWNUM SL, " +
                      "TO_CHAR(ISSUE_DATE,'dd/mm/yyyy')ISSUE_DATE, " +
                      "CONTRACT_NO, " +
                     "to_char(NVL(TRAN_ID,'0'))TRAN_ID, " +
                      "TO_CHAR(SHIPPING_DATE,'dd/mm/yyyy')SHIPPING_DATE, " +
                      "TO_CHAR(CONTRACT_EXPIRE_DATE,'dd/mm/yyyy')CONTRACT_EXPIRE_DATE, " +
                      "PO_NO, " +
                      "STYLE_NO, " +
                      "ITEM_NAME, " +
                      "to_char(NVL(SIZE_ID,'0'))SIZE_ID, " +
                      "SIZE_NAME, " +
                      "to_char(NVL(ORDER_QUANTITY,'0'))ORDER_QUANTITY, " +
                      "to_char(NVL(PO_PRICE,'0'))PO_PRICE, " +
                      "to_char(NVL(HANGER_COST_PER_UNIT,'0'))HANGER_COST_PER_UNIT, " +
                      "to_char(NVL(UNIT_COST,'0'))UNIT_COST, " +
                      "to_char(NVL(TOTAL_AMOUNT_IN_USD,'0'))TOTAL_AMOUNT_IN_USD, " +
                      "SHIPPING_ADDRESS, " +
                      "TO_CHAR(AMENDMENT_DATE,'dd/mm/yyyy')AMENDMENT_DATE, " +
                      "to_char(NVL(HS_CODE,'0'))HS_CODE, " +
                      "to_char(NVL(RATE,'0'))RATE, " +
                      "to_char(NVL(season_id,'0'))season_id " +



                     "FROM vew_contact_sub WHERE head_office_id = '" + objContractDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objContractDTO.BranchOfficeId + "'  AND AMENDMENT_DATE IS NULL ";




                if (objContractDTO.ContactNo.Length > 0)
                {

                    sql = sql + "and CONTRACT_NO = '" + objContractDTO.ContactNo + "' ";
                }

                if (objContractDTO.IssueDate.Length > 6)
                {

                    sql = sql + "and ISSUE_DATE = TO_DATE('" + objContractDTO.IssueDate + "','dd/mm/yyyy' )";
                }

                if (objContractDTO.BuyerId.Length > 6)
                {

                    sql = sql + "and buyer_id = '" + objContractDTO.BuyerId + "' ";
                }



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
        public DataTable searchContactRecordSub(ContractDTO objContractDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";


           

                sql = "SELECT " +
                       "ROWNUM SL, " +
                       "TO_CHAR(ISSUE_DATE,'dd/mm/yyyy')ISSUE_DATE, " +
                       "CONTRACT_NO, " +
                       "TO_CHAR(AMENDMENT_DATE,'dd/mm/yyyy')AMENDMENT_DATE, " +
                       "BUYER_NAME, " +
                       "amendment_name "+


                      "FROM VEW_CONTRACT_SUB WHERE head_office_id = '" + objContractDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objContractDTO.BranchOfficeId + "'   ";




            if (objContractDTO.ContractId !=" ")
            {

                sql = sql + "and CONTRACT_ID = '" + objContractDTO.ContractId + "' ";
            }

            if (objContractDTO.IssueDate.Length > 6)
            {

                sql = sql + "and ISSUE_DATE = TO_DATE('" + objContractDTO.IssueDate + "','dd/mm/yyyy' )";
            }


            if (objContractDTO.AmendMentDate.Length > 6)
            {

                sql = sql + "and AMENDMENT_DATE = TO_DATE('" + objContractDTO.AmendMentDate + "','dd/mm/yyyy' )";
            }


            if (objContractDTO.IssueYear.Length > 0)
            {

                sql = sql + "and  to_char(ISSUE_DATE, 'YYYY') ='" + objContractDTO.IssueYear + "' ";
            }

           

            if (objContractDTO.BuyerId != "")
            {

                sql = sql + "and  BUYER_ID ='" + objContractDTO.BuyerId + "' ";
            }

            if (objContractDTO.AmendId != "")
            {

                sql = sql + "and  AMENDMENT_ID ='" + objContractDTO.AmendId + "' ";
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


        public ContractDTO searcContactMain(string strContactNo, string strIssueDate, string strAmmendDate, string strHeadOfficeId, string strBranchOfficeId)
        {


            ContractDTO objContractDTO = new ContractDTO();
            ContractDAL objContractDAL = new ContractDAL();

            string sql = "";
            if(strAmmendDate.Length > 6)
            {


                sql = "SELECT " +

                        "NVL (TO_CHAR (ISSUE_DATE, 'dd/mm/yyyy'), '0'), " +
                        "TO_CHAR (NVL (VENDOR_ID, '')), " +
                        "TO_CHAR (NVL (VENDOR_BANK_ID, '')), " +
                        "TO_CHAR (NVL (MANUFACTURE_ID, '0')), " +
                        "TO_CHAR (NVL (MANUFACTURE_BANK_ID, '0')), " +
                        "TO_CHAR (NVL (SHIP_ID, '0')), " +
                        "TO_CHAR (NVL (SHIPMENT_TYPE_ID, '0')), " +
                        "TO_CHAR (NVL (PAYMENT_TERM_ID, '0')), " +
                        "TO_CHAR (NVL (ULTIMATE_CONSIGNEE_ID, '0')), " +
                        "TO_CHAR (NVL (CONTRACT_NO, '0')), " +
                        "TO_CHAR (NVL (BUYER_ID, '0')) " +


                        "from vew_search_contact_main where head_office_id = '" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "' ";



                if (strContactNo.Length > 0)
                {
                    sql = sql + "and CONTRACT_NO = '" + strContactNo + "' ";
                }

                //if (strAmmendId.Length > 0)
                //{
                //    sql = sql + "and AMENDMENT_ID = '" + strAmmendId + "' ";
                //}

                if (strIssueDate.Length > 6)
                {

                    sql = sql + "and ISSUE_DATE = TO_DATE(  '" + strIssueDate + "','dd/mm/yyyy') ";
                }


                if (strAmmendDate.Length > 6)
                {

                    sql = sql + "and AMENDMENT_DATE = TO_DATE(  '" + strAmmendDate + "','dd/mm/yyyy') ";
                }


            }
            else
            {


                sql = "SELECT " +

                        "NVL (TO_CHAR (ISSUE_DATE, 'dd/mm/yyyy'), '0'), " +
                        "TO_CHAR (NVL (VENDOR_ID, '')), " +
                        "TO_CHAR (NVL (VENDOR_BANK_ID, '')), " +
                        "TO_CHAR (NVL (MANUFACTURE_ID, '0')), " +
                        "TO_CHAR (NVL (MANUFACTURE_BANK_ID, '0')), " +
                        "TO_CHAR (NVL (SHIP_ID, '0')), " +
                        "TO_CHAR (NVL (SHIPMENT_TYPE_ID, '0')), " +
                        "TO_CHAR (NVL (PAYMENT_TERM_ID, '0')), " +
                        "TO_CHAR (NVL (ULTIMATE_CONSIGNEE_ID, '0')), " +
                        "TO_CHAR (NVL (CONTRACT_NO, '0')), " +
                         "TO_CHAR (NVL (BUYER_ID, '0')) " +

                        "from vew_search_contact_main where head_office_id = '" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "' AND AMENDMENT_DATE IS NULL ";



                if (strContactNo.Length > 0)
                {
                    sql = sql + " and CONTRACT_NO = '" + strContactNo + "' ";
                }

                //if (strAmmendId.Length > 0)
                //{
                //    sql = sql + "and AMENDMENT_ID = '" + strAmmendId + "' ";
                //}

                if (strIssueDate.Length > 6)
                {

                    sql = sql + "and ISSUE_DATE = TO_DATE(  '" + strIssueDate + "','dd/mm/yyyy') ";
                }




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


                        objContractDTO.IssueDate = objDataReader.GetString(0);
                        objContractDTO.VendorId = objDataReader.GetString(1);
                        objContractDTO.VendorBankId = objDataReader.GetString(2);
                        objContractDTO.ManufactureId = objDataReader.GetString(3);
                        objContractDTO.ManufactureBankId = objDataReader.GetString(4);
                        objContractDTO.ShipId = objDataReader.GetString(5);
                        objContractDTO.ShipTypeId = objDataReader.GetString(6);
                        objContractDTO.PaymentTermId = objDataReader.GetString(7);
                        objContractDTO.UltimateConsigneeId = objDataReader.GetString(8);
                        objContractDTO.ContactNo = objDataReader.GetString(9);
                        objContractDTO.BuyerId = objDataReader.GetString(10);

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



            return objContractDTO;


        }
        public ContractDTO searchAmmendmentId(string strContactNo, string strIssueDate, string strAmmendDate, string strHeadOfficeId, string strBranchOfficeId)
        {


            ContractDTO objContractDTO = new ContractDTO();
            ContractDAL objContractDAL = new ContractDAL();

            string sql = "";

                sql = "SELECT " +

                        "TO_CHAR (NVL (AMENDMENT_ID, '0')) " +



                        " from VEW_CONTRACT_SUB where head_office_id = '" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "' and CONTRACT_NO = '" + strContactNo + "' and ISSUE_DATE = TO_DATE(  '" + strIssueDate + "','dd/mm/yyyy')  and AMENDMENT_DATE = TO_DATE(  '" + strAmmendDate + "','dd/mm/yyyy') ";



         



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


                        objContractDTO.AmendId = objDataReader.GetString(0);
  

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



            return objContractDTO;


        }
        public ContractDTO searcAmendDate(string strAmendId, string strContactNo, string strIssueDate, string strAmmendDate,  string strHeadOfficeId, string strBranchOfficeId)
        {


            ContractDTO objContractDTO = new ContractDTO();
            ContractDAL objContractDAL = new ContractDAL();

            string sql = "";
            sql = "SELECT " +

                    "NVL (TO_CHAR (AMENDMENT_DATE, 'dd/mm/yyyy'), '0') " +


                    " from vew_search_amend_date where CONTRACT_NO = '" + strContactNo + "' AND CONTRACT_ISSUE_DATE = TO_DATE('" + strIssueDate + "', 'dd/mm/yyyy')  AND head_office_id = '" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "' and AMENDMENT_ID = '" + strAmendId + "' ";

           

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


                        objContractDTO.AmendMentDate = objDataReader.GetString(0);


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



            return objContractDTO;


        }



        ///////////////////////////////

        public string saveContractBooking(ContractDTO objContractDTO)
        {

            ContractDAL objContractDAL = new ContractDAL();

            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("pro_contact_booking_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objContractDTO.TranId != "")
            {

                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.TranId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objContractDTO.ContactNo != "")
            {

                objOracleCommand.Parameters.Add("P_CONTRACT_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.ContactNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_CONTRACT_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }



            if (objContractDTO.ShippingDate.Length > 6)
            {

                objOracleCommand.Parameters.Add("P_SHIPPING_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.ShippingDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SHIPPING_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objContractDTO.ModelNo != "")
            {

                objOracleCommand.Parameters.Add("P_MODEL_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.ModelNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_MODEL_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objContractDTO.POId != "")
            {

                objOracleCommand.Parameters.Add("P_PO_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.POId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PO_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objContractDTO.StyleId != "")
            {

                objOracleCommand.Parameters.Add("P_STYLE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.StyleId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_STYLE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objContractDTO.ColorId != "")
            {

                objOracleCommand.Parameters.Add("P_COLOR_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.ColorId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_COLOR_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objContractDTO.OrderQty != "")
            {

                objOracleCommand.Parameters.Add("P_ORDER_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.OrderQty;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_ORDER_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }




            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.BranchOfficeId;


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


        public DataTable searchContactBookingRecord(ContractDTO objContractDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";



            sql = "SELECT " +


   
    "TO_CHAR(SHIPPING_DATE,'dd/mm/yyyy')SHIPPING_DATE, " +
    "MODEL_NO, " +
   "PO_NO, " +
   "PO_ID, "+
   "STYLE_ID, "+
   "STYLE_NO, " +
   "TO_CHAR (NVL (tran_id, '0'))tran_id, " +
   "color_id, " +
   "color_name, "+
   "ORDER_QUANTITY "+


  "FROM vew_booking WHERE   head_office_id = '" + objContractDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objContractDTO.BranchOfficeId + "'  ";




            if (objContractDTO.ContactNo.Length > 0)
            {

                sql = sql + "and CONTRACT_NO = '" + objContractDTO.ContactNo + "' ";
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

        public string deleteContractBooking(ContractDTO objContractDTO)
        {

            ContractDAL objContractDAL = new ContractDAL();

            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("PRO_DELETE_CONTACT_BOOKING");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objContractDTO.TranId != "")
            {

                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.TranId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objContractDTO.ContactNo != "")
            {

                objOracleCommand.Parameters.Add("P_CONTRACT_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.ContactNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_CONTRACT_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }




            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objContractDTO.BranchOfficeId;


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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;


using SINHA.MEDLAR.ERP.DTO;
using Oracle.ManagedDataAccess.Client;

using System.Configuration;
using System.Collections.Specialized;

namespace SINHA.MEDLAR.ERP.DAL
{

    public class FabricIssueDAL
    {

        #region "Oracle Connection Function"

        private OracleConnection GetConnection()
        {
            var conString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConString"];
            string strConnString = conString.ConnectionString;
            return new OracleConnection(strConnString);
        }

        #endregion



        public string saveFabricIssueSub(FabricIssueDTO objFabricIssueDTO)
        {

            string strMsg = "";
            OracleTransaction trans = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_foreign_fabric_issue_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objFabricIssueDTO.TranId != "")
            {
                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.TranId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

           

            if (objFabricIssueDTO.IssueDate != "")
            {
                objOracleCommand.Parameters.Add("P_ISSUE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.IssueDate;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_ISSUE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objFabricIssueDTO.ChallanNo != "")
            {
                objOracleCommand.Parameters.Add("P_CHALLAN_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.ChallanNo;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_CHALLAN_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objFabricIssueDTO.SupplierId != "")
            {
                objOracleCommand.Parameters.Add("P_SUPPLIER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.SupplierId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_SUPPLIER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objFabricIssueDTO.ProgrammeId != "")
            {
                objOracleCommand.Parameters.Add("P_PROGRAMME_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.ProgrammeId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_PROGRAMME_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            if (objFabricIssueDTO.FabricId != "")
            {
                objOracleCommand.Parameters.Add("P_FABRIC_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.FabricId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_FABRIC_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objFabricIssueDTO.FabricConstructionId != "")
            {
                objOracleCommand.Parameters.Add("P_FABRIC_CONSTRUCTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.FabricConstructionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_FABRIC_CONSTRUCTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objFabricIssueDTO.StyleId != "")
            {
                objOracleCommand.Parameters.Add("P_STYLE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.StyleId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_STYLE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            if (objFabricIssueDTO.ColorId != "")
            {
                objOracleCommand.Parameters.Add("P_COLOR_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.ColorId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_COLOR_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            if (objFabricIssueDTO.ArtId != "")
            {
                objOracleCommand.Parameters.Add("P_ART_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.ArtId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_ART_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objFabricIssueDTO.StoreId != "")
            {
                objOracleCommand.Parameters.Add("P_STORE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.StoreId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_STORE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objFabricIssueDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objFabricIssueDTO.ReceiveQuantity != "")
            {
                objOracleCommand.Parameters.Add("P_RECEIVE_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.ReceiveQuantity;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_RECEIVE_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objFabricIssueDTO.IssueQuantity != "")
            {
                objOracleCommand.Parameters.Add("P_ISSUE_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.IssueQuantity;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_ISSUE_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objFabricIssueDTO.RemainingQuantity != "")
            {
                objOracleCommand.Parameters.Add("P_REMAINING_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.RemainingQuantity;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_REMAINING_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.BranchOfficeId;


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
        public string saveLocalFabricReceivePI(FabricIssueDTO objFabricIssueDTO)
        {

            string strMsg = "";
            OracleTransaction trans = null;
            OracleCommand objOracleCommand = new OracleCommand("PRO_FABRIC_PI_MAIN_SAVE");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objFabricIssueDTO.ReferenceNo != "")
            {
                objOracleCommand.Parameters.Add("P_REFERENCE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.ReferenceNo;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_REFERENCE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objFabricIssueDTO.ReceiveDate != "")
            {
                objOracleCommand.Parameters.Add("P_RECEIVE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.ReceiveDate;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_RECEIVE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objFabricIssueDTO.PI != "")
            {
                objOracleCommand.Parameters.Add("P_PI_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.PI;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_PI_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objFabricIssueDTO.PO != "")
            {
                objOracleCommand.Parameters.Add("P_PO_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.PO;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_PO_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objFabricIssueDTO.SupplierId != "")
            {
                objOracleCommand.Parameters.Add("P_SUPPLIER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.SupplierId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_SUPPLIER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            if (objFabricIssueDTO.ProgrammeId != "")
            {
                objOracleCommand.Parameters.Add("P_PROGRAMME_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.ProgrammeId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_PROGRAMME_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            if (objFabricIssueDTO.ColorId != "")
            {
                objOracleCommand.Parameters.Add("P_COLOR_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.ColorId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_COLOR_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objFabricIssueDTO.FabricId != "")
            {
                objOracleCommand.Parameters.Add("P_FABRIC_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.FabricId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_FABRIC_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objFabricIssueDTO.FabricConstructionId != "")
            {
                objOracleCommand.Parameters.Add("P_FABRIC_CONSTRUCTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.FabricConstructionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_FABRIC_CONSTRUCTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objFabricIssueDTO.MeasureId != "")
            {
                objOracleCommand.Parameters.Add("P_MEASURE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.MeasureId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_MEASURE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objFabricIssueDTO.CurrencyId != "")
            {
                objOracleCommand.Parameters.Add("P_CURRENCY_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.CurrencyId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_CURRENCY_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objFabricIssueDTO.Blance != "")
            {
                objOracleCommand.Parameters.Add("P_BLANCE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.Blance;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_BLANCE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objFabricIssueDTO.Quantity != "")
            {
                objOracleCommand.Parameters.Add("P_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.Quantity;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objFabricIssueDTO.Rate != "")
            {
                objOracleCommand.Parameters.Add("P_RATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.Rate;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_RATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.BranchOfficeId;



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
        public string saveZipperIssue(FabricIssueDTO objFabricIssueDTO)
        {

            string strMsg = "";
            OracleTransaction trans = null;
            OracleCommand objOracleCommand = new OracleCommand("PRO_ZIPPER_ISSUE_SAVE");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            if (objFabricIssueDTO.ChallanNo != "")
            {
                objOracleCommand.Parameters.Add("P_CHALLAN_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.ChallanNo;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_CHALLAN_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objFabricIssueDTO.IssueDate.Length > 6)
            {
                objOracleCommand.Parameters.Add("P_ISSUE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.IssueDate;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_ISSUE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objFabricIssueDTO.SupplierId != "")
            {
                objOracleCommand.Parameters.Add("P_SUPPLIER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.SupplierId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_SUPPLIER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objFabricIssueDTO.StoreId != "")
            {
                objOracleCommand.Parameters.Add("P_STORE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.StoreId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_STORE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            if (objFabricIssueDTO.ProgrammeId != "")
            {
                objOracleCommand.Parameters.Add("P_PROGRAMME_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.ProgrammeId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_PROGRAMME_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            if (objFabricIssueDTO.ColorId != "")
            {
                objOracleCommand.Parameters.Add("P_COLOR_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.ColorId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_COLOR_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objFabricIssueDTO.ParticularName != "")
            {
                objOracleCommand.Parameters.Add("P_PARTICULAR_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.ParticularName;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_PARTICULAR_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objFabricIssueDTO.StyleId != "")
            {
                objOracleCommand.Parameters.Add("P_STYLE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.StyleId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_STYLE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objFabricIssueDTO.ArtId != "")
            {
                objOracleCommand.Parameters.Add("P_ART_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.ArtId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_ART_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objFabricIssueDTO.LineId != "")
            {
                objOracleCommand.Parameters.Add("P_LINE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.LineId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_LINE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objFabricIssueDTO.MeasureId != "")
            {
                objOracleCommand.Parameters.Add("P_MEASURE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.MeasureId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_MEASURE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objFabricIssueDTO.Blance != "")
            {
                objOracleCommand.Parameters.Add("P_BLANCE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.Blance;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_BLANCE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objFabricIssueDTO.Quantity != "")
            {
                objOracleCommand.Parameters.Add("P_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.Quantity;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }




            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.BranchOfficeId;



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
        public string saveZipperReceive(FabricIssueDTO objFabricIssueDTO)
        {

            string strMsg = "";
            OracleTransaction trans = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_zipper_receive_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objFabricIssueDTO.InvoiceNo != "")
            {
                objOracleCommand.Parameters.Add("P_INVOICE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.InvoiceNo;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_INVOICE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objFabricIssueDTO.ReceiveDate != "")
            {
                objOracleCommand.Parameters.Add("P_RECEIVE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.ReceiveDate;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_RECEIVE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objFabricIssueDTO.ContactNo != "")
            {
                objOracleCommand.Parameters.Add("P_CONTACT_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.ContactNo;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_CONTACT_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objFabricIssueDTO.LcNo != "")
            {
                objOracleCommand.Parameters.Add("P_BACK_TO_BACK_LC_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.LcNo;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_BACK_TO_BACK_LC_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objFabricIssueDTO.AirChallanNo != "")
            {
                objOracleCommand.Parameters.Add("P_AIR_CHALLAN_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.AirChallanNo;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_AIR_CHALLAN_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            if (objFabricIssueDTO.HandCarryYn != "")
            {
                objOracleCommand.Parameters.Add("P_HAND_CARRY_YN", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.HandCarryYn;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_HAND_CARRY_YN", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            if (objFabricIssueDTO.SupplierId != "")
            {
                objOracleCommand.Parameters.Add("P_SUPPLIER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.SupplierId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_SUPPLIER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objFabricIssueDTO.BuyerId != "")
            {
                objOracleCommand.Parameters.Add("P_BUYER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.BuyerId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_BUYER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objFabricIssueDTO.StoreId != "")
            {
                objOracleCommand.Parameters.Add("P_STORE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.StoreId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_STORE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objFabricIssueDTO.ImporterId != "")
            {
                objOracleCommand.Parameters.Add("P_IMPORTER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.ImporterId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_IMPORTER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objFabricIssueDTO.ProgrammeId != "")
            {
                objOracleCommand.Parameters.Add("P_PROGRAMME_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.ProgrammeId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_PROGRAMME_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objFabricIssueDTO.ColorId != "")
            {
                objOracleCommand.Parameters.Add("P_COLOR_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.ColorId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_COLOR_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objFabricIssueDTO.ParticularName != "")
            {
                objOracleCommand.Parameters.Add("P_PARTICULAR_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.ParticularName;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_PARTICULAR_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objFabricIssueDTO.StyleId != "")
            {
                objOracleCommand.Parameters.Add("P_STYLE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.StyleId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_STYLE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objFabricIssueDTO.ArtId != "")
            {
                objOracleCommand.Parameters.Add("P_ART_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.ArtId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_ART_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objFabricIssueDTO.Quantity != "")
            {
                objOracleCommand.Parameters.Add("P_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.Quantity;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objFabricIssueDTO.Rate != "")
            {
                objOracleCommand.Parameters.Add("P_ZIPPER_RATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.Rate;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_ZIPPER_RATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            if (objFabricIssueDTO.CurrencyId != "")
            {
                objOracleCommand.Parameters.Add("P_CURRENCY_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.CurrencyId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_CURRENCY_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objFabricIssueDTO.SizeId != "")
            {
                objOracleCommand.Parameters.Add("P_MEASURE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.SizeId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_MEASURE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objFabricIssueDTO.Length != "")
            {
                objOracleCommand.Parameters.Add("P_ZIPPER_LENGTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.Length;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_ZIPPER_LENGTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }




            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.BranchOfficeId;



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
        public string deleteLocalFabricReceivePI(FabricIssueDTO objFabricIssueDTO)
        {

            string strMsg = "";
            OracleTransaction trans = null;
            OracleCommand objOracleCommand = new OracleCommand("PRO_DELETE_FABRIC_PI");
            objOracleCommand.CommandType = CommandType.StoredProcedure;




            if (objFabricIssueDTO.PO != "")
            {
                objOracleCommand.Parameters.Add("P_PO_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.PO;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_PO_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.BranchOfficeId;



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
        public string deleteZipperIssue(FabricIssueDTO objFabricIssueDTO)
        {

            string strMsg = "";
            OracleTransaction trans = null;
            OracleCommand objOracleCommand = new OracleCommand("PRO_DELETE_ZIPPER_ISSUE");
            objOracleCommand.CommandType = CommandType.StoredProcedure;




            if (objFabricIssueDTO.ChallanNo != "")
            {
                objOracleCommand.Parameters.Add("P_CHALLAN_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.ChallanNo;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_CHALLAN_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objFabricIssueDTO.IssueDate != "")
            {
                objOracleCommand.Parameters.Add("P_ISSUE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.IssueDate;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_ISSUE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.BranchOfficeId;



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
        public string deleteZipperReceive(FabricIssueDTO objFabricIssueDTO)
        {

            string strMsg = "";
            OracleTransaction trans = null;
            OracleCommand objOracleCommand = new OracleCommand("PRO_DELETE_ZIPPER_RECEIVE");
            objOracleCommand.CommandType = CommandType.StoredProcedure;




            if (objFabricIssueDTO.InvoiceNo != "")
            {
                objOracleCommand.Parameters.Add("P_INVOICE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.InvoiceNo;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_INVOICE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objFabricIssueDTO.ReceiveDate.Length > 6)
            {
                objOracleCommand.Parameters.Add("P_INVOICE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.ReceiveDate;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_INVOICE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.BranchOfficeId;



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
        public string saveLocalFabricReceive(FabricIssueDTO objFabricIssueDTO)
        {

            string strMsg = "";
            OracleTransaction trans = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_local_fabric_receive_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objFabricIssueDTO.TranId != "")
            {
                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.TranId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objFabricIssueDTO.ReceiveDate.Length > 6)
            {
                objOracleCommand.Parameters.Add("P_RECEIVE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.ReceiveDate;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_RECEIVE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objFabricIssueDTO.ChallanNo != "")
            {
                objOracleCommand.Parameters.Add("P_CHALLAN_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.ChallanNo;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_CHALLAN_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objFabricIssueDTO.FabricId != "")
            {
                objOracleCommand.Parameters.Add("P_FABRIC_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.FabricId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_FABRIC_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objFabricIssueDTO.FabricConstructionId != "")
            {
                objOracleCommand.Parameters.Add("P_FABRIC_CONSTRUCTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.FabricConstructionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_FABRIC_CONSTRUCTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objFabricIssueDTO.SupplierId != "")
            {
                objOracleCommand.Parameters.Add("P_SUPPLIER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.SupplierId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_SUPPLIER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objFabricIssueDTO.PI != "")
            {
                objOracleCommand.Parameters.Add("P_PI_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.PI;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_PI_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objFabricIssueDTO.PO != "")
            {
                objOracleCommand.Parameters.Add("P_PO_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.PO;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_PO_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }





            if (objFabricIssueDTO.ProgrammeId != "")
            {
                objOracleCommand.Parameters.Add("P_PROGRAMME_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.ProgrammeId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_PROGRAMME_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            if (objFabricIssueDTO.ColorId != "")
            {
                objOracleCommand.Parameters.Add("P_COLOR_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.ColorId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_COLOR_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            if (objFabricIssueDTO.MeasureId != "")
            {
                objOracleCommand.Parameters.Add("P_MEASURE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.MeasureId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_MEASURE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objFabricIssueDTO.CurrencyId != "")
            {
                objOracleCommand.Parameters.Add("P_CURRENCY_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.CurrencyId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_CURRENCY_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objFabricIssueDTO.Blance != "")
            {
                objOracleCommand.Parameters.Add("P_PO_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.Blance;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_PO_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objFabricIssueDTO.TotalReceiveQuantity != "")
            {
                objOracleCommand.Parameters.Add("P_TOTAL_RECEIVE_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.TotalReceiveQuantity;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_TOTAL_RECEIVE_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objFabricIssueDTO.ReceiveQuantity != "")
            {
                objOracleCommand.Parameters.Add("P_RECEIVE_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.ReceiveQuantity;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_RECEIVE_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objFabricIssueDTO.Rate != "")
            {
                objOracleCommand.Parameters.Add("P_RATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.Rate;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_RATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objFabricIssueDTO.Amount != "")
            {
                objOracleCommand.Parameters.Add("P_AMOUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.Amount;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_AMOUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.BranchOfficeId;


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
        public string deleteLocalFabricReceive(FabricIssueDTO objFabricIssueDTO)
        {

            string strMsg = "";
            OracleTransaction trans = null;
            OracleCommand objOracleCommand = new OracleCommand("PRO_DELETE_FABRIC_RECEIVE");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            if (objFabricIssueDTO.TranId != "")
            {
                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.TranId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objFabricIssueDTO.ChallanNo != "")
            {
                objOracleCommand.Parameters.Add("P_CHALLAN_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.ChallanNo;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_CHALLAN_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            if (objFabricIssueDTO.ReceiveDate.Length > 6)
            {
                objOracleCommand.Parameters.Add("P_RECEIVE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.ReceiveDate;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_RECEIVE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }





            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.BranchOfficeId;


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
        public string deleteForeignFabricIssue(FabricIssueDTO objFabricIssueDTO)
        {

            string strMsg = "";
            OracleTransaction trans = null;
            OracleCommand objOracleCommand = new OracleCommand("PRO_DELETE_FOREIGN_FAB_ISSUE");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            if (objFabricIssueDTO.TranId != "")
            {
                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.TranId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objFabricIssueDTO.ChallanNo != "")
            {
                objOracleCommand.Parameters.Add("P_CHALLAN_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.ChallanNo;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_CHALLAN_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            if (objFabricIssueDTO.IssueDate.Length > 6)
            {
                objOracleCommand.Parameters.Add("P_ISSUE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.IssueDate;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_ISSUE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }





            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.BranchOfficeId;


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
        public string processForeignFabricIssueFromReceive(FabricIssueDTO objFabricIssueDTO)
        {

            string strMsg = "";
            OracleTransaction trans = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_foreign_fab_issue_search");
            objOracleCommand.CommandType = CommandType.StoredProcedure;




            if (objFabricIssueDTO.InvoiceNo != "")
            {
                objOracleCommand.Parameters.Add("P_INVOICE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.InvoiceNo;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_INVOICE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            if (objFabricIssueDTO.ReceiveDate.Length > 6)
            {
                objOracleCommand.Parameters.Add("P_RECEIVE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.ReceiveDate;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_RECEIVE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }





            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.BranchOfficeId;


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
        public string saveLocalFabricAcceptance(FabricIssueDTO objFabricIssueDTO)
        {

            string strMsg = "";
            OracleTransaction trans = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_local_fabric_accept_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objFabricIssueDTO.ReferenceNo != "")
            {
                objOracleCommand.Parameters.Add("P_REFERENCE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.ReferenceNo;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_REFERENCE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objFabricIssueDTO.AcceptanceDate != "")
            {
                objOracleCommand.Parameters.Add("P_ACCEPTANCE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.AcceptanceDate;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_ACCEPTANCE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objFabricIssueDTO.ChallanNo != "")
            {
                objOracleCommand.Parameters.Add("P_CHALLAN_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.ChallanNo;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_CHALLAN_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objFabricIssueDTO.LcTypeId != "")
            {
                objOracleCommand.Parameters.Add("P_ACCEPTANCE_TYPE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.LcTypeId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_ACCEPTANCE_TYPE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objFabricIssueDTO.LcNo != "")
            {
                objOracleCommand.Parameters.Add("P_LC_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.LcNo;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_LC_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objFabricIssueDTO.DeliveryNo != "")
            {
                objOracleCommand.Parameters.Add("P_DELIVERY_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.DeliveryNo;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_DELIVERY_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            if (objFabricIssueDTO.PI != "")
            {
                objOracleCommand.Parameters.Add("P_PI_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.PI;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_PI_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objFabricIssueDTO.PO != "")
            {
                objOracleCommand.Parameters.Add("P_PO_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.PO;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_PO_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objFabricIssueDTO.ProgrammeId != "")
            {
                objOracleCommand.Parameters.Add("P_PROGRAMME_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.ProgrammeId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_PROGRAMME_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objFabricIssueDTO.FabricId != "")
            {
                objOracleCommand.Parameters.Add("P_FABRIC_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.FabricId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_FABRIC_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objFabricIssueDTO.FabricConstructionId != "")
            {
                objOracleCommand.Parameters.Add("P_FABRIC_CONSTRUCTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.FabricConstructionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_FABRIC_CONSTRUCTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            if (objFabricIssueDTO.ColorId != "")
            {
                objOracleCommand.Parameters.Add("P_COLOR_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.ColorId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_COLOR_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objFabricIssueDTO.MeasureId != "")
            {
                objOracleCommand.Parameters.Add("P_MEASURE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.MeasureId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_MEASURE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objFabricIssueDTO.Quantity != "")
            {
                objOracleCommand.Parameters.Add("P_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.Quantity;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objFabricIssueDTO.POBlance != "")
            {
                objOracleCommand.Parameters.Add("P_PO_BLANCE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.POBlance;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_PO_BLANCE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objFabricIssueDTO.Blance != "")
            {
                objOracleCommand.Parameters.Add("P_BLANCE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.Blance;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_BLANCE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objFabricIssueDTO.RateInDollar != "")
            {
                objOracleCommand.Parameters.Add("P_RATE_IN_DOLLAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.RateInDollar;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_RATE_IN_DOLLAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objFabricIssueDTO.RateInTaka != "")
            {
                objOracleCommand.Parameters.Add("P_RATE_IN_TAKA", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.RateInTaka;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_RATE_IN_TAKA", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.BranchOfficeId;


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
        public string saveLocalFabricIssue(FabricIssueDTO objFabricIssueDTO)
        {

            string strMsg = "";
            OracleTransaction trans = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_local_fabric_issue_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objFabricIssueDTO.TranId != "")
            {
                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.TranId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objFabricIssueDTO.IssueDate != "")
            {
                objOracleCommand.Parameters.Add("P_ISSUE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.IssueDate;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_ISSUE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objFabricIssueDTO.ChallanNo != "")
            {
                objOracleCommand.Parameters.Add("P_CHALLAN_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.ChallanNo;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_CHALLAN_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            if (objFabricIssueDTO.ProgrammeId != "")
            {
                objOracleCommand.Parameters.Add("P_PROGRAMME_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.ProgrammeId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_PROGRAMME_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objFabricIssueDTO.FabricId != "")
            {
                objOracleCommand.Parameters.Add("P_FABRIC_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.FabricId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_FABRIC_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objFabricIssueDTO.FabricConstructionId != "")
            {
                objOracleCommand.Parameters.Add("P_FABRIC_CONSTRUCTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.FabricConstructionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_FABRIC_CONSTRUCTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            if (objFabricIssueDTO.ColorId != "")
            {
                objOracleCommand.Parameters.Add("P_COLOR_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.ColorId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_COLOR_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objFabricIssueDTO.MeasureId != "")
            {
                objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.MeasureId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objFabricIssueDTO.Quantity != "")
            {
                objOracleCommand.Parameters.Add("P_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.Quantity;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objFabricIssueDTO.Blance != "")
            {
                objOracleCommand.Parameters.Add("P_BALANCE_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.Blance;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_BALANCE_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objFabricIssueDTO.Rate != "")
            {
                objOracleCommand.Parameters.Add("P_RATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.Rate;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_RATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objFabricIssueDTO.StoreId != "")
            {
                objOracleCommand.Parameters.Add("P_STORE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.StoreId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_STORE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objFabricIssueDTO.SupplierId != "")
            {
                objOracleCommand.Parameters.Add("P_SUPPLIER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.SupplierId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_SUPPLIER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objFabricIssueDTO.ReturnToSupplier != "")
            {
                objOracleCommand.Parameters.Add("P_RETURN_TO_SUPPLIER_YN", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.ReturnToSupplier;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_RETURN_TO_SUPPLIER_YN", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.BranchOfficeId;


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
        public string deleteLocalFabricAcceptance(FabricIssueDTO objFabricIssueDTO)
        {

            string strMsg = "";
            OracleTransaction trans = null;
            OracleCommand objOracleCommand = new OracleCommand("PRO_DELETE_FABRIC_ACCEPTANCE");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objFabricIssueDTO.TranId != "")
            {
                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.TranId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objFabricIssueDTO.ChallanNo != "")
            {
                objOracleCommand.Parameters.Add("P_CHALLAN_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.ChallanNo;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_CHALLAN_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objFabricIssueDTO.AcceptanceDate.Length > 6)
            {
                objOracleCommand.Parameters.Add("P_ACCEPTANCE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.AcceptanceDate;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_ACCEPTANCE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.BranchOfficeId;


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
        public string deleteLocalFabricIssue(FabricIssueDTO objFabricIssueDTO)
        {

            string strMsg = "";
            OracleTransaction trans = null;
            OracleCommand objOracleCommand = new OracleCommand("PRO_DELETE_FABRIC_ISSUE");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objFabricIssueDTO.TranId != "")
            {
                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.TranId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            if (objFabricIssueDTO.ChallanNo != "")
            {
                objOracleCommand.Parameters.Add("P_CHALLAN_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.ChallanNo;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_CHALLAN_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objFabricIssueDTO.IssueDate != "")
            {
                objOracleCommand.Parameters.Add("P_ISSUE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.IssueDate;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_ISSUE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFabricIssueDTO.BranchOfficeId;


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
        public DataTable searchForeignFabricIssueSub(FabricIssueDTO objFabricIssueDTO)
        {

            DataTable dt = new DataTable();

            //string strYN = "";
            //string sql = "";

            //sql = "SELECT 'Y'  FROM FOREIGN_FABRIC_ISSUE_SUB WHERE  INVOICE_NO = '" + objFabricIssueDTO.InvoiceNo + "' AND HEAD_OFFICE_ID = '" + objFabricIssueDTO.HeadOfficeId + "' AND BRANCH_OFFICE_ID ='" + objFabricIssueDTO.BranchOfficeId + "' AND RECEIVE_DATE = to_date('" + objFabricIssueDTO.ReceiveDate + "', 'dd/mm/yyyy') ";




            //OracleCommand objCommand = new OracleCommand(sql);
            //OracleDataReader objDataReader;

            //using (OracleConnection strConn = GetConnection())
            //{

            //    objCommand.Connection = strConn;
            //    strConn.Open();
            //    objDataReader = objCommand.ExecuteReader();
            //    try
            //    {
            //        while (objDataReader.Read())
            //        {

            //            strYN = objDataReader.GetString(0);



            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        throw new Exception("Error : " + ex.Message);

            //    }

            //    finally
            //    {

            //        strConn.Close();
            //    }


            //}

            //if(strYN == "Y")
            //{


                string sql1 = "";

                sql1 = "SELECT " +
                    "TRAN_ID, " +

             "PROGRAMME_ID, " +
             "FABRIC_ID, " +
             "FABRIC_CONSTRUCTION_ID, " +
             "STYLE_ID, " +
             "COLOR_ID, " +
             "ART_ID, " +
             "UNIT_ID, " +
             "RECEIVE_QUANTITY, " +
             "ISSUE_QUANTITY, " +
             "REMAINING_QUANTITY " +


             "FROM VEW_FOREIGN_FABRIC_ISSUE_SUB WHERE  head_office_id = '" + objFabricIssueDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objFabricIssueDTO.BranchOfficeId + "'  ";



                if (objFabricIssueDTO.StoreId.Length > 0)
                {

                    sql1 = sql1 + "and STORE_ID = '" + objFabricIssueDTO.StoreId + "'";
                }



                if (objFabricIssueDTO.IssueDate.Length > 6)
                {

                    sql1 = sql1 + "and ISSUE_DATE = TO_DATE('" + objFabricIssueDTO.IssueDate + "','dd/mm/yyyy' )";
                }

                if (objFabricIssueDTO.ChallanNo !="" )
                {

                    sql1 = sql1 + "and CHALLAN_NO = '" + objFabricIssueDTO.ChallanNo + "'";
                }




                //sql = sql + "order by SL ";

                OracleCommand objCommand1 = new OracleCommand(sql1);
                OracleDataAdapter objDataAdapter1 = new OracleDataAdapter(objCommand1);
                using (OracleConnection strConn = GetConnection())
                {
                    try
                    {
                        objCommand1.Connection = strConn;
                        strConn.Open();
                        objDataAdapter1.Fill(dt);

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


            //}
            //else
            //{

            //    string sql2 = "";

            //    sql2 = "SELECT " +
            //           "to_char(NVL(TRAN_ID,'0'))TRAN_ID, " +
            //           "to_char(NVL(PROGRAMME_ID,0))PROGRAMME_ID, " +
            //           "to_char(NVL(FABRIC_ID,'0'))FABRIC_ID, " +
            //           "to_char(NVL(FABRIC_CONSTRUCTION_ID,'0'))FABRIC_CONSTRUCTION_ID, " +
            //           "to_char(NVL(STYLE_ID,'0'))STYLE_ID, " +
            //           "to_char(NVL(COLOR_ID, '0'))COLOR_ID, " +
            //           "to_char(NVL(ART_ID, '0'))ART_ID, " +
            //           "to_char(NVL(STORE_ID, '0'))STORE_ID, " +
            //            "to_char(NVL(UNIT_ID, '0'))UNIT_ID, " +
            //           "to_char(NVL(CURRENCY_ID, '0'))CURRENCY_ID, " +
            //            "to_char(NVL(RATE, '0'))RATE, " +
            //           "to_char(NVL(WIDTH, '0'))WIDTH, " +
            //            "to_char(NVL(NUM_OF_ROLL, '0'))NUM_OF_ROLL, " +
            //           "to_char(NVL(RECEIVE_QUANTITY, '0'))RECEIVE_QUANTITY " +


            //          " FROM VEW_FOREIGN_FAB_RECEIVE_SUB WHERE  INVOICE_NO = '" + objFabricIssueDTO.InvoiceNo + "' AND head_office_id = '" + objFabricIssueDTO.HeadOfficeId + "' and  branch_office_id = '" + objFabricIssueDTO.BranchOfficeId + "'  and RECEIVE_DATE = TO_DATE('" + objFabricIssueDTO.ReceiveDate + "', 'dd/mm/yyyy') ";




            //    //sql = sql + "order by SL ";

            //    OracleCommand objCommand1 = new OracleCommand(sql2);
            //    OracleDataAdapter objDataAdapter1 = new OracleDataAdapter(objCommand1);
            //    using (OracleConnection strConn = GetConnection())
            //    {
            //        try
            //        {
            //            objCommand1.Connection = strConn;
            //            strConn.Open();
            //            objDataAdapter1.Fill(dt);

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


            //}




            return dt;

        }
        public DataTable searchFabricReceivePI(FabricIssueDTO objFabricIssueDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +

                   "to_char(NVL(PROGRAMME_ID,'0'))PROGRAMME_ID, " +
                   "to_char(NVL(COLOR_ID,'0'))COLOR_ID, " +
                   "to_char(NVL(FABRIC_ID,'0'))FABRIC_ID, " +
                   "to_char(NVL(FABRIC_CONSTRUCTION_ID,'0'))FABRIC_CONSTRUCTION_ID, " +
                   "to_char(NVL(MEASURE_ID,'0'))MEASURE_ID, " +
                   "to_char(NVL(BLANCE,'0'))BLANCE, " +
                   "to_char(NVL(QUANTITY,0))QUANTITY, " +
                   "to_char(NVL(CURRENCY_ID,'0'))CURRENCY_ID, " +
                   "to_char(NVL(supplier_id,'0'))supplier_id, " +
                   "to_char(NVL(RATE, '0'))RATE " +



                  "FROM vew_search_fabric_receive_pi WHERE head_office_id = '" + objFabricIssueDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objFabricIssueDTO.BranchOfficeId + "'  ";



            if (objFabricIssueDTO.ReferenceNo.Length > 0)
            {

                sql = sql + "and REFERENCE_NO = '" + objFabricIssueDTO.ReferenceNo + "'";
            }



            if (objFabricIssueDTO.SupplierId.Length > 0)
            {

                sql = sql + "and SUPPLIER_ID = '" + objFabricIssueDTO.SupplierId + "'";
            }


            if (objFabricIssueDTO.ReceiveDate.Length > 6)
            {

                sql = sql + "and RECEIVE_DATE = TO_DATE('" + objFabricIssueDTO.ReceiveDate + "','dd/mm/yyyy' )";
            }



            if (objFabricIssueDTO.PI.Length > 0)
            {

                sql = sql + "and PI_NO ='" + objFabricIssueDTO.PI + "'";
            }


            if (objFabricIssueDTO.PO.Length > 0)
            {

                sql = sql + "and PO_NO ='" + objFabricIssueDTO.PO + "'";
            }


            //sql = sql + "order by SL ";

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
        public DataTable searchZipperIssueRecord(FabricIssueDTO objFabricIssueDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +

                   "to_char(NVL(PROGRAMME_ID,'0'))PROGRAMME_ID, " +
                   "to_char(NVL(COLOR_ID,'0'))COLOR_ID, " +
                   "to_char(NVL(SUPPLIER_ID,'0'))SUPPLIER_ID, " +
                   "to_char(NVL(STORE_ID,'0'))STORE_ID, " +
                   "to_char(NVL(MEASURE_ID,'0'))MEASURE_ID, " +
                   "to_char(NVL(BLANCE,'0'))BLANCE, " +
                   "to_char(NVL(QUANTITY,0))QUANTITY, " +
                   "to_char(NVL(PARTICULAR_NAME,'N/A'))PARTICULAR_NAME, " +
                   "to_char(NVL(STYLE_ID,'0'))STYLE_ID, " +
                   "to_char(NVL(ART_ID, '0'))ART_ID, " +
                   "to_char(NVL(LINE_ID, '0'))LINE_ID " +


                  "FROM VEW_SEARCH_ZIPPER_ISSUE_ENTRY WHERE head_office_id = '" + objFabricIssueDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objFabricIssueDTO.BranchOfficeId + "' AND CHALLAN_NO = '" + objFabricIssueDTO.ChallanNo + "'   ";



            if (objFabricIssueDTO.IssueDate.Length > 6)
            {

                sql = sql + "and ISSUE_DATE = TO_DATE('" + objFabricIssueDTO.IssueDate + "', 'dd/mm/yyyy') ";
            }



            if (objFabricIssueDTO.SupplierId.Length > 0)
            {

                sql = sql + "and SUPPLIER_ID = '" + objFabricIssueDTO.SupplierId + "'";
            }


            if (objFabricIssueDTO.StoreId.Length > 0)
            {

                sql = sql + "and STORE_ID ='" + objFabricIssueDTO.StoreId + "'";
            }




            //sql = sql + "order by SL ";

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
        public DataTable searchZipperIssueRecordEntry(FabricIssueDTO objFabricIssueDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
                   "rownum sl, " +
                   "to_char(NVL(CHALLAN_NO,'0'))CHALLAN_NO, " +
                   "TO_CHAR(ISSUE_DATE,'dd/mm/yyyy')ISSUE_DATE, " +
                   "to_char(NVL(SUPPLIER_NAME,'0'))SUPPLIER_NAME, " +
                   "to_char(NVL(STORE_NAME,'0'))STORE_NAME, " +
                   "to_char(NVL(PROGRAMME_NAME,'0'))PROGRAMME_NAME, " +
                   "to_char(NVL(COLOR_NAME,'0'))COLOR_NAME, " +
                   "to_char(NVL(PARTICULAR_NAME,0))PARTICULAR_NAME, " +
                   "to_char(NVL(STYLE_NAME,0))STYLE_NAME, " +
                   "to_char(NVL(ART_NO,'N/A'))ART_NO, " +
                   "to_char(NVL(LINE_NAME,'0'))LINE_NAME, " +
                   "to_char(NVL(MEASURE_NAME, '0'))MEASURE_NAME, " +
                   "to_char(NVL(BLANCE, '0'))BLANCE, " +
                   "to_char(NVL(QUANTITY, '0'))QUANTITY " +


                  "FROM VEW_SEARCH_ZIPPER_ISSUE_ENTRY WHERE head_office_id = '" + objFabricIssueDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objFabricIssueDTO.BranchOfficeId + "' AND CHALLAN_NO = '" + objFabricIssueDTO.ChallanNo + "'   ";



            if (objFabricIssueDTO.IssueDate.Length > 6)
            {

                sql = sql + "and ISSUE_DATE = TO_DATE('" + objFabricIssueDTO.IssueDate + "', 'dd/mm/yyyy') ";
            }



            if (objFabricIssueDTO.SupplierId.Length > 0)
            {

                sql = sql + "and SUPPLIER_ID = '" + objFabricIssueDTO.SupplierId + "'";
            }


            if (objFabricIssueDTO.StoreId.Length > 0)
            {

                sql = sql + "and STORE_ID ='" + objFabricIssueDTO.StoreId + "'";
            }




            //sql = sql + "order by SL ";

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
        public DataTable searchFabricReceiveEntryPI(FabricIssueDTO objFabricIssueDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
               "rownum SL, " +
               "REFERENCE_NO, " +
               "PROGRAMME_ID, " +
               "PROGRAMME_NAME, " +
               "COLOR_ID, " +
               "COLOR_NAME, " +
               "FABRIC_ID, " +
               "FABRIC_NAME, " +
               "FABRIC_CONSTRUCTION_ID, " +
               "FABRIC_CONSTRUCTION, " +
               "MEASURE_ID, " +
               "MEASURE_NAME, " +
               "CURRENCY_ID, " +
               "CURRENCY_NAME, " +
               "BLANCE, " +
               "QUANTITY, " +
               "RATE, " +
               "TO_CHAR(RECEIVE_DATE,'dd/mm/yyyy')RECEIVE_DATE, " +
               "PI_NO, " +
               "PO_NO, " +
               "SUPPLIER_ID, " +
               "SUPPLIER_NAME, " +
               "HEAD_OFFICE_ID, " +
               "BRANCH_OFFICE_ID " +



                  "FROM VEW_SEARCH_FABRIC_RECEIVE_PI WHERE head_office_id = '" + objFabricIssueDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objFabricIssueDTO.BranchOfficeId + "'  ";



            if (objFabricIssueDTO.ReferenceNo.Length > 0)
            {

                sql = sql + "and REFERENCE_NO = '" + objFabricIssueDTO.ReferenceNo + "'";
            }



            if (objFabricIssueDTO.SupplierId.Length > 0)
            {

                sql = sql + "and SUPPLIER_ID = '" + objFabricIssueDTO.SupplierId + "'";
            }


            if (objFabricIssueDTO.ReceiveDate.Length > 6)
            {

                sql = sql + "and RECEIVE_DATE = TO_DATE('" + objFabricIssueDTO.ReceiveDate + "','dd/mm/yyyy' )";
            }



            if (objFabricIssueDTO.PI.Length > 0)
            {

                sql = sql + "and PI_NO ='" + objFabricIssueDTO.PI + "'";
            }


            if (objFabricIssueDTO.PO.Length > 0)
            {

                sql = sql + "and PO_NO ='" + objFabricIssueDTO.PO + "'";
            }


            //sql = sql + "order by SL ";

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
        public DataTable searchZipperReceiveEntry(FabricIssueDTO objFabricIssueDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
               "rownum SL, " +
               "REFERENCE_NO, " +
               "PROGRAMME_ID, " +
               "PROGRAMME_NAME, " +
               "COLOR_ID, " +
               "COLOR_NAME, " +
               "FABRIC_ID, " +
               "FABRIC_NAME, " +
               "FABRIC_CONSTRUCTION_ID, " +
               "FABRIC_CONSTRUCTION, " +
               "MEASURE_ID, " +
               "MEASURE_NAME, " +
               "CURRENCY_ID, " +
               "CURRENCY_NAME, " +
               "BLANCE, " +
               "QUANTITY, " +
               "RATE, " +
               "TO_CHAR(RECEIVE_DATE,'dd/mm/yyyy')RECEIVE_DATE, " +
               "PI_NO, " +
               "PO_NO, " +
               "SUPPLIER_ID, " +
               "SUPPLIER_NAME, " +
               "HEAD_OFFICE_ID, " +
               "BRANCH_OFFICE_ID " +



                  "FROM VEW_SEARCH_FABRIC_RECEIVE_PI WHERE INVOICE_NO = '" + objFabricIssueDTO.InvoiceNo + "' AND head_office_id = '" + objFabricIssueDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objFabricIssueDTO.BranchOfficeId + "'  ";






            if (objFabricIssueDTO.ReceiveDate.Length > 6)
            {

                sql = sql + "and RECEIVE_DATE = TO_DATE('" + objFabricIssueDTO.ReceiveDate + "','dd/mm/yyyy' )";
            }




            //sql = sql + "order by SL ";

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
        public DataTable searchZipperReceiveEntryRecord(FabricIssueDTO objFabricIssueDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
                "ROWNUM SL, " +
                "INVOICE_NO, " +
                "TO_CHAR(RECEIVE_DATE,'dd/mm/yyyy')RECEIVE_DATE, " +
                "CONTACT_NO, " +
                "BACK_TO_BACK_LC_NO, " +
                "AIR_CHALLAN_NO, " +
                "HAND_CARRY_YN, " +
                "SUPPLIER_ID, " +
                "SUPPLIER_NAME, " +
                "BUYER_ID, " +
                "BUYER_NAME, " +
                "STORE_ID, " +
                "STORE_NAME, " +
                "IMPORTER_ID, " +
                "IMPORTER_NAME, " +
                "PROGRAMME_ID, " +
                "PROGRAMME_NAME, " +
                "COLOR_ID, " +
                "COLOR_NAME, " +
                "PARTICULAR_NAME, " +
                "STYLE_ID, " +
                "STYLE_NO, " +
                "ART_NO, " +
                "QUANTITY, " +
                "ZIPPER_RATE, " +
                "CURRENCY_ID, " +
                "CURRENCY_NAME, " +
                "MEASURE_ID, " +
                "MEASURE_NAME, " +
                "ZIPPER_LENGTH " +




                  "FROM VEW_SEARCH_ZIP_RECEIVE_ENTRY WHERE INVOICE_NO = '" + objFabricIssueDTO.InvoiceNo + "' AND head_office_id = '" + objFabricIssueDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objFabricIssueDTO.BranchOfficeId + "'  ";






            if (objFabricIssueDTO.ReceiveDate.Length > 6)
            {

                sql = sql + "and RECEIVE_DATE = TO_DATE('" + objFabricIssueDTO.ReceiveDate + "','dd/mm/yyyy' )";
            }




            sql = sql + "order by SL ";

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
        public DataTable searchFabricReceive(FabricIssueDTO objFabricIssueDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +


                   "PI_NO, " +
                   "PO_NO, " +
                   "PROGRAMME_ID, " +
                   "COLOR_ID, " +
                   "MEASURE_ID, " +
                   "CURRENCY_ID, " +
                   "PO_QUANTITY, " +
                   "TOTAL_RECEIVE_QUANTITY, " +
                   "QUANTITY_NEW, " +
                   "RATE, " +
                   "UPDATE_BY, " +
                   "UPDATE_DATE, " +
                   "HEAD_OFFICE_ID, " +
                   "BRANCH_OFFICE_ID, " +
                   "RECEIVE_DATE, " +
                   "CHALLAN_NO, " +
                   "FABRIC_ID, " +
                   "FABRIC_CONSTRUCTION_ID, " +
                   "SUPPLIER_ID, " +
                   "AMOUNT, " +
                   "QUANTITY " +


                  "FROM VEW_SEARCH_FABRIC_RECEIVE WHERE head_office_id = '" + objFabricIssueDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objFabricIssueDTO.BranchOfficeId + "'  ";



            if (objFabricIssueDTO.ReferenceNo.Length > 0)
            {

                sql = sql + "and REFERENCE_NO = '" + objFabricIssueDTO.ReferenceNo + "'";
            }



            if (objFabricIssueDTO.ChallanNo.Length > 0)
            {

                sql = sql + "and CHALLAN_NO = '" + objFabricIssueDTO.ChallanNo + "'";
            }


            if (objFabricIssueDTO.SupplierId.Length > 0)
            {

                sql = sql + "and SUPPLIER_ID = '" + objFabricIssueDTO.SupplierId + "'";
            }


            if (objFabricIssueDTO.ReceiveDate.Length > 6)
            {

                sql = sql + "and RECEIVE_DATE = TO_DATE('" + objFabricIssueDTO.ReceiveDate + "','dd/mm/yyyy' )";
            }



            if (objFabricIssueDTO.FabricConstructionId.Length > 0)
            {

                sql = sql + "and FABRIC_CONSTRUCTION_ID ='" + objFabricIssueDTO.FabricConstructionId + "'";
            }


            if (objFabricIssueDTO.FabricId.Length > 0)
            {

                sql = sql + "and FABRIC_ID ='" + objFabricIssueDTO.FabricId + "'";
            }


            //sql = sql + "order by SL ";

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
        public DataTable searchFabricReceiveFromPI(FabricIssueDTO objFabricIssueDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +

                  "REFERENCE_NO, " +
                   "PI_NO, " +
                   "PO_NO, " +
                   "PROGRAMME_ID, " +
                   "COLOR_ID, " +
                   "MEASURE_ID, " +
                   "CURRENCY_ID, " +
                   "BLANCE, " +
                   "QUANTITY TOTAL_RECEIVE_QUANTITY, " +
                   "RATE ," +
                   "RECEIVE_QUANTITY, " +
                   "QUANTITY " +




                  "FROM VEW_SEARCH_FABRIC_RECEIVE_PI WHERE head_office_id = '" + objFabricIssueDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objFabricIssueDTO.BranchOfficeId + "'  ";






            if (objFabricIssueDTO.PO.Length > 0)
            {

                sql = sql + "and PO_NO = '" + objFabricIssueDTO.PO + "'";
            }




            //sql = sql + "order by SL ";

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
        public DataTable searchFabricRecePI(FabricIssueDTO objFabricIssueDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +

                  "to_char(NVL(REFERENCE_NO,'0'))REFERENCE_NO, " +
                   "to_char(NVL(PI_NO,'0'))PI_NO, " +
                   "to_char(NVL(PO_NO,'0'))PO_NO, " +
                   "to_char(NVL(PROGRAMME_ID,'0'))PROGRAMME_ID, " +
                   "to_char(NVL(COLOR_ID,'0'))COLOR_ID, " +
                   "to_char(NVL(MEASURE_ID,'0'))MEASURE_ID, " +
                   "to_char(NVL(CURRENCY_ID,'0'))CURRENCY_ID, " +
                   "to_char(NVL(PO_QUANTITY,'0'))PO_QUANTITY, " +
                   "to_char(NVL(TOTAL_RECEIVE_QUANTITY,'0'))TOTAL_RECEIVE_QUANTITY, " +
                   "to_char(NVL(RATE,'0'))RATE, " +
                   "to_char(NVL(RECEIVE_QUANTITY,'0'))RECEIVE_QUANTITY, " +
                   "to_char(NVL(QUANTITY,'0'))QUANTITY, " +
                   "to_char(NVL(quantity_new,'0'))quantity_new " +




                  "FROM VEW_SEARCH_FAB_RECEIVE_PI WHERE head_office_id = '" + objFabricIssueDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objFabricIssueDTO.BranchOfficeId + "'  ";








            if (objFabricIssueDTO.PO.Length > 0)
            {

                sql = sql + "and PO_NO = '" + objFabricIssueDTO.PO + "'";
            }




            //sql = sql + "order by SL ";

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
        public DataTable searchFabricReceiveFromSupplier(FabricIssueDTO objFabricIssueDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +

                  "to_char(NVL(REFERENCE_NO,'0'))REFERENCE_NO, " +
                   "to_char(NVL(PI_NO,'0'))PI_NO, " +
                   "to_char(NVL(PO_NO,'0'))PO_NO, " +
                   "to_char(NVL(PROGRAMME_ID,'0'))PROGRAMME_ID, " +
                   "to_char(NVL(COLOR_ID,'0'))COLOR_ID, " +
                   "to_char(NVL(MEASURE_ID,'0'))MEASURE_ID, " +
                   "to_char(NVL(CURRENCY_ID,'0'))CURRENCY_ID, " +
                   "to_char(NVL(PO_QUANTITY,'0'))PO_QUANTITY, " +
                   "to_char(NVL(TOTAL_RECEIVE_QUANTITY,'0'))TOTAL_RECEIVE_QUANTITY, " +
                   "to_char(NVL(RATE,'0'))RATE, " +

                   "to_char(NVL(QUANTITY,'0'))QUANTITY, " +
                   "to_char(NVL(quantity_new,'0'))quantity_new " +




                  "FROM VEW_SEARCH_FABRIC_RECEIVE WHERE head_office_id = '" + objFabricIssueDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objFabricIssueDTO.BranchOfficeId + "'  ";








            if (objFabricIssueDTO.PO.Length > 0)
            {

                sql = sql + "and PO_NO = '" + objFabricIssueDTO.PO + "'";
            }

            if (objFabricIssueDTO.PI.Length > 0)
            {

                sql = sql + "and PI_NO = '" + objFabricIssueDTO.PI + "'";
            }

            if (objFabricIssueDTO.ChallanNo.Length > 0)
            {

                sql = sql + "and CHALLAN_NO = '" + objFabricIssueDTO.ChallanNo + "'";
            }


            //sql = sql + "order by SL ";

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
        public DataTable searchZipperReceiveSub(FabricIssueDTO objFabricIssueDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +

                   "to_char(NVL(PROGRAMME_ID,'0'))PROGRAMME_ID, " +
                   "to_char(NVL(STYLE_ID,'0'))STYLE_ID, " +
                   "to_char(NVL(COLOR_ID,'0'))COLOR_ID, " +
                  "to_char(NVL(ART_NO,'0'))ART_NO, " +
                  "to_char(NVL(ZIPPER_LENGTH,'0'))ZIPPER_LENGTH, " +
                   "to_char(NVL(MEASURE_ID,'0'))MEASURE_ID, " +
                   "to_char(NVL(QUANTITY,'0'))QUANTITY, " +
                   "to_char(NVL(CURRENCY_ID,'0'))CURRENCY_ID, " +
                   "to_char(NVL(ZIPPER_RATE,'0'))ZIPPER_RATE " +




                  "FROM VEW_SEARCH_ZIP_RECEIVE_ENTRY WHERE INVOICE_NO = '" + objFabricIssueDTO.InvoiceNo + "'  AND head_office_id = '" + objFabricIssueDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objFabricIssueDTO.BranchOfficeId + "'  ";



            if (objFabricIssueDTO.ReceiveDate.Length > 6)
            {

                sql = sql + "and RECEIVE_DATE = TO_DATE('" + objFabricIssueDTO.ReceiveDate + "','dd/mm/yyyy' )";
            }





            //sql = sql + "order by SL ";

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
        public DataTable searchFabricReceiveEntry(FabricIssueDTO objFabricIssueDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
                  "SL, " +
                  "REFERENCE_NO, " +
                   "PI_NO, " +
                   "PO_NO, " +
                   "PROGRAMME_ID, " +
                   "PROGRAMME_NAME, " +
                   "COLOR_ID, " +
                   "COLOR_NAME, " +
                   "MEASURE_ID, " +
                   "MEASURE_NAME, " +
                   "CURRENCY_ID, " +
                   "CURRENCY_NAME, " +
                   "QUANTITY, " +
                   "TOTAL_RECEIVE_QUANTITY, " +
                   "QUANTITY_NEW, " +
                   "RATE, " +
                   "TO_CHAR(RECEIVE_DATE, 'dd/mm/yyyy')RECEIVE_DATE, " +
                   "CHALLAN_NO, " +
                   "FABRIC_ID, " +
                   "FABRIC_NAME, " +
                   "FABRIC_CONSTRUCTION_ID, " +
                   "FABRIC_CONSTRUCTION, " +
                   "SUPPLIER_ID, " +
                   "SUPPLIER_NAME, " +
                   "AMOUNT " +




                  "FROM VEW_SEARCH_FABRIC_RECEIVE WHERE head_office_id = '" + objFabricIssueDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objFabricIssueDTO.BranchOfficeId + "'  ";






            if (objFabricIssueDTO.PO.Length > 0)
            {

                sql = sql + "and PO_NO = '" + objFabricIssueDTO.PO + "'";
            }




            //sql = sql + "order by SL ";

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
        public DataTable searchFabricAcceptanceMain(FabricIssueDTO objFabricIssueDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +


                    "PI_NO, " +
                    "PO_NO, " +
                    "PROGRAMME_ID, " +
                    "FABRIC_ID, " +
                    "FABRIC_CONSTRUCTION_ID, " +
                    "COLOR_ID, " +
                    "UNIT_ID, " +
                    "QUANTITY, " +
                    "PO_QUANTITY, " +
                    "BLANCE_QUANTITY, " +
                    "RATE_IN_DOLLAR, " +
                    "RATE_IN_TAKA " +




                  "FROM VEW_LOCAL_FAB_ACCEPTANCE_SUB WHERE head_office_id = '" + objFabricIssueDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objFabricIssueDTO.BranchOfficeId + "'  ";





            if (objFabricIssueDTO.AcceptanceDate.Length > 6)
            {

                sql = sql + "and ACCEPTANCE_DATE = TO_DATE('" + objFabricIssueDTO.AcceptanceDate + "','dd/mm/yyyy' )";
            }



            if (objFabricIssueDTO.ChallanNo.Length > 0)
            {

                sql = sql + "and CHALLAN_NO ='" + objFabricIssueDTO.ChallanNo + "'";
            }




            //sql = sql + "order by SL ";

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
        public DataTable searchFabricAcceptanceFromReceive(FabricIssueDTO objFabricIssueDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
                   "SL, " +
                   "REFERENCE_NO, " +
                   "PI_NO, " +
                   "PO_NO, " +
                   "to_char(NVL(PROGRAMME_ID, '0'))PROGRAMME_ID, " +
                   "PROGRAMME_NAME, " +
                   "to_char(NVL(COLOR_ID, '0'))COLOR_ID, " +
                   "COLOR_NAME, " +
                   "to_char(NVL(MEASURE_ID, '0'))MEASURE_ID, " +
                   "MEASURE_NAME, " +
                   "to_char(NVL(CURRENCY_ID, '0'))CURRENCY_ID, " +
                   "CURRENCY_NAME, " +
                   "to_char(NVL(PO_QUANTITY, '0'))PO_QUANTITY, " +
                   "TOTAL_RECEIVE_QUANTITY, " +
                   "QUANTITY_NEW, " +
                   "RATE, " +
                   "RECEIVE_DATE, " +
                   "CHALLAN_NO, " +
                   "to_char(NVL(FABRIC_ID, '0'))FABRIC_ID, " +
                   "FABRIC_NAME, " +
                   "to_char(NVL(FABRIC_CONSTRUCTION_ID, '0'))FABRIC_CONSTRUCTION_ID, " +
                   "FABRIC_CONSTRUCTION, " +
                   "to_char(NVL(SUPPLIER_ID, '0'))SUPPLIER_ID, " +
                   "SUPPLIER_NAME, " +
                   "AMOUNT, " +
                   "to_char(NVL(PO_BLANCE,'0'))PO_BLANCE, " +
                   "to_char(NVL(QUANTITY,'0'))QUANTITY, " +
                   "RATE_IN_DOLLAR, " +
                   "RATE_IN_TAKA " +



                  "FROM VEW_SEARCH_FABRIC_REC_FOR_ACCP WHERE head_office_id = '" + objFabricIssueDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objFabricIssueDTO.BranchOfficeId + "'  ";



            if (objFabricIssueDTO.PO.Length > 0)
            {

                sql = sql + "and PO_NO = '" + objFabricIssueDTO.PO + "'";
            }





            if (objFabricIssueDTO.FromDate.Length > 6 && objFabricIssueDTO.ToDate.Length > 6)
            {

                sql = sql + "and RECEIVE_DATE = TO_DATE('" + objFabricIssueDTO.AcceptanceDate + "','dd/mm/yyyy' )";
            }






            //sql = sql + "order by SL ";

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
        public DataTable searchFabricIssue(FabricIssueDTO objFabricIssueDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +

               "TRAN_ID,  " +
               "CHALLAN_NO, " +
               "to_char(nvl(PROGRAMME_ID, '0'))PROGRAMME_ID, " +
               "to_char(nvl(COLOR_ID,'0'))COLOR_ID, " +
               "to_char(nvl(UNIT_ID,'0'))UNIT_ID, " +

               "to_char(nvl(BALANCE_QUANTITY, '0'))BALANCE_QUANTITY, " +
               "to_char(nvl(QUANTITY,'0'))QUANTITY, " +
               "to_char(nvl(FABRIC_ID,'0'))FABRIC_ID, " +
               "to_char(nvl(FABRIC_CONSTRUCTION_ID,'0'))FABRIC_CONSTRUCTION_ID, " +
               "to_char(nvl(RATE,'0'))RATE " +




                  "FROM vew_LOCAL_FABRIC_ISSUE_SUB WHERE head_office_id = '" + objFabricIssueDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objFabricIssueDTO.BranchOfficeId + "'  ";



            if (objFabricIssueDTO.IssueDate.Length > 6)
            {

                sql = sql + "and ISSUE_DATE = TO_DATE('" + objFabricIssueDTO.IssueDate + "','dd/mm/yyyy' )";
            }



            if (objFabricIssueDTO.ChallanNo.Length > 0)
            {

                sql = sql + "and CHALLAN_NO ='" + objFabricIssueDTO.ChallanNo + "'";
            }




            //sql = sql + "order by SL ";

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
        public DataTable searchFabricIssueEntry(FabricIssueDTO objFabricIssueDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
               "ROWNUM SL, " +
               "REFERENCE_NO, " +
               "CHALLAN_NO, " +
               "PROGRAMME_ID, " +
               "PROGRAMME_NAME, " +
               "COLOR_ID, " +
               "COLOR_NAME, " +
               "MEASURE_ID, " +
               "MEASURE_NAME, " +
               "CURRENCY_ID, " +
               "CURRENCY_NAME, " +
               "BLANCE, " +
               "QUANTITY, " +
               "RATE, " +
               "ISSUE_DATE, " +
               "STORE_ID, " +
               "STORE_NAME, " +
               "SUPPLIER_ID, " +
               "SUPPLIER_NAME, " +
               "RETURN_FROM_STORE_YN, " +
               "UPDATE_BY, " +
               "UPDATE_DATE, " +
               "HEAD_OFFICE_ID, " +
               "BRANCH_OFFICE_ID, " +
               "FABRIC_ID, " +
               "fabric_name, " +
               "FABRIC_CONSTRUCTION_ID, " +
               "fabric_construction " +



                  "FROM vew_search_fabric_issue WHERE head_office_id = '" + objFabricIssueDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objFabricIssueDTO.BranchOfficeId + "'  ";









            if (objFabricIssueDTO.ChallanNo.Length > 0)
            {

                sql = sql + "and CHALLAN_NO ='" + objFabricIssueDTO.ChallanNo + "'";
            }




            //sql = sql + "order by SL ";

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

        public FabricIssueDTO searchForeignFabricMain(string strChalanNo, string strIssueDate, string strHeadOfficeId, string strBranchOfficeId)
        {

            FabricIssueDAL objFabricIssueDAL = new FabricIssueDAL();
            FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();

            //string strYN = "";
            //string sql = "";
            //sql = "SELECT 'Y'  FROM FOREIGN_FABRIC_ISSUE_MAIN WHERE  INVOICE_NO = '" + strInvoiceNo + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID ='" + strBranchOfficeId + "' AND RECEIVE_DATE = to_date('" + strReceiveDate + "', 'dd/mm/yyyy') ";




            //OracleCommand objCommand = new OracleCommand(sql);
            //OracleDataReader objDataReader;

            //using (OracleConnection strConn = GetConnection())
            //{

            //    objCommand.Connection = strConn;
            //    strConn.Open();
            //    objDataReader = objCommand.ExecuteReader();
            //    try
            //    {
            //        while (objDataReader.Read())
            //        {

            //            strYN = objDataReader.GetString(0);
                        


            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        throw new Exception("Error : " + ex.Message);

            //    }

            //    finally
            //    {

            //        strConn.Close();
            //    }


            //}

            //if(strYN== "Y")
            //{
                string sql1 = "";
                sql1 = "SELECT " +


                      "TO_CHAR (NVL (STORE_ID, '0')), " +
                      "TO_CHAR (NVL (SUPPLIER_ID, '0')) " +

                      

                      "FROM VEW_FOREIGN_FABRIC_ISSUE_MAIN WHERE  CHALLAN_NO = '" + strChalanNo + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID ='" + strBranchOfficeId + "' AND ISSUE_DATE = to_date('" + strIssueDate + "', 'dd/mm/yyyy') ";




                OracleCommand objCommand1 = new OracleCommand(sql1);
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

                            objFabricIssueDTO.StoreId = objDataReader1.GetString(0);
                            objFabricIssueDTO.SupplierId = objDataReader1.GetString(1);
                           

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


            //}
            //else
            //{

            //    string sql2 = "";
            //    sql2 = "SELECT " +


            //          "TO_CHAR (NVL (STORE_ID, '0')), " +
            //          "TO_CHAR (NVL (SUPPLIER_ID, '0')) " +


            //          "FROM FOREIGN_FABRIC_RECEIVE_MAIN WHERE  INVOICE_NO = '" + strInvoiceNo + "' AND HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID ='" + strBranchOfficeId + "' AND RECEIVE_DATE = to_date('" + strReceiveDate + "', 'dd/mm/yyyy') ";




            //    OracleCommand objCommand2 = new OracleCommand(sql2);
            //    OracleDataReader objDataReader2;

            //    using (OracleConnection strConn = GetConnection())
            //    {

            //        objCommand2.Connection = strConn;
            //        strConn.Open();
            //        objDataReader2 = objCommand2.ExecuteReader();
            //        try
            //        {
            //            while (objDataReader2.Read())
            //            {

            //                objFabricIssueDTO.StoreId = objDataReader2.GetString(0);
            //                objFabricIssueDTO.SupplierId = objDataReader2.GetString(1);


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

            //}



           

            return objFabricIssueDTO;

        }
        public FabricIssueDTO searchLocalFabricAcceptanceSub(string strChalanNo, string strAcceptanceDate, string strHeadOfficeId, string strBranchOfficeId)
        {

            FabricIssueDAL objFabricIssueDAL = new FabricIssueDAL();
            FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();

            string sql = "";
            sql = "SELECT " +


                   "to_char(NVL(DELIVERY_NO,0))DELIVERY_NO, " +
                    "to_char(NVL(LC_NO,0))LC_NO " +


                  "FROM VEW_LOCAL_FAB_ACCEPTANCE_MAIN WHERE  HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID ='" + strBranchOfficeId + "' ";

            if (strChalanNo.Length > 0)
            {

                sql = sql + " and CHALLAN_NO = '" + strChalanNo + "' ";

            }

            if (strAcceptanceDate.Length > 6)
            {

                sql = sql + " and ACCEPTANCE_DATE = TO_DATE('" + strAcceptanceDate + "', 'dd/mm/yyyy') ";

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

                        objFabricIssueDTO.DeliveryNo = objDataReader.GetString(0);
                        objFabricIssueDTO.ChallanNo = objDataReader.GetString(1);


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

            return objFabricIssueDTO;

        }
        public FabricIssueDTO searchDNNo(string strPoNo, string strChallanNo, string strPINo, string strHeadOfficeId, string strBranchOfficeId)
        {

            FabricIssueDAL objFabricIssueDAL = new FabricIssueDAL();
            FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();

            string sql = "";
            sql = "SELECT " +

                   "to_char(NVL(LC_NO,0))LC_NO, " +
                   "to_char(NVL(DELIVERY_NO,0))DELIVERY_NO, " +
                    "TO_CHAR(ACCEPTANCE_DATE, 'dd/mm/yyyy')ACCEPTANCE_DATE " +

                  "FROM VEW_SEARCH_FABRIC_ACCEPTANCE WHERE   HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID ='" + strBranchOfficeId + "' ";

            if (strPoNo.Length > 0)
            {

                sql = sql + "and PO_NO = '" + strPoNo + "'";
            }

            if (strChallanNo.Length > 0)
            {

                sql = sql + "and CHALLAN_NO_MAIN = '" + strChallanNo + "'";
            }

            if (strPINo.Length > 0)
            {

                sql = sql + "and PI_NO = '" + strPINo + "'";
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

                        objFabricIssueDTO.LcNo = objDataReader.GetString(0);
                        objFabricIssueDTO.DeliveryNo = objDataReader.GetString(1);
                        objFabricIssueDTO.AcceptanceDate = objDataReader.GetString(2);

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

            return objFabricIssueDTO;

        }
        public FabricIssueDTO searchFabricInfoPI(string strPONo, string strPINo, string strReceiveDate, string strHeadOfficeId, string strBranchOfficeId)
        {

            FabricIssueDAL objFabricIssueDAL = new FabricIssueDAL();
            FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();

            string sql = "";
            sql = "SELECT " +


                  "TO_CHAR (NVL (REFERENCE_NO, '0')), " +
                  "NVL (TO_CHAR (RECEIVE_DATE, 'dd/mm/yyyy'), ' '), " +
                  "TO_CHAR (NVL (PI_NO, '0')), " +
                  "TO_CHAR (NVL (SUPPLIER_ID, '0')), " +
                  "TO_CHAR (NVL (PO_NO, '0')) " +



                  "FROM vew_search_fabric_receive_pi WHERE  HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID ='" + strBranchOfficeId + "' ";


            if (strPONo.Length > 0)
            {

                sql = sql + " and PO_NO = '" + strPONo + "'  ";
            }

            if (strPINo.Length > 0)
            {

                sql = sql + " and PI_NO = '" + strPINo + "'  ";
            }


            if (strReceiveDate.Length > 6)
            {

                sql = sql + " and receive_date = to_date('" + strReceiveDate + "', 'dd/mm/yyyy')";
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

                        objFabricIssueDTO.ReferenceNo = objDataReader.GetString(0);
                        objFabricIssueDTO.ReceiveDate = objDataReader.GetString(1);
                        objFabricIssueDTO.PI = objDataReader.GetString(2);
                        objFabricIssueDTO.SupplierId = objDataReader.GetString(3);
                        objFabricIssueDTO.PO = objDataReader.GetString(4);
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

            return objFabricIssueDTO;

        }
        public FabricIssueDTO searchZipperInfo(string strChallanNo, string strIssueDate, string strHeadOfficeId, string strBranchOfficeId)
        {

            FabricIssueDAL objFabricIssueDAL = new FabricIssueDAL();
            FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();

            string sql = "";
            sql = "SELECT " +


                  "TO_CHAR (NVL (STORE_ID, '0')), " +
                  "NVL (TO_CHAR (ISSUE_DATE, 'dd/mm/yyyy'), ' '), " +
                  "TO_CHAR (NVL (SUPPLIER_ID, '0')) " +




                  "FROM VEW_SEARCH_ZIPPER_ISSUE_ENTRY WHERE  HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID ='" + strBranchOfficeId + "' AND challan_no = '" + strChallanNo + "' ";


            if (strChallanNo.Length > 0)
            {

                sql = sql + " and CHALLAN_NO = '" + strChallanNo + "'  ";
            }

            if (strIssueDate.Length > 6)
            {

                sql = sql + " and ISSUE_DATE = to_date('" + strIssueDate + "', 'dd/mm/yyyy')";
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

                        objFabricIssueDTO.StoreId = objDataReader.GetString(0);
                        objFabricIssueDTO.IssueDate = objDataReader.GetString(1);
                        objFabricIssueDTO.SupplierId = objDataReader.GetString(2);

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

            return objFabricIssueDTO;

        }
        public FabricIssueDTO searchZipperReceiveRecord(string strInvoiceNo, string strReceiveDate, string strHeadOfficeId, string strBranchOfficeId)
        {

            FabricIssueDAL objFabricIssueDAL = new FabricIssueDAL();
            FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();

            string sql = "";
            sql = "SELECT " +
                  "NVL (TO_CHAR (RECEIVE_DATE, 'dd/mm/yyyy'), ' '), " +
                  "TO_CHAR (NVL (BACK_TO_BACK_LC_NO, '0')), " +
                  "TO_CHAR (NVL (AIR_CHALLAN_NO, '0')), " +
                  "TO_CHAR (NVL (CONTACT_NO, '0')), " +
                   "TO_CHAR (NVL (IMPORTER_ID, '0')), " +
                  "TO_CHAR (NVL (STORE_ID, '0')), " +
                  "TO_CHAR (NVL (BUYER_ID, '0')), " +
                  "TO_CHAR (NVL (SUPPLIER_ID, '0')), " +
                 "TO_CHAR (NVL (HAND_CARRY_YN, '0')), " +
                 "TO_CHAR (NVL (PARTICULAR_NAME, 'N/A')) " +



                  "FROM vew_search_zipper_entry WHERE INVOICE_NO ='" + strInvoiceNo + "'    AND  HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID ='" + strBranchOfficeId + "' ";



            if (strReceiveDate.Length > 6)
            {

                sql = sql + " and receive_date = to_date('" + strReceiveDate + "', 'dd/mm/yyyy')";
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


                        objFabricIssueDTO.ReceiveDate = objDataReader.GetString(0);
                        objFabricIssueDTO.LcNo = objDataReader.GetString(1);
                        objFabricIssueDTO.AirChallanNo = objDataReader.GetString(2);
                        objFabricIssueDTO.ContactNo = objDataReader.GetString(3);
                        objFabricIssueDTO.ImporterId = objDataReader.GetString(4);
                        objFabricIssueDTO.StoreId = objDataReader.GetString(5);
                        objFabricIssueDTO.BuyerId = objDataReader.GetString(6);
                        objFabricIssueDTO.SupplierId = objDataReader.GetString(7);
                        objFabricIssueDTO.HandCarryYn = objDataReader.GetString(8);
                        objFabricIssueDTO.ParticularName = objDataReader.GetString(9);
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

            return objFabricIssueDTO;

        }

        public FabricIssueDTO searchFabricReceEntry(string strChallanNo, string strReceiveDate, string strHeadOfficeId, string strBranchOfficeId)
        {

            FabricIssueDAL objFabricIssueDAL = new FabricIssueDAL();
            FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();

            string sql = "";
            sql = "SELECT " +


                  "TO_CHAR (NVL (REFERENCE_NO, '0')), " +
                  "NVL (TO_CHAR (RECEIVE_DATE, 'dd/mm/yyyy'), ' '), " +
                  "TO_CHAR (NVL (FABRIC_CONSTRUCTION_ID, '0')), " +
                  "TO_CHAR (NVL (FABRIC_ID, '0')), " +
                  "TO_CHAR (NVL (SUPPLIER_ID, '0')), " +
                   "TO_CHAR (NVL (AMOUNT, '0')), " +
                    "TO_CHAR (NVL (CHALLAN_NO, '0')) " +



                  "FROM VEW_SEARCH_FABRIC_RECEIVE WHERE  HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID ='" + strBranchOfficeId + "' ";


            if (strChallanNo.Length > 0)
            {

                sql = sql + " and CHALLAN_NO = '" + strChallanNo + "'  ";
            }

            if (strReceiveDate.Length > 6)
            {

                sql = sql + " and receive_date = to_date('" + strReceiveDate + "', 'dd/mm/yyyy')";
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

                        objFabricIssueDTO.ReferenceNo = objDataReader.GetString(0);
                        objFabricIssueDTO.ReceiveDate = objDataReader.GetString(1);
                        objFabricIssueDTO.FabricConstructionId = objDataReader.GetString(2);
                        objFabricIssueDTO.FabricId = objDataReader.GetString(3);
                        objFabricIssueDTO.SupplierId = objDataReader.GetString(4);
                        objFabricIssueDTO.RateInTaka = objDataReader.GetString(5);
                        objFabricIssueDTO.ChallanNo = objDataReader.GetString(6);
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

            return objFabricIssueDTO;

        }

        public FabricIssueDTO searchFabrciReceiveSupp(string strChallanNo, string strPONo, string strPINo, string strReceiveDate, string strHeadOfficeId, string strBranchOfficeId)
        {

            FabricIssueDAL objFabricIssueDAL = new FabricIssueDAL();
            FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();

            string sql = "";
            sql = "SELECT " +


                  "'Y' " +


                  "FROM VEW_SEARCH_FABRIC_RECEIVE WHERE  HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID ='" + strBranchOfficeId + "' ";


            if (strPONo.Length > 0)
            {

                sql = sql + " and PO_NO = '" + strPONo + "'  ";
            }

            if (strPINo.Length > 0)
            {

                sql = sql + " and PI_NO = '" + strPINo + "'  ";
            }


            if (strChallanNo.Length > 0)
            {

                sql = sql + " and CHALLAN_NO = '" + strChallanNo + "'  ";
            }

            if (strReceiveDate.Length > 6)
            {

                sql = sql + " and receive_date = to_date('" + strReceiveDate + "', 'dd/mm/yyyy')";
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

                        objFabricIssueDTO.PI = objDataReader.GetString(0);

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

            return objFabricIssueDTO;

        }


        public FabricIssueDTO searchFabricAcceptanceYn(string strPONo, string strChallanNo, string strPINo, string strHeadOfficeId, string strBranchOfficeId)
        {

            FabricIssueDAL objFabricIssueDAL = new FabricIssueDAL();
            FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();

            string sql = "";
            sql = "SELECT " +


                  "'Y' " +


                  "FROM VEW_SEARCH_FABRIC_ACCEPTANCE WHERE  HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID ='" + strBranchOfficeId + "' ";


            if (strPONo.Length > 0)
            {

                sql = sql + " and PO_NO = '" + strPONo + "'  ";
            }

            if (strPINo.Length > 0)
            {

                sql = sql + " and PI_NO = '" + strPINo + "'  ";
            }


            if (strChallanNo.Length > 0)
            {

                sql = sql + " and CHALLAN_NO = '" + strChallanNo + "'  ";
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

                        objFabricIssueDTO.PI = objDataReader.GetString(0);

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

            return objFabricIssueDTO;

        }


        public FabricIssueDTO searchFabrciReceiveEntryPI(string strChallanNo, string strPONo, string strPINo, string strReceiveDate, string strHeadOfficeId, string strBranchOfficeId)
        {

            FabricIssueDAL objFabricIssueDAL = new FabricIssueDAL();
            FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();

            string sql = "";

            sql = "SELECT " +

                  "TO_CHAR (NVL (FABRIC_CONSTRUCTION_ID, '0')), " +
                  "TO_CHAR (NVL (FABRIC_ID, '0')), " +
                  "TO_CHAR (NVL (SUPPLIER_ID, '0')), " +
                  "NVL (TO_CHAR (RECEIVE_DATE, 'dd/mm/yyyy'), ' '), " +
                  "TO_CHAR (NVL (RATE, '0')) " +



                  "FROM VEW_SEARCH_FAB_RECEIVE_PI WHERE  HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID ='" + strBranchOfficeId + "' ";






            if (strPONo.Length > 0)
            {

                sql = sql + " and PO_NO = '" + strPONo + "'  ";
            }

            if (strPINo.Length > 0)
            {

                sql = sql + " and PI_NO = '" + strPINo + "'  ";
            }


            if (strChallanNo.Length > 0)
            {

                sql = sql + " and CHALLAN_NO = '" + strChallanNo + "'  ";
            }

            if (strReceiveDate.Length > 6)
            {

                sql = sql + " and receive_date = to_date('" + strReceiveDate + "', 'dd/mm/yyyy')";
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

                        objFabricIssueDTO.FabricConstructionId = objDataReader.GetString(0);
                        objFabricIssueDTO.FabricId = objDataReader.GetString(1);
                        objFabricIssueDTO.SupplierId = objDataReader.GetString(2);
                        objFabricIssueDTO.ReceiveDate = objDataReader.GetString(3);
                        objFabricIssueDTO.Amount = objDataReader.GetString(4);


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

            return objFabricIssueDTO;

        }






        public FabricIssueDTO searcLocalFabricReceiveMain(string strChallanNo, string strReceiveDte, string strSupplierId, string strHeadOfficeId, string strBranchOfficeId)
        {


            FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();



            string sql1 = "";

            sql1 = "SELECT " +


              "TO_CHAR (NVL (CHALLAN_NO, '0')), " +
              "TO_CHAR (NVL (SUPPLIER_ID, '0')), " +
              "NVL(TO_CHAR(RECEIVE_DATE, 'dd/mm/yyyy'), ' ')RECEIVE_DATE, " +
               "TO_CHAR (NVL (FABRIC_ID, '0')), " +
                "TO_CHAR (NVL (FABRIC_CONSTRUCTION_ID, '0')) " +


              "from VEW_SEARCH_FABRIC_RECEIVE_MAIN where head_office_id = '" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "' ";



            if (strChallanNo.Length > 0)
            {
                sql1 = sql1 + "and CHALLAN_NO = '" + strChallanNo + "' ";
            }

            if (strReceiveDte.Length > 6)
            {

                sql1 = sql1 + "and RECEIVE_DATE = TO_DATE('" + strReceiveDte + "', 'dd/mm/yyyy') ";
            }

            if (strSupplierId.Length > 6)
            {

                sql1 = sql1 + "and SUPPLIER_ID = '" + strSupplierId + "' ";
            }




            OracleCommand objCommand1 = new OracleCommand(sql1);
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



                        objFabricIssueDTO.ChallanNo = objDataReader1.GetString(0);
                        objFabricIssueDTO.SupplierId = objDataReader1.GetString(1);
                        objFabricIssueDTO.ReceiveDate = objDataReader1.GetString(2);
                        objFabricIssueDTO.FabricId = objDataReader1.GetString(3);
                        objFabricIssueDTO.FabricConstructionId = objDataReader1.GetString(4);


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



            return objFabricIssueDTO;
        }
        public FabricIssueDTO searcLocalFabricIssueMain(string strChallanNo, string strReceiveDte, string strSupplierId, string strStoreId, string strHeadOfficeId, string strBranchOfficeId)
        {


            FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();



            string sql1 = "";

            sql1 = "SELECT " +


              "TO_CHAR (NVL (STORE_ID, '0')), " +
              "TO_CHAR (NVL (SUPPLIER_ID, '0')), " +
               "TO_CHAR (NVL (RETURN_TO_SUPPLIER_YN, '0')) " +

              "from VEW_LOCAL_FABRIC_ISSUE_MAIN where head_office_id = '" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "' ";



            if (strChallanNo.Length > 0)
            {
                sql1 = sql1 + "and CHALLAN_NO = '" + strChallanNo + "' ";
            }

            if (strReceiveDte.Length > 6)
            {

                sql1 = sql1 + "and ISSUE_DATE = TO_DATE('" + strReceiveDte + "', 'dd/mm/yyyy') ";
            }

            if (strSupplierId.Length > 6)
            {

                sql1 = sql1 + "and SUPPLIER_ID = '" + strSupplierId + "' ";
            }

            if (strStoreId.Length > 6)
            {

                sql1 = sql1 + "and STORE_ID = '" + strStoreId + "' ";
            }


            OracleCommand objCommand1 = new OracleCommand(sql1);
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



                        objFabricIssueDTO.StoreId = objDataReader1.GetString(0);
                        objFabricIssueDTO.SupplierId = objDataReader1.GetString(1);
                        objFabricIssueDTO.ReturnToSupplier = objDataReader1.GetString(2);

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



            return objFabricIssueDTO;
        }
        public DataTable searchFabricReceiveSub(FabricIssueDTO objFabricIssueDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
                    "to_char(NVL(TRAN_ID,'0'))TRAN_ID, " +
                    "to_char(NVL(PO_NO,0))PO_NO, " +
                     "to_char(NVL(PI_NO,0))PI_NO, " +
                    "to_char(NVL(PROGRAMME_ID,'0'))PROGRAMME_ID, " +
                    "to_char(NVL(COLOR_ID,'0'))COLOR_ID, " +
                    "to_char(NVL(RECEIVE_QUANTITY,'0'))RECEIVE_QUANTITY, " +
                      "to_char(NVL(TOTAL_RECEIVE_QUANTITY,'0'))TOTAL_RECEIVE_QUANTITY, " +
                    "to_char(NVL(PO_QUANTITY, '0'))PO_QUANTITY, " +
                    "to_char(NVL(UNIT_ID, '0'))UNIT_ID, " +
                    "to_char(NVL(RATE, '0'))RATE, " +
                    "to_char(NVL(CURRENCY_ID, '0'))CURRENCY_ID " +


                   "FROM VEW_SEARCH_FABRIC_RECEIVE_SUB WHERE head_office_id = '" + objFabricIssueDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objFabricIssueDTO.BranchOfficeId + "'  ";





            if (objFabricIssueDTO.ChallanNo.Length > 0)
            {

                sql = sql + "and CHALLAN_NO = '" + objFabricIssueDTO.ChallanNo + "'";
            }


            if (objFabricIssueDTO.SupplierId.Length > 0)
            {

                sql = sql + "and SUPPLIER_ID = '" + objFabricIssueDTO.SupplierId + "'";
            }


            if (objFabricIssueDTO.ReceiveDate.Length > 6)
            {

                sql = sql + "and RECEIVE_DATE = TO_DATE('" + objFabricIssueDTO.ReceiveDate + "','dd/mm/yyyy' )";
            }



            if (objFabricIssueDTO.FabricConstructionId.Length > 0)
            {

                sql = sql + "and FABRIC_CONSTRUCTION_ID ='" + objFabricIssueDTO.FabricConstructionId + "'";
            }


            if (objFabricIssueDTO.FabricId.Length > 0)
            {

                sql = sql + "and FABRIC_ID ='" + objFabricIssueDTO.FabricId + "'";
            }


            //sql = sql + "order by SL ";

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


        public FabricIssueDTO searchForeignLcFabricTotalQty(string strSupplierId, string strProgrammeId, string strHeadOfficeId, string strBranchOfficeId)
        {

            FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();
            //sql = "SELECT NVL(SUM(QUANTITY),0)qty from FOREIGN_FABRIC_RECEIVE where head_office_id = '" + strHeadOfficeId + "' and branch_office_id = '" + strBranchOfficeId + "'  " +
            //    " and buyer_id = '" + strBuyerId + "' and supplier_id = '" + strSupplierId + "' and fabric_id = '" + strFabricId + "' and FABRIC_CONSTRUCTION_ID ='" + strFabricConstructionId + "' " +
            //    " and color_id = '"+strColorId+"' and style_id = '"+strStyleId+"' and art_id = '"+strArtId+"' and importer_id = '"+strImporterId+"' ";
            string sql = "";
            sql = "SELECT NVL(SUM(QUANTITY),0)qty from vew_foreign_fabric_qty where head_office_id = '" + strHeadOfficeId + "' and branch_office_id = '" + strBranchOfficeId + "'  AND PROGRAMME_ID ='" + strProgrammeId + "' and SUPPLIER_ID = '" + strSupplierId + "' ";



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


                        objFabricIssueDTO.ReceiveQuantity = Convert.ToString(objDataReader.GetInt32(0));


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




            return objFabricIssueDTO;
        }
        public FabricIssueDTO searchForeignFabricTotalRcvQty(string strSupplierId, string strProgrammeId, string strFabricId, string strConstructionId, string strStyleId, string strHeadOfficeId, string strBranchOfficeId)
        {

            FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();
            //sql = "SELECT NVL(SUM(QUANTITY),0)qty from FOREIGN_FABRIC_RECEIVE where head_office_id = '" + strHeadOfficeId + "' and branch_office_id = '" + strBranchOfficeId + "'  " +
            //    " and buyer_id = '" + strBuyerId + "' and supplier_id = '" + strSupplierId + "' and fabric_id = '" + strFabricId + "' and FABRIC_CONSTRUCTION_ID ='" + strFabricConstructionId + "' " +
            //    " and color_id = '"+strColorId+"' and style_id = '"+strStyleId+"' and art_id = '"+strArtId+"' and importer_id = '"+strImporterId+"' ";
            string sql = "";
            sql = "SELECT  " +

               " NVL(SUM(ISSUE_QUANTITY),0)ISSUE_QUANTITY, " +
                  " (select NVL(SUM(RECEIVE_QUANTITY),0) from FOREIGN_FABRIC_RECEIVE_SUB where   " +
                  " head_office_id = s.head_office_id and branch_office_id = s.branch_office_id  " +
                 
                  " AND PROGRAMME_ID ='" + strProgrammeId + "' and SUPPLIER_ID = '" + strSupplierId + "')RECEIVE_QUANTITY, " +

                    "ABS( NVL(SUM(ISSUE_QUANTITY),0) - " +
                  " (select NVL(SUM(RECEIVE_QUANTITY),0) from FOREIGN_FABRIC_RECEIVE_SUB where   " +
                  " head_office_id = s.head_office_id and branch_office_id = s.branch_office_id  " +
                
                  " AND PROGRAMME_ID ='" + strProgrammeId + "' and SUPPLIER_ID = '" + strSupplierId + "'))REMAINING_QUANTITY " +



               " from VEW_FOREIGN_FABRIC_ISSUE_SUB s where head_office_id = '" + strHeadOfficeId + "' and branch_office_id = '" + strBranchOfficeId + "'  " +
            
               " AND PROGRAMME_ID ='" + strProgrammeId + "' and SUPPLIER_ID = '" + strSupplierId + "' " +

               " GROUP BY   head_office_id,branch_office_id,PROGRAMME_ID,SUPPLIER_ID ";




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

                        objFabricIssueDTO.IssueQuantity = Convert.ToString(objDataReader.GetInt32(0));
                        objFabricIssueDTO.ReceiveQuantity = Convert.ToString(objDataReader.GetInt32(1));
                        objFabricIssueDTO.RemainingQuantity = Convert.ToString(objDataReader.GetInt32(2));

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




            return objFabricIssueDTO;
        }
        public FabricIssueDTO searchSingleQty(string strSupplierId, string strProgrammeId, string strFabricId, string strConstructionId, string strStyleId, string strArtId, string strColorId, string strUnitId, string strHeadOfficeId, string strBranchOfficeId)
        {

            FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();
            string sql = "SELECT NVL(SUM(RECEIVE_QUANTITY),0)qty from VEW_FOREIGN_FAB_RECEIVE_SUB where head_office_id = '" + strHeadOfficeId + "' and branch_office_id = '" + strBranchOfficeId + "'  " +
                " and supplier_id = '" + strSupplierId + "' and fabric_id = '" + strFabricId + "' and FABRIC_CONSTRUCTION_ID ='" + strConstructionId + "' " +
                " and color_id = '" + strColorId + "' and style_id = '" + strStyleId + "' and art_id = '" + strArtId + "'  and programme_id = '"+strProgrammeId+"' and unit_id ='"+strUnitId+"' ";





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

                      
                        objFabricIssueDTO.ReceiveQuantity = Convert.ToString(objDataReader.GetInt32(0));
                     

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




            return objFabricIssueDTO;
        }


        public DataTable SearchForeignfabricIssue(FabricIssueDTO objFabricIssueDTO)
        {


            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
               "TO_CHAR(ISSUE_DATE,'DD/MM/YYYY')ISSUE_DATE, " +
              "TRAN_ID, " +
   "CHALLAN_NO, " +

   "SUPPLIER_ID, " +
   "SUPPLIER_NAME, " +

   "PROGRAMME_ID, " +
   "PROGRAMME_NAME, " +
   "FABRIC_ID, " +
   "FABRIC_NAME, " +
   "FABRIC_CONSTRUCTION_ID, " +
   "FABRIC_CONSTRUCTION_NAME, " +
   "STYLE_ID, " +
   "STYLE_NO, " +
   "COLOR_ID, " +
   "COLOR_NAME, " +
   "ART_ID, " +
   "ART_NO, " +
    "ISSUE_QUANTITY, " +
   "STORE_NAME " +

  





               " FROM VEW_FOREIGN_FABRIC_ISSUE_SUB where head_office_id = '" + objFabricIssueDTO.HeadOfficeId + "' and branch_office_id = '" + objFabricIssueDTO.BranchOfficeId + "'  ";

            if (objFabricIssueDTO.IssueYear.Length > 0)
            {


                sql = sql + " and TO_CHAR(ISSUE_DATE, 'YYYY') = '" + objFabricIssueDTO.IssueYear + "'  ";

            }


            if (objFabricIssueDTO.ChallanNo.Length > 0)
            {


                sql = sql + " and CHALLAN_NO = '" + objFabricIssueDTO.ChallanNo + "'  ";

            }

            if (objFabricIssueDTO.StyleId.Length > 0)
            {


                sql = sql + " and STYLE_NO = '" + objFabricIssueDTO.StyleId + "' ";

            }

            if (objFabricIssueDTO.SupplierId.Length > 0)
            {


                sql = sql + " and Supplier_id = '" + objFabricIssueDTO.SupplierId + "' ";

            }

            if (objFabricIssueDTO.ProgrammeId.Length > 0)
            {


                sql = sql + " and PROGRAMME_ID = '" + objFabricIssueDTO.ProgrammeId + "' ";

            }

            if (objFabricIssueDTO.ArtId.Length > 0)
            {


                sql = sql + " and ART_ID = '" + objFabricIssueDTO.ArtId + "' ";

            }

            if (objFabricIssueDTO.FabricId.Length > 0)
            {


                sql = sql + " and FABRIC_ID = '" + objFabricIssueDTO.FabricId + "' ";

            }

            if (objFabricIssueDTO.FabricConstructionId.Length > 0)
            {


                sql = sql + " and FABRIC_CONSTRUCTION_ID = '" + objFabricIssueDTO.FabricConstructionId + "' ";

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




    }

}

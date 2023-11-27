using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SINHA.MEDLAR.ERP.DTO;

using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Configuration;

namespace SINHA.MEDLAR.ERP.DAL
{
    public class PoRequisitionDAL
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

        public string savePoRequisitionInfo(PoRequisitionDTO objPoRequisitionDTO)
        {

            PoRequisitionDAL objPoRequisitionDAL = new PoRequisitionDAL();

            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("PRO_PO_REQUISITION_SAVE");
            objOracleCommand.CommandType = CommandType.StoredProcedure;
            
            if (objPoRequisitionDTO.RequisitionNo != "")
            {

                objOracleCommand.Parameters.Add("P_REQUISITION_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoRequisitionDTO.RequisitionNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_REQUISITION_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objPoRequisitionDTO.PurchaseDate !="")
            {

                objOracleCommand.Parameters.Add("P_PURCHASE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoRequisitionDTO.PurchaseDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PURCHASE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objPoRequisitionDTO.SectionId != "")
            {

                objOracleCommand.Parameters.Add("P_SECTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoRequisitionDTO.SectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SECTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objPoRequisitionDTO.Discount != "")
            {

                objOracleCommand.Parameters.Add("P_DISCOUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoRequisitionDTO.Discount;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_DISCOUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objPoRequisitionDTO.TotalAmount != "")
            {

                objOracleCommand.Parameters.Add("P_TOTAL_AMOUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoRequisitionDTO.TotalAmount;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_TOTAL_AMOUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }



            if (objPoRequisitionDTO.PartNo != "")
            {

                objOracleCommand.Parameters.Add("P_PART_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoRequisitionDTO.PartNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PART_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objPoRequisitionDTO.PartName != "")
            {

                objOracleCommand.Parameters.Add("P_PARTICULAR_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoRequisitionDTO.PartName;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PARTICULAR_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objPoRequisitionDTO.PoUnitId != "")
            {

                objOracleCommand.Parameters.Add("P_PO_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoRequisitionDTO.PoUnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PO_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objPoRequisitionDTO.PresentStock != "")
            {

                objOracleCommand.Parameters.Add("P_PRESENT_STOCK", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoRequisitionDTO.PresentStock;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PRESENT_STOCK", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objPoRequisitionDTO.RequiredQty != "")
            {

                objOracleCommand.Parameters.Add("P_REQUIRED_QTY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoRequisitionDTO.RequiredQty;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_REQUIRED_QTY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objPoRequisitionDTO.AppearedQty != "")
            {

                objOracleCommand.Parameters.Add("P_APPEARED_QTY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoRequisitionDTO.AppearedQty;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_APPEARED_QTY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objPoRequisitionDTO.Rate != "")
            {

                objOracleCommand.Parameters.Add("P_RATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoRequisitionDTO.Rate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_RATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objPoRequisitionDTO.Price != "")
            {

                objOracleCommand.Parameters.Add("P_PRICE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoRequisitionDTO.Price;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PRICE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }




            if (objPoRequisitionDTO.Remarks != "")
            {

                objOracleCommand.Parameters.Add("P_REMARKS", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoRequisitionDTO.Remarks;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_REMARKS", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;


            }


            if (objPoRequisitionDTO.SLNO != "")
            {

                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoRequisitionDTO.SLNO;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objPoRequisitionDTO.Freight != "")
            {

                objOracleCommand.Parameters.Add("P_FREIGHT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoRequisitionDTO.Freight;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_FREIGHT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objPoRequisitionDTO.TrackingChargeFee != "")
            {

                objOracleCommand.Parameters.Add("P_TRACKING_CHARGE_FEE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoRequisitionDTO.TrackingChargeFee;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_TRACKING_CHARGE_FEE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objPoRequisitionDTO.CurrencyId != "")
            {

                objOracleCommand.Parameters.Add("P_CURRENCY_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoRequisitionDTO.CurrencyId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_CURRENCY_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }



            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoRequisitionDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoRequisitionDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoRequisitionDTO.BranchOfficeId;


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
        //public string processPoRequisitionTotalAmount(PoRequisitionDTO objPoRequisitionDTO)
        //{

        //    PoRequisitionDAL objPoRequisitionDAL = new PoRequisitionDAL();

        //    string strMsg = "";
        //    OracleTransaction trans = null;

        //    OracleCommand objOracleCommand = new OracleCommand("PRO_PO_REQUISITION_UPDATE");
        //    objOracleCommand.CommandType = CommandType.StoredProcedure;

        //    if (objPoRequisitionDTO.RequisitionNo != "")
        //    {

        //        objOracleCommand.Parameters.Add("P_REQUISITION_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoRequisitionDTO.RequisitionNo;
        //    }
        //    else
        //    {
        //        objOracleCommand.Parameters.Add("P_REQUISITION_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //    }
        //    if (objPoRequisitionDTO.PurchaseDate != "")
        //    {

        //        objOracleCommand.Parameters.Add("P_PURCHASE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoRequisitionDTO.PurchaseDate;
        //    }
        //    else
        //    {
        //        objOracleCommand.Parameters.Add("P_PURCHASE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //    }
        //    if (objPoRequisitionDTO.Freight != "")
        //    {

        //        objOracleCommand.Parameters.Add("P_FREIGHT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoRequisitionDTO.Freight;
        //    }
        //    else
        //    {
        //        objOracleCommand.Parameters.Add("P_FREIGHT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //    }
        //    if (objPoRequisitionDTO.Discount != "")
        //    {

        //        objOracleCommand.Parameters.Add("P_DISCOUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoRequisitionDTO.Discount;
        //    }
        //    else
        //    {
        //        objOracleCommand.Parameters.Add("P_DISCOUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //    }
        //    if (objPoRequisitionDTO.TotalAmount != "")
        //    {

        //        objOracleCommand.Parameters.Add("P_TOTAL_AMOUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoRequisitionDTO.TotalAmount;
        //    }
        //    else
        //    {
        //        objOracleCommand.Parameters.Add("P_TOTAL_AMOUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //    }


        //    objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoRequisitionDTO.UpdateBy;
        //    objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoRequisitionDTO.HeadOfficeId;
        //    objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoRequisitionDTO.BranchOfficeId;


        //    objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 1000).Direction = ParameterDirection.Output;

        //    using (OracleConnection strConn = GetConnection())
        //    {
        //        try
        //        {
        //            objOracleCommand.Connection = strConn;
        //            strConn.Open();
        //            trans = strConn.BeginTransaction();
        //            objOracleCommand.ExecuteNonQuery();
        //            trans.Commit();
        //            strConn.Close();
        //            strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
        //        }

        //        catch (Exception ex)
        //        {
        //            throw new Exception("Error : " + ex.Message);
        //            trans.Rollback();
        //        }

        //        finally
        //        {

        //            strConn.Close();

        //        }

        //    }



        //    return strMsg;
        //}
        public string deletePoRequisitionRecord(PoRequisitionDTO objPoRequisitionDTO)
        {

            PoRequisitionDAL objPoRequisitionDAL = new PoRequisitionDAL();

            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("PRO_DELETE_PO_REQUISITION");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objPoRequisitionDTO.RequisitionNo != "")
            {

                objOracleCommand.Parameters.Add("P_REQUISITION_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoRequisitionDTO.RequisitionNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_REQUISITION_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
           
            if (objPoRequisitionDTO.PurchaseDate.Length > 6)
            {

                objOracleCommand.Parameters.Add("P_PURCHASE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoRequisitionDTO.PurchaseDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PURCHASE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoRequisitionDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoRequisitionDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoRequisitionDTO.BranchOfficeId;


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
        public string deletePoRequisitionSubRecord(PoRequisitionDTO objPoRequisitionDTO)
        {

            PoRequisitionDAL objPoRequisitionDAL = new PoRequisitionDAL();

            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("PRO_DELETE_PO_REQUISITION_SUB");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objPoRequisitionDTO.SLNO != "")
            {

                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoRequisitionDTO.SLNO;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objPoRequisitionDTO.RequisitionNo != "")
            {

                objOracleCommand.Parameters.Add("P_REQUISITION_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoRequisitionDTO.RequisitionNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_REQUISITION_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objPoRequisitionDTO.PurchaseDate.Length > 6)
            {

                objOracleCommand.Parameters.Add("P_PURCHASE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoRequisitionDTO.PurchaseDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PURCHASE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objPoRequisitionDTO.SectionId != "")
            {

                objOracleCommand.Parameters.Add("P_SECTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoRequisitionDTO.SectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SECTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoRequisitionDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoRequisitionDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPoRequisitionDTO.BranchOfficeId;


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

        public PoRequisitionDTO searchPoRequisitionRecordMain(string strRequisitionNo,  string strPurchaseDate, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {


            PoRequisitionDTO objPoRequisitionDTO = new PoRequisitionDTO();
            PoRequisitionDAL objPoRequisitionDAL = new PoRequisitionDAL();

            string sql = "";

            sql = "SELECT " +

                  "NVL (TO_CHAR (PURCHASE_DATE, 'dd/mm/yyyy'), '0')PURCHASE_DATE, " +
                  "TO_CHAR (NVL (SECTION_ID, '0'))SECTION_ID, " +
                  "TO_CHAR (NVL (DISCOUNT, '0'))DISCOUNT, " +
                  "TO_CHAR (NVL (TOTAL_AMOUNT, '0'))TOTAL_AMOUNT, " +
                  "TO_CHAR (NVL (FREIGHT, '0'))FREIGHT, " +
                  "TO_CHAR (NVL (TRACKING_CHARGE_FEE, '0'))TRACKING_CHARGE_FEE, " +
                  "TO_CHAR (NVL (TOTAL_PRICE, '0'))TOTAL_PRICE " +

                  " FROM vew_po_requisition_main WHERE   head_office_id = '" + strHeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "' and requisition_no = '" + strRequisitionNo + "'  ";


            if (strPurchaseDate.Length > 6)
            {
                sql = sql + " and  PURCHASE_DATE = TO_DATE('" + strPurchaseDate + "', 'dd/mm/yyyy') ";

            }
  

            if (strSectionId.Length > 0)
            {
                sql = sql + " and section_id = '" + strSectionId + "' ";

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

                      
                        objPoRequisitionDTO.PurchaseDate = objDataReader["PURCHASE_DATE"].ToString();
                        objPoRequisitionDTO.SectionId = objDataReader["SECTION_ID"].ToString();
                        objPoRequisitionDTO.Discount = objDataReader["DISCOUNT"].ToString();
                        objPoRequisitionDTO.TotalAmount = objDataReader["TOTAL_AMOUNT"].ToString();
                        objPoRequisitionDTO.Freight = objDataReader["FREIGHT"].ToString();
                        objPoRequisitionDTO.TrackingChargeFee = objDataReader["TRACKING_CHARGE_FEE"].ToString();
                        objPoRequisitionDTO.TotalPrice = objDataReader["TOTAL_PRICE"].ToString();

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
            return objPoRequisitionDTO;         

        }
        public PoRequisitionDTO getParticularname(string strPartNo, string strHeadOfficeId, string strBranchOfficeId)
        {


            PoRequisitionDTO objPoRequisitionDTO = new PoRequisitionDTO();
            PoRequisitionDAL objPoRequisitionDAL = new PoRequisitionDAL();

            string sql = "";

            sql = "SELECT " +

                "SPARE_PART_CATEGORY_NAME " +

                " FROM L_SPARE_PART_CATEGORY WHERE  SPARE_PART_CATEGORY_NO = '" + strPartNo + "' AND  head_office_id = '" + strHeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "'  ";


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
                        objPoRequisitionDTO.PartName = objDataReader.GetString(0);

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



            return objPoRequisitionDTO;


        }
        //public DataTable LoadPoRequisitionRecord(PoRequisitionDTO objPoRequisitionDTO)
        //{

        //    DataTable dt = new DataTable();
        //    string sql = "";

        //    sql = "SELECT " +
        //        "SL_NO, " +
        //        "REQUISITION_NO, " +
        //        "PURCHASE_ID, " +
        //        "PART_NO, " +
        //        "TO_CHAR(NVL(PARTICULAR_NAME,'0'))PARTICULAR_NAME, " +
        //        "TO_CHAR(PURCHASE_DATE,'dd/mm/yyyy'), " +
        //        "SECTION_ID, "+
        //        "PRESENT_STOCK, " +
        //        "REQUIRED_QTY, " +
        //        "APPEARED_QTY, " +
        //        "RATE, " +
        //        "PRICE, " +
        //        "REMARKS " +
              

        //        "FROM VEW_PO_REQUISITION WHERE   head_office_id = '" + objPoRequisitionDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objPoRequisitionDTO.BranchOfficeId + "'  ";




        //    OracleCommand objCommand = new OracleCommand(sql);
        //    OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
        //    using (OracleConnection strConn = GetConnection())
        //    {
        //        try
        //        {
        //            objCommand.Connection = strConn;
        //            strConn.Open();
        //            objDataAdapter.Fill(dt);

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



        //    return dt;

        //}
        public DataTable LoadRequisitionNo(PoRequisitionDTO objPoRequisitionDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +


                "TO_CHAR(NVL(REQUISITION_NO,'0'))REQUISITION_NO " +


                "FROM PO_REQUISITION_MAIN WHERE (lower(REQUISITION_NO) like lower( '%" + objPoRequisitionDTO.RequisitionNo + "%')  or upper(REQUISITION_NO)like upper('%" + objPoRequisitionDTO.RequisitionNo + "%')) AND  head_office_id = '" + objPoRequisitionDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objPoRequisitionDTO.BranchOfficeId + "' ORDER BY TRAN_ID DESC ";


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
        public DataTable LoadPartNo(PoRequisitionDTO objPoRequisitionDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +


                "TO_CHAR(NVL(SPARE_PART_CATEGORY_NO,'0'))PART_NO, " +
                "TO_CHAR(NVL(SPARE_PART_CATEGORY_NAME,'0'))PARTICULAR_NAME " +


                "FROM vew_get_part_no WHERE (lower(SPARE_PART_CATEGORY_NO) like lower( '%" + objPoRequisitionDTO.PartNo + "%')  or upper(SPARE_PART_CATEGORY_NO)like upper('%" + objPoRequisitionDTO.PartNo + "%')) AND  head_office_id = '" + objPoRequisitionDTO.HeadOfficeId + "'   ";


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
        
        public DataTable LoadPoRequisitionRecordSub(PoRequisitionDTO objPoRequisitionDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
                "TO_CHAR (NVL (REQUISITION_NO, ''))REQUISITION_NO, " +
                "TO_CHAR (NVL (PART_NO, ''))PART_NO, " +
                "TO_CHAR(NVL(PARTICULAR_NAME,''))PARTICULAR_NAME, " +
                "TO_CHAR (NVL (PRESENT_STOCK, ''))PRESENT_STOCK, " +
                "TO_CHAR (NVL (REQUIRED_QTY, ''))REQUIRED_QTY, " +
                "TO_CHAR (NVL (APPROVED_QTY, ''))APPROVED_QTY, " +
                "TO_CHAR (NVL (RATE, ''))RATE, " +
                "TO_CHAR (NVL (PRICE, ''))PRICE, " +
                "TO_CHAR (NVL (REMARKS, ''))REMARKS, " +
                "TO_CHAR (NVL (PO_UNIT_ID,  ''))PO_UNIT_ID, " +
                "TO_CHAR (NVL (TRAN_ID,  ''))TRAN_ID, " +
                "TO_CHAR (NVL (CURRENCY_ID,  ''))CURRENCY_ID, " +
                "TO_CHAR (NVL (CURRENCY_NAME,  ''))CURRENCY_NAME " +


                " FROM VEW_PO_REQUISITION WHERE   head_office_id = '" + objPoRequisitionDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objPoRequisitionDTO.BranchOfficeId + "' and  REQUISITION_NO = '" + objPoRequisitionDTO.RequisitionNo + "'  ";



            if (objPoRequisitionDTO.PurchaseDate.Length > 6)
            {
                sql = sql + " and    PURCHASE_DATE = TO_DATE ('" + objPoRequisitionDTO.PurchaseDate + "', 'dd/mm/yyyy') ";

            }


            sql = sql + " order by TO_NUMBER(TRAN_ID) ";

         

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


        public DataTable getPurchaseId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();

            if (strHeadOfficeId == "331" && strBranchOfficeId == "104")
            {
                string sql = "";
                sql = "select ' ' PURCHASE_ID, ' Please Select One ' PURCHASE_OFFICE_NAME from dual " +
                        "union " +

                    "SELECT " +
                      "to_char(PURCHASE_ID), " +
                      "PURCHASE_OFFICE_NAME " +
                      "FROM L_PURCHASE_INFO WHERE HEAD_OFFICE_ID = '" + strHeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "' order by PURCHASE_OFFICE_NAME ";

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

            else
            {
                string sql = "";
                sql = "select ' ' PURCHASE_ID, ' Please Select One ' OFFICE_NAME from dual " +
                        "union " +

                    "SELECT " +
                      "to_char(PURCHASE_ID), " +
                      "PURCHASE_OFFICE_NAME " +
                      "FROM L_PURCHASE_INFO ";

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

        }
        public DataTable getPartNo(string strHeadOfficeId,string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            string sql = "";
            sql = "select ' ' SPARE_PART_CATEGORY_ID, ' Please Select One ' SPARE_PART_CATEGORY_NO from dual " +
                    "union " +

                "SELECT " +
                  "to_char(SPARE_PART_CATEGORY_ID), " +
                  "to_char(SPARE_PART_CATEGORY_NO) " +
                  "FROM L_SPARE_PART_CATEGORY   WHERE HEAD_OFFICE_ID= '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID= '" + strBranchOfficeId + "' order by SPARE_PART_CATEGORY_ID ";

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

    }
}
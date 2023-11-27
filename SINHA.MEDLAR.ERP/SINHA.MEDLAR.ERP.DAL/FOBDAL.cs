﻿using System;
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
    public class FOBDAL
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
        public string saveFOBasPerCostSheetInfo(FOBDTO objFOBDTO)
        {




            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("PRO_BUDGET_COST_SAVE");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objFOBDTO.TranId != "")
            {

                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.TranId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objFOBDTO.ContractId != "")
            {

                objOracleCommand.Parameters.Add("P_CONTRACT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.ContractId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_CONTRACT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objFOBDTO.FOBDate.Length > 6)
            {

                objOracleCommand.Parameters.Add("P_FOB_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.FOBDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_FOB_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }



            if (objFOBDTO.POId != "")
            {

                objOracleCommand.Parameters.Add("P_PO_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.POId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PO_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objFOBDTO.StyleId != "")
            {

                objOracleCommand.Parameters.Add("P_STYLE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.StyleId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_STYLE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objFOBDTO.BuyerId != "")
            {

                objOracleCommand.Parameters.Add("P_BUYER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.BuyerId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_BUYER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objFOBDTO.SeasonId != "")
            {

                objOracleCommand.Parameters.Add("P_SEASON_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.SeasonId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SEASON_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objFOBDTO.FabricId != "")
            {

                objOracleCommand.Parameters.Add("P_FABRIC_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.FabricId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_FABRIC_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objFOBDTO.SupplierId != "")
            {

                objOracleCommand.Parameters.Add("P_SUPPLIER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.SupplierId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SUPPLIER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }




            if (objFOBDTO.ArtId != "")
            {

                objOracleCommand.Parameters.Add("P_ART_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.ArtId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_ART_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objFOBDTO.SizeId != "")
            {

                objOracleCommand.Parameters.Add("P_SIZE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.SizeId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SIZE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }




            if (objFOBDTO.Consumption != "")
            {

                objOracleCommand.Parameters.Add("P_CONSUMPTION", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.Consumption;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_CONSUMPTION", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objFOBDTO.Price != "")
            {

                objOracleCommand.Parameters.Add("P_PRICE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.Price;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PRICE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objFOBDTO.TotalPrice != "")
            {

                objOracleCommand.Parameters.Add("P_TOTAL_PRICE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.TotalPrice;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_TOTAL_PRICE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }




            if (objFOBDTO.BudgetQtyInYds != "")
            {

                objOracleCommand.Parameters.Add("P_BUDGET_QTY_IN_YDS", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.BudgetQtyInYds;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_BUDGET_QTY_IN_YDS", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objFOBDTO.BudgetValue != "")
            {

                objOracleCommand.Parameters.Add("P_BUDGET_VALUE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.BudgetValue;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_BUDGET_VALUE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objFOBDTO.AmendmentDate.Length > 6 )
            {

                objOracleCommand.Parameters.Add("P_AMENDMENT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.AmendmentDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_AMENDMENT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objFOBDTO.OrderQuantity !="")
            {

                objOracleCommand.Parameters.Add("P_ORDER_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.OrderQuantity;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_ORDER_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.BranchOfficeId;


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
        public string saveFOBActualCost(FOBDTO objFOBDTO)
        {


            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("PRO_ACTUAL_COST_SAVE");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objFOBDTO.TranId != "")
            {

                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.TranId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objFOBDTO.ContractId != "")
            {

                objOracleCommand.Parameters.Add("P_CONTRACT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.ContractId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_CONTRACT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objFOBDTO.FOBDate.Length > 6)
            {

                objOracleCommand.Parameters.Add("P_FOB_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.FOBDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_FOB_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }



            if (objFOBDTO.POId != "")
            {

                objOracleCommand.Parameters.Add("P_PO_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.POId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PO_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objFOBDTO.StyleId != "")
            {

                objOracleCommand.Parameters.Add("P_STYLE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.StyleId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_STYLE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objFOBDTO.BuyerId != "")
            {

                objOracleCommand.Parameters.Add("P_BUYER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.BuyerId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_BUYER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objFOBDTO.SeasonId != "")
            {

                objOracleCommand.Parameters.Add("P_SEASON_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.SeasonId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SEASON_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objFOBDTO.FabricId != "")
            {

                objOracleCommand.Parameters.Add("P_FABRIC_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.FabricId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_FABRIC_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }




            if (objFOBDTO.SupplierId != "")
            {

                objOracleCommand.Parameters.Add("P_SUPPLIER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.SupplierId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SUPPLIER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

          


            if (objFOBDTO.BudgetValue != "")
            {

                objOracleCommand.Parameters.Add("P_BUDGET_VALUE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.BudgetValue;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_BUDGET_VALUE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }



            if (objFOBDTO.AcTualQuantity != "")
            {

                objOracleCommand.Parameters.Add("P_ACTUAL_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.AcTualQuantity;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_ACTUAL_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objFOBDTO.ActualPrice != "")
            {

                objOracleCommand.Parameters.Add("P_ACTUAL_PRICE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.ActualPrice;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_ACTUAL_PRICE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objFOBDTO.ActualValue != "")
            {

                objOracleCommand.Parameters.Add("P_ACTUAL_VALUE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.ActualValue;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_ACTUAL_VALUE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objFOBDTO.ActualVariance != "")
            {

                objOracleCommand.Parameters.Add("P_ACTUAL_VARIANCE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.ActualVariance;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_ACTUAL_VARIANCE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objFOBDTO.PINo != "")
            {

                objOracleCommand.Parameters.Add("P_PI_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.PINo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PI_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objFOBDTO.PIDate.Length > 6)
            {

                objOracleCommand.Parameters.Add("P_PI_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.PIDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PI_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objFOBDTO.AmendmentDate.Length > 6)
            {

                objOracleCommand.Parameters.Add("P_AMENDMENT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.AmendmentDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_AMENDMENT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objFOBDTO.OrderQuantity !="")
            {

                objOracleCommand.Parameters.Add("P_ORDER_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.OrderQuantity;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_ORDER_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }



            if (objFOBDTO.ArtId != "")
            {

                objOracleCommand.Parameters.Add("P_ART_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.ArtId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_ART_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objFOBDTO.BudgetQuantity != "")
            {

                objOracleCommand.Parameters.Add("P_BUDGET_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.BudgetQuantity;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_BUDGET_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objFOBDTO.BudgetPrice != "")
            {

                objOracleCommand.Parameters.Add("P_BUDGET_PRICE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.BudgetPrice;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_BUDGET_PRICE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }



            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.BranchOfficeId;


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

      
        public string deleteFOBActualCostRecord(FOBDTO objFOBDTO)
        {



            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("PRO_DELETE_ACTUAL_COST_RECORD");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.TranId;


            if (objFOBDTO.BuyerId != "")
            {

                objOracleCommand.Parameters.Add("P_BUYER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.BuyerId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_BUYER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objFOBDTO.ContactId != "")
            {

                objOracleCommand.Parameters.Add("P_CONTRACT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.ContactId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_CONTRACT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objFOBDTO.FOBDate.Length > 6)
            {

                objOracleCommand.Parameters.Add("P_FOB_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.FOBDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_FOB_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objFOBDTO.POId != "")
            {

                objOracleCommand.Parameters.Add("P_PO_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.POId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PO_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objFOBDTO.StyleId != "")
            {

                objOracleCommand.Parameters.Add("P_STYLE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.StyleId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_STYLE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }




            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.BranchOfficeId;


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
        public string processFOBActualCostFromFOBBudget(FOBDTO objFOBDTO)
        {



            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("pro_fob_actual_cost_search");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objFOBDTO.BuyerId != "")
            {

                objOracleCommand.Parameters.Add("P_BUYER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.BuyerId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_BUYER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objFOBDTO.ContractId != "")
            {

                objOracleCommand.Parameters.Add("P_CONTRACT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.ContractId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_CONTRACT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }



            if (objFOBDTO.FOBDate.Length > 6)
            {

                objOracleCommand.Parameters.Add("P_FOB_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.FOBDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_FOB_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objFOBDTO.AmendmentDate.Length > 6)
            {

                objOracleCommand.Parameters.Add("P_AMENDMENT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.AmendmentDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_AMENDMENT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objFOBDTO.POId.Length > 0)
            {

                objOracleCommand.Parameters.Add("P_PO_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.POId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PO_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objFOBDTO.StyleId.Length > 0)
            {

                objOracleCommand.Parameters.Add("P_STYLE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.StyleId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_STYLE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objFOBDTO.SeasonId.Length > 0)
            {

                objOracleCommand.Parameters.Add("P_SEASON_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.SeasonId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SEASON_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }







            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.BranchOfficeId;


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
        public string processFOBBudgetCostFromCosting(FOBDTO objFOBDTO)
        {



            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("pro_fob_budget_cost_search");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objFOBDTO.BuyerId != "")
            {

                objOracleCommand.Parameters.Add("P_BUYER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.BuyerId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_BUYER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objFOBDTO.ContractId != "")
            {

                objOracleCommand.Parameters.Add("P_CONTRACT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.ContractId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_CONTRACT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }



            if (objFOBDTO.FOBDate.Length > 6)
            {

                objOracleCommand.Parameters.Add("P_FOB_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.FOBDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_FOB_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objFOBDTO.AmendmentDate.Length > 6)
            {

                objOracleCommand.Parameters.Add("P_AMENDMENT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.AmendmentDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_AMENDMENT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objFOBDTO.POId.Length > 0)
            {

                objOracleCommand.Parameters.Add("P_PO_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.POId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PO_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objFOBDTO.StyleId.Length > 0)
            {

                objOracleCommand.Parameters.Add("P_STYLE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.StyleId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_STYLE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objFOBDTO.SeasonId.Length > 0)
            {

                objOracleCommand.Parameters.Add("P_SEASON_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.SeasonId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SEASON_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }







            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.BranchOfficeId;


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

        public DataTable searchFOBPerCostSheetRecord(FOBDTO objFOBDTO)
        {


            DataTable dt = new DataTable();
            //string sql = "";

            //sql = "SELECT 'Y' FROM VEW_SEARCH_BUDGET_COST_SUB WHERE head_office_id = '" + objFOBDTO.HeadOfficeId + "' AND branch_office_id = '" + objFOBDTO.BranchOfficeId + "' ";

            //if (objFOBDTO.ContractId.Length > 0)
            //{

            //    sql = sql + "and CONTRACT_ID = '" + objFOBDTO.ContractId + "' ";
            //}


            //if (objFOBDTO.POId.Length > 0)
            //{

            //    sql = sql + "and PO_ID = '" + objFOBDTO.POId + "'";
            //}


            //if (objFOBDTO.StyleId.Length > 0)
            //{

            //    sql = sql + "and style_ID = '" + objFOBDTO.StyleId + "'";
            //}

            //if (objFOBDTO.BuyerId.Length > 0)
            //{

            //    sql = sql + "and buyer_id = '" + objFOBDTO.BuyerId + "'";
            //}

            //if (objFOBDTO.AmendmentDate.Length > 6)
            //{

            //    sql = sql + "and AMENDMENT_DATE = to_date('" + objFOBDTO.AmendmentDate + "', 'dd/mm/yyyy') ";
            //}

            //if (objFOBDTO.FOBDate.Length > 6)
            //{

            //    sql = sql + "and FOB_DATE = to_date('" + objFOBDTO.FOBDate + "', 'dd/mm/yyyy') ";
            //}


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



            //            objFOBDTO.Msg = objDataReader.GetString(0);



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


            //if (objFOBDTO.Msg == "Y")
            //{
                string sql1 = "";

                sql1 = "SELECT " +
       "to_char(NVL(TRAN_ID,'0'))TRAN_ID, " +

       "to_char(NVL(SUPPLIER_ID,'0'))SUPPLIER_ID, " +
       "to_char(NVL(ART_ID,'0'))ART_ID, " +
       "to_char(NVL(SIZE_ID,'0'))SIZE_ID, " +
       "to_char(NVL(CONSUMPTION, '0'))CONSUMPTION, " +
       "to_char(NVL(PRICE, '0'))PRICE, " +
       "to_char(NVL(TOTAL_PRICE, '0'))TOTAL_PRICE, " +
        "to_char(NVL(BUDGET_QTY_IN_YDS, '0'))BUDGET_QTY_IN_YDS, " +
       "to_char(NVL(BUDGET_VALUE, '0'))BUDGET_VALUE, " +
       "to_char(NVL(FABRIC_ID, '0'))FABRIC_ID, " +
       "to_char(NVL(FABRIC_SYMBOLIC_ID, '0'))FABRIC_SYMBOLIC_ID " +







                      " FROM VEW_SEARCH_BUDGET_COST_SUB WHERE head_office_id = '" + objFOBDTO.HeadOfficeId + "' and  branch_office_id = '" + objFOBDTO.BranchOfficeId + "'  ";






                if (objFOBDTO.ContractId.Length > 0)
                {

                    sql1 = sql1 + "and CONTRACT_ID = '" + objFOBDTO.ContractId + "' ";
                }


                if (objFOBDTO.POId.Length > 0)
                {

                    sql1 = sql1 + "and PO_ID = '" + objFOBDTO.POId + "'";
                }


                if (objFOBDTO.StyleId.Length > 0)
                {

                    sql1 = sql1 + "and style_ID = '" + objFOBDTO.StyleId + "'";
                }

                if (objFOBDTO.BuyerId.Length > 0)
                {

                    sql1 = sql1 + "and buyer_id = '" + objFOBDTO.BuyerId + "'";
                }

                if (objFOBDTO.AmendmentDate.Length > 6)
                {

                    sql1 = sql1 + "and AMENDMENT_DATE = to_date('" + objFOBDTO.AmendmentDate + "', 'dd/mm/yyyy') ";
                }

                if (objFOBDTO.FOBDate.Length > 6)
                {

                    sql1 = sql1 + "and FOB_DATE = to_date('" + objFOBDTO.FOBDate + "', 'dd/mm/yyyy') ";
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



//        }
//            else
//            {


//                string sql2 = "";
//        sql2 = "SELECT " +
//                        "to_char(NVL(TRAN_ID,'0'))TRAN_ID, " +
//                        "to_char(NVL(ART_ID,'0'))ART_ID, " +
//                         "to_char(NVL(SIZE_ID,'0'))SIZE_ID, " +
//                          "to_char(NVL(CONSUMPTION, '0'))CONSUMPTION, " +
//                          "to_char(NVL(QUANTITY, '0'))BUDGET_QTY_IN_YDS, " +
//                           "to_char(NVL(FABRIC_ID, '0'))FABRIC_ID, " +
//                           "to_char(NVL(TOTAL_PRICE, '0'))PRICE, " +

//                           "TOTAL_PRICE_NEW TOTAL_PRICE, " +
//                            "to_char(NVL(BUDGET_VALUE, '0'))BUDGET_VALUE, " +
//                           "to_char(NVL(SUPPLIER_ID,'0'))SUPPLIER_ID " +
                            

//                                      " FROM VEW_SEARCH_COSTING_SUB WHERE head_office_id = '" + objFOBDTO.HeadOfficeId + "' and  branch_office_id = '" + objFOBDTO.BranchOfficeId + "'  ";




//                if (objFOBDTO.ContractId.Length > 0)
//                {

//                    sql2 = sql2 + "and CONTRACT_ID = '" + objFOBDTO.ContractId + "' ";
//                }


//                if (objFOBDTO.POId.Length > 0)
//                {

//                    sql2 = sql2 + "and PO_ID = '" + objFOBDTO.POId + "'";
//                }


//                if (objFOBDTO.StyleId.Length > 0)
//                {

//                    sql2 = sql2 + "and style_ID = '" + objFOBDTO.StyleId + "'";
//                }

//                if (objFOBDTO.BuyerId.Length > 0)
//                {

//                    sql2 = sql2 + "and buyer_id = '" + objFOBDTO.BuyerId + "'";
//                }

//                if (objFOBDTO.AmendmentDate.Length > 6)
//                {

//                    sql2 = sql2 + "and AMENDMENT_DATE = to_date('" + objFOBDTO.AmendmentDate + "', 'dd/mm/yyyy') ";
//                }

//                if (objFOBDTO.FOBDate.Length > 6)
//                {

//                    sql2 = sql2 + "and FOB_DATE = to_date('" + objFOBDTO.FOBDate + "', 'dd/mm/yyyy') ";
//                }





//                sql = sql + "order by SL ";

//                OracleCommand objCommand2 = new OracleCommand(sql2);
//OracleDataAdapter objDataAdapter2 = new OracleDataAdapter(objCommand2);
//                using (OracleConnection strConn = GetConnection())
//                {
//                    try
//                    {
//                        objCommand2.Connection = strConn;
//                        strConn.Open();
//                        objDataAdapter2.Fill(dt);

//                    }
//                    catch (Exception ex)
//                    {

//                        throw new Exception("Error : " + ex.Message);
//                    }

//                    finally
//                    {

//                        strConn.Close();
//                    }

//                }





//            }





            return dt;
        }
        public DataTable searchFOBActualCostSheetRecord(FOBDTO objFOBDTO)
        {


            DataTable dt = new DataTable();


            //string sql = "";

            //sql = "SELECT 'Y' FROM VEW_SEARCH_ACTUAL_COST_SUB WHERE head_office_id = '" + objFOBDTO.HeadOfficeId + "' AND branch_office_id = '" + objFOBDTO.BranchOfficeId + "' ";

            //if (objFOBDTO.ContactNo.Length > 0)
            //{
            //    sql = sql + "and CONTRACT_NO = '" + objFOBDTO.ContactNo + "' ";
            //}

            //if (objFOBDTO.POId.Length > 0)
            //{

            //    sql = sql + "and PO_ID_BUDGET = '" + objFOBDTO.POId + "' ";
            //}

            //if (objFOBDTO.StyleId.Length > 0)
            //{

            //    sql = sql + "and STYLE_ID_BUDGET = '" + objFOBDTO.StyleId + "' ";
            //}



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



            //            objFOBDTO.Msg = objDataReader.GetString(0);



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




            //if (objFOBDTO.Msg == "Y")
            //{





                string sql1 = "";

                sql1 = "SELECT " +
                       "to_char(NVL(TRAN_ID,'0'))TRAN_ID, " +

                       "to_char(NVL(SUPPLIER_ID,'0'))SUPPLIER_ID, " +
                       "to_char(NVL(BUDGET_VALUE, '0'))BUDGET_VALUE, " +
                       "to_char(NVL(FABRIC_ID, '0'))FABRIC_ID, " +
                       "to_char(NVL(FABRIC_SYMBOLIC_ID, '0'))FABRIC_SYMBOLIC_ID, " +


                        "to_char(NVL(ACTUAL_QUANTITY, '0'))ACTUAL_QUANTITY, " +
                         "to_char(NVL(ACTUAL_PRICE, '0'))ACTUAL_PRICE, " +
                          "to_char(NVL(ACTUAL_VALUE, '0'))ACTUAL_VALUE, " +
                           "to_char(NVL(ACTUAL_VARIANCE, '0'))ACTUAL_VARIANCE, " +
                            "to_char(NVL(PI_NO, '0'))PI_NO, " +
                             "NVL (TO_CHAR (PI_DATE, 'dd/mm/yyyy'), ' ')PI_DATE, " +


                              "to_char(NVL(budget_price, '0'))budget_price, " +
                              "to_char(NVL(ART_ID, '0'))ART_ID, " +
                              "to_char(NVL(budget_QUANTITY, '0'))budget_QUANTITY " +



                      " FROM  VEW_SEARCH_ACTUAL_COST_SUB WHERE head_office_id = '" + objFOBDTO.HeadOfficeId + "' and  branch_office_id = '" + objFOBDTO.BranchOfficeId + "'  ";



                if (objFOBDTO.FOBDate.Length > 6)
                {

                    sql1 = sql1 + "and FOB_DATE = TO_DATE('" + objFOBDTO.FOBDate + "', 'dd/mm/yyyy') ";
                }


                if (objFOBDTO.ContractId.Length > 0)
                {

                    sql1 = sql1 + "and CONTRACT_ID = '" + objFOBDTO.ContractId + "' ";
                }


                if (objFOBDTO.POId.Length > 0)
                {

                    sql1 = sql1 + "and PO_ID = '" + objFOBDTO.POId + "'";
                }


                if (objFOBDTO.StyleId.Length > 0)
                {

                    sql1 = sql1 + "and style_id = '" + objFOBDTO.StyleId + "'";
                }

            if (objFOBDTO.AmendmentDate.Length > 0)
            {

                sql1 = sql1 + "and AMENDMENT_DATE = to_date('" + objFOBDTO.AmendmentDate + "', 'dd/mm/yyyy') ";
            }



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

            //           "to_char(NVL(SUPPLIER_ID,'0'))SUPPLIER_ID, " +
            //           "to_char(NVL(BUDGET_VALUE, '0'))BUDGET_VALUE, " +
            //           "to_char(NVL(FABRIC_ID, '0'))FABRIC_ID, " +
            //           "to_char(NVL(FABRIC_SYMBOLIC_ID, '0'))FABRIC_SYMBOLIC_ID, " +


            //            "to_char(NVL(ACTUAL_QUANTITY, '0'))ACTUAL_QUANTITY, " +
            //             "to_char(NVL(ACTUAL_PRICE, '0'))ACTUAL_PRICE, " +
            //              "to_char(NVL(ACTUAL_VALUE, '0'))ACTUAL_VALUE, " +
            //               "to_char(NVL(ACTUAL_VARIANCE, '0'))ACTUAL_VARIANCE, " +
            //                "to_char(NVL(PI_NO, '0'))PI_NO, " +
            //                "to_char(NVL(PO_ID_BUDGET, '0'))PO_ID, " +
            //                "to_char(NVL(STYLE_ID_BUDGET, '0'))STYLE_ID, " +
            //                 "PI_DATE " +




            //          " FROM VEW_SEARCH_BUDGET_COST_SUB WHERE head_office_id = '" + objFOBDTO.HeadOfficeId + "' and  branch_office_id = '" + objFOBDTO.BranchOfficeId + "'  ";



            //    if (objFOBDTO.FOBDate.Length > 6)
            //    {

            //        sql2 = sql2 + "and FOB_DATE = TO_DATE('" + objFOBDTO.FOBDate + "', 'dd/mm/yyyy') ";
            //    }


            //    if (objFOBDTO.ContactNo.Length > 0)
            //    {

            //        sql2 = sql2 + "and CONTRACT_NO = '" + objFOBDTO.ContactNo + "' ";
            //    }


            //    if (objFOBDTO.POId.Length > 0)
            //    {

            //        sql2 = sql2 + "and PO_id = '" + objFOBDTO.POId + "'";
            //    }


            //    if (objFOBDTO.StyleId.Length > 0)
            //    {

            //        sql2 = sql2 + "and style_id = '" + objFOBDTO.StyleId + "'";
            //    }




            //    OracleCommand objCommand2 = new OracleCommand(sql2);
            //    OracleDataAdapter objDataAdapter2 = new OracleDataAdapter(objCommand2);
            //    using (OracleConnection strConn = GetConnection())
            //    {
            //        try
            //        {
            //            objCommand2.Connection = strConn;
            //            strConn.Open();
            //            objDataAdapter2.Fill(dt);

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




            //sql = sql + "order by SL ";





            return dt;
        }
        public DataTable FOBActualCostSub(FOBDTO objFOBDTO)
        {


            DataTable dt = new DataTable();


            string sql = "";






            sql = "SELECT " +
                       "to_char(NVL(TRAN_ID,'0'))TRAN_ID, " +

                       "to_char(NVL(SUPPLIER_ID,'0'))SUPPLIER_ID, " +
                       "to_char(NVL(BUDGET_VALUE, '0'))BUDGET_VALUE, " +
                       "to_char(NVL(FABRIC_ID, '0'))FABRIC_ID, " +
                       "to_char(NVL(FABRIC_SYMBOLIC_ID, '0'))FABRIC_SYMBOLIC_ID, " +


                        "to_char(NVL(ACTUAL_QUANTITY, '0'))ACTUAL_QUANTITY, " +
                         "to_char(NVL(ACTUAL_PRICE, '0'))ACTUAL_PRICE, " +
                          "to_char(NVL(ACTUAL_VALUE, '0'))ACTUAL_VALUE, " +
                           "to_char(NVL(ACTUAL_VARIANCE, '0'))ACTUAL_VARIANCE, " +
                            "to_char(NVL(PI_NO, '0'))PI_NO, " +
                              "to_char(NVL(PO_ID, '0'))PO_ID, " +
                                "to_char(NVL(style_id, '0'))style_id, " +
                             "NVL (TO_CHAR (PI_DATE, 'dd/mm/yyyy'), ' ')PI_DATE " +




                      " FROM  VEW_SEARCH_ACTUAL_COST_SUB WHERE head_office_id = '" + objFOBDTO.HeadOfficeId + "' and  branch_office_id = '" + objFOBDTO.BranchOfficeId + "'  ";



                if (objFOBDTO.FOBDate.Length > 6)
                {

                sql = sql + "and FOB_DATE = TO_DATE('" + objFOBDTO.FOBDate + "', 'dd/mm/yyyy') ";
                }


                if (objFOBDTO.ContactNo.Length > 0)
                {

                sql = sql + "and CONTRACT_NO = '" + objFOBDTO.ContactNo + "' ";
                }


                if (objFOBDTO.POId.Length > 0)
                {

                sql = sql + "and PO_ID_BUDGET = '" + objFOBDTO.POId + "'";
                }


                if (objFOBDTO.StyleId.Length > 0)
                {

                sql = sql + "and style_id_budget = '" + objFOBDTO.StyleId + "'";
                }




                OracleCommand objCommand1 = new OracleCommand(sql);
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


           

            return dt;
        }

        public FOBDTO searcFOBCostSheetMain(string strContactId, string strFOBDate, string strAmendmentDate, string strPONo, string strStyleNo, string strBuyerId, string strSeasonId, string strHeadOfficeId, string strBranchOfficeId)
        {


            FOBDTO objFOBDTO = new FOBDTO();

            ContractDAL objContractDAL = new ContractDAL();

            //string sql = "";

            //sql = "SELECT 'Y' FROM VEW_SEARCH_PER_COST_SHEET_MAIN WHERE head_office_id = '" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "' ";

            //if (strContactNo.Length > 0)
            //{
            //    sql = sql + "and CONTRACT_NO = '" + strContactNo + "' ";
            //}

            //if (strPONo.Length > 6)
            //{

            //    sql = sql + "and PO_NO = '" + strPONo + "' ";
            //}

            //if (strStyleNo.Length > 6)
            //{

            //    sql = sql + "and STYLE_NO = '" + strStyleNo + "' ";
            //}



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



            //            objFOBDTO.Msg = objDataReader.GetString(0);



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



            //if (objFOBDTO.Msg == "Y")
            //{
                string sql1 = "";

            sql1 = "SELECT " +


           
              "TO_CHAR (NVL (SEASON_ID, '0')), " +
              " NVL(TO_CHAR(AMENDMENT_DATE, 'dd/mm/yyyy'),'0')AMENDMENT_DATE, " +
               "TO_CHAR (NVL (ORDER_QUANTITY, '0'))ORDER_QUANTITY " +



              "from VEW_SEARCH_BUDGET_COST_MAIN where head_office_id = '" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "' ";



            if (strContactId.Length > 0)
            {
                sql1 = sql1 + "and CONTRACT_ID= '" + strContactId + "' ";
            }

            if (strPONo.Length > 0)
            {

                sql1 = sql1 + "and PO_ID = '" + strPONo + "' ";
            }

            if (strStyleNo.Length > 0)
            {

                sql1 = sql1 + "and STYLE_ID = '" + strStyleNo + "' ";
            }

            if (strBuyerId.Length > 0)
            {

                sql1 = sql1 + "and BUYER_ID = '" + strBuyerId + "' ";
            }

            if (strAmendmentDate.Length > 6)
            {

                sql1 = sql1 + "and AMENDMENT_DATE = to_date('" + strAmendmentDate + "', 'dd/mm/yyyy') ";
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



                      
                        objFOBDTO.SeasonId = objDataReader1.GetString(0);
                        objFOBDTO.AmendmentDate = objDataReader1.GetString(1);
                        objFOBDTO.OrderQuantity = objDataReader1.GetString(2);

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


            //      "TO_CHAR (NVL (BUYER_ID, '0')), " +
            //      "NVL(TO_CHAR(FOB_DATE, 'dd/mm/yyyy'), ' ')FOB_DATE " +



            //      "from vew_search_contact_main where head_office_id = '" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "' ";



            //    if (strContactNo.Length > 0)
            //    {
            //        sql2 = sql2 + "and CONTRACT_NO = '" + strContactNo + "' ";
            //    }

            //    if (strPONo.Length > 6)
            //    {

            //        sql2 = sql2 + "and PO_NO = '" + strPONo + "' ";
            //    }

            //    if (strStyleNo.Length > 6)
            //    {

            //        sql2 = sql2 + "and STYLE_NO = '" + strStyleNo + "' ";
            //    }




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



            //                objFOBDTO.BuyerId = objDataReader2.GetString(0);
            //                objFOBDTO.FOBDate = objDataReader2.GetString(1);


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

            return objFOBDTO;
        }
        public FOBDTO searcPOId(string strContactNo, string strHeadOfficeId, string strBranchOfficeId)
        {


            FOBDTO objFOBDTO = new FOBDTO();

            ContractDAL objContractDAL = new ContractDAL();


            string sql1 = "";

            sql1 = "SELECT " +


              "TO_CHAR (NVL (PO_ID, '0')) " +



              "from L_PO_CONTRACT where head_office_id = '" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "' and CONTRACT_NO = '" + strContactNo + "' ";




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



                        objFOBDTO.POId = objDataReader1.GetString(0);
                     


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



           
            return objFOBDTO;
        }
       
        public FOBDTO searcStyleId(string strContactNo,string strPOId, string strHeadOfficeId, string strBranchOfficeId)
        {


            FOBDTO objFOBDTO = new FOBDTO();

            ContractDAL objContractDAL = new ContractDAL();


            string sql1 = "";

            sql1 = "SELECT " +


              "TO_CHAR (NVL (STYLE_ID, '0')) " +



              "from L_STYLE_CONTRACT where head_office_id = '" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "' and CONTRACT_NO = '" + strContactNo + "' AND PO_ID = '"+ strPOId + "' ";




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



                        objFOBDTO.StyleId = objDataReader1.GetString(0);



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




            return objFOBDTO;
        }
        public FOBDTO searcFOBDate(string strBuyerId,  string strContactId, string strPOId, string strStyleId, string strHeadOfficeId, string strBranchOfficeId)
        {


            FOBDTO objFOBDTO = new FOBDTO();

            ContractDAL objContractDAL = new ContractDAL();

            string sql = "";

            sql = "SELECT  'Y' from FOB_BUDGET_COST_MAIN where  buyer_id = '" + strBuyerId + "' and head_office_id = '" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "' and CONTRACT_ID = '" + strContactId + "' AND PO_ID = '" + strPOId + "' AND style_id = '" + strStyleId + "'";
            


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



                        objFOBDTO.Msg = objDataReader.GetString(0);
                       


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

            if (objFOBDTO.Msg == "Y")
            {
                string sql1 = "";

                sql1 = "SELECT " +


                  " NVL(TO_CHAR  (FOB_DATE, 'dd/mm/yyyy'), ' ')FOB_DATE, " +
                  "TO_CHAR (NVL (SEASON_ID, '0')) " +
                


                  "from VEW_CONTRACT_FOB_DATE where head_office_id = '" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "' and CONTRACT_ID = '" + strContactId + "' AND PO_ID = '" + strPOId + "' AND style_id = '" + strStyleId + "'";

                if (strBuyerId.Length > 0)
                {
                    sql1 = sql1 + " and buyer_id = '" + strBuyerId + "'";

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



                            objFOBDTO.FOBDate = objDataReader1.GetString(0);
                            objFOBDTO.SeasonId = objDataReader1.GetString(1);


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
            else
            {

                string sql2 = "";

                sql2 = "SELECT " +


                  " NVL(TO_CHAR  (SHIPPING_DATE, 'dd/mm/yyyy'), ' ')FOB_DATE, " +
                   "TO_CHAR (NVL (SEASON_ID, '0')) " +


                  "from vew_contract_shipping_date where head_office_id = '" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "' and CONTRACT_ID = '" + strContactId + "' AND PO_ID = '" + strPOId + "' AND style_id = '" + strStyleId + "'";

                if (strBuyerId.Length > 0)
                {
                    sql2 = sql2 + " and buyer_id = '" + strBuyerId + "'";

                }


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



                            objFOBDTO.FOBDate = objDataReader2.GetString(0);
                            objFOBDTO.SeasonId = objDataReader2.GetString(1);


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






         




            return objFOBDTO;
        }
        public FOBDTO searcFOBDateCosting(string strBuyerId, string strContactId, string strPOId, string strStyleId, string strHeadOfficeId, string strBranchOfficeId)
        {


            FOBDTO objFOBDTO = new FOBDTO();

            ContractDAL objContractDAL = new ContractDAL();

            string sql = "";

            sql = "SELECT  'Y' from COSTING_MAIN where  buyer_id = '" + strBuyerId + "' and head_office_id = '" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "' and CONTRACT_ID = '" + strContactId + "' AND PO_ID = '" + strPOId + "' AND style_id = '" + strStyleId + "'";



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



                        objFOBDTO.Msg = objDataReader.GetString(0);



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

            if (objFOBDTO.Msg == "Y")
            {
                string sql1 = "";

                sql1 = "SELECT " +


                  " NVL(TO_CHAR  (FOB_DATE, 'dd/mm/yyyy'), ' ')FOB_DATE, " +
                  "TO_CHAR (NVL (SEASON_ID, '0')) " +



                  "from VEW_SEARCH_COSTING_MAIN where head_office_id = '" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "' and CONTRACT_ID = '" + strContactId + "' AND PO_ID = '" + strPOId + "' AND style_id = '" + strStyleId + "'";

                if (strBuyerId.Length > 0)
                {
                    sql1 = sql1 + " and buyer_id = '" + strBuyerId + "'";

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



                            objFOBDTO.FOBDate = objDataReader1.GetString(0);
                            objFOBDTO.SeasonId = objDataReader1.GetString(1);


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
            else
            {

                string sql2 = "";

                sql2 = "SELECT " +


                  " NVL(TO_CHAR  (SHIPPING_DATE, 'dd/mm/yyyy'), ' ')FOB_DATE, " +
                  "TO_CHAR (NVL (SEASON_ID, '0'))SEASON_ID " +



                  "from vew_contract_shipping_date where head_office_id = '" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "' and CONTRACT_ID = '" + strContactId + "' AND PO_ID = '" + strPOId + "' AND style_id = '" + strStyleId + "'";

                if (strBuyerId.Length > 0)
                {
                    sql2 = sql2 + " and buyer_id = '" + strBuyerId + "'";

                }


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



                            objFOBDTO.FOBDate = objDataReader2.GetString(0);
                            objFOBDTO.SeasonId = objDataReader2.GetString(1);


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











            return objFOBDTO;
        }
        public FOBDTO searcOrderQuantityBYPOStyle(string strBuyerId, string strContactId, string strPOId, string strStyleId, string strHeadOfficeId, string strBranchOfficeId)
        {


            FOBDTO objFOBDTO = new FOBDTO();

            ContractDAL objContractDAL = new ContractDAL();


                string sql1 = "";

                sql1 = "SELECT " +

                  "TO_CHAR (NVL (SUM(ORDER_QUANTITY), '0')), " +
                   "TO_CHAR (NVL (SUM(ORDER_QUANTITY_REG), '0')), " +
                   "TO_CHAR (NVL (SUM(ORDER_QUANTITY_TALL), '0')), " +
                   "TO_CHAR (NVL (SUM(ORDER_QUANTITY_BIGG), '0')) " +




                  "from vew_contract_order_qty where head_office_id = '" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "' and CONTRACT_ID = '" + strContactId + "' AND PO_ID = '" + strPOId + "' AND style_id = '" + strStyleId + "'";

                if (strBuyerId.Length > 0)
                {
                    sql1 = sql1 + " and buyer_id = '" + strBuyerId + "'";

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



                            objFOBDTO.OrderQuantity = objDataReader1.GetString(0);
                            objFOBDTO.OrderQuantityForReg = objDataReader1.GetString(1);
                            objFOBDTO.OrderQuantityForTall = objDataReader1.GetString(2);
                            objFOBDTO.OrderQuantityForBig = objDataReader1.GetString(3);


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

           




            return objFOBDTO;
        }
        public FOBDTO searcBudgetValue(string strFabricId,  string strBuyerId, string strContactId, string strPOId, string strStyleId, string strFOBDate, string strHeadOfficeId, string strBranchOfficeId)
        {


            FOBDTO objFOBDTO = new FOBDTO();
            ContractDAL objContractDAL = new ContractDAL();
            string sql = "";

            sql = "SELECT  'Y' from FOB_ACTUAL_COST_SUB where  buyer_id = '" + strBuyerId + "' and head_office_id = '" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "' and CONTRACT_ID = '" + strContactId + "' AND PO_ID = '" + strPOId + "' AND style_id = '" + strStyleId + "' AND FOB_DATE = TO_DATE('"+strFOBDate+"','dd/mm/yyyy') ";



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



                        objFOBDTO.Msg = objDataReader.GetString(0);



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

            if (objFOBDTO.Msg == "Y")
            {

                string sql1 = "";

                sql1 = "SELECT " +

                  "TO_CHAR (NVL (BUDGET_VALUE, '0')) " +



                  "from FOB_ACTUAL_COST_SUB where FABRIC_ID = '"+strFabricId+"' AND buyer_id = '" + strBuyerId + "' and head_office_id = '" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "' and CONTRACT_ID = '" + strContactId + "' AND PO_ID = '" + strPOId + "' AND style_id = '" + strStyleId + "' AND FOB_DATE = TO_DATE('" + strFOBDate + "','dd/mm/yyyy') ";

               

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



                            objFOBDTO.BudgetValue = objDataReader1.GetString(0);




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
            else
            {

                string sql2 = "";

                sql2 = "SELECT " +

                  "TO_CHAR (NVL (BUDGET_VALUE, '0')) " +



                  "from FOB_BUDGET_COST_SUB where FABRIC_ID = '" + strFabricId + "' AND buyer_id = '" + strBuyerId + "' and head_office_id = '" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "' and CONTRACT_ID = '" + strContactId + "' AND PO_ID = '" + strPOId + "' AND style_id = '" + strStyleId + "' AND FOB_DATE = TO_DATE('" + strFOBDate + "','dd/mm/yyyy') ";



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



                            objFOBDTO.BudgetValue = objDataReader2.GetString(0);




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






            return objFOBDTO;
        }
        public FOBDTO searcIssueDate(string strBuyerId, string strContactId, string strHeadOfficeId, string strBranchOfficeId)
        {


            FOBDTO objFOBDTO = new FOBDTO();

            ContractDAL objContractDAL = new ContractDAL();

            string sql = "";

            sql = "SELECT  NVL(to_char(ISSUE_DATE, 'dd/mm/yyyy'), '0') ISSUE_DATE from VEW_SEARCH_CONTACT_MAIN where  buyer_id = '" + strBuyerId + "' AND contract_id = '"+ strContactId + "' and head_office_id = '" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "' ";



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



                        objFOBDTO.IssueDate = objDataReader.GetString(0);



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

            return objFOBDTO;
        }
        public FOBDTO searcAmendmentDate(string strContractId, string strAmendmentId, string strHeadOfficeId, string strBranchOfficeId)
        {


            FOBDTO objFOBDTO = new FOBDTO();

            ContractDAL objContractDAL = new ContractDAL();

            string sql = "";

            sql = "SELECT  NVL(to_char(AMENDMENT_DATE, 'dd/mm/yyyy'), '0') AMENDMENT_DATE from VEW_SEARCH_CONTACT_MAIN where  AMENDMENT_ID = '" + strAmendmentId + "' AND contract_id = '" + strContractId + "' and head_office_id = '" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "'  ";



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



                        objFOBDTO.AmendmentDate = objDataReader.GetString(0);



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

            return objFOBDTO;
        }

        public FOBDTO searchFOBActualCostMain(string strContactId, string strFOBDate, string strPONo, string strStyleNo, string strBuyerId, string strSeasonId, string strHeadOfficeId, string strBranchOfficeId)
        {


            FOBDTO objFOBDTO = new FOBDTO();

            ContractDAL objContractDAL = new ContractDAL();

            //string sql = "";

            //sql = "SELECT 'Y' FROM VEW_SEARCH_ACTUAL_COST_MAIN WHERE head_office_id = '" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "' AND FOB_DATE = TO_DATE('" + strFOBDate + "', 'dd/mm/yyyy') ";

            //if (strContactNo.Length > 0)
            //{
            //    sql = sql + "and CONTRACT_NO = '" + strContactNo + "' ";
            //}

            //if (strPONo.Length > 0)
            //{

            //    sql = sql + "and PO_ID_BUDGET = '" + strPONo + "' ";
            //}

            //if (strStyleNo.Length > 0)
            //{

            //    sql = sql + "and STYLE_ID_BUDGET = '" + strStyleNo + "' ";
            //}



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



            //            objFOBDTO.Msg = objDataReader.GetString(0);



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



            //if (objFOBDTO.Msg == "Y")
            //{
                string sql1 = "";

            sql1 = "SELECT " +


            
              "TO_CHAR (NVL (SEASON_ID, '0')), " +
              "NVL(TO_CHAR(FOB_DATE, 'dd/mm/yyyy'), ' ')FOB_DATE, " +
               "NVL(TO_CHAR(AMENDMENT_DATE, 'dd/mm/yyyy'), ' ')AMENDMENT_DATE, " +
                "TO_CHAR (NVL (ORDER_QUANTITY, '0'))ORDER_QUANTITY " +



              "from VEW_SEARCH_ACTUAL_COST_MAIN where head_office_id = '" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "' AND FOB_DATE = TO_DATE('"+ strFOBDate + "', 'dd/mm/yyyy') ";



            if (strContactId.Length > 0)
            {
                sql1 = sql1 + "and CONTRACT_ID = '" + strContactId + "' ";
            }

            if (strPONo.Length > 0)
            {

                sql1 = sql1 + "and PO_ID = '" + strPONo + "' ";
            }

            if (strStyleNo.Length > 0)
            {

                sql1 = sql1 + "and STYLE_ID = '" + strStyleNo + "' ";
            }


            if (strBuyerId !=" ")
            {

                sql1 = sql1 + "and BUYER_ID = '" + strBuyerId + "' ";
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



                       
                        objFOBDTO.SeasonId = objDataReader1.GetString(0);
                        objFOBDTO.FOBDate = objDataReader1.GetString(1);
                        objFOBDTO.AmendmentDate = objDataReader1.GetString(2);
                        objFOBDTO.OrderQuantity = objDataReader1.GetString(3);

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


            //  "TO_CHAR (NVL (buyer_name, '0')), " +
            //  "TO_CHAR (NVL (SEASON_ID, '0')), " +
            //  "NVL(TO_CHAR(FOB_DATE, 'dd/mm/yyyy'), ' ')FOB_DATE " +



            // "from  VEW_SEARCH_BUDGET_COST_MAIN where head_office_id = '" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "'  AND FOB_DATE = TO_DATE('" + strFOBDate + "', 'dd/mm/yyyy') ";



            //    if (strContactNo.Length > 0)
            //    {
            //        sql2 = sql2 + "and CONTRACT_NO = '" + strContactNo + "' ";
            //    }

            //    if (strPONo.Length > 0)
            //    {

            //        sql2 = sql2 + "and PO_ID = '" + strPONo + "' ";
            //    }

            //    if (strStyleNo.Length > 0)
            //    {

            //        sql2 = sql2 + "and STYLE_ID = '" + strStyleNo + "' ";
            //    }




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



            //                objFOBDTO.BuyerName = objDataReader2.GetString(0);
            //                objFOBDTO.SeasonId = objDataReader2.GetString(1);
            //                objFOBDTO.FOBDate = objDataReader2.GetString(2);


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

            return objFOBDTO;
        }
        public FOBDTO FOBActualCostMain(string strBuyerId,  string strContactNo, string strFOBDate, string strHeadOfficeId, string strBranchOfficeId)
        {


            FOBDTO objFOBDTO = new FOBDTO();

            ContractDAL objContractDAL = new ContractDAL();

            string sql = "";


            sql = "SELECT " +


                  "TO_CHAR (NVL (buyer_name, '0')), " +
                  "TO_CHAR (NVL (SEASON_ID, '0')), " +
                   "TO_CHAR (NVL (PO_ID_BUDGET, '0')), " +
                    "TO_CHAR (NVL (STYLE_ID_BUDGET, '0')), " +
                  "NVL(TO_CHAR(FOB_DATE, 'dd/mm/yyyy'), ' ')FOB_DATE " +
  


                  "from VEW_SEARCH_ACTUAL_COST_MAIN where head_office_id = '" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "' AND FOB_DATE = TO_DATE('" + strFOBDate + "', 'dd/mm/yyyy') and CONTRACT_NO = '" + strContactNo + "' ";






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



                            objFOBDTO.BuyerName = objDataReader.GetString(0);
                            objFOBDTO.SeasonId = objDataReader.GetString(1);
                            objFOBDTO.POId = objDataReader.GetString(2);
                            objFOBDTO.StyleId = objDataReader.GetString(3);
                            objFOBDTO.FOBDate = objDataReader.GetString(4);


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



            return objFOBDTO;
        }


        public DataTable searchFOBActualCost(FOBDTO objFOBDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";




            sql = "SELECT " +
                   "ROWNUM SL, " +
                   "TO_CHAR(FOB_DATE,'dd/mm/yyyy')FOB_DATE, " +
                   "CONTRACT_NO, " +
                   "PO_NO, " +
                   "STYLE_NO, " +
                    "BUYER_NAME, " +
                   "SEASON_NAME, " +
                   "TO_CHAR(AMENDMENT_DATE,'dd/mm/yyyy')AMENDMENT_DATE " +




                  "FROM VEW_FOB_ACTUAL_COST_MAIN WHERE head_office_id = '" + objFOBDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objFOBDTO.BranchOfficeId + "'   ";




            if (objFOBDTO.ContactNo.Length > 0)
            {

                sql = sql + "and CONTRACT_NO = '" + objFOBDTO.ContactNo + "' ";
            }

            if (objFOBDTO.FOBDate.Length > 6)
            {

                sql = sql + "and FOB_DATE = TO_DATE('" + objFOBDTO.FOBDate + "','dd/mm/yyyy' )";
            }

            if (objFOBDTO.Year.Length > 0)
            {

                sql = sql + "and  to_char(FOB_DATE, 'YYYY') ='" + objFOBDTO.Year + "' ";
            }

            if (objFOBDTO.POId != "")
            {

                sql = sql + "and  PO_ID ='" + objFOBDTO.POId + "' ";
            }

            if (objFOBDTO.StyleId != "")
            {

                sql = sql + "and  STYLE_ID ='" + objFOBDTO.StyleId + "' ";
            }

            if (objFOBDTO.BuyerId != "")
            {

                sql = sql + "and  BUYER_ID ='" + objFOBDTO.BuyerId + "' ";
            }

            if (objFOBDTO.SeasonId != "")
            {

                sql = sql + "and  SEASON_ID ='" + objFOBDTO.SeasonId + "' ";
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
        public DataTable searchFOBBudgetCost(FOBDTO objFOBDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";




            sql = "SELECT " +
                   "ROWNUM SL, " +
                   "TO_CHAR(FOB_DATE,'dd/mm/yyyy')FOB_DATE, " +
                   "CONTRACT_NO, " +
                   "PO_NO, " +
                   "STYLE_NO, " +
                    "BUYER_NAME, " +
                   "SEASON_NAME, " +
                    "TO_CHAR(AMENDMENT_DATE,'dd/mm/yyyy')AMENDMENT_DATE " +




                  " FROM VEW_SEARCH_BUDGET_COST_SUB WHERE head_office_id = '" + objFOBDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objFOBDTO.BranchOfficeId + "'   ";




            if (objFOBDTO.ContactNo.Length > 0)
            {

                sql = sql + "and CONTRACT_NO = '" + objFOBDTO.ContactNo + "' ";
            }

            if (objFOBDTO.FOBDate.Length > 6)
            {

                sql = sql + "and FOB_DATE = TO_DATE('" + objFOBDTO.FOBDate + "','dd/mm/yyyy' )";
            }





            if (objFOBDTO.Year.Length > 0)
            {

                sql = sql + "and  to_char(FOB_DATE, 'YYYY') ='" + objFOBDTO.Year + "' ";
            }

            if (objFOBDTO.POId != "")
            {

                sql = sql + "and  PO_ID ='" + objFOBDTO.POId + "' ";
            }

            if (objFOBDTO.StyleId != "")
            {

                sql = sql + "and  STYLE_ID ='" + objFOBDTO.StyleId + "' ";
            }

            if (objFOBDTO.BuyerId != "")
            {

                sql = sql + "and  BUYER_ID ='" + objFOBDTO.BuyerId + "' ";
            }

            if (objFOBDTO.SeasonId != "")
            {

                sql = sql + "and  SEASON_ID ='" + objFOBDTO.SeasonId + "' ";
            }


            if (objFOBDTO.AmendmentDate.Length > 6)
            {

                sql = sql + "and  AMENDMENT_DATE ='" + objFOBDTO.AmendmentDate + "' ";
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

        public string deletePerCostSheetRecord(FOBDTO objFOBDTO)
        {



            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("PRO_DELETE_COST_SHEET_RECORD");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.TranId;


            if (objFOBDTO.BuyerId != "")
            {

                objOracleCommand.Parameters.Add("P_BUYER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.BuyerId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_BUYER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objFOBDTO.ContactId != "")
            {

                objOracleCommand.Parameters.Add("P_CONTRACT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.ContactId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_CONTRACT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objFOBDTO.FOBDate.Length > 6)
            {

                objOracleCommand.Parameters.Add("P_FOB_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.FOBDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_FOB_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objFOBDTO.POId != "")
            {

                objOracleCommand.Parameters.Add("P_PO_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.POId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PO_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objFOBDTO.StyleId != "")
            {

                objOracleCommand.Parameters.Add("P_STYLE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.StyleId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_STYLE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }





            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFOBDTO.BranchOfficeId;


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

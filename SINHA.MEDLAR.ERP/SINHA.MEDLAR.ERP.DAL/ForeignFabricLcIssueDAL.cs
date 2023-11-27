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
    public class ForeignFabricLcIssueDAL
    {
        OracleTransaction trans = null;

        //Save Foreign Fabric Issue 
        #region "Oracle Connection Function"

        private OracleConnection GetConnection()
        {
            var conString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConString"];
            string strConnString = conString.ConnectionString;
            return new OracleConnection(strConnString);
        }

        #endregion

        public string deleteForeignIssueRecord(ForeignFabricLcIssueDTO objForeignFabricLcIssueDTO)
        {
            string strMsg = "";

            OracleCommand objOracleCommand = new OracleCommand("pro_foreign_fabric_issue_del");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricLcIssueDTO.TranId;
            objOracleCommand.Parameters.Add("P_ISSUE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricLcIssueDTO.IssueDate;
            objOracleCommand.Parameters.Add("P_CHALLAN_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricLcIssueDTO.ChallanNo;


            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricLcIssueDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricLcIssueDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricLcIssueDTO.BranchOfficeId;

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
                    throw new Exception("Error : " + ex.Message);

                }

                finally
                {

                    strConn.Close();
                }

            }



            return strMsg;
        }

        public string saveForeignLcFabricIssue(ForeignFabricLcIssueDTO objForeignFabricLcIssueDTO)
        {

            string strMsg = "";

            OracleCommand objOracleCommand = new OracleCommand("pro_foreign_fabric_issue_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricLcIssueDTO.TranId;


            if (objForeignFabricLcIssueDTO.IssueDate.Length > 6)
            {
                objOracleCommand.Parameters.Add("P_ISSUE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricLcIssueDTO.IssueDate;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_ISSUE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            objOracleCommand.Parameters.Add("P_CHALLAN_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricLcIssueDTO.ChallanNo;



            if (objForeignFabricLcIssueDTO.SupplierId != " ")
            {
                objOracleCommand.Parameters.Add("P_SUPPLIER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricLcIssueDTO.SupplierId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_SUPPLIER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }




            if (objForeignFabricLcIssueDTO.ProgrammeId != " ")
            {
                objOracleCommand.Parameters.Add("P_PROGRAMME_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricLcIssueDTO.ProgrammeId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_PROGRAMME_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objForeignFabricLcIssueDTO.FabricId != " ")
            {
                objOracleCommand.Parameters.Add("P_FABRIC_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricLcIssueDTO.FabricId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_FABRIC_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objForeignFabricLcIssueDTO.FabricConstructionId != " ")
            {
                objOracleCommand.Parameters.Add("P_FABRIC_CONSTRUCTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricLcIssueDTO.FabricConstructionId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_FABRIC_CONSTRUCTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objForeignFabricLcIssueDTO.StyleId != " ")
            {
                objOracleCommand.Parameters.Add("P_STYLE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricLcIssueDTO.StyleId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_STYLE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objForeignFabricLcIssueDTO.ColorId != " ")
            {
                objOracleCommand.Parameters.Add("P_COLOR_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricLcIssueDTO.ColorId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_COLOR_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            objOracleCommand.Parameters.Add("P_ART_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricLcIssueDTO.ArtId;

            objOracleCommand.Parameters.Add("P_RECEIVE_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricLcIssueDTO.ReceiveQty;
            objOracleCommand.Parameters.Add("P_ISSUE_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricLcIssueDTO.IssueQty;

            if (objForeignFabricLcIssueDTO.UnitId != " ")
            {
                objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricLcIssueDTO.UnitId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objForeignFabricLcIssueDTO.StoreLocationId != " ")
            {
                objOracleCommand.Parameters.Add("P_STORE_LOCATION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricLcIssueDTO.StoreLocationId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_STORE_LOCATION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricLcIssueDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_UPDATE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricLcIssueDTO.UpdateDate;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricLcIssueDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricLcIssueDTO.BranchOfficeId;

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
                    throw new Exception("Error : " + ex.Message);

                }

                finally
                {

                    strConn.Close();
                }

            }

            return strMsg;

        }
        public DataTable SearchForeignfabricIssue(ForeignFabricLcIssueDTO objForeignFabricLcIssueDTO)
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

   "RECEIVE_QUANTITY, " +
    "ISSUE_QUANTITY, " +
   "REMAINING_QUANTITY, " +
   "STORE_LOCATION_NAME "+





               " FROM VEW_FOREIGN_FABRIC_ISSUE where head_office_id = '" + objForeignFabricLcIssueDTO.HeadOfficeId + "' and branch_office_id = '" + objForeignFabricLcIssueDTO.BranchOfficeId + "'  ";

            if (objForeignFabricLcIssueDTO.Year.Length > 0)
            {


                sql = sql + " and TO_CHAR(ISSUE_DATE, 'YYYY') = '" + objForeignFabricLcIssueDTO.Year + "' ";

            }


            if (objForeignFabricLcIssueDTO.ChallanNo.Length > 0)
            {


                sql = sql + " and CHALLAN_NO = '" + objForeignFabricLcIssueDTO.ChallanNo + "' ";

            }

            if (objForeignFabricLcIssueDTO.StyleId.Length > 0)
            {


                sql = sql + " and STYLE_NO = '" + objForeignFabricLcIssueDTO.StyleId + "' ";

            }

            if (objForeignFabricLcIssueDTO.SupplierId.Length > 0 )
            {


                sql = sql + " and Supplier_id = '" + objForeignFabricLcIssueDTO.SupplierId + "' ";

            }

            if (objForeignFabricLcIssueDTO.ProgrammeId.Length > 0)
            {


                sql = sql + " and PROGRAMME_ID = '" + objForeignFabricLcIssueDTO.ProgrammeId + "' ";

            }

            if (objForeignFabricLcIssueDTO.ArtId.Length > 0)
            {


                sql = sql + " and ART_ID = '" + objForeignFabricLcIssueDTO.ArtId + "' ";

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




        public ForeignFabricLcIssueDTO searchForeignLcFabricTotalQty(string strSupplierId, string strProgrammeId, string strHeadOfficeId, string strBranchOfficeId)
        {

            ForeignFabricLcIssueDTO objForeignFabricLcIssueDTO = new ForeignFabricLcIssueDTO();

            string sql = "";
            //sql = "SELECT NVL(SUM(QUANTITY),0)qty from FOREIGN_FABRIC_RECEIVE where head_office_id = '" + strHeadOfficeId + "' and branch_office_id = '" + strBranchOfficeId + "'  " +
            //    " and buyer_id = '" + strBuyerId + "' and supplier_id = '" + strSupplierId + "' and fabric_id = '" + strFabricId + "' and FABRIC_CONSTRUCTION_ID ='" + strFabricConstructionId + "' " +
            //    " and color_id = '"+strColorId+"' and style_id = '"+strStyleId+"' and art_id = '"+strArtId+"' and importer_id = '"+strImporterId+"' ";

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


                        objForeignFabricLcIssueDTO.Quantity = Convert.ToString(objDataReader.GetInt32(0));


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
            return objForeignFabricLcIssueDTO;
        }

        public ForeignFabricLcIssueDTO searchForeignLcFabricIssueByInvoice(string strReceiveDate, string strInvoiceNo, string strTranId, string strHeadOfficeId, string strBranchOfficeId)
        {

            ForeignFabricLcIssueDTO objForeignFabricLcIssueDTO = new ForeignFabricLcIssueDTO();

            string sql = "";
            sql = "SELECT " +

 
     "TO_CHAR (NVL (STORE_LOCATION_ID,'0'))STORE_LOCATION_ID, " +
     "TO_CHAR (NVL (SUPPLIER_ID,'0'))SUPPLIER_ID, " +
     "TO_CHAR (NVL (PROGRAMME_ID,'0'))PROGRAMME_ID, " +
     "TO_CHAR (NVL (FABRIC_ID,'0'))FABRIC_ID, " +
     "TO_CHAR (NVL (FABRIC_CONSTRUCTION_ID,'0'))FABRIC_CONSTRUCTION_ID, " +
     "TO_CHAR (NVL (STYLE_ID,'0'))STYLE_ID, " +
     "TO_CHAR (NVL (COLOR_ID,'0'))COLOR_ID, " +
     "TO_CHAR (NVL (ART_ID,'0'))ART_ID, " +

     "TO_CHAR (NVL (RECEIVE_QUANTITY,'0'))RECEIVE_QUANTITY, " +
      "TO_CHAR (NVL (ISSUE_QUANTITY,'0'))ISSUE_QUANTITY, " +
     "TO_CHAR (NVL (REMAINING_QUANTITY,'0'))REMAINING_QUANTITY, " +
     "TO_CHAR (NVL (UNIT_ID,'0'))UNIT_ID " +





                 " FROM VEW_FOREIGN_FABRIC_ISSUE where head_office_id = '" + strHeadOfficeId + "' and branch_office_id = '" + strBranchOfficeId + "' AND tran_id = '" + strTranId + "' ";

            if (strReceiveDate.Length > 6)
            {


                sql = sql + " and ISSUE_DATE = to_date('" + strReceiveDate + "', 'dd/mm/yyyy') ";

            }


            if (strInvoiceNo.Length > 0)
            {


                sql = sql + " and CHALLAN_NO = '" + strInvoiceNo + "' ";

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



                        objForeignFabricLcIssueDTO.StoreLocationId = objDataReader.GetString(0);
                        objForeignFabricLcIssueDTO.SupplierId = objDataReader.GetString(1);
                        objForeignFabricLcIssueDTO.ProgrammeId = objDataReader.GetString(2);
                        objForeignFabricLcIssueDTO.FabricId = objDataReader.GetString(3);
                        objForeignFabricLcIssueDTO.FabricConstructionId = objDataReader.GetString(4);
                        objForeignFabricLcIssueDTO.StyleId = objDataReader.GetString(5);
                        objForeignFabricLcIssueDTO.ColorId = objDataReader.GetString(6);
                        objForeignFabricLcIssueDTO.ArtId = objDataReader.GetString(7);

                        objForeignFabricLcIssueDTO.ReceiveQty = objDataReader.GetString(8);
                        objForeignFabricLcIssueDTO.IssueQty = objDataReader.GetString(9);
                        objForeignFabricLcIssueDTO.RemainingQuantity = objDataReader.GetString(10);
                   
                        objForeignFabricLcIssueDTO.UnitId = objDataReader.GetString(11);
                      

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
            return objForeignFabricLcIssueDTO;
        }







    }
}

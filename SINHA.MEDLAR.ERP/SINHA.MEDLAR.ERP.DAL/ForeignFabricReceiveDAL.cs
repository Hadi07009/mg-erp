using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SINHA.MEDLAR.ERP.DTO;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace SINHA.MEDLAR.ERP.DAL
{
    public class ForeignFabricReceiveDAL
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

        //Dropdown
        public DataTable getSupplierName()
        {
            DataTable dt = new DataTable();
            string sql = "select 0 SUPPLIER_ID,' Please Select one ' SUPPLIER_NAME from dual " +
                "union " +
                "select SUPPLIER_ID, SUPPLIER_NAME from L_SUPPLIER";
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
        public DataTable getBuyerName()
        {
            DataTable dt = new DataTable();
            string sql = "select 0 BUYER_ID,' Please Select one ' BUYER_NAME from dual " +
                "union " +
                "select BUYER_ID, BUYER_NAME from L_BUYER_STORE";
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
      
        public DataTable getShipmentMode()
        {
            DataTable dt = new DataTable();
            string sql = "select 0 SHIPMENT_TYPE_ID,' Please Select one ' SHIPMENT_TYPE_NAME from dual " +
                "union " +
                "select SHIPMENT_TYPE_ID, SHIPMENT_TYPE_NAME from L_SHIPMENT_TYPE";
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
        public DataTable getProgrammeName()
        {
            DataTable dt = new DataTable();
            string sql = "select 0 PROGRAMME_ID,' Please Select one ' PROGRAMME_NAME from dual " +
                "union " +
                "select PROGRAMME_ID, PROGRAMME_NAME from L_PROGRAMME";
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
        public DataTable getFabricName()
        {
            DataTable dt = new DataTable();
            string sql = "select 0 FABRIC_ID,' Please Select one ' FABRIC_NAME from dual " +
                "union " +
                "select FABRIC_ID, FABRIC_NAME from L_FABRIC";
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
        public DataTable getColorName()
        {
            DataTable dt = new DataTable();
            string sql = "select 0 COLOR_ID,' Please Select one ' COLOR_NAME from dual " +
                "union " +
                "select COLOR_ID, COLOR_NAME from L_COLOR_STORE";
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
        public DataTable getConstructionName()
        {
            DataTable dt = new DataTable();
            string sql = "select 0 FABRIC_CONSTRUCTION_ID,' Please Select one ' FABRIC_CONSTRUCTION from dual " +
                "union " +
                "select FABRIC_CONSTRUCTION_ID, FABRIC_CONSTRUCTION from L_FABRIC_CONSTRUCTION order by FABRIC_CONSTRUCTION";
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
        public DataTable getStyleName()
        {
            DataTable dt = new DataTable();
            string sql = "select 0 STYLE_ID,' Please Select one ' STYLE_NAME from dual " +
                "union " +
                "select STYLE_ID, STYLE_NO from L_STYLE_STORE";
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
        public DataTable getUnitName()
        {
            DataTable dt = new DataTable();
            string sql = "select 0 UNIT_ID,' Please Select one ' UNIT_NAME from dual " +
                "union " +
                "select UNIT_ID, UNIT_NAME from L_UNIT_STORE";
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
        public DataTable getCurrencyName()
        {
            DataTable dt = new DataTable();
            string sql = "select 0 CURRENCY_ID,' Please Select one ' CURRENCY_NAME from dual " +
                "union " +
                "select CURRENCY_ID, CURRENCY_NAME from L_CURRENCY";
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

        //Save Foreign Fabric Receive
        public string deleteForeignLcFabricRecord(ForeignFabricReceiveDTO objForeignFabricReceiveDTO)
        {

            string strMsg = "";

            OracleCommand objOracleCommand = new OracleCommand("pro_foreign_fabric_delete");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.TranId;


            if (objForeignFabricReceiveDTO.ReceiveDate.Length > 6)
            {
                objOracleCommand.Parameters.Add("P_RECEIVE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.ReceiveDate;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_RECEIVE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("P_INVOICE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.InvoiceNo;



            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.BranchOfficeId;

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
        public string saveForeignLcFabricReceive(ForeignFabricReceiveDTO objForeignFabricReceiveDTO)
        {

            string strMsg = "";

            OracleCommand objOracleCommand = new OracleCommand("pro_foreign_fabric_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.TranId;


            if (objForeignFabricReceiveDTO.ReceiveDate.Length > 6 )
            {
                objOracleCommand.Parameters.Add("P_RECEIVE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.ReceiveDate;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_RECEIVE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

          
            objOracleCommand.Parameters.Add("P_INVOICE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.InvoiceNo;
            objOracleCommand.Parameters.Add("P_LC_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.BtoBLC;


            if (objForeignFabricReceiveDTO.ShipmentModeId != " ")
            {
                objOracleCommand.Parameters.Add("P_SHIPMENT_TYPE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.ShipmentModeId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_SHIPMENT_TYPE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            objOracleCommand.Parameters.Add("P_SHIPMENT_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.ShipmentNo;
            objOracleCommand.Parameters.Add("P_STORE_LOCATION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.StoreLocationId;


            if (objForeignFabricReceiveDTO.SupplierId != " ")
            {
                objOracleCommand.Parameters.Add("P_SUPPLIER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.SupplierId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_SUPPLIER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objForeignFabricReceiveDTO.ImporterId != " ")
            {
                objOracleCommand.Parameters.Add("P_IMPORTER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.ImporterId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_IMPORTER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objForeignFabricReceiveDTO.BuyerId != " ")
            {
                objOracleCommand.Parameters.Add("P_BUYER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.BuyerId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_BUYER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objForeignFabricReceiveDTO.ProgrammeId != " ")
            {
                objOracleCommand.Parameters.Add("P_PROGRAMME_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.ProgrammeId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_PROGRAMME_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objForeignFabricReceiveDTO.FabricId != " ")
            {
                objOracleCommand.Parameters.Add("P_FABRIC_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.FabricId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_FABRIC_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objForeignFabricReceiveDTO.FabricConstructionId != " ")
            {
                objOracleCommand.Parameters.Add("P_FABRIC_CONSTRUCTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.FabricConstructionId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_FABRIC_CONSTRUCTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objForeignFabricReceiveDTO.StyleId != " ")
            {
                objOracleCommand.Parameters.Add("P_STYLE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.StyleId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_STYLE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objForeignFabricReceiveDTO.ColorId != " ")
            {
                objOracleCommand.Parameters.Add("P_COLOR_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.ColorId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_COLOR_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
           
            objOracleCommand.Parameters.Add("P_ART_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.ArtId;
            objOracleCommand.Parameters.Add("P_WIDTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.Width;
            objOracleCommand.Parameters.Add("P_NUM_OF_ROLL", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.NoOfRoll;
            objOracleCommand.Parameters.Add("P_RECEIVE_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.Quantity;

            if (objForeignFabricReceiveDTO.UnitId != " ")
            {
                objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.UnitId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("P_RATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.CurrencyRate;
            if (objForeignFabricReceiveDTO.CurrencyId != " ")
            {
                objOracleCommand.Parameters.Add("P_CURRENCY_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.CurrencyId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_CURRENCY_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
           
           

            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.BranchOfficeId;

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
        //Load data while saving
        public DataTable loadForeignfabricReceive(ForeignFabricReceiveDTO objForeignFabricReceiveDTO)
        {


            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
               "TO_CHAR(RECEIVE_DATE,'DD/MM/YYYY')RECEIVE_DATE, " +
              "TRAN_ID, "+
   "INVOICE_NO, " +
   "LC_NO, " +
   "SHIPMENT_TYPE_ID, " +
   "SHIPMENT_TYPE_NAME, " +
   "SHIPMENT_NO, " +
   "STORE_LOCATION_ID, " +
   "STORE_LOCATION_NAME, " +
   "SUPPLIER_ID, " +
   "SUPPLIER_NAME, " +
   "IMPORTER_ID, " +
   "IMPORTER_NAME, " +
   "BUYER_ID, " +
   "BUYER_NAME, " +
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
   "ART_NO, "+
   "WIDTH, " +
   "NUM_OF_ROLL, " +
   "RECEIVE_QUANTITY, " +
   "UNIT_ID, " +
   "UNIT_NAME, " +
   "RATE, " +
   "CURRENCY_ID, " +
   "CURRENCY_NAME, " +
   "UPDATE_BY, " +
   "UPDATE_DATE, " +
   "HEAD_OFFICE_ID, " +
   "BRANCH_OFFICE_ID " +

               " FROM VEW_FOREIGN_FABRIC_RECEIVE where head_office_id = '" + objForeignFabricReceiveDTO.HeadOfficeId + "' and branch_office_id = '" + objForeignFabricReceiveDTO.BranchOfficeId + "'  ";

            if(objForeignFabricReceiveDTO.ReceiveDate.Length > 0 )
            {


                sql = sql + " and RECEIVE_DATE = to_date( '"+ objForeignFabricReceiveDTO.ReceiveDate + "', 'dd/mm/yyyy') ";

            }


            if (objForeignFabricReceiveDTO.InvoiceNo.Length > 0)
            {


                sql = sql + " and INVOICE_NO = '" + objForeignFabricReceiveDTO.InvoiceNo + "' ";

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
        public DataTable SearchForeignfabricReceive(ForeignFabricReceiveDTO objForeignFabricReceiveDTO)
        {


            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
               "TO_CHAR(RECEIVE_DATE,'DD/MM/YYYY')RECEIVE_DATE, " +
              "TRAN_ID, " +
   "INVOICE_NO, " +
   "LC_NO, " +
   "SHIPMENT_TYPE_ID, " +
   "SHIPMENT_TYPE_NAME, " +
   "SHIPMENT_NO, " +
   "STORE_LOCATION_ID, " +
   "STORE_LOCATION_NAME, " +
   "SUPPLIER_ID, " +
   "SUPPLIER_NAME, " +
   "IMPORTER_ID, " +
   "IMPORTER_NAME, " +
   "BUYER_ID, " +
   "BUYER_NAME, " +
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
   "WIDTH, " +
   "NUM_OF_ROLL, " +
   "RECEIVE_QUANTITY, " +
   "UNIT_ID, " +
   "UNIT_NAME, " +
   "RATE, " +
   "CURRENCY_ID, " +
   "CURRENCY_NAME, " +
   "UPDATE_BY, " +
   "UPDATE_DATE, " +
   "HEAD_OFFICE_ID, " +
   "BRANCH_OFFICE_ID " +

               " FROM VEW_FOREIGN_FABRIC_RECEIVE where head_office_id = '" + objForeignFabricReceiveDTO.HeadOfficeId + "' and branch_office_id = '" + objForeignFabricReceiveDTO.BranchOfficeId + "'  ";

            if (objForeignFabricReceiveDTO.Year.Length > 0)
            {


                sql = sql + " and TO_CHAR(RECEIVE_DATE, 'YYYY') = '" + objForeignFabricReceiveDTO.Year + "' ";

            }


            if (objForeignFabricReceiveDTO.InvoiceNo.Length > 0)
            {


                sql = sql + " and INVOICE_NO = '" + objForeignFabricReceiveDTO.InvoiceNo + "' ";

            }

            if (objForeignFabricReceiveDTO.StyleId.Length > 0)
            {


                sql = sql + " and STYLE_ID = '" + objForeignFabricReceiveDTO.StyleId + "' ";

            }

            if (objForeignFabricReceiveDTO.BuyerId.Length > 0)
            {


                sql = sql + " and BUYER_ID = '" + objForeignFabricReceiveDTO.BuyerId + "' ";

            }

            if (objForeignFabricReceiveDTO.ProgrammeId.Length > 0)
            {


                sql = sql + " and PROGRAMME_ID = '" + objForeignFabricReceiveDTO.ProgrammeId + "' ";

            }

            if (objForeignFabricReceiveDTO.SupplierId.Length > 0)
            {


                sql = sql + " and SUPPLIER_ID = '" + objForeignFabricReceiveDTO.SupplierId + "' ";

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


        public ForeignFabricReceiveDTO searchForeignLcFabricByInvoice(string strReceiveDate, string strInvoiceNo, string strTranId, string strHeadOfficeId, string strBranchOfficeId)
        {

            ForeignFabricReceiveDTO objForeignFabricReceiveDTO = new ForeignFabricReceiveDTO();

            string sql = "";
            sql = "SELECT " +

     "TO_CHAR (NVL (TRAN_ID,'0'))TRAN_ID, " +
     "TO_CHAR (NVL (LC_NO,'0'))LC_NO, " +
     "TO_CHAR (NVL (SHIPMENT_TYPE_ID,'0'))SHIPMENT_TYPE_ID ," +
     "TO_CHAR (NVL (SHIPMENT_NO,'0'))SHIPMENT_NO, " +
     "TO_CHAR (NVL (STORE_LOCATION_ID,'0'))STORE_LOCATION_ID, " +
     "TO_CHAR (NVL (SUPPLIER_ID,'0'))SUPPLIER_ID, " +
     "TO_CHAR (NVL (IMPORTER_ID,'0'))IMPORTER_ID, " +
     "TO_CHAR (NVL (BUYER_ID,'0'))BUYER_ID, " +
     "TO_CHAR (NVL (PROGRAMME_ID,'0'))PROGRAMME_ID, " +
     "TO_CHAR (NVL (FABRIC_ID,'0'))FABRIC_ID, " +
     "TO_CHAR (NVL (FABRIC_CONSTRUCTION_ID,'0'))FABRIC_CONSTRUCTION_ID, " +
     "TO_CHAR (NVL (STYLE_ID,'0'))STYLE_ID, " +
     "TO_CHAR (NVL (COLOR_ID,'0'))COLOR_ID, " +
     "TO_CHAR (NVL (ART_ID,'0'))ART_ID, " +
     "TO_CHAR (NVL (WIDTH,'0'))WIDTH, " +
     "TO_CHAR (NVL (NUM_OF_ROLL,'0'))NUM_OF_ROLL, " +
     "TO_CHAR (NVL (RECEIVE_QUANTITY,'0'))RECEIVE_QUANTITY, " +
     "TO_CHAR (NVL (UNIT_ID,'0'))UNIT_ID, " +
   
     "TO_CHAR (NVL (RATE,'0'))RATE, " +
     "TO_CHAR (NVL (CURRENCY_ID,'0'))CURRENCY_ID " +
    
   

                 " FROM VEW_FOREIGN_FABRIC_RECEIVE where head_office_id = '" + strHeadOfficeId + "' and branch_office_id = '" + strBranchOfficeId + "' AND tran_id = '"+strTranId+"' ";

            if (strReceiveDate.Length > 6)
            {


                sql = sql + " and RECEIVE_DATE = to_date('" + strReceiveDate + "', 'dd/mm/yyyy') ";

            }


            if (strInvoiceNo.Length > 0)
            {


                sql = sql + " and INVOICE_NO = '" + strInvoiceNo + "' ";

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


                        objForeignFabricReceiveDTO.TranId = objDataReader.GetString(0);
                        objForeignFabricReceiveDTO.BtoBLC = objDataReader.GetString(1);
                        objForeignFabricReceiveDTO.ShipmentModeId = objDataReader.GetString(2);
                        objForeignFabricReceiveDTO.ShipmentNo = objDataReader.GetString(3);
                        objForeignFabricReceiveDTO.StoreLocationId = objDataReader.GetString(4);
                        objForeignFabricReceiveDTO.SupplierId = objDataReader.GetString(5);
                        objForeignFabricReceiveDTO.ImporterId = objDataReader.GetString(6);
                        objForeignFabricReceiveDTO.BuyerId = objDataReader.GetString(7);
                        objForeignFabricReceiveDTO.ProgrammeId = objDataReader.GetString(8);
                        objForeignFabricReceiveDTO.FabricId = objDataReader.GetString(9);
                        objForeignFabricReceiveDTO.FabricConstructionId = objDataReader.GetString(10);
                        objForeignFabricReceiveDTO.StyleId = objDataReader.GetString(11);
                        objForeignFabricReceiveDTO.ColorId = objDataReader.GetString(12);
                        objForeignFabricReceiveDTO.ArtId = objDataReader.GetString(13);
                        objForeignFabricReceiveDTO.Width = objDataReader.GetString(14);

                        objForeignFabricReceiveDTO.NoOfRoll = objDataReader.GetString(15);
                        objForeignFabricReceiveDTO.Quantity = objDataReader.GetString(16);
                        objForeignFabricReceiveDTO.UnitId = objDataReader.GetString(17);
                        objForeignFabricReceiveDTO.Rate = objDataReader.GetString(18);
                        objForeignFabricReceiveDTO.CurrencyId = objDataReader.GetString(19);

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
            return objForeignFabricReceiveDTO;
        }
        public ForeignFabricReceiveDTO searchTotalForeignRcvQty(string strInvoiceNo, string strHeadOfficeId, string strBranchOfficeId)
        {

            ForeignFabricReceiveDTO objForeignFabricReceiveDTO = new ForeignFabricReceiveDTO();

            string sql = "";
            sql = "SELECT " +


                  "TO_CHAR (NVL (sum(RECEIVE_QUANTITY),'0'))RECEIVE_QUANTITY " +




                 " FROM VEW_FOREIGN_FAB_RECEIVE_SUB where head_office_id = '" + strHeadOfficeId + "' and branch_office_id = '" + strBranchOfficeId + "'  and INVOICE_NO = '" + strInvoiceNo + "' ";

          


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


                        objForeignFabricReceiveDTO.TotalQuantity = objDataReader.GetString(0);
                       

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
            return objForeignFabricReceiveDTO;
        }

        public ForeignFabricReceiveDTO searchForeignLcFabricTotalQty(string strReceiveDate, string strInvoiceNo, string strBuyerId, string strSupplierId, string strFabricId, string strFabricConstructionId, string strColorId, string strStyleId, string strArtId, string strImporterId,string strProgrammeId, string strHeadOfficeId, string strBranchOfficeId)
        {

            ForeignFabricReceiveDTO objForeignFabricReceiveDTO = new ForeignFabricReceiveDTO();

            string sql = "";
            //sql = "SELECT NVL(SUM(QUANTITY),0)qty from FOREIGN_FABRIC_RECEIVE where head_office_id = '" + strHeadOfficeId + "' and branch_office_id = '" + strBranchOfficeId + "'  " +
            //    " and buyer_id = '" + strBuyerId + "' and supplier_id = '" + strSupplierId + "' and fabric_id = '" + strFabricId + "' and FABRIC_CONSTRUCTION_ID ='" + strFabricConstructionId + "' " +
            //    " and color_id = '"+strColorId+"' and style_id = '"+strStyleId+"' and art_id = '"+strArtId+"' and importer_id = '"+strImporterId+"' ";

            sql = "SELECT NVL(SUM(QUANTITY) ,0)qty from vew_foreign_fabric_qty where head_office_id = '" + strHeadOfficeId + "' and branch_office_id = '" + strBranchOfficeId + "'   AND PROGRAMME_ID ='"+strProgrammeId+"' and SUPPLIER_ID = '"+strSupplierId+"' ";
                


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


                        objForeignFabricReceiveDTO.TotalQuantity = Convert.ToString(objDataReader.GetInt32(0));
     

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
            return objForeignFabricReceiveDTO;
        }



        public ForeignFabricReceiveDTO searchForeignLcFabricReceiveTotalQty(string strReceiveDate, string strInvoiceNo, string strBuyerId, string strSupplierId, string strFabricId, string strFabricConstructionId, string strColorId, string strStyleId, string strArtId, string strImporterId, string strProgrammeId, string strHeadOfficeId, string strBranchOfficeId)
        {

            ForeignFabricReceiveDTO objForeignFabricReceiveDTO = new ForeignFabricReceiveDTO();

            string sql = "";
            //sql = "SELECT NVL(SUM(QUANTITY),0)qty from FOREIGN_FABRIC_RECEIVE where head_office_id = '" + strHeadOfficeId + "' and branch_office_id = '" + strBranchOfficeId + "'  " +
            //    " and buyer_id = '" + strBuyerId + "' and supplier_id = '" + strSupplierId + "' and fabric_id = '" + strFabricId + "' and FABRIC_CONSTRUCTION_ID ='" + strFabricConstructionId + "' " +
            //    " and color_id = '"+strColorId+"' and style_id = '"+strStyleId+"' and art_id = '"+strArtId+"' and importer_id = '"+strImporterId+"' ";

            sql = "SELECT NVL(SUM(RECEIVE_QUANTITY) ,0)qty from VEW_FOREIGN_FABRIC_RECV_QTY where head_office_id = '" + strHeadOfficeId + "' and branch_office_id = '" + strBranchOfficeId + "'   AND PROGRAMME_ID ='" + strProgrammeId + "' and SUPPLIER_ID = '" + strSupplierId + "' ";



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


                        objForeignFabricReceiveDTO.TotalQuantity = Convert.ToString(objDataReader.GetInt32(0));


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
            return objForeignFabricReceiveDTO;
        }

        public ForeignFabricReceiveDTO searchForeignFabricTotalQty(string strReceiveDate, string strInvoiceNo, string strBuyerId, string strSupplierId, string strFabricId, string strFabricConstructionId, string strColorId, string strStyleId, string strArtId, string strImporterId, string strProgrammeId, string strHeadOfficeId, string strBranchOfficeId)
        {

            ForeignFabricReceiveDTO objForeignFabricReceiveDTO = new ForeignFabricReceiveDTO();

            string sql = "";
            //sql = "SELECT NVL(SUM(QUANTITY),0)qty from FOREIGN_FABRIC_RECEIVE where head_office_id = '" + strHeadOfficeId + "' and branch_office_id = '" + strBranchOfficeId + "'  " +
            //    " and buyer_id = '" + strBuyerId + "' and supplier_id = '" + strSupplierId + "' and fabric_id = '" + strFabricId + "' and FABRIC_CONSTRUCTION_ID ='" + strFabricConstructionId + "' " +
            //    " and color_id = '"+strColorId+"' and style_id = '"+strStyleId+"' and art_id = '"+strArtId+"' and importer_id = '"+strImporterId+"' ";

            sql = "SELECT NVL(SUM(RECEIVE_QUANTITY) ,0)qty from FOREIGN_FABRIC_RECEIVE where head_office_id = '" + strHeadOfficeId + "' and branch_office_id = '" + strBranchOfficeId + "'    ";

            if(strProgrammeId.Length > 0 )
            {

                sql = sql + " and PROGRAMME_ID ='" + strProgrammeId + "'  ";


            }

            if (strSupplierId.Length > 0)
            {

                sql = sql + " and SUPPLIER_ID ='" + strSupplierId + "'  ";


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


                        objForeignFabricReceiveDTO.TotalQuantity = Convert.ToString(objDataReader.GetInt32(0));


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
            return objForeignFabricReceiveDTO;
        }

        ///////////////////////////////////////NEW/////////////////////////////////////////
        public string saveForeignFabricReceiveInfo(ForeignFabricReceiveDTO objForeignFabricReceiveDTO)
        {

            string strMsg = "";

            OracleCommand objOracleCommand = new OracleCommand("PRO_FOREIGN_FAB_RECEIVE_SAVE");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.TranId;


            if (objForeignFabricReceiveDTO.ReceiveDate.Length > 6)
            {
                objOracleCommand.Parameters.Add("P_RECEIVE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.ReceiveDate;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_RECEIVE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            if (objForeignFabricReceiveDTO.InvoiceNo != " ")
            {
                objOracleCommand.Parameters.Add("P_INVOICE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.InvoiceNo;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_INVOICE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objForeignFabricReceiveDTO.LCNo != " ")
            {
                objOracleCommand.Parameters.Add("P_LC_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.LCNo;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_LC_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objForeignFabricReceiveDTO.SupplierId != " ")
            {
                objOracleCommand.Parameters.Add("P_SUPPLIER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.SupplierId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_SUPPLIER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objForeignFabricReceiveDTO.BuyerId != " ")
            {
                objOracleCommand.Parameters.Add("P_BUYER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.BuyerId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_BUYER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objForeignFabricReceiveDTO.ImporterId != " ")
            {
                objOracleCommand.Parameters.Add("P_IMPORTER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.ImporterId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_IMPORTER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objForeignFabricReceiveDTO.ShipmentNo != " ")
            {
                objOracleCommand.Parameters.Add("P_SHIPMENT_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.ShipmentNo;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_SHIPMENT_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objForeignFabricReceiveDTO.ShipmentId != " ")
            {
                objOracleCommand.Parameters.Add("P_SHIPMENT_TYPE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.ShipmentId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_SHIPMENT_TYPE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objForeignFabricReceiveDTO.ProgrammeId != " ")
            {
                objOracleCommand.Parameters.Add("P_PROGRAMME_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.ProgrammeId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_PROGRAMME_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objForeignFabricReceiveDTO.FabricId != " ")
            {
                objOracleCommand.Parameters.Add("P_FABRIC_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.FabricId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_FABRIC_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objForeignFabricReceiveDTO.FabricConstructionId != " ")
            {
                objOracleCommand.Parameters.Add("P_FABRIC_CONSTRUCTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.FabricConstructionId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_FABRIC_CONSTRUCTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objForeignFabricReceiveDTO.StyleId != " ")
            {
                objOracleCommand.Parameters.Add("P_STYLE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.StyleId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_STYLE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objForeignFabricReceiveDTO.ColorId != " ")
            {
                objOracleCommand.Parameters.Add("P_COLOR_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.ColorId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_COLOR_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objForeignFabricReceiveDTO.ArtId != " ")
            {
                objOracleCommand.Parameters.Add("P_ART_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.ArtId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_ART_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objForeignFabricReceiveDTO.StoreId != " ")
            {
                objOracleCommand.Parameters.Add("P_STORE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.StoreId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_STORE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objForeignFabricReceiveDTO.UnitId != " ")
            {
                objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.UnitId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objForeignFabricReceiveDTO.CurrencyId != " ")
            {
                objOracleCommand.Parameters.Add("P_CURRENCY_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.CurrencyId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_CURRENCY_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objForeignFabricReceiveDTO.Rate != " ")
            {
                objOracleCommand.Parameters.Add("P_RATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.Rate;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_RATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objForeignFabricReceiveDTO.Width != " ")
            {
                objOracleCommand.Parameters.Add("P_WIDTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.Width;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_WIDTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objForeignFabricReceiveDTO.NumberOfRoll != " ")
            {
                objOracleCommand.Parameters.Add("P_NUM_OF_ROLL", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.NumberOfRoll;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_NUM_OF_ROLL", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objForeignFabricReceiveDTO.Quantity != " ")
            {
                objOracleCommand.Parameters.Add("P_RECEIVE_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.Quantity;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_RECEIVE_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.BranchOfficeId;

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

        public DataTable searcForeignFabricReceiveSub(ForeignFabricReceiveDTO objForeignFabricReceiveDTO)
        {


            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
                   "to_char(NVL(TRAN_ID,'0'))TRAN_ID, " +
                   "to_char(NVL(PROGRAMME_ID,0))PROGRAMME_ID, " +
                   "to_char(NVL(FABRIC_ID,'0'))FABRIC_ID, " +
                   "to_char(NVL(FABRIC_CONSTRUCTION_ID,'0'))FABRIC_CONSTRUCTION_ID, " +
                   "to_char(NVL(STYLE_ID,'0'))STYLE_ID, " +
                   "to_char(NVL(COLOR_ID, '0'))COLOR_ID, " +
                   "to_char(NVL(ART_ID, '0'))ART_ID, " +
                   "to_char(NVL(STORE_ID, '0'))STORE_ID, " +
                    "to_char(NVL(UNIT_ID, '0'))UNIT_ID, " +
                   "to_char(NVL(CURRENCY_ID, '0'))CURRENCY_ID, " +
                    "to_char(NVL(RATE, '0'))RATE, " +
                   "to_char(NVL(WIDTH, '0'))WIDTH, " +
                    "to_char(NVL(NUM_OF_ROLL, '0'))NUM_OF_ROLL, " +
                   "to_char(NVL(RECEIVE_QUANTITY, '0'))RECEIVE_QUANTITY " +


                  " FROM VEW_FOREIGN_FAB_RECEIVE_SUB WHERE head_office_id = '" + objForeignFabricReceiveDTO.HeadOfficeId + "' and  branch_office_id = '" + objForeignFabricReceiveDTO.BranchOfficeId + "'  ";



            if (objForeignFabricReceiveDTO.ReceiveDate.Length > 6)
            {

                sql = sql + "and RECEIVE_DATE = TO_DATE('" + objForeignFabricReceiveDTO.ReceiveDate + "', 'dd/mm/yyyy') ";
            }


            if (objForeignFabricReceiveDTO.InvoiceNo.Length > 0)
            {

                sql = sql + "and INVOICE_NO = '" + objForeignFabricReceiveDTO.InvoiceNo + "' ";
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

        public ForeignFabricReceiveDTO searcForeignFabricReceiveMain(string strInvoiceNo, string strReceiveDate, string strHeadOfficeId, string strBranchOfficeId)
        {



            ForeignFabricReceiveDTO objForeignFabricReceiveDTO = new ForeignFabricReceiveDTO();


            string sql1 = "";

            sql1 = "SELECT " +


              "TO_CHAR (NVL (LC_NO, '0'))LC_NO, " +


               "TO_CHAR (NVL (BUYER_ID, '0'))BUYER_ID, " +
               "TO_CHAR (NVL (SUPPLIER_ID, '0'))SUPPLIER_ID, " +
              "TO_CHAR (NVL (IMPORTER_ID, '0'))IMPORTER_ID, " +
               "TO_CHAR (NVL (SHIPMENT_NO, '0'))SHIPMENT_NO, " +
              "TO_CHAR (NVL (SHIPMENT_TYPE_ID, '0'))SHIPMENT_TYPE_ID, " +
              "TO_CHAR (NVL (STORE_ID, '0'))STORE_ID " +

              "from VEW_FOREIGN_FAB_RECEIVE_MAIN where head_office_id = '" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "' ";



            if (strInvoiceNo.Length > 0)
            {
                sql1 = sql1 + "and INVOICE_NO = '" + strInvoiceNo + "' ";
            }

            if (strReceiveDate.Length > 6)
            {

                sql1 = sql1 + "and RECEIVE_DATE = TO_DATE('" + strReceiveDate + "', 'dd/mm/yyyy') ";
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



                        objForeignFabricReceiveDTO.LCNo = objDataReader1.GetString(0);
                        objForeignFabricReceiveDTO.BuyerId = objDataReader1.GetString(1);
                        objForeignFabricReceiveDTO.SupplierId = objDataReader1.GetString(2);

                        objForeignFabricReceiveDTO.ImporterId = objDataReader1.GetString(3);
                        objForeignFabricReceiveDTO.ShipmentNo = objDataReader1.GetString(4);
                        objForeignFabricReceiveDTO.ShipmentId = objDataReader1.GetString(5);
                        objForeignFabricReceiveDTO.StoreId = objDataReader1.GetString(6);

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





            return objForeignFabricReceiveDTO;
        }
        public ForeignFabricReceiveDTO searchFabricAssign(string strTranId, string strHeadOfficeId, string strBranchOfficeId)
        {



            ForeignFabricReceiveDTO objForeignFabricReceiveDTO = new ForeignFabricReceiveDTO();


            string sql1 = "";

            sql1 = "SELECT " +


              "TO_CHAR (NVL (PROGRAMME_ID, '0'))PROGRAMME_ID, " +
              "TO_CHAR (NVL (SUPPLIER_ID, '0'))SUPPLIER_ID, " +
              "TO_CHAR (NVL (FABRIC_NAME, '0'))FABRIC_NAME, " +
              "TO_CHAR (NVL (FABRIC_CONSTRUCTION_NAME, '0'))FABRIC_CONSTRUCTION_NAME, " +
              "TO_CHAR (NVL (STYLE_NO, '0'))STYLE_NO, " +
              "TO_CHAR (NVL (COLOR_NAME, '0'))COLOR_NAME, " +
              "TO_CHAR (NVL (ART_NO, '0'))ART_NO, " +
              "TO_CHAR (NVL (UNIT_NAME, '0'))UNIT_NAME, " +
              "TO_CHAR (NVL (CURRENCY_NAME, '0'))CURRENCY_NAME " +



              "from VEW_FOREIGN_FABRIC_ASSIGN where head_office_id = '" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "' and tran_id = '" + strTranId + "' ";



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



                        objForeignFabricReceiveDTO.ProgrammeId = objDataReader1.GetString(0);
                        objForeignFabricReceiveDTO.SupplierId = objDataReader1.GetString(1);
                        objForeignFabricReceiveDTO.FabricId = objDataReader1.GetString(2);

                        objForeignFabricReceiveDTO.ConstructionId = objDataReader1.GetString(3);
                        objForeignFabricReceiveDTO.StyleId = objDataReader1.GetString(4);
                        objForeignFabricReceiveDTO.ColorId = objDataReader1.GetString(5);
                        objForeignFabricReceiveDTO.ArtId = objDataReader1.GetString(6);
                        objForeignFabricReceiveDTO.UnitId = objDataReader1.GetString(7);
                        objForeignFabricReceiveDTO.CurrencyId = objDataReader1.GetString(8);

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





            return objForeignFabricReceiveDTO;
        }
        public string deleteForeignFabricReceiveRecord(ForeignFabricReceiveDTO objForeignFabricReceiveDTO)
        {



            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("PRO_DELETE_FOREIGN_FAB_RECEIVE");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.TranId;



            if (objForeignFabricReceiveDTO.InvoiceNo != " ")
            {

                objOracleCommand.Parameters.Add("P_INVOICE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.InvoiceNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_INVOICE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objForeignFabricReceiveDTO.ReceiveDate.Length > 6)
            {

                objOracleCommand.Parameters.Add("P_RECEIVE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.ReceiveDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_RECEIVE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }






            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.BranchOfficeId;


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


        public DataTable SearchForeignFabricReceive(ForeignFabricReceiveDTO objForeignFabricReceiveDTO)
        {


            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +

                   "to_char(NVL(INVOICE_NO,0))INVOICE_NO, " +
                  "NVL(TO_CHAR(RECEIVE_DATE, 'dd/mm/yyyy'), ' ')RECEIVE_DATE, " +
                   "to_char(NVL(LC_NO,'0'))LC_NO, " +
                   "to_char(NVL(BUYER_NAME,'0'))BUYER_NAME, " +
                   "to_char(NVL(IMPORTER_NAME, '0'))IMPORTER_NAME, " +
                   "to_char(NVL(SUPPLIER_NAME, '0'))SUPPLIER_NAME, " +
                   "to_char(NVL(SHIPMENT_NO, '0'))SHIPMENT_NO, " +
                    "to_char(NVL(SHIPMENT_TYPE_NAME, '0'))SHIPMENT_TYPE_NAME, " +
                      "to_char(NVL(TRAN_ID,'0'))TRAN_ID " +



                  " FROM VEW_FOREIGN_FAB_RECEIVE_SUB WHERE head_office_id = '" + objForeignFabricReceiveDTO.HeadOfficeId + "' and  branch_office_id = '" + objForeignFabricReceiveDTO.BranchOfficeId + "'  ";


            if (objForeignFabricReceiveDTO.InvoiceNo.Length > 0)
            {

                sql = sql + "and INVOICE_NO = '" + objForeignFabricReceiveDTO.InvoiceNo + "' ";
            }

            if (objForeignFabricReceiveDTO.Year.Length > 6)
            {

                sql = sql + "and TO_CHAR(RECEIVE_DATE, 'YYYY') = TO_DATE('" + objForeignFabricReceiveDTO.Year + "', 'dd/mm/yyyy') ";

            }


            if (objForeignFabricReceiveDTO.LCNo.Length > 0)
            {

                sql = sql + "and LC_NO = '" + objForeignFabricReceiveDTO.LCNo + "' ";
            }

            if (objForeignFabricReceiveDTO.BuyerId.Length > 0)
            {

                sql = sql + "and BUYER_ID = '" + objForeignFabricReceiveDTO.BuyerId + "' ";
            }

            if (objForeignFabricReceiveDTO.ImporterId.Length > 0)
            {

                sql = sql + "and IMPORTER_ID = '" + objForeignFabricReceiveDTO.ImporterId + "' ";
            }

            if (objForeignFabricReceiveDTO.SupplierId.Length > 0)
            {

                sql = sql + "and SUPPLIER_ID = '" + objForeignFabricReceiveDTO.SupplierId + "' ";
            }

            if (objForeignFabricReceiveDTO.ShipmentNo.Length > 0)
            {

                sql = sql + "and SHIPMENT_NO = '" + objForeignFabricReceiveDTO.ShipmentNo + "' ";
            }

            if (objForeignFabricReceiveDTO.ShipmentId.Length > 0)
            {

                sql = sql + "and SHIPMENT_TYPE_ID = '" + objForeignFabricReceiveDTO.ShipmentId + "' ";
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



        /////////////////////////////////////////////Fabric Assign///////////////////////////////
        public string saveProgrammeFFSCAUCRecord(ForeignFabricReceiveDTO objForeignFabricReceiveDTO)
        {

            string strMsg = "";

            OracleCommand objOracleCommand = new OracleCommand("pro_foreign_fabric_assign");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            if (objForeignFabricReceiveDTO.TranId != " ")
            {
                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.TranId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objForeignFabricReceiveDTO.ProgrammeId != " ")
            {
                objOracleCommand.Parameters.Add("P_PROGRAMME_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.ProgrammeId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_PROGRAMME_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objForeignFabricReceiveDTO.SupplierId != " ")
            {
                objOracleCommand.Parameters.Add("P_SUPPLIER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.SupplierId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_SUPPLIER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objForeignFabricReceiveDTO.FabricId != " ")
            {
                objOracleCommand.Parameters.Add("P_FABRIC_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.FabricId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_FABRIC_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objForeignFabricReceiveDTO.FabricConstructionId != " ")
            {
                objOracleCommand.Parameters.Add("P_FABRIC_CONSTRUCTION_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.FabricConstructionId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_FABRIC_CONSTRUCTION_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objForeignFabricReceiveDTO.StyleId != " ")
            {
                objOracleCommand.Parameters.Add("P_STYLE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.StyleId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_STYLE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objForeignFabricReceiveDTO.ColorId != " ")
            {
                objOracleCommand.Parameters.Add("P_COLOR_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.ColorId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_COLOR_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objForeignFabricReceiveDTO.ArtId != " ")
            {
                objOracleCommand.Parameters.Add("P_ART_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.ArtId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_ART_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            if (objForeignFabricReceiveDTO.UnitId != " ")
            {
                objOracleCommand.Parameters.Add("P_UNIT_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.UnitId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_UNIT_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            if (objForeignFabricReceiveDTO.CurrencyId != " ")
            {
                objOracleCommand.Parameters.Add("P_CURRENCY_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.CurrencyId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_CURRENCY_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objForeignFabricReceiveDTO.BranchOfficeId;

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

        public DataTable loadProgrammeFFSCAUC(ForeignFabricReceiveDTO objForeignFabricReceiveDTO)
        {


            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +

                   "PROGRAMME_NAME, " +
                    "SUPPLIER_NAME, " +
                   "FABRIC_NAME, " +
                   "FABRIC_CONSTRUCTION_NAME, " +
                   "STYLE_NO, " +
                   "COLOR_NAME, " +
                   "ART_NO, " +
                    "UNIT_NAME, " +
                   "CURRENCY_NAME, " +
                   "tran_id "+




                  " FROM VEW_FOREIGN_FABRIC_ASSIGN WHERE head_office_id = '" + objForeignFabricReceiveDTO.HeadOfficeId + "' and  branch_office_id = '" + objForeignFabricReceiveDTO.BranchOfficeId + "' AND tran_id is not null  ";

            if (objForeignFabricReceiveDTO.ProgrammeId.Length > 0)
            {

                sql = sql + "and PROGRAMME_ID = '" + objForeignFabricReceiveDTO.ProgrammeId + "' ";

            }
            if (objForeignFabricReceiveDTO.SupplierId.Length > 0)
            {

                sql = sql + "and SUPPLIER_ID = '" + objForeignFabricReceiveDTO.SupplierId + "' ";

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


    }
}

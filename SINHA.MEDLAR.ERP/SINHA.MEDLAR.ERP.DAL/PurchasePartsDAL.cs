using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Oracle.ManagedDataAccess.Client;
using SINHA.MEDLAR.ERP.DTO;

namespace SINHA.MEDLAR.ERP.DAL
{
    public class PurchasePartsDAL
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

        public string savePurchasePartsRecord(PurchasePartsDTO objPurchasePartsDTO)
        {
            string strMsg = "";
            PurchasePartsDAL objPurchasePartsDAL = new PurchasePartsDAL();

         


            OracleCommand objOracleCommand = new OracleCommand("pro_purchase_parts_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchasePartsDTO.TranId;

            if (objPurchasePartsDTO.PONo != "")
            {
                objOracleCommand.Parameters.Add("P_PO_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchasePartsDTO.PONo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PO_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objPurchasePartsDTO.RequisitionNo != "")
            {
                objOracleCommand.Parameters.Add("p_requisition_no", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchasePartsDTO.RequisitionNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_requisition_no", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            //RequisitionNo


            if (objPurchasePartsDTO.MachineId != "")
            {
                objOracleCommand.Parameters.Add("P_MACHINE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchasePartsDTO.MachineId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_MACHINE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objPurchasePartsDTO.SupplierId != "")
            {
                objOracleCommand.Parameters.Add("P_SUPPLIER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchasePartsDTO.SupplierId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_SUPPLIER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objPurchasePartsDTO.PartNo != "")
            {
                objOracleCommand.Parameters.Add("P_PART_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchasePartsDTO.PartNo;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_PART_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objPurchasePartsDTO.ParticularName != "")
            {
                objOracleCommand.Parameters.Add("P_PARTICULAR_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchasePartsDTO.ParticularName;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_PARTICULAR_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

           


            if (objPurchasePartsDTO.PurchaseQuantity != "")
            {
                objOracleCommand.Parameters.Add("P_PURCHASE_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchasePartsDTO.PurchaseQuantity;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_PURCHASE_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objPurchasePartsDTO.UnitPrice != "")
            {
                objOracleCommand.Parameters.Add("P_UNIT_PRICE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchasePartsDTO.UnitPrice;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_UNIT_PRICE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objPurchasePartsDTO.TotalPrice != "")
            {
                objOracleCommand.Parameters.Add("P_TOTAL_PRICE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchasePartsDTO.TotalPrice;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_TOTAL_PRICE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objPurchasePartsDTO.CurrencyId != "")
            {
                objOracleCommand.Parameters.Add("P_CURRENCY_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchasePartsDTO.CurrencyId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_CURRENCY_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objPurchasePartsDTO.RefNo != "")
            {
                objOracleCommand.Parameters.Add("P_REF_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchasePartsDTO.RefNo;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_REF_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchasePartsDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchasePartsDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchasePartsDTO.BranchOfficeId;


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

        public string deletePurchasePartsRecordById(PurchasePartsDTO objPurchasePartsDTO)
        {
            string strMsg = "";

            OracleCommand objOracleCommand = new OracleCommand("PRO_DELETE_PURCHASE_PARTS");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("P_REF_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchasePartsDTO.RefNo;
            objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchasePartsDTO.TranId;

            if (objPurchasePartsDTO.PONo != "")
            {
                objOracleCommand.Parameters.Add("P_PO_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchasePartsDTO.PONo;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_PO_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objPurchasePartsDTO.MachineId != "")
            {
                objOracleCommand.Parameters.Add("P_MACHINE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchasePartsDTO.MachineId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_MACHINE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objPurchasePartsDTO.SupplierId != "")
            {
                objOracleCommand.Parameters.Add("P_SUPPLIER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchasePartsDTO.SupplierId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_SUPPLIER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchasePartsDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchasePartsDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchasePartsDTO.BranchOfficeId;


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

        public string deletePurchasePartsRecord(PurchasePartsDTO objPurchasePartsDTO)
        {
            string strMsg = "";
           
            OracleCommand objOracleCommand = new OracleCommand("PRO_DELETE_PURCHASE_PARTS_ALL");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

          

            if (objPurchasePartsDTO.MachineId != "")
            {
                objOracleCommand.Parameters.Add("P_MACHINE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchasePartsDTO.MachineId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_MACHINE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objPurchasePartsDTO.SupplierId != "")
            {
                objOracleCommand.Parameters.Add("P_SUPPLIER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchasePartsDTO.SupplierId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_SUPPLIER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchasePartsDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchasePartsDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objPurchasePartsDTO.BranchOfficeId;


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
        public DataTable loadPartsRecordSub(PurchasePartsDTO objPurchasePartsDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

          sql = "SELECT " +

         "TRAN_ID, " +
         "PO_NO, " +
         "PARTICULAR_NAME, " +
         "PART_NO, " +
         "to_char(NVL(PURCHASE_QUANTITY,'0'))PURCHASE_QUANTITY, " +
         "to_char(NVL(UNIT_PRICE,'0'))UNIT_PRICE, " +
         "to_char(NVL(TOTAL_PRICE,'0'))TOTAL_PRICE, " +
         "to_char(NVL(CURRENCY_ID,'0'))CURRENCY_ID " +
         

        "FROM VEW_PURCHASE_PARTS WHERE HEAD_OFFICE_ID = '" +objPurchasePartsDTO.HeadOfficeId+"' and branch_office_id = '"+objPurchasePartsDTO.BranchOfficeId+"' AND REF_NO = '"+objPurchasePartsDTO.RefNo+ "' AND TRAN_ID = '" + objPurchasePartsDTO.TranId + "'  ";

            if(objPurchasePartsDTO.MachineId.Length > 0)
            {

                sql = sql + " and machine_id = '"+ objPurchasePartsDTO.MachineId + "' ";

            }


            if (objPurchasePartsDTO.SupplierId.Length > 0)
            {

                sql = sql + " and SUPPLIER_ID = '" + objPurchasePartsDTO.SupplierId + "' ";

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
        public DataTable loadPartsRecordSubAll(PurchasePartsDTO objPurchasePartsDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +

                "rownum SL, "+
         "TRAN_ID, " +
         "PO_NO, " +
         "PARTICULAR_NAME, " +
         "PART_NO, " +
         "PURCHASE_QUANTITY, " +
         "UNIT_PRICE, " +
         "TOTAL_PRICE, " +
         "CURRENCY_NAME, " +
           "machine_name, " +
            "supplier_name, " +
             "REF_NO, " +
             "EQUIPMENT_name "+


        "FROM VEW_PURCHASE_PARTS WHERE HEAD_OFFICE_ID = '" + objPurchasePartsDTO.HeadOfficeId + "' and branch_office_id = '" + objPurchasePartsDTO.BranchOfficeId + "'  ";

            if (objPurchasePartsDTO.MachineId.Length > 0)
            {

                sql = sql + " and machine_id = '" + objPurchasePartsDTO.MachineId + "' ";

            }


            if (objPurchasePartsDTO.SupplierId.Length > 0)
            {

                sql = sql + " and SUPPLIER_ID = '" + objPurchasePartsDTO.SupplierId + "' ";

            }


            if (objPurchasePartsDTO.PartNo.Length > 0)
            {

                sql = sql + " and PART_NO = '" + objPurchasePartsDTO.PartNo + "' ";

            }


            if (objPurchasePartsDTO.PONo.Length > 0)
            {

                sql = sql + " and PO_NO = '" + objPurchasePartsDTO.PONo + "' ";

            }

            if (objPurchasePartsDTO.EquipmentId.Length > 0)
            {

                sql = sql + " and Equipment_Id = '" + objPurchasePartsDTO.EquipmentId + "' ";

            }


            sql = sql + " order by SL";


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
        public PurchasePartsDTO searchPurchasePartsMain(string strRefNo, string strTranId, string strMachineId, string strSupplierId, string strHeadOfficeId, string strBranchOfficeId)
        {

            PurchasePartsDTO objPoRequisitionDTO = new PurchasePartsDTO();


            string sql = "";

            sql = "SELECT " +


                  "TO_CHAR (NVL (MACHINE_ID, '0'))MACHINE_ID, " +
                  "TO_CHAR (NVL (SUPPLIER_ID, '0'))SUPPLIER_ID " +


                  " FROM VEW_PURCHASE_PARTS WHERE  REF_NO = '"+ strRefNo + "' AND TRAN_ID = '" + strTranId + "' AND head_office_id = '" + strHeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "'  ";




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


                        objPoRequisitionDTO.MachineId = objDataReader["MACHINE_ID"].ToString();
                        objPoRequisitionDTO.SupplierId = objDataReader["SUPPLIER_ID"].ToString();


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

    }
}

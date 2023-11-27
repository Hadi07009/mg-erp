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
    public class ProcessDAL
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



        public string saveEmployeeProcess(ProcessDTO objProcessDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_employee_process_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;




            objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProcessDTO.EmployeeId;
            objOracleCommand.Parameters.Add("p_process_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProcessDTO.ProcessId;

            if (objProcessDTO.Efficiency != "")
            {
                objOracleCommand.Parameters.Add("p_EFFICIENCY_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProcessDTO.Efficiency;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_EFFICIENCY_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objProcessDTO.Capcity != "")
            {
                objOracleCommand.Parameters.Add("p_CAPACITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProcessDTO.Capcity;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_CAPACITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objProcessDTO.StitchLength != "")
            {
                objOracleCommand.Parameters.Add("p_STITCH_LENGTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProcessDTO.StitchLength;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_STITCH_LENGTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objProcessDTO.Remarks != "")
            {
                objOracleCommand.Parameters.Add("P_REMARKS", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProcessDTO.Remarks;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_REMARKS", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
           


            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProcessDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProcessDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProcessDTO.BranchOfficeId;


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
        public string DeleteEmployeeProcess(ProcessDTO objProcessDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_employee_process_delete");
            objOracleCommand.CommandType = CommandType.StoredProcedure;




            objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProcessDTO.EmployeeId;
            objOracleCommand.Parameters.Add("p_process_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProcessDTO.ProcessId;




            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProcessDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProcessDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProcessDTO.BranchOfficeId;


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
        public string saveProductionDefect(ProcessDTO objProcessDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_product_defect_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;




            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProcessDTO.EmployeeId;

            
            if (objProcessDTO.ProductionDate.Length > 0 )
            {
                objOracleCommand.Parameters.Add("P_PRODUCTION_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProcessDTO.ProductionDate;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_PRODUCTION_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objProcessDTO.LineId != "")
            {

                objOracleCommand.Parameters.Add("P_LINE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProcessDTO.LineId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_LINE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objProcessDTO.RunningOperator != "")
            {

                objOracleCommand.Parameters.Add("P_RUNNING_OPERATOR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProcessDTO.RunningOperator;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_RUNNING_OPERATOR", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objProcessDTO.OrderProduction != "")
            {

                objOracleCommand.Parameters.Add("P_ORDER_PRODUCTION", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProcessDTO.OrderProduction;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_ORDER_PRODUCTION", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objProcessDTO.DefectAllow  != "")
            {

                objOracleCommand.Parameters.Add("P_DEFECT_ALLOW", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProcessDTO.DefectAllow;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_DEFECT_ALLOW", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objProcessDTO.DefectAllowPerHead != "")
            {

                objOracleCommand.Parameters.Add("P_DEFECT_ALLOW_PER_HEAD", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProcessDTO.DefectAllowPerHead;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_DEFECT_ALLOW_PER_HEAD", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objProcessDTO.ProductionValue != "")
            {

                objOracleCommand.Parameters.Add("P_PRODUCTION_VALUE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProcessDTO.ProductionValue;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_PRODUCTION_VALUE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objProcessDTO.DefectValue != "")
            {

                objOracleCommand.Parameters.Add("P_DEFECT_VALUE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProcessDTO.DefectValue;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_DEFECT_VALUE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objProcessDTO.ProductionHour != "")
            {

                objOracleCommand.Parameters.Add("P_PRODUCTION_HOUR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProcessDTO.ProductionHour;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_PRODUCTION_HOUR", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objProcessDTO.ProcessId != "")
            {

                objOracleCommand.Parameters.Add("P_PROCESS_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProcessDTO.ProcessId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_PROCESS_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

          

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProcessDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProcessDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProcessDTO.BranchOfficeId;


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
        public string deleteProductionDefect(ProcessDTO objProcessDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_delete_production_defect");
            objOracleCommand.CommandType = CommandType.StoredProcedure;




            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProcessDTO.EmployeeId;


            if (objProcessDTO.ProductionDate.Length > 0)
            {
                objOracleCommand.Parameters.Add("P_PRODUCTION_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProcessDTO.ProductionDate;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_PRODUCTION_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }





            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProcessDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProcessDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProcessDTO.BranchOfficeId;


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
        public string saveEfficiencyInfo(ProcessDTO objProcessDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_efficiency_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;




            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProcessDTO.EmployeeId;


            if (objProcessDTO.ProcessId.Length > 0)
            {
                objOracleCommand.Parameters.Add("P_PROCESS_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProcessDTO.ProcessId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_PROCESS_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

           

            if (objProcessDTO.SMV != "")
            {

                objOracleCommand.Parameters.Add("P_PROCESS_TIME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProcessDTO.SMV;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_PROCESS_TIME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objProcessDTO.TargetValue != "")
            {

                objOracleCommand.Parameters.Add("P_TARGET_VALUE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProcessDTO.TargetValue;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_TARGET_VALUE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objProcessDTO.EfficiencyDate.Length >  6)
            {

                objOracleCommand.Parameters.Add("P_efficiency_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProcessDTO.EfficiencyDate;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_efficiency_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }



            if (objProcessDTO.AchieveQuantity != "")
            {

                objOracleCommand.Parameters.Add("P_achieve_quantity", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProcessDTO.AchieveQuantity;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_achieve_quantity", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objProcessDTO.WorkingHour != "")
            {

                objOracleCommand.Parameters.Add("P_working_hour", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProcessDTO.WorkingHour;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_working_hour", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objProcessDTO.LineId != "")
            {

                objOracleCommand.Parameters.Add("P_LINE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProcessDTO.LineId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_LINE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objProcessDTO.StyleNo != "")
            {

                objOracleCommand.Parameters.Add("P_STYLE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProcessDTO.StyleNo;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_STYLE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProcessDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProcessDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProcessDTO.BranchOfficeId;


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
        public string deleteEfficiencyRecord(ProcessDTO objProcessDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_delete_efficency");
            objOracleCommand.CommandType = CommandType.StoredProcedure;




            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProcessDTO.EmployeeId;


            if (objProcessDTO.EfficiencyDate.Length > 6)
            {
                objOracleCommand.Parameters.Add("P_EFFICIENCY_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProcessDTO.EfficiencyDate;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_EFFICIENCY_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }




            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProcessDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProcessDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objProcessDTO.BranchOfficeId;


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
        public DataTable showProcessEntry(ProcessDTO objProcessDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
                    "rownum SL, "+
                   "CARD_NO, " +
                   "EMPLOYEE_NAME, " +
                   "DESIGNATION_NAME, " +
                   "PROCESS_NAME, "+
                   "EMPLOYEE_ID, "+
                   "EFFICIENCY_NO, "+
                   "CAPACITY, "+
                   "STITCH_LENGTH, "+
                   "TARGET_VALUE "+

                  "FROM VEW_SEARCH_EMP_PROCESS_ENTRY WHERE head_office_id = '" + objProcessDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objProcessDTO.BranchOfficeId + "' ";


            if (objProcessDTO.CardNo.Length > 0)
            {

                sql = sql + "and card_no = '" + objProcessDTO.CardNo + "'";
            }

            if (objProcessDTO.EmployeeId.Length > 0)
            {

                sql = sql + "and employee_id = '" + objProcessDTO.EmployeeId + "'";
            }

            if (objProcessDTO.FromCapacity.Length > 0 && objProcessDTO.ToCapacity.Length > 0)
            {

                sql = sql + "and CAPACITY IN( '" + objProcessDTO.FromCapacity + "', '" + objProcessDTO.ToCapacity + "')    ";
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


        public DataTable searchProductionDefectEntry(ProcessDTO objProcessDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
                   "rownum SL, " +
                   "CARD_NO, " +
                   "EMPLOYEE_NAME, " +
                   "DESIGNATION_NAME, " +

                   "TO_CHAR(PRODUCTION_DATE,'dd/mm/yyyy')PRODUCTION_DATE, " +
   
                   "PRODUCTION_VALUE, "+
                   "DEFECT_VALUE, " +
                   "production_hour, "+
                   "EMPLOYEE_ID, " +
                    "PROCESS_ID, " +
                   "PROCESS_NAME " +

                  "FROM vew_search_production_defect WHERE head_office_id = '" + objProcessDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objProcessDTO.BranchOfficeId + "' ";


            if (objProcessDTO.CardNo.Length > 0)
            {

                sql = sql + "and CARD_NO = '" + objProcessDTO.CardNo + "'";
            }

            if (objProcessDTO.EmployeeId.Length > 0)
            {

                sql = sql + "and employee_id = '" + objProcessDTO.EmployeeId + "'";
            }

            if (objProcessDTO.ProductionFromDate.Length > 6 && objProcessDTO.ProductionToDate.Length > 6)
            {

                sql = sql + "and production_date between to_date('" + objProcessDTO.ProductionFromDate + "', 'dd/mm/yyyy') and to_date('" + objProcessDTO.ProductionToDate + "', 'dd/mm/yyyy') ";
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
        public DataTable searchEfficiencyEntry(ProcessDTO objProcessDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
                   "rownum SL, " +
                   "CARD_NO, " +
                   "EMPLOYEE_NAME, " +
                   "DESIGNATION_NAME, " +

                   "TO_CHAR(EFFICIENCY_DATE,'dd/mm/yyyy')EFFICIENCY_DATE, " +
                   "process_name, "+
                   "machine_name, " +
                   "PROCESS_TIME, " +
                   "TARGET_VALUE, " +
                   "PROCESS_CODE, " +
                   "ACHIEVE_QUANTITY, " +
                   "WORKING_HOUR, "+
                   "EMPLOYEE_ID, "+
                   "STYLE_NO "+
                   

                  "FROM vew_search_efficiency_entry WHERE head_office_id = '" + objProcessDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objProcessDTO.BranchOfficeId + "' ";

            if (objProcessDTO.ProcessId.Length > 0)
            {

                sql = sql + "and PROCESS_ID = '" + objProcessDTO.ProcessId + "'";
            }


            if (objProcessDTO.CardNo.Length > 0)
            {

                sql = sql + "and CARD_NO = '" + objProcessDTO.CardNo + "'";
            }

            if (objProcessDTO.EmployeeId.Length > 0)
            {

                sql = sql + "and employee_id = '" + objProcessDTO.EmployeeId + "'";
            }

            if (objProcessDTO.ProductionFromDate.Length > 6 && objProcessDTO.ProductionToDate.Length > 6)
            {

                sql = sql + "and EFFICIENCY_DATE between to_date('" + objProcessDTO.ProductionFromDate + "', 'dd/mm/yyyy') and to_date('" + objProcessDTO.ProductionToDate + "', 'dd/mm/yyyy') ";
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

        public ProcessDTO getDefectDays(string strEmployeeId, string strHeadOfficeId, string strBranchOfficeId, string strFromDate, string strToDate)
        {

            ProcessDTO objProcessDTO = new ProcessDTO();

            string sql = "";
            sql = "SELECT " +

                  "TO_CHAR(NVL(DEFECT_ALLOW,'0')), " +
                  "TO_CHAR(NVL(DEFECT_ALLOW_PER_HEAD,'0')), " +
                  "TO_CHAR(NVL(LINE_ID,'0')), " +
                  "TO_CHAR(NVL(RUNNING_OPERATOR,'0')), " +
                  "TO_CHAR(NVL(ORDER_PRODUCTION,'0')), " +
                  "TO_CHAR(NVL(DEFECT_ALLOW,'0')), " +
                  "TO_CHAR(NVL(DEFECT_ALLOW_PER_HEAD,'0')), " +

                  "TO_CHAR(NVL(production_value,'0')), " +
                  "TO_CHAR(NVL(defect_value,'0')), " +
                  "TO_CHAR(NVL(production_hour,'0')) " +
                

                  "FROM VEW_SEARCH_PRODUCTION_DEFECT WHERE HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID ='" + strBranchOfficeId + "' AND employee_id = '" + strEmployeeId + "'  ";


            if (strFromDate.Length > 6 && strToDate.Length > 6)
            {
                sql = sql + " and PRODUCTION_DATE BETWEEN to_date('" + strFromDate + "', 'dd/mm/yyyy') and to_date('" + strToDate + "', 'dd/mm/yyyy')   ";

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

                        objProcessDTO.DefectAllow = objDataReader.GetString(0);
                        objProcessDTO.DefectAllowPerHead = objDataReader.GetString(1);
                        objProcessDTO.LineId = objDataReader.GetString(2);
                        objProcessDTO.RunningOperator = objDataReader.GetString(3);
                        objProcessDTO.OrderProduction = objDataReader.GetString(4);
                        objProcessDTO.DefectAllow = objDataReader.GetString(5);
                        objProcessDTO.DefectAllowPerHead = objDataReader.GetString(6);

                        objProcessDTO.ProductionValue = objDataReader.GetString(7);
                        objProcessDTO.DefectValue = objDataReader.GetString(8);
                        objProcessDTO.ProductionHour = objDataReader.GetString(9);

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


            return objProcessDTO;

        }

        public ProcessDTO searchEmployeeProcessEntry(string strEmployeeId, string strProcessId, string strEfficencyId, string strHeadOfficeId, string strBranchOfficeId)
        {

            ProcessDTO objProcessDTO = new ProcessDTO();

            string sql = "";
            sql = "SELECT " +

                  "TO_CHAR(NVL(PROCESS_ID,'0')), " +
                  "TO_CHAR(NVL(EFFICIENCY_ID,'0')) " +


                  "FROM VEW_SEARCH_EMP_PROCESS_ENTRY WHERE HEAD_OFFICE_ID = '" + strHeadOfficeId + "' AND BRANCH_OFFICE_ID ='" + strBranchOfficeId + "' AND employee_id = '" + strEmployeeId + "' ";


            if (strProcessId.Length > 0)
            {
                sql = sql + " and PROCESS_NAME ='"+strProcessId+"'  ";

            }

            if (strEfficencyId.Length > 0)
            {
                sql = sql + " and EFFICIENCY_NO ='" + strEfficencyId + "'  ";

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

                        objProcessDTO.ProcessId = objDataReader.GetString(0);
                        objProcessDTO.Efficiency = objDataReader.GetString(1);


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


            return objProcessDTO;
        }


    }
}

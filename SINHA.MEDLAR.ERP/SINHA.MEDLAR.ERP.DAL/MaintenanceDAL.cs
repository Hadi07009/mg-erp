using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;

using Oracle.ManagedDataAccess.Client;

using SINHA.MEDLAR.ERP.DTO;
namespace SINHA.MEDLAR.ERP.DAL
{
 public  class MaintenanceDAL
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

        #region DML

        public string saveMAchinePartsInfo(MaintenanceDTO objMaintenanceDTO)
        {


            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("pro_machine_parts_entry");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objMaintenanceDTO.MachinePartsId != "")
            {

                objOracleCommand.Parameters.Add("P_MACHINE_PARTS_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMaintenanceDTO.MachinePartsId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_MACHINE_PARTS_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objMaintenanceDTO.MachinelId != "")
            {

                objOracleCommand.Parameters.Add("P_MACHINE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMaintenanceDTO.MachinelId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_MACHINE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objMaintenanceDTO.MachineModelId != "")
            {

                objOracleCommand.Parameters.Add("P_MACHINE_MODEL_NAME_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMaintenanceDTO.MachineModelId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_MACHINE_MODEL_NAME_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objMaintenanceDTO.MachineParts != "")
            {

                objOracleCommand.Parameters.Add("P_MACHINE_PARTS", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMaintenanceDTO.MachineParts;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_MACHINE_PARTS", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }



            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMaintenanceDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMaintenanceDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMaintenanceDTO.BranchOfficeId;


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

        public string saveMachinePartsReceiveInfo(MaintenanceDTO objMaintenanceDTO)
        {


            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("pro_machine_parts_receive");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objMaintenanceDTO.MachinePartsReceiveId != "")
            {

                objOracleCommand.Parameters.Add("P_MACHINE_PARTS_RECEIVE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMaintenanceDTO.MachinePartsReceiveId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_MACHINE_PARTS_RECEIVE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objMaintenanceDTO.ReceiveDate.Length > 6)
            {

                objOracleCommand.Parameters.Add("P_RECEIVE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMaintenanceDTO.ReceiveDate;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_RECEIVE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objMaintenanceDTO.MachinelId != "")
            {

                objOracleCommand.Parameters.Add("P_MACHINE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMaintenanceDTO.MachinelId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_MACHINE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objMaintenanceDTO.MachineModelId != "")
            {

                objOracleCommand.Parameters.Add("P_MACHINE_MODEL_NAME_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMaintenanceDTO.MachineModelId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_MACHINE_MODEL_NAME_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objMaintenanceDTO.MachinePartsId != "")
            {

                objOracleCommand.Parameters.Add("P_MACHINE_PARTS_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMaintenanceDTO.MachinePartsId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_MACHINE_PARTS_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objMaintenanceDTO.DepartmentId != "")
            {

                objOracleCommand.Parameters.Add("P_DEPARTMENT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMaintenanceDTO.DepartmentId ;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_DEPARTMENT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objMaintenanceDTO.MachineMRNo != "")
            {

                objOracleCommand.Parameters.Add("P_MR_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMaintenanceDTO.MachineMRNo;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_MR_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objMaintenanceDTO.MachineBoxNo != "")
            {

                objOracleCommand.Parameters.Add("P_BOX_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMaintenanceDTO.MachineBoxNo;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_BOX_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objMaintenanceDTO.ReceiveQuantity != "")
            {

                objOracleCommand.Parameters.Add("P_RECEIVE_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMaintenanceDTO.ReceiveQuantity;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_RECEIVE_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMaintenanceDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMaintenanceDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMaintenanceDTO.BranchOfficeId;


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

        public string saveMachinePartsIssueInfo(MaintenanceDTO objMaintenanceDTO)
        {


            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("pro_machine_parts_issue");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objMaintenanceDTO.MachinePartsIssueId != "")
            {

                objOracleCommand.Parameters.Add("P_MACHINE_PARTS_ISSUE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMaintenanceDTO.MachinePartsIssueId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_MACHINE_PARTS_ISSUE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objMaintenanceDTO.IssueDate.Length > 6)
            {

                objOracleCommand.Parameters.Add("P_ISSUE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMaintenanceDTO.IssueDate;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_ISSUE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
           
            if (objMaintenanceDTO.MachinelId != "")
            {

                objOracleCommand.Parameters.Add("P_MACHINE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMaintenanceDTO.MachinelId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_MACHINE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objMaintenanceDTO.MachineModelId != "")
            {

                objOracleCommand.Parameters.Add("P_MACHINE_MODEL_NAME_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMaintenanceDTO.MachineModelId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_MACHINE_MODEL_NAME_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objMaintenanceDTO.MachinePartsId != "")
            {

                objOracleCommand.Parameters.Add("P_MACHINE_PARTS_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMaintenanceDTO.MachinePartsId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_MACHINE_PARTS_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
           

           

            if (objMaintenanceDTO.IssueQuantity != "")
            {

                objOracleCommand.Parameters.Add("P_ISSUE_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMaintenanceDTO.IssueQuantity;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_ISSUE_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objMaintenanceDTO.SRNo != "")
            {

                objOracleCommand.Parameters.Add("P_SR_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMaintenanceDTO.SRNo;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_SR_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objMaintenanceDTO.Remarks != "")
            {

                objOracleCommand.Parameters.Add("P_REMARKS", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMaintenanceDTO.Remarks;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_REMARKS", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMaintenanceDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMaintenanceDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMaintenanceDTO.BranchOfficeId;


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

        public string saveMachineInfo(MaintenanceDTO objMaintenanceDTO)
        {

            LoginDTO objLoginDTO = new LoginDTO();
            string strMsg = "";


            OracleCommand objOracleCommand = new OracleCommand("pro_mainta_machine_name_save");

            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objMaintenanceDTO.MachinelId != "")
            {
                objOracleCommand.Parameters.Add("P_MACHINE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMaintenanceDTO.MachinelId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_MACHINE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            if (objMaintenanceDTO.MachineName != "")
            {
                objOracleCommand.Parameters.Add("P_MACHINE_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMaintenanceDTO.MachineName;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_MACHINE_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMaintenanceDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMaintenanceDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMaintenanceDTO.BranchOfficeId;


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

        public string saveMachineModelInfo(MaintenanceDTO objMaintenanceDTO)
        {


            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("pro_machine_model_name_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objMaintenanceDTO.MachineModelId != "")
            {

                objOracleCommand.Parameters.Add("P_MACHINE_MODEL_NAME_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMaintenanceDTO.MachineModelId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_MACHINE_MODEL_NAME_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


          
            if (objMaintenanceDTO.MachinelId != "")
            {

                objOracleCommand.Parameters.Add("P_MACHINE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMaintenanceDTO.MachinelId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_MACHINE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objMaintenanceDTO.MachineModelName != "")
            {

                objOracleCommand.Parameters.Add("P_MACHINE_MODEL_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMaintenanceDTO.MachineModelName;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_MACHINE_MODEL_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }





            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMaintenanceDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMaintenanceDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objMaintenanceDTO.BranchOfficeId;


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

        #endregion

        #region getMethod
        public DataTable getDepartmentId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            string sql = "";
            sql = "select ' ' DEPARTMENT_ID, ' Please Select One ' DEPARTMENT_NAME from dual " +
                    "union " +

                "SELECT " +
                  "to_char(DEPARTMENT_ID), " +
                  "to_char(DEPARTMENT_NAME) " +
                  "FROM L_DEPARTMENT where head_office_id ='" + strHeadOfficeId + "' ORDER BY  DEPARTMENT_NAME";

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
        public DataTable getMachineId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            string sql = "";
            sql = "select ' ' MACHINE_ID, ' Please Select One ' MACHINE_NAME from dual " +
                    "union " +

                "SELECT " +
                  "to_char(MACHINE_ID), " +
                  "to_char(MACHINE_NAME) " +
                  "FROM L_MACHINE_NAME_MANTAINANCE where head_office_id ='" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "'  ORDER BY  MACHINE_NAME";

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

        public DataTable getMachineIdSearch(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            string sql = "";
            sql = "select ' ' MACHINE_ID, ' Please Select One ' MACHINE_NAME from dual " +
                    "union " +

                "SELECT " +
                  "to_char(MACHINE_ID), " +
                  "to_char(MACHINE_NAME) " +
                  "FROM L_MACHINE_NAME_MANTAINANCE where head_office_id ='" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "'  ORDER BY  MACHINE_NAME";

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

        public DataTable getMachineModelId(string strMachineIdId, string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            string sql = "";
            sql = "select ' ' MACHINE_MODEL_NAME_ID, ' Please Select One ' MACHINE_MODEL_NAME from dual " +
                    "union " +

                "SELECT " +
                  "to_char(MACHINE_MODEL_NAME_ID), " +
                  "to_char(MACHINE_MODEL_NAME) " +
                  "FROM L_MACHINE_MODEL_NAME where head_office_id ='" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "'  ";
            if (strMachineIdId.Length > 0)
            {
                sql = sql + " and MACHINE_ID ='" + strMachineIdId + "' ";

            }

            sql = sql + " ORDER BY  MACHINE_MODEL_NAME ";

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

        public DataTable getMachineModelIdSearch(string strMachineIdSearch, string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            string sql = "";
            sql = "select ' ' MACHINE_MODEL_NAME_ID, ' Please Select One ' MACHINE_MODEL_NAME from dual " +
                    "union " +

                "SELECT " +
                  "to_char(MACHINE_MODEL_NAME_ID), " +
                  "to_char(MACHINE_MODEL_NAME) " +
                  "FROM L_MACHINE_MODEL_NAME where head_office_id ='" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "'  ";
            if (strMachineIdSearch.Length > 0)
            {
                sql = sql + " and MACHINE_ID ='" + strMachineIdSearch + "' ";

            }

            sql = sql + " ORDER BY  MACHINE_MODEL_NAME ";

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

        public DataTable getMachinePartsId(string strMachineModelId, string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            string sql = "";
            sql = "select ' ' MACHINE_PARTS_ID, ' Please Select One ' MACHINE_PARTS from dual " +
                    "union " +

                "SELECT " +
                  "to_char(MACHINE_PARTS_ID), " +
                  "to_char(MACHINE_PARTS) " +
                  "FROM L_MACHINE_PARTS where head_office_id ='" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "'  ";
            if (strMachineModelId.Length > 0)
            {
                sql = sql + " and MACHINE_MODEL_NAME_ID ='" + strMachineModelId + "' ";

            }

            sql = sql + " ORDER BY  MACHINE_PARTS ";

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

        public DataTable getMachinePartsIdSearch(string strMachineModelIdSearch, string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            string sql = "";
            sql = "select ' ' MACHINE_PARTS_ID, ' Please Select One ' MACHINE_PARTS from dual " +
                    "union " +

                "SELECT " +
                  "to_char(MACHINE_PARTS_ID), " +
                  "to_char(MACHINE_PARTS) " +
                  "FROM L_MACHINE_PARTS where head_office_id ='" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "'  ";
            if (strMachineModelIdSearch.Length > 0)
            {
                sql = sql + " and MACHINE_MODEL_NAME_ID ='" + strMachineModelIdSearch + "' ";

            }

            sql = sql + " ORDER BY  MACHINE_PARTS ";

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

        #endregion

        #region searchMethod

        public MaintenanceDTO searchMachineModelEntry(string strMachineModeltNameId, string strHeadOfficeId, string strBranchOfficeId)
        {

            MaintenanceDTO objMaintenanceDTO = new MaintenanceDTO();
            string sql = "";
            sql = "SELECT " +
                  "to_char(nvl(MACHINE_ID, '0')), " +
                  "to_char(nvl(MACHINE_MODEL_NAME, 'N/A')) " +


                  "FROM VEW_SEARCH_MACHINE_MODEL_NAME WHERE MACHINE_MODEL_NAME_ID = '" + strMachineModeltNameId + "' and head_office_id = '" + strHeadOfficeId + "' and branch_office_id ='" + strBranchOfficeId + "' ";




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

                        objMaintenanceDTO.MachinelId = objDataReader.GetString(0);
                        objMaintenanceDTO.MachineModelName = objDataReader.GetString(1);



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


            return objMaintenanceDTO;

        }

        public MaintenanceDTO searchMachinePartsEntry(string strMachinePartsId, string strHeadOfficeId, string strBranchOfficeId)
        {

            MaintenanceDTO objMaintenanceDTO = new MaintenanceDTO();
            string sql = "";
            sql = "SELECT " +
                 "to_char(nvl(MACHINE_ID, '0')), " +

                 "to_char(nvl(MACHINE_MODEL_NAME_ID, '0')), " +

                 "to_char(nvl(MACHINE_PARTS, '0')) " +

                 "FROM VEW_SEARCH_MACHINE_PARTS WHERE MACHINE_PARTS_ID = '" + strMachinePartsId + "' and head_office_id = '" + strHeadOfficeId + "' and branch_office_id ='" + strBranchOfficeId + "' ";


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

                        objMaintenanceDTO.MachinelId = objDataReader.GetString(0);
                        objMaintenanceDTO.MachineModelId = objDataReader.GetString(1);
                        objMaintenanceDTO.MachineParts = objDataReader.GetString(2);

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


            return objMaintenanceDTO;

        }

        public MaintenanceDTO searchMachinePartsReceivedEntry(string strMachinePartsReceiveId, string strReceivedate, string strHeadOfficeId, string strBranchOfficeId)
        {

            MaintenanceDTO objMaintenanceDTO = new MaintenanceDTO();
            string sql = "";
            sql = "SELECT " +
                 "to_char(nvl(MACHINE_ID, '0')), " +

                 "to_char(nvl(MACHINE_MODEL_NAME_ID, '0')), " +

                 "to_char(nvl(MACHINE_PARTS_ID, '0')), " +

                  "to_char(nvl(DEPARTMENT_ID, '0')), " +
                  "to_char(nvl(MR_NO, '0')), " +

                  "to_char(nvl(BOX_NO, '0')) ," +
                   "to_char(nvl(RECEIVE_QUANTITY, '0')) " +

                 "FROM VEW_SEARCH_MAINTENANCE_RECEIVE WHERE MACHINE_PARTS_RECEIVE_ID = '" + strMachinePartsReceiveId + "' and head_office_id = '" + strHeadOfficeId + "' and branch_office_id ='" + strBranchOfficeId + "' and RECEIVE_DATE= to_date ('"+strReceivedate+"', 'dd/mm/yyyy') ";


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
                       
                        objMaintenanceDTO.MachinelId = objDataReader.GetString(0);
                        objMaintenanceDTO.MachineModelId = objDataReader.GetString(1);
                        objMaintenanceDTO.MachinePartsId = objDataReader.GetString(2);
                        objMaintenanceDTO.DepartmentId = objDataReader.GetString(3);
                        objMaintenanceDTO.MachineMRNo = objDataReader.GetString(4);
                        objMaintenanceDTO.MachineBoxNo = objDataReader.GetString(5);
                        objMaintenanceDTO.ReceiveQuantity = objDataReader.GetString(6);

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


            return objMaintenanceDTO;

        }

        public MaintenanceDTO searchMachinePartsIssueEntry(string strMachinePartsIssueId, string strHeadOfficeId, string strBranchOfficeId)
        {

            MaintenanceDTO objMaintenanceDTO = new MaintenanceDTO();
            string sql = "";
            sql = "SELECT " +
                 "TO_CHAR(ISSUE_DATE,'dd/mm/yyyy')ISSUE_DATE," +
                 "to_char(nvl(MACHINE_ID, '0')), " +

                 "to_char(nvl(MACHINE_MODEL_NAME_ID, '0')), " +

                 "to_char(nvl(MACHINE_PARTS_ID, '0')), " +

                

                  "to_char(nvl(ISSUE_QUANTITY, '0')) ," +
                    "to_char(nvl(SR_NO, '0')) ," +
                   "to_char(nvl(REMARKS, '0')) " +

                 "FROM VEW_SEARCH_MAINTENANCE_ISSUE WHERE MACHINE_PARTS_ISSUE_ID = '" + strMachinePartsIssueId + "' and head_office_id = '" + strHeadOfficeId + "' and branch_office_id ='" + strBranchOfficeId + "' ";


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

                        objMaintenanceDTO.IssueDate = objDataReader.GetString(0);
                        objMaintenanceDTO.MachinelId = objDataReader.GetString(1);
                        objMaintenanceDTO.MachineModelId = objDataReader.GetString(2);
                        objMaintenanceDTO.MachinePartsId = objDataReader.GetString(3);
                        
                        objMaintenanceDTO.IssueQuantity = objDataReader.GetString(4);
                        objMaintenanceDTO.SRNo = objDataReader.GetString(5);
                        objMaintenanceDTO.Remarks = objDataReader.GetString(6);

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


            return objMaintenanceDTO;

        }

        public DataTable MachinePartsEntrySearch(MaintenanceDTO objMaintenanceDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql ="SELECT " +

                   "MACHINE_PARTS_RECEIVE_ID, " +
             
           
                    "MACHINE_NAME,"+
                    "MACHINE_MODEL_NAME,"+
                    "MACHINE_PARTS,"+
               "TO_CHAR(RECEIVE_DATE,'dd/mm/yyyy')RECEIVE_DATE," +
               "DEPARTMENT_NAME," +
               "MR_NO,"+
               "BOX_NO,"+
                      "RECEIVE_QUANTITY"+
                  " FROM VEW_SEARCH_MAINTENANCE_RECEIVE WHERE head_office_id = '" + objMaintenanceDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objMaintenanceDTO.BranchOfficeId + "' ";

            if (objMaintenanceDTO.MachineMRNo.Length > 0)
            {

                sql = sql + "and MR_NO = '" + objMaintenanceDTO.MachineMRNo + "'";
            }

            if (objMaintenanceDTO.MachinelId.Length > 0)
            {

                sql = sql + "and MACHINE_ID = '" + objMaintenanceDTO.MachinelId + "'";
            }

            if (objMaintenanceDTO.MachineModelId.Length > 0)
            {

                sql = sql + "and MACHINE_MODEL_NAME_ID = '" + objMaintenanceDTO.MachineModelId + "'";
            }

            if (objMaintenanceDTO.MachinePartsId.Length > 0)
            {

                sql = sql + "and MACHINE_PARTS_ID = '" + objMaintenanceDTO.MachinePartsId + "'";
            }

           

            if (objMaintenanceDTO.PartsReceiveFromDate.Length > 6 && objMaintenanceDTO.PartsReceiveToDate.Length > 6)
            {

                sql = sql + "and RECEIVE_DATE between to_date('" + objMaintenanceDTO.PartsReceiveFromDate + "', 'dd/mm/yyyy') and to_date('" + objMaintenanceDTO.PartsReceiveToDate + "', 'dd/mm/yyyy') ";
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

        public DataTable MachinePartsReceivedSearch(MaintenanceDTO objMaintenanceDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +

                   "MACHINE_PARTS_RECEIVE_ID, " +
                    "MACHINE_NAME," +
                    "MACHINE_MODEL_NAME," +
                    "MACHINE_PARTS," +
                       "TO_CHAR(RECEIVE_DATE,'dd/mm/yyyy')RECEIVE_DATE," +
                      "MR_NO," +
                      "BOX_NO," +
                      "RECEIVE_QUANTITY"+
                  " FROM VEW_SEARCH_MAINTENANCE_RECEIVE WHERE head_office_id = '" + objMaintenanceDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objMaintenanceDTO.BranchOfficeId + "' ";

            //if (objMaintenanceDTO.MachineMRNo.Length > 0)
            //{

            //    sql = sql + "and MR_NO = '" + objMaintenanceDTO.MachineMRNo + "'";
            //}

            if (objMaintenanceDTO.MachinelId.Length > 0)
            {

                sql = sql + "and MACHINE_ID = '" + objMaintenanceDTO.MachinelId + "'";
            }

            if (objMaintenanceDTO.MachineModelId.Length > 0)
            {

                sql = sql + "and MACHINE_MODEL_NAME_ID = '" + objMaintenanceDTO.MachineModelId + "'";
            }

            if (objMaintenanceDTO.MachinePartsId.Length > 0)
            {

                sql = sql + "and MACHINE_PARTS_ID = '" + objMaintenanceDTO.MachinePartsId + "'";
            }



            if (objMaintenanceDTO.PartsIssueFromDate.Length > 6 && objMaintenanceDTO.PartsIssueToDate.Length > 6)
            {

                sql = sql + "and RECEIVE_DATE between to_date('" + objMaintenanceDTO.PartsIssueFromDate + "', 'dd/mm/yyyy') and to_date('" + objMaintenanceDTO.PartsIssueToDate + "', 'dd/mm/yyyy') ";
            }



            sql = sql + " Order by MACHINE_PARTS_RECEIVE_ID ";

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
        #endregion

        #region loadMethod

        public DataTable loadMachinPartsInfo(string strHeadOffieId, string strBranchOffieId)
        {

            MaintenanceDTO objMaintenanceDTO = new MaintenanceDTO();
            MaintenanceDAL objMaintenanceDAL = new MaintenanceDAL();

            DataTable dt = new DataTable();

            string sql = "";
            sql = "SELECT " +

                   "MACHINE_PARTS_ID, " +
                   "MACHINE_NAME, " +
                   "MACHINE_MODEL_NAME ," +

                       "MACHINE_PARTS " +

                  " FROM VEW_SEARCH_MACHINE_PARTS ORDER BY MACHINE_PARTS_ID ";

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

        public DataTable loadMachineNameInfo(string strHeadOffieId, string strBranchOfficeId)
        {

            MaintenanceDTO objMaintenanceDTO = new MaintenanceDTO();
            MaintenanceDAL objMaintenanceDAL = new MaintenanceDAL();

            DataTable dt = new DataTable();

            string sql = "";
            sql = "SELECT " +

                 "MACHINE_ID, " +

                  "MACHINE_NAME " +

                 " FROM L_MACHINE_NAME_MANTAINANCE ORDER BY MACHINE_ID ";

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

        public DataTable loadMachineModelInfo(string strHeadOffieId, string strBranchOffieId)
        {

            MaintenanceDTO objMaintenanceDTO = new MaintenanceDTO();
            MaintenanceDAL objMaintenanceDAL = new MaintenanceDAL();
            DataTable dt = new DataTable();

            string sql = "";
            sql = "SELECT " +

                   "MACHINE_MODEL_NAME_ID, " +

                   "MACHINE_NAME, " +
                     "MACHINE_MODEL_NAME " +
                  " FROM VEW_SEARCH_MACHINE_MODEL_NAME ORDER BY MACHINE_MODEL_NAME_ID ";

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


        public DataTable loadMachinePartsReceiveRecord(string strHeadOffieId, string strBranchOffieId)
        {

            MaintenanceDTO objMaintenanceDTO = new MaintenanceDTO();
            MaintenanceDAL objMaintenanceDAL = new MaintenanceDAL();
            DataTable dt = new DataTable();

            string sql = "";
            sql = "SELECT " +

                   "MACHINE_PARTS_RECEIVE_ID, " +
             
                    "TO_CHAR(RECEIVE_DATE,'dd/mm/yyyy')RECEIVE_DATE," +
                    "MACHINE_NAME,"+
                    "MACHINE_MODEL_NAME,"+
                    "MACHINE_PARTS,"+
                    "DEPARTMENT_NAME,"+
                      "MR_NO," +
                        "BOX_NO," +
                        "RECEIVE_QUANTITY"+
                  " FROM VEW_SEARCH_MAINTENANCE_RECEIVE ORDER BY MACHINE_PARTS_RECEIVE_ID ";

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

        public DataTable loadMachinePartsIssueRecord(MaintenanceDTO objMaintenanceDTO)
        {

            MaintenanceDAL objMaintenanceDAL = new MaintenanceDAL();
            DataTable dt = new DataTable();

            string sql = "";
            sql = "SELECT " +

                   "MACHINE_PARTS_ISSUE_ID, " +

                    
                    "MACHINE_NAME," +
                    "MACHINE_MODEL_NAME," +
                    "MACHINE_PARTS," +
                    "TO_CHAR(ISSUE_DATE,'dd/mm/yyyy')ISSUE_DATE," +

                   
                    "ISSUE_QUANTITY," +
                    "SR_NO" +
                  
                  
                  " FROM VEW_SEARCH_MAINTENANCE_ISSUE Where head_office_id ='"+objMaintenanceDTO.HeadOfficeId+"' and branch_office_id ='"+objMaintenanceDTO.BranchOfficeId+"' ";

            if (objMaintenanceDTO.MachinePartsIssueId.Length > 0)
            {

                sql = sql + "and MACHINE_PARTS_ISSUE_ID = '" + objMaintenanceDTO.MachinePartsIssueId + "'";
            }
            if (objMaintenanceDTO.MachinelId.Length > 0)
            {

                sql = sql + "and MACHINE_ID = '" + objMaintenanceDTO.MachinelId + "'";
            }
            if (objMaintenanceDTO.MachineModelId.Length > 0)
            {

                sql = sql + "and MACHINE_MODEL_NAME_ID = '" + objMaintenanceDTO.MachineModelId + "'";
            }

            if (objMaintenanceDTO.MachinePartsId.Length > 0)
            {

                sql = sql + "and MACHINE_PARTS_ID = '" + objMaintenanceDTO.MachinePartsId + "'";
            }



            if (objMaintenanceDTO.PartsIssueFromDate.Length > 6 && objMaintenanceDTO.PartsIssueToDate.Length > 6)
            {

                sql = sql + "and ISSUE_DATE between to_date('" + objMaintenanceDTO.PartsIssueFromDate + "', 'dd/mm/yyyy') and to_date('" + objMaintenanceDTO.PartsIssueToDate + "', 'dd/mm/yyyy') ";
            }


            sql = sql + " order by MACHINE_PARTS_ISSUE_ID ";

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
        #endregion
    }

}

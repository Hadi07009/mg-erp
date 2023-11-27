using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

using SINHA.MEDLAR.ERP.DTO;

using SINHA.MEDLAR.ERP.DTO;


using Oracle.ManagedDataAccess.Client;

using System.Configuration;

namespace SINHA.MEDLAR.ERP.DAL
{
    public class WorkerProcessDAL
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

        public string saveWorkerSkillProcess(WokerProcessDTO objWokerProcessDTO)
        {

            string strMsg = "";
            OracleTransaction trans = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_worker_process_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objWokerProcessDTO.ProcessId!= "")
            {

                objOracleCommand.Parameters.Add("P_PROCESS_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.ProcessId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_PROCESS_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objWokerProcessDTO.ProcessTypeId != "")
            {

                objOracleCommand.Parameters.Add("P_PROCESS_TYPE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.ProcessTypeId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_PROCESS_TYPE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objWokerProcessDTO.SizeId != "")
            {

                objOracleCommand.Parameters.Add("P_SIZE_TYPE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.SizeId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_SIZE_TYPE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objWokerProcessDTO.ProcessName != "")
            {

                objOracleCommand.Parameters.Add("P_PROCESS_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.ProcessName;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_PROCESS_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.BranchOfficeId;


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
        public string saveMachineDetailInformation(WokerProcessDTO objWokerProcessDTO)
        {

            string strMsg = "";
            OracleTransaction trans = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_machine_information_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objWokerProcessDTO.MachineId != "")
            {

                objOracleCommand.Parameters.Add("P_MACHINE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.MachineId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_MACHINE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objWokerProcessDTO.MachineType != "")
            {

                objOracleCommand.Parameters.Add("P_MACHINE_TYPE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.MachineType;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_MACHINE_TYPE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objWokerProcessDTO.BrandId != "")
            {

                objOracleCommand.Parameters.Add("P_MACHINE_BRAND_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.BrandId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_MACHINE_BRAND_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objWokerProcessDTO.ModelId != "")
            {

                objOracleCommand.Parameters.Add("P_MACHINE_MODEL_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.ModelId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_MACHINE_MODEL_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objWokerProcessDTO.MachineRegionId != "")
            {

                objOracleCommand.Parameters.Add("P_MACHINE_REGION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.MachineRegionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_MACHINE_REGION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objWokerProcessDTO.ManufacturerSL != "")
            {

                objOracleCommand.Parameters.Add("P_MACNUFACTURER_SERIAL_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.ManufacturerSL;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_MACNUFACTURER_SERIAL_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objWokerProcessDTO.MALSL != "")
            {

                objOracleCommand.Parameters.Add("P_MAL_SERIAL_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.MALSL;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_MAL_SERIAL_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.BranchOfficeId;


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
        public string saveMachineTypeInfo(WokerProcessDTO objWokerProcessDTO)
        {

            string strMsg = "";
            OracleTransaction trans = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_machine_type_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objWokerProcessDTO.MachineId != "")
            {

                objOracleCommand.Parameters.Add("P_MACHINE_TYPE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.MachineId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_MACHINE_TYPE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objWokerProcessDTO.MachineType != "")
            {

                objOracleCommand.Parameters.Add("P_MACHINE_TYPE_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.MachineType;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_MACHINE_TYPE_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.BranchOfficeId;


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
        public string saveMachineRegionInfo(WokerProcessDTO objWokerProcessDTO)
        {

            string strMsg = "";
            OracleTransaction trans = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_machine_region_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objWokerProcessDTO.MachineRegionId != "")
            {

                objOracleCommand.Parameters.Add("P_MACHINE_REGION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.MachineRegionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_MACHINE_REGION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objWokerProcessDTO.MachineRegionName != "")
            {

                objOracleCommand.Parameters.Add("P_MACHINE_REGION_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.MachineRegionName;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_MACHINE_REGION_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.BranchOfficeId;


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
        public string saveMachineModel(WokerProcessDTO objWokerProcessDTO)
        {

            string strMsg = "";
            OracleTransaction trans = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_machine_model_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objWokerProcessDTO.ModelId != "")
            {

                objOracleCommand.Parameters.Add("P_MACHINE_MODEL_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.ModelId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_MACHINE_MODEL_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objWokerProcessDTO.ModelName != "")
            {

                objOracleCommand.Parameters.Add("P_MACHINE_MODEL_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.ModelName;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_MACHINE_MODEL_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.BranchOfficeId;


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
        public string saveMachineBrand(WokerProcessDTO objWokerProcessDTO)
        {

            string strMsg = "";
            OracleTransaction trans = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_machine_brand_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objWokerProcessDTO.BrandId != "")
            {

                objOracleCommand.Parameters.Add("P_MACHINE_BRAND_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.BrandId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_MACHINE_BRAND_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objWokerProcessDTO.BrandName != "")
            {

                objOracleCommand.Parameters.Add("P_MACHINE_BRAND_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.BrandName;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_MACHINE_BRAND_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.BranchOfficeId;


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
        public string saveIESize(WokerProcessDTO objWokerProcessDTO)
        {

            string strMsg = "";
            OracleTransaction trans = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_ie_size_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objWokerProcessDTO.SizeId != "")
            {

                objOracleCommand.Parameters.Add("P_SIZE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.SizeId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_SIZE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objWokerProcessDTO.SizeName != "")
            {

                objOracleCommand.Parameters.Add("P_SIZE_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.SizeName;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_SIZE_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.BranchOfficeId;


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

        public string saveWorkerSkill(WokerProcessDTO objWokerProcessDTO)
        {

            string strMsg = "";
            OracleTransaction trans = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_worker_skill_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objWokerProcessDTO.EmployeeId != "")
            {

                objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.EmployeeId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objWokerProcessDTO.ProcessId != "")
            {

                objOracleCommand.Parameters.Add("P_process_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.ProcessId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_process_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objWokerProcessDTO.SizeId != "")
            {

                objOracleCommand.Parameters.Add("P_SIZE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.SizeId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_SIZE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objWokerProcessDTO.SMV != "")
            {

                objOracleCommand.Parameters.Add("P_SMV", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.SMV;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_SMV", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.BranchOfficeId;


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

        public DataTable searchMachineEntryResult(WokerProcessDTO objWokerProcessDTO)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            DataTable dt = new DataTable();

            string sql = "";
            sql = "SELECT " +
                "rownum sl, "+
                "MACHINE_ID, " +
               "MACHINE_TYPE_ID, " +
               "MACHINE_TYPE_NAME, " +
               "MACHINE_BRAND_ID, " +
               "MACHINE_BRAND_NAME, " +
               "MACHINE_MODEL_ID, " +
               "MACHINE_MODEL_NAME, " +
               "MACHINE_REGION_ID, " +
               "MACHINE_REGION_NAME, " +
               "MACNUFACTURER_SERIAL_NO, " +
               "MAL_SERIAL_NO, " +
               "UPDATE_BY, " +
               "UPDATE_DATE, " +
               "HEAD_OFFICE_ID, " +
               "BRANCH_OFFICE_ID " +


               "from VEW_SEARCH_MACHINE_BASIC_INFO where head_office_id = '" + objWokerProcessDTO.HeadOfficeId + "' AND branch_office_id = '" + objWokerProcessDTO.BranchOfficeId + "'  ";


            if (objWokerProcessDTO.BrandId.Length > 0 )
            {

                sql = sql + " and MACHINE_BRAND_ID ='" + objWokerProcessDTO .BrandId+ "' ";

            }

            if (objWokerProcessDTO.ModelId.Length > 0)
            {

                sql = sql + " and MACHINE_MODEL_ID ='" + objWokerProcessDTO.ModelId + "' ";

            }



            if (objWokerProcessDTO.MachineRegionId.Length > 0)
            {

                sql = sql + " and MACHINE_REGION_ID ='" + objWokerProcessDTO.MachineRegionId + "' ";

            }

            if (objWokerProcessDTO.MachineType.Length > 0)
            {

                sql = sql + " and MACHINE_TYPE_ID ='" + objWokerProcessDTO.MachineType + "' ";

            }

            if (objWokerProcessDTO.MachineType.Length > 0)
            {

                sql = sql + " order by  sl ";

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


        public string deleteWorkerProcess(WokerProcessDTO objWokerProcessDTO)
        {

            string strMsg = "";
            OracleTransaction trans = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_delete_worker_process");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objWokerProcessDTO.ProcessId != "")
            {

                objOracleCommand.Parameters.Add("P_PROCESS_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.ProcessId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_PROCESS_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }



            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.BranchOfficeId;


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

        public string deleteWorkerSize(WokerProcessDTO objWokerProcessDTO)
        {

            string strMsg = "";
            OracleTransaction trans = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_delete_worker_size");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objWokerProcessDTO.SizeId != "")
            {

                objOracleCommand.Parameters.Add("P_SIZE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.SizeId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_SIZE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }



            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.BranchOfficeId;


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
        public string saveTBInformation(WokerProcessDTO objWokerProcessDTO)
        {

            string strMsg = "";
            OracleTransaction trans = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_size_basic_info_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objWokerProcessDTO.ProcessId != "")
            {

                objOracleCommand.Parameters.Add("P_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.ProcessId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objWokerProcessDTO.ProcessTypeId != "")
            {

                objOracleCommand.Parameters.Add("P_SIZE_TYPE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.ProcessTypeId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_SIZE_TYPE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objWokerProcessDTO.ProcessName != "")
            {

                objOracleCommand.Parameters.Add("P_SIZE_TYPE_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.ProcessName;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_SIZE_TYPE_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objWokerProcessDTO.ProcessSelectTypeId != "")
            {

                objOracleCommand.Parameters.Add("P_PROCESS_SELECT_TYPE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.ProcessSelectTypeId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_PROCESS_SELECT_TYPE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objWokerProcessDTO.BranchOfficeId;


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

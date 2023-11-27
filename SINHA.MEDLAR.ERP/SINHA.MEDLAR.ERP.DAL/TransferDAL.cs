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
    public class TransferDAL
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

        public DataTable loadEmployeeTransferEntry()
        {

            LeaveDTO objEmployeeLeaveDTO = new LeaveDTO();


            DataTable dt = new DataTable();

            string sql = "";
            sql = "SELECT " +
                  "EMPLOYEE_ID, " +
                  "(SELECT EMPLOYEE_NAME FROM EMPLOYEE_BASIC_INFORMATION WHERE EMPLOYEE_CODE = T.EMPLOYEE_CODE)EMPLOYEE_NAME, " +
                  "TRANSFER_YEAR, " +
                  "TRANSFER_MONTH, " +
                  "TRANSFER_DATE, " +
                  "EFECTIVE_DATE, " +
                  "APPROVED_BY " +


                  "FROM EMPLOYEE_TRANSFER T ORDER BY EMPLOYEE_ID";

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


        public string saveEmployeeTransfer(TransferDTO objEmployeeTransferDTO)
        {

           
            string strMsg = "";


            OracleCommand objOracleCommand = new OracleCommand("pro_employee_transfer");

            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objEmployeeTransferDTO.EmployeeId != "")
            {
                objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeTransferDTO.EmployeeId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }




            if (objEmployeeTransferDTO.HeadOfficeId != "")
            {
                objOracleCommand.Parameters.Add("p_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeTransferDTO.HeadOfficeId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeTransferDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeTransferDTO.UnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeTransferDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeTransferDTO.SectionId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objEmployeeTransferDTO.DesignationId != "")
            {
                objOracleCommand.Parameters.Add("p_designation_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeTransferDTO.DesignationId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_designation_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeTransferDTO.DepartmentId != "")
            {
                objOracleCommand.Parameters.Add("p_department_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeTransferDTO.DepartmentId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_department_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objEmployeeTransferDTO.CatagoryId != "")
            {
                objOracleCommand.Parameters.Add("p_catagory_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeTransferDTO.CatagoryId;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_catagory_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeTransferDTO.ApprovedBy != "")
            {
                objOracleCommand.Parameters.Add("p_approved_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeTransferDTO.ApprovedBy;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_approved_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }






            if (objEmployeeTransferDTO.TransferDate != "")
            {
                objOracleCommand.Parameters.Add("p_transfer_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeTransferDTO.TransferDate;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_transfer_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeTransferDTO.EffectiveDate != "")
            {
                objOracleCommand.Parameters.Add("p_efective_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeTransferDTO.EffectiveDate;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_efective_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeTransferDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeTransferDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeTransferDTO.UpdateBy;

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
        public string employeeTransferProcess(TransferDTO objEmployeeTransferDTO)
        {


            string strMsg = "";


            OracleCommand objOracleCommand = new OracleCommand("pro_employee_transfer_process");

            objOracleCommand.CommandType = CommandType.StoredProcedure;

         
            objOracleCommand.Parameters.Add("p_branch_office_id_to", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeTransferDTO.BranchOfficeIdTo;

            objOracleCommand.Parameters.Add("p_unit_id_from", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeTransferDTO.UnitIdFrom;
            objOracleCommand.Parameters.Add("p_unit_id_to", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeTransferDTO.UnitIdTo;

            objOracleCommand.Parameters.Add("p_section_id_from", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeTransferDTO.SectionIdFrom;
            objOracleCommand.Parameters.Add("p_section_id_to", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeTransferDTO.SectionIdTo;
          
            objOracleCommand.Parameters.Add("p_transfer_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeTransferDTO.Year;
            objOracleCommand.Parameters.Add("p_transfer_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeTransferDTO.Month;

            
            objOracleCommand.Parameters.Add("p_efective_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeTransferDTO.EffectiveDate;

            if (objEmployeeTransferDTO.ApprovedBy != "")
            {
                objOracleCommand.Parameters.Add("p_approved_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeTransferDTO.ApprovedBy;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_approved_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeTransferDTO.EmployeeId;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeTransferDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeTransferDTO.BranchOfficeId;
     


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

    }
}

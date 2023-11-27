using System;
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
    public class SalaryUnitDAL
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

        public string saveSalaryUnitInformation(SalaryUnitDTO objSalaryUnitDTO)
        {

            SalaryUnitDAL objSalaryUnitDAL = new SalaryUnitDAL();
            string strMsg = "";

            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("PRO_SALARY_UNIT_SAVE");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objSalaryUnitDTO.SalaryUnitId != "")
            {

                objOracleCommand.Parameters.Add("P_SALARY_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryUnitDTO.SalaryUnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SALARY_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;


            }

            if (objSalaryUnitDTO.SalaryUnitName != "")
            {

                objOracleCommand.Parameters.Add("P_SALARY_UNIT_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryUnitDTO.SalaryUnitName;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SALARY_UNIT_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;


            }



            objOracleCommand.Parameters.Add("P_ACTIVE_YN", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryUnitDTO.ActiveYn;



            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryUnitDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryUnitDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSalaryUnitDTO.BranchOfficeId;


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

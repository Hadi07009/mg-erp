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
    public class LineDAL
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

        public string saveLineInformation(LineDTO objLineDTO)
        {
            string strMsg = "";
            

            OracleCommand objOracleCommand = new OracleCommand("PRO_LINE_INFORMATION_SAVE");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objLineDTO.LineId != "")
            {

                objOracleCommand.Parameters.Add("P_LINE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLineDTO.LineId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_LINE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objLineDTO.LineName != "")
            {

                objOracleCommand.Parameters.Add("P_LINE_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLineDTO.LineName;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_LINE_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objLineDTO.ProductionUnitId != "")
            {

                objOracleCommand.Parameters.Add("P_PRODUCTIION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLineDTO.ProductionUnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PRODUCTIION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objLineDTO.SalaryUnitId != "")
            {

                objOracleCommand.Parameters.Add("P_SALARY_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLineDTO.SalaryUnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SALARY_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            objOracleCommand.Parameters.Add("P_ACTIVE_YN", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLineDTO.ActvieYn;


            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLineDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLineDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLineDTO.BranchOfficeId;


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

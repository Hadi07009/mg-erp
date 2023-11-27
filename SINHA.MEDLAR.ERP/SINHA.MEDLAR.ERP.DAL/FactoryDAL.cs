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
    public class FactoryDAL
    {
        OracleTransaction trans = null;

        private OracleConnection GetConnection()
        {
            var conString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConString"];
            string strConnString = conString.ConnectionString;
            return new OracleConnection(strConnString);
        }

        public string saveFactoryInformation(FactoryDTO objFactoryDTO)
        {
            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("PRO_FACTORY_INFORMATION_SAVE");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objFactoryDTO.FactoryId != "")
            {

                objOracleCommand.Parameters.Add("P_FACTORY_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFactoryDTO.FactoryId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_FACTORY_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objFactoryDTO.FactoryName != "")
            {

                objOracleCommand.Parameters.Add("P_FACTORY_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFactoryDTO.FactoryName;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_FACTORY_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objFactoryDTO.MobileNo != "")
            {

                objOracleCommand.Parameters.Add("P_FACTORY_ADDRESS", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFactoryDTO.MobileNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_FACTORY_ADDRESS", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objFactoryDTO.PhoneNo != "")
            {

                objOracleCommand.Parameters.Add("P_OFFICE_ADDRESS", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFactoryDTO.PhoneNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_OFFICE_ADDRESS", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objFactoryDTO.FaxNo != "")
            {

                objOracleCommand.Parameters.Add("P_PHONE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFactoryDTO.FaxNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PHONE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objFactoryDTO.EmailAddress != "")
            {

                objOracleCommand.Parameters.Add("P_FAX", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFactoryDTO.EmailAddress;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_FAX", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objFactoryDTO.FactoryAddress != "")
            {

                objOracleCommand.Parameters.Add("P_EMAIL_ADDRESS", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFactoryDTO.FactoryAddress;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_EMAIL_ADDRESS", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            objOracleCommand.Parameters.Add("P_ACTIVE_YN", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFactoryDTO.ActiveYn;


            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFactoryDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFactoryDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objFactoryDTO.BranchOfficeId;


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

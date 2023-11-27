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
    public class BankDAL
    {
        //OracleTransaction trans = null;

        private OracleConnection GetConnection()
        {
            var conString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConString"];
            string strConnString = conString.ConnectionString;
            return new OracleConnection(strConnString);
        }

        public string saveBankInformation(BankDTO objBankDTO)
        {
            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("pro_bank_information_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objBankDTO.BankId != "")
            {

                objOracleCommand.Parameters.Add("P_BANK_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objBankDTO.BankId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_BANK_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objBankDTO.BankName != "")
            {

                objOracleCommand.Parameters.Add("P_BANK_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objBankDTO.BankName;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_BANK_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objBankDTO.AccountNo != "")
            {

                objOracleCommand.Parameters.Add("P_BANK_ACCOUNT_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objBankDTO.AccountNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_BANK_ACCOUNT_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objBankDTO.SwiftCode != "")
            {

                objOracleCommand.Parameters.Add("P_SWIFT_CODE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objBankDTO.SwiftCode;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SWIFT_CODE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

          


            if (objBankDTO.MobileNo != "")
            {

                objOracleCommand.Parameters.Add("P_MOBILE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objBankDTO.MobileNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_MOBILE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objBankDTO.PhoneNo != "")
            {

                objOracleCommand.Parameters.Add("P_PHONE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objBankDTO.PhoneNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PHONE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objBankDTO.FaxNo != "")
            {

                objOracleCommand.Parameters.Add("P_FAX", OracleDbType.Varchar2, ParameterDirection.Input).Value = objBankDTO.FaxNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_FAX", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objBankDTO.EmailAddress != "")
            {

                objOracleCommand.Parameters.Add("P_EMAIL_ADDRESS", OracleDbType.Varchar2, ParameterDirection.Input).Value = objBankDTO.EmailAddress;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_EMAIL_ADDRESS", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objBankDTO.BankAddress != "")
            {

                objOracleCommand.Parameters.Add("P_BANK_ADDRESS", OracleDbType.Varchar2, ParameterDirection.Input).Value = objBankDTO.BankAddress;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_BANK_ADDRESS", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            objOracleCommand.Parameters.Add("P_ACTIVE_YN", OracleDbType.Varchar2, ParameterDirection.Input).Value = objBankDTO.ActiveYn;


            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objBankDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objBankDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objBankDTO.BranchOfficeId;


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

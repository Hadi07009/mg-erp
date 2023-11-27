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
    public class ColorDAL
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

        public string saveColorInformation(ColorDTO objColorDTO)
        {
          
            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("pro_color_information_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objColorDTO.ColorId != "")
            {
                objOracleCommand.Parameters.Add("p_color_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objColorDTO.ColorId;

            }
            else
            {
                objOracleCommand.Parameters.Add("p_color_id", OracleDbType.Varchar2, ParameterDirection.Input).Value =null;

            }

           
            if (objColorDTO.ColorShortName != "")
            {
                objOracleCommand.Parameters.Add("p_color_short_name", OracleDbType.Varchar2, ParameterDirection.Input).Value = objColorDTO.ColorShortName;

            }
            else
            {
                objOracleCommand.Parameters.Add("p_color_short_name", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objColorDTO.ColorFullName != "")
            {
                objOracleCommand.Parameters.Add("p_color_full_name", OracleDbType.Varchar2, ParameterDirection.Input).Value = objColorDTO.ColorFullName;

            }
            else
            {
                objOracleCommand.Parameters.Add("p_color_full_name", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objColorDTO.ActiveYn != "")
            {
                objOracleCommand.Parameters.Add("p_active_yn", OracleDbType.Varchar2, ParameterDirection.Input).Value = objColorDTO.ActiveYn;

            }
            else
            {
                objOracleCommand.Parameters.Add("p_active_yn", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }



            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objColorDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objColorDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objColorDTO.BranchOfficeId;


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


        public string saveColorContractInfo(ColorDTO objColorDTO)
        {

            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("pro_color_contract_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objColorDTO.ColorId != "")
            {
                objOracleCommand.Parameters.Add("p_color_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objColorDTO.ColorId;

            }
            else
            {
                objOracleCommand.Parameters.Add("p_color_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objColorDTO.ColorName != "")
            {
                objOracleCommand.Parameters.Add("p_color_name", OracleDbType.Varchar2, ParameterDirection.Input).Value = objColorDTO.ColorName;

            }
            else
            {
                objOracleCommand.Parameters.Add("p_color_name", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }




            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objColorDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objColorDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objColorDTO.BranchOfficeId;


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

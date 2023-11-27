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
    public class StyleDAL
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

        public string saveStyleInformation(StyleDTO objStyleDTO)
        {

            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("PRO_STYLE_INFORMATION_SAVE");
            objOracleCommand.CommandType = CommandType.StoredProcedure;



            if (objStyleDTO.BuyerId != "")
            {

                objOracleCommand.Parameters.Add("p_buyer_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objStyleDTO.BuyerId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_buyer_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objStyleDTO.styleId != "")
            {

                objOracleCommand.Parameters.Add("p_style_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objStyleDTO.styleId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_style_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }



            if (objStyleDTO.styleNo != "")
            {

                objOracleCommand.Parameters.Add("p_style_no", OracleDbType.Varchar2, ParameterDirection.Input).Value = objStyleDTO.styleNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_style_no", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objStyleDTO.StyleDes != "")
            {

                objOracleCommand.Parameters.Add("p_style_des", OracleDbType.Varchar2, ParameterDirection.Input).Value = objStyleDTO.StyleDes;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_style_des", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            objOracleCommand.Parameters.Add("p_active_yn", OracleDbType.Varchar2, ParameterDirection.Input).Value = objStyleDTO.StyleDes;


            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objStyleDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objStyleDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objStyleDTO.BranchOfficeId;


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

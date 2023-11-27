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
    public class ShareDistributionDAL
    {
        OracleTransaction trans = null;

        private OracleConnection GetConnection()
        {
            var conString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConString"];
            string strConnString = conString.ConnectionString;
            return new OracleConnection(strConnString);
        }
        public string SaveShareDistribution(ShareDistributionDTO objShareDistributionDTO)
        {
            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("sp_save_share_distribution");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objShareDistributionDTO.DistributionId != "")
            {
                objOracleCommand.Parameters.Add("P_DISTRIBUTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objShareDistributionDTO.DistributionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_DISTRIBUTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objShareDistributionDTO.CompanyId != "")
            {
                objOracleCommand.Parameters.Add("P_COMPANY_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objShareDistributionDTO.CompanyId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_COMPANY_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objShareDistributionDTO.ShareHolderId != "")
            {
                objOracleCommand.Parameters.Add("P_SHARE_HOLDER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objShareDistributionDTO.ShareHolderId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SHARE_HOLDER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objShareDistributionDTO.NomineeId != "")
            {
                objOracleCommand.Parameters.Add("P_NOMINEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objShareDistributionDTO.NomineeId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_NOMINEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objShareDistributionDTO.NoOfShare != "")
            {
                objOracleCommand.Parameters.Add("P_NO_OF_SHARE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objShareDistributionDTO.NoOfShare;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_NO_OF_SHARE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objShareDistributionDTO.FaceValue != "")
            {
                objOracleCommand.Parameters.Add("P_FACE_VALUE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objShareDistributionDTO.FaceValue;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_FACE_VALUE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objShareDistributionDTO.DisplayOrder != "")
            {
                objOracleCommand.Parameters.Add("P_DISPLAY_ORDER", OracleDbType.Varchar2, ParameterDirection.Input).Value = objShareDistributionDTO.DisplayOrder;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_DISPLAY_ORDER", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objShareDistributionDTO.UpdateBy;
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
        public string CalculateShare(ShareDistributionDTO objShareDistributionDTO)
        {
            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("sp_cal_cumulate_share_holding");
            objOracleCommand.CommandType = CommandType.StoredProcedure;
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
        public DataTable GetShareDistribution()
        {
            DataTable myTable = new DataTable();
            try
            {
                OracleCommand objOracleCommand = new OracleCommand("sp_get_share_distribution");
                objOracleCommand.CommandType = CommandType.StoredProcedure;
                objOracleCommand.Parameters.Add("p_dbcursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                string VALUE = string.Empty;

                using (OracleConnection strConn = GetConnection())
                {
                    try
                    {
                        objOracleCommand.Connection = strConn;
                        strConn.Open();
                        trans = strConn.BeginTransaction();

                        myTable.Load(objOracleCommand.ExecuteReader());
                        // OracleDataReader dr = objOracleCommand.ExecuteReader();
                        trans.Commit();
                        strConn.Close();
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return myTable;
        }
        public string DeleteShare(ShareDistributionDTO objShareDistributionDTO)
        {
            string strMsg = "";
            OracleCommand objOracleCommand = new OracleCommand("SP_DELETE_SHARE");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("P_SHARE_DISTRIBUTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objShareDistributionDTO.DistributionId;
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




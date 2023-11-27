using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

using Oracle.ManagedDataAccess.Client;


using SINHA.MEDLAR.ERP.DTO;
using System.IO;

namespace SINHA.MEDLAR.ERP.DAL
{
    public class SparePartDAL
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



        public string saveSparePartFile(string strSparePartId, string strFileName, byte strByte, string strEmployeeId, string strHeadOffieId, string strBranchOffieId)
        {

            SparePartDTO objSparePartDTO = new SparePartDTO();
            string strMsg = "";


            OracleCommand objOracleCommand = new OracleCommand("PRO_SPARE_PART_FILE_UPLOAD");

            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (strSparePartId.Length > 0 )
            {
                objOracleCommand.Parameters.Add("P_SPARE_PART_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = strSparePartId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_SPARE_PART_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            if (strFileName.Length > 0 )
            {
                objOracleCommand.Parameters.Add("P_FILE_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = strFileName;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_FILE_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            objOracleCommand.Parameters.Add("P_FILE_SIZE", OracleDbType.Blob, ParameterDirection.Input).Value = null;
            




            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = strEmployeeId;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = strHeadOffieId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = strBranchOffieId;


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
        public SparePartDTO searchSparePartsFile(string SlNo)
        {

            SparePartDTO objSparePartDTO = new SparePartDTO();
           

            string sql = "";
            sql = "SELECT " +
                  "FILE_SIZE " +


                  "FROM SPARE_PART_FILE_UPLOAD WHERE SL = '" + SlNo + "'";




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

                        //byte[] file = File.ReadAllBytes(objDataReader["FILE_SIZE"].ToString());
                        objSparePartDTO.FileName = objDataReader.GetString(0);
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
            return objSparePartDTO;

        }

    }
}

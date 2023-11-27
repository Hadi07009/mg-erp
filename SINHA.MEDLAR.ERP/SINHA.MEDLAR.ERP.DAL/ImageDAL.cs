using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Web.SessionState;
using Oracle.ManagedDataAccess.Client;

using SINHA.MEDLAR.ERP.DTO;
using System.IO;

namespace SINHA.MEDLAR.ERP.DAL
{
    public class ImageDAL
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

        public string saveEmployeeImage(ImageDTO objImageDTO)
        {

            LoginDTO objLoginDTO = new LoginDTO();
            string strMsg = "";


            OracleCommand objOracleCommand = new OracleCommand("pro_employee_pic_save");

            objOracleCommand.CommandType = CommandType.StoredProcedure;

          



            if (objImageDTO.EmployeeId != "")
            {
                objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objImageDTO.EmployeeId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }




            objOracleCommand.Parameters.Add("P_IMAGE_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objImageDTO.ImagePath;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objImageDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objImageDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objImageDTO.UpdateBy;

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

        public string deleteEmployeeImage(ImageDTO objImageDTO)
        {

            LoginDTO objLoginDTO = new LoginDTO();
            string strMsg = "";


            OracleCommand objOracleCommand = new OracleCommand("pro_delete_employee_image");

            objOracleCommand.CommandType = CommandType.StoredProcedure;





          
            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objImageDTO.EmployeeId;

            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objImageDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objImageDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objImageDTO.BranchOfficeId;
            

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
        public ImageDTO searchEmployeeImage(string strEmployeeId, string strHeadOfficeId, string strBranchOfficeId)
        {
            ImageDTO objImageDTO = new ImageDTO();
            string sql = "";

            sql = "SELECT " +
                  "to_char(nvl(IMAGE_ID, '0')), " +
                  "to_char(nvl(EMPLOYEE_ID,'0')), " +
                  "(select employee_name from employee_basic where employee_id = e.employee_id AND head_office_id = e.head_office_id)employee_name, " +
                  "to_char(nvl(IMAGE_NAME, 'N/A')) " +
                 



                  "FROM EMPLOYEE_IMAGE e WHERE  employee_id = '"+strEmployeeId+"' AND head_office_id = '"+objImageDTO.HeadOfficeId+"' and branch_office_id = '"+objImageDTO.BranchOfficeId+"' ";



            MemoryStream objMemoryStream = new MemoryStream ();
            OracleCommand objCommand = new OracleCommand(sql);
            
            OracleDataReader objDataReader;

            DataTable dt = new DataTable();

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                try
                {
                    while (objDataReader.Read())
                    {

                        objImageDTO.ImageId = objDataReader.GetString(0);
                        objImageDTO.EmployeeId = objDataReader.GetString(1);
                        objImageDTO.EmployeeName = objDataReader.GetString(2);
                        objImageDTO.ImagePath = objDataReader.GetString(3);
                        //string strImage = Convert.ToBase64String(objDataReader.GetString(3));


                        //objImageDTO.Image = objDataReader.GetByte(3);
                        //objImageDTO.ImagePath = objDataReader.GetString(3);
                        //byte[] file = File.ReadAllBytes(objDataReader["EMPLOYEE_IMAGE"].ToString());
                        //objDataReader.Close();

                        //objMemoryStream.Write(file, 0, file.Length);
                        //Response.Buffer = true;
                        //Response.BinaryWrite(file);

                        //objOracleDataAdapter.Fill(objCommand);


                        //objMemoryStream.Dispose();



                        

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
            return objImageDTO;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.BLL;
using System.Web.Security;

using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.IO;

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class FileUpload : System.Web.UI.Page
    {
        string strEmployeeId = "";
        string strSectionId = "";
        string strDepartmentId = "";
        string strDesignationId = "";
        string strUnitId = "";
        string strCatagoryId;
        string strHeadOfficeId = "";
        string strBranchOfficeId = "";
        string strEmployeeTypeId = "";
        string strLoginDay = "";
        string strLoginMonth = "";
        string strLoginDate = "";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }


        public void uploadFile()
        {

            if (!FileUpload1.HasFile)
            {
                Response.Write("No file Selected"); return;
            }
            else
            {
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                string extension = Path.GetExtension(filename);
                string contentType = FileUpload1.PostedFile.ContentType;
                HttpPostedFile file = FileUpload1.PostedFile;
                byte[] document = new byte[file.ContentLength];
                file.InputStream.Read(document, 0, file.ContentLength);

                //Validations  
                if ((extension == ".pdf") || (extension == ".doc") || (extension == ".docx") || (extension == ".xls"))//extension  
                {
                    if (file.ContentLength <= 31457280)//size  
                    {
                        //Insert the Data in the Table  
                        //using (SqlConnection connection = new SqlConnection())
                        //{
                        //    connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                        //    connection.Open();
                        //    SqlCommand cmd = new SqlCommand();
                        //    cmd.Connection = connection;
                        //    string commandText = @"insert into Documents(Name_File,DisplayName,Extension,ContentType,FileData,FileSize,UploadDate)                                                   values(@Name_File,@DisplayName,@Extension,@ContentType,@FileData,@FileSize,getdate())";
                        //    cmd.CommandText = commandText;
                        //    cmd.CommandType = CommandType.Text;
                        //    cmd.Parameters.Add("@Name_File", SqlDbType.VarChar);
                        //    cmd.Parameters["@Name_File"].Value = filename;
                        //    cmd.Parameters.Add("@DisplayName", SqlDbType.VarChar);

                        //    cmd.Parameters["@DisplayName"].Value = txtfilename.Text.Trim();
                        //    cmd.Parameters.Add("@Extension", SqlDbType.VarChar);
                        //    cmd.Parameters["@Extension"].Value = extension;

                        //    cmd.Parameters.Add("@ContentType", SqlDbType.VarChar);
                        //    cmd.Parameters["@ContentType"].Value = contentType;

                        //    cmd.Parameters.Add("@FileData", SqlDbType.VarBinary);
                        //    cmd.Parameters["@FileData"].Value = document;

                        //    cmd.Parameters.Add("@FileSize", SqlDbType.BigInt);
                        //    cmd.Parameters["@FileSize"].Value = document.Length;
                        //    cmd.ExecuteNonQuery();
                        //    cmd.Dispose();
                        //    connection.Close();
                        //    Response.Write("Data has been Added");
                        //}

                    }
                    else
                    { Response.Write("Inavlid File size"); return; }
                }
                else
                {
                    Response.Write("Inavlid File"); return;
                }
            }
        } 





    }
}
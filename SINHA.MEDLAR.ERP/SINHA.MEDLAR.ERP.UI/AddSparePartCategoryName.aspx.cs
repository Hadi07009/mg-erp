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

using System.IO;

using System.Net;

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class AddSparePartCategoryName : System.Web.UI.Page
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
            if (Session["strEmployeeId"] == null)
            {
                sessionEmpty();
                return;

            }
            if (!IsPostBack)
            {
                loadSesscion();
                loadPartCategoryRecord();
                getOfficeName();
                getEquipementId();
                getPartId();
                
            }



            if (IsPostBack)
            {

                loadSesscion();
                
            }

            txtSparePartCategoryName.Attributes.Add("onkeypress", "return controlEnter('" + txtSparePartCategoryNo.ClientID + "', event)");
            txtSparePartCategoryNo.Attributes.Add("onkeypress", "return controlEnter('" + txtQuantity.ClientID + "', event)");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (ddlEquipementId.Text == " ")
            {
                string strMsg = "Please Select Equipement Name!!!";
                MessageBox(strMsg);
                ddlEquipementId.Focus();
                return;

            }


            else if (ddlSparePartId.Text ==" ")
            {

                string strMsg = "Please Select Part Name!!!";
                MessageBox(strMsg);
                ddlSparePartId.Focus();
                return;
            }

            else if (txtSparePartCategoryName.Text == string.Empty)
            {

                string strMsg = "Please Enter Part Category Name!!!";
                MessageBox(strMsg);
                //ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "alert('Please Enter Unit Name');", true);
                txtSparePartCategoryName.Focus();
                return ;
            }

            else if (txtQuantity.Text == string.Empty)
            {

                string strMsg = "Please Enter Quantity!!!";
                MessageBox(strMsg);
                //ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "alert('Please Enter Unit Name');", true);
                txtQuantity.Focus();
                return;
            }


            else if (txtSparePartCategoryNo.Text == string.Empty)
            {

                string strMsg = "Please Enter Part Category No!!!";
                MessageBox(strMsg);
                //ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "alert('Please Enter Unit Name');", true);
                txtSparePartCategoryNo.Focus();
                return;
            }
            else
            {
                savePartCategoryInfo();
                uploadSparePartsFile();
                loadPartCategoryRecord();

            }

        }



        #region "Function"

        public void loadSesscion()
        {

            strEmployeeId = Session["strEmployeeId"].ToString().Trim();
            strSectionId = Session["strSectionId"].ToString().Trim();

            strDesignationId = Session["strDesignationId"].ToString().Trim();
            strUnitId = Session["strUnitId"].ToString().Trim();
            strCatagoryId = Session["strCatagoryId"].ToString().Trim();
            strHeadOfficeId = Session["strHeadOfficeId"].ToString().Trim();
            strBranchOfficeId = Session["strBranchOfficeId"].ToString().Trim();
            //strEmployeeTypeId = Session["strEmployeeTypeId"].ToString().Trim();
            strLoginDay = Session["strLoginDay"].ToString().Trim();
            strLoginMonth = Session["strLoginMonth"].ToString().Trim();
            strLoginDate = Session["strLoginDate"].ToString().Trim();

        }
        public void uploadSparePartsFile()
        {
            try
            {

                if (ddlSparePartId.Text == " ")
                {
                    string strMsg = "Please Select Spare Part Name!!!";
                    ddlSparePartId.Focus();
                    MessageBox(strMsg);
                    return;

                }
                else
                {


                        LookUpDTO objLookUpDTO = new LookUpDTO();
                        LookUpBLL objLookUpBLL = new LookUpBLL();

                        HttpPostedFile imgFile = FileUpload1.PostedFile;

                        string strContentType = FileUpload1.PostedFile.ContentType;

                        string strFileName = FileUpload1.PostedFile.FileName;
                        string strFileNamePath = Path.GetFileName(strFileName);
                        string ext = Path.GetExtension(strFileNamePath);
                        txtFileName.Text = FileUpload1.FileName; ;



                        FileInfo fi = new System.IO.FileInfo(FileUpload1.PostedFile.FileName);

                        string fileName = fi.Name;
                        BinaryReader b = new BinaryReader(imgFile.InputStream);
                        byte[] byteArray = b.ReadBytes(imgFile.ContentLength);
                        string fileSize = Convert.ToBase64String(byteArray);


                        if (FileUpload1.PostedFile != null && FileUpload1.PostedFile.ContentLength > 0)
                        {


                            if (ddlSparePartId.SelectedValue.ToString() != " ")
                            {
                                objLookUpDTO.SparePartId = ddlSparePartId.SelectedValue.ToString();
                            }
                            else
                            {
                                objLookUpDTO.SparePartId = "";

                            }


                            objLookUpDTO.FileName = strFileName;

                            objLookUpDTO.FileSize = fileSize;


                            objLookUpDTO.UpdateBy = strEmployeeId;
                            objLookUpDTO.HeadOfficeId = strHeadOfficeId;
                            objLookUpDTO.BranchOfficeId = strBranchOfficeId;

                            string strMsg = objLookUpBLL.SparePartsFileSave(objLookUpDTO);
                            //MessageBox(strMsg);




                        }


                     
                      
                    

                }


            }

            catch (Exception ex)
            {

                FileUpload1.Dispose();
                FileUpload1.FileContent.Dispose();
                FileUpload1.PostedFile.InputStream.Close();
                FileUpload1.PostedFile.InputStream.Dispose();
                lblMsg.Text = ex.Message;

            }


            //Response.Redirect(Request.Url.AbsoluteUri);

        }
        public void savePDFFile()
        {










        }


        public void getEquipementId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlEquipementId.DataSource = objLookUpBLL.getEquipementId(strHeadOfficeId, strBranchOfficeId);

            ddlEquipementId.DataTextField = "EQUIPMENT_NAME";
            ddlEquipementId.DataValueField = "EQUIPMENT_ID";

            ddlEquipementId.DataBind();
            if (ddlEquipementId.Items.Count > 0)
            {

                ddlEquipementId.SelectedIndex = 0;
            }

        }


        public void getPartId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            string strEquipementId = "";
            if (ddlEquipementId.Text != " ")
            {
                strEquipementId = ddlEquipementId.SelectedValue.ToString();
            }
            else
            {
                strEquipementId = "";

            }

            ddlSparePartId.DataSource = objLookUpBLL.getPartId(strEquipementId, strHeadOfficeId, strBranchOfficeId);

            ddlSparePartId.DataTextField = "SPARE_PART_NAME";
            ddlSparePartId.DataValueField = "SPARE_PART_ID";

            ddlSparePartId.DataBind();
            if (ddlSparePartId.Items.Count > 0)
            {

                ddlSparePartId.SelectedIndex = 0;
            }

        }


        public void sessionEmpty()
        {
            Session["strEmployeeId"] = null;
            Session["strSectionId"] = null;
            Session["strDepartmentId"] = null;
            Session["strDesignationId"] = null;
            Session["strUnitId"] = null;
            Session["strCatagoryId"] = null;
            Session["strHeadOfficeId"] = null;
            Session["strBranchOfficeId"] = null;
            Session["strLoginDay"] = null;
            Session["strLoginMonth"] = null;
            Session["strLoginDate"] = null;
            Session.Clear();
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            FormsAuthentication.SignOut();
            Response.Redirect("Login.aspx", true);

        }

        public void getOfficeName()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.getHeadOfficeName(strHeadOfficeId, strBranchOfficeId);

            lblHeadOfficeName.Text = objLookUpDTO.HeadOfficeName;
            lblHeadOfficeAddress.Text = objLookUpDTO.HeadOfficeAddress;
            lblBranchOfficeName.Text = objLookUpDTO.BranchOfficeName;
            lblBranchOfficeAddress.Text = objLookUpDTO.BranchOfficeAddress;

        }


        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }

        public void savePartCategoryInfo()
        {


            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            if (ddlSparePartId.SelectedValue.ToString() != " ")
            {
                objLookUpDTO.SparePartId = ddlSparePartId.SelectedValue.ToString();
            }
            else
            {
                objLookUpDTO.SparePartId = "";

            }

            objLookUpDTO.SparePartCategoryId = txtSparePartCategoryId.Text;
            objLookUpDTO.SparePartCategoryName = txtSparePartCategoryName.Text;
            objLookUpDTO.SparePartCategoryNo = txtSparePartCategoryNo.Text;
            objLookUpDTO.QuantityPerEnginee = txtQuantity.Text;

            objLookUpDTO.ItemNo = txtItemNo.Text;

            objLookUpDTO.UpdateBy = strEmployeeId;
            objLookUpDTO.HeadOfficeId = strHeadOfficeId;
            objLookUpDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objLookUpBLL.savePartCategoryInfo(objLookUpDTO);
            MessageBox(strMsg);

        }

        public void deleteSparePartCategory()
        {


            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO.SparePartCategoryId = txtSparePartCategoryId.Text;
            objLookUpDTO.BranchOfficeName = "";

            objLookUpDTO.UpdateBy = strEmployeeId;
            objLookUpDTO.HeadOfficeId = strHeadOfficeId;
            objLookUpDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objLookUpBLL.deleteSparePartCategory(objLookUpDTO);
            MessageBox(strMsg);

        }


        public void searchPartCategoryInfo()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.searchPartCategoryInfo(txtSparePartCategoryId.Text, strHeadOfficeId, strBranchOfficeId);

            txtSparePartCategoryName.Text = objLookUpDTO.SparePartCategoryName;
            txtSparePartCategoryNo.Text = objLookUpDTO.SparePartCategoryNo;
            txtQuantity.Text = objLookUpDTO.QuantityPerEnginee;
            txtItemNo.Text = objLookUpDTO.ItemNo;

            if (objLookUpDTO.ItemNo == "0")
            {
                txtItemNo.Text ="";


            }
            else
            {

                txtItemNo.Text = objLookUpDTO.ItemNo;

            }

            if (objLookUpDTO.SparePartId == "0")
            {

                //nothing to do
            }
            else
            {
                ddlSparePartId.SelectedValue = objLookUpDTO.SparePartId;
            }

            if (objLookUpDTO.EquipmetId == "0")
            {

                //nothing to do
            }
            else
            {
                ddlEquipementId.SelectedValue = objLookUpDTO.EquipmetId;
            }


        }

        public void loadPartCategoryRecord()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            string strPartId = "", strPartNo;

            if (ddlSparePartId.Text != "0")
            {
                strPartId = ddlSparePartId.SelectedValue.ToString();
            }
            else
            {
                strPartId = "";

            }

            if (txtPartNo.Text != " ")
            {
                strPartNo = txtPartNo.Text;
            }
            else
            {
                strPartNo = "";

            }



            dt = objLookUpBLL.loadPartCategoryRecord(strPartId, strPartNo, strHeadOfficeId, strBranchOfficeId);


            if (dt.Rows.Count > 0)
            {
                gvUnit.DataSource = dt;
                gvUnit.DataBind();
                string strMsg = "TOTAL " + gvUnit.Rows.Count + " RECORD FOUND";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvUnit.DataSource = dt;
                gvUnit.DataBind();
                int totalcolums = gvUnit.Rows[0].Cells.Count;
                gvUnit.Rows[0].Cells.Clear();
                gvUnit.Rows[0].Cells.Add(new TableCell());
                gvUnit.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvUnit.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                MessageBox(strMsg);
                lblMsg.Text = strMsg;

            }


        }


        public void clearTextBox()
        {
            txtSparePartCategoryId.Text = "";
            txtSparePartCategoryName.Text = "";
            txtSparePartCategoryNo.Text = "";
            txtQuantity.Text = "";
            txtItemNo.Text = "";
        }

        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSparePartCategoryId.Text == string.Empty)
            {

                string strMsg = "Please Enter Part Category ID!!!";
                MessageBox(strMsg);
                txtSparePartCategoryId.Focus();
                return;
            }
            else
            {
                searchPartCategoryInfo();

            }
        }


        public void deleteSparePartInfo(string strSparePartId, string strOfficeName)
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO.SparePartCategoryId = strSparePartId;

            objLookUpDTO.BranchOfficeName = strOfficeName;
            objLookUpDTO.UpdateBy = strEmployeeId;
            objLookUpDTO.HeadOfficeId = strHeadOfficeId;
            objLookUpDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objLookUpBLL.deleteSparePartInfo(objLookUpDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);


        }

        protected void btnSearchByCardNo_Click(object sender, EventArgs e)
        {
            if (txtSparePartCategoryId.Text == string.Empty)
            {

                string strMsg = "Please Enter Part Category ID!!!";
                MessageBox(strMsg);
                txtSparePartCategoryId.Focus();
                return;
            }
            else
            {
                searchPartCategoryInfo();

            }
        }

        protected void gvUnit_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUnit.PageIndex = e.NewPageIndex;
            loadPartCategoryRecord();
        }

        protected void gvUnit_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int stor_id = Convert.ToInt32(gvUnit.DataKeys[e.RowIndex].Values["SPARE_PART_CATEGORY_ID"].ToString());
            string strOfficeName = (gvUnit.DataKeys[e.RowIndex].Values["BRANCH_OFFICE_NAME"].ToString());

            string strSparePartId = Convert.ToString(stor_id);

            deleteSparePartInfo(strSparePartId, strOfficeName);
            
            loadPartCategoryRecord();


        }
        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvUnit, "Select$" + e.Row.RowIndex);
            }
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvUnit.SelectedRow.RowIndex;
            string strUnitId = gvUnit.SelectedRow.Cells[0].Text;
            string strUnitName = gvUnit.SelectedRow.Cells[1].Text;
            string strUnitNameBng = gvUnit.SelectedRow.Cells[2].Text;
           

            txtSparePartCategoryId.Text = strUnitId;
            //txtSparePartCategoryName.Text = strUnitName;
            //txtSparePartCategoryNo.Text = strUnitNameBng;

            searchPartCategoryInfo();


            
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                clearTextBox();
                getPartId();
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " +ex.Message);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSparePartCategoryId.Text == string.Empty)
                {

                    string strMsg = "Please Enter Part Category ID!!!";
                    MessageBox(strMsg);
                    txtSparePartCategoryId.Focus();
                    return;
                }
                else
                {

                    deleteSparePartCategory();
                    clearTextBox();
                    loadPartCategoryRecord();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
        }

        protected void ddlEquipementId_SelectedIndexChanged(object sender, EventArgs e)
        {
            getPartId();
        }

        protected void ddlSparePartId_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadPartCategoryRecord();
        }




        protected void btnView_Click(object sender, EventArgs e)
        {


            //string embed = "<object data=\"{0}{1}\" type=\"application/pdf\" width=\"500px\" height=\"600px\">";
            //embed += "If you are unable to view file, you can download from <a href = \"{0}{1}&download=1\">here</a>";
            //embed += " or download <a target = \"_blank\" href = \"http://get.adobe.com/reader/\">Adobe PDF Reader</a> to view the file.";
            //embed += "</object>";
            //ltEmbed.Text = string.Format(embed, ResolveUrl("~/FileCS.ashx?SPARE_PART_ID ="), ddlSparePartId.SelectedValue.ToString());
            if (ddlSparePartId.Text == " ")
            {

                string strMsg = "Please Select Part Name!!!";
                MessageBox(strMsg);
                ddlSparePartId.Focus();
                return;
            }
            else
            {

                Response.Redirect("FileCS.ashx?SPARE_PART_ID=" + Server.UrlEncode(ddlSparePartId.SelectedValue.ToString()));

            }

        }

        protected void btnSearchRecord_Click(object sender, EventArgs e)
        {

            loadPartCategoryRecord();


        }
    }
}
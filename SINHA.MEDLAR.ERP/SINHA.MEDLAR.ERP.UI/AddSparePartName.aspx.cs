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

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class AddSparePartName : System.Web.UI.Page
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
                loadPartRecord();
                getOfficeName();
                getEquipementId();
            }

            if (IsPostBack)
            {

                loadSesscion();
                
            }

            txtSparePartName.Attributes.Add("onkeypress", "return controlEnter('" + txtSparePartNo.ClientID + "', event)");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (ddlEquipementId.Text == " ")
            {

                string strMsg = "Please Select Equipement Name!!!";
                MessageBox(strMsg);
                //ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "alert('Please Enter Unit Name');", true);
                ddlEquipementId.Focus();
                return;
            }

            else if (txtSparePartName.Text == string.Empty)
            {

                string strMsg = "Please Enter Part Name!!!";
                MessageBox(strMsg);
                //ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "alert('Please Enter Unit Name');", true);
                txtSparePartName.Focus();
                return ;
            }

            else if (txtSparePartNo.Text == string.Empty)
            {

                string strMsg = "Please Enter Part No!!!";
                MessageBox(strMsg);
                //ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "alert('Please Enter Unit Name');", true);
                txtSparePartNo.Focus();
                return;
            }
            else
            {
                savePartInfo();
                loadPartRecord();

            }

        }
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
        #region "Function"

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

        public void savePartInfo()
        {


            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO.SparePartId = txtSparePartId.Text;
            objLookUpDTO.SparePartName = txtSparePartName.Text;
            objLookUpDTO.SparePartNo = txtSparePartNo.Text;

            if (ddlEquipementId.SelectedValue.ToString() != " ")
            {
                objLookUpDTO.EquipmetId = ddlEquipementId.SelectedValue.ToString();
            }
            else
            {
                objLookUpDTO.EquipmetId = "";

            }


            objLookUpDTO.UpdateBy = strEmployeeId;
            objLookUpDTO.HeadOfficeId = strHeadOfficeId;
            objLookUpDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objLookUpBLL.savePartInfo(objLookUpDTO);
            MessageBox(strMsg);

        }

        public void deleteSparePart()
        {


            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO.SparePartId = txtSparePartId.Text;
         

            objLookUpDTO.UpdateBy = strEmployeeId;
            objLookUpDTO.HeadOfficeId = strHeadOfficeId;
            objLookUpDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objLookUpBLL.deleteSparePart(objLookUpDTO);
            MessageBox(strMsg);

        }


        public void searchPartInfo()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.searchPartInfo(txtSparePartId.Text, strHeadOfficeId, strBranchOfficeId);

            txtSparePartName.Text = objLookUpDTO.SparePartName;
            txtSparePartNo.Text = objLookUpDTO.SparePartNo;

            if (objLookUpDTO.EquipmetId == "0")
            {

                //nothing to do
            }
            else
            {
                ddlEquipementId.SelectedValue = objLookUpDTO.EquipmetId;
            }


        }

        public void loadPartRecord()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.loadPartRecord(strHeadOfficeId, strBranchOfficeId);


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
            txtSparePartId.Text = "";
            txtSparePartName.Text = "";
            txtSparePartNo.Text = "";


        }

        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSparePartId.Text == string.Empty)
            {

                string strMsg = "Please Enter Part ID!!!";
                MessageBox(strMsg);
                txtSparePartId.Focus();
                return;
            }
            else
            {
                searchPartInfo();

            }
        }

        protected void gvUnit_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUnit.PageIndex = e.NewPageIndex;
            loadPartRecord();
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

            txtSparePartId.Text = strUnitId;
            //txtSparePartName.Text = strUnitName;
            //txtSparePartNo.Text = strUnitNameBng;


            searchPartInfo();
            //string strMsg = "Row Index: " + strRowId + "\\nUnit ID: " + strUnitId + "\\nUnit Name : " + strUnitName + "\\nUnit Name Bangla : " + strUnitNameBng ;
            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + strMsg + "');", true);
            //MessageBox(strMsg);
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                clearTextBox();
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
                if (txtSparePartId.Text == string.Empty)
                {

                    string strMsg = "Please Enter Part ID!!!";
                    MessageBox(strMsg);
                    txtSparePartId.Focus();
                    return;
                }
                else
                {

                    deleteSparePart();
                    clearTextBox();
                    loadPartRecord();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
        }

    
    }
}
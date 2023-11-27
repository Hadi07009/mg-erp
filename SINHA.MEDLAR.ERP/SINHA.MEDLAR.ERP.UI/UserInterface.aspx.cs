using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.BLL;

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class UserInterface : System.Web.UI.Page
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
                Response.Redirect("Login.aspx", true );
                return;

            }

            if (!IsPostBack)
            {
                getSoftwareId();
                lblMsg.Text = "";
            }


            if (IsPostBack)
            {
                loadSesscion();
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }
        public void getSoftwareId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlSoftwareId.DataSource = objLookUpBLL.getSoftwareId(strHeadOfficeId, strBranchOfficeId);

            ddlSoftwareId.DataTextField = "SOFTWARE_NAME";
            ddlSoftwareId.DataValueField = "SOFTWARE_ID";

            ddlSoftwareId.DataBind();
            if (ddlSoftwareId.Items.Count > 0)
            {
                ddlSoftwareId.SelectedIndex = 0;
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

        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }
        public void clear()
        {

            txtUserInterfaceName.Text = string.Empty;
            txtUserInterfaceName.Text = string.Empty;
            txtDisplayName.Text = string.Empty;
            ddlSoftwareId.SelectedIndex = 0;
            chkActiveYn.Checked = false;
        }

        public void SaveUserInterface()
        {

            EventPermissionDTO objEventPermissionDTO = new EventPermissionDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();



            objEventPermissionDTO.InterfaceId = txtUserInterfaceId.Text;
            objEventPermissionDTO.InterfaceName = txtUserInterfaceName.Text;
            objEventPermissionDTO.UIDisplayName = txtDisplayName.Text;
            if (ddlSoftwareId.SelectedValue.ToString() != " ")
                objEventPermissionDTO.SoftwareId = ddlSoftwareId.SelectedValue.ToString();
            else
                objEventPermissionDTO.SoftwareId = "";
            if (chkActiveYn.Checked == true)
                objEventPermissionDTO.ActiveYn = "Y";
            else
                objEventPermissionDTO.ActiveYn = "N";
            objEventPermissionDTO.HeadOfficeId = strHeadOfficeId;
            objEventPermissionDTO.BranchOfficeId = strBranchOfficeId;
            objEventPermissionDTO.CreateBy = strEmployeeId;

            string strMsg = objLookUpBLL.SaveUserInterface(objEventPermissionDTO);
            if (strMsg == "Successfully Added")
                clear();
            MessageBox(strMsg);
            //MessageBox(strMsg);
            //lblMsg.Text = strMsg;



        }
       
        #endregion


        protected void GvUserInterface_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvUserInterface.PageIndex = e.NewPageIndex;
            //loadEmployeeCatagoryRecord();
        }

        protected void GvUserInterface_SelectedIndexChanged(object sender, EventArgs e)
        {
            int strGvUserInterface_ = GvUserInterface.SelectedRow.RowIndex;
            string UIId = GvUserInterface.SelectedRow.Cells[0].Text;
            string DisplayName = GvUserInterface.SelectedRow.Cells[1].Text;
            string UIName = GvUserInterface.SelectedRow.Cells[2].Text;
            string Status = GvUserInterface.SelectedRow.Cells[4].Text;
            string SoftId = GvUserInterface.SelectedRow.Cells[5].Text;

            txtUserInterfaceId.Text = UIId;
            txtUserInterfaceName.Text = UIName;
            txtDisplayName.Text = DisplayName;
            ddlSoftwareId.SelectedValue = SoftId;
            if (Status == "Y")
                chkActiveYn.Checked = true;
            else
                chkActiveYn.Checked = false;
        }

        protected void GvUserInterface_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.GvUserInterface, "Select$" + e.Row.RowIndex);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlSoftwareId.Text == " ")
                {
                    string strMsg = "Please Select Software";
                    MessageBox(strMsg);
                    ddlSoftwareId.Focus();
                    return;
                }
                if (txtUserInterfaceName.Text == string.Empty)
                {
                    string strMsg = "Please Enter UI Name";
                    MessageBox(strMsg);
                    txtUserInterfaceName.Focus();
                    return;
                }
                if (txtDisplayName.Text == string.Empty)
                {
                    string strMsg = "Please Enter Display Name";
                    MessageBox(strMsg);
                    txtDisplayName.Focus();
                    return;
                }
                SaveUserInterface();
                GetUserInterface();
            }

            catch (Exception ex)
            {

                throw new Exception("Error :" + ex.Message);
            }
        }
        public void GetUserInterface()
        {
            EventPermissionDTO objEventPermissionDTO = new EventPermissionDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();

            objEventPermissionDTO.HeadOfficeId = strHeadOfficeId;
            objEventPermissionDTO.BranchOfficeId = strBranchOfficeId;

            dt = objLookUpBLL.GetUserInterface(objEventPermissionDTO);
            if (dt.Rows.Count > 0)
            {
                GvUserInterface.DataSource = dt;
                GvUserInterface.DataBind();
                string strMsg = "TOTAL " + GvUserInterface.Rows.Count + " RECORD FOUND";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
            }
            else
            {
               // dt.Rows.Add(dt.NewRow());
                GvUserInterface.DataSource = dt;
                GvUserInterface.DataBind();
                //int totalcolums = GvUserInterface.Rows[0].Cells.Count;
                //GvUserInterface.Rows[0].Cells.Clear();
                //GvUserInterface.Rows[0].Cells.Add(new TableCell());
                //GvUserInterface.Rows[0].Cells[0].ColumnSpan = totalcolums;
                //GvUserInterface.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                lblMsg.Text = strMsg;
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            GetUserInterface();
        }
    }
}
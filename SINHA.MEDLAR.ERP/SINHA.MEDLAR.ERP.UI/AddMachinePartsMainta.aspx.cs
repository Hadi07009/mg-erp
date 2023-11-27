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
    public partial class AddMachinePartsMainta : System.Web.UI.Page
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
                loadMachinPartsInfo();
                getMachineId();
                getMachineModelId();
                getOfficeName();
            }

            if (IsPostBack)
            {

                loadSesscion();
            }


      
          
            txtMachineParts.Attributes.Add("onkeypress", "return controlEnter('" + btnSave.ClientID + "', event)");
      


        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if ( ddlMachineId.SelectedValue == string.Empty || ddlMAchineModelId.Text == string.Empty || txtMachineParts.Text == string.Empty)
                {
                    string strMsg = "Please Fill All The Field!!!";
                    txtMachineParts.Focus();
                    MessageBox(strMsg);
                    return;


                }

                else
                {
                    saveMAchinePartsInfo();
                    loadMachinPartsInfo(); 

                }



            }
            catch (Exception ex)
            {

                throw new Exception("Error : " + ex.Message);

            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //if (dtpFromDate.Text == "")
            //{
            //    string strMsg = "Please Enter From Date!!!";
            //    MessageBox(strMsg);
            //    dtpFromDate.Focus();
            //    return;

            //}
            //else if (dtpToDate.Text == "")
            //{
            //    string strMsg = "Please Enter To Date!!!";
            //    MessageBox(strMsg);
            //    dtpToDate.Focus();
            //    return;

            //}
            //else
            //{
            //    gvEmployeeList.SelectedIndex = 0;
            //    SewingDefectEntrySummery();
            //}
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {

                clear();

            }
            catch (Exception ex)
            {

                throw new Exception("Error : " + ex.Message);
            }
        }

        #region "Function"




        public void getMachineId()
        {

            MaintenanceBLL objMaintenanceBLL = new MaintenanceBLL();
            ddlMachineId.DataSource = objMaintenanceBLL.getMachineId(strHeadOfficeId, strBranchOfficeId);

            ddlMachineId.DataTextField = "MACHINE_NAME";

            ddlMachineId.DataValueField = "MACHINE_ID";

            ddlMachineId.DataBind();
            if (ddlMachineId.Items.Count > 0)
            {

                ddlMachineId.SelectedIndex = 0;
            }

        }
        

        public void getMachineModelId()
        {
            
            MaintenanceBLL objMaintenanceBLL = new MaintenanceBLL();

            string strMachineIdId = "";
            if (ddlMachineId.SelectedValue.ToString() != " ")
            {
                strMachineIdId = ddlMachineId.SelectedValue.ToString();
            }
            else
            {
                strMachineIdId = "";

            }

            ddlMAchineModelId.DataSource = objMaintenanceBLL.getMachineModelId(strMachineIdId, strHeadOfficeId, strBranchOfficeId);

            ddlMAchineModelId.DataValueField = "MACHINE_MODEL_NAME_ID";
            ddlMAchineModelId.DataTextField = "MACHINE_MODEL_NAME";

            ddlMAchineModelId.DataBind();
            if (ddlMAchineModelId.Items.Count > 0)
            {
                ddlMAchineModelId.SelectedIndex = 0;
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


        public void loadMachinPartsInfo()
        {
            MaintenanceDTO objMaintenanceDTO = new MaintenanceDTO();
            MaintenanceBLL objMaintenanceBLL = new MaintenanceBLL();

            DataTable dt = new DataTable();
            dt = objMaintenanceBLL.loadMachinPartsInfo(strHeadOfficeId, strBranchOfficeId);


            if (dt.Rows.Count > 0)
            {
                gvUnit.DataSource = dt;
                gvUnit.DataBind();
                string strMsg = "TOTAL " + gvUnit.Rows.Count + " RECORD FOUND";

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

        public void clear()
        {
           
            txtMachinePartsId.Text = "";
            ddlMachineId.Items.Clear();
            ddlMachineId.Items.Clear();
            txtMachineParts.Text = "";
            getMachineId(); 
            getMachineModelId();

        }
        public void saveMAchinePartsInfo()
        {

            MaintenanceDTO objMaintenanceDTO = new MaintenanceDTO();
            MaintenanceBLL objMaintenanceBLL = new MaintenanceBLL();

            objMaintenanceDTO.MachinePartsId = txtMachinePartsId.Text;
            objMaintenanceDTO.MachinelId = ddlMachineId.SelectedValue.ToString();
            objMaintenanceDTO.MachineModelId = ddlMAchineModelId.SelectedValue.ToString();
            objMaintenanceDTO.MachineParts = txtMachineParts.Text;

            objMaintenanceDTO.UpdateBy = strEmployeeId;
            objMaintenanceDTO.HeadOfficeId = strHeadOfficeId;
            objMaintenanceDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objMaintenanceBLL.saveMAchinePartsInfo(objMaintenanceDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);
            txtMachineParts.Text = "";
          
        }


        public void searchMachinePartsEntry()
        {

            MaintenanceDTO objMaintenanceDTO = new MaintenanceDTO();
            MaintenanceBLL objMaintenanceBLL = new MaintenanceBLL();

            objMaintenanceDTO = objMaintenanceBLL.searchMachinePartsEntry(txtMachinePartsId.Text, strHeadOfficeId, strBranchOfficeId);

            if (objMaintenanceDTO.MachinelId == "0")
            {

                //nothing to do
            }
            else
            {
                ddlMachineId.SelectedValue = objMaintenanceDTO.MachinelId;
            }

            if (objMaintenanceDTO.MachineModelId == "0")
            {

                //nothing to do
            }
            else
            {
                ddlMAchineModelId.SelectedValue = objMaintenanceDTO.MachineModelId;
            }

            txtMachineParts.Text = objMaintenanceDTO.MachineParts;

        }

        #endregion

        #region "GridView Functionlity"

        protected void gvUnit_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUnit.PageIndex = e.NewPageIndex;

        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvUnit.SelectedRow.RowIndex;

            string strMachinePartsId= gvUnit.SelectedRow.Cells[0].Text.Replace("&nbsp;", "");

            txtMachinePartsId.Text = strMachinePartsId;
            searchMachinePartsEntry();


        }
        protected void gvUnit_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        }
        protected void gvUnit_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvUnit.EditIndex = e.NewEditIndex;
            loadMachinPartsInfo();
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

        protected void chkActiveYn_CheckedChanged(object sender, EventArgs e)
        {

        }

       

        protected void ddlMachineNameId_SelectedIndexChanged(object sender, EventArgs e)
        {
            getMachineModelId();
        }
       


        #endregion

       
    }
}
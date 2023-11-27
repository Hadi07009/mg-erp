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
    public partial class MachinePartsReceiveMainta : System.Web.UI.Page
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
               // loadMachinePartsReceiveRecord();
             
                getOfficeName();
                getMachideId();
                getMachineModelId();
                getMachinePartsId();
                getMachineIdSearch();
                getMachineModelIdSearch();
                getMachinePartsIdSearch();
                getDepartmentId();

            }

            if (IsPostBack)
            {

                loadSesscion();
            }

            txtMrNo.Attributes.Add("onkeypress", "return controlEnter('" + txtBoxNo.ClientID + "', event)");
          
            txtBoxNo.Attributes.Add("onkeypress", "return controlEnter('" + txtReceiveQuantity.ClientID + "', event)");
           
            txtReceiveQuantity.Attributes.Add("onkeypress", "return controlEnter('" + btnSave.ClientID + "', event)");


        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtBoxNo.Text == string.Empty || txtMrNo.Text == string.Empty ||txtReceiveQuantity.Text==string.Empty)
                {
                    string strMsg = "Please Fill All The Field!!!";
                    txtBoxNo.Focus();
                    MessageBox(strMsg);
                    return;


                }

                else
                {
                    saveMachinePartsReceiveInfo();
                    loadMachinePartsReceiveRecord();

                }



            }
            catch (Exception ex)
            {

                throw new Exception("Error : " + ex.Message);

            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            {
                MachinePartsEntrySearch();
              //  loadMachinePartsReceiveRecord();
            }
        }


        public void MachinePartsEntrySearch()
        {
            MaintenanceDTO objMaintenanceDTO = new MaintenanceDTO();
            MaintenanceBLL objMaintenanceBLL = new MaintenanceBLL();
            DataTable dt = new DataTable();



            objMaintenanceDTO.HeadOfficeId = strHeadOfficeId;
            objMaintenanceDTO.BranchOfficeId = strBranchOfficeId;
            objMaintenanceDTO.MachinePartsReceiveId = txtMachinePartsReceiveId.Text;
         
            objMaintenanceDTO.MachineMRNo = txtMrNoSearch.Text;
            objMaintenanceDTO.PartsReceiveFromDate = dtpPdFromDate.Text;
            objMaintenanceDTO.PartsReceiveToDate = dtpPdToDate.Text;

            if (ddlMachineIdSearch.SelectedValue.ToString() != " ")
            {
                objMaintenanceDTO.MachinelId = ddlMachineIdSearch.SelectedValue.ToString();
            }
            else
            {

                objMaintenanceDTO.MachinelId = "";
            }

            //
            if (ddlMachineModelIdSearch.SelectedValue.ToString() != " ")
            {
                objMaintenanceDTO.MachineModelId = ddlMachineModelIdSearch.SelectedValue.ToString();
            }
            else
            {

                objMaintenanceDTO.MachineModelId = "";
            }

            // parts
            if (ddlMachinePartsIdSearch.SelectedValue.ToString() != " ")
            {
                objMaintenanceDTO.MachinePartsId = ddlMachinePartsIdSearch.SelectedValue.ToString();
            }
            else
            {

                objMaintenanceDTO.MachinePartsId = "";
            }


            dt = objMaintenanceBLL.MachinePartsEntrySearch(objMaintenanceDTO);


            if (dt.Rows.Count > 0)
            {
                gvUnit.DataSource = dt;
                gvUnit.DataBind();

                int count = ((DataTable)gvUnit.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
                // getFirstIndex();


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
                //lblMsgRecord.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
            }

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

        public void getDepartmentId()
        {

            MaintenanceBLL objMaintenanceBLL = new MaintenanceBLL();
            ddlDepartmentId.DataSource = objMaintenanceBLL.getDepartmentId(strHeadOfficeId, strBranchOfficeId);

            ddlDepartmentId.DataTextField = "DEPARTMENT_NAME";

            ddlDepartmentId.DataValueField = "DEPARTMENT_ID";

            ddlDepartmentId.DataBind();
            if (ddlDepartmentId.Items.Count > 0)
            {

                ddlDepartmentId.SelectedIndex = 0;
            }

        }


        public void getMachideId()
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


        public void getMachineIdSearch()
        {

            MaintenanceBLL objMaintenanceBLL = new MaintenanceBLL();
            ddlMachineIdSearch.DataSource = objMaintenanceBLL.getMachineIdSearch(strHeadOfficeId, strBranchOfficeId);

            ddlMachineIdSearch.DataTextField = "MACHINE_NAME";

            ddlMachineIdSearch.DataValueField = "MACHINE_ID";

            ddlMachineIdSearch.DataBind();
            if (ddlMachineIdSearch.Items.Count > 0)
            {

                ddlMachineIdSearch.SelectedIndex = 0;
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

            ddlMachineModelId.DataSource = objMaintenanceBLL.getMachineModelId(strMachineIdId, strHeadOfficeId, strBranchOfficeId);

            ddlMachineModelId.DataValueField = "MACHINE_MODEL_NAME_ID";
            ddlMachineModelId.DataTextField = "MACHINE_MODEL_NAME";

            ddlMachineModelId.DataBind();
            if (ddlMachineModelId.Items.Count > 0)
            {
                ddlMachineModelId.SelectedIndex = 0;
            }


        }

        //modelsearch

        public void getMachineModelIdSearch ()
        {

            MaintenanceBLL objMaintenanceBLL = new MaintenanceBLL();

            string strMachineIdIdSerach = "";
            if (ddlMachineIdSearch.SelectedValue.ToString() != " ")
            {
                strMachineIdIdSerach = ddlMachineIdSearch.SelectedValue.ToString();
            }
            else
            {
                strMachineIdIdSerach = "";

            }

            ddlMachineModelIdSearch.DataSource = objMaintenanceBLL.getMachineModelIdSearch(strMachineIdIdSerach, strHeadOfficeId, strBranchOfficeId);

            ddlMachineModelIdSearch.DataValueField = "MACHINE_MODEL_NAME_ID";
            ddlMachineModelIdSearch.DataTextField = "MACHINE_MODEL_NAME";

            ddlMachineModelIdSearch.DataBind();
            if (ddlMachineModelIdSearch.Items.Count > 0)
            {
                ddlMachineModelIdSearch.SelectedIndex = 0;
            }


        }

        public void getMachinePartsId()
        {

            MaintenanceBLL objMaintenanceBLL = new MaintenanceBLL();

            string strMachineModelId = "";
            if (ddlMachineModelId.SelectedValue.ToString() != " ")
            {
                strMachineModelId = ddlMachineModelId.SelectedValue.ToString();
            }
            else
            {
                strMachineModelId = "";

            }

            ddlMachinePartsId.DataSource = objMaintenanceBLL.getMachinePartsId(strMachineModelId, strHeadOfficeId, strBranchOfficeId);

            ddlMachinePartsId.DataValueField = "MACHINE_PARTS_ID";
            ddlMachinePartsId.DataTextField = "MACHINE_PARTS";

            ddlMachinePartsId.DataBind();
            if (ddlMachinePartsId.Items.Count > 0)
            {
                ddlMachinePartsId.SelectedIndex = 0;
            }


        }

        public void getMachinePartsIdSearch()
        {

            MaintenanceBLL objMaintenanceBLL = new MaintenanceBLL();

            string strMachineModelIdSearch = "";
            if (ddlMachineModelIdSearch.SelectedValue.ToString() != " ")
            {
                strMachineModelIdSearch = ddlMachineModelIdSearch.SelectedValue.ToString();
            }
            else
            {
                strMachineModelIdSearch = "";

            }

            ddlMachinePartsIdSearch.DataSource = objMaintenanceBLL.getMachinePartsIdSearch(strMachineModelIdSearch, strHeadOfficeId, strBranchOfficeId);

            ddlMachinePartsIdSearch.DataValueField = "MACHINE_PARTS_ID";
            ddlMachinePartsIdSearch.DataTextField = "MACHINE_PARTS";

            ddlMachinePartsIdSearch.DataBind();
            if (ddlMachinePartsIdSearch.Items.Count > 0)
            {
                ddlMachinePartsIdSearch.SelectedIndex = 0;
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


        public void loadMachinePartsReceiveRecord()
        {
            MaintenanceDTO objMaintenanceDTO = new MaintenanceDTO();
            MaintenanceBLL objMaintenanceBLL = new MaintenanceBLL();

            DataTable dt = new DataTable();
            dt = objMaintenanceBLL.loadMachinePartsReceiveRecord(strHeadOfficeId, strBranchOfficeId);


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
            txtMachinePartsReceiveId.Text = "";
            dtpPartsReceiveDate.Text = "";
            ddlMachineId.Items.Clear();
            ddlMachineModelId.Items.Clear();
            ddlMachinePartsId.Items.Clear();
            ddlDepartmentId.Items.Clear();
            txtBoxNo.Text = "";
            txtMrNo.Text = "";
            txtReceiveQuantity.Text = "";
         
            
            loadMachinePartsReceiveRecord();
            getMachideId();
            getMachineModelId();
            getMachinePartsId();
          

        }
        public void saveMachinePartsReceiveInfo()
        {

            MaintenanceDTO objMaintenanceDTO = new MaintenanceDTO();
            MaintenanceBLL objMaintenanceBLL = new MaintenanceBLL();

            objMaintenanceDTO.MachinePartsReceiveId = txtMachinePartsReceiveId.Text;
            objMaintenanceDTO.ReceiveDate = dtpPartsReceiveDate.Text;
            objMaintenanceDTO.MachinelId = ddlMachineId.SelectedValue.ToString();
            objMaintenanceDTO.MachineModelId = ddlMachineModelId.SelectedValue.ToString();
            objMaintenanceDTO.MachinePartsId = ddlMachinePartsId.SelectedValue.ToString();
            objMaintenanceDTO.DepartmentId = ddlDepartmentId.SelectedValue.ToString();
            objMaintenanceDTO.MachineMRNo = txtMrNo.Text;
            objMaintenanceDTO.MachineBoxNo = txtBoxNo.Text;
            objMaintenanceDTO.ReceiveQuantity = txtReceiveQuantity.Text;


       

            objMaintenanceDTO.UpdateBy = strEmployeeId;
            objMaintenanceDTO.HeadOfficeId = strHeadOfficeId;
            objMaintenanceDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objMaintenanceBLL.saveMachinePartsReceiveInfo(objMaintenanceDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);


            txtMachinePartsReceiveId.Text = "";
            txtMrNo.Text = "";
            txtBoxNo.Text = "";
            txtReceiveQuantity.Text = "";
         

        }



        public void searchMachinePartsReceivedEntry()
        {

            MaintenanceDTO objMaintenanceDTO = new MaintenanceDTO();
            MaintenanceBLL objMaintenanceBLL = new MaintenanceBLL();

            objMaintenanceDTO = objMaintenanceBLL.searchMachinePartsReceivedEntry(txtMachinePartsReceiveId.Text,dtpPartsReceiveDate.Text, strHeadOfficeId, strBranchOfficeId);

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
                ddlMachineModelId.SelectedValue = objMaintenanceDTO.MachineModelId;
            }

            if (objMaintenanceDTO.MachinePartsId == "0")
            {

                //nothing to do
            }
            else
            {
                ddlMachinePartsId.SelectedValue = objMaintenanceDTO.MachinePartsId;
            }

            if (objMaintenanceDTO.DepartmentId == "0")
            {

                //nothing to do
            }
            else
            {
                ddlDepartmentId.SelectedValue = objMaintenanceDTO.DepartmentId;
            }

            txtMrNo.Text = objMaintenanceDTO.MachineMRNo;
            txtBoxNo.Text = objMaintenanceDTO.MachineBoxNo;
            txtReceiveQuantity.Text = objMaintenanceDTO.ReceiveQuantity;

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

            string strdailysewingentryid = gvUnit.SelectedRow.Cells[0].Text.Replace("&nbsp;", "");
            string strReceiveDate = gvUnit.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
         

            txtMachinePartsReceiveId.Text = strdailysewingentryid;
            dtpPartsReceiveDate.Text = strReceiveDate;
            searchMachinePartsReceivedEntry();

    

        }
        protected void gvUnit_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        }
        protected void gvUnit_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvUnit.EditIndex = e.NewEditIndex;
            searchMachinePartsReceivedEntry();
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

        protected void ddlMachinePartsId_SelectedIndexChanged(object sender, EventArgs e)
        {
          getMachinePartsId();
        }
        protected void ddlMachinePartsIdSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            getMachinePartsIdSearch();
        }
        protected void ddlMachineNameId_SelectedIndexChanged(object sender, EventArgs e)
        {
            getMachineModelId();
        }

        protected void ddlMachineNameIdSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            getMachineModelIdSearch();
        }
       

        #endregion

        

       
    }
}
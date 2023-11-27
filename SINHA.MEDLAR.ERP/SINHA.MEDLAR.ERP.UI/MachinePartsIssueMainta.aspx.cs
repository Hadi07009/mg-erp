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
    public partial class MachinePartsIssueMainta : System.Web.UI.Page
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
             //   loadMachinePartsIssueRecord();
             
                getOfficeName();
                getMachideId();
                getMachineModelId();
                getMachinePartsId();
                getMachineIdSearch();
                getMachineModelIdSearch();
                getMachinePartsIdSearch();
            }

            if (IsPostBack)
            {

                loadSesscion();
            }


            txtIssueQuantity.Attributes.Add("onkeypress", "return controlEnter('" + txtSRNo.ClientID + "', event)");
            txtSRNo.Attributes.Add("onkeypress", "return controlEnter('" + txtRemarks.ClientID + "', event)");
          txtRemarks.Attributes.Add("onkeypress", "return controlEnter('" + btnSave.ClientID + "', event)");


        }

        #region Save
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtIssueQuantity.Text == string.Empty || txtSRNo.Text == string.Empty ||txtRemarks.Text==string.Empty)
                {
                    string strMsg = "Please Fill All The Field!!!";
                    txtSRNo.Focus();
                    MessageBox(strMsg);
                    return;


                }

                else
                {
                    saveMachinePartsIssueInfo();
                    loadMachinePartsIssueRecord();

                }



            }
            catch (Exception ex)
            {

                throw new Exception("Error : " + ex.Message);

            }
        }
        #endregion
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            {
                MachinePartsReceivedSearch();
                loadMachinePartsIssueRecord();
            }
        }

        public void MachinePartsReceivedSearch()
        {
            MaintenanceDTO objMaintenanceDTO = new MaintenanceDTO();
            MaintenanceBLL objMaintenanceBLL = new MaintenanceBLL();
            DataTable dt = new DataTable();



            objMaintenanceDTO.HeadOfficeId = strHeadOfficeId;
            objMaintenanceDTO.BranchOfficeId = strBranchOfficeId;
            objMaintenanceDTO.MachinePartsReceiveId = txtMachinePartsIssueId.Text;
           
            objMaintenanceDTO.PartsIssueFromDate = dtpPdFromDate.Text;
            objMaintenanceDTO.PartsIssueToDate = dtpPdToDate.Text;

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


            dt = objMaintenanceBLL.MachinePartsReceivedSearch(objMaintenanceDTO);


            if (dt.Rows.Count > 0)
            {
                GridView2.DataSource = dt;
                GridView2.DataBind();

                int count = ((DataTable)GridView2.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                //MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
                // getFirstIndex();


            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                GridView2.DataSource = dt;
                GridView2.DataBind();
                int totalcolums = GridView2.Rows[0].Cells.Count;
                GridView2.Rows[0].Cells.Clear();
                GridView2.Rows[0].Cells.Add(new TableCell());
                GridView2.Rows[0].Cells[0].ColumnSpan = totalcolums;
                GridView2.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
            }

        }
       
        #region "Function"

       


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

#endregion
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


        public void loadMachinePartsIssueRecord()
        {
            MaintenanceDTO objMaintenanceDTO = new MaintenanceDTO();
            MaintenanceBLL objMaintenanceBLL = new MaintenanceBLL();

            DataTable dt = new DataTable();

            objMaintenanceDTO.HeadOfficeId = strHeadOfficeId;
            objMaintenanceDTO.BranchOfficeId = strBranchOfficeId;

            if (txtMachinePartsIssueId.Text == "")
            {
                objMaintenanceDTO.MachinePartsIssueId = "";
            }
            else
            {
                objMaintenanceDTO.MachinePartsIssueId = txtMachinePartsIssueId.Text;
            }
            objMaintenanceDTO.PartsIssueFromDate = dtpPdFromDate.Text;
            objMaintenanceDTO.PartsIssueToDate = dtpPdToDate.Text;

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



            dt = objMaintenanceBLL.loadMachinePartsIssueRecord(objMaintenanceDTO);


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

        #region Clear
        public void clear()
        {

                txtMachinePartsIssueId.Text = "";
                dtpIssueDate.Text = "";
                ddlMachineId.Items.Clear();
                ddlMachineModelId.Items.Clear();
                ddlMachinePartsId.Items.Clear();

                txtIssueQuantity.Text = "";
                txtSRNo.Text = "";
                txtRemarks.Text = "";

       
                getMachideId();
                getMachineModelId();
                getMachinePartsId();


                }
        #endregion

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


        #region Save
        public void saveMachinePartsIssueInfo()
        {

            MaintenanceDTO objMaintenanceDTO = new MaintenanceDTO();
            MaintenanceBLL objMaintenanceBLL = new MaintenanceBLL();

            objMaintenanceDTO.MachinePartsIssueId = txtMachinePartsIssueId.Text;
           
            objMaintenanceDTO.MachinelId = ddlMachineId.SelectedValue.ToString();
            objMaintenanceDTO.MachineModelId = ddlMachineModelId.SelectedValue.ToString();
            objMaintenanceDTO.MachinePartsId = ddlMachinePartsId.SelectedValue.ToString();
            objMaintenanceDTO.IssueDate = dtpIssueDate.Text;
            objMaintenanceDTO.IssueQuantity = txtIssueQuantity.Text;
            objMaintenanceDTO.SRNo = txtSRNo.Text;
            objMaintenanceDTO.Remarks = txtRemarks.Text;




            objMaintenanceDTO.UpdateBy = strEmployeeId;
            objMaintenanceDTO.HeadOfficeId = strHeadOfficeId;
            objMaintenanceDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objMaintenanceBLL.saveMachinePartsIssueInfo(objMaintenanceDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);


            txtMachinePartsIssueId.Text = "";
            txtSRNo.Text = "";
            txtIssueQuantity.Text = "";
            txtRemarks.Text = "";


        }

#endregion save

#region Search 
        
        public void searchMachinePartsIssueEntry()
        {

            MaintenanceDTO objMaintenanceDTO = new MaintenanceDTO();
            MaintenanceBLL objMaintenanceBLL = new MaintenanceBLL();

            objMaintenanceDTO = objMaintenanceBLL.searchMachinePartsIssueEntry(txtMachinePartsIssueId.Text, strHeadOfficeId, strBranchOfficeId);

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
         //   dtpIssueDate.Text = objMaintenanceDTO.IssueDate;
          
            txtIssueQuantity.Text = objMaintenanceDTO.IssueQuantity;
            txtSRNo.Text = objMaintenanceDTO.SRNo;
            txtRemarks.Text = objMaintenanceDTO.Remarks;

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

            string strMachinePartsIssueId = gvUnit.SelectedRow.Cells[0].Text.Replace("&nbsp;", "");
            string strIssueDate = gvUnit.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");

            txtMachinePartsIssueId.Text = strMachinePartsIssueId;

            dtpIssueDate.Text = strIssueDate;

            searchMachinePartsIssueEntry();


        }




        protected void gvUnit_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        }
        protected void gvUnit_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvUnit.EditIndex = e.NewEditIndex;
            loadMachinePartsIssueRecord();
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
        protected void gvUnit2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;

        }


        protected void OnRowDataBound2(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvUnit, "Select$" + e.Row.RowIndex);
            }
        }

        protected void OnSelectedIndexChanged2(object sender, EventArgs e)
        {
            string strmachinepartsissueid = GridView2.SelectedRow.Cells[0].Text.Replace("&nbsp;", "");
            string strReceiveDate = GridView2.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
            string strReceivseQty = GridView2.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");

            txtReceiveQuantity.Text = strReceivseQty;
            txtMachinePartsIssueId.Text = strmachinepartsissueid;
            dtpIssueDate.Text = strReceiveDate;
            searchMachinePartsReceivedEntry(strmachinepartsissueid, strReceiveDate,strHeadOfficeId,strBranchOfficeId);
        }


        public void searchMachinePartsReceivedEntry(string strmachinepartsissueid, string strReceiveDate, string strHeadOfficeId, string strBranchOfficeId)
        {

            MaintenanceDTO objMaintenanceDTO = new MaintenanceDTO();
            MaintenanceBLL objMaintenanceBLL = new MaintenanceBLL();

            objMaintenanceDTO = objMaintenanceBLL.searchMachinePartsReceivedEntry(strmachinepartsissueid, strReceiveDate, strHeadOfficeId, strBranchOfficeId);

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

          

        }

        protected void gvUnit2_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView2.EditIndex = e.NewEditIndex;
           loadMachinePartsIssueRecord();
        }

        #endregion

        

       
    }
}
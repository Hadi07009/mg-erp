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

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class EventPermission : System.Web.UI.Page
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
        string strSoftId = "";
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
                getLoginEmpId();
                GetUserInterface();
                clearMsg();
                getOfficeName();               
            }
            if (IsPostBack)
            {
                loadSesscion();
            }
        }
        #region "FUNCTION"       
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
            Session["strSoftId"] = null;
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
        public void clearMsg()
        {
            lblMsg.Text = string.Empty;
            //lblMsgRecord.Text = string.Empty;
        }
        public void getLoginEmpId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlEmployeeId.DataSource = objLookUpBLL.getLoginEmpId(strHeadOfficeId, strBranchOfficeId);

            ddlEmployeeId.DataTextField = "EMPLOYEE_NAME";
            ddlEmployeeId.DataValueField = "EMPLOYEE_ID";

            ddlEmployeeId.DataBind();
            if (ddlEmployeeId.Items.Count > 0)
            {

                ddlEmployeeId.SelectedIndex = 0;
            }

        }
        //public void GetDisableEvent(string MenuId)
        //{

        //    LookUpBLL objLookUpBLL = new LookUpBLL();
        //    ddlDisableAdd.DataSource = objLookUpBLL.GetDisableEvent(ddlMenuId.SelectedValue);

        //    ddlDisableAdd.DataTextField = "EVENT_NAME";
        //    ddlDisableAdd.DataValueField = "DISABLE_EVENT_ID";

        //    ddlDisableAdd.DataBind();
        //    if (ddlDisableAdd.Items.Count > 0)
        //    {
        //        ddlDisableAdd.SelectedIndex = 0;
        //    }

        //}
        //public void GetMenuName()
        //{
        //    LookUpBLL objLookUpBLL = new LookUpBLL();
        //    ddlMenuId.DataSource = objLookUpBLL.GetMenuName();

        //    ddlMenuId.DataTextField = "MENU_NAME";
        //    ddlMenuId.DataValueField = "MENU_ID";
        //    ddlMenuId.DataBind();
        //    if (ddlMenuId.Items.Count > 0)
        //    {
        //        ddlMenuId.SelectedIndex = 0;
        //    }
        //}
        public void GetUserInterface()
        {
            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlUserInterfaceId.DataSource = objLookUpBLL.GetUserInterface();

            ddlUserInterfaceId.DataTextField = "DISPLAY_NAME";
            ddlUserInterfaceId.DataValueField = "UI_ID";
            ddlUserInterfaceId.DataBind();
            if (ddlUserInterfaceId.Items.Count > 0)
            {
                ddlUserInterfaceId.SelectedIndex = 0;
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
            strSoftId = Session["strSoftId"].ToString().Trim();
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
     
        public void GetEventPermission()
        {
            EventPermissionDTO objEventPermissionDTO = new EventPermissionDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();

            if (ddlEmployeeId.SelectedValue.ToString() != " ")
            {
                objEventPermissionDTO.EmployeeId = ddlEmployeeId.SelectedValue.ToString();
            }
            else
            {
                objEventPermissionDTO.EmployeeId = "";
            }
            if (ddlUserInterfaceId.SelectedValue.ToString() != " ")
            {
                objEventPermissionDTO.InterfaceId = ddlUserInterfaceId.SelectedValue.ToString();
            }
            else
            {
                objEventPermissionDTO.InterfaceId = "";
            }
            objEventPermissionDTO.UpdateBy = strEmployeeId;
            objEventPermissionDTO.HeadOfficeId = strHeadOfficeId;
            objEventPermissionDTO.BranchOfficeId = strBranchOfficeId;

            dt = objLookUpBLL.GetEventPermission(objEventPermissionDTO);
            if (dt.Rows.Count > 0)
            {
                gvEventPermissionList.DataSource = dt;
                gvEventPermissionList.DataBind();
                string strMsg = "TOTAL " + gvEventPermissionList.Rows.Count + " RECORD FOUND";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvEventPermissionList.DataSource = dt;
                gvEventPermissionList.DataBind();
                int totalcolums = gvEventPermissionList.Rows[0].Cells.Count;
                gvEventPermissionList.Rows[0].Cells.Clear();
                gvEventPermissionList.Rows[0].Cells.Add(new TableCell());
                gvEventPermissionList.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvEventPermissionList.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                lblMsg.Text = strMsg;
            }
        }
       
        public void clearMessage()
        {

            lblMsg.Text = string.Empty;
        }
        public void SaveEventPermission()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            EventPermissionDTO objEventPermissionDTO = new EventPermissionDTO();
            string strMsg = "";

            //if (ChekDisableSave.Checked == true)
            //    objEventPermissionDTO.DisableSave = "1";
            //else
            //    objEventPermissionDTO.DisableSave = "0";
            //if (ChekDisableAdd.Checked == true)
            //    objEventPermissionDTO.DisableAdd = "1";
            //else
            //    objEventPermissionDTO.DisableAdd = "0";
            //if (ChekDisableSearch.Checked == true)
            //    objEventPermissionDTO.DisableSearch = "1";
            //else
            //    objEventPermissionDTO.DisableSearch = "0";
            //if (ChekDisableProcess.Checked == true)
            //    objEventPermissionDTO.DisableProcess = "1";
            //else
            //    objEventPermissionDTO.DisableProcess = "0";

            //if (ChekDisableAtten.Checked == true)
            //    objEventPermissionDTO.DisableAtten = "1";
            //else
            //    objEventPermissionDTO.DisableAtten = "0";

            //if (ChekDisableDelete.Checked == true)
            //    objEventPermissionDTO.DisaleDelete = "1";
            //else
            //    objEventPermissionDTO.DisaleDelete = "0";

            if (ddlEmployeeId.SelectedValue.ToString() != " ")
            {
                objEventPermissionDTO.EmployeeId = ddlEmployeeId.SelectedValue.ToString();
            }
            else
            {
                objEventPermissionDTO.EmployeeId = "";
            }
            if (ddlUserInterfaceId.SelectedValue.ToString() != " ")
            {
                objEventPermissionDTO.InterfaceId = ddlUserInterfaceId.SelectedValue.ToString();
            }
            else
            {
                objEventPermissionDTO.InterfaceId = "";
            }
            if (ddlDisableSave.SelectedValue.ToString() != "")
            {
                objEventPermissionDTO.DisableSaveEventId = ddlDisableSave.SelectedValue.ToString();
            }
            else
            {
                objEventPermissionDTO.DisableSaveEventId = "";
            }
            if (ddlDisableAdd.SelectedValue.ToString() != "")
            {
                objEventPermissionDTO.DisableAddEventId = ddlDisableAdd.SelectedValue.ToString();
            }
            else
            {
                objEventPermissionDTO.DisableAddEventId = "";
            }
            if (ddlDisableProcessEvent.SelectedValue.ToString() != "")
            {
                objEventPermissionDTO.DisableProcessEventId = ddlDisableProcessEvent.SelectedValue.ToString();
            }
            else
            {
                objEventPermissionDTO.DisableProcessEventId = "";
            }
            if (ddlDisableSearchEvent.SelectedValue.ToString() != "")
            {
                objEventPermissionDTO.DisableSearchEventId = ddlDisableSearchEvent.SelectedValue.ToString();
            }
            else
            {
                objEventPermissionDTO.DisableSearchEventId = "";
            }

            if (ddlDisableAttenEvent.SelectedValue.ToString() != "")
            {
                objEventPermissionDTO.DisableAttenEventId = ddlDisableAttenEvent.SelectedValue.ToString();
            }
            else
            {
                objEventPermissionDTO.DisableAttenEventId = "";
            }
            if (ddlDisableDeleteEvent.SelectedValue.ToString() != "")
            {
                objEventPermissionDTO.DisableDeleteEventId = ddlDisableDeleteEvent.SelectedValue.ToString();
            }
            else
            {
                objEventPermissionDTO.DisableDeleteEventId = "";
            }
            objEventPermissionDTO.CreateBy = strEmployeeId;
            objEventPermissionDTO.HeadOfficeId = strHeadOfficeId;
            objEventPermissionDTO.BranchOfficeId = strBranchOfficeId;
            strMsg = objLookUpBLL.SaveEventPermission(objEventPermissionDTO);
            MessageBox(strMsg);
            lblMsg.Text = strMsg;

    }

  
      
        #endregion
        #region "Grid View Functionality"
        protected void gvEventPermissionList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEventPermissionList.PageIndex = e.NewPageIndex;
            
        }
        protected void gvEventPermissionList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvEventPermissionList.SelectedRow.RowIndex;
            string UserId = gvEventPermissionList.SelectedRow.Cells[9].Text;
            string interfaceId = gvEventPermissionList.SelectedRow.Cells[8].Text;
            string DisableSaveEventId = gvEventPermissionList.SelectedRow.Cells[10].Text.Replace("&nbsp;", "");
            string DisableAddEventId = gvEventPermissionList.SelectedRow.Cells[11].Text.Replace("&nbsp;", "");
            string DisableProcessEventId = gvEventPermissionList.SelectedRow.Cells[12].Text.Replace("&nbsp;", "");
            string DisableSearchEventId = gvEventPermissionList.SelectedRow.Cells[13].Text.Replace("&nbsp;", "");
            string DisableattenEventId= gvEventPermissionList.SelectedRow.Cells[14].Text.Replace("&nbsp;", "");
            string DisableDeleteEventId = gvEventPermissionList.SelectedRow.Cells[15].Text.Replace("&nbsp;", "");

            ddlEmployeeId.Text = UserId;
            ddlUserInterfaceId.Text = interfaceId;

            GetDropdown(interfaceId);

            ddlDisableSave.SelectedValue = DisableSaveEventId;
            ddlDisableAdd.SelectedValue = DisableAddEventId;
            ddlDisableProcessEvent.SelectedValue = DisableProcessEventId;
            ddlDisableSearchEvent.SelectedValue = DisableSearchEventId;
            ddlDisableAttenEvent.SelectedValue = DisableattenEventId;
            ddlDisableDeleteEvent.SelectedValue = DisableDeleteEventId;


            //if (DisableSave == "1")
            //   ChekDisableSave.Checked = true;
            //else
            //    ChekDisableSave.Checked = false;

            //if (DisableAdd == "1")
            //    ChekDisableAdd.Checked = true;
            //else
            //    ChekDisableAdd.Checked = false;

            //if (DisableProcess == "1")
            //    ChekDisableProcess.Checked = true;
            //else
            //    ChekDisableProcess.Checked = false;

            //if (DisableSearch == "1")
            //    ChekDisableSearch.Checked = true;
            //else
            //    ChekDisableSearch.Checked = false;

            //if (Disableatten == "1")
            //    ChekDisableAtten.Checked = true;
            //else
            //    ChekDisableAtten.Checked = false;

            //if (DisableDelete == "1")
            //    ChekDisableDelete.Checked = true;
            //else
            //    ChekDisableDelete.Checked = false;
        }

        protected void gvEventPermissionList_RowDataBound(GridViewRowEventArgs e)
        {
            //e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            //e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        }

        protected void gvEventPermissionList_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvEventPermissionList, "Select$" + e.Row.RowIndex);
            }
        }
        #endregion
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
              {
                if (ddlEmployeeId.Text == " ")
                {
                    string strMsg = "Please Select User Name!!!";
                    MessageBox(strMsg);
                    ddlEmployeeId.Focus();
                    return;
                }              
                else if (ddlUserInterfaceId.Text == "")
                {
                    string strMsg = "Please Select InterFace";
                    MessageBox(strMsg);
                    ddlUserInterfaceId.Focus();
                    return;
                }
                else
                {
                    SaveEventPermission();
                    GetEventPermission();
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
        }
      
        protected void btnShow_Click(object sender, EventArgs e)
        {
            if (ddlEmployeeId.Text == " ")
            {
                string strMsg = "Please Select User Name!!!";
                MessageBox(strMsg);
                ddlEmployeeId.Focus();
                return;
            }
            GetEventPermission();          
        }

        protected void ddlUserInterfaceId_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetDropdown(ddlUserInterfaceId.SelectedValue);

            //LookUpBLL objLookUpBLL = new LookUpBLL();
            //DataTable data = new DataTable();

            //data = objLookUpBLL.GetDisableEvent(ddlUserInterfaceId.SelectedValue);

            //ddlDisableSearchEvent.DataSource= data;
            //ddlDisableSearchEvent.DataTextField = "EVENT_NAME";
            //ddlDisableSearchEvent.DataValueField = "ID";


            //ddlDisableAdd.DataSource = data;
            //ddlDisableAdd.DataTextField = "EVENT_NAME";
            //ddlDisableAdd.DataValueField = "ID";


            //ddlDisableSave.DataSource = data;
            //ddlDisableSave.DataTextField = "EVENT_NAME";
            //ddlDisableSave.DataValueField = "ID";

            //ddlDisableAttenEvent.DataSource = data;
            //ddlDisableAttenEvent.DataTextField = "EVENT_NAME";
            //ddlDisableAttenEvent.DataValueField = "ID";

            //ddlDisableDeleteEvent.DataSource = data;
            //ddlDisableDeleteEvent.DataTextField = "EVENT_NAME";
            //ddlDisableDeleteEvent.DataValueField = "ID";

            //ddlDisableProcessEvent.DataSource = data;
            //ddlDisableProcessEvent.DataTextField = "EVENT_NAME";
            //ddlDisableProcessEvent.DataValueField = "ID";

            //ddlDisableAdd.DataBind();
            //ddlDisableSearchEvent.DataBind();
            //ddlDisableSave.DataBind();
            //ddlDisableAttenEvent.DataBind();
            //ddlDisableDeleteEvent.DataBind();
            //ddlDisableProcessEvent.DataBind();

        }

        public void GetDropdown(string userInterfaceId)
        {
            LookUpBLL objLookUpBLL = new LookUpBLL();
            DataTable data = new DataTable();

            data = objLookUpBLL.GetDisableEvent(userInterfaceId);

            ddlDisableSearchEvent.DataSource = data;
            ddlDisableSearchEvent.DataTextField = "EVENT_NAME";
            ddlDisableSearchEvent.DataValueField = "ID";


            ddlDisableAdd.DataSource = data;
            ddlDisableAdd.DataTextField = "EVENT_NAME";
            ddlDisableAdd.DataValueField = "ID";


            ddlDisableSave.DataSource = data;
            ddlDisableSave.DataTextField = "EVENT_NAME";
            ddlDisableSave.DataValueField = "ID";

            ddlDisableAttenEvent.DataSource = data;
            ddlDisableAttenEvent.DataTextField = "EVENT_NAME";
            ddlDisableAttenEvent.DataValueField = "ID";

            ddlDisableDeleteEvent.DataSource = data;
            ddlDisableDeleteEvent.DataTextField = "EVENT_NAME";
            ddlDisableDeleteEvent.DataValueField = "ID";

            ddlDisableProcessEvent.DataSource = data;
            ddlDisableProcessEvent.DataTextField = "EVENT_NAME";
            ddlDisableProcessEvent.DataValueField = "ID";



            ddlDisableAdd.DataBind();
            ddlDisableSearchEvent.DataBind();
            ddlDisableSave.DataBind();
            ddlDisableAttenEvent.DataBind();
            ddlDisableDeleteEvent.DataBind();
            ddlDisableProcessEvent.DataBind();
        }
    }
}
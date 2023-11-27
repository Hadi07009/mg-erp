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
    public partial class DisableEvent : System.Web.UI.Page
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
                GetUI();
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
        public void GetUI()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlUserInterfaceId.DataSource = objLookUpBLL.GetUI(strHeadOfficeId, strBranchOfficeId);

            ddlUserInterfaceId.DataTextField = "DISPLAY_NAME";
            ddlUserInterfaceId.DataValueField = "UI_ID";

            ddlUserInterfaceId.DataBind();
            if (ddlUserInterfaceId.Items.Count > 0)
            {
                ddlUserInterfaceId.SelectedIndex = 0;
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

            txtEvenId.Text = string.Empty;
            txtEventName.Text = string.Empty;
            txtId.Text = string.Empty;
            ddlUserInterfaceId.SelectedIndex = 0;
        }

        public void SaveDisableEvent()
        {

            EventPermissionDTO objEventPermissionDTO = new EventPermissionDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();



            objEventPermissionDTO.Id = txtId.Text;
            objEventPermissionDTO.EventId = txtEvenId.Text;
            objEventPermissionDTO.EventName = txtEventName.Text;
            if (ddlUserInterfaceId.SelectedValue.ToString() != " ")
                objEventPermissionDTO.InterfaceId = ddlUserInterfaceId.SelectedValue.ToString();
            else
                objEventPermissionDTO.InterfaceId = "";
           
            objEventPermissionDTO.HeadOfficeId = strHeadOfficeId;
            objEventPermissionDTO.BranchOfficeId = strBranchOfficeId;
            objEventPermissionDTO.CreateBy = strEmployeeId;

            string strMsg = objLookUpBLL.SaveDisableEvent(objEventPermissionDTO);
            if (strMsg == "Successfully Updated")
                clear();
            MessageBox(strMsg);
            //MessageBox(strMsg);
            //lblMsg.Text = strMsg;



        }
       
        #endregion


        protected void GvDisableEvent_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvDisableEvent.PageIndex = e.NewPageIndex;
            //loadEmployeeCatagoryRecord();
        }

        protected void GvDisableEvent_SelectedIndexChanged(object sender, EventArgs e)
        {
            int strGvDisableEvent_ = GvDisableEvent.SelectedRow.RowIndex;
            string Id = GvDisableEvent.SelectedRow.Cells[0].Text;
            string EvwntId = GvDisableEvent.SelectedRow.Cells[2].Text;
            string EventName = GvDisableEvent.SelectedRow.Cells[3].Text;
            string UIId = GvDisableEvent.SelectedRow.Cells[4].Text;

            txtId.Text = Id;
            txtEvenId.Text = EvwntId;
            txtEventName.Text = EventName;
            ddlUserInterfaceId.SelectedValue = UIId;
            
        }

        protected void GvDisableEvent_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.GvDisableEvent, "Select$" + e.Row.RowIndex);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlUserInterfaceId.Text == "")
                {
                    string strMsg = "Please Select User Interface";
                    MessageBox(strMsg);
                    ddlUserInterfaceId.Focus();
                    return;
                }
                if (txtEvenId.Text == string.Empty)
                {
                    string strMsg = "Please Enter Event Id";
                    MessageBox(strMsg);
                    txtEvenId.Focus();
                    return;
                }
                if (txtEventName.Text == string.Empty)
                {
                    string strMsg = "Please Enter Event Name";
                    MessageBox(strMsg);
                    txtEventName.Focus();
                    return;
                }
                SaveDisableEvent();
                GetDisableEvent();
            }

            catch (Exception ex)
            {

                throw new Exception("Error :" + ex.Message);
            }
        }
        public void GetDisableEvent()
        {
            EventPermissionDTO objEventPermissionDTO = new EventPermissionDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();

            objEventPermissionDTO.HeadOfficeId = strHeadOfficeId;
            objEventPermissionDTO.BranchOfficeId = strBranchOfficeId;

            dt = objLookUpBLL.GetDisableEvent(objEventPermissionDTO);
            if (dt.Rows.Count > 0)
            {
                GvDisableEvent.DataSource = dt;
                GvDisableEvent.DataBind();
                string strMsg = "TOTAL " + GvDisableEvent.Rows.Count + " RECORD FOUND";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
            }
            else
            {
                // dt.Rows.Add(dt.NewRow());
                GvDisableEvent.DataSource = dt;
                GvDisableEvent.DataBind();
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
            GetDisableEvent();
        }
    }
}
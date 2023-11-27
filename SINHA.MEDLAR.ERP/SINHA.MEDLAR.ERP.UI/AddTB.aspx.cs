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
    public partial class AddTB : System.Web.UI.Page
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
                getOfficeName();
                getTB();
                getProcessSelectTypeId();
                loadBasicSize();
            }

            if (IsPostBack)
            {

                loadSesscion();

            }
        }


        #region "Function"

        public void getTB()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlProcessTypeId.DataSource = objLookUpBLL.getTB(strHeadOfficeId, strBranchOfficeId);

            ddlProcessTypeId.DataTextField = "SIZE_TYPE_NAME";
            ddlProcessTypeId.DataValueField = "SIZE_TYPE_ID";

            ddlProcessTypeId.DataBind();
            if (ddlProcessTypeId.Items.Count > 0)
            {

                ddlProcessTypeId.SelectedIndex = 0;
            }

        }

        public void getProcessSelectTypeId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlProcessSelectTypeId.DataSource = objLookUpBLL.getProcessSelectTypeId(strHeadOfficeId, strBranchOfficeId);

            ddlProcessSelectTypeId.DataTextField = "PROCESS_NAME";
            ddlProcessSelectTypeId.DataValueField = "ID";

            ddlProcessSelectTypeId.DataBind();
            if (ddlProcessSelectTypeId.Items.Count > 0)
            {

                ddlProcessSelectTypeId.SelectedIndex = 0;
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

        public void loadBasicSize()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.loadBasicSize(strHeadOfficeId, strBranchOfficeId);


            if (dt.Rows.Count > 0)
            {
                gvUnit.DataSource = dt;
                gvUnit.DataBind();
                string strMsg = "TOTAL " + gvUnit.Rows.Count + " RECORD FOUND";
                //MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;
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
                lblMsgRecord.Text = strMsg;

            }


        }

      
        public void saveTBInformation()
        {

           WokerProcessDTO objWokerProcessDTO = new WokerProcessDTO ();
           WorkerProcessBLL objWorkerProcessBLL = new WorkerProcessBLL ();

           objWokerProcessDTO.ProcessId = txtProcessId.Text;
           objWokerProcessDTO.ProcessName = txtProcessName.Text;

           if (ddlProcessTypeId.Text != " ")
           {
               objWokerProcessDTO.ProcessTypeId = ddlProcessTypeId.SelectedValue.ToString();

           }
           else
           {
               objWokerProcessDTO.ProcessTypeId = "";
           }

           if (ddlProcessSelectTypeId.Text != " ")
           {
               objWokerProcessDTO.ProcessSelectTypeId = ddlProcessSelectTypeId.SelectedValue.ToString();

           }
           else
           {
               objWokerProcessDTO.ProcessSelectTypeId = "";
           }


           objWokerProcessDTO.UpdateBy = strEmployeeId;
           objWokerProcessDTO.HeadOfficeId = strHeadOfficeId;
           objWokerProcessDTO.BranchOfficeId = strBranchOfficeId;


           string strMsg = objWorkerProcessBLL.saveTBInformation(objWokerProcessDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);

        }

        public void clearTextBox()
        {
            txtProcessId.Text = "";
            txtProcessName.Text = "";


        }

        #endregion

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                clearTextBox();

            }

            catch (Exception ex)
            {
                throw new Exception("Error : "+ex.Message);

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlProcessTypeId.Text == " ")
                {
                    string strMsg = "Please Select Process Type!!!";
                    MessageBox(strMsg);
                    ddlProcessTypeId.Focus();
                    return;
                }
                else if(txtProcessName.Text == " ")
                {
                    string strMsg = "Please Enter Process Name!!!";
                    MessageBox(strMsg);
                    txtProcessName.Focus();
                    return;

                }
                else
                {
                    saveTBInformation();
                    loadBasicSize();
                    clearTextBox();
                }


            }

            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);

            }
        }



        #region "Grid View Functionality"

        protected void gvUnit_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUnit.PageIndex = e.NewPageIndex;
            loadBasicSize();
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
            string strUnitName = gvUnit.SelectedRow.Cells[2].Text;
            

            txtProcessId.Text = strUnitId;
            txtProcessName.Text = strUnitName;
      


            //tring strMsg = "Row Index: " + strRowId + "\\nUnit ID: " + strUnitId + "\\nUnit Name : " + strUnitName + "\\nUnit Name Bangla : " + strUnitNameBng;
            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + strMsg + "');", true);
            //MessageBox(strMsg);
        }


        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }

    }
}
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

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;

using System.Web.Security;
using System.Web.UI.HtmlControls;

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class MachineInformation : System.Web.UI.Page
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
                getMachineBrandId();
                getMachineModelId();
                getMachineRegionId();
                getMachineTypeId();
                clearMsg();



            }
            if (IsPostBack)
            {

                loadSesscion();

            }

            lblMsgRecord.Text = string.Empty;
            txtManufacturerSerialNo.Attributes.Add("onkeypress", "return controlEnter('" + txtMALSerialNo.ClientID + "', event)");
        }
        
         #region "Function"


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


        public void clearYellowTextBox()
        {
           

        }

        public void clearMessage()
        {

            lblMsg.Text = string.Empty;
        }
        public void clearTextBox()
        {
          

        }

        public void clearMsg()
        {

            lblMsg.Text = string.Empty;
          
        }


        public void searchMachineEntryResult()
        {

            WokerProcessDTO objWokerProcessDTO = new WokerProcessDTO ();
            WorkerProcessBLL objWorkerProcessBLL = new WorkerProcessBLL ();


            DataTable dt = new DataTable();

            if (ddlMachineBrandId.SelectedValue.ToString() != " ")
            {
                objWokerProcessDTO.BrandId = ddlMachineBrandId.SelectedValue.ToString();
            }
            else
            {
                objWokerProcessDTO.BrandId = "";

            }

            if (ddlMachineModelId.SelectedValue.ToString() != " ")
            {
                objWokerProcessDTO.ModelId = ddlMachineModelId.SelectedValue.ToString();
            }
            else
            {
                objWokerProcessDTO.ModelId = "";

            }


            if (ddlMachineRegionId.SelectedValue.ToString() != " ")
            {
                objWokerProcessDTO.MachineRegionId = ddlMachineRegionId.SelectedValue.ToString();
            }
            else
            {
                objWokerProcessDTO.MachineRegionId = "";

            }

            if (ddlMachineTypeId.SelectedValue.ToString() != " ")
            {
                objWokerProcessDTO.MachineType = ddlMachineTypeId.SelectedValue.ToString();
            }
            else
            {
                objWokerProcessDTO.MachineType = "";

            }


            objWokerProcessDTO.HeadOfficeId = strHeadOfficeId;
            objWokerProcessDTO.BranchOfficeId = strBranchOfficeId;

            dt = objWorkerProcessBLL.searchMachineEntryResult(objWokerProcessDTO);


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

        //public void getOfficeName()
        //{

        //    LookUpDTO objLookUpDTO = new LookUpDTO();
        //    LookUpBLL objLookUpBLL = new LookUpBLL();

        //    objLookUpDTO = objLookUpBLL.getHeadOfficeName(strHeadOfficeId, strBranchOfficeId);


        //    Label mpLabel = (Label)Master.FindControl("lblHeadOfficeName");
        //    HeadOfficeName = objLookUpDTO.HeadOfficeName;
        //    BranchOfficeName = objLookUpDTO.BranchOfficeName;
        //    HeadOfficeAddress = objLookUpDTO.HeadOfficeAddress;
        //    BranchOfficeAddress = objLookUpDTO.BranchOfficeAddress;



        //}

        //public string HeadOfficeName
        //{
        //    get { return lblHeadOfficeName.Text; }
        //    set { lblHeadOfficeName.Text = value; }
        //}

        //public string BranchOfficeName
        //{
        //    get { return lblBranchOfficeName.Text; }
        //    set { lblBranchOfficeName.Text = value; }
        //}

        //public string HeadOfficeAddress
        //{
        //    get { return lblHeadOfficeAddress.Text; }
        //    set { lblHeadOfficeAddress.Text = value; }
        //}

        //public string BranchOfficeAddress
        //{
        //    get { return lblBranchOfficeAddress.Text; }
        //    set { lblBranchOfficeAddress.Text = value; }
        //}

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

        public void getMachineTypeId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlMachineTypeId.DataSource = objLookUpBLL.getMachineTypeId(strHeadOfficeId, strBranchOfficeId);

            ddlMachineTypeId.DataTextField = "MACHINE_TYPE_NAME";
            ddlMachineTypeId.DataValueField = "MACHINE_TYPE_ID";

            ddlMachineTypeId.DataBind();
            if (ddlMachineTypeId.Items.Count > 0)
            {

                ddlMachineTypeId.SelectedIndex = 0;
            }

        }

        public void getMachineBrandId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlMachineBrandId.DataSource = objLookUpBLL.getMachineBrandId(strHeadOfficeId, strBranchOfficeId);

            ddlMachineBrandId.DataTextField = "MACHINE_BRAND_NAME";
            ddlMachineBrandId.DataValueField = "MACHINE_BRAND_ID";

            ddlMachineBrandId.DataBind();
            if (ddlMachineBrandId.Items.Count > 0)
            {

                ddlMachineBrandId.SelectedIndex = 0;
            }

        }

        public void getMachineRegionId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlMachineRegionId.DataSource = objLookUpBLL.getMachineRegionId(strHeadOfficeId, strBranchOfficeId);

            ddlMachineRegionId.DataTextField = "MACHINE_REGION_NAME";
            ddlMachineRegionId.DataValueField = "MACHINE_REGION_ID";

            ddlMachineRegionId.DataBind();
            if (ddlMachineRegionId.Items.Count > 0)
            {

                ddlMachineRegionId.SelectedIndex = 0;
            }

        }

        public void getMachineModelId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlMachineModelId.DataSource = objLookUpBLL.getMachineModelId(strHeadOfficeId, strBranchOfficeId);

            ddlMachineModelId.DataTextField = "MACHINE_MODEL_NAME";
            ddlMachineModelId.DataValueField = "MACHINE_MODEL_ID";

            ddlMachineModelId.DataBind();
            if (ddlMachineModelId.Items.Count > 0)
            {

                ddlMachineModelId.SelectedIndex = 0;
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

        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }


        public void saveMachineDetailInformation()
        {



            WokerProcessDTO objWokerProcessDTO = new WokerProcessDTO();
            WorkerProcessBLL objWorkerProcessBLL = new WorkerProcessBLL();


            objWokerProcessDTO.MachineId = txtMachineId.Text;
            objWokerProcessDTO.ManufacturerSL = txtManufacturerSerialNo.Text;
            objWokerProcessDTO.MALSL = txtMALSerialNo.Text;



            if (ddlMachineBrandId.SelectedValue.ToString() != " ")
            {
                objWokerProcessDTO.BrandId = ddlMachineBrandId.SelectedValue.ToString();
            }
            else
            {
                objWokerProcessDTO.BrandId = "";

            }


            if (ddlMachineModelId.SelectedValue.ToString() != " ")
            {
                objWokerProcessDTO.ModelId = ddlMachineModelId.SelectedValue.ToString();
            }
            else
            {
                objWokerProcessDTO.ModelId = "";

            }


            if (ddlMachineRegionId.SelectedValue.ToString() != " ")
            {
                objWokerProcessDTO.MachineRegionId = ddlMachineRegionId.SelectedValue.ToString();
            }
            else
            {
                objWokerProcessDTO.MachineRegionId = "";

            }

            if (ddlMachineTypeId.SelectedValue.ToString() != " ")
            {
                objWokerProcessDTO.MachineType = ddlMachineTypeId.SelectedValue.ToString();
            }
            else
            {
                objWokerProcessDTO.MachineType = "";

            }

            objWokerProcessDTO.UpdateBy = strEmployeeId;
            objWokerProcessDTO.HeadOfficeId = strHeadOfficeId;
            objWokerProcessDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objWorkerProcessBLL.saveMachineDetailInformation(objWokerProcessDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);




        }
      
        #endregion
        #region "GridView Functionlity"

        protected void gvUnit_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUnit.PageIndex = e.NewPageIndex;
           
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            //int strRowId = gvUnit.SelectedRow.RowIndex;
            //string strProcessId = gvUnit.SelectedRow.Cells[0].Text;
            //string strProcessName = gvUnit.SelectedRow.Cells[1].Text;

            //txtMachineId.Text = strProcessId;
            //txtMachineTypeName.Text = strProcessName;

            //string strMsg = "Row Index: " + strRowId + "\\nMachine ID: " + strProcessId + "\\nMachine Type : " + strProcessName;
            ////ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + strMsg + "');", true);
            //MessageBox(strMsg);
        }
        protected void gvUnit_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        }
        protected void gvUnit_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvUnit.EditIndex = e.NewEditIndex;
            
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





        #endregion

        protected void btnClear_Click(object sender, EventArgs e)
        {
            getMachineBrandId();
            getMachineModelId();
            getMachineRegionId();
            getMachineTypeId();

            txtMachineId.Text = "";
            txtMALSerialNo.Text = "";
            txtManufacturerSerialNo.Text = "";

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            saveMachineDetailInformation();
            searchMachineEntryResult();
            clearTextBox();

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            searchMachineEntryResult();
        }
    }
}
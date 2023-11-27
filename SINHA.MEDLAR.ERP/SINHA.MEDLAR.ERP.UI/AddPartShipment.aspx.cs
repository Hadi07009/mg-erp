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
    public partial class AddPartShipment : System.Web.UI.Page
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
            loadPartshipmentRecord();
        }

        if (IsPostBack)
        {

            loadSesscion();
        }

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


        public void loadPartshipmentRecord()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.loadPartshipmentRecord();


            if (dt.Rows.Count > 0)
            {
                gvPartShipment.DataSource = dt;
                gvPartShipment.DataBind();
                string strMsg = "TOTAL " + gvPartShipment.Rows.Count + " RECORD FOUND";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvPartShipment.DataSource = dt;
                gvPartShipment.DataBind();
                int totalcolums = gvPartShipment.Rows[0].Cells.Count;
                gvPartShipment.Rows[0].Cells.Clear();
                gvPartShipment.Rows[0].Cells.Add(new TableCell());
                gvPartShipment.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvPartShipment.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                MessageBox(strMsg);
                lblMsg.Text = strMsg;

            }


        }


        public void clear()
        {
            txtPartShipmentId.Text = string.Empty;
            txtPartShipmentName.Text = string.Empty;

        }

        public void savePartshipmentInfo()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();


            objLookUpDTO.PartShipmentId = txtPartShipmentId.Text;
            objLookUpDTO.PartShipmentName = txtPartShipmentName.Text;



            objLookUpDTO.UpdateBy = strHeadOfficeId;
            objLookUpDTO.HeadOfficeId = strBranchOfficeId;
            objLookUpDTO.BranchOfficeId = strEmployeeId;
            string strMsg = objLookUpBLL.savePartshipmentInfo(objLookUpDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);


        }

        public void clearTextBox()
        {
            txtPartShipmentId.Text = "";
            txtPartShipmentName.Text = "";

        }


        public void searchPartshipmentEntry()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();




            objLookUpDTO = objLookUpBLL.searchPartshipmentEntry(txtPartShipmentId.Text, strHeadOfficeId, strBranchOfficeId);

            txtPartShipmentName.Text = objLookUpDTO.PartShipmentName;



        }


        #endregion

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtPartShipmentName.Text == "")
                {

                    string strMsg = "Please Enter Partshipment Name!!!";
                    txtPartShipmentName.Focus();
                    MessageBox(strMsg);
                    return; 
                }
                else
                {
                    savePartshipmentInfo();
                    loadPartshipmentRecord();

                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error : " + ex.Message);
            }
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


        #region "GridView Functionlity"

        protected void gvPartShipment_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPartShipment.PageIndex = e.NewPageIndex;
            loadPartshipmentRecord();
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvPartShipment.SelectedRow.RowIndex;
            string strPartShipmentId = gvPartShipment.SelectedRow.Cells[0].Text;
            string strPartShipmentName = gvPartShipment.SelectedRow.Cells[1].Text;


            txtPartShipmentId.Text = strPartShipmentId;
            txtPartShipmentName.Text = strPartShipmentName;

        }
        protected void gvUnit_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        }
        protected void gvPartShipment_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvPartShipment.EditIndex = e.NewEditIndex;
            loadPartshipmentRecord();
        }
        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvPartShipment, "Select$" + e.Row.RowIndex);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtPartShipmentId.Text == "")
            {

                string strMsg = "Please Enter Partshipment ID!!!";
                txtPartShipmentId.Focus();
                MessageBox(strMsg);
                return;

            }
            else
            {

                searchPartshipmentEntry();
            }
        }


        #endregion

    }
}
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
    public partial class AddTranShipment : System.Web.UI.Page
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
            loadTranshipmentRecord();
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


        public void loadTranshipmentRecord()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.loadTranshipmentRecord();


            if (dt.Rows.Count > 0)
            {
                gvTranShipment.DataSource = dt;
                gvTranShipment.DataBind();
                string strMsg = "TOTAL " + gvTranShipment.Rows.Count + " RECORD FOUND";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvTranShipment.DataSource = dt;
                gvTranShipment.DataBind();
                int totalcolums = gvTranShipment.Rows[0].Cells.Count;
                gvTranShipment.Rows[0].Cells.Clear();
                gvTranShipment.Rows[0].Cells.Add(new TableCell());
                gvTranShipment.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvTranShipment.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                MessageBox(strMsg);
                lblMsg.Text = strMsg;

            }


        }


        public void clear()
        {
            txtTranShipmentId.Text = string.Empty;
            txtTranShipmentName.Text = string.Empty;

        }

        public void saveTranshipmentInfo()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();


            objLookUpDTO.TranShipmentId = txtTranShipmentId.Text;
            objLookUpDTO.TranShipmentName = txtTranShipmentName.Text;



            objLookUpDTO.UpdateBy = strHeadOfficeId;
            objLookUpDTO.HeadOfficeId = strBranchOfficeId;
            objLookUpDTO.BranchOfficeId = strEmployeeId;
            string strMsg = objLookUpBLL.saveTranshipmentInfo(objLookUpDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);


        }

        public void clearTextBox()
        {
            txtTranShipmentId.Text = "";
            txtTranShipmentName.Text = "";

        }


        public void searchTranshipmentEntry()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();




            objLookUpDTO = objLookUpBLL.searchTranshipmentEntry(txtTranShipmentId.Text, strHeadOfficeId, strBranchOfficeId);

            txtTranShipmentName.Text = objLookUpDTO.TranShipmentName;



        }


        #endregion

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtTranShipmentName.Text == "")
                {

                    string strMsg = "Please Enter Transhipment Name!!!";
                    txtTranShipmentName.Focus();
                    MessageBox(strMsg);
                    return; 
                }
                else
                {
                    saveTranshipmentInfo();
                    loadTranshipmentRecord();

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

        protected void gvTranShipment_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTranShipment.PageIndex = e.NewPageIndex;
            loadTranshipmentRecord();
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvTranShipment.SelectedRow.RowIndex;
            string strTranShipmentId = gvTranShipment.SelectedRow.Cells[0].Text;
            string strTranShipmentName = gvTranShipment.SelectedRow.Cells[1].Text;


            txtTranShipmentId.Text = strTranShipmentId;
            txtTranShipmentName.Text = strTranShipmentName;

        }
        protected void gvUnit_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        }
        protected void gvTranShipment_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvTranShipment.EditIndex = e.NewEditIndex;
            loadTranshipmentRecord();
        }
        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvTranShipment, "Select$" + e.Row.RowIndex);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtTranShipmentId.Text == "")
            {

                string strMsg = "Please Enter Transhipment ID!!!";
                txtTranShipmentId.Focus();
                MessageBox(strMsg);
                return;

            }
            else
            {

                searchTranshipmentEntry();
            }
        }


        #endregion

    }
}
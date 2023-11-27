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
using System.Collections.Specialized;

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;
using System.Drawing;


namespace SINHA.MEDLAR.ERP.UI
{
    public partial class PoDocuments : System.Web.UI.Page
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
        string strReport = "";
        bool status;


        ReportDocument rd = new ReportDocument();

        string strDefaultName = "Report";
        ExportFormatType formatType = ExportFormatType.NoFormat;


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
                clearMsg();
                getOfficeName();
                getCurrentDate();            
            }

            if (IsPostBack)
            {

                loadSesscion();

            }

            txtPoNumber.Focus();

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
            lblMsgRecord.Text = string.Empty;
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

        public void getCurrentDate()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.getCurrentDate();


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


        public void savePoDocumentsSave()
        {

            PoDocumentsDTO objPoDocumentsDTO = new PoDocumentsDTO();
            PoDocumentsBLL objPoDocumentsBLL = new PoDocumentsBLL();


            int rowIndex = 0;
            string strMsg = "";



            objPoDocumentsDTO.PoNumber = txtPoNumber.Text;
            objPoDocumentsDTO.DocumentName = txtDocumentName.Text;

            objPoDocumentsDTO.UpdateBy = strEmployeeId;
            objPoDocumentsDTO.HeadOfficeId = strHeadOfficeId;
            objPoDocumentsDTO.BranchOfficeId = strBranchOfficeId;


            strMsg = objPoDocumentsBLL.savePoDocumentsSave(objPoDocumentsDTO);
            //MessageBox(strMsg);
            lblMsg.Text = strMsg;
            

            if (strMsg == "UPDATED SUCCESSFULLY")
            {
                MessageBox(strMsg);
            }
            else if(strMsg == "INSERTED SUCCESSFULLY")
            {

                MessageBox(strMsg);

            }
        }


        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtPoNumber.Text == " ")
            {
                string strMsg = "Please Enter Po Number!!!";
                MessageBox(strMsg);
                txtPoNumber.Focus();
                return;

            }
            else
            {
                LoadPoDocumentsRecord();
            }
        }

        public void LoadPoDocumentsRecord()
        {
            PoDocumentsDTO objPoDocumentsDTO = new PoDocumentsDTO();
            PoDocumentsBLL objPoDocumentsBLL = new PoDocumentsBLL();

            string strPoNumber;
            if (txtPoNumber.Text.Length > 0)
            {

                strPoNumber = txtPoNumber.Text;
            }
            else
            {
                strPoNumber = "";

            }


            objPoDocumentsDTO = objPoDocumentsBLL.LoadPoDocumentsRecord(strPoNumber, strHeadOfficeId, strBranchOfficeId);

            if (objPoDocumentsDTO.DocumentName == "0")
            {
                txtDocumentName.Text = "";
            }
            else
            {
                txtDocumentName.Text = objPoDocumentsDTO.DocumentName;
            }
            

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
           
            if (txtPoNumber.Text == "")
            {
                string strMsg = "Please Enter Po Number!!!";
                MessageBox(strMsg);
                txtPoNumber.Focus();
                return;
            }
   
            else
            {

                savePoDocumentsSave();
                LoadPoDocumentsRecord();

            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtPoNumber.Text = "";
            txtDocumentName.Text = "";
        }



        #region "Grid View Functionality"

        protected void chkPDF_CheckedChanged(object sender, EventArgs e)
        {

        }
        protected void chkExcel_CheckedChanged(object sender, EventArgs e)
        {

        }
        #endregion


        protected void txtPoNumber_TextChanged(object sender, EventArgs e)
        {
            PoDocumentsDTO objPoDocumentsDTO = new PoDocumentsDTO();
            PoDocumentsBLL objPoDocumentsBLL = new PoDocumentsBLL();

            DataTable dt = new DataTable();

            objPoDocumentsDTO.PoNumber = txtPoNumber.Text; ;
            objPoDocumentsDTO.HeadOfficeId = strHeadOfficeId;
            objPoDocumentsDTO.BranchOfficeId = strBranchOfficeId;

            dt = objPoDocumentsBLL.LoadPoNumber(objPoDocumentsDTO);


            if (dt.Rows.Count > 0)
            {
                gvPoRequisition3.Visible = true;

                gvPoRequisition3.DataSource = dt;
                ViewState["CurrentTable3"] = dt;
                gvPoRequisition3.DataBind();


            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvPoRequisition3.DataSource = dt;
                gvPoRequisition3.DataBind();
                int totalcolums = gvPoRequisition3.Rows[0].Cells.Count;
                gvPoRequisition3.Rows[0].Cells.Clear();
                gvPoRequisition3.Rows[0].Cells.Add(new TableCell());
                gvPoRequisition3.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvPoRequisition3.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;

            }
        }
        protected void gvPoRequisition3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //e.Row.Cells[0].BackColor = Color.FromName("#BAD7E6");

                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvPoRequisition3, "Select$" + e.Row.RowIndex);
            }
        }
        protected void gvPoRequisition3_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPoNumber.Text = gvPoRequisition3.SelectedRow.Cells[0].Text;
            gvPoRequisition3.Visible = false;

            LoadPoDocumentsRecord();
        }
    }
}
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
using System.Net;

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class AddSeason : System.Web.UI.Page
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
                loadSeasonRecord();
                getOfficeName();
            }

            if (IsPostBack)
            {

                loadSesscion();
                
            }


            
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (txtSeasonName.Text == string.Empty)
            {

                string strMsg = "Please Enter Season Name!!!";
                MessageBox(strMsg);
                txtSeasonName.Focus();
                return ;
            }
            else
            {
                saveSeasonInfo();
                loadSeasonRecord();

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


        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }

        public void saveSeasonInfo()
        {


            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO.SeasonId = txtSeasonId.Text;
            objLookUpDTO.SeasonName = txtSeasonName.Text;


            objLookUpDTO.UpdateBy = strEmployeeId;
            objLookUpDTO.HeadOfficeId = strHeadOfficeId;
            objLookUpDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objLookUpBLL.saveSeasonInfo(objLookUpDTO);
            MessageBox(strMsg);

        }

        public void searchSeasonInfo()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.searchSeasonInfo(txtSeasonId.Text);

            txtSeasonName.Text = objLookUpDTO.SeasonName;



        }

        public void loadSeasonRecord()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.loadSeasonRecord(strHeadOfficeId, strBranchOfficeId);


            if (dt.Rows.Count > 0)
            {
                gvSeason.DataSource = dt;
                gvSeason.DataBind();
                string strMsg = "TOTAL " + gvSeason.Rows.Count + " RECORD FOUND";
                lblMsg.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvSeason.DataSource = dt;
                gvSeason.DataBind();
                int totalcolums = gvSeason.Rows[0].Cells.Count;
                gvSeason.Rows[0].Cells.Clear();
                gvSeason.Rows[0].Cells.Add(new TableCell());
                gvSeason.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvSeason.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                MessageBox(strMsg);
                lblMsg.Text = strMsg;

            }


        }


        public void clearTextBox()
        {
            txtSeasonId.Text = "";
            txtSeasonName.Text = "";
        }

        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSeasonId.Text == string.Empty)
            {

                string strMsg = "Please Enter Season ID!!!";
                MessageBox(strMsg);
                txtSeasonId.Focus();
                return;
            }
            else
            {
                //string url = Request.Url.ToString() ;
                //url = url + "?ID=" + txtSeasonId.Text;
                //var webClient = new WebClient();
                //string data = webClient.DownloadString(url) + txtSeasonId.Text;
                //Response.Write(Request.Form[url]) ;
                //btnSearch.PostBackUrl = url;
                searchSeasonInfo();

            }
        }

        protected void gvSeason_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSeason.PageIndex = e.NewPageIndex;
            loadSeasonRecord();
        }

        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvSeason.SelectedRow.RowIndex;
            string strSeasonId = gvSeason.SelectedRow.Cells[0].Text;
            string strSeasonName = gvSeason.SelectedRow.Cells[1].Text;
           

            txtSeasonId.Text = strSeasonId;
            txtSeasonName.Text = strSeasonName;
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





    
    }
}
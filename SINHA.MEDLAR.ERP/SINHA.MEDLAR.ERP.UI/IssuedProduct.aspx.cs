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
using System.Web.Services;
using System.Web.Script.Services;

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class IssuedProduct : System.Web.UI.Page
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


        //ReportDocument rd = new ReportDocument();
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
                getMonthYear();
                getSectionId();

                txtPartNo.Focus();

            }
            if (IsPostBack)
            {

                loadSesscion();
            }
            Session["strRequisitionNo"] = "";


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
        public void getSectionId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();


            ddlSectionId.DataSource = objLookUpBLL.getSectionId( strHeadOfficeId,  strBranchOfficeId);

            ddlSectionId.DataTextField = "SECTION_NAME";
            ddlSectionId.DataValueField = "SECTION_ID";

            ddlSectionId.DataBind();
            if (ddlSectionId.Items.Count > 0)
            {

                ddlSectionId.SelectedIndex = 0;
            }

        }
        public void getMonthYear()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.getMonthYear();

            txtYear.Text = objLookUpDTO.Year;
            txtMonth.Text = objLookUpDTO.Month;

        }
        public void clearAllTextBox()
        {
            txtTranId.Text = string.Empty;
            txtOpeningBlance.Text = string.Empty;
            txtIssuedQty.Text = string.Empty;
            dtpIssuedDate.Text = string.Empty;
            txtOpeningBlance.Text = string.Empty;
            txtIssuedInFavor.Text = string.Empty;
            txtRemarks.Text = string.Empty;
            txtPartNo.Text = string.Empty;
           
        }
        public void clearTextBox()
        {
            txtTranId.Text = string.Empty;
            txtOpeningBlance.Text = string.Empty;
            txtIssuedQty.Text = string.Empty;
            dtpIssuedDate.Text = string.Empty;
            txtOpeningBlance.Text = string.Empty;
            txtIssuedInFavor.Text = string.Empty;
            txtRemarks.Text = string.Empty;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<string> GetPartNo(string PartNo)
        {
            List<string> allPartNo = new List<string>();

            LookUpBLL objLookUpBLL = new LookUpBLL();

            string strHeadOfficeId = "";
            string strBranchOfficeId = "";
            if (System.Web.HttpContext.Current.Session["strHeadOfficeId"].ToString() != "")
            {
                strHeadOfficeId = System.Web.HttpContext.Current.Session["strHeadOfficeId"].ToString();
            }
            if (System.Web.HttpContext.Current.Session["strBranchOfficeId"].ToString() != "")
            {
                strBranchOfficeId = System.Web.HttpContext.Current.Session["strBranchOfficeId"].ToString();
            }

            string strRequisitionNo = "";

            if (System.Web.HttpContext.Current.Session["strRequisitionNo"].ToString() != "")
            {
                strRequisitionNo = System.Web.HttpContext.Current.Session["strRequisitionNo"].ToString();
            }

            allPartNo = objLookUpBLL.SearchPartNoFromMonthlyStore(strRequisitionNo, PartNo, strHeadOfficeId, strBranchOfficeId);

            return allPartNo;
        }
        public void clearMessage()
        {

            lblMsg.Text = string.Empty;
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

      
        public void loadIssuedProductInfo()
        {
            IssuedProductDTO objIssuedProductDTO = new IssuedProductDTO();
            IssuedProductBLL objIssuedProductBLL = new IssuedProductBLL();

            DataTable dt = new DataTable();


            objIssuedProductDTO.PartNo = txtPartNo.Text;
            //objIssuedProductDTO.TranDate = dtpTranDate.Text;


            objIssuedProductDTO.HeadOfficeId = strHeadOfficeId;
            objIssuedProductDTO.BranchOfficeId = strBranchOfficeId;

            dt = objIssuedProductBLL.loadIssuedProductInfo(objIssuedProductDTO);

            gvIssuedProduct.Columns[1].Visible = true;
            if (dt.Rows.Count > 0)
            {
                gvIssuedProduct.DataSource = dt;
                ViewState["CurrentTable"] = dt;
                gvIssuedProduct.DataBind();
                gvIssuedProduct.Columns[1].Visible = false;
                int count = ((DataTable)gvIssuedProduct.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsg.Text = strMsg;
                // getFirstIndex();
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvIssuedProduct.DataSource = dt;
                gvIssuedProduct.DataBind();
                gvIssuedProduct.Columns[1].Visible = false;
                int totalcolums = gvIssuedProduct.Rows[0].Cells.Count;
                gvIssuedProduct.Rows[0].Cells.Clear();
                gvIssuedProduct.Rows[0].Cells.Add(new TableCell());
                gvIssuedProduct.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvIssuedProduct.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
            }





        }


        public void searchIssuedProductInfo()
        {

            IssuedProductDTO objIssuedProductDTO = new IssuedProductDTO();
            IssuedProductBLL objIssuedProductBLL = new IssuedProductBLL();
            DataTable dt = new DataTable();


            if (txtPartNo.Text != "")
            {
                objIssuedProductDTO.PartNo = txtPartNo.Text;
            }
            else
            {
                objIssuedProductDTO.PartNo = "";

            }
            if (txtYear.Text !="")
            {
                objIssuedProductDTO.TranYear = txtYear.Text;
            }
            else
            {
                objIssuedProductDTO.TranYear = "";

            }

            if (txtMonth.Text != "")
            {
                objIssuedProductDTO.TranMonth = txtMonth.Text;
            }
            else
            {
                objIssuedProductDTO.TranMonth = "";

            }

            objIssuedProductDTO.HeadOfficeId = strHeadOfficeId;
            objIssuedProductDTO.BranchOfficeId = strBranchOfficeId;



            objIssuedProductDTO = objIssuedProductBLL.searchIssuedProductInfo(objIssuedProductDTO);

            if (objIssuedProductDTO.OpeningBlance != "0")
            {
                txtOpeningBlance.Text = objIssuedProductDTO.OpeningBlance;
            }
            else {
                txtOpeningBlance.Text = "0";
            }
        }

        //public string CheckSavedData(string strPartNo)
        //{
        //    IssuedProductDTO objIssuedProductDTO = new IssuedProductDTO();
        //    IssuedProductBLL objIssuedProductBLL = new IssuedProductBLL();

        //    objIssuedProductDTO = objIssuedProductBLL.CheckSavedData(strPartNo, strHeadOfficeId, strBranchOfficeId);

        //    if (objIssuedProductDTO.MRRNo != "")
        //    {
        //        txtMRRNo.Text = objIssuedProductDTO.MRRNo;
        //    }
        //    else
        //    {
        //        txtMRRNo.Text = "";
        //    }

        //    if (objIssuedProductDTO.ReceivedQty != "")
        //    {
        //        txtIssuedInFavor.Text = objIssuedProductDTO.ReceivedQty;
        //    }
        //    else
        //    {
        //        txtIssuedInFavor.Text = "0";
        //    }

        //    if (objIssuedProductDTO.ReceivedDate != "")
        //    {
        //        dtpReceivedDate.Text = objIssuedProductDTO.ReceivedDate;
        //    }
        //    else
        //    {
        //        dtpReceivedDate.Text = "";
        //    }

        //    return objIssuedProductDTO.MRRNo;
        //}

        public void saveIssuedProductInfo()
        {
            IssuedProductDTO objIssuedProductDTO = new IssuedProductDTO();
            IssuedProductBLL objIssuedProductBLL = new IssuedProductBLL();

            objIssuedProductDTO.TranId = txtTranId.Text;
            objIssuedProductDTO.PartNo = txtPartNo.Text;
            objIssuedProductDTO.OpeningBlance = txtOpeningBlance.Text;
            objIssuedProductDTO.IssuedQty = txtIssuedQty.Text;
            objIssuedProductDTO.IssuedDate = dtpIssuedDate.Text;

            if (ddlSectionId.SelectedValue == string.Empty)
            {
                objIssuedProductDTO.SectionId = "";
            }
            else {
                objIssuedProductDTO.SectionId = ddlSectionId.SelectedValue;
            }
            objIssuedProductDTO.IssuedInFavor = txtIssuedInFavor.Text;

            objIssuedProductDTO.Remarks = txtRemarks.Text;


            objIssuedProductDTO.HeadOfficeId = strHeadOfficeId;
            objIssuedProductDTO.BranchOfficeId = strBranchOfficeId;
            objIssuedProductDTO.UpdateBy = strEmployeeId;


            string strMsg = objIssuedProductBLL.saveIssuedProductInfo(objIssuedProductDTO);
            if (strMsg != "UPDATED SUCCESSFULLY" && strMsg != "" && strMsg != "null")
            {
                string input = strMsg;
                string subStr = input.Substring(22);
                txtTranId.Text = subStr;
                lblMsg.Text = strMsg;
                MessageBox(strMsg);

            }
            else
            {

                MessageBox(strMsg);

            }

        }
 
        #endregion

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtOpeningBlance.Text == string.Empty)
                {
                    string strMsg = "Please click searh Button!!!";
                    MessageBox(strMsg);
                    btnSearch.Focus();
                    return;

                }
                else if (txtIssuedQty.Text == string.Empty)
                {
                    string strMsg = "Please Enter Issued Qty!!!";
                    MessageBox(strMsg);
                    txtIssuedQty.Focus();
                    return;

                }
                else if (dtpIssuedDate.Text == string.Empty)
                {
                    string strMsg = "Please Enter Issued Date!!!";
                    MessageBox(strMsg);
                    dtpIssuedDate.Focus();
                    return;

                }

                else if (ddlSectionId.SelectedValue == string.Empty )
                {
                    string strMsg = "Please Select Section!!!";
                    MessageBox(strMsg);
                    ddlSectionId.Focus();
                    return;
                }
                else if (txtIssuedInFavor.Text == string.Empty)
                {
                    string strMsg = "Please Enter Issued In-favor!!!";
                    MessageBox(strMsg);
                    txtIssuedInFavor.Focus();
                    return;

                }
                else
                {
                    saveIssuedProductInfo();
                    loadIssuedProductInfo();

                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);

            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPartNo.Text == "")
                {
                    string strMsg = "Please Enter Part No!!!";
                    MessageBox(strMsg);
                    txtPartNo.Focus();
                    return;
                }
                else if (txtYear.Text == "")
                {
                    string strMsg = "Please Enter Year!!!";
                    MessageBox(strMsg);
                    txtYear.Focus();
                    return;
                }
                else if (txtMonth.Text == "")
                {
                    string strMsg = "Please Enter Month!!!";
                    MessageBox(strMsg);
                    txtMonth.Focus();
                    return;
                }
                else
                {

                    searchIssuedProductInfo();
                    loadIssuedProductInfo();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);

            }
        }


        #region "Grid View Functionality"

        protected void gvIssuedProduct_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvIssuedProduct.SelectedRow.RowIndex + 1;
            string strTranId = gvIssuedProduct.SelectedRow.Cells[1].Text;
            string strPartNo = gvIssuedProduct.SelectedRow.Cells[2].Text;
            string strOpeningBlance = gvIssuedProduct.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            string strIssuedQty = gvIssuedProduct.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
            string strIssuedDate = gvIssuedProduct.SelectedRow.Cells[5].Text;
            string strSectionId = gvIssuedProduct.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");
            string strIssuedInFavor = gvIssuedProduct.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");
            string strRemarks = gvIssuedProduct.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");
            


            txtTranId.Text = strTranId;
            txtPartNo.Text = strPartNo;
            txtOpeningBlance.Text = strOpeningBlance;
            txtIssuedQty.Text = strIssuedQty;
            dtpIssuedDate.Text = strIssuedDate;

            SearchSectionId(strTranId);

            txtIssuedInFavor.Text = strIssuedInFavor;
            txtRemarks.Text = strRemarks;
                  

        }
        public void SearchSectionId(string strTranId)
        {
            IssuedProductDTO objIssuedProductDTO = new IssuedProductDTO();
            IssuedProductBLL objIssuedProductBLL = new IssuedProductBLL();
            objIssuedProductDTO = objIssuedProductBLL.searchSectionId(strTranId, strHeadOfficeId, strBranchOfficeId);

            if (objIssuedProductDTO.SectionId != "")
            {
                ddlSectionId.SelectedValue = objIssuedProductDTO.SectionId;
                ddlSectionId.DataBind();
            }
            else {
                getSectionId();
            }
        }

        protected void gvIssuedProduct_OnRowEditing(object sender, GridViewEditEventArgs e)
        {




        }


        protected void gvIssuedProduct_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int stor_id = Convert.ToInt32(gvIssuedProduct.DataKeys[e.RowIndex].Value.ToString());
            string strTranId = Convert.ToString(stor_id);

            deleteIssuedProductRecord(strTranId);
            clearTextBox();
            loadIssuedProductInfo();
        }
        public void deleteIssuedProductRecord(string strTranId)
        {

            IssuedProductDTO objIssuedProductDTO = new IssuedProductDTO();
            IssuedProductBLL objIssuedProductBLL = new IssuedProductBLL();


            objIssuedProductDTO.TranId = strTranId;
            objIssuedProductDTO.PartNo = txtPartNo.Text;


            objIssuedProductDTO.UpdateBy = strEmployeeId;
            objIssuedProductDTO.HeadOfficeId = strHeadOfficeId;
            objIssuedProductDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objIssuedProductBLL.deleteIssuedProductRecord(objIssuedProductDTO);
            MessageBox(strMsg);
        }


        protected void gvIssuedProduct_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[10].Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Cells[10].Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Cells[10].Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvIssuedProduct, "Select$" + e.Row.Cells[10]);
               
            }
        }

        #endregion

        protected void chkPDF_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        protected void chkExcel_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clearAllTextBox();          
        }

    }
}
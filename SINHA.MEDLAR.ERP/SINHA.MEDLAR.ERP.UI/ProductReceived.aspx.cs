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
    public partial class ProductReceived : System.Web.UI.Page
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

               

                //Session["strRequisitionNo"] = txtRequisitionNo.Text;
                txtRequisitionNo.Focus();

            }
            if (IsPostBack)
            {

                loadSesscion();
            }


            txtReceivedQty.Attributes.Add("onkeypress", "return controlEnter('" + dtpReceivedDate.ClientID + "', event)");
            txtRequisitionNo.Attributes.Add("onkeypress", "return controlEnter('" + txtPartNoSrc.ClientID + "', event)");

            Session["strRequisitionNo"] = txtRequisitionNo.Text;
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

        public void clearAllTextBox()
        {
            txtMRRNo.Text = string.Empty;
            txtPartNo.Text = string.Empty;
            txtRequiredQty.Text = string.Empty;
            txtApprovedQty.Text = string.Empty;
            txtReceivedQty.Text = string.Empty;
            txtRequisitionNo.Text = string.Empty;
            txtPartNoSrc.Text = string.Empty;
            dtpReceivedDate.Text = string.Empty;
        }
        public void clearTextBox()
        {
            txtMRRNo.Text = string.Empty;
            txtPartNo.Text = string.Empty;
            txtRequiredQty.Text = string.Empty;
            txtApprovedQty.Text = string.Empty;
            txtReceivedQty.Text = string.Empty;
            dtpReceivedDate.Text = string.Empty;

        }
       
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<string> GetRequisitionNo(string RequisitionNo)
        {
            List<string> allRequisitionNo = new List<string>();

            LookUpBLL objLookUpBLL = new LookUpBLL();

            string strHeadOfficeId = "";
            string strBranchOfficeId = "";
            if (System.Web.HttpContext.Current.Session["strHeadOfficeId"].ToString() !="")
            {
                strHeadOfficeId = System.Web.HttpContext.Current.Session["strHeadOfficeId"].ToString();
            }
            if (System.Web.HttpContext.Current.Session["strBranchOfficeId"].ToString() != "")
            {
                strBranchOfficeId = System.Web.HttpContext.Current.Session["strBranchOfficeId"].ToString();
            }

            //allRequisitionNo = objLookUpBLL.SearchRequisitionNo(RequisitionNo, strHeadOfficeId, strBranchOfficeId);
            allRequisitionNo = objLookUpBLL.SearchRequisitionNoFromPOtracking(RequisitionNo, strHeadOfficeId, strBranchOfficeId);

            return allRequisitionNo;
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

           
            //allPartNo = objLookUpBLL.SearchPartNo(strRequisitionNo,PartNo, strHeadOfficeId, strBranchOfficeId);
            allPartNo = objLookUpBLL.SearchPartNoFromPOTracking(strRequisitionNo, PartNo, strHeadOfficeId, strBranchOfficeId);

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

      
        public void loadProductReceivedInfo()
        {
            ProductReceivedDTO objProductReceivedDTO = new ProductReceivedDTO();
            ProductReceivedBLL objProductReceivedBLL = new ProductReceivedBLL();

            DataTable dt = new DataTable();


            objProductReceivedDTO.RequisitionNo = txtRequisitionNo.Text;
            objProductReceivedDTO.PartNo = txtPartNo.Text;
            objProductReceivedDTO.ReceivedDate = dtpReceivedDate.Text;


            objProductReceivedDTO.HeadOfficeId = strHeadOfficeId;
            objProductReceivedDTO.BranchOfficeId = strBranchOfficeId;

            dt = objProductReceivedBLL.loadProductReceivedInfo(objProductReceivedDTO);

            gvProductReceved.Columns[1].Visible = true;
            if (dt.Rows.Count > 0)
            {
                gvProductReceved.DataSource = dt;
                ViewState["CurrentTable"] = dt;
                gvProductReceved.DataBind();
                gvProductReceved.Columns[1].Visible = false;
                int count = ((DataTable)gvProductReceved.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsg.Text = strMsg;
                // getFirstIndex();
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvProductReceved.DataSource = dt;
                gvProductReceved.DataBind();
                gvProductReceved.Columns[1].Visible = false;
                int totalcolums = gvProductReceved.Rows[0].Cells.Count;
                gvProductReceved.Rows[0].Cells.Clear();
                gvProductReceved.Rows[0].Cells.Add(new TableCell());
                gvProductReceved.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvProductReceved.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
            }





        }


        public void searchProductReceivedInfo()
        {

            ProductReceivedDTO objProductReceivedDTO = new ProductReceivedDTO();
            ProductReceivedBLL objProductReceivedBLL = new ProductReceivedBLL();
            DataTable dt = new DataTable();


            if (txtRequisitionNo.Text != "")
            {
                objProductReceivedDTO.RequisitionNo = txtRequisitionNo.Text;
            }
            else
            {
                objProductReceivedDTO.RequisitionNo = "";

            }
            if (txtPartNoSrc.Text != "")
            {
                objProductReceivedDTO.PartNoSrc = txtPartNoSrc.Text;
            }
            else
            {
                objProductReceivedDTO.PartNoSrc = "";

            }

            objProductReceivedDTO.HeadOfficeId = strHeadOfficeId;
            objProductReceivedDTO.BranchOfficeId = strBranchOfficeId;
           


            dt = objProductReceivedBLL.searchProductReceivedInfo(objProductReceivedDTO);


            if (dt.Rows.Count > 0)
            {
                gvProductRecInfoSearch.DataSource = dt;
                gvProductRecInfoSearch.DataBind();

                int count = ((DataTable)gvProductRecInfoSearch.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsg.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvProductRecInfoSearch.DataSource = dt;
                gvProductRecInfoSearch.DataBind();
                int totalcolums = gvProductRecInfoSearch.Rows[0].Cells.Count;
                gvProductRecInfoSearch.Rows[0].Cells.Clear();
                gvProductRecInfoSearch.Rows[0].Cells.Add(new TableCell());
                gvProductRecInfoSearch.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvProductRecInfoSearch.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //gvProductRecInfoSearch.Columns[2].Visible = false;
            }

        }

        public string CheckSavedData(string strPartNo)
        {
            ProductReceivedDTO objProductReceivedDTO = new ProductReceivedDTO();
            ProductReceivedBLL objProductReceivedBLL = new ProductReceivedBLL();

            objProductReceivedDTO = objProductReceivedBLL.CheckSavedData(strPartNo, strHeadOfficeId, strBranchOfficeId);

            if (objProductReceivedDTO.MRRNo != "")
            {
                txtMRRNo.Text = objProductReceivedDTO.MRRNo;
            }
            else
            {
                txtMRRNo.Text = "";
            }

            if (objProductReceivedDTO.ReceivedQty != "")
            {
                txtReceivedQty.Text = objProductReceivedDTO.ReceivedQty;
            }
            else
            {
                txtReceivedQty.Text = "0";
            }

            if (objProductReceivedDTO.ReceivedDate != "")
            {
                dtpReceivedDate.Text = objProductReceivedDTO.ReceivedDate;
            }
            else
            {
                dtpReceivedDate.Text = "";
            }


            if (objProductReceivedDTO.TranId == "0" || objProductReceivedDTO.TranId == null)
            {
                txtTranId.Text = "";
            }
            else
            {
                txtTranId.Text = objProductReceivedDTO.TranId;
            }



            return objProductReceivedDTO.MRRNo;
        }

        public void saveProductReceivedInfo()
        {

            ProductReceivedDTO objProductReceivedDTO = new ProductReceivedDTO();
            ProductReceivedBLL objProductReceivedBLL = new ProductReceivedBLL();

            objProductReceivedDTO.TranId = txtTranId.Text;
            objProductReceivedDTO.MRRNo = txtMRRNo.Text;
            objProductReceivedDTO.RequisitionNo = txtRequisitionNo.Text;
            objProductReceivedDTO.PartNo = txtPartNo.Text;

            objProductReceivedDTO.RequiredQty = txtRequiredQty.Text;
            objProductReceivedDTO.ApprovedQty = txtApprovedQty.Text;
            objProductReceivedDTO.ReceivedQty = txtReceivedQty.Text;

            objProductReceivedDTO.ReceivedDate = dtpReceivedDate.Text;

           


            objProductReceivedDTO.HeadOfficeId = strHeadOfficeId;
            objProductReceivedDTO.BranchOfficeId = strBranchOfficeId;
            objProductReceivedDTO.UpdateBy = strEmployeeId;


            string strMsg = objProductReceivedBLL.saveProductReceivedInfo(objProductReceivedDTO);
            if (strMsg != "UPDATED SUCCESSFULLY" && strMsg != "" && strMsg != "null" && strMsg != "RECEIVED QUANTITY CAN NOT BE LARGER THAN REQUIRED QUANTITY!!!" && strMsg != "RECEIVED QUANTITY CAN NOT BE LARGER THAN APPROVED QUANTITY!!!")
            {
                string input = strMsg;
                string subStr = input.Substring(22);
                txtMRRNo.Text = subStr;
                lblMsg.Text = strMsg;
                MessageBox(strMsg);

            }else
            {

                MessageBox(strMsg);

            }
          




        }
 
        #endregion

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {


                if (gvProductRecInfoSearch.Rows.Count == 0 || gvProductReceved.Rows.Count == 0)
                {
                    string strMsg = "Please click searh Button!!!";
                    MessageBox(strMsg);
                    btnSearch.Focus();
                    return;
                }
                else if (txtPartNo.Text == string.Empty)
                {
                    string strMsg = "Please click in the Gridview!!!";
                    MessageBox(strMsg);
                    return;

                }
                else if (txtRequiredQty.Text == string.Empty)
                {
                    string strMsg = "Please click in the Gridview!!!";
                    MessageBox(strMsg);
                    return;

                }
                else if (txtApprovedQty.Text == string.Empty)
                {
                    string strMsg = "Please click in the Gridview!!!";
                    MessageBox(strMsg);
                    return;

                }

                else if (dtpReceivedDate.Text == string.Empty )
                {
                    string strMsg = "Please Enter Received Date!!!";
                    MessageBox(strMsg);
                    dtpReceivedDate.Focus();
                    return;
                }
                else
                {
                    saveProductReceivedInfo();
                    loadProductReceivedInfo();

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
                if (txtRequisitionNo.Text == "")
                {
                    string strMsg = "Please Enter Requisition!!!";
                    MessageBox(strMsg);
                    txtRequisitionNo.Focus();
                    return;
                }

                //else if (txtPartNoSrc.Text == "")
                //{
                //    string strMsg = "Please Enter Part No!!!";
                //    MessageBox(strMsg);
                //    txtPartNoSrc.Focus();
                //    return;
                //}               
                else
                {

                    searchProductReceivedInfo();
                    loadProductReceivedInfo();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);

            }
        }

        #region "Grid View Functionality"

        protected void gvProductRecInfoSearch_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvProductRecInfoSearch.SelectedRow.RowIndex + 1;
            string strPartNo = gvProductRecInfoSearch.SelectedRow.Cells[1].Text;
            string strRequiredQty = gvProductRecInfoSearch.SelectedRow.Cells[4].Text;
            string strApprovedQty = gvProductRecInfoSearch.SelectedRow.Cells[5].Text;


            txtPartNo.Text = strPartNo;
            CheckSavedData(strPartNo);
            txtRequiredQty.Text = strRequiredQty;
            txtApprovedQty.Text = strApprovedQty;



        }
       



        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {




        }


        protected void gvProductRecInfoSearch_RowDataBound(GridViewRowEventArgs e)
        {
            //e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        }

        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvProductRecInfoSearch, "Select$" + e.Row.RowIndex);
            }
        }
    
        protected void gvProductRecInfoSearch_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        #endregion

        #region "Grid View Functionality2"

        protected void gvProductReceved_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvProductReceved.SelectedRow.RowIndex + 1;
            string strTranId = gvProductReceved.SelectedRow.Cells[1].Text;
            string strMRRNo = gvProductReceved.SelectedRow.Cells[2].Text;
            string strRequisitionNo = gvProductReceved.SelectedRow.Cells[3].Text;
            string strPartNo = gvProductReceved.SelectedRow.Cells[4].Text;
            string strRequiredQty = gvProductReceved.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
            string strApprovedQty = gvProductReceved.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");
            string strReceivedQty = gvProductReceved.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");
            string strReceivedDate = gvProductReceved.SelectedRow.Cells[8].Text;


            //txtTranId.Text = strTranId;
            //txtMRRNo.Text = strMRRNo;
            //txtRequisitionNo.Text = strRequisitionNo;
            //txtPartNo.Text = strPartNo;           
            //txtRequiredQty.Text = strRequiredQty;
            //txtApprovedQty.Text = strApprovedQty;
            //txtReceivedQty.Text = strReceivedQty;
            //dtpReceivedDate.Text = strReceivedDate;

            CheckSavedData(strPartNo);



        }


        protected void gvProductReceved_OnRowEditing(object sender, GridViewEditEventArgs e)
        {




        }


        protected void gvProductReceved_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
           
            string strMrrNo = Convert.ToString(gvProductReceved.DataKeys[e.RowIndex].Values[0]);
            string strTranId = Convert.ToString(gvProductReceved.DataKeys[e.RowIndex].Values[1]);
            string strReceivedDate = Convert.ToString(gvProductReceved.DataKeys[e.RowIndex].Values[2]);
            string strPartNo = Convert.ToString(gvProductReceved.DataKeys[e.RowIndex].Values[3]);

            deleteProductReceivedRecord(strTranId, strMrrNo, strReceivedDate, strPartNo);
            clearTextBox();
            loadProductReceivedInfo();
        }
        public void deleteProductReceivedRecord(string strTranId, string strMrrNo, string strReceivedDate, string strPartNo)
        {

            ProductReceivedDTO objProductReceivedDTO = new ProductReceivedDTO();
            ProductReceivedBLL objProductReceivedBLL = new ProductReceivedBLL();


            objProductReceivedDTO.TranId = strTranId;
            objProductReceivedDTO.MRRNo = strMrrNo;
            objProductReceivedDTO.RequisitionNo = txtRequisitionNo.Text;
            objProductReceivedDTO.ReceivedDate = strReceivedDate;
            objProductReceivedDTO.PartNo = strPartNo;


            objProductReceivedDTO.UpdateBy = strEmployeeId;
            objProductReceivedDTO.HeadOfficeId = strHeadOfficeId;
            objProductReceivedDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objProductReceivedBLL.deleteProductReceivedRecord(objProductReceivedDTO);
            MessageBox(strMsg);
        }


        protected void gvProductReceved_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[10].Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Cells[10].Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Cells[10].Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvProductReceved, "Select$" + e.Row.Cells[10]);
               
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

        //protected void txtRequisitionNo_TextChanged(object sender, EventArgs e)
        //{
        //    Session["strRequisitionNo"] = txtRequisitionNo.Text;
        //    //txtPartNoSrc.Focus();
        //}
    }
}
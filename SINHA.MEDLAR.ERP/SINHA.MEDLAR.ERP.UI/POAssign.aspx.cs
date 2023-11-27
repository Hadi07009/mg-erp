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
using System.Web.Services;
using System.Web.Script.Services;

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class POAssign : System.Web.UI.Page
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
                //loadPOAssignRecord();
                getOfficeName();
                //getStyleId();
                getLineId();
                clearMsg();
                txtPONo.Focus();
            }

            if (IsPostBack)
            {

                loadSesscion();
                
            }

            txtPONo.Attributes.Add("onkeypress", "return controlEnter('" + ddlStyleId.ClientID + "', event)");
            ddlStyleId.Attributes.Add("onkeypress", "return controlEnter('" + ddlLineId.ClientID + "', event)");
           

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (txtPONo.Text == string.Empty)
            {
                string strMsg = "Please Enter PO NO!!!";
                MessageBox(strMsg);
                txtPONo.Focus();
                return ;
            }
            else if (ddlStyleId.SelectedValue == "")
            {
                string strMsg = "Please Select Style No!!!";
                MessageBox(strMsg);
                ddlStyleId.Focus();
                return;
            }

            //else if (txtStyleNo.Text == string.Empty)
            //{
            //    string strMsg = "Please Enter Style NO!!!";
            //    MessageBox(strMsg);
            //    txtStyleNo.Focus();
            //    return;
            //}



            else if (ddlLineId.Text == string.Empty)
            {
                string strMsg = "Please Select Line Name!!!";
                MessageBox(strMsg);
                ddlLineId.Focus();
                return;
            }

            else
            {
                SavePOAssignInfo();
                loadPOAssignRecord();

            }

        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
           
                ShowPOAssignRecord();
            
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

        protected void txtPONo_TextChanged(object sender, EventArgs e)
        {
            SearchStyleId();
        }      

        public void clearMsg()
        {

            lblMsg.Text = string.Empty;
            //lblMsgRecord.Text = string.Empty;
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


      

        public void getLineId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            string strLineId = "";

          


            ddlLineId.DataSource = objLookUpBLL.getLineId(strHeadOfficeId, strBranchOfficeId);

            ddlLineId.DataTextField = "LINE_NAME";
            ddlLineId.DataValueField = "LINE_ID";

            ddlLineId.DataBind();
            if (ddlLineId.Items.Count > 0)
            {

                ddlLineId.SelectedIndex = 0;
            }

        }

        public void SearchStyleId()
        {

            try
            {
                LookUpBLL objLookUpBLL = new LookUpBLL();
                string strPONo = "";

                if (txtPONo.Text != "")
                {
                    strPONo = txtPONo.Text;
                }
                else
                {
                    strPONo = "";
                }



                ddlStyleId.DataSource = objLookUpBLL.SearchStyleId(strPONo, strHeadOfficeId, strBranchOfficeId);

                ddlStyleId.DataTextField = "STYLE_NO";
                ddlStyleId.DataValueField = "STYLE_ID";



                ddlStyleId.DataBind();
                if (ddlStyleId.Items.Count > 0)
                {

                    ddlStyleId.SelectedIndex = 0;
                }

                ddlStyleId.Focus();

            }
            catch (Exception ex)
            {
                MessageBox("Not Found any Style");
            }

        }
        public void getStyleId()
        {

            try
            {
                LookUpBLL objLookUpBLL = new LookUpBLL();
                string strPONo = "";

                if (txtPONo.Text != "")
                {
                    strPONo = txtPONo.Text;
                }
                else
                {
                    strPONo = "";
                }
                string strBuyerId = "";


                ddlStyleId.DataSource = objLookUpBLL.getStyleId(strBuyerId, strHeadOfficeId, strBranchOfficeId);

                ddlStyleId.DataTextField = "STYLE_NO";
                ddlStyleId.DataValueField = "STYLE_ID";



                ddlStyleId.DataBind();
                if (ddlStyleId.Items.Count > 0)
                {

                    ddlStyleId.SelectedIndex = 0;
                }

                ddlStyleId.Focus();

            }
            catch (Exception ex)
            {
                MessageBox("Not Found any Style");
            }

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

        public void SavePOAssignInfo()
        {


            POAssignDTO objPOAssignDTO = new POAssignDTO();
            POAssignBLL objPOAssignBLL = new POAssignBLL();


           

            if (ddlLineId.SelectedValue.ToString() != " ")
            {

                objPOAssignDTO.LineId = ddlLineId.SelectedValue.ToString();

            }
            else
            {

                objPOAssignDTO.LineId = "";
            }


            objPOAssignDTO.POId = txtPOId.Text;
            objPOAssignDTO.PONo = txtPONo.Text;
            //objPOAssignDTO.StyleNo = txtStyleNo.Text;
            if (ddlStyleId.SelectedValue.ToString() != " ")
            {

                objPOAssignDTO.StyleId = ddlStyleId.SelectedValue.ToString();

            }
            else
            {

                objPOAssignDTO.StyleId = "";
            }



            objPOAssignDTO.UpdateBy = strEmployeeId;
            objPOAssignDTO.HeadOfficeId = strHeadOfficeId;
            objPOAssignDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objPOAssignBLL.SavePOAssignInfo(objPOAssignDTO);

            if (strMsg != "INSERTED SUCCESSFULLY" && strMsg != "UPDATED SUCCESSFULLY")
            {
                string input = strMsg;
                string subStr = input.Substring(22);
                txtPOId.Text = subStr;
                MessageBox(strMsg);

            }
           
            else
            {
                MessageBox(strMsg);

            }          

        }

        public void searchPOAssignnfo()
        {
            POAssignDTO objPOAssignDTO = new POAssignDTO();
            POAssignBLL objPOAssignBLL = new POAssignBLL();

            objPOAssignDTO = objPOAssignBLL.searchPOAssignnfo(txtPOId.Text);


          
            if (objPOAssignDTO.LineId == "0")
            {


            }
            else
            {
                ddlLineId.SelectedValue = objPOAssignDTO.LineId;

            }

            if (objPOAssignDTO.PONo == "0")
            {
                txtPONo.Text = "";

            }
            else
            {
                txtPONo.Text = objPOAssignDTO.PONo;
            }

            if (objPOAssignDTO.StyleId == "0")
            {                

            }
            else
            {
                ddlStyleId.SelectedValue = objPOAssignDTO.StyleId;
            }
            //if (objPOAssignDTO.StyleNo == "0")
            //{
            //    txtStyleNo.Text = "";

            //}
            //else
            //{
            //    txtStyleNo.Text = objPOAssignDTO.StyleNo;
            //}



        }

        public void searchLineName(string strPoId)
        {
            POAssignDTO objPOAssignDTO = new POAssignDTO();
            POAssignBLL objPOAssignBLL = new POAssignBLL();

            objPOAssignDTO = objPOAssignBLL.searchLineName(strPoId, strHeadOfficeId, strBranchOfficeId);

            if (objPOAssignDTO.StyleId != "0")
            {
                //getStyleId();
                ddlStyleId.SelectedValue = objPOAssignDTO.StyleId;
            }
            else
            {
                SearchStyleId();
            }

            if (objPOAssignDTO.LineId != "0")
            {
                ddlLineId.SelectedValue = objPOAssignDTO.LineId;
            }
            else
            {
                getLineId();
            }

        }

        public void ShowPOAssignRecord()
        {
            POAssignDTO objPOAssignDTO = new POAssignDTO();
            POAssignBLL objPOAssignBLL = new POAssignBLL();

            DataTable dt = new DataTable();

         
            if (txtPONo.Text != "")
            {
                objPOAssignDTO.PONo = txtPONo.Text;
            }
            else
            {
                objPOAssignDTO.PONo = "";
            }

            //if (txtStyleNo.Text != "")
            //{
            //    objPOAssignDTO.StyleNo = txtStyleNo.Text;
            //}
            //else
            //{
            //    objPOAssignDTO.StyleNo = "";
            //}
            if (ddlStyleId.SelectedValue != "")
            {
                objPOAssignDTO.StyleId = ddlStyleId.SelectedValue;
            }
            else
            {
                objPOAssignDTO.StyleId = "";
            }


            if (ddlLineId.SelectedValue != " ")
            {
                objPOAssignDTO.LineId = ddlLineId.SelectedValue;
            }
            else
            {
                objPOAssignDTO.LineId = "";
            }

            objPOAssignDTO.HeadOfficeId = strHeadOfficeId;
            objPOAssignDTO.BranchOfficeId = strBranchOfficeId;

            dt = objPOAssignBLL.ShowPOAssignRecord(objPOAssignDTO);

            gvBuyerInfo.Columns[6].Visible = true;
            if (dt.Rows.Count > 0)
            {
                gvBuyerInfo.DataSource = dt;
                gvBuyerInfo.DataBind();
                gvBuyerInfo.Columns[6].Visible = false;
                string strMsg = "TOTAL " + gvBuyerInfo.Rows.Count + " RECORD FOUND";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvBuyerInfo.DataSource = dt;
                gvBuyerInfo.DataBind();
                gvBuyerInfo.Columns[6].Visible = false;
                int totalcolums = gvBuyerInfo.Rows[0].Cells.Count;
                gvBuyerInfo.Rows[0].Cells.Clear();
                gvBuyerInfo.Rows[0].Cells.Add(new TableCell());
                gvBuyerInfo.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvBuyerInfo.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                MessageBox(strMsg);
                lblMsg.Text = strMsg;

            }


        }


        public void deletePOAssignRecord(string strTarnId,string PO_No)
        {
            POAssignDTO objPOAssignDTO = new POAssignDTO();
            POAssignBLL objPOAssignBLL = new POAssignBLL();

            objPOAssignDTO.TranId = strTarnId;
            if (txtPONo.Text != "")
            {
                objPOAssignDTO.PONo = txtPONo.Text;
            }
            else
            {
                objPOAssignDTO.PONo = PO_No;
            }


            if (ddlStyleId.SelectedValue != "")
            {
                objPOAssignDTO.StyleId = ddlStyleId.SelectedValue;
            }
            else
            {
                objPOAssignDTO.StyleId = "";
            }



            objPOAssignDTO.UpdateBy = strEmployeeId;
            objPOAssignDTO.HeadOfficeId = strHeadOfficeId;
            objPOAssignDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objPOAssignBLL.deletePOAssignRecord(objPOAssignDTO);
            MessageBox(strMsg);
        }


        public void loadPOAssignRecord()
        {
            POAssignDTO objPOAssignDTO = new POAssignDTO();
            POAssignBLL objPOAssignBLL = new POAssignBLL();

            DataTable dt = new DataTable();


            objPOAssignDTO.POId = "";
  
            objPOAssignDTO.PONo = txtPONo.Text;

            //objPOAssignDTO.StyleNo = txtStyleNo.Text;         
            if (ddlStyleId.SelectedValue != "")
            {
                objPOAssignDTO.StyleId = ddlStyleId.SelectedValue;
            }
            else
            {
                objPOAssignDTO.StyleId = "";
            }

            if (ddlLineId.SelectedValue != " ")
            {
                objPOAssignDTO.LineId = ddlLineId.SelectedValue;
            }
            else
            {
                objPOAssignDTO.LineId = "";
            }

            objPOAssignDTO.HeadOfficeId = strHeadOfficeId;
            objPOAssignDTO.BranchOfficeId = strBranchOfficeId;

            dt = objPOAssignBLL.loadPOAssignRecord(objPOAssignDTO);

            gvBuyerInfo.Columns[6].Visible = true;
            if (dt.Rows.Count > 0)
            {
                gvBuyerInfo.DataSource = dt;
                gvBuyerInfo.DataBind();
                gvBuyerInfo.Columns[6].Visible = false;
                string strMsg = "TOTAL " + gvBuyerInfo.Rows.Count + " RECORD FOUND";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvBuyerInfo.DataSource = dt;
                gvBuyerInfo.DataBind();
                gvBuyerInfo.Columns[6].Visible = false;
                int totalcolums = gvBuyerInfo.Rows[0].Cells.Count;
                gvBuyerInfo.Rows[0].Cells.Clear();
                gvBuyerInfo.Rows[0].Cells.Add(new TableCell());
                gvBuyerInfo.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvBuyerInfo.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                MessageBox(strMsg);
                lblMsg.Text = strMsg;

            }
        }

        public void clearTextBox()
        {
            txtPOId.Text = "";
            txtPONo.Text = "";
            SearchStyleId();
            getLineId();
          

        }

        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtPOId.Text == string.Empty)
            {

                string strMsg = "Please Enter ID!!!";
                MessageBox(strMsg);
                txtPOId.Focus();
                return;
            }
            else
            {
                searchPOAssignnfo();

            }
        }

        protected void gvBuyerInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvBuyerInfo.PageIndex = e.NewPageIndex;           
        }

        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[5].Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Cells[5].Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Cells[5].Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvBuyerInfo, "Select$" + e.Row.Cells[5]);

            }
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvBuyerInfo.SelectedRow.RowIndex;
            string strPoId = gvBuyerInfo.SelectedRow.Cells[0].Text.Replace("&nbsp;", "");
            string strPoNo = gvBuyerInfo.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
            //string strStyleNo = gvBuyerInfo.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
           


            txtPOId.Text = strPoId;
            txtPONo.Text = strPoNo;
            //txtStyleNo.Text = strStyleNo;

            searchLineName(strPoId);

         //   searchPOAssignnfo();

        }



        protected void gvBuyerInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                GridViewRow row = (GridViewRow)gvBuyerInfo.Rows[e.RowIndex];
                Label lbldeleteid = (Label)row.FindControl("TRAN_ID");

                //if (lbldeleteid == null)
                //{

                //    string strMsg = "ID NOT FOUND!!!";
                //    MessageBox(strMsg);
                //    return;
                //}
                //else
                //{

                int stor_id = Convert.ToInt32(gvBuyerInfo.DataKeys[e.RowIndex].Values[0]);
                string PO_No = gvBuyerInfo.DataKeys[e.RowIndex].Values[1].ToString();
                string strTarnId = Convert.ToString(stor_id);

                deletePOAssignRecord(strTarnId, PO_No);
                ShowPOAssignRecord();

                //}
            }
            catch (Exception ex)
            {
                MessageBox("It haven't any ID for delete");
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

        protected void ddlFactoryId_SelectedIndexChanged(object sender, EventArgs e)
        {
            getLineId();
        }

       
    }
}
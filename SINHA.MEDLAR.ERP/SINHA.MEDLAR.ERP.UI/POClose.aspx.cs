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
    public partial class POClose : System.Web.UI.Page
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
                //loadPOCloseRecord();
                getOfficeName();
                getBuyerId();
                clearMsg();
            }

            if (IsPostBack)
            {

                loadSesscion();
                
            }


        }

        public void clearMsg()
        {

            lblMsg.Text = string.Empty;
            //lblMsgRecord.Text = string.Empty;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (ddlBuyerId.SelectedValue == string.Empty)
                {
                    string strMsg = "Please Select Buyer Name!!!";
                    MessageBox(strMsg);
                    ddlBuyerId.Focus();
                    return;
                }
                else
                {
                    addPOCloseInfo();
                    //loadPOCloseRecord();

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);

            }

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlBuyerId.SelectedValue == string.Empty)
                {
                    string strMsg = "Please Select Buyer Name!!!";
                    MessageBox(strMsg);
                    ddlBuyerId.Focus();
                    return;
                }
                else
                {

                    searchBuyerInfoFromPOMain();
                    //loadPOCloseRecord();
                }

            }

            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);

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
        public void getBuyerId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlBuyerId.DataSource = objLookUpBLL.getBuyerId(strHeadOfficeId,strBranchOfficeId);

            ddlBuyerId.DataTextField = "BUYER_SHORT_NAME";
            ddlBuyerId.DataValueField = "BUYER_ID";

            ddlBuyerId.DataBind();
            if (ddlBuyerId.Items.Count > 0)
            {

                ddlBuyerId.SelectedIndex = 0;
            }


        }

        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }

        public void addPOCloseInfo()
        {

            POCloseDTO objPOCloseDTO = new POCloseDTO();
            POCloseBLL objPOCloseBLL = new  POCloseBLL();
            string strMsg = "";
            string strCount = GridView1.Rows.Count.ToString();

            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkPOInfo = (CheckBox)row.FindControl("chkPOInfo");
                    if (chkPOInfo.Checked)
                    {

                        if (chkPOInfo.Checked)
                        {
                            objPOCloseDTO.FinalizedYN = "Y";
                        }
                        else
                        {
                            objPOCloseDTO.FinalizedYN = "N";
                        }
                        string strPONo = (row.FindControl("lblPONo") as Label).Text;
                        objPOCloseDTO.PONo = strPONo;

                        string strPODate = (row.FindControl("lblPODate") as Label).Text;
                        objPOCloseDTO.PODate = strPODate;

                        if (ddlBuyerId.SelectedValue != " ")
                        {
                            objPOCloseDTO.BuyerId = ddlBuyerId.SelectedValue;
                        }
                        else
                        {
                            objPOCloseDTO.BuyerId = "";
                        }

                        objPOCloseDTO.UpdateBy = strEmployeeId;
                        objPOCloseDTO.HeadOfficeId = strHeadOfficeId;
                        objPOCloseDTO.BranchOfficeId = strBranchOfficeId;


                        strMsg = objPOCloseBLL.addPOCloseInfo(objPOCloseDTO);

                    }

                }


            }

            lblMsg.Text = strMsg;
            MessageBox(strMsg);

        }

        //public void loadPOCloseRecord()
        //{
        //    POCloseDTO objPOCloseDTO = new POCloseDTO();
        //    POCloseBLL objPOCloseBLL = new POCloseBLL();

        //    string strBuyerId = "";

        //    if (ddlBuyerId.SelectedValue != "")
        //    {
        //        strBuyerId = ddlBuyerId.SelectedValue;
        //    }
        //    else
        //    {
        //        strBuyerId = "";
        //    }

        //    DataTable dt = new DataTable();
        //    dt = objPOCloseBLL.loadPOCloseRecord(strBuyerId,strHeadOfficeId, strBranchOfficeId);


        //    if (dt.Rows.Count > 0)
        //    {
        //        gvPOCloseInfo.DataSource = dt;
        //        gvPOCloseInfo.DataBind();
        //        string strMsg = "TOTAL " + gvPOCloseInfo.Rows.Count + " RECORD FOUND";
        //        //MessageBox(strMsg);
        //        lblMsg.Text = strMsg;
        //    }
        //    else
        //    {
        //        dt.Rows.Add(dt.NewRow());
        //        gvPOCloseInfo.DataSource = dt;
        //        gvPOCloseInfo.DataBind();
        //        int totalcolums = gvPOCloseInfo.Rows[0].Cells.Count;
        //        gvPOCloseInfo.Rows[0].Cells.Clear();
        //        gvPOCloseInfo.Rows[0].Cells.Add(new TableCell());
        //        gvPOCloseInfo.Rows[0].Cells[0].ColumnSpan = totalcolums;
        //        gvPOCloseInfo.Rows[0].Cells[0].Text = "NO RECORD FOUND";

        //        string strMsg = "NO RECORD FOUND!!!";
        //        //MessageBox(strMsg);
        //        //lblMsg.Text = strMsg;

        //    }


        //}
        //protected void gvPOCloseInfo_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
           

        //    string strPO_NO = gvPOCloseInfo.DataKeys[e.RowIndex].Values[0].ToString();
        //    string strPODate = gvPOCloseInfo.DataKeys[e.RowIndex].Values[1].ToString();


        //    deletePOCloseRecord(strPO_NO, strPODate);           
        //    loadPOCloseRecord();



            

        //    ////Get the value of column from the DataKeys using the RowIndex.
        //    //int id = Convert.ToInt32(GridView1.DataKeys[rowIndex].Values[0]);
        //    //string group = GridView1.DataKeys[rowIndex].Values[1].ToString();



        //}
        public void deletePOCloseRecord(string strPO_NO, string strPODate)
        {

            POCloseDTO objPOCloseDTO = new POCloseDTO();
            POCloseBLL objPOCloseBLL = new POCloseBLL();


            objPOCloseDTO.PONo = strPO_NO;
            objPOCloseDTO.PODate = strPODate;


            if (ddlBuyerId.SelectedValue != "")
            {
                objPOCloseDTO.BuyerId = ddlBuyerId.SelectedValue;
            }
            else {
                objPOCloseDTO.BuyerId = "";
            }

            objPOCloseDTO.UpdateBy = strEmployeeId;
            objPOCloseDTO.HeadOfficeId = strHeadOfficeId;
            objPOCloseDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objPOCloseBLL.deletePOCloseRecord(objPOCloseDTO);
            MessageBox(strMsg);
        }
        public void searchBuyerInfoFromPOMain()
        {

            POCloseDTO objPOCloseDTO = new POCloseDTO();
            POCloseBLL objPOCloseBLL = new POCloseBLL();

            DataTable dt = new DataTable();



           

            if (ddlBuyerId.SelectedValue != " ")
            {
                objPOCloseDTO.BuyerId = ddlBuyerId.SelectedValue;
            }
            else
            {
                objPOCloseDTO.BuyerId = "";

            }
            if (txtPONo.Text != "")
            {
                objPOCloseDTO.PONo = txtPONo.Text;
            }
            else
            {
                objPOCloseDTO.PONo = "";
            }


            objPOCloseDTO.HeadOfficeId = strHeadOfficeId;
            objPOCloseDTO.BranchOfficeId = strBranchOfficeId;

            dt = objPOCloseBLL.searchBuyerInfoFromPOMain(objPOCloseDTO);


            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();

                int count = ((DataTable)GridView1.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //GridView1.Columns[2].Visible = false;
                // getFirstIndex();
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                GridView1.DataSource = dt;
                GridView1.DataBind();
                int totalcolums = GridView1.Rows[0].Cells.Count;
                GridView1.Rows[0].Cells.Clear();
                GridView1.Rows[0].Cells.Add(new TableCell());
                GridView1.Rows[0].Cells[0].ColumnSpan = totalcolums;
                GridView1.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //GridView1.Columns[2].Visible = false;
            }

        }

        #endregion


        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;           
        }

        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
            //    e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

            //    e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.GridView1, "Select$" + e.Row.RowIndex);
            //}
        }
        protected void GridView1_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
        protected void GridView1_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            //int strRowId = GridView1.SelectedRow.RowIndex;
            //string strBuyerId = GridView1.SelectedRow.Cells[0].Text.Replace("&nbsp;", "");
            //string strBuyerShortName = GridView1.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
            //string strBuyerFullName = GridView1.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");

            //txtBuyerId.Text = strBuyerId;
            //txtBuyerShortName.Text = strBuyerShortName;
            //txtBuyerFullName.Text = strBuyerFullName;

        }

       
    }
}
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
using SINHA.MEDLAR.ERP.DTO.ViewModels;
using System.Web.Script.Serialization;

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class VFRatioScanPack : System.Web.UI.Page
    {
        static string strEmployeeId = "";
        static string strSectionId = "";
        static string strDepartmentId = "";
        static string strDesignationId = "";
        static string strUnitId = "";
        static string strCatagoryId;

        static string strHeadOfficeId = "";
        static string strBranchOfficeId = "";

        static string strEmployeeTypeId = "";
        static string strLoginDay = "";
        static string strLoginMonth = "";
        static string strLoginDate = "";

        static string strCartoonId ;

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

                //        LoadCartoonDetails();
                //        GetCartoonSsummary();
                //        getOfficeName();

            }

            if (IsPostBack)
            {

                loadSesscion();
                
            }
        }


        [System.Web.Services.WebMethod]
        public static List<CartoonSummary> GetCartoonSummary(string po_no, string style_no)
        {

            


            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();
            DataTable dt = new DataTable();

            List<CartoonSummary> objCartoonSummaries = objLookUpBLL.GetCartoonSummary(po_no, style_no, strHeadOfficeId, strBranchOfficeId);


            //    dt
            //List<CartoonSummary> objCartoonSummaries = CartoonSummary.GetCartoonSummary(po_no, style_no);
            //string msg = "OK";
            //return msg;
            //return "PO: " + po_no + " Style " + style_no + " Ho_id " + ho_id + " br_id " + br_id;

            //return "PO: " + po_no + " Style " + style_no + Environment.NewLine + "The Current Time is: "
            //    + DateTime.Now.ToString();

            return objCartoonSummaries;
        }

        [System.Web.Services.WebMethod]
        public static List<SINHA.MEDLAR.ERP.DTO.ViewModels.CartoonDetail> GetCartoonDetail(string cartoonId, string poNo, string styleNo)
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();
            DataTable dt = new DataTable();

            List<SINHA.MEDLAR.ERP.DTO.ViewModels.CartoonDetail> objCartoonDetail = objLookUpBLL.GetCartoonDetail(cartoonId, poNo, styleNo, strHeadOfficeId, strBranchOfficeId);
            return objCartoonDetail;
        }

        [System.Web.Services.WebMethod]
        public static object SaveProduct(string cartoonId, string poNo, string styleNo, string barCode)
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();
            string status = string.Empty;

            objLookUpDTO.PONo = poNo;  //
            objLookUpDTO.StyleNo = styleNo;
            objLookUpDTO.BarcodeNumber = barCode; //

            objLookUpDTO.UpdateBy = strEmployeeId;
            objLookUpDTO.HeadOfficeId = strHeadOfficeId;
            objLookUpDTO.BranchOfficeId = strBranchOfficeId;
            objLookUpDTO.CartoonId = cartoonId; //hfCartoonId.Value; // 

            string strMsg = objLookUpBLL.SaveProduct(objLookUpDTO, out status);

            //string cartoonNumber = objLookUpBLL.getNextCurtoonNumber(cartoonId, poNo, styleNo, strHeadOfficeId, strBranchOfficeId);
            string result = "{ message: \"" + strMsg + "\", status: \"" + status + "\" }";
            JavaScriptSerializer j = new JavaScriptSerializer();
            object a = j.Deserialize(result, typeof(object));
            return a;
        }
        //protected void btnSave_Click(object sender, EventArgs e)
        //{

        //    if (txtStyleNo.Text.Trim() == string.Empty)
        //    {

        //        string strMsg = "Please Enter Style!!!";
        //        MessageBox(strMsg);
        //        txtStyleNo.Focus();
        //        return ;
        //    }
        //    else if (txtPoNo.Text.Trim() == string.Empty)
        //    {

        //        string strMsg = "Please Enter PO!!!";
        //        MessageBox(strMsg);
        //        txtPoNo.Focus();
        //        return;
        //    }
        //    else if (txtBarcode.Text.Trim() == string.Empty)
        //    {

        //        string strMsg = "Please Enter Barcode Number!!!";
        //        MessageBox(strMsg);
        //        txtBarcode.Focus();
        //        return;
        //    }
        //    //if (txtSizeName.Text.Trim() == string.Empty)
        //    //{

        //    //    string strMsg = "Please Enter Size Name!!!";
        //    //    MessageBox(strMsg);
        //    //    txtSizeName.Focus();
        //    //    return;
        //    //}
        //    //else if (txtBarcodeNumber.Text.Trim() == string.Empty)
        //    //{

        //    //    string strMsg = "Please Enter Barcode Number!!!";
        //    //    MessageBox(strMsg);
        //    //    txtBarcodeNumber.Focus();
        //    //    return;
        //    //}
        //    //if (txtOrderQty.Text.Trim() == string.Empty)
        //    //{

        //    //    string strMsg = "Please Enter Order Qty!!!";
        //    //    MessageBox(strMsg);
        //    //    txtOrderQty.Focus();
        //    //    return;
        //    //}
        //    //else if (txtQtyperCutton.Text.Trim() == string.Empty)
        //    //{

        //    //    string strMsg = "Please Enter Quantity Per Cutton!!!";
        //    //    MessageBox(strMsg);
        //    //    txtQtyperCutton.Focus();
        //    //    return;
        //    //}
        //    else
        //    {
        //        SaveRatioScanPackRecord();
       //         getNextCurtoonNumber();
        //        clearTextBox();
        //        GetCartoonSsummary();
        //        LoadCartoonDetails();
        //    }

        //}
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
        //#region "Function"

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

        //public void getOfficeName()
        //{

        //    LookUpDTO objLookUpDTO = new LookUpDTO();
        //    LookUpBLL objLookUpBLL = new LookUpBLL();

        //    objLookUpDTO = objLookUpBLL.getHeadOfficeName(strHeadOfficeId, strBranchOfficeId);

        //    lblHeadOfficeName.Text = objLookUpDTO.HeadOfficeName;
        //    lblHeadOfficeAddress.Text = objLookUpDTO.HeadOfficeAddress;
        //    lblBranchOfficeName.Text = objLookUpDTO.BranchOfficeName;
        //    lblBranchOfficeAddress.Text = objLookUpDTO.BranchOfficeAddress;

        //}


        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }




        //public void SaveRatioScanPackRecord()
        //{

        //    string status = string.Empty;

        //    LookUpDTO objLookUpDTO = new LookUpDTO();
        //    LookUpBLL objLookUpBLL = new LookUpBLL();
        //    objLookUpDTO.StyleNo = txtStyleNo.Text.Trim(); //
        //    objLookUpDTO.PONo = txtPoNo.Text.Trim();  //
        //    objLookUpDTO.BarcodeNumber = txtBarcode.Text.Trim(); //

        //    objLookUpDTO.UpdateBy = strEmployeeId;
        //    objLookUpDTO.HeadOfficeId = strHeadOfficeId;
        //    objLookUpDTO.BranchOfficeId = strBranchOfficeId;
        //    objLookUpDTO.CartoonId = hfCartoonId.Value; // 

        //    string strMsg = objLookUpBLL.SaveRatioScanPackRecord(objLookUpDTO, out status);

        //    txtResult.Text = status;
        //    if (!string.IsNullOrEmpty(strMsg))
        //        MessageBox(strMsg);
        //}

        //public void searchSizeNameForPacking()
        //{

        //    LookUpDTO objLookUpDTO = new LookUpDTO();
        //    LookUpBLL objLookUpBLL = new LookUpBLL();

        //    objLookUpDTO = objLookUpBLL.searchSizeNameForPacking(txtPoNo.Text);


        //    txtStyleNo.Text = objLookUpDTO.SizeName;



        //}



        //public void GetCartoonSsummary()
        //{
        //    LookUpDTO objLookUpDTO = new LookUpDTO();
        //    LookUpBLL objLookUpBLL = new LookUpBLL();

        //    DataTable dt = new DataTable();
        //    dt = objLookUpBLL.GetCartoonSsummary(txtPoNo.Text, txtStyleNo.Text, strHeadOfficeId, strBranchOfficeId);


        //    if (dt.Rows.Count > 0)
        //    {
        //        gvBuyerEntry.DataSource = dt;
        //        gvBuyerEntry.DataBind();
        //        string strMsg = "TOTAL " + gvBuyerEntry.Rows.Count + " RECORD FOUND";
        //        //MessageBox(strMsg);

        //        lblMsgRecord.Text = strMsg;
        //    }
        //    else
        //    {
        //        dt.Rows.Add(dt.NewRow());
        //        gvBuyerEntry.DataSource = dt;
        //        gvBuyerEntry.DataBind();
        //        int totalcolums = gvBuyerEntry.Rows[0].Cells.Count;
        //        gvBuyerEntry.Rows[0].Cells.Clear();
        //        gvBuyerEntry.Rows[0].Cells.Add(new TableCell());
        //        gvBuyerEntry.Rows[0].Cells[0].ColumnSpan = totalcolums;
        //        gvBuyerEntry.Rows[0].Cells[0].Text = "NO RECORD FOUND";

        //        string strMsg = "NO RECORD FOUND!!!";
        //        MessageBox(strMsg);
        //        // lblMsg.Text = strMsg;
        //        lblMsgRecord.Text = strMsg;

        //    }


        //    //}
        //public void LoadCartoonDetails()
        //{
        //    LookUpDTO objLookUpDTO = new LookUpDTO();
        //    LookUpBLL objLookUpBLL = new LookUpBLL();

        //    DataTable dt = new DataTable();
        //    dt = objLookUpBLL.LoadCartoonDetails(hfCartoonId.Value, txtPoNo.Text, txtStyleNo.Text, strHeadOfficeId, strBranchOfficeId);
        //    //if (dt.Rows.Count > 0)
        //    //{
        //    //    string cartoonNumber = dt.Rows[0]["cartoon_number"].ToString();
        //    //}
        //    // Object o = dt.Rows[0]["cartoon_number"];


        //    if (dt.Rows.Count > 0)
        //    {
        //        txtCartoonNumber.Text = dt.Rows[0]["cartoon_number"].ToString();

        //        GvProjection.DataSource = dt;
        //        GvProjection.DataBind();
        //        string strMsg = "TOTAL " + GvProjection.Rows.Count + " RECORD FOUND";
        //        MessageBox(strMsg);

        //        //lblMsgRecord.Text = strMsg;
        //    }
        //    else
        //    {
        //        dt.Rows.Add(dt.NewRow());
        //        GvProjection.DataSource = dt;
        //        GvProjection.DataBind();
        //        int totalcolums = GvProjection.Rows[0].Cells.Count;
        //        GvProjection.Rows[0].Cells.Clear();
        //        GvProjection.Rows[0].Cells.Add(new TableCell());
        //        GvProjection.Rows[0].Cells[0].ColumnSpan = totalcolums;
        //        GvProjection.Rows[0].Cells[0].Text = "NO RECORD FOUND";

        //        string strMsg = "NO RECORD FOUND!!!";
        //        MessageBox(strMsg);
        //        // lblMsg.Text = strMsg;
        //        lblMsgRecord.Text = strMsg;

        //    }


        //}

        //public void getNextCurtoonNumber()
        //{
        //    LookUpDTO objLookUpDTO = new LookUpDTO();
        //    LookUpBLL objLookUpBLL = new LookUpBLL();

        //    DataTable dt = new DataTable();
        //    dt = objLookUpBLL.getNextCurtoonNumber(cartoonId, poNo, styleNo, strHeadOfficeId, strBranchOfficeId);

        //    if (dt.Rows.Count > 0)
        //    {
        //        txtCartoonNumber.Text = dt.Rows[0]["cartoon_number"].ToString();
        //    }
        //}
        //    //public void loadSizeName()
        //    //{
        //    //    LookUpDTO objLookUpDTO = new LookUpDTO();
        //    //    LookUpBLL objLookUpBLL = new LookUpBLL();

        //    //    DataTable dt = new DataTable();
        //    //    dt = objLookUpBLL.loadSizeName(txtPoNo.Text,txtStyleNo.Text);


        //    //    if (dt.Rows.Count > 0)
        //    //    {
        //    //        gvBuyerEntry.DataSource = dt;
        //    //        gvBuyerEntry.DataBind();
        //    //        string strMsg = "TOTAL " + gvBuyerEntry.Rows.Count + " RECORD FOUND";
        //    //        //MessageBox(strMsg);

        //    //        lblMsgRecord.Text = strMsg;
        //    //    }
        //    //    else
        //    //    {
        //    //        dt.Rows.Add(dt.NewRow());
        //    //        gvBuyerEntry.DataSource = dt;
        //    //        gvBuyerEntry.DataBind();
        //    //        int totalcolums = gvBuyerEntry.Rows[0].Cells.Count;
        //    //        gvBuyerEntry.Rows[0].Cells.Clear();
        //    //        gvBuyerEntry.Rows[0].Cells.Add(new TableCell());
        //    //        gvBuyerEntry.Rows[0].Cells[0].ColumnSpan = totalcolums;
        //    //        gvBuyerEntry.Rows[0].Cells[0].Text = "NO RECORD FOUND";

        //    //        string strMsg = "NO RECORD FOUND!!!";
        //    //        MessageBox(strMsg);
        //    //       // lblMsg.Text = strMsg;
        //    //        lblMsgRecord.Text = strMsg;

        //    //    }


        //    //}



        //    //public void clearTextBox()
        //    //{
        //    //    //txtSizeName.Text = "";
        //    //    txtBarcode.Text = "";
        //    //    //txtOrderQty.Text = "";
        //    //    //txtQtyperCutton.Text = "";


        //    //}

        //    //#endregion

        //    //protected void btnSearch_Click(object sender, EventArgs e)
        //    //{
        //    //    if (txtPoNo.Text == string.Empty)
        //    //    {

        //    //        string strMsg = "Please Enter PO No!!!";
        //    //        MessageBox(strMsg);
        //    //        txtPoNo.Focus();
        //    //        return;
        //    //    }

        //    //   else if (txtStyleNo.Text == string.Empty)
        //    //    {

        //    //        string strMsg = "Please Enter Style No!!!";
        //    //        MessageBox(strMsg);
        //    //        txtStyleNo.Focus();
        //    //        return;
        //    //    }
        //    //    else
        //    //    {
        //    //        //searchSizeNameForPacking();

        //    //        GetCartoonSsummary();

        //    //    }
        //    //}

        //    //protected void gvBuyerEntry_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //    //{
        //    //    gvBuyerEntry.PageIndex = e.NewPageIndex;

        //    //}

        //    //protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        //    //{

        //    //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    //    {
        //    //        e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
        //    //        e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

        //    //        e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvBuyerEntry, "Select$" + e.Row.RowIndex);
        //    //    }
        //    //}

        //    //protected void OnSelectedIndexChanged(object sender, EventArgs e)
        //    //{
        //    //    //LoadCartoonDetails();

        //    //    int strRowId = gvBuyerEntry.SelectedRow.RowIndex;
        //    //    strCartoonId = gvBuyerEntry.SelectedRow.Cells[0].Text.Replace("&nbsp;", "");


        //    //    hfCartoonId.Value = strCartoonId;

        //    //    string strPoNo = gvBuyerEntry.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
        //    //    string strStyNo = gvBuyerEntry.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
        //    //    LoadCartoonDetails();
        //    //    if (txtBarcode.Text.Trim() == string.Empty)
        //    //    {

        //    //        string strMsg = "Please Enter Barcode Number!!!";
        //    //        MessageBox(strMsg);
        //    //        txtBarcode.Focus();
        //    //        return;
        //    //    }
        //    //    //SaveRatioScanPackRecord();
        //    //    //string strPoNo = gvBuyerEntry.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
        //    //    //string strOderQty = gvBuyerEntry.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
        //    //    //string strQuantityPerCutton = gvBuyerEntry.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");


        //    //    //txt

        //    //    //string CartoonId = strSizeId;

        //    //    //txtSizeName.Text = strSizeName;
        //    //    //txtStyleNo.Text = strStyleNo;
        //    //    //txtPoNo.Text = strPoNo;
        //    //    //txtOrderQty.Text = strOderQty;
        //    //    //txtQtyperCutton.Text = strQuantityPerCutton;





        //    //}

        //    //protected void btnClear_Click(object sender, EventArgs e)
        //    //{
        //    //    try
        //    //    {
        //    //        clearTextBox();
        //    //    }
        //    //    catch (Exception ex)
        //    //    {
        //    //        throw new Exception("Error : " +ex.Message);
        //    //    }
        //    //}


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;
using System.Data;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.BLL;
using System.Web.Security;


namespace SINHA.MEDLAR.ERP.UI
{
    public partial class VFPackingList : System.Web.UI.Page
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


        ReportDocument rd = new ReportDocument();
        ExportFormatType formatType = ExportFormatType.NoFormat;
        string strDefaultName = "Report";
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
                loadVFPackingRecord();
                getSizeNameId();
                getDate();
                getOfficeName();
               
            }

            if (IsPostBack)
            {

                loadSesscion();

            }


        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (ddlSizeNameId.Text == string.Empty)
            {

                string strMsg = "Please Enter Size Name!!!";
                //lblMsg.Text = strMsg;
                 MessageBox(strMsg);
                //ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "alert('Please Enter Unit Name');", true);
                //txtSizeName.Focus();
                return ;
            }
            else if (txtBarcodeNumber.Text == string.Empty)
                {

                    string strMsg = "Please Enter Barcode Number.!!!";
                  // lblMsg.Text = strMsg;
                MessageBox(strMsg);
                //ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "alert('Please Enter Unit Name');", true);
                txtBarcodeNumber.Focus();
                    return;
                }
            else if (dtpPackingDate.Text == string.Empty)
            {

                string strMsg = "Please Enter Packing Date!!!";
                //lblMsg.Text = strMsg;
                MessageBox(strMsg);
                //ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "alert('Please Enter Unit Name');", true);
                // txtBarcodeNumber.Focus();
                return;
            }
            else if (txtPoNo.Text == string.Empty)
            {

                string strMsg = "Please Enter PO!!!";
                //lblMsg.Text = strMsg;
                MessageBox(strMsg);
                //ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "alert('Please Enter Unit Name');", true);
                // txtBarcodeNumber.Focus();
                return;
            }
            else if (txtStyleNo.Text == string.Empty)
            {

                string strMsg = "Please Enter Style!!!";
               // lblMsg.Text = strMsg;
                MessageBox(strMsg);
                //ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "alert('Please Enter Unit Name');", true);
                // txtBarcodeNumber.Focus();
                return;
            }
            else if (txtTotalOrderQty.Text == string.Empty)
            {

                string strMsg = "Please Enter Total Order Quantity!!!";
               // lblMsg.Text = strMsg;
                MessageBox(strMsg);
                //ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "alert('Please Enter Unit Name');", true);
                // txtBarcodeNumber.Focus();
                return;
            }

            else if (txtSizeWiweQuantityPerCutton.Text == string.Empty)
            {

                string strMsg = "Please Enter Per Cutton Quantity!!!";
                // lblMsg.Text = strMsg;
                MessageBox(strMsg);
                //ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "alert('Please Enter Unit Name');", true);
                // txtBarcodeNumber.Focus();
                return;
            }
            else if (txtSizeWiseOrderQty.Text == string.Empty)
            {

                string strMsg = "Please Enter Size Wise Order Quantity!!!";
               // lblMsg.Text = strMsg;
                MessageBox(strMsg);
                //ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "alert('Please Enter Unit Name');", true);
                // txtBarcodeNumber.Focus();
                return;
            }
          
            else
            {
                
                saveVFPackingList();
                
                loadVFPackingRecord();
                searchOrderQuantity();
                txtBarcodeNumber.Text = "";
                
                
                
                    //string strMsg = "";
                    //lblMsg.Text = strMsg;
                   
                
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

        public void VFPackingSheet()
        {

            try
            {
                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();


                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                //objReportDTO.UpdateBy = strEmployeeId;

                objReportDTO.PONo = txtPoNo.Text;
                objReportDTO.StyleNo = txtStyleNo.Text;


                //if (ddlSectionId.SelectedValue.ToString() != " ")
                //{
                //    objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                //}
                //else
                //{

                //    objReportDTO.SectionId = "";
                //}



                //if (ddlUnitId.SelectedValue.ToString() != " ")
                //{
                //    objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                //}
                //else
                //{
                //    objReportDTO.UnitId = "";

                //}

                //if (strHeadOfficeId == "441")
                //{
                //    string strPath = Path.Combine(Server.MapPath("~/Reports/rptIncremetSheetAllPower.rpt"));
                //    this.Context.Session["strReportPath"] = strPath;
                //    rd.Load(strPath);
                //    rd.SetDataSource(objReportBLL.VFPackingSheet(objReportDTO));

                //}
                //else
                //{

                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptVFPackingList.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.VFPackingSheet(objReportDTO));

                //}


                rd.SetDatabaseLogon("erp", "erp");
                CrystalReportViewer1.ReportSource = rd;
                CrystalReportViewer1.DataBind();

                reportMaster();


                this.CrystalReportViewer1.Dispose();
                this.CrystalReportViewer1 = null;
                rd.Dispose();
                rd.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            catch (Exception ex)
            {

                this.CrystalReportViewer1.Dispose();
                this.CrystalReportViewer1 = null;
                rd.Dispose();
                rd.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();

            }



        }
        public void reportMaster()
        {

            if (chkPDF.Checked == true)
            {

                CrystalReportViewer1.ReportSource = rd;
                CrystalReportViewer1.DataBind();
                ReportDocument crReportDocument = new ReportDocument();
                Response.Clear();
                Response.Buffer = true;

                formatType = ExportFormatType.PortableDocFormat;
                Stream oStream = null;
                byte[] byteArray = null;

                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();

                oStream = rd.ExportToStream(formatType);
                byteArray = new byte[oStream.Length];
                oStream.Read(byteArray, 0, Convert.ToInt32(oStream.Length - 1));
                Response.ClearContent();
                Response.ClearHeaders();
                Response.ContentType = "application/pdf";
                Response.BinaryWrite(byteArray);
                Response.Flush();
                Response.Close();
                rd.Close();
                rd.Dispose();
            }
            if (chkExcel.Checked == true)
            {

                //CrystalReportViewer1.ReportSource = rd;
                //CrystalReportViewer1.DataBind();

                //formatType = ExportFormatType.Excel;
                //MemoryStream oStream;
                //Response.Clear();
                //Response.Buffer = false;
                //Response.ClearContent();
                //Response.ClearHeaders();

                //oStream = (MemoryStream)rd.ExportToStream(formatType);
                //Response.ContentType = "application/vnd.ms-excel";
                //oStream.Seek(0, SeekOrigin.Begin);
                //Response.BinaryWrite(oStream.ToArray());
                ////Response.End();
                //oStream.Flush();
                //oStream.Close();
                //oStream.Dispose();
                //CrystalReportViewer1.RefreshReport();

                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.ExcelRecord, Response, true, "increment_sheet");
                Response.End();
                CrystalReportViewer1.RefreshReport();

            }




        }

        public void getDate()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.getDate();

            dtpPackingDate.Text = objLookUpDTO.FromDate;
           



        }

        public void getSizeNameId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlSizeNameId.DataSource = objLookUpBLL.getSizeNameId(txtPoNo.Text, txtStyleNo.Text, strHeadOfficeId, strBranchOfficeId);

            ddlSizeNameId.DataTextField = "SIZE_NAME";
            ddlSizeNameId.DataValueField = "BARCODE_NUMBER_ID";

            ddlSizeNameId.DataBind();
            if (ddlSizeNameId.Items.Count > 0)
            {

                ddlSizeNameId.SelectedIndex = 0;
            }


        }


        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }

        public void saveVFPackingList()
        {


            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            if (ddlSizeNameId.SelectedValue.ToString() != " ")
            {
                objLookUpDTO.SizeNameId = ddlSizeNameId.SelectedValue.ToString();

            }
            else
            {

                objLookUpDTO.SizeNameId = "";

            }


           // objLookUpDTO.SizeName= txtSizeName.Text;
            objLookUpDTO.BarcodeNumber = txtBarcodeNumber.Text;
            objLookUpDTO.CRDDate = dtpCRDDate.Text;
            objLookUpDTO.PackingDate = dtpPackingDate.Text;
            objLookUpDTO.StyleNo = txtStyleNo.Text;
            objLookUpDTO.PONo = txtPoNo.Text;
            objLookUpDTO.TotalOrderQTY = txtTotalOrderQty.Text;
            objLookUpDTO.TotalShipQTY = txtTotalShipQty.Text;
            objLookUpDTO.TotalCuttonQTY = txtTotalCTNQty.Text;
            objLookUpDTO.SizeWisePackingQTY= txtSizeWiweQuantityPerCutton.Text;
            objLookUpDTO.OrderQty = txtSizeWiseOrderQty.Text;
            objLookUpDTO.UpdateBy = strEmployeeId;
            objLookUpDTO.HeadOfficeId = strHeadOfficeId;
            objLookUpDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objLookUpBLL.saveVFPackingList(objLookUpDTO);
            //MessageBox(strMsg);
            // lblMsgRecord.Text = strMsg;
            //lblMsg.Text = strMsg;

            if (strMsg == "CUTTON COMPLETE!!!")
            {
                txtMsg.Text = "";
                MessageBox(strMsg);
            }

           else if (strMsg == "MISS MATCH BARCODE!!")
            {
                txtMsg.Text = "";
                MessageBox(strMsg);
            }

            else if (strMsg == "LIMIT OVER ")
            {
                txtMsg.Text = "";
                MessageBox(strMsg);
            }
            else if (strMsg == "LIMIT OVER THIS SIZE!!")
            {
                txtMsg.Text = "";
                MessageBox(strMsg);
            }

            else if (strMsg == "LIMIT OVER CUTTON QUANTITY!!!")
            {
                txtMsg.Text = "";
                MessageBox(strMsg);
            }
            else
            {
                
                txtMsg.Text = strMsg;

            }



        }

        public void searchItemInfo()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.searchItemInfo(ddlSizeNameId.Text, strHeadOfficeId, strBranchOfficeId);

            ddlSizeNameId.Text = objLookUpDTO.ItemId;
            txtBarcodeNumber.Text = objLookUpDTO.ItemName;


        }

        public void searchOrderQuantity()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.searchOrderQuantity(txtPoNo.Text,txtStyleNo.Text, strHeadOfficeId, strBranchOfficeId);

           // txtTotalOrderQty.Text = objLookUpDTO.TotalOrderQTY;
            txtTotalShipQty.Text = objLookUpDTO.TotalShipQTY;
            txtTotalCTNQty.Text = objLookUpDTO.TotalCuttonQTY;


        }
        public void searchTotalOrderQuantity()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.searchTotalOrderQuantity(txtPoNo.Text, txtStyleNo.Text, strHeadOfficeId, strBranchOfficeId);

            txtTotalOrderQty.Text = objLookUpDTO.TotalOrderQTY;
            //txtTotalShipQty.Text = objLookUpDTO.TotalShipQTY;
            //txtTotalCTNQty.Text = objLookUpDTO.TotalCuttonQTY;


        }
        public void searchUnderSizeNaneInfo()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.searchUnderSizeNaneInfo(ddlSizeNameId.SelectedValue.ToString(),txtPoNo.Text, txtStyleNo.Text, strHeadOfficeId, strBranchOfficeId);

            txtSizeWiweQuantityPerCutton.Text = objLookUpDTO.SizeWisePackingQTY;
            txtSizeWiseOrderQty.Text = objLookUpDTO.OrderQty;
        


        }

        public void loadVFPackingRecord()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.loadVFPackingRecord(txtStyleNo.Text,dtpPackingDate.Text,txtPoNo.Text, strHeadOfficeId, strBranchOfficeId);


            if (dt.Rows.Count > 0)
            {
                gvUnit.DataSource = dt;
                gvUnit.DataBind();
                string strMsg = "TOTAL " + gvUnit.Rows.Count + " RECORD FOUND";
                //MessageBox(strMsg);
                //lblMsgRecord.Text = strMsg;
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
                // MessageBox(strMsg);
                //lblMsg.Text = strMsg;
                txtMsg.Text = strMsg;
                //lblMsgRecord.Text = strMsg;

            }


        }


        public void clearTextBox()
        {
          // dtpCRDDate.Text = "";
          // ddlSizeNameId.Text = "";
            txtBarcodeNumber.Text = "";
            

        }
        public void chckQtyPerCutton()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();
            //dtpCRDDate.Text = "";
            //ddlSizeNameId.Text = "";
            int count=0;
            count = 0;
            objLookUpDTO = objLookUpBLL.chckQtyPerCutton(ddlSizeNameId.SelectedValue.ToString(),count, txtStyleNo.Text, txtPoNo.Text, strHeadOfficeId, strBranchOfficeId);
            // objLookUpDTO.SizeWisePackingQTY = txtSizeWiweQuantityPerCutton.Text ;
            //int p = Convert.ToInt32(txtSizeWiweQuantityPerCutton.Text);
            //if(p==count)
            //{

            //    string strMsg = "limit over cutton Quantity!!!";
            //    // lblMsg.Text = strMsg;
            //    MessageBox(strMsg);
            //    //ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "alert('Please Enter Unit Name');", true);
            //    // txtBarcodeNumber.Focus();
            //    return;
            //}


        }

        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtPoNo.Text == string.Empty)
            {

                string strMsg = "Please Enter PO!!!";
                MessageBox(strMsg);
                txtPoNo.Focus();
                return;
            }

            if (txtStyleNo.Text == string.Empty)
            {

                string strMsg = "Please Enter Style!!!";
                 MessageBox(strMsg);
                txtStyleNo.Focus();
                return;
            }
            else
            {
                searchTotalOrderQuantity();
                searchOrderQuantity();
                loadVFPackingRecord();
                getSizeNameId();

            }
        }

        protected void gvUnit_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUnit.PageIndex = e.NewPageIndex;
           
        }
        protected void chkExcel_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExcel.Checked == true)
            {
                chkExcel.AutoPostBack = true;
                chkPDF.Checked = false;


            }
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

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvUnit.SelectedRow.RowIndex;
            string strUnitId = gvUnit.SelectedRow.Cells[0].Text;
            string strUnitName = gvUnit.SelectedRow.Cells[1].Text;

            ddlSizeNameId.Text = strUnitId;
            txtBarcodeNumber.Text = strUnitName;



            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + strMsg + "');", true);
            //MessageBox(strMsg);
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                clearTextBox();
                chckQtyPerCutton();


            }
            catch (Exception ex)
            {
                throw new Exception("Error : " +ex.Message);
            }
        }
        protected void ddlSizeNameId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSizeNameId.Text == "")
            {
                string strMsg = "Please Select Size Name!!!";
                //ddlContractId.Focus();
                MessageBox(strMsg);
                return;

            }
           else if (txtPoNo.Text == "")
            {
                string strMsg = "Please Select PO!!!";
                //ddlContractId.Focus();
                MessageBox(strMsg);
                return;

            }
            else if (txtStyleNo.Text == "")
            {
                string strMsg = "Please Select PO!!!";
                //ddlContractId.Focus();
                MessageBox(strMsg);
                return;

            }

            else
            {

                searchUnderSizeNaneInfo();

            }

        }
        protected void chkPDF_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPDF.Checked == true)
            {
                chkPDF.AutoPostBack = true;
                chkExcel.Checked = false;

            }
        }

     

        protected void btnSearchSize_Click(object sender, EventArgs e)
        {
           
        }

        protected void btnVFSheet_Click(object sender, EventArgs e)
        {
            VFPackingSheet();
        }

        //protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}
    }
}
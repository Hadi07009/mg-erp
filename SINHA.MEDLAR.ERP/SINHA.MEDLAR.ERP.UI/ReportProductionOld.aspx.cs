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
    public partial class Report : System.Web.UI.Page
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
                getBuyerId();
            }

            if (IsPostBack)
            {

                loadSesscion();
            }

        }

        #region "Check Box Region"
        protected void chkPDF_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPDF.Checked == true)
            {

                chkPDF.AutoPostBack = true;
                chkExcel.Checked = false;
                chkText.Checked = false;
                chkWord.Checked = false;
                chkCSV.Checked = false;
            }
        }



        protected void chkExcel_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExcel.Checked == true)
            {
                chkExcel.AutoPostBack = true;
                chkPDF.Checked = false;
                chkText.Checked = false;
                chkWord.Checked = false;
                chkCSV.Checked = false;
            }
        }

        protected void chkWord_CheckedChanged(object sender, EventArgs e)
        {
            if (chkWord.Checked == true)
            {
                chkWord.AutoPostBack = true;
                chkPDF.Checked = false;
                chkText.Checked = false;
                chkExcel.Checked = false;
                chkCSV.Checked = false;
            }
        }

        protected void chkText_CheckedChanged(object sender, EventArgs e)
        {
            if (chkText.Checked == true)
            {
                chkText.AutoPostBack = true;
                chkPDF.Checked = false;
                chkWord.Checked = false;
                chkExcel.Checked = false;
                chkCSV.Checked = false;
            }
        }

        protected void chkCSV_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCSV.Checked == true)
            {
                chkCSV.AutoPostBack = true;
                chkPDF.Checked = false;
                chkWord.Checked = false;
                chkExcel.Checked = false;
                chkText.Checked = false;
            }
        }


        #endregion

        #region "Function"
        public void getBuyerId()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();


            ddlBuyerId.DataSource = objLookUpBLL.getBuyerId(strHeadOfficeId, strBranchOfficeId);

            ddlBuyerId.DataTextField = "BUYER_FULL_NAME";
            ddlBuyerId.DataValueField = "BUYER_ID";

            ddlBuyerId.DataBind();
            if (ddlBuyerId.Items.Count > 0)
            {

                ddlBuyerId.SelectedIndex = 0;
            }


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


     



        #endregion

        #region "Export Convert Function"
        public void ReportFormatMaster()
        {
            //Export the report in different format
            string strDefaultName = "Report";
            ExportFormatType formatType = ExportFormatType.NoFormat;
            if (chkPDF.Checked == true)
            {
                CrystalReportViewer1.ReportSource = rd;
                CrystalReportViewer1.DataBind();
                ReportDocument crReportDocument = new ReportDocument();
                Response.Clear();
                Response.Buffer = true;

                formatType = ExportFormatType.PortableDocFormat;
                System.IO.Stream oStream = null;
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
                //Response.End();
                //oStream.Flush();
                //oStream.Close();
                //oStream.Dispose();
                //CrystalReportViewer1.RefreshReport();


                rd.ExportToHttpResponse
(CrystalDecisions.Shared.ExportFormatType.ExcelRecord, Response, true, "report_production");
                Response.End();
                CrystalReportViewer1.RefreshReport();


            }

            if (chkWord.Checked == true)
            {
                formatType = ExportFormatType.WordForWindows;
                MemoryStream oStream;
                oStream = (MemoryStream)rd.ExportToStream(formatType);
                Response.ContentType = "application/vnd.ms-word";
                oStream.Seek(0, SeekOrigin.Begin);
                Response.BinaryWrite(oStream.ToArray());
                Response.End();
                oStream.Flush();
                oStream.Close();
                oStream.Dispose();
                CrystalReportViewer1.RefreshReport();

            }

            if (chkCSV.Checked == true)
            {
                formatType = ExportFormatType.CharacterSeparatedValues;
                rd.ExportToHttpResponse(formatType, Response, true, strDefaultName);
                Response.End();
                CrystalReportViewer1.RefreshReport();
            }

            if (chkText.Checked == true)
            {
                formatType = ExportFormatType.RichText;
                MemoryStream oStream;
                oStream = (MemoryStream)rd.ExportToStream(formatType);
                Response.ContentType = "text/html";
                oStream.Seek(0, SeekOrigin.Begin);
                Response.BinaryWrite(oStream.ToArray());
                Response.End();
                oStream.Flush();
                oStream.Close();
                oStream.Dispose();
                CrystalReportViewer1.RefreshReport();
            }


            //switch (rbFormat.SelectedItem.Value)
            //{
            //    case "Word":
            //        formatType = ExportFormatType.WordForWindows;
            //        break;
            //    case "PDF":
            //        formatType = ExportFormatType.PortableDocFormat;
            //        break;
            //    case "Excel":
            //        formatType = ExportFormatType.Excel;
            //        break;
            //    case "CSV":
            //        formatType = ExportFormatType.CharacterSeparatedValues;
            //        break;
            //}

            //rd.ExportToHttpResponse(formatType, Response, true, strDefaultName );
            //Response.End();
            //CrystalReportViewer1.RefreshReport();





        }



        #endregion

        protected void btnView_Click(object sender, EventArgs e)
        {

            #region "Report View Functionality"

            if (rdoPOAssignInformation.Checked == true)
            {

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();


                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;

                objReportDTO.FromDate = dtpFromDate.Text;
                objReportDTO.ToDate = dtoToDate.Text;
                objReportDTO.PONo = txtPONo.Text;

                if (ddlBuyerId.SelectedValue.ToString() != " ")
                {

                    objReportDTO.BuyerId = ddlBuyerId.SelectedValue.ToString();

                }
                else
                {
                    objReportDTO.BuyerId = "";

                }


                string strPath = Path.Combine(Server.MapPath("~/Reports/rptPOAssign.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                DataSet ds = new DataSet();

                ds = (objReportBLL.pOAssignInformation(objReportDTO));
                rd.SetDataSource(ds);
                rd.SetDatabaseLogon("erp", "erp");
                CrystalReportViewer1.ReportSource = rd;
                CrystalReportViewer1.DataBind();




                ReportFormatMaster();




            }

            if (rdoPOEntryInformation.Checked == true)
            {

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();


                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;

                objReportDTO.FromDate = dtpFromDate.Text;
                objReportDTO.ToDate = dtoToDate.Text;
                objReportDTO.PONo = txtPONo.Text;

                if (ddlBuyerId.SelectedValue.ToString() != " ")
                {

                    objReportDTO.BuyerId = ddlBuyerId.SelectedValue.ToString();

                }
                else
                {
                    objReportDTO.BuyerId = "";

                }


                string strPath = Path.Combine(Server.MapPath("~/Reports/rptPOEntry.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                DataSet ds = new DataSet();

                ds = (objReportBLL.pOEntryInformation(objReportDTO));
                rd.SetDataSource(ds);
                rd.SetDatabaseLogon("erp", "erp");
                CrystalReportViewer1.ReportSource = rd;
                CrystalReportViewer1.DataBind();




                ReportFormatMaster();




            }

            if (rdoShipmentInformation.Checked == true)
            {

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();


                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;

                objReportDTO.FromDate = dtpFromDate.Text;
                objReportDTO.ToDate = dtoToDate.Text;
                objReportDTO.PONo = txtPONo.Text;

                if (ddlBuyerId.SelectedValue.ToString() != " ")
                {

                    objReportDTO.BuyerId = ddlBuyerId.SelectedValue.ToString();

                }
                else
                {
                    objReportDTO.BuyerId = "";

                }


                string strPath = Path.Combine(Server.MapPath("~/Reports/rptShipmentInformation.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                DataSet ds = new DataSet();

                ds = (objReportBLL.shipmentInformation(objReportDTO));
                rd.SetDataSource(ds);
                rd.SetDatabaseLogon("erp", "erp");
                CrystalReportViewer1.ReportSource = rd;
                CrystalReportViewer1.DataBind();




                ReportFormatMaster();




            }



            if (rdoProductionReport.Checked == true)
            {

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();


                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;

                objReportDTO.FromDate = dtpFromDate.Text;
                objReportDTO.ToDate = dtoToDate.Text;
                objReportDTO.PONo = txtPONo.Text;

                if (ddlBuyerId.SelectedValue.ToString() != " ")
                {

                    objReportDTO.BuyerId = ddlBuyerId.SelectedValue.ToString();

                }
                else
                {
                    objReportDTO.BuyerId = "";

                }


                string strPath = Path.Combine(Server.MapPath("~/Reports/rptDailyProduction.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                DataSet ds = new DataSet();

                ds = (objReportBLL.productionReport(objReportDTO));
                rd.SetDataSource(ds);
                rd.SetDatabaseLogon("erp", "erp");
                CrystalReportViewer1.ReportSource = rd;
                CrystalReportViewer1.DataBind();




                ReportFormatMaster();
               



            }


            if (rdoProductionReportSummery.Checked == true)
            {

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();


                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;

                objReportDTO.FromDate = dtpFromDate.Text;
                objReportDTO.ToDate = dtoToDate.Text;
                objReportDTO.PONo = txtPONo.Text;

                if (ddlBuyerId.SelectedValue.ToString() != " ")
                {

                    objReportDTO.BuyerId = ddlBuyerId.SelectedValue.ToString();

                }
                else
                {
                    objReportDTO.BuyerId = "";

                }


                string strPath = Path.Combine(Server.MapPath("~/Reports/rptProductionReportSummery.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                DataSet ds = new DataSet();

                ds = (objReportBLL.productionReportSummery(objReportDTO));
                rd.SetDataSource(ds);
                rd.SetDatabaseLogon("erp", "erp");
                CrystalReportViewer1.ReportSource = rd;
                CrystalReportViewer1.DataBind();




                ReportFormatMaster();

            }


            if (rdoProductionReportByBuyer.Checked == true)
            {

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();


                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;

                objReportDTO.FromDate = dtpFromDate.Text;
                objReportDTO.ToDate = dtoToDate.Text;
                objReportDTO.PONo = txtPONo.Text;

                if (ddlBuyerId.SelectedValue.ToString() != " ")
                {

                    objReportDTO.BuyerId = ddlBuyerId.SelectedValue.ToString();

                }
                else
                {
                    objReportDTO.BuyerId = "";

                }


                string strPath = Path.Combine(Server.MapPath("~/Reports/rptProductionReportByBuyer.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                DataSet ds = new DataSet();

                ds = (objReportBLL.productionReportByBuyer(objReportDTO));
                rd.SetDataSource(ds);
                rd.SetDatabaseLogon("erp", "erp");
                CrystalReportViewer1.ReportSource = rd;
                CrystalReportViewer1.DataBind();




                ReportFormatMaster();

            }


            if (rdoDailyProductionReportSummery.Checked == true)
            {

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();


                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;

                objReportDTO.FromDate = dtpFromDate.Text;
                objReportDTO.ToDate = dtoToDate.Text;
                objReportDTO.PONo = txtPONo.Text;

                if (ddlBuyerId.SelectedValue.ToString() != " ")
                {

                    objReportDTO.BuyerId = ddlBuyerId.SelectedValue.ToString();

                }
                else
                {
                    objReportDTO.BuyerId = "";

                }


                string strPath = Path.Combine(Server.MapPath("~/Reports/rptDailyProductionSummery.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                DataSet ds = new DataSet();

                ds = (objReportBLL.dailyProductionReportSummery(objReportDTO));
                rd.SetDataSource(ds);
                rd.SetDatabaseLogon("erp", "erp");
                CrystalReportViewer1.ReportSource = rd;
                CrystalReportViewer1.DataBind();




                ReportFormatMaster();

            }


            if (rdoPurchaseOrder.Checked == true)
            {

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();


                processContactSheet();


                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;

                objReportDTO.FromDate = dtpFromDate.Text;
                objReportDTO.ToDate = dtoToDate.Text;
                objReportDTO.PONo = txtPONo.Text;




                string strPath = Path.Combine(Server.MapPath("~/Reports/rptPurchaseOrder.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                DataSet ds = new DataSet();

                ds = (objReportBLL.purchaseOrder(objReportDTO));
                rd.SetDataSource(ds);
                rd.SetDatabaseLogon("erp", "erp");
                CrystalReportViewer1.ReportSource = rd;
                CrystalReportViewer1.DataBind();




                ReportFormatMaster();

            }


        }

            #endregion








        #region "User Defined Function"

        public void processContactSheet()
        {


            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();


            objReportDTO.FromDate = dtpFromDate.Text;
            objReportDTO.ToDate = dtoToDate.Text;

            objReportDTO.UpdateBy = strEmployeeId;
            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;





            string strMsg = objReportBLL.processContactSheet(objReportDTO);




        }




        #endregion
    }
}
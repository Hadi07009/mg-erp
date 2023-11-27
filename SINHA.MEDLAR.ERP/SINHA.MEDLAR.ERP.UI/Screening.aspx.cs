using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using SINHA.MEDLAR.ERP.BLL;
using SINHA.MEDLAR.ERP.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class Screening : System.Web.UI.Page
    {
        
        string strHeadOfficeId = "";
        string strBranchOfficeId = "";
        
        ReportDocument rd = new ReportDocument();

        string strDefaultName = "Report";
        CrystalDecisions.Shared.ExportFormatType formatType = ExportFormatType.NoFormat;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtPasscode_TextChanged(object sender, EventArgs e)
        {
            hfPassCode.Value = string.Empty;

            if (txtPasscode.Text == "1")
            {                
                txtPulse.Focus();
                lblPulse.Visible = true;
                txtPulse.Visible = true;
                btnRoadMap.Visible = true;
                
                hfPassCode.Value = txtPasscode.Text;
                txtPasscode.Text = string.Empty;
                lblPasscode.Visible = false;
                txtPasscode.Visible = false;
            }

            if (txtPasscode.Text == "2")
            {
                txtPulse.Focus();
                lblPulse.Visible = true;
                txtPulse.Visible = true;
                btnRoadMap.Visible = true;
                
                hfPassCode.Value = txtPasscode.Text;
                txtPasscode.Text = string.Empty;
                lblPasscode.Visible = false;
                txtPasscode.Visible = false;
            }
        }

        protected void btnRoadMap_Click(object sender, EventArgs e)
        {
            

            try
            {                
                int counter = 0;

                if (txtPulse.Text != string.Empty)
                {
                    try
                    {
                        int pulse = Convert.ToInt32(txtPulse.Text);

                        for (int p = 2000; p <= 2500; p++)
                        {
                            if (p == pulse)
                                counter = counter + 1;
                        }
                    }
                    catch
                    {
                    }

                    if (counter == 0)
                    {
                        lblMessage.Text = "What is pulse actually.";
                        return;
                    }
                    else
                    {
                        lblMessage.Text = "";
                    }
                }
                if (hfPassCode.Value == "1" || hfPassCode.Value == "2")
                {
                    GetRoadMap();
                }
                else
                {
                    lblMessage.Text = "Passcode.";
                    return;
                }
                
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

        public void GetRoadMap()
        {
            try
            {
                string strDefaultName = "Report";
                ExportFormatType formatType = ExportFormatType.NoFormat;

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.Year = txtPulse.Text;
                objReportDTO.BranchOfficeId = "104";                                          
                                                
                string strPath = Path.Combine(Server.MapPath("~/Reports/RptRoadMap.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetRoadMap(objReportDTO));
                
                rd.SetDatabaseLogon("erp", "erp");
                CrystalReportViewer1.ReportSource = rd;
                CrystalReportViewer1.DataBind();

                reportMaster("Screening");

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

        public void reportMaster(string fileName)
        {
            if (hfPassCode.Value == "1")
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
                rd.FileName = fileName;
                rd.Close();
                rd.Dispose();
            }

            if(hfPassCode.Value == "2")
            {
               
               rd.ExportToHttpResponse (CrystalDecisions.Shared.ExportFormatType.ExcelRecord, Response, true, fileName);
               Response.End();
               CrystalReportViewer1.RefreshReport();
            }
        }

       
        //protected void btnProgress_Click(object sender, EventArgs e)
        //{
        //    if (txtPulse.Text == string.Empty)
        //    {
        //        lblMessage.Text = "What is pulse.";
        //        return;
        //    }
        //    else
        //    {
        //        lblMessage.Text = "";
        //    }

        //    int counter = 0;
        //    try
        //    {
        //        int pulse = Convert.ToInt32(txtPulse.Text);

        //        for(int p = 2000; p <= 2500; p++ )
        //        {
        //            if(p == pulse)
        //            counter = counter + 1;
        //        }
        //    }
        //    catch
        //    {
        //    }

        //    if(counter == 0)
        //    {
        //        lblMessage.Text = "What is pulse actually.";
        //        return;
        //    }
        //    else
        //    {
        //        lblMessage.Text = "";
        //    }
        //}
    }
}
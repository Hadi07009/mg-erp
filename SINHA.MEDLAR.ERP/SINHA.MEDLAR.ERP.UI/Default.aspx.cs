using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;



namespace SINHA.MEDLAR.HR.UI
{
    public partial class Default : System.Web.UI.Page
    {
        string strEmployeeId = "";
        string strSectionId = "";
        string strDesignationId = "";
        string strUnitId = "";
        string strCatagoryId;
        string strHeadOfficeId = "";
        string strBranchOfficeId = "";
        string strLoginDay = "";
        string strLoginMonth = "";
        string strLoginDate = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Clear();

            //int height = 30;
            //int width = 100;

            //Bitmap bmp = new Bitmap(width, height);
            //RectangleF rectf = new RectangleF(10, 5, 0, 0);
            //Graphics g = Graphics.FromImage(bmp);
            //g.Clear(Color.White);
            //g.SmoothingMode = SmoothingMode.AntiAlias;
            //g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            //g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            //g.DrawString(Session["captcha"].ToString(), new Font("Thaoma", 12, FontStyle.Italic), Brushes.Green, rectf);
            //g.DrawRectangle(new Pen(Color.Red), 1, 1, width - 2, height - 2);
            //g.Flush();
            //Response.ContentType = "image/jpeg";
            //bmp.Save(Response.OutputStream, ImageFormat.Jpeg);

            //g.Dispose();
            //bmp.Dispose();
            loadSession();
           
        }

        private void Page_PreInit(object sender, EventArgs e)
        {
            loadSession();
            checkReport();

        } 


        public void checkReport()
        {

            if (strHeadOfficeId == "331" && (strDesignationId == "1" || strDesignationId == "266") && strBranchOfficeId == "104")
            {
                Response.Redirect("ReportHeadOffice.aspx", false);

            }
            if (strHeadOfficeId == "331" && strDesignationId == "164" && strBranchOfficeId == "104")
            {
                Response.Redirect("ReportOthers.aspx", false);

            }

            if (strHeadOfficeId == "331" && strBranchOfficeId == "102")
            {
                Response.Redirect("ReportWorker.aspx", false);

            }
            if (strHeadOfficeId == "331" && strBranchOfficeId == "103" && strDesignationId == "1")
            {
                Response.Redirect("ReportWorker.aspx", false);

            }
            if (strHeadOfficeId == "331" && strBranchOfficeId == "103" && strDesignationId != "1")
            {

                Response.Redirect("ReportOthers.aspx", false);
            }

            if (strHeadOfficeId == "331" && strBranchOfficeId == "101")
            {
                Response.Redirect("ReportWorker.aspx", false);

            }


            if (strHeadOfficeId == "441")
            {
                Response.Redirect("ReportPower.aspx", false);

            }

            if (strHeadOfficeId == "441" && strDesignationId == "1")
            {
                Response.Redirect("ReportHeadOfficePower.aspx", false);

            }

        }

        public void loadSession()
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
     

    }
}
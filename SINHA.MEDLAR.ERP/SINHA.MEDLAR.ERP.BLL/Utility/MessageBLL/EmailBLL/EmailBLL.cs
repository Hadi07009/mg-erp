using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using SINHA.MEDLAR.ERP.COMMON.Utility.MessageService.EmailService;
using System.Net.Mail;
using System.Net;
using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.BLL.Utility.NetworkBLL;

namespace SINHA.MEDLAR.ERP.BLL.Utility.MessageBLL.EmailBLL
{
    public class EmailBLL
    {
        //public string SendHearingNotification(string to_email_address, string to_display_nm, string subject, string actionName, string caseNo, string defendant, string complainant, string hearingDate, string caseStatus)
        //{
        //    string success = string.Empty;
        //    string to_user_id = string.Empty;
        //    string to_email_id = string.Empty;
        //    string emailfooter = string.Empty;
        //    string password = string.Empty;

        //    //try
        //    //{

        //        //For Email
        //        string ToDisplayName = string.Empty;
        //        string ToAdr = string.Empty;
        //        string FromDisplayName = string.Empty;
        //        string FromAdr = string.Empty;
        //        string CcDisplayName = string.Empty;
        //        string CcAdr = string.Empty;
        //        string BccAdr = string.Empty;
        //        //string Subject = string.Empty;
        //        string BodyText = string.Empty;
        //        string file_path = string.Empty;

        //        //string EmailFooterFileName = "EMAIL_FOOTER_ACTIVATION.txt";
        //        //string EmailBODYFileName = "EMAIL_BODY_USER_ACTIVATION.txt";

        //        StringBuilder TextMessage = new StringBuilder();

        //        string tmpFileName = string.Empty;
        //        string random = string.Empty;
        //        #region email sending
        //        // if EmailSendiing is flag is ON
        //        //if (string.Compare(ConfigurationManager.AppSettings["isEmailSend"].ToString(), "1") == 0)
        //        //{


        //        ToDisplayName = to_display_nm;
        //        ToAdr = to_email_address;
        //        if (string.IsNullOrEmpty(ToAdr))
        //        {
        //            success = "0";
        //            return success;
        //        }

        //        FromDisplayName = string.Empty;
        //        FromAdr = ConfigurationManager.AppSettings["MailSenderAddress"].ToString();
        //        CcDisplayName = string.Empty;
        //        CcAdr = string.Empty;
        //        BccAdr = string.Empty;
        //        //Subject = "IE Credintials";

        //        BodyText = string.Empty;

        //        //reading From File
        //        //file_path = LS_IBU_USER_DOC + @"\" + EmailBODYFileName;
        //        //BodyText = File.ReadAllText(file_path);

        //        BodyText = "<html><body> Dear Sir, <br/>" + actionName + "<br/>";

        //        TextMessage.AppendLine(BodyText);

        //        BodyText = string.Empty;
        //        to_user_id = string.Empty;
        //        to_email_id = string.Empty;
        //        //to_user_id = user_id;
        //        to_email_id = ToAdr;

                
        //        //string plainPassword = Sinha.Core.Utility.Security.Credintial.GeneratePassword(6);

        //        TextMessage.AppendLine("----------------------------------------------------------------------------------------------" + "<br/>");
        //        TextMessage.AppendLine("Case Number  :  " + caseNo + "<br/>");
        //        TextMessage.AppendLine("Defendant    :  " + defendant + "<br/>");
        //        TextMessage.AppendLine("Complainant  :  " + complainant + "<br/>");
        //        TextMessage.AppendLine("Hearing Date :  " + hearingDate + "<br/>");
        //        TextMessage.AppendLine("Status       :  " + caseStatus + "<br/>");
        //        TextMessage.AppendLine("----------------------------------------------------------------------------------------------" + "<br/>");


        //        //file_path = LS_IBU_USER_DOC + @"\" + EmailFooterFileName;
        //        //emailfooter = File.ReadAllText(file_path);

        //        emailfooter = "<br>For any query </br>Please e-mail to: <a href=\"erp.medlar@sinha-medlar.com\">erp.medlar@sinha-medlar.com</a></body></html>";

        //        TextMessage.AppendLine(emailfooter);
        //        BodyText = TextMessage.ToString();
        //        Email.SendBasicMail
        //        (
        //           ToDisplayName
        //           , ToAdr
        //           , FromDisplayName
        //           , FromAdr
        //           , CcDisplayName
        //           , CcAdr
        //           , BccAdr
        //           , subject
        //           , BodyText
        //           , string.Empty);
        //        #endregion
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //}
        //    return success;
        //}

        //public string SendMail(string toAddress, string displayName, string subject, string actionName, string caseNo, string defendant, string complainant, string hearingDate, string caseStatus)
        //{
        //    string HostAddress = ConfigurationManager.AppSettings["MailServerIP"];
        //    string HostPort = ConfigurationManager.AppSettings["MailServerPort"];
        //    string MailSenderAddress = ConfigurationManager.AppSettings["MailSenderAddress"];
        //    string HostPassword = ConfigurationManager.AppSettings["MailSenderPassword"];

        //    StringBuilder TextMessage = new StringBuilder();
        //    string BodyText = string.Empty;

        //    BodyText = "<html><body> Dear Sir, <br/>" + actionName + "<br/>";
        //    TextMessage.AppendLine(BodyText);
        //    BodyText = string.Empty;
            
        //    TextMessage.AppendLine("----------------------------------------------------------------------------------------------" + "<br/>");
        //    TextMessage.AppendLine("Case Number  :  " + caseNo + "<br/>");
        //    TextMessage.AppendLine("Defendant    :  " + defendant + "<br/>");
        //    TextMessage.AppendLine("Complainant  :  " + complainant + "<br/>");
        //    TextMessage.AppendLine("Hearing Date :  " + hearingDate + "<br/>");
        //    TextMessage.AppendLine("Status       :  " + caseStatus + "<br/>");
        //    TextMessage.AppendLine("----------------------------------------------------------------------------------------------" + "<br/>");

        //    TextMessage.AppendLine("" + "<br/>");
        //    TextMessage.AppendLine("Reminder is generated in 30 munites interval from  09:00 to 18:00  from live server for testing.");
        //    TextMessage.AppendLine("" + "<br/>");

        //    string emailfooter = "<br>For any query </br>Please e-mail to: <a href=\"erp.medlar@sinha-medlar.com\">erp.medlar@sinha-medlar.com</a></body></html>";

        //    TextMessage.AppendLine(emailfooter);
        //    BodyText = TextMessage.ToString();
            
        //    MailMessage mailMessgae = new MailMessage();
        //    mailMessgae.From = new MailAddress(MailSenderAddress);
        //    mailMessgae.Subject = "Hearing Reminder";
        //    mailMessgae.IsBodyHtml = true;
        //    mailMessgae.Body = BodyText;

        //    string[] multi = toAddress.Split(',');

        //    foreach (var address in multi)
        //    {
        //        mailMessgae.To.Add(address);
        //    }

        //    SmtpClient smtp = new SmtpClient();
        //    smtp.Host = HostAddress;
        //    smtp.EnableSsl = false;

        //    NetworkCredential credential = new NetworkCredential();
            
        //    credential.UserName = mailMessgae.From.Address;
        //    credential.Password = HostPassword;
        //    smtp.UseDefaultCredentials = false;
        //    smtp.Credentials = credential;
        //    smtp.Port = Convert.ToInt32(HostPort);
        //    smtp.Send(mailMessgae);

        //    return "";
        //}
                
        public string SendCaseReminder(string toAddress, string ccAddress, string fromDisplayName, string subject, string actionName, List<CaseInfoDTO> objCaseList)
        {
            string result = "Mail Sent Successfully.";

            try {

                string iPAddress = Network.GetIpAddress();

                string WebServerIP = ConfigurationManager.AppSettings["WebServerIP"];
                string HostAddress = ConfigurationManager.AppSettings["MailServerIP"];
                string HostPort = ConfigurationManager.AppSettings["MailServerPort"];
                string MailSenderAddress = ConfigurationManager.AppSettings["MailSenderAddress"];
                string HostPassword = ConfigurationManager.AppSettings["MailSenderPassword"];

                if(iPAddress != WebServerIP)
                {
                    result = "Application has not been deployed in prescribed server...";
                    return result;
                }


                StringBuilder TextMessage = new StringBuilder();

                string Css1 =
                            "table" +
                            "{" +
                                "font-family: arial, sans-serif;" +
                                "border-collapse: collapse;" +
                                "width: 100 %;" +
                            "}";
                string Css2 = "td, th" +
                              "{" +
                                "border: 1px solid #dddddd;" +
                                "text-align: left;" +
                                "padding: 8px;" +
                              "}";

                string Css3 = "th" +
                              "{" +
                              "background: Aqua;" +
                              "}";
                string fontCss1 = ".f-13-bold" +
                              "{" +
                              "font-weight:bold;" +
                              "font-size: 13px;" +
                              "}";

                string fontCss2 = ".f-15-bold-ita-u" +
                                "{" +
                                "font-weight:bold;" +
                                "font-style: italic;" +
                                "text-decoration: underline;" +
                                "font-size: 15px;" +
                                "}";

                string Css = "<style>" + Css1 + Css2 + Css3 + fontCss1 + fontCss2 + "</style>";
                string HeaderText = "<head>" + Css + "</head>";

                //Start

                string thead =
                              "<thead><tr>" +
                              "<th> Serial No</th>" +
                              "<th> Date </th>" +
                              "<th> Activity Type </th>" +
                              "<th> Case No </th>" +
                              "<th> Defendant </th>" +
                              "<th> Complainant </th>" +
                              
                              "<th> Case State </th>" +
                              "<th> Remarks </th>" +
                              "</tr></thead>";
                //End

                string tbody = string.Empty;
                string tbodyRow = string.Empty;
                string td = string.Empty;
                foreach (var caseInfo in objCaseList)
                {
                    td = td + "<td>" + caseInfo.SerialNo + "</td>";
                    td = td + "<td>" + caseInfo.HistoryDate + "</td>";
                    td = td + "<td>" + caseInfo.ActivityName + "</td>";
                    td = td + "<td>" + caseInfo.CaseNo + "</td>";

                    td = td + "<td>" + caseInfo.Defendant + "</td>";
                    td = td + "<td>" + caseInfo.Complaintant + "</td>";

                    td = td + "<td>" + caseInfo.CaseStatus + "</td>";

                    td = td + "<td>" + caseInfo.Remarks + "</td>";

                    tbodyRow = tbodyRow + "<tr>" + td + "</tr>";

                    td = string.Empty;
                }

                tbody = "<tbody>" + tbodyRow + "</tbody>";

                string table = "<table>" + thead + tbody + "</table>";

                string message = string.Empty;
                               
                
                string instruction = "<h3> Following is/are the list of case/cases to attend before the court-</h3>";
                message = instruction + "<br/>";

                string body = "<body>" + message + table + "</body>";
                                              

                string html = "<html>" + HeaderText + body;
                TextMessage.AppendLine(html);
                
                string emailfooter = "<br/><br/>For any query, please e-mail to: <a href=\"hadi@sinha-medlar.com\">hadi@sinha-medlar.com</a></body></html>";
                TextMessage.AppendLine(emailfooter);


                string BodyText = string.Empty;
                BodyText = TextMessage.ToString();

                MailMessage mailMessgae = new MailMessage();
                mailMessgae.From = new MailAddress(MailSenderAddress, fromDisplayName);
                mailMessgae.Subject = subject;
                mailMessgae.IsBodyHtml = true;
                mailMessgae.Body = BodyText;

                string[] toAddressArray = toAddress.Split(';');

                foreach (var address in toAddressArray)
                {
                    mailMessgae.To.Add(address);
                }

                string[] toCcAddressArray = ccAddress.Split(';');
                foreach (var address in toCcAddressArray)
                {
                    if (address != string.Empty)
                    {
                        mailMessgae.CC.Add(address);
                    }                    
                }
                mailMessgae.Bcc.Add("erp.medlar@sinha-medlar.com");

                SmtpClient smtp = new SmtpClient();
                smtp.Host = HostAddress;
                smtp.EnableSsl = false;

                NetworkCredential credential = new NetworkCredential();

                credential.UserName = mailMessgae.From.Address;
                credential.Password = HostPassword;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = credential;
                smtp.Port = Convert.ToInt32(HostPort);
                smtp.Send(mailMessgae);
            }
            catch(Exception ex)
            {
                //result = "Unable to send mail.";
                result = ex.Message.ToString();
            }
            return result;
        }

        public string SendMailTest(string toAddress, string ccAddress, string fromDisplayName, string subject, string actionName, List<CaseInfoDTO> objCaseList)
        {
            string result = "Mail Sent Successfully.";

            try
            {

                string iPAddress = Network.GetIpAddress();

                string WebServerIP = ConfigurationManager.AppSettings["WebServerIP"];
                string HostAddress = ConfigurationManager.AppSettings["MailServerIP"];
                string HostPort = ConfigurationManager.AppSettings["MailServerPort"];
                string MailSenderAddress = ConfigurationManager.AppSettings["MailSenderAddress"];
                string HostPassword = ConfigurationManager.AppSettings["MailSenderPassword"];

                if (iPAddress != WebServerIP)
                {
                    result = "Application has not been deployed in prescribed server...";
                    return result;
                }


                StringBuilder TextMessage = new StringBuilder();

                string Css1 =
                            "table" +
                            "{" +
                                "font-family: arial, sans-serif;" +
                                "border-collapse: collapse;" +
                                "width: 100 %;" +
                            "}";
                string Css2 = "td, th" +
                              "{" +
                                "border: 1px solid #dddddd;" +
                                "text-align: left;" +
                                "padding: 8px;" +
                              "}";

                string Css3 = "th" +
                              "{" +
                              "background: yellow;" +
                              "}";
                string fontCss1 = ".f-13-bold" +
                              "{" +
                              "font-weight:bold;" +
                              "font-size: 13px;" +
                              "}";

                string fontCss2 = ".f-15-bold-ita-u" +
                                "{" +
                                "font-weight:bold;" +
                                "font-style: italic;" +
                                "text-decoration: underline;" +
                                "font-size: 15px;" +
                                "}";

                string Css = "<style>" + Css1 + Css2 + Css3 + fontCss1 + fontCss2 + "</style>";
                string HeaderText = "<head>" + Css + "</head>";

                //Start

                string thead =
                              "<thead><tr>" +
                              "<th> Serial No</th>" +
                              "<th> Hearing Date </th>" +
                              "<th> Case No </th>" +
                              "<th> Defendant </th>" +
                              "<th> Complainant </th>" +
                              "<th> Case State </th>" +
                              "<th> Remarks </th>" +
                              "</tr></thead>";
                //End

                string tbody = string.Empty;
                string tbodyRow = string.Empty;
                string td = string.Empty;
                foreach (var caseInfo in objCaseList)
                {
                    td = td + "<td>" + caseInfo.SerialNo + "</td>";
                    td = td + "<td>" + caseInfo.HearingDate + "</td>";
                    td = td + "<td>" + caseInfo.CaseNo + "</td>";

                    td = td + "<td>" + caseInfo.Defendant + "</td>";
                    td = td + "<td>" + caseInfo.Complaintant + "</td>";
                    td = td + "<td>" + caseInfo.CaseStatus + "</td>";

                    td = td + "<td>" + caseInfo.Remarks + "</td>";

                    tbodyRow = tbodyRow + "<tr>" + td + "</tr>";

                    td = string.Empty;
                }

                tbody = "<tbody>" + tbodyRow + "</tbody>";

                string table = "<table>" + thead + tbody + "</table>";

                string message = string.Empty;

                string note = "<h3> System generated reminder on upcomming hearing dates...</h3>";
                string generationDate = "Generation date: " + String.Format("{0:f}", DateTime.Now) + "<br/>";
                string salutation = "Dear Sir, <br/>";                
                message = note + generationDate + salutation + actionName + "-<br/><br/>";

                string body = "<body>" + message + table + "</body>";
                                
                
                string html = "<html>" + HeaderText + body;
                TextMessage.AppendLine(html);
                string emailfooter = "<br/><br/>For any query, please e-mail to: <a href=\"hadi@sinha-medlar.com\">hadi@sinha-medlar.com</a></body></html>";
                TextMessage.AppendLine(emailfooter);


                string BodyText = string.Empty;
                BodyText = TextMessage.ToString();

                MailMessage mailMessgae = new MailMessage();
                mailMessgae.From = new MailAddress(MailSenderAddress, fromDisplayName);
                mailMessgae.Subject = "Hearing Reminder";
                mailMessgae.IsBodyHtml = true;
                mailMessgae.Body = BodyText;

                string[] toAddressArray = toAddress.Split(';');

                foreach (var address in toAddressArray)
                {
                    mailMessgae.To.Add(address);
                }

                string[] toCcAddressArray = ccAddress.Split(';');
                foreach (var address in toCcAddressArray)
                {
                    mailMessgae.CC.Add(address);
                }
                mailMessgae.Bcc.Add("erp.medlar@sinha-medlar.com");

                SmtpClient smtp = new SmtpClient();
                smtp.Host = HostAddress;
                smtp.EnableSsl = false;

                NetworkCredential credential = new NetworkCredential();

                credential.UserName = mailMessgae.From.Address;
                credential.Password = HostPassword;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = credential;
                smtp.Port = Convert.ToInt32(HostPort);
                smtp.Send(mailMessgae);
            }
            catch (Exception ex)
            {
                result = ex.Message.ToString();
            }
            return result;
        }


        //public string SendMailTest(string toAddress, string ccAddress, string fromDisplayName, string subject, string actionName, List<CaseInfoDTO> objCaseList)
        //{
        //    string result = "Mail Sent Successfully.";

        //    try
        //    {

        //        string iPAddress = Network.GetIpAddress();

        //        string WebServerIP = ConfigurationManager.AppSettings["WebServerIP"];
        //        string HostAddress = ConfigurationManager.AppSettings["MailServerIP"];
        //        string HostPort = ConfigurationManager.AppSettings["MailServerPort"];
        //        string MailSenderAddress = ConfigurationManager.AppSettings["MailSenderAddress"];
        //        string HostPassword = ConfigurationManager.AppSettings["MailSenderPassword"];

        //        if (iPAddress != WebServerIP)
        //        {
        //            result = "Application has not been deployed in prescribed server...";
        //            return result;
        //        }


        //        StringBuilder TextMessage = new StringBuilder();

        //        string Css1 =
        //                    "table" +
        //                    "{" +
        //                        "font-family: arial, sans-serif;" +
        //                        "border-collapse: collapse;" +
        //                        "width: 100 %;" +
        //                    "}";
        //        string Css2 = "td, th" +
        //                      "{" +
        //                        "border: 1px solid #dddddd;" +
        //                        "text-align: left;" +
        //                        "padding: 8px;" +
        //                      "}";

        //        string Css3 = "th" +
        //                      "{" +
        //                      "background: yellow;" +
        //                      "}";
        //        string fontCss1 = ".f-13-bold" +
        //                      "{" +
        //                      "font-weight:bold;" +
        //                      "font-size: 13px;" +
        //                      "}";

        //        string fontCss2 = ".f-15-bold-ita-u" +
        //                        "{" +
        //                        "font-weight:bold;" +
        //                        "font-style: italic;" +
        //                        "text-decoration: underline;" +
        //                        "font-size: 15px;" +
        //                        "}";

        //        string Css = "<style>" + Css1 + Css2 + Css3 + fontCss1 + fontCss2 + "</style>";
        //        string HeaderText = "<head>" + Css + "</head>";

        //        Start

        //        string thead =
        //                      "<thead><tr>" +
        //                      "<th> Serial No</th>" +
        //                      "<th> Hearing Date </th>" +
        //                      "<th> Case No </th>" +
        //                      "<th> Defendant </th>" +
        //                      "<th> Complainant </th>" +
        //                      "<th> Case State </th>" +
        //                      "<th> Remarks </th>" +
        //                      "</tr></thead>";
        //        End

        //        string tbody = string.Empty;
        //        string tbodyRow = string.Empty;
        //        string td = string.Empty;
        //        foreach (var caseInfo in objCaseList)
        //        {
        //            td = td + "<td>" + caseInfo.SerialNo + "</td>";
        //            td = td + "<td>" + caseInfo.HearingDate + "</td>";
        //            td = td + "<td>" + caseInfo.CaseNo + "</td>";

        //            td = td + "<td>" + caseInfo.Defendant + "</td>";
        //            td = td + "<td>" + caseInfo.Complaintant + "</td>";
        //            td = td + "<td>" + caseInfo.CaseStatus + "</td>";

        //            td = td + "<td>" + caseInfo.Remarks + "</td>";

        //            tbodyRow = tbodyRow + "<tr>" + td + "</tr>";

        //            td = string.Empty;
        //        }

        //        tbody = "<tbody>" + tbodyRow + "</tbody>";

        //        string table = "<table>" + thead + tbody + "</table>";

        //        string message = string.Empty;

        //        string note = "<h3> System generated reminder on upcomming hearing dates...</h3>";
        //        string generationDate = "Generation date: " + String.Format("{0:f}", DateTime.Now) + "<br/>";
        //        string salutation = "Dear Sir, <br/>";

        //        message = actionName + "-<br/><br/>";
        //        message = "<h1> System generated Reminder about upcomming Hearing dates...</h1>Dear Sir, <br/> You are requested to follow the bellow reminder-<br/><br/>";
        //        message = "<h1> System generated Reminder about upcomming Hearing dates...</h1>Dear Sir, <br/> You are requested to follow the bellow reminder-<br/><br/>";
        //        string genDate = "<h5> System generated Reminder about upcomming Hearing dates...</h5>";

        //        message = note + generationDate + salutation + actionName + "-<br/><br/>";

        //        string body = "<body>" + message + table + "</body>";

        //        string html = "<!DOCTYPE html><html>" + HeaderText + body + "</html>";
        //        TextMessage.AppendLine(html);
        //        string BodyText = string.Empty;

        //        old
        //        string BodyText = string.Empty;
        //        BodyText = "<html><body> Dear Sir, <br/>" + actionName + "<br/>";
        //        TextMessage.AppendLine(BodyText);
        //        BodyText = string.Empty;


        //        BodyText = TextMessage.ToString();


        //        string html = "<html>" + HeaderText + body;
        //        TextMessage.AppendLine(html);
        //        TextMessage.AppendLine("" + "<br/>");
        //        TextMessage.AppendLine("Reminder is Generated at 09.00AM, 03.00PM and 06:00PM each day mentioning next 3 hearing dates from live server for testing.");
        //        TextMessage.AppendLine("" + "<br/>");
        //        string emailfooter = "<br/><br/>For any query, please e-mail to: <a href=\"asadur.rahman@sinha-medlar.com\">asadur.rahman@sinha-medlar.com</a></body></html>";
        //        TextMessage.AppendLine(emailfooter);


        //        string BodyText = string.Empty;
        //        BodyText = TextMessage.ToString();

        //        MailMessage mailMessgae = new MailMessage();
        //        mailMessgae.From = new MailAddress(MailSenderAddress, fromDisplayName);
        //        mailMessgae.Subject = "Hearing Reminder";
        //        mailMessgae.IsBodyHtml = true;
        //        mailMessgae.Body = BodyText;

        //        string[] toAddressArray = toAddress.Split(';');

        //        foreach (var address in toAddressArray)
        //        {
        //            mailMessgae.To.Add(address);
        //        }

        //        string[] toCcAddressArray = ccAddress.Split(';');
        //        foreach (var address in toCcAddressArray)
        //        {
        //            mailMessgae.CC.Add(address);
        //        }
        //        mailMessgae.Bcc.Add("erp.medlar@sinha-medlar.com");

        //        SmtpClient smtp = new SmtpClient();
        //        smtp.Host = HostAddress;
        //        smtp.EnableSsl = false;

        //        NetworkCredential credential = new NetworkCredential();

        //        credential.UserName = mailMessgae.From.Address;
        //        credential.Password = HostPassword;
        //        smtp.UseDefaultCredentials = false;
        //        smtp.Credentials = credential;
        //        smtp.Port = Convert.ToInt32(HostPort);
        //        smtp.Send(mailMessgae);
        //    }
        //    catch (Exception ex)
        //    {
        //        result = "Unable to send mail.";
        //        result = ex.Message.ToString();
        //    }
        //    return result;
        //}

        #region Attendance Report
        public string SendAttendanceSummary(string toAddress, string ccAddress, string fromDisplayName, string subject, string actionName, AttendanceDashboardDTO objDashboard, string AttachmentFileName)
        {
            string result = "Mail Sent Successfully.";
            string[] _attachFile = new string[100];

            try
            {

                string iPAddress = Network.GetIpAddress();

                string WebServerIP = ConfigurationManager.AppSettings["WebServerIP"];
                string HostAddress = ConfigurationManager.AppSettings["MailServerIP"];
                string HostPort = ConfigurationManager.AppSettings["MailServerPort"];
                string MailSenderAddress = ConfigurationManager.AppSettings["MailSenderAddress"];
                string HostPassword = ConfigurationManager.AppSettings["MailSenderPassword"];

                if (iPAddress != WebServerIP)
                {
                    result = "Application has not been deployed in prescribed server...";
                    return result;
                }


                StringBuilder TextMessage = new StringBuilder();

                string Css1 =
                            "table" +
                            "{" +
                                "font-family: arial, sans-serif;" +
                                "border-collapse: collapse;" +
                                "width: 100 %;" +
                            "}";

                string Css2 = "td, th" +
                              "{" +
                                "border: 1px solid #dddddd;" +
                                "text-align: left;" +
                                "padding: 8px;" +
                              "}";

                string Css3 = "th" +
                              "{" +
                              "background: Aqua;" +
                              "}";
                string fontCss1 = ".f-13-bold" +
                              "{" +
                              "font-weight:bold;" +
                              "font-size: 13px;" +
                              "}";

                string fontCss2 = ".f-15-bold-ita-u" +
                                "{" +
                                "font-weight:bold;" +
                                "font-style: italic;" +
                                "text-decoration: underline;" +
                                "font-size: 15px;" +
                                "}";

                string Css = "<style>" + Css1 + Css2 + Css3 + fontCss1 + fontCss2 + "</style>";
                string HeaderText = "<head>" + Css + "</head>";

                //Start

                string thead =
                              "<thead><tr>" +
                              "<th> Present(all) </th>" +
                              "<th> Day Off(ho) </th>" +
                              "<th> Night Duty(fsw) </th>" +
                              "<th> Night Duty(ho) </th>" +
                              "<th> Out Duty(fsw) </th>" +
                              "<th> Out Duty(ho)</th>" +
                              "<th> Leave(fsw) </th>" +
                              "<th> Leave(ho) </th>" +
                                                                                          
                              "<th> Physical Present(all) </th>" +
                              "<th> Punch(all) </th>" +
                              "<th> No Punch (fsw) </th>" +
                              "<th> No Punch (ho) </th>" +
                              "<th> Unrecognized(all) </th>" +
                              "<th> No Punch(all) </th>" +
                              "<th> Accuracy(%) </th>" +
                              "</tr></thead>";
                
                string tbody = string.Empty;
                string tbodyRow = string.Empty;
                string td = string.Empty;
                                
                td = td + "<td>" + objDashboard.Present + "</td>";
                td = td + "<td>" + objDashboard.DayOffOther + "</td>";
                td = td + "<td>" + objDashboard.NightDuty + "</td>";
                td = td + "<td>" + objDashboard.NightDutyOther + "</td>";
                td = td + "<td>" + objDashboard.OutDuty + "</td>";
                td = td + "<td>" + objDashboard.OutDutyOther + "</td>";
                td = td + "<td>" + objDashboard.Leave + "</td>";
                td = td + "<td>" + objDashboard.LeaveOther + "</td>";
                                
                td = td + "<td>" + objDashboard.PhysicalPresent + "</td>";
                td = td + "<td>" + objDashboard.PunchOverall + "</td>";

                td = td + "<td>" + objDashboard.NoPunch + "</td>";
                td = td + "<td>" + objDashboard.NoPunchOther + "</td>";
                                
                td = td + "<td>" + objDashboard.UnrecognizedToMachine + "</td>";
                td = td + "<td>" + objDashboard.NoPunchOverall + "</td>";
                td = td + "<td>" + objDashboard.Accuracy + "</td>";

                tbodyRow = tbodyRow + "<tr>" + td + "</tr>";

                td = string.Empty;
                
                tbody = "<tbody>" + tbodyRow + "</tbody>";

                string table = "<table>" + thead + tbody + "</table>";

                string message = string.Empty;

                //old
                //string salutation = "<h3>Dear Sir</h3>";                
                //string instruction = "<h3>" + actionName + "</h3>";
                //string ActiveOther = "<h3> Active HO Staff: " + objDashboard.ActiveOther + " </h3>";
                //string Active = "<h3> Active Factory Staff and Worker: " + objDashboard.Active + " </h3>";

                //new
                string salutation = "<span><b>Dear Sir</b><br/>";
                string instruction = actionName + "<br/><br/>";

                string ActiveOther = "HO Staff (Active): " + objDashboard.ActiveOther + "<br/>";
                string ResignOther = "HO Staff (Resign): " + objDashboard.ResignOther + "<br/>";
                
                string Active = "Factory Staff and Worker (Active): " + objDashboard.Active + "<br/></span>";
                string Resign = "Factory Staff and Worker (Resign): " + objDashboard.Resign + "<br/><br/></span>";

                string AboutAttachment = "<p></br></br> Please find the attached file that consists of those  personnel who did not punch, the reason of not punching is one of the following- </br></p>";

                string Reasion1 = "<p><ol> <li>Leave</li>";
                string Reasion2 = "<li>Absent</li>";
                //string Reasion3 = "<li>Resign Pipeline</li>";
                string Reasion4 = "<li>Physically Present but  don’t punch.</li></ol></p>";

                //string Regards1 = "<h3>Kind Regards </h3>";
                //string Regards2 = "<p><b>Md.Asadur Rahman </b> </p>";
                //string Regards3 = "<p style='padding-top:30px;'>Senior Software Engineer </p>";                      

                message = salutation + 
                          instruction + 
                          ActiveOther +
                          ResignOther +
                          Active +
                          Resign +
                          table +
                          AboutAttachment +
                          Reasion1 +
                          Reasion2 +
                          //Reasion3 +
                          Reasion4;

                        //+ Regards1 
                        //+ Regards2 
                        //+ Regards3 +
                        //"<br/>"


                string body = "<body>" + message + "</body>";
                
                string html = "<html>" + HeaderText + body;
                TextMessage.AppendLine(html);

                string emailfooter = "<br/><br/>For any query, please e-mail to: <a href=\"hadi@sinha-medlar.com\">hadi@sinha-medlar.com</a>";
                TextMessage.AppendLine(emailfooter);

                TextMessage.AppendLine("</body></html>");

                string BodyText = string.Empty;
                BodyText = TextMessage.ToString();

                MailMessage mailMessgae = new MailMessage();
                mailMessgae.From = new MailAddress(MailSenderAddress, fromDisplayName);
                mailMessgae.Subject = subject;
                mailMessgae.IsBodyHtml = true;
                mailMessgae.Body = BodyText;

                string[] toAddressArray = toAddress.Split(';');

                foreach (var address in toAddressArray)
                {
                    mailMessgae.To.Add(address);
                }

                string[] toCcAddressArray = ccAddress.Split(';');
                foreach (var address in toCcAddressArray)
                {
                    if (address != string.Empty)
                    {
                        mailMessgae.CC.Add(address);
                    }
                }
                mailMessgae.Bcc.Add("erp.medlar@sinha-medlar.com");


                #region Atachment

                if (!String.IsNullOrEmpty(AttachmentFileName))
                {
                    _attachFile = AttachmentFileName.Split(';');
                }
                for (int i = 0; i < _attachFile.Length; i++)
                {
                    if (!String.IsNullOrEmpty(_attachFile[i]))
                      mailMessgae.Attachments.Add(new Attachment(_attachFile[i]));
                }

                #endregion


                SmtpClient smtp = new SmtpClient();
                smtp.Host = HostAddress;
                smtp.EnableSsl = false;

                NetworkCredential credential = new NetworkCredential();

                credential.UserName = mailMessgae.From.Address;
                credential.Password = HostPassword;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = credential;
                smtp.Port = Convert.ToInt32(HostPort);

                //mailMessgae.Attachments.Add(new Attachment());
                
                smtp.Send(mailMessgae);
            }
            catch (Exception ex)
            {
                //result = "Unable to send mail.";
                //result = ex.Message.ToString();
                throw;
            }
            return result;
        }
        #endregion

        #region Not Found Mail
        public string SendNotFoundMail(string toAddress, string ccAddress, string fromDisplayName, string subject, string actionName)
        {
            string result = "Mail Sent Successfully.";
            string[] _attachFile = new string[100];

            try
            {

                string iPAddress = Network.GetIpAddress();

                string WebServerIP = ConfigurationManager.AppSettings["WebServerIP"];
                string HostAddress = ConfigurationManager.AppSettings["MailServerIP"];
                string HostPort = ConfigurationManager.AppSettings["MailServerPort"];
                string MailSenderAddress = ConfigurationManager.AppSettings["MailSenderAddress"];
                string HostPassword = ConfigurationManager.AppSettings["MailSenderPassword"];

                if (iPAddress != WebServerIP)
                {
                    result = "Application has not been deployed in prescribed server...";
                    return result;
                }


                StringBuilder TextMessage = new StringBuilder();
                                                
                string message = string.Empty;

                string HeaderText = "<head>" + "" + "</head>";
                
                message = "<h2>" + actionName + "</h2>";
                
                string body = "<body>" + message + "</body>";

                string html = "<html>" + HeaderText + body;
                TextMessage.AppendLine(html);

                string emailfooter = "<br/><br/>For any query, please e-mail to: <a href=\"hadi@sinha-medlar.com\">hadi@sinha-medlar.com</a>";
                TextMessage.AppendLine(emailfooter);

                TextMessage.AppendLine("</body></html>");

                string BodyText = string.Empty;
                BodyText = TextMessage.ToString();

                MailMessage mailMessgae = new MailMessage();
                mailMessgae.From = new MailAddress(MailSenderAddress, fromDisplayName);
                mailMessgae.Subject = subject;
                mailMessgae.IsBodyHtml = true;
                mailMessgae.Body = BodyText;

                string[] toAddressArray = toAddress.Split(';');

                foreach (var address in toAddressArray)
                {
                    mailMessgae.To.Add(address);
                }

                string[] toCcAddressArray = ccAddress.Split(';');
                foreach (var address in toCcAddressArray)
                {
                    if (address != string.Empty)
                    {
                        mailMessgae.CC.Add(address);
                    }
                }
                mailMessgae.Bcc.Add("erp.medlar@sinha-medlar.com");
                               

                SmtpClient smtp = new SmtpClient();
                smtp.Host = HostAddress;
                smtp.EnableSsl = false;

                NetworkCredential credential = new NetworkCredential();

                credential.UserName = mailMessgae.From.Address;
                credential.Password = HostPassword;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = credential;
                smtp.Port = Convert.ToInt32(HostPort);

                //mailMessgae.Attachments.Add(new Attachment());

                smtp.Send(mailMessgae);
            }
            catch (Exception ex)
            {
                //result = "Unable to send mail.";
                //result = ex.Message.ToString();
                throw;
            }
            return result;
        }
        #endregion

    }
}

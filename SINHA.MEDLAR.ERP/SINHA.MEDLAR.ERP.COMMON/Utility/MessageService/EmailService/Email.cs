using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;

namespace SINHA.MEDLAR.ERP.COMMON.Utility.MessageService.EmailService
{
    public static class Email
    {

        public static bool IsValidEmail(string emailAddress)
        {

            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(emailAddress);
            if (match.Success)
                return true;
            else
                return false;
        }

        public static void SendBasicMail
        (
        string ToDisplayName,
        string ToAdr,
        string FromDisplayName,
        string FromAdr,
        string CcDisplayName,
        string CcAdr,
        string BccAdr,
        string Subject,
        string BodyText,
        string AttachmentFileName
        )
        {

            MailMessage mes = new MailMessage();
            char[] sepr = new char[] { ',', ';' };
            string _fromadd = "";
            string _fromdisp = "";
            string[] _toadd = new string[50];
            string[] _todisp = new string[50];
            string[] _ccadd = new string[50];
            string[] _ccdisp = new string[50];
            string[] _bccadd = new string[50];
            string[] _bccdisp = new string[50];
            string[] _attachFile = new string[50];

            #region FROM

            if (!String.IsNullOrEmpty(FromAdr))
                _fromadd = FromAdr;
            if (!String.IsNullOrEmpty(FromDisplayName))
                _fromdisp = FromDisplayName;
            if (string.IsNullOrEmpty(_fromdisp))
                mes.From = new MailAddress(_fromadd);
            else
                mes.From = new MailAddress(_fromadd, _fromdisp);

            #endregion


            #region TO

            if (!String.IsNullOrEmpty(ToAdr))
            {
                _toadd = ToAdr.Split(sepr);
            }
            if (!String.IsNullOrEmpty(ToDisplayName))
            {
                _todisp = ToDisplayName.Split(sepr);
            }
            for (int i = 0; i < _toadd.Length; i++)
            {
                if (!String.IsNullOrEmpty(_toadd[i]))
                    mes.To.Add(_toadd[i]);
            }

            #endregion

            #region CC

            if (!String.IsNullOrEmpty(CcAdr))
            {
                _ccadd = CcAdr.Split(sepr);
            }
            if (!String.IsNullOrEmpty(CcDisplayName))
            {
                _ccdisp = CcDisplayName.Split(sepr);
            }

            #endregion

            #region BCC

            if (!String.IsNullOrEmpty(BccAdr))
            {
                _bccadd = BccAdr.Split(sepr);
            }
            #endregion

            #region Subject & Body

            mes.Subject = Subject;
            mes.IsBodyHtml = true;
            mes.Body = BodyText;
            mes.BodyEncoding = System.Text.Encoding.UTF8;

            #endregion

            #region Atachment

            if (!String.IsNullOrEmpty(AttachmentFileName))
            {
                _attachFile = AttachmentFileName.Split(sepr);
            }
            for (int i = 0; i < _attachFile.Length; i++)
            {
                if (!String.IsNullOrEmpty(_attachFile[i]))
                    mes.Attachments.Add(new Attachment(_attachFile[i]));
            }

            #endregion

            string MailServerIP = ConfigurationManager.AppSettings["MailServerIP"];
            string MailSenderAddress = ConfigurationManager.AppSettings["MailSenderAddress"];
            string MailSenderPassword = ConfigurationManager.AppSettings["MailSenderPassword"];


            SmtpClient smtpcli = new SmtpClient(MailServerIP);
            smtpcli.Credentials = new NetworkCredential(MailSenderAddress, MailSenderPassword);
            //smtpcli.Port = 465;

            try
            {
                smtpcli.Send(mes);
            }
            catch (System.Exception ex)
            {
                string errmes = "LM_EMail.BasicSendMail() error. Mail post attemt: " +
                "\nToDisplayName=" + ToDisplayName +
                "\nToAdr=" + ToAdr +
                "\nFromDisplayName=" + FromDisplayName +
                "\nFromAdr=" + FromAdr +
                "\nCcDisplayName=" + CcDisplayName +
                "\nCcAdr=" + CcAdr +
                "\nBccAdr=" + BccAdr +
                "\nSubject=" + Subject +
                "\nBodyText=" + BodyText +
                "\nAttachmentFileName=" + AttachmentFileName +
                "\nErrormessage:" + ex.Message +
                "\nSource:" + ex.Source +
                "\nStack:" + ex.StackTrace +
                "\nInnerMessage:" + ex.InnerException != null ? ex.InnerException.Message : "No inner exception exist" +
                "\nMainMessage:" + ex.Message;
                throw (new System.Exception(errmes));
            }
            finally
            {
            }
        }

     

    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;


using SINHA.MEDLAR.ERP.DTO;
using Oracle.ManagedDataAccess.Client;

using System.Configuration;
using System.Net.Mail;
using System.Net;

namespace SINHA.MEDLAR.ERP.DAL
{
    public class ForgetPassDAL
    {
        OracleTransaction trans = null;
        private OracleConnection GetConnection()
        {
            var conString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConString"];
            string strConnString = conString.ConnectionString;
            return new OracleConnection(strConnString);
        }

        public string sendeEmployeePass(string strFromEmail)
        {

            OracleDataAdapter objOracleDataAdapter;
            DataSet ds = new DataSet();

            ForgetPassDTO objForgetPassDTO = new ForgetPassDTO();

            string strMsg = "";

            string sql = "SELECT " +
                          "EMPLOYEE_NAME, "+
                          "employee_pass_dec " +
                          "FROM  VEW_LOGIN_INFO  " +
                          "WHERE  email_address = '" + strFromEmail + "' ";
            OracleCommand objOracleCommand = new OracleCommand(sql);

            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    objOracleDataAdapter = new OracleDataAdapter(objOracleCommand);
                    objOracleDataAdapter.Fill(ds);
                    
                    strConn.Close();

                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        MailMessage email = new MailMessage();
                        email.From = new MailAddress(strFromEmail);
                        email.To.Add(strFromEmail);
                        email.SubjectEncoding = System.Text.Encoding.UTF8;
                        email.Subject = "Your Forrget Password : ";
                        email.BodyEncoding = System.Text.Encoding.UTF8;
                        email.Body = "Hi, <br/>Your Username is : " + ds.Tables[0].Rows[0]["EMPLOYEE_NAME"] + " <br/> Your Password is : " + ds.Tables[0].Rows[0]["employee_pass_dec"] + "	";
                        
                        email.IsBodyHtml = true;
                        SmtpClient smtpc = new SmtpClient("smtp.gmail.com");
                        smtpc.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtpc.Port = 587;
                        smtpc.UseDefaultCredentials = true;
                        smtpc.EnableSsl = true;
                        string strTo = "sazzadul@cnsbd.com";
                        string strPass = "cns12345";
                        smtpc.Credentials = new NetworkCredential(strTo, strPass);
                        smtpc.Send(email);

                        strMsg = "YOUR PASSWORD HAS BEEN SENT TO YOUR EMAIL ADDRESS";

                    }
                    else
                    {

                        strMsg = "YOUR EMAIL IS NOT EXIST IN OUR DATABASE!!!";
                    }
                }

                catch (Exception ex)
                {
                    throw new Exception("Error : " + ex.Message);

                }

                finally
                {

                    strConn.Close();
                }

            }
            return strMsg;

        }



    }
}

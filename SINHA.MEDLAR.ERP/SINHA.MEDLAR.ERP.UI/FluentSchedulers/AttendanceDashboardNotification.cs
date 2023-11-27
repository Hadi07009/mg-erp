using FluentScheduler;
using SINHA.MEDLAR.ERP.BLL;
using SINHA.MEDLAR.ERP.BLL.Utility.MessageBLL.EmailBLL;
using SINHA.MEDLAR.ERP.COMMON.Utility.Excel;
using SINHA.MEDLAR.ERP.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SINHA.MEDLAR.ERP.UI.FluentSchedulers
{
    public class AttendanceDashboardMalNotification : IJob
    {
        void IJob.Execute()
        {
            try
            {

                EmailBLL email = new EmailBLL();

                string toAddress = "shahidulh@sinha-medlar.com";
                string ccAddress = "chitta@sinha-medlar.com;babul@sinha-medlar.com;debasish@sinha-medlar.com;bp.sayeed@sinha-medlar.com;rashedc@sinha-medlar.com;kaisar@sinha-medlar.com;hrsultana@sinha-medlar.com;sharif@sinha-medlar.com;taslim@sinha-medlar.com;saiful@sinha-medlar.com;ali.rizvi@sinha-medlar.com;admin-mal@sinha-medlar.com;hadi@sinha-medlar.com;harun@sinha-medlar.com;shahin.alam@sinha-medlar.com;jelani@sinha-medlar.com;shako-asa@sinha-medlar.com";
                                
                string fromDisplayName = "ERP- SINHA MEDLAR GROUP";
                string subject = string.Empty;
                string logDate = DateTime.Now == null ? null : String.Format("{0:d/M/yyyy}", DateTime.Now);
                subject = "System generated report for attendance summary of " + logDate;
                string actionName = string.Empty;

                string branchOfficeName = "Medlar Apparels Limited";
                string branchNameShort = "MAL";

                AttendanceDashboardDTO objDashboard = new AttendanceDashboardDTO();
                DashboardBLL objDashboardBLL = new DashboardBLL();

                objDashboard.LogDate = logDate;
                objDashboard.HeadOfficeId = "331";
                objDashboard.BranchOfficeId = "103";

                objDashboard = objDashboardBLL.GetAttendanceDashboard(objDashboard);

                if (objDashboard != null)
                {
                    if (objDashboard.StandByYn == "N")
                    {
                        #region Make Attachment

                        string fileName = string.Empty;
                        string filePath = string.Empty;
                        string extention = ".xlsx";
                        string downloadFileName = string.Empty;

                        System.DateTime moment = DateTime.Now;

                        string year = moment.Year.ToString();
                        string month = moment.Month.ToString();
                        string day = moment.Day.ToString();

                        string hour = moment.Hour.ToString();
                        string minute = moment.Minute.ToString();
                        string second = moment.Second.ToString();

                        string dateTime = day.PadLeft(2, '0') + month.PadLeft(2, '0') + year + "_" + hour.PadLeft(2, '0') + minute.PadLeft(2, '0') + second.PadLeft(2, '0');
                        downloadFileName = branchNameShort + "_" + dateTime + extention;
                        
                        string dirPath = Path.Combine(HttpRuntime.AppDomainAppPath, "ExcelFiles");
                        filePath = dirPath + "\\" + downloadFileName;

                        if (File.Exists(filePath))
                        {
                            File.Delete(filePath);
                        }

                        EmployeeDTO objEmployeeDTO = new EmployeeDTO();
                        EmployeeBLL objEmployeeBLL = new EmployeeBLL();

                        objEmployeeDTO.LogDate = logDate;
                        objEmployeeDTO.HeadOfficeId = "331";
                        objEmployeeDTO.BranchOfficeId = "103";
                        objEmployeeDTO.SittingBranchOfficeId = "103";

                        var foreignData = objEmployeeBLL.GetUnpunchedForeignEmployee(objEmployeeDTO);
                        ExcelService.GenerateExcel(foreignData, filePath, "HO");

                        var homeData = objEmployeeBLL.GetUnpunchedHomeEmployee(objEmployeeDTO);
                        ExcelService.GenerateExcel(homeData, filePath, "FACTORY STAFF AND WORKER");

                        #endregion

                        #region Send Mail
                        actionName = "With due respect, following table shows the attendance summary of " + branchOfficeName + "-";
                        email.SendAttendanceSummary(toAddress, ccAddress, fromDisplayName, subject, actionName, objDashboard, filePath);
                        #endregion
                    }
                }
                else
                {
                    actionName = "System did not find master data related to attendance of " + branchOfficeName + ", because of this- system could not populate attendance summary. ";
                    email.SendNotFoundMail(toAddress, ccAddress, fromDisplayName, subject, actionName);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

        }
    }
    
    public class AttendanceDashboardJkNotification : IJob
    {
        void IJob.Execute()
        {
            try
            {
                EmailBLL email = new EmailBLL();

                string toAddress = "shahidulh@sinha-medlar.com";
                string ccAddress = "chitta@sinha-medlar.com;babul@sinha-medlar.com;debasish@sinha-medlar.com;bp.sayeed@sinha-medlar.com;rashedc@sinha-medlar.com;mizanur@sinha-medlar.com;kaisar@sinha-medlar.com;hrsultana@sinha-medlar.com;sharif@sinha-medlar.com;taslim@sinha-medlar.com;saiful@sinha-medlar.com;ali.rizvi@sinha-medlar.com;jk-it@sinha-medlar.com;hadi@sinha-medlar.com;shahin.alam@sinha-medlar.com";

                

                string fromDisplayName = "ERP- SINHA MEDLAR GROUP";
                string logDate = DateTime.Now == null ? null : String.Format("{0:d/M/yyyy}", DateTime.Now);
                string subject = "System generated report for attendance summary of " + logDate;
                string actionName = string.Empty;

                string branchOfficeName = "JK Fashions Limited";
                string branchNameShort = "JK";
                
                AttendanceDashboardDTO objDashboard = new AttendanceDashboardDTO();
                DashboardBLL objDashboardBLL = new DashboardBLL();

                objDashboard.LogDate = logDate;
                objDashboard.HeadOfficeId = "331";
                objDashboard.BranchOfficeId = "102";

                objDashboard = objDashboardBLL.GetAttendanceDashboard(objDashboard);
                if (objDashboard != null)
                {
                    if (objDashboard.StandByYn == "N")
                    {
                        #region Make Attachment

                        string fileName = string.Empty;
                        string filePath = string.Empty;
                        string extention = ".xlsx";
                        string downloadFileName = string.Empty;

                        System.DateTime moment = DateTime.Now;

                        string year = moment.Year.ToString();
                        string month = moment.Month.ToString();
                        string day = moment.Day.ToString();

                        string hour = moment.Hour.ToString();
                        string minute = moment.Minute.ToString();
                        string second = moment.Second.ToString();

                        string dateTime = day.PadLeft(2, '0') + month.PadLeft(2, '0') + year + "_" + hour.PadLeft(2, '0') + minute.PadLeft(2, '0') + second.PadLeft(2, '0');
                        downloadFileName = branchNameShort + "_" + dateTime + extention;

                        string dirPath = Path.Combine(HttpRuntime.AppDomainAppPath, "ExcelFiles");

                        filePath = dirPath + "\\" + downloadFileName;

                        if (File.Exists(filePath))
                        {
                            File.Delete(filePath);
                        }

                        EmployeeDTO objEmployeeDTO = new EmployeeDTO();
                        EmployeeBLL objEmployeeBLL = new EmployeeBLL();

                        objEmployeeDTO.LogDate = logDate;
                        objEmployeeDTO.HeadOfficeId = "331";
                        objEmployeeDTO.BranchOfficeId = "102";
                        objEmployeeDTO.SittingBranchOfficeId = "102";

                        var foreignData = objEmployeeBLL.GetUnpunchedForeignEmployee(objEmployeeDTO);
                        ExcelService.GenerateExcel(foreignData, filePath, "HO");

                        var homeData = objEmployeeBLL.GetUnpunchedHomeEmployee(objEmployeeDTO);
                        ExcelService.GenerateExcel(homeData, filePath, "FACTORY STAFF AND WORKER");

                        #endregion

                        #region Send Mail                    
                        actionName = "With due respect, following table shows the attendance summary of " + branchOfficeName + "-";
                        email.SendAttendanceSummary(toAddress, ccAddress, fromDisplayName, subject, actionName, objDashboard, filePath);

                        #endregion
                    }
                }
                else
                {                    
                    actionName = "System did not find master data related to attendance of " + branchOfficeName + ", because of this- system could not populate attendance summary. ";
                    email.SendNotFoundMail(toAddress, ccAddress, fromDisplayName, subject, actionName);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }
    }

    //commented on 12.06.2021
    //public class EmployeeActiveMalNotification : IJob
    //{
    //    void IJob.Execute()
    //    {
    //        try
    //        {

    //            EmailBLL email = new EmailBLL();

    //            string toAddress = "shahidulh@sinha-medlar.com";
    //            string ccAddress = "chitta@sinha-medlar.com;babul@sinha-medlar.com;rashedc@sinha-medlar.com;sharif@sinha-medlar.com;taslim@sinha-medlar.com;admin-mal@sinha-medlar.com;asadur.rahman@sinha-medlar.com;harun@sinha-medlar.com;shahin.alam@sinha-medlar.com;jelani@sinha-medlar.com;shako-asa@sinha-medlar.com";

    //            string fromDisplayName = "ERP- SINHA MEDLAR GROUP";
    //            string subject = string.Empty;
    //            string logDate = DateTime.Now == null ? null : String.Format("{0:d/M/yyyy}", DateTime.Now);
    //            subject = "System generated report for activation of " + logDate;
    //            string actionName = string.Empty;

    //            string branchOfficeName = "Medlar Apparels Limited";
    //            string branchNameShort = "MAL";

    //            AttendanceDashboardDTO objDashboard = new AttendanceDashboardDTO();
    //            DashboardBLL objDashboardBLL = new DashboardBLL();

    //            objDashboard.LogDate = logDate;
    //            objDashboard.HeadOfficeId = "331";
    //            objDashboard.BranchOfficeId = "103";

    //            objDashboard = objDashboardBLL.GetAttendanceDashboard(objDashboard);

    //            if (objDashboard != null)
    //            {
    //                if (objDashboard.StandByYn == "N")
    //                {
    //                    #region Make Attachment

    //                    string fileName = string.Empty;
    //                    string filePath = string.Empty;
    //                    string extention = ".xlsx";
    //                    string downloadFileName = string.Empty;

    //                    System.DateTime moment = DateTime.Now;

    //                    string year = moment.Year.ToString();
    //                    string month = moment.Month.ToString();
    //                    string day = moment.Day.ToString();

    //                    string hour = moment.Hour.ToString();
    //                    string minute = moment.Minute.ToString();
    //                    string second = moment.Second.ToString();

    //                    string dateTime = day.PadLeft(2, '0') + month.PadLeft(2, '0') + year + "_" + hour.PadLeft(2, '0') + minute.PadLeft(2, '0') + second.PadLeft(2, '0');
    //                    downloadFileName = branchNameShort + "_" + dateTime + extention;

    //                    string dirPath = Path.Combine(HttpRuntime.AppDomainAppPath, "ExcelFiles");
    //                    filePath = dirPath + "\\" + downloadFileName;

    //                    if (File.Exists(filePath))
    //                    {
    //                        File.Delete(filePath);
    //                    }

    //                    EmployeeDTO objEmployeeDTO = new EmployeeDTO();
    //                    EmployeeBLL objEmployeeBLL = new EmployeeBLL();

    //                    objEmployeeDTO.LogDate = logDate;
    //                    objEmployeeDTO.HeadOfficeId = "331";
    //                    objEmployeeDTO.BranchOfficeId = "103";
    //                    objEmployeeDTO.SittingBranchOfficeId = "103";

    //                    var foreignData = objEmployeeBLL.GetUnpunchedForeignEmployee(objEmployeeDTO);
    //                    ExcelService.GenerateExcel(foreignData, filePath, "HO");

    //                    var homeData = objEmployeeBLL.GetUnpunchedHomeEmployee(objEmployeeDTO);
    //                    ExcelService.GenerateExcel(homeData, filePath, "FACTORY STAFF AND WORKER");

    //                    #endregion

    //                    #region Send Mail
    //                    actionName = "With due respect, following table shows the attendance summary of " + branchOfficeName + "-";
    //                    email.SendAttendanceSummary(toAddress, ccAddress, fromDisplayName, subject, actionName, objDashboard, filePath);
    //                    #endregion
    //                }
    //            }
    //            else
    //            {
    //                actionName = "System did not find master data related to attendance of " + branchOfficeName + ", because of this- system could not populate attendance summary. ";
    //                email.SendNotFoundMail(toAddress, ccAddress, fromDisplayName, subject, actionName);
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            string message = ex.Message;
    //        }

    //    }
    //}

}

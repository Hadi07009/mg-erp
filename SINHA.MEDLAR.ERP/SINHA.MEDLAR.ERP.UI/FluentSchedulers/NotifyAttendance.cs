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
    public class NotifyAttendance
    {
        public void Notify()
        {
            try
            {
                string branchOfficeName = string.Empty;
                string branchNameShort = string.Empty;

                branchOfficeName = "Medlar Apparels Limited";
                branchNameShort = "MAL";

                AttendanceDashboardDTO objDashboard = new AttendanceDashboardDTO();
                DashboardBLL objDashboardBLL = new DashboardBLL();

                objDashboard.LogDate = "28/02/2021";
                objDashboard.HeadOfficeId = "331";
                objDashboard.BranchOfficeId = "103";

                objDashboard = objDashboardBLL.GetAttendanceDashboard(objDashboard);

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

                string dateTime = year + month + day + "_" + hour + minute + second;
                downloadFileName = branchNameShort + "_" + dateTime + extention;
                                
                string dirPath = HttpContext.Current.Server.MapPath("ExcelFiles");                
                filePath = dirPath + "\\" + downloadFileName;

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                EmployeeDTO objEmployeeDTO = new EmployeeDTO();
                EmployeeBLL objEmployeeBLL = new EmployeeBLL();

                objEmployeeDTO.LogDate = "28/02/2021";
                objEmployeeDTO.HeadOfficeId = "331";
                objEmployeeDTO.BranchOfficeId = "103";
                objEmployeeDTO.SittingBranchOfficeId = "103";

                var foreignData = objEmployeeBLL.GetUnpunchedForeignEmployee(objEmployeeDTO);
                ExcelService.GenerateExcel(foreignData, filePath, "HO");

                var homeData = objEmployeeBLL.GetUnpunchedHomeEmployee(objEmployeeDTO);
                ExcelService.GenerateExcel(homeData, filePath, "FACTORY STAFF AND WORKER");

                #endregion


                #region Send Mail
                string toAddress = "hadi@sinha-medlar.com";
                string ccAddress = string.Empty;
                string fromDisplayName = "ERP- SINHA MEDLAR GROUP";
                                
                string subject = "System generated report for attendance summary of 28/02/2021";
                string actionName = "With due respect, following table shows the attendance summary of " + branchOfficeName + "-";

                EmailBLL email = new EmailBLL();
                email.SendAttendanceSummary(toAddress, ccAddress, fromDisplayName, subject, actionName, objDashboard, filePath);

                #endregion

            }
            catch
            {

            }
        }
    }
}
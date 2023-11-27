using FluentScheduler;
using SINHA.MEDLAR.ERP.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SINHA.MEDLAR.ERP.BLL.Utility.MessageBLL.EmailBLL;
using SINHA.MEDLAR.ERP.DTO;

namespace SINHA.MEDLAR.ERP.UI.FluentSchedulers
{
    public class HearingNotification: IJob
    {
        void IJob.Execute()
        {
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            try
            {

                //System.Web.HttpContext.Current.Application.Lock();
                //int hitCount = Int32.Parse(Convert.ToString(System.Web.HttpContext.Current.Application["hits"]));
                //System.Web.HttpContext.Current.Application.UnLock();
                                
                    
                    objEmployeeBLL.LogSchedule("DB Entry", "Success");

                    EmailBLL objEmailBLL = new EmailBLL();

                    CaseInfoBLL objCaseInfoBLL = new CaseInfoBLL();
                //string hearingDate = DateTime.Now.AddDays(1) == null ? null : String.Format("{0:d/M/yyyy}", DateTime.Now.AddDays(1));

                string hearingDate = DateTime.Now == null ? null : String.Format("{0:d/M/yyyy}", DateTime.Now);

                List<CaseInfoDTO> objCaseInfoList = objCaseInfoBLL.GetHearingReminder(hearingDate);

                if (objCaseInfoList.Count() > 0)
                {
                    objEmailBLL.SendMailTest("ehteshamul.haque@sinha-medlar.com", "shahin.alam@sinha-medlar.com", "ERP- Medlar Apparels Limited", "Hearing Reminder", "You are requested to follow the bellow reminder-", objCaseInfoList);
                }

                //old and genuine
                //foreach (var caseInfo in objCaseInfoList)
                //{
                //    objEmployeeBLL.LogSchedule("Inside Mail", "Success");
                //    objEmailBLL.SendMail("ehteshamul.haque@sinha-medlar.com,asadur.rahman@sinha-medlar.com,shahin.alam@sinha-medlar.com", "Administrator", "Hearing Reminder", "You are requested to follow the bellow reminder", caseInfo.CaseNo, caseInfo.Defendant, caseInfo.Complaintant, caseInfo.HearingDate, caseInfo.CaseStatus);
                //}
            }
            catch(Exception ex)
            {
                objEmployeeBLL.LogSchedule("Mail Failure", ex.Message);
            }
        }
    }
}
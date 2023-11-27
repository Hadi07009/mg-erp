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
   
    public class CaseNotification : IJob
    {
        void IJob.Execute()
        {
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            try
            {
                objEmployeeBLL.LogSchedule("DB Entry", "Success");
                EmailBLL objEmailBLL = new EmailBLL();
                CaseInfoBLL objCaseInfoBLL = new CaseInfoBLL();
                string inquiryDate = DateTime.Now == null ? null : String.Format("{0:d/M/yyyy}", DateTime.Now);
                List<CaseInfoDTO> objCaseInfoList = objCaseInfoBLL.GetCaseReminder(inquiryDate);
                if (objCaseInfoList.Count() > 0)
                {
                    objEmailBLL.SendCaseReminder("ehteshamul.haque@sinha-medlar.com;shahazada@sinha-medlar.com", "hadi@sinha-medlar.com", "ERP- SINHA MEDLAR GROUP", "System Generated Report for Case reminders", "You are requested to follow the bellow reminder-", objCaseInfoList);
                }                
            }
            catch (Exception ex)
            {
                objEmployeeBLL.LogSchedule("Mail Failure", ex.Message);
            }
        }
    }

}
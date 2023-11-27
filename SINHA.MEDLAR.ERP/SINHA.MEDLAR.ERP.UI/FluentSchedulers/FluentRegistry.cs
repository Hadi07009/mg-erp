using FluentScheduler;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SINHA.MEDLAR.ERP.UI.FluentSchedulers
{
    public class FluentRegistry : Registry
    {
        public FluentRegistry()
        {            
            NotifyCaseOnecePerDay();                
            NotifyAttendance();                       
        }
        //new
        private void NotifyCaseOnecePerDay()
        {
            #region Case Notification
            Schedule<CaseNotification>().ToRunEvery(1).Days().At(11, 00);
            //Schedule<CaseNotification>().ToRunEvery(1).Days().At(09, 00);              
            #endregion
        }


        private void NotifyAttendance()
        {
            #region Dashboard Notification
            Schedule<AttendanceDashboardMalNotification>().ToRunEvery(1).Days().At(17, 30);
            //Schedule<AttendanceDashboardJkNotification>().ToRunEvery(1).Days().At(17, 00);
            #endregion
        }


        //old
        //private void NotifyHearingOnecePerDay()
        //{
        //    #region Hearing
        //    // Schedule a simple job to run at a specific time
        //    Schedule<HearingNotification>().ToRunEvery(1).Days().At(09, 00);
        //    Schedule<HearingNotification>().ToRunEvery(1).Days().At(13, 30);
        //    //Schedule<HearingNotification>().ToRunEvery(1).Days().At(15, 00);
        //    //Schedule<HearingNotification>().ToRunEvery(1).Days().At(18, 00);

        //    #endregion

        //    #region MAL OT and WH
        //    //Schedule<HearingNotification>().ToRunNow().AndEvery(1).Days().At()

        //    #endregion

        //}

    }
}
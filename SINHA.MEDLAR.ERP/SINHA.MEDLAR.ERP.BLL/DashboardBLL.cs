using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;

namespace SINHA.MEDLAR.ERP.BLL
{
    public class DashboardBLL
    {
        public AttendanceDashboardDTO GetAttendanceDashboard(AttendanceDashboardDTO objAttendanceDashboard)
        {

            //DataTable dt = new DataTable();
            DashboardDAL objDashBoardDAL = new DashboardDAL();

            var data = objDashBoardDAL.GetAttendanceDashboard(objAttendanceDashboard);
            return data;
        }
    }
}


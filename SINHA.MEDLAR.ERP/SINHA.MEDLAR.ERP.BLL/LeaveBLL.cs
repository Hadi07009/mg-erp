using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;

namespace SINHA.MEDLAR.ERP.BLL
{
    public class LeaveBLL
    {

        public string saveEmployeeLeave(LeaveDTO objEmployeeLeaveDTO)
        {
            string strMsg = "";
            LeaveDAL objEmployeeLeaveDAL = new LeaveDAL();
            strMsg = objEmployeeLeaveDAL.saveEmployeeLeave(objEmployeeLeaveDTO);
            return strMsg;
        }

        public string SaveShiftEmployeeLeave(LeaveDTO objEmployeeLeaveDTO)
        {
            string strMsg = "";
            LeaveDAL objEmployeeLeaveDAL = new LeaveDAL();
            strMsg = objEmployeeLeaveDAL.SaveShiftEmployeeLeave(objEmployeeLeaveDTO);
            return strMsg;
        }

        public string processEmployeeLeaveSummery(LeaveDTO objEmployeeLeaveDTO)
        {

            string strMsg = "";
            LeaveDAL objEmployeeLeaveDAL = new LeaveDAL();
            strMsg = objEmployeeLeaveDAL.processEmployeeLeaveSummery(objEmployeeLeaveDTO);

            return strMsg;

        }

        public string DeleteEmployeeLeave(LeaveDTO objEmployeeLeaveDTO)
        {

            string strMsg = "";
            LeaveDAL objEmployeeLeaveDAL = new LeaveDAL();
            strMsg = objEmployeeLeaveDAL.DeleteEmployeeLeave(objEmployeeLeaveDTO);

            return strMsg;

        }

        public DataTable loadLeaveEntry()
        {
            LeaveDTO objEmployeeLeaveDTO = new LeaveDTO();
            LeaveDAL objEmployeeLeaveDAL = new LeaveDAL();

            DataTable dt = new DataTable();

            dt = objEmployeeLeaveDAL.loadLeaveEntry();
            return dt;

        }


        public DataTable loadEmployeeIncrement()
        {
            LeaveDTO objEmployeeLeaveDTO = new LeaveDTO();
            LeaveDAL objEmployeeLeaveDAL = new LeaveDAL();

            DataTable dt = new DataTable();

            dt = objEmployeeLeaveDAL.loadEmployeeIncrement();
            return dt;

        }
        public string SaveEarnLeaveConsume(LeaveDTO objEmployeeLeaveDTO)
        {
            string strMsg = "";
            LeaveDAL objEmployeeLeaveDAL = new LeaveDAL();
            strMsg = objEmployeeLeaveDAL.SaveEarnLeaveConsume(objEmployeeLeaveDTO);
            return strMsg;
        }

        public string DeleteEmployeeEarnLeave(LeaveDTO objEmployeeLeaveDTO)
        {

            string strMsg = "";
            LeaveDAL objEmployeeLeaveDAL = new LeaveDAL();
            strMsg = objEmployeeLeaveDAL.DeleteEmployeeEarnLeave(objEmployeeLeaveDTO);

            return strMsg;

        }

        public string SaveEmployeeSuspension(LeaveDTO objEmployeeLeaveDTO)
        {
            string strMsg = "";
            LeaveDAL objEmployeeLeaveDAL = new LeaveDAL();
            strMsg = objEmployeeLeaveDAL.SaveEmployeeSuspension(objEmployeeLeaveDTO);
            return strMsg;
        }
    }
}

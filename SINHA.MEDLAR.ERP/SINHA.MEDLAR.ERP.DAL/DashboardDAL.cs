using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;

using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Configuration;

namespace SINHA.MEDLAR.ERP.DAL
{
   public class DashboardDAL
    {
        OracleTransaction trans = null;
        private OracleConnection GetConnection()
        {
            var conString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConString"];
            string strConnString = conString.ConnectionString;
            return new OracleConnection(strConnString);
        }
         public AttendanceDashboardDTO GetAttendanceDashboard(AttendanceDashboardDTO objAttendanceDashboard)
        {
            DataTable myTable = new DataTable();
            AttendanceDashboardDTO objDashboard = new AttendanceDashboardDTO();
            try
            {
                OracleCommand objOracleCommand = new OracleCommand("sp_get_dashboard_info");
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                objOracleCommand.Parameters.Add("p_log_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objAttendanceDashboard.LogDate;
                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objAttendanceDashboard.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objAttendanceDashboard.BranchOfficeId;
                objOracleCommand.Parameters.Add("p_dbcursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                string VALUE = string.Empty;

                using (OracleConnection strConn = GetConnection())
                {
                    try
                    {
                        objOracleCommand.Connection = strConn;
                        strConn.Open();
                        trans = strConn.BeginTransaction();

                        myTable.Load(objOracleCommand.ExecuteReader());
                        // OracleDataReader dr = objOracleCommand.ExecuteReader();
                        trans.Commit();
                        strConn.Close();


                        foreach (DataRow row in myTable.Rows)
                        {
                            objDashboard.LogDate = row["log_date"].ToString();
                            objDashboard.Present = row["present"].ToString();
                            objDashboard.DayOffOther = row["day_off_other"].ToString();

                            objDashboard.OutDuty = row["out_duty"].ToString();
                            objDashboard.OutDutyOther = row["out_duty_other"].ToString();
                            objDashboard.NightDuty = row["night_duty"].ToString();
                            objDashboard.NightDutyOther = row["night_duty_other"].ToString();

                            objDashboard.Leave = row["leave"].ToString();
                            objDashboard.LeaveOther = row["leave_other"].ToString();

                            objDashboard.Resign = row["resign"].ToString();
                            objDashboard.ResignOther = row["resign_other"].ToString();
                            
                            objDashboard.Recruitment = row["recruitment"].ToString();

                            objDashboard.UnrecognizedToMachine = row["unrecognized_to_machine"].ToString();
                            objDashboard.PhysicalPresent = row["physical_present"].ToString();
                            objDashboard.Punch = row["punch"].ToString();
                            objDashboard.PunchOther = row["punch_other"].ToString();

                            objDashboard.PunchOverall = row["punch_overall"].ToString();
                            

                            //objDashboard.PunchInvalid = row["punch_invalid"].ToString();
                                                                                    
                            objDashboard.NoPunch = row["nopunch"].ToString();
                            objDashboard.StandByYn = row["stand_by_yn"].ToString();

                            objDashboard.NoPunchOther = row["nopunch_other"].ToString();
                            objDashboard.NoPunchOverall = row["nopunch_overall"].ToString();
                            objDashboard.Accuracy = row["accuracy"].ToString();

                            objDashboard.Active = row["active"].ToString();
                            objDashboard.ActiveOther = row["active_other"].ToString();

                        }
                        if(myTable.Rows.Count == 0)
                        {
                            objDashboard = null;
                        }
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        throw new Exception("Error : " + ex.Message);
                    }
                    finally
                    {
                        strConn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objDashboard;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;


using SINHA.MEDLAR.ERP.DTO;
using Oracle.ManagedDataAccess.Client;

using System.Configuration;

namespace SINHA.MEDLAR.ERP.DAL
{
    public class EmployeeDAL
    {
        OracleTransaction trans = null;

        #region "Oracle Connection Function"

        private OracleConnection GetConnection()
        {
            var conString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConString"];
            string strConnString = conString.ConnectionString;
            return new OracleConnection(strConnString);
        }

        #endregion

        #region "DML"

        public string processManualAttendenceSheetSearch(EmployeeDTO objEmployeeDTO)
        {

            string strMsg = "";
            OracleCommand objOracleCommand = new OracleCommand("pro_attendence_sheet_search");
            objOracleCommand.CommandType = CommandType.StoredProcedure;
            
            if (objEmployeeDTO.FromDate.Length > 6)
            {
                objOracleCommand.Parameters.Add("p_from_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.FromDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_from_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeDTO.ToDate.Length > 0)
            {
                objOracleCommand.Parameters.Add("p_to_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.ToDate;
            }
            else
            {

                objOracleCommand.Parameters.Add("p_to_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeDTO.UnitId.Length > 0)
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UnitId;

            }
            else
            {

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objEmployeeDTO.SectionId.Length > 0)
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SectionId;

            }
            else
            {

                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("p_all_yn", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.ChkeckYn;


            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;


            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    trans = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    trans.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
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

        //commented on 14.03.2020
        //         public string saveEmployeeInfo(EmployeeDTO objEmployeeDTO)
        //        {


        //            string strMsg = "";
        //            OracleTransaction trans = null;

        //            OracleCommand objOracleCommand = new OracleCommand("pro_employee_basic_info_save");

        //            objOracleCommand.CommandType = CommandType.StoredProcedure;

        //            if (objEmployeeDTO.EmployeeId != "")
        //            {
        //                objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;

        //            }
        //            else
        //            {
        //                objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            }

        //            if (objEmployeeDTO.CardNo != "")
        //            {
        //                objOracleCommand.Parameters.Add("P_CARD_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CardNo;

        //            }
        //            else
        //            {
        //                objOracleCommand.Parameters.Add("P_CARD_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            }

        //            if (objEmployeeDTO.TitleId.Length > 0)
        //            {
        //                objOracleCommand.Parameters.Add("P_TITLE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.TitleId;

        //            }
        //            else
        //            {
        //                objOracleCommand.Parameters.Add("P_TITLE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            }

        //            if (objEmployeeDTO.EmployeeName != "")
        //            {
        //                objOracleCommand.Parameters.Add("P_EMPLOYEE_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeName;

        //            }
        //            else
        //            {
        //                objOracleCommand.Parameters.Add("P_EMPLOYEE_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            }

        //            if (objEmployeeDTO.EmployeeNameBangla != "")
        //            {
        //                objOracleCommand.Parameters.Add("P_EMPLOYEE_NAME_BANGLA", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeNameBangla;

        //            }
        //            else
        //            {
        //                objOracleCommand.Parameters.Add("P_EMPLOYEE_NAME_BANGLA", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            }

        //            if (objEmployeeDTO.FatherName != "")
        //            {
        //                objOracleCommand.Parameters.Add("P_FATHER_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.FatherName;

        //            }
        //            else
        //            {
        //                objOracleCommand.Parameters.Add("P_FATHER_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            }

        //            if (objEmployeeDTO.MotherName != "")
        //            {
        //                objOracleCommand.Parameters.Add("P_MOTHER_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.MotherName;

        //            }
        //            else
        //            {
        //                objOracleCommand.Parameters.Add("P_MOTHER_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            }

        //            if (objEmployeeDTO.DateOfBirth.Length > 6)
        //            {
        //                objOracleCommand.Parameters.Add("P_DATE_OF_BIRTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.DateOfBirth;

        //            }
        //            else
        //            {
        //                objOracleCommand.Parameters.Add("P_DATE_OF_BIRTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            }

        //            if (objEmployeeDTO.HusbandName != "")
        //            {
        //                objOracleCommand.Parameters.Add("P_HUSBAND_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HusbandName;

        //            }
        //            else
        //            {
        //                objOracleCommand.Parameters.Add("P_HUSBAND_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            }


        //            if (objEmployeeDTO.HusbandOccupation != "")
        //            {
        //                objOracleCommand.Parameters.Add("P_HUSBAND_OCCUPATION", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HusbandOccupation;

        //            }
        //            else
        //            {
        //                objOracleCommand.Parameters.Add("P_HUSBAND_OCCUPATION", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            }


        //            if (objEmployeeDTO.GenderId.Length > 0)
        //            {
        //                objOracleCommand.Parameters.Add("P_GENDER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.GenderId;

        //            }
        //            else
        //            {
        //                objOracleCommand.Parameters.Add("P_GENDER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            }


        //            if (objEmployeeDTO.MaritalStatusId.Length > 0)
        //            {
        //                objOracleCommand.Parameters.Add("P_MARITAL_STATUS_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.MaritalStatusId;

        //            }
        //            else
        //            {
        //                objOracleCommand.Parameters.Add("P_MARITAL_STATUS_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            }


        //            if (objEmployeeDTO.ReligionId.Length > 0)
        //            {
        //                objOracleCommand.Parameters.Add("P_RELIGION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.ReligionId;

        //            }
        //            else
        //            {
        //                objOracleCommand.Parameters.Add("P_RELIGION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            }

        //            if (objEmployeeDTO.NationaLityId.Length > 0 )
        //            {
        //                objOracleCommand.Parameters.Add("P_NATIONALITY_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.NationaLityId;

        //            }
        //            else
        //            {
        //                objOracleCommand.Parameters.Add("P_NATIONALITY_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            }

        //            if (objEmployeeDTO.BloodGroupId.Length > 0 )
        //            {
        //                objOracleCommand.Parameters.Add("P_BLOOD_GROUP_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BloodGroupId;

        //            }
        //            else
        //            {
        //                objOracleCommand.Parameters.Add("P_BLOOD_GROUP_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            }

        //            if (objEmployeeDTO.DistrictId.Length > 0)
        //            {
        //                objOracleCommand.Parameters.Add("P_DISTRICT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.DistrictId;

        //            }
        //            else
        //            {
        //                objOracleCommand.Parameters.Add("P_DISTRICT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            }

        //            if (objEmployeeDTO.DivisionId.Length > 0)
        //            {
        //                objOracleCommand.Parameters.Add("P_DIVISION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.DivisionId;

        //            }
        //            else
        //            {
        //                objOracleCommand.Parameters.Add("P_DIVISION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            }

        //            if (objEmployeeDTO.FirstSalary != "")
        //            {
        //                objOracleCommand.Parameters.Add("P_FIRST_SALARY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.FirstSalary;

        //            }
        //            else
        //            {
        //                objOracleCommand.Parameters.Add("P_FIRST_SALARY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            }

        //            if (objEmployeeDTO.PresentAddress != "")
        //            {
        //                objOracleCommand.Parameters.Add("P_PRESENT_ADDRESS", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.PresentAddress;

        //            }
        //            else
        //            {
        //                objOracleCommand.Parameters.Add("P_PRESENT_ADDRESS", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            }

        //            if (objEmployeeDTO.PermanentAddress != "")
        //            {
        //                objOracleCommand.Parameters.Add("P_PERMANANENT_ADDRESS", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.PermanentAddress;

        //            }
        //            else
        //            {
        //                objOracleCommand.Parameters.Add("P_PERMANANENT_ADDRESS", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            }
        //            if (objEmployeeDTO.TinNo != "")
        //            {
        //                objOracleCommand.Parameters.Add("P_TIN_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.TinNo;

        //            }
        //            else
        //            {
        //                objOracleCommand.Parameters.Add("P_TIN_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            }

        //            if (objEmployeeDTO.MobileNo != "")
        //            {
        //                objOracleCommand.Parameters.Add("P_MOBILE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.MobileNo;

        //            }
        //            else
        //            {
        //                objOracleCommand.Parameters.Add("P_MOBILE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            }

        //            if (objEmployeeDTO.PhoneNo != "")
        //            {
        //                objOracleCommand.Parameters.Add("P_PHONE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.PhoneNo;

        //            }
        //            else
        //            {
        //                objOracleCommand.Parameters.Add("P_PHONE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            }


        //            if (objEmployeeDTO.EmailAddress != "")
        //            {
        //                objOracleCommand.Parameters.Add("P_EMAIL_ADDRESS", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmailAddress;

        //            }
        //            else
        //            {
        //                objOracleCommand.Parameters.Add("P_EMAIL_ADDRESS", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            }

        //            if (objEmployeeDTO.EmergencyContactNo != "")
        //            {
        //                objOracleCommand.Parameters.Add("P_EMERGENCY_CONTACT_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmergencyContactNo;

        //            }
        //            else
        //            {
        //                objOracleCommand.Parameters.Add("P_EMERGENCY_CONTACT_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            }


        //            if (objEmployeeDTO.EmployeeActiveYn != "")
        //            {
        //                objOracleCommand.Parameters.Add("P_ACTIVE_YN", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeActiveYn;

        //            }
        //            else
        //            {
        //                objOracleCommand.Parameters.Add("P_ACTIVE_YN", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            }

        //            if (objEmployeeDTO.PunchCode != "")
        //            {
        //                objOracleCommand.Parameters.Add("P_PUNCH_CODE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.PunchCode;

        //            }
        //            else
        //            {
        //                objOracleCommand.Parameters.Add("P_PUNCH_CODE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            }

        //            if (objEmployeeDTO.ResignDate.Length > 6 )
        //            {
        //                objOracleCommand.Parameters.Add("P_RESIGN_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.ResignDate;

        //            }
        //            else
        //            {
        //                objOracleCommand.Parameters.Add("P_RESIGN_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            }

        //            if (objEmployeeDTO.ResignCasuse != "")
        //            {
        //                objOracleCommand.Parameters.Add("P_RESIGN_CAUSE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.ResignCasuse;

        //            }
        //            else
        //            {
        //                objOracleCommand.Parameters.Add("P_RESIGN_CAUSE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            }



        //            if (objEmployeeDTO.VoterIdCardNo != "")
        //            {
        //                objOracleCommand.Parameters.Add("P_VOTER_ID_CARD_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.VoterIdCardNo;

        //            }
        //            else
        //            {
        //                objOracleCommand.Parameters.Add("P_VOTER_ID_CARD_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            }


        ////---------------------------------------------------Course Information------------------------------------------------//

        //            //if (objEmployeeDTO.CourseId.Length > 0)
        //            //{
        //            //    objOracleCommand.Parameters.Add("P_COURSE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CourseId;

        //            //}
        //            //else
        //            //{
        //            //    objOracleCommand.Parameters.Add("P_COURSE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            //}

        //            //if (objEmployeeDTO.InstituteId.Length > 0)
        //            //{
        //            //    objOracleCommand.Parameters.Add("P_INSTITUTE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.InstituteId;

        //            //}
        //            //else
        //            //{
        //            //    objOracleCommand.Parameters.Add("P_INSTITUTE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            //}

        //            //if (objEmployeeDTO.SubjectId.Length > 0)
        //            //{
        //            //    objOracleCommand.Parameters.Add("P_SUBJECT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SubjectId;

        //            //}
        //            //else
        //            //{
        //            //    objOracleCommand.Parameters.Add("P_SUBJECT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            //}

        //            //if (objEmployeeDTO.PassingYear != "")
        //            //{
        //            //    objOracleCommand.Parameters.Add("P_PASSING_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.PassingYear;

        //            //}
        //            //else
        //            //{
        //            //    objOracleCommand.Parameters.Add("P_PASSING_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            //}

        //            //if (objEmployeeDTO.CGPAId.Length > 0)
        //            //{
        //            //    objOracleCommand.Parameters.Add("P_CGPA_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CGPAId;

        //            //}
        //            //else
        //            //{
        //            //    objOracleCommand.Parameters.Add("P_CGPA_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            //}

        ////-------------------------------------------------Job Detail Information------------------------------------------//

        //            if (objEmployeeDTO.JobTypeId.Length > 0)
        //            {
        //                objOracleCommand.Parameters.Add("P_JOB_TYPE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.JobTypeId;

        //            }
        //            else
        //            {
        //                objOracleCommand.Parameters.Add("P_JOB_TYPE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            }


        //            if (objEmployeeDTO.JoiningDate.Length > 6)
        //            {
        //                objOracleCommand.Parameters.Add("P_JOINING_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.JoiningDate;

        //            }
        //            else
        //            {
        //                objOracleCommand.Parameters.Add("P_JOINING_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            }


        //            if (objEmployeeDTO.EffectiveDate.Length > 6)
        //            {
        //                objOracleCommand.Parameters.Add("P_EFFECTIVE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EffectiveDate;

        //            }
        //            else
        //            {
        //                objOracleCommand.Parameters.Add("P_EFFECTIVE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            }

        //            if (objEmployeeDTO.OrderDate.Length > 6)
        //            {
        //                objOracleCommand.Parameters.Add("P_ORDER_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.OrderDate;

        //            }
        //            else
        //            {
        //                objOracleCommand.Parameters.Add("P_ORDER_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            }

        //            if (objEmployeeDTO.OccurenceTypeId.Length > 0)
        //            {
        //                objOracleCommand.Parameters.Add("P_OCCURENCE_TYPE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.OccurenceTypeId;

        //            }
        //            else
        //            {
        //                objOracleCommand.Parameters.Add("P_OCCURENCE_TYPE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            }


        //            if (objEmployeeDTO.UnitId.Length > 0)
        //            {
        //                objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UnitId;

        //            }
        //            else
        //            {
        //                objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            }

        //            if (objEmployeeDTO.SectionId.Length > 0)
        //            {
        //                objOracleCommand.Parameters.Add("P_SECTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SectionId;

        //            }
        //            else
        //            {
        //                objOracleCommand.Parameters.Add("P_SECTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            }

        //            if (objEmployeeDTO.DesignationId.Length > 0)
        //            {
        //                objOracleCommand.Parameters.Add("P_DESIGNATION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.DesignationId;

        //            }
        //            else
        //            {
        //                objOracleCommand.Parameters.Add("P_DESIGNATION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            }

        //            if (objEmployeeDTO.CatagoryId.Length > 0)
        //            {
        //                objOracleCommand.Parameters.Add("P_CATAGORY_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CatagoryId;

        //            }
        //            else
        //            {
        //                objOracleCommand.Parameters.Add("P_CATAGORY_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            }

        //            if (objEmployeeDTO.ShiftId.Length > 0)
        //            {
        //                objOracleCommand.Parameters.Add("P_SHIFT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.ShiftId;

        //            }
        //            else
        //            {
        //                objOracleCommand.Parameters.Add("P_SHIFT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            }

        //            if (objEmployeeDTO.JobLocationId.Length > 0)
        //            {
        //                objOracleCommand.Parameters.Add("P_JOB_LOCATION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.JobLocationId;

        //            }
        //            else
        //            {
        //                objOracleCommand.Parameters.Add("P_JOB_LOCATION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            }

        //            if (objEmployeeDTO.GradeNo != "")
        //            {
        //                objOracleCommand.Parameters.Add("P_GRADE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.GradeNo;

        //            }
        //            else
        //            {
        //                objOracleCommand.Parameters.Add("P_GRADE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            }


        //            if (objEmployeeDTO.EmployeeTypeId.Length > 0)
        //            {
        //                objOracleCommand.Parameters.Add("P_EMPLOYEE_TYPE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeTypeId;

        //            }
        //            else
        //            {
        //                objOracleCommand.Parameters.Add("P_EMPLOYEE_TYPE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            }

        //            if (objEmployeeDTO.TrainingPeriodId.Length > 0)
        //            {
        //                objOracleCommand.Parameters.Add("P_TRAINING_PERIOD_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.TrainingPeriodId;

        //            }
        //            else
        //            {
        //                objOracleCommand.Parameters.Add("P_TRAINING_PERIOD_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            }

        //            if (objEmployeeDTO.PaymentTypeId.Length > 0)
        //            {
        //                objOracleCommand.Parameters.Add("P_PAYMENT_TYPE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.PaymentTypeId;

        //            }
        //            else
        //            {
        //                objOracleCommand.Parameters.Add("P_PAYMENT_TYPE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            }



        //            if (objEmployeeDTO.AccountNo != "")
        //            {
        //                objOracleCommand.Parameters.Add("P_ACCOUNT_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.AccountNo;

        //            }
        //            else
        //            {
        //                objOracleCommand.Parameters.Add("P_ACCOUNT_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            }


        //            if (objEmployeeDTO.GrossSalary != "")
        //            {
        //                objOracleCommand.Parameters.Add("P_GROSS_SALARY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.GrossSalary;

        //            }
        //            else
        //            {
        //                objOracleCommand.Parameters.Add("P_GROSS_SALARY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            }


        //            if (objEmployeeDTO.ReportingTo != "")
        //            {
        //                objOracleCommand.Parameters.Add("P_REPORTING_TO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.ReportingTo;

        //            }
        //            else
        //            {
        //                objOracleCommand.Parameters.Add("P_REPORTING_TO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            }

        //            if (objEmployeeDTO.ApprovedBY.Length > 0)
        //            {
        //                objOracleCommand.Parameters.Add("P_APPROVED_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.ApprovedBY;

        //            }
        //            else
        //            {
        //                objOracleCommand.Parameters.Add("P_APPROVED_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            }


        //            if (objEmployeeDTO.ReferenceBy.Length > 0)
        //            {
        //                objOracleCommand.Parameters.Add("P_REFERENCE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.ReferenceBy;

        //            }
        //            else
        //            {
        //                objOracleCommand.Parameters.Add("P_REFERENCE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            }

        //            if (objEmployeeDTO.JoiningSalary != "")
        //            {
        //                objOracleCommand.Parameters.Add("P_JOINING_SALARY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.JoiningSalary;

        //            }
        //            else
        //            {
        //                objOracleCommand.Parameters.Add("P_JOINING_SALARY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            }

        //            if (objEmployeeDTO.JoiningDesignationId != "")
        //            {
        //                objOracleCommand.Parameters.Add("P_JOINING_DESIGNATION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.JoiningDesignationId;

        //            }
        //            else
        //            {
        //                objOracleCommand.Parameters.Add("P_JOINING_DESIGNATION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            }

        //            if (objEmployeeDTO.AllowanceAmount != "")
        //            {
        //                objOracleCommand.Parameters.Add("P_ALLOWANCE_AMOUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.AllowanceAmount;

        //            }
        //            else
        //            {
        //                objOracleCommand.Parameters.Add("P_ALLOWANCE_AMOUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            }


        //            if (objEmployeeDTO.ConfirmDate.Length > 6 )
        //            {
        //                objOracleCommand.Parameters.Add("P_CONFIRM_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.ConfirmDate;

        //            }
        //            else
        //            {
        //                objOracleCommand.Parameters.Add("P_CONFIRM_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            }

        //            if (objEmployeeDTO.DepartmentId != "")
        //            {
        //                objOracleCommand.Parameters.Add("P_DEPARTMENT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.DepartmentId;

        //            }
        //            else
        //            {
        //                objOracleCommand.Parameters.Add("P_DEPARTMENT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            }



        //            // //----------------------------------------------Pre Job Expreience---------------------------------------------------------//

        //            //if (objEmployeeDTO.OrganizationName != "")
        //            //{
        //            //    objOracleCommand.Parameters.Add("P_ORGANIZATION_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.OrganizationName;

        //            //}
        //            //else
        //            //{
        //            //    objOracleCommand.Parameters.Add("P_ORGANIZATION_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            //}


        //            //if (objEmployeeDTO.PreDepartmentId.Length > 0)
        //            //{
        //            //    objOracleCommand.Parameters.Add("P_PRE_DEPARTMENT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.PreDepartmentId;

        //            //}
        //            //else
        //            //{
        //            //    objOracleCommand.Parameters.Add("P_PRE_DEPARTMENT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            //}

        //            //if (objEmployeeDTO.PreDesignationId.Length > 0)
        //            //{
        //            //    objOracleCommand.Parameters.Add("P_PRE_DESIGNATION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.PreDesignationId;

        //            //}
        //            //else
        //            //{
        //            //    objOracleCommand.Parameters.Add("P_PRE_DESIGNATION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            //}

        //            //if (objEmployeeDTO.WorkingDuration != "")
        //            //{
        //            //    objOracleCommand.Parameters.Add("P_WORKING_DURATION", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.WorkingDuration;

        //            //}
        //            //else
        //            //{
        //            //    objOracleCommand.Parameters.Add("P_WORKING_DURATION", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            //}

        //            //if (objEmployeeDTO.YearOfExperience != "")
        //            //{
        //            //    objOracleCommand.Parameters.Add("P_YEAR_OF_EXPERIENCE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.YearOfExperience;

        //            //}
        //            //else
        //            //{
        //            //    objOracleCommand.Parameters.Add("P_YEAR_OF_EXPERIENCE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            //}


        //            //if (objEmployeeDTO.LeaveYear != "")
        //            //{
        //            //    objOracleCommand.Parameters.Add("P_LEAVE_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.LeaveYear;

        //            //}
        //            //else
        //            //{
        //            //    objOracleCommand.Parameters.Add("P_LEAVE_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            //}



        //            //if (objEmployeeDTO.LeaveMonth != "")
        //            //{
        //            //    objOracleCommand.Parameters.Add("P_LEAVE_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.LeaveMonth;

        //            //}
        //            //else
        //            //{
        //            //    objOracleCommand.Parameters.Add("P_LEAVE_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            //}

        //            //if (objEmployeeDTO.LeaveDate != "")
        //            //{
        //            //    objOracleCommand.Parameters.Add("P_LEAVE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.LeaveDate;

        //            //}
        //            //else
        //            //{
        //            //    objOracleCommand.Parameters.Add("P_LEAVE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            //}

        //            //if (objEmployeeDTO.LeavingReson != "")
        //            //{
        //            //    objOracleCommand.Parameters.Add("P_LEAVING_REASON", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.LeavingReson;

        //            //}
        //            //else
        //            //{
        //            //    objOracleCommand.Parameters.Add("P_LEAVING_REASON", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

        //            //}




        //            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UpdateBy;
        //            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
        //            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;


        //            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

        //            using (OracleConnection strConn = GetConnection())
        //            {
        //                try
        //                {
        //                    objOracleCommand.Connection = strConn;
        //                    strConn.Open();
        //                    trans = strConn.BeginTransaction();
        //                    objOracleCommand.ExecuteNonQuery();
        //                    trans.Commit();
        //                    strConn.Close();
        //                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
        //                }

        //                catch (Exception ex)
        //                {
        //                    throw new Exception("Error : " + ex.Message);
        //                    trans.Rollback();
        //                }

        //                finally
        //                {

        //                    strConn.Close();
        //                }

        //            }

        //            return strMsg;


        //        }

        //added on 14.03.2020

        public string LogSchedule(string infoType, string info)
        {
            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("SCHEDULE_LOG_SAVE");

            objOracleCommand.CommandType = CommandType.StoredProcedure;
            objOracleCommand.Parameters.Add("p_info_type", OracleDbType.Varchar2, ParameterDirection.Input).Value = infoType;
            objOracleCommand.Parameters.Add("P_INFO", OracleDbType.Varchar2, ParameterDirection.Input).Value = info;            
            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    trans = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    trans.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
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
            return strMsg;
        }

        public string saveEmployeeInfo(EmployeeDTO objEmployeeDTO, out string EmpId)
        {
            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("pro_employee_basic_info_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objEmployeeDTO.EmployeeId != "")
            {
                objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.CardNo != "")
            {
                objOracleCommand.Parameters.Add("P_CARD_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CardNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_CARD_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objEmployeeDTO.TitleId.Length > 0)
            {
                objOracleCommand.Parameters.Add("P_TITLE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.TitleId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_TITLE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.EmployeeName != "")
            {
                objOracleCommand.Parameters.Add("P_EMPLOYEE_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeName;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_EMPLOYEE_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.EmployeeNameBangla != "")
            {
                objOracleCommand.Parameters.Add("P_EMPLOYEE_NAME_BANGLA", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeNameBangla;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_EMPLOYEE_NAME_BANGLA", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.FatherName != "")
            {
                objOracleCommand.Parameters.Add("P_FATHER_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.FatherName;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_FATHER_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.MotherName != "")
            {
                objOracleCommand.Parameters.Add("P_MOTHER_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.MotherName;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_MOTHER_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.DateOfBirth.Length > 6)
            {
                objOracleCommand.Parameters.Add("P_DATE_OF_BIRTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.DateOfBirth;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_DATE_OF_BIRTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.HusbandName != "")
            {
                objOracleCommand.Parameters.Add("P_HUSBAND_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HusbandName;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_HUSBAND_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.HusbandOccupation != "")
            {
                objOracleCommand.Parameters.Add("P_HUSBAND_OCCUPATION", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HusbandOccupation;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_HUSBAND_OCCUPATION", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeDTO.GenderId.Length > 0)
            {
                objOracleCommand.Parameters.Add("P_GENDER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.GenderId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_GENDER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.MaritalStatusId.Length > 0)
            {
                objOracleCommand.Parameters.Add("P_MARITAL_STATUS_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.MaritalStatusId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_MARITAL_STATUS_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.ReligionId.Length > 0)
            {
                objOracleCommand.Parameters.Add("P_RELIGION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.ReligionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_RELIGION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.NationaLityId.Length > 0)
            {
                objOracleCommand.Parameters.Add("P_NATIONALITY_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.NationaLityId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_NATIONALITY_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.BloodGroupId.Length > 0)
            {
                objOracleCommand.Parameters.Add("P_BLOOD_GROUP_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BloodGroupId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_BLOOD_GROUP_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.DistrictId.Length > 0)
            {
                objOracleCommand.Parameters.Add("P_DISTRICT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.DistrictId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_DISTRICT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.DivisionId.Length > 0)
            {
                objOracleCommand.Parameters.Add("P_DIVISION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.DivisionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_DIVISION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeDTO.FirstSalary != "")
            {
                objOracleCommand.Parameters.Add("P_FIRST_SALARY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.FirstSalary;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_FIRST_SALARY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            //added on 07.04.2022
            if (objEmployeeDTO.HiddenSalary != "")
            {
                objOracleCommand.Parameters.Add("P_HIDDEN_SALARY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HiddenSalary;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_HIDDEN_SALARY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeDTO.PresentAddress != "")
            {
                objOracleCommand.Parameters.Add("P_PRESENT_ADDRESS", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.PresentAddress;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PRESENT_ADDRESS", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.PermanentAddress != "")
            {
                objOracleCommand.Parameters.Add("P_PERMANANENT_ADDRESS", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.PermanentAddress;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PERMANANENT_ADDRESS", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.PresentAddressBangla != "")
            {
                objOracleCommand.Parameters.Add("P_PRESENT_ADDRESS_BANGLA", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.PresentAddressBangla;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PRESENT_ADDRESS_BANGLA", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.PermanentAddressBangla != "")
            {
                objOracleCommand.Parameters.Add("P_PERMANENT_ADDRESS_BANGLA", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.PermanentAddressBangla;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PERMANENT_ADDRESS_BANGLA", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.TinNo != "")
            {
                objOracleCommand.Parameters.Add("P_TIN_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.TinNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_TIN_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeDTO.MobileNo != "")
            {
                objOracleCommand.Parameters.Add("P_MOBILE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.MobileNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_MOBILE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeDTO.PhoneNo != "")
            {
                objOracleCommand.Parameters.Add("P_PHONE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.PhoneNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PHONE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.EmailAddress != "")
            {
                objOracleCommand.Parameters.Add("P_EMAIL_ADDRESS", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmailAddress;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_EMAIL_ADDRESS", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeDTO.EmergencyContactNo != "")
            {
                objOracleCommand.Parameters.Add("P_EMERGENCY_CONTACT_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmergencyContactNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_EMERGENCY_CONTACT_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeDTO.EmployeeActiveYn != "")
            {
                objOracleCommand.Parameters.Add("P_ACTIVE_YN", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeActiveYn;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_ACTIVE_YN", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeDTO.PaymentYn != "")
            {
                objOracleCommand.Parameters.Add("P_PAYMENT_YN", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.PaymentYn;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PAYMENT_YN", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeDTO.PunchCode != "")
            {
                objOracleCommand.Parameters.Add("P_PUNCH_CODE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.PunchCode;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PUNCH_CODE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeDTO.ResignDate.Length > 6)
            {
                objOracleCommand.Parameters.Add("P_RESIGN_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.ResignDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_RESIGN_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeDTO.ResignCasuse != "")
            {
                objOracleCommand.Parameters.Add("P_RESIGN_CAUSE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.ResignCasuse;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_RESIGN_CAUSE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.NIDNo != "")
            {
                objOracleCommand.Parameters.Add("P_NID_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.NIDNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_NID_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
           
            
            if (objEmployeeDTO.JobTypeId.Length > 0)
            {
                objOracleCommand.Parameters.Add("P_JOB_TYPE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.JobTypeId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_JOB_TYPE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.JoiningDate.Length > 6)
            {
                objOracleCommand.Parameters.Add("P_JOINING_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.JoiningDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_JOINING_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.EffectiveDate.Length > 6)
            {
                objOracleCommand.Parameters.Add("P_EFFECTIVE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EffectiveDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_EFFECTIVE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.OrderDate.Length > 6)
            {
                objOracleCommand.Parameters.Add("P_ORDER_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.OrderDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_ORDER_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.OccurenceTypeId.Length > 0)
            {
                objOracleCommand.Parameters.Add("P_OCCURENCE_TYPE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.OccurenceTypeId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_OCCURENCE_TYPE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeDTO.UnitId.Length > 0)
            {
                objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.SectionId.Length > 0)
            {
                objOracleCommand.Parameters.Add("P_SECTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SECTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.DesignationId.Length > 0)
            {
                objOracleCommand.Parameters.Add("P_DESIGNATION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.DesignationId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_DESIGNATION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.CatagoryId.Length > 0)
            {
                objOracleCommand.Parameters.Add("P_CATAGORY_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CatagoryId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_CATAGORY_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.ShiftId.Length > 0)
            {
                objOracleCommand.Parameters.Add("P_SHIFT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.ShiftId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SHIFT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.JobLocationId.Length > 0)
            {
                objOracleCommand.Parameters.Add("P_JOB_LOCATION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.JobLocationId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_JOB_LOCATION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.GradeNo != "")
            {
                objOracleCommand.Parameters.Add("P_GRADE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.GradeNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_GRADE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.EmployeeTypeId.Length > 0)
            {
                objOracleCommand.Parameters.Add("P_EMPLOYEE_TYPE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeTypeId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_EMPLOYEE_TYPE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.TrainingPeriodId.Length > 0)
            {
                objOracleCommand.Parameters.Add("P_TRAINING_PERIOD_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.TrainingPeriodId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_TRAINING_PERIOD_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.PaymentTypeId.Length > 0)
            {
                objOracleCommand.Parameters.Add("P_PAYMENT_TYPE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.PaymentTypeId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PAYMENT_TYPE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            ///
            if (objEmployeeDTO.BankId != "")
            {
                objOracleCommand.Parameters.Add("P_BANK_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BankId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_BANK_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeDTO.AccountNo != "")
            {
                objOracleCommand.Parameters.Add("P_ACCOUNT_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.AccountNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_ACCOUNT_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            if (objEmployeeDTO.GrossSalary != "")
            {
                objOracleCommand.Parameters.Add("P_GROSS_SALARY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.GrossSalary;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_GROSS_SALARY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.ReportingTo != "")
            {
                objOracleCommand.Parameters.Add("P_REPORTING_TO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.ReportingTo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_REPORTING_TO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.ApprovedBY.Length > 0)
            {
                objOracleCommand.Parameters.Add("P_APPROVED_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.ApprovedBY;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_APPROVED_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.ReferenceBy.Length > 0)
            {
                objOracleCommand.Parameters.Add("P_REFERENCE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.ReferenceBy;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_REFERENCE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.JoiningSalary != "")
            {
                objOracleCommand.Parameters.Add("P_JOINING_SALARY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.JoiningSalary;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_JOINING_SALARY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.JoiningDesignationId != "")
            {
                objOracleCommand.Parameters.Add("P_JOINING_DESIGNATION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.JoiningDesignationId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_JOINING_DESIGNATION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.AllowanceAmount != "")
            {
                objOracleCommand.Parameters.Add("P_ALLOWANCE_AMOUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.AllowanceAmount;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_ALLOWANCE_AMOUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.ConfirmDate.Length > 6)
            {
                objOracleCommand.Parameters.Add("P_CONFIRM_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.ConfirmDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_CONFIRM_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.DepartmentId != "")
            {
                objOracleCommand.Parameters.Add("P_DEPARTMENT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.DepartmentId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_DEPARTMENT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            
            if (objEmployeeDTO.BirthRegistrationNo != "")
            {
                objOracleCommand.Parameters.Add("P_BIRTH_REG_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BirthRegistrationNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_BIRTH_REG_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.BKashNo != "")
            {
                objOracleCommand.Parameters.Add("P_BKASH_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BKashNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_BKASH_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.RocketNo != "")
            {
                objOracleCommand.Parameters.Add("P_ROCKET_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.RocketNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_ROCKET_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.FatherNameBangla != "")
            {
                objOracleCommand.Parameters.Add("P_FATHER_NAME_BANGLA", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.FatherNameBangla;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_FATHER_NAME_BANGLA", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.MotherNameBangla != "")
            {
                objOracleCommand.Parameters.Add("P_MOTHER_NAME_BANGLA", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.MotherNameBangla;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_MOTHER_NAME_BANGLA", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeDTO.SittingBranchOfficeId.Length > 0)
            {
                objOracleCommand.Parameters.Add("P_SITTING_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SittingBranchOfficeId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SITTING_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.IdCardNo != "")
            {
                objOracleCommand.Parameters.Add("P_ID_CARD_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.IdCardNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_ID_CARD_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.CompanyId.Length > 0)
            {
                objOracleCommand.Parameters.Add("P_COMPANY_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CompanyId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_COMPANY_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;
            objOracleCommand.Parameters.Add("P_EMP_ID", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    trans = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    trans.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
                    EmpId = objOracleCommand.Parameters["P_EMP_ID"].Value.ToString();
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
            return strMsg;
        }
        public string UpdateEmployeeInfo(EmployeeDTO objEmployeeDTO)
        {
            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("sp_update_employee_basic");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objEmployeeDTO.EmployeeId != "")
            {
                objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            
            if (objEmployeeDTO.TitleId.Length > 0)
            {
                objOracleCommand.Parameters.Add("P_TITLE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.TitleId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_TITLE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }           
            if (objEmployeeDTO.EmployeeNameBangla != "")
            {
                objOracleCommand.Parameters.Add("P_EMPLOYEE_NAME_BANGLA", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeNameBangla;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_EMPLOYEE_NAME_BANGLA", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.FatherName != "")
            {
                objOracleCommand.Parameters.Add("P_FATHER_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.FatherName;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_FATHER_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.MotherName != "")
            {
                objOracleCommand.Parameters.Add("P_MOTHER_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.MotherName;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_MOTHER_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.DateOfBirth.Length > 6)
            {
                objOracleCommand.Parameters.Add("P_DATE_OF_BIRTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.DateOfBirth;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_DATE_OF_BIRTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.HusbandName != "")
            {
                objOracleCommand.Parameters.Add("P_HUSBAND_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HusbandName;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_HUSBAND_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.HusbandOccupation != "")
            {
                objOracleCommand.Parameters.Add("P_HUSBAND_OCCUPATION", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HusbandOccupation;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_HUSBAND_OCCUPATION", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeDTO.GenderId.Length > 0)
            {
                objOracleCommand.Parameters.Add("P_GENDER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.GenderId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_GENDER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.MaritalStatusId.Length > 0)
            {
                objOracleCommand.Parameters.Add("P_MARITAL_STATUS_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.MaritalStatusId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_MARITAL_STATUS_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.ReligionId.Length > 0)
            {
                objOracleCommand.Parameters.Add("P_RELIGION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.ReligionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_RELIGION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.NationaLityId.Length > 0)
            {
                objOracleCommand.Parameters.Add("P_NATIONALITY_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.NationaLityId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_NATIONALITY_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.BloodGroupId.Length > 0)
            {
                objOracleCommand.Parameters.Add("P_BLOOD_GROUP_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BloodGroupId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_BLOOD_GROUP_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.DistrictId.Length > 0)
            {
                objOracleCommand.Parameters.Add("P_DISTRICT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.DistrictId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_DISTRICT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.DivisionId.Length > 0)
            {
                objOracleCommand.Parameters.Add("P_DIVISION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.DivisionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_DIVISION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
           
            if (objEmployeeDTO.PresentAddress != "")
            {
                objOracleCommand.Parameters.Add("P_PRESENT_ADDRESS", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.PresentAddress;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PRESENT_ADDRESS", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.PermanentAddress != "")
            {
                objOracleCommand.Parameters.Add("P_PERMANANENT_ADDRESS", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.PermanentAddress;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PERMANANENT_ADDRESS", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.PresentAddressBangla != "")
            {
                objOracleCommand.Parameters.Add("P_PRESENT_ADDRESS_BANGLA", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.PresentAddressBangla;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PRESENT_ADDRESS_BANGLA", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.PermanentAddressBangla != "")
            {
                objOracleCommand.Parameters.Add("P_PERMANENT_ADDRESS_BANGLA", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.PermanentAddressBangla;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PERMANENT_ADDRESS_BANGLA", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.TinNo != "")
            {
                objOracleCommand.Parameters.Add("P_TIN_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.TinNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_TIN_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeDTO.MobileNo != "")
            {
                objOracleCommand.Parameters.Add("P_MOBILE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.MobileNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_MOBILE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeDTO.PhoneNo != "")
            {
                objOracleCommand.Parameters.Add("P_PHONE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.PhoneNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PHONE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.EmailAddress != "")
            {
                objOracleCommand.Parameters.Add("P_EMAIL_ADDRESS", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmailAddress;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_EMAIL_ADDRESS", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeDTO.EmergencyContactNo != "")
            {
                objOracleCommand.Parameters.Add("P_EMERGENCY_CONTACT_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmergencyContactNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_EMERGENCY_CONTACT_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeDTO.NIDNo != "")
            {
                objOracleCommand.Parameters.Add("P_NID_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.NIDNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_NID_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeDTO.BirthRegistrationNo != "")
            {
                objOracleCommand.Parameters.Add("P_BIRTH_REG_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BirthRegistrationNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_BIRTH_REG_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            
            if (objEmployeeDTO.FatherNameBangla != "")
            {
                objOracleCommand.Parameters.Add("P_FATHER_NAME_BANGLA", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.FatherNameBangla;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_FATHER_NAME_BANGLA", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.MotherNameBangla != "")
            {
                objOracleCommand.Parameters.Add("P_MOTHER_NAME_BANGLA", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.MotherNameBangla;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_MOTHER_NAME_BANGLA", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;            
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    trans = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    trans.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
                    
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
            return strMsg;
        }


        public string SaveImage(EmployeeDTO objEmployeeDTO)
         {

             string strMsg = "";
             OracleTransaction trans = null;

             OracleCommand objOracleCommand = new OracleCommand("PRO_EMPLOYEE_IMAGE_SAVE");

             objOracleCommand.CommandType = CommandType.StoredProcedure;

             if (objEmployeeDTO.EmployeeId != "")
             {
                 objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;
             }
             else
             {
                 objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
             }

                objOracleCommand.Parameters.Add("P_EMPLOYEE_PIC", OracleDbType.Blob, ParameterDirection.Input).Value = objEmployeeDTO.EmployeePic;

            //if (objEmployeeDTO.EmployeePicture != "")
            //{
            //    byte[] array = System.Convert.FromBase64String(objEmployeeDTO.EmployeePicture);
            //    objOracleCommand.Parameters.Add("P_EMPLOYEE_PIC", OracleDbType.Blob, ParameterDirection.Input).Value = array;
            //}
            //else
            //{
            //    objOracleCommand.Parameters.Add("P_EMPLOYEE_PIC", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            //}
            if (objEmployeeDTO.FileName != "")
             {
                 objOracleCommand.Parameters.Add("P_IMAGE_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.FileName;
             }
             else
             {
                 objOracleCommand.Parameters.Add("P_IMAGE_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
             }
             if (objEmployeeDTO.ImageType != "")
             {
                 objOracleCommand.Parameters.Add("P_IMAGE_EXTENSION", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.ImageType;
             }
             else
             {
                 objOracleCommand.Parameters.Add("P_IMAGE_EXTENSION", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
             }

             objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UpdateBy;
             objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
             objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
             objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objOracleCommand.Connection = strConn;
                     strConn.Open();
                     trans = strConn.BeginTransaction();
                     objOracleCommand.ExecuteNonQuery();
                     trans.Commit();
                     strConn.Close();
                     strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
                 }

                 catch (Exception ex)
                 {
                     throw new Exception("Error : " + ex.Message);
                     trans.Rollback();
                 }

                 finally
                 {
                     strConn.Close();
                 }
             }

             return strMsg;
         }

        //New
        public string SaveSignatureImage(EmployeeDTO objEmployeeDTO)
        {

            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("PRO_SIGNATURE_IMAGE_SAVE");

            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objEmployeeDTO.EmployeeId != "")
            {
                objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeDTO.Signature != "")
            {
                byte[] array = System.Convert.FromBase64String(objEmployeeDTO.Signature);
                objOracleCommand.Parameters.Add("P_signature", OracleDbType.Blob, ParameterDirection.Input).Value = array;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_signature", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.SignatureImageName != "")
            {
                objOracleCommand.Parameters.Add("P_sig_image_name", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SignatureImageName;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_sig_image_name", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.SignatureImageType != "")
            {
                objOracleCommand.Parameters.Add("P_sig_image_extension", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SignatureImageType;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_sig_image_extension", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    trans = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    trans.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
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

            return strMsg;
        }

        public string EmployeeLeaveSave(LeaveDTO objLeaveDTO)
         {

             string strMsg = "";
             OracleTransaction trans = null;

             OracleCommand objOracleCommand = new OracleCommand("PRO_EMPLOYEE_LEAVE_FILE_SAVE");

             objOracleCommand.CommandType = CommandType.StoredProcedure;

             if (objLeaveDTO.EmployeeId != "")
             {
                 objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLeaveDTO.EmployeeId;
             }
             else
             {
                 objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
             }

             if (objLeaveDTO.LeaveYear != "")
             {
                 objOracleCommand.Parameters.Add("P_LEAVE_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLeaveDTO.LeaveYear;
             }
             else
             {
                 objOracleCommand.Parameters.Add("P_LEAVE_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
             }

             if (objLeaveDTO.FromDate != "")
             {
                 objOracleCommand.Parameters.Add("P_LEAVE_START_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLeaveDTO.FromDate;
             }
             else
             {
                 objOracleCommand.Parameters.Add("P_LEAVE_START_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
             }

             if (objLeaveDTO.ToDate != "")
             {
                 objOracleCommand.Parameters.Add("P_LEAVE_END_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLeaveDTO.ToDate;
             }
             else
             {
                 objOracleCommand.Parameters.Add("P_LEAVE_END_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
             }

             if (objLeaveDTO.FileName != "")
             {
                 objOracleCommand.Parameters.Add("P_FILE_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLeaveDTO.FileName;
             }
             else
             {
                 objOracleCommand.Parameters.Add("P_FILE_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
             }

             objOracleCommand.Parameters.Add("P_FILE_SIZE", OracleDbType.Blob, ParameterDirection.Input).Value = objLeaveDTO.FileSize;

            //if (objLeaveDTO.FileSize != "")
            //{
            //    byte[] array = System.Convert.FromBase64String(objEmployeeDTO.FileSize);
            //    objOracleCommand.Parameters.Add("P_FILE_SIZE", OracleDbType.Blob, ParameterDirection.Input).Value = array;
            //}
            //else
            //{
            //    objOracleCommand.Parameters.Add("P_FILE_SIZE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            //}

            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLeaveDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLeaveDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLeaveDTO.BranchOfficeId;

            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;
            //objOracleCommand.Parameters.Add("p_emp_id", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

            using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objOracleCommand.Connection = strConn;
                     strConn.Open();
                     trans = strConn.BeginTransaction();
                     objOracleCommand.ExecuteNonQuery();
                     trans.Commit();
                     strConn.Close();
                     strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
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
             return strMsg;
         }
        public string uploadEmployeeDesFile(EmployeeDTO objEmployeeDTO)
        {


            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("PRO_EMPLOYEE_WORK_FILE_SAVE");

            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objEmployeeDTO.EmployeeId != "")
            {
                objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objEmployeeDTO.FileName != "")
            {
                objOracleCommand.Parameters.Add("P_FILE_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.FileName;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_FILE_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objEmployeeDTO.FileSize != "")
            {

                byte[] array = System.Convert.FromBase64String(objEmployeeDTO.FileSize);
                objOracleCommand.Parameters.Add("P_FILE_SIZE", OracleDbType.Blob, ParameterDirection.Input).Value = array;




            }
            else
            {
                objOracleCommand.Parameters.Add("P_FILE_SIZE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }





            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;


            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    trans = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    trans.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
                }

                catch (Exception ex)
                {
                    throw new Exception("Error : " + ex.Message);
                    trans.Rollback();
                }

                finally
                {

                    strConn.Close();
                }

            }

            return strMsg;


        }
        public string saveActiveEmployee(EmployeeDTO objEmployeeDTO)
         {


             string strMsg = "";
             OracleTransaction trans = null;

             OracleCommand objOracleCommand = new OracleCommand("pro_active_employee");

             objOracleCommand.CommandType = CommandType.StoredProcedure;

           
             objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;

             objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UpdateBy;
             objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
             objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;


             objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objOracleCommand.Connection = strConn;
                     strConn.Open();
                     trans = strConn.BeginTransaction();
                     objOracleCommand.ExecuteNonQuery();
                     trans.Commit();
                     strConn.Close();
                     strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
                 }

                 catch (Exception ex)
                 {
                     throw new Exception("Error : " + ex.Message);
                     trans.Rollback();
                 }

                 finally
                 {

                     strConn.Close();
                 }

             }

             return strMsg;


         }
         public string saveCounselingInfo(EmployeeDTO objEmployeeDTO)
         {


             string strMsg = "";
             OracleTransaction trans = null;

             OracleCommand objOracleCommand = new OracleCommand("pro_employee_counseling_save");

             objOracleCommand.CommandType = CommandType.StoredProcedure;


             objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;
             objOracleCommand.Parameters.Add("P_counseling_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.VerificationDate;
             objOracleCommand.Parameters.Add("P_remarks", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Remarks;

             if (objEmployeeDTO.DHURange != "")
             {
                 objOracleCommand.Parameters.Add("p_dhu", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.DHURange;
             }
             else
             {
                 objOracleCommand.Parameters.Add("p_dhu", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.DHURange;

             }


             objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UpdateBy;
             objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
             objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;


             objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objOracleCommand.Connection = strConn;
                     strConn.Open();
                     trans = strConn.BeginTransaction();
                     objOracleCommand.ExecuteNonQuery();
                     trans.Commit();
                     strConn.Close();
                     strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
                 }

                 catch (Exception ex)
                 {
                     throw new Exception("Error : " + ex.Message);
                     trans.Rollback();
                 }

                 finally
                 {

                     strConn.Close();
                 }

             }

             return strMsg;


         }
         public string saveInactiveEmployee(EmployeeDTO objEmployeeDTO)
         {


             string strMsg = "";
             OracleTransaction trans = null;

             OracleCommand objOracleCommand = new OracleCommand("pro_inactive_employee");

             objOracleCommand.CommandType = CommandType.StoredProcedure;


             objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;

             objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UpdateBy;
             objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
             objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;


             objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objOracleCommand.Connection = strConn;
                     strConn.Open();
                     trans = strConn.BeginTransaction();
                     objOracleCommand.ExecuteNonQuery();
                     trans.Commit();
                     strConn.Close();
                     strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
                 }

                 catch (Exception ex)
                 {
                     throw new Exception("Error : " + ex.Message);
                     trans.Rollback();
                 }

                 finally
                 {

                     strConn.Close();
                 }

             }

             return strMsg;


         }

         //old
         public string saveEmployeeCard(EmployeeDTO objEmployeeDTO)
         {

             string strMsg = "";
             OracleTransaction trans = null;

             OracleCommand objOracleCommand = new OracleCommand("pro_employee_id_save");

             objOracleCommand.CommandType = CommandType.StoredProcedure;
            
             objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;

             if(objEmployeeDTO.UnitId != "")
             {
                 objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UnitId;
             }
             else
             {
                 objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

             }

             if (objEmployeeDTO.SectionId != "")
             {

                 objOracleCommand.Parameters.Add("P_SECTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SectionId;

             }
             else
             {
                 objOracleCommand.Parameters.Add("P_SECTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

             }
            //P_ISSUE_DATE
            objOracleCommand.Parameters.Add("P_ISSUE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UpdateBy;
             objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
             objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;


             objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objOracleCommand.Connection = strConn;
                     strConn.Open();
                     trans = strConn.BeginTransaction();
                     objOracleCommand.ExecuteNonQuery();
                     trans.Commit();
                     strConn.Close();
                     strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
                 }

                 catch (Exception ex)
                 {
                     throw new Exception("Error : " + ex.Message);
                     trans.Rollback();
                 }

                 finally
                 {

                     strConn.Close();
                 }

             }

             return strMsg;


         }

        public string SaveIdCard(EmployeeDTO objEmployeeDTO)
        {
            string strMsg = "";
            OracleTransaction trans = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_employee_id_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;
            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;
            if (objEmployeeDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objEmployeeDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("P_SECTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SECTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.IssueDate != "")
            {
                objOracleCommand.Parameters.Add("P_ISSUE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.IssueDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_ISSUE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;

            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    trans = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    trans.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
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
            return strMsg;
        }

        public string SaveCase(EmployeeDTO objEmployeeDTO)
        {
            string strMsg = "";
            OracleTransaction trans = null;
            OracleCommand objOracleCommand = new OracleCommand("sp_save_case_info");
            objOracleCommand.CommandType = CommandType.StoredProcedure;
                          

            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;

            if (objEmployeeDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("P_SECTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SECTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
                        
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UpdateBy;

            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    trans = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    trans.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
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
            return strMsg;
        }

        public string ReorderCase(EmployeeDTO objEmployeeDTO)
        {
            string strMsg = "";
            OracleTransaction trans = null;
            OracleCommand objOracleCommand = new OracleCommand("sp_reorder_case");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;
            objOracleCommand.Parameters.Add("P_DISPLAY_ORDER", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.DisplayOrder;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UpdateBy;

            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    trans = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    trans.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
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
            return strMsg;
        }

        public string RemoveCase(string employeeId)
        {
            string strMsg = "";
            OracleTransaction trans = null;
            OracleCommand objOracleCommand = new OracleCommand("sp_delete_case");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = employeeId;
            
            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    trans = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    trans.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
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
            return strMsg;
        }

        //new
        public string DeleteUnpaidEmployeePermanently(string cacheId, string employeeId, string loggedInEmployee)
        {
            string strMsg = "";
            OracleTransaction trans = null;
            OracleCommand objOracleCommand = new OracleCommand("sp_del_unpaid_emp_permanently");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("P_CACHE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = cacheId;
            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = employeeId;
            objOracleCommand.Parameters.Add("P_LOGGED_IN_EMPLOYEE", OracleDbType.Varchar2, ParameterDirection.Input).Value = loggedInEmployee;
            
            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    trans = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    trans.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
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
            return strMsg;
        }


        public string saveIncrementLetter(EmployeeDTO objEmployeeDTO)
         {


             string strMsg = "";
             OracleTransaction trans = null;

             OracleCommand objOracleCommand = new OracleCommand("pro_inc_letter_save");

             objOracleCommand.CommandType = CommandType.StoredProcedure;


             objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;

             if (objEmployeeDTO.UnitId != "")
             {

                 objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UnitId;

             }
             else
             {
                 objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

             }

             if (objEmployeeDTO.SectionId != "")
             {

                 objOracleCommand.Parameters.Add("P_SECTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SectionId;

             }
             else
             {
                 objOracleCommand.Parameters.Add("P_SECTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

             }

             if (objEmployeeDTO.ApprovedBY != "")
             {

                 objOracleCommand.Parameters.Add("P_APPROVED_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.ApprovedBY;

             }
             else
             {
                 objOracleCommand.Parameters.Add("P_APPROVED_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

             }


             objOracleCommand.Parameters.Add("P_INCREMENT_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Year;

             objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UpdateBy;
             objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
             objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;


             objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objOracleCommand.Connection = strConn;
                     strConn.Open();
                     trans = strConn.BeginTransaction();
                     objOracleCommand.ExecuteNonQuery();
                     trans.Commit();
                     strConn.Close();
                     strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
                 }

                 catch (Exception ex)
                 {
                     throw new Exception("Error : " + ex.Message);
                     trans.Rollback();
                 }

                 finally
                 {

                     strConn.Close();
                 }

             }

             return strMsg;


         }
         public string deleteEmployeeIdCard(EmployeeDTO objEmployeeDTO)
         {


             string strMsg = "";
             OracleTransaction trans = null;

             OracleCommand objOracleCommand = new OracleCommand("pro_employee_id_delete");
             objOracleCommand.CommandType = CommandType.StoredProcedure;
                       

             if (objEmployeeDTO.UnitId != "")
             {

                 objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UnitId;

             }
             else
             {
                 objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

             }

             if (objEmployeeDTO.SectionId != "")
             {

                 objOracleCommand.Parameters.Add("P_SECTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SectionId;

             }
             else
             {
                 objOracleCommand.Parameters.Add("P_SECTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

             }

             objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UpdateBy;
             objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
             objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;


             objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objOracleCommand.Connection = strConn;
                     strConn.Open();
                     trans = strConn.BeginTransaction();
                     objOracleCommand.ExecuteNonQuery();
                     trans.Commit();
                     strConn.Close();
                     strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
                 }

                 catch (Exception ex)
                 {
                     throw new Exception("Error : " + ex.Message);
                     trans.Rollback();
                 }

                 finally
                 {

                     strConn.Close();
                 }

             }

             return strMsg;


         }
         public string deleteIncrementLetter(EmployeeDTO objEmployeeDTO)
         {


             string strMsg = "";
             OracleTransaction trans = null;

             OracleCommand objOracleCommand = new OracleCommand("pro_delete_inc_letter");

             objOracleCommand.CommandType = CommandType.StoredProcedure;


           

             if (objEmployeeDTO.UnitId != "")
             {

                 objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UnitId;

             }
             else
             {
                 objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

             }

             if (objEmployeeDTO.SectionId != "")
             {

                 objOracleCommand.Parameters.Add("P_SECTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SectionId;

             }
             else
             {
                 objOracleCommand.Parameters.Add("P_SECTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

             }

             objOracleCommand.Parameters.Add("P_INCREMENT_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Year;


             objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UpdateBy;
             objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
             objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;


             objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objOracleCommand.Connection = strConn;
                     strConn.Open();
                     trans = strConn.BeginTransaction();
                     objOracleCommand.ExecuteNonQuery();
                     trans.Commit();
                     strConn.Close();
                     strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
                 }

                 catch (Exception ex)
                 {
                     throw new Exception("Error : " + ex.Message);
                     trans.Rollback();
                 }

                 finally
                 {

                     strConn.Close();
                 }

             }

             return strMsg;


         }
         public string saveEmployeeAttendence(EmployeeDTO objEmployeeDTO)
         {


             string strMsg = "";
             OracleTransaction trans = null;
             //old
             OracleCommand objOracleCommand = new OracleCommand("PRO_EMPLOYEE_LOG_TEMP_MANUALLY");
             //new security comment
             //OracleCommand objOracleCommand = new OracleCommand("SP_SAVE_MANUAL_ATTENDANCE");
            
             objOracleCommand.CommandType = CommandType.StoredProcedure;
                        
             if (objEmployeeDTO.EmployeeId != "")
             {
                 objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;
             }
             else
             {
                 objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
             }


             if (objEmployeeDTO.UnitId != "")
             {
                 objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UnitId;
             }
             else
             {
                 objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
             }

             if (objEmployeeDTO.SectionId != "")
             {
                 objOracleCommand.Parameters.Add("P_SECTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SectionId;
             }
             else
             {
                 objOracleCommand.Parameters.Add("P_SECTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
             }

             if (objEmployeeDTO.LogInTime != "")
             {
                 objOracleCommand.Parameters.Add("P_FIRST_IN", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.LogInTime;
             }
             else
             {
                 objOracleCommand.Parameters.Add("P_FIRST_IN", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
             }

             if (objEmployeeDTO.LunchOutTime != "")
             {
                 objOracleCommand.Parameters.Add("P_LUNCH_OUT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.LunchOutTime;

             }
             else
             {
                 objOracleCommand.Parameters.Add("P_LUNCH_OUT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

             }

             if (objEmployeeDTO.LunchInTime != "")
             {
                 objOracleCommand.Parameters.Add("P_LUNCH_IN", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.LunchInTime;

             }
             else
             {
                 objOracleCommand.Parameters.Add("P_LUNCH_IN", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

             }

             if (objEmployeeDTO.FinalOutTime != "")
             {
                 objOracleCommand.Parameters.Add("P_LAST_OUT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.FinalOutTime;
             }
             else
             {
                 objOracleCommand.Parameters.Add("P_LAST_OUT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
             }
                        

            if (objEmployeeDTO.LogDate.Length> 6 )
             {
                 objOracleCommand.Parameters.Add("P_LOG_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.LogDate;
             }
             else
             {
                 objOracleCommand.Parameters.Add("P_LOG_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
             }

            if (objEmployeeDTO.FinalOutDate.Length > 6)
            {
                objOracleCommand.Parameters.Add("P_LAST_OUT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.FinalOutDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_LAST_OUT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            
            if (objEmployeeDTO.AllUnitYn != "")
             {
                 objOracleCommand.Parameters.Add("P_ALL_UNIT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.AllUnitYn;
             }
             else
             {
                 objOracleCommand.Parameters.Add("P_ALL_UNIT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
             }

            //if (objEmployeeDTO.ActiveYn != "")
            //{
            //    objOracleCommand.Parameters.Add("p_active_yn", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.ActiveYn;
            //}
            //else
            //{
            //    objOracleCommand.Parameters.Add("p_active_yn", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            //}

            if (objEmployeeDTO.Remark != "")
             {
                 objOracleCommand.Parameters.Add("P_REMARKS", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Remark;

             }
             else
             {
                 objOracleCommand.Parameters.Add("P_REMARKS", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

             }



             objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UpdateBy;
             objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
             objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;


             objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objOracleCommand.Connection = strConn;
                     strConn.Open();
                     trans = strConn.BeginTransaction();
                     objOracleCommand.ExecuteNonQuery();
                     trans.Commit();
                     strConn.Close();
                     strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
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

             return strMsg;


         }

        public string saveEmployeeAttendenceRemarks(EmployeeDTO objEmployeeDTO)
        {


            string strMsg = "";
            OracleTransaction trans = null;
            //old
            OracleCommand objOracleCommand = new OracleCommand("PRO_EMPLOYEE_LATE_REMARKS");
            //new security comment
            //OracleCommand objOracleCommand = new OracleCommand("SP_SAVE_MANUAL_ATTENDANCE");

            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objEmployeeDTO.EmployeeId != "")
            {
                objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objEmployeeDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("P_SECTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SECTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeDTO.LogInTime != "")
            {
                objOracleCommand.Parameters.Add("P_FIRST_IN", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.LogInTime;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_FIRST_IN", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeDTO.LunchOutTime != "")
            {
                objOracleCommand.Parameters.Add("P_LUNCH_OUT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.LunchOutTime;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_LUNCH_OUT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objEmployeeDTO.LunchInTime != "")
            {
                objOracleCommand.Parameters.Add("P_LUNCH_IN", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.LunchInTime;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_LUNCH_IN", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objEmployeeDTO.FinalOutTime != "")
            {
                objOracleCommand.Parameters.Add("P_LAST_OUT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.FinalOutTime;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_LAST_OUT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objEmployeeDTO.LogDate.Length > 6)
            {
                objOracleCommand.Parameters.Add("P_LOG_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.LogDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_LOG_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeDTO.FinalOutDate.Length > 6)
            {
                objOracleCommand.Parameters.Add("P_LAST_OUT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.FinalOutDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_LAST_OUT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeDTO.AllUnitYn != "")
            {
                objOracleCommand.Parameters.Add("P_ALL_UNIT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.AllUnitYn;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_ALL_UNIT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            //if (objEmployeeDTO.ActiveYn != "")
            //{
            //    objOracleCommand.Parameters.Add("p_active_yn", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.ActiveYn;
            //}
            //else
            //{
            //    objOracleCommand.Parameters.Add("p_active_yn", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            //}

            if (objEmployeeDTO.Remark != "")
            {
                objOracleCommand.Parameters.Add("P_REMARKS", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Remark;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_REMARKS", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }



            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;


            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    trans = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    trans.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
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

            return strMsg;


        }

        public string saveEmployeeAttendenceNewJoin(EmployeeDTO objEmployeeDTO)
        {


            string strMsg = "";
            OracleTransaction trans = null;
            //old
            OracleCommand objOracleCommand = new OracleCommand("PRO_E_LOG_TEMP_MANUALLY_N");
            //new security comment
            //OracleCommand objOracleCommand = new OracleCommand("SP_SAVE_MANUAL_ATTENDANCE");

            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objEmployeeDTO.EmployeeId != "")
            {
                objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objEmployeeDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("P_SECTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SECTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeDTO.LogInTime != "")
            {
                objOracleCommand.Parameters.Add("P_FIRST_IN", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.LogInTime;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_FIRST_IN", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeDTO.LunchOutTime != "")
            {
                objOracleCommand.Parameters.Add("P_LUNCH_OUT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.LunchOutTime;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_LUNCH_OUT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objEmployeeDTO.LunchInTime != "")
            {
                objOracleCommand.Parameters.Add("P_LUNCH_IN", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.LunchInTime;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_LUNCH_IN", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objEmployeeDTO.FinalOutTime != "")
            {
                objOracleCommand.Parameters.Add("P_LAST_OUT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.FinalOutTime;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_LAST_OUT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            if (objEmployeeDTO.LogDate.Length > 6)
            {
                objOracleCommand.Parameters.Add("P_LOG_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.LogDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_LOG_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeDTO.FinalOutDate.Length > 6)
            {
                objOracleCommand.Parameters.Add("P_LAST_OUT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.FinalOutDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_LAST_OUT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeDTO.AllUnitYn != "")
            {
                objOracleCommand.Parameters.Add("P_ALL_UNIT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.AllUnitYn;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_ALL_UNIT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            //if (objEmployeeDTO.ActiveYn != "")
            //{
            //    objOracleCommand.Parameters.Add("p_active_yn", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.ActiveYn;
            //}
            //else
            //{
            //    objOracleCommand.Parameters.Add("p_active_yn", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            //}

            if (objEmployeeDTO.Remark != "")
            {
                objOracleCommand.Parameters.Add("P_REMARKS", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Remark;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_REMARKS", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }



            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;


            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    trans = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    trans.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
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

            return strMsg;


        }
        public string processManualAttendence(EmployeeDTO objEmployeeDTO)
         {
            
            string strMsg = "";
            OracleTransaction trans = null;
            OracleCommand objOracleCommand;

            //new added on 03.01.2021
            objOracleCommand = new OracleCommand("sp_process_manual_attendance");
            //old commented on 03.01.2021
            //objOracleCommand = new OracleCommand("pro_employee_log_process_upd");
            objOracleCommand.CommandType = CommandType.StoredProcedure;
            
             if (objEmployeeDTO.UnitId != "")
             {
                 objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UnitId;
             }
             else
             {
                 objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
             }

             if (objEmployeeDTO.SectionId != "")
             {
                 objOracleCommand.Parameters.Add("P_SECTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SectionId;

             }
             else
             {
                 objOracleCommand.Parameters.Add("P_SECTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

             }



             if (objEmployeeDTO.FromDate.Length > 6)
             {
                 objOracleCommand.Parameters.Add("p_from_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.FromDate;

             }
             else
             {
                 objOracleCommand.Parameters.Add("p_from_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

             }

             if (objEmployeeDTO.ToDate.Length > 6)
             {
                 objOracleCommand.Parameters.Add("p_to_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.ToDate;

             }
             else
             {
                 objOracleCommand.Parameters.Add("p_to_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

             }


             objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UpdateBy;
             objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
             objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;


             objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objOracleCommand.Connection = strConn;
                     strConn.Open();
                     trans = strConn.BeginTransaction();
                     objOracleCommand.ExecuteNonQuery();
                     trans.Commit();
                     strConn.Close();
                     strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
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

             return strMsg;


         }
        public string deleteManualAttendence(EmployeeDTO objEmployeeDTO)
        {


            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("pro_delete_manual_attendenc");

            objOracleCommand.CommandType = CommandType.StoredProcedure;



            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;

            if (objEmployeeDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UnitId;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objEmployeeDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("P_SECTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SectionId;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_SECTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }



            if (objEmployeeDTO.AttendenceDate.Length > 6)
            {
                objOracleCommand.Parameters.Add("p_log_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.AttendenceDate;

            }
            else
            {
                objOracleCommand.Parameters.Add("p_log_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            


            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;


            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    trans = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    trans.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
                }

                catch (Exception ex)
                {
                    throw new Exception("Error : " + ex.Message);
                    trans.Rollback();
                }

                finally
                {

                    strConn.Close();
                }

            }

            return strMsg;


        }
        public string processManualAttendenceForBP(EmployeeDTO objEmployeeDTO)
         {


             string strMsg = "";
             OracleTransaction trans = null;

             OracleCommand objOracleCommand = new OracleCommand("pro_employee_log_bp_upd");

             objOracleCommand.CommandType = CommandType.StoredProcedure;





             if (objEmployeeDTO.UnitId != "")
             {
                 objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UnitId;

             }
             else
             {
                 objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

             }

             if (objEmployeeDTO.SectionId != "")
             {
                 objOracleCommand.Parameters.Add("P_SECTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SectionId;

             }
             else
             {
                 objOracleCommand.Parameters.Add("P_SECTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

             }



             if (objEmployeeDTO.FromDate.Length > 6)
             {
                 objOracleCommand.Parameters.Add("p_from_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.FromDate;

             }
             else
             {
                 objOracleCommand.Parameters.Add("p_from_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

             }

             if (objEmployeeDTO.ToDate.Length > 6)
             {
                 objOracleCommand.Parameters.Add("p_to_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.ToDate;

             }
             else
             {
                 objOracleCommand.Parameters.Add("p_to_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

             }


             objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UpdateBy;
             objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
             objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;


             objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objOracleCommand.Connection = strConn;
                     strConn.Open();
                     trans = strConn.BeginTransaction();
                     objOracleCommand.ExecuteNonQuery();
                     trans.Commit();
                     strConn.Close();
                     strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
                 }

                 catch (Exception ex)
                 {
                     throw new Exception("Error : " + ex.Message);
                     trans.Rollback();
                 }

                 finally
                 {

                     strConn.Close();
                 }

             }

             return strMsg;


         }
         public string addSalaryCertificateInfo(EmployeeDTO objEmployeeDTO)
         {


             string strMsg = "";
             OracleTransaction trans = null;

             OracleCommand objOracleCommand = new OracleCommand("PRO_SALARY_CERTIFICATE_ADD");

             objOracleCommand.CommandType = CommandType.StoredProcedure;

             if (objEmployeeDTO.EmployeeId != "")
             {
                 objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;

             }
             else
             {
                 objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

             }


             objOracleCommand.Parameters.Add("P_CERTIFICATE_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Year;
             objOracleCommand.Parameters.Add("P_CERTIFICATE_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Month;


           
             if (objEmployeeDTO.UnitId != "")
             {
                 objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UnitId;

             }
             else
             {
                 objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

             }

             if (objEmployeeDTO.SectionId != "")
             {
                 objOracleCommand.Parameters.Add("P_SECTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SectionId;

             }
             else
             {
                 objOracleCommand.Parameters.Add("P_SECTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

             }



             if (objEmployeeDTO.ApprovedBY != "")
             {
                 objOracleCommand.Parameters.Add("P_APPROVED_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.ApprovedBY;

             }
             else
             {
                 objOracleCommand.Parameters.Add("P_APPROVED_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

             }



             objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UpdateBy;
             objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
             objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;


             objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objOracleCommand.Connection = strConn;
                     strConn.Open();
                     trans = strConn.BeginTransaction();
                     objOracleCommand.ExecuteNonQuery();
                     trans.Commit();
                     strConn.Close();
                     strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
                 }

                 catch (Exception ex)
                 {
                     throw new Exception("Error : " + ex.Message);
                     trans.Rollback();
                 }

                 finally
                 {

                     strConn.Close();
                 }

             }

             return strMsg;


         }
         public string saveEmployeePreJobInfo(EmployeeDTO objEmployeeDTO)
         {


             string strMsg = "";


             OracleCommand objOracleCommand = new OracleCommand("pro_employee_pre_job_history");

             objOracleCommand.CommandType = CommandType.StoredProcedure;

             if (objEmployeeDTO.EmployeeId != "")
             {
                 objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;

             }
             else
             {
                 objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

             }

             if (objEmployeeDTO.JoiningDate != "")
             {
                 objOracleCommand.Parameters.Add("P_JOINING_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.JoiningDate;

             }
             else
             {
                 objOracleCommand.Parameters.Add("P_JOINING_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

             }


             if (objEmployeeDTO.OrganizationName != "")
             {
                 objOracleCommand.Parameters.Add("P_ORGANIZATION_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.OrganizationName;

             }
             else
             {
                 objOracleCommand.Parameters.Add("P_ORGANIZATION_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

             }


             if (objEmployeeDTO.SectionName != "")
             {
                 objOracleCommand.Parameters.Add("P_SECTION_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SectionName;

             }
             else
             {
                 objOracleCommand.Parameters.Add("P_SECTION_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

             }


             if (objEmployeeDTO.DesignationName != "")
             {
                 objOracleCommand.Parameters.Add("P_DESIGNATION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.DesignationName;

             }
             else
             {
                 objOracleCommand.Parameters.Add("P_DESIGNATION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

             }
             if (objEmployeeDTO.PreSalary != "")
             {
                 objOracleCommand.Parameters.Add("P_PREVIOUS_SALARY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.PreSalary;

             }
             else
             {
                 objOracleCommand.Parameters.Add("P_PREVIOUS_SALARY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

             }

             if (objEmployeeDTO.WorkingDuration != "")
             {
                 objOracleCommand.Parameters.Add("P_WORKING_DURATION", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.WorkingDuration;

             }
             else
             {
                 objOracleCommand.Parameters.Add("P_WORKING_DURATION", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

             }

             if (objEmployeeDTO.YearOfExperience != "")
             {
                 objOracleCommand.Parameters.Add("P_YEAR_OF_EXPERIENCE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.YearOfExperience;

             }
             else
             {
                 objOracleCommand.Parameters.Add("P_YEAR_OF_EXPERIENCE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

             }


             if (objEmployeeDTO.LeaveDate != "")
             {
                 objOracleCommand.Parameters.Add("P_LEAVE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.LeaveDate;

             }
             else
             {
                 objOracleCommand.Parameters.Add("P_LEAVE_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

             }


             if (objEmployeeDTO.LeavingReson != "")
             {
                 objOracleCommand.Parameters.Add("P_LEAVING_REASON", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.LeavingReson;

             }
             else
             {
                 objOracleCommand.Parameters.Add("P_LEAVING_REASON", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

             }


             objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UpdateBy;
             objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
             objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;


             objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objOracleCommand.Connection = strConn;
                     strConn.Open();
                     trans = strConn.BeginTransaction();
                     objOracleCommand.ExecuteNonQuery();
                     trans.Commit();
                     strConn.Close();
                     strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
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
         public string saveEmployeeEducation(EmployeeDTO objEmployeeDTO)
         {


             string strMsg = "";


             OracleCommand objOracleCommand = new OracleCommand("pro_employee_education_history");

             objOracleCommand.CommandType = CommandType.StoredProcedure;

             if (objEmployeeDTO.EmployeeId != "")
             {
                 objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;

             }
             else
             {
                 objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

             }


             if (objEmployeeDTO.CourseId != "")
             {
                 objOracleCommand.Parameters.Add("P_COURSE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CourseId;

             }
             else
             {
                 objOracleCommand.Parameters.Add("P_COURSE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

             }

             if (objEmployeeDTO.InstitueName != "")
             {
                 objOracleCommand.Parameters.Add("P_INSTITUTE_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.InstitueName;

             }
             else
             {
                 objOracleCommand.Parameters.Add("P_INSTITUTE_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

             }




             if (objEmployeeDTO.SubjectId != "")
             {
                 objOracleCommand.Parameters.Add("P_SUBJECT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SubjectId;

             }
             else
             {
                 objOracleCommand.Parameters.Add("P_SUBJECT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

             }



             if (objEmployeeDTO.PassingYear != "")
             {
                 objOracleCommand.Parameters.Add("P_PASSING_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.PassingYear;

             }
             else
             {
                 objOracleCommand.Parameters.Add("P_PASSING_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

             }


             if (objEmployeeDTO.CGPAId != "")
             {
                 objOracleCommand.Parameters.Add("P_CGPA", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CGPAId;

             }
             else
             {
                 objOracleCommand.Parameters.Add("P_CGPA", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

             }


             objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UpdateBy;
             objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
             objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;


             objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objOracleCommand.Connection = strConn;
                     strConn.Open();
                     trans = strConn.BeginTransaction();
                     objOracleCommand.ExecuteNonQuery();
                     trans.Commit();
                     strConn.Close();
                     strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
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

         public string saveSubjectInfo(EmployeeDTO objEmployeeDTO)
         {


             string strMsg = "";


             OracleCommand objOracleCommand = new OracleCommand("pro_subject_save");

             objOracleCommand.CommandType = CommandType.StoredProcedure;

             if (objEmployeeDTO.SubjectId != "")
             {
                 objOracleCommand.Parameters.Add("p_subject_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SubjectId;

             }
             else
             {
                 objOracleCommand.Parameters.Add("p_subject_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

             }


             if (objEmployeeDTO.SubjectName != "")
             {
                 objOracleCommand.Parameters.Add("p_subject_name", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SubjectName;

             }
             else
             {
                 objOracleCommand.Parameters.Add("p_subject_name", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

             }

         


             objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UpdateBy;
             objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
             objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;


             objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objOracleCommand.Connection = strConn;
                     strConn.Open();
                     trans = strConn.BeginTransaction();
                     objOracleCommand.ExecuteNonQuery();
                     trans.Commit();
                     strConn.Close();
                     strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
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

         public string inactiveProcess(EmployeeDTO objEmployeeDTO)
         {


             string strMsg = "";
            
             OracleCommand objOracleCommand = new OracleCommand("pro_inactive_process");
             OracleTransaction trans = null;

             objOracleCommand.CommandType = CommandType.StoredProcedure;
                    
             //if (objEmployeeDTO.UnitId != "")
             //{
             //    objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UnitId;
             //}
             //else
             //{
             //    objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
             //}

             //if (objEmployeeDTO.SectionId != "")
             //{
             //    objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SectionId;
             //}
             //else
             //{
             //    objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
             //}

             objOracleCommand.Parameters.Add("p_inactive_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Year;
             objOracleCommand.Parameters.Add("p_inactive_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Month;

             //if (objEmployeeDTO.InactiveReason != "")
             //{
             //    objOracleCommand.Parameters.Add("p_inactive_reason", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.InactiveReason;
             //}
             //else
             //{
             //    objOracleCommand.Parameters.Add("p_inactive_reason", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
             //}

             objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UpdateBy;
             objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
             objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;

             objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objOracleCommand.Connection = strConn;
                     strConn.Open();
                     trans = strConn.BeginTransaction();
                     objOracleCommand.ExecuteNonQuery();
                     trans.Commit();
                     strConn.Close();
                     strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
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

             return strMsg;


         }
         public string saveEmployeeLogData(EmployeeDTO objEmployeeDTO)
         {

             string strMsg = "";
             OracleTransaction trans = null;
             OracleCommand objOracleCommand = new OracleCommand("pro_employee_log_save");
           
             objOracleCommand.CommandType = CommandType.StoredProcedure;

             if (objEmployeeDTO.CardNo != "")
             {
                 objOracleCommand.Parameters.Add("P_CARD_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CardNo;
             }
             else
             {
                 objOracleCommand.Parameters.Add("P_CARD_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

             }

          
             if (objEmployeeDTO.LogDate.Length > 6)
             {

                 objOracleCommand.Parameters.Add("P_LOG_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.LogDate;

             }
             else
             {

                 objOracleCommand.Parameters.Add("P_LOG_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
             }

             if (objEmployeeDTO.LogTime != "")
             {
                 objOracleCommand.Parameters.Add("P_LOG_TIME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.LogTime;


             }
             else
             {
                 objOracleCommand.Parameters.Add("P_LOG_TIME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;


             }


             objOracleCommand.Parameters.Add("P_FILE_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.FileName;
             objOracleCommand.Parameters.Add("P_FILE_PATH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.FilePath;

             objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UpdateBy;
             objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
             objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
             objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;


             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objOracleCommand.Connection = strConn;
                     strConn.Open();
                     trans = strConn.BeginTransaction();
                     objOracleCommand.ExecuteNonQuery();
                     trans.Commit();
                     strConn.Close();
                     strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
                 }

                 catch (Exception ex)
                 {
                     throw new Exception("Error : " + ex.Message);
                     trans.Rollback();
                 }

                 finally
                 {

                     strConn.Close();
                 }

             }


             return strMsg;


         }
         public string deleteEmployeeLog(EmployeeDTO objEmployeeDTO)
         {

             string strMsg = "";
             OracleTransaction trans = null;
             OracleCommand objOracleCommand = new OracleCommand("pro_delete_employee_log");

             objOracleCommand.CommandType = CommandType.StoredProcedure;



             objOracleCommand.Parameters.Add("P_FILE_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.FileName;
             objOracleCommand.Parameters.Add("p_from_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.FromDate;
             objOracleCommand.Parameters.Add("p_to_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.ToDate;

             objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
             objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
             objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UpdateBy;

             objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;


             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objOracleCommand.Connection = strConn;
                     strConn.Open();
                     //strConn.BeginTransaction();
                     trans = strConn.BeginTransaction();
                     objOracleCommand.ExecuteNonQuery();
                     trans.Commit();
                     strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
                 }

                 catch (Exception ex)
                 {
                     throw new Exception("Error : " + ex.Message);
                     trans.Rollback();
                 }

                 finally
                 {

                     strConn.Close();
                 }

             }


             return strMsg;


         }
         public string employeeLogProcess(EmployeeDTO objEmployeeDTO)
         {

             string strMsg = "";
             OracleTransaction trans = null;
             OracleCommand objOracleCommand = new OracleCommand("pro_employee_log_process");

             objOracleCommand.CommandType = CommandType.StoredProcedure;



             objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
             objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
             objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UpdateBy;

             objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;


             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objOracleCommand.Connection = strConn;
                     strConn.Open();
                     trans = strConn.BeginTransaction();
                     objOracleCommand.ExecuteNonQuery();
                     trans.Commit();
                     strConn.Close();
                     strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
                 }

                 catch (Exception ex)
                 {
                     throw new Exception("Error : " + ex.Message);
                     trans.Rollback();
                 }

                 finally
                 {

                     strConn.Close();
                 }

             }


             return strMsg;


         }
         public string uploadEmpLogData(EmployeeDTO objEmployeeDTO)
         {
             string strMsg = "";


             OracleCommand objOracleCommand = new OracleCommand("pro_upload_employee_log_data");

             objOracleCommand.CommandType = CommandType.StoredProcedure;

             objOracleCommand.Parameters.Add("P_FILE_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.FileName;
             objOracleCommand.Parameters.Add("P_FILE_PATH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.FilePath;


             objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UpdateBy;
             objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
             objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
             objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objOracleCommand.Connection = strConn;
                     strConn.Open();
                     trans = strConn.BeginTransaction();
                     objOracleCommand.ExecuteNonQuery();
                     trans.Commit();
                     strConn.Close();
                     strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
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

         public EmployeeDTO searchEmpLeaveEntry(string strEmployeeId, string strFromDate, string strToDate, string strYear, string strHeadOfficeId, string strBranchOfficeId)
         {


             EmployeeDTO objEmployeeDTO = new EmployeeDTO();
             EmployeeDAL objEmployeeDAL = new EmployeeDAL();

             string sql = "";
             sql = "SELECT " +

                  "TO_CHAR(LEAVE_START_DATE, 'dd/mm/yyyy')LEAVE_START_DATE, " +
                  "TO_CHAR(LEAVE_END_DATE, 'dd/mm/yyyy')LEAVE_END_DATE, " +
                  "TO_CHAR (NVL (LEAVE_TYPE_ID, '0'))LEAVE_TYPE_ID, " +
                  "TO_CHAR (NVL (REMARKS, '0'))REMARKS, " +
                  "TO_CHAR (NVL (APPROVED_BY, '0')) " +


                   "from vew_search_emp_leave where employee_id = '" + strEmployeeId + "' AND LEAVE_START_DATE = to_Date('" + strFromDate + "', 'dd/mm/yyyy') AND LEAVE_END_DATE = to_Date('" + strToDate + "', 'dd/mm/yyyy') and leave_year = '"+strYear+"' and head_office_id = '" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "' ";




             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataReader objDataReader;

             using (OracleConnection strConn = GetConnection())
             {

                 objCommand.Connection = strConn;
                 strConn.Open();
                 objDataReader = objCommand.ExecuteReader();
                 try
                 {
                     while (objDataReader.Read())
                     {


                         objEmployeeDTO.FromDate = objDataReader.GetString(0);
                         objEmployeeDTO.ToDate = objDataReader.GetString(1);
                         objEmployeeDTO.LeaveTypeId = objDataReader.GetString(2);
                         objEmployeeDTO.Remarks = objDataReader.GetString(3);
                         objEmployeeDTO.ApprovedBY = objDataReader.GetString(4);


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








             return objEmployeeDTO;


         }

        //commented on 14.03.2020
        //public EmployeeDTO searchEmployeeInfo(string strEmployeeId, string strCardNo, string strHeadOfficeId, string strBranchOfficeId, string strEmpId)
        //{


        //    EmployeeDTO objEmployeeDTO = new EmployeeDTO();




        //    string sql = "";
        //    sql = "SELECT "+

        //             "TO_CHAR (NVL (card_no, '0')), " +
        //            "TO_CHAR (NVL (employee_name, 'N/A')), " +
        //            "TO_CHAR (NVL (employee_name_bangla, 'N/A')), " +
        //            "TO_CHAR (NVL (father_name, 'N/A')), " +
        //            "TO_CHAR (NVL (mother_name, 'N/A')), " +
        //            "NVL (TO_CHAR (DATE_OF_BIRTH, 'dd/mm/yyyy'), ' '), " +
        //            "TO_CHAR (NVL (gender_id, '0')), " +
        //            "TO_CHAR (NVL (designation_id, '0')), " +

        //            "TO_CHAR (NVL (MARTITAL_STATUS_ID, '0')), " +
        //            "TO_CHAR (NVL (blood_group_id, '0')), " +
        //            "TO_CHAR (NVL (catagory_id, '0')), " +
        //            "TO_CHAR (NVL (husband_name, 'N/A')), " +
        //            "TO_CHAR (NVL (husband_occupation, 'N/A')), " +
        //            "TO_CHAR (NVL (present_address, 'N/A')), " +
        //            "TO_CHAR (NVL (PERMANANENT_ADDRESS, 'N/A')), " +
        //            "TO_CHAR (NVL (TIN_NO, 'N/A')), " +
        //            "TO_CHAR (NVL (mobile_no, '0')), " +
        //            "TO_CHAR (NVL (phone_no, '0')), " +
        //            "TO_CHAR (NVL (email_address, 'N/A')), " +
        //            "TO_CHAR (NVL (unit_id, '0')), " +
        //            "TO_CHAR (NVL (organization_name, 'N/A')), " +
        //            "TO_CHAR (NVL (working_duration, 'N/A')), " +
        //            "TO_CHAR (NVL (year_of_experience, '0')), " +
        //            "TO_CHAR (NVL (leave_year, '0')), " +
        //            "TO_CHAR (NVL (leave_month, '0')), " +
        //            "NVL (TO_CHAR (leave_date, 'dd/mm/yyyy'), ' '), " +
        //            "TO_CHAR (NVL (leaving_reason, '0')), " +
        //            "TO_CHAR (NVL (gross_salary, '0')), " +
        //            "TO_CHAR (NVL (reference_by, '0')), " +
        //            "TO_CHAR (NVL (district_id, '0')), " +
        //            "TO_CHAR (NVL (division_id, '0')), " +
        //            "TO_CHAR (NVL (account_no, '0')), " +
        //             "TO_CHAR (NVL (first_salary, '0')), " +
        //          // "TO_CHAR (NVL (net_salary, '0')), " +
        //            "TO_CHAR (NVL (SECTION_ID, '0')), " +
        //            "TO_CHAR (NVL (JOB_OFFICE_ID, '0')), "+
        //            "TO_CHAR (NVL (VOTER_ID_CARD_NO, '0')), " +
        //            "TO_CHAR (NVL (NATIONALITY_ID, '0')), " +
        //            "NVL (TO_CHAR (ORDER_DATE, 'dd/mm/yyyy'), ' '), " +
        //            "NVL (TO_CHAR (effective_date, 'dd/mm/yyyy'), ' '), " +
        //            "TO_CHAR (NVL (active_yn, '0')), "+
        //            "TO_CHAR (NVL (occurence_type_id, '0')), " +
        //            "NVL (TO_CHAR (joining_date, 'dd/mm/yyyy'), ' '), " +
        //            "TO_CHAR (NVL (TITLE_ID, '0')), " +
        //            "TO_CHAR (NVL (religion_id, '0')), " +
        //            "TO_CHAR (NVL (employee_id, '0')), " +
        //            "TO_CHAR (NVL (JOINING_SALARY, '0')), " +
        //            "TO_CHAR (NVL (JOINING_DESIGNATION_ID, '0')), " +
        //            "TO_CHAR (NVL (EMERGENCY_CONTACT_NO, '0')), " +
        //            "TO_CHAR (NVL (ALLOWANCE_AMOUNT, '0')), " +
        //            "TO_CHAR (NVL (PUNCH_CODE, '0')), " +
        //            "TO_CHAR (NVL (grade_no, '0')), " +

        //            "NVL (TO_CHAR (RESIGN_DATE, 'dd/mm/yyyy'), ' '), " +
        //            "TO_CHAR (NVL (supervisor_id, '0')), " +
        //             "NVL (TO_CHAR (CONFIRM_DATE, 'dd/mm/yyyy'), ' '), " +
        //             "TO_CHAR (NVL (RESIGN_CAUSE, 'N/A')), " +
        //             "TO_CHAR (NVL (department_id, '0')), " +
        //             "TO_CHAR (NVL (employee_type_id, '0')), " +
        //             "TO_CHAR (NVL (TRAINING_PERIOD_ID, '0')), " +
        //             "TO_CHAR (NVL (PAYMENT_TYPE_ID, '0')), " +
        //             "TO_CHAR (NVL (APPROVED_BY, '0')), " +
        //            "TO_CHAR (NVL (JOB_TYPE_ID, '0')), " +
        //            "TO_CHAR (NVL (JOB_LOCATION_ID, '0')), " +
        //            "NVL(grade_number, '0') " +

        //            "from vew_search_employee_detail where employee_id = '" + strEmployeeId + "' and head_office_id = '" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "' ";





        //    if (strEmpId.Length > 0)
        //    {
        //        sql = sql + " AND employee_id = '" + strEmpId + "' ";

        //    }



        //    OracleCommand objCommand = new OracleCommand(sql);
        //    OracleDataReader objDataReader;

        //    using (OracleConnection strConn = GetConnection())
        //    {

        //        objCommand.Connection = strConn;
        //        strConn.Open();
        //        objDataReader = objCommand.ExecuteReader();
        //        try
        //        {
        //            while (objDataReader.Read())
        //            {


        //                objEmployeeDTO.CardNo = objDataReader.GetString(0);
        //                objEmployeeDTO.EmployeeName = objDataReader.GetString(1);
        //                objEmployeeDTO.EmployeeNameBangla = objDataReader.GetString(2);
        //                objEmployeeDTO.FatherName = objDataReader.GetString(3);
        //                objEmployeeDTO.MotherName = objDataReader.GetString(4);
        //                objEmployeeDTO.DateOfBirth = objDataReader.GetString(5);
        //                objEmployeeDTO.GenderId = objDataReader.GetString(6);
        //                objEmployeeDTO.DesignationId = objDataReader.GetString(7);

        //                objEmployeeDTO.MaritalStatusId = objDataReader.GetString(8);
        //                objEmployeeDTO.BloodGroupId = objDataReader.GetString(9);
        //                objEmployeeDTO.CatagoryId = objDataReader.GetString(10);
        //                objEmployeeDTO.HusbandName = objDataReader.GetString(11);
        //                objEmployeeDTO.HusbandOccupation = objDataReader.GetString(12);
        //                objEmployeeDTO.PresentAddress = objDataReader.GetString(13);
        //                objEmployeeDTO.PermanentAddress = objDataReader.GetString(14);
        //               objEmployeeDTO.TinNo = objDataReader.GetString(15);
        //               objEmployeeDTO.MobileNo = objDataReader.GetString(16);
        //                objEmployeeDTO.PhoneNo = objDataReader.GetString(17);
        //                objEmployeeDTO.EmailAddress = objDataReader.GetString(18);

        //                objEmployeeDTO.UnitId = objDataReader.GetString(19);
        //                objEmployeeDTO.OrganizationName = objDataReader.GetString(20);
        //                objEmployeeDTO.WorkingDuration = objDataReader.GetString(21);
        //                objEmployeeDTO.YearOfExperience = objDataReader.GetString(22);
        //                objEmployeeDTO.LeaveYear = objDataReader.GetString(23);
        //                objEmployeeDTO.LeaveMonth = objDataReader.GetString(24);
        //                objEmployeeDTO.LeaveDate = objDataReader.GetString(25);
        //                objEmployeeDTO.LeavingReson = objDataReader.GetString(26);
        //                objEmployeeDTO.GrossSalary = objDataReader.GetString(27);
        //                objEmployeeDTO.ReferenceBy = objDataReader.GetString(28);
        //                objEmployeeDTO.DistrictId = objDataReader.GetString(29);
        //                objEmployeeDTO.DivisionId = objDataReader.GetString(30);

        //                objEmployeeDTO.AccountNo = objDataReader.GetString(31);
        //                objEmployeeDTO.FirstSalary = objDataReader.GetString(32);
        //                objEmployeeDTO.SectionId = objDataReader.GetString(33);
        //                objEmployeeDTO.JobOfficeId = objDataReader.GetString(34);
        //                objEmployeeDTO.VoterIdCardNo = objDataReader.GetString(35);
        //                objEmployeeDTO.NationaLityId = objDataReader.GetString(36);
        //                objEmployeeDTO.OrderDate = objDataReader.GetString(37);
        //                objEmployeeDTO.EffectiveDate = objDataReader.GetString(38);
        //                objEmployeeDTO.EmployeeActiveYn = objDataReader.GetString(39);
        //                objEmployeeDTO.OccurenceTypeId = objDataReader.GetString(40);
        //                objEmployeeDTO.JoiningDate = objDataReader.GetString(41);
        //                objEmployeeDTO.TitleId = objDataReader.GetString(42);
        //                objEmployeeDTO.ReligionId = objDataReader.GetString(43);

        //                objEmployeeDTO.EmployeeId = objDataReader.GetString(44);
        //                objEmployeeDTO.JoiningSalary = objDataReader.GetString(45);
        //                objEmployeeDTO.JoiningDesignationId = objDataReader.GetString(46);
        //                objEmployeeDTO.EmergencyContactNo = objDataReader.GetString(47);
        //                objEmployeeDTO.AllowanceAmount = objDataReader.GetString(48);
        //                objEmployeeDTO.PunchCode = objDataReader.GetString(49);
        //                objEmployeeDTO.GradeNo = objDataReader.GetString(50);
        //                objEmployeeDTO.ResignDate = objDataReader.GetString(51);
        //                objEmployeeDTO.ReportingTo = objDataReader.GetString(52);
        //                objEmployeeDTO.ConfirmDate = objDataReader.GetString(53);
        //                objEmployeeDTO.ResignCasuse = objDataReader.GetString(54);
        //                objEmployeeDTO.DepartmentId = objDataReader.GetString(55);

        //                objEmployeeDTO.EmployeeTypeId = objDataReader.GetString(56);
        //                objEmployeeDTO.TrainingPeriodId = objDataReader.GetString(57);
        //                objEmployeeDTO.PaymentTypeId = objDataReader.GetString(58);
        //                objEmployeeDTO.ApprovedBY = objDataReader.GetString(59);
        //                objEmployeeDTO.JobTypeId = objDataReader.GetString(60);
        //                objEmployeeDTO.JobLocationId = objDataReader.GetString(61);
        //                objEmployeeDTO.grade_number = objDataReader.GetString(62);


        //           }
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception("Error : " + ex.Message);

        //        }

        //        finally
        //        {

        //            strConn.Close();
        //        }

        //    }




        //    return objEmployeeDTO;


        //}

        //added on 14.03.2020
        public EmployeeDTO searchEmployeeInfo(string strEmployeeId, string strCardNo, string strHeadOfficeId, string strBranchOfficeId, string strEmpId)
        {


            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            string sql = "";
            sql = "SELECT " +

                     "TO_CHAR (NVL (card_no, '0')), " +
                    "TO_CHAR (NVL (employee_name, 'N/A')), " +
                    "TO_CHAR (NVL (employee_name_bangla, 'N/A')), " +
                    "TO_CHAR (NVL (father_name, 'N/A')), " +
                    "TO_CHAR (NVL (mother_name, 'N/A')), " +
                    "NVL (TO_CHAR (DATE_OF_BIRTH, 'dd/mm/yyyy'), ' '), " +
                    "TO_CHAR (NVL (gender_id, '0')), " +
                    "TO_CHAR (NVL (designation_id, '0')), " +

                    "TO_CHAR (NVL (MARTITAL_STATUS_ID, '0')), " +
                    "TO_CHAR (NVL (blood_group_id, '0')), " +
                    "TO_CHAR (NVL (catagory_id, '0')), " +
                    "TO_CHAR (NVL (husband_name, 'N/A')), " +
                    "TO_CHAR (NVL (husband_occupation, 'N/A')), " +
                    "TO_CHAR (NVL (present_address, 'N/A')), " +
                    "TO_CHAR (NVL (PERMANANENT_ADDRESS, 'N/A')), " +
                    "TO_CHAR (NVL (present_address_bangla, 'N/A')), " +
                    "TO_CHAR (NVL (PERMANENT_ADDRESS_BANGLA, 'N/A')), " +
                    "TO_CHAR (NVL (TIN_NO, 'N/A')), " +
                    "TO_CHAR (NVL (mobile_no, '0')), " +
                    "TO_CHAR (NVL (phone_no, '0')), " +
                    "TO_CHAR (NVL (email_address, 'N/A')), " +
                    "TO_CHAR (NVL (unit_id, '0')), " +
                    "TO_CHAR (NVL (organization_name, 'N/A')), " +
                    "TO_CHAR (NVL (working_duration, 'N/A')), " +
                    "TO_CHAR (NVL (year_of_experience, '0')), " +
                    "TO_CHAR (NVL (leave_year, '0')), " +
                    "TO_CHAR (NVL (leave_month, '0')), " +
                    "NVL (TO_CHAR (leave_date, 'dd/mm/yyyy'), ' '), " +
                    "TO_CHAR (NVL (leaving_reason, '0')), " +
                    "TO_CHAR (NVL (gross_salary, '0')), " +
                    "TO_CHAR (NVL (reference_by, '0')), " +
                    "TO_CHAR (NVL (district_id, '0')), " +
                    "TO_CHAR (NVL (division_id, '0')), " +
                    "TO_CHAR (NVL (account_no, '0')), " +
                     "TO_CHAR (NVL (first_salary, '0')), " +
                    // "TO_CHAR (NVL (net_salary, '0')), " +
                    "TO_CHAR (NVL (SECTION_ID, '0')), " +
                    "TO_CHAR (NVL (JOB_OFFICE_ID, '0')), " +
                    "TO_CHAR (NVL (NID_NO, '0')), " +
                    "TO_CHAR (NVL (NATIONALITY_ID, '0')), " +
                    "NVL (TO_CHAR (ORDER_DATE, 'dd/mm/yyyy'), ' '), " +
                    "NVL (TO_CHAR (effective_date, 'dd/mm/yyyy'), ' '), " +
                    "TO_CHAR (NVL (active_yn, '0')), " +
                                        
                    "TO_CHAR (NVL (occurence_type_id, '0')), " +
                    "NVL (TO_CHAR (joining_date, 'dd/mm/yyyy'), ' '), " +
                    "TO_CHAR (NVL (TITLE_ID, '0')), " +
                    "TO_CHAR (NVL (religion_id, '0')), " +
                    "TO_CHAR (NVL (employee_id, '0')), " +
                    "TO_CHAR (NVL (JOINING_SALARY, '0')), " +
                    "TO_CHAR (NVL (JOINING_DESIGNATION_ID, '0')), " +
                    "TO_CHAR (NVL (EMERGENCY_CONTACT_NO, '0')), " +
                    "TO_CHAR (NVL (ALLOWANCE_AMOUNT, '0')), " +
                    "TO_CHAR (NVL (PUNCH_CODE, '0')), " +
                    "TO_CHAR (NVL (grade_no, '0')), " +

                    "NVL (TO_CHAR (RESIGN_DATE, 'dd/mm/yyyy'), ' '), " +
                    "TO_CHAR (NVL (supervisor_id, '0')), " +
                     "NVL (TO_CHAR (CONFIRM_DATE, 'dd/mm/yyyy'), ' '), " +
                     "TO_CHAR (NVL (RESIGN_CAUSE, 'N/A')), " +
                     "TO_CHAR (NVL (department_id, '0')), " +
                     "TO_CHAR (NVL (employee_type_id, '0')), " +
                     "TO_CHAR (NVL (TRAINING_PERIOD_ID, '0')), " +
                     "TO_CHAR (NVL (PAYMENT_TYPE_ID, '0')), " +
                     "TO_CHAR (NVL (APPROVED_BY, '0')), " +
                    "TO_CHAR (NVL (JOB_TYPE_ID, '0')), " +
                    "TO_CHAR (NVL (JOB_LOCATION_ID, '0')), " +
                    "NVL(grade_number, '0'), " +
                    "TO_CHAR (NVL (birth_reg_no, '0')), " +
                    "TO_CHAR (NVL (BKASH_NO, '0')), " +
                    "TO_CHAR (NVL (ROCKET_NO, '0')), " +
                    "TO_CHAR (NVL (FATHER_NAME_BANGLA, '0')), " +
                    "TO_CHAR (NVL (MOTHER_NAME_BANGLA, '0')), " +
                    "TO_CHAR (NVL (SITTING_BRANCH_OFFICE_ID, '0')), " +
                    "TO_CHAR (NVL (payment_yn, '0')), " +
                    "TO_CHAR (NVL (bank_id, '0')), " +
                    "TO_CHAR (NVL (ID_CARD_NO, '0')), " +
                    "TO_CHAR (NVL (company_id, '0')), " +
                    "TO_CHAR (NVL (hidden_salary, '0')) " +
                    //bank_id
                    "from vew_search_employee_detail where employee_id = '" + strEmployeeId + "' and head_office_id = '" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "' ";

            if (strEmpId.Length > 0)
            {
                sql = sql + " AND employee_id = '" + strEmpId + "' ";

            }
            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;
            using (OracleConnection strConn = GetConnection())
            {
                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                try
                {
                    while (objDataReader.Read())
                    {
                        objEmployeeDTO.CardNo = objDataReader.GetString(0);
                        objEmployeeDTO.EmployeeName = objDataReader.GetString(1);
                        objEmployeeDTO.EmployeeNameBangla = objDataReader.GetString(2);
                        objEmployeeDTO.FatherName = objDataReader.GetString(3);
                        objEmployeeDTO.MotherName = objDataReader.GetString(4);
                        objEmployeeDTO.DateOfBirth = objDataReader.GetString(5);
                        objEmployeeDTO.GenderId = objDataReader.GetString(6);
                        objEmployeeDTO.DesignationId = objDataReader.GetString(7);
                        objEmployeeDTO.MaritalStatusId = objDataReader.GetString(8);
                        objEmployeeDTO.BloodGroupId = objDataReader.GetString(9);
                        objEmployeeDTO.CatagoryId = objDataReader.GetString(10);
                        objEmployeeDTO.HusbandName = objDataReader.GetString(11);
                        objEmployeeDTO.HusbandOccupation = objDataReader.GetString(12);
                        objEmployeeDTO.PresentAddress = objDataReader.GetString(13);
                        objEmployeeDTO.PermanentAddress = objDataReader.GetString(14);
                        objEmployeeDTO.PresentAddressBangla = objDataReader.GetString(15);
                        objEmployeeDTO.PermanentAddressBangla = objDataReader.GetString(16);
                        objEmployeeDTO.TinNo = objDataReader.GetString(17);
                        objEmployeeDTO.MobileNo = objDataReader.GetString(18);
                        objEmployeeDTO.PhoneNo = objDataReader.GetString(19);
                        objEmployeeDTO.EmailAddress = objDataReader.GetString(20);
                        objEmployeeDTO.UnitId = objDataReader.GetString(21);
                        objEmployeeDTO.OrganizationName = objDataReader.GetString(22);
                        objEmployeeDTO.WorkingDuration = objDataReader.GetString(23);
                        objEmployeeDTO.YearOfExperience = objDataReader.GetString(24);
                        objEmployeeDTO.LeaveYear = objDataReader.GetString(25);
                        objEmployeeDTO.LeaveMonth = objDataReader.GetString(26);
                        objEmployeeDTO.LeaveDate = objDataReader.GetString(27);
                        objEmployeeDTO.LeavingReson = objDataReader.GetString(28);
                        objEmployeeDTO.GrossSalary = objDataReader.GetString(29);
                        objEmployeeDTO.ReferenceBy = objDataReader.GetString(30);
                        objEmployeeDTO.DistrictId = objDataReader.GetString(31);
                        objEmployeeDTO.DivisionId = objDataReader.GetString(32);
                        objEmployeeDTO.AccountNo = objDataReader.GetString(33);
                        objEmployeeDTO.FirstSalary = objDataReader.GetString(34);
                        objEmployeeDTO.SectionId = objDataReader.GetString(35);
                        objEmployeeDTO.JobOfficeId = objDataReader.GetString(36);
                        objEmployeeDTO.NIDNo = objDataReader.GetString(37);
                        objEmployeeDTO.NationaLityId = objDataReader.GetString(38);
                        objEmployeeDTO.OrderDate = objDataReader.GetString(39);
                        objEmployeeDTO.EffectiveDate = objDataReader.GetString(40);
                        objEmployeeDTO.EmployeeActiveYn = objDataReader.GetString(41);
                        objEmployeeDTO.OccurenceTypeId = objDataReader.GetString(42);
                        objEmployeeDTO.JoiningDate = objDataReader.GetString(43);
                        objEmployeeDTO.TitleId = objDataReader.GetString(44);
                        objEmployeeDTO.ReligionId = objDataReader.GetString(45);
                        objEmployeeDTO.EmployeeId = objDataReader.GetString(46);
                        objEmployeeDTO.JoiningSalary = objDataReader.GetString(47);
                        objEmployeeDTO.JoiningDesignationId = objDataReader.GetString(48);
                        objEmployeeDTO.EmergencyContactNo = objDataReader.GetString(49);
                        objEmployeeDTO.AllowanceAmount = objDataReader.GetString(50);
                        objEmployeeDTO.PunchCode = objDataReader.GetString(51);
                        objEmployeeDTO.GradeNo = objDataReader.GetString(52);
                        objEmployeeDTO.ResignDate = objDataReader.GetString(53);
                        objEmployeeDTO.ReportingTo = objDataReader.GetString(54);
                        objEmployeeDTO.ConfirmDate = objDataReader.GetString(55);
                        objEmployeeDTO.ResignCasuse = objDataReader.GetString(56);
                        objEmployeeDTO.DepartmentId = objDataReader.GetString(57);
                        objEmployeeDTO.EmployeeTypeId = objDataReader.GetString(58);
                        objEmployeeDTO.TrainingPeriodId = objDataReader.GetString(59);
                        objEmployeeDTO.PaymentTypeId = objDataReader.GetString(60);
                        objEmployeeDTO.ApprovedBY = objDataReader.GetString(61);
                        objEmployeeDTO.JobTypeId = objDataReader.GetString(62);
                        objEmployeeDTO.JobLocationId = objDataReader.GetString(63);
                        objEmployeeDTO.grade_number = objDataReader.GetString(64);
                        objEmployeeDTO.BirthRegistrationNo = objDataReader.GetString(65);
                        objEmployeeDTO.BKashNo = objDataReader.GetString(66);
                        objEmployeeDTO.RocketNo = objDataReader.GetString(67);
                        objEmployeeDTO.FatherNameBangla = objDataReader.GetString(68);
                        objEmployeeDTO.MotherNameBangla = objDataReader.GetString(69);
                        objEmployeeDTO.SittingBranchOfficeId = objDataReader.GetString(70);
                        objEmployeeDTO.PaymentYn = objDataReader.GetString(71);
                        objEmployeeDTO.BankId = objDataReader.GetString(72);
                        objEmployeeDTO.IdCardNo = objDataReader.GetString(73);
                        objEmployeeDTO.CompanyId = objDataReader.GetString(74);
                        objEmployeeDTO.HiddenSalary = objDataReader.GetString(75);
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
            return objEmployeeDTO;
        }

        //new GetEmployeeCacheByCacheId
        public EmployeeDTO GetEmployeeCacheByCacheId(string cacheId)
        {


            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            string sql = "";
            sql = "SELECT " +
                  "TO_CHAR (NVL (cache_id, '0')), " +
                  "TO_CHAR (NVL (employee_id, 'N/A')), " +
                  "TO_CHAR (NVL (TITLE_ID, '0')), " +

                  "TO_CHAR (NVL (card_no, '0')), " +
                  "TO_CHAR (NVL (PUNCH_CODE, '0')), "+
                  "TO_CHAR (NVL (employee_name, 'N/A')), " +

                  "TO_CHAR (NVL (employee_name_bangla, 'N/A')), " +
                  "NVL (TO_CHAR (joining_date, 'dd/mm/yyyy'), ' '), " +
                  "TO_CHAR (NVL (employee_type_id, '0')), " +

                  "TO_CHAR (NVL (designation_id, '0')), " +
                  "TO_CHAR (NVL (grade_no, '0')), " +
                  "TO_CHAR (NVL (unit_id, '0')), " +

                  "TO_CHAR (NVL (SECTION_ID, '0')), " +
                  "TO_CHAR (NVL (nid_no, '0')), " +
                  "TO_CHAR (NVL (gender_id, '0')), " +
                  "TO_CHAR (NVL (religion_id, '0')), " +
                  "TO_CHAR (NVL (active_yn, '0')) " +                    
                                       
                  "from VEW_EMPLOYEE_CACHE where cache_id = '" + cacheId + "' ";

            //if (strEmpId.Length > 0)
            //{
            //    sql = sql + " AND employee_id = '" + strEmpId + "' ";

            //}
            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;
            using (OracleConnection strConn = GetConnection())
            {
                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                try
                {
                    while (objDataReader.Read())
                    {
                        objEmployeeDTO.CacheId = objDataReader.GetString(0);
                        objEmployeeDTO.EmployeeId = objDataReader.GetString(1);
                        objEmployeeDTO.TitleId = objDataReader.GetString(2);

                        objEmployeeDTO.CardNo = objDataReader.GetString(3);
                        objEmployeeDTO.PunchCode = objDataReader.GetString(4);
                        objEmployeeDTO.EmployeeName = objDataReader.GetString(5);

                        objEmployeeDTO.EmployeeNameBangla = objDataReader.GetString(6);
                        objEmployeeDTO.JoiningDate = objDataReader.GetString(7);
                        objEmployeeDTO.EmployeeTypeId = objDataReader.GetString(8);

                        objEmployeeDTO.DesignationId = objDataReader.GetString(9);
                        objEmployeeDTO.GradeNo = objDataReader.GetString(10);
                        objEmployeeDTO.UnitId = objDataReader.GetString(11);

                        objEmployeeDTO.SectionId = objDataReader.GetString(12);
                        objEmployeeDTO.NIDNo = objDataReader.GetString(13);
                        objEmployeeDTO.GenderId = objDataReader.GetString(14);
                        objEmployeeDTO.ReligionId = objDataReader.GetString(15);
                        objEmployeeDTO.EmployeeActiveYn = objDataReader.GetString(16);
                               
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
            return objEmployeeDTO;
        }

        public EmployeeDTO ReadOnlyYn(string strEmployeeId, string strMonth, string strYear, string strHeadOfficeId, string strBranchOfficeId)
         {


             EmployeeDTO objEmployeeDTO = new EmployeeDTO();

            
             string sql = "";
             sql = "SELECT " +

                      " 'Y' " +


                     "from VEW_SEARCH_EMPLOYEE_DETAIL where employee_id = '" + strEmployeeId + "' AND JOINING_YEAR = '" + strYear + "' AND JOINING_MONTH = '" + strMonth + "' and head_office_id = '" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "' ";




             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataReader objDataReader;

             using (OracleConnection strConn = GetConnection())
             {

                 objCommand.Connection = strConn;
                 strConn.Open();
                 objDataReader = objCommand.ExecuteReader();
                 try
                 {
                     while (objDataReader.Read())
                     {


                         objEmployeeDTO.LockYn = objDataReader.GetString(0);



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




             return objEmployeeDTO;


         }
         public EmployeeDTO PermissionYn(string strEmployeeId, string strHeadOfficeId, string strBranchOfficeId)
         {


             EmployeeDTO objEmployeeDTO = new EmployeeDTO();




             string sql = "";
             sql = "SELECT " +

                      " 'Y' " +


                     "from vew_search_readonly where employee_id = '" + strEmployeeId + "' and head_office_id = '" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "' ";




             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataReader objDataReader;

             using (OracleConnection strConn = GetConnection())
             {

                 objCommand.Connection = strConn;
                 strConn.Open();
                 objDataReader = objCommand.ExecuteReader();
                 try
                 {
                     while (objDataReader.Read())
                     {


                         objEmployeeDTO.PermissionYn = objDataReader.GetString(0);



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




             return objEmployeeDTO;


         }
         public EmployeeDTO searchAttendenceRecord(string strLogDate, string strEmployeeId, string strHeadOfficeId, string strBranchOfficeId)
         {

             EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            
             string sql = "";
             sql = "SELECT " +

                      "TO_CHAR (NVL (FIRST_IN, '0')), " +
                     "TO_CHAR (NVL (LUNCH_OUT, '0')), " +
                     "TO_CHAR (NVL (LUNCH_IN, '0')), " +
                     "TO_CHAR (NVL (LAST_OUT, '0')), " +
                     "TO_CHAR (NVL (LAST_OUT_LOG_DATE, '0')), " +          
                     "TO_CHAR (NVL (REMARKS, '0')) " +                   
                     "from VEW_SEARCH_ATTENDENCE_ENTRY where employee_id = '" + strEmployeeId + "' and log_date = TO_DATE('" + strLogDate + "', 'dd/mm/yyyy') AND head_office_id = '" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "' ";
                     
             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataReader objDataReader;

             using (OracleConnection strConn = GetConnection())
             {

                 objCommand.Connection = strConn;
                 strConn.Open();
                 objDataReader = objCommand.ExecuteReader();
                 try
                 {
                     while (objDataReader.Read())
                     {


                         objEmployeeDTO.LogInTime = objDataReader.GetString(0);
                         objEmployeeDTO.LunchOutTime = objDataReader.GetString(1);
                         objEmployeeDTO.LunchInTime = objDataReader.GetString(2);
                         objEmployeeDTO.FinalOutTime = objDataReader.GetString(3);
                        objEmployeeDTO.FinalOutDate = objDataReader.GetString(4);
                        objEmployeeDTO.Remark = objDataReader.GetString(5);


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




             return objEmployeeDTO;


         }
         public EmployeeDTO searchAttendenceRecordFromAttenSearchIn(string strLogDate, string strEmployeeId, string strHeadOfficeId, string strBranchOfficeId)
         {
             EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            
             string sql = "";
             sql = "SELECT " +

                     "TO_CHAR (NVL (FIRST_IN, '0')) " +       
                     "from VEW_SEARCH_EMP_FOR_ATTENDENCE where employee_id = '" + strEmployeeId + "' and log_date = TO_DATE('" + strLogDate + "', 'dd/mm/yyyy') AND head_office_id = '" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "' ";
            
             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataReader objDataReader;

             using (OracleConnection strConn = GetConnection())
             {

                 objCommand.Connection = strConn;
                 strConn.Open();
                 objDataReader = objCommand.ExecuteReader();
                 try
                 {
                     while (objDataReader.Read())
                     {


                         objEmployeeDTO.LogInTime = objDataReader.GetString(0);
                        



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




             return objEmployeeDTO;


         }
         public EmployeeDTO searchAttendenceRecordFromAttenSearchLunchIn(string strLogDate, string strEmployeeId, string strHeadOfficeId, string strBranchOfficeId)
         {


             EmployeeDTO objEmployeeDTO = new EmployeeDTO();




             string sql = "";
             sql = "SELECT " +


                     "TO_CHAR (NVL (LUNCH_IN, '0')) " +
                    


                     "from VEW_SEARCH_EMP_FOR_ATTENDENCE where employee_id = '" + strEmployeeId + "' and log_date = TO_DATE('" + strLogDate + "', 'dd/mm/yyyy') AND head_office_id = '" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "' ";






             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataReader objDataReader;

             using (OracleConnection strConn = GetConnection())
             {

                 objCommand.Connection = strConn;
                 strConn.Open();
                 objDataReader = objCommand.ExecuteReader();
                 try
                 {
                     while (objDataReader.Read())
                     {


                       
                         objEmployeeDTO.LunchInTime = objDataReader.GetString(0);
             



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




             return objEmployeeDTO;


         }
         public EmployeeDTO searchAttendenceRecordFromAttenSearchLunchOut(string strLogDate, string strEmployeeId, string strHeadOfficeId, string strBranchOfficeId)
         {

             EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            

             string sql = "";
             sql = "SELECT " +


                     "TO_CHAR (NVL (LUNCH_OUT, '0')) " +



                     "from VEW_SEARCH_EMP_FOR_ATTENDENCE where employee_id = '" + strEmployeeId + "' and log_date = TO_DATE('" + strLogDate + "', 'dd/mm/yyyy') AND head_office_id = '" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "' ";






             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataReader objDataReader;

             using (OracleConnection strConn = GetConnection())
             {

                 objCommand.Connection = strConn;
                 strConn.Open();
                 objDataReader = objCommand.ExecuteReader();
                 try
                 {
                     while (objDataReader.Read())
                     {



                         objEmployeeDTO.LunchOutTime = objDataReader.GetString(0);




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




             return objEmployeeDTO;


         }
         public EmployeeDTO searchAttendenceRecordFromAttenSearchFinalOut(string strLogDate, string strEmployeeId, string strHeadOfficeId, string strBranchOfficeId)
         {


             EmployeeDTO objEmployeeDTO = new EmployeeDTO();




             string sql = "";
             sql = "SELECT " +


                     "TO_CHAR (NVL (LAST_OUT, '0')) " +



                     "from VEW_SEARCH_EMP_FOR_ATTENDENCE where employee_id = '" + strEmployeeId + "' and log_date = TO_DATE('" + strLogDate + "', 'dd/mm/yyyy') AND head_office_id = '" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "' ";






             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataReader objDataReader;

             using (OracleConnection strConn = GetConnection())
             {

                 objCommand.Connection = strConn;
                 strConn.Open();
                 objDataReader = objCommand.ExecuteReader();
                 try
                 {
                     while (objDataReader.Read())
                     {



                         objEmployeeDTO.FinalOutTime = objDataReader.GetString(0);




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




             return objEmployeeDTO;


         }
         public EmployeeDTO searchEmployeeStatus(string strEmployeeId, string strCardNo, string strHeadOfficeId, string strBranchOfficeId, string strEmpId)
         {


             EmployeeDTO objEmployeeDTO = new EmployeeDTO();




             string sql = "";
             sql = "SELECT " +


                     "TO_CHAR (NVL (STATUS, 'N/A')) " +
                    




                     "from vew_employee_status where employee_id = '" + strEmployeeId + "' and head_office_id = '" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "' ";



             if (strCardNo.Length > 0)
             {
                 sql = sql + " AND card_no = '" + strCardNo + "' ";

             }

             if (strEmpId.Length > 0)
             {
                 sql = sql + " AND employee_id = '" + strEmpId + "' ";

             }



             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataReader objDataReader;

             using (OracleConnection strConn = GetConnection())
             {

                 objCommand.Connection = strConn;
                 strConn.Open();
                 objDataReader = objCommand.ExecuteReader();
                 try
                 {
                     while (objDataReader.Read())
                     {


                         objEmployeeDTO.Msg = objDataReader.GetString(0);
                       




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




             return objEmployeeDTO;


         }
         public EmployeeDTO searchEmployeeEducation(string strEmployeeId, string strYear, string strHeadOfficeId, string strBranchOfficeId)
         {


             EmployeeDTO objEmployeeDTO = new EmployeeDTO();




             string sql = "";
             sql = "SELECT " +

                      "TO_CHAR (NVL (INSTITUTE_NAME, 'N/A')), " +
                     "TO_CHAR (NVL (COURSE_ID, '')), " +
                     "TO_CHAR (NVL (SUBJECT_ID, '')), " +
                     "TO_CHAR (NVL (PASSING_YEAR, '0')), " +
                     "TO_CHAR (NVL (CGPA, '0')) " +



                     "from VEW_SEARCH_EMPLOYEE_EDUCATION where employee_id = '" + strEmployeeId + "' and PASSING_YEAR = '"+strYear+"' AND head_office_id = '" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "' ";



            
             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataReader objDataReader;

             using (OracleConnection strConn = GetConnection())
             {

                 objCommand.Connection = strConn;
                 strConn.Open();
                 objDataReader = objCommand.ExecuteReader();
                 try
                 {
                     while (objDataReader.Read())
                     {


                         objEmployeeDTO.InstitueName = objDataReader.GetString(0);
                         objEmployeeDTO.CourseId = objDataReader.GetString(1);
                         objEmployeeDTO.SubjectId = objDataReader.GetString(2);
                         objEmployeeDTO.PassingYear = objDataReader.GetString(3);
                         objEmployeeDTO.CGPA = objDataReader.GetString(4);
                        

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




             return objEmployeeDTO;


         }
         public EmployeeDTO searchEmployeePreJobInfo(string strEmployeeId, string strJoiningDate ,string strHeadOfficeId, string strBranchOfficeId)
         {


             EmployeeDTO objEmployeeDTO = new EmployeeDTO();




             string sql = "";
             sql = "SELECT " +

                     "TO_CHAR (NVL (ORGANIZATION_NAME, 'N/A')), " +
                     "TO_CHAR (NVL (SECTION_NAME, 'N/A')), " +
                     "TO_CHAR (NVL (DESIGNATION_NAME, 'N/A')), " +
                     "TO_CHAR (NVL (PREVIOUS_SALARY, '0')), " +
                     "TO_CHAR (NVL (WORKING_DURATION, '0')), " +
                     "TO_CHAR (NVL (YEAR_OF_EXPERIENCE, '0')), " +
                     "NVL (TO_CHAR (LEAVE_DATE, 'dd/mm/yyyy'), ''), " +
                     "TO_CHAR (NVL (LEAVING_REASON, 'N/A')), " +
                     "NVL (TO_CHAR (JOINING_DATE, 'dd/mm/yyyy'), '') " +


                     "from VEW_SEARCH_EMPLOYEE_PRE_JOB where employee_id = '" + strEmployeeId + "' and joining_date = to_date('" + strJoiningDate + "', 'dd/mm/yyyy') and  head_office_id = '" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "' ";




             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataReader objDataReader;

             using (OracleConnection strConn = GetConnection())
             {

                 objCommand.Connection = strConn;
                 strConn.Open();
                 objDataReader = objCommand.ExecuteReader();
                 try
                 {
                     while (objDataReader.Read())
                     {


                         objEmployeeDTO.OrganizationName = objDataReader.GetString(0);
                         objEmployeeDTO.SectionName = objDataReader.GetString(1);
                         objEmployeeDTO.DesignationName = objDataReader.GetString(2);
                         objEmployeeDTO.PreSalary = objDataReader.GetString(3);
                         objEmployeeDTO.WorkingDuration = objDataReader.GetString(4);
                         objEmployeeDTO.YearOfExperience = objDataReader.GetString(5);
                         if (objEmployeeDTO.LeaveDate == null)
                         {
                             objEmployeeDTO.LeaveDate = null;
                         }
                         else
                         {

                             objEmployeeDTO.LeaveDate = objDataReader.GetString(6);
                         }
                        
                         objEmployeeDTO.LeavingReson = objDataReader.GetString(7);
                         objEmployeeDTO.JoiningDate = objDataReader.GetString(8);
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




             return objEmployeeDTO;


         }

         public DataSet bindEmployeeRecord()
         {

             EmployeeDTO objEmployeeDTO = new EmployeeDTO();

             DataSet ds = new DataSet();
             DataTable dt = new DataTable();

             string sql = "";
             sql = "Select * "+

                   " FROM VEW_EMPLOYEE_BASIC_INFO where ROWNUM <= 12 ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(ds);
                     ds.AcceptChanges();
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


             return ds ;

         }
         public DataTable searchEmployeeRecord(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql =  "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "UNIT_NAME, " +
                    "SECTION_NAME, " +

                    "DESIGNATION_NAME, " +
                    "TO_CHAR(JOINING_DATE, 'dd/mm/yyyy')JOINING_DATE " +
                    ",GENDER_NAME " +
                    ", TO_CHAR(DATE_OF_BIRTH, 'dd/mm/yyyy')DATE_OF_BIRTH " +                    
                    ",nid_no " +
                   "FROM VEW_SEARCH_EMPLOYEE_INFO WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "' AND branch_office_id = '" + objEmployeeDTO.BranchOfficeId + "' AND active_yn = '" + objEmployeeDTO.EmployeeActiveYn + "'";

             if (objEmployeeDTO.EmployeeId.Length > 0)
             {

                 sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
             }
             
             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }

             if (objEmployeeDTO.CardNo.Length > 0)
             {

                 sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
             }

             if (objEmployeeDTO.GradeNo.Length > 0)
             {

                 sql = sql + "and grade_no = '" + objEmployeeDTO.GradeNo + "'";
             }

             if (objEmployeeDTO.BloodGroupId.Length > 0)
             {

                 sql = sql + "and blood_group_id = '" + objEmployeeDTO.BloodGroupId + "'";
             }

             if (objEmployeeDTO.EmployeeName.Length > 0)
             {

                 sql = sql + "and (lower(employee_name) like lower( '%" + objEmployeeDTO.EmployeeName + "%')  or upper(employee_name)like upper('%" + objEmployeeDTO.EmployeeName + "%')) ";
             }

             if (objEmployeeDTO.FromConfirmDate.Length > 6 && objEmployeeDTO.ToConfirmDate.Length > 6)
             {

                 sql = sql + "and confirm_date between to_date ( '" + objEmployeeDTO.FromConfirmDate + "', 'dd/mm/yyyy') and to_date ( '" + objEmployeeDTO.ToConfirmDate + "', 'dd/mm/yyyy')   ";
             }
            if (objEmployeeDTO.FromCreateDate.Length > 6 && objEmployeeDTO.ToCreateDate.Length > 6)
            {

                sql = sql + "and create_date between to_date ( '" + objEmployeeDTO.FromCreateDate + "', 'dd/mm/yyyy') and to_date ( '" + objEmployeeDTO.ToCreateDate + "', 'dd/mm/yyyy')   ";
            }
            if (objEmployeeDTO.EmployeeTypeId.Length > 0)
             {

                 sql = sql + "and EMPLOYEE_TYPE_ID = '" + objEmployeeDTO.EmployeeTypeId + "'";
             }
            if (objEmployeeDTO.NIDNo.Length > 0)
            {
                sql = sql + "and NID_NO = '" + objEmployeeDTO.NIDNo + "'";
            }

            sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchEmployeeRecordForAttendence(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";


           
                 sql = "SELECT " +
                        "rownum sl, " +
                        "CARD_NO, " +
                        "EMPLOYEE_ID, " +
                        "EMPLOYEE_NAME, " +
                        "DESIGNATION_NAME, " +
                        "shift_id " +
                       "FROM VEW_SEARCH_EMP_FOR_ATTENDENCE WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "' AND branch_office_id = '" + objEmployeeDTO.BranchOfficeId + "' ";


                 if (objEmployeeDTO.FromDate.Length > 6 && objEmployeeDTO.ToDate.Length > 6)
                 {
                     sql = sql + "and log_date between to_date( '" + objEmployeeDTO.FromDate + "', 'dd/mm/yyyy') and to_date('" + objEmployeeDTO.ToDate + "', 'dd/mm/yyyy')";
                 }

                 if (objEmployeeDTO.EmployeeId.Length > 0)
                 {
                     sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
                 }

                 if (objEmployeeDTO.SectionId.Length > 0)
                 {
                     sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
                 }

                 if (objEmployeeDTO.UnitId.Length > 0)
                 {
                     sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
                 }

                if (!string.IsNullOrEmpty(objEmployeeDTO.ShiftId))
                {
                    sql = sql + "and shift_id = '" + objEmployeeDTO.ShiftId + "'";
                }

            if (objEmployeeDTO.CardNo.Length > 0)
                 {
                     sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
                 }
                 
             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchEmployeeAllforAttendenceEntry(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";



             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME " +


                   "FROM VEW_SEARCH_EMP_ALL_ATTENDENCE WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "' AND branch_office_id = '" + objEmployeeDTO.BranchOfficeId + "' ";


             //if (objEmployeeDTO.FromDate.Length > 6 && objEmployeeDTO.ToDate.Length > 6)
             //{

             //    sql = sql + "and log_date between to_date( '" + objEmployeeDTO.FromDate + "', 'dd/mm/yyyy') and to_date('" + objEmployeeDTO.ToDate + "', 'dd/mm/yyyy')";
             //}

             if (objEmployeeDTO.EmployeeId.Length > 0)
             {

                 sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
             }

             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }

             if (objEmployeeDTO.CardNo.Length > 0)
             {

                 sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
             }




             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchEmpRecordAttendence(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME " +


                   "FROM VEW_SEARCH_EMP_ATTENDENCE WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "' AND branch_office_id = '" + objEmployeeDTO.BranchOfficeId + "'  ";

             if (objEmployeeDTO.EmployeeId.Length > 0)
             {

                 sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
             }

             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }

             if (objEmployeeDTO.CardNo.Length > 0)
             {

                 sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
             }



             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchEmployeeRecordLastOutIsNull(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME " +


                   "FROM VEW_SEARCH_EMP_LAST_OUT_NULL WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "' AND branch_office_id = '" + objEmployeeDTO.BranchOfficeId + "' AND LOG_DATE = TO_DATE('" + objEmployeeDTO.LogDate + "', 'dd/mm/yyyy')  ";

             if (objEmployeeDTO.EmployeeId.Length > 0)
             {

                 sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
             }

             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }

             if (objEmployeeDTO.CardNo.Length > 0)
             {

                 sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
             }



             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchAttendenceEntry(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                   "rownum sl, " +
                   "CARD_NO, " +
                   "EMPLOYEE_ID, " +
                   "EMPLOYEE_NAME, " +
                   "DESIGNATION_NAME, " +
                   "FIRST_IN, " +
                   "LUNCH_OUT, "+
                   "LUNCH_IN, "+
                   "LAST_OUT, "+
                   "REMARKS, " +
                   "shift_id " +
                   "FROM VEW_SEARCH_ATTENDENCE_ENTRY WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "' AND branch_office_id = '" + objEmployeeDTO.BranchOfficeId + "' AND LOG_DATE = TO_DATE('"+objEmployeeDTO.LogDate+"', 'dd/mm/yyyy') ";

             if (objEmployeeDTO.EmployeeId.Length > 0)
             {
                 sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
             }

             if (objEmployeeDTO.SectionId.Length > 0)
             {
                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {
                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }

             if (objEmployeeDTO.CardNo.Length > 0)
             {
                 sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
             }
            if (!string.IsNullOrEmpty(objEmployeeDTO.ShiftId))
            {
                sql = sql + "and shift_id = '" + objEmployeeDTO.ShiftId + "'";
            }

            sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);
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
             
             return dt;
         }
         public DataTable searchEmployeeRecordEducation(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME, " +
                    "COURSE_NAME, "+
                    "INSTITUTE_NAME, "+
                    "SUBJECT_NAME, "+
                    "PASSING_YEAR, "+
                    "CGPA "+

                   "FROM VEW_SEARCH_EMP_EDU_HISTORY WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "' AND branch_office_id = '" + objEmployeeDTO.BranchOfficeId + "' ";

             if (objEmployeeDTO.EmployeeId.Length > 0)
             {

                 sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
             }
             if (objEmployeeDTO.EmployeeName.Length > 0)
             {

                 sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeName + "'";
             }

             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }

             if (objEmployeeDTO.CardNo.Length > 0)
             {

                 sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
             }



             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchEmployeePreJobInfo(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME, " +
                    "ORGANIZATION_NAME, " +
                    "SECTION_NAME, " +
                    "DESIGNATION_NAME, " +
                    "PREVIOUS_SALARY, " +
                    "WORKING_DURATION " +

                   "FROM VEW_SEARCH_EMP_PRE_JOB_HISTORY WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "' AND branch_office_id = '" + objEmployeeDTO.BranchOfficeId + "' ";

             if (objEmployeeDTO.EmployeeId.Length > 0)
             {

                 sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
             }
             if (objEmployeeDTO.EmployeeName.Length > 0)
             {

                 sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeName + "'";
             }

             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }

             if (objEmployeeDTO.CardNo.Length > 0)
             {

                 sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
             }



             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchEmployeeRecordForHold(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME " +


                   "FROM VEW_BASIC_INFO WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "' AND branch_office_id = '"+objEmployeeDTO.BranchOfficeId+"'  ";



             if (objEmployeeDTO.EmployeeId.Length > 0)
             {

                 sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
             }

             if (objEmployeeDTO.CardNo.Length > 0)
             {

                 sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
             }


             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }

           


             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchIncrementHoldInfo(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME, " +
                    "INCREMENT_HOLD_YEAR, "+
                   
                    "EMPLOYEE_ID " +

                   "FROM VEW_SEARCH_INCREMENT_HOLD_INFO WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "' AND branch_office_id = '" + objEmployeeDTO.BranchOfficeId + "' and INCREMENT_HOLD_YEAR = '" + objEmployeeDTO.Year + "' AND HOLD_YN = 'Y' ";



             //if (objEmployeeDTO.Month.Length > 0)
             //{

             //    sql = sql + "and INCREMENT_HOLD_MONTH = '" + objEmployeeDTO.Month + "'";
             //}

             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }




             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }

         public DataTable searchEmployeeRecordForLeave(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";


             if (objEmployeeDTO.HeadOfficeId == "441" && objEmployeeDTO.BranchOfficeId == "105" && (objEmployeeDTO.UnitId == "91" || objEmployeeDTO.UnitId == "") && objEmployeeDTO.UpdateBy == "105")
             {


                 sql = "SELECT " +
                       "rownum sl, " +
                       "CARD_NO, " +
                       "EMPLOYEE_ID, " +
                       "EMPLOYEE_NAME, " +
                       "DESIGNATION_NAME, " +
                       "UNIT_NAME, " +
                       "SECTION_NAME " +


                      "FROM VEW_BASIC_INFO WHERE head_office_id = '" + 1 + "' AND branch_office_id = '" + objEmployeeDTO.BranchOfficeId + "' ";


                 if (objEmployeeDTO.EmployeeName.Length > 0)
                 {

                     sql = sql + "and (lower(employee_name) like lower( '%" + objEmployeeDTO.EmployeeName + "%')  or upper(employee_name)like upper('%" + objEmployeeDTO.EmployeeName + "%')) ";
                 }


             }

             else
             {
                 sql = "SELECT " +
                        "rownum sl, " +
                        "CARD_NO, " +
                        "EMPLOYEE_ID, " +
                        "EMPLOYEE_NAME, " +
                        "DESIGNATION_NAME, " +
                         "UNIT_NAME, " +
                        "SECTION_NAME " +


                       "FROM VEW_BASIC_INFO WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "' AND branch_office_id = '" + objEmployeeDTO.BranchOfficeId + "' ";


                 if (objEmployeeDTO.SectionId.Length > 0)
                 {

                     sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
                 }

                 if (objEmployeeDTO.UnitId.Length > 0)
                 {

                     sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
                 }

                 if (objEmployeeDTO.CardNo.Length > 0)
                 {

                     sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
                 }

                 if (objEmployeeDTO.EmployeeId.Length > 0)
                 {

                     sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
                 }


                 if (objEmployeeDTO.EmployeeName.Length > 0)
                 {

                     sql = sql + "and (lower(employee_name) like lower( '%" + objEmployeeDTO.EmployeeName + "%')  or upper(employee_name)like upper('%" + objEmployeeDTO.EmployeeName + "%')) ";
                 }

                 sql = sql + "order by SL ";
             }
             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchLeaveEntry(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             if (objEmployeeDTO.HeadOfficeId == "441" && objEmployeeDTO.BranchOfficeId == "105"  && (objEmployeeDTO.UnitId == "91"|| objEmployeeDTO.UnitId == "") && objEmployeeDTO.UpdateBy == "105")
             {

                 sql = "SELECT " +
                  "rownum sl, " +
                  "CARD_NO, " +

                  "EMPLOYEE_NAME, " +
                  "DESIGNATION_NAME, " +
                   "UNIT_NAME, " +
                   "SECTION_NAME, " +
                  "EMPLOYEE_ID, " +
                  "TO_CHAR(LEAVE_START_DATE, 'dd/mm/yyyy')LEAVE_START_DATE, " +
                  "TO_CHAR(LEAVE_END_DATE, 'dd/mm/yyyy')LEAVE_END_DATE, " +
                  "TOTAL_LEAVE, " +
                  "APPROVE_BY_NAME, " +
                  "file_name, " +
                  "leave_type_name " +

                 "FROM VEW_SEARCH_LEAVE_ENTRY WHERE head_office_id = '" + 1 + "' AND branch_office_id = '" + objEmployeeDTO.BranchOfficeId + "' " +
                 " AND leave_year = '" + objEmployeeDTO.Year + "'  ";



                 sql = sql + "order by SL ";
             }
             else
             {

                 sql = "SELECT " +
                   "rownum sl, " +
                   "CARD_NO, " +

                   "EMPLOYEE_NAME, " +
                   "DESIGNATION_NAME, " +
                   "UNIT_NAME, " +
                   "SECTION_NAME, " +
                   "EMPLOYEE_ID, " +
                   "TO_CHAR(LEAVE_START_DATE, 'dd/mm/yyyy')LEAVE_START_DATE, " +
                   "TO_CHAR(LEAVE_END_DATE, 'dd/mm/yyyy')LEAVE_END_DATE, " +
                   "TOTAL_LEAVE, " +
                   "APPROVE_BY_NAME, " +
                   "file_name, " +
                   "leave_type_name " +

                  "FROM VEW_SEARCH_LEAVE_ENTRY WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "' AND branch_office_id = '" + objEmployeeDTO.BranchOfficeId + "' " +
                  " AND leave_year = '" + objEmployeeDTO.Year + "'  ";


                 if (objEmployeeDTO.SectionId.Length > 0)
                 {

                     sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
                 }

                 if (objEmployeeDTO.UnitId.Length > 0)
                 {

                     sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
                 }

                 if (objEmployeeDTO.CardNo.Length > 0)
                 {

                     sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
                 }

                 if (objEmployeeDTO.EmpId.Length > 0)
                 {

                     sql = sql + "and employee_id = '" + objEmployeeDTO.EmpId + "'";
                 }



                 sql = sql + "order by SL ";
             }
             
            

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }


        //--searchLeaveEntry
        public DataTable GetShiftEmployeeLeave(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";
                       
            
                sql = "SELECT " +
                  "rownum sl, " +
                  "CARD_NO, " +

                  "EMPLOYEE_NAME, " +
                  "DESIGNATION_NAME, " +
                  "EMPLOYEE_ID, " +
                  "TO_CHAR(LEAVE_START_DATE, 'dd/mm/yyyy')LEAVE_START_DATE, " +
                  "TO_CHAR(LEAVE_END_DATE, 'dd/mm/yyyy')LEAVE_END_DATE, " +
                  "TOTAL_LEAVE, " +
                  "APPROVE_BY_NAME, " +
                  "file_name, " +
                  "leave_type_name " +

                 "FROM VEW_SEARCH_LEAVE_ENTRY WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "' AND branch_office_id = '" + objEmployeeDTO.BranchOfficeId + "' " +
                 " AND leave_year = '" + objEmployeeDTO.Year + "'  ";

                if (objEmployeeDTO.SectionId.Length > 0)
                {
                    sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
                }

                if (objEmployeeDTO.UnitId.Length > 0)
                {
                    sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
                }

                if (objEmployeeDTO.CardNo.Length > 0)
                {
                    sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
                }

                if (objEmployeeDTO.EmpId.Length > 0)
                {
                    sql = sql + "and employee_id = '" + objEmployeeDTO.EmpId + "'";
                }
                sql = sql + "order by SL ";
            

            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataAdapter.Fill(dt);

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
            return dt;
        }

        public DataTable searchLeaveSummery(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                   "EMPLOYEE_ID, " +
                   "LEAVE_YEAR, " +
                   "LEAVE_TYPE_ID, " +
                   "LEAVE_TYPE_NAME, " +
                   "TOTAL_LEAVE, " +
                   "MAX_ALLOW, " +
                   "remaining_blance, " +
                   "HEAD_OFFICE_ID, " +
                   "BRANCH_OFFICE_ID " +
                   
                   "FROM VEW_SEARCH_LEAVE_STATUS WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "' AND branch_office_id = '" + objEmployeeDTO.BranchOfficeId + "' " +
                   " AND leave_year = '" + objEmployeeDTO.Year + "' AND employee_id = '" + objEmployeeDTO.EmployeeId + "' ";
                       
             if (objEmployeeDTO.CardNo.Length > 0)
             {

                 sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
             }

             if (objEmployeeDTO.EmpId.Length > 0)
             {

                 sql = sql + "and employee_id = '" + objEmployeeDTO.EmpId + "'";
             }



             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchEmployeeRecordforAdvance(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME " +


                   "FROM VEW_BASIC_INFO WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "' and branch_office_id = '"+objEmployeeDTO.BranchOfficeId+"' ";


             if (objEmployeeDTO.EmployeeId.Length > 0)
             {

                 sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
             }

             if (objEmployeeDTO.CardNo.Length > 0)
             {

                 sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }



             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }


             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchEmployeeRecordforMiscEntryHO(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME " +


                   "FROM VEW_BASIC_INFO_HO WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "'";



             if (objEmployeeDTO.EmployeeId.Length > 0)
             {

                 sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
             }

             if (objEmployeeDTO.CardNo.Length > 0)
             {

                 sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
             }


             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }

             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
        public DataTable searchEmployeeRecordforPunching(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql =  "SELECT " +
                   "rownum sl, " +
                   "CARD_NO, " +
                   "EMPLOYEE_ID, " +
                   "EMPLOYEE_NAME, " +
                   "DESIGNATION_NAME, " +
                   "sitting_branch_office_id " +
                   //added on 30.03.2022
                   //"FROM VEW_BASIC_INFO WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND sitting_branch_office_id = '" + objEmployeeDTO.BranchOfficeId + "'";

                    //old: commented on 30.03.2022
                   "FROM VEW_BASIC_INFO WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "'";

            if (objEmployeeDTO.EmployeeId.Length > 0)
            {

                sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
            }

            if (objEmployeeDTO.CardNo.Length > 0)
            {

                sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
            }


            if (objEmployeeDTO.SectionId.Length > 0)
            {

                sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
            }

            if (objEmployeeDTO.UnitId.Length > 0)
            {

                sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
            }

            sql = sql + "order by SL ";

            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataAdapter.Fill(dt);

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



            return dt;

        }
        public DataTable searchEmployeeRecordforPurchaseEntry(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME " +


                   "FROM VEW_BASIC_INFO_HO WHERE 1 = 1 ";



             if (objEmployeeDTO.EmployeeId.Length > 0)
             {

                 sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
             }

             if (objEmployeeDTO.CardNo.Length > 0)
             {

                 sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
             }


             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }

            



            sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchMonthlyBankFile(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "SALARY_YEAR, " +
                    "MONTH_NAME, " +
                    "FILE_NAME " +



                   "FROM vew_search_monthly_bank_file WHERE head_office_id = '"+objEmployeeDTO.HeadOfficeId+"' and branch_office_id = '"+objEmployeeDTO.BranchOfficeId+"' ";



             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchPurchaseEntryRecord(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "INVOICE_NO, "+
                   "EMPLOYEE_ID, "+
                   "EMPLOYEE_NAME, "+
                   "CARD_NO, "+
                   "designation_name, "+
                   "LEDGER_NO, "+
                   "PRODUCT_SL_NO, " +

                   "REQUISITION_NO, "+
                   "TO_CHAR(REQUISITION_DATE, 'dd/mm/yyyy')REQUISITION_DATE, " +
                   "UNIT_ID, "+
                   "unit_name, "+
                   "SECTION_ID, "+
                   "section_name, "+
                   "MRR_NO, "+
                   "TO_CHAR(MRR_DATE,'dd/mm/yyyy')MRR_DATE, " +
                   "TO_CHAR(PURCHASE_DATE,'dd/mm/yyyy')PURCHASE_DATE, " +
                   "PURCHASE_QUANTITY, "+
                   "PRICE, "+
                   "WARRANTY_PERIOD, "+
                   "PRODUCT_DESCRIPTION, "+
                   "SUPPLIER_NAME, "+ 
                   "REMARKS, "+ 
                   "UPDATE_BY, "+
                   "UPDATE_DATE, "+
                   "HEAD_OFFICE_ID, "+
                   "BRANCH_OFFICE_ID, "+ 
                   "PURCHASE_QUANTITY, "+
                   "FILE_NAME, "+
                   "TRAN_ID, " +
                   "PRODUCT_NAME "+

                   "FROM vew_search_purchase_info WHERE 1 = 1 ";



             if (objEmployeeDTO.EmployeeId.Length > 0)
             {

                 sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
             }

             if (objEmployeeDTO.CardNo.Length > 0)
             {

                 sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
             }


             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }



             if (objEmployeeDTO.RequisitionNo.Length > 0)
             {

                 sql = sql + "and REQUISITION_NO = '" + objEmployeeDTO.RequisitionNo + "'";
             }


             if (objEmployeeDTO.SLNo.Length > 0)
             {

                 sql = sql + "and PRODUCT_SL_NO = '" + objEmployeeDTO.SLNo + "'";
             }

             if (objEmployeeDTO.ProductId.Length > 0)
             {

                 sql = sql + "and PRODUCT_ID = '" + objEmployeeDTO.ProductId + "'";
             }


             if (objEmployeeDTO.FromDate.Length > 6 && objEmployeeDTO.ToDate.Length > 6)
             {

                 sql = sql + "and PURCHASE_DATE BETWEEN TO_DATE( '" + objEmployeeDTO.FromDate + "', 'dd/mm/yyyy') AND TO_DATE( '" + objEmployeeDTO.ToDate + "', 'dd/mm/yyyy') ";
             }


             if (objEmployeeDTO.SupplierName.Length > 0)
             {

                 sql = sql + "and (lower(SUPPLIER_NAME) like lower( '%" + objEmployeeDTO.SupplierName + "%')  or upper(SUPPLIER_NAME)like upper('%" + objEmployeeDTO.SupplierName + "%')) ";
             }

            if (objEmployeeDTO.EmployeeName.Length > 0)
            {

                sql = sql + "and (lower(emp_name) like lower( '%" + objEmployeeDTO.EmployeeName + "%')  or upper(emp_name)like upper('%" + objEmployeeDTO.EmployeeName + "%')) ";
            }



          



            sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable employeeRecordforTransfer(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME " +


                   "FROM VEW_BASIC_INFO WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "'";



             if (objEmployeeDTO.EmployeeId.Length > 0)
             {

                 sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
             }

             if (objEmployeeDTO.CardNo.Length > 0)
             {

                 sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
             }


             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }

             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }

         

         public DataTable searchEmployeeRecordforAdvanceEntry(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME " +


                   "FROM VEW_BASIC_INFO WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "'";



             if (objEmployeeDTO.EmployeeId.Length > 0)
             {

                 sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
             }

             if (objEmployeeDTO.CardNo.Length > 0)
             {

                 sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
             }


             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }

             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchEmployeeRecordforHalf(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME " +


                   "FROM VEW_SEARCH_HO_EMPLOYEE_HALF WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "'";



             if (objEmployeeDTO.EmployeeId.Length > 0)
             {

                 sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
             }

             if (objEmployeeDTO.CardNo.Length > 0)
             {

                 sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
             }


             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }

             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchEmployeeRecordHold(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME " +


                   "FROM VEW_BASIC_INFO WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "'";



             if (objEmployeeDTO.EmployeeId.Length > 0)
             {

                 sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
             }

             if (objEmployeeDTO.CardNo.Length > 0)
             {

                 sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
             }


             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }

             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public EmployeeDTO searchEmployeeMisc(string strEmployeeId, string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
         {
             
             EmployeeDTO objEmployeeDTO = new EmployeeDTO();
             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                   "to_char(nvl(1, '')), " +
                   "to_char(UPPER(employee_name)) " +

                   "FROM VEW_BASIC_INFO_HO_FOR_MISC WHERE head_office_id = '" + strHeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + strBranchOfficeId + "' and employee_id = '" + strEmployeeId + "' ";



             if (strSectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + strSectionId + "'";
             }

             if (strUnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + strUnitId + "'";
             }

             

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataReader objDataReader;

             using (OracleConnection strConn = GetConnection())
             {

                 objCommand.Connection = strConn;
                 strConn.Open();
                 objDataReader = objCommand.ExecuteReader();
                 if (objDataReader.Read())
                 {
                     objEmployeeDTO.Msg =  objDataReader.GetString(0);
                     objEmployeeDTO.EmployeeName = objDataReader.GetString(1);

                 }



             }


             return objEmployeeDTO;

         }
         public DataTable searchInactiveEmployee(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +

                    "INACTIVE_YEAR, " +
                    "INACTIVE_MONTH, " +
                    "status_id, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME, " +
                    "create_date, " +
                    "status_name, " +

                    "Joining_date, " +
                    "UNIT_NAME, " +
                    "SECTION_NAME, " +
                    "designation_id, " +
                    "unit_id, " +
                    "section_id, " +
                    "active_yn, " +
                    "resign_date, " +
                    "resign_cause " +
                    "FROM vew_search_inactive_employee WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "'";
            
             if (objEmployeeDTO.Year.Length > 0)
             {

                 sql = sql + "and inactive_year = '" + objEmployeeDTO.Year + "'";
             }

             if (objEmployeeDTO.Month.Length > 0)
             {

                 sql = sql + "and inactive_month = '" + objEmployeeDTO.Month + "'";
             }


             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }

             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchInactiveEmployeeList(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                   
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME, " +
                     "EMPLOYEE_ID " +


                   "FROM VEW_SEARCH_INACTIVE_LIST WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "'";


             if (objEmployeeDTO.CardNo.Length > 0)
             {

                 sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
             }
             
             if (objEmployeeDTO.EmployeeId.Length > 0)
             {

                 sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
             }

             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }

             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchActiveEmployeeList(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +

                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME, " +
                     "EMPLOYEE_ID, " +
                     "ISSUE_DATE, " +
                     "EMPLOYEE_PIC, " +
                     "IMAGE_NAME " +


                   "FROM VEW_SEARCH_ACTIVE_LIST WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "'";


             if (objEmployeeDTO.CardNo.Length > 0)
             {

                 sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
             }

             if (objEmployeeDTO.EmployeeId.Length > 0)
             {

                 sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
             }

             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }
            if (objEmployeeDTO.FromCreateDate.Length > 6 && objEmployeeDTO.ToCreateDate.Length > 6)
            {

                sql = sql + "and create_date between to_date ( '" + objEmployeeDTO.FromCreateDate + "', 'dd/mm/yyyy') and to_date ( '" + objEmployeeDTO.ToCreateDate + "', 'dd/mm/yyyy')   ";
            }
            sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }

         public DataTable searchIncEmployeeList(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +

                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME, " +
                     "EMPLOYEE_ID " +


                   "FROM VEW_SEARCH_EMP_LIST_ENCREMENT WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' and INCREMENT_YEAR = '"+objEmployeeDTO.Year+"' ";


             if (objEmployeeDTO.CardNo.Length > 0)
             {

                 sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
             }

             if (objEmployeeDTO.EmployeeId.Length > 0)
             {

                 sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
             }

             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }

             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchEmployeeList(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME, " +
                     "EMPLOYEE_ID " +


                   "FROM VEW_BASIC_INFO WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "'";


             if (objEmployeeDTO.CardNo.Length > 0)
             {

                 sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
             }

             if (objEmployeeDTO.EmployeeId.Length > 0)
             {

                 sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
             }

             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }

             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchTaxEntry(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME, " +
                    "TAX_FEE, " +
                    "EMPLOYEE_ID " +
                  


                   "FROM vew_search_tax_entry WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' and salary_year = '" + objEmployeeDTO.Year + "' and salary_month = '" + objEmployeeDTO.Month + "' ";



            


             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }

             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchAdvanceEntry(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME, " +
                    "ADVANCE_FEE, " +
                    "ADVANCE_DEDUCT_FEE, "+
                    "EMPLOYEE_ID, " +
                    "LEDGER_PAGE_NO "+



                   "FROM vew_search_advance_entry WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' and advance_year = '" + objEmployeeDTO.Year + "' and advance_month = '" + objEmployeeDTO.Month + "' ";




             if (objEmployeeDTO.EmployeeId.Length > 0)
             {

                 sql = sql + "and EMPLOYEE_ID = '" + objEmployeeDTO.EmployeeId + "'";
             }

             if (objEmployeeDTO.CardNo.Length > 0)
             {

                 sql = sql + "and CARD_NO = '" + objEmployeeDTO.CardNo + "'";
             }


             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }

             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchEmployeeInformation(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME, " +
                    "designation_id " +
                    
                   "FROM VEW_SEARCH_EMPLOYEE_INFO WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' AND active_yn = '" + objEmployeeDTO.EmployeeActiveYn + "' ";
            
             if (objEmployeeDTO.EmployeeId.Length > 0)
             {

                 sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
             }


             if (objEmployeeDTO.EmpId.Length > 0)
             {

                 sql = sql + "and employee_id = '" + objEmployeeDTO.EmpId + "'";
             }

             if (objEmployeeDTO.CardNo.Length > 0)
             {

                 sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
             }


             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }


             if (objEmployeeDTO.PunchCode.Length > 0)
             {

                 sql = sql + "and punch_code = '" + objEmployeeDTO.PunchCode + "'";
             }


             if (objEmployeeDTO.GradeNo.Length > 0)
             {

                 sql = sql + "and grade_no = '" + objEmployeeDTO.GradeNo + "'";
             }

             if (objEmployeeDTO.BloodGroupId.Length > 0)
             {

                 sql = sql + "and blood_group_id = '" + objEmployeeDTO.BloodGroupId + "'";
             }

             if (objEmployeeDTO.FromConfirmDate.Length > 6 && objEmployeeDTO.ToConfirmDate.Length > 6)
             {

                 sql = sql + "and confirm_date between to_date ( '" + objEmployeeDTO.FromConfirmDate + "', 'dd/mm/yyyy') and to_date ( '" + objEmployeeDTO.ToConfirmDate + "', 'dd/mm/yyyy')   ";
             }


             if (objEmployeeDTO.EmployeeName.Length > 0)
             {

                 sql = sql + "and (lower(employee_name) like lower( '%" + objEmployeeDTO.EmployeeName + "%')  or upper(employee_name)like upper('%" + objEmployeeDTO.EmployeeName + "%')) ";
             }

             if (objEmployeeDTO.EmployeeTypeId.Length > 0)
             {

                 sql = sql + "and EMPLOYEE_TYPE_ID = '" + objEmployeeDTO.EmployeeTypeId + "'";
             }
            if (objEmployeeDTO.NIDNo.Length > 0)
            {
                sql = sql + "and NID_NO = '" + objEmployeeDTO.NIDNo + "'";
            }


            sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }


        //New
        public DataTable GetEmployeeById(string employeeId)
        {

            DataTable dt = new DataTable();
            string sql = "";
            sql = "SELECT " +
                   "EMPLOYEE_ID, " +
                   "EMPLOYEE_NAME, " +
                   "BRANCH_OFFICE_ID, " +
                   "HEAD_OFFICE_ID " +
                   "FROM EMPLOYEE_BASIC WHERE EMPLOYEE_ID = '" + employeeId + "' AND active_yn = 'Y'" ;
            
            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataAdapter.Fill(dt);
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
            return dt;
        }

        public DataTable searchEmployeeRecordForProcess(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME " +


                   "FROM VEW_SEARCH_EMPLOYEE_INFO WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' AND active_yn = '" + objEmployeeDTO.EmployeeActiveYn + "' ";



             if (objEmployeeDTO.EmployeeId.Length > 0)
             {

                 sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
             }


            
             if (objEmployeeDTO.CardNo.Length > 0)
             {

                 sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
             }


             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }


             if (objEmployeeDTO.EmployeeName.Length > 0)
             {

                 sql = sql + "and employee_name like '%" + objEmployeeDTO.EmployeeName + "%' ";
             }



             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchJobHistory(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME, " +
                    "GROSS_SALARY, "+
                    "OCCURENCE_TYPE_NAME, "+
                    "TO_CHAR(JOINING_DATE, 'dd/mm/yyyy')JOINING_DATE " +

                   "FROM VEW_EMPLOYEE_JOB_HISTORY WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' ";



             if (objEmployeeDTO.EmployeeId.Length > 0)
             {

                 sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
             }


           



             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchEmployeeSummeryInformation(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME, " +
                    "to_char(joining_date, 'dd/mm/yyyy')joining_date, " +
                    "UNIT_NAME, "+
                    "job_type_name, "+
                    "employee_pic "+


                   "FROM VEW_SEARCH_EMPLOYEE_INFO WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' AND employee_id = '" + objEmployeeDTO.EmployeeId + "'";



           

           

             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchSalaryInfoHO(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME, " +
                    "salary_year, "+
                    "advance_fee, "+
                    "arrear_fee, "+
                    "FOOD_ALLOWANCE_FEE, "+
                    "FOOD_DEDUCT_FEE, "+
                    "WORKING_DAY, "+
                    "ADVANCE_SALARY "+

                   "FROM VEW_SEARCH_SALARY_INFO_HO WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' and salary_year = '" + objEmployeeDTO.Year + "' and salary_month = '" + objEmployeeDTO.Month + "'  ";



             //if (objEmployeeDTO.EmployeeId.Length > 0)
             //{

             //    sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
             //}

             //if (objEmployeeDTO.CardNo.Length > 0)
             //{

             //    sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
             //}


             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }


          

             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
        public DataTable searchPunchingInfo(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
                   "rownum sl, " +
                   "CARD_NO, " +
                   "EMPLOYEE_ID, " +
                   "EMPLOYEE_NAME, " +
                   "DESIGNATION_NAME, " +
                   "PUNCH_CODE " +

                  "FROM VEW_BASIC_INFO WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' and punch_code <> 0 ";



            //if (objEmployeeDTO.EmployeeId.Length > 0)
            //{

            //    sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
            //}

            //if (objEmployeeDTO.CardNo.Length > 0)
            //{

            //    sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
            //}


            if (objEmployeeDTO.SectionId.Length > 0)
            {

                sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
            }

            if (objEmployeeDTO.UnitId.Length > 0)
            {

                sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
            }




            sql = sql + "order by SL ";

            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataAdapter.Fill(dt);

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



            return dt;

        }
        public DataTable searchSalaryInfoHOMISC(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME, " +
                    "salary_year, " +
                    "advance_fee, " +
                    "arrear_fee, " +
                    "FOOD_ALLOWANCE_FEE, "+
                    "FOOD_DEDUCT_FEE, "+
                    "WORKING_DAY, "+
                    "ADVANCE_SALARY "+


                   "FROM VEW_SEARCH_SALARY_INFO_HO_MISC WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' and salary_year = '" + objEmployeeDTO.Year + "' and salary_month = '" + objEmployeeDTO.Month + "' ";





             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + " and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }




             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchEmployeeRecordforHOMiscEntry(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME " +


                   "FROM VEW_BASIC_INFO_HO_FOR_MISC WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "'";



             if (objEmployeeDTO.EmployeeId.Length > 0)
             {

                 sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
             }

             if (objEmployeeDTO.CardNo.Length > 0)
             {

                 sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
             }


             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }

             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchEmployeeRecordforAttendenceEntry(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME " +


                   "FROM VEW_GET_EMP_FOR_ATTENDENCE WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "'";



             if (objEmployeeDTO.EmployeeId.Length > 0)
             {

                 sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
             }

             if (objEmployeeDTO.CardNo.Length > 0)
             {

                 sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
             }


             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }

             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }

         public DataTable searchEmployeeRecordforSalaryCertificate(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME " +


                   "FROM VEW_EMPLOYEE_DETAIL_INFO WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "'";



             if (objEmployeeDTO.EmployeeId.Length > 0)
             {

                 sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
             }

             if (objEmployeeDTO.CardNo.Length > 0)
             {

                 sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
             }


             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }

             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchSalaryCertificateEntry(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME, " +
                    "certificate_year, "+
                    "certificate_month "+


                   "FROM vew_search_salary_certif_entry WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' and certificate_year = '" + objEmployeeDTO.Year + "' and certificate_month = '" + objEmployeeDTO.Month + "' ";



          


             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }

             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }

        public DataTable searchEmployeeRecordforTemp(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
                   "rownum sl, " +
                   "CARD_NO, " +
                   "EMPLOYEE_ID, " +
                   "EMPLOYEE_NAME, " +
                   "DESIGNATION_NAME, " +
                   "GRADE_NO " +

                  "FROM VEW_BASIC_INFO_RESIGN WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "'";


            if (objEmployeeDTO.CardNo.Length > 0)
            {

                sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
            }

            if (objEmployeeDTO.EmployeeId.Length > 0)
            {

                sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
            }

            if (objEmployeeDTO.SectionId.Length > 0)
            {

                sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
            }

            if (objEmployeeDTO.UnitId.Length > 0)
            {

                sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
            }

            sql = sql + "order by SL ";

            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataAdapter.Fill(dt);

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



            return dt;

        }

        public DataTable searchEmployeeRecordforResignEntry(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME, " +
                    "GRADE_NO " +

                   "FROM VEW_BASIC_INFO_RESIGN WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "'";

            if (objEmployeeDTO.EmployeeTypeId == "1") //Staff
            {
                sql = sql + " and first_salary > 0 ";
            }
            if (objEmployeeDTO.EmployeeTypeId == "2") //Staff
            {
                sql = sql + " and (first_salary = 0 or first_salary is null)";
            }

            if (objEmployeeDTO.CardNo.Length > 0)
             {
                 sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
             }

             if (objEmployeeDTO.EmployeeId.Length > 0)
             {
                 sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
             }

             if (objEmployeeDTO.SectionId.Length > 0)
             {
                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {
                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }

             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);
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
             return dt;
         }
        public DataTable searchEmployeeRecordforResignEntryOT(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
                   "rownum sl, " +
                   "CARD_NO, " +
                   "EMPLOYEE_ID, " +
                   "EMPLOYEE_NAME, " +
                   "DESIGNATION_NAME, " +
                   "GRADE_NO " +

                  "FROM VEW_SEARCH_RESIGN_EMP_FOR_OT WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' AND salary_year = '"+objEmployeeDTO.Year+"' and salary_month = '"+objEmployeeDTO.Month+"' ";


            if (objEmployeeDTO.CardNo.Length > 0)
            {

                sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
            }

            if (objEmployeeDTO.EmployeeId.Length > 0)
            {

                sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
            }

            if (objEmployeeDTO.SectionId.Length > 0)
            {

                sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
            }

            if (objEmployeeDTO.UnitId.Length > 0)
            {

                sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
            }

            sql = sql + "order by SL ";

            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataAdapter.Fill(dt);

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



            return dt;

        }

        //public DataTable searchEmployeeRecordforMiscEntryWorker(EmployeeDTO objEmployeeDTO)
        // {

        //     DataTable dt = new DataTable();
        //     string sql = "";

        //     sql = "SELECT " +
        //            "rownum sl, " +
        //            "CARD_NO, " +
        //            "EMPLOYEE_ID, " +
        //            "EMPLOYEE_NAME, " +
        //            "DESIGNATION_NAME, " +
        //            "GRADE_NO "+

        //           "FROM VEW_BASIC_INFO_WORKER WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "'";


        //    if (objEmployeeDTO.CardNo.Length > 0)
        //    {

        //        sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
        //    }

        //    if (objEmployeeDTO.EmployeeId.Length > 0)
        //     {

        //         sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
        //     }

        //     if (objEmployeeDTO.SectionId.Length > 0)
        //     {

        //         sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
        //     }

        //     if (objEmployeeDTO.UnitId.Length > 0)
        //     {

        //         sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
        //     }

        //     sql = sql + "order by SL ";

        //     OracleCommand objCommand = new OracleCommand(sql);
        //     OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
        //     using (OracleConnection strConn = GetConnection())
        //     {
        //         try
        //         {
        //             objCommand.Connection = strConn;
        //             strConn.Open();
        //             objDataAdapter.Fill(dt);

        //         }
        //         catch (Exception ex)
        //         {

        //             throw new Exception("Error : " + ex.Message);
        //         }

        //         finally
        //         {

        //             strConn.Close();
        //         }

        //     }



        //     return dt;

        // }

        public DataTable searchEmployeeRecordforMiscEntryWorker(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
                   "rownum sl, " +
                   "CARD_NO, " +
                   "EMPLOYEE_ID, " +
                   "EMPLOYEE_NAME, " +
                   "DESIGNATION_NAME, " +
                   "joining_date," +
                   "UNIT_ID, " +
                   "SECTION_ID, " +

                   "UNIT_NAME, " +
                   "SECTION_NAME, " +
                   "gross_salary, " +
                   "first_salary, " +
                   "employee_type_id, " +
                   "GRADE_NO " +
                   "FROM VEW_HALF_SAL_PAYABLE_WORKER WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "'";
            
            if (objEmployeeDTO.SectionId.Length > 0)
            {
                sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
            }

            if (objEmployeeDTO.UnitId.Length > 0)
            {
                sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
            }

            sql = sql + "order by SL ";

            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataAdapter.Fill(dt);
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
            return dt;
        }

        
        public DataTable GetPayableWorker(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
                   "rownum sl, " +
                   "CARD_NO, " +
                   "EMPLOYEE_ID, " +
                   "EMPLOYEE_NAME, " +
                   "DESIGNATION_NAME, " +

                   "UNIT_ID, " +
                   "SECTION_ID, " +

                   "UNIT_NAME, " +
                   "SECTION_NAME, " +
                   "gross_salary, " +
                   "first_salary, " +
                   "GRADE_NO " +
                "FROM VEW_PAYABLE_BASIC_INFO_WORKER WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "'";
            
            if (objEmployeeDTO.SectionId.Length > 0)
            {

                sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
            }

            if (objEmployeeDTO.UnitId.Length > 0)
            {
                sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
            }

            if (objEmployeeDTO.EmployeeId.Length > 0)
            {
                sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
            }

            if (objEmployeeDTO.CardNo.Length > 0)
            {
                sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
            }

            sql = sql + "order by SL ";

            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataAdapter.Fill(dt);
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
            return dt;
        }


        public DataTable SearchEmpForGazetteProcess(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
                   "rownum sl, " +
                   "CARD_NO, " +
                   "EMPLOYEE_ID, " +
                   "EMPLOYEE_NAME, " +
                   "DESIGNATION_NAME, " +
                   "GRADE_NO " +

                  "FROM VEW_BASIC_INFO_WORKER_GAZETTE WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "'";


            //if (objEmployeeDTO.CardNo.Length > 0)
            //{

            //    sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
            //}

            if (objEmployeeDTO.EmployeeId.Length > 0)
            {

                sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
            }

            if (objEmployeeDTO.SectionId.Length > 0)
            {
                sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
            }

            if (objEmployeeDTO.UnitId.Length > 0)
            {
                sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
            }
            sql = sql + "order by SL ";

            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataAdapter.Fill(dt);
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
            return dt;
        }
        public DataTable searchWorkerRecordforArrear(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME, " +
                    "TO_CHAR(JOINING_DATE, 'dd/mm/yyyy')JOINING_DATE, "+

                      "(SELECT   increment_amount "+
                 " FROM   INCREMENT_WORKER "+
                " WHERE   employee_id = e.employee_id "+
                       " AND (SELECT   TO_CHAR (joining_date, 'YYYY') "+
                              " FROM   employee_job_detail "+
                             " WHERE       employee_id = e.employee_id "+
                                     " AND head_office_id = e.head_office_id "+
                                     " AND branch_office_id = e.branch_office_id) = '"+objEmployeeDTO.Year+"' "+
                        "AND TO_NUMBER((SELECT   TO_CHAR (joining_date, 'MM') "+
                         "      FROM   employee_job_detail "+
                          "    WHERE       employee_id = e.employee_id "+
                           "           AND head_office_id = e.head_office_id "+
                            "          AND branch_office_id = e.branch_office_id)) = "+
                            "  '"+objEmployeeDTO.Month+"' "+
                       " AND head_office_id = e.head_office_id "+
                       " AND branch_office_id = e.branch_office_id)increment_amount " +



                   "FROM vew_search_worker_for_arrear e WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' AND JOINING_YEAR = '" + objEmployeeDTO.Year + "' AND TO_NUMBER(JOINING_MONTH) = '" + objEmployeeDTO.Month + "' ";


             if (objEmployeeDTO.CardNo.Length > 0)
             {

                 sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
             }

             if (objEmployeeDTO.EmployeeId.Length > 0)
             {

                 sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
             }

             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }

             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchWorkerArrearEntry(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME, " +
                    "INCREMENT_AMOUNT_MANUAL, " +
                    "to_char(joining_date, 'dd/mm/yyyy')joining_date "+


                   "FROM vew_search_arrear_entry WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' AND arrear_year = '" + objEmployeeDTO.Year + "' AND arrear_month = '" + objEmployeeDTO.Month + "' ";


             if (objEmployeeDTO.CardNo.Length > 0)
             {

                 sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
             }

             if (objEmployeeDTO.EmployeeId.Length > 0)
             {

                 sql = sql + "and EMPLOYEE_ID = '" + objEmployeeDTO.EmployeeId + "'";
             }


           

             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }

             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchWorkerRecordForProcess(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME, " +
                    "EFFICIENCY_NO, " +
                    "CAPACITY, " +
                    "MACHINE_NAME, "+
                    "SMV, "+
                    "TARGET_VALUE, "+
                    "PROCESS_NAME "+
                  

                   "FROM vew_worker_process WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "'";


             if (objEmployeeDTO.ProcessCode.Length > 0)
             {

                 sql = sql + "and PROCESS_CODE = '" + objEmployeeDTO.ProcessCode + "'";
             }


             if (objEmployeeDTO.CardNo.Length > 0)
             {

                 sql = sql + "and Card_No = '" + objEmployeeDTO.CardNo + "'";
             }

             if (objEmployeeDTO.EmployeeId.Length > 0)
             {

                 sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
             }

             if (objEmployeeDTO.ProcessId.Length > 0)
             {

                 sql = sql + "and process_id = '" + objEmployeeDTO.ProcessId + "'";

             }
            

             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchWorkerRecord(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME, " +
                    "GRADE_NO " +

                   "FROM VEW_BASIC_INFO_WORKER WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "'";


             if (objEmployeeDTO.CardNo.Length > 0)
             {

                 sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
             }

             if (objEmployeeDTO.EmployeeId.Length > 0)
             {

                 sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }

             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

            

             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchOperatorRecordForVerification(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             if (objEmployeeDTO.UnitId == "17")
             {

                 sql = "SELECT " +
                       "rownum sl, " +
                       "CARD_NO, " +
                       "EMPLOYEE_ID, " +
                       "EMPLOYEE_NAME, " +
                       "DESIGNATION_NAME, " +
                       "GRADE_NO, " +
                       "to_char(JOINING_DATE, 'dd/mm/yyyy')JOINING_DATE, " +
                       "GROSS_SALARY, " +
                       "to_char(PRODUCTION_DATE,'dd/mm/yyyy')PRODUCTION_DATE, " +
                       "DHU " +

                      "FROM VEW_SEARCH_OP_INFO_RANGE WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' AND LINE_ID in ('17','18','19','20','21','35')";




                 if (objEmployeeDTO.FromDate.Length > 6 && objEmployeeDTO.ToDate.Length > 6)
                 {

                     sql = sql + "and PRODUCTION_DATE BETWEEN TO_DATE( '" + objEmployeeDTO.FromDate + "', 'dd/mm/yyyy') AND TO_DATE('" + objEmployeeDTO.ToDate + "', 'dd/mm/yyyy')";
                 }

                 if (objEmployeeDTO.DHURange.Length > 0)
                 {
                     if (objEmployeeDTO.DHURange == "1")
                     {
                         sql = sql + "and (DHU >= 0 AND DHU <= 10.99) ";
                     }
                     else if (objEmployeeDTO.DHURange == "2")
                     {
                         sql = sql + "and (DHU >= 11 AND DHU <= 19.99) ";
                     }
                     else if (objEmployeeDTO.DHURange == "3")
                     {
                         sql = sql + " and DHU >= 20 ";

                     }

                 }


             }

             else if (objEmployeeDTO.UnitId == "22")
             {

                 sql = "SELECT " +
                       "rownum sl, " +
                       "CARD_NO, " +
                       "EMPLOYEE_ID, " +
                       "EMPLOYEE_NAME, " +
                       "DESIGNATION_NAME, " +
                       "GRADE_NO, " +
                       "to_char(JOINING_DATE, 'dd/mm/yyyy')JOINING_DATE, " +
                       "GROSS_SALARY, " +
                       "to_char(PRODUCTION_DATE,'dd/mm/yyyy')PRODUCTION_DATE, " +
                       "DHU " +

                      "FROM VEW_SEARCH_OP_INFO_RANGE WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' AND LINE_ID in ('22','23','24','25','26','34')";




                 if (objEmployeeDTO.FromDate.Length > 6 && objEmployeeDTO.ToDate.Length > 6)
                 {

                     sql = sql + "and PRODUCTION_DATE BETWEEN TO_DATE( '" + objEmployeeDTO.FromDate + "', 'dd/mm/yyyy') AND TO_DATE('" + objEmployeeDTO.ToDate + "', 'dd/mm/yyyy')";
                 }

                 if (objEmployeeDTO.DHURange.Length > 0)
                 {
                     if (objEmployeeDTO.DHURange == "1")
                     {
                         sql = sql + "and (DHU >= 0 AND DHU <= 10.99) ";
                     }
                     else if (objEmployeeDTO.DHURange == "2")
                     {
                         sql = sql + "and (DHU >= 11 AND DHU <= 19.99) ";
                     }
                     else if (objEmployeeDTO.DHURange == "3")
                     {
                         sql = sql + " and DHU >= 20 ";

                     }

                 }


             }


             else if (objEmployeeDTO.UnitId == "27")
             {

                 sql = "SELECT " +
                       "rownum sl, " +
                       "CARD_NO, " +
                       "EMPLOYEE_ID, " +
                       "EMPLOYEE_NAME, " +
                       "DESIGNATION_NAME, " +
                       "GRADE_NO, " +
                       "to_char(JOINING_DATE, 'dd/mm/yyyy')JOINING_DATE, " +
                       "GROSS_SALARY, " +
                       "to_char(PRODUCTION_DATE,'dd/mm/yyyy')PRODUCTION_DATE, " +
                       "DHU " +

                      "FROM VEW_SEARCH_OP_INFO_RANGE WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' AND LINE_ID in ('27','28','29','30','31','36')";




                 if (objEmployeeDTO.FromDate.Length > 6 && objEmployeeDTO.ToDate.Length > 6)
                 {

                     sql = sql + "and PRODUCTION_DATE BETWEEN TO_DATE( '" + objEmployeeDTO.FromDate + "', 'dd/mm/yyyy') AND TO_DATE('" + objEmployeeDTO.ToDate + "', 'dd/mm/yyyy')";
                 }

                 if (objEmployeeDTO.DHURange.Length > 0)
                 {
                     if (objEmployeeDTO.DHURange == "1")
                     {
                         sql = sql + "and (DHU >= 0 AND DHU <= 10.99) ";
                     }
                     else if (objEmployeeDTO.DHURange == "2")
                     {
                         sql = sql + "and (DHU >= 11 AND DHU <= 19.99) ";
                     }
                     else if (objEmployeeDTO.DHURange == "3")
                     {
                         sql = sql + " and DHU >= 20 ";

                     }

                 }


             }

             else if (objEmployeeDTO.UnitId == "32")
             {

                 sql = "SELECT " +
                       "rownum sl, " +
                       "CARD_NO, " +
                       "EMPLOYEE_ID, " +
                       "EMPLOYEE_NAME, " +
                       "DESIGNATION_NAME, " +
                       "GRADE_NO, " +
                       "to_char(JOINING_DATE, 'dd/mm/yyyy')JOINING_DATE, " +
                       "GROSS_SALARY, " +
                       "to_char(PRODUCTION_DATE,'dd/mm/yyyy')PRODUCTION_DATE, " +
                       "DHU " +

                      "FROM VEW_SEARCH_OP_INFO_RANGE WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' AND LINE_ID in ('32','37','38','39','40','41')";




                 if (objEmployeeDTO.FromDate.Length > 6 && objEmployeeDTO.ToDate.Length > 6)
                 {

                     sql = sql + "and PRODUCTION_DATE BETWEEN TO_DATE( '" + objEmployeeDTO.FromDate + "', 'dd/mm/yyyy') AND TO_DATE('" + objEmployeeDTO.ToDate + "', 'dd/mm/yyyy')";
                 }

                 if (objEmployeeDTO.DHURange.Length > 0)
                 {
                     if (objEmployeeDTO.DHURange == "1")
                     {
                         sql = sql + "and (DHU >= 0 AND DHU <= 10.99) ";
                     }
                     else if (objEmployeeDTO.DHURange == "2")
                     {
                         sql = sql + "and (DHU >= 11 AND DHU <= 19.99) ";
                     }
                     else if (objEmployeeDTO.DHURange == "3")
                     {
                         sql = sql + " and DHU >= 20 ";

                     }

                 }


             }

             else
             {

                 sql = "SELECT " +
                        "rownum sl, " +
                        "CARD_NO, " +
                        "EMPLOYEE_ID, " +
                        "EMPLOYEE_NAME, " +
                        "DESIGNATION_NAME, " +
                        "GRADE_NO, " +
                        "to_char(JOINING_DATE, 'dd/mm/yyyy')JOINING_DATE, " +
                        "GROSS_SALARY, " +
                        "to_char(PRODUCTION_DATE,'dd/mm/yyyy')PRODUCTION_DATE, " +
                        "DHU " +

                       "FROM VEW_SEARCH_OP_INFO_RANGE WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' ";



                 if (objEmployeeDTO.CardNo.Length > 0)
                 {

                     sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
                 }

                 if (objEmployeeDTO.LineId.Length > 0)
                 {

                     sql = sql + "and LINE_ID = '" + objEmployeeDTO.LineId + "'";
                 }


                 if (objEmployeeDTO.FromDate.Length > 6 && objEmployeeDTO.ToDate.Length > 6)
                 {

                     sql = sql + "and PRODUCTION_DATE BETWEEN TO_DATE( '" + objEmployeeDTO.FromDate + "', 'dd/mm/yyyy') AND TO_DATE('" + objEmployeeDTO.ToDate + "', 'dd/mm/yyyy')";
                 }

                 if (objEmployeeDTO.DHURange.Length > 0)
                 {
                     if (objEmployeeDTO.DHURange == "1")
                     {
                         sql = sql + "and (DHU >= 0 AND DHU <= 10.99) ";
                     }
                     else if (objEmployeeDTO.DHURange == "2")
                     {
                         sql = sql + "and (DHU >= 11 AND DHU <= 19.99) ";
                     }
                     else if (objEmployeeDTO.DHURange == "3")
                     {
                         sql = sql + " and DHU >= 20 ";

                     }

                 }


             }
             


             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchEmployeeProcess(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "process_name, " +
                    "EFFICIENCY_100 " +


                   "FROM vew_search_emp_process_name WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' AND EMPLOYEE_ID = '"+objEmployeeDTO.EmployeeId+"' ";


          



             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchConselingInfo(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "CARD_NO, "+
                    "DESIGNATION_NAME, "+
                    "to_char(COUNSELING_DATE, 'dd/mm/yyyy')COUNSELING_DATE, " +
                     "REMARKS, " +
                     "DHU "+

                   "FROM VEW_SEARCH_COUNSELING_INFO WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' AND EMPLOYEE_ID = '" + objEmployeeDTO.EmployeeId + "' ";






             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchProcessRecord(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +

                    "TOP_PROCESS_ID, " +
                    "TOP_PROCESS_NAME " +


                   "FROM PROCESS WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "'ORDER BY TOP_PROCESS_ID ";


            

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
        

         public DataTable searchEmployeeRecordforTransfer(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME " +


                   "FROM VEW_BASIC_INFO WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "'";


             if (objEmployeeDTO.CardNo.Length > 0)
             {

                 sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
             }

             if (objEmployeeDTO.EmployeeId.Length > 0)
             {

                 sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
             }

             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }

             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
        public DataTable employeeRecordForYearlyPromotion(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
                   "rownum sl, " +
                   "CARD_NO, " +
                   "EMPLOYEE_ID, " +
                   //"UNIT_ID, " +
                   //"SECTION_ID, " +
                   "EMPLOYEE_NAME, " +
                   "DESIGNATION_NAME " +
                   
                  "FROM VEW_BASIC_INFO WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "'";

            if (objEmployeeDTO.CardNo.Length > 0)
            {

                sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
            }

            if (objEmployeeDTO.EmployeeId.Length > 0)
            {

                sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
            }

            if (objEmployeeDTO.SectionId.Length > 0)
            {

                sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
            }

            if (objEmployeeDTO.UnitId.Length > 0)
            {

                sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
            }

            sql = sql + "order by SL ";

            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataAdapter.Fill(dt);

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



            return dt;

        }

        public DataTable LoadWorkerPromotionRecord(EmployeeDTO objEmployeeDTO)
        {

            DataSet ds = null;
            DataTable myTable = new DataTable();
            try
            {
                string strMsg = "";
                OracleTransaction objOracleTransaction;
                OracleCommand objOracleCommand = new OracleCommand("SP_GET_PROMOTION_QUEUE");
                objOracleCommand.CommandType = CommandType.StoredProcedure;
                //p_promotion_year
                objOracleCommand.Parameters.Add("p_promotion_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.PromotionYear;
                objOracleCommand.Parameters.Add("p_promotion_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Month;

                //objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UnitId;
                //objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SectionId;

                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return myTable;

        }


        //NEW: 29.09.2020
        public DataTable GetVirtualTransfer(EmployeeDTO objEmployeeDTO)
        {

            DataSet ds = null;
            DataTable myTable = new DataTable();
            try
            {
                string strMsg = "";
                OracleTransaction objOracleTransaction;
                OracleCommand objOracleCommand = new OracleCommand("SP_GET_VIRTUAL_TRANSFER");
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UnitId;
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SectionId;

                objOracleCommand.Parameters.Add("p_from_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.FromDate;
                objOracleCommand.Parameters.Add("p_to_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.ToDate;


                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return myTable;

        }

        public DataTable GetVirtualTransferByTransferId(string transferId)
        {

            DataTable myTable = new DataTable();
            try
            {                                
                OracleCommand objOracleCommand = new OracleCommand("SP_GET_VIRTUAL_TRANSFER_BY_ID");
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                objOracleCommand.Parameters.Add("P_TRANSFER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = transferId;
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
                        trans.Commit();
                        strConn.Close();
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return myTable;

        }


        public DataTable GetSecurityLog(EmployeeDTO objEmployeeDTO)
        {

            DataSet ds = null;
            DataTable myTable = new DataTable();
            try
            {
                string strMsg = "";
                OracleTransaction objOracleTransaction;
                OracleCommand objOracleCommand = new OracleCommand("SP_GET_SECURITY_LOG");
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;
                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
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
                        trans.Commit();
                        strConn.Close();
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return myTable;

        }

        //new
        public List<EmployeeDTO> GetEmployeePicture(EmployeeDTO objEmployeeDTO)
        {

            EmployeeDTO objEmployee = new EmployeeDTO();
            List<EmployeeDTO> objEmployees = new List<EmployeeDTO>();
            
                OracleCommand objOracleCommand = new OracleCommand("SP_GET_EMPLOYEE_IMAGE");
                OracleDataReader objDataReader;
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                //objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;
                objOracleCommand.Parameters.Add("p_employee_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeTypeId;
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UnitId;
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SectionId;

                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
                objOracleCommand.Parameters.Add("p_dbcursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                string VALUE = string.Empty;

                using (OracleConnection strConn = GetConnection())
                {
                    try
                    {
                        objOracleCommand.Connection = strConn;
                        strConn.Open();
                        objDataReader = objOracleCommand.ExecuteReader();
                        //try
                        //{
                            while (objDataReader.Read())
                            {
                                objEmployee = new EmployeeDTO();

                                //objEmployee.EmployeeId =  objDataReader.GetString(0);
                                //objEmployee.EmployeePic = (byte[]) (objDataReader.GetOracleBlob(1)).Value;
                                //objEmployees.Add(objEmployee);

                                objEmployee.EmployeeId = Convert.ToString(objDataReader["EMPLOYEE_ID"]);
                                objEmployee.EmployeePic = (byte[])objDataReader["EMPLOYEE_PIC"];
                                objEmployees.Add(objEmployee);
                            }

                            //old
                            //objOracleCommand.Connection = strConn;
                            //strConn.Open();
                            //trans = strConn.BeginTransaction();
                            //myTable.Load(objOracleCommand.ExecuteReader());
                            ////byte[] imgData = (byte[])objDataReader["EMPLOYEE_PIC"];
                            //trans.Commit();
                            //strConn.Close();
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
                    return objEmployees;                  
        }
        //new
        public string UpdateEmployeePicture(EmployeeDTO objEmployeeDTO)
        {

            string strMsg = "";
            OracleTransaction trans = null;
            OracleCommand objOracleCommand = new OracleCommand("sp_update_employee_picture");

            objOracleCommand.CommandType = CommandType.StoredProcedure;
            
            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;
            objOracleCommand.Parameters.Add("p_employee_pic", OracleDbType.Blob, ParameterDirection.Input).Value = objEmployeeDTO.EmployeePic;
            //objOracleCommand.Parameters.Add("p_thumbnail", OracleDbType.Blob, ParameterDirection.Input).Value = objEmployeeDTO.Thumbnail;
            
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;


            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    trans = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    trans.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
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


            return strMsg;


        }
        //new
        public List<LeaveDTO> GetEmployeeLeave(LeaveDTO objLeaveDTO)
        {

            LeaveDTO objLeave = new LeaveDTO();
            List<LeaveDTO> objLeaves = new List<LeaveDTO>();

            OracleCommand objOracleCommand = new OracleCommand("SP_GET_EMPLOYEE_LEAVE_INFO");
            OracleDataReader objDataReader;
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLeaveDTO.EmployeeId;
            
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLeaveDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLeaveDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("p_dbcursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            string VALUE = string.Empty;

            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    objDataReader = objOracleCommand.ExecuteReader();
                   
                    while (objDataReader.Read())
                    {
                        objLeave = new LeaveDTO();

                        //objEmployee.EmployeeId =  objDataReader.GetString(0);
                        //objEmployee.EmployeePic = (byte[]) (objDataReader.GetOracleBlob(1)).Value;
                        //objEmployees.Add(objEmployee);

                        objLeave.EmployeeId = Convert.ToString(objDataReader["EMPLOYEE_ID"]);
                        objLeave.FileSize = (byte[])objDataReader["file_size"];
                        objLeave.leave_start_date = Convert.ToString(objDataReader["leave_start_date"]);
                        objLeave.row_number = Convert.ToString(objDataReader["row_number"]);
                        //p_row_number
                        //
                        objLeaves.Add(objLeave);
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
            return objLeaves;
        }
        //new
        public string UpdateEmployeeLeave(LeaveDTO objLeaveDTO)
        {

            string strMsg = "";
            OracleTransaction trans = null;
            OracleCommand objOracleCommand = new OracleCommand("sp_update_employee_leave");

            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLeaveDTO.EmployeeId;
            objOracleCommand.Parameters.Add("file_size", OracleDbType.Blob, ParameterDirection.Input).Value = objLeaveDTO.FileSize;
            objOracleCommand.Parameters.Add("p_leave_start_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLeaveDTO.leave_start_date;
            objOracleCommand.Parameters.Add("p_row_number", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLeaveDTO.row_number;

            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLeaveDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLeaveDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLeaveDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;


            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    trans = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    trans.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
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
            return strMsg;
        }


        public DataTable searchWorkerRecordForIncrement(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";


             if (objEmployeeDTO.BranchOfficeId == "110")
             {

                //NEW FROM MAL
                sql = "SELECT " +
                               "rownum sl, " +
                               "CARD_NO, " +
                               "EMPLOYEE_ID, " +
                               "EMPLOYEE_NAME, " +
                               "DESIGNATION_NAME, " +
                               "to_char(JOINING_DATE,'dd/mm/yyyy')JOINING_DATE, " +
                               "GROSS_SALARY, " +
                               "GRADE_NO," +
                               "TOTAL_YEAR " +
                                "FROM VEW_WORKER_INCREMENT_SEARCH  e WHERE  head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' AND JOINING_YEAR = '" + objEmployeeDTO.Year + "' AND to_number(joining_month) = '" + objEmployeeDTO.FromMonthId + "' AND unit_id in  ('113', '114', '126', '115', '117', '118', '119', '120', '121', '116', '122', '123', '124', '125') ";

                if (objEmployeeDTO.CardNo.Length > 0)
                {
                    sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
                }

                if (objEmployeeDTO.EmployeeId.Length > 0)
                {
                    sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
                }

                //BP OLD AND ORIGINAL
                //sql = "SELECT " +
                //"rownum sl, " +
                //"CARD_NO, " +
                //"EMPLOYEE_ID, " +
                //"EMPLOYEE_NAME, " +
                //"DESIGNATION_NAME, " +
                //"to_char(JOINING_DATE,'dd/mm/yyyy')JOINING_DATE, " +
                //"GROSS_SALARY, " +
                //"GRADE_NO," +
                //"(SELECT   TRUNC(MONTHS_BETWEEN ( " +
                //"                    TO_DATE ('"+objEmployeeDTO.LimitDate+"', 'dd/mm/yyyy'), " +
                //"                   TO_DATE (e.joining_date) " +
                //"               ) " +
                //"              / 12) " +
                //" FROM   employee_job_detail " +
                // "where employee_id = e.employee_id and  head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "') TOTAL_YEAR " +
                //"FROM VEW_WORKER_INCREMENT_SEARCH  e WHERE  head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' AND unit_id in  ('113', '114', '126', '115', '117', '118', '119', '120', '121', '116', '122', '123', '124', '125') " + " and " +
                //"(SELECT   TRUNC(MONTHS_BETWEEN ( " +
                //"                    TO_DATE ('" + objEmployeeDTO.LimitDate + "', 'dd/mm/yyyy'), " +
                // "                   TO_DATE (e.joining_date) " +
                //  "               ) " +
                //   "              / 12) " +
                //   " FROM   employee_job_detail " +
                //"where employee_id = e.employee_id and  head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "') > 0  ";
                //if (objEmployeeDTO.CardNo.Length > 0)
                //{
                //    sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
                //}
                //if (objEmployeeDTO.EmployeeId.Length > 0)
                //{
                //    sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
                //}               
                //if (objEmployeeDTO.LimitDate.Length > 6)
                //{
                //    sql = sql + "and joining_date <= to_date('" + objEmployeeDTO.LimitDate + "','dd/mm/yyyy') ";
                //}


            }
             else
             {
                if (objEmployeeDTO.HeadOfficeId == "331" && objEmployeeDTO.BranchOfficeId == "103")
                {

                    if (objEmployeeDTO.UnitId == "37")
                    {


                        sql = "SELECT " +
                               "rownum sl, " +
                               "CARD_NO, " +
                               "EMPLOYEE_ID, " +
                               "EMPLOYEE_NAME, " +
                               "DESIGNATION_NAME, " +
                               "to_char(JOINING_DATE,'dd/mm/yyyy')JOINING_DATE, " +
                               "GROSS_SALARY, " +
                               "GRADE_NO," +
                               "TOTAL_YEAR " +
                                "FROM VEW_WORKER_INCREMENT_SEARCH  e WHERE  head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' AND JOINING_YEAR = '" + objEmployeeDTO.Year + "' AND to_number(joining_month) = '" + objEmployeeDTO.FromMonthId + "' AND unit_id in  ('37', '38', '39', '40', '41', '42', '49', '93', '130') ";

                        if (objEmployeeDTO.CardNo.Length > 0)
                        {
                            sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
                        }

                        if (objEmployeeDTO.EmployeeId.Length > 0)
                        {
                            sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
                        }
                    }

                    if (objEmployeeDTO.UnitId == "43")
                    {
                       sql = "SELECT " +
                       "rownum sl, " +
                       "CARD_NO, " +
                       "EMPLOYEE_ID, " +
                       "EMPLOYEE_NAME, " +
                       "DESIGNATION_NAME, " +
                       "to_char(JOINING_DATE,'dd/mm/yyyy')JOINING_DATE, " +
                       "GROSS_SALARY, " +
                       "GRADE_NO," +
                       "TOTAL_YEAR " +
                       "FROM VEW_WORKER_INCREMENT_SEARCH  e WHERE  head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' AND JOINING_YEAR = '" + objEmployeeDTO.Year + "' AND to_number(joining_month) = '" + objEmployeeDTO.FromMonthId + "' AND unit_id IN('43', '44',  '45', '46', '47', '48','50','90','94')";

                        if (objEmployeeDTO.CardNo.Length > 0)
                        {
                            sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
                        }

                        if (objEmployeeDTO.EmployeeId.Length > 0)
                        {
                            sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
                        }
                    }

                    if (objEmployeeDTO.UnitId == "52")
                    {

                        sql = "SELECT " +
                          "rownum sl, " +
                          "CARD_NO, " +
                          "EMPLOYEE_ID, " +
                          "EMPLOYEE_NAME, " +
                          "DESIGNATION_NAME, " +
                          "to_char(JOINING_DATE,'dd/mm/yyyy')JOINING_DATE, " +
                          "GROSS_SALARY, " +
                          "GRADE_NO," +
                          "TOTAL_YEAR " +

             "FROM VEW_WORKER_INCREMENT_SEARCH  e WHERE  head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' AND JOINING_YEAR = '" + objEmployeeDTO.Year + "' AND to_number(joining_month) = '" + objEmployeeDTO.FromMonthId + "' AND unit_id IN('52', '53', '54', '55', '56', '57', '51', '95')";


                        if (objEmployeeDTO.CardNo.Length > 0)
                        {

                            sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
                        }

                        if (objEmployeeDTO.EmployeeId.Length > 0)
                        {

                            sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
                        }
                    }


                    if (objEmployeeDTO.UnitId == "58")
                    {

                        sql = "SELECT " +
               "rownum sl, " +
               "CARD_NO, " +
               "EMPLOYEE_ID, " +
               "EMPLOYEE_NAME, " +
               "DESIGNATION_NAME, " +
               "to_char(JOINING_DATE,'dd/mm/yyyy')JOINING_DATE, " +
               "GROSS_SALARY, " +
               "GRADE_NO," +
               "TOTAL_YEAR " +

              "FROM VEW_WORKER_INCREMENT_SEARCH  e WHERE  head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' AND JOINING_YEAR = '" + objEmployeeDTO.Year + "' AND to_number(joining_month) = '" + objEmployeeDTO.FromMonthId + "' AND unit_id IN('58', '59')";


                        if (objEmployeeDTO.CardNo.Length > 0)
                        {

                            sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
                        }

                        if (objEmployeeDTO.EmployeeId.Length > 0)
                        {
                            sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
                        }
                    }
                    if (objEmployeeDTO.UnitId == "102")
                    {
                        sql = "SELECT " +
                "rownum sl, " +
                "CARD_NO, " +
                "EMPLOYEE_ID, " +
                "EMPLOYEE_NAME, " +
                "DESIGNATION_NAME, " +
                "to_char(JOINING_DATE,'dd/mm/yyyy')JOINING_DATE, " +
                "GROSS_SALARY, " +
                "GRADE_NO," +
                "TOTAL_YEAR " +

               "FROM VEW_WORKER_INCREMENT_SEARCH  e WHERE  head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' AND JOINING_YEAR = '" + objEmployeeDTO.Year + "' AND to_number(joining_month) = '" + objEmployeeDTO.FromMonthId + "' AND unit_id IN ('96', '97', '98', '99', '100', '101', '102', '103', '131')";

                        if (objEmployeeDTO.CardNo.Length > 0)
                        {
                            sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
                        }

                        if (objEmployeeDTO.EmployeeId.Length > 0)
                        {
                            sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
                        }
                    }
                }

                else if (objEmployeeDTO.HeadOfficeId == "331" && objEmployeeDTO.BranchOfficeId == "102")
                {

                    if (objEmployeeDTO.UnitId == "1")
                    {


                        sql = "SELECT " +
                                "rownum sl, " +
                                "CARD_NO, " +
                                "EMPLOYEE_ID, " +
                                "EMPLOYEE_NAME, " +
                                "DESIGNATION_NAME, " +
                                "to_char(JOINING_DATE,'dd/mm/yyyy')JOINING_DATE, " +
                                "GROSS_SALARY, " +
                                "GRADE_NO," +
                                "TOTAL_YEAR " +

               "FROM VEW_WORKER_INCREMENT_SEARCH  e WHERE  head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' AND JOINING_YEAR = '" + objEmployeeDTO.Year + "' AND to_number(joining_month) = '" + objEmployeeDTO.FromMonthId + "' AND unit_id IN ('1', '2','3', '4','5','69','70','71', '72', '74','75','76','77')";


                        if (objEmployeeDTO.CardNo.Length > 0)
                        {

                            sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
                        }

                        if (objEmployeeDTO.EmployeeId.Length > 0)
                        {

                            sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
                        }



                    }

                    if (objEmployeeDTO.UnitId == "6")
                    {
                        sql = "SELECT " +
                "rownum sl, " +
                "CARD_NO, " +
                "EMPLOYEE_ID, " +
                "EMPLOYEE_NAME, " +
                "DESIGNATION_NAME, " +
                "to_char(JOINING_DATE,'dd/mm/yyyy')JOINING_DATE, " +
                "GROSS_SALARY, " +
                "GRADE_NO," +
                "TOTAL_YEAR " +

               "FROM VEW_WORKER_INCREMENT_SEARCH  e WHERE  head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' AND JOINING_YEAR = '" + objEmployeeDTO.Year + "' AND to_number(joining_month) = '" + objEmployeeDTO.FromMonthId + "' AND  unit_id IN('6','7','8','9','10','11','78','79','80','81','82','83', '84', '85','86','87','88','89')";


                        if (objEmployeeDTO.CardNo.Length > 0)
                        {

                            sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
                        }

                        if (objEmployeeDTO.EmployeeId.Length > 0)
                        {

                            sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
                        }
                    }

                }


                else if (objEmployeeDTO.HeadOfficeId == "331" && objEmployeeDTO.BranchOfficeId == "101")
                {

                    if (objEmployeeDTO.UnitId == "17")
                    {

                        sql = "SELECT " +
               "rownum sl, " +
               "CARD_NO, " +
               "EMPLOYEE_ID, " +
               "EMPLOYEE_NAME, " +
               "DESIGNATION_NAME, " +
               "to_char(JOINING_DATE,'dd/mm/yyyy')JOINING_DATE, " +
               "GROSS_SALARY, " +
               "GRADE_NO," +
               "TOTAL_YEAR " +

              "FROM VEW_WORKER_INCREMENT_SEARCH  e WHERE  head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' AND JOINING_YEAR = '" + objEmployeeDTO.Year + "' AND to_number(joining_month) = '" + objEmployeeDTO.FromMonthId + "' AND  unit_id IN('17', '18', '22')";


                        if (objEmployeeDTO.CardNo.Length > 0)
                        {

                            sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
                        }

                        if (objEmployeeDTO.EmployeeId.Length > 0)
                        {

                            sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
                        }

                    }

                    if (objEmployeeDTO.UnitId == "19")
                    {
                        sql = "SELECT " +
                                     "rownum sl, " +
                                     "CARD_NO, " +
                                     "EMPLOYEE_ID, " +
                                     "EMPLOYEE_NAME, " +
                                     "DESIGNATION_NAME, " +
                                     "to_char(JOINING_DATE,'dd/mm/yyyy')JOINING_DATE, " +
                                     "GROSS_SALARY, " +
                                     "GRADE_NO," +
                                     "TOTAL_YEAR " +

                                    "FROM VEW_WORKER_INCREMENT_SEARCH  e WHERE  head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' AND JOINING_YEAR = '" + objEmployeeDTO.Year + "' AND to_number(joining_month) = '" + objEmployeeDTO.FromMonthId + "' AND  unit_id IN('19', '24', '25', '23')";


                        if (objEmployeeDTO.CardNo.Length > 0)
                        {

                            sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
                        }

                        if (objEmployeeDTO.EmployeeId.Length > 0)
                        {

                            sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
                        }




                    }


                    if (objEmployeeDTO.UnitId == "26")
                    {


                        sql = "SELECT " +
                                    "rownum sl, " +
                                    "CARD_NO, " +
                                    "EMPLOYEE_ID, " +
                                    "EMPLOYEE_NAME, " +
                                    "DESIGNATION_NAME, " +
                                    "to_char(JOINING_DATE,'dd/mm/yyyy')JOINING_DATE, " +
                                    "GROSS_SALARY, " +
                                    "GRADE_NO," +
                                    "TOTAL_YEAR " +

                                   "FROM VEW_WORKER_INCREMENT_SEARCH  e WHERE  head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' AND JOINING_YEAR = '" + objEmployeeDTO.Year + "' AND to_number(joining_month) = '" + objEmployeeDTO.FromMonthId + "' AND UNIT_ID IN ('26', '27', '28')";


                        if (objEmployeeDTO.CardNo.Length > 0)
                        {

                            sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
                        }

                        if (objEmployeeDTO.EmployeeId.Length > 0)
                        {

                            sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
                        }




                    }


                    if (objEmployeeDTO.UnitId == "12")
                    {

                        sql = "SELECT " +
                                      "rownum sl, " +
                                      "CARD_NO, " +
                                      "EMPLOYEE_ID, " +
                                      "EMPLOYEE_NAME, " +
                                      "DESIGNATION_NAME, " +
                                      "to_char(JOINING_DATE,'dd/mm/yyyy')JOINING_DATE, " +
                                      "GROSS_SALARY, " +
                                      "GRADE_NO," +
                                      "TOTAL_YEAR " +

                                     "FROM VEW_WORKER_INCREMENT_SEARCH  e WHERE  head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' AND JOINING_YEAR = '" + objEmployeeDTO.Year + "' AND to_number(joining_month) = '" + objEmployeeDTO.FromMonthId + "' AND UNIT_ID IN ('12', '13')";


                        if (objEmployeeDTO.CardNo.Length > 0)
                        {

                            sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
                        }

                        if (objEmployeeDTO.EmployeeId.Length > 0)
                        {

                            sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";

                        }
                    }

                    if (objEmployeeDTO.UnitId == "15")
                    {


                        sql = "SELECT " +
                                     "rownum sl, " +
                                     "CARD_NO, " +
                                     "EMPLOYEE_ID, " +
                                     "EMPLOYEE_NAME, " +
                                     "DESIGNATION_NAME, " +
                                     "to_char(JOINING_DATE,'dd/mm/yyyy')JOINING_DATE, " +
                                     "GROSS_SALARY, " +
                                     "GRADE_NO," +
                                     "TOTAL_YEAR " +

                                    "FROM VEW_WORKER_INCREMENT_SEARCH  e WHERE  head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' AND JOINING_YEAR = '" + objEmployeeDTO.Year + "' AND to_number(joining_month) = '" + objEmployeeDTO.FromMonthId + "' AND UNIT_ID IN ('15', '16', '20', '21', '30', '31')";


                        if (objEmployeeDTO.CardNo.Length > 0)
                        {

                            sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
                        }

                        if (objEmployeeDTO.EmployeeId.Length > 0)
                        {

                            sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";

                        }






                    }

                    if (objEmployeeDTO.UnitId == "14")
                    {
                        sql = "SELECT " +
                                     "rownum sl, " +
                                     "CARD_NO, " +
                                     "EMPLOYEE_ID, " +
                                     "EMPLOYEE_NAME, " +
                                     "DESIGNATION_NAME, " +
                                     "to_char(JOINING_DATE,'dd/mm/yyyy')JOINING_DATE, " +
                                     "GROSS_SALARY, " +
                                     "GRADE_NO," +
                                     "TOTAL_YEAR " +

                                    "FROM VEW_WORKER_INCREMENT_SEARCH  e WHERE  head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' AND JOINING_YEAR = '" + objEmployeeDTO.Year + "' AND to_number(joining_month) = '" + objEmployeeDTO.FromMonthId + "' AND UNIT_ID IN ('14', '29', '32', '33', '34', '35', '36', '60')";


                        if (objEmployeeDTO.CardNo.Length > 0)
                        {

                            sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
                        }

                        if (objEmployeeDTO.EmployeeId.Length > 0)
                        {

                            sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";

                        }


                    }


                }

                else
                {

                    sql = "SELECT " +
                                       "rownum sl, " +
                                       "CARD_NO, " +
                                       "EMPLOYEE_ID, " +
                                       "EMPLOYEE_NAME, " +
                                       "DESIGNATION_NAME, " +
                                       "to_char(JOINING_DATE,'dd/mm/yyyy')JOINING_DATE, " +
                                       "GROSS_SALARY, " +
                                       "GRADE_NO," +
                                       "TOTAL_YEAR " +

                                      "FROM VEW_WORKER_INCREMENT_SEARCH  e WHERE  head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' AND JOINING_YEAR = '" + objEmployeeDTO.Year + "' AND to_number(joining_month) = '" + objEmployeeDTO.FromMonthId + "' ";


                    if (objEmployeeDTO.CardNo.Length > 0)
                    {

                        sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
                    }

                    if (objEmployeeDTO.EmployeeId.Length > 0)
                    {

                        sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";

                    }


                    if (objEmployeeDTO.UnitId.Length > 0)
                    {

                        sql = sql + " and unit_id = '" + objEmployeeDTO.UnitId + "'";
                    }

                    if (objEmployeeDTO.SectionId.Length > 0)
                    {

                        sql = sql + " and section_id = '" + objEmployeeDTO.SectionId + "'";
                    }




                }



            }

             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchWorkerRecordForIncrementCasual(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME, " +
                    "to_char(JOINING_DATE,'dd/mm/yyyy')JOINING_DATE, " +
                    "GROSS_SALARY, " +
                    "GRADE_NO " +

                   "FROM VEW_INCREMENT_SEARCH_CASUAL WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "'";


             if (objEmployeeDTO.CardNo.Length > 0)
             {

                 sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
             }

             if (objEmployeeDTO.EmployeeId.Length > 0)
             {

                 sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
             }

             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }

             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchIncrementEntryWorkerCasual(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME, " +
                    "to_char(joining_date,'dd/mm/yyyy')joining_date, " +
                    "gross_salary, " +
                    "INCREMENT_AMOUNT, " +
                    "current_gross " +

                   "FROM VEW_INCREMENT_SHEET_CASUAL WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' and increment_year ='" + objEmployeeDTO.Year + "'  ";




             if (objEmployeeDTO.CardNo.Length > 0)
             {

                 sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
             }

             if (objEmployeeDTO.EmployeeId.Length > 0)
             {

                 sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
             }

             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }

             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchWorkerRecordForAnnualIncrement(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME, " +
                    "to_char(JOINING_DATE,'dd/mm/yyyy') JOINING_DATE, " +
                    "gross_salary, " +
                    "total_year, " +
                    "total_month, " +
                    "TOTAL_5_PERCENT, " +
                    "GRADE_NO, " +
                    "batch_no " +

                   "FROM VEW_INC_PROSAL_WORKER_ABOVE_1 WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' AND INCREMENT_YEAR = '" + objEmployeeDTO.Year + "' AND INCREMENT_MONTH = '" + objEmployeeDTO.Month + "' ";

                    //if (objEmployeeDTO.BranchOfficeId == "110")
                    //{
                    //    sql = sql + " and total_month >= 12 ";
                    //}
                    //else
                    //{
                    //    sql = sql + " and total_month > 12 ";
                    //}


                    if (objEmployeeDTO.CardNo.Length > 0)
                     {
                         sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
                     }

                     if (objEmployeeDTO.EmployeeId.Length > 0)
                     {
                         sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
                     }

                     if (objEmployeeDTO.SectionId.Length > 0)
                     {
                         sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
                     }

                     if (objEmployeeDTO.UnitId.Length > 0)
                     {
                         sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
                     }
                     sql = sql + "order by SL ";

                     OracleCommand objCommand = new OracleCommand(sql);
                     OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
                     using (OracleConnection strConn = GetConnection())
                     {
                         try
                         {
                             objCommand.Connection = strConn;
                             strConn.Open();
                             objDataAdapter.Fill(dt);
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
             return dt;
         }
         public DataTable searchWorkerRecordForAnnualIncrementNonProposal(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME, " +
                    "to_char(JOINING_DATE,'dd/mm/yyyy')JOINING_DATE, " +
                    "gross_salary, " +
                    "GRADE_NO " +

                   "FROM VEW_SEARCH_WORKER_NON_PROPOSAL e WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "'  "+
                   "AND NOT EXISTS "+
                    "(SELECT   1 " +
                    "   FROM   INCREMENT_PROPOSAL_WORKER " +
                     " WHERE       EMPLOYEE_ID = e.employee_id " +
                      "        AND head_office_id = e.head_office_id " +
                       "       AND branch_office_id = e.branch_office_id " +
                        "      AND increment_year =  '"+ objEmployeeDTO .Year+ "' " +
                         "          )" ;


             if (objEmployeeDTO.CardNo.Length > 0)
             {

                 sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
             }

             if (objEmployeeDTO.EmployeeId.Length > 0)
             {

                 sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
             }

             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }

             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
        public DataTable SearchAnnualIncrementNonProposalStaff(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
                   "rownum sl, " +
                   "CARD_NO, " +
                   "EMPLOYEE_ID, " +
                   "EMPLOYEE_NAME, " +
                   "DESIGNATION_NAME, " +
                   "to_char(JOINING_DATE,'dd/mm/yyyy')JOINING_DATE, " +
                   "gross_salary, " +
                   "GRADE_NO " +

                  "FROM VEW_SEARCH_STAFF_NON_PROPOSAL e WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "'  " +
                  "AND NOT EXISTS " +
                   "(SELECT   1 " +
                   "   FROM   INCREMENT_PROPOSAL_STAFF " +
                    " WHERE       EMPLOYEE_ID = e.employee_id " +
                     "        AND head_office_id = e.head_office_id " +
                      "       AND branch_office_id = e.branch_office_id " +
                       "      AND increment_year =  '" + objEmployeeDTO.Year + "' " +
                        "          )";


            if (objEmployeeDTO.CardNo.Length > 0)
            {

                sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
            }

            if (objEmployeeDTO.EmployeeId.Length > 0)
            {

                sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
            }

            if (objEmployeeDTO.SectionId.Length > 0)
            {

                sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
            }

            if (objEmployeeDTO.UnitId.Length > 0)
            {

                sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
            }

            sql = sql + "order by SL ";

            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataAdapter.Fill(dt);

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



            return dt;

        }
        public DataTable searchStaffRecordForIncrementMonthly(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
                   "rownum sl, " +
                   "CARD_NO, " +
                   "EMPLOYEE_ID, " +
                   "EMPLOYEE_NAME, " +
                   "DESIGNATION_NAME, " +
                   "to_char(JOINING_DATE,'dd/mm/yyyy')JOINING_DATE, " +
                   "GROSS_SALARY " +




            "FROM VEW_BASIC_INFO_STAFF S WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' ";
         


            if (objEmployeeDTO.CardNo.Length > 0)
            {

                sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
            }

            if (objEmployeeDTO.EmployeeId.Length > 0)
            {

                sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
            }

            if (objEmployeeDTO.SectionId.Length > 0)
            {

                sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
            }

            if (objEmployeeDTO.UnitId.Length > 0)
            {

                sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
            }

            sql = sql + "order by SL ";

            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataAdapter.Fill(dt);

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



            return dt;

        }
        public DataTable searchStaffRecordForIncrement(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME, " +
                    "to_char(JOINING_DATE,'dd/mm/yyyy')JOINING_DATE, "+
                    "GROSS_SALARY_NEW, " +
                    "batch_no, " +
                    "finalized_yn " +

                   "FROM VEW_INC_PROSAL_STAFF_ABOVE_1 WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' AND INCREMENT_YEAR = '" + objEmployeeDTO.Year + "' AND INCREMENT_MONTH = '" + objEmployeeDTO.Month + "' ";


            if (objEmployeeDTO.CardNo.Length > 0)
             {

                 sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
             }

             if (objEmployeeDTO.EmployeeId.Length > 0)
             {

                 sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
             }

             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }

             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchIncrementEntryWorker(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";


            if (objEmployeeDTO.BranchOfficeId == "110")
            {
                //FROM MAL
                sql = "SELECT " +
                          "rownum sl, " +
                          "CARD_NO, " +
                          "EMPLOYEE_ID, " +
                          "EMPLOYEE_NAME, " +
                          "DESIGNATION_NAME, " +
                          "to_char(joining_date,'dd/mm/yyyy')joining_date, " +
                          "gross_salary, " +
                          "basic_salary, " +
                          "HOUSE_RENT_FEE, " +
                          "TOTAL_INCREMENT_AMOUNT, " +
                          "current_gross, " +
                          "INCREMENT_YEAR, " +
                          "INCREMENT_MONTH " +
                          "FROM VEW_INCREMENT_SHEET_WORKER WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' AND JOINING_YEAR ='" + objEmployeeDTO.Year + "' and JOINING_MONTH = '" + objEmployeeDTO.Month + "' AND unit_id in  ('113', '114', '126', '115', '117', '118', '119', '120', '121', '116', '122', '123', '124', '125')  ";

                if (objEmployeeDTO.CardNo.Length > 0)
                {
                    sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
                }

                if (objEmployeeDTO.EmployeeId.Length > 0)
                {
                    sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
                }


                //BP ORIGINAL COMMENTED
                //sql = "SELECT " +
                //       "rownum sl, " +
                //       "CARD_NO, " +
                //       "EMPLOYEE_ID, " +
                //       "EMPLOYEE_NAME, " +
                //       "DESIGNATION_NAME, " +
                //       "to_char(joining_date,'dd/mm/yyyy')joining_date, " +
                //       "gross_salary, " +
                //       "basic_salary, " +
                //       "HOUSE_RENT_FEE, " +
                //       "TOTAL_INCREMENT_AMOUNT, " +
                //       "current_gross, " +
                //       "INCREMENT_YEAR, "+
                //       "INCREMENT_MONTH "+

                //      "FROM VEW_INCREMENT_SHEET_WORKER WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId  +"' AND unit_id in  ('113', '114', '126', '115', '117', '118', '119', '120', '121', '116', '122', '123', '124', '125') " + " AND increment_year = '" + objEmployeeDTO.Year + "' AND increment_month = '" + objEmployeeDTO.Month + "' ";
                //if (objEmployeeDTO.CardNo.Length > 0)
                //{
                //    sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
                //}

                //if (objEmployeeDTO.EmployeeId.Length > 0)
                //{
                //    sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
                //}                

            }
            else
            if (objEmployeeDTO.HeadOfficeId == "331" && objEmployeeDTO.BranchOfficeId == "103")
            {
                if (objEmployeeDTO.UnitId == "37")
                {
                    sql = "SELECT " +
                          "rownum sl, " +
                          "CARD_NO, " +
                          "EMPLOYEE_ID, " +
                          "EMPLOYEE_NAME, " +
                          "DESIGNATION_NAME, " +
                          "to_char(joining_date,'dd/mm/yyyy')joining_date, " +
                          "gross_salary, " +
                          "basic_salary, " +
                          "HOUSE_RENT_FEE, " +
                          "TOTAL_INCREMENT_AMOUNT, " +
                          "current_gross, " +
                          "INCREMENT_YEAR, " +
                          "INCREMENT_MONTH " +
                          "FROM VEW_INCREMENT_SHEET_WORKER WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' AND JOINING_YEAR ='" + objEmployeeDTO.Year + "' and JOINING_MONTH = '" + objEmployeeDTO.Month + "' AND unit_id in  ('37', '38', '39', '40', '41', '42', '49', '93', '130')  ";
                    
                    if (objEmployeeDTO.CardNo.Length > 0)
                    {
                        sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
                    }

                    if (objEmployeeDTO.EmployeeId.Length > 0)
                    {
                        sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
                    }
                    
                }

                if (objEmployeeDTO.UnitId == "43")
                {


                    sql = "SELECT " +
                                        "rownum sl, " +
                                        "CARD_NO, " +
                                        "EMPLOYEE_ID, " +
                                        "EMPLOYEE_NAME, " +
                                        "DESIGNATION_NAME, " +
                                        "to_char(joining_date,'dd/mm/yyyy')joining_date, " +
                                        "gross_salary, " +
                                        "basic_salary, " +
                                        "HOUSE_RENT_FEE, " +
                                        "TOTAL_INCREMENT_AMOUNT, " +
                                        "current_gross, " +
                                        "INCREMENT_YEAR, " +
                                        "INCREMENT_MONTH " +

                                       "FROM VEW_INCREMENT_SHEET_WORKER WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' AND JOINING_YEAR ='" + objEmployeeDTO.Year + "' and JOINING_MONTH = '" + objEmployeeDTO.Month + "' AND unit_id IN('43', '44',  '45', '46', '47', '48','50','90','94')  ";




                    if (objEmployeeDTO.CardNo.Length > 0)
                    {

                        sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
                    }

                    if (objEmployeeDTO.EmployeeId.Length > 0)
                    {

                        sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
                    }




                }

                if (objEmployeeDTO.UnitId == "52")
                {

                    sql = "SELECT " +
                                        "rownum sl, " +
                                        "CARD_NO, " +
                                        "EMPLOYEE_ID, " +
                                        "EMPLOYEE_NAME, " +
                                        "DESIGNATION_NAME, " +
                                        "to_char(joining_date,'dd/mm/yyyy')joining_date, " +
                                        "gross_salary, " +
                                        "basic_salary, " +
                                        "HOUSE_RENT_FEE, " +
                                        "TOTAL_INCREMENT_AMOUNT, " +
                                        "current_gross, " +
                                        "INCREMENT_YEAR, " +
                                        "INCREMENT_MONTH " +
                                       "FROM VEW_INCREMENT_SHEET_WORKER WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' and  JOINING_YEAR ='" + objEmployeeDTO.Year + "' and JOINING_MONTH = '" + objEmployeeDTO.Month + "' AND unit_id IN('52', '53', '54', '55', '56', '57', '51', '95') ";




                    if (objEmployeeDTO.CardNo.Length > 0)
                    {

                        sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
                    }

                    if (objEmployeeDTO.EmployeeId.Length > 0)
                    {

                        sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
                    }





                }


                if (objEmployeeDTO.UnitId == "58")
                {

                    sql = "SELECT " +
                                         "rownum sl, " +
                                         "CARD_NO, " +
                                         "EMPLOYEE_ID, " +
                                         "EMPLOYEE_NAME, " +
                                         "DESIGNATION_NAME, " +
                                         "to_char(joining_date,'dd/mm/yyyy')joining_date, " +
                                         "gross_salary, " +
                                         "basic_salary, " +
                                         "HOUSE_RENT_FEE, " +
                                         "TOTAL_INCREMENT_AMOUNT, " +
                                         "current_gross, " +
                                         "INCREMENT_YEAR, " +
                                        "INCREMENT_MONTH " +

                                        "FROM VEW_INCREMENT_SHEET_WORKER WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' and  JOINING_YEAR ='" + objEmployeeDTO.Year + "' and JOINING_MONTH = '" + objEmployeeDTO.Month + "' AND unit_id IN('58', '59') ";




                    if (objEmployeeDTO.CardNo.Length > 0)
                    {

                        sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
                    }

                    if (objEmployeeDTO.EmployeeId.Length > 0)
                    {

                        sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
                    }



                }


                if (objEmployeeDTO.UnitId == "102")
                {


                    sql = "SELECT " +
                                         "rownum sl, " +
                                         "CARD_NO, " +
                                         "EMPLOYEE_ID, " +
                                         "EMPLOYEE_NAME, " +
                                         "DESIGNATION_NAME, " +
                                         "to_char(joining_date,'dd/mm/yyyy')joining_date, " +
                                         "gross_salary, " +
                                         "basic_salary, " +
                                         "HOUSE_RENT_FEE, " +
                                         "TOTAL_INCREMENT_AMOUNT, " +
                                         "current_gross, " +
                                         "INCREMENT_YEAR, " +
                                        "INCREMENT_MONTH " +

                                        "FROM VEW_INCREMENT_SHEET_WORKER WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' and  JOINING_YEAR ='" + objEmployeeDTO.Year + "' and JOINING_MONTH = '" + objEmployeeDTO.Month + "' AND unit_id IN('96', '97', '98', '99', '100', '101', '102', '103', '131') ";




                    if (objEmployeeDTO.CardNo.Length > 0)
                    {

                        sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
                    }

                    if (objEmployeeDTO.EmployeeId.Length > 0)
                    {

                        sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
                    }





                }





            }

            else if (objEmployeeDTO.HeadOfficeId == "331" && objEmployeeDTO.BranchOfficeId == "102")
            {

                if (objEmployeeDTO.UnitId == "1")
                {


                    sql = "SELECT " +
                                         "rownum sl, " +
                                         "CARD_NO, " +
                                         "EMPLOYEE_ID, " +
                                         "EMPLOYEE_NAME, " +
                                         "DESIGNATION_NAME, " +
                                         "to_char(joining_date,'dd/mm/yyyy')joining_date, " +
                                         "gross_salary, " +
                                         "basic_salary, " +
                                         "HOUSE_RENT_FEE, " +
                                         "TOTAL_INCREMENT_AMOUNT, " +
                                         "current_gross, " +
                                        "INCREMENT_YEAR, " +
                                        "INCREMENT_MONTH " +

                                        "FROM VEW_INCREMENT_SHEET_WORKER WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' and  JOINING_YEAR ='" + objEmployeeDTO.Year + "' and JOINING_MONTH = '" + objEmployeeDTO.Month + "' AND unit_id IN ('1', '2','3', '4','5','69','70','71', '72', '74','75','76','77') ";




                    if (objEmployeeDTO.CardNo.Length > 0)
                    {

                        sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
                    }

                    if (objEmployeeDTO.EmployeeId.Length > 0)
                    {

                        sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
                    }


                }

                if (objEmployeeDTO.UnitId == "6")
                {
                    sql = "SELECT " +
                                         "rownum sl, " +
                                         "CARD_NO, " +
                                         "EMPLOYEE_ID, " +
                                         "EMPLOYEE_NAME, " +
                                         "DESIGNATION_NAME, " +
                                         "to_char(joining_date,'dd/mm/yyyy')joining_date, " +
                                         "gross_salary, " +
                                         "basic_salary, " +
                                         "HOUSE_RENT_FEE, " +
                                         "TOTAL_INCREMENT_AMOUNT, " +
                                         "current_gross, " +
                                         "INCREMENT_YEAR, " +
                                        "INCREMENT_MONTH " +

                                        "FROM VEW_INCREMENT_SHEET_WORKER WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' AND JOINING_YEAR ='" + objEmployeeDTO.Year + "' and JOINING_MONTH = '" + objEmployeeDTO.Month + "' AND unit_id IN ('6','7','8','9','10','11','78','79','80','81','82','83', '84', '85','86','87','88','89') ";




                    if (objEmployeeDTO.CardNo.Length > 0)
                    {

                        sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
                    }

                    if (objEmployeeDTO.EmployeeId.Length > 0)
                    {

                        sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
                    }



                  
                }

            }


            else if (objEmployeeDTO.HeadOfficeId == "331" && objEmployeeDTO.BranchOfficeId == "101")
            {

                if (objEmployeeDTO.UnitId == "17")
                {

                    sql = "SELECT " +
                      "rownum sl, " +
                      "CARD_NO, " +
                      "EMPLOYEE_ID, " +
                      "EMPLOYEE_NAME, " +
                      "DESIGNATION_NAME, " +
                      "to_char(joining_date,'dd/mm/yyyy')joining_date, " +
                      "gross_salary, " +
                      "basic_salary, " +
                      "HOUSE_RENT_FEE, " +
                      "TOTAL_INCREMENT_AMOUNT, " +
                      "current_gross, " +
                      "INCREMENT_YEAR, " +
                      "INCREMENT_MONTH " +

                     "FROM VEW_INCREMENT_SHEET_WORKER WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' AND JOINING_YEAR ='" + objEmployeeDTO.Year + "' and JOINING_MONTH = '" + objEmployeeDTO.Month + "' AND unit_id IN ('17', '18', '22') ";




                    if (objEmployeeDTO.CardNo.Length > 0)
                    {

                        sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
                    }

                    if (objEmployeeDTO.EmployeeId.Length > 0)
                    {

                        sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
                    }





                }

                if (objEmployeeDTO.UnitId == "19")
                {
                    sql = "SELECT " +
                     "rownum sl, " +
                     "CARD_NO, " +
                     "EMPLOYEE_ID, " +
                     "EMPLOYEE_NAME, " +
                     "DESIGNATION_NAME, " +
                     "to_char(joining_date,'dd/mm/yyyy')joining_date, " +
                     "gross_salary, " +
                     "basic_salary, " +
                     "HOUSE_RENT_FEE, " +
                     "TOTAL_INCREMENT_AMOUNT, " +
                     "current_gross, " +
                     "INCREMENT_YEAR, " +
                     "INCREMENT_MONTH " +

                    "FROM VEW_INCREMENT_SHEET_WORKER WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' AND JOINING_YEAR ='" + objEmployeeDTO.Year + "' and JOINING_MONTH = '" + objEmployeeDTO.Month + "' AND unit_id IN ('19', '24', '25', '23') ";




                    if (objEmployeeDTO.CardNo.Length > 0)
                    {

                        sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
                    }

                    if (objEmployeeDTO.EmployeeId.Length > 0)
                    {

                        sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
                    }

                   

                }


                if (objEmployeeDTO.UnitId == "26")
                {


                    sql = "SELECT " +
                      "rownum sl, " +
                      "CARD_NO, " +
                      "EMPLOYEE_ID, " +
                      "EMPLOYEE_NAME, " +
                      "DESIGNATION_NAME, " +
                      "to_char(joining_date,'dd/mm/yyyy')joining_date, " +
                      "gross_salary, " +
                      "basic_salary, " +
                      "HOUSE_RENT_FEE, " +
                      "TOTAL_INCREMENT_AMOUNT, " +
                      "current_gross, " +
                      "INCREMENT_YEAR, " +
                      "INCREMENT_MONTH " +

                     "FROM VEW_INCREMENT_SHEET_WORKER WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' AND JOINING_YEAR ='" + objEmployeeDTO.Year + "' and JOINING_MONTH = '" + objEmployeeDTO.Month + "' AND unit_id IN ('26', '27', '28') ";




                    if (objEmployeeDTO.CardNo.Length > 0)
                    {

                        sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
                    }

                    if (objEmployeeDTO.EmployeeId.Length > 0)
                    {

                        sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
                    }

                  

                }


                if (objEmployeeDTO.UnitId == "12")
                {

                    sql = "SELECT " +
                       "rownum sl, " +
                       "CARD_NO, " +
                       "EMPLOYEE_ID, " +
                       "EMPLOYEE_NAME, " +
                       "DESIGNATION_NAME, " +
                       "to_char(joining_date,'dd/mm/yyyy')joining_date, " +
                       "gross_salary, " +
                       "basic_salary, " +
                       "HOUSE_RENT_FEE, " +
                       "TOTAL_INCREMENT_AMOUNT, " +
                       "current_gross, " +
                       "INCREMENT_YEAR, " +
                       "INCREMENT_MONTH " +

                      "FROM VEW_INCREMENT_SHEET_WORKER WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' AND JOINING_YEAR ='" + objEmployeeDTO.Year + "' and JOINING_MONTH = '" + objEmployeeDTO.Month + "' AND unit_id IN ('12', '13') ";




                    if (objEmployeeDTO.CardNo.Length > 0)
                    {

                        sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
                    }

                    if (objEmployeeDTO.EmployeeId.Length > 0)
                    {

                        sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
                    }

                  
                }

                if (objEmployeeDTO.UnitId == "15")
                {

                    sql = "SELECT " +
                                         "rownum sl, " +
                                         "CARD_NO, " +
                                         "EMPLOYEE_ID, " +
                                         "EMPLOYEE_NAME, " +
                                         "DESIGNATION_NAME, " +
                                         "to_char(joining_date,'dd/mm/yyyy')joining_date, " +
                                         "gross_salary, " +
                                         "basic_salary, " +
                                         "HOUSE_RENT_FEE, " +
                                         "TOTAL_INCREMENT_AMOUNT, " +
                                         "current_gross, " +
                                        "INCREMENT_YEAR, " +
                                        "INCREMENT_MONTH " +

                                        "FROM VEW_INCREMENT_SHEET_WORKER WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' AND JOINING_YEAR ='" + objEmployeeDTO.Year + "' and JOINING_MONTH = '" + objEmployeeDTO.Month + "' AND unit_id IN ('15', '16', '20', '21', '30', '31') ";




                    if (objEmployeeDTO.CardNo.Length > 0)
                    {

                        sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
                    }

                    if (objEmployeeDTO.EmployeeId.Length > 0)
                    {

                        sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
                    }



                }

                if (objEmployeeDTO.UnitId == "14")
                {
                    sql = "SELECT " +
                                 "rownum sl, " +
                                 "CARD_NO, " +
                                 "EMPLOYEE_ID, " +
                                 "EMPLOYEE_NAME, " +
                                 "DESIGNATION_NAME, " +
                                 "to_char(JOINING_DATE,'dd/mm/yyyy')JOINING_DATE, " +
                                 "GROSS_SALARY, " +
                                 "GRADE_NO," +
                                 "TOTAL_YEAR, " +
                                 "INCREMENT_YEAR, " +
                                 "INCREMENT_MONTH " +

                                "FROM VEW_WORKER_INCREMENT_SEARCH  e WHERE  head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' AND JOINING_YEAR ='" + objEmployeeDTO.Year + "' and JOINING_MONTH = '" + objEmployeeDTO.Month + "' AND UNIT_ID IN ('14', '29', '32', '33', '34', '35', '36', '60')";


                    if (objEmployeeDTO.CardNo.Length > 0)
                    {

                        sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
                    }

                    if (objEmployeeDTO.EmployeeId.Length > 0)
                    {

                        sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";

                    }


                }


            }

            else
            {

                sql = "SELECT " +
                                   "rownum sl, " +
                                   "CARD_NO, " +
                                   "EMPLOYEE_ID, " +
                                   "EMPLOYEE_NAME, " +
                                   "DESIGNATION_NAME, " +
                                   "to_char(JOINING_DATE,'dd/mm/yyyy')JOINING_DATE, " +
                                   "GROSS_SALARY, " +
                                   "GRADE_NO," +
                                   "TOTAL_YEAR, " +
                                   "INCREMENT_YEAR, " +
                                   "INCREMENT_MONTH " +

                                  "FROM VEW_WORKER_INCREMENT_SEARCH  e WHERE  head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' AND JOINING_YEAR ='" + objEmployeeDTO.Year + "' and JOINING_MONTH = '" + objEmployeeDTO.Month + "' ";


               


                if (objEmployeeDTO.CardNo.Length > 0)
                {

                    sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
                }

                if (objEmployeeDTO.EmployeeId.Length > 0)
                {

                    sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";

                }


                if (objEmployeeDTO.UnitId.Length > 0)
                {

                    sql = sql + " and unit_id = '" + objEmployeeDTO.UnitId + "'";
                }

                if (objEmployeeDTO.SectionId.Length > 0)
                {

                    sql = sql + " and section_id = '" + objEmployeeDTO.SectionId + "'";
                }




            



        }

            sql = sql + " order by  increment_year  desc, increment_month desc, to_number(card_no) asc , sl desc";



           

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchIncrementEntryWorkerAnnual(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql =  "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME, " +
                    "to_char(joining_date,'dd/mm/yyyy') joining_date, " +
                    "gross_salary, " +
                    "TOTAL_5_PERCENT, " +
                    "increment_amount, " +
                    "increment_amount_2nd_term, " +
                    //"proposed_gross_salary, " +

                    "NVL(GROSS_SALARY, 0) + NVL(TOTAL_5_PERCENT, 0) + NVL(increment_amount, 0) + NVL(increment_amount_2nd_term, 0) proposed_gross_salary, " +

                    "current_gross, " +
                    "FINALIZED_YN, " +
                    "batch_no " +
                    "FROM vew_search_worker_annual_inc WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' and increment_year ='" + objEmployeeDTO.Year + "' and increment_month ='" + objEmployeeDTO.Month + "' ";

            if (objEmployeeDTO.CardNo.Length > 0)
             {
                 sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
             }

             if (objEmployeeDTO.EmployeeId.Length > 0)
             {
                 sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
             }

             if (objEmployeeDTO.SectionId.Length > 0)
             {
                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {
                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }

             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchIncrementEntryWorkerNonProposal(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME, " +
                    "to_char(joining_date,'dd/mm/yyyy')joining_date, " +
                    "gross_salary, " +
                    "TOTAL_5_PERCENT, " +
                    "increment_amount, " +
                    "current_gross, " +
                    "MANUAL_INCREMENT_AMOUNT "+

                   "FROM VEW_WORKER_INC_NON_PROPOSAL WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' and increment_year ='" + objEmployeeDTO.Year + "'  ";




             if (objEmployeeDTO.CardNo.Length > 0)
             {

                 sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
             }

             if (objEmployeeDTO.EmployeeId.Length > 0)
             {

                 sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
             }

             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }

             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }

        //public DataTable searchIncrementEntryStaffNonProposal(EmployeeDTO objEmployeeDTO)
        //{
        //    DataTable dt = new DataTable();
        //    string sql = "";

        //    sql = "SELECT " +
        //           "rownum sl, " +
        //           "CARD_NO, " +
        //           "EMPLOYEE_ID, " +
        //           "EMPLOYEE_NAME, " +
        //           "DESIGNATION_NAME, " +
        //           "to_char(joining_date,'dd/mm/yyyy')joining_date, " +
        //           "gross_salary, " +
        //           "TOTAL_5_PERCENT, " +
        //           "increment_amount, " +
        //           "current_gross, " +
        //           "MANUAL_INCREMENT_AMOUNT " +

        //          "FROM VEW_STAFF_INC_NON_PROPOSAL WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' and increment_year ='" + objEmployeeDTO.Year + "'  ";




        //    if (objEmployeeDTO.CardNo.Length > 0)
        //    {

        //        sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
        //    }

        //    if (objEmployeeDTO.EmployeeId.Length > 0)
        //    {

        //        sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
        //    }

        //    if (objEmployeeDTO.SectionId.Length > 0)
        //    {

        //        sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
        //    }

        //    if (objEmployeeDTO.UnitId.Length > 0)
        //    {

        //        sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
        //    }

        //    sql = sql + "order by SL ";

        //    OracleCommand objCommand = new OracleCommand(sql);
        //    OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
        //    using (OracleConnection strConn = GetConnection())
        //    {
        //        try
        //        {
        //            objCommand.Connection = strConn;
        //            strConn.Open();
        //            objDataAdapter.Fill(dt);

        //        }
        //        catch (Exception ex)
        //        {

        //            throw new Exception("Error : " + ex.Message);
        //        }

        //        finally
        //        {

        //            strConn.Close();
        //        }

        //    }



        //    return dt;

        //}


        public DataTable searchIncrementEntryStaffNonProposal(EmployeeDTO objEmployeeDTO)
        {
            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
                   "rownum sl, " +
                   "CARD_NO, " +
                   "EMPLOYEE_ID, " +
                   "EMPLOYEE_NAME, " +
                   "DESIGNATION_NAME, " +
                   "to_char(joining_date,'dd/mm/yyyy')joining_date, " +
                   "gross_salary, " +
                   "TOTAL_5_PERCENT, " +
                   "increment_amount, " +
                   "current_gross, " +
                   "MANUAL_INCREMENT_AMOUNT " +

                  "FROM VEW_STAFF_INC_NON_PROPOSAL WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' and increment_year ='" + objEmployeeDTO.Year + "'  ";




            if (objEmployeeDTO.CardNo.Length > 0)
            {

                sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
            }

            if (objEmployeeDTO.EmployeeId.Length > 0)
            {

                sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
            }

            if (objEmployeeDTO.SectionId.Length > 0)
            {

                sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
            }

            if (objEmployeeDTO.UnitId.Length > 0)
            {

                sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
            }

            sql = sql + "order by SL ";

            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataAdapter.Fill(dt);

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



            return dt;

        }


        public DataTable searchIncrementEntryStaff(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME, " +
                    "to_char(joining_date,'dd/mm/yyyy')joining_date, " +
                    "gross_salary, " +
                    "basic_salary, " +
                    "HOUSE_RENT_FEE, " +
                    "INCREMENT_AMOUNT, " +
                    "NVL(gross_salary, 0) + NVL(INCREMENT_AMOUNT, 0) proposed_gross_salary, " +
                    "current_gross, " +
                    "FINALIZED_YN, " +
                    "batch_no " +

                   "FROM VEW_SEARCH_STAFF_ANNUAL_INC WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' and increment_year ='" + objEmployeeDTO.Year + "' and increment_month ='" + objEmployeeDTO.Month + "' ";


            if (objEmployeeDTO.Year.Length > 0)
             {

                 sql = sql + "and increment_year ='" + objEmployeeDTO.Year + "' ";
             }

           
             if (objEmployeeDTO.CardNo.Length > 0)
             {

                 sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
             }

             if (objEmployeeDTO.EmployeeId.Length > 0)
             {

                 sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
             }

             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }

             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
        public DataTable searchIncrementEntryStaffMonthly(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
                   "rownum sl, " +
                   "CARD_NO, " +
                   "EMPLOYEE_ID, " +
                   "EMPLOYEE_NAME, " +
                   "DESIGNATION_NAME, " +
                   "to_char(joining_date,'dd/mm/yyyy')joining_date, " +
                   "gross_salary, " +
                   "INCREMENT_AMOUNT, " +
                   "current_gross, " +
                 
                   "to_char(YEARLY_INC_EFFECT_DATE,'dd/mm/yyyy')YEARLY_INC_EFFECT_DATE, " +
                   "YEARLY_INCREMENT " +

                  "FROM VEW_INC_SEARCH_STAFF_MONTHLY WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "'  ";


            if (objEmployeeDTO.Year.Length > 0)
            {

                sql = sql + "and increment_year ='" + objEmployeeDTO.Year + "' ";
            }

            if (objEmployeeDTO.Month.Length > 0)
            {

                sql = sql + "and increment_month ='" + objEmployeeDTO.Month + "' ";
            }


            if (objEmployeeDTO.CardNo.Length > 0)
            {

                sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
            }

            if (objEmployeeDTO.EmployeeId.Length > 0)
            {

                sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
            }

            if (objEmployeeDTO.SectionId.Length > 0)
            {

                sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
            }

            if (objEmployeeDTO.UnitId.Length > 0)
            {

                sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
            }

            sql = sql + "order by SL ";

            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataAdapter.Fill(dt);

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



            return dt;

        }
        public DataTable searchWorkerRecordforBonus(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME, " +
                    "GRADE_NO, " +
                    "TOTAL_MONTH "+

                   "FROM VEW_WORKER_FOR_BONUS WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "'";


             if (objEmployeeDTO.CardNo.Length > 0)
             {

                 sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
             }

             if (objEmployeeDTO.EmployeeId.Length > 0)
             {

                 sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
             }

             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }

             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchHORecordforBonus(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME, " +
                     "EMPLOYEE_ID " +
                   
                   "FROM VEW_HO_FOR_BONUS WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "'";


             if (objEmployeeDTO.CardNo.Length > 0)
             {

                 sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
             }

             if (objEmployeeDTO.EmployeeId.Length > 0)
             {

                 sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
             }

             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }

             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchStaffRecordforBonus(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME, " +
                    "GRADE_NO, " +
                    "TOTAL_MONTH " +

                   "FROM VEW_STAFF_FOR_BONUS WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "'";


             if (objEmployeeDTO.CardNo.Length > 0)
             {

                 sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
             }

             if (objEmployeeDTO.EmployeeId.Length > 0)
             {

                 sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
             }

             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }

             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchRecordforBonusManual(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME, " +
                    "GRADE_NO, " +
                    "TOTAL_MONTH " +

                   "FROM VEW_BONUS_MANUAL WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' AND EID_MONTH_FROM = '" + objEmployeeDTO.FromMonth + "' and EID_MONTH_TO = '" + objEmployeeDTO.ToMonth + "' AND eid_year = '"+objEmployeeDTO.EidYear+"' and eid_type_id = '"+objEmployeeDTO.EidTypeId+"' ";


             if (objEmployeeDTO.CardNo.Length > 0)
             {

                 sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
             }

             if (objEmployeeDTO.EmployeeId.Length > 0)
             {

                 sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
             }

             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }

             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchEmployeeRecordforSkill(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME " +
                 

                   "FROM VEW_BASIC_INFO WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "'";


             if (objEmployeeDTO.CardNo.Length > 0)
             {

                 sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
             }

             if (objEmployeeDTO.EmployeeId.Length > 0)
             {

                 sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
             }

             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }

             if (objEmployeeDTO.GradeNo.Length > 0)
             {

                 sql = sql + "and GRADE_ID = '" + objEmployeeDTO.GradeNo + "'";
             }

             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable loadProcess(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                 
                    "PROCESS_ID, " +
                    "PROCESS_NAME " +


                   "FROM L_PROCESS WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' order by PROCESS_ID ";


             
            

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable LoadWorkerSkill(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME, " +
                    "process_name, " +
                    "size_name, " +
                    "smv "+

                   "FROM vew_search_worker_skill_entry WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "'";


             if (objEmployeeDTO.CardNo.Length > 0)
             {

                 sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
             }

             if (objEmployeeDTO.EmployeeId.Length > 0)
             {

                 sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
             }

             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }

             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchIncremenRecord(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME " +
                    "FROM VEW_SEARCH_INCRMENT_HO WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "'";

            //Added for filtering by Asad on 18.04.2019
            sql = sql + " and employee_id in (SELECT employee_id FROM increment_basic_info i WHERE increment_year ='" + objEmployeeDTO.Year + "' " +
                        " AND head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "'" +
                        " AND INCREMENT_AMOUNT > 0 " +
                        " AND NOT EXISTS " +
                        " (SELECT 1 FROM increment_hold_info " +
                        " WHERE employee_id = i.employee_id " +
                        " AND increment_hold_year = '" + objEmployeeDTO.Year + "' " +
                        " AND head_office_id = '" + objEmployeeDTO.HeadOfficeId + "' " +
                        " AND branch_office_id = '" + objEmployeeDTO.BranchOfficeId + "' " +
                        " AND HOLD_YN = 'Y')) ";


            if (objEmployeeDTO.CardNo.Length > 0)
             {

                 sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
             }

             if (objEmployeeDTO.EmployeeId.Length > 0)
             {

                 sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
             }

             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }

             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchAdvanceArrearEntry(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME, " +
                    "advance_fee, " +
                    "from_month_name, " +
                    "to_month_name, " +
                    "STATUS "+
                   "FROM vew_search_arrear_advan_entry WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "'";
            //    //Added for filtering by Asad on 18.04.2019
            //sql = sql + " and employee_id in (SELECT employee_id FROM increment_basic_info i WHERE increment_year ='" + objEmployeeDTO.Year + "' " +
            //            " AND head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "'" +
            //            " AND INCREMENT_AMOUNT > 0 " +
            //            " AND NOT EXISTS " +
            //            " (SELECT 1 FROM increment_hold_info " +
            //            " WHERE employee_id = i.employee_id " +
            //            " AND increment_hold_year = '" + objEmployeeDTO.Year + "' " +
            //            " AND head_office_id = '" + objEmployeeDTO.HeadOfficeId + "' " +
            //            " AND branch_office_id = '" + objEmployeeDTO.BranchOfficeId + "' " +
            //            " AND HOLD_YN = 'Y')) ";

            if (objEmployeeDTO.Year.Length > 0)
            {
                sql = sql + "and arrear_year = '" + objEmployeeDTO.Year + "'";
            }

            if (objEmployeeDTO.FromMonthId.Length > 0)
             {
                 sql = sql + "and arrear_from_month_id = '" + objEmployeeDTO.FromMonthId + "'";
             }
             if (objEmployeeDTO.ToMonthId.Length > 0)
             {
                 sql = sql + "and arrear_to_month_id = '" + objEmployeeDTO.ToMonthId + "'";
             }

             if (objEmployeeDTO.SectionId.Length > 0)
             {
                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }

             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchEmployeeRecordWorker(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME " +


                   "FROM VEW_BASIC_INFO_WORKER WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "'";


             if (objEmployeeDTO.CardNo.Length > 0)
             {

                 sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
             }

             if (objEmployeeDTO.EmployeeId.Length > 0)
             {

                 sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
             }

             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }

             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchEmployeeRecordStaff(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME " +


                   "FROM VEW_BASIC_INFO_STAFF WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "'";


             if (objEmployeeDTO.CardNo.Length > 0)
             {

                 sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
             }

             if (objEmployeeDTO.EmployeeId.Length > 0)
             {

                 sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
             }

             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }

             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }

         public DataTable searchEmployeeRecordforSalaryEntryStaff(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME " +

                    //new from 21.09.2020
                    "FROM VEW_PAYABLE_BASIC_INFO_STAFF WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "'";
                    //old
                    //"FROM VEW_BASIC_INFO_STAFF WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "'";
                    
                if (objEmployeeDTO.EmployeeId.Length > 0)
                 {
                     sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
                 }

                 if (objEmployeeDTO.CardNo.Length > 0)
                 {
                     sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
                 }


                 if (objEmployeeDTO.SectionId.Length > 0)
                 {
                     sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
                 }

                 if (objEmployeeDTO.SectionId.Length > 0)
                 {
                     sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
                 }

                 if (objEmployeeDTO.UnitId.Length > 0)
                 {
                     sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
                 }

                 sql = sql + "order by SL ";

                 OracleCommand objCommand = new OracleCommand(sql);
                 OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
                 using (OracleConnection strConn = GetConnection())
                 {
                     try
                     {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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
             return dt;
         }

        public DataTable GetPayableStaff(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
                   "rownum sl, " +
                   "CARD_NO, " +
                   "EMPLOYEE_ID, " +
                   "EMPLOYEE_NAME, " +
                   "DESIGNATION_NAME " +
                   "FROM VEW_PAYABLE_BASIC_INFO_STAFF WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "'";
            
            if (objEmployeeDTO.EmployeeId.Length > 0)
            {
                sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
            }

            if (objEmployeeDTO.CardNo.Length > 0)
            {
                sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
            }


            if (objEmployeeDTO.SectionId.Length > 0)
            {
                sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
            }

            if (objEmployeeDTO.SectionId.Length > 0)
            {
                sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
            }

            if (objEmployeeDTO.UnitId.Length > 0)
            {
                sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
            }

            sql = sql + "order by SL ";

            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataAdapter.Fill(dt);

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
            return dt;
        }

        public DataTable searchEmployeeRecordforMiscEntryStaff(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME " +
                "FROM vew_search_employee_staff_misc WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "'";
                

            if (objEmployeeDTO.EmployeeId.Length > 0)
             {

                 sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
             }

             if (objEmployeeDTO.CardNo.Length > 0)
             {

                 sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
             }


             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }

             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }

        public DataTable GetPayableMiscStaff(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
                   "rownum sl, " +
                   "CARD_NO, " +
                   "EMPLOYEE_ID, " +
                   "EMPLOYEE_NAME, " +
                   "DESIGNATION_NAME " +
               "FROM VEW_PAYABLE_MISC_STAFF WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "'";


            if (objEmployeeDTO.EmployeeId.Length > 0)
            {

                sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
            }

            if (objEmployeeDTO.CardNo.Length > 0)
            {

                sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
            }


            if (objEmployeeDTO.SectionId.Length > 0)
            {

                sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
            }

            if (objEmployeeDTO.SectionId.Length > 0)
            {

                sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
            }

            if (objEmployeeDTO.UnitId.Length > 0)
            {

                sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
            }

            sql = sql + "order by SL ";

            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataAdapter.Fill(dt);

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
            return dt;
        }

        public DataTable searchSalaryInfoStaff(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME, " +
                    "ADVANCE_FEE, "+
                    "ARREAR_FEE, "+
                    "FOOD_ALLOWANCE_FEE, " +
                    "FOOD_DEDUCT_FEE, "+
                    "WORKING_DAY, "+
                    "LOAN_AMOUNT, "+
                    "ADVANCE_SALARY, "+
                    "PUNCH_YN, " +
                    "absent_day, " +
                    "leave_day, " +
                    "late_day " +

                   "FROM VEW_SEARCH_SALARY_INFO_STAFF WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' and salary_year = '" + objEmployeeDTO.Year + "' and salary_month = '" + objEmployeeDTO.Month + "' ";
                        
             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

            
             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }

           

             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchMiscSalaryInfoStaff(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME, " +
                    "ADVANCE_FEE, " +
                    "ARREAR_FEE, " +
                    "FOOD_ALLOWANCE_FEE, " +
                    "FOOD_DEDUCT_FEE, " +
                    "ADVANCE_SALARY "+

                   "FROM VEW_SEARCH_SALARY_STAFF_MISC WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' and salary_year = '" + objEmployeeDTO.Year + "' and salary_month = '" + objEmployeeDTO.Month + "' ";
            
             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }


             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }



             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchSalaryInfoWorker(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME, " +
                    "ADVANCE_FEE, " +
                    "ARREAR_FEE, " +
                    "OVER_TIME_HOUR, "+ 
                    "EARLY_DEPTR_HOUR, " +
                    "WORKING_DAY, " +

                    "PARTIAL_DAY, " +
                    "BKASH_YN, " +
                    "ATTENDENCE_FEE,  " +
                    "ADVANCE_SALARY, "+
                    "NUMBER_OF_LATE, "+
                    "NUMBER_OF_ABSENT, "+
                    "NUMBER_OF_LEAVE, " +
                    "PUNCH_YN " +
                   "FROM VEW_SEARCH_SALARY_INFO_WORKER WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' and salary_year = '" + objEmployeeDTO.Year + "' and salary_month = '" + objEmployeeDTO.Month + "' ";
            
             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }

            if (objEmployeeDTO.EmployeeId.Length > 0)
            {

                sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
            }
            if (objEmployeeDTO.CardNo.Length > 0)
            {

                sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
            }

            sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchSalaryInfoResign(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME, " +
                    "ADVANCE_FEE, " +
                    "ARREAR_FEE, " +
                    "OVER_TIME_HOUR, " +
                    "WORKING_DAY, " +
                    "ATTENDENCE_FEE  " +

                   "FROM VEW_SEARCH_SALARY_INFO_RESIGN WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' and salary_year = '" + objEmployeeDTO.Year + "' and salary_month = '" + objEmployeeDTO.Month + "' ";







             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }



             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchWorkerPromotionEntry(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME, " +
                    "UNIT_NAME_TO, " +
                    "SECTION_NAME_TO, " +
                    "TO_CHAR(effective_date, 'dd/mm/yyyy')effective_date " +

                   "FROM VEW_SEARCH_WORKER_TRANS_ENTRY WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' and transfer_year = '" + objEmployeeDTO.Year + "' and transfer_month = '" + objEmployeeDTO.Month + "' ";







             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id_from = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id_From = '" + objEmployeeDTO.UnitId + "'";
             }



             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
        public DataTable searchYearlyWorkerPromotionEntry(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
                   "rownum sl, " +
                   "CARD_NO, " +
                   "EMPLOYEE_ID, " +
                   "EMPLOYEE_NAME, " +
                   "DESIGNATION_NAME, " +
                   "UNIT_NAME_TO, " +
                   "SECTION_NAME_TO, " +
                   "TO_CHAR(effective_date, 'dd/mm/yyyy')effective_date, " +
                   "GRADE_NO "+

                  "FROM VEW_YEARLY_WORKER_PROMT_ENTRY WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' and promotion_year = '" + objEmployeeDTO.Year + "'  ";







            if (objEmployeeDTO.SectionId.Length > 0)
            {

                sql = sql + "and section_id_from = '" + objEmployeeDTO.SectionId + "'";
            }

            if (objEmployeeDTO.UnitId.Length > 0)
            {

                sql = sql + "and unit_id_From = '" + objEmployeeDTO.UnitId + "'";
            }



            sql = sql + "order by SL ";

            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataAdapter.Fill(dt);

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



            return dt;

        }
   
        public DataTable searchHalfSalaryInfoWorker(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME, " +
                    "PAYMENT_AMOUNT, " +
                    "WORKING_DAY, " +
                    "OVER_TIME_HOUR, "+
                    "OVER_TIME_AMOUNT " +


                   "FROM VEW_HALF_SHEET_WORKER WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' and salary_year = '" + objEmployeeDTO.Year + "' and salary_month = '" + objEmployeeDTO.Month + "' ";







             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }



             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchHalfSalaryInfoHO(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME, " +
                    "WORKING_DAY, " +
                    "PAYMENT_AMOUNT, " +
                    "payment_amount_second, " +
                    "EMPLOYEE_ID, " +
                    "ADVANCE_FEE, "+
                    "SALARY_PERCENTAGE "+

                   "FROM VEW_HALF_SHEET_HO WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' and salary_year = '" + objEmployeeDTO.Year + "' and salary_month = '" + objEmployeeDTO.Month + "' ";







             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }



             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchHalfSalaryInfoStaff(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME, " +
                    "PAYMENT_AMOUNT, " +
                    "payment_amount_second, "+
                    "WORKING_DAY " +


                   "FROM VEW_HALF_SHEET_STAFF WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' and salary_year = '" + objEmployeeDTO.Year + "' and salary_month = '" + objEmployeeDTO.Month + "' ";







             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }



             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchWorkerBonusEntry(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME, " +
                    "joining_date, "+
                    "TOTAL_MONTH, " +
                     "GROSS_SALARY, " +
                    "BASIC_SALARY, " +
                   
                    "BONUS_AMOUNT, " +
                    "BONUS_PERCENT,  " +
                    "EMPLOYEE_ID "+

                   "FROM VEW_SEARCH_WORKER_BONUS_ENTRY WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' and eid_year = '" + objEmployeeDTO.Year + "'  and eid_type_id ='" + objEmployeeDTO.EidTypeId + "'  ";
            

             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }



             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }

         public DataTable searchBonusEntryManual(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME, " +
                    "joining_date, " +
                    "TOTAL_MONTH, " +
                     "GROSS_SALARY, " +
                    "BONUS_AMOUNT_FIRST, " +
                    "BONUS_AMOUNT_SECOND, " +
                    "EMPLOYEE_ID " +


                   "FROM VEW_BONUS_MANUAL_ENTRY WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' and eid_year = '" + objEmployeeDTO.Year + "'  and eid_type_id ='" + objEmployeeDTO.EidTypeId + "' and EID_MONTH_FROM = '" + objEmployeeDTO.FromMonth + "' and EID_MONTH_TO = '" + objEmployeeDTO.ToMonth + "' ";







             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }



             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchStaffBonusEntry(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME, " +
                    "joining_date, "+
                    "TOTAL_MONTH, " +
                     "GROSS_SALARY, " +
                    "first_salary, " +
                    "second_salary, "+
                    "BONUS_PERCENT, "+
                    "EMPLOYEE_ID "+


                   "FROM VEW_SEARCH_STAFF_BONUS WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' and eid_year = '" + objEmployeeDTO.Year + "'  and eid_type_id ='" + objEmployeeDTO.EidTypeId + "'  ";







             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }



             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchOverTimeInfoWorker(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME, " +

                 
                    "OVER_TIME_HOUR, " +
                    "OVER_TIME_AMOUNT, " +
                    "ot_advance_amount " +
                   "FROM vew_search_over_time_woker WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' and OT_YEAR = '" + objEmployeeDTO.Year + "' and OT_MONTH = '" + objEmployeeDTO.Month + "' ";
            
             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }



             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchLeaveWorker(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME, " +
                    "LEAVE_DAY, "+
                    "LEAVE_AMOUNT "+

                   "FROM VEW_SEARCH_LEAVE_ENTRY_WORKER WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' and leave_year = '" + objEmployeeDTO.Year + "'  ";







             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }



             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchLeaveStaff(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME, " +
                    "LEAVE_DAY, " +
                    "LEAVE_AMOUNT "+

                   "FROM VEW_SEARCH_LEAVE_ENTRY_STAFF WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' and leave_year = '" + objEmployeeDTO.Year + "' ";







             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }



             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }

         public DataTable searchEmployeeRecordForPreJobInfo(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME " +


                   "FROM VEW_BASIC_INFO WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "' AND branch_office_id = '"+objEmployeeDTO.BranchOfficeId+"' ";

             if (objEmployeeDTO.EmployeeId.Length > 0)
             {

                 sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
             }

             if (objEmployeeDTO.CardNo.Length > 0)
             {

                 sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
             }


             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }

             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchEmployeeEducationRecordForDelete(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME, " +
                     "INSTITUTE_NAME, " +
                    "COURSE_NAME, "+
                    "SUBJECT_NAME, "+
                    "PASSING_YEAR " +


                   "FROM vew_delete_emp_edu_history WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "' AND branch_office_id = '" + objEmployeeDTO.BranchOfficeId + "' ";

             if (objEmployeeDTO.EmployeeId.Length > 0)
             {

                 sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
             }

             if (objEmployeeDTO.CardNo.Length > 0)
             {

                 sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
             }


             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }

             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchEmployeeEductionEntryRecord(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME, " +
                     "INSTITUTE_NAME, " +
                    "COURSE_NAME, " +
                    "SUBJECT_NAME, " +
                    "PASSING_YEAR " +


                   "FROM VEW_SEARCH_EMP_EDUCTION_ENTRY WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "' AND branch_office_id = '" + objEmployeeDTO.BranchOfficeId + "' and employee_id = '" + objEmployeeDTO.EmployeeId + "' ";

             //if (objEmployeeDTO.EmployeeId.Length > 0)
             //{

             //    sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
             //}

             //if (objEmployeeDTO.CardNo.Length > 0)
             //{

             //    sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
             //}


             //if (objEmployeeDTO.SectionId.Length > 0)
             //{

             //    sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             //}

             //if (objEmployeeDTO.UnitId.Length > 0)
             //{

             //    sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             //}

             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchEmployeePreviousJobHistoryForDelete(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME, " +
                    "TO_CHAR(JOINING_DATE,'mm/dd/yyyy')JOINING_DATE, " +
                    "ORGANIZATION_NAME, " +
                    "SECTION_NAME " +
                  



                   "FROM VEW_DELETE_PRE_JOB_HISTORY WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "' AND branch_office_id = '" + objEmployeeDTO.BranchOfficeId + "' ";

             if (objEmployeeDTO.EmployeeId.Length > 0)
             {

                 sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
             }

             if (objEmployeeDTO.CardNo.Length > 0)
             {

                 sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
             }


             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }

             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchEmployeeEntryRecord(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME, " +
                    "TO_CHAR(JOINING_DATE,'dd/mm/yyyy')JOINING_DATE, " +
                    "ORGANIZATION_NAME, " +
                    "SECTION_NAME " +




                   "FROM VEW_SEARCH_EMP_PRE_JOB_ENTRY WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "' AND branch_office_id = '" + objEmployeeDTO.BranchOfficeId + "' ";

             if (objEmployeeDTO.EmployeeId.Length > 0)
             {

                 sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
             }

             if (objEmployeeDTO.CardNo.Length > 0)
             {

                 sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
             }


             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }

             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable searchEmpLogFile(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                   "rownum SL, " +
                   "CARD_NO, " +
                   "EMPLOYEE_NAME, " +
                   "DESIGNATION_NAME, " +
                   "FIRST_IN, " +
                   "LAST_OUT, " +
                   "LUNCH_OUT, "+
                   "LUNCH_IN, "+
                   "OT_HOUR "+



                   "FROM VEW_ATTENDENCE_SHEET WHERE LOG_DATE BETWEEN TO_DATE('" + objEmployeeDTO.FromDate + "', 'DD/MM/YYYY') and TO_DATE('" + objEmployeeDTO.ToDate + "','dd/mm/yyyy') " +
                   "AND HEAD_OFFICE_ID = '" + objEmployeeDTO .HeadOfficeId+ "' and branch_office_id = '"+objEmployeeDTO.BranchOfficeId+"' ";

             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }


           
             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }

         public DataTable searchEmployeeRecordforImage(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "rownum sl, " +
                    "CARD_NO, " +
                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME " +


                   "FROM VEW_BASIC_INFO WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "' and branch_office_id = '" + objEmployeeDTO.BranchOfficeId + "' ";


             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }

             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }

             sql = sql + "order by SL ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }


        #endregion

         public string DeleteEmployeeEducation(EmployeeDTO objEmployeeDTO)
         {

             string strMsg = "";
             OracleTransaction trans = null;
             OracleCommand objOracleCommand = new OracleCommand("pro_delete_employee_education");

             objOracleCommand.CommandType = CommandType.StoredProcedure;

           

             objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;
             objOracleCommand.Parameters.Add("P_PASSING_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.PassingYear;

             objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UpdateBy;
             objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
             objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
             objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;


             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objOracleCommand.Connection = strConn;
                     strConn.Open();
                     trans = strConn.BeginTransaction();
                     objOracleCommand.ExecuteNonQuery();
                     trans.Commit();
                     strConn.Close();
                     strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
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


             return strMsg;


         }
         public string DeleteEmployeePreviousJobHistory(EmployeeDTO objEmployeeDTO)
         {

             string strMsg = "";
             OracleTransaction trans = null;
             OracleCommand objOracleCommand = new OracleCommand("pro_delete_emp_pre_job_hisoty");

             objOracleCommand.CommandType = CommandType.StoredProcedure;



             objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;
             objOracleCommand.Parameters.Add("p_joining_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.JoiningDate;

             objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UpdateBy;
             objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
             objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
             objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;


             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objOracleCommand.Connection = strConn;
                     strConn.Open();
                     trans = strConn.BeginTransaction();
                     objOracleCommand.ExecuteNonQuery();
                     trans.Commit();
                     strConn.Close();
                     strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
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


             return strMsg;


         }

        //DeleteVirtualTransfer
        //public string DeleteEmployeePreviousJobHistory(EmployeeDTO objEmployeeDTO)
        //{

        //    string strMsg = "";
        //    OracleTransaction trans = null;
        //    OracleCommand objOracleCommand = new OracleCommand("pro_delete_emp_pre_job_hisoty");

        //    objOracleCommand.CommandType = CommandType.StoredProcedure;
            
        //    objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;
        //    objOracleCommand.Parameters.Add("p_joining_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.JoiningDate;

        //    objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UpdateBy;
        //    objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
        //    objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
        //    objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;


        //    using (OracleConnection strConn = GetConnection())
        //    {
        //        try
        //        {
        //            objOracleCommand.Connection = strConn;
        //            strConn.Open();
        //            trans = strConn.BeginTransaction();
        //            objOracleCommand.ExecuteNonQuery();
        //            trans.Commit();
        //            strConn.Close();
        //            strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
        //        }

        //        catch (Exception ex)
        //        {
        //            trans.Rollback();
        //            throw new Exception("Error : " + ex.Message);
        //        }

        //        finally
        //        {
        //            strConn.Close();
        //        }
        //    }
        //    return strMsg;
        //}

        public EmployeeDTO getUrl(string strEmployeeId,  string strMenuId, string strSoftId, string strHeadOfficeId, string strBranchOfficeId)
         {


             EmployeeDTO objEmployeeDTO = new EmployeeDTO();




             string sql = "";
             sql = "SELECT " +

                     "TO_CHAR (NVL (MENU_PATH, 'N/A')) " +



                     "from MENU_MAPPING where menu_id = '" + strMenuId + "' and soft_id = '" + strSoftId + "' and EMPLOYEE_ID = '" + strEmployeeId + "' AND head_office_id = '" + strHeadOfficeId + "' AND branch_office_id = '" + strBranchOfficeId + "' ";




             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataReader objDataReader;

             using (OracleConnection strConn = GetConnection())
             {

                 objCommand.Connection = strConn;
                 strConn.Open();
                 objDataReader = objCommand.ExecuteReader();
                 try
                 {
                     while (objDataReader.Read())
                     {


                         objEmployeeDTO.MenuPath = objDataReader.GetString(0);

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




             return objEmployeeDTO;


         }
         public EmployeeDTO getSetUpUrl(string strEmployeeId, string strMenuId, string strSoftId, string strHeadOfficeId, string strBranchOfficeId)
         {


             EmployeeDTO objEmployeeDTO = new EmployeeDTO();




             string sql = "";
             sql = "SELECT " +

                     "TO_CHAR (NVL (MENU_PATH, 'N/A')) " +



                     "from MENU_MAPPING_SETUP where menu_id = '" + strMenuId + "' and soft_id = '" + strSoftId + "' AND EMPLOYEE_ID = '" + strEmployeeId + "'";




             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataReader objDataReader;

             using (OracleConnection strConn = GetConnection())
             {

                 objCommand.Connection = strConn;
                 strConn.Open();
                 objDataReader = objCommand.ExecuteReader();
                 try
                 {
                     while (objDataReader.Read())
                     {


                         objEmployeeDTO.MenuPath = objDataReader.GetString(0);

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




             return objEmployeeDTO;


         }
         public EmployeeDTO getTopMenuUpUrl(string strMenuId, string strSoftId, string strHeadOfficeId, string strBranchOfficeId)
         {


             EmployeeDTO objEmployeeDTO = new EmployeeDTO();




             string sql = "";
             sql = "SELECT " +

                     "TO_CHAR (NVL (MENU_PATH, 'N/A')) " +



                     "from MENU_MAPPING_TOP where menu_id = '" + strMenuId + "' and soft_id = '" + strSoftId + "'";




             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataReader objDataReader;

             using (OracleConnection strConn = GetConnection())
             {

                 objCommand.Connection = strConn;
                 strConn.Open();
                 objDataReader = objCommand.ExecuteReader();
                 try
                 {
                     while (objDataReader.Read())
                     {


                         objEmployeeDTO.MenuPath = objDataReader.GetString(0);

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




             return objEmployeeDTO;


         }

         public DataTable getMenuItem(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "MENU_ID, " +
                    "MENU_NAME " +



                   "FROM MENU_MAPPING WHERE EMPLOYEE_ID = '" + objEmployeeDTO.EmployeeId + "' AND SOFT_ID = '" + objEmployeeDTO .SoftId+ "' AND ACTIVE_YN = 'Y' and head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "'";




             sql = sql + "order by MENU_NAME ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataSet getTopMenuItem(EmployeeDTO objEmployeeDTO)
         {

             DataSet ds = new DataSet();
             string sql = "";

             sql = "SELECT " +
                    "MENU_ID, " +
                    "MENU_NAME, " +
                    "MENU_PATH " +


                   "FROM MENU_MAPPING_TOP WHERE EMPLOYEE_ID = '" + objEmployeeDTO.EmployeeId + "' AND SOFT_ID = '" + objEmployeeDTO.SoftId + "' AND ACTIVE_YN = 'Y' and head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "'";




             sql = sql + "order by TO_NUMBER (substr(menu_id, 2,3)) ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(ds);

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



             return ds;

         }
         public DataTable getSetupMenu(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +
                    "MENU_ID, " +
                    "MENU_NAME " +



                   "FROM MENU_MAPPING_SETUP WHERE ACTIVE_YN = 'Y' AND SOFT_ID = '" + objEmployeeDTO.SoftId + "' and head_office_id = '"+objEmployeeDTO.HeadOfficeId+"' and branch_office_id = '"+objEmployeeDTO.BranchOfficeId+"' and employee_id = '"+objEmployeeDTO.EmployeeId+"' ";




             sql = sql + "order by  MENU_NAME ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }


         public EmployeeDTO searchCounselingEntry(string strEmployeeId, string strHeadOfficeId, string strBranchOfficeId)
         {


             EmployeeDTO objEmployeeDTO = new EmployeeDTO();
             EmployeeDAL objEmployeeDAL = new EmployeeDAL();

             string sql = "";
             sql = "SELECT " +

                     "to_char(NVL(count(*), '0'))number_of_counseling " +


                     "from EMPLOYEE_COUNSELING where employee_id  = '" + strEmployeeId + "' and head_office_id = '" + strHeadOfficeId + "' and branch_office_id = '"+strBranchOfficeId+"' ";




             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataReader objDataReader;

             using (OracleConnection strConn = GetConnection())
             {

                 objCommand.Connection = strConn;
                 strConn.Open();
                 objDataReader = objCommand.ExecuteReader();
                 try
                 {
                     while (objDataReader.Read())
                     {


                         objEmployeeDTO.NumberOfCounseling = objDataReader.GetString(0);

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

            
             return objEmployeeDTO;


         }


         public string deleteAttendenceAprovedEmployeeRecord(EmployeeDTO objEmployeeDTO)
         {

             EmployeeDAL objEmployeeDAL = new EmployeeDAL();

             string strMsg = "";
             OracleTransaction trans = null;

             OracleCommand objOracleCommand = new OracleCommand("PRO_DELETE_ATTENDENCE_APPROVE");
             objOracleCommand.CommandType = CommandType.StoredProcedure;


             if (objEmployeeDTO.EmpId != "")
             {

                 objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmpId;
             }
             else
             {
                 objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

             }

             if (objEmployeeDTO.AprovedDate != "")
             {

                 objOracleCommand.Parameters.Add("P_LOG_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.AprovedDate;
             }
             else
             {
                 objOracleCommand.Parameters.Add("P_LOG_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

             }



             objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UpdateBy;
             objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
             objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;


             objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 1000).Direction = ParameterDirection.Output;

             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objOracleCommand.Connection = strConn;
                     strConn.Open();
                     trans = strConn.BeginTransaction();
                     objOracleCommand.ExecuteNonQuery();
                     trans.Commit();
                     strConn.Close();
                     strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
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



             return strMsg;
         }

         public string addAttendenceAprovedEmp(EmployeeDTO objEmployeeDTO)
         {


             string strMsg = "";
             OracleTransaction trans = null;

             OracleCommand objOracleCommand = new OracleCommand("PRO_ATTENDENCE_APPROVE_SAVE");

             objOracleCommand.CommandType = CommandType.StoredProcedure;


             if (objEmployeeDTO.EmployeeId != "")
             {
                 objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;

             }
             else
             {
                 objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

             }
             if (objEmployeeDTO.UnitId != "")
             {
                 objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UnitId;

             }
             else
             {
                 objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

             }
             if (objEmployeeDTO.SectionId != "")
             {
                 objOracleCommand.Parameters.Add("P_SECTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SectionId;

             }
             else
             {
                 objOracleCommand.Parameters.Add("P_SECTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

             }
             if (objEmployeeDTO.AttendenceDate.Length > 6)
             {
                 objOracleCommand.Parameters.Add("P_LOG_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.AttendenceDate;

             }
             else
             {
                 objOracleCommand.Parameters.Add("P_LOG_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

             }


             objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UpdateBy;
             objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
             objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;


             objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objOracleCommand.Connection = strConn;
                     strConn.Open();
                     trans = strConn.BeginTransaction();
                     objOracleCommand.ExecuteNonQuery();
                     trans.Commit();
                     strConn.Close();
                     strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
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

             return strMsg;


         }


         public DataTable searchAttendenceAprovedEmployeeEntry(EmployeeDTO objEmployeeDTO)
         {

             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +

                    "EMPLOYEE_ID, " +
                    "EMPLOYEE_CODE, " +
                    "CARD_NO, " +
                    "EMPLOYEE_NAME, " +
                    "DESIGNATION_NAME, " +
                    "UNIT_ID, " +
                    "SECTION_ID, " +
                    "TO_CHAR(LOG_DATE, 'dd/mm/yyyy')LOG_DATE, " +
                    "FIRST_IN_TIME, " +
                    "LUNCH_OUT_TIME, " +
                    "LUNCH_IN_TIME, " +
                    "FINAL_OUT_TIME " +

                   "FROM VEW_ATTENDENCE_APPROVE WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "' AND branch_office_id = '" + objEmployeeDTO.BranchOfficeId + "' AND LOG_DATE = TO_DATE('" + objEmployeeDTO.AprovedDate + "', 'dd/mm/yyyy') ";


             if (objEmployeeDTO.UnitId.Length > 0)
             {

                 sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
             }
             if (objEmployeeDTO.SectionId.Length > 0)
             {

                 sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
             }


             sql = sql + "order by EMPLOYEE_ID ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }
         public DataTable DownloadImgEmployee(EmployeeDTO objEmployeeDTO)
         {
             DataTable dt = new DataTable();
             string sql = "";

             sql = "SELECT " +


                    "EMPLOYEE_PIC, " +
                    "FILE_NAME " +


                   "FROM VEW_DISPLAY_IMAGE WHERE    EMPLOYEE_ID='" + objEmployeeDTO.EmployeeId + "' ORDER BY EMPLOYEE_ID ";

             OracleCommand objCommand = new OracleCommand(sql);
             OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
             using (OracleConnection strConn = GetConnection())
             {
                 try
                 {
                     objCommand.Connection = strConn;
                     strConn.Open();
                     objDataAdapter.Fill(dt);

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



             return dt;

         }


        public DataTable searchMonthlyLunchEntryHO(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
                   "rownum sl, " +
                   "CARD_NO, " +
                   "EMPLOYEE_ID, " +
                   "EMPLOYEE_NAME, " +
                   "DESIGNATION_NAME, " +
                   "salary_year, " +
                   "lunch_day, " +
                   "absent_day, " +
                   "MONTH_DAY, " +
                   "FOOD_ALLOWANCE_FEE, " +
                   "FOOD_DEDUCT_FEE, " +
                   "ABSENT_DAY, " +
                   "working_day "+

                  "FROM VEW_SEARCH_LUNCH_ENTRY_HO WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' and salary_year = '" + objEmployeeDTO.Year + "' and salary_month = '" + objEmployeeDTO.Month + "' ";





            if (objEmployeeDTO.SectionId.Length > 0)
            {

                sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
            }

            if (objEmployeeDTO.UnitId.Length > 0)
            {

                sql = sql + " and unit_id = '" + objEmployeeDTO.UnitId + "'";
            }




            sql = sql + "order by SL ";

            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataAdapter.Fill(dt);

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



            return dt;

        }


        public DataTable searchEmployeeforLunchEntry(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
                   "rownum sl, " +
                   "CARD_NO, " +
                   "EMPLOYEE_ID, " +
                   "EMPLOYEE_NAME, " +
                   "DESIGNATION_NAME " +


                  "FROM VEW_BASIC_INFO_HO WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "'";



            if (objEmployeeDTO.EmployeeId.Length > 0)
            {

                sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
            }

            if (objEmployeeDTO.CardNo.Length > 0)
            {

                sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
            }


            if (objEmployeeDTO.SectionId.Length > 0)
            {

                sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
            }

            if (objEmployeeDTO.UnitId.Length > 0)
            {

                sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
            }

            sql = sql + "order by SL ";

            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataAdapter.Fill(dt);

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



            return dt;

        }
        public string addSalaryCheckedProcessForEmp(EmployeeDTO objEmployeeDTO)
        {


            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("pro_salary_approve_checked ");

            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objEmployeeDTO.EmployeeId != "")
            {
                objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objEmployeeDTO.Year != "")
            {
                objOracleCommand.Parameters.Add("P_APPROVE_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Year;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_APPROVE_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objEmployeeDTO.Month != "")
            {
                objOracleCommand.Parameters.Add("P_APPROVE_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Month;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_APPROVE_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objEmployeeDTO.OccurenceTypeId != "")
            {
                objOracleCommand.Parameters.Add("p_occurence_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.OccurenceTypeId;

            }
            else
            {
                objOracleCommand.Parameters.Add("p_occurence_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;


            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    trans = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    trans.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
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

            return strMsg;


        }

        public string addSalaryAppovedProcessForEmp(EmployeeDTO objEmployeeDTO)
        {


            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("pro_salary_approve_Save");

            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objEmployeeDTO.EmployeeId != "")
            {
                objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objEmployeeDTO.Year != "")
            {
                objOracleCommand.Parameters.Add("P_APPROVE_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Year;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_APPROVE_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objEmployeeDTO.Month != "")
            {
                objOracleCommand.Parameters.Add("P_APPROVE_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Month;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_APPROVE_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            //added on 07.02.2022
            if (objEmployeeDTO.OccurenceTypeId != "")
            {
                objOracleCommand.Parameters.Add("p_occurence_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.OccurenceTypeId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_occurence_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;


            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    trans = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    trans.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
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

            return strMsg;


        }
        public string SalaryAppovedProcessForEmp(EmployeeDTO objEmployeeDTO)
        {


            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("pro_salary_approve_process ");

            objOracleCommand.CommandType = CommandType.StoredProcedure;


           

            if (objEmployeeDTO.Year != "")
            {
                objOracleCommand.Parameters.Add("P_APPROVE_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Year;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_APPROVE_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objEmployeeDTO.Month != "")
            {
                objOracleCommand.Parameters.Add("P_APPROVE_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Month;

            }
            else
            {
                objOracleCommand.Parameters.Add("P_APPROVE_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }



            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;


            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    trans = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    trans.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
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

            return strMsg;


        }
        public DataTable searchSalaryApprovedEmployeeEntry(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
                   "rownum sl, " +
                   "CARD_NO, " +
                   "EMPLOYEE_NAME, " +
                   "DESIGNATION_NAME, " +
                   "UNIT_NAME, " +
                   "SECTION_NAME, " +
                   "FIRST_SALARY, " +
                   "GROSS_SALARY, " +
                   "EMPLOYEE_ID, " +
                   "INCREMENT_AMOUNT, "+
                   "MANUAL_INCREMENT_AMOUNT, "+
                   "GROSS_SALARY_PRE, " +
                   "FIRST_SALARY_PRE, " +
                   "joining_date, " +
                   "occurence_type_name, " +
                   "OCCURENCE_TYPE_ID, " +
                   "approve_status " +

                  "FROM VEW_SALARY_PENDING_LIST WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "' AND branch_office_id = '" + objEmployeeDTO.BranchOfficeId + "' AND APPROVED_YN = 'Y' AND CHECKED_YN = 'Y'  AND APPROVE_YEAR = '" + objEmployeeDTO.Year + "' and APPROVE_MONTH = '" + objEmployeeDTO.Month + "' ";


            if (objEmployeeDTO.UnitId.Length > 0)
            {

                sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
            }
            if (objEmployeeDTO.SectionId.Length > 0)
            {

                sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
            }

            sql = sql + " order by occurence_type_name asc";


            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataAdapter.Fill(dt);

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



            return dt;

        }
        public DataTable searchSalaryCheckedEmployeeEntry(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
                   "rownum sl, " +
                   "CARD_NO, " +
                   "EMPLOYEE_NAME, " +
                   "DESIGNATION_NAME, " +
                   "UNIT_NAME, " +
                   "SECTION_NAME, " +
                   "FIRST_SALARY, " +
                   "GROSS_SALARY, " +
                   "EMPLOYEE_ID, " +
                   "INCREMENT_AMOUNT, " +
                   "MANUAL_INCREMENT_AMOUNT, " +
                   "GROSS_SALARY_PRE, " +
                   "FIRST_SALARY_PRE, " +
                   "joining_date, " +
                   "occurence_type_name, " +
                   "CHECKED_STATUS " +

                  "FROM VEW_SALARY_PENDING_LIST WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "' AND branch_office_id = '" + objEmployeeDTO.BranchOfficeId + "' AND CHECKED_YN = 'Y' AND APPROVE_YEAR = '" + objEmployeeDTO.Year + "' and APPROVE_MONTH = '" + objEmployeeDTO.Month + "' ";


            if (objEmployeeDTO.UnitId.Length > 0)
            {

                sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
            }
            if (objEmployeeDTO.SectionId.Length > 0)
            {

                sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
            }




            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataAdapter.Fill(dt);

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



            return dt;

        }

        public DataTable LoadEmployeeSalaryApprove(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
                   "rownum sl, " +
                   "CARD_NO, " +
                   "EMPLOYEE_ID, " +
                   "EMPLOYEE_NAME, " +
                   "DESIGNATION_NAME, " +
                   "UNIT_NAME, " +
                   "SECTION_NAME, " +
                   "FIRST_SALARY, " +
                   "GROSS_SALARY, " +
                   "INCREMENT_AMOUNT, "+
                   "MANUAL_INCREMENT_AMOUNT, "+
                   "GROSS_SALARY_PRE, "+
                   "FIRST_SALARY_PRE, "+
                   "joining_date, "+
                   "occurence_type_name, " +
                   "occurence_type_id, " +
                   "approve_status " +
                  //"occurence_type_code || ' (' || approve_status || ')' approve_status " +


                  "FROM VEW_SALARY_PENDING_LIST WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "' AND branch_office_id = '" + objEmployeeDTO.BranchOfficeId + "' AND APPROVE_YEAR = '"+objEmployeeDTO.Year+ "' and APPROVE_MONTH = '"+objEmployeeDTO.Month+ "' AND APPROVED_YN <> 'Y'  AND CHECKED_YN = 'Y' ";

            if (objEmployeeDTO.EmployeeId.Length > 0)
            {

                sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
            }

            if (objEmployeeDTO.SectionId.Length > 0)
            {

                sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
            }

            if (objEmployeeDTO.UnitId.Length > 0)
            {

                sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
            }

            if (objEmployeeDTO.CardNo.Length > 0)
            {

                sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
            }



            sql = sql + "order by occurence_type_name ";

            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataAdapter.Fill(dt);

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



            return dt;

        }
        public DataTable LoadEmployeeSalaryCheck(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
                   "rownum sl, " +
                   "CARD_NO, " +
                   "EMPLOYEE_ID, " +
                   "EMPLOYEE_NAME, " +
                   "DESIGNATION_NAME, " +
                   "UNIT_NAME, " +
                   "SECTION_NAME, " +
                   "FIRST_SALARY, " +
                   "GROSS_SALARY, " +
                   "INCREMENT_AMOUNT, " +
                   "MANUAL_INCREMENT_AMOUNT, " +
                   "GROSS_SALARY_PRE, " +
                   "FIRST_SALARY_PRE, " +
                   "joining_date, " +
                   "occurence_type_name, " +
                   "occurence_type_id, " +
                   "CHECKED_STATUS " +
                   
                  "FROM VEW_SALARY_PENDING_LIST WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "' AND branch_office_id = '" + objEmployeeDTO.BranchOfficeId + "' AND APPROVE_YEAR = '" + objEmployeeDTO.Year + "' and APPROVE_MONTH = '" + objEmployeeDTO.Month + "' AND CHECKED_YN <> 'Y'   ";

            if (objEmployeeDTO.EmployeeId.Length > 0)
            {

                sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
            }

            if (objEmployeeDTO.SectionId.Length > 0)
            {

                sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
            }

            if (objEmployeeDTO.UnitId.Length > 0)
            {

                sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
            }

            if (objEmployeeDTO.CardNo.Length > 0)
            {

                sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
            }



            sql = sql + "order by SL ";

            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataAdapter.Fill(dt);

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



            return dt;

        }

        public DataTable searchEmployeeSalaryApprove(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
                   "rownum sl, " +
                   "CARD_NO, " +
                   "EMPLOYEE_ID, " +
                   "EMPLOYEE_NAME, " +
                   "DESIGNATION_NAME, " +
                   "UNIT_NAME, " +
                   "SECTION_NAME, " +
                   "FIRST_SALARY, " +
                   "GROSS_SALARY, " +
                   //"occurence_type_name, " +
                   "to_char(joining_date, 'dd/mm/yyyy')joining_date " +
                  // "REMARKS " +

                  " FROM VEW_BASIC_INFO_HO WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "' AND branch_office_id = '" + objEmployeeDTO.BranchOfficeId + "'  ";

            if (objEmployeeDTO.EmployeeId.Length > 0)
            {

                sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
            }

            if (objEmployeeDTO.SectionId.Length > 0)
            {

                sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
            }

            if (objEmployeeDTO.UnitId.Length > 0)
            {

                sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
            }

            if (objEmployeeDTO.CardNo.Length > 0)
            {

                sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
            }



            sql = sql + "order by SL ";

            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataAdapter.Fill(dt);

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



            return dt;

        }

        public string deleteSalaryAprovedEmpRecord(EmployeeDTO objEmployeeDTO)
        {

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("PRO_DELETE_SALARY_APPROVE");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objEmployeeDTO.EmpId != "")
            {

                objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmpId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objEmployeeDTO.Year != "")
            {

                objOracleCommand.Parameters.Add("P_APPROVE_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Year;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_APPROVE_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objEmployeeDTO.Month != "")
            {

                objOracleCommand.Parameters.Add("P_APPROVE_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Month;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_APPROVE_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }





            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;


            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 1000).Direction = ParameterDirection.Output;

            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    trans = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    trans.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
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



            return strMsg;
        }
        public string deleteSalaryCheckEmpRecord(EmployeeDTO objEmployeeDTO)
        {

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("PRO_DELETE_SALARY_CHECKED");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objEmployeeDTO.EmpId != "")
            {

                objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmpId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objEmployeeDTO.Year != "")
            {

                objOracleCommand.Parameters.Add("P_APPROVE_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Year;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_APPROVE_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objEmployeeDTO.Month != "")
            {

                objOracleCommand.Parameters.Add("P_APPROVE_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Month;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_APPROVE_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }





            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;


            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 1000).Direction = ParameterDirection.Output;

            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    trans = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    trans.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
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



            return strMsg;
        }
        public string deleteSalaryCheckedEmpRecord(EmployeeDTO objEmployeeDTO)
        {

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("PRO_DELETE_SALARY_CHECKED");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objEmployeeDTO.EmpId != "")
            {

                objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmpId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objEmployeeDTO.Year != "")
            {

                objOracleCommand.Parameters.Add("P_APPROVE_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Year;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_APPROVE_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objEmployeeDTO.Month != "")
            {

                objOracleCommand.Parameters.Add("P_APPROVE_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Month;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_APPROVE_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }





            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;


            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 1000).Direction = ParameterDirection.Output;

            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    trans = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    trans.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
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



            return strMsg;
        }

        //old
        public DataTable searchEmployeeInfo(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
                   "rownum sl, " +
                   "CARD_NO, " +
                   "EMPLOYEE_NAME, " +
                   "DESIGNATION_NAME, " +
                   "EMPLOYEE_ID " +
                   "FROM VEW_BASIC_INFO_WORKER WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "' AND branch_office_id = '" + objEmployeeDTO.BranchOfficeId + "' ";

            if (objEmployeeDTO.EmployeeId.Length > 0)
            {
                sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
            }
            if (objEmployeeDTO.SectionId.Length > 0)
            {
                sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
            }

            if (objEmployeeDTO.UnitId.Length > 0)
            {
                sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
            }

            if (objEmployeeDTO.CardNo.Length > 0)
            {
                sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
            }

            sql = sql + "order by SL ";

            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataAdapter.Fill(dt);
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
            return dt;
        }

        public DataTable GetEmployeeBasicInfo(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";
            //VEW_BASIC_INFO_WORKER
            sql = "SELECT " +
                   "rownum sl, " +
                   "CARD_NO, " +
                   "EMPLOYEE_NAME, " +
                   "DESIGNATION_NAME, " +
                   "EMPLOYEE_ID, " +
                   "shift_name, " +
                   "shift_effect_date, " +
                   "shift_id, " +
                   "holiday_name, " +
                   "holiday_effect_date " +
                   "FROM VW_EMP_SHIFT_BASIC_INFO WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "' AND branch_office_id = '" + objEmployeeDTO.BranchOfficeId + "' ";

            if (objEmployeeDTO.ShiftId.Length>0)
            {
                sql = sql + "and shift_id = '" + objEmployeeDTO.ShiftId + "'";
            }

            if (objEmployeeDTO.EmployeeId.Length > 0)
            {
                sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
            }
            if (objEmployeeDTO.SectionId.Length > 0)
            {
                sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
            }

            if (objEmployeeDTO.UnitId.Length > 0)
            {
                sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
            }

            if (objEmployeeDTO.CardNo.Length > 0)
            {
                sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
            }
            
            sql = sql + "order by SL ";

            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataAdapter.Fill(dt);
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
            return dt;
        }

        public string saveOfficeShiftTime(EmployeeDTO objEmployeeDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_Office_Shift_Time_Save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;
            
            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;
           
            if (objEmployeeDTO.ShiftTypeId != " ")
            {
                objOracleCommand.Parameters.Add("P_SHIFT_TYPE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.ShiftTypeId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SHIFT_TYPE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
                        
            if (objEmployeeDTO.UnitId != " ")
            {
                objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeDTO.SectionId != " ")
            {
                objOracleCommand.Parameters.Add("P_SECTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SECTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            
            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
            
            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    objOracleTransaction = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    objOracleTransaction.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
                }

                catch (Exception ex)
                {
                    objOracleTransaction.Rollback();
                    throw new Exception("Error : " + ex.Message);
                }

                finally
                {

                    strConn.Close();
                }

            }
            return strMsg;

        }

        public string SaveEmployeeShiftMapping(EmployeeDTO objEmployeeDTO, out string status)
        {
            string strMsg = "";

            status = "NOK";

            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("sp_employee_shift_mapping_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;
            
            objOracleCommand.Parameters.Add("p_mapping_id", OracleDbType.Decimal, ParameterDirection.Input).Value = objEmployeeDTO.MappingId;
            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;

            if (objEmployeeDTO.ShiftId != "")
            {
                objOracleCommand.Parameters.Add("P_SHIFT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.ShiftId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SHIFT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            objOracleCommand.Parameters.Add("p_effect_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EffectiveDate;
            objOracleCommand.Parameters.Add("p_end_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EndDate;
            //objOracleCommand.Parameters.Add("p_active_yn", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.ActiveYn;


            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("P_create_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CreateBy;

            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;
            objOracleCommand.Parameters.Add("P_STATUS", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    objOracleTransaction = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    objOracleTransaction.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
                    status = objOracleCommand.Parameters["P_STATUS"].Value.ToString();
                }
                catch (Exception ex)
                {
                    objOracleTransaction.Rollback();
                    throw new Exception("Error : " + ex.Message);
                }
                finally
                {
                    strConn.Close();
                }
            }
            return strMsg;
        }

        public DataTable loadOfficeShiftTime(EmployeeDTO objEmployeeDTO)
        {
            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
                   "rownum sl, " +
                   "CARD_NO, " +
                   "EMPLOYEE_NAME, " +
                   "DESIGNATION_NAME, " +
                   "EMPLOYEE_ID, " +
                   "SHIFT_TYPE_ID, " +
                   "shift_type_name, " +
                   "HOLIDAY_ID, " +
                   "HOLIDAY_NAME " +
                  " FROM VEW_OFFICE_SHIFT_TIME WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "' AND branch_office_id = '" + objEmployeeDTO.BranchOfficeId + "' ";
            if (objEmployeeDTO.SectionId.Length > 0)
            {
                sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
            }

            if (objEmployeeDTO.UnitId.Length > 0)
            {
                sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
            }
            sql = sql + "order by SL ";

            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataAdapter.Fill(dt);
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
            return dt;
        }


        public DataTable GetEmployeeShiftMapping(EmployeeDTO objEmployeeDTO)
        {
            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
                  "rownum sl, " +
                  "MAPPING_ID, " +
                  "EMPLOYEE_ID, " +
                  "card_no, " +
                  "employee_name, " +
                  "designation_name, " +
                  "SHIFT_ID, " +
                  "shift_name, " +
                  "TO_CHAR(EFFECT_DATE, 'DD/MM/YYYY') EFFECT_DATE, " +
                  "END_DATE, " +
                  "UNIT_ID, " +
                  "SECTION_ID, " +
                  "HEAD_OFFICE_ID, " +
                  "BRANCH_OFFICE_ID " +
                  " FROM VW_EMPLOYEE_SHIFT_MAPPING WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "' AND branch_office_id = '" + objEmployeeDTO.BranchOfficeId + "' ";
            
                  //sql = sql + "order by to_number(card_no), EFFECT_DATE ";

                OracleCommand objCommand = new OracleCommand(sql);
                OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
                using (OracleConnection strConn = GetConnection())
                {
                    try
                    {
                        objCommand.Connection = strConn;
                        strConn.Open();
                        objDataAdapter.Fill(dt);
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
                return dt;
        }


        #region Emoplyee Special Mapping
        public string SaveSpecialEmployeeShiftMapping(EmployeeDTO objEmployeeDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("sp_special_emp_shift_map_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            objOracleCommand.Parameters.Add("p_mapping_id", OracleDbType.Decimal, ParameterDirection.Input).Value = objEmployeeDTO.MappingId;
            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;

            if (objEmployeeDTO.ShiftId != "")
            {
                objOracleCommand.Parameters.Add("P_SHIFT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.ShiftId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SHIFT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            objOracleCommand.Parameters.Add("p_effect_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EffectiveDate;
            objOracleCommand.Parameters.Add("p_active_yn", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.ActiveYn;


            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("P_create_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CreateBy;

            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    objOracleTransaction = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    objOracleTransaction.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
                }

                catch (Exception ex)
                {
                    objOracleTransaction.Rollback();
                    throw new Exception("Error : " + ex.Message);
                }

                finally
                {

                    strConn.Close();
                }

            }
            return strMsg;

        }
        public DataTable GetSpecialEmployeeShiftMapping(EmployeeDTO objEmployeeDTO)
        {
            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
                  "rownum sl, " +
                  "MAPPING_ID, " +
                  "EMPLOYEE_ID, " +
                  "card_no, " +
                  "employee_name, " +
                  "designation_name, " +

                  "SHIFT_ID, " +
                  "shift_name, " +

                  //"shift_name, " +
                  //"holiday_name, " +
                  //"SPECIAL_SHIFT_ID, " +
                  //"special_shift_name, " +
                  ////"SHIFT_ID, " +

                  "EFFECT_DATE, " +
                  "ACTIVE_YN, " +
                  "UNIT_ID, " +
                  "SECTION_ID, " +
                  "HEAD_OFFICE_ID, " +
                  "BRANCH_OFFICE_ID " +
                  " FROM VW_SPECIAL_EMP_SHIFT_MAPPING WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "' AND branch_office_id = '" + objEmployeeDTO.BranchOfficeId + "' " + "and effect_date =  nvl('" + objEmployeeDTO.EffectiveDate + "', effect_date)" + "and employee_id =  nvl('" + objEmployeeDTO.EmployeeId + "', employee_id) ";
            // VW_EMP_SPECIAL_SHIFT_MAPPING //NEW 
            if (!string.IsNullOrEmpty(objEmployeeDTO.CardNo))
                sql = sql + " and card_no= '" +  objEmployeeDTO.CardNo + "'" ;

            sql = sql + " order by SL ";

            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataAdapter.Fill(dt);
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
            return dt;
        }
        #endregion


        public string deleteOfficeShiftTimeRecord(EmployeeDTO objEmployeeDTO)
        {

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("PRO_DELETE_OFFICE_SHIFT_TIME");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            if (objEmployeeDTO.EmpId != "")
            {

                objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmpId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }






            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;


            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 1000).Direction = ParameterDirection.Output;

            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    trans = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    trans.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
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



            return strMsg;
        }

        public string SaveEmployeeShiftHolidayMapping(EmployeeDTO objEmployeeDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("SAVE_EMP_SHIFT_HOLIDAY_MAPPING");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("p_mapping_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.MappingId;
            objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;
  
            if (objEmployeeDTO.DayId != "0")
            {
                objOracleCommand.Parameters.Add("p_holiday_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.DayId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_holiday_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeDTO.EffectiveDate != "")
            {
                objOracleCommand.Parameters.Add("p_effect_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EffectiveDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_effect_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            //if (objEmployeeDTO.ActiveYn != "")
            //{
            //    objOracleCommand.Parameters.Add("p_active_yn", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.ActiveYn;
            //}
            //else
            //{
            //    objOracleCommand.Parameters.Add("p_active_yn", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            //}

            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("p_create_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CreateBy;

            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    objOracleTransaction = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    objOracleTransaction.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
                }

                catch (Exception ex)
                {
                    objOracleTransaction.Rollback();
                    throw new Exception("Error : " + ex.Message);
                }
                finally
                {
                    strConn.Close();
                }
            }
            return strMsg;
        }


        public EmployeeShiftHolidayMapping GetEmployeeShiftHolidayMappingByMappingId(string mappingId)
        {
            List<EmployeeShiftHolidayMapping> objMappings = new List<EmployeeShiftHolidayMapping>();

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            DataTable dt = new DataTable();
            try
            {
                string strMsg = "";
                OracleTransaction objOracleTransaction;
                OracleCommand objOracleCommand = new OracleCommand("SP_GET_SHIFT_DH_EMP_BY_MAP_ID");
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                //objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = headOfficeId;
                //objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = branchOfficeId;

                objOracleCommand.Parameters.Add("p_mapping_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = mappingId;

                objOracleCommand.Parameters.Add("p_dbcursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                string VALUE = string.Empty;

                using (OracleConnection strConn = GetConnection())
                {
                    try
                    {
                        objOracleCommand.Connection = strConn;
                        strConn.Open();
                        trans = strConn.BeginTransaction();

                        dt.Load(objOracleCommand.ExecuteReader());
                        trans.Commit();
                        strConn.Close();

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            EmployeeShiftHolidayMapping objMapping = new EmployeeShiftHolidayMapping();
                            objMapping.SL = Convert.ToDecimal(dt.Rows[i]["sl"]);
                            objMapping.MappingId = Convert.ToDecimal(dt.Rows[i]["mapping_id"]);
                            objMapping.CradNo = Convert.ToString(dt.Rows[i]["CARD_NO"]);
                            objMapping.EmployeeName = Convert.ToString(dt.Rows[i]["EMPLOYEE_NAME"]);
                            objMapping.DesignationName = Convert.ToString(dt.Rows[i]["DESIGNATION_NAME"]);

                            objMapping.EmployeeId = Convert.ToString(dt.Rows[i]["EMPLOYEE_ID"]);
                            objMapping.HolidayId = Convert.ToDecimal(dt.Rows[i]["Holiday_Id"]);
                            objMapping.HolidayName = Convert.ToString(dt.Rows[i]["HOLIDAY_MANE"]);
                            objMapping.EffectDate = Convert.ToString(dt.Rows[i]["EFFECT_DATE"]); 
                            objMapping.ActiveYn = Convert.ToString(dt.Rows[i]["active_yn"]);
                            objMappings.Add(objMapping);
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMappings.ToList().SingleOrDefault();
        }

        //03.04.2019
        public List<EmployeeDTO> GetShiftEmployeeBasicInfo(EmployeeDTO objEmployeeDTO)
        {
            List<EmployeeDTO> objEmployeeBasics = new List<EmployeeDTO>();

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            DataTable dt = new DataTable();
            try
            {
                string strMsg = "";
                OracleTransaction objOracleTransaction;
                OracleCommand objOracleCommand = new OracleCommand("SP_GET_SHIFT_EMP_BASIC_INFO");
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                if (objEmployeeDTO.EmployeeId != "")
                {
                    objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;
                }
                else
                {
                    objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
                }

                if (objEmployeeDTO.CardNo != "")
                {
                    objOracleCommand.Parameters.Add("p_card_no", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CardNo;
                }
                else
                {
                    objOracleCommand.Parameters.Add("p_card_no", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
                }

                if (objEmployeeDTO.ShiftId != "")
                {
                    objOracleCommand.Parameters.Add("p_shift_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.ShiftId;
                }
                else
                {
                    objOracleCommand.Parameters.Add("p_shift_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
                }

                objOracleCommand.Parameters.Add("p_effect_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EffectiveDate;

                if (objEmployeeDTO.UnitId != "")
                {
                    objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UnitId;
                }
                else
                {
                    objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
                }
                if (objEmployeeDTO.SectionId != "")
                {
                    objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SectionId;
                }
                else
                {
                    objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
                }
                
                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
                                
                objOracleCommand.Parameters.Add("p_dbcursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                string VALUE = string.Empty;

                using (OracleConnection strConn = GetConnection())
                {
                    try
                    {
                        objOracleCommand.Connection = strConn;
                        strConn.Open();
                        trans = strConn.BeginTransaction();

                        dt.Load(objOracleCommand.ExecuteReader());
                        trans.Commit();
                        strConn.Close();

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            EmployeeDTO obj = new EmployeeDTO();
                            obj.SLNo = Convert.ToString(dt.Rows[i]["sl"]);
                            obj.GroupOfficeNameEng = Convert.ToString(dt.Rows[i]["GROUP_OFFICE_NAME_ENG"]);

                            obj.HeadOfficeId = Convert.ToString(dt.Rows[i]["head_office_id"]);
                            obj.HeadOfficeName = Convert.ToString(dt.Rows[i]["head_office_name"]);
                            obj.HeadOfficeAddress = Convert.ToString(dt.Rows[i]["head_office_address"]);

                            obj.BranchOfficeId = Convert.ToString(dt.Rows[i]["BRANCH_OFFICE_ID"]);
                            
                            obj.EmployeeId = Convert.ToString(dt.Rows[i]["employee_id"]);
                            obj.EmployeeName = Convert.ToString(dt.Rows[i]["employee_name"]);
                            obj.EmployeeNameBangla = Convert.ToString(dt.Rows[i]["employee_name_bangla"]);

                            obj.CardNo = Convert.ToString(dt.Rows[i]["card_no"]);
                            obj.DesignationId = Convert.ToString(dt.Rows[i]["designation_id"]);
                            obj.DesignationName = Convert.ToString(dt.Rows[i]["designation_name"]);
                            obj.GradeNo = Convert.ToString(dt.Rows[i]["GRADE_NO"]);

                            obj.UnitId = Convert.ToString(dt.Rows[i]["unit_id"]);
                            obj.UnitName = Convert.ToString(dt.Rows[i]["unit_name"]);

                            obj.SectionId = Convert.ToString(dt.Rows[i]["section_id"]);
                            obj.SectionName = Convert.ToString(dt.Rows[i]["section_name"]);

                            //obj.GrossSalary = Convert.ToString(dt.Rows[i]["gross_salary"]);
                            //obj.FirstSalary = Convert.ToString(dt.Rows[i]["first_salary"]);
                            
                            obj.ShiftName = Convert.ToString(dt.Rows[i]["shift_name"]);
                            //obj.ShiftEffectDate = Convert.ToString(dt.Rows[i]["shift_effect_date"]);
                            //obj.HolidayName = Convert.ToString(dt.Rows[i]["holiday_name"]);
                            //obj.HolidayEffectDate = Convert.ToString(dt.Rows[i]["holiday_effect_date"]);

                            objEmployeeBasics.Add(obj);
                        }
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        //throw new Exception("Error : " + ex.Message);
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
            return objEmployeeBasics;
        }

        //Old
        public string saveOfficeShiftHoliday(EmployeeDTO objEmployeeDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction;
            OracleCommand objOracleCommand = new OracleCommand("pro_Office_Shift_Holiday_Save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;
            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;
            
            if (objEmployeeDTO.HolidayDate != " ")
            {
                objOracleCommand.Parameters.Add("P_HOLIDAY_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HolidayDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_HOLIDAY_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            
            if (objEmployeeDTO.UnitId != " ")
            {
                objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeDTO.SectionId != " ")
            {
                objOracleCommand.Parameters.Add("P_SECTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SECTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
            
            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    trans = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    trans.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
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
            return strMsg;
        }

        public DataTable loadOfficeShiftHoliday(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
                   "rownum sl, " +
                   "CARD_NO, " +
                   "EMPLOYEE_NAME, " +
                   "DESIGNATION_NAME, " +
                   "EMPLOYEE_ID " +
                  " FROM VEW_OFFICE_SHIFT_HOLIDAY WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "' AND branch_office_id = '" + objEmployeeDTO.BranchOfficeId + "' ";

            if (objEmployeeDTO.EmployeeId.Length > 0)
            {
                sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
            }

            if (objEmployeeDTO.SectionId.Length > 0)
            {
                sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
            }

            if (objEmployeeDTO.UnitId.Length > 0)
            {

                sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
            }

            //if (objEmployeeDTO.CardNo.Length > 0)
            //{

            //    sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
            //}





            sql = sql + "order by SL ";

            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataAdapter.Fill(dt);

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



            return dt;

        }

        public DataTable GetShiftEmpHolidayMappingByEmp(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
                   "rownum SL, " +
                   "mapping_id MappingId, " +
                   "CARD_NO CradNo, " +
                   "EMPLOYEE_NAME EmployeeName, " +
                   "DESIGNATION_NAME DesignationName, " +
                   "EMPLOYEE_ID EmployeeId, " +
                   "Holiday_Id HolidayId, " +
                   "HOLIDAY_MANE HolidayName, " +
                   "shift_name ShiftName, " +
                   "EFFECT_DATE EffectDate " +
                  " FROM VW_OFFICE_SFT_HOLIDAY_MAPPING WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "' AND branch_office_id = '" + objEmployeeDTO.BranchOfficeId + "' ";

            if (objEmployeeDTO.EmployeeId.Length > 0)
            {
                sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
            }
           // sql = sql + "order by SL ";

            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataAdapter.Fill(dt);
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
            return dt;
        }

        public string deleteOfficeShiftHolidayRecord(EmployeeDTO objEmployeeDTO)
        {

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("PRO_DELETE_OFFICE_HOLIDAY_TIME");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objEmployeeDTO.EmpId != "")
            {
                objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmpId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;

            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 1000).Direction = ParameterDirection.Output;

            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    trans = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    trans.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
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
            return strMsg;
        }


        public string DeleteEmployeeShiftHoliday(string mappingId)
        {

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("SP_DEL_EMP_SHIFT_DH_BY_MAP_ID");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("p_mapping_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = mappingId;

            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 1000).Direction = ParameterDirection.Output;

            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    trans = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    trans.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
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
            return strMsg;
        }

        public DataTable searchOTSalaryInfoResign(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
                   "rownum sl, " +
                   "CARD_NO, " +
                   "EMPLOYEE_ID, " +
                   "EMPLOYEE_NAME, " +
                   "DESIGNATION_NAME, " +
                   "OT_HOUR " +
                 


                  "FROM VEW_SEARCH_OT_ENTRY_RESIGN WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' and ot_year = '" + objEmployeeDTO.Year + "' and ot_month = '" + objEmployeeDTO.Month + "' ";







            if (objEmployeeDTO.SectionId.Length > 0)
            {

                sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
            }

            if (objEmployeeDTO.UnitId.Length > 0)
            {

                sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
            }



            sql = sql + "order by SL ";

            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataAdapter.Fill(dt);

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



            return dt;

        }


        public DataTable searchSalaryInfoTemp(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
                   "rownum sl, " +
                   "CARD_NO, " +
                   "EMPLOYEE_ID, " +
                   "EMPLOYEE_NAME, " +
                   "DESIGNATION_NAME, " +
                   "ADVANCE_FEE, " +
                   "ARREAR_FEE, " +
                   "OVER_TIME_HOUR, " +
                   "WORKING_DAY, " +
                   "ATTENDENCE_FEE  " +

                  "FROM VIEW_SALARY_INFO_ENTRY_TEMP WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' and salary_year = '" + objEmployeeDTO.Year + "' and salary_month = '" + objEmployeeDTO.Month + "' ";







            if (objEmployeeDTO.SectionId.Length > 0)
            {

                sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
            }

            if (objEmployeeDTO.UnitId.Length > 0)
            {

                sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
            }



            sql = sql + "order by SL ";

            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataAdapter.Fill(dt);

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



            return dt;

        }

        public DataTable searchSalaryApproveEntryRecord(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
                   "rownum sl, " +
                   "CARD_NO, " +
                   "EMPLOYEE_ID, " +
                   "EMPLOYEE_NAME, " +
                   "DESIGNATION_NAME, " +
                    "FIRST_SALARY, " +
                    "GROSS_SALARY " +

                  "FROM VEW_SEARCH_EMP_FOR_SAL_APPROVE WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "'";



            if (objEmployeeDTO.EmployeeId.Length > 0)
            {

                sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
            }

            if (objEmployeeDTO.CardNo.Length > 0)
            {

                sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
            }


            if (objEmployeeDTO.SectionId.Length > 0)
            {

                sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
            }



            if (objEmployeeDTO.UnitId.Length > 0)
            {

                sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
            }

            sql = sql + "order by SL ";

            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataAdapter.Fill(dt);

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



            return dt;

        }

        public DataTable loadSalaryApproveEntryRecord(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
                   "rownum sl, " +
                   "CARD_NO, " +
                   "EMPLOYEE_ID, " +
                   "EMPLOYEE_NAME, " +
                   "DESIGNATION_NAME, " +
                   "FIRST_SALARY, " +
                   "GROSS_SALARY, " +
                   "FIRST_SALARY_PRE, " +
                   "GROSS_SALARY_PRE, " +
                   "APPROVE_STATUS "+




                  "FROM VEW_SALARY_PENDING_LIST WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' and approve_year = '" + objEmployeeDTO.Year + "' and approve_month = '" + objEmployeeDTO.Month + "' AND MANUAL_YN = 'Y' ";




            if (objEmployeeDTO.SectionId.Length > 0)
            {

                sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
            }


            if (objEmployeeDTO.UnitId.Length > 0)
            {

                sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
            }



            sql = sql + "order by SL ";

            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataAdapter.Fill(dt);

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



            return dt;

        }


        public DataTable searchDiscardAnnualIncrementWorker(EmployeeDTO objEmployeeDTO)
        {

            DataSet ds = null;
            DataTable myTable = new DataTable();
            try
            {
                string strMsg = "";
                OracleTransaction objOracleTransaction;
                OracleCommand objOracleCommand = new OracleCommand("SP_GET_ANNUAL_INCR_DETAIL_W");
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                objOracleCommand.Parameters.Add("p_increment_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Year;
                objOracleCommand.Parameters.Add("p_increment_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Month;
                objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;

                if (objEmployeeDTO.FromDate.Length > 6)
                {
                    objOracleCommand.Parameters.Add("p_from_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.FromDate;
                }
                else
                {
                    objOracleCommand.Parameters.Add("p_from_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
                }
                if (objEmployeeDTO.ToDate.Length > 6)
                {
                    objOracleCommand.Parameters.Add("p_to_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.ToDate;
                }
                else
                {
                    objOracleCommand.Parameters.Add("p_to_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
                }

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UnitId;
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SectionId;
                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
                objOracleCommand.Parameters.Add("p_logged_in_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UpdateBy;

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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return myTable;
        }

        public string PrepareAttendanceSummary(ReportDTO objReportDTO)
        {
            string strMsg = "";
           
            OracleCommand objOracleCommand = new OracleCommand("sp_prepare_attendance_summary");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("p_from_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objReportDTO.FromDate;
            objOracleCommand.Parameters.Add("p_to_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objReportDTO.ToDate;

            objOracleCommand.Parameters.Add("p_floor_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objReportDTO.UnitId;
            objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objReportDTO.SectionId;

            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objReportDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objReportDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objReportDTO.UpdateBy;
            
            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;


            using (OracleConnection strConn = GetConnection())
            {
                try
                {

                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    trans = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    trans.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
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
            return strMsg;
        }

        public DataTable GetEmployeeInformation(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
                   "rownum sl, " +
                   "CARD_NO, " +
                   "EMPLOYEE_ID, " +
                   "EMPLOYEE_NAME, " +
                   "DESIGNATION_NAME, " +
                   "EMAIL_ADDRESS, " +
                   "MOBILE_NO, " +
                   "BRANCH_OFFICE_NAME " +

                  "FROM VEW_GET_EMPLOYEE_INFO WHERE  active_yn ='Y' ";
            // head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objEmployeeDTO.BranchOfficeId + "' AND
            if (objEmployeeDTO.HeadOfficeId.Length > 0)
            {

                sql = sql + "and head_office_id = '" + objEmployeeDTO.HeadOfficeId + "'";
            }
            if (objEmployeeDTO.BranchOfficeId.Length > 0)
            {

                sql = sql + "and branch_office_id = '" + objEmployeeDTO.BranchOfficeId + "'";
            }
            if (objEmployeeDTO.DesignationId.Length > 0)
            {

                sql = sql + "and designation_id = '" + objEmployeeDTO.DesignationId + "'";
            }

            if (objEmployeeDTO.EmployeeName.Length > 0)
            {

                sql = sql + "and (lower(employee_name) like lower( '%" + objEmployeeDTO.EmployeeName + "%')  or upper(employee_name)like upper('%" + objEmployeeDTO.EmployeeName + "%')) ";
            }
            sql = sql + "order by SL ";

            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataAdapter.Fill(dt);
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
            return dt;
        }

        public string SaveEmployeeContactDetail(EmployeeDTO objEmployeeDTO)
        {

            string strMsg = "";
            OracleTransaction trans = null;
            OracleCommand objOracleCommand = new OracleCommand("SP_EMPLOYEE_CONTACT_DETAIL");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objEmployeeDTO.EmployeeId != "")
            {
                objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.PhoneNo != "")
            {
                objOracleCommand.Parameters.Add("P_PHONE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.PhoneNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PHONE_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.EmailAddress != "")
            {
                objOracleCommand.Parameters.Add("P_EMAIL_ADDRESS", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmailAddress;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_EMAIL_ADDRESS", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    trans = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    trans.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
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
            return strMsg;
        }

        public DataTable GetPermanentQueue(EmployeeDTO objEmployeeDTO)
        {

            DataSet ds = null;
            DataTable myTable = new DataTable();
            try
            {
                string strMsg = "";
                OracleTransaction objOracleTransaction;
                OracleCommand objOracleCommand = new OracleCommand("SP_GET_PERMANENT_QUEUE");
                objOracleCommand.CommandType = CommandType.StoredProcedure;
                objOracleCommand.Parameters.Add("p_permanent_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Year;
                objOracleCommand.Parameters.Add("p_permanent_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Month;
                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return myTable;
        }
        //public string EmployeeSkillSave(EmployeeDTO objEmployeeDTO)
        //{
        //    string strMsg = "";

        //    //status = "NOK";

        //    OracleTransaction objOracleTransaction = null;
        //    OracleCommand objOracleCommand = new OracleCommand("sp_skill_worker_save");
        //    objOracleCommand.CommandType = CommandType.StoredProcedure;


        //    objOracleCommand.Parameters.Add("p_skill_id", OracleDbType.Decimal, ParameterDirection.Input).Value = objEmployeeDTO.SkillId;
        //    objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;

        //    if (objEmployeeDTO.SkillLevelId != "")
        //    {
        //        objOracleCommand.Parameters.Add("P_SKILL_LEVEL_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SkillLevelId;
        //    }
        //    else
        //    {
        //        objOracleCommand.Parameters.Add("P_SKILL_LEVEL_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
        //    }

        //    objOracleCommand.Parameters.Add("p_effect_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EffectiveDate;
        //    objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
        //    objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
        //    objOracleCommand.Parameters.Add("P_create_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CreateBy;

        //    objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;
        //    //   objOracleCommand.Parameters.Add("P_STATUS", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

        //    using (OracleConnection strConn = GetConnection())
        //    {
        //        try
        //        {
        //            objOracleCommand.Connection = strConn;
        //            strConn.Open();
        //            objOracleTransaction = strConn.BeginTransaction();
        //            objOracleCommand.ExecuteNonQuery();
        //            objOracleTransaction.Commit();
        //            strConn.Close();
        //            strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
        //            //status = objOracleCommand.Parameters["P_STATUS"].Value.ToString();
        //        }
        //        catch (Exception ex)
        //        {
        //            objOracleTransaction.Rollback();
        //            throw new Exception("Error : " + ex.Message);
        //        }
        //        finally
        //        {
        //            strConn.Close();
        //        }
        //    }
        //    return strMsg;
        //}
        //public List<EmployeeDTO> GetSkillEmployeeBasicInfo(EmployeeDTO objEmployeeDTO)
        //{
        //    List<EmployeeDTO> objEmployeeBasics = new List<EmployeeDTO>();

        //    LookUpDTO objLookUpDTO = new LookUpDTO();
        //    LookUpDAL objLookUpDAL = new LookUpDAL();

        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        string strMsg = "";
        //        OracleTransaction objOracleTransaction;
        //        OracleCommand objOracleCommand = new OracleCommand("SP_GET_SKILL_EMP_BASIC_INFO");
        //        objOracleCommand.CommandType = CommandType.StoredProcedure;

        //        if (objEmployeeDTO.EmployeeId != "")
        //        {
        //            objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;
        //        }
        //        else
        //        {
        //            objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
        //        }

        //        if (objEmployeeDTO.CardNo != "")
        //        {
        //            objOracleCommand.Parameters.Add("p_card_no", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CardNo;
        //        }
        //        else
        //        {
        //            objOracleCommand.Parameters.Add("p_card_no", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
        //        }

        //        if (objEmployeeDTO.SkillLevelId != "")
        //        {
        //            objOracleCommand.Parameters.Add("p_skill_level_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SkillLevelId;
        //        }
        //        else
        //        {
        //            objOracleCommand.Parameters.Add("p_skill_level_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
        //        }
        //        if (objEmployeeDTO.EffectiveDate != "")
        //        {
        //            objOracleCommand.Parameters.Add("p_effect_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EffectiveDate;
        //        }
        //        else
        //        {
        //            objOracleCommand.Parameters.Add("p_effect_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
        //        }


        //        if (objEmployeeDTO.UnitId != "")
        //        {
        //            objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UnitId;
        //        }
        //        else
        //        {
        //            objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
        //        }
        //        if (objEmployeeDTO.SectionId != "")
        //        {
        //            objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SectionId;
        //        }
        //        else
        //        {
        //            objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
        //        }

        //        objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
        //        objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;

        //        objOracleCommand.Parameters.Add("p_dbcursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

        //        string VALUE = string.Empty;

        //        using (OracleConnection strConn = GetConnection())
        //        {
        //            try
        //            {
        //                objOracleCommand.Connection = strConn;
        //                strConn.Open();
        //                trans = strConn.BeginTransaction();

        //                dt.Load(objOracleCommand.ExecuteReader());
        //                trans.Commit();
        //                strConn.Close();

        //                for (int i = 0; i < dt.Rows.Count; i++)
        //                {
        //                    EmployeeDTO obj = new EmployeeDTO();
        //                    obj.SLNo = Convert.ToString(dt.Rows[i]["sl"]);
        //                    obj.GroupOfficeNameEng = Convert.ToString(dt.Rows[i]["GROUP_OFFICE_NAME_ENG"]);

        //                    obj.HeadOfficeId = Convert.ToString(dt.Rows[i]["head_office_id"]);
        //                    obj.HeadOfficeName = Convert.ToString(dt.Rows[i]["head_office_name"]);
        //                    obj.HeadOfficeAddress = Convert.ToString(dt.Rows[i]["head_office_address"]);

        //                    obj.BranchOfficeId = Convert.ToString(dt.Rows[i]["BRANCH_OFFICE_ID"]);
        //                    //obj.BranchOfficeName = Convert.ToString(dt.Rows[i]["EMPLOYEE_NAME"]);
        //                    //obj.BranchOfficeAddress = Convert.ToString(dt.Rows[i]["DESIGNATION_NAME"]);

        //                    obj.EmployeeId = Convert.ToString(dt.Rows[i]["employee_id"]);
        //                    obj.EmployeeName = Convert.ToString(dt.Rows[i]["employee_name"]);
        //                    obj.EmployeeNameBangla = Convert.ToString(dt.Rows[i]["employee_name_bangla"]);

        //                    obj.CardNo = Convert.ToString(dt.Rows[i]["card_no"]);
        //                    obj.DesignationId = Convert.ToString(dt.Rows[i]["designation_id"]);
        //                    obj.DesignationName = Convert.ToString(dt.Rows[i]["designation_name"]);
        //                    obj.GradeNo = Convert.ToString(dt.Rows[i]["GRADE_NO"]);

        //                    obj.UnitId = Convert.ToString(dt.Rows[i]["unit_id"]);
        //                    obj.UnitName = Convert.ToString(dt.Rows[i]["unit_name"]);

        //                    obj.SectionId = Convert.ToString(dt.Rows[i]["section_id"]);
        //                    obj.SectionName = Convert.ToString(dt.Rows[i]["section_name"]);

        //                    // obj.GrossSalary = Convert.ToString(dt.Rows[i]["gross_salary"]);
        //                    // obj.FirstSalary = Convert.ToString(dt.Rows[i]["first_salary"]);

        //                    obj.SkillLevelName = Convert.ToString(dt.Rows[i]["skill_level_name"]);
        //                    obj.SkillLevelId = Convert.ToString(dt.Rows[i]["skill_level_id"]);
        //                    obj.EffectiveDate = Convert.ToString(dt.Rows[i]["Skill_effect_date"]);

        //                    objEmployeeBasics.Add(obj);
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                trans.Rollback();
        //                throw new Exception("Error : " + ex.Message);
        //            }
        //            finally
        //            {
        //                strConn.Close();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return objEmployeeBasics;
        //}
        //public DataTable GetSkillEmployeeMapping(EmployeeDTO objEmployeeDTO)
        //{
        //    DataTable dt = new DataTable();
        //    string sql = "";

        //    sql = "SELECT " +
        //          "rownum sl, " +
        //          "skill_ID, " +
        //          "EMPLOYEE_ID, " +
        //          "card_no, " +
        //          "employee_name, " +
        //          "designation_name, " +
        //          "SKILL_LEVEL_ID, " +
        //          "SKILL_LEVEL_NAME, " +
        //          "EFFECT_DATE, " +
        //          "UNIT_ID, " +
        //          "SECTION_ID, " +
        //          "HEAD_OFFICE_ID, " +
        //          "BRANCH_OFFICE_ID " +
        //          " FROM VW_SKILL_EMPLOYEE_MAPPING WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "' AND branch_office_id = '" + objEmployeeDTO.BranchOfficeId + "' " + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";

        //    //if (objEmployeeDTO.EmployeeId.Length > 0)
        //    //    {
        //    //        sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
        //    //    }

        //    //if (objEmployeeDTO.SectionId.Length > 0)
        //    //{
        //    //    sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
        //    //}

        //    //if (objEmployeeDTO.UnitId.Length > 0)
        //    //{
        //    //    sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
        //    //}
        //    sql = sql + "order by SL ";

        //    OracleCommand objCommand = new OracleCommand(sql);
        //    OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
        //    using (OracleConnection strConn = GetConnection())
        //    {
        //        try
        //        {
        //            objCommand.Connection = strConn;
        //            strConn.Open();
        //            objDataAdapter.Fill(dt);
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception("Error : " + ex.Message);
        //        }
        //        finally
        //        {
        //            strConn.Close();
        //        }
        //    }
        //    return dt;
        //}

        //public string ActiveInactiveEmployeeSave(EmployeeDTO objEmployeeDTO)
        //{
        //    string strMsg = "";
        //    OracleTransaction objOracleTransaction = null;
        //    OracleCommand objOracleCommand = new OracleCommand("sp_active_inactive_emp_save");
        //    objOracleCommand.CommandType = CommandType.StoredProcedure;
        //    objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;
        //    objOracleCommand.Parameters.Add("p_active_yn", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.ActiveYn;
        //    objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
        //    objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
        //    objOracleCommand.Parameters.Add("P_create_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CreateBy;

        //    objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;
        //    using (OracleConnection strConn = GetConnection())
        //    {
        //        try
        //        {
        //            objOracleCommand.Connection = strConn;
        //            strConn.Open();
        //            objOracleTransaction = strConn.BeginTransaction();
        //            objOracleCommand.ExecuteNonQuery();
        //            objOracleTransaction.Commit();
        //            strConn.Close();
        //            strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
        //        }
        //        catch (Exception ex)
        //        {
        //            objOracleTransaction.Rollback();
        //            throw new Exception("Error : " + ex.Message);
        //        }
        //        finally
        //        {
        //            strConn.Close();
        //        }
        //    }
        //    return strMsg;
        //}

        //public List<EmployeeDTO> GetActiveInactiveEmployee(EmployeeDTO objEmployeeDTO)
        //{
        //    List<EmployeeDTO> objEmployeeBasics = new List<EmployeeDTO>();

        //    LookUpDTO objLookUpDTO = new LookUpDTO();
        //    LookUpDAL objLookUpDAL = new LookUpDAL();

        //    DataTable dt = new DataTable();
        //    try
        //    {

        //        OracleCommand objOracleCommand = new OracleCommand("SP_GET_ACTIVE_INACTIVE_EMP");
        //        objOracleCommand.CommandType = CommandType.StoredProcedure;

        //        if (objEmployeeDTO.EmployeeId != "")
        //        {
        //            objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;
        //        }
        //        else
        //        {
        //            objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
        //        }

        //        if (objEmployeeDTO.CardNo != "")
        //        {
        //            objOracleCommand.Parameters.Add("p_card_no", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CardNo;
        //        }
        //        else
        //        {
        //            objOracleCommand.Parameters.Add("p_card_no", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
        //        }

        //        if (objEmployeeDTO.UnitId != "")
        //        {
        //            objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UnitId;
        //        }
        //        else
        //        {
        //            objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
        //        }
        //        if (objEmployeeDTO.SectionId != "")
        //        {
        //            objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SectionId;
        //        }
        //        else
        //        {
        //            objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
        //        }
        //        objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Year;
        //        objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Month;
        //        objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
        //        objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;

        //        objOracleCommand.Parameters.Add("p_dbcursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

        //        string VALUE = string.Empty;

        //        using (OracleConnection strConn = GetConnection())
        //        {
        //            try
        //            {
        //                objOracleCommand.Connection = strConn;
        //                strConn.Open();
        //                trans = strConn.BeginTransaction();

        //                dt.Load(objOracleCommand.ExecuteReader());
        //                trans.Commit();
        //                strConn.Close();

        //                for (int i = 0; i < dt.Rows.Count; i++)
        //                {
        //                    EmployeeDTO obj = new EmployeeDTO();
        //                    obj.SLNo = Convert.ToString(dt.Rows[i]["sl"]);
        //                    obj.GroupOfficeNameEng = Convert.ToString(dt.Rows[i]["GROUP_OFFICE_NAME_ENG"]);

        //                    obj.HeadOfficeId = Convert.ToString(dt.Rows[i]["head_office_id"]);
        //                    obj.HeadOfficeName = Convert.ToString(dt.Rows[i]["head_office_name"]);
        //                    obj.HeadOfficeAddress = Convert.ToString(dt.Rows[i]["head_office_address"]);

        //                    obj.BranchOfficeId = Convert.ToString(dt.Rows[i]["BRANCH_OFFICE_ID"]);
        //                    obj.EmployeeId = Convert.ToString(dt.Rows[i]["employee_id"]);
        //                    obj.EmployeeName = Convert.ToString(dt.Rows[i]["employee_name"]);
        //                    obj.EmployeeNameBangla = Convert.ToString(dt.Rows[i]["employee_name_bangla"]);

        //                    obj.CardNo = Convert.ToString(dt.Rows[i]["card_no"]);
        //                    obj.DesignationId = Convert.ToString(dt.Rows[i]["designation_id"]);
        //                    obj.DesignationName = Convert.ToString(dt.Rows[i]["designation_name"]);
        //                    obj.GradeNo = Convert.ToString(dt.Rows[i]["GRADE_NO"]);

        //                    obj.UnitId = Convert.ToString(dt.Rows[i]["unit_id"]);
        //                    obj.UnitName = Convert.ToString(dt.Rows[i]["unit_name"]);

        //                    obj.SectionId = Convert.ToString(dt.Rows[i]["section_id"]);
        //                    obj.SectionName = Convert.ToString(dt.Rows[i]["section_name"]);
        //                    obj.ActiveYn = Convert.ToString(dt.Rows[i]["active_yn"]);
        //                    objEmployeeBasics.Add(obj);
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                trans.Rollback();
        //                throw new Exception("Error : " + ex.Message);
        //            }
        //            finally
        //            {
        //                strConn.Close();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return objEmployeeBasics;
        //}
        public string ActiveInactiveEmployeeSave(EmployeeDTO objEmployeeDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("sp_active_inactive_emp_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;
            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;
            objOracleCommand.Parameters.Add("p_active_yn", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.ActiveYn;
            objOracleCommand.Parameters.Add("P_STATUS_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.StatusId;
            objOracleCommand.Parameters.Add("p_status", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Status;
            objOracleCommand.Parameters.Add("p_effect_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EffectiveDate;

            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("P_create_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CreateBy;

            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    objOracleTransaction = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    objOracleTransaction.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
                }
                catch (Exception ex)
                {
                    objOracleTransaction.Rollback();
                    throw new Exception("Error : " + ex.Message);
                }
                finally
                {
                    strConn.Close();
                }
            }
            return strMsg;
        }

        public List<EmployeeDTO> GetActiveInactiveEmployee(EmployeeDTO objEmployeeDTO)
        {
            List<EmployeeDTO> objEmployeeBasics = new List<EmployeeDTO>();

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            DataTable dt = new DataTable();
            try
            {

                OracleCommand objOracleCommand = new OracleCommand("SP_GET_ACTIVE_INACTIVE_EMP");
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                if (objEmployeeDTO.EmployeeId != "")
                {
                    objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;
                }
                else
                {
                    objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
                }

                if (objEmployeeDTO.CardNo != "")
                {
                    objOracleCommand.Parameters.Add("p_card_no", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CardNo;
                }
                else
                {
                    objOracleCommand.Parameters.Add("p_card_no", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
                }

                if (objEmployeeDTO.UnitId != "")
                {
                    objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UnitId;
                }
                else
                {
                    objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
                }
                if (objEmployeeDTO.SectionId != "")
                {
                    objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SectionId;
                }
                else
                {
                    objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
                }
                objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Year;
                objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Month;
                objOracleCommand.Parameters.Add("P_start_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.FromDate;
                objOracleCommand.Parameters.Add("p_end_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.ToDate;
                objOracleCommand.Parameters.Add("p_active_yn", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.ActiveYn;
                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;

                objOracleCommand.Parameters.Add("p_dbcursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                string VALUE = string.Empty;

                using (OracleConnection strConn = GetConnection())
                {
                    try
                    {
                        objOracleCommand.Connection = strConn;
                        strConn.Open();
                        trans = strConn.BeginTransaction();

                        dt.Load(objOracleCommand.ExecuteReader());
                        trans.Commit();
                        strConn.Close();

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            EmployeeDTO obj = new EmployeeDTO();
                            obj.SLNo = Convert.ToString(dt.Rows[i]["sl"]);
                            obj.GroupOfficeNameEng = Convert.ToString(dt.Rows[i]["GROUP_OFFICE_NAME_ENG"]);

                            obj.HeadOfficeId = Convert.ToString(dt.Rows[i]["head_office_id"]);
                            obj.HeadOfficeName = Convert.ToString(dt.Rows[i]["head_office_name"]);
                            obj.HeadOfficeAddress = Convert.ToString(dt.Rows[i]["head_office_address"]);

                            obj.BranchOfficeId = Convert.ToString(dt.Rows[i]["BRANCH_OFFICE_ID"]);
                            obj.EmployeeId = Convert.ToString(dt.Rows[i]["employee_id"]);
                            obj.EmployeeName = Convert.ToString(dt.Rows[i]["employee_name"]);
                            obj.EmployeeNameBangla = Convert.ToString(dt.Rows[i]["employee_name_bangla"]);

                            obj.CardNo = Convert.ToString(dt.Rows[i]["card_no"]);
                            obj.DesignationId = Convert.ToString(dt.Rows[i]["designation_id"]);
                            obj.DesignationName = Convert.ToString(dt.Rows[i]["designation_name"]);
                            obj.GradeNo = Convert.ToString(dt.Rows[i]["GRADE_NO"]);
                            obj.JoiningDate = Convert.ToString(dt.Rows[i]["JOINING_DATE"]);

                            obj.UnitId = Convert.ToString(dt.Rows[i]["unit_id"]);
                            obj.UnitName = Convert.ToString(dt.Rows[i]["unit_name"]);

                            obj.SectionId = Convert.ToString(dt.Rows[i]["section_id"]);
                            obj.SectionName = Convert.ToString(dt.Rows[i]["section_name"]);
                            obj.ActiveYn = Convert.ToString(dt.Rows[i]["active_yn"]);
                            objEmployeeBasics.Add(obj);
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
            return objEmployeeBasics;
        }
        public string EmployeeSkillSave(EmployeeDTO objEmployeeDTO)
        {
            string strMsg = "";

            //status = "NOK";

            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("sp_skill_worker_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            objOracleCommand.Parameters.Add("p_skill_id", OracleDbType.Decimal, ParameterDirection.Input).Value = objEmployeeDTO.SkillId;
            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;

            if (objEmployeeDTO.SkillLevelId != "")
            {
                objOracleCommand.Parameters.Add("P_SKILL_LEVEL_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SkillLevelId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SKILL_LEVEL_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            objOracleCommand.Parameters.Add("p_effect_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EffectiveDate;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("P_create_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CreateBy;

            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;
            //   objOracleCommand.Parameters.Add("P_STATUS", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    objOracleTransaction = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    objOracleTransaction.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
                    //status = objOracleCommand.Parameters["P_STATUS"].Value.ToString();
                }
                catch (Exception ex)
                {
                    objOracleTransaction.Rollback();
                    throw new Exception("Error : " + ex.Message);
                }
                finally
                {
                    strConn.Close();
                }
            }
            return strMsg;
        }
        public List<EmployeeDTO> GetEmployeeSkillBasicInfo(EmployeeDTO objEmployeeDTO)
        {
            List<EmployeeDTO> objEmployeeBasics = new List<EmployeeDTO>();

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            DataTable dt = new DataTable();
            try
            {

                OracleCommand objOracleCommand = new OracleCommand("SP_GET_SKILL_EMP_BASIC_INFO");
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                if (objEmployeeDTO.EmployeeId != "")
                {
                    objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;
                }
                else
                {
                    objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
                }

                if (objEmployeeDTO.CardNo != "")
                {
                    objOracleCommand.Parameters.Add("p_card_no", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CardNo;
                }
                else
                {
                    objOracleCommand.Parameters.Add("p_card_no", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
                }

                if (objEmployeeDTO.SkillLevelId != "")
                {
                    objOracleCommand.Parameters.Add("p_skill_level_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SkillLevelId;
                }
                else
                {
                    objOracleCommand.Parameters.Add("p_skill_level_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
                }
                if (objEmployeeDTO.EffectiveDate != "")
                {
                    objOracleCommand.Parameters.Add("p_effect_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EffectiveDate;
                }
                else
                {
                    objOracleCommand.Parameters.Add("p_effect_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
                }


                if (objEmployeeDTO.UnitId != "")
                {
                    objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UnitId;
                }
                else
                {
                    objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
                }
                if (objEmployeeDTO.SectionId != "")
                {
                    objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SectionId;
                }
                else
                {
                    objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
                }

                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;

                objOracleCommand.Parameters.Add("p_dbcursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                string VALUE = string.Empty;

                using (OracleConnection strConn = GetConnection())
                {
                    try
                    {
                        objOracleCommand.Connection = strConn;
                        strConn.Open();
                        trans = strConn.BeginTransaction();

                        dt.Load(objOracleCommand.ExecuteReader());
                        trans.Commit();
                        strConn.Close();

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            EmployeeDTO obj = new EmployeeDTO();
                            obj.SLNo = Convert.ToString(dt.Rows[i]["sl"]);
                            obj.GroupOfficeNameEng = Convert.ToString(dt.Rows[i]["GROUP_OFFICE_NAME_ENG"]);

                            obj.HeadOfficeId = Convert.ToString(dt.Rows[i]["head_office_id"]);
                            obj.HeadOfficeName = Convert.ToString(dt.Rows[i]["head_office_name"]);
                            obj.HeadOfficeAddress = Convert.ToString(dt.Rows[i]["head_office_address"]);

                            obj.BranchOfficeId = Convert.ToString(dt.Rows[i]["BRANCH_OFFICE_ID"]);
                            //obj.BranchOfficeName = Convert.ToString(dt.Rows[i]["EMPLOYEE_NAME"]);
                            //obj.BranchOfficeAddress = Convert.ToString(dt.Rows[i]["DESIGNATION_NAME"]);

                            obj.EmployeeId = Convert.ToString(dt.Rows[i]["employee_id"]);
                            obj.EmployeeName = Convert.ToString(dt.Rows[i]["employee_name"]);
                            obj.EmployeeNameBangla = Convert.ToString(dt.Rows[i]["employee_name_bangla"]);

                            obj.CardNo = Convert.ToString(dt.Rows[i]["card_no"]);
                            obj.DesignationId = Convert.ToString(dt.Rows[i]["designation_id"]);
                            obj.DesignationName = Convert.ToString(dt.Rows[i]["designation_name"]);
                            obj.GradeNo = Convert.ToString(dt.Rows[i]["GRADE_NO"]);

                            obj.UnitId = Convert.ToString(dt.Rows[i]["unit_id"]);
                            obj.UnitName = Convert.ToString(dt.Rows[i]["unit_name"]);

                            obj.SectionId = Convert.ToString(dt.Rows[i]["section_id"]);
                            obj.SectionName = Convert.ToString(dt.Rows[i]["section_name"]);

                            // obj.GrossSalary = Convert.ToString(dt.Rows[i]["gross_salary"]);
                            // obj.FirstSalary = Convert.ToString(dt.Rows[i]["first_salary"]);

                            obj.SkillLevelName = Convert.ToString(dt.Rows[i]["skill_level_name"]);
                            obj.SkillLevelId = Convert.ToString(dt.Rows[i]["skill_level_id"]);
                            obj.EffectiveDate = Convert.ToString(dt.Rows[i]["Skill_effect_date"]);

                            objEmployeeBasics.Add(obj);
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
            return objEmployeeBasics;
        }
        public DataTable GetEmployeeSkill(EmployeeDTO objEmployeeDTO)
        {
            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
                  "rownum sl, " +
                  "skill_ID, " +
                  "EMPLOYEE_ID, " +
                  "card_no, " +
                  "employee_name, " +
                  "designation_name, " +
                  "SKILL_LEVEL_ID, " +
                  "SKILL_LEVEL_NAME, " +
                  "EFFECT_DATE, " +
                  "UNIT_ID, " +
                  "SECTION_ID, " +
                  "HEAD_OFFICE_ID, " +
                  "BRANCH_OFFICE_ID " +
                  " FROM VW_EMPLOYEE_SKILL_MAPPING WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "' AND branch_office_id = '" + objEmployeeDTO.BranchOfficeId + "' " + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";

            sql = sql + "order by SL ";

            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataAdapter.Fill(dt);
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
            return dt;
        }
        public string DeleteEmployeeSkillRecord(EmployeeDTO objEmployeeDTO)
        {

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("PRO_DELETE_EMP_SKILL_RECORD");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objEmployeeDTO.SkillId != 0)
            {
                objOracleCommand.Parameters.Add("P_SKILL_ID", OracleDbType.Decimal, ParameterDirection.Input).Value = objEmployeeDTO.SkillId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SKILL_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;

            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 1000).Direction = ParameterDirection.Output;
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    trans = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    trans.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
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
            return strMsg;
        }

        public DataTable GetSpecialIncrement(EmployeeDTO objEmployeeDTO)
        {

            DataSet ds = null;
            DataTable myTable = new DataTable();
            try
            {
                OracleCommand objOracleCommand = new OracleCommand("SP_GET_SPECIAL_INCREMENT");
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                objOracleCommand.Parameters.Add("p_increment_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Year;
                objOracleCommand.Parameters.Add("p_increment_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Month;
                objOracleCommand.Parameters.Add("p_employee_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeTypeId;
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UnitId;
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SectionId;
                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
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
                        trans.Commit();
                        strConn.Close();
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return myTable;
        }
        public DataTable GetSpecialIncrementProposal(EmployeeDTO objEmployeeDTO)
        {

            DataSet ds = null;
            DataTable myTable = new DataTable();
            try
            {
                OracleCommand objOracleCommand = new OracleCommand("SP_GET_SPECIAL_INCR_PROPOSAL");
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                objOracleCommand.Parameters.Add("p_increment_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Year;
                objOracleCommand.Parameters.Add("p_increment_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Month;
                objOracleCommand.Parameters.Add("p_employee_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeTypeId;
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UnitId;
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SectionId;
                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
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
                        trans.Commit();
                        strConn.Close();
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return myTable;
        }
        public string SaveMeternityBenefitInfo(EmployeeDTO objEmployeeDTO)
        {

            string strMsg = "";
            OracleTransaction trans = null;
            OracleCommand objOracleCommand = new OracleCommand("SP_SAVE_IND_PAYMENT_INFO");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;
            objOracleCommand.Parameters.Add("P_CARD_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CardNo;
            objOracleCommand.Parameters.Add("P_SALARY_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Year;
            objOracleCommand.Parameters.Add("P_SALARY_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Month;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("p_logged_in_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    trans = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    trans.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
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
            return strMsg;
        }
        public DataTable GetEmployeeBasicInformation(EmployeeDTO objEmployeeDTO)
        {
            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
                   "rownum sl, " +
                   "CARD_NO, " +
                   "EMPLOYEE_ID, " +
                   "EMPLOYEE_NAME, " +
                   "DESIGNATION_NAME " +

                  "FROM VEW_SEARCH_WORKER_INFO WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "' AND branch_office_id = '" + objEmployeeDTO.BranchOfficeId + "' ";

            if (objEmployeeDTO.EmployeeId.Length > 0)
            {

                sql = sql + "and employee_id = '" + objEmployeeDTO.EmployeeId + "'";
            }
            if (objEmployeeDTO.CardNo.Length > 0)
            {
                sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
            }

            if (objEmployeeDTO.SectionId.Length > 0)
            {

                sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
            }
            if (objEmployeeDTO.UnitId.Length > 0)
            {

                sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
            }
            sql = sql + "order by SL ";
            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataAdapter.Fill(dt);
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
            return dt;
        }
        public DataTable GetMaternityBenefitedEmployee(EmployeeDTO objEmployeeDTO)
        {

            DataSet ds = null;
            DataTable myTable = new DataTable();
            try
            {
                OracleCommand objOracleCommand = new OracleCommand("SP_GET_MATERNITY_BENEFITED_EMP");
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;
                objOracleCommand.Parameters.Add("p_benefit_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Year;
                objOracleCommand.Parameters.Add("p_benefit_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Month;
                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
                objOracleCommand.Parameters.Add("p_logged_in_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UpdateBy;
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
                        trans.Commit();
                        strConn.Close();
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return myTable;
        }
        public DataTable GetLeaveEncashmentEmpInfo(EmployeeDTO objEmployeeDTO)
        {

            DataSet ds = null;
            DataTable myTable = new DataTable();
            try
            {
                string strMsg = "";
                OracleTransaction objOracleTransaction;
                OracleCommand objOracleCommand = new OracleCommand("SP_GET_LEAVEENCASH_WORKER_INFO");
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                objOracleCommand.Parameters.Add("p_leave_encashment_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.LeaveYear;
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UnitId;
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SectionId;
                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
                objOracleCommand.Parameters.Add("p_logged_in_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UpdateBy;

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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return myTable;
        }
        public DataTable GetLeaveEncashmentStaffEmpInfo(EmployeeDTO objEmployeeDTO)
        {

            DataSet ds = null;
            DataTable myTable = new DataTable();
            try
            {
                string strMsg = "";
                OracleTransaction objOracleTransaction;
                OracleCommand objOracleCommand = new OracleCommand("SP_GET_LEAVEENCASH_STAFF_INFO");
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                objOracleCommand.Parameters.Add("p_leave_encashment_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.LeaveYear;
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UnitId;
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SectionId;
                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
                objOracleCommand.Parameters.Add("p_logged_in_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UpdateBy;

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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return myTable;
        }

        public DataTable GetSelectedMonthlyIncrementList(EmployeeDTO objEmployeeDTO)
        {

            DataSet ds = null;
            DataTable myTable = new DataTable();
            try
            {
                string strMsg = "";
                OracleTransaction objOracleTransaction;
                OracleCommand objOracleCommand = new OracleCommand("sp_get_monthly_incr_sel_lst_w");
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                objOracleCommand.Parameters.Add("p_increment_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Year;
                objOracleCommand.Parameters.Add("p_increment_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Month;
                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
                objOracleCommand.Parameters.Add("p_unit_group_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UnitGroupId;
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UnitId;
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SectionId;

                objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UpdateBy;

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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return myTable;
        }

        public DataTable GetMonthlyEligibleIncrementListWorker(EmployeeDTO objEmployeeDTO)
        {

            DataSet ds = null;
            DataTable myTable = new DataTable();
            try
            {
                string strMsg = "";
                OracleTransaction objOracleTransaction;
                OracleCommand objOracleCommand = new OracleCommand("sp_get_monthly_elig_incr_lst_w");
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                objOracleCommand.Parameters.Add("p_increment_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Year;
                objOracleCommand.Parameters.Add("p_increment_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Month;
                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
                objOracleCommand.Parameters.Add("p_unit_group_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UnitGroupId;
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UnitId;
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SectionId;

                objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UpdateBy;

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
            }
            catch (Exception ex)

            {
                trans.Rollback();
                throw ex;
            }
            return myTable;
        }
        public string SaveEnvelope(EmployeeDTO objEmployeeDTO)
        {
            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("sp_save_envelope");
            objOracleCommand.CommandType = CommandType.StoredProcedure;
            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;
            if (objEmployeeDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("P_SECTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SECTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;

            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    trans = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    trans.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
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
            return strMsg;
        }
        public string DeleteEnvelope(EmployeeDTO objEmployeeDTO)
        {
            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("sp_delete_envelope");

            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objEmployeeDTO.UnitId != "")
            {
                objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeDTO.SectionId != "")
            {
                objOracleCommand.Parameters.Add("P_SECTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SECTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;


            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    trans = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    trans.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
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

            return strMsg;
        }
        public EventPermissionDTO GetEventPermission(EventPermissionDTO objEventPermissionDTO)
        {
            EventPermissionDTO objEmployeeEventPermission = new EventPermissionDTO();

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            DataTable dt = new DataTable();

            int count = 0;

            try
            {
                OracleCommand objOracleCommand = new OracleCommand("SP_GET_EVENT_PERMISSION");
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                if (objEventPermissionDTO.UpdateBy != "")
                {
                    objOracleCommand.Parameters.Add("p_loged_in_employee", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEventPermissionDTO.UpdateBy;
                }
                else
                {
                    objOracleCommand.Parameters.Add("p_loged_in_employee", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
                }
                objOracleCommand.Parameters.Add("p_ui_code", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEventPermissionDTO.UICode;
                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEventPermissionDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEventPermissionDTO.BranchOfficeId;

                objOracleCommand.Parameters.Add("p_dbcursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                string VALUE = string.Empty;
                using (OracleConnection strConn = GetConnection())
                {
                    try
                    {
                        objOracleCommand.Connection = strConn;
                        strConn.Open();
                        trans = strConn.BeginTransaction();
                        dt.Load(objOracleCommand.ExecuteReader());
                        trans.Commit();
                        strConn.Close();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            count = count + 1;

                            objEmployeeEventPermission.EmployeeId = Convert.ToString(dt.Rows[i]["employee_id"]);
                            objEmployeeEventPermission.MenuCode = Convert.ToString(dt.Rows[i]["menu_code"]);
                            objEmployeeEventPermission.MenuName = Convert.ToString(dt.Rows[i]["menu_name"]);
                            objEmployeeEventPermission.DisableSave = Convert.ToString(dt.Rows[i]["disable_save"]);
                            objEmployeeEventPermission.DisableAdd = Convert.ToString(dt.Rows[i]["disable_add"]);
                            objEmployeeEventPermission.DisableProcess = Convert.ToString(dt.Rows[i]["disable_process"]);
                            objEmployeeEventPermission.DisableSearch = Convert.ToString(dt.Rows[i]["disable_search"]);
                            objEmployeeEventPermission.DisableAtten = Convert.ToString(dt.Rows[i]["disable_atten"]);
                            objEmployeeEventPermission.DisaleDelete = Convert.ToString(dt.Rows[i]["disable_delete"]);

                            objEmployeeEventPermission.DisableSaveEventId = Convert.ToString(dt.Rows[i]["disable_save_event_id"]);
                            objEmployeeEventPermission.DisableAddEventId = Convert.ToString(dt.Rows[i]["disable_add_event_id"]);
                            objEmployeeEventPermission.DisableProcessEventId = Convert.ToString(dt.Rows[i]["disable_process_event_id"]);
                            objEmployeeEventPermission.DisableSearchEventId = Convert.ToString(dt.Rows[i]["disable_search_event_id"]);
                            objEmployeeEventPermission.DisableAttenEventId = Convert.ToString(dt.Rows[i]["disable_atten_event_id"]);
                            objEmployeeEventPermission.DisaleDeleteEventId = Convert.ToString(dt.Rows[i]["disable_delete_event_id"]);
                            
                            objEmployeeEventPermission.HeadOfficeId = Convert.ToString(dt.Rows[i]["head_office_id"]);
                            objEmployeeEventPermission.BranchOfficeId = Convert.ToString(dt.Rows[i]["BRANCH_OFFICE_ID"]);
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
            if (count == 0)
                return null;
            else
            return objEmployeeEventPermission;
        }

        public EventPermissionDTO GetEventPermissionNew(EventPermissionDTO objEventPermissionDTO)
        {
            EventPermissionDTO objEmployeeEventPermission = new EventPermissionDTO();

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            DataTable dt = new DataTable();

            int count = 0;

            try
            {
                OracleCommand objOracleCommand = new OracleCommand("SP_GET_EVENT_PERMISSION_NEW");
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                if (objEventPermissionDTO.UpdateBy != "")
                {
                    objOracleCommand.Parameters.Add("p_loged_in_employee", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEventPermissionDTO.UpdateBy;
                }
                else
                {
                    objOracleCommand.Parameters.Add("p_loged_in_employee", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
                }
                objOracleCommand.Parameters.Add("p_ui_name", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEventPermissionDTO.UIName;
                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEventPermissionDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEventPermissionDTO.BranchOfficeId;

                objOracleCommand.Parameters.Add("p_dbcursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                string VALUE = string.Empty;
                using (OracleConnection strConn = GetConnection())
                {
                    try
                    {
                        objOracleCommand.Connection = strConn;
                        strConn.Open();
                        trans = strConn.BeginTransaction();
                        dt.Load(objOracleCommand.ExecuteReader());
                        trans.Commit();
                        strConn.Close();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            count = count + 1;

                            objEmployeeEventPermission.EmployeeId = Convert.ToString(dt.Rows[i]["employee_id"]);
                            objEmployeeEventPermission.UICode = Convert.ToString(dt.Rows[i]["ui_code"]);
                            objEmployeeEventPermission.UIName = Convert.ToString(dt.Rows[i]["ui_name"]);

                            //objEmployeeEventPermission.DisableSave = Convert.ToString(dt.Rows[i]["disable_save"]);
                            //objEmployeeEventPermission.DisableAdd = Convert.ToString(dt.Rows[i]["disable_add"]);
                            //objEmployeeEventPermission.DisableProcess = Convert.ToString(dt.Rows[i]["disable_process"]);
                            //objEmployeeEventPermission.DisableSearch = Convert.ToString(dt.Rows[i]["disable_search"]);
                            //objEmployeeEventPermission.DisableAtten = Convert.ToString(dt.Rows[i]["disable_atten"]);
                            //objEmployeeEventPermission.DisaleDelete = Convert.ToString(dt.Rows[i]["disable_delete"]);

                            objEmployeeEventPermission.DisableSaveEventId = Convert.ToString(dt.Rows[i]["disable_save_event_id"]);
                            objEmployeeEventPermission.DisableAddEventId = Convert.ToString(dt.Rows[i]["disable_add_event_id"]);
                            objEmployeeEventPermission.DisableProcessEventId = Convert.ToString(dt.Rows[i]["disable_process_event_id"]);
                            objEmployeeEventPermission.DisableSearchEventId = Convert.ToString(dt.Rows[i]["disable_search_event_id"]);
                            objEmployeeEventPermission.DisableAttenEventId = Convert.ToString(dt.Rows[i]["disable_atten_event_id"]);
                            objEmployeeEventPermission.DisaleDeleteEventId = Convert.ToString(dt.Rows[i]["disable_delete_event_id"]);

                            objEmployeeEventPermission.HeadOfficeId = Convert.ToString(dt.Rows[i]["head_office_id"]);
                            objEmployeeEventPermission.BranchOfficeId = Convert.ToString(dt.Rows[i]["BRANCH_OFFICE_ID"]);
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
            if (count == 0)
                return null;
            else
                return objEmployeeEventPermission;
        }


        public DataTable GetEmpConfirmationWithIncrement(EmployeeDTO objEmployeeDTO)
        {

            DataSet ds = null;
            DataTable myTable = new DataTable();
            try
            {
                OracleCommand objOracleCommand = new OracleCommand("sp_get_confirmed_Confirmation");
                objOracleCommand.CommandType = CommandType.StoredProcedure;
                objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;
                objOracleCommand.Parameters.Add("p_increment_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Year;
                objOracleCommand.Parameters.Add("p_increment_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Month;
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UnitId;
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SectionId;
                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
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
                        trans.Commit();
                        strConn.Close();
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return myTable;
        }
        public DataTable GetEmployeeBasicInformatiom(EmployeeDTO objEmployeeDTO)
        {

            DataSet ds = null;
            DataTable myTable = new DataTable();
            try
            {
                OracleCommand objOracleCommand = new OracleCommand("sp_get_emp_confirmation_info");
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;
                objOracleCommand.Parameters.Add("p_card_no", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CardNo;
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UnitId;
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SectionId;
                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
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
                        trans.Commit();
                        strConn.Close();
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return myTable;
        }
        public string SaveAttendanceBonus(EmployeeDTO objEmployeeDTO)
        {
            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("sp_save_attendance_bonus");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objEmployeeDTO.DesignationId != "")
            {
                objOracleCommand.Parameters.Add("p_designation_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.DesignationId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_designation_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            objOracleCommand.Parameters.Add("p_working_day", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.WorkingDay;
            objOracleCommand.Parameters.Add("p_attendance_bonus", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.AttendanceBonus;

            objOracleCommand.Parameters.Add("P_CREATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;

            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    trans = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    trans.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
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
            return strMsg;
        }
        public DataTable GetAttendanceBonus(EmployeeDTO objEmployeeDTO)
        {
            DataTable myTable = new DataTable();
            try
            {
                OracleCommand objOracleCommand = new OracleCommand("SP_GET_ATTENDANCE_BONUS");
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return myTable;
        }
        public string SaveEmployeeInCache(EmployeeDTO objEmployeeDTO)
        {
            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("pro_employee_cache_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objEmployeeDTO.CacheId != "")
            {
                objOracleCommand.Parameters.Add("p_cache_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CacheId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_cache_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            
            if (objEmployeeDTO.UnitId.Length > 0)
            {
                objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UnitId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.SectionId.Length > 0)
            {
                objOracleCommand.Parameters.Add("P_SECTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SectionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_SECTION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeDTO.CardNo != "")
            {
                objOracleCommand.Parameters.Add("P_CARD_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CardNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_CARD_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.PunchCode != "")
            {
                objOracleCommand.Parameters.Add("P_PUNCH_CODE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.PunchCode;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_PUNCH_CODE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.TitleId.Length > 0)
            {
                objOracleCommand.Parameters.Add("P_TITLE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.TitleId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_TITLE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.EmployeeName != "")
            {
                objOracleCommand.Parameters.Add("P_EMPLOYEE_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeName;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_EMPLOYEE_NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.EmployeeNameBangla != "")
            {
                objOracleCommand.Parameters.Add("P_EMPLOYEE_NAME_BANGLA", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeNameBangla;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_EMPLOYEE_NAME_BANGLA", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            
            if (objEmployeeDTO.GenderId.Length > 0)
            {
                objOracleCommand.Parameters.Add("P_GENDER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.GenderId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_GENDER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.JoiningDate.Length > 6)
            {
                objOracleCommand.Parameters.Add("P_JOINING_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.JoiningDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_JOINING_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.EmployeeTypeId.Length > 0)
            {
                objOracleCommand.Parameters.Add("P_EMPLOYEE_TYPE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeTypeId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_EMPLOYEE_TYPE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.NIDNo != "")
            {
                objOracleCommand.Parameters.Add("p_nid_no", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.NIDNo;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_nid_no", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            
            if (objEmployeeDTO.DesignationId.Length > 0)
            {
                objOracleCommand.Parameters.Add("P_DESIGNATION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.DesignationId;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_DESIGNATION_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            
            if (objEmployeeDTO.ReligionId.Length > 0)
            {
                objOracleCommand.Parameters.Add("p_religion_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.ReligionId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_religion_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeDTO.EmployeeActiveYn != "")
            {
                objOracleCommand.Parameters.Add("P_ACTIVE_YN", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeActiveYn;
            }
            else
            {
                objOracleCommand.Parameters.Add("P_ACTIVE_YN", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
            
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("P_CREATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CreateBy;
            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    trans = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    trans.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();

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
            return strMsg;
        }

        //
        public string ApproveEmployment(string cacheId, string headOfficeId, string branchOfficeId, string createBy)
        {
            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("sp_approve_employee_basic");
            objOracleCommand.CommandType = CommandType.StoredProcedure;
            objOracleCommand.Parameters.Add("p_cache_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = cacheId;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = headOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = branchOfficeId;
            objOracleCommand.Parameters.Add("P_CREATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = createBy;
            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    trans = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    trans.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();

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
            return strMsg;
        }
        public DataTable GetEmployeeCacseInformation(EmployeeDTO objEmployeeDTO)
        {
            DataSet ds = null;
            DataTable myTable = new DataTable();
            try
            {
                OracleCommand objOracleCommand = new OracleCommand("SP_GET_EMPLOYEE_CACHE");
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;
                objOracleCommand.Parameters.Add("p_card_no", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CardNo;
                objOracleCommand.Parameters.Add("p_employee_name", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeName;
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UnitId;
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SectionId;
                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
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
                        trans.Commit();
                        strConn.Close();
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return myTable;
        }
        public string UpdateEmployeeCache(EmployeeDTO objEmployeeDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("sp_update_employee_cache");
            objOracleCommand.CommandType = CommandType.StoredProcedure;
            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;
            objOracleCommand.Parameters.Add("P_recognize_yn", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.RecognizeYn;
                        
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("P_create_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CreateBy;

            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    objOracleTransaction = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    objOracleTransaction.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
                }
                catch (Exception ex)
                {
                    objOracleTransaction.Rollback();
                    throw new Exception("Error : " + ex.Message);
                }
                finally
                {
                    strConn.Close();
                }
            }
            return strMsg;
        }

        //CountFaceId(string branchOfficeId)
        public string DeleteFaceId(string branchOfficeId)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("sp_delete_faseid_user");
            objOracleCommand.CommandType = CommandType.StoredProcedure;
            //objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = branchOfficeId;
            //objOracleCommand.Parameters.Add("p_create_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CreateBy;

            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    objOracleTransaction = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    objOracleTransaction.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
                }
                catch (Exception ex)
                {
                    objOracleTransaction.Rollback();
                    throw new Exception("Error : " + ex.Message);
                }
                finally
                {
                    strConn.Close();
                }
            }
            return strMsg;
        }

        public string SaveFaceId(EmployeeDTO objEmployeeDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("sp_save_faseid_user");
            objOracleCommand.CommandType = CommandType.StoredProcedure;
            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("p_create_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CreateBy;

            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    objOracleTransaction = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    objOracleTransaction.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
                }
                catch (Exception ex)
                {
                    objOracleTransaction.Rollback();
                    throw new Exception("Error : " + ex.Message);
                }
                finally
                {
                    strConn.Close();
                }
            }
            return strMsg;
        }

        
        public string CountFaceId(string branchOfficeId)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("sp_count_faseid_user");
            objOracleCommand.CommandType = CommandType.StoredProcedure;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = branchOfficeId;
            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    objOracleTransaction = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    objOracleTransaction.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
                }
                catch (Exception ex)
                {
                    objOracleTransaction.Rollback();
                    throw new Exception("Error : " + ex.Message);
                }
                finally
                {
                    strConn.Close();
                }
            }
            return strMsg;
        }


        public string SaveResignEmployee(EmployeeDTO objEmployeeDTO)
        {
            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("sp_save_resign_employee");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objEmployeeDTO.EmployeeId != "")
            {
                objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
          
            if (objEmployeeDTO.ResignDate.Length > 6)
            {
                objOracleCommand.Parameters.Add("p_resign_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.ResignDate;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_resign_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objEmployeeDTO.ResignCasuse.Length > 6)
            {
                objOracleCommand.Parameters.Add("p_resign_cause", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.ResignCasuse;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_resign_cause", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("P_CREATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CreateBy;
            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    trans = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    trans.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();

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
            return strMsg;
        }
        public DataTable GetEmployeeForResign(EmployeeDTO objEmployeeDTO)
        {

            DataSet ds = null;
            DataTable myTable = new DataTable();
            try
            {
                OracleCommand objOracleCommand = new OracleCommand("sp_get_employee_for_resign");
                objOracleCommand.CommandType = CommandType.StoredProcedure;
                objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;
                objOracleCommand.Parameters.Add("p_card_no", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CardNo;

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UnitId;
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SectionId;

                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return myTable;
        }
        public DataTable GetResignEmployee(EmployeeDTO objEmployeeDTO)
        {

            DataSet ds = null;
            DataTable myTable = new DataTable();
            try
            {
                OracleCommand objOracleCommand = new OracleCommand("sp_get_resign_employee");
                objOracleCommand.CommandType = CommandType.StoredProcedure;
                objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;
                objOracleCommand.Parameters.Add("p_card_no", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CardNo;
                objOracleCommand.Parameters.Add("p_from_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.FromDate;
                objOracleCommand.Parameters.Add("p_to_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.ToDate;

                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return myTable;
        }
        public string SaveFoodDeduction(EmployeeDTO objEmployeeDTO)
        {
            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("sp_save_food_deduction");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;
            objOracleCommand.Parameters.Add("P_SALARY_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Year;
            objOracleCommand.Parameters.Add("P_SALARY_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Month;

            if (objEmployeeDTO.InsideDay != "")
            {
                objOracleCommand.Parameters.Add("p_inside_day", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.InsideDay;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_inside_day", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objEmployeeDTO.OutSideDay != "")
            {
                objOracleCommand.Parameters.Add("p_outside_day", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.OutSideDay;
            }
            else
            {
                objOracleCommand.Parameters.Add("p_outside_day", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("P_CREATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CreateBy;
            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    trans = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    trans.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();

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
            return strMsg;
        }
        public DataTable GetFoodDeduction(EmployeeDTO objEmployeeDTO)
        {

            DataSet ds = null;
            DataTable myTable = new DataTable();
            try
            {
                OracleCommand objOracleCommand = new OracleCommand("sp_get_food_deduction");
                objOracleCommand.CommandType = CommandType.StoredProcedure;
                objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;
                objOracleCommand.Parameters.Add("p_card_no", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CardNo;

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UnitId;
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SectionId;
                objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Year;
                objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Month;

                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return myTable;
        }
        public DataTable GetEmployeeForFoodDetuction(EmployeeDTO objEmployeeDTO)
        {

            DataSet ds = null;
            DataTable myTable = new DataTable();
            try
            {
                OracleCommand objOracleCommand = new OracleCommand("sp_get_emp_for_food_deduction");
                objOracleCommand.CommandType = CommandType.StoredProcedure;
                objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;
                objOracleCommand.Parameters.Add("p_card_no", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CardNo;

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UnitId;
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SectionId;

                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return myTable;
        }
        //OLD
        public string SaveInactiveEmpAfterMonthlySalary(EmployeeDTO objEmployeeDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("sp_inactive_after_monthly_sal");
            objOracleCommand.CommandType = CommandType.StoredProcedure;
            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;
            objOracleCommand.Parameters.Add("p_inactive_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Year;
            objOracleCommand.Parameters.Add("p_inactive_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Month;
            objOracleCommand.Parameters.Add("P_STATUS_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.StatusId;
            objOracleCommand.Parameters.Add("p_inactive_reason", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.InactiveReason;
            objOracleCommand.Parameters.Add("p_resign_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.ResignDate;

            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("P_create_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CreateBy;

            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    objOracleTransaction = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    objOracleTransaction.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
                }
                catch (Exception ex)
                {
                    objOracleTransaction.Rollback();
                    throw new Exception("Error : " + ex.Message);
                }
                finally
                {
                    strConn.Close();
                }
            }
            return strMsg;
        }

        //NEW: 24.04.2021
        public string ProcessMonthlyInactivation(EmployeeDTO objEmployeeDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("sp_process_month_inactivation");
            objOracleCommand.CommandType = CommandType.StoredProcedure;
            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;
            objOracleCommand.Parameters.Add("p_inactive_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Year;
            objOracleCommand.Parameters.Add("p_inactive_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Month;
            objOracleCommand.Parameters.Add("P_STATUS_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.StatusId;
            objOracleCommand.Parameters.Add("p_inactive_reason", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.InactiveReason;
            objOracleCommand.Parameters.Add("p_resign_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.ResignDate;

            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("P_create_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CreateBy;

            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    objOracleTransaction = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    objOracleTransaction.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
                }
                catch (Exception ex)
                {
                    objOracleTransaction.Rollback();
                    throw new Exception("Error : " + ex.Message);
                }
                finally
                {
                    strConn.Close();
                }
            }
            return strMsg;
        }

        public string ResetMonthlyInactiveProcess(EmployeeDTO objEmployeeDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("reset_monthly_inactive_process");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;
            objOracleCommand.Parameters.Add("p_inactive_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Year;
            objOracleCommand.Parameters.Add("p_inactive_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Month;
            objOracleCommand.Parameters.Add("P_STATUS_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.StatusId;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("P_create_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CreateBy;

            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    objOracleTransaction = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    objOracleTransaction.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
                }
                catch (Exception ex)
                {
                    objOracleTransaction.Rollback();
                    throw new Exception("Error : " + ex.Message);
                }
                finally
                {
                    strConn.Close();
                }
            }
            return strMsg;
        }


        public DataTable GetEmployeeForInActive(EmployeeDTO objEmployeeDTO)
        {

            DataSet ds = null;
            DataTable myTable = new DataTable();
            try
            {
                OracleCommand objOracleCommand = new OracleCommand("SP_GET_MONTHLY_INACTIVE_EMP");
                objOracleCommand.CommandType = CommandType.StoredProcedure;
                objOracleCommand.Parameters.Add("p_card_no", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CardNo;
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UnitId;
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SectionId;
                objOracleCommand.Parameters.Add("p_inactive_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Year;
                objOracleCommand.Parameters.Add("p_inactive_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Month;
                objOracleCommand.Parameters.Add("p_ststus_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.StatusId;
                objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CreateBy;


                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return myTable;
        }
        public DataTable GetSalaryUnitSection(EmployeeDTO objEmployeeDTO)
        {
            DataTable myTable = new DataTable();
            try
            {
                OracleCommand objOracleCommand = new OracleCommand("SP_GET_SAL_UNIT_SECTION_TOP_G");
                objOracleCommand.CommandType = CommandType.StoredProcedure;
                objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Year;
                objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Month;

                objOracleCommand.Parameters.Add("P_PAYMENT_TYPE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.PaymentTypeId;
                objOracleCommand.Parameters.Add("p_eid_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EidTypeId;

                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return myTable;
        }
        public DataTable GetSalaryUnitSectionBottomGrid(EmployeeDTO objEmployeeDTO)
        {
            DataTable myTable = new DataTable();
            try
            {
                OracleCommand objOracleCommand = new OracleCommand("SP_GET_SALARY_UNIT_SECTION");
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Year;
                objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Month;

                objOracleCommand.Parameters.Add("P_PAYMENT_TYPE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.PaymentTypeId;
                objOracleCommand.Parameters.Add("p_eid_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EidTypeId;
                
                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return myTable;
        }

        public string IsPhaseWiseSalaryLock(EmployeeDTO objEmployeeDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("SP_IS_PHASE_WISE_PAYMENT_LOCK");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Year;
            objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Month;
            objOracleCommand.Parameters.Add("P_PAYMENT_PHASE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.PhaseId;


            objOracleCommand.Parameters.Add("p_payment_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.PaymentTypeId;
            objOracleCommand.Parameters.Add("p_eid_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EidTypeId;

            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;

            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    objOracleTransaction = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    objOracleTransaction.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
                }
                catch (Exception ex)
                {
                    objOracleTransaction.Rollback();
                    throw new Exception("Error : " + ex.Message);
                }
                finally
                {
                    strConn.Close();
                }
            }
            return strMsg;
        }


        public string CreatePhaseIdInMonthlySalary(EmployeeDTO objEmployeeDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("sp_create_phase_wise_salary");
            objOracleCommand.CommandType = CommandType.StoredProcedure;
            objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UnitId;
            objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SectionId;
            objOracleCommand.Parameters.Add("p_payment_phase_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.PhaseId;
            objOracleCommand.Parameters.Add("p_payment_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.PaymentTypeId;
            objOracleCommand.Parameters.Add("p_eid_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EidTypeId;
            
            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Year;
            objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Month;

            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("P_create_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CreateBy;

            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    objOracleTransaction = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    objOracleTransaction.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
                }
                catch (Exception ex)
                {
                    objOracleTransaction.Rollback();
                    throw new Exception("Error : " + ex.Message);
                }
                finally
                {
                    strConn.Close();
                }
            }
            return strMsg;
        }
        public string UpdatePhaseIdInMonthlySalary(EmployeeDTO objEmployeeDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            //new
            OracleCommand objOracleCommand = new OracleCommand("sp_rem_mon_sal_pay_phase_us");
            //old
            //OracleCommand objOracleCommand = new OracleCommand("sp_update_phase_monthly_salary");
            objOracleCommand.CommandType = CommandType.StoredProcedure;
            objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UnitId;
            objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SectionId;
            objOracleCommand.Parameters.Add("p_payment_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.PaymentTypeId;

            objOracleCommand.Parameters.Add("p_eid_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EidTypeId;

            objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Year;
            objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Month;

            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("P_create_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CreateBy;

            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    objOracleTransaction = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    objOracleTransaction.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
                }
                catch (Exception ex)
                {
                    objOracleTransaction.Rollback();
                    throw new Exception("Error : " + ex.Message);
                }
                finally
                {
                    strConn.Close();
                }
            }
            return strMsg;
        }
        public DataTable GetEmployeeEarnLeave(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            if (objEmployeeDTO.HeadOfficeId == "441" && objEmployeeDTO.BranchOfficeId == "105" && (objEmployeeDTO.UnitId == "91" || objEmployeeDTO.UnitId == "") && objEmployeeDTO.UpdateBy == "105")
            {

                sql = "SELECT " +
                 "rownum sl, " +
                 "CARD_NO, " +

                 "EMPLOYEE_NAME, " +
                 "DESIGNATION_NAME, " +
                 "EMPLOYEE_ID, " +
                 "TO_CHAR(LEAVE_START_DATE, 'dd/mm/yyyy')LEAVE_START_DATE, " +
                 "TO_CHAR(LEAVE_END_DATE, 'dd/mm/yyyy')LEAVE_END_DATE, " +
                 "TOTAL_LEAVE, " +
                 "APPROVE_BY_NAME, " +
                 "leave_type_name " +

                "FROM VEW_SEARCH_EARN_LEAVE WHERE head_office_id = '" + 1 + "' AND branch_office_id = '" + objEmployeeDTO.BranchOfficeId + "' " +
                " AND leave_year = '" + objEmployeeDTO.Year + "'  ";



                sql = sql + "order by SL ";
            }
            else
            {

                sql = "SELECT " +
                  "rownum sl, " +
                  "CARD_NO, " +

                  "EMPLOYEE_NAME, " +
                  "DESIGNATION_NAME, " +
                  "EMPLOYEE_ID, " +
                  "TO_CHAR(LEAVE_START_DATE, 'dd/mm/yyyy')LEAVE_START_DATE, " +
                  "TO_CHAR(LEAVE_END_DATE, 'dd/mm/yyyy')LEAVE_END_DATE, " +
                  "TOTAL_LEAVE, " +
                  "APPROVE_BY_NAME, " +
                  "leave_type_name " +

                 "FROM VEW_SEARCH_EARN_LEAVE WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "' AND branch_office_id = '" + objEmployeeDTO.BranchOfficeId + "' " +
                 " AND leave_year = '" + objEmployeeDTO.Year + "'  ";


                if (objEmployeeDTO.SectionId.Length > 0)
                {

                    sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
                }

                if (objEmployeeDTO.UnitId.Length > 0)
                {

                    sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
                }

                if (objEmployeeDTO.CardNo.Length > 0)
                {

                    sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
                }

                if (objEmployeeDTO.EmpId.Length > 0)
                {

                    sql = sql + "and employee_id = '" + objEmployeeDTO.EmpId + "'";
                }

                sql = sql + "order by SL ";
            }
            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataAdapter.Fill(dt);

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
            return dt;
        }

        public DataTable GetConsumedEarnLeave(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            if (objEmployeeDTO.HeadOfficeId == "441" && objEmployeeDTO.BranchOfficeId == "105" && (objEmployeeDTO.UnitId == "91" || objEmployeeDTO.UnitId == "") && objEmployeeDTO.UpdateBy == "105")
            {

                sql = "SELECT " +
                 "rownum sl, " +
                 "CARD_NO, " +

                 "EMPLOYEE_NAME, " +
                 "DESIGNATION_NAME, " +
                 "EMPLOYEE_ID, " +
                 "TO_CHAR(LEAVE_START_DATE, 'dd/mm/yyyy')LEAVE_START_DATE, " +
                 "TO_CHAR(LEAVE_END_DATE, 'dd/mm/yyyy')LEAVE_END_DATE, " +
                 "TOTAL_LEAVE, " +
                 "APPROVE_BY_NAME, " +
                 "leave_type_name " +

                "FROM VEW_SEARCH_EARN_LEAVE WHERE head_office_id = '" + 1 + "' AND branch_office_id = '" + objEmployeeDTO.BranchOfficeId + "' " +
                " AND consume_year = '" + objEmployeeDTO.Year + "'  ";



                sql = sql + "order by SL ";
            }
            else
            {

                sql = "SELECT " +
                  "rownum sl, " +
                  "CARD_NO, " +

                  "EMPLOYEE_NAME, " +
                  "DESIGNATION_NAME, " +
                  "EMPLOYEE_ID, " +
                  "TO_CHAR(LEAVE_START_DATE, 'dd/mm/yyyy')LEAVE_START_DATE, " +
                  "TO_CHAR(LEAVE_END_DATE, 'dd/mm/yyyy')LEAVE_END_DATE, " +
                  "TOTAL_LEAVE, " +
                  "APPROVE_BY_NAME, " +
                  "leave_type_name " +

                 "FROM VEW_SEARCH_EARN_LEAVE WHERE head_office_id = '" + objEmployeeDTO.HeadOfficeId + "' AND branch_office_id = '" + objEmployeeDTO.BranchOfficeId + "' " +
                 " AND consume_year = '" + objEmployeeDTO.Year + "'  ";


                if (objEmployeeDTO.SectionId.Length > 0)
                {

                    sql = sql + "and section_id = '" + objEmployeeDTO.SectionId + "'";
                }

                if (objEmployeeDTO.UnitId.Length > 0)
                {

                    sql = sql + "and unit_id = '" + objEmployeeDTO.UnitId + "'";
                }

                if (objEmployeeDTO.CardNo.Length > 0)
                {

                    sql = sql + "and card_no = '" + objEmployeeDTO.CardNo + "'";
                }

                if (objEmployeeDTO.EmpId.Length > 0)
                {

                    sql = sql + "and employee_id = '" + objEmployeeDTO.EmpId + "'";
                }

                sql = sql + "order by SL ";
            }
            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataAdapter.Fill(dt);

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
            return dt;
        }
        public DataTable GetSuspensionEmployee(EmployeeDTO objEmployeeDTO)
        {
            DataTable myTable = new DataTable();
            try
            {
                OracleCommand objOracleCommand = new OracleCommand("SP_GET_SUSPENSION_EMPLOYEE");
                objOracleCommand.CommandType = CommandType.StoredProcedure;
                objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;
                objOracleCommand.Parameters.Add("p_card_no", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CardNo;
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UnitId;
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SectionId;
                objOracleCommand.Parameters.Add("P_start_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.StartDate;
                objOracleCommand.Parameters.Add("P_end_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EndDate;
                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
                //  objOracleCommand.Parameters.Add("p_logged_in_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = Convert.ToInt32(objReportDTO.cr);
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return myTable;
        }
        public string SavePaymentHoldEmployee(EmployeeDTO objEmployeeDTO)
        {
            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("sp_payment_hold_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;
            
            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;
            objOracleCommand.Parameters.Add("P_PAYMENT_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Year;
            objOracleCommand.Parameters.Add("P_PAYMENT_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Month;
            objOracleCommand.Parameters.Add("p_payment_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.PaymentTypeId;
            objOracleCommand.Parameters.Add("p_eid_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EidTypeId;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("P_CREATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CreateBy;
            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    trans = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    trans.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();

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
            return strMsg;
        }
        public DataTable GetPaymentHoldEmployee(EmployeeDTO objEmployeeDTO)
        {

            DataSet ds = null;
            DataTable myTable = new DataTable();
            try
            {
                OracleCommand objOracleCommand = new OracleCommand("sp_get_payment_hold_emp");
                objOracleCommand.CommandType = CommandType.StoredProcedure;
                                
                objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;
                objOracleCommand.Parameters.Add("p_card_no", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CardNo;
                                
                objOracleCommand.Parameters.Add("p_payment_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Year;
                objOracleCommand.Parameters.Add("p_payment_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Month;

                objOracleCommand.Parameters.Add("p_payment_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.PaymentTypeId;
                objOracleCommand.Parameters.Add("p_eid_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EidTypeId;

                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return myTable;
        }
        public DataTable GetEmployeeForPaymentHold(EmployeeDTO objEmployeeDTO)
        {

            DataSet ds = null;
            DataTable myTable = new DataTable();
            try
            {
                OracleCommand objOracleCommand = new OracleCommand("sp_get_emp_for_payment_hold");
                objOracleCommand.CommandType = CommandType.StoredProcedure;
                                
                objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;
                objOracleCommand.Parameters.Add("p_card_no", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CardNo;

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UnitId;
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SectionId;

                objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Year;
                objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Month;
                objOracleCommand.Parameters.Add("p_payment_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.PaymentTypeId;
                objOracleCommand.Parameters.Add("p_eid_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EidTypeId;
                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return myTable;
        }
        public string MakeHoldPayment(EmployeeDTO objEmployeeDTO)
        {
            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("sp_make_hold_payment");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("P_HOLD_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HoldId;
            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;
            objOracleCommand.Parameters.Add("P_PAYMENT_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Year;
            objOracleCommand.Parameters.Add("P_PAYMENT_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Month;
            objOracleCommand.Parameters.Add("p_payment_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.PaymentTypeId;
            objOracleCommand.Parameters.Add("p_eid_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EidTypeId;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("P_CREATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CreateBy;
            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    trans = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    trans.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();

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
            return strMsg;
        }

        public string DeleteEmpFromPaymentHold(EmployeeDTO objEmployeeDTO)
        {
            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("SP_DELET_EMP_FROM_PAYMENT_HOLD");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("P_HOLD_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HoldId;
            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;
            objOracleCommand.Parameters.Add("P_PAYMENT_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Year;
            objOracleCommand.Parameters.Add("P_PAYMENT_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Month;
            objOracleCommand.Parameters.Add("p_payment_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.PaymentTypeId;
            objOracleCommand.Parameters.Add("p_eid_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EidTypeId;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("P_CREATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CreateBy;
            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    trans = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    trans.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();

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
            return strMsg;
        }
        public string HoldPayment(EmployeeDTO objEmployeeDTO)
        {
            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("sp_hold_payment");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("P_HOLD_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HoldId;
            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;
            objOracleCommand.Parameters.Add("P_PAYMENT_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Year;
            objOracleCommand.Parameters.Add("P_PAYMENT_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Month;
            objOracleCommand.Parameters.Add("p_payment_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.PaymentTypeId;
            objOracleCommand.Parameters.Add("p_eid_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EidTypeId;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("P_CREATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CreateBy;
            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    trans = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    trans.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();

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
            return strMsg;
        }
        public string DeleteFromResign(EmployeeDTO objEmployeeDTO)
        {
            string strMsg = "";
            OracleCommand objOracleCommand = new OracleCommand("SP_DELETE_FROM_RESIGN");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;
            objOracleCommand.Parameters.Add("p_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;


            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    trans = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    trans.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
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
            return strMsg;
        }
        public DataTable GetVirtualTransferNew(EmployeeDTO objEmployeeDTO)
        {

            DataSet ds = null;
            DataTable myTable = new DataTable();
            try
            {
                string strMsg = "";
                OracleTransaction objOracleTransaction;
                OracleCommand objOracleCommand = new OracleCommand("SP_GET_VIRTUAL_TRANSFER_new");
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UnitId;
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SectionId;

                objOracleCommand.Parameters.Add("p_from_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.FromDate;
                objOracleCommand.Parameters.Add("p_to_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.ToDate;


                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return myTable;

        }
        public string SaveAttendanceDashboard(AttendanceDashboardDTO objAttendanceDashboardDTO)
        {
            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("sp_save_attendance_dashboard");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("p_dashboard_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objAttendanceDashboardDTO.AttendanceDashBoardId;
            objOracleCommand.Parameters.Add("p_log_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objAttendanceDashboardDTO.LogDate;
            objOracleCommand.Parameters.Add("p_present", OracleDbType.Varchar2, ParameterDirection.Input).Value = objAttendanceDashboardDTO.Present;
            objOracleCommand.Parameters.Add("p_day_off_other", OracleDbType.Varchar2, ParameterDirection.Input).Value = objAttendanceDashboardDTO.DayOffOther;
            objOracleCommand.Parameters.Add("p_leave", OracleDbType.Varchar2, ParameterDirection.Input).Value = objAttendanceDashboardDTO.Leave;
            objOracleCommand.Parameters.Add("p_leave_other", OracleDbType.Varchar2, ParameterDirection.Input).Value = objAttendanceDashboardDTO.LeaveOther;

            objOracleCommand.Parameters.Add("p_out_duty", OracleDbType.Varchar2, ParameterDirection.Input).Value = objAttendanceDashboardDTO.OutDuty;
            objOracleCommand.Parameters.Add("p_out_duty_other", OracleDbType.Varchar2, ParameterDirection.Input).Value = objAttendanceDashboardDTO.OutDutyOther;
            objOracleCommand.Parameters.Add("p_night_duty", OracleDbType.Varchar2, ParameterDirection.Input).Value = objAttendanceDashboardDTO.NightDuty;
            objOracleCommand.Parameters.Add("p_night_duty_other", OracleDbType.Varchar2, ParameterDirection.Input).Value = objAttendanceDashboardDTO.NightDutyOther;
            objOracleCommand.Parameters.Add("p_recruitment", OracleDbType.Varchar2, ParameterDirection.Input).Value = objAttendanceDashboardDTO.Recruitment;
            objOracleCommand.Parameters.Add("p_unrecognized_machine", OracleDbType.Varchar2, ParameterDirection.Input).Value = objAttendanceDashboardDTO.UnrecognizedToMachine;

            objOracleCommand.Parameters.Add("p_stand_by_yn", OracleDbType.Varchar2, ParameterDirection.Input).Value = objAttendanceDashboardDTO.StandByYn;

            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objAttendanceDashboardDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objAttendanceDashboardDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("P_CREATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objAttendanceDashboardDTO.CreateBy;
            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    trans = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    trans.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();

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
            return strMsg;
        }

        //public string SaveAttendanceDashboard(EmployeeDTO objEmployeeDTO)
        //{
        //    string strMsg = "";
        //    OracleTransaction trans = null;

        //    OracleCommand objOracleCommand = new OracleCommand("sp_save_attendance_dashboard");
        //    objOracleCommand.CommandType = CommandType.StoredProcedure;

        //    objOracleCommand.Parameters.Add("p_dashboard_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.AttendanceDashBoardId;
        //    objOracleCommand.Parameters.Add("p_log_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.LogDate;
        //    objOracleCommand.Parameters.Add("p_present", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Present;
        //    objOracleCommand.Parameters.Add("p_out_duty", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.OutDuty;
        //    objOracleCommand.Parameters.Add("p_recruitment", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Recruitment;

        //    objOracleCommand.Parameters.Add("p_detection", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Detection;
        //    objOracleCommand.Parameters.Add("p_other_detection", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.OtherDetection;
        //    objOracleCommand.Parameters.Add("p_day_off", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.DayOff;

        //    objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
        //    objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
        //    objOracleCommand.Parameters.Add("P_CREATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CreateBy;
        //    objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;
        //    using (OracleConnection strConn = GetConnection())
        //    {
        //        try
        //        {
        //            objOracleCommand.Connection = strConn;
        //            strConn.Open();
        //            trans = strConn.BeginTransaction();
        //            objOracleCommand.ExecuteNonQuery();
        //            trans.Commit();
        //            strConn.Close();
        //            strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();

        //        }
        //        catch (Exception ex)
        //        {
        //            trans.Rollback();
        //            throw new Exception("Error : " + ex.Message);
        //        }
        //        finally
        //        {
        //            strConn.Close();
        //        }
        //    }
        //    return strMsg;
        //}
        public DataTable GetAttendanceDashboard(EmployeeDTO objEmployeeDTO)
        {
            DataTable myTable = new DataTable();
            try
            {
                OracleCommand objOracleCommand = new OracleCommand("sp_get_attendance_dashboard");
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                objOracleCommand.Parameters.Add("p_from_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.FromDate;
                objOracleCommand.Parameters.Add("p_to_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.ToDate;

                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return myTable;
        }
        public string SaveShift(EmployeeDTO objEmployeeDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("SP_SAVE_SHIFT");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("p_shift_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.ShiftId;
            objOracleCommand.Parameters.Add("p_shift_name", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.ShiftName;
            objOracleCommand.Parameters.Add("p_duty_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.DutyTypeId;
            objOracleCommand.Parameters.Add("p_create_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CreateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    objOracleTransaction = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    objOracleTransaction.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
                }

                catch (Exception ex)
                {
                    objOracleTransaction.Rollback();
                    throw new Exception("Error : " + ex.Message);
                }
                finally
                {
                    strConn.Close();
                }
            }
            return strMsg;
        }
        public DataTable GetShift(string HeadOfficeId, string BranchOfficeId)
        {

            DataTable myTable = new DataTable();
            try
            {
                OracleCommand objOracleCommand = new OracleCommand("SP_GET_SHIFT");
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = BranchOfficeId;

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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return myTable;
        }
        public DataTable GetLogChangeEmpInfoSheet(EmployeeDTO objEmployeeDTO)
        {

            DataSet ds = null;
            DataTable myTable = new DataTable();
            try
            {                
                OracleCommand objOracleCommand = new OracleCommand("sp_get_security_log_by_param");
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                objOracleCommand.Parameters.Add("p_from_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.FromDate;
                objOracleCommand.Parameters.Add("p_to_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.ToDate;
                objOracleCommand.Parameters.Add("p_change_param", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.ChangeParam;
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UnitId;
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SectionId;
                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
                objOracleCommand.Parameters.Add("p_logged_in_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CreateBy;
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
                        trans.Commit();
                        strConn.Close();
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return myTable;
        }


        public DataTable GetUnpunchedHomeEmployee(EmployeeDTO objEmployeeDTO)
        {

            DataSet ds = null;
            DataTable myTable = new DataTable();
            try
            {
                string strMsg = "";
                OracleTransaction objOracleTransaction;

                //NEW
                OracleCommand objOracleCommand = new OracleCommand("sp_get_unpunched_reglr_homeemp");

                //OLD:2 USED IN DAILY ATTENDANCE REPORT
                //OracleCommand objOracleCommand = new OracleCommand("SP_GET_UNPUNCHED_HOME_EMP");
                //OLD:1
                //OracleCommand objOracleCommand = new OracleCommand("SP_GET_EMPLOYEE_WITHOUT_PUNCH");

                objOracleCommand.CommandType = CommandType.StoredProcedure;

                objOracleCommand.Parameters.Add("p_log_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.LogDate;
                objOracleCommand.Parameters.Add("p_floor_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.FloorId;
                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
                //new
                objOracleCommand.Parameters.Add("p_logged_in_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UpdateBy;
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
                        trans.Commit();
                        strConn.Close();
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return myTable;

        }

        public DataTable GetUnpunchedForeignEmployee(EmployeeDTO objEmployeeDTO)
        {

            DataSet ds = null;
            DataTable myTable = new DataTable();
            try
            {
                string strMsg = "";
                OracleTransaction objOracleTransaction;

                //NEW
                OracleCommand objOracleCommand = new OracleCommand("SP_GET_UNPUNCHED_FOREIGN_EMP");
                //OLD
                //OracleCommand objOracleCommand = new OracleCommand("SP_GET_EMPLOYEE_WITHOUT_PUNCH");

                objOracleCommand.CommandType = CommandType.StoredProcedure;

                objOracleCommand.Parameters.Add("p_log_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.LogDate;
                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
                objOracleCommand.Parameters.Add("p_logged_in_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UpdateBy;
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
                        trans.Commit();
                        strConn.Close();
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return myTable;

        }

        public string ProcessIncrementArrearStaff(EmployeeDTO objEmployeeDTO)
        {


            string strMsg = "";

            OracleCommand objOracleCommand = new OracleCommand("sp_process_incr_arrear_staff");
            OracleTransaction trans = null;

            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("p_increment_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Year;
            objOracleCommand.Parameters.Add("p_increment_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Month;
            objOracleCommand.Parameters.Add("p_arrear_from_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.FromYear;
            objOracleCommand.Parameters.Add("p_arrear_from_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.FromMonthId;
            objOracleCommand.Parameters.Add("p_arrear_to_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.ToYear;
            objOracleCommand.Parameters.Add("p_arrear_to_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.ToMonthId;
            objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UnitId;
            objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SectionId;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("p_logged_in_employee", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    trans = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    trans.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
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
            return strMsg;
        }
        public DataTable GetRoamingEmployee(EmployeeDTO objEmployeeDTO)
        {

            DataSet ds = null;
            DataTable myTable = new DataTable();
            try
            {
                string strMsg = "";
                OracleTransaction objOracleTransaction;
                OracleCommand objOracleCommand = new OracleCommand("SP_GET_ROAMING_EMPLOYEE");
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UnitId;
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SectionId;
                objOracleCommand.Parameters.Add("p_roaming_date", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Date;

                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return myTable;

        }
        public string CreateIndividualPaymentPhase(EmployeeDTO objEmployeeDTO)
        {
            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("sp_save_indiv_payment_phase");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;
            objOracleCommand.Parameters.Add("P_PAYMENT_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Year;
            objOracleCommand.Parameters.Add("P_PAYMENT_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Month;
            objOracleCommand.Parameters.Add("p_phase_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.PhaseId;
            objOracleCommand.Parameters.Add("p_payment_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.PaymentTypeId;
            objOracleCommand.Parameters.Add("p_eid_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EidTypeId;

            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("P_CREATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CreateBy;
            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    trans = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    trans.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();

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
            return strMsg;
        }
        public DataTable GetIndividualPaidEmployee(EmployeeDTO objEmployeeDTO)
        {

            DataSet ds = null;
            DataTable myTable = new DataTable();
            try
            {
                OracleCommand objOracleCommand = new OracleCommand("sp_get_individual_paid_emp");
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;
                objOracleCommand.Parameters.Add("p_card_no", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CardNo;
                objOracleCommand.Parameters.Add("p_payment_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Year;
                objOracleCommand.Parameters.Add("p_payment_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Month;
                objOracleCommand.Parameters.Add("p_payment_phase_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.PhaseId;
                objOracleCommand.Parameters.Add("p_payment_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.PaymentTypeId;
                objOracleCommand.Parameters.Add("p_eid_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EidTypeId;
                
                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return myTable;
        }
        public string DeleteEmpFromIndividualPayment(EmployeeDTO objEmployeeDTO)
        {
            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("SP_DELETE_EMP_INDIVID_PAYMENT");
            objOracleCommand.CommandType = CommandType.StoredProcedure;


            objOracleCommand.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;
            objOracleCommand.Parameters.Add("P_PAYMENT_YEAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Year;
            objOracleCommand.Parameters.Add("P_PAYMENT_MONTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Month;

            objOracleCommand.Parameters.Add("p_payment_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.PaymentTypeId;
            objOracleCommand.Parameters.Add("p_eid_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EidTypeId;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("P_CREATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CreateBy;
            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    trans = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    trans.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();

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
            return strMsg;
        }
        public DataTable GetIndividualPaymentSheet(EmployeeDTO objEmployeeDTO)
        {

            DataSet ds = null;
            DataTable myTable = new DataTable();
            try
            {
                OracleCommand objOracleCommand = new OracleCommand("sp_get_individual_peyment_s");
                objOracleCommand.CommandType = CommandType.StoredProcedure;
                                
                objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;
                objOracleCommand.Parameters.Add("p_card_no", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CardNo;
                objOracleCommand.Parameters.Add("p_payment_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Year;
                objOracleCommand.Parameters.Add("p_payment_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Month;

                objOracleCommand.Parameters.Add("p_payment_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.PaymentTypeId;
                objOracleCommand.Parameters.Add("p_eid_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EidTypeId;

                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
                objOracleCommand.Parameters.Add("p_logged_in_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CreateBy;
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return myTable;
        }
        public DataTable GetEmployeeForIndividualPayment(EmployeeDTO objEmployeeDTO)
        {

            DataSet ds = null;
            DataTable myTable = new DataTable();
            try
            {
                OracleCommand objOracleCommand = new OracleCommand("sp_get_emp_for_individ_payment");
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;
                objOracleCommand.Parameters.Add("p_card_no", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CardNo;
                objOracleCommand.Parameters.Add("p_payment_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Year;
                objOracleCommand.Parameters.Add("p_payment_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Month;
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UnitId;
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SectionId;
                objOracleCommand.Parameters.Add("p_designation_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.DesignationId;

                objOracleCommand.Parameters.Add("p_payment_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.PaymentTypeId;
                objOracleCommand.Parameters.Add("p_eid_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EidTypeId;

                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
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
                        trans.Commit();
                        strConn.Close();
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return myTable;
        }

        public DataTable GetPhaseWisePaymentSetup(EmployeeDTO objEmployeeDTO)
        {

            DataSet ds = null;
            DataTable myTable = new DataTable();
            try
            {
                OracleCommand objOracleCommand = new OracleCommand("SP_GET_PHASEWISE_PAYMENT_SETUP");
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                objOracleCommand.Parameters.Add("p_salary_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Year;
                objOracleCommand.Parameters.Add("p_salary_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Month;
                
                objOracleCommand.Parameters.Add("p_payment_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.PaymentTypeId;
                objOracleCommand.Parameters.Add("p_eid_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EidTypeId;

                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return myTable;
        }
        public DataTable GetPaymentRule(EmployeeDTO objEmployeeDTO)
        {

            DataSet ds = null;
            DataTable myTable = new DataTable();
            try
            {
                OracleCommand objOracleCommand = new OracleCommand("SP_GET_PAYMENT_RULE");
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                objOracleCommand.Parameters.Add("p_payment_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Year;
                objOracleCommand.Parameters.Add("p_payment_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Month;
                objOracleCommand.Parameters.Add("p_payment_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.PaymentTypeId;
                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return myTable;
        }

        public DataTable GetEmployeeInformatiom(EmployeeDTO objEmployeeDTO)
        {
            DataTable myTable = new DataTable();
            try
            {
                OracleCommand objOracleCommand = new OracleCommand("sp_get_emp_basic_information");
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;
                objOracleCommand.Parameters.Add("p_card_no", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CardNo;
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UnitId;
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SectionId;
                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
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
                        trans.Commit();
                        strConn.Close();
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return myTable;
        }
        public DataTable GetMonthlyInactiveSheet(EmployeeDTO objEmployeeDTO)
        {

            DataSet ds = null;
            DataTable myTable = new DataTable();
            try
            {
                OracleCommand objOracleCommand = new OracleCommand("SP_GET_MONTHLY_INACTIVE_SHEET");
                objOracleCommand.CommandType = CommandType.StoredProcedure;
                objOracleCommand.Parameters.Add("p_card_no", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CardNo;
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UnitId;
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SectionId;
                objOracleCommand.Parameters.Add("p_inactive_year", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Year;
                objOracleCommand.Parameters.Add("p_inactive_month", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.Month;
                objOracleCommand.Parameters.Add("p_ststus_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.StatusId;
                objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CreateBy;


                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return myTable;
        }
        public string chkEmployeeActivation(EmployeeDTO objEmployeeDTO)
        {
            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("sp_chk_emp_activation");
            objOracleCommand.CommandType = CommandType.StoredProcedure;
            objOracleCommand.Parameters.Add("P_CARD_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CardNo;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    trans = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    trans.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();

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
            return strMsg;
        }
        public DataTable GetWorkerForProductionDefectProcess(EmployeeDTO objEmployeeDTO)
        {
            DataTable myTable = new DataTable();
            try
            {
                OracleCommand objOracleCommand = new OracleCommand("sp_get_production_defect_emp");
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                objOracleCommand.Parameters.Add("p_employee_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeId;
                objOracleCommand.Parameters.Add("p_card_no", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.CardNo;
                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
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
                        trans.Commit();
                        strConn.Close();
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return myTable;
        }

        public DataTable GetEmpForPromotion(EmployeeDTO objEmployeeDTO)
        {

            DataTable myTable = new DataTable();
            try
            {
                OracleCommand objOracleCommand = new OracleCommand("sp_get_emp_for_promotion");
                objOracleCommand.CommandType = CommandType.StoredProcedure;
                //objOracleCommand.Parameters.Add("p_employee_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeTypeId;
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UnitId;
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SectionId;
                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return myTable;
        }

        public DataTable GetEmpForGradeChange(EmployeeDTO objEmployeeDTO)
        {

            DataTable myTable = new DataTable();
            try
            {
                OracleCommand objOracleCommand = new OracleCommand("sp_get_emp_for_grade_change");
                objOracleCommand.CommandType = CommandType.StoredProcedure;
                //objOracleCommand.Parameters.Add("p_employee_type_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.EmployeeTypeId;
                objOracleCommand.Parameters.Add("p_unit_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.UnitId;
                objOracleCommand.Parameters.Add("p_section_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.SectionId;
                objOracleCommand.Parameters.Add("p_grade_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.GradeId;
                objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.HeadOfficeId;
                objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.BranchOfficeId;
                objOracleCommand.Parameters.Add("p_SCHEDULE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objEmployeeDTO.ScheduleID;
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return myTable;
        }










    }
}

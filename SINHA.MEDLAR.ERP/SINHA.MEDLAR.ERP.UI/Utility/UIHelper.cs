using SINHA.MEDLAR.ERP.BLL;
using SINHA.MEDLAR.ERP.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SINHA.MEDLAR.ERP.UI.Utility
{
    public static class UIHelper
    {
        public static void PopulateDropdown(DropDownList dropdownlist, string dataTextField, string dataValueField, DataTable dt, string defaultText, string defaultValue, string selectedValue)
        {
            try
            {
                dropdownlist.Items.Insert(0, new ListItem(defaultText, defaultValue));

                foreach (DataRow row in dt.Rows)
                {
                    dropdownlist.Items.Add(new ListItem(row[dataTextField].ToString(), row[dataValueField].ToString()));
                }

                dropdownlist.DataTextField = dataTextField;
                dropdownlist.DataValueField = dataValueField;

                dropdownlist.DataBind();

                if (dropdownlist.Items.Count > 0)
                    dropdownlist.SelectedValue = selectedValue;
            }
            catch(Exception ex)
            {
            }
        }

        //1:
        public static void SetSucureEvents(Page page, EventPermissionDTO objEventPermDTO)
        {            
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();         
            var objEventPermissions = objEmployeeBLL.GetEventPermissionNew(objEventPermDTO);

            if (objEventPermissions != null)
            {

                ContentPlaceHolder MainContent = page.Master.FindControl("ContentPlaceHolder2") as ContentPlaceHolder;

                Button btnDisableAtten = MainContent.FindControl(objEventPermissions.DisableAttenEventId) as Button;
                Button btnDisableSave = MainContent.FindControl(objEventPermissions.DisableSaveEventId) as Button;
                Button btnDisableAdd = MainContent.FindControl(objEventPermissions.DisableAddEventId) as Button;
                Button btnDisableProcess = MainContent.FindControl(objEventPermissions.DisableProcessEventId) as Button;
                Button btnDisaleDelete = MainContent.FindControl(objEventPermissions.DisaleDeleteEventId) as Button;
                Button btnDisableSearch = MainContent.FindControl(objEventPermissions.DisableSearchEventId) as Button;

                if (!string.IsNullOrEmpty(objEventPermissions.DisableAttenEventId))
                {
                    if (btnDisableAtten != null)
                    {
                        btnDisableAtten.Visible = false;
                    }
                }
                else
                {
                    if (btnDisableAtten != null)
                    {
                        btnDisableAtten.Visible = true;
                    }
                }

                //2        
                if (!string.IsNullOrEmpty(objEventPermissions.DisableSaveEventId))
                {
                    if (btnDisableSave != null)
                    {
                        btnDisableSave.Visible = false;
                    }
                }
                else
                {
                    if (btnDisableSave != null)
                    {
                        btnDisableSave.Visible = true;
                    }
                }

                //3
                if (!string.IsNullOrEmpty(objEventPermissions.DisableAddEventId))
                {
                    if (btnDisableAdd != null)
                    {
                        btnDisableAdd.Visible = false;
                    }

                }
                else
                {
                    if (btnDisableAdd != null)
                    {
                        btnDisableAdd.Visible = true;
                    }
                }

                //4
                if (!string.IsNullOrEmpty(objEventPermissions.DisableProcessEventId))
                {
                    if (btnDisableProcess != null)
                    {
                        btnDisableProcess.Visible = false;
                    }
                }
                else
                {
                    if (btnDisableProcess != null)
                    {
                        btnDisableProcess.Visible = true;
                    }
                }

                //5
                if (!string.IsNullOrEmpty(objEventPermissions.DisaleDeleteEventId))
                {
                    if (btnDisaleDelete != null)
                    {
                        btnDisaleDelete.Visible = false;
                    }
                }
                else
                {
                    if (btnDisaleDelete != null)
                    {
                        btnDisaleDelete.Visible = true;
                    }
                }

                //6
                if (!string.IsNullOrEmpty(objEventPermissions.DisableSearchEventId))
                {
                    if (btnDisableSearch != null)
                    {
                        btnDisableSearch.Visible = false;
                    }
                }
                else
                {
                    if (btnDisableSearch != null)
                    {
                        btnDisableSearch.Visible = true;
                    }
                }
            }
        }

        //2
        public static void SetSucureEvents(ContentPlaceHolder MainContent, EventPermissionDTO objEventPermDTO)
        {
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            var objEventPermissions = objEmployeeBLL.GetEventPermissionNew(objEventPermDTO);

            if (objEventPermissions != null)
            {

                //ContentPlaceHolder MainContent = page.Master.FindControl("ContentPlaceHolder2") as ContentPlaceHolder;

                Button btnDisableAtten = MainContent.FindControl(objEventPermissions.DisableAttenEventId) as Button;
                Button btnDisableSave = MainContent.FindControl(objEventPermissions.DisableSaveEventId) as Button;
                Button btnDisableAdd = MainContent.FindControl(objEventPermissions.DisableAddEventId) as Button;
                Button btnDisableProcess = MainContent.FindControl(objEventPermissions.DisableProcessEventId) as Button;
                Button btnDisaleDelete = MainContent.FindControl(objEventPermissions.DisaleDeleteEventId) as Button;
                Button btnDisableSearch = MainContent.FindControl(objEventPermissions.DisableSearchEventId) as Button;

                if (!string.IsNullOrEmpty(objEventPermissions.DisableAttenEventId))
                {
                    if (btnDisableAtten != null)
                    {
                        btnDisableAtten.Visible = false;
                    }
                }
                else
                {
                    if (btnDisableAtten != null)
                    {
                        btnDisableAtten.Visible = true;
                    }
                }

                //2        
                if (!string.IsNullOrEmpty(objEventPermissions.DisableSaveEventId))
                {
                    if (btnDisableSave != null)
                    {
                        btnDisableSave.Visible = false;
                    }
                }
                else
                {
                    if (btnDisableSave != null)
                    {
                        btnDisableSave.Visible = true;
                    }
                }

                //3
                if (!string.IsNullOrEmpty(objEventPermissions.DisableAddEventId))
                {
                    if (btnDisableAdd != null)
                    {
                        btnDisableAdd.Visible = false;
                    }

                }
                else
                {
                    if (btnDisableAdd != null)
                    {
                        btnDisableAdd.Visible = true;
                    }
                }

                //4
                if (!string.IsNullOrEmpty(objEventPermissions.DisableProcessEventId))
                {
                    if (btnDisableProcess != null)
                    {
                        btnDisableProcess.Visible = false;
                    }
                }
                else
                {
                    if (btnDisableProcess != null)
                    {
                        btnDisableProcess.Visible = true;
                    }
                }

                //5
                if (!string.IsNullOrEmpty(objEventPermissions.DisaleDeleteEventId))
                {
                    if (btnDisaleDelete != null)
                    {
                        btnDisaleDelete.Visible = false;
                    }
                }
                else
                {
                    if (btnDisaleDelete != null)
                    {
                        btnDisaleDelete.Visible = true;
                    }
                }

                //6
                if (!string.IsNullOrEmpty(objEventPermissions.DisableSearchEventId))
                {
                    if (btnDisableSearch != null)
                    {
                        btnDisableSearch.Visible = false;
                    }
                }
                else
                {
                    if (btnDisableSearch != null)
                    {
                        btnDisableSearch.Visible = true;
                    }
                }
            }
        }


        //3 final
        public static void SetSucureEvents(Page page, string employeeId, string uiName, string branchOfficeId, string headOfficeId)
        {
            EventPermissionDTO objEventPermDTO = new EventPermissionDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();

            objEventPermDTO.UpdateBy = employeeId;
            objEventPermDTO.UIName = uiName;
            objEventPermDTO.BranchOfficeId = branchOfficeId;
            objEventPermDTO.HeadOfficeId = headOfficeId;

            var objEventPermissions = objEmployeeBLL.GetEventPermissionNew(objEventPermDTO);

            if (objEventPermissions != null)
            {

                ContentPlaceHolder MainContent = page.Master.FindControl("ContentPlaceHolder2") as ContentPlaceHolder;

                Button btnDisableAtten = MainContent.FindControl(objEventPermissions.DisableAttenEventId) as Button;
                Button btnDisableSave = MainContent.FindControl(objEventPermissions.DisableSaveEventId) as Button;
                Button btnDisableAdd = MainContent.FindControl(objEventPermissions.DisableAddEventId) as Button;
                Button btnDisableProcess = MainContent.FindControl(objEventPermissions.DisableProcessEventId) as Button;
                Button btnDisaleDelete = MainContent.FindControl(objEventPermissions.DisaleDeleteEventId) as Button;
                Button btnDisableSearch = MainContent.FindControl(objEventPermissions.DisableSearchEventId) as Button;

                if (!string.IsNullOrEmpty(objEventPermissions.DisableAttenEventId))
                {
                    if (btnDisableAtten != null)
                    {
                        btnDisableAtten.Visible = false;
                    }
                }
                else
                {
                    if (btnDisableAtten != null)
                    {
                        btnDisableAtten.Visible = true;
                    }
                }

                //2        
                if (!string.IsNullOrEmpty(objEventPermissions.DisableSaveEventId))
                {
                    if (btnDisableSave != null)
                    {
                        btnDisableSave.Visible = false;
                    }
                }
                else
                {
                    if (btnDisableSave != null)
                    {
                        btnDisableSave.Visible = true;
                    }
                }

                //3
                if (!string.IsNullOrEmpty(objEventPermissions.DisableAddEventId))
                {
                    if (btnDisableAdd != null)
                    {
                        btnDisableAdd.Visible = false;
                    }

                }
                else
                {
                    if (btnDisableAdd != null)
                    {
                        btnDisableAdd.Visible = true;
                    }
                }

                //4
                if (!string.IsNullOrEmpty(objEventPermissions.DisableProcessEventId))
                {
                    if (btnDisableProcess != null)
                    {
                        btnDisableProcess.Visible = false;
                    }
                }
                else
                {
                    if (btnDisableProcess != null)
                    {
                        btnDisableProcess.Visible = true;
                    }
                }

                //5
                if (!string.IsNullOrEmpty(objEventPermissions.DisaleDeleteEventId))
                {
                    if (btnDisaleDelete != null)
                    {
                        btnDisaleDelete.Visible = false;
                    }
                }
                else
                {
                    if (btnDisaleDelete != null)
                    {
                        btnDisaleDelete.Visible = true;
                    }
                }

                //6
                if (!string.IsNullOrEmpty(objEventPermissions.DisableSearchEventId))
                {
                    if (btnDisableSearch != null)
                    {
                        btnDisableSearch.Visible = false;
                    }
                }
                else
                {
                    if (btnDisableSearch != null)
                    {
                        btnDisableSearch.Visible = true;
                    }
                }
            }
        }


        //1
        //    if (basicInfo.DisableAtten == "1")
        //    {
        //        foreach (Control control in controls)
        //        {
        //            if (control.ID == basicInfo.DisableAttenEventId)
        //            {
        //                control.Visible = false;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        foreach (Control control in controls)
        //        {
        //            if (control.ID == basicInfo.DisableAttenEventId)
        //            {
        //                control.Visible = true;
        //            }
        //        }
        //    }

        //    //2        
        //    if (basicInfo.DisableSave == "1")
        //        {
        //            foreach (Control control in controls)
        //            {
        //                if (control.ID == basicInfo.DisableSaveEventId)
        //                {
        //                    control.Visible = false;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            foreach (Control control in controls)
        //            {
        //                if (control.ID == basicInfo.DisableSaveEventId)
        //                {
        //                    control.Visible = true;
        //                }
        //            }
        //        }

        //    //3
        //    if (basicInfo.DisableAdd == "1")
        //    {
        //        foreach (Control control in controls)
        //        {
        //            if (control.ID == basicInfo.DisableAddEventId)
        //            {
        //                control.Visible = false;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        foreach (Control control in controls)
        //        {
        //            if (control.ID == basicInfo.DisableAddEventId)
        //            {
        //                control.Visible = true;
        //            }
        //        }
        //    }

        //    //4
        //    if (basicInfo.DisableProcess == "1")
        //    {
        //        foreach (Control control in controls)
        //        {
        //            if (control.ID == basicInfo.DisableProcessEventId)
        //            {
        //                control.Visible = false;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        foreach (Control control in controls)
        //        {
        //            if (control.ID == basicInfo.DisableProcessEventId)
        //            {
        //                control.Visible = true;
        //            }
        //        }
        //    }

        //    //5
        //    if (basicInfo.DisaleDelete == "1")
        //    {
        //        foreach (Control control in controls)
        //        {
        //            if (control.ID == basicInfo.DisableSearchEventId)
        //            {
        //                control.Visible = false;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        foreach (Control control in controls)
        //        {
        //            if (control.ID == basicInfo.DisableSearchEventId)
        //            {
        //                control.Visible = true;
        //            }
        //        }
        //    }

        //    //6
        //    if (basicInfo.DisableSearch == "1")
        //    {
        //        foreach (Control control in controls)
        //        {
        //            if (control.ID == basicInfo.DisableSearchEventId)
        //            {
        //                control.Visible = false;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        foreach (Control control in controls)
        //        {
        //            if (control.ID == basicInfo.DisableSearchEventId)
        //            {
        //                control.Visible = true;
        //            }
        //        }
        //    }


    }
}
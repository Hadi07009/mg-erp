using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO
{
    public class WokerProcessDTO
    {

        private string strProcessId;
        private string strProcessCode;
        private string strProcessName;

        private string strUpdateBy;
        private string strHeadOfficeId;
        private string strBranchOfficeId;

        private string strSizeId;
        private string strSizeName;
        private string strEmployeeId;
        private string strSMV;
        private string strMachineId;
        private string strMachineType;
        private string strBrandId;
        private string strBrandName;
        private string strModelId;
        private string strModelName;
        private string strMachineRegionId;
        private string strMachineRegionName;
        private string strManufacturerSL;
        private string strMALSL;
        private string strProcessTypeId;
        private string strProcessSelectTypeId;

        public string ProcessSelectTypeId
        {
            get { return strProcessSelectTypeId; }
            set { strProcessSelectTypeId = value; }
        }
        public string ProcessTypeId
        {
            get { return strProcessTypeId; }
            set { strProcessTypeId = value; }
        }
        public string ManufacturerSL
        {
            get { return strManufacturerSL; }
            set { strManufacturerSL = value; }
        }
        public string MALSL
        {
            get { return strMALSL; }
            set { strMALSL = value; }
        }

        public string MachineRegionName
        {
            get { return strMachineRegionName; }
            set { strMachineRegionName = value; }
        }

        public string MachineRegionId
        {
            get { return strMachineRegionId; }
            set { strMachineRegionId = value; }
        }

        public string ModelId
        {
            get { return strModelId; }
            set { strModelId = value; }
        }

        public string ModelName
        {
            get { return strModelName; }
            set { strModelName = value; }
        }
        public string BrandId
        {
            get { return strBrandId; }
            set { strBrandId = value; }
        }
        public string BrandName
        {
            get { return strBrandName; }
            set { strBrandName = value; }
        }
        public string MachineId
        {
            get { return strMachineId; }
            set { strMachineId = value; }
        }

        public string MachineType
        {
            get { return strMachineType; }
            set { strMachineType = value; }
        }


        public string EmployeeId
        {
            get { return strEmployeeId; }
            set { strEmployeeId = value; }
        }

        public string SMV
        {
            get { return strSMV; }
            set { strSMV = value; }
        }

        public string SizeId
        {
            get { return strSizeId; }
            set { strSizeId = value; }
        }


        public string SizeName
        {
            get { return strSizeName; }
            set { strSizeName = value; }
        }


        public string ProcessName
        {
            get { return strProcessName; }
            set { strProcessName = value; }
        }

        public string ProcessCode
        {
            get { return strProcessCode; }
            set { strProcessCode = value; }
        }
        public string  ProcessId
        {
            get { return strProcessId;}
            set { strProcessId = value;} 
        }

        public string UpdateBy
        {
            get { return strUpdateBy; }
            set { strUpdateBy = value; }
        }

        public string HeadOfficeId
        {
            get { return strHeadOfficeId; }
            set { strHeadOfficeId = value; }
        }

        public string BranchOfficeId
        {
            get { return strBranchOfficeId; }
            set { strBranchOfficeId = value; }
        }

    }
}

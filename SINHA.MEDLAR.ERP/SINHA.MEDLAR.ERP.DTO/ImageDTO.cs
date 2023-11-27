using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO
{
    public class ImageDTO
    {
         
        private string strImageId;
        private string strEmployeeId;
        private string strEmployeeName;
        private byte[] strImage;
        private string strImagePath;

        private string strHeadOfficeId;
        private string strBranchOfficeId;
        private string strUpdateBy;


        public string ImageId
        {

            get { return strImageId; }
            set { strImageId = value;} 
        }

        public string EmployeeId
        {

            get { return strEmployeeId; }
            set { strEmployeeId = value; }
        }

        public string EmployeeName
        {

            get { return strEmployeeName; }
            set { strEmployeeName = value; }
        }

        public byte[] Image
        {

            get { return strImage; }
            set { strImage = value; }
        }

        public string ImagePath
        {

            get { return strImagePath; }
            set { strImagePath = value; }
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

        public string UpdateBy
        {

            get { return strUpdateBy; }
            set { strUpdateBy = value; }
        }

    }
}

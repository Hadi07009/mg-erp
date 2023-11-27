using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO
{
  public class PolyBagDTO
    {
        private string strPolybagStyleId;
        private string strPolybagId;
        private string strStyleId;
        private string strPolybagLenght;
        private string strPolybagWidth;
        private string strPolybagHeight;
        private string strHeadOfficeId;
        private string strBranchOfficeId;
        private string strUpdateBy;

        public string PolybagStyleId
        {
            get { return strPolybagStyleId; }
            set { strPolybagStyleId = value; }

        }
        public string PolybagId
        {
            get { return strPolybagId; }
            set { strPolybagId = value; }

        }
        public string StyleId
        {
            get { return strStyleId; }
            set { strStyleId = value; }

        }
        public string PolybagLenght
        {
            get { return strPolybagLenght; }
            set { strPolybagLenght = value; }

        }
        public string PolybagWidth
        {
            get { return strPolybagWidth; }
            set { strPolybagWidth = value; }

        }
        public string PolybagHeight
        {
            get { return strPolybagHeight; }
            set { strPolybagHeight = value; }

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO
{

    public class SparePartDTO
    {

        private string strSparePartId;
        private string strSparePartName;
        private string strSparePartNo;

        private string strSparePartCategoryId;
        private string strSparePartCategoryName;
        private string strSparePartCategoryNo;
        private string strQuantityPerEnginee;

        private string strEquipmetId;
        private string strEquipmentName;
        private string strFileName;


        private string strUpdateBY;
        private string strHeadOffieId;
        private string strBranchOffieId;
        private byte[] strFileSize;


        public byte[] FileSize
        {
            get { return strFileSize; }
            set { strFileSize = value; }


        }

        public string UpdateBY
        {
            get { return strUpdateBY; }
            set { strUpdateBY = value; }


        }

        public string HeadOffieId
        {
            get { return strHeadOffieId; }
            set { strHeadOffieId = value; }


        }

        public string BranchOffieId
        {
            get { return strBranchOffieId; }
            set { strBranchOffieId = value; }


        }


        public string FileName
        {
            get { return strFileName; }
            set { strFileName = value; }


        }

        public string EquipmetId
        {
            get { return strEquipmetId; }
            set { strEquipmetId = value; }


        }

        public string EquipmentName
        {
            get { return strEquipmentName; }
            set { strEquipmentName = value; }


        }

        public string QuantityPerEnginee
        {
            get { return strQuantityPerEnginee; }
            set { strQuantityPerEnginee = value; }


        }


        public string SparePartCategoryId
        {
            get { return strSparePartCategoryId; }
            set { strSparePartCategoryId = value; }


        }

        public string SparePartCategoryName
        {
            get { return strSparePartCategoryName; }
            set { strSparePartCategoryName = value; }


        }

        public string SparePartCategoryNo
        {
            get { return strSparePartCategoryNo; }
            set { strSparePartCategoryNo = value; }


        }

        public string SparePartId
        {
            get { return strSparePartId; }
            set { strSparePartId = value; }


        }

        public string SparePartName
        {
            get { return strSparePartName; }
            set { strSparePartName = value; }


        }

        public string SparePartNo
        {
            get { return strSparePartNo; }
            set { strSparePartNo = value; }


        }
    }
}

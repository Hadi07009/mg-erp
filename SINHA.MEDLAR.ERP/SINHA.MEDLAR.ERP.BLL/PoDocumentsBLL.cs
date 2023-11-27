using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;
using System.Data;

namespace SINHA.MEDLAR.ERP.BLL
{
    public class PoDocumentsBLL
    {
        public string savePoDocumentsSave(PoDocumentsDTO objPoDocumentsDTO)
        {

            PoDocumentsDAL objPoDocumentsDAL = new PoDocumentsDAL();
            string strMsg = objPoDocumentsDAL.savePoDocumentsSave(objPoDocumentsDTO);
            return strMsg;
        }

        public PoDocumentsDTO LoadPoDocumentsRecord(string strPoNumber, string strHeadOfficeId, string strBranchOfficeId)
        {
            PoDocumentsDTO objPoDocumentsDTO = new PoDocumentsDTO();
            PoDocumentsDAL objPoDocumentsDAL = new PoDocumentsDAL();
            objPoDocumentsDTO = objPoDocumentsDAL.LoadPoDocumentsRecord(strPoNumber, strHeadOfficeId, strBranchOfficeId);
            return objPoDocumentsDTO;
        }
        public string deletePoDocumentsRecordRecord(PoDocumentsDTO objPoDocumentsODTO)
        {

            PoDocumentsDAL objPoDocumentsDAL = new PoDocumentsDAL();
            string strMsg = objPoDocumentsDAL.deletePoDocumentsRecordRecord(objPoDocumentsODTO);
            return strMsg;
        }

        public DataTable LoadPoNumber(PoDocumentsDTO objPoDocumentsDTO)
        {

            DataTable dt = new DataTable();
            PoDocumentsDAL objPoDocumentsDAL = new PoDocumentsDAL();


            dt = objPoDocumentsDAL.LoadPoNumber(objPoDocumentsDTO);
            return dt;

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SINHA.MEDLAR.ERP.DAL;
using SINHA.MEDLAR.ERP.DTO;
using System.Data;
namespace SINHA.MEDLAR.ERP.BLL
{
  public  class DigitalBoardBLL
    {
      public DataTable getBuyerId(string strHeadOfficeId, string strBranchOfficeId)
      {

          DataTable dt = new DataTable();
          DigitalBoardDAL objDigitalBoardDAL = new DigitalBoardDAL();


          dt = objDigitalBoardDAL.getBuyerId(strHeadOfficeId, strBranchOfficeId);
          return dt;

      }
      public DataTable getBuyerIdSearch(string strHeadOfficeId, string strBranchOfficeId)
      {

          DataTable dt = new DataTable();
          DigitalBoardDAL objDigitalBoardDAL = new DigitalBoardDAL();


          dt = objDigitalBoardDAL.getBuyerIdSearch(strHeadOfficeId, strBranchOfficeId);
          return dt;

      }

      public DataTable loadDigitalBoardInputRecord(string strHeadOffieId, string strBranchOffieId)
      {

          DigitalBoardDTO objDigitalBoardDTO = new DigitalBoardDTO();
          DigitalBoardDAL objDigitalBoardDAL = new DigitalBoardDAL();
          DataTable dt = new DataTable();

          dt = objDigitalBoardDAL.loadDigitalBoardInputRecord(strHeadOffieId, strBranchOffieId);
          return dt;

      }

      public string saveDigitalBoardInputInfo(DigitalBoardDTO objDigitalBoardDTO)
      {

          DigitalBoardDAL objDigitalBoardDAL = new DigitalBoardDAL();
          string strMsg = "";

          strMsg = objDigitalBoardDAL.saveDigitalBoardInputInfo(objDigitalBoardDTO);
          return strMsg;
      }

      public DigitalBoardDTO searchDigitalBoardInputEntry(string strDigitalInputEntryId, string strHeadOfficeId, string strBranchOfficeId)
      {

          DigitalBoardDTO objDigitalBoardDTO = new DigitalBoardDTO();
          DigitalBoardDAL objDigitalBoardDAL = new DigitalBoardDAL();

          objDigitalBoardDTO = objDigitalBoardDAL.searchDigitalBoardInputEntry(strDigitalInputEntryId, strHeadOfficeId, strBranchOfficeId);
          return objDigitalBoardDTO;

      }


      public DataTable getLineId(string strHeadOfficeId, string strBranchOfficeId)
      {

          DataTable dt = new DataTable();
          DigitalBoardDAL objDigitalBoardDAL = new DigitalBoardDAL();


          dt = objDigitalBoardDAL.getLineId(strHeadOfficeId, strBranchOfficeId);
          return dt;

      }

      public DataTable getLineIdSearch(string strHeadOfficeId, string strBranchOfficeId)
      {

          DataTable dt = new DataTable();
          DigitalBoardDAL objDigitalBoardDAL = new DigitalBoardDAL();


          dt = objDigitalBoardDAL.getLineIdSearch(strHeadOfficeId, strBranchOfficeId);
          return dt;

      }

      public DataTable DigitalBoardEntrySearch(DigitalBoardDTO objDigitalBoardDTO)
      {

          DigitalBoardDAL objDigitalBoardDAL = new DigitalBoardDAL();
          DataTable dt = new DataTable();

          dt = objDigitalBoardDAL.DigitalBoardEntrySearch(objDigitalBoardDTO);
          return dt;

      }

    }
}

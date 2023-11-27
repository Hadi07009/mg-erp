using SINHA.MEDLAR.ERP.BLL;
using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DTO.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class PackingSetting : System.Web.UI.Page
    {
     public  static string strEmployeeId = "";
        static string strSectionId = "";
        static string strDepartmentId = "";
        static string strDesignationId = "";
        static string strUnitId = "";
        static string strCatagoryId;
        static string strHeadOfficeId = "";
        static string strBranchOfficeId = "";
        static string strEmployeeTypeId = "";
        static string strLoginDay = "";
        static string strLoginMonth = "";
        static string strLoginDate = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            loadSesscion();

            if (Session["strEmployeeId"] == null)
            {
                sessionEmpty();
                return;
            }
            if (!IsPostBack)
            {
                //getOfficeName();
            }
        }

        public void loadSesscion()
        {
            strEmployeeId = Session["strEmployeeId"].ToString().Trim();
            strSectionId = Session["strSectionId"].ToString().Trim();

            strDesignationId = Session["strDesignationId"].ToString().Trim();
            strUnitId = Session["strUnitId"].ToString().Trim();
            strCatagoryId = Session["strCatagoryId"].ToString().Trim();
            strHeadOfficeId = Session["strHeadOfficeId"].ToString().Trim();
            strBranchOfficeId = Session["strBranchOfficeId"].ToString().Trim();
            strLoginDay = Session["strLoginDay"].ToString().Trim();
            strLoginMonth = Session["strLoginMonth"].ToString().Trim();
            strLoginDate = Session["strLoginDate"].ToString().Trim();
        }

        public void sessionEmpty()
        {
            Session["strEmployeeId"] = null;
            Session["strSectionId"] = null;
            Session["strDepartmentId"] = null;
            Session["strDesignationId"] = null;
            Session["strUnitId"] = null;
            Session["strCatagoryId"] = null;
            Session["strHeadOfficeId"] = null;
            Session["strBranchOfficeId"] = null;
            Session["strLoginDay"] = null;
            Session["strLoginMonth"] = null;
            Session["strLoginDate"] = null;
            Session.Clear();
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            FormsAuthentication.SignOut();
            Response.Redirect("Login.aspx", true);
        }

        [System.Web.Services.WebMethod]
        public static string SavePackingMaster(PackingMaster model)
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();
            string status = string.Empty;

            PackingMaster objPacking = new PackingMaster();
            objPacking = model;
            
            objPacking.HeadOfficeId = strHeadOfficeId;
            objPacking.BranchOfficeId = strBranchOfficeId;
            objPacking.LoggedInEmployeeId = strEmployeeId;
            
            string strMsg = objLookUpBLL.SavePackingMaster(objPacking);

            return strMsg;
        }

        [System.Web.Services.WebMethod]
        //public static string SaveProductSizIenfo(ProductSizeInfo model)
        public static string SaveProductSizeInfo(ProductSizeInfo model)
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();
            string status = string.Empty;

            ProductSizeInfo objProductSize = new ProductSizeInfo();
            objProductSize = model;
            objProductSize.HeadOfficeId = strHeadOfficeId;
            objProductSize.BranchOfficeId = strBranchOfficeId;
            objProductSize.LoggedInEmployeeId = strEmployeeId;

            string strMsg = objLookUpBLL.SaveProductSizeInfo(objProductSize);

            return strMsg;
        }
        [System.Web.Services.WebMethod]
        public static string SaveCartoonDetails(CartoonDetails model)
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();
            string status = string.Empty;

            CartoonDetails objCartoonDetails = new CartoonDetails();
            objCartoonDetails = model;
            objCartoonDetails.HeadOfficeId = strHeadOfficeId;
            objCartoonDetails.BranchOfficeId = strBranchOfficeId;
            objCartoonDetails.LoggedInEmployeeId = strEmployeeId;

            string strMsg = objLookUpBLL.SaveCartoonDetails(objCartoonDetails);

            return strMsg;
        }

        [System.Web.Services.WebMethod]
        public static string SaveCartoonMapping(CartoonMapping model)
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();
            string status = string.Empty;

            CartoonMapping objCartoonMapping = new CartoonMapping();
            objCartoonMapping = model;
            objCartoonMapping.HeadOfficeId = strHeadOfficeId;
            objCartoonMapping.BranchOfficeId = strBranchOfficeId;
            objCartoonMapping.LoggedInEmployeeId = strEmployeeId;

            string strMsg = objLookUpBLL.SaveCartoonMapping(objCartoonMapping);

            return strMsg;
        }

        [System.Web.Services.WebMethod]
        public static List<ProductSizeInfo> GetProductSizeInfo(string po_no, string style_no, string packing_master_id)
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            ProductSizeInfo objProductSizeInfo = new ProductSizeInfo();

            objProductSizeInfo.po_no = po_no;
            objProductSizeInfo.style_no = style_no;

            objProductSizeInfo.packing_master_id = Convert.ToDecimal(packing_master_id);

            objProductSizeInfo.HeadOfficeId = strHeadOfficeId;
            objProductSizeInfo.BranchOfficeId = strBranchOfficeId;
            objProductSizeInfo.LoggedInEmployeeId = strEmployeeId;

            List<ProductSizeInfo> productSizeInfo = objLookUpBLL.GetProductSizeInfo(objProductSizeInfo);

            // string strMsg = objLookUpBLL.GetPackingMaster(objPacking);

            return productSizeInfo;
        }


        [System.Web.Services.WebMethod]
        public static List<PackingMaster> GetAllPackingMaster()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();
            
            PackingMaster objPacking = new PackingMaster();
            objPacking.HeadOfficeId = strHeadOfficeId;
            objPacking.BranchOfficeId = strBranchOfficeId;
            

            List<PackingMaster> objCartoonSummaries = objLookUpBLL.GetAllPackingMaster(objPacking);

            return objCartoonSummaries;
        }

        [System.Web.Services.WebMethod]
        public static List<PackingMaster> GetPackingMaster(PackingMaster model)
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();
            
            PackingMaster objPacking = new PackingMaster();
            objPacking = model;
            objPacking.HeadOfficeId = strHeadOfficeId;
            objPacking.BranchOfficeId = strBranchOfficeId;
            objPacking.LoggedInEmployeeId = strEmployeeId;

            List<PackingMaster> objCartoonSummaries = objLookUpBLL.GetPackingMaster(objPacking);

         // string strMsg = objLookUpBLL.GetPackingMaster(objPacking);

            return objCartoonSummaries;
        }
        [System.Web.Services.WebMethod]
        public static List<CartoonDetails> GetCartoonDetailsInfo(string po_no, string style_no,string packing_master_id)
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            CartoonDetails objCartoon = new CartoonDetails();

            objCartoon.po_no = po_no;
            objCartoon.style_no = style_no;
            objCartoon.packing_master_id = packing_master_id;


            objCartoon.HeadOfficeId = strHeadOfficeId;
            objCartoon.BranchOfficeId = strBranchOfficeId;
            objCartoon.LoggedInEmployeeId = strEmployeeId;

            List<CartoonDetails> objCartoonSummaries = objLookUpBLL.GetCartoonDetailsInfo(objCartoon);

            // string strMsg = objLookUpBLL.GetPackingMaster(objPacking);

            return objCartoonSummaries;
        }
        [System.Web.Services.WebMethod]
        public static List<CartoonMapping> GetCartoonMappingInfo(string po_no, string style_no)
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            CartoonMapping objCartoon = new CartoonMapping();

            objCartoon.po_no = po_no;
            objCartoon.style_no = style_no;


            objCartoon.HeadOfficeId = strHeadOfficeId;
            objCartoon.BranchOfficeId = strBranchOfficeId;
            objCartoon.LoggedInEmployeeId = strEmployeeId;

            List<CartoonMapping> objCartoonMapping = objLookUpBLL.GetCartoonMappingInfo(objCartoon);

            // string strMsg = objLookUpBLL.GetPackingMaster(objPacking);

            return objCartoonMapping;
        }


        [System.Web.Services.WebMethod]
        public static List<BuyerInfo> GetBuyer()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();
            DataTable dt = new DataTable();
            List<BuyerInfo> objBuyerInfo = objLookUpBLL.GetBuyer(strHeadOfficeId, strBranchOfficeId);
          //  objLookUpBLL.getBuyerId(strHeadOfficeId, strBranchOfficeId);

            return objBuyerInfo;
        }
        [System.Web.Services.WebMethod]
        public static List<CartoonDetails> GetCartoonSize(string po_no,string style_no, string packing_master_id)
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();
            DataTable dt = new DataTable();

            List<CartoonDetails> objCartoonDetails = objLookUpBLL.GetCartoonSize(po_no, style_no, packing_master_id,strHeadOfficeId, strBranchOfficeId);
            //  objLookUpBLL.getBuyerId(strHeadOfficeId, strBranchOfficeId);

            return objCartoonDetails;
        }
        [System.Web.Services.WebMethod]
        public static List<PackingType> GetPackingType()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();
            DataTable dt = new DataTable();
            List<PackingType> objPackingType = objLookUpBLL.GetPackingType(strHeadOfficeId, strBranchOfficeId);

            return objPackingType;
        }

        [System.Web.Services.WebMethod]
        public static List<ShipmentType> GetShipmentMode()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();
            DataTable dt = new DataTable();
            List<ShipmentType> objShipmentType = objLookUpBLL.GetShipmentMode(strHeadOfficeId, strBranchOfficeId);

            return objShipmentType;
        }

        [System.Web.Services.WebMethod]
        public static List<SeasonInfo> GetSeason()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();
            DataTable dt = new DataTable();
            List<SeasonInfo> objSeasonInfo = objLookUpBLL.GetSeason(strHeadOfficeId, strBranchOfficeId);

            return objSeasonInfo;
        }

        [System.Web.Services.WebMethod]
        public static List<ProductSizeInfo> GetSizeInfo(string po_no, string style_no, string packing_master_id)
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();
            DataTable dt = new DataTable();
            //old
            // List<ProductSizeInfo> objProductSizeInfo = objLookUpBLL.GetSizeInfo(strHeadOfficeId, strBranchOfficeId);
            List<ProductSizeInfo> objProductSizeInfo = objLookUpBLL.GetSizeInfo(po_no, style_no, packing_master_id, strHeadOfficeId, strBranchOfficeId);

            return objProductSizeInfo;
        }


        [System.Web.Services.WebMethod]
        public static List<ManufacturerInfo> GetManufacturer()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();
            DataTable dt = new DataTable();
            List<ManufacturerInfo> objManufacturerInfo = objLookUpBLL.GetManufacturer(strHeadOfficeId, strBranchOfficeId);

            return objManufacturerInfo;
        }

        //changed from GetCartoonDetails
        [System.Web.Services.WebMethod]
        public static List<CartoonDTO> GetCartoon()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();
            DataTable dt = new DataTable();
            List<CartoonDTO> objCartoonDTO = objLookUpBLL.GetCartoon(strHeadOfficeId, strBranchOfficeId);

            return objCartoonDTO;
        }

        public static List<CartoonSummary> GetCartoonSummary(string po_no, string style_no)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();
            DataTable dt = new DataTable();

            List<CartoonSummary> objCartoonSummaries = objLookUpBLL.GetCartoonSummary(po_no, style_no, strHeadOfficeId, strBranchOfficeId);

                return objCartoonSummaries;
        }
        
    }
}
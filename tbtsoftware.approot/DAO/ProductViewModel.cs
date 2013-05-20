namespace bnb.approot.DAO
{
    using System;

    public class ProductViewModel
    {
        #region Public Properties

        public int BranchID { get; set; }

        public string CateID { get; set; }

        public string CateName { get; set; }

        public string FullDescript { get; set; }

        public double GiaGiaoCham { get; set; }

        public Boolean HasVAT { get; set; }

        public int ID { get; set; }

        public int ImageID { get; set; }

        public string ImageUrl { get; set; }

        public DateTime InvestigateDate { get; set; }

        public double InvestigatePrice { get; set; }

        public Boolean IsDelete { get; set; }

        public Boolean IsDisplay { get; set; }

        public string MaSanPham { get; set; }

        public string Name { get; set; }

        public double OnlinePrice { get; set; }

        public double OnlinePriceProf { get; set; }

        public int OrderSort { get; set; }

        public string ProductName { get; set; }

        public string ProductNameSEO { get; set; }

        public double PurchasePrice { get; set; }

        public int Quantity { get; set; }

        public string ShortDescript { get; set; }

        public double SlowPriceProf { get; set; }

        public int SupplierID { get; set; }

        public Boolean TheoDoi { get; set; }

        public double TyLeCK { get; set; }

        #endregion
    }

    public class ProductAutocomplete
    {
        #region Public Properties

        public int ID { get; set; }

        public string ProductName { get; set; }

        #endregion
    }
}
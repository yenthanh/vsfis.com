namespace bnb.approot.DAO
{
    using System;

    public class SanPhamCanhBao
    {
        #region Public Properties

        public int CanhBaoSanPhamID { get; set; }

        public int ID { get; set; }

        public int ImageID { get; set; }

        public string ImageUrl { get; set; }

        public DateTime InvestigateDate { get; set; }

        public float InvestigatePrice { get; set; }

        public string LyDoCanhBao { get; set; }

        public string MotaXuLy { get; set; }

        public string MucDoNghiemTrong { get; set; }

        public DateTime NgayCanhBao { get; set; }

        public DateTime NgayXuLy { get; set; }

        public float OnlinePrice { get; set; }

        public string ProductName { get; set; }

        public float PurchasePrice { get; set; }

        public Boolean TrangThaiXuLy { get; set; }

        #endregion
    }
}
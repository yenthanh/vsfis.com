namespace bnb.approot.DAO
{
    using System;

    public class KhachHangCanhBao
    {
        #region Public Properties

        public string Address { get; set; }

        public string BranchName { get; set; }

        public int CanhBaoKHID { get; set; }

        public string GasUsed { get; set; }

        public int ID { get; set; }

        public string LyDoCanhBao { get; set; }

        public string MotaXuLy { get; set; }

        public string MucDoNghiemTrong { get; set; }

        public string Name { get; set; }

        public DateTime NgayCanhBao { get; set; }

        public DateTime NgayXuLy { get; set; }

        public string Tel { get; set; }

        public Boolean TrangThaiXuLy { get; set; }

        #endregion
    }
}
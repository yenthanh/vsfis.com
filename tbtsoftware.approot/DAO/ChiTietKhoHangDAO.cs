namespace bnb.approot.DAO
{
    using System.Collections.Generic;
    using System.Linq;

    using MinhPham.Web.BepNhaBan.DAO;

    public class ChiTietWarehouseDAO
    {
        #region Static Fields

        private static readonly BNBDataContext DB = new BNBDataContext(DBConnect.GetConnectionString());

        #endregion

        #region Public Methods and Operators

        public static bool CheckExistChiTietPhieuNhapKhoTheoIDTemp(int ID)
        {
            return DB.Temp_HoaDon_MuaCTs.Any(p => p.ProductID.Equals(ID));
        }

        public static HoaDon_MuaCT ChiTietPhieuNhapKhoTheoID(int Id)
        {
            return DB.HoaDon_MuaCTs.First(p => p.HDMCTID.Equals(Id));
        }

        public static Temp_HoaDon_MuaCT ChiTietPhieuNhapKhoTheoIDTemp(int Id)
        {
            return DB.Temp_HoaDon_MuaCTs.First(p => p.HDMCTID.Equals(Id));
        }

        public static IQueryable<ChiTietPhieuNhapKhoFull> DanhSachChiTietPNKTheoHDMIDFull(int HDMID)
        {
            IQueryable<ChiTietPhieuNhapKhoFull> t0 = from t1 in DB.HoaDon_MuaCTs
                                                     join t2 in DB.Products on t1.ProductID equals t2.ID
                                                     where t1.HDMID == HDMID
                                                     select
                                                         new ChiTietPhieuNhapKhoFull
                                                             {
                                                                 HDMCTID = (int)t1.HDMID,
                                                                 ID = (int)t1.ProductID,
                                                                 ProductName = t2.Name,
                                                                 SoLuong = (decimal)t1.SoLuong,
                                                                 DonGia = (decimal)t1.DonGia,
                                                                 ThueSuat = (decimal)t1.ThueSuat,
                                                                 TienThue = (decimal)t1.TienThue,
                                                                 SuatCK = (decimal)t1.SuatCK,
                                                                 TienCK = (decimal)t1.TienCK,
                                                                 ThanhTien = (decimal)t1.ThanhTien,
                                                                 //Name = t1.,
                                                             };
            return t0;
        }

        public static List<HoaDon_MuaCT> DanhSachChiTietPhieuNhapKho()
        {
            return DB.HoaDon_MuaCTs.ToList();
        }

        public static List<Temp_HoaDon_MuaCT> DanhSachChiTietPhieuNhapKhoTemp()
        {
            return DB.Temp_HoaDon_MuaCTs.ToList();
        }

        public static decimal SumSLChiTietPNK()
        {
            IQueryable<double?> t0 = from t1 in DB.Temp_HoaDon_MuaCTs select t1.SoLuong;
            if (!t0.Any())
            {
                return 0;
            }
            double? sum = t0.Sum();
            if (sum != null)
            {
                return (decimal)sum;
            }
            return 0;
        }

        public static decimal SumSLChiTietPNKTheoMa(int HDMID)
        {
            IQueryable<double?> t0 = from t1 in DB.HoaDon_MuaCTs where t1.HDMID == HDMID select t1.SoLuong;
            if (!t0.Any())
            {
                return 0;
            }
            double? sum = t0.Sum();
            if (sum != null)
            {
                return (decimal)sum;
            }
            return 0;
        }

        public static void ThemChiTietPhieuNhapKho(HoaDon_MuaCT _obj)
        {
            DB.HoaDon_MuaCTs.InsertOnSubmit(_obj);
            DB.SubmitChanges();
        }

        public static void ThemChiTietPhieuNhapKhoTemp(Temp_HoaDon_MuaCT _obj)
        {
            DB.Temp_HoaDon_MuaCTs.InsertOnSubmit(_obj);
            DB.SubmitChanges();
        }

        public static decimal TongTienChiTietPNK()
        {
            IQueryable<double?> t0 = from t1 in DB.Temp_HoaDon_MuaCTs select t1.ThanhTien;
            if (!t0.Any())
            {
                return 0;
            }
            double? sum = t0.Sum();
            if (sum != null)
            {
                return (decimal)sum;
            }
            return 0;
        }

        public static decimal TongTienChiTietPNKTheoMa(int HDMID)
        {
            IQueryable<double?> t0 = from t1 in DB.HoaDon_MuaCTs where t1.HDMID == HDMID select t1.ThanhTien;
            if (!t0.Any())
            {
                return 0;
            }
            double? sum = t0.Sum();
            if (sum != null)
            {
                return (decimal)sum;
            }
            return 0;
        }

        public static void Update()
        {
            DB.SubmitChanges();
        }

        public static void XoaChiTietPhieuNhapKho(int Id)
        {
            DB.HoaDon_MuaCTs.DeleteOnSubmit(DB.HoaDon_MuaCTs.Single(p => p.HDMCTID.Equals(Id)));
            DB.SubmitChanges();
        }

        public static void XoaChiTietPhieuNhapKhoTemp(int Id)
        {
            DB.Temp_HoaDon_MuaCTs.DeleteOnSubmit(DB.Temp_HoaDon_MuaCTs.Single(p => p.HDMCTID.Equals(Id)));
            DB.SubmitChanges();
        }

        #endregion
    }
}
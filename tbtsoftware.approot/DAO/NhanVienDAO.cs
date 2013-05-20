namespace MinhPham.Web.BepNhaBan.DAO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using bnb.approot.DAO;

    public class EmployeeDAO
    {
        #region Static Fields

        private static readonly BNBDataContext DB = new BNBDataContext(DBConnect.GetConnectionString());

        #endregion

        #region Public Methods and Operators

        public static IQueryable<EmployeeViewModel> DanhSachNhanVienFull()
        {
            var t0 = from t1 in DB.Employees
                                               let branchId = t1.BranchID
                                               where branchId != null
                                               join t2 in DB.Branches on branchId equals t2.ID
                                               join t3 in DB.Teams on t1.TeamID equals t3.ID
                                               let dateTime = t1.DOB
                                               where dateTime != null
                                               select
                                                   new EmployeeViewModel
                                                       {
                                                           EmployeeID = t1.ID,
                                                           TeamID = t1.TeamID,
                                                           ChiNhanhID = (int)branchId,
                                                           Alias = t1.Alias,
                                                           EmployeeName = t1.Name,
                                                           Position = t1.Position,
                                                           DOB = (DateTime)dateTime,
                                                           Gender = t1.Gender != null && (bool)t1.Gender,
                                                           CMTND = t1.CMTND,
                                                           QueQuan = t1.QueQuan,
                                                           Address = t1.Address,
                                                           Tel = t1.Tel,
                                                           Phone = t1.Phone,
                                                           GiaDinh = t1.GiaDinh,
                                                           LuongCoBan = (float)t1.LuongCoBan,
                                                           Email = t1.Email,
                                                           TheoDoi = (bool)t1.TheoDoi,
                                                           Name = t1.Note,
                                                           Created = (DateTime)t1.Created,
                                                           HinhAnh = t1.Picture,
                                                           BranchName = t2.Name,
                                                           TeamName = t3.Name,
                                                       };
            return t0;
        }

        public static List<Employee> Get()
        {
            return DB.Employees.ToList();
        }

        public static void Insert(Employee _obj)
        {
            DB.Employees.InsertOnSubmit(_obj);
            DB.SubmitChanges();
        }

        public static Employee Get(int Id)
        {
            return DB.Employees.First(p => p.ID.Equals(Id));
        }

        public static void Update()
        {
            DB.SubmitChanges();
        }

        public static void Delete(int Id)
        {
            DB.Employees.DeleteOnSubmit(DB.Employees.Single(p => p.ID.Equals(Id)));
            DB.SubmitChanges();
        }

        #endregion
    }
}
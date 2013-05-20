namespace MinhPham.Web.BepNhaBan.DAO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class MemberGroupDAO
    {
        #region Public Methods and Operators

        public static void Update()
        {
            BNBDataContext.Instance.SubmitChanges();
        }

        public static IQueryable<TBT_AdminFunctionGroup> DanhSachNhomChucNang()
        {
            return BNBDataContext.Instance.TBT_AdminFunctionGroups.OrderBy(p => p.FunctionGroupOrder);
        }

        public static IQueryable<TBT_AdminMemberGroupFunction> DanhSachQuyenHanNhomThanhVien()
        {
            return BNBDataContext.Instance.TBT_AdminMemberGroupFunctions;
        }

        public static IQueryable<TBT_AdminFunctionName> DanhSachTinhNang()
        {
            return BNBDataContext.Instance.TBT_AdminFunctionNames.OrderBy(p => p.FunctionOrder);
        }

        public static IQueryable DanhSachTinhNangChucNang(int function_Group_ID)
        {
            return from t1 in BNBDataContext.Instance.TBT_AdminFunctions
                   join t2 in BNBDataContext.Instance.TBT_AdminFunctionGroups on t1.Function_Group_ID equals t2.Function_Group_ID
                   join t3 in BNBDataContext.Instance.TBT_AdminFunctionNames on t1.FunctionName_ID equals t3.FunctionName_ID
                   where t2.Function_Group_ID == function_Group_ID
                   orderby t3.FunctionOrder
                   select
                       new
                           {
                               t1.Function_ID,
                               t1.FunctionCode,
                               t1.Function_Group_ID,
                               t1.FunctionDesc,
                               t1.FunctionName_ID,
                               t3.FunctionName,
                           };
        }

        public static IQueryable<TBT_AdminFunction> DanhSachTinhNangChucNang1(int function_Group_ID)
        {
            return from t1 in BNBDataContext.Instance.TBT_AdminFunctions
                   join t2 in BNBDataContext.Instance.TBT_AdminFunctionGroups on t1.Function_Group_ID equals t2.Function_Group_ID
                   join t3 in BNBDataContext.Instance.TBT_AdminFunctionNames on t1.FunctionName_ID equals t3.FunctionName_ID
                   where t2.Function_Group_ID == function_Group_ID
                   orderby t3.FunctionOrder
                   select t1;
        }

        public static void DeleteGroup(int id)
        {
            BNBDataContext.Instance.Roles.DeleteOnSubmit(
                BNBDataContext.Instance.Roles.Single<Role>(p => p.Group_ID.Equals(id)));
            BNBDataContext.Instance.SubmitChanges();
        }

        public static void DeleteGroupFunction(int groupId)
        {
            IQueryable<TBT_AdminMemberGroupFunction> qry = from t1 in BNBDataContext.Instance.TBT_AdminMemberGroupFunctions
                                                           where t1.Group_ID == groupId
                                                           select t1;

            BNBDataContext.Instance.TBT_AdminMemberGroupFunctions.DeleteAllOnSubmit(qry);
            BNBDataContext.Instance.SubmitChanges();
        }

        public static void InsertMember(User obj)
        {
            BNBDataContext.Instance.Users.InsertOnSubmit(obj);
            BNBDataContext.Instance.SubmitChanges();
        }

        public static Boolean KiemTraTonTaiTinhNangChucNang(int functionName_ID, int function_Group_ID)
        {
            if (
                BNBDataContext.Instance.TBT_AdminFunctions.Any(p => p.FunctionName_ID == functionName_ID && p.Function_Group_ID == function_Group_ID))
            {
                return true;
            }
            return false;
        }

        public static IQueryable LayDanhSachThanhVien()
        {
            var xx = from t1 in BNBDataContext.Instance.Users
                     join t2 in BNBDataContext.Instance.Roles on t1.Group_ID equals t2.Group_ID
                     orderby t1.UserName
                     select
                         new
                             {
                                 t1.UserName,
                                 t2.Group_ID,
                                 t2.GroupName,
                                 t1.FullName,
                                 t1.Phone,
                                 t1.Position,
                                 t1.CreateDate,
                                 t1.Active
                             };
            return xx;
        }

        public static TBT_AdminFunctionGroup LayNhomChucNangById(int Id)
        {
            return BNBDataContext.Instance.TBT_AdminFunctionGroups.Single(p => p.Function_Group_ID.Equals(Id));
        }

        public static int LayOrderSortTinhNang()
        {
            return (int)(from t1 in BNBDataContext.Instance.TBT_AdminFunctionNames select t1.FunctionOrder).Max();
        }

        public static User LayThanhVienTheoUsername(string Id)
        {
            return BNBDataContext.Instance.Users.Single<User>(p => p.UserName.Equals(Id));
        }

        public static TBT_AdminFunctionName LayTinhNangById(int Id)
        {
            return BNBDataContext.Instance.TBT_AdminFunctionNames.Single(p => p.FunctionName_ID.Equals(Id));
        }

        public static TBT_AdminFunction LayTinhNangChucNangById(int Id)
        {
            return BNBDataContext.Instance.TBT_AdminFunctions.Single(p => p.Function_ID.Equals(Id));
        }

        public static void ThemNhomChucNang(TBT_AdminFunctionGroup obj)
        {
            BNBDataContext.Instance.TBT_AdminFunctionGroups.InsertOnSubmit(obj);
            BNBDataContext.Instance.SubmitChanges();
        }

        public static void ThemNhomNguoiDung(Role obj)
        {
            BNBDataContext.Instance.Roles.InsertOnSubmit(obj);
            BNBDataContext.Instance.SubmitChanges();
        }

        public static void ThemTinhNang(TBT_AdminFunctionName obj)
        {
            BNBDataContext.Instance.TBT_AdminFunctionNames.InsertOnSubmit(obj);
            BNBDataContext.Instance.SubmitChanges();
        }

        public static void ThemTinhNangChucNang(TBT_AdminFunction obj)
        {
            BNBDataContext.Instance.TBT_AdminFunctions.InsertOnSubmit(obj);
            BNBDataContext.Instance.SubmitChanges();
        }

        public static string XoaNhomChucNang(int id)
        {
            try
            {
                BNBDataContext.Instance.TBT_AdminFunctionGroups.DeleteOnSubmit(
                    BNBDataContext.Instance.TBT_AdminFunctionGroups.Single(p => p.Function_Group_ID.Equals(id)));
                BNBDataContext.Instance.SubmitChanges();
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string XoaNhomThanhVien(int id)
        {
            try
            {
                BNBDataContext.Instance.Roles.DeleteOnSubmit(
                    BNBDataContext.Instance.Roles.Single<Role>(p => p.Group_ID.Equals(id)));
                BNBDataContext.Instance.SubmitChanges();
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string XoaThanhVien(string id)
        {
            try
            {
                BNBDataContext.Instance.Users.DeleteOnSubmit(
                    BNBDataContext.Instance.Users.Single<User>(p => p.UserName.Equals(id)));
                BNBDataContext.Instance.SubmitChanges();
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string XoaTinhNang(int id)
        {
            try
            {
                BNBDataContext.Instance.TBT_AdminFunctionNames.DeleteOnSubmit(
                    BNBDataContext.Instance.TBT_AdminFunctionNames.Single(p => p.FunctionName_ID.Equals(id)));
                BNBDataContext.Instance.SubmitChanges();
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static void XoaTinhNangByNhomThanhVien(int id)
        {
            foreach (
                TBT_AdminMemberGroupFunction t1 in BNBDataContext.Instance.TBT_AdminMemberGroupFunctions.Where(p => p.Group_ID.Equals(id)))
            {
                BNBDataContext.Instance.TBT_AdminMemberGroupFunctions.DeleteOnSubmit(t1);
            }
            BNBDataContext.Instance.SubmitChanges();
        }

        public static string XoaTinhNangChucNang(int id)
        {
            try
            {
                BNBDataContext.Instance.TBT_AdminFunctions.DeleteOnSubmit(BNBDataContext.Instance.TBT_AdminFunctions.Single(p => p.Function_ID.Equals(id)));
                BNBDataContext.Instance.SubmitChanges();
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static List<Role> getAllGroupName()
        {
            return BNBDataContext.Instance.Roles.OrderByDescending(p => p.GroupName).ToList<Role>();
        }

        public static List<User> getAllMemberName()
        {
            return BNBDataContext.Instance.Users.OrderByDescending(p => p.UserName).ToList<User>();
        }

        public static Role getGroupByID(int id)
        {
            return
                BNBDataContext.Instance.Roles.OrderByDescending(p => p.GroupName).Single(p => p.Group_ID == id);
        }

        #endregion
    }
}
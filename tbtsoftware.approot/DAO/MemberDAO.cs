namespace MinhPham.Web.BepNhaBan.DAO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class RoleDAO
    {
        public static void DeleteRole(int id)
        {
            BNBDataContext.Instance.Roles.DeleteOnSubmit(BNBDataContext.Instance.Roles.Single(p => p.Group_ID.Equals(id)));
            BNBDataContext.Instance.SubmitChanges();
        }

        public static List<Role> Get()
        {
            return BNBDataContext.Instance.Roles.OrderByDescending(p => p.GroupName).ToList();
        }


        public static Role Get(int id)
        {
            return BNBDataContext.Instance.Roles.OrderByDescending(p => p.GroupName).Single(p => p.Group_ID == id);
        }
    }

    public static class MemberDAO
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

        public static void Delete(string id)
        {
            BNBDataContext.Instance.Users.DeleteOnSubmit(BNBDataContext.Instance.Users.Single(p => p.UserName.Equals(id)));
            BNBDataContext.Instance.SubmitChanges();
        }

        public static void Insert(User obj)
        {
            BNBDataContext.Instance.Users.InsertOnSubmit(obj);
            BNBDataContext.Instance.SubmitChanges();
        }

        public static Boolean KiemTraTonTaiTinhNangChucNang(int functionName_ID, int function_Group_ID)
        {
            if (
                BNBDataContext.Instance.TBT_AdminFunctions.Any(
                    p => p.FunctionName_ID == functionName_ID && p.Function_Group_ID == function_Group_ID))
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
            int? max = (from t1 in BNBDataContext.Instance.TBT_AdminFunctionNames select t1.FunctionOrder).Max();
            if (max != null)
            {
                return (int)max;
            }
            return 0;
        }

        public static TBT_AdminFunctionName LayTinhNangById(int Id)
        {
            return BNBDataContext.Instance.TBT_AdminFunctionNames.Single(p => p.FunctionName_ID.Equals(Id));
        }

        public static TBT_AdminFunction LayTinhNangChucNangById(int Id)
        {
            return BNBDataContext.Instance.TBT_AdminFunctions.Single(p => p.Function_ID.Equals(Id));
        }

        public static List<User> Get()
        {
            return BNBDataContext.Instance.Users.OrderByDescending(p => p.UserName).ToList();
        }

        public static User Get(string Id)
        {
            return BNBDataContext.Instance.Users.Single(p => p.UserName.Equals(Id));
        }


        #endregion
    }
}
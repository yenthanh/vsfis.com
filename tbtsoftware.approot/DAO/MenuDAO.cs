namespace MinhPham.Web.BepNhaBan.DAO
{
    using System.Collections.Generic;
    using System.Linq;

    using bnb.approot.DAO;

    public static class MenuDAO
    {
        #region Public Properties

        public static int GetRoot
        {
            get
            {
                return BNBDataContext.Instance.Menus.First(o => o.ParentId == 0).Id;
            }
        }

        #endregion

        #region Public Methods and Operators

        public static List<Menu> Get(int pId)
        {
            return
                BNBDataContext.Instance.Menus.Where(p => p.IsDelete.Equals(false) && p.Id.Equals(pId))
                  .OrderByDescending(p => p.OrderSort)
                  .ToList();
        }

        public static Menu Find(int pId)
        {
            return
                BNBDataContext.Instance.Menus.FirstOrDefault(p => p.IsDelete.Equals(false) && p.Id.Equals(pId));
        }

        public static List<Menu> GetChild(int pId)
        {
            return
                BNBDataContext.Instance.Menus.Where(p => p.IsDelete.Equals(false) && p.IsDisplay == true && p.ParentId.Equals(pId))
                  .OrderByDescending(p => p.OrderSort)
                  .ToList();
        }

        public static List<MenuForListBox> GetHierarchyMenu(int parentID, int level)
        {
            var rs = new List<MenuForListBox>();
            var parentMenuColl =
                BNBDataContext.Instance.Menus.Where(p => p.IsDelete.Equals(false) && p.ParentId == parentID)
                  .OrderBy(p => p.OrderSort)
                  .ToList();
            foreach (var item in parentMenuColl)
            {
                var cflbit = new MenuForListBox(item.Id, item.Name) { ImgSrc = item.ImgSrc, Link = item.Link };
                var tstr = "";
                if (level > 0)
                {
                    tstr = "└------";

                    for (int i = 1; i < level; i++)
                    {
                        tstr += "------";
                    }
                }
                cflbit.Name = tstr + item.Name;

                cflbit.Descript = item.Descript;
                if (item.OrderSort != null)
                {
                    cflbit.OrderSort = (int)item.OrderSort;
                }
                if (item.IsDelete != null)
                {
                    cflbit.IsDelete = (bool)item.IsDelete;
                }
                if (item.IsDisplay != null)
                {
                    cflbit.IsDisplay = (bool)item.IsDisplay;
                }

                rs.Add(cflbit);
                var crs = GetHierarchyMenu(item.Id, level + 1);
                rs.AddRange(crs);
            }
            return rs;
        }

        public static void Save(Menu pObj)
        {
            BNBDataContext.Instance.Menus.InsertOnSubmit(pObj);
            BNBDataContext.Instance.SubmitChanges();
        }

        public static void Update()
        {
            BNBDataContext.Instance.SubmitChanges();
        }

        #endregion
    }
}
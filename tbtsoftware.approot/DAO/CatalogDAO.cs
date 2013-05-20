using System.Collections.Generic;
using System.Linq;
using bnb.approot.DAO;

namespace MinhPham.Web.BepNhaBan.DAO
{
    public class CatalogDAO
    {
        #region Public Properties

        public static string GetRoot
        {
            get
            {
                return BNBDataContext.Instance.Catalogs.First(o => o.ParentID == "0").ID;
            }
        }

        #endregion

        #region Public Methods and Operators

        public static void Delete(string Id)
        {
            foreach (Catalog t1 in BNBDataContext.Instance.Catalogs)
            {
                if (t1.ParentID == Id)
                {
                    Delete(t1.ID);
                }
            }
            BNBDataContext.Instance.Catalogs.DeleteOnSubmit(
                BNBDataContext.Instance.Catalogs.Single(p => p.ID.Equals(Id)));
            BNBDataContext.Instance.SubmitChanges();
        }

        public static List<Catalog> Get()
        {
            return
                BNBDataContext.Instance.Catalogs.Where(p => p.IsDelete == false && p.ID != GetRoot)
                              .OrderBy(p => p.Name)
                              .ToList();
        }

        public static List<CategoryForListBox> GetHierarchyCategory(string parentID, int level)
        {
            var rs = new List<CategoryForListBox>();

            List<Catalog> rootCategories =
                BNBDataContext.Instance.Catalogs.Where(p => p.IsDelete.Equals(false) && p.ParentID == parentID)
                              .OrderBy(p => p.OrderSort)
                              .ToList();
            foreach (Catalog ctit in rootCategories)
            {
                var cflbit = new CategoryForListBox(ctit.ID, ctit.Name);
                if (level > 0)
                {
                    string tstr = "└------";

                    for (int i = 1; i < level; i++)
                    {
                        tstr += "------";
                    }
                    cflbit.Name = tstr + ctit.Name;
                    cflbit.Description = ctit.Description;
                    if (ctit.OrderSort != null)
                    {
                        cflbit.OrderSort = (int)ctit.OrderSort;
                    }
                    if (ctit.IsDelete != null)
                    {
                        cflbit.IsDelete = (bool)ctit.IsDelete;
                    }
                    if (ctit.IsDisplay != null)
                    {
                        cflbit.IsDisplay = (bool)ctit.IsDisplay;
                    }
                }
                rs.Add(cflbit);
                List<CategoryForListBox> crs = GetHierarchyCategory(ctit.ID, level + 1);
                rs.AddRange(crs);
            }
            return rs;
        }

        public static List<string> GetListIDHierarchyCategory(string parentID)
        {
            var rs = new List<string>();
            List<Catalog> rootCategories =
                BNBDataContext.Instance.Catalogs.Where(p => p.IsDelete.Equals(false) && p.ParentID == parentID)
                              .OrderBy(p => p.OrderSort)
                              .ToList();
            foreach (Catalog ctit in rootCategories)
            {
                rs.Add(ctit.ID);
                List<string> crs = GetListIDHierarchyCategory(ctit.ID);
                rs.AddRange(crs);
            }
            return rs;
        }

        #endregion
    }
}
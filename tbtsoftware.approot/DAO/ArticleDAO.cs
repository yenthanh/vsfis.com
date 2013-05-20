using System;
using System.Collections.Generic;
using System.Linq;

namespace MinhPham.Web.BepNhaBan.DAO
{
    public class ArticleDAO
    {
        #region Public Methods and Operators

        public static Boolean Any(int pID)
        {
            if (BNBDataContext.Instance.Articles.Any(p => p.Id.Equals(pID)))
            {
                return true;
            }
            return false;
        }

        public static Boolean Any(string pAlias)
        {
            if (BNBDataContext.Instance.Partners.Any(p => p.Alias.Equals(pAlias)))
            {
                return true;
            }
            return false;
        }

        public static int Count()
        {
            return BNBDataContext.Instance.Articles.Count();
        }

        public static void Delete(int pId)
        {
            BNBDataContext.Instance.Articles.DeleteOnSubmit(
                BNBDataContext.Instance.Articles.Single(p => p.Id.Equals(pId)));
            BNBDataContext.Instance.SubmitChanges();
        }

        public static Article Find(int pID)
        {
            return BNBDataContext.Instance.Articles.First(p => p.Id.Equals(pID));
        }

        public static List<Article> Get()
        {
            var x = BNBDataContext.Instance.Articles.ToList();
            return x;
        }

        public static void Insert(Article pNew)
        {
            BNBDataContext.Instance.Articles.InsertOnSubmit(pNew);
            BNBDataContext.Instance.SubmitChanges();
        }

        public static void Update()
        {
            BNBDataContext.Instance.SubmitChanges();
        }

        #endregion
    }
}
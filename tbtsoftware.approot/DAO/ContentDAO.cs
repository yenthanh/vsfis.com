using System;
using System.Collections.Generic;
using System.Linq;

namespace MinhPham.Web.BepNhaBan.DAO
{
    public class ContentDAO
    {
        #region Public Methods and Operators

        public static Boolean Any(int pID)
        {
            if (BNBDataContext.Instance.Contents.Any(p => p.Id.Equals(pID)))
            {
                return true;
            }
            return false;
        }

        public static int Count()
        {
            return BNBDataContext.Instance.Contents.Count();
        }

        public static void Delete(int pId)
        {
            BNBDataContext.Instance.Contents.DeleteOnSubmit(
                BNBDataContext.Instance.Contents.Single(p => p.Id.Equals(pId)));
            BNBDataContext.Instance.SubmitChanges();
        }

        public static Content Find(int pID)
        {
            return BNBDataContext.Instance.Contents.First(p => p.Id.Equals(pID));
        }

        public static Content Find(string pTitle)
        {
            return BNBDataContext.Instance.Contents.First(p => p.Title.Equals(pTitle));
        }


        public static List<Content> Get()
        {
            var x = BNBDataContext.Instance.Contents.ToList();
            return x;
        }

        public static void Insert(Content pNew)
        {
            BNBDataContext.Instance.Contents.InsertOnSubmit(pNew);
            BNBDataContext.Instance.SubmitChanges();
        }

        public static void Update()
        {
            BNBDataContext.Instance.SubmitChanges();
        }

        #endregion
    }
}
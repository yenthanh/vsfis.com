using System;
using System.Collections.Generic;
using System.Linq;

namespace MinhPham.Web.BepNhaBan.DAO
{
    public class ServiceDAO
    {
        #region Public Methods and Operators

        public static Boolean Any(int pID)
        {
            if (BNBDataContext.Instance.Services.Any(p => p.Id.Equals(pID)))
            {
                return true;
            }
            return false;
        }

        public static Boolean Any(string pAlias)
        {
            if (BNBDataContext.Instance.Services.Any(p => p.Name.Equals(pAlias)))
            {
                return true;
            }
            return false;
        }

        public static int Count()
        {
            return BNBDataContext.Instance.Services.Count();
        }

        public static void Delete(int pId)
        {
            BNBDataContext.Instance.Services.DeleteOnSubmit(
                BNBDataContext.Instance.Services.Single(p => p.Id.Equals(pId)));
            BNBDataContext.Instance.SubmitChanges();
        }
       
        public static Service Find(int pID)
        {
            return BNBDataContext.Instance.Services.First(p => p.Id.Equals(pID));
        }

        public static Service Find(string name)
        {
            return BNBDataContext.Instance.Services.FirstOrDefault(p => p.Name.Equals(name));
        }


        public static List<Service> Get()
        {
            var x = BNBDataContext.Instance.Services.ToList();
            return x;
        }

        public static void Insert(Service pNew)
        {
            BNBDataContext.Instance.Services.InsertOnSubmit(pNew);
            BNBDataContext.Instance.SubmitChanges();
        }

        public static void Update()
        {
            BNBDataContext.Instance.SubmitChanges();
        }

        #endregion
    }
}
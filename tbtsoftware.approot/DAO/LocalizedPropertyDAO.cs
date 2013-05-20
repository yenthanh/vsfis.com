using System.Collections.Generic;
using System.Linq;

namespace MinhPham.Web.BepNhaBan.DAO
{
    public class LocalizedPropertyDAO
    {
        public static List<LocalizedProperty> Get(int entityId)
        {
            return BNBDataContext.Instance.LocalizedProperties.Where(o => o.EntityId == entityId).ToList();
        }

        public static LocalizedProperty Find(int entityId, int languageId, string localeKeyGroup, string localKey)
        {
            return BNBDataContext.Instance.LocalizedProperties.FirstOrDefault(o => o.EntityId == entityId && o.LanguageId == languageId && o.LocaleKeyGroup == localeKeyGroup && o.LocaleKey == localKey);
        }

        public static void Insert(LocalizedProperty pNew)
        {
            BNBDataContext.Instance.LocalizedProperties.InsertOnSubmit(pNew);
            BNBDataContext.Instance.SubmitChanges();
        }
    }
}
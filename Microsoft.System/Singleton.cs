using System;
using System.Reflection;
using log4net;

namespace MinhPham.Core.Common
{
    public static class Singleton<TClass>
        where TClass : class
    {
        // ReSharper disable StaticFieldInGenericType

        #region Static Fields

        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private static readonly object SyncObject = new object();

        private static volatile TClass _instance;

        #endregion

        #region Constructors and Destructors

        static Singleton()
        {
            // ReSharper restore EmptyConstructor
            // Explicit static constructor to tell C# compiler not to mark type as beforefieldinit
        }

        #endregion

        #region Public Properties

        public static TClass Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncObject)
                    {
                        if (_instance == null)
                        {
                            Log.Debug("Creating singleton instanse for: " + typeof(TClass).FullName);
                            _instance = (TClass)Activator.CreateInstance(typeof(TClass), true);
                        }
                    }
                }

                return _instance;
            }

            set
            {
                lock (SyncObject)
                {
                    _instance = value;
                }
            }
        }

        #endregion
    }
}
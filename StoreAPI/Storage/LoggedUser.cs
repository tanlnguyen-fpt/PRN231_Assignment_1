using DataAccess.DTO;

namespace StoreAPI.Storage
{
    internal class LoggedUser
    {
        private static LoggedUser instance = null;
        private static readonly object iLock = new object();
        public LoggedUser()
        {

        }

        public static LoggedUser Instance
        {
            get
            {
                lock (iLock)
                {
                    if (instance == null)
                    {
                        instance = new LoggedUser();
                    }
                    return instance;
                }
            }
        }
        public MemberDTO User { get; set; }
    }
}

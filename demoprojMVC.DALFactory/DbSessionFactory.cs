using System.Runtime.Remoting.Messaging;
using demoprojMVC.IDAL;

namespace demoprojMVC.DALFactory
{
    public class DbSessionFactory
    {
        public static IDbSession GetCurrentDbSession()
        {
            IDbSession dbSession = CallContext.GetData("DbSession") as IDbSession;
            if (dbSession == null)
            {
                dbSession = new DbSession();
                CallContext.SetData("DbSession",dbSession);
            }
            return dbSession;

        }
    }
}
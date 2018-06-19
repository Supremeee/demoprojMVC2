using System.Data.Entity;
using System.Runtime.Remoting.Messaging;
using demoprojMVC.Model;

namespace demoprojMVC.EFDAL
{
    public class DbContextFactory
    {
        public static DbContext GetCurrentDbContext()
        {
            //一次请求共用一个实例，上下文都可以做到切换
            DbContext db = CallContext.GetData("DbContext") as DbContext;
            if (db == null)
            {
                db = new DataModelContainer();
                CallContext.SetData("DbContext",db);
            }
            return db;
        }
    }
}
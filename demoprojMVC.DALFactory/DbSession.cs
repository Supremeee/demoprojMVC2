using System;
using demoprojMVC.EFDAL;
using demoprojMVC.IDAL;

namespace demoprojMVC.DALFactory
{
    public partial class DbSession : IDbSession
    {
        
        public int SaveChanges()
        {
            return DbContextFactory.GetCurrentDbContext().SaveChanges();
        }
    }
}
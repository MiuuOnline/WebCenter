using System.Data.Entity;

namespace Fs.Data.Database
{
    public class DbContextFactory : IDbContextFactory
    {
        private readonly DbContext _context;

        public DbContextFactory()
        {
            // the context is new()ed up instead of being injected to avoid direct dependency on EF
            // not sure if this is good approach...but it removes direct dependency on EF from web tier
            _context = new DbContext(new FsContext(), false);
        }

        public DbContext GetDbContext()
        {
            return _context;
        }

        // see comment in IDbContextFactory inteface...
        //public void Dispose()
        //{
        //    if (_context != null)
        //    {
        //        _context.Dispose();
        //        GC.SuppressFinalize(this);
        //    }
        //}
    }
}

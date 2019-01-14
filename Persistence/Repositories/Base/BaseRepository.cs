using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace CloseTalk.Persistence.Repositories.Base
{
    public abstract class BaseRepository<T> : IDisposable
        where T : class, new()
    {

        protected readonly AppDbContext Context;
        protected readonly DbSet<T> EntitySet;


        public BaseRepository(AppDbContext context)
        {
            Context = context;
            EntitySet = Context.Set<T>();
        }

        internal protected async Task<int> SaveChanges()
        {
            try
            {
                return await Context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region IDisposable Support

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Context.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion

    }
}

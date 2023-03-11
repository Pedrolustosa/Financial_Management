using Domain.Interfaces.Generics;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace Infrastructure.Repository.Generics
{
    public class GenericsRepository<T> : IGeneric<T>, IDisposable where T : class
    {
        private readonly DbContextOptions<ContextDB> _optionsBuilder;

        public GenericsRepository()
        {
            _optionsBuilder = new DbContextOptions<ContextDB>();
        }

        public async Task Add(T Item)
        {
            using (var data = new ContextDB(_optionsBuilder))
            {
                await data.Set<T>().AddAsync(Item);
                await data.SaveChangesAsync();
            }
        }

        public async Task Delete(T Item)
        {
            using (var data = new ContextDB(_optionsBuilder))
            {
                data.Set<T>().Remove(Item);
                await data.SaveChangesAsync();
            }
        }

        public async Task<T?> GetEntityById(int Id)
        {
            using (var data = new ContextDB(_optionsBuilder))
            {
                return await data.Set<T>().FindAsync(Id);
            }
        }

        public async Task<List<T>> List()
        {
            using (var data = new ContextDB(_optionsBuilder))
            {
                return await data.Set<T>().ToListAsync();
            }
        }

        public async Task Update(T Item)
        {
            using (var data = new ContextDB(_optionsBuilder))
            {
                data.Set<T>().Update(Item);
                await data.SaveChangesAsync();
            }
        }

        #region Disposed https://docs.microsoft.com/pt-br/dotnet/standard/garbage-collection/implementing-dispose
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);



        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            disposed = true;
        }
        #endregion
    }
}

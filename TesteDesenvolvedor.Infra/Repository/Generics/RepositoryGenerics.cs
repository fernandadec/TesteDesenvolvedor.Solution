using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using SendGrid.Helpers.Mail;
using System.Runtime.InteropServices;
using TesteDesenvolvedor.Infra.Context;
using TesteDesenvolvedor.Services.Interfaces.Generics;

namespace TesteDesenvolvedor.Infra.Repository.Generics
{
    public class RepositoryGenerics<T> : IGeneric<T>, IDisposable where T : class
    {
        private readonly DbContextOptions<TextSqlContext> _OptionsBuilder;

        public RepositoryGenerics()
        {
            _OptionsBuilder = new DbContextOptions<TextSqlContext>();
        }

        public async Task Add(T Objeto)
        {
            using (var data = new TextSqlContext(_OptionsBuilder))
            {
                await data.Set<T>().AddAsync(Objeto);
                await data.SaveChangesAsync();
            }
        }

        public async Task Delete(T Objeto)
        {
            using (var data = new TextSqlContext(_OptionsBuilder))
            {
                data.Set<T>().Remove(Objeto);
                await data.SaveChangesAsync();
            }
        }

        public async Task<T> GetEntityById(int Id)
        {
            using (var data = new TextSqlContext(_OptionsBuilder))
            {
                return await data.Set<T>().FindAsync(Id);
            }
        }
        public async Task<List<T>> List()
        {
            using (var data = new TextSqlContext(_OptionsBuilder))
            {
                return await data.Set<T>().ToListAsync();
            }
        }

        public async Task Update(T Objeto)
        {
            using (var data = new TextSqlContext(_OptionsBuilder))
            {
                data.Set<T>().Update(Objeto);
                await data.SaveChangesAsync();
            }
        }

        bool disposed = false;
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

            }

            disposed = true;
        }


    }
}

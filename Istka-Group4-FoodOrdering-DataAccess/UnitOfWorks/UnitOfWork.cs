using Istka_Group4_FoodOrdering_DataAccess.Contexts;
using Istka_Group4_FoodOrdering_DataAccess.Repositories;
using Istka_Group4_FoodOrdering_Entity.Repositories;
using Istka_Group4_FoodOrdering_Entity.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Wissen.Istka.BlogProject.App.DataAccess.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FoodDbContext _context;
        private bool disposed = false;
        public UnitOfWork(FoodDbContext context)
        {
            _context = context;
        }

        public IRepository<T> GetRepository<T>() where T : class, new()
        {
            return new Repository<T>(_context);
        }
        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);  //Garbage collector u güncelleyip , bu takibi keser. Yani yazılımcı istediği zaman bu methodu kullanarak dispose edebilir. 
        }


    }
}

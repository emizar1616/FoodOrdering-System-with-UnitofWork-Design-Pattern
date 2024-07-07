using Istka_Group4_FoodOrdering_Entity.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Istka_Group4_FoodOrdering_Entity.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : class, new();
        void Commit(); //İçine SaveChanges(); geliyor 
        Task CommitAsync(); // Bu da savechanges ın asenkron olanını çağırmak içindir.
    }
}

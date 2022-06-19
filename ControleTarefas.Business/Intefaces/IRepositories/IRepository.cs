using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ControleTarefas.Business.Intefaces.IRepositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        Task Insert(TEntity entity);
        void Add(TEntity entity);
        Task<TEntity> GetById(int id);
        Task<List<TEntity>> GetAll();
        Task Update(TEntity entity);
        Task Delete(TEntity t);
        Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> predicate);
        Task<int> SaveChanges();
        int SaveChanges_();

    }
}

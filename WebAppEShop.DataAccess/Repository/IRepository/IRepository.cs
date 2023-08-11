using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebAppEShop.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        //T - Generic Class e.g. CategoryModelClass
        IEnumerable<T> GetAll(string? includeProperties = null); //T GetFirstOrDefault();
        T Get(Expression<Func<T, bool>> filter, string? includeProperties = null);
        void Add(T entity);
        //void Update(T entity);// video tutorial skip update bcoz condition changes
        void Delete(T entity); // void DeleteAll();
        void DeleteRange(IEnumerable<T> entity);
        //void Save();
    }
}

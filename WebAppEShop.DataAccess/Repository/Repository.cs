using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebAppEShop.DataAccess.Data;
using WebAppEShop.DataAccess.Repository.IRepository;

namespace WebAppEShop.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContextClass _applicationDbContextClass;
        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContextClass applicationDbContextClass)
        {
            _applicationDbContextClass = applicationDbContextClass;
            this.dbSet = _applicationDbContextClass.Set<T>();
            //_applicationDbContextClass.CategoriesTableName = dbSet; <- above line mean
            //_applicationDbContextClass.CategoriesTableName.Add(); isEqual ->*
            //dbSet.Add(); *<-
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            //IQueryable<T> query = dbSet.Where(filter); //*<-Same 1 as below same 2
            IQueryable<T> query = dbSet; //*<-same 2
            query = query.Where(filter); //*<-same 2
            return query.FirstOrDefault()!; //*<- GreenLineError:
            /*ToResolve GreenLineError: Possible null reference return &
            Exception: ArgumentNullException Solve: add NullCheck ! ->
                ->return query.FirstOrDefault()!;*/
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();//sometime error occured return query.ToList()!;

        }
    }
}

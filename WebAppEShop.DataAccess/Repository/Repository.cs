using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
            _applicationDbContextClass.ProductTableName.Include(item => item.CategoryModelClass)
                .Include(item => item.CategoryId);
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

        public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            //IQueryable<T> query = dbSet.Where(filter); //*<-Same 1 as below same 2
            IQueryable<T> query = dbSet; //*<-same 2
            query = query.Where(filter); //*<-same 2
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var itemIncludeProperties in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(itemIncludeProperties);
                }
            }
            return query.FirstOrDefault()!; //*<- GreenLineError:
            /*ToResolve GreenLineError: Possible null reference return &
            Exception: ArgumentNullException Solve: add NullCheck ! ->
                ->return query.FirstOrDefault()!;*/
        }
        //Category,CoverType // i change it to CategoryModelClass,CategoryId (1st,2nd) 
        public IEnumerable<T> GetAll(string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            //if(includeProperties != null) //generic
            if (!string.IsNullOrEmpty(includeProperties)) //more generic
            {
                foreach (var itemIncludeProperties in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(itemIncludeProperties);
                }
            }
            return query.ToList();//sometime error occured return query.ToList()!;

        }
    }
}

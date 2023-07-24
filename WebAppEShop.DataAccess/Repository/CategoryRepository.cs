using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppEShop.DataAccess.Data;
using WebAppEShop.DataAccess.Repository.IRepository;
using WebAppEShop.Model.Models;

namespace WebAppEShop.DataAccess.Repository
{
    public class CategoryRepository : Repository<CategoryModelClass>, ICategoryRepository
    {
        private readonly ApplicationDbContextClass _applicationDbContextClass;
        public CategoryRepository(ApplicationDbContextClass applicationDbContextClass) : base(applicationDbContextClass)
        {
            _applicationDbContextClass = applicationDbContextClass;
        }

        /*public void Save()
        {
            //_applicationDbContextClass.SaveChanges();
            //i transfer this Save(); to UnitOfWorkRepository class
        }*/

        public void Update(CategoryModelClass categoryModelClass)
        {
            _applicationDbContextClass.Update(categoryModelClass);
        }
    }
}

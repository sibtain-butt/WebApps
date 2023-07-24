using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppEShop.DataAccess.Data;
using WebAppEShop.DataAccess.Repository.IRepository;

namespace WebAppEShop.DataAccess.Repository
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {

        private readonly ApplicationDbContextClass _applicationDbContextClass;
        public ICategoryRepository CategoryRepository { get; private set; }

        public IProductRepository ProductRepository { get; private set; }

        public UnitOfWorkRepository(ApplicationDbContextClass applicationDbContextClass)
        {
            _applicationDbContextClass = applicationDbContextClass;
            CategoryRepository = new CategoryRepository(_applicationDbContextClass);
            ProductRepository = new ProductRepository(_applicationDbContextClass);
        }

        

        public void Save()
        {
            _applicationDbContextClass.SaveChanges();
        }
    }
}

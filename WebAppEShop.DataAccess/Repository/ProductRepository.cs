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
    public class ProductRepository : Repository<ProductModelClass>, IProductRepository
    {
        private readonly ApplicationDbContextClass _applicationDbContext;
        public ProductRepository(ApplicationDbContextClass applicationDbContextClass) : base(applicationDbContextClass)
        {
            _applicationDbContext = applicationDbContextClass;
        }

        public void Update(ProductModelClass productModelClass)
        {
            _applicationDbContext.Update(productModelClass);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppEShop.DataAccess.Data;
using WebAppEShop.DataAccess.Repository.IRepository;
using WebAppEShop.Model.Models;
using WebAppEShop.Model.Models.ViewModels;

namespace WebAppEShop.DataAccess.Repository
{
    public class ProductRepository : Repository<ProductModelClass>, IProductRepository
    {
        private readonly ApplicationDbContextClass _applicationDbContext;
        public ProductRepository(ApplicationDbContextClass applicationDbContextClass) : base(applicationDbContextClass)
        {
            _applicationDbContext = applicationDbContextClass;
        }

        //public new void Add(ProductModelClass productModelClass)
        //{
        //    //_applicationDbContext.Add(productModelClass);

        //    //explicitly update every single entities in object[productModelClass] 
        //    //var productModelClassFromDb = _applicationDbContext.ProductTableName.FirstOrDefault(item => item.Id == productModelClass.Id);
        //    var productModelClassFromDb = _applicationDbContext.ProductTableName.Add(productModelClass);
        //    if (productModelClassFromDb != null)
        //    {
        //        productModelClassFromDb.Entity.Title = productModelClass.Title;
        //        productModelClassFromDb.Entity.Description = productModelClass.Description;
        //        productModelClassFromDb.Entity.Author = productModelClass.Author;
        //        productModelClassFromDb.Entity.ISBN = productModelClass.ISBN;
        //        productModelClassFromDb.Entity.Price = productModelClass.Price;
        //        productModelClassFromDb.Entity.Price50 = productModelClass.Price50;
        //        productModelClassFromDb.Entity.Price100 = productModelClass.Price100;
        //        productModelClassFromDb.Entity.ListPrice = productModelClass.ListPrice;
        //        productModelClassFromDb.Entity.CategoryId = productModelClass.CategoryId;

        //        if (productModelClass.ImageUrl == null)
        //        {
        //            productModelClassFromDb.Entity.ImageUrl = "You didnot upload any Image";
        //        }
        //    }

        //}

        public void Update(ProductModelClass productModelClass)
        {
            /*update single entity in object[productModelClass] will update
            all entities For e.g. updating title will also update empty ImageUrl field*/
            //_applicationDbContext.Update(productModelClass);

            //explicitly update every single entities in object[productModelClass] 
            var productModelClassFromDb = _applicationDbContext.ProductTableName.FirstOrDefault(item => item.Id == productModelClass.Id);
            if(productModelClassFromDb != null)
            {
                productModelClassFromDb.Title = productModelClass.Title;
                productModelClassFromDb.Description = productModelClass.Description;
                productModelClassFromDb.Author = productModelClass.Author;
                productModelClassFromDb.ISBN = productModelClass.ISBN;
                productModelClassFromDb.Price = productModelClass.Price;
                productModelClassFromDb.Price50 = productModelClass.Price50;
                productModelClassFromDb.Price100 = productModelClass.Price100;
                productModelClassFromDb.ListPrice = productModelClass.ListPrice;                
                productModelClassFromDb.CategoryId = productModelClass.CategoryId;

                if(productModelClass.ImageUrl != null)
                {
                    productModelClassFromDb.ImageUrl = productModelClass.ImageUrl;
                }
            }
        }

        //public void Update(ProductViewModel productViewModel)
        //{
        //    _applicationDbContext.Update(productViewModel);
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppEShop.DataAccess.Repository.IRepository
{
    public interface IUnitOfWorkRepository
    {
        //here we will have ALL the Repositories like ICategoryRepository, IProductRepository...
        ICategoryRepository CategoryRepository { get; }
        IProductRepository ProductRepository { get; }

        /*we will implement the Global Method here like Save();
        that's why we Making IUnitOfWorkRepository*/
        void Save();
        
    }
}

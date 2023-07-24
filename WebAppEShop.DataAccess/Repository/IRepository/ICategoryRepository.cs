using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppEShop.Model.Models;

namespace WebAppEShop.DataAccess.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<CategoryModelClass>
    {
        void Update(CategoryModelClass categoryModelClass);
        //void Save(); //i transfer this Save(); to IUnitOfWorkRepository interface
    }
}

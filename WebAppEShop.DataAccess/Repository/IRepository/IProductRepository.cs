﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppEShop.Model.Models;
using WebAppEShop.Model.Models.ViewModels;

namespace WebAppEShop.DataAccess.Repository.IRepository
{
    public interface IProductRepository : IRepository<ProductModelClass>
    {
        //void Add(ProductViewModel productViewModel);
        new void Add(ProductModelClass productModelClass);
        //void Update(ProductViewModel productViewModel);
        void Update(ProductModelClass productModelClass);
        //void Save(); //i transfer this Save(); to IUnitOfWorkRepository interface
    }
}

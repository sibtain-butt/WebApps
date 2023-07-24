using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppEShop.Model.Models.ViewModels
{
    public class ProductViewModel
    {
        public ProductModelClass? ProductModelClass { get; set; }
        public IEnumerable<SelectListItem>? SelectListItemCategoryModelList { get; set; }
    }
}

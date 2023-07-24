using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebAppEShop.DataAccess.Data;
using WebAppEShop.DataAccess.Repository;
using WebAppEShop.DataAccess.Repository.IRepository;
using WebAppEShop.Model.Models;
using WebAppEShop.Model.Models.ViewModels;

namespace WebAppEShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        //private readonly ApplicationDbContextClass _applicationDbContextClass;
        //private readonly IProductRepository _iProductRepository;
        private readonly IUnitOfWorkRepository _iUnitOfWorkRepository;

        public ProductController(IUnitOfWorkRepository iUnitOfWorkRepository)
        {
            //_iProductRepository = iProductRepository;
            _iUnitOfWorkRepository = iUnitOfWorkRepository;
        }


        public IActionResult Index()
        {
            //List<ProductModelClass> objProductList = _applicationDbContextClass.CategoriesTableName.ToList();
            //List<ProductModelClass> objProductList = _iProductRepository.GetAll().ToList();
            List<ProductModelClass> objProductList = _iUnitOfWorkRepository.ProductRepository.GetAll().ToList();

            return View(objProductList);
        }


        //when leave it blank then it's by default Get Method => [HttpGet]
        public IActionResult Create()
        {
            //below codes are in WebAppEShop.Model.Models.ViewModels
            /*//========== ==> Method 1 using ViewBag & ViewData <== ==========//
            IEnumerable<SelectListItem> selectListItemCategoryModelList = _iUnitOfWorkRepository.
                CategoryRepository.GetAll().Select(item => new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString(),
                });
            //========== ==> ViewBag <== ==========// ViewBag.KeyName = KeyValue;
            ViewBag.SelectListItemCategory = selectListItemCategoryModelList;
            //========== ==> ViewData <== =========// ViewData["KeyName"] = KeyValue; TypeCast needed
            ViewData["SelectListItemCategory"] = selectListItemCategoryModelList;*/

            //========== ==> Method 2 using ProductViewModel <== ==========//
            ProductViewModel productViewModel = new()
            {
                SelectListItemCategoryModelList = _iUnitOfWorkRepository.CategoryRepository.GetAll()
                .Select(item => new SelectListItem { Text = item.Name, Value = item.Id.ToString() }),
                ProductModelClass = new ProductModelClass()
            };

            return View(productViewModel);
        }

        [HttpPost]
        public IActionResult Create(ProductViewModel productViewModel)
        {
            /*if (ProductModelClass.Name == ProductModelClass.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name");
            }*/
            if (ModelState.IsValid)
            {
                /*_applicationDbContextClass.CategoriesTableName.Add(ProductModelClass);
                _applicationDbContextClass.SaveChanges();*/
                /*_iProductRepository.Add(ProductModelClass);
                _iProductRepository.Save();*/
                _iUnitOfWorkRepository.ProductRepository.Add(productViewModel);
                _iUnitOfWorkRepository.Save();
                TempData["tempDataKeySuccess"] = "Product added successfully";
                return RedirectToAction("Index");
            }
            else
            {
                productViewModel.SelectListItemCategoryModelList = _iUnitOfWorkRepository.CategoryRepository.GetAll()
                .Select(item => new SelectListItem { Text = item.Name, Value = item.Id.ToString() });
                    //ProductModelClass = new ProductModelClass()

                };

            return View(productViewModel);
        }
        //}
        //    return View();
    }


    //when leave it blank then it's by default Get Method => [HttpGet]
    public IActionResult Edit(int? productId)
    {
        if (productId == null || productId == 0)
        {
            return NotFound();
        }
        //ProductModelClass? ProductModelClassFromDb = _applicationDbContextClass.CategoriesTableName.Find(ProductId);
        //ProductModelClass? ProductModelClassFromDb = _iProductRepository.Get(item => item.Id == ProductId);
        ProductModelClass? productModelClassFromDb = _iUnitOfWorkRepository.ProductRepository.Get(item => item.Id == productId);
        /*ProductModelClass? ProductModelClassFromDb1 = _applicationDbContextClass.CategoriesTableName.FirstOrDefault(item => item.Id == id);
        ProductModelClass? ProductModelClassFromDb2 = _applicationDbContextClass.CategoriesTableName.Where(item => item.Id == id).FirstOrDefault();*/
        if (productModelClassFromDb == null)
        {
            return NotFound();
        }

        return View(productModelClassFromDb);
    }
    [HttpPost]
    public IActionResult Edit(ProductModelClass productModelClass)
    {
        if (ModelState.IsValid)
        {
            //_applicationDbContextClass.CategoriesTableName.Add(ProductModelClass);
            /*_applicationDbContextClass.CategoriesTableName.Update(ProductModelClass);
            _applicationDbContextClass.SaveChanges();*/
            /*_iProductRepository.Update(ProductModelClass);
            _iProductRepository.Save();*/
            _iUnitOfWorkRepository.ProductRepository.Update(productModelClass);
            _iUnitOfWorkRepository.Save();
            TempData["tempDataKeySuccess"] = "Product edited successfully";
            return RedirectToAction("Index");
        }
        return View();
    }


    //when leave it blank then it's by default Get Method => [HttpGet]
    public IActionResult Delete(int? productId)
    {
        if (productId == null || productId == 0)
        {
            return NotFound();
        }
        //ProductModelClass? ProductModelClassFromDb = _applicationDbContextClass.CategoriesTableName.Find(ProductId);
        //ProductModelClass? ProductModelClassFromDb = _iProductRepository.Get(item => item.Id == ProductId);
        ProductModelClass? productModelClassFromDb = _iUnitOfWorkRepository.ProductRepository.Get(item => item.Id == productId);
        if (productModelClassFromDb == null)
        {
            return NotFound();
        }

        return View(productModelClassFromDb);
    }
    [HttpPost, ActionName("Delete")]
    public IActionResult DeletePost(int? productId)
    {
        //ProductModelClass? ProductModelClassFromDb = _applicationDbContextClass.CategoriesTableName.Find(ProductId);
        //ProductModelClass? ProductModelClassFromDb = _iProductRepository.Get(item => item.Id == ProductId);
        ProductModelClass? productModelClassFromDb = _iUnitOfWorkRepository.ProductRepository.Get(item => item.Id == productId);
        if (productModelClassFromDb == null)
        {
            return NotFound();
        }

        //_applicationDbContextClass.CategoriesTableName.Add(ProductModelClass);
        //_applicationDbContextClass.CategoriesTableName.Update(ProductModelClass);
        /*_applicationDbContextClass.CategoriesTableName.Remove(ProductModelClassFromDb);
        _applicationDbContextClass.SaveChanges();*/
        /*_iProductRepository.Delete(ProductModelClassFromDb);
        _iProductRepository.Save();*/
        _iUnitOfWorkRepository.ProductRepository.Delete(productModelClassFromDb);
        _iUnitOfWorkRepository.Save();
        TempData["tempDataKeySuccess"] = "Product deleted successfully";
        return RedirectToAction("Index");
    }

}
}







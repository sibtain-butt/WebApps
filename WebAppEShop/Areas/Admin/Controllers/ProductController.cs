using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using NuGet.Protocol;
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
        private readonly IWebHostEnvironment _webHostEnvironment;


        public ProductController(IUnitOfWorkRepository iUnitOfWorkRepository, IWebHostEnvironment webHostEnvironment)
        {
            //_iProductRepository = iProductRepository;
            _iUnitOfWorkRepository = iUnitOfWorkRepository;
            _webHostEnvironment = webHostEnvironment;
        }


        public IActionResult Index()
        {
            //List<ProductModelClass> objProductList = _applicationDbContextClass.CategoriesTableName.ToList();
            //List<ProductModelClass> objProductList = _iProductRepository.GetAll().ToList();
            List<ProductModelClass> objProductList = 
                _iUnitOfWorkRepository.ProductRepository
                .GetAll(includeProperties: "CategoryModelClass").ToList();

            return View(objProductList);
        }

        //////    //--------------------------Start-----------------------------
        //////    // i comment below [HttpGet & HttpPost] of Create() method ==> to combine it as Upsert() method

        //    //when leave it blank then it's by default Get Method => [HttpGet]
        //    public IActionResult Create()
        //    {
        //        //below codes are in WebAppEShop.Model.Models.ViewModels
        //        /*//========== ==> Method 1 using ViewBag & ViewData <== ==========//
        //        IEnumerable<SelectListItem> selectListItemCategoryModelList = _iUnitOfWorkRepository.
        //            CategoryRepository.GetAll().Select(item => new SelectListItem
        //            {
        //                Text = item.Name,
        //                Value = item.Id.ToString(),
        //            });
        //        //========== ==> ViewBag <== ==========// ViewBag.KeyName = KeyValue;
        //        ViewBag.SelectListItemCategory = selectListItemCategoryModelList;
        //        //========== ==> ViewData <== =========// ViewData["KeyName"] = KeyValue; TypeCast needed
        //        ViewData["SelectListItemCategory"] = selectListItemCategoryModelList;*/

        //        //========== ==> Method 2 using ProductViewModel <== ==========//
        //        ProductViewModel productViewModel = new()
        //        {
        //            SelectListItemCategoryModelList = _iUnitOfWorkRepository.CategoryRepository.GetAll()
        //            .Select(item => new SelectListItem { Text = item.Name, Value = item.Id.ToString() }),
        //            ProductModelClass = new ProductModelClass()
        //        };

        //        return View(productViewModel);
        //    }

        //    [HttpPost]
        //    public IActionResult Create(ProductModelClass productModelClass, ProductViewModel productViewModel)
        //    {
        //        /*if (ProductModelClass.Name == ProductModelClass.DisplayOrder.ToString())
        //        {
        //            ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name");
        //        }*/
        //        if (ModelState.IsValid)
        //        {
        //            /*_applicationDbContextClass.CategoriesTableName.Add(ProductModelClass);
        //            _applicationDbContextClass.SaveChanges();*/
        //            /*_iProductRepository.Add(ProductModelClass);
        //            _iProductRepository.Save();*/
        //            _iUnitOfWorkRepository.ProductRepository.Add(productModelClass);
        //            _iUnitOfWorkRepository.Save();
        //            TempData["tempDataKeySuccess"] = "Product added successfully";
        //            return RedirectToAction("Index");
        //        }
        //        else
        //        {
        //            productViewModel.SelectListItemCategoryModelList = _iUnitOfWorkRepository.CategoryRepository.GetAll()
        //            .Select(item => new SelectListItem { Text = item.Name, Value = item.Id.ToString() });
        //            //ProductModelClass = new ProductModelClass()
        //        };

        //        return View(productViewModel);
        //    }
        //    //}
        //    //    return View();
        ////}
        //////--------------------------------END----------------------

        //when leave it blank then it's by default Get Method => [HttpGet]
        public IActionResult Upsert(int? productId)
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

            if (productId == null || productId == 0)
            {
                //do Implement Create() method
                return View(productViewModel);
            }
            else
            {
                productViewModel.ProductModelClass =
                    _iUnitOfWorkRepository.ProductRepository.Get(item => item.Id == productId);
                return View(productViewModel);
            }


            //return View(productViewModel); //move this line in if(){}-else{} statement
        }

        [HttpPost]
        public IActionResult Upsert(ProductViewModel? productViewModel, IFormFile? productFormFile)
        {
            /*if (ProductModelClass.Name == ProductModelClass.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name");
            }*/
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (productFormFile != null)
                {
                    string productFileName = Guid.NewGuid().ToString() + Path.GetExtension(productFormFile.FileName);
                    string productFilePathNew = Path.Combine(wwwRootPath, @"images\product");                       

                    if (!string.IsNullOrEmpty(productViewModel!.ProductModelClass!.ImageUrl))
                    {
                        //Delete the Old Image
                        var productFilePathOld =
                            Path.Combine(wwwRootPath, productViewModel.ProductModelClass.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(productFilePathOld))
                        {
                            System.IO.File.Delete(productFilePathOld);
                            //System.IO.File.Copy(productFilePathNew, productFilePathOld);
                        }
                    }
                    //Create file by copying file to our given (path combine) 
                    using var productFileStream =
                        new FileStream(Path.Combine(productFilePathNew, productFileName), FileMode.Create);
                    productFormFile.CopyTo(productFileStream);
                    productViewModel!.ProductModelClass!.ImageUrl = @"\images\product\" + productFileName;
                }
                else
                {                       
                        if ((productViewModel!.ProductModelClass!.ImageUrl == null) && (productViewModel.ProductModelClass.Id == 0))
                        {
                            string imageUrlSource = Path.Combine(wwwRootPath, @"images\no_image_available1.png");
                        
                        //string imageDestination = Path.Combine(wwwRootPath, @"\images\product\" + productFileName);
                        productViewModel!.ProductModelClass!.ImageUrl = imageUrlSource;
                        //if (!string.IsNullOrEmpty(productViewModel!.ProductModelClass!.ImageUrl))

                        //Delete the Old Image
                        //string imageUrlDestination =
                        //    Path.Combine(wwwRootPath, productViewModel.ProductModelClass.ImageUrl!);
                        //if (System.IO.File.Exists(productViewModel.ProductModelClass.ImageUrl))
                        //{
                        //System.IO.File.Delete(productFilePathOld);
                        //System.IO.File.Copy(imageUrlSource, imageDestination);
                                //}
                    }
                    //"@Model.DefaultImageUrlString" or @"\images\no_image_available.png"
                    //productViewModel!.ProductModelClass!.ImageUrl = "u didn't upload any image";
                    //productViewModel!.ProductModelClass!.ImageUrl = productViewModel!.ProductModelClass!.ImageUrl;

                }

                if (productViewModel!.ProductModelClass!.Id == 0)
                {
                    _iUnitOfWorkRepository.ProductRepository.Add(productViewModel.ProductModelClass);
                    _iUnitOfWorkRepository.Save();
                    TempData["tempDataKeySuccess"] = "Product added successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    _iUnitOfWorkRepository.ProductRepository.Update(productViewModel.ProductModelClass);
                    _iUnitOfWorkRepository.Save();
                    TempData["tempDataKeySuccess"] = "Product updated successfully";
                    return RedirectToAction("Index");
                }

                /*_applicationDbContextClass.CategoriesTableName.Add(ProductModelClass);
                _applicationDbContextClass.SaveChanges();*/
                /*_iProductRepository.Add(ProductModelClass);
               _iProductRepository.Save();*/

                //_iUnitOfWorkRepository.ProductRepository.Add(productViewModel.ProductModelClass);
                //_applicationDbContextClass.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT [dbo].[{typeof(DatabaseTable).Name}] ON");
                //_applicationDbContextClass.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT [dbo].[{typeof(DatabaseTable).Name}] OFF");

                //_iUnitOfWorkRepository.Save();//moved this to above if-else statement
                //TempData["tempDataKeySuccess"] = "Product added successfully";//moved to above if-else
                //return RedirectToAction("Index");
            }
            else
            {
                productViewModel!.SelectListItemCategoryModelList = _iUnitOfWorkRepository.CategoryRepository.GetAll()
                .Select(item => new SelectListItem { Text = item.Name, Value = item.Id.ToString() });
                //ProductModelClass = new ProductModelClass()
            };

            return View(productViewModel);
        }

        ////--------------------------Start Edit Method-----------------------------
        //// i comment below [HttpGet & HttpPost] of Edit() method ==> to combine it as Upsert() method        

        //    //when leave it blank then it's by default Get Method => [HttpGet]
        //    public IActionResult Edit(int? productId)
        //{
        //    if (productId == null || productId == 0)
        //    {
        //        return NotFound();
        //    }
        //    //ProductModelClass? ProductModelClassFromDb = _applicationDbContextClass.CategoriesTableName.Find(ProductId);
        //    //ProductModelClass? ProductModelClassFromDb = _iProductRepository.Get(item => item.Id == ProductId);
        //    ProductModelClass? productModelClassFromDb = _iUnitOfWorkRepository.ProductRepository.Get(item => item.Id == productId);
        //    /*ProductModelClass? ProductModelClassFromDb1 = _applicationDbContextClass.CategoriesTableName.FirstOrDefault(item => item.Id == id);
        //    ProductModelClass? ProductModelClassFromDb2 = _applicationDbContextClass.CategoriesTableName.Where(item => item.Id == id).FirstOrDefault();*/
        //    if (productModelClassFromDb == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(productModelClassFromDb);
        //}
        //[HttpPost]
        //public IActionResult Edit(ProductModelClass productModelClass)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //_applicationDbContextClass.CategoriesTableName.Add(ProductModelClass);
        //        /*_applicationDbContextClass.CategoriesTableName.Update(ProductModelClass);
        //        _applicationDbContextClass.SaveChanges();*/
        //        /*_iProductRepository.Update(ProductModelClass);
        //        _iProductRepository.Save();*/
        //        _iUnitOfWorkRepository.ProductRepository.Update(productModelClass);
        //        _iUnitOfWorkRepository.Save();
        //        TempData["tempDataKeySuccess"] = "Product edited successfully";
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}
        ////--------------------------End Edit Method-----------------------------
        //// i comment above [HttpGet & HttpPost] of Edit() method ==> to combine it as Upsert() method

        ////--------------------------Start Delete Method-----------------------------
        ////i comment this both [HttpGet] & [HttpPost] method of Delete Method because
        ////i replace it with below last code in API CALLS -> Delete Method & we don't
        ////need it's view also i will comment that Views>>Product>>Delete.cshtml

        ////when leave it blank then it's by default Get Method => [HttpGet]
        //public IActionResult Delete(int? productId)//Views>>Product>>Index.cshtml [asp-for-productId]
        //{
        //    if (productId == null || productId == 0)
        //    {
        //        return NotFound();
        //    }
        //    //ProductModelClass? ProductModelClassFromDb = _applicationDbContextClass.CategoriesTableName.Find(ProductId);
        //    //ProductModelClass? ProductModelClassFromDb = _iProductRepository.Get(item => item.Id == ProductId);
        //    ProductModelClass productModelClassFromDb = _iUnitOfWorkRepository.ProductRepository.Get(item => item.Id == productId);
        //    if (productModelClassFromDb == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(productModelClassFromDb);
        //}
        //[HttpPost, ActionName("Delete")]
        //public IActionResult DeletePost(int? productId)//Views>>Product>>Index.cshtml [asp-for-productId]
        //{
        //    //ProductModelClass? ProductModelClassFromDb = _applicationDbContextClass.CategoriesTableName.Find(ProductId);
        //    //ProductModelClass? ProductModelClassFromDb = _iProductRepository.Get(item => item.Id == ProductId);
        //    ProductModelClass productModelClassFromDb = _iUnitOfWorkRepository.ProductRepository.Get(item => item.Id == productId);
        //    if (productModelClassFromDb == null)
        //    {
        //        return NotFound();
        //    }

        //    //_applicationDbContextClass.CategoriesTableName.Add(ProductModelClass);
        //    //_applicationDbContextClass.CategoriesTableName.Update(ProductModelClass);
        //    /*_applicationDbContextClass.CategoriesTableName.Remove(ProductModelClassFromDb);
        //    _applicationDbContextClass.SaveChanges();*/
        //    /*_iProductRepository.Delete(ProductModelClassFromDb);
        //    _iProductRepository.Save();*/
        //    _iUnitOfWorkRepository.ProductRepository.Delete(productModelClassFromDb);
        //    _iUnitOfWorkRepository.Save();
        //    TempData["tempDataKeySuccess"] = "Product deleted successfully";
        //    return RedirectToAction("Index");
        //}
        ////--------------------------End Delete Method-----------------------------


        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<ProductModelClass> objProductList =
                _iUnitOfWorkRepository.ProductRepository
                .GetAll(includeProperties: "CategoryModelClass").ToList();
            return Json(new { data = objProductList });
        }
        [HttpDelete]
        public IActionResult Delete(int? id) //this id is not productId in asp-rout-productId but
            //this int? id -> is like @obj.id [primaryKey] of ProductModelClass like we did it in
            //Views>>Product>>Index.cshtml -> asp-route-productId="@obj.id"
        {
            var objProductToBeDeleted =
                _iUnitOfWorkRepository.ProductRepository
                .Get(item => item.Id == id);
            if (objProductToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error in deleting" });
            }
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            //Delete the Old Image
            var productFilePathOld =
                Path.Combine(wwwRootPath, objProductToBeDeleted!.ImageUrl!.TrimStart('\\'));
            if (System.IO.File.Exists(productFilePathOld))
            {
                System.IO.File.Delete(productFilePathOld);
            }
            _iUnitOfWorkRepository.ProductRepository.Delete(objProductToBeDeleted);
            _iUnitOfWorkRepository.Save();

            return Json(new { success = true, message = "Deleted Successfully" });
        }

        #endregion
    }
}







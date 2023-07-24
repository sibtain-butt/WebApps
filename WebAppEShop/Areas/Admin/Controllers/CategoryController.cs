using Microsoft.AspNetCore.Mvc;
using WebAppEShop.DataAccess.Data;
using WebAppEShop.DataAccess.Repository;
using WebAppEShop.DataAccess.Repository.IRepository;
using WebAppEShop.Model.Models;


namespace WebAppEShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        //private readonly ApplicationDbContextClass _applicationDbContextClass;
        //private readonly ICategoryRepository _iCategoryRepository;
        private readonly IUnitOfWorkRepository _iUnitOfWorkRepository;

        public CategoryController(IUnitOfWorkRepository iUnitOfWorkRepository)
        {
            //_iCategoryRepository = iCategoryRepository;
            _iUnitOfWorkRepository = iUnitOfWorkRepository;
        }


        public IActionResult Index()
        {
            //List<CategoryModelClass> objCategoryList = _applicationDbContextClass.CategoriesTableName.ToList();
            //List<CategoryModelClass> objCategoryList = _iCategoryRepository.GetAll().ToList();
            List<CategoryModelClass> objCategoryList = _iUnitOfWorkRepository.CategoryRepository.GetAll().ToList();
            return View(objCategoryList);
        }


        //when leave it blank then it's by default Get Method => [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CategoryModelClass categoryModelClass)
        {
            /*if (categoryModelClass.Name == categoryModelClass.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name");
            }*/
            if (ModelState.IsValid)
            {
                /*_applicationDbContextClass.CategoriesTableName.Add(categoryModelClass);
                _applicationDbContextClass.SaveChanges();*/
                /*_iCategoryRepository.Add(categoryModelClass);
                _iCategoryRepository.Save();*/
                _iUnitOfWorkRepository.CategoryRepository.Add(categoryModelClass);
                _iUnitOfWorkRepository.Save();
                TempData["tempDataKeySuccess"] = "Category added successfully";
                return RedirectToAction("Index");
            }
            return View();
        }


        //when leave it blank then it's by default Get Method => [HttpGet]
        public IActionResult Edit(int? categoryId)
        {
            if (categoryId == null || categoryId == 0)
            {
                return NotFound();
            }
            //CategoryModelClass? categoryModelClassFromDb = _applicationDbContextClass.CategoriesTableName.Find(categoryId);
            //CategoryModelClass? categoryModelClassFromDb = _iCategoryRepository.Get(item => item.Id == categoryId);
            CategoryModelClass? categoryModelClassFromDb = _iUnitOfWorkRepository.CategoryRepository.Get(item => item.Id == categoryId);
            /*CategoryModelClass? categoryModelClassFromDb1 = _applicationDbContextClass.CategoriesTableName.FirstOrDefault(item => item.Id == id);
            CategoryModelClass? categoryModelClassFromDb2 = _applicationDbContextClass.CategoriesTableName.Where(item => item.Id == id).FirstOrDefault();*/
            if (categoryModelClassFromDb == null)
            {
                return NotFound();
            }

            return View(categoryModelClassFromDb);
        }
        [HttpPost]
        public IActionResult Edit(CategoryModelClass categoryModelClass)
        {
            if (ModelState.IsValid)
            {
                //_applicationDbContextClass.CategoriesTableName.Add(categoryModelClass);
                /*_applicationDbContextClass.CategoriesTableName.Update(categoryModelClass);
                _applicationDbContextClass.SaveChanges();*/
                /*_iCategoryRepository.Update(categoryModelClass);
                _iCategoryRepository.Save();*/
                _iUnitOfWorkRepository.CategoryRepository.Update(categoryModelClass);
                _iUnitOfWorkRepository.Save();
                TempData["tempDataKeySuccess"] = "Category edited successfully";
                return RedirectToAction("Index");
            }
            return View();
        }


        //when leave it blank then it's by default Get Method => [HttpGet]
        public IActionResult Delete(int? categoryId)
        {
            if (categoryId == null || categoryId == 0)
            {
                return NotFound();
            }
            //CategoryModelClass? categoryModelClassFromDb = _applicationDbContextClass.CategoriesTableName.Find(categoryId);
            //CategoryModelClass? categoryModelClassFromDb = _iCategoryRepository.Get(item => item.Id == categoryId);
            CategoryModelClass? categoryModelClassFromDb = _iUnitOfWorkRepository.CategoryRepository.Get(item => item.Id == categoryId);
            if (categoryModelClassFromDb == null)
            {
                return NotFound();
            }

            return View(categoryModelClassFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? categoryId)
        {
            //CategoryModelClass? categoryModelClassFromDb = _applicationDbContextClass.CategoriesTableName.Find(categoryId);
            //CategoryModelClass? categoryModelClassFromDb = _iCategoryRepository.Get(item => item.Id == categoryId);
            CategoryModelClass? categoryModelClassFromDb = _iUnitOfWorkRepository.CategoryRepository.Get(item => item.Id == categoryId);
            if (categoryModelClassFromDb == null)
            {
                return NotFound();
            }

            //_applicationDbContextClass.CategoriesTableName.Add(categoryModelClass);
            //_applicationDbContextClass.CategoriesTableName.Update(categoryModelClass);
            /*_applicationDbContextClass.CategoriesTableName.Remove(categoryModelClassFromDb);
            _applicationDbContextClass.SaveChanges();*/
            /*_iCategoryRepository.Delete(categoryModelClassFromDb);
            _iCategoryRepository.Save();*/
            _iUnitOfWorkRepository.CategoryRepository.Delete(categoryModelClassFromDb);
            _iUnitOfWorkRepository.Save();
            TempData["tempDataKeySuccess"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }

    }
}







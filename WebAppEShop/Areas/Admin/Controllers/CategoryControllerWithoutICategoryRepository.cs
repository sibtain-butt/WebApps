/*using Microsoft.AspNetCore.Mvc;
using WebAppEShop.DataAccess.Data;
using WebAppEShop.Model.Models;

namespace WebAppEShop.Areas.AdminArea.Controllers
{
    public class CategoryControllerWithoutICategoryRepository : Controller
    {
        private readonly ApplicationDbContextClass _applicationDbContextClass;
        public CategoryControllerWithoutICategoryRepository(ApplicationDbContextClass applicationDbContextClass)
        {
            _applicationDbContextClass = applicationDbContextClass;
        }


        public IActionResult Index()
        {
            List<CategoryModelClass> objCategoryList = _applicationDbContextClass.CategoriesTableName.ToList();
            return View(objCategoryList);
        }


        //when leave it blank then it's by default Get Method => [HttpGet]
        public IActionResult CreateNewCategoryView()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateNewCategoryView(CategoryModelClass categoryModelClass)
        {
            *//*if (categoryModelClass.Name == categoryModelClass.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name");
            }*//*
            if (ModelState.IsValid)
            {
                _applicationDbContextClass.CategoriesTableName.Add(categoryModelClass);
                _applicationDbContextClass.SaveChanges();
                TempData["tempDataKeySuccess"] = "Category added successfully";
                return RedirectToAction("Index");
            }
            return View();
        }


        //when leave it blank then it's by default Get Method => [HttpGet]
        public IActionResult EditCategoryView(int? categoryId)
        {
            if (categoryId == null || categoryId == 0)
            {
                return NotFound();
            }
            CategoryModelClass? categoryModelClassFromDb = _applicationDbContextClass.CategoriesTableName.Find(categoryId);
            *//*CategoryModelClass? categoryModelClassFromDb1 = _applicationDbContextClass.CategoriesTableName.FirstOrDefault(item => item.Id == id);
            CategoryModelClass? categoryModelClassFromDb2 = _applicationDbContextClass.CategoriesTableName.Where(item => item.Id == id).FirstOrDefault();*//*
            if (categoryModelClassFromDb == null)
            {
                return NotFound();
            }

            return View(categoryModelClassFromDb);
        }
        [HttpPost]
        public IActionResult EditCategoryView(CategoryModelClass categoryModelClass)
        {
            if (ModelState.IsValid)
            {
                //_applicationDbContextClass.CategoriesTableName.Add(categoryModelClass);
                _applicationDbContextClass.CategoriesTableName.Update(categoryModelClass);
                _applicationDbContextClass.SaveChanges();
                TempData["tempDataKeySuccess"] = "Category edited successfully";
                return RedirectToAction("Index");
            }
            return View();
        }


        //when leave it blank then it's by default Get Method => [HttpGet]
        public IActionResult DeleteCategoryView(int? categoryId)
        {
            if (categoryId == null || categoryId == 0)
            {
                return NotFound();
            }
            CategoryModelClass? categoryModelClassFromDb = _applicationDbContextClass.CategoriesTableName.Find(categoryId);
            if (categoryModelClassFromDb == null)
            {
                return NotFound();
            }

            return View(categoryModelClassFromDb);
        }
        [HttpPost, ActionName("DeleteCategoryView")]
        public IActionResult DeleteCategoryViewPost(int? categoryId)
        {
            CategoryModelClass? categoryModelClassFromDb = _applicationDbContextClass.CategoriesTableName.Find(categoryId);
            if (categoryModelClassFromDb == null)
            {
                return NotFound();
            }

            //_applicationDbContextClass.CategoriesTableName.Add(categoryModelClass);
            //_applicationDbContextClass.CategoriesTableName.Update(categoryModelClass);
            _applicationDbContextClass.CategoriesTableName.Remove(categoryModelClassFromDb);
            _applicationDbContextClass.SaveChanges();
            TempData["tempDataKeySuccess"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
*/
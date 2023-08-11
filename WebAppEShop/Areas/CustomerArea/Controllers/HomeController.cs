using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppEShop.DataAccess.Repository.IRepository;
using WebAppEShop.Model.Models;

namespace WebAppEShop.Areas.CustomerArea.Controllers
{
    [Area("CustomerArea")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWorkRepository _iUnitOfWorkRepository;

        public HomeController(ILogger<HomeController> logger, IUnitOfWorkRepository iUnitOfWorkRepository)
        {
            _logger = logger;
            _iUnitOfWorkRepository = iUnitOfWorkRepository;
        }

        public IActionResult Index()
        {
            IEnumerable<ProductModelClass> productIEnumerable = 
                _iUnitOfWorkRepository.ProductRepository.GetAll(
                    includeProperties: "CategoryModelClass");
            return View(productIEnumerable);
        }

        public IActionResult Details(int? productId)
        {
            ProductModelClass objProduct =
                _iUnitOfWorkRepository.ProductRepository.Get(
                    item => item.Id == productId,
                    includeProperties: "CategoryModelClass");
            return View(objProduct);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
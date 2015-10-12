using System.Linq;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;

namespace SportsStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        private readonly IProductRepository _productRepository;

        public NavController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;
            var categories = _productRepository.Products.Select(p => p.Category).Distinct().OrderBy(x => x);
            return PartialView(categories);
        }
    }
}

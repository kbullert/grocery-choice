using System.Web.Mvc;
using System.Threading.Tasks;
using GroceryChoice.Repository;
using GroceryChoice.Model;


namespace GroceryChoice.Web.Controllers
{
    public class PrepController : Controller
    {
        private ICategoryRepository _categoryRepository;
        private IGroceryRepository _groceryRepository;

        public PrepController()
        {
            _categoryRepository = new CategoryRepository();
            _groceryRepository = new GroceryRepository();
        }

        public ActionResult Index()
        {
            return View(_categoryRepository.MajorCategories);
        }

        public ActionResult FindMinorCategories(int id)
        {
            return View(_categoryRepository.FindAllMinorCategories(id));
        }

        public async Task<ActionResult> DeleteMajorCategory(int id)
        {
            await _categoryRepository.DeleteMajorCategoryAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> SaveMajorCategory(MajorCategory majorCategory)
        {
            await _categoryRepository.SaveMajorCategoryAsync(majorCategory);
            return RedirectToAction("Index");
        }

        public ActionResult FindItemCategories(int id)
        {
            return View(_categoryRepository.FindAllItemCategories(id));
        }

        public ActionResult BrandGroceries()
        {
            return View(_groceryRepository.BrandGroceries);
        }

        public ActionResult FindGenericGroceries(int id)
        {
            return View(_groceryRepository.FindAllGenericGroceries(id));
        }
    }
}
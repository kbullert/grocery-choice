using GroceryChoice.Model;
using GroceryChoice.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace GroceryChoice.Web.Controllers
{
    public class MinorCategoryController : ApiController
    {
        private ICategoryRepository _categoryRepository;

        public MinorCategoryController()
        {
            _categoryRepository = new CategoryRepository();
        }

        public IEnumerable<MinorCategory> GetMinorCategories()
        {
            return _categoryRepository.MinorCategories;
        }

        public IHttpActionResult GetMinorCategory(int id)
        {
            MinorCategory result = _categoryRepository.MinorCategories.Where(mc => mc.MinorCategoryId == id).FirstOrDefault();
            return result == null ? (IHttpActionResult)BadRequest("No Minor Category Found") : Ok(result);
        }

        public async Task PostMinorCategory(MinorCategory minorCategory)
        {
            await _categoryRepository.SaveMinorCategoryAsync(minorCategory);
        }

        public async Task DeleteMinorCategory(int id)
        {
            await _categoryRepository.DeleteMinorCategoryAsync(id);
        }
    }
}

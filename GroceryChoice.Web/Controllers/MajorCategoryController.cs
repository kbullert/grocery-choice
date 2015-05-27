using GroceryChoice.Model;
using GroceryChoice.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace GroceryChoice.Web.Controllers
{
    public class MajorCategoryController : ApiController
    {
        private ICategoryRepository _categoryRepository;

        public MajorCategoryController()
        {
            _categoryRepository = new CategoryRepository();
        }

        public IEnumerable<MajorCategory> GetMajorCategories()
        {
            return _categoryRepository.MajorCategories;
        }

        public IHttpActionResult GetMajorCategory(int id)
        {
            MajorCategory result = _categoryRepository.MajorCategories.Where(mc => mc.MajorCategoryId == id).FirstOrDefault();
            return result == null ? (IHttpActionResult) BadRequest("No Major Category Found") : Ok(result);
        }

        public async Task PostMajorCategory(MajorCategory majorCategory)
        {
            await _categoryRepository.SaveMajorCategoryAsync(majorCategory);
        }

        public async Task DeleteMajorCategory(int id)
        {
            await _categoryRepository.DeleteMajorCategoryAsync(id);
        }
    }
}

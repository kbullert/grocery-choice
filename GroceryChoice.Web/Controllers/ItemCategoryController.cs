using GroceryChoice.Model;
using GroceryChoice.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace GroceryChoice.Web.Controllers
{
    public class ItemCategoryController : ApiController
    {
        private ICategoryRepository _categoryRepository;

        public ItemCategoryController()
        {
            _categoryRepository = new CategoryRepository();
        }

        public IEnumerable<ItemCategory> GetItemCategories()
        {
            return _categoryRepository.ItemCategories;
        }

        public IHttpActionResult GetItemCategory(int id)
        {
            ItemCategory result = _categoryRepository.ItemCategories.Where(ic => ic.ItemCategoryId == id).FirstOrDefault();
            return result == null ? (IHttpActionResult)BadRequest("No Item Category Found") : Ok(result);
        }

        public async Task PostItemCategory(ItemCategory itemCategory)
        {
            await _categoryRepository.SaveItemCategoryAsync(itemCategory);
        }

        public async Task DeleteItemCategory(int id)
        {
            await _categoryRepository.DeleteItemCategoryAsync(id);
        }
    }
}

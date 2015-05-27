using GroceryChoice.Model;
using GroceryChoice.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace GroceryChoice.Web.Controllers
{
    public class BrandGroceryController : ApiController
    {
        private IGroceryRepository _groceryRepository;

        public BrandGroceryController()
        {
            _groceryRepository = new GroceryRepository();
        }

        public IEnumerable<BrandGrocery> GetBrandGroceries()
        {
            return _groceryRepository.BrandGroceries;
        }

        public IHttpActionResult GetBrandGrocery(int id)
        {
            BrandGrocery result = _groceryRepository.BrandGroceries.Where(bg => bg.BrandGroceryId == id).FirstOrDefault();
            return result == null ? (IHttpActionResult) BadRequest("No Brand Grocery Found") : Ok(result);
        }

        public async Task PostBrandGrocery(BrandGrocery brandGrocery)
        {
            await _groceryRepository.SaveBrandGroceryAsync(brandGrocery);
        }

        public async Task DeleteBrandGrocery(int id)
        {
            await _groceryRepository.DeleteBrandGroceryAsync(id);
        }
    }
}

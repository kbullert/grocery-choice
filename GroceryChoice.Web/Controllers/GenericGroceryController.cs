using GroceryChoice.Model;
using GroceryChoice.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace GroceryChoice.Web.Controllers
{
    public class GenericGroceryController : ApiController
    {
        private IGroceryRepository _groceryRepository;

        public GenericGroceryController()
        {
            _groceryRepository = new GroceryRepository();
        }

        public IEnumerable<GenericGrocery> GetGenericGroceries()
        {
            return _groceryRepository.GenericGroceries;
        }

        public IHttpActionResult GetGenericGrocery(int id)
        {
            GenericGrocery result = _groceryRepository.GenericGroceries.Where(gg => gg.GenericGroceryId == id).FirstOrDefault();
            return result == null ? (IHttpActionResult)BadRequest("No Generic Grocery Found") : Ok(result);
        }

        public async Task PostGenericGrocery(GenericGrocery genericGrocery)
        {
            await _groceryRepository.SaveGenericGroceryAsync(genericGrocery);
        }

        public async Task DeleteGenericGrocery(int id)
        {
            await _groceryRepository.DeleteGenericGroceryAsync(id);
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;

namespace GroceryChoice.Model
{
    public interface IGroceryRepository
    {
        IEnumerable<BrandGrocery> BrandGroceries { get; }
        Task<int> SaveBrandGroceryAsync(BrandGrocery brandGrocery);
        Task<BrandGrocery> DeleteBrandGroceryAsync(int brandGroceryID);

        IEnumerable<GenericGrocery> GenericGroceries { get; }
        Task<int> SaveGenericGroceryAsync(GenericGrocery genericGrocery);
        Task<GenericGrocery> DeleteGenericGroceryAsync(int genericGroceryID);
        List<GenericGrocery> FindAllGenericGroceries(int id);
    }
}

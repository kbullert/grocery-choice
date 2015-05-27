using System.Collections.Generic;
using System.Threading.Tasks;

namespace GroceryChoice.Model
{
    public interface ICategoryRepository
    {
        IEnumerable<MajorCategory> MajorCategories { get; }
        Task<int> SaveMajorCategoryAsync(MajorCategory majorCategory);
        Task<MajorCategory> DeleteMajorCategoryAsync(int majorCategoryID);

        IEnumerable<MinorCategory> MinorCategories { get; }
        Task<int> SaveMinorCategoryAsync(MinorCategory minorCategory);
        Task<MinorCategory> DeleteMinorCategoryAsync(int minorCategoryID);
        List<MinorCategory> FindAllMinorCategories(int id);

        IEnumerable<ItemCategory> ItemCategories { get; }
        Task<int> SaveItemCategoryAsync(ItemCategory itemCategory);
        Task<ItemCategory> DeleteItemCategoryAsync(int itemCategoryID);
        List<ItemCategory> FindAllItemCategories(int id);
    }
}

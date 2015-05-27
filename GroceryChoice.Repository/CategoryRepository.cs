using System.Collections.Generic;
using System.Threading.Tasks;
using GroceryChoice.Model;
using System.Linq;

namespace GroceryChoice.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private CategoryContext context = new CategoryContext();

        public IEnumerable<MajorCategory> MajorCategories
        {
            get
            {
                return context.MajorCategories;
            }
        }

        public IEnumerable<MinorCategory> MinorCategories
        {
            get
            {
                return context.MinorCategories;
            }
        }

        public IEnumerable<ItemCategory> ItemCategories
        {
            get
            {
                return context.ItemCategories;
            }
        }

        public async Task<int> SaveMajorCategoryAsync(MajorCategory majorCategory)
        {
            if (majorCategory.MajorCategoryId == 0)
            {
                context.MajorCategories.Add(majorCategory);
            }
            else
            {
                MajorCategory dbEntry = context.MajorCategories.Find(majorCategory.MajorCategoryId);
                if (dbEntry != null)
                {
                    dbEntry.MajorCategoryName = majorCategory.MajorCategoryName;
                }
            }

            return await context.SaveChangesAsync();
        }

        public async Task<MajorCategory> DeleteMajorCategoryAsync(int majorCategoryID)
        {
            MajorCategory dbEntry = context.MajorCategories.Find(majorCategoryID);
            if (dbEntry != null)
            {
                context.MajorCategories.Remove(dbEntry);
            }

            await context.SaveChangesAsync();
            return dbEntry;
        }

        public async Task<int> SaveMinorCategoryAsync(MinorCategory minorCategory)
        {
            if (minorCategory.MinorCategoryId == 0)
            {
                context.MinorCategories.Add(minorCategory);
            }
            else
            {
                MinorCategory dbEntry = context.MinorCategories.Find(minorCategory.MinorCategoryId);
                if (dbEntry != null)
                {
                    dbEntry.MinorCategoryName = minorCategory.MinorCategoryName;
                    dbEntry.MajorCategoryId = minorCategory.MajorCategoryId;
                }
            }

            return await context.SaveChangesAsync();
        }

        public async Task<MinorCategory> DeleteMinorCategoryAsync(int minorCategoryID)
        {
            MinorCategory dbEntry = context.MinorCategories.Find(minorCategoryID);
            if (dbEntry != null)
            {
                context.MinorCategories.Remove(dbEntry);
            }

            await context.SaveChangesAsync();
            return dbEntry;
        }

        public List<MinorCategory> FindAllMinorCategories(int id)
        {
            List<MinorCategory> minorCategories = (from c in context.MinorCategories
                     where id == c.MajorCategoryId
                     select c).ToList();

            return minorCategories;
        }

        public async Task<int> SaveItemCategoryAsync(ItemCategory itemCategory)
        {
            if (itemCategory.ItemCategoryId == 0)
            {
                context.ItemCategories.Add(itemCategory);
            }
            else
            {
                ItemCategory dbEntry = context.ItemCategories.Find(itemCategory.ItemCategoryId);
                if (dbEntry != null)
                {
                    dbEntry.ItemCategoryName = itemCategory.ItemCategoryName;
                    dbEntry.MinorCategoryId = itemCategory.MinorCategoryId;
                }
            }

            return await context.SaveChangesAsync();
        }

        public async Task<ItemCategory> DeleteItemCategoryAsync(int itemCategoryID)
        {
            ItemCategory dbEntry = context.ItemCategories.Find(itemCategoryID);
            if (dbEntry != null)
            {
                context.ItemCategories.Remove(dbEntry);
            }

            await context.SaveChangesAsync();
            return dbEntry;
        }

        public List<ItemCategory> FindAllItemCategories(int id)
        {
            List<ItemCategory> itemCategories = (from c in context.ItemCategories
                                                   where id == c.MinorCategoryId
                                                   select c).ToList();

            return itemCategories;
        }
    }
}

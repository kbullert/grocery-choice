using System.Collections.Generic;
using System.Data.Entity;
using GroceryChoice.Model;

namespace GroceryChoice.Repository
{
    public class CategoryDbInitializer : DropCreateDatabaseAlways<CategoryContext>
    {
        public void InitializeDatabase(CategoryContext context)
        {
            if (!context.Database.Exists())
            {
                context.Database.Create();
                Seed(context);
                context.SaveChanges();
            }
        }
        
        protected override void Seed(CategoryContext context)
        {
            new List<MajorCategory> {
                new MajorCategory() { MajorCategoryName = "Canned Goods"},
                new MajorCategory() { MajorCategoryName = "Ingredients"}
            }.ForEach(mc => context.MajorCategories.Add(mc));

            context.SaveChanges();

            new List<MinorCategory> {
                new MinorCategory() { MajorCategoryId = 1, MinorCategoryName = "Fruit", HasItemCategory = true },
                new MinorCategory() { MajorCategoryId = 1, MinorCategoryName = "Vegetables", HasItemCategory = true },
                new MinorCategory() { MajorCategoryId = 2, MinorCategoryName = "Flour", HasItemCategory = false },
                new MinorCategory() { MajorCategoryId = 2, MinorCategoryName = "Sugar", HasItemCategory = false }
            }.ForEach(mc => context.MinorCategories.Add(mc));

            context.SaveChanges();

            new List<ItemCategory> {
                new ItemCategory() { MinorCategoryId = 1, ItemCategoryName = "Peaches" },
                new ItemCategory() { MinorCategoryId = 2, ItemCategoryName = "Peas" },
                new ItemCategory() { MinorCategoryId = 3, ItemCategoryName = "Flour" },
                new ItemCategory() { MinorCategoryId = 4, ItemCategoryName = "Sugar" }
            }.ForEach(ic => context.ItemCategories.Add(ic));

            context.SaveChanges();
        }
    }
}

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
                new MinorCategory() { MajorCategoryId = 1, MinorCategoryName = "Fruit" },
                new MinorCategory() { MajorCategoryId = 1, MinorCategoryName = "Vegetables" },
                new MinorCategory() { MajorCategoryId = 2, MinorCategoryName = "Flour" },
                new MinorCategory() { MajorCategoryId = 2, MinorCategoryName = "Sugar" }
            }.ForEach(mc => context.MinorCategories.Add(mc));

            context.SaveChanges();

            new List<ItemCategory> {
                new ItemCategory() { MinorCategoryId = 1, ItemCategoryName = "Peaches", HasItemCategory = true },
                new ItemCategory() { MinorCategoryId = 2, ItemCategoryName = "Peas", HasItemCategory = true },
                new ItemCategory() { MinorCategoryId = 3, ItemCategoryName = "Flour", HasItemCategory = false },
                new ItemCategory() { MinorCategoryId = 4, ItemCategoryName = "Sugar", HasItemCategory = false }
            }.ForEach(ic => context.ItemCategories.Add(ic));

            context.SaveChanges();
        }
    }
}

using GroceryChoice.Model;
using System.Collections.Generic;
using System.Data.Entity;

namespace GroceryChoice.Repository
{
    public class GroceryDbInitializer : DropCreateDatabaseAlways<GroceryContext>
    {
        public void InitializeDatabase(GroceryContext context)
        {
            if (!context.Database.Exists())
            {
                context.Database.Create();
                Seed(context);
                context.SaveChanges();
            }
        }
        
        protected override void Seed(GroceryContext context)
        {
            new List<BrandGrocery> {
                new BrandGrocery() { UPC = "024000016717", Brand = "Del Monte", Description = "Sliced Peaches in Heavy Syrup", Size = "15.25 oz", MajorCategoryId = 1, MinorCategoryId = 1, ItemCategoryId = 1 },
                new BrandGrocery() { UPC = "024000132097", Brand = "Del Monte", Description = "No Sugar Added Sliced Pears", Size = "15.25 oz", MajorCategoryId = 1, MinorCategoryId = 1, ItemCategoryId = 2 },
                new BrandGrocery() { UPC = "024000163084", Brand = "Del Monte", Description = "Sweet Peas", Size = "15 oz", MajorCategoryId = 1, MinorCategoryId = 2, ItemCategoryId = 3 },
                new BrandGrocery() { UPC = "016000106109", Brand = "Gold Medal", Description = "All-Purpose Enriched Bleached Flour", Size = "5 lb", MajorCategoryId = 2, MinorCategoryId = 3, ItemCategoryId = 4 },
                new BrandGrocery() { UPC = "070090304104", Brand = "Crystal Sugar", Description = "Granulated Sugar", Size = "4 lb", MajorCategoryId = 2, MinorCategoryId = 4, ItemCategoryId = 5 }
            }.ForEach(bg => context.BrandGroceries.Add(bg));

            context.SaveChanges();

            new List<GenericGrocery> {
                new GenericGrocery() { BrandGroceryId = 1, UPC = "011110828774", Store = "Kroger", StoreBrand = "Kroger", Description = "Sliced Peaches in Heavy Syrup", Size = "15.25 oz" },
                new GenericGrocery() { BrandGroceryId = 1, UPC = "041190015023", Store = "ShopRite", StoreBrand = "ShopRite", Description = "Sliced Peaches in Heavy Syrup", Size = "15.25 oz" },
                new GenericGrocery() { BrandGroceryId = 2, UPC = "011110859396", Store = "Kroger", StoreBrand = "Kroger Value", Description = "Sweet Peas", Size = "15 oz" },
                new GenericGrocery() { BrandGroceryId = 2, UPC = "077890287057", Store = "Wegman's", StoreBrand = "Wegman's", Description = "Sweet Peas", Size = "15 oz" },
                new GenericGrocery() { BrandGroceryId = 3, UPC = "075450048551", Store = "Hy-Vee", StoreBrand = "Hy-Vee", Description = "All-Purpose Enriched Bleached Flour", Size = "5 lb" },
                new GenericGrocery() { BrandGroceryId = 3, UPC = "021130530014", Store = "Safeway", StoreBrand = "Safeway", Description = "All-Purpose Enriched Bleached Flour", Size = "5 lb" },
                new GenericGrocery() { BrandGroceryId = 4, UPC = "050428451809", Store = "CVS", StoreBrand = "Gold Emblem", Description = "Granulated Sugar", Size = "4 lb" },
                new GenericGrocery() { BrandGroceryId = 4, UPC = "605388004222", Store = "Walmart", StoreBrand = "Great Value", Description = "Granulated Sugar", Size = "4 lb" }
            }.ForEach(gg => context.GenericGroceries.Add(gg));

            context.SaveChanges();
        }
    }
}

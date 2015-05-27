using System.Data.Entity;
using GroceryChoice.Model;

namespace GroceryChoice.Repository
{
    public class CategoryContext : DbContext
    {
        public CategoryContext() : base("GroceryChoiceDb")
        {
            Database.SetInitializer<CategoryContext>(new CategoryDbInitializer());
        }

        public DbSet<MajorCategory> MajorCategories { get; set; }
        public DbSet<MinorCategory> MinorCategories { get; set; }
        public DbSet<ItemCategory> ItemCategories { get; set; }
    }
}

using GroceryChoice.Model;
using System.Data.Entity;

namespace GroceryChoice.Repository
{
    public class GroceryContext : DbContext
    {
        public GroceryContext() : base("GroceryChoiceDb")
        {
            Database.SetInitializer<GroceryContext>(new GroceryDbInitializer());
        }

        public DbSet<BrandGrocery> BrandGroceries { get; set; }
        public DbSet<GenericGrocery> GenericGroceries { get; set; }
    }
}

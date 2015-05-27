using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceryChoice.Model;

namespace GroceryChoice.Repository
{
    public class GroceryRepository : IGroceryRepository
    {
        private GroceryContext context = new GroceryContext();
        
        public IEnumerable<BrandGrocery> BrandGroceries
        {
            get
            {
                return context.BrandGroceries;
            }
        }

        public async Task<int> SaveBrandGroceryAsync(BrandGrocery brandGrocery)
        {
            if (brandGrocery.BrandGroceryId == 0)
            {
                context.BrandGroceries.Add(brandGrocery);
            }
            else
            {
                BrandGrocery dbEntry = context.BrandGroceries.Find(brandGrocery.BrandGroceryId);
                if (dbEntry != null)
                {
                    dbEntry.UPC = brandGrocery.UPC;
                    dbEntry.Brand = brandGrocery.Brand;
                    dbEntry.Description = brandGrocery.Description;
                    dbEntry.Size = brandGrocery.Size;
                }
            }

            return await context.SaveChangesAsync();
        }

        public async Task<BrandGrocery> DeleteBrandGroceryAsync(int brandGroceryID)
        {
            BrandGrocery dbEntry = context.BrandGroceries.Find(brandGroceryID);
            if (dbEntry != null)
            {
                context.BrandGroceries.Remove(dbEntry);
            }

            await context.SaveChangesAsync();
            return dbEntry;
        }

        public IEnumerable<GenericGrocery> GenericGroceries
        {
            get
            {
                return context.GenericGroceries;
            }
        }

        public async Task<int> SaveGenericGroceryAsync(GenericGrocery genericGrocery)
        {
            if (genericGrocery.GenericGroceryId == 0)
            {
                context.GenericGroceries.Add(genericGrocery);
            }
            else
            {
                GenericGrocery dbEntry = context.GenericGroceries.Find(genericGrocery.GenericGroceryId);
                if (dbEntry != null)
                {
                    dbEntry.BrandGroceryId = genericGrocery.BrandGroceryId;
                    dbEntry.UPC = genericGrocery.UPC;
                    dbEntry.Store = genericGrocery.Store;
                    dbEntry.StoreBrand = genericGrocery.StoreBrand;
                    dbEntry.Description = genericGrocery.Description;
                    dbEntry.Size = genericGrocery.Size;
                }
            }

            return await context.SaveChangesAsync();
        }

        public async Task<GenericGrocery> DeleteGenericGroceryAsync(int genericGroceryID)
        {
            GenericGrocery dbEntry = context.GenericGroceries.Find(genericGroceryID);
            if (dbEntry != null)
            {
                context.GenericGroceries.Remove(dbEntry);
            }

            await context.SaveChangesAsync();
            return dbEntry;
        }

        public List<GenericGrocery> FindAllGenericGroceries(int id)
        {
            List<GenericGrocery> genericGroceries = (from c in context.GenericGroceries
                                                 where id == c.BrandGroceryId
                                                 select c).ToList();

            return genericGroceries;
        }
    }
}

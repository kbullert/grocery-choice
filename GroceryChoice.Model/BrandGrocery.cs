namespace GroceryChoice.Model
{
    public class BrandGrocery
    {
        public int BrandGroceryId { get; set; }
        public string UPC { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public int MajorCategoryId { get; set; }
        public int MinorCategoryId { get; set; }
        public int? ItemCategoryId { get; set; }
    }
}

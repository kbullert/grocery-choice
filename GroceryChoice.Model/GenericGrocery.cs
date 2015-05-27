namespace GroceryChoice.Model
{
    public class GenericGrocery
    {
        public int GenericGroceryId { get; set; }
        public int BrandGroceryId { get; set; }
        public string UPC { get; set; }
        public string Store { get; set; }
        public string StoreBrand { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public int MajorCategoryId { get; set; }
        public int MinorCategoryId { get; set; }
        public int? ItemCategoryId { get; set; }
    }
}

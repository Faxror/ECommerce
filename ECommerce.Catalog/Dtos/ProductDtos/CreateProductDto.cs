namespace ECommerce.Catalog.Dtos.ProductDtos
{
    public class CreateProductDto
    {
        public string ProdcutName { get; set; }
        public Decimal ProdcutPrice { get; set; }
        public int ProdcutStock { get; set; }
        public string ProdcutImageUrl { get; set; }
        public string ProdcutDescription { get; set; }
        public string CategoryID { get; set; }
    }
}

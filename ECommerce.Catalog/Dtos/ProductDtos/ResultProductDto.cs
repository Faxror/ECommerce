namespace ECommerce.Catalog.Dtos.ProductDtos
{
    public class ResultProductDto
    {
        public string ProdcutID { get; set; }
        public string ProdcutName { get; set; }
        public Decimal ProdcutPrice { get; set; }
        public int ProdcutStock { get; set; }
        public string ProdcutImageUrl { get; set; }
        public string ProdcutDescription { get; set; }
        public string CategoryID { get; set; }
    }
}

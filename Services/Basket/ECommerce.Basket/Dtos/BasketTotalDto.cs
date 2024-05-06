namespace ECommerce.Basket.Dtos
{
    public class BasketTotalDto
    {
        public string UserId { get; set; }
        public string DiscountCode { get; set; }
        public int DiscountRate { get; set; }

        public List<BasketİtemDto> Basketİtems { get; set; }

        public decimal TotalPrice { get => Basketİtems.Sum(x => x.Price * x.Quantity); }
    }
}

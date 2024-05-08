namespace  ECommerce.Dto.CatalogDtos.CommentDtos
{
    public class UpdateCommentDto
    {
        public int UserCommentId { get; set; }

        public string NameSurname { get; set; }
        public string? İmageUrl { get; set; }

        public string Email { get; set; }
        public string CommentDetail { get; set; }
        public int Rating { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool Status { get; set; }

        public string ProductId { get; set; }
    }
}

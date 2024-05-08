using ECommerce.Comment.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Comment.Context
{
    public class CommentContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1442; initial Catalog=ECommerceCommentDb;  User=sa; Password=1234567aA*");
            base.OnConfiguring(optionsBuilder);

        }

        public DbSet<UserComment> userComments { get; set; }
    }
}

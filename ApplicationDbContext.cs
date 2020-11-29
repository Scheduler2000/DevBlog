
using DevBlog.Models;

using Microsoft.EntityFrameworkCore;

namespace DevBlog
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<ArticleModel> Articles { get; set; }

        public DbSet<SubscriberModel> Subscribers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

    }
}

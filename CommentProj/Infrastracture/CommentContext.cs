using CommentProj.Models;
using System.Data.Entity;

namespace CommentProj.Infrastracture
{
    public class CommentContext : DbContext
    {
        public CommentContext() : base("CommentDb")
        { }

        public DbSet<Comment> Comments { get; set; }
    }
}
using System.ComponentModel.DataAnnotations.Schema;
namespace API.Entities
{
    [Table("Posts")]
    public class Post
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public string Content { get; set; }
        public string Type { get; set; } // Programming, Travel ETC.
        public int Upvotes { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
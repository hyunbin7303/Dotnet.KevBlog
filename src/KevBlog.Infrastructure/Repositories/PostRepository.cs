using KevBlog.Domain.Constants;
using KevBlog.Domain.Entities;
using KevBlog.Domain.Repositories;
using KevBlog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace KevBlog.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly DataContext _dbContext;
        public PostRepository(DataContext dbContext)
        {
            this._dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task CreateAsync(Post post)
        {
            _dbContext.Posts.Add(post);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Post> GetPostById(int id)
        {
            return await _dbContext.Posts.Where(x => x.Id == id).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Post>> GetPostsByUserName(string userName)
        {
            return await _dbContext.Posts.Where(x => x.User.UserName == userName).ToListAsync();
        }
        public async Task<IEnumerable<Post>> GetPostsAsync()
        {
            return await _dbContext.Posts.AsNoTracking().Include(u => u.User).ToListAsync();
        }
        public async Task RemoveAsync(int id)
        {
            _dbContext.Posts.Remove(new Post { Id = id });
        }

        public async Task UpdateAsync(Post user)
        {
            _dbContext.Entry(user).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
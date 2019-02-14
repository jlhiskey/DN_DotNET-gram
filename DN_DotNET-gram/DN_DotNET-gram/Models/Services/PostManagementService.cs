using DN_DotNET_gram.Data;
using DN_DotNET_gram.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DN_DotNET_gram.Models.Services
{
    /// <summary>
    /// Handles Post related database services.
    /// </summary>
    public class PostManagementService : IPostManager
    {
        private readonly DotNetgramDBContext _context;

        public PostManagementService(DotNetgramDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Delete post using post.ID as search criteria.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Task</returns>
        public async Task DeleteAsync(int id)
        {
            Post post = await _context.Posts.FindAsync(id);
            if (post != null)
            {
                _context.Remove(post);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        ///  Finds a post and returns it using post.ID as search criteria.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Post</returns>
        public async Task<Post> FindPost(int id)
        {
            Post post = await _context.Posts.FirstOrDefaultAsync(p => p.ID == id);

            return post;
        }

        /// <summary>
        /// Returns a list containing all existing Posts.
        /// </summary>
        /// <returns>List<Post></returns>
        public async Task<List<Post>> GetPosts()
        {
            return await _context.Posts.ToListAsync();
        }

        /// <summary>
        /// Either creates or updates a post.
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        public async Task SaveAsync(Post post)
        {
            //If existing post isnt found then post is added.
            if (await _context.Posts.FirstOrDefaultAsync(p => p.ID == post.ID) == null)
            {
                _context.Posts.Add(post);
            }
            //If existing post is found then post is updated
            else
            {
                _context.Posts.Update(post);
            }
            await _context.SaveChangesAsync();
        }
    }
}

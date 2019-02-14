using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DN_DotNET_gram.Models.Interfaces
{
    public interface IPostManager
    {
        /// <summary>
        /// Delete post using post.ID as search criteria.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Task</returns>
        Task DeleteAsync(int id);

        /// <summary>
        /// Finds a post and returns it using post.ID as search criteria.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Post</returns>
        Task<Post> FindPost(int id);

        /// <summary>
        /// Returns a list containing all existing Posts.
        /// </summary>
        /// <returns>List<Post></Post></returns>
        Task<List<Post>> GetPosts();

        /// <summary>
        /// Either creates or updates a post.
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        Task SaveAsync(Post post);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DN_DotNET_gram.Models.Interfaces
{
    interface IPostManager
    {
        //Add Post
        Task CreatePost(Post post);

        //Edit Post
        Task EditPost(Post post);

        //Delete Post
        Task DeletePost(Post post);

        //Get Post
        Task<Post> GetPost(int id);

        //Get All Posts
        Task<IEnumerable<Post>> GetPosts();

    }
}

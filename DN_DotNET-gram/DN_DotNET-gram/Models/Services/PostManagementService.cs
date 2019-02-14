using DN_DotNET_gram.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DN_DotNET_gram.Models.Services
{
    public class PostManagementService : IPostManager
    {
        public Task CreatePost(Post post)
        {
            throw new NotImplementedException();
        }

        public Task DeletePost(Post post)
        {
            throw new NotImplementedException();
        }

        public Task EditPost(Post post)
        {
            throw new NotImplementedException();
        }

        public Task<Post> GetPost(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Post>> GetPosts()
        {
            throw new NotImplementedException();
        }
    }
}

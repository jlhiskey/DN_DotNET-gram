using DN_DotNET_gram.Data;
using DN_DotNET_gram.Models;
using DN_DotNET_gram.Models.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DotNetGramServicesTestSuite
{
    public class DotNetGramServicesTestSuite
    {
        public Post CreatePost()
        {
            Post testPost = new Post { ID = 1, Name = "Ricky Bobby", Details = "Shake and Bake", URL = "www.rickybobby.com" };
            return testPost;
        }

        [Fact]
        public async void CanCreatePost()
        {
            DbContextOptions<DotNetgramDBContext> options = new DbContextOptionsBuilder<DotNetgramDBContext>().UseInMemoryDatabase("CreatePost").Options;

            using (DotNetgramDBContext context = new DotNetgramDBContext(options))
            {
                Post testPost = CreatePost();

                PostManagementService postService = new PostManagementService(context);

                await postService.SaveAsync(testPost);

                var result = context.Posts.FirstOrDefault(a => a.ID == testPost.ID);

                Assert.Equal(testPost, result);
            }
        }

        [Fact]
        public async void CanUpdatePost()
        {
            DbContextOptions<DotNetgramDBContext> options = new DbContextOptionsBuilder<DotNetgramDBContext>().UseInMemoryDatabase("UpdatePost").Options;

            using (DotNetgramDBContext context = new DotNetgramDBContext(options))
            {
                Post testPost = CreatePost();

                PostManagementService postService = new PostManagementService(context);

                await postService.SaveAsync(testPost);

                testPost = context.Posts.FirstOrDefault(a => a.ID == testPost.ID);

                testPost.Name = "Tom Riddle";

                await postService.SaveAsync(testPost);

                var result = context.Posts.FirstOrDefault(a => a.ID == testPost.ID);

                Assert.Equal(testPost, result);
            }
        }

        [Fact]
        public async void CanFindPost()
        {
            DbContextOptions<DotNetgramDBContext> options = new DbContextOptionsBuilder<DotNetgramDBContext>().UseInMemoryDatabase("FindPost").Options;

            using (DotNetgramDBContext context = new DotNetgramDBContext(options))
            {
                Post testPost = CreatePost();

                PostManagementService postService = new PostManagementService(context);

                await postService.SaveAsync(testPost);

                Post expected = context.Posts.FirstOrDefault(a => a.ID == testPost.ID);
                Post actual = await postService.FindPost(testPost.ID);

                Assert.Equal(expected, actual);
            }
        }

        [Fact]
        public async void CanFindAllPosts()
        {
            DbContextOptions<DotNetgramDBContext> options = new DbContextOptionsBuilder<DotNetgramDBContext>().UseInMemoryDatabase("FindPosts").Options;

            using (DotNetgramDBContext context = new DotNetgramDBContext(options))
            {
                Post testPost1 = CreatePost();
                Post testPost2 = CreatePost();
                testPost2.ID = 2;

                List<Post> listPosts = new List<Post> { testPost1, testPost2 };

                PostManagementService postService = new PostManagementService(context);

                await postService.SaveAsync(testPost1);
                await postService.SaveAsync(testPost2);

                IEnumerable<Post> expected = listPosts;
                IEnumerable<Post> actual = await postService.GetPosts();

                Assert.Equal(expected, actual);
            }
        }

        [Fact]
        public async void CanDeletePost()
        {
            DbContextOptions<DotNetgramDBContext> options = new DbContextOptionsBuilder<DotNetgramDBContext>().UseInMemoryDatabase("DeletePost").Options;

            using (DotNetgramDBContext context = new DotNetgramDBContext(options))
            {
                Post testPost = CreatePost();

                PostManagementService postService = new PostManagementService(context);

                await postService.SaveAsync(testPost);
                await postService.DeleteAsync(testPost.ID);

                var result = context.Posts.FirstOrDefault(a => a.ID == testPost.ID);

                Assert.Null(result);
            }
        }
    }
}

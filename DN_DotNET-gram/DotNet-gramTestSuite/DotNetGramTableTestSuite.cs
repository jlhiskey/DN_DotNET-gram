using DN_DotNET_gram.Models;
using System;
using Xunit;

namespace DotNetGramTableTestSuite
{
    public class DotNetGramTableTestSuite
    {
        public Post CreatePost()
        {
            Post testPost = new Post { ID = 1, Name = "Ricky Bobby", Details = "Shake and Bake", URL = "www.rickybobby.com" };
            return testPost;
        }

        [Fact]
        public void TestIDSet()
        {
            Post testPost = new Post();
            testPost.ID = 1;
            Assert.Equal(1, testPost.ID);
        }

        [Fact]
        public void TestIDGet()
        {
            Post testPost = CreatePost();
            Assert.Equal(1, testPost.ID);
        }

        [Fact]
        public void TestNameSet()
        {
            Post testPost = new Post();
            testPost.Name = "JimBob";
            Assert.Equal("JimBob", testPost.Name);
        }

        [Fact]
        public void TestNameGet()
        {
            Post testPost = CreatePost();
            Assert.Equal("Ricky Bobby", testPost.Name);
        }

        [Fact]
        public void TestDetailsSet()
        {
            Post testPost = new Post();
            testPost.Details = "Details are in here.";
            Assert.Equal("Details are in here.", testPost.Details);
        }

        [Fact]
        public void TestDetailsGet()
        {
            Post testPost = CreatePost();
            Assert.Equal("Shake and Bake", testPost.Details);
        }

        [Fact]
        public void TestURLSet()
        {
            Post testPost = new Post();
            testPost.URL = "www.testingURL.com";
            Assert.Equal("www.testingURL.com", testPost.URL);
        }

        [Fact]
        public void TestURLGet()
        {
            Post testPost = CreatePost();
            Assert.Equal("www.rickybobby.com", testPost.URL);
        }
    }
}

using DN_DotNET_gram.Models;
using System;
using Xunit;

namespace DotNetGramServicesTestSuite
{
    public class DotNetGramServicesTestSuite
    {
        public Post CreateComp()
        {
            Post testPost = new Post { ID = 1, Name = "Ricky Bobby", Details = "Shake and Bake", URL = "www.rickybobby.com" };
            return testPost;
        }

        [Fact]
        public void Test1()
        {

        }
    }
}

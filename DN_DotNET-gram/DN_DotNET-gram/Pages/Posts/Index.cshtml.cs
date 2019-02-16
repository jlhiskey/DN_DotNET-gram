using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using DN_DotNET_gram.Models;
using DN_DotNET_gram.Models.Interfaces;

namespace DN_DotNET_gram.Pages.Posts
{
    public class IndexModel : PageModel
    {
        private readonly IPostManager _post;

        public IndexModel(IPostManager post)
        {
            _post = post;
        }

        /// <summary>
        /// Sets ID
        /// </summary>
        [FromRoute]
        public int ID { get; set; }

        /// <summary>
        /// Holding spot for Post
        /// </summary>
        public Post Post { get; set; }

        /// <summary>
        /// Sets Post from DB using ID
        /// </summary>
        /// <returns></returns>
        public async Task OnGet()
        {
            // set all the data for my .cshtml page.

            // Get the specific Restaurant data for the id that was sent. 
            Post = await _post.FindPost(ID);
        }
    }
}
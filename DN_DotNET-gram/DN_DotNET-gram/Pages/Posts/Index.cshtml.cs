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

        [FromRoute]
        public int ID { get; set; }
        public Post post { get; set; }

        public async Task OnGet()
        {
            // set all the data for my .cshtml page.

            // Get the specific Restaurant data for the id that was sent. 
            post = await _post.FindPost(ID);
        }
    }
}
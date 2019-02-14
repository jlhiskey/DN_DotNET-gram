using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using DN_DotNET_gram.Models;
using DN_DotNET_gram.Models.Interfaces;

namespace DN_DotNET_gram.Pages.Posts
{
    public class ManageModel : PageModel
    {
        private readonly IPostManager _post;

        public ManageModel(IPostManager post)
        {
            _post = post;
        }

        /// <summary>
        /// Sets the ID
        /// </summary>
        [FromRoute]
        public int? ID { get; set; }

        /// <summary>
        /// Holding Spot for Post
        /// </summary>
        [BindProperty]
        public Post Post { get; set; }

        /// <summary>
        /// Sets the Post
        /// </summary>
        /// <returns>Post</returns>
        public async Task OnGet()
        {
            Post = await _post.FindPost(ID.GetValueOrDefault()) ?? new Post();
        }

        /// <summary>
        /// Saves updated or new post into database and redirects to Index Page.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPost()
        {
            var post = await _post.FindPost(ID.GetValueOrDefault()) ?? new Post();

            post.Name = Post.Name;
            post.URL = Post.URL;
            post.Details = Post.Details;

            await _post.SaveAsync(post);

            return RedirectToPage("/Index", new { id = post.ID });
        }

        /// <summary>
        /// Deletes post from database and redirects to Index Page
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPostDelete()
        {
            await _post.DeleteAsync(ID.Value);
            return RedirectToPage("/Index");
        }
    }
}
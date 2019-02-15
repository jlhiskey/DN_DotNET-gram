using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using DN_DotNET_gram.Models;
using DN_DotNET_gram.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using System.IO;
using DN_DotNET_gram.Models.Util;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage.Blob;

namespace DN_DotNET_gram.Pages.Posts
{
    public class ManageModel : PageModel
    {
        private readonly IPostManager _post;

        public ManageModel(IPostManager post, IConfiguration configuration)
        {
            _post = post;

            BlobImage = new Blob(configuration);
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

        [BindProperty]
        public IFormFile Image { get; set; }

        public Blob BlobImage { get; set; }

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
           
            post.Details = Post.Details;

            if(Image != null)
            {
                var filePath = Path.GetTempFileName();

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await Image.CopyToAsync(stream);
                }

                //Retrieve a container
                var container = await BlobImage.GetContainer("pictures");

                //Upload image
                BlobImage.UploadFile(container, Image.FileName, filePath);

                CloudBlob blob = await BlobImage.GetBlob(Image.FileName, container.Name);

                post.URL = blob.Uri.ToString();
            }

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
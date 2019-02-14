using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DN_DotNET_gram.Models
{
    public class Post
    {
        /// <summary>
        /// Post ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Post Details
        /// </summary>
        public string Details { get; set; }
        /// <summary>
        /// Post Comments
        /// </summary>
        public string[] Comments { get; set; }

        /// <summary>
        /// Image URL
        /// </summary>
        public string URL { get; set; }
    }
}

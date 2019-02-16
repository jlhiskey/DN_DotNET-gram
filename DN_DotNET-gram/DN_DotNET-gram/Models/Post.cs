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
        /// Author of Post
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Post Details
        /// </summary>
        public string Details { get; set; }
        
        /// <summary>
        /// Image URL
        /// </summary>
        public string URL { get; set; }
    }
}

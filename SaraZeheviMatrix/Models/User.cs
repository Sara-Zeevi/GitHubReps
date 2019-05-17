using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SaraZeheviMatrix.Models
{    /// <summary>
    /// user information
   /// </summary>
    public class User
     {  /// <summary>
        /// user neme of user
        /// </summary>
        [Required]
        public string UserName { get; set; }
        /// <summary>
        /// email of user
        /// </summary>
        [Required(ErrorMessage = "Please enter Social Email id")]
        public string Email { get; set; }
        /// <summary>
        /// password of user
        /// </summary>
        [Required]
        public string Password { get; set; }
        public virtual List<string> Bookmarks { get; set; }

    }
}
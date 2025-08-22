﻿using System.ComponentModel.DataAnnotations;

namespace ApiJWT.Models
{
    public class RegisterModel
    {
        [Required, StringLength(100)]
        public string FirstName { get; set; }

        [Required, StringLength(100)]
        public string LastName { get; set; }

        [Required, StringLength(50)]
        public string Username { get; set; }

        [Required, StringLength(125)]
        public string Email { get; set; }

        [Required, StringLength(250)]
        public string Password { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gutr.Models
{
    public class NoteCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string Title { get; set; }

        [MinLength(5, ErrorMessage = "Please enter at least 5 characters.")]
        [MaxLength(500)]
        public string Content { get; set; }

        public int FavoriteId { get; set; }
        public string Email { get; set; }

        public override string ToString() => Title;
       

    }
}

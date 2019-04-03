﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gutr.Models
{
    public class NoteListItem
    {
        public string userEmail { get; set; }
        public int NoteId { get; set; }
        public string Title { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        public override string ToString() => Title;
    }
}
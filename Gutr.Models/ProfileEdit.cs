﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gutr.Models
{
    public class ProfileEdit
    { 
        public Guid OwnerId { get; set; } 
        public string Name { get; set; }

        public string Summary { get; set; }

        public string Url { get; set; }

        public string ImageUrl { get; set; }
    }
}

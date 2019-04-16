using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gutr.Data
{
    public class Profile
    {
        [Key]
        public Guid OwnerId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Summary { get; set; }

        public string Url { get; set; }

        public string Email { get; set; }
    }
}

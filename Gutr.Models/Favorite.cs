using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gutr.Models
{
    public class Favorite
    {
        public Guid OwnerId { get; set; }
        public int FavoriteId { get; set; }
        public int NoteId { get; set; }
    }
}

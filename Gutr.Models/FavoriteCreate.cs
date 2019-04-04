using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gutr.Models
{
    public class FavoriteCreate
    {
        public NoteCreate Note { get; set; }
        
        //public int FavoriteId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gutr.Data
{
    public class Favorite
    {
        
        public int Id { get; set; }

        public bool FavoriteBool { get; set; }
    }
}

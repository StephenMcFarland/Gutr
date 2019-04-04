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
        
        public Guid Id { get; set; }

        public virtual Note Note { get; set; }
    }
}

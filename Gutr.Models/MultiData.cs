using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gutr.Models;

namespace Gutr.Models
{
    public class MultiData
    {
        public IEnumerable<ProfileDetail> Profiles { get; set; }

        public IEnumerable<NoteListItem> Notes { get; set; }
    }
}
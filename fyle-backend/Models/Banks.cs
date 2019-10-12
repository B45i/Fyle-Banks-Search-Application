using System;
using System.Collections.Generic;

namespace fyle_backend.Models
{
    public partial class Banks
    {
        public Banks()
        {
            Branches = new HashSet<Branches>();
        }

        public string Name { get; set; }
        public long Id { get; set; }

        public virtual ICollection<Branches> Branches { get; set; }
    }
}

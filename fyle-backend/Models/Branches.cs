using System;
using System.Collections.Generic;

namespace fyle_backend.Models
{
    public partial class Branches
    {
        public string Ifsc { get; set; }
        public long? BankId { get; set; }
        public string Branch { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string State { get; set; }

        public virtual Banks Bank { get; set; }
    }
}

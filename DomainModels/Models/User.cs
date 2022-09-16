using DomainModels.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Models
{
    public class User : Entity
    {
        public string Username { get; set; }

        public byte[] PassHash { get; set; }

        public byte[] PassSalt { get; set; }
    }
}

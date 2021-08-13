using System;
using System.Collections.Generic;

#nullable disable

namespace Miniprojekti.Models
{
    public partial class Person
    {
        public Person()
        {
            Messages = new HashSet<Message>();
        }

        public int PersonId { get; set; }
        public string NickName { get; set; }
        public string Hometown { get; set; }
        public string Description { get; set; }
        public byte[] Photo { get; set; }
        public string Password { get; set; }
        public int? PasswordHash { get; set; }
        public DateTime? RegistrationDate { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
    }
}

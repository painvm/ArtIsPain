using ArtIsPain.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArtIsPain.Shared
{
    public class User : Person, INamed
    {
        public string Username { get; set; }

        public DateTime LastLoginDate { get; set; }

        public DateTime RegistrationDate { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
using ArtIsPain.Shared.Interfaces;
using System;

namespace ArtIsPain.Shared.Models
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
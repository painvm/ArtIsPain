using System;
using System.Collections.Generic;
using System.Text;

namespace ArtIsPain.Shared
{
    public class UserEntity : HumanBeingEntity
    {
        public string Username { get; set; }

        public DateTime LastLoginDate { get; set; }

        public DateTime RegistrationDate { get; set; }
    }
}
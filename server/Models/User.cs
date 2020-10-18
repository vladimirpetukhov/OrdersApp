using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Server.API.Models
{
    public class User : IdentityUser<int>
    {
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string KnownAs { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string Introduction { get; set; }
        public string LookingFor { get; set; }
        public string Interests { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public virtual ICollection<Photo> Photos { get; set; } = new HashSet<Photo>();
        public virtual ICollection<Like> Likers { get; set; } = new List<Like>();
        public virtual ICollection<Like> Likees { get; set; } = new List<Like>();
        public virtual ICollection<Message> MessagesSent { get; set; } = new HashSet<Message>();
        public virtual ICollection<Message> MessagesReceived { get; set; } = new HashSet<Message>();
        public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
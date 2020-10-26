using Suls.Data.LoL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Suls.Data
{
    public class User
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.UserGames = new HashSet<UserGames>();
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public virtual ICollection<UserGames> UserGames { get; set; }
    }
}

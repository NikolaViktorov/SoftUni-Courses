using System.ComponentModel.DataAnnotations;

namespace Suls.Data
{
    public class UserTrip
    {
        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public string TripId { get; set; }

        public virtual Trip Trip { get; set; }
    }
}

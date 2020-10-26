using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using SharedTrip.Data;
using SharedTrip.ViewModels.Trips;

namespace SharedTrip.Services
{
    public class TripsService : ITripsService
    {
        private readonly ApplicationDbContext db;

        public TripsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public bool AddUserToTrip(string userId, string tripId)
        {
            var userInTrip = this.db.UserTrips.Any(x => x.UserId == userId && x.TripId == tripId);
            if (userInTrip)
            {
                return false;
            }

            var userTrip = new UserTrip
            {
                UserId = userId,
                TripId = tripId
            };

            this.db.UserTrips.Add(userTrip);
            this.db.SaveChanges();
            return true;
        }

        public void Create(AddTripInputModel input)
        {
            var trip = new Trip
            {
                StartPoint = input.StartPoint,
                EndPoint = input.EndPoint,
                Seats = input.Seats,
                ImagePath = input.ImagePath,
                Description = input.Description,
                DepartureTime = DateTime.ParseExact(input.DepartureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture)
            };

            this.db.Trips.Add(trip);
            this.db.SaveChanges();
        }

        public IEnumerable<TripViewModel> GetAll()
        {
            var trips = this.db.Trips.Select(t => new TripViewModel
            {
                StartPoint = t.StartPoint,
                EndPoint = t.EndPoint,
                Seats = t.Seats,
                DepartureTime = t.DepartureTime,
                Id = t.Id,
                UsedSeats = t.UserTrips.Count()
            }).ToList();

            return trips;
        }

        public TripDetailsViewModel GetDetails(string tripId)
        {
            var trip = this.db.Trips.Where(t => t.Id == tripId).Select(t => new TripDetailsViewModel
            {
                Id = tripId,
                ImagePath = t.ImagePath,
                DepartureTime = t.DepartureTime,
                StartPoint = t.StartPoint,
                EndPoint = t.EndPoint,
                Description = t.Description,
                Seats = t.Seats,
                UsedSeats = t.UserTrips.Count()
            }).FirstOrDefault();

            return trip;
        }

        public bool HasAvailableSeats(string tripId)
        {
            var trip = this.db.Trips.Where(t => t.Id == tripId)
                .Select(t => new { t.Seats, TakenSeats = t.UserTrips.Count() })
                .FirstOrDefault();
            var availableSeats = trip.Seats - trip.TakenSeats;
            return availableSeats > 0;
        }
    }
}

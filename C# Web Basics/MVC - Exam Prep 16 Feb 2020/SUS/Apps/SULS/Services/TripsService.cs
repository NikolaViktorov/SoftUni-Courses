using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Suls.Data;
using Suls.ViewModels.Trips;

namespace Suls.Services
{
    public class TripsService : ITripsService
    {
        private readonly ApplicationDbContext db;

        public TripsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(TripInputModel model)
        {
            var trip = new Trip
            {
                StartPoint = model.StartPoint,
                EndPoint = model.EndPoint,
                DepartureTime = DateTime.Parse(model.DepartureTime),
                ImagePath = model.ImagePath,
                Seats = model.Seats,
                Description = model.Description
            };

            this.db.Trips.Add(trip);
            this.db.SaveChanges();
        }

        public IEnumerable<HomePageTripViewModel> GetAll()
        {
            var trips = this.db.Trips.Select(x => new HomePageTripViewModel
            {
                StartPoint = x.StartPoint,
                EndPoint = x.EndPoint,
                Seats = x.Seats,
                DepartureTime = x.DepartureTime,
                Id = x.Id
            }).ToList();

            return trips;
        }

        public TripViewModel GetById(string tripId)
        {
            return this.db.Trips.Where(x => x.Id == tripId)
                .Select(x => new TripViewModel 
                {
                    Id = x.Id,
                    StartPoint = x.StartPoint,
                    EndPoint = x.EndPoint,
                    DepartureTime = x.DepartureTime,
                    Description = x.Description,
                    Seats = x.Seats,
                    ImagePath = x.ImagePath
                }).FirstOrDefault();
        }

        public bool AddUserToTrip(string userId, string tripId)
        {
            var con = this.db.UsersTrips.Where(x => x.UserId == userId && x.TripId == tripId).FirstOrDefault();
            if (con == null)
            {
                this.db.UsersTrips.Add(new UserTrip
                {
                    UserId = userId,
                    TripId = tripId
                });
                this.db.SaveChanges();

                return true;
            }

            return false;
        }
    }
}

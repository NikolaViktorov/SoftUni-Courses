using Suls.ViewModels.Trips;
using System;
using System.Collections.Generic;
using System.Text;

namespace Suls.Services
{
    public interface ITripsService
    {
        void Create(TripInputModel model);

        IEnumerable<HomePageTripViewModel> GetAll();

        TripViewModel GetById(string tripId);
        bool AddUserToTrip(string userId, string tripId);
    }
}

using Suls.Services;
using Suls.ViewModels.Trips;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Suls.Controllers
{
    public class TripsController : Controller
    {
        private readonly ITripsService tripsService;

        public TripsController(ITripsService tripsService)
        {
            this.tripsService = tripsService;
        }

        public HttpResponse Add()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(TripInputModel input)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrEmpty(input.StartPoint))
            {
                return this.Error("Start point required!");
            }
            if (string.IsNullOrEmpty(input.EndPoint))
            {
                return this.Error("End point required!");
            }
            if (string.IsNullOrEmpty(input.DepartureTime) || !DateTime.TryParse(input.DepartureTime, out _))
            {
                return this.Error("Departure time required!");
            }
            if (input.Seats < 2 || input.Seats > 6)
            {
                return this.Error("Seats should be between 2 and 6!");
            }
            if (string.IsNullOrEmpty(input.Description))
            {
                return this.Error("Description required!");
            }

            this.tripsService.Create(input);

            return this.Redirect("/Trips/All");
        }

        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = this.tripsService.GetAll();

            return this.View(viewModel);
        }

        public HttpResponse Details(string tripId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = this.tripsService.GetById(tripId);

            return this.View(viewModel);
        }

        public HttpResponse AddUserToTrip(string tripId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();
            if (this.tripsService.AddUserToTrip(userId, tripId))
            {
                return this.Redirect("/Trips/All");
            }

            return this.Redirect($"/Trips/Details?tripId={tripId}");

        }
    }
}

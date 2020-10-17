using BattleCards.Data;
using BattleCards.ViewModels;
using BattleCards.ViewModels.Cards;
using Microsoft.EntityFrameworkCore;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using BattleCards.Services;

namespace BattleCards.Controllers
{
    public class CardsController : Controller
    {
        private readonly ICardsService cardsService;

        public CardsController(ICardsService cardsService)
        {
            this.cardsService = cardsService;
        }
        // GET /cards/add
        public HttpResponse Add()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            return this.View();
        }

        [HttpPost("/Cards/Add")]
        public HttpResponse DoAdd(AddCardInputModel model)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }


            if (string.IsNullOrEmpty(model.Name) || model.Name.Length < 5 || model.Name.Length > 15)
            {
                return this.Error("Name should be between 5 and 15 characters long.");
            }

            if (string.IsNullOrWhiteSpace(model.Image) )
            {
                return this.Error("The image is required!");
            }

            if (!Uri.TryCreate(model.Image, UriKind.Absolute, out _))
            {
                return this.Error("Image url should be valid");
            }

            if (string.IsNullOrWhiteSpace(model.Keyword))
            {
                return this.Error("Keyword is required.");
            }

            if (model.Attack < 0)
            {
                this.Error("The attack should be non-negative number.");
            }

            if (model.Health < 0)
            {
                this.Error("The health should be non-negative number.");
            }

            if (string.IsNullOrWhiteSpace(model.Description) || model.Description.Length > 200)
            {
                return this.Error("Description is required with max length 200 characters.");
            }


            var cardId = this.cardsService.AddCard(model);

            var userId = this.GetUserId();
            this.cardsService.AddCardToUserCollection(userId, cardId);

            return this.Redirect("/Cards/All");
        }

        // /cards/all
        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var cardsViewModel = this.cardsService.GetAll().ToList();

            return this.View(cardsViewModel);
        }

        // /cards/collection
        public HttpResponse Collection()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();
            var viewModel = this.cardsService.GetByUserId(userId);

            return this.View(viewModel);
        }

        public HttpResponse AddToCollection(int cardId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();
            this.cardsService.AddCardToUserCollection(userId, cardId);

            return this.Redirect("/Cards/All");
        }

        public HttpResponse RemoveFromCollection(int cardId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();
            this.cardsService.RemoveCardToUserCollection(userId, cardId);

            return this.Redirect("/Cards/Collection");
        }
    }
}

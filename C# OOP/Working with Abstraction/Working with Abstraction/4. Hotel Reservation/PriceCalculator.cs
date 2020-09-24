using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservation
{
    public static class PriceCalculator
    {
        private static decimal TotalPrice = 0;
        
        public static decimal GetTotalPrice()
        {
            return TotalPrice;
        }
        public static void CalculatePirce(decimal pricePerDay, int numberOfDays,
            string season, string discountType)
        {
            TotalPrice += pricePerDay * numberOfDays;
            switch (season)
            {
                case "Summer":
                    TotalPrice *= 4;
                    break;
                case "Spring":
                    TotalPrice *= 2;
                    break;
                case "Autumn":
                    TotalPrice *= 1;
                    break;
                case "Winter":
                    TotalPrice *= 3;
                    break;
            }
            switch (discountType)
            {
                case "VIP":
                    TotalPrice -= TotalPrice * (decimal)0.2;
                    break;
                case "SecondVisit":
                    TotalPrice -= TotalPrice * (decimal)0.1;
                    break;
                default:
                    break;
            }
        }

    }
}

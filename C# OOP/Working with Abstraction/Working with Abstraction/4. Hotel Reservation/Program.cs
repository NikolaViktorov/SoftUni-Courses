using System;

namespace HotelReservation
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] reservationDetails = Console.ReadLine()
                .Split();

            decimal pricePerDay = decimal.Parse(reservationDetails[0]);
            int numberOfDays = int.Parse(reservationDetails[1]);
            string season = reservationDetails[2];
            string discountType = null;
            try
            {
                 discountType = reservationDetails[3];
            }
            catch (Exception)
            {
            }

            PriceCalculator.CalculatePirce(pricePerDay, numberOfDays, season, discountType);
            Console.WriteLine($"{PriceCalculator.GetTotalPrice():F2}");
        }
    }
}

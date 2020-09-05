using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChennaiSuburbanRailway
{

    public class Pricing
    {
        /// <summary>
        /// List of stations
        /// </summary>
        enum Station
        {
            Chennai_Beach=1,
            Chennai_Fort,
            Chennai_Park,
            Chennai_Egmore,
            Chetpet,
            Nungambakkam,
            Kodambakkam,
            Mambalam,
            Saidapet,
            Guindy,
            St_Thomas_Mount,
            Pazhavanthangal,
            Meenambakkam,
            Trisulam,
            Pallavaram,
            Chromepet,
            Tambaram_Sanatorium,
            Tambaram
        }

        /// <summary>
        /// To calculate basic pricing
        /// </summary>
        /// <param name="fromStation">Station from</param>
        /// <param name="toStation">Station to</param>
        /// <param name="numberOfStops">Number of stops</param>
        /// <returns>Ticket total price</returns>
        private double CalculatePricing(int fromStation, int toStation, int numberOfStops)
        {
            double price=10.00;         
            
            double totalPrice = numberOfStops>=17 ? 20.00 :(numberOfStops > 15 ? price + 15.00 :(numberOfStops >10 ?  price + 10.00 : (numberOfStops > 5 ?  price + 5.00 : price ))) ;
            
            return totalPrice;
        }

        /// <summary>
        /// Calculate pricing based on passengers age
        /// </summary>
        /// <param name="age">Passengers age</param>
        /// <param name="price">Total price</param>
        /// <returns>Age-wise ticket total price</returns>
        private double ReturnAgeWisePricing(int age, double price)
        {
            double returnAgeWisePrice = age < 3 ? 0 : (age < 10) ? 0.75 * price : price;
            return returnAgeWisePrice;
        }

        /// <summary>
        /// Calculate return ticket price
        /// </summary>
        /// <param name="returnTicket">Return ticket condition(Y/N)</param>
        /// <param name="totalPrice">Total price</param>
        /// <returns>Return-ticket total price</returns>
        private double ReturnTicketPricing(char returnTicket,double totalPrice)
        {
            return totalPrice = returnTicket == 'Y' ? totalPrice * 1.75 : totalPrice;
        }

        /// <summary>
        /// Ticket-Booking system
        /// </summary>
        public void TicketBooking()
        {            
            Console.WriteLine("Welcome to Chennai Suburban Railway");
            Console.WriteLine("-----------------------------------");

            int i = 1;
            foreach (string name in Enum.GetNames(typeof(Pricing.Station)))
            {
                Console.WriteLine(i + "." + name);
                i++;
            }
            Console.WriteLine("Please enter the stop number from the list you are boarding from : ");
            int fromStation = int.Parse(Console.ReadLine());

            Console.WriteLine("-----------------------------------");
            int j = 1;

            foreach (string name in Enum.GetNames(typeof(Pricing.Station)))
            {
                Console.WriteLine(j + "." + name);
                j++;
            }
            Console.WriteLine("Please enter the stop number from the list you want to reach : ");
            int toStation = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter your age : ");
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine("Do you want a return ticket (Y:N) : ");
            char returnTicket = Convert.ToChar(Console.ReadLine());


            int numberOfStops = Math.Abs(fromStation - toStation);
            double totalPrice = this.CalculatePricing(fromStation, toStation, numberOfStops);

            totalPrice = this.ReturnAgeWisePricing(age, totalPrice);
            totalPrice = this.ReturnTicketPricing(returnTicket, totalPrice);

            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Purchase Date & Time : " + DateTime.Now);
            Console.WriteLine("From Station : " + Enum.GetName(typeof(Pricing.Station), fromStation));
            Console.WriteLine("To station: " + Enum.GetName(typeof(Pricing.Station), toStation));
            if (returnTicket == 'Y')
            {
                Console.WriteLine("From Station : " + Enum.GetName(typeof(Pricing.Station), fromStation));
                numberOfStops = numberOfStops * 2;
            }
            Console.WriteLine(numberOfStops + " stops");
            Console.WriteLine("Total price :" + totalPrice);
            Console.WriteLine("---------------------------------------");
            Console.ReadLine();
        }
    }
}

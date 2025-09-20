/*
 * Bridger Davidson
 * CST-250
 * 09/09/2025
 * VehicleClassLibrary - Motorcycle Model
 * Activity 1 - In class activity
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleClassLibrary2._2.Models
{

    public class MotorcycleModel : VehicleModel
    {
        // Class level props
        public bool HasSideCar { get; set; }
        public decimal SeatHeight { get; set; }

        /// <summary>
        /// Default Constructor with VehicleModel as base
        /// </summary>
        public MotorcycleModel() : base()
        {
            HasSideCar = false;
            SeatHeight = 0;
        }

        /// <summary>
        /// Perameterized Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="make"></param>
        /// <param name="model"></param>
        /// <param name="year"></param>
        /// <param name="price"></param>
        /// <param name="numOfWheels"></param>
        /// <param name="hasSideCar"></param>
        /// <param name="seatHeight"></param>
        public MotorcycleModel(int id, string make, string model, int year, decimal price, int numOfWheels, string color, int mileage, bool hasSideCar, decimal seatHeight) : base(id, make, model, year, price, numOfWheels, color, mileage)
        {
            HasSideCar = hasSideCar;
            SeatHeight = seatHeight;
        }

        /// <summary>
        /// ToString Method for printing a motorcycle
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            // Print the vehicle in the following format using string interpolation...
            // 1: 2001 Harley Davidson Cruiser with 2 wheels and a 38 inch tall seat with(out) a side car - $1,500.00
            string sideCar = HasSideCar ? "with" : "without";
            return $"{Id}: {Year} {Color} {Make} {Model} with {NumOfWheels} and a {SeatHeight} inch tall seat {sideCar} a side car, {Mileage} miles on the engine - {Price:C2}";
        }

    }
}

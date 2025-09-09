/*
 * Bridger Davidson
 * CST-250
 * 09/09/2025
 * VehicleClassLibrary - Car Model
 * Activity 1 - In class activity
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleClassLibrary2._2.Models
{
    public class CarModel : VehicleModel
    {

        // Class level props
        public bool IsConvertable { get; set; }
        public decimal TrunkSize { get; set; }

        /// <summary>
        /// Default constructor
        /// Use base attribute to also call our VehicleModel Constructor
        /// </summary>
        public CarModel() : base()
        {
            IsConvertable = false;
            TrunkSize = 0m;
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
        public CarModel(int id, string make, string model, int year, decimal price, int numOfWheels, bool isConvertable, decimal trunkSize) : base(id, make, model, year, price, numOfWheels)
        {
            // Notice how the base identifies which perameters are from the VehicleModel class
            IsConvertable = isConvertable;
            TrunkSize = trunkSize;
        }

        /// <summary>
        /// ToString Method for printing a car
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            // Use a ternary operator (in-line if) to get the convertible string
            string convertable = IsConvertable ? "with" : "without";

            // Print the vehicle in the following format using string interpolation...
            // 1: 2022 Honda Civic with 4 wheels and a 14.7 cubic foot trunk with(out) a convertable top - $27,000.00

            return $"{Id}: {Year} {Make} {Model} with {NumOfWheels} and a {TrunkSize} cubic foot trunk {convertable} a convertable top - {Price:C2}";
        }
    }
}

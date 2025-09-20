/*
 * Bridger Davidson
 * CST-250
 * 09/09/2025
 * VehicleClassLibrary - Pickup Model
 * Activity 1 - In class activity
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleClassLibrary2._2.Models
{
    public class PickupModel : VehicleModel
    {
        // Class level props
        public decimal BedLength { get; set; }
        public bool HasTopper { get; set; }

        /// <summary>
        /// Default Constructor using VehicleModel as base
        /// </summary>
        public PickupModel() : base()
        {
            BedLength = 0;
            HasTopper = false;
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
        /// <param name="hasTopper"></param>
        /// <param name="bedLength"></param>
        public PickupModel(int id, string make, string model, int year, decimal price, int numOfWheels, string color, int mileage, bool hasTopper, decimal bedLength) : base(id, make, model, year, price, numOfWheels, color, mileage)
        {
            HasTopper = hasTopper;
            BedLength = bedLength;
        }

        /// <summary>
        /// ToString Method for printing a pickup
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            // 1: 1994 Chevy Siverado with 4 wheels and a 7 foot bed with(out) a topper - $1,500.00
            string topper = HasTopper ? "with" : "without";
            return $"{Id}: {Year} {Color} {Make} {Model} with {NumOfWheels} wheels and a {BedLength} foot bed {topper} a topper, {Mileage} miles on the engine - {Price:C2}";
        } 
    }
}

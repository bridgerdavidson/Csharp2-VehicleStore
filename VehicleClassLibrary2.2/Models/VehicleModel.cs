/*
 * Bridger Davidson
 * CST-250
 * 09/09/2025
 * VehicleClassLibrary
 * Activity 1 - In class activity
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleClassLibrary2._2.Models
{
    // Internal means the class is only accessable within the same assembly (dll or exe) (folder)
    // Public means it is accessable from any assembly
    public class VehicleModel
    {
        // Class level props
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public int NumOfWheels { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public VehicleModel()
        {
            Id = 0;
            Make = "Unknown";
            Model = "Unknown";
            Year = 0;
            Price = 0;
            NumOfWheels = 0;
        }

        /// <summary>
        /// Parameterized Constructor for the vehicle model class
        /// </summary>
        /// <param name="id"></param>
        /// <param name="make"></param>
        /// <param name="model"></param>
        /// <param name="year"></param>
        /// <param name="price"></param>
        /// <param name="numOfWheels"></param>
        public VehicleModel(int id, string make, string model, int year, decimal price, int numOfWheels)
        {
            Id = id;
            Make = make;
            Model = model;
            Year = year;
            Price = price;
            NumOfWheels = numOfWheels;
        }

        /// <summary>
        /// ToString method for printing a vehicle
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            // Print the vehicle in the following format...
            // 1: 2022 Honda Civic with 4 wheels - $800.00
            return $"{Id}: {Year} {Make} {Model} with {NumOfWheels} wheels - {Price:C2}";
        }
    }
}

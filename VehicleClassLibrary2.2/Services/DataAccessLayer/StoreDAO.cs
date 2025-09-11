/*
 * Bridger Davidson
 * CST-250
 * 09/09/2025
 * VehicleClassLibrary - DAO
 * Activity 1 - In class activity
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleClassLibrary2._2.Models;

namespace VehicleClassLibrary2._2.Services.DataAccessLayer
{
    // Since this class will be used by both the console and winforms, make it public
    public class StoreDAO
    {
        //-----------------------------------------------------------
        // Using the VehicleModel class instead of any of the more specific models
        // the OOP pillar of polymorphism. Our inventory and shopping cart lists will be able
        // to hold data of the VehicleModel type as well as any classes that extend the model,
        // such as the CarModel, MotorcycleModel, and the PickupModel.
        //-----------------------------------------------------------

        private List<VehicleModel> _inventory;

        private List<VehicleModel> _shoppingCart;

        // Declare and Initialize private vars
        // The directory for the inventory text file
        private string _fileDirectory = "Data";
        // The name of the inventory text file
        private string _textFile = "inventory.txt";
        // The full path to the text file
        private string _filePath;

        /// <summary>
        /// Default Constructor
        /// It's purpose is to initialize the props
        /// </summary>
        public StoreDAO()
        {
            // Initialize the vehicle model list (create a new instance of the list)
            _inventory = new List<VehicleModel>();
            _shoppingCart = new List<VehicleModel>();
            // Set up the file to the inventory text file
            // Build the full file path by combining the apps base directory,
            // The subdirectory name and the text file name.
            _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory , _fileDirectory, _textFile);
        }

        /// <summary>
        /// Get a list of vehicles in the inventory
        /// Return inventory to the business logic layer
        /// </summary>
        /// <returns></returns>
        public List<VehicleModel> GetInventory()
        {
            return _inventory;
        }

        /// <summary>
        /// Get a list of vehicles in the shopping cart
        /// Return shopping cart to the business logic layer
        /// </summary>
        /// <returns></returns>
        public List<VehicleModel> GetShoppingCart() 
        {
            return _shoppingCart;
        }

        /// <summary>
        /// Add a new vehicle to the inventory
        /// Returns the vehicle added id
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public int AddVehicleToInventory(VehicleModel vehicle)
        {
            // Set the id for the new vehicle
            vehicle.Id = _inventory.Count + 1;
            // Add the vehicle to the inventory list
            _inventory.Add(vehicle);
            return vehicle.Id;
        }

        /// <summary>
        /// Add a vehicle to the shopping cart using an id
        /// Returns number of vehicles in the shopping cart
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <returns></returns>
        public int AddVehicleToCart(int vehicleId)
        {
            // Loop thru the inventory to find the correct vehicle
            // Loop = (starting point, condition, increment)
            for (int i = 0; i < _inventory.Count; i++)
            {
                if (_inventory[i].Id == vehicleId)
                {
                    // If true add vehicle to shopping cart
                    _shoppingCart.Add(_inventory[i]);
                }
            }

            // Return number of items in shopping cart
            return _shoppingCart.Count;
        }

        /// <summary>
        /// Get the total of the users shopping cart and clear the cart
        /// </summary>
        /// <returns></returns>
        public decimal Checkout()
        {
            decimal total = 0m;
            foreach (VehicleModel vehicle in _shoppingCart)
            {
                total += vehicle.Price;
            }

            //Clear the cart
            _shoppingCart.Clear();

            return total;
        }
    }
}

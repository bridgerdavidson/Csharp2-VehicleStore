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

        /// <summary>
        /// Write the inventory to a text file
        /// </summary>
        /// <returns></returns>
        public bool WriteInventory()
        {
            // Check if the directory exsists
            if (!Directory.Exists(_fileDirectory))
            {
                // If it doesn't exist
                Directory.CreateDirectory(_fileDirectory);
            }
            try
            {
                // Create the stream writer to write to the file
                using StreamWriter writer = new StreamWriter(_filePath);
                {
                    foreach (VehicleModel vehicle in _inventory)
                    {
                        Type type = vehicle.GetType();
                        switch (type.Name)
                        {
                            case "CarModel":
                                CarModel car = (CarModel)vehicle;
                                writer.WriteLine($"Car, {car.Make}, {car.Model}, {car.Year}, {car.Price}, {car.NumOfWheels}, {car.IsConvertable}, {car.TrunkSize}");
                                break;

                            case "MotorcycleModel":
                                MotorcycleModel motorcycle = (MotorcycleModel)vehicle;
                                writer.WriteLine($"Motorcycle, {motorcycle.Make}, {motorcycle.Model}, {motorcycle.Year}, {motorcycle.Price}, {motorcycle.NumOfWheels}, {motorcycle.HasSideCar}, {motorcycle.SeatHeight}");
                                break;

                            case "PickupModel":
                                PickupModel pickup = (PickupModel)vehicle;
                                writer.WriteLine($"Pickup, {pickup.Make}, {pickup.Model}, {pickup.Year}, {pickup.Price}, {pickup.NumOfWheels}, {pickup.HasTopper}, {pickup.BedLength}");
                                break;

                            default:
                                writer.WriteLine($"Vehicle, {vehicle.Make}, {vehicle.Model}, {vehicle.Year}, {vehicle.Price}, {vehicle.NumOfWheels}, {vehicle.HasTopper}, {vehicle.BedLength}");
                                break;
                        }
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        } // End of Write inventory

        /// <summary>
        /// Read the list of vehicles from a text file
        /// </summary>
        /// <returns></returns>
        public List<VehicleModel> ReadInventory()
        {
            string? line = "";
            string[] parts = [];
            string make = "", model = "";
            int year = 0, numOfWheels = 0;
            decimal price = 0m;

            bool isConvertable = false, hasSideCar = false, hasTopper = false;
            decimal trunkSize = 0m, seatHeight = 0, bedLength = 0;

            try
            {
                if(File.Exists(_filePath))
                {
                    using (StreamReader reader = new StreamReader(_filePath))
                    {
                        while ((line = reader.ReadLine()) != null)
                        {
                            // Split the line just read in on the commas
                            parts = line.Split(", ");

                            // Use the parts array to get the common data
                            make = parts[1];
                            model = parts[2];
                            year = ParseInteger(parts[3]);
                            price = ParseInteger(parts[4]);
                            numOfWheels = ParseInteger(parts[5]);

                            // Use the first piece of data to create a swithc for the specific model
                            switch(parts[0])
                            {
                                case "Car":
                                    isConvertable = ParseBoolean(parts[6]);
                                    trunkSize = ParseDecimal(parts[7]);
                                    CarModel car = new CarModel(0, make, model, year, price, numOfWheels, isConvertable, trunkSize);
                                    AddVehicleToInventory(car);
                                    break;

                                case "Motorcycle":
                                    hasSideCar = ParseBoolean(parts[6]);
                                    seatHeight = ParseDecimal(parts[7]);
                                    MotorcycleModel motorcycle = new MotorcycleModel(0, make, model, year, price, numOfWheels, hasSideCar, seatHeight);
                                    AddVehicleToInventory(motorcycle);
                                    break;

                                case "Pickup":
                                    hasTopper = ParseBoolean(parts[6]);
                                    bedLength = ParseDecimal(parts[7]);
                                    PickupModel pickup = new PickupModel(0, make, model, year, price, numOfWheels, hasTopper, bedLength);
                                    AddVehicleToInventory(pickup);
                                    break;

                                default:
                                    VehicleModel vehicle = new VehicleModel(0, make, model, year, price, numOfWheels);
                                    AddVehicleToInventory(vehicle);
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                // Return the inventory as is
                return _inventory;
            }
            // Return the read inventory
            return _inventory;
        } // End of ReadInventory

        /// <summary>
        /// Method to safely parse an int
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private int ParseInteger(string input)
        {
            try
            {
                // Parse the input and return
                return int.Parse(input);
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        /// <summary>
        /// Method to safely parse a decimal
        /// </summary>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <returns></returns>
        private decimal ParseDecimal(string input)
        {
            try
            {
                return decimal.Parse(input);
            }
            catch (Exception e)
            {
                return 0m;
            }
        }

        /// <summary>
        /// Method to safely parse a bool
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private bool ParseBoolean(string input)
        {
            try
            {
                return bool.Parse(input);
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

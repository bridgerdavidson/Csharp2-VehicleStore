/*
 * Bridger Davidson
 * CST-250
 * 09/13/2025
 * VehicleClassLibrary - StoreLogic
 * Activity 1 - In class activity
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleClassLibrary2._2.Models;
using VehicleClassLibrary2._2.Services.DataAccessLayer;

namespace VehicleClassLibrary2._2.Services.BusinessLogicLayer
{
    public class StoreLogic
    {
        // Declare class level variable
        private StoreDAO _storeDAO;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public StoreLogic()
        {
            _storeDAO = new StoreDAO();
        }

        /// <summary>
        /// Get inventory from storeDAO
        /// </summary>
        /// <returns></returns>
        public List<VehicleModel> GetInventory()
        {
            return _storeDAO.GetInventory();
        }

        /// <summary>
        /// Get shopping cart from store
        /// </summary>
        /// <returns></returns>
        public List<VehicleModel> GetShoppingCart()
        {
            return _storeDAO.GetShoppingCart();
        }

        /// <summary>
        /// Add vehicle to inventory
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public int AddVehicleToInventory(VehicleModel vehicle)
        {
            // Call and return the AddVehicleToInventory method in the DAO
            return _storeDAO.AddVehicleToInventory(vehicle);
        }

        /// <summary>
        /// Add vehicle to cart
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public int AddVehicleToCart(int vehicleId)
        {
            return _storeDAO.AddVehicleToCart(vehicleId);
        }

        /// <summary>
        /// Write the inventory to a text file
        /// </summary>
        public void WriteInventory()
        {
            _storeDAO.WriteInventory();
        }
        /// <summary>
        /// Read the list of vehicles from a text file
        /// </summary>
        /// <returns></returns>
        public List<VehicleModel> ReadInventory()
        {
            return _storeDAO.ReadInventory();
        }

        /// <summary>
        /// Checkout pulling from the DAO
        /// </summary>
        /// <returns></returns>
        public decimal Checkout()
        {
            return _storeDAO.Checkout();
        }

    }
}

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
        public int AddVehicleToCart(VehicleModel vehicle)
        {
            return _storeDAO.AddVehicleToCart(vehicle.Id);
        }

        // Add checkout method
        public decimal Checkout()
        {
            return _storeDAO.Checkout();
        }

        // HOMEWORK:
        // Complete the activity guide steps 42-50
    }
}

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
    }
}

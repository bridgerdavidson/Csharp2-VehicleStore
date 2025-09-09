
//Bridger Davidson
//CST-250

using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Schema;
using VehicleClassLibrary2._2.Models;

namespace VehicleClassLibrary.Tests
{
    public class StoreLogicTests
    {
        [Fact]
        public void AddVehicleToInventory_ShouldIncreaseInventoryCount()
        {
            StoreLogic store = new StoreLogic();
            CarModel car = new CarModel
            {
                Id = 1,
                Make = 'Honda',
                Model = 'Civic',
                Year = 2022,
                Price = 25000m,
                NumOfWheels = 4,
                IsConvertable = true,
                TrunkSize = 2.5m
            };

            store.AddVehicleToInventory(car);

            List<VehicleModel> inventory = store.GetInventory();

            Assert.Contains(car, inventory);
        }

        [Fact]
        public void GetInventory_ShouldReturnEmptyList_WhenNoVehicles_Added()
        {
            StoreLogic store = new StoreLogic();
            List<VehicleModel> inventory = store.GetInventory();
            Assert.Empty(inventory);
        }

        [Fact]
        public void AddVehicleToCart_ShouldAddVehicle_WhenValidVehicleIdGiven()
        {
            StoreLogic store = new StoreLogic();
            CarModel car = new CarModel
            {
                Id = 1,
                Make = 'Honda',
                Model = 'Civic',
                Year = 2022,
                Price = 25000m,
                NumOfWheels = 4,
                IsConvertable = true,
                TrunkSize = 2.5m
            };

            store.AddVehicleToInventory(car);

            int result = store.AddVehicleToCart(car.Id);

            List<VehicleModel> cart = store.GetShoppingCart();
            Assert.Equal(1, result);
            Assert.Contains(cart, verify => verify.Id == car.Id);
        }
        [Fact]
        public void GetShoppingCart_ShouldReturnEmptyList_WhenNoVehiclesAdded()
        {
            StoreLogic store = new StoreLogic();
            List<VehicleModel> cart = store.GetShoppingCart();
            Assert.Empty(cart);
        }
        [Fact]
        public void Checkout_ShouldReturnCorrectTotal_AndClearCart()
        {
            StoreLogic store = new StoreLogic();
            CarModel car1 = new CarModel
            {
                Id = 3,
                Make = 'Ford',
                Model = 'F-150',
                Year = 2021,
                Price = 40000m,
                NumOfWheels = 4,
                IsConvertable = true,
                TrunkSize = 2.5m
            };
            CarModel car2 = new CarModel
            {
                Id = 4,
                Make = 'Chevy',
                Model = 'Silverado',
                Year = 2022,
                Price = 45000m,
                NumOfWheels = 4,
                IsConvertable = true,
                TrunkSize = 2.5m
            };

            store.AddVehicleToInventory(car1);
            store.AddVehicleToInventory(car2);

            store.AddVehicleToCart(car1);
            store.AddVehicleToCart(car2);

            decimal total = store.Checkout();

            List<VehicleModel> cartAfterCheckout = store.GetShoppingCart();

            Assert.True(total >= (car1.Price + car2.Price) * 0.95m);
            Assert.True(total <= (car1.Price + car2.Price) * 1.05m);

            Assert.Empty(cartAfterCheckout);
        }
    }
}
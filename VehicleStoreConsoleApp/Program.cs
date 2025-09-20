/*
 * Bridger Davidson
 * CST-250
 * 09/16/2025
 * VehicleClassLibrary - Program
 * Activity 1 - In class activity
 */

//---------------------------------------------
// Start of Entry Point (Main Method)
//---------------------------------------------

// Print a welcome message to the user
using System;
using System.Numerics;
using System.Runtime.ExceptionServices;
using System.Xml;
using VehicleClassLibrary2._2.Models;
using VehicleClassLibrary2._2.Services.BusinessLogicLayer;

Console.WriteLine("Welcome to the Vehicle Shop! \n\nTo begin, please create a selection of vehicles and add them to the inventory. Once The inventory is populated, you can proceed by adding vehicles to your cart. \n\nFinally, when you're ready to complete your purchase, proceed to the checkout where your total bill will be calculated.");

// Call the control loop function to manage the app running
ControlLoop();

//---------------------------------------------
// End of Entry Point (Main Method)
//---------------------------------------------

// Read an integer input from the user
// This is a function and not a method
// static - can not be instantiated
static int ReadChoice()
{
    // Declare and Initalize
    // Set input as a nullable refrence type

    // "Declare input as a string and initalize it as an empty string"
    string? input = "";
    int choice = -1;

    // Loop until the user enters a valid choice
    while(choice <= 1 || choice > 7)
    {
        // Print menu
        Console.Write("Choose an action:\n" +
            "0) Quit\n" +
            "1) Print the inventory\n" +
            "2) Print the shopping cart\n" +
            "3) Create a vehicle\n" +
            "4) Add a vehicle to the shopping cart\n" +
            "5) Checkout\n" +
            "6) Save inventory to text file\n" +
            "7) Load inventory from a text file\n" +
            "Please select an action: ");

        // Read the user input from the console based on keyboard enter being pressed
        input = Console.ReadLine();

        // Make sure the user entered a value
        if (!string.IsNullOrEmpty(input))
        {
            try
            {
                // Try to convert the user input (string) into an integer
                choice = int.Parse(input);
            }
            catch (FormatException)
            {
                // Handles the case where the input was not in a valid number format
                Console.WriteLine("Please enter a valid number only instead of alphanumeric.");
            }
            catch (OverflowException)
            {
                // Handles the case where the number entered is too large or too small for an int
                Console.WriteLine("Please enter a valid number. The number entered was either too small or too large.");
            }
            catch (Exception e)
            {
                // Catch any other unexpected exceptions and show the error message
                Console.WriteLine("There was an exception " + e.ToString() + ". Please try again.");
            }

            // Check if the parsed number is within a valid range 0-7
            if (choice >= 0 && choice <= 7)
            {
                return choice; // Valid input in range, so return immediately
            }
            else
            {
                // If the number was parsed successfully but not in the 0-7 range
                Console.WriteLine("Please enter a number from 0 to 7.");
            }
        }
    }
    return choice;
}

// Control the Vehicle Store Loop
// This enables us to keep the Main entry point clean by taking the code
// that manages the entire app and uer input in this Contorl Loop
static void ControlLoop()
{
    // Create an instance of our store logic class
    StoreLogic storeLogic = new StoreLogic();
    // Create a list to hold multiple VehicleModel objects
    List<VehicleModel> vehicleList = new List<VehicleModel>();
    // Create a single VehicleModel
    VehicleModel vehicle = new VehicleModel();
    VehicleModel myVehicle = new VehicleModel();

    // Declare and initialize
    int choice = -1;
    decimal total = 0m;

    // Set a flag to determine entry validity
    bool isValid = false;

    // Continue the loop until the user enters 0 to quit
    while(choice != 0)
    {
        // Get input from user
        choice = ReadChoice();

        switch (choice)
        {
            case 0:
                Console.WriteLine("Have a nice day!");
                break;
            // Print inventory
            case 1:

                // Print inventory
                PrintInventory(storeLogic, vehicleList);
                Console.WriteLine();
                break;
            // Print Shopping Cart
            case 2:
                // Get the shopping car list from storeLogic
                vehicleList = storeLogic.GetShoppingCart();
                // Print the shopping cart
                Console.WriteLine("Shopping cart: ");
                foreach(VehicleModel inventoryVehicle in vehicleList)
                {
                    Console.WriteLine(inventoryVehicle); 
                }
                Console.WriteLine();
                break;

            // Create a vehicle
            case 3:
                // Create a vehicle and put in inventory
                // Read the type of vehicle
                Console.Write("Enter 1) to Create a Car, 2) to Create a Motorcycle, or 3) to Create a Pickup: ");

                // Do not leave this loop until we have a valid input
                // Iterate through the process once before you test it
                do
                {
                    // Get the input
                    if (int.TryParse(Console.ReadLine(), out choice))
                    {
                        // Make sure the choice is in the range
                        if (choice >= 1 && choice <= 3)
                        {
                            // Set flag to true
                            isValid = true;

                            // Get the common props for the vehicle
                            Console.Write("Enter the make of the vehicle: ");
                            myVehicle.Make = Console.ReadLine();
                            Console.Write("Enter the model of the vehicle: ");
                            myVehicle.Model = Console.ReadLine();
                            Console.Write("Enter the year of the vehicle: ");
                            myVehicle.Year = int.Parse(Console.ReadLine());
                            Console.Write("Enter the price of the vehicle: ");
                            myVehicle.Price = decimal.Parse(Console.ReadLine());
                            Console.Write("Enter the number of wheels on the vehicle: ");
                            myVehicle.NumOfWheels = int.Parse(Console.ReadLine());
                            Console.Write("Enter the number of wheels on the vehicle: ");
                            myVehicle.Color = Console.ReadLine();
                            Console.Write("Enter the number of wheels on the vehicle: ");
                            myVehicle.Mileage = int.Parse(Console.ReadLine());

                            // Lets take the specific vehicle props out to a function
                            vehicle = GetVehicleSpecificProp(choice, myVehicle);
                        }
                    }
                    else
                    {
                        Console.WriteLine("The entry is not valid. Please enter a number from 1 to 3.");
                    }
                } while (!isValid);

                // Add the vehicle to the inventory
                storeLogic.AddVehicleToInventory(vehicle);
                Console.WriteLine();
                break;
            // Add a vehicle to the shopping cart
            case 4:
                int id;

                // Print the inventory to make it easy for the user to pick an id
                PrintInventory(storeLogic, vehicleList);
                // Get the id of the vehicle from the user (with error checking)
                Console.WriteLine("Enter the id of the vehicle you want to buy: ");
                while(true)
                {
                    if (int.TryParse(Console.ReadLine(), out id))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Enter an integer.");
                    }
                }
                // Add it to the cart
                storeLogic.AddVehicleToCart(id);
                Console.WriteLine() ;
                break;
            // Checkout
            case 5:
                // Checkout the user
                total = storeLogic.Checkout();
                Console.WriteLine("Your total is: $" + total);
                Console.WriteLine();
                break;
            // Save inventory to text file
            case 6:
                // Use the business logic layer to write the inventory to the file
                storeLogic.WriteInventory();
                // Print success message
                Console.WriteLine("The inventory has been saved to the text file");
                Console.WriteLine();
                break;
            // Load inventory from a text file
            case 7:
                // Use the business logic layer to read the inventory from the file
                storeLogic.ReadInventory();
                // Print success message
                Console.WriteLine("The inventory has been read from the text file");
                Console.WriteLine();
                break;

            // Other input
            default:
                Console.WriteLine("Invalid Input!");
                Console.WriteLine();
                break;

        }
    }

    // Print the inventory
    static void PrintInventory(StoreLogic storeLogic, List<VehicleModel> vehicleList)
    {
        vehicleList = storeLogic.GetInventory();
        // Print inventory
        Console.WriteLine("Inventory:");
        // Loop and print every vehicle
        foreach (VehicleModel inventoryVehicle in vehicleList)
        {
            Console.WriteLine(inventoryVehicle);
        }
    }

}

// Get vehicle specific props
static VehicleModel GetVehicleSpecificProp(int choice, VehicleModel vehicle)
{
    // Declare and init (specialty vehicle variables)
    bool isConvertable = false, hasSideCar = false, hasTopper = false;
    decimal trunkSize = 0m, seatHeight = 0m, bedLength = 0m;

    // If statement since we only have 3 to read the vehicle specific props
    if(choice == 1)
    {
        // Car

        // Read the convertible status for the car
        Console.Write("Enter if the car is a convertable (true/false): ");
        isConvertable = StringToBoolUserInput();

        // Read the trunk size
        Console.Write("Enter the trunk size for the car in cubic feet: ");
        trunkSize = StringToDecimalUserInput();

        // Make CarModel
        return new CarModel(vehicle.Id, vehicle.Make, vehicle.Model, vehicle.Year, vehicle.Price, vehicle.NumOfWheels, vehicle.Color, vehicle.Mileage, isConvertable, trunkSize);
    }
    else if (choice == 2)
    {
        // Motorcycle

        // Read the side car status for the motorcycle
        Console.Write("Enter if the motorcycle has a side car (true/false): ");
        hasSideCar = StringToBoolUserInput();

        // Read the seat height
        Console.Write("Enter the seat height for the motorcycle in inches: ");
        seatHeight = StringToDecimalUserInput();

        // Make MotorcycleModel
        return new MotorcycleModel(vehicle.Id, vehicle.Make, vehicle.Model, vehicle.Year, vehicle.Price, vehicle.NumOfWheels, vehicle.Color, vehicle.Mileage, hasSideCar, seatHeight);
    }
    else
    {
        // Pickup

        // Read the topper status for the pickup
        Console.WriteLine("Enter if the pickup has a topper (true/false): ");
        hasTopper = StringToBoolUserInput();

        // Read the bed length
        Console.Write("Enter the bed length for the pickup in feet: ");
        bedLength = StringToDecimalUserInput();

        // Make MotorcycleModel
        return new PickupModel(vehicle.Id, vehicle.Make, vehicle.Model, vehicle.Year, vehicle.Price, vehicle.NumOfWheels, vehicle.Color, vehicle.Mileage, hasTopper, bedLength);
    }

}
// Safely converts a string to a boolean with error checking
static bool StringToBoolUserInput()
{
    while (true)
    {
        bool output;
        if (bool.TryParse(Console.ReadLine(), out output))
        {
            return output;
        }
        else
        {
            Console.WriteLine("Enter true or false. Try again.");
        }
    }
}
static decimal StringToDecimalUserInput()
{
    while (true)
    {
        decimal output;
        if (decimal.TryParse(Console.ReadLine(), out output))
        {
            return output;
        }
        else
        {
            Console.WriteLine("Enter true or false. Try again.");
        }
    }
}



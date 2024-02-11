using System.Reflection;
using ModernAppliances.Entities;
using ModernAppliances.Entities.Abstract;
using ModernAppliances.Helpers;

namespace ModernAppliances
{
    /// <summary>
    /// Manager class for Modern Appliances
    /// This manager class is responsible for managing the appliances in the store. When the program starts, it loads a list of appliances from a file. 
    /// The user can then perform various operations on the appliances, such as checking out an appliance, finding appliances, 
    /// and displaying appliances of various types. The manager class is also responsible for generating a random list of appliances.
    /// This code is a part of the Modern Appliances project. With Classes and Inheritance, this project is designed to simulate a store that sells modern appliances.
    /// A system that allows both employees and customers to interact with the store's inventory of appliances.
    /// </summary>
    /// <remarks>Author: Augusto Antunes Barros and Akshar Patel</remarks>
    /// <remarks>Date: 02/13/2024 </remarks>
    internal class MyModernAppliances : ModernAppliances
    {
        /// <summary>
        /// Option 1: Performs a checkout
        /// </summary>
        public override void Checkout()
        {
            // Write "Enter the item number of an appliance: "
            Console.Write("Enter the item number of an appliance: ");

            // Create long variable to hold item number
            long applianceNumber;

            // Get user input as string and assign to variable.
            string userInput = Console.ReadLine();

            // Convert user input from string to long and store as item number variable.
            applianceNumber = long.Parse(userInput);

            // Create 'foundAppliance' variable to hold appliance with item number
            Appliance foundAppliance;

            // Assign null to foundAppliance (foundAppliance may need to be set as nullable)
            foundAppliance = null;

            // Loop through Appliances
            foreach (Appliance appliance in Appliances)
            {
                // Test appliance item number equals entered item number
                if (appliance.ItemNumber == applianceNumber)
                {
                    // Assign appliance in list to foundAppliance variable
                    foundAppliance = appliance;

                    // Break out of loop (since we found what need to)
                    break;
                }
            }
                // Test appliance was not found (foundAppliance is null)
                if (foundAppliance is null)
                {
                    // Write "No appliances found with that item number."
                    Console.WriteLine("No appliances found with that item number.");
                }
            
                else if (foundAppliance.IsAvailable)
                {
                    // Checkout found appliance
                    foundAppliance.Checkout();

                    // Write "Appliance has been checked out."
                    Console.WriteLine($"Appliance {applianceNumber} has been checked out.");
                }
                else
                {
                    // Write "The appliance is not available to be checked out."
                    Console.WriteLine("The appliance is not available to be checked out.");
                }

            Console.WriteLine();

        }

        /// <summary>
        /// Option 2: Finds appliances
        /// </summary>
        public override void Find()
        {
            Console.WriteLine();
            // Write "Enter brand to search for:"
            Console.Write("Enter brand to search for: ");

            // Create string variable to hold entered brand
            string brand;

            // Get user input as string and assign to variable.
            string userInput = Console.ReadLine();

            // Create list to hold found Appliance objects
            List<Appliance> found = new List<Appliance>();

            // Iterate through loaded appliances
            foreach (Appliance appliance in Appliances)
            {
                // Test current appliance brand matches what user entered
                if (appliance.Brand == userInput)
                {
                    // Add current appliance in list to found list
                    found.Add(appliance);
                }
            }
            // Display found appliances
            DisplayAppliancesFromList(found, 0);
            // DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Displays Refridgerators
        /// </summary>
        public override void DisplayRefrigerators()
        {
            Console.WriteLine(); 
            // Write "Enter number of doors:"
            Console.WriteLine("Enter number of doors:");

            // Write "0 - Any"
            Console.WriteLine("0 - Any");
            // Write "2 - Double doors"
            Console.WriteLine("2 - Double doors");
            // Write "3 - Three doors"
            Console.WriteLine("3 - Three doors");
            // Write "4 - Four doors"
            Console.WriteLine("4 - Four doors");

            // Write "Enter number of doors: "
            Console.Write("Enter number of doors: ");

            // Create variable to hold entered number of doors
            int numDoors;
            // Get user input as string and assign to variable
            string userInput = Console.ReadLine();
            // Convert user input from string to int and store as number of doors variable.
            numDoors = int.Parse(userInput);
            // Create list to hold found Appliance objects
            List<Appliance> applienceObjects = new List<Appliance>();

            // Iterate/loop through Appliances
            foreach (Appliance appliance in Appliances)
            {
                // Test that current appliance is a refrigerator
                if (appliance is Refrigerator)
                {
                    // Down cast Appliance to Refrigerator
                    Refrigerator refrigerator = (Refrigerator)appliance;
                    // Refrigerator refrigerator = (Refrigerator) appliance;
                    
                    // Test user entered 0 or refrigerator doors equals what user entered.
                    if (numDoors == 0 || numDoors == refrigerator.Doors)
                    {
                        // Add current appliance in list to found list
                        applienceObjects.Add(appliance);
                    }
                }
            }

            // Display found appliances
            DisplayAppliancesFromList(applienceObjects, 0);
            // DisplayAppliancesFromList(applienceObjects, 0);

        }


        /// <summary>
        /// Displays Vacuums
        /// </summary>
        /// <param name="grade">Grade of vacuum to find (or null for any grade)</param>
        /// <param name="voltage">Vacuum voltage (or 0 for any voltage)</param>
        public override void DisplayVacuums()
        {
            
            Console.WriteLine();
            // Write "Possible options:"
            Console.WriteLine("Possible options:");

            // Write "0 - Any"
            Console.WriteLine("0 - Any");
            // Write "1 - Residential"
            Console.WriteLine("1 - Residential");
            // Write "2 - Commercial"
            Console.WriteLine("2 - Commercial");

            // Write "Enter grade:"
            Console.Write("Enter grade: ");

            // Get user input as string and assign to variable
            string userInput_grade = Console.ReadLine();

            // Create grade variable to hold grade to find (Any, Residential, or Commercial)
            string grade;

            // Test input is "0"
            if (userInput_grade == "0")
            {
                // Assign "Any" to grade
                grade = "Any";
                
            }

            // Test input is "1"
            else if (userInput_grade == "1")
            {
                grade = "Residential";
                // Assign "Residential" to grade
            }

            // Test input is "2"
            else if (userInput_grade == "2")
            {
                grade = "Commercial";
                // Assign "Commercial" to grade
            }

            // Otherwise (input is something else)
            else
            {
                // Write "Invalid option."
                Console.WriteLine("Invalid option.");
                // Return to calling (previous) method
                return;
            }

            Console.WriteLine();
            // Write "Enter battery value:"
            Console.WriteLine("Enter battery value:");

            // Write "0 - Any"
            Console.WriteLine("0 - Any");
            // Write "1 - 18 Volt"
            Console.WriteLine("18 - for 18 Volt (low)");
            // Write "2 - 24 Volt"
            Console.WriteLine("24 - for 24 Volt (high)");

            // Write "Enter voltage:"
            Console.Write("Enter voltage: ");

            // Get user input as string
            string userInput_voltage = Console.ReadLine();  

            // Create variable to hold voltage
            int voltage;


            // Test input is "0"
            if (userInput_voltage == "0")
            {
                // Assign 0 to voltage
                voltage = 0;
            }
            // Test input is "1"
            else if (userInput_voltage == "18")
            {
                // Assign 18 to voltage
                voltage = 18;
            }
            // Test input is "2"
            else if (userInput_voltage == "24")
            {
                // Assign 24 to voltage
                voltage = 24;
            }
            // Otherwise
            else
            {
                // Write "Invalid option."
                Console.WriteLine("Invalid option.");
                // Return to calling (previous) method
                return;
            }

            // Create found variable to hold list of found appliances.
            List<Appliance> found = new List<Appliance>();

            // Loop through Appliances
            foreach (Appliance appliance in Appliances)
            {
                // Check if current appliance is vacuum
                if (appliance is Vacuum)
                {
                    // Down cast current Appliance to Vacuum object
                    Vacuum vacuum = (Vacuum)appliance;

                    // Test grade is "Any" or grade is equal to current vacuum grade and voltage is 0 or voltage is equal to current vacuum voltage
                    if ((grade == "Any" || grade == vacuum.Grade) && (voltage == 0 || voltage == vacuum.BatteryVoltage))            
                    {
                        // Add current appliance in list to found list
                        found.Add(appliance);
                    }
                }
            }
            // Display found appliances
            DisplayAppliancesFromList(found, 0);
            
            // DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Displays microwaves
        /// </summary>
        public override void DisplayMicrowaves()
        {
            
            Console.WriteLine();
            // Write "Room where the microwave will be installed: "
            Console.WriteLine("Room where the microwave will be installed: ");

            // Write "0 - Any"
            Console.WriteLine("0 - Any");
            // Write "1 - Kitchen"
            Console.WriteLine("K - Kitchen");
            // Write "2 - Work site"
            Console.WriteLine("W - Work site");

            // Write "Enter room type:"
            Console.Write("Enter room type: ");

            // Get user input as string and assign to variable
            string userInput = Console.ReadLine();
            // Create character variable that holds room type
            char roomType;

            // Test input is "0"
            if (userInput == "0")
            {
                // Assign 'A' to room type variable
                roomType = 'A';
            }
            // Test input is "1"
            else if (userInput == "k" || userInput == "K")
            {
                // Assign 'K' to room type variable
                roomType = 'K';
            }
            // Test input is "2"
            else if (userInput == "w" || userInput == "W")
            {
                // Assign 'W' to room type variable
                roomType = 'W';
            }
            // Otherwise (input is something else)
            else
            {
                // Write "Invalid option."
                Console.WriteLine("Invalid option.");
                // Return to calling method
                return;
                // return;
            }

            // Create variable that holds list of 'found' appliances
            List<Appliance> listFound = new List<Appliance>();

            // Loop through Appliances
            foreach (Appliance appliance in Appliances)
            {
                // Test current appliance is Microwave
                if (appliance is Microwave)
                {
                    // Down cast Appliance to Microwave
                    Microwave microwave = (Microwave)appliance;

                    // Test room type equals 'A' or microwave room type
                    if (roomType == 'A' || roomType == microwave.RoomType)
                    {
                        // Add current appliance in list to found list
                        listFound.Add(appliance);
                    }
                }
            }

            // Display found appliances
            DisplayAppliancesFromList(listFound, 0);
            
            
        }

        /// <summary>
        /// Displays dishwashers
        /// </summary>
        public override void DisplayDishwashers()
        {
            Console.WriteLine();
            // Write "Enter the sound rating of the dishwasher:"
            Console.WriteLine("Enter the sound rating of the dishwasher:");

            // Write "0 - Any"
            Console.WriteLine("0 - Any");
            // Write "1 - Quietest"
            Console.WriteLine("1 - Quietest");
            // Write "2 - Quieter"
            Console.WriteLine("2 - Quieter");
            // Write "3 - Quiet"
            Console.WriteLine("3 - Quiet");
            // Write "4 - Moderate"
            Console.WriteLine("4 - Moderate");

            // Write "Enter sound rating:"
            Console.Write("Enter sound rating: ");

            // Get user input as string and assign to variable
            string userInput = Console.ReadLine();

            // Create variable that holds sound rating
            string soundRating;

            // Test input is "0"
            if (userInput == "0")
            {
                // Assign "Any" to sound rating variable
                soundRating = "Any";
            }
            // Test input is "1"
            else if (userInput == "1")
            {
                // Assign "Qt" to sound rating variable
                soundRating = "Qt";
            }
            // Test input is "2"
            else if (userInput == "2")
            {
                // Assign "Qr" to sound rating variable
                soundRating = "Qr";
            }
            // Test input is "3"
            else if (userInput == "3")
            {
                // Assign "Qu" to sound rating variable
                soundRating = "Qu";
            }
            // Test input is "4"
            else if (userInput == "4")
            {
                // Assign "M" to sound rating variable
                soundRating = "M";
            }
            // Otherwise (input is something else)
            else
            {
                // Write "Invalid option."
                Console.WriteLine("Invalid option.");
                // Return to calling method
                return;
            }
            // Create variable that holds list of found appliances
            List<Appliance> found = new List<Appliance>();
            
            // Loop through Appliances
            foreach (Appliance appliance in Appliances)
            {
                // Test if current appliance is dishwasher
                if (appliance is Dishwasher)
                {

                    // Down cast current Appliance to Dishwasher
                    Dishwasher dishwasher = (Dishwasher)appliance;

                    // Test sound rating is "Any" or equals soundrating for current dishwasher
                    if (soundRating == "Any" || soundRating == dishwasher.SoundRating)
                    {
                        // Add current appliance in list to found list
                        found.Add(appliance);
                    }
                }
            }

            // Display found appliances (up to max. number inputted)
            DisplayAppliancesFromList(found, 0);
            // DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Generates random list of appliances
        /// </summary>
        public override void RandomList()
        {
            Console.WriteLine();
            // Write "Appliance Types"
            Console.WriteLine("Appliance Types");

            // Write "0 - Any"
            Console.WriteLine("0 - Any");
            // Write "1 – Refrigerators"
            Console.WriteLine("1 – Refrigerators");
            // Write "2 – Vacuums"
            Console.WriteLine("2 – Vacuums");
            // Write "3 – Microwaves"
            Console.WriteLine("3 – Microwaves");
            // Write "4 – Dishwashers"
            Console.WriteLine("4 – Dishwashers");

            // Write "Enter type of appliance:"
            Console.Write("Enter type of appliance: ");

            // Get user input as string and assign to appliance type variable
            string userInput_type = Console.ReadLine();

            // Write "Enter number of appliances: "
            Console.Write("Enter number of appliances: ");

            // Get user input as string and assign to variable
            string userInput = Console.ReadLine();

            // Convert user input from string to int
            int num = int.Parse(userInput);

            // Create variable to hold list of found appliances
            List<Appliance> found = new List<Appliance>();

            // Loop through appliances
            foreach (Appliance appliance in Appliances)
            {
                // Test inputted appliance type is "0"
                if (userInput_type == "0")
                {
                    // Add current appliance in list to found list
                    found.Add(appliance);
                }
                // Test inputted appliance type is "1"
                else if (userInput_type == "1")
                {
                    // Test current appliance type is Refrigerator
                    if (appliance is Refrigerator)
                    {
                        // Add current appliance in list to found list
                        found.Add(appliance);
                    }
                }
                
                // Test inputted appliance type is "2"
                else if (userInput_type == "2")
                {
                    // Test current appliance type is Vacuum
                    if (appliance is Vacuum)
                    {
                        // Add current appliance in list to found list
                        found.Add(appliance);
                    }
                }
                // Test inputted appliance type is "3"
                else if (userInput_type == "3")
                {
                    // Test current appliance type is Microwave
                    if (appliance is Microwave)
                    {
                        // Add current appliance in list to found list
                        found.Add(appliance);
                    }
                // Test inputted appliance type is "4"
                else if (userInput_type == "4")
                {
                    // Test current appliance type is Dishwasher
                    if (appliance is Dishwasher)
                    {
                        // Add current appliance in list to found list
                        found.Add(appliance);
                    }
                }
            // Randomize list of found appliances
            found.Sort(new RandomComparer());
            }

            // Display found appliances (up to max. number inputted)
            DisplayAppliancesFromList(found, num);
            // DisplayAppliancesFromList(found, num);

        }
    }
    }
}


/* Module 10 Final Project: Classes and Objects
   Group members:
        Emily Harker, Jhoana Herrera, Jiang Seereeram, Justin Hill, Catherine Rinaldi
*/

using System;
using System.Collections.Generic;

class Program
{
    public static void Main()
    {
        int option;                                                                         // Stores user option selection
        var contractors = new List<Subcontractor>();                                        // Create list of Subcontractor objects to allow for as many instances as needed

        Console.WriteLine("Contractor Directory");
        do                                                                                  // Option selection. Allow user to add contractors and calculate pay
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Add a Subcontractor");
            Console.WriteLine("2. Calculate Pay");
            Console.WriteLine("3. Exit");
            option = Convert.ToInt32(Console.ReadLine());

            switch (option)                                                                     // Switch statement to implement selected option
            {
                case 1:                                                                         // Add a subcontractor
                    Console.WriteLine("Enter the name of the subcontractor:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter the number of the subcontractor:");
                    int number = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter the start date of the subcontractor:");
                    DateTime startDate = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Enter the shift of the subcontractor (1 for day, 2 for night):");
                    int shift = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter the pay rate of the subcontractor:");
                    double payRate = Convert.ToDouble(Console.ReadLine());
                    contractors.Add(new Subcontractor(name, number, startDate, shift, payRate));
                    Console.WriteLine("Subcontractor added.\n");
                    break;
                case 2:                                                                         // Calculate pay using subcontractor number
                    bool found = false;
                    Console.WriteLine("Enter subcontractor number:");
                    int subcontractor = Convert.ToInt32(Console.ReadLine());
                    foreach (var contractor in contractors)
                    {
                        if (contractor.number == subcontractor)
                        {
                            found = true;
                            Console.WriteLine("Enter the number of hours worked:");
                            int hours = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine($"The pay for subcontractor {contractor.name} is {(contractor.CalculatePay(hours)).ToString("C")}.\n");   // Displays pay with currency format
                            break;
                        }
                    }
                    if (!found)                                                                 // If subcontractor not found
                    {
                        Console.WriteLine("Subcontractor not found.\n");
                    }
                    break;
                case 3:
                    Console.WriteLine("Exiting program...");
                    break;
                default:
                    Console.WriteLine("Invalid option.\n");
                    break;
            }
        } while (option != 3);


    }
}

class Contractor
{
    public string name { get; set; }            // Stores contractor name
    public int number { get; set; }             // Stores contractor number
    public DateTime startDate { get; set; }     // Stores contractor start date
    public Contractor()                         // Default constructor 
    {
        name = "Unknown";
        number = 0;
        startDate = DateTime.Now;
    }
    public Contractor(string name, int number, DateTime startDate)  // Constructor with input
    {
        this.name = name;
        this.number = number;
        this.startDate = startDate;
    }
}

class Subcontractor : Contractor                // Subcontractor class inherits from Contractor class
{
    public int shift { get; set; }              // Stores subcontractor shift (1 for day, 2 for night)
    public double payRate { get; set; }         // Stores hourly pay rate
    public Subcontractor()
    {
        shift = 0;
        payRate = 0;
    }
    public Subcontractor(string name, int number, DateTime startDate, int shift, double payRate)
    {
        this.name = name;
        this.number = number;
        this.startDate = startDate;
        this.shift = shift;
        this.payRate = payRate;
    }

    public float CalculatePay(int hours)       // Calculate pay based on hours worked and shift
    {
        if (shift == 2)
        {
            return (float)(payRate * hours * 1.03);
        }
        else
        {
            return (float)(payRate * hours);
        }
    }
}
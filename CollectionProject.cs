using System;
using System.Collections.Generic;

class Program
{
    public static void Main()
    {
        //Create dictionary
        Dictionary<string, string> countries = new Dictionary<string, string>();
        MenuOption menuOption;

        Console.WriteLine("Welcome to the Country Abbreviation Dictionary!");
        Console.WriteLine("This dictionary stores the abbreviations and names of various countries.");
        Console.WriteLine("Please select an option from the menu below:");

        //Main program. Continue to run the program until the user selects the Exit option.
        do
        {
            menuOption = GetUserChoice();

            switch (menuOption)
            {
                case MenuOption.Populate:
                    //Populate the Dictionary: Add keys and values determined by your group.
                    countries.Add("USA", "United States of America");
                    countries.Add("CAN", "Canada");
                    countries.Add("MEX", "Mexico");
                    countries.Add("BRA", "Brazil");
                    countries.Add("GBR", "United Kingdom");
                    countries.Add("JPN", "Japan");
                    countries.Add("AUS", "Australia");
                    countries.Add("ITA", "Italy");
                    countries.Add("ANG", "Angola");
                    break;
                case MenuOption.Display:
                    //Display Dictionary Contents: Show the contents of the dictionary using any of the three enumeration methods covered in Module 7.
                    if (countries.Count == 0)
                    {
                        Console.WriteLine("Dictionary is empty.");
                        break;
                    }
                    Console.WriteLine("Country Abbreviations:");
                    foreach (KeyValuePair<string, string> country in countries)
                    {
                        Console.WriteLine("{0} - {1}", country.Key, country.Value);
                    }
                    break;
                case MenuOption.Remove:
                    //Remove a Key: Remove a specified key from the dictionary.
                    Console.WriteLine("Enter the abbreviation you would like to remove: ");
                    string key = Console.ReadLine();
                    if (countries.ContainsKey(key))
                    {
                        countries.Remove(key);
                        Console.WriteLine("Key removed successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Key not found.");
                    }
                    break;
                case MenuOption.Add:
                    //Add a New Key and Value: Insert a new key-value pair into the dictionary.
                    Console.WriteLine("Enter the abbreviation you would like to add: ");
                    string newKey = Console.ReadLine();
                    if (countries.ContainsKey(newKey))
                    {
                        Console.WriteLine("Key already exists. Use the Change option to add a value to an existing key.");
                        break;
                    }
                    Console.WriteLine("Enter the country name you would like to add: ");
                    string newValue = Console.ReadLine();
                    countries.Add(newKey, newValue);
                    break;
                case MenuOption.Change:
                    //Add a Value to an Existing Key: Append a new value to an existing key.
                    Console.WriteLine("Enter the abbreviation you would like to add a value to: ");
                    string existingKey = Console.ReadLine();
                    if (countries.ContainsKey(existingKey))
                    {
                        Console.WriteLine("Enter the new value you would like to add: ");
                        string value = Console.ReadLine();
                        countries[existingKey] = value;
                    }
                    else
                    {
                        Console.WriteLine("Key not found.");
                    }
                    break;
                case MenuOption.Sort:
                    //Sort the Keys: Sort the keys in the dictionary.
                    List<string> keys = new List<string>(countries.Keys);
                    keys.Sort();
                    Console.WriteLine("Sorted Country Abbreviations:");
                    foreach (string k in keys)
                    {
                        Console.WriteLine("{0} - {1}", k, countries[k]);
                    }
                    break;
                case MenuOption.Exit:
                    //Exit the program
                    Console.WriteLine("Program ended."); 
                    return;
                default:
                    Console.WriteLine("Invalid Option");
                    break;
            }
            Console.WriteLine();
        } while (menuOption != MenuOption.Exit);
    }
    //Get the user's choice and return the selected option.
    static MenuOption GetUserChoice()
    {
        Console.WriteLine("1. Populate the Dictionary          2. Display Dictionary Contents");
        Console.WriteLine("3. Remove a Key                     4. Add a New Key and Value");
        Console.WriteLine("5. Add a Value to an Existing Key   6. Sort the Keys");
        Console.WriteLine("7. Exit");
        Console.WriteLine("Enter the number of the function you would like to perform: ");
        MenuOption choice = (MenuOption)int.Parse(Console.ReadLine());
        return choice;
    }

    //Create an enumeration named MenuOption that contains the options listed in the menu.
    enum MenuOption
    {
        Populate = 1, //Populate the Dictionary: Add keys and values determined by your group.
        Display, //Display Dictionary Contents: Show the contents of the dictionary using any of the three enumeration methods covered in Module 7.
        Remove, //Remove a Key: Remove a specified key from the dictionary.
        Add, //Add a New Key and Value: Insert a new key-value pair into the dictionary.
        Change, //Add a Value to an Existing Key: Append a new value to an existing key.
        Sort, //Sort the Keys: Sort the keys in the dictionary.
        Exit
    }
}
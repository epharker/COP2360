using System;

namespace Beverages
{
    public class Alcohol
    {
        public string Name { get; set; }
        public string PlaceOfOrigin { get; set; }
    }
    public class Wine : Alcohol // Class taken from Classes.txt
    {
        public decimal Price;
        public int Year;
        public Wine(decimal price) => Price = price;
        public Wine(decimal price, int year) : this(price) => Year = year;
    }
    class Program
    {
        static void Main()
        {
            Wine exampleWine = new Wine(120.00m, 2021);
            exampleWine.Name = "Petrolo Boggina";
            exampleWine.PlaceOfOrigin = "Italy";

            Console.WriteLine("Name: {0}\nPrice: {1:c}\nYear: {2}\nPlace of Origin: {3}", exampleWine.Name, exampleWine.Price, exampleWine.Year, exampleWine.PlaceOfOrigin);
        }
    }
}
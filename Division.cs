using System;

class Program
{
    static void Main()
    {   
        Start:
        try {
           
            Console.Write("Enter a number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter another number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"{num1} / {num2} = {Divide(num1, num2)}");
        }  
         catch (FormatException ex) { 
            Console.WriteLine($"Error: FormatException. Method: {ex.TargetSite} -- {ex.Message}\nPlease only enter integers. Try again.");
            goto Start;
        }
        catch (DivideByZeroException ex) { 
            Console.WriteLine($"Error: DivideByZeroException. Method: {ex.TargetSite} -- {ex.Message}\nCannot divide by zero. Try again.");
            goto Start;
        }
        catch (OverflowException ex) { 
            Console.WriteLine($"Error: OverflowException. Method: {ex.TargetSite} -- {ex.Message}\nNumber is too large or too small. Try again.");
            goto Start;
        }
        catch (Exception ex) { 
            Console.WriteLine($"Error: {ex.ToString()}");
        } 
        
        Console.WriteLine("---Press any key to exit.---");
        Console.ReadKey();
        
    }

    static int Divide(int x, int y) {
        return x / y;
    }
}
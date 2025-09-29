const uint smallCarpetPrice = 25;
const uint largeCarpetPrice = 35;
const double salesTaxRate = 0.06;
const uint validDays = 30;
uint numOfSmallCarpet = 0;
uint numOfLargeCarpet = 0;
uint totalPriceOfSmallSize = 0;
uint totalPriceOfLargeSize = 0;
double tax = 0.0;
double grandTotal = 0.0;
double totalAfterTax = 0;
string sizeOfCarpet = "";
uint choice = 0;

Console.WriteLine("**** Welcome to Islam's carpet cleaning services ****");
Console.WriteLine();
Console.WriteLine("Main menue (Press the number of the following):");
Console.WriteLine(" 1- show prices \n 2- order cleaning service \n 3- Exit");
choice = (uint)Convert.ToInt32(Console.ReadLine());


switch (choice)
{
    case 1:
        Console.WriteLine("Small carpet cleaning price : $25");
        Console.WriteLine("Large carpet cleaning price : $35");
        Console.WriteLine();
        Console.WriteLine("Press 2 to order cleaning service or 3 to exit");

        int subChoice = Convert.ToInt32(Console.ReadLine());
        if (subChoice == 2)
        {
            goto case 2;
        }
        else 
        { 
            goto case 3; 
        }
            break;
    case 2:
        Console.WriteLine("Enter number of small carpets : ");
        numOfSmallCarpet = (uint)Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter number of large carpets : ");
        numOfLargeCarpet = (uint)Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("----------------------------------------------------------");
        Console.WriteLine("\t\t\tInvoice");
        Console.WriteLine("----------------------------------------------------------");
        Console.WriteLine("number of carpets\tSize\tprice per size\ttotal");
        Console.WriteLine("----------------------------------------------------------");

        if (numOfSmallCarpet >= 0)
        {
            sizeOfCarpet = "Small";
            totalPriceOfSmallSize = numOfSmallCarpet * smallCarpetPrice;
            Console.WriteLine($"{numOfSmallCarpet} \t\t\t{sizeOfCarpet} \t\t{smallCarpetPrice}\t {totalPriceOfSmallSize}");
        }

        if (numOfLargeCarpet >= 0)
        {
            sizeOfCarpet = "Large";
            totalPriceOfLargeSize = numOfLargeCarpet * largeCarpetPrice;
            Console.WriteLine($"{numOfLargeCarpet} \t\t\t{sizeOfCarpet} \t\t{largeCarpetPrice}\t {totalPriceOfLargeSize}");
        }

        grandTotal = totalPriceOfSmallSize + totalPriceOfLargeSize;
        tax = Math.Round(grandTotal * salesTaxRate, 1);
        totalAfterTax = grandTotal + tax;


        Console.WriteLine("----------------------------------------------------------");
        Console.WriteLine($"Grand Total before taxes \t\t\t{grandTotal}");
        Console.WriteLine($" + Total Taxes \t\t\t\t\t{tax}");
        Console.WriteLine("----------------------------------------------------------");
        Console.WriteLine($"Total after sales taxes({salesTaxRate * 100}%) \t\t\t{totalAfterTax}");
        Console.WriteLine();
        Console.WriteLine($"\tThis estimate is valid for {validDays} days");
        Console.WriteLine("----------------------------------------------------------");
        break;
    case 3:
        Environment.Exit(0);
        break;
    default:
        Console.WriteLine("Invalid choice. Please select a valid option.");
        break;
}





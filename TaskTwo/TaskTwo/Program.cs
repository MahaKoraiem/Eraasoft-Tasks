ProgramRunner programRunner = new ProgramRunner();

public class ProgramRunner
{
    string choice;

    Numberslist list = new Numberslist();
    public ProgramRunner()
    {
        MainMenu();
        choice = "";
        Run();

    }
    
    public void MainMenu()
    {
        Console.WriteLine("Main menu \n\nP - Print numbers \nA - Add numbers \nM - Display mean of the numbers \n" +
            "S - Display the smallest number \nL - Display the largest number \nF - Find a number \n" +
            "O - Sort Asc \nD - Sort Desc \nC - Clear the whole list \nR - Remove an element\nW - Swap two elements\nQ - Quit");
    }

    public void Run()
    {
        do
        {
            Console.WriteLine("\nEnter your choice: ");
            choice = Console.ReadLine().ToUpper();
            switch (choice)
            {
                case "P":
                    Console.WriteLine("===========================");
                    PrintChoice();
                    Console.WriteLine("===========================");
                    break;
                case "A":
                    Console.WriteLine("===========================");
                    AddChoice();
                    Console.WriteLine("===========================");
                    break;
                case "C":
                    Console.WriteLine("===========================");
                    ClearChoice();
                    Console.WriteLine("===========================");
                    break;
                case "F":
                    Console.WriteLine("===========================");
                    SearchChoice();
                    Console.WriteLine("===========================");
                    break;
                case "D":
                    Console.WriteLine("===========================");
                    SortDescChoice();
                    Console.WriteLine("===========================");
                    break;
                case "O":
                    Console.WriteLine("===========================");
                    SortAscChoice();
                    Console.WriteLine("===========================");
                    break;
                case "S":
                    Console.WriteLine("===========================");
                    FindSmallestChoice();
                    Console.WriteLine("===========================");
                    break;
                case "L":
                    Console.WriteLine("===========================");
                    FindLargestChoice();
                    Console.WriteLine("===========================");
                    break;
                case "R":
                    Console.WriteLine("===========================");
                    RemoveChoice();
                    Console.WriteLine("===========================");
                    break;
                case "M":
                    Console.WriteLine("===========================");
                    CalculateMeanChoice();
                    Console.WriteLine("===========================");
                    break;
                case "W":
                    Console.WriteLine("===========================");
                    SwapChoice();
                    Console.WriteLine("===========================");
                    break;
                case "Q":
                    Console.WriteLine("===========================");
                    Console.WriteLine("Goodbye!");
                    Console.WriteLine("===========================");
                    break;
                default:
                    Console.WriteLine("Unknown selection, please try again");
                    break;
            }
        } while (choice != "Q");
    }

    public void PrintChoice()
    {
        if(list.IsEmpty())
            Console.WriteLine("The List is empty");
        else
            list.PrintNumbers();
    }

    public void AddChoice()
    {
        Console.WriteLine("Enter a number to add to the list: ");
        int number = Convert.ToInt32(Console.ReadLine());
        list.AddNumber(number);
        Console.WriteLine($"The number : {number} is added successfully");
    }

    public void ClearChoice()
    {
        if (list.IsEmpty())
        {
            Console.WriteLine("The List is already empty");
            return;
        }
        list.ClearList();
        Console.WriteLine("The List is cleared successfully");
    }

    public void SearchChoice()
    {
        if(list.IsEmpty())
        {
            Console.WriteLine("The List is empty");
            return;
        }

        Console.WriteLine("Enter a number to search in the list: ");
        int number = Convert.ToInt32(Console.ReadLine());
        bool found = list.SearchNumber(number);
        if(found)
            Console.WriteLine($"The number : {number} is found in the list");
        else
            Console.WriteLine($"The number : {number} is not found in the list");
    }

    public void FindSmallestChoice()
    {
        if (list.IsEmpty())
            Console.WriteLine("The List is empty");
        else
        {
            int smallest = list.GetSmallest();
            Console.WriteLine($"The smallest number in the list is: {smallest}");
        }
    }

    public void FindLargestChoice()
    {
        if (list.IsEmpty())
            Console.WriteLine("The List is empty");
        else
        {
            int largest = list.GetLargest();
            Console.WriteLine($"The largest number in the list is: {largest}");
        }
    }

    public void CalculateMeanChoice()
    {
        if (list.IsEmpty())
            Console.WriteLine("The List is empty");
        else
        {
            double mean = list.GetMean();
            Console.WriteLine($"The mean of the numbers in the list is: {mean}");
        }
    }

    public void SortAscChoice()
    {
        if (list.IsEmpty())
            Console.WriteLine("The List is empty");
        else
        {
            list.SortAsc();
            Console.WriteLine("The list is sorted successfully");
        }
    }

    public void SortDescChoice()
    {
        if (list.IsEmpty())
            Console.WriteLine("The List is empty");
        else
        {
            list.SortDesc();
            Console.WriteLine("The list is sorted successfully");
        }
    }

    public void RemoveChoice()
    {
        if (list.IsEmpty())
        {
            Console.WriteLine("The List is empty");
            return;
        }
        Console.WriteLine("Enter the number to remove from the list: ");
        int index = Convert.ToInt32(Console.ReadLine());
        list.RemoveElement(index);
        Console.WriteLine($"The number is removed successfully");
    }

    public void SwapChoice()
    {
        if (list.IsEmpty())
        {
            Console.WriteLine("The List is empty");
            return;
        }
        Console.WriteLine("Enter the first index to swap: ");
        int index1 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the second index to swap: ");
        int index2 = Convert.ToInt32(Console.ReadLine());
        list.swap(index1, index2);
        Console.WriteLine($"The numbers at index {index1} and {index2} are swapped successfully");
    }


}



public class Numberslist
{
    int[] array;
    int count;
    int capacity;
    int newCapacity;
    public Numberslist()
    {
       initializeList();
    }

    public void initializeList()
    {
        count = 0;
        capacity = 4;
        array = new int[capacity];
    }

    public bool IsEmpty()
    {
        return count == 0;
    }

    public void AddNumber(int number)
    {
        if(count < capacity)
        {
            if(count > 0)
            {
                bool duplicate = false;
                for (int i = 0; i < count; i++)
                {
                    if(array[i] == number)
                    {
                        Console.WriteLine("This number already exists!");
                        duplicate = true;
                        break;
                    }
                }

                if (!duplicate)
                    array[count++] = number;
            }
            else
            {
                array[count] = number;
                count++;
            }
        }
        else
        {
            this.newCapacity = capacity * 2;
            int[] newArray = new int[newCapacity];
            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }
            array = newArray;
            capacity = newCapacity;
            array[count] = number;
            count++;
        }
    }

    public void PrintNumbers()
    {
        Console.Write("[");
        
        for(int i = 0; i<this.count; i++)
        {
            if(i < count - 1)
                Console.Write(array[i] + ", ");
            else
                Console.Write(array[i]);
        }
        Console.WriteLine("] ");
       
    }

    public void ClearList()
    {
        initializeList();
    }

    public bool SearchNumber(int number)
    {
        for(int i = 0; i<count; i++)
        {
            if(array[i] == number)
                return true;
        }
        return false;
    }

    public int GetSmallest()
    {
        int smallest = array[0];
        for (int i = 1; i < count; i++)
        {
            if (array[i] < smallest)
                smallest = array[i];
        }
        return smallest;
    }

    public int GetLargest()
    {
        
        int largest = array[0];
        for (int i= 1;  i < this.count; i++)
        {
            if (array[i] > largest)
                largest = array[i];
        }
        return largest;
    }

    public double GetMean()
    {
        
        double sum = 0;
        for (int i = 0; i < count; i++)
        {
            sum += array[i];
        }
        return sum / count;
    }

    public void RemoveElement(int removedNumber)
    {
        int[] newArray = new int[count];
        int newIndex = 0;
        for (int i = 0;i < count;i++)
        {
            if (array[i] != removedNumber)
                newArray[newIndex++] = array[i];
            if (array[i] == removedNumber)
                continue;
        }
        count = newIndex;
        array = newArray;
    }

    public void swap(int num1, int num2)
    {
        int temp = 0;
        temp = array[num1];
        array[num1] = array[num2];
        array[num2] = temp;
    }

    public void SortAsc()
    {
        for (int i = 0; i <= count - 2; i++)
        {
            int minIndex = i;
            for (int j = i+1; j <= count - 1; j++)
            {
                if (array[j] < array[minIndex])
                    minIndex = j;
            }
            swap(i, minIndex);
        }
    }

    public void SortDesc()
    {
        for (int i = 0; i <= count - 2; i++)
        {
            int maxIndex = i;
            for (int j = i + 1; j <= count - 1; j++)
            {
                if (array[j] > array[maxIndex])
                    maxIndex = j;
            }
            swap(i, maxIndex);
        }
    }
}



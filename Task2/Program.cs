internal class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        char choice;
        char[] ValidChoices = new char[] { 'P', 'A', 'M', 'S', 'L', 'Q', 'E', 'R', 'C' };
        do
        {
            choice = Menu();
            if(numbers.Count != 0 || choice == 'A' || choice == 'Q' || choice == 'C')
            {
                ManageList(choice, ref numbers);
            }
            else
            {
                if(ValidChoices.Contains(choice))
                {
                    Console.WriteLine("List is empty. Please add numbers first.");
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
        } while(choice != 'Q');
    }

    public static char Menu()
    {
        Console.WriteLine();
        Console.WriteLine("--- Welcome to list Management ---");
        Console.WriteLine("P - Print all");
        Console.WriteLine("A - Add");
        Console.WriteLine("M - Display mean");
        Console.WriteLine("S - Display smallest");
        Console.WriteLine("L - Display largest");
        Console.WriteLine("E - Search by value");
        Console.WriteLine("R - Arrange list");
        Console.WriteLine("C - Clear list");
        Console.WriteLine("Q - Quit");
        Console.Write("Enter your choice: ");
        char choice = 'X';
        try
        {
            choice = char.Parse(Console.ReadLine().ToUpper());
        } catch {}
        Console.WriteLine();
        return choice;
    }

    public static void ManageList(char choice, ref List<int> numbers)
    {
        switch (choice)
        {
            case 'P':
                Console.WriteLine("Numbers:");
                Console.Write("[ ");
                for(int i = 0; i < numbers.Count; ++i) Console.Write(numbers[i] + " ");
                Console.Write(']');
                break;
            case 'A':
                Console.Write("Enter a number: ");
                try 
                {
                    int num = int.Parse(Console.ReadLine());
                    bool flag = true;
                    for(int i = 0; i < numbers.Count; ++i) if(numbers[i] == num) flag = false;
                    if(flag) { numbers.Add(num); Console.WriteLine($"{num} was added!"); }
                    else Console.WriteLine($"{num} Already exists!");
                } catch{ Console.WriteLine("Invalid Input."); }
                break;
            case 'M':
                Console.WriteLine("Mean:");
                double mean = 0;
                for(int i = 0; i < numbers.Count; ++i) mean += numbers[i];
                mean /= numbers.Count;
                Console.WriteLine(mean);
                break;
            case 'S':
                Console.WriteLine("Smallest:");
                int smallest = numbers[0];
                for(int i = 1; i < numbers.Count; ++i) if(numbers[i] < smallest) smallest = numbers[i];
                Console.WriteLine(smallest);
                break;
            case 'L':
                Console.WriteLine("Largest:");
                int largest = numbers[0];
                for(int i = 1; i < numbers.Count; ++i) if(numbers[i] > largest) largest = numbers[i];
                Console.WriteLine(largest);
                break;
            case 'E':
                Console.Write("Enter a number: ");
                try 
                {
                    int val = int.Parse(Console.ReadLine());
                    bool found = false;
                    for(int i = 0; i < numbers.Count; ++i) if(val == numbers[i]) { Console.WriteLine($"{val} Found at index {i}"); found = true; break; }
                    if(!found) Console.WriteLine($"{val} Not found!");
                } catch{ Console.WriteLine("Invalid Input."); }
                break;
            case 'R':
                Console.WriteLine("1 - Ascendingly");
                Console.WriteLine("2 - Descendingly");
                Console.Write("Enter your choice: ");
                try 
                {
                    int ch = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    if(ch == 1) { SortListAsc(ref numbers); Console.WriteLine("List was sorted successfully!"); }
                    else if(ch == 2) { SortListDes(ref numbers); Console.WriteLine("List was sorted successfully!"); }
                    else Console.WriteLine("Invalid choice");
                } catch{ Console.WriteLine("Invalid Input."); }
                break;
            case 'C':
                if(numbers.Count == 0) Console.WriteLine("List is already Empty!");
                else Console.WriteLine("List Cleared!");
                numbers.Clear();
                break;
            case 'Q':
                Console.WriteLine("Goodbye!");
                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
        }
    }

    public static void SortListAsc(ref List<int> numbers)
    {
        for(int i = 0; i < numbers.Count; ++i)
        {
            int index = i, smallest = numbers[i];
            for(int j = i + 1; j < numbers.Count; ++j)
            {
                if(numbers[j] < smallest) { smallest = numbers[j]; index = j; }
            }
            numbers[index] = numbers[i];
            numbers[i] = smallest;
        }
    }

    public static void SortListDes(ref List<int> numbers)
    {
        for(int i = 0; i < numbers.Count; ++i)
        {
            int index = i, largest = numbers[i];
            for(int j = i + 1; j < numbers.Count; ++j)
            {
                if(numbers[j] > largest) { largest = numbers[j]; index = j; }
            }
            numbers[index] = numbers[i];
            numbers[i] = largest;
        }
    }
}
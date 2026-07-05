namespace task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Estimate for carpet cleaning service");
            Console.Write("Number of small carpets: ");
            int s = Convert.ToInt32(Console.ReadLine());
            Console.Write("Number of large carpets: ");
            int l = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Price per small carpet: $25");
            Console.WriteLine("Price per small carpet: $35");
            int cost = s*25 + l*35;
            Console.WriteLine($"Cost: ${cost}");
            double tax = cost * 0.06;
            Console.WriteLine($"Tax: ${tax}");
            Console.WriteLine("===============================");
            Console.WriteLine($"Total estimate: ${cost + tax}");
            Console.WriteLine("This estimate is valid for 30 days");
        }
    }
}
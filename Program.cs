using System;

namespace searchFight
{
    class Program
    {
        static int Main(string[] args)
        {
            Console.WriteLine("Querying...");
            if (args.Length > 0)
            {
                
                
                return 0;
            }
            else
            {
                Console.WriteLine("Please enter arguments");
                IOUtils iOUtils = new IOUtils();
                iOUtils.printManual();
                return 1;
            }
        }
    }
}

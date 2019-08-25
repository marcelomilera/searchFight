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
                BingEngine bingEngine = new BingEngine();
                ContextualEngine contextualEngine = new ContextualEngine();
                foreach (var searchTerm in args)
                {
                    bingEngine.search(searchTerm);
                    contextualEngine.search(searchTerm);
                }
                return 0;
            }
            else
            {
                Console.WriteLine("Please enter arguments");
                IOUtils.printManual();
                return 1;
            }
        }
    }
}

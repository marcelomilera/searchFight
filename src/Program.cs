using System;
using System.Linq;
using System.Collections.Generic;

namespace searchFight
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length > 0)
            {
                BingEngine bingEngine = new BingEngine();
                ContextualEngine contextualEngine = new ContextualEngine();
                //(Search term, search results count) pairs
                Dictionary<string, int> termCount = new Dictionary<string, int>();
                Dictionary<string, int> bingCount = new Dictionary<string, int>();
                Dictionary<string, int> contextualCount = new Dictionary<string, int>();
                for (int i = 0; i < args.Length; i++)
                {
                    var searchTerm = args[i];

                    int bingSearchCount = bingEngine.getSearchCount(searchTerm);
                    int contextualSearchCount = contextualEngine.getSearchCount(searchTerm);

                    termCount.Add(args[i], bingSearchCount + contextualSearchCount);
                    
                    bingCount.Add(args[i], bingSearchCount);
                    contextualCount.Add(args[i], contextualSearchCount);

                    Console.WriteLine($"{searchTerm}: Bing: {bingSearchCount} Contextual Web Search: {contextualSearchCount}");
                }
                var bingWinnerCount = bingCount.Values.Max();
                var contextualWinnerCount = contextualCount.Values.Max();
                var totalWinnerCount = termCount.Values.Max();
                
                var bingWinner = bingCount.FirstOrDefault(x => x.Value == bingWinnerCount).Key;
                var contextualWinner = contextualCount.FirstOrDefault(x => x.Value == contextualWinnerCount).Key;
                var totalWinner = termCount.FirstOrDefault(x => x.Value == totalWinnerCount).Key;
                Console.WriteLine($"Bing winner: {bingWinner}");
                Console.WriteLine($"Contextual Web Search winner: {contextualWinner}");
                Console.WriteLine($"Total winner: {totalWinner}");
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

using System;
using System.Net;
using System.IO;
using System.Collections.Generic;

namespace searchFight
{
    class ContextualEngine
    {
        const string accessKey = "a81eb5091dmsh432dd772673f05cp1e325ajsn616b5d115ee7";
        const string apiHost = "contextualwebsearch-websearch-v1.p.rapidapi.com";
        const string uriBase = "https://contextualwebsearch-websearch-v1.p.rapidapi.com/api/Search/WebSearchAPI";

        public void search(string searchTerm){
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            if (accessKey.Length == 50)
            {
                Console.WriteLine("Searching the Web for: " + searchTerm);
                SearchResult result = ContextualWebSearch(searchTerm);
                Console.WriteLine("\nRelevant HTTP Headers:\n");
                foreach (var header in result.relevantHeaders)
                    Console.WriteLine(header.Key + ": " + header.Value);

                Console.WriteLine("\nJSON Response:\n");
                Console.WriteLine(IOUtils.JsonPrettyPrint(result.jsonResult));
            }
            else
            {
                Console.WriteLine("Invalid Contextual Search API subscription key!");
                Console.WriteLine("Please paste yours into the source code.");
            }
            Console.Write("\nPress Enter to exit ");
            Console.ReadLine();
        }

        public struct SearchResult
        {
            public String jsonResult;
            public Dictionary<String, String> relevantHeaders;
        }

        public SearchResult ContextualWebSearch(string searchQuery)
        {
            // Construct the search request URI.
            var uriQuery = uriBase + "?q=" + Uri.EscapeDataString(searchQuery);

            // Perform request and get a response.
            WebRequest request = HttpWebRequest.Create(uriQuery);
            request.Headers["X-RapidAPI-Key"] = accessKey;
            request.Headers["X-RapidAPI-Host"] = apiHost;
            HttpWebResponse response = (HttpWebResponse)request.GetResponseAsync().Result;
            string json = new StreamReader(response.GetResponseStream()).ReadToEnd();

            // Create a result object.
            var searchResult = new SearchResult()
            {
                jsonResult = json,
                relevantHeaders = new Dictionary<String, String>()
            };

            // Extract Contextual HTTP headers.
            foreach (String header in response.Headers)
            {
                if (header.StartsWith("ContextualAPIs-") || header.StartsWith("X-MSEdge-"))
                    searchResult.relevantHeaders[header] = response.Headers[header];
            }
            return searchResult;
        }

        
    }
}
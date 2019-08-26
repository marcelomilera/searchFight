using System;
using System.Net;
using System.IO;
using System.Collections.Generic;

namespace searchFight
{
    abstract class BaseEngine
    {
        public struct SearchResult
        {
            public String jsonResult;
            public Dictionary<String, String> relevantHeaders;
        }

        public abstract bool isValidAPIKey();

        public void search(string searchTerm){
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            if (isValidAPIKey())
            {
                Console.WriteLine("Searching the Web for: " + searchTerm);
                SearchResult result = webSearch(searchTerm);
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

        public SearchResult webSearch(string searchTerm)
        {
            // Construct the search request URI.
            var uriQuery = constructURIQuery(searchTerm);
            
            // Create request
            WebRequest request = createRequest(uriQuery);
            
            // Perform request and get a response.
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

        //CONSTRUCT URI QUERY
        public abstract string constructURIQuery(string searchTerm);
        //CONSTRUCT REQUEST
        public WebRequest createRequest(string uriQuery){
            WebRequest request = HttpWebRequest.Create(uriQuery);
            request = addHeaders(request);
            return request;
        }
        //ADD HEADERS
        public abstract WebRequest addHeaders(WebRequest request);
        //ADD PARAMS METHOD
        public abstract string addParameters(string uriQuery);
        //EXTRACT COUNT FROM JSON RESPONSE
        public abstract string extractCountFromResponse();
        
    }
}
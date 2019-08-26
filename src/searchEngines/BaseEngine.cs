using System;
using System.Net;
using System.IO;
using System.Collections.Generic;

namespace searchFight
{
    abstract class BaseEngine
    {
        public string jsonResult;

        public abstract bool isValidAPIKey();

        public string webSearch(string searchTerm)
        {
            // Construct the search request URI.
            var uriQuery = constructURIQuery(searchTerm);
            
            // Create request
            WebRequest request = createRequest(uriQuery);
            
            // Perform request and get a response.
            HttpWebResponse response = (HttpWebResponse)request.GetResponseAsync().Result;
            jsonResult = new StreamReader(response.GetResponseStream(), System.Text.Encoding.UTF8).ReadToEnd();

            return jsonResult;
        }

        public string search(string searchTerm){
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            if (isValidAPIKey())
            {
                string jsonResult = webSearch(searchTerm);
                return jsonResult;
            }
            else
            {
                Console.WriteLine("Invalid Contextual Search API subscription key!");
                return "";
            }
        }

        public abstract string constructURIQuery(string searchTerm);

        public WebRequest createRequest(string uriQuery){
            WebRequest request = HttpWebRequest.Create(uriQuery);
            request = addHeaders(request);
            return request;
        }

        public abstract WebRequest addHeaders(WebRequest request);

        public abstract string addParameters(string uriQuery);

    }
}
using System;
using System.Net;
using System.IO;
using System.Collections.Generic;

namespace searchFight
{
    class ContextualEngine : BaseEngine
    {
        const string accessKey = "a81eb5091dmsh432dd772673f05cp1e325ajsn616b5d115ee7";
        const string apiHost = "contextualwebsearch-websearch-v1.p.rapidapi.com";
        const string uriBase = "https://contextualwebsearch-websearch-v1.p.rapidapi.com/api/Search/WebSearchAPI";
        readonly Dictionary<string, string> parameters = new Dictionary<string, string>(){
            {"pageNumber", "1"},
            {"pageSize", "1"}
        };

        public override bool isValidAPIKey(){
            if (accessKey.Length == 50) return true;
            return false;
        }

        public override string constructURIQuery(string searchTerm){
            string escapedSearchTerm = Uri.EscapeDataString(searchTerm);
            string uriQuery = $"{uriBase}?q={escapedSearchTerm}";
            return uriQuery;
        }
       
        public override WebRequest addHeaders(WebRequest request){
            request.Headers["X-RapidAPI-Key"] = accessKey;
            request.Headers["X-RapidAPI-Host"] = apiHost;
            return request;
        }

        public override string addParameters(string uriQuery){
            foreach (KeyValuePair<string, string> param in parameters)
            {
                uriQuery = $"{uriQuery}&{param.Key}={param.Value}";
            }
            return uriQuery;
        }

        public override string extractCountFromResponse(){
            return "";
        }
    }
}
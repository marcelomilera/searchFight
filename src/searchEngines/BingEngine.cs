using System;
using System.Net;
using System.IO;
using System.Collections.Generic;

namespace searchFight
{
    class BingEngine : BaseEngine
    {
        const string accessKey = "c1d6bb13fed94447b094734f3782b702";
        const string uriBase = "https://api.cognitive.microsoft.com/bing/v7.0/search";
        readonly Dictionary<string, string> parameters = new Dictionary<string, string>(){
            {"count", "1"},
            {"answerCount", "1"},
            {"responseFilter", "Webpages"}
        };
        public override bool isValidAPIKey(){
            if (accessKey.Length == 32) return true;
            return false;
        }

        public override string constructURIQuery(string searchTerm){
            string escapedSearchTerm = Uri.EscapeDataString(searchTerm);
            string uriQuery = $"{uriBase}?q={escapedSearchTerm}";
            uriQuery = addParameters(uriQuery);
            return uriQuery;
        }
       
        public override WebRequest addHeaders(WebRequest request){
            request.Headers["Ocp-Apim-Subscription-Key"] = accessKey;
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
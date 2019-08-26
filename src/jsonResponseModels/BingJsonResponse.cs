using System.Runtime.Serialization;
using System.Collections.Generic;

namespace searchFight
{
    [DataContract]
    class BingJsonResponse : IExtensibleDataObject
    {
        [DataMember]
        public string _type { get; set;}

        [DataMember]
        public QueryContext queryContext { get; set;}

        [DataMember]
        public WebPages webPages { get; set;}

        private ExtensionDataObject extensionDataObject_value;
        public ExtensionDataObject ExtensionData
        {
            get
            {
                return extensionDataObject_value;
            }
            set
            {
                extensionDataObject_value = value;
            }
        }
    }

    [DataContract]
    class QueryContext : IExtensibleDataObject
    {
        [DataMember]
        public string originalQuery { get; set;}

        private ExtensionDataObject extensionDataObject_value;
        public ExtensionDataObject ExtensionData
        {
            get
            {
                return extensionDataObject_value;
            }
            set
            {
                extensionDataObject_value = value;
            }
        }
    }

    [DataContract]
    class WebPages : IExtensibleDataObject
    {
        [DataMember]
        public string webSearchUrl { get; set;}

        [DataMember]
        public int totalEstimatedMatches { get; set;}

        private ExtensionDataObject extensionDataObject_value;
        public ExtensionDataObject ExtensionData
        {
            get
            {
                return extensionDataObject_value;
            }
            set
            {
                extensionDataObject_value = value;
            }
        }
    }
}
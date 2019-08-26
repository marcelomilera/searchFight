using System.Runtime.Serialization;
using System.Collections.Generic;

namespace searchFight
{
    [DataContract]
    class ContextualJsonResponse : IExtensibleDataObject
    {
        [DataMember]
        public string _type { get; set;}

        [DataMember]
        public string didUMean { get; set;}

        [DataMember]
        public int totalCount { get; set;}

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
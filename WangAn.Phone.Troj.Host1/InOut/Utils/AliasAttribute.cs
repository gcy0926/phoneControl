using System;

namespace InOut.Utils
{
    
    public class AliasAttribute:Attribute
    {
        public  string Alias { get; set; }

        public AliasAttribute(string alias)
        {
            Alias = alias;
        }
    }
}

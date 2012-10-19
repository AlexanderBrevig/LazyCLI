using System;

namespace LazyCLI
{
    public class LazyCLIAttribute : Attribute
    {
        public LazyCLIAttribute()
        {
            //
        }

        public LazyCLIAttribute(string alias)
        {
            Alias = alias;
        }

        public string Alias { get; set; }
    }
}

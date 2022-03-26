using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace YatchMasterWS.Services
{
    public class CamelCasePolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name)
        {
            // if the string is empty or the first character is already lowercase just return as is
            if (string.IsNullOrEmpty(name) || char.IsLower(name[0]))
                return name;

            char[] chars = name.ToCharArray(); // get a list of chars
            chars[0] = char.ToLowerInvariant(chars[0]); // make the first character lower case 

            // leave the rest of the characters alone or do more processing on it?

            return new string(chars); // return the altered string
        }
    }
}

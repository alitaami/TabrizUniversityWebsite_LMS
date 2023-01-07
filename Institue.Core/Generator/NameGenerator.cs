using System;
using System.Collections.Generic;
using System.Text;

namespace Institue.Core.Generator
{
    public class NameGenerator
    {
        public static string GenerateUniqueCode()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
    }
 
}

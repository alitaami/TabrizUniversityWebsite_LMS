using System;
using System.Collections.Generic;
using System.Text;

namespace Institue.Core.Convertors
{
   public class FixedText
    {
        public static string FixUsername(string username)
        {
            return username.ToLower();
        }

    }
}

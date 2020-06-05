using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ClientAPI.Infra.CrossCutting
{
    public static class Util
    { 
        public static string RemoveNonNumeric(string str)
        {
            if (str == null)
                return null;

            return Regex.Replace(str, @"[^0-9]+", "");
        }
    }
}

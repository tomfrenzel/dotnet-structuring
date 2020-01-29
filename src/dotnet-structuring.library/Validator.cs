using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dotnet_structuring.library
{
    public class Validator
    {
        public bool Number(string input)
        {
            var valid = false;

            while (!valid)
            {
                valid = !string.IsNullOrWhiteSpace(input) &&
                            input.All(c => c >= '0' && c <= '9');

                if (!valid)
                    return false;
            }
            return true;
        }
        
}
}

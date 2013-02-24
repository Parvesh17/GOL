using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Model
{
    public static class ValidationMethods
    {

        public static void ValidateGreaterThenZero(this int val, string errorMessage)
        {
            if (val <= 0 )
            {
                throw new ArgumentException(errorMessage);
            }
        }

        public static void ValidateGreaterThenZero(this short val, string errorMessage)
        {
            if (val <= 0)
            {
                throw new ArgumentException(errorMessage);
            }
        }

        public static void ValidateElementForNull<T>(this T obj, string errorMessage)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("errorMessage");
            }
        }

    }
}

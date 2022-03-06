using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.Extensions
{
    public static class PrimitiveExtensions
    {
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        public static int ToInt(this object obj)
        {
            return Convert.ToInt32(obj);
        }

        public static double ToDouble(this object obj)
        {
            return Convert.ToDouble(obj);
        }

        public static IComparable ToNumber(this object obj, Type type)
        {
            switch (type.ToString())
            {
                case "System.Int32":
                    return Convert.ToInt32(obj);
                case "System.Double":
                    return Convert.ToDouble(obj);
                    case "System.float":
                default:
                    return 0;
            }
        }
    }
}

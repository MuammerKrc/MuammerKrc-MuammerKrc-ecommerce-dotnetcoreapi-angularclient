using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Validators
{
    public class FluentErrorDesc
    {
        public static string NotNull = "Bu alan boş bırakılamaz";
        private static string maxLengthDesc = $"Maksimum karakter sayısı ";
        private static string minLengthDesc = $"Minumum karakter sayısı ";
        public static string minNumberDesc(int value) => $"En az {value}'e eşit olabilir";
        public static string maxNumberDesc(int value) => $"En fazla {value} eşit olabilir";


        public static string MaxLength(int maxLength)
        {
            return maxLengthDesc + maxLength;
        }
        public static string Minlength(int minLength)
        {
            return maxLengthDesc + minLength;
        }

    }
}

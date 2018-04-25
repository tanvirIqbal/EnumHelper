using System;
using System.ComponentModel;
using System.Reflection;

namespace EnumHelper
{
    class Program
    {
        public enum Demo
        {
            [Description("This is Enum 1")]
            ThisIsEnum1 = 1,
            [Description("This is Enum 2")]
            ThisIsEnum2 = 2,
            [Description("This is Enum 3")]
            ThisIsEnum3 = 3,
            [Description("This is Enum 4")]
            ThisIsEnum4 = 4,
            [Description("This is Enum 5")]
            ThisIsEnum5 = 5
        }
        static void Main(string[] args)
        {
            for (int i = 1; i < 6; i++)
            {
                Console.WriteLine(GetEnumDescription((Demo)i));
            }
            Console.ReadLine();
        }

        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
    }
}

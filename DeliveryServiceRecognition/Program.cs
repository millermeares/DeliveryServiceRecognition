using System;

namespace DeliveryServiceRecognition
{
    class Program
    {
        static void Main(string[] args)
        {
            string _1 = "9999 9999 9999";
            string _2 = "9999 9999 9999 999";
            string _3 = "9999 9999 9999 9999 9999";
            string _4 = "9999 9999 9999 9999 9999 99";

            string _5 = "1Z 9999 9999 9999 9999";
            string _6 = "9999 9999 9999";
            string _7 = "T 9999 9999 99";
            string _8 = "9999 99999";

            string _9 = "9400 1000 0000 0000 0000 00";
            string _10 = "9205 5000 0000 0000 0000 00";
            string _11 = "9407 3000 0000 0000 0000 00";
            string _12 = "9407 3000 0000 0000 0000 00";

            string[] numbers = new string[] { _1, _2, _3, _4, _5, _6, _7, _8, _9, _10, _11, _12 };
            foreach (string num in numbers)
            {
                Console.WriteLine(GetShippingCourier.GetCourierFromNumber(num));
            }
        }

    }
}

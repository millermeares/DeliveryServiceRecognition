using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DeliveryServiceRecognition
{
    class GetShippingCourier
    {
        public static string GetCourierFromNumber(string trackingNumber)
        {
            trackingNumber = trackingNumber.Replace(" ", "");

            string courier = "Unknown";
            if (IsFedExTrack(trackingNumber))
            {
                courier = "FedEx";
            }
            if (IsUSPSTrack(trackingNumber))
            {
                courier = "USPS";
            }
            if (IsUPSTrack(trackingNumber))
            {
                courier = "UPS";
            }
            if (IsFedExUPS_Overlap(trackingNumber))
            {
                courier = "UPS/FedEx";
            }


            return courier;
        }
        // regex largely derived from this post. Some modifications made in testing: https://andrewkurochkin.com/blog/code-for-recognizing-delivery-company-by-track
        private static bool IsUPSTrack(string trackingNumber)
        {
            List<Regex> validators = new List<Regex>();
            validators.Add(new Regex(@"^(1Z)[0-9A-Z]{16}$"));
            validators.Add(new Regex(@"^(T)+[0-9A-Z]{10}$"));
            validators.Add(new Regex(@"^[0-9]{9}$"));
            validators.Add(new Regex(@"^[0-9]{26}$"));

            foreach (Regex val in validators)
            {
                if (val.IsMatch(trackingNumber))
                {
                    return true;
                }
            }
            return false;
        }
        //source for regular expressions: https://andrewkurochkin.com/blog/code-for-recognizing-delivery-company-by-track
        private static bool IsFedExTrack(string trackingNumber)
        {
            List<Regex> validators = new List<Regex>();
            validators.Add(new Regex(@"^[0-9]{20}$"));
            validators.Add(new Regex(@"^[0-9]{15}$"));
            validators.Add(new Regex(@"^[0-9]{22}$"));

            foreach (Regex val in validators)
            {
                if (val.IsMatch(trackingNumber))
                {
                    return true;
                }
            }
            return false;
        }
        //source for regular expressions: https://andrewkurochkin.com/blog/code-for-recognizing-delivery-company-by-track
        private static bool IsUSPSTrack(string trackingNumber)
        {
            List<Regex> validators = new List<Regex>();
            validators.Add(new Regex(@"^(94|93|92|94|95)[0-9]{20}$"));
            validators.Add(new Regex(@"^(94|93|92|94|95)[0-9]{22}$"));
            validators.Add(new Regex(@"^(70|14|23|03)[0-9]{14}$"));
            validators.Add(new Regex(@"^(M0|82)[0-9]{8}$"));
            validators.Add(new Regex(@"^([A-Z]{2})[0-9]{9}([A-Z]{2})$"));

            foreach (Regex val in validators)
            {
                if (val.IsMatch(trackingNumber))
                {
                    return true;
                }
            }
            return false;
        }
        private static bool IsFedExUPS_Overlap(string trackingNumber)
        {
            return new Regex(@"^[0-9]{12}$").IsMatch(trackingNumber);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Net;

namespace CarSales.Parser
{
    static class Parser
    {
        private static WebClient client = new WebClient();
        private static String adres;
        private static String regexImg = @"(?<=data-src="")(.*?\.jpeg)";                        
        private static String regexTxt;
        private static String[] regex = new String[10];

        public static String[] StartPars(String name)
        {
            switch (name)
            {
                case "BMW":
                    MatchCollection matches = Regex.Matches(client.DownloadString("https://cars.av.by/bmw"), regexImg);
                    for (int i = 0; i < 10; i++)
                        regex[i] = matches[i].Groups[1].Value;
                    break;
                case "Mercedes-Benz":
                    adres = client.DownloadString("");
                    break;
                case "Audi":
                    adres = client.DownloadString("");
                    break;
                case "Porshe":
                    adres = client.DownloadString("");
                    break;
            }
            return regex;
        }
    }
}

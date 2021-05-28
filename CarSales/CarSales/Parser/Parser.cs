using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Net;

namespace CarSales.Parser
{
    static class Parser
    {
        private static WebClient client = new WebClient();
        private static String regexImg = @"(?<=data-src="")(.*?\.jpeg)";
        private static String regexCarName = @"";
        private static String regexHref = @"(?<=a class=""listing-item__link"" href="")(.+?)(?="")";
        private static String[] regex = new String[10];
        private static MatchCollection matches;

        public static String[] ParsImg(String name)
        {
            switch (name)
            {
                case "BMW":
                    matches = Regex.Matches(client.DownloadString("https://cars.av.by/bmw"), regexImg);
                    regex = MatchToStrArr(matches);
                    break;
                case "Mercedes-Benz":
                    matches = Regex.Matches(client.DownloadString("https://cars.av.by/mercedes-benz"), regexImg);
                    regex = MatchToStrArr(matches);
                    break;
                case "Audi":
                    matches = Regex.Matches(client.DownloadString("https://cars.av.by/audi"), regexImg);
                    regex = MatchToStrArr(matches);
                    break;
                case "Porsche":
                    matches = Regex.Matches(client.DownloadString("https://cars.av.by/porsche"), regexImg);
                    regex = MatchToStrArr(matches);
                    break;
            }
            return regex;
        }

        public static String[] ParsHref(String name)
        {
            switch (name)
            {
                case "BMW":
                    matches = Regex.Matches(client.DownloadString("https://cars.av.by/bmw"), regexHref);
                    regex = MatchToStrArr(matches);
                    break;
                case "Mercedes-Benz":
                    matches = Regex.Matches(client.DownloadString("https://cars.av.by/mercedes-benz"), regexHref);
                    regex = MatchToStrArr(matches);
                    break;
                case "Audi":
                    matches = Regex.Matches(client.DownloadString("https://cars.av.by/audi"), regexHref);
                    regex = MatchToStrArr(matches);
                    break;
                case "Porsche":
                    matches = Regex.Matches(client.DownloadString("https://cars.av.by/porsche"), regexHref);
                    regex = MatchToStrArr(matches);
                    break;
            }
            return regex;
        }

        private static String[] MatchToStrArr(MatchCollection matches)
        {
            String[] matchToStrArr = new String[10];

            for (int i = 0; i < 10; i++)
                matchToStrArr[i] = matches[i].Groups[1].Value;

            return matchToStrArr;
        }
    }
}

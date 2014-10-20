using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevLayer.Dev
{
    public static class StringCompareTool
    {
        public static StrCmpResult StringMatchWithStrictOrder(string str1, string str2, int minMacthWords = 2, string ignoreChars = " ()（）")
        {
            StrCmpResult result = new StrCmpResult();
            if (string.IsNullOrWhiteSpace(str1) || string.IsNullOrWhiteSpace(str2) || minMacthWords < 2)
                return result;
            if (ignoreChars != null && ignoreChars.Length > 0)
                foreach (char c in ignoreChars)
                {
                    str1 = str1.Replace(c.ToString(), "");
                    str2 = str2.Replace(c.ToString(), "");
                }

            List<string> matchs = new List<string>();
            int i1 = 0, i2 = 0;
            while (i1 < str1.Length && i2 < str2.Length)
            {
                int i2t = str2.IndexOf(str1[i1], i2);
                if (i2t < 0)
                {
                    i1++;
                    continue;
                }
                i2 = i2t;
                if (i1 + minMacthWords > str1.Length || i2 + minMacthWords > str2.Length)
                    break;
                int lenght = 2;
                while (str1[i1 + lenght - 1] == str2[i2 + lenght - 1])
                {
                    if (i1 + lenght >= str1.Length || i2 + lenght >= str2.Length)
                        break;
                    lenght++;
                }
                lenght--;
                if (lenght >= minMacthWords)
                {
                    matchs.Add(str1.Substring(i1, lenght));
                    i1 += lenght;
                    i2 += lenght;
                }
                else
                {
                    i1++;
                    i2++;
                }
            }
            result.Matchs = matchs.ToArray();
            result.Str1MatchRate = Math.Round(1.0 * matchs.Sum(item => item.Length) / str1.Length, 2);
            result.Str2MatchRate = Math.Round(1.0 * matchs.Sum(item => item.Length) / str2.Length, 2);
            return result;
        }
    }

    public class StrCmpResult
    {
        public string[] Matchs { get; set; }

        public double Str1MatchRate { get; set; }

        public double Str2MatchRate { get; set; }

        public int MatchLevel(double bothMatch = 0.6, double singleMatch = 0.8)
        {
            int result = 0;
            if (Str1MatchRate >= bothMatch && Str2MatchRate >= bothMatch)
                result += 1;
            if (Str1MatchRate >= singleMatch || Str2MatchRate >= singleMatch)
                result += 2;
            return result;
        }
    }
}

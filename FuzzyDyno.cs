using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuzzyString;

namespace FuzzyDyno
{
    /// <summary>
    /// Fuzzy String comparisons enable us to find a string that most closely matches a given string input.
    /// icon from http://cookie-waffle.deviantart.com/
    /// </summary>
    public static class FuzzyStringComparisons
    {
        /// <summary>
        /// Fuzzy string comparison betwee two strings using the JaroWinkler algorithm. 
        /// Well suited to short string
        /// Returns 1 if the strings are identical.
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns>A value between 0 and 1</returns>
        public static double CompareTwoStrings(string str1, string str2)
        {
            double value = FuzzyString.ComparisonMetrics.JaroWinklerDistance(str1, str2);
            return value;
        }



        /// <summary>
        /// Get the closest match, to a given string, from a list of strings.
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="strings"></param>
        /// <returns>a string matching</returns>
        public static string GetBestMatch(string str1, List<string> strings )
        {
            List<double> distances = strings.Select(x => FuzzyString.ComparisonMetrics.JaroWinklerDistance(str1, x)).ToList();
            int ind = distances.IndexOf(distances.Max());
            return strings[ind];
        }



    }
}

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
        /// Has problems if strings have repeat letters
        /// Returns 1 if the strings are identical.
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <param name="ignoreCase"></param>
        /// <returns>A value between 0 and 1</returns>
        public static double JaroWinkler(string str1, string str2, bool ignoreCase = false)
        {
            if (ignoreCase)
            {
                str1 = str1.ToLower();
                str2 = str2.ToLower();
            }
            double value = FuzzyString.ComparisonMetrics.JaroWinklerDistance(str1, str2);
            return value;
        }

        /// <summary>
        /// Fuzzy string comparison betwee two strings using the Jaccard Index. 
        /// Returns 1 if the strings are identical.
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <param name="ignoreCase"></param>
        /// <returns>A value between 0 and 1</returns>
        public static double JaccardIndex(string str1, string str2, bool ignoreCase = false)
        {
            if (ignoreCase)
            {
                str1 = str1.ToLower();
                str2 = str2.ToLower();
            }
            double value = FuzzyString.ComparisonMetrics.JaccardIndex(str1, str2);
            return value;
        }

        /// <summary>
        /// Fuzzy string comparison betwee two strings using the LevenshteinDistance. 
        /// Returns 1 if the strings are identical.
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <param name="ignoreCase"></param>
        /// <returns>A value between 0 and 1</returns>
        public static double LevenshteinDistance(string str1, string str2, bool ignoreCase = false)
        {
            if (ignoreCase)
            {
                str1 = str1.ToLower();
                str2 = str2.ToLower();
            }
            double value = FuzzyString.ComparisonMetrics.LevenshteinDistance(str1, str2);
            return value;
        }


        /// <summary>
        /// Get the closest match, to a given string, from a list of strings.
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="strings"></param>
        /// <returns>Best strings</returns>
        public static List<string> GetBestMatch(string str1, List<string> strings )
        {
            int bestLev = strings.Select(x => FuzzyString.ComparisonMetrics.LevenshteinDistance(str1, x)).Min();
            List<string> best = strings.Where(x => FuzzyString.ComparisonMetrics.LevenshteinDistance(str1, x) == bestLev).ToList();
            if (best.Count() > 1)
            {
                double bestJacc = best.Select(x => FuzzyString.ComparisonMetrics.JaccardIndex(str1, x)).Max();
                best = best.Where(x => FuzzyString.ComparisonMetrics.JaccardIndex(str1, x) == bestJacc).ToList();
            }

            return best;
        }



    }
}

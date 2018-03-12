///////////////////////////////////////////////////////////////////
//
// Youbiquitous v1.0 .NET Core
// Author: Dino Esposito
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Expoware.Youbiquitous.Core.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Checks whether the string contains any of the specified substrings.
        /// Search is case-insensitive.
        /// </summary>
        /// <param name="theString">String to search</param>
        /// <param name="tokens">List of substrings</param>
        /// <returns>True if any substrings is contained</returns>
        public static bool ContainsAny(this string theString, params string[] tokens)
        {
            var temp = theString.ToLower();
            return tokens.Any(s => temp.Contains(s.ToLower()));
        }

        /// <summary>
        /// Replaces any of the specified substrings with a given string
        /// </summary>
        /// <param name="theString">Original string</param>
        /// <param name="replacement">String to replace</param>
        /// <param name="tokens">List of substrings to replace</param>
        /// <returns>Modified string</returns>
        public static string ReplaceAny(this string theString, string replacement, params string[] tokens)
        {
            return tokens.Aggregate(theString, (current, t) => current.Replace(t, replacement));
        }

        /// <summary>
        /// Indicate whether a given string equals any of the specified substrings. 
        /// </summary>
        /// <param name="theString">String to process</param>
        /// <param name="args">List of possible matches</param>
        /// <returns>True/False</returns>
        public static bool EqualsAny(this string theString, params string[] args)
        {
            if (theString == null)
                return args.Any(token => token == null);
            return args.Any(token => theString.Equals(token, StringComparison.CurrentCultureIgnoreCase));
        }

        /// <summary>
        /// Indicate whether the given string is NULL or empty or whitespace.
        /// </summary>
        /// <param name="theString">String to process</param>
        /// <returns>True/False</returns>
        public static bool IsNullOrWhitespace(this string theString)
        {
            return string.IsNullOrWhiteSpace(theString);
        }

        /// <summary>
        /// Remove empty strings from an array
        /// </summary>
        /// <param name="theStringArray">Array of strings</param>
        /// <returns>Array without empty strings</returns>
        public static string[] RemoveEmpty(this IEnumerable<string> theStringArray)
        {
            return theStringArray.Where(s => !s.IsNullOrWhitespace()).ToArray();
        }

        /// <summary>
        /// Turns the string into a boolean (accepting yes/no, y/n, 1/0, +/-)
        /// Case-insensitive
        /// </summary>
        /// <param name="theString">Original string</param>
        /// <returns>Boolean</returns>
        public static bool ToBool(this string theString)
        {
            if (theString == null) throw new ArgumentNullException(nameof(theString));
            if (theString.IsNullOrWhitespace())
                return false;
            theString = theString.ToLower();
            return theString.ToLower().EqualsAny("yes", "y", "1", "+", "true");
        }

        /// <summary>
        /// Turns the string into an integer
        /// </summary>
        /// <param name="theString">Original string</param>
        /// <param name="defaultNumber">Value to return if conversion fails</param>
        /// <returns>Integer</returns>
        public static int ToInt(this string theString, int defaultNumber = 0)
        {
            if (theString.IsNullOrWhitespace())
                return defaultNumber;
            
            int number;
            var success = int.TryParse(theString, out number);
            if (!success)
            {
                if (theString.Contains("."))
                    theString = theString.SubstringTo(".");
                decimal number2;
                success = decimal.TryParse(theString, out number2);
                if (success)
                    number = (int)number2;
            }
            return success ? number : defaultNumber;
        }

        /// <summary>
        /// Parse a given string to a date.
        /// </summary>
        /// <param name="theString">String to parse</param>
        /// <param name="defaultDate">Date to return in case of failure</param>
        /// <returns>Date</returns>
        public static DateTime ToDate(this string theString, DateTime defaultDate = default(DateTime))
        {
            DateTime date;
            var success = DateTime.TryParse(theString, out date);
            return success ? date : defaultDate;   
        }

        /// <summary>
        /// Builds a date from a comma-separated string y,m,d
        /// </summary>
        /// <param name="theString">Original string, ideally y/m/d</param>
        /// <returns>Nullable date</returns>
        public static DateTime? TryAsCsvDate(this string theString)
        {
            if (theString.IsNullOrWhitespace())
                return null;
            var tokens = theString.Split(',');
            if (tokens.Length != 3)
                return null;
            try
            {
                return new DateTime(tokens[0].ToInt(), tokens[1].ToInt(), tokens[2].ToInt());
            }
            catch
            {
                return null;
            }
        }
        
        /// <summary>
        /// Inserts the string into the specified format string
        /// </summary>
        /// <param name="theString">Original string</param>
        /// <param name="format">Pattern</param>
        /// <returns>Modified string</returns>
        public static string InsertInto(this string theString, string format)
        {
            return string.Format(format, theString);
        }

        /// <summary>
        /// Get a slice of the provided string that begins at specified substring.
        /// </summary>
        /// <param name="theString">String to process</param>
        /// <param name="marker">Substring to locate</param>
        /// <param name="shouldIncludeMarker">Whether substring should be skipped or included</param>
        /// <returns>Substring</returns>
        public static string SubstringFrom(this string theString, string marker, bool shouldIncludeMarker = false)
        {
            var index = theString.IndexOf(marker, StringComparison.CurrentCultureIgnoreCase);
            if (index < 0)
                return theString;

            var startIndex = shouldIncludeMarker ? index : index + marker.Length;
            return theString.Substring(startIndex);
        }

        /// <summary>
        /// Get a slice of the provided string that ends at the specified substring.
        /// </summary>
        /// <param name="theString">String to process</param>
        /// <param name="marker">Substring to locate</param>
        /// <param name="shouldIncludeMarker">Whether substring should be skipped or included</param>
        /// <returns>Substring</returns>
        public static string SubstringTo(this string theString, string marker, bool shouldIncludeMarker = false)
        {
            var index = theString.IndexOf(marker, StringComparison.CurrentCultureIgnoreCase);
            if (index < 0)
                return theString;

            var endIndex = shouldIncludeMarker ? index + marker.Length : index;
            return theString.Substring(0, endIndex);
        }

        /// <summary>
        /// Get a slice of the provided string included between markers (not included)
        /// </summary>
        /// <param name="theString">String to process</param>
        /// <param name="marker1">Initial substring</param>
        /// <param name="marker2">Ending substring</param>
        /// <returns>Substring</returns>
        public static string SubstringBetween(this string theString, string marker1, string marker2)
        {
            var temp = theString.SubstringFrom(marker1);
            return temp.SubstringTo(marker2);
        }

        /// <summary>
        /// Returns a user-friendly value if the string is null or empty
        /// </summary>
        /// <param name="theString">Original string</param>
        /// <param name="emptyText">Text if it's empty</param>
        /// <returns></returns>
        public static string ToDefault(this string theString, string emptyText = "")
        {
            return theString.IsNullOrWhitespace() ? emptyText : theString;
        }

        /// <summary>
        /// Checks whether the string is a valid email address
        /// </summary>
        /// <param name="theString">Original string</param>
        /// <param name="okayIfEmpty">Whether empty is acceptable</param>
        /// <returns></returns>
        public static bool IsValidEmail(this string theString, bool okayIfEmpty = false)
        {
            if (theString.IsNullOrWhitespace())
                return okayIfEmpty;

            try
            {
                return Regex.IsMatch(theString,
                      @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                      @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                      RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        /// <summary>
        /// Turns a h:m string into a DateTime
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static DateTime? ToTime(this string time)
        {
            if (time.IsNullOrWhitespace())
                return null;

            var tokens = time.Split(':');
            if (tokens.Length != 2)
                return null;
            var date = new DateTime(
                DateTime.Today.Year,
                DateTime.Today.Month,
                DateTime.Today.Day,
                tokens[0].ToInt(),
                tokens[1].ToInt(),
                0);
            return date;
        }

        /// <summary>
        /// Breaks a char-separared string into an array of integers
        /// </summary>
        /// <param name="theString">Original string</param>
        /// <param name="separator">separator</param>
        /// <returns>Array of integers</returns>
        public static IList<int> ToIntList(this string theString, char separator = ',')
        {
            const int naN = -9999999;

            var list = new List<int>();
            if (theString.IsNullOrWhitespace())
                return list;

            var tokens = theString.Split(separator);
            list.AddRange(tokens.Select(t => t.ToInt(naN)).Where(number => number != naN));
            return list;
        }

        /// <summary>
        /// Returns a nice HTML text if the string is null or empty
        /// </summary>
        /// <param name="theString">Original string</param>
        /// <param name="defaultText">Default text if empty</param>
        /// <param name="css">Default CSS if empty</param>
        /// <returns>Modified string</returns>
        public static string ToHtmlDefault(this string theString, string defaultText = "", string css = "")
        {
            if (theString.IsNullOrWhitespace())
            {
                return css.IsNullOrWhitespace()
                    ? defaultText
                    : $"<span class='{css}'>{defaultText}</span>";
            }
            return theString;
        }

        /// <summary>
        /// Turns the string into titlecase according to the current culture
        /// </summary>
        /// <param name="theString">Original string</param>
        /// <returns>Modified string</returns>
        public static string Capitalize(this string theString)
        {
            if (theString.IsNullOrWhitespace())
                return theString;

            var tokens = theString.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            for (var i = 0; i < tokens.Length; i++)
            {
                var token = tokens[i];
                tokens[i] = token.Substring(0, 1).ToUpper() + token.Substring(1).ToLower();
            }

            return string.Join(" ", tokens);
        }

        /// <summary>
        /// Trims if not empty
        /// </summary>
        /// <param name="theString">Original string</param>
        /// <returns>Modified string</returns>
        public static string TrimOrDefault(this string theString)
        {
            return theString.IsNullOrWhitespace() ? null : theString.Trim();
        }

        /// <summary>
        /// Formats as a mailto HTML string
        /// </summary>
        /// <param name="theString">Email address</param>
        /// <param name="textFormat">Pattern for the anchor text. Uses the email.</param>
        /// <returns></returns>
        public static string Mailto(this string theString, string textFormat = "{0}")
        {
            if (!theString.IsValidEmail())
                return theString;
            var anchorText = string.Format(textFormat, theString);
            return $"<a href=mailto:{theString}>{anchorText}</a>";
        }
    }
}
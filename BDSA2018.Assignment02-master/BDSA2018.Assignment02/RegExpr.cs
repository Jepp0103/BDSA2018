using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BDSA2018.Assignment02
{
    public static class RegExpr
    {
        public static IEnumerable<string> SplitLine(IEnumerable<string> lines)
        {
            var pattern = @"\w+";
            foreach (var line in lines)
            {
                foreach (Match match in Regex.Matches(line, pattern)) {
                    yield return match.Value;
                }
            }
        }

        public static IEnumerable<(int width, int height)> Resolution(string resolutions)
        {
            var pattern = @"((?<width>\d+)x(?<height>\d+))";
            foreach (Match match in Regex.Matches(resolutions, pattern))
            {
                var groups = match.Groups;
                int width = Convert.ToInt32(groups["width"].Value);
                int height = Convert.ToInt32(groups["height"].Value);

                yield return (width, height);
            }

        }

        public static IEnumerable<string> InnerText(string html, string tag)
        {
            throw new NotImplementedException();
        }
    }
}

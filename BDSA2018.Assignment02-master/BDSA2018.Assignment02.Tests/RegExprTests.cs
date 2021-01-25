using Xunit;
using System.Collections.Generic;

namespace BDSA2018.Assignment02.Tests
{
    public class RegExprTests
    {
        [Fact]
        public void SplitLine_given_3_strings_result_10_words()
        {
            var lines = new string[] { "Jeg hedder Jeppe", "Hvad sker der idag", "23ar 98yh gammel" };
            var result = RegExpr.SplitLine(lines);
            Assert.Equal(new string[] { "Jeg", "hedder", "Jeppe", "Hvad", "sker", "der", "idag", "23ar", "98yh", "gammel" }, result);
        }

        [Fact]
        public void Resolutions_given_1_resolution_result_1920_1080_tuple()
        {
            IEnumerable<(int, int)> expected = new (int, int)[] { (1920, 1080) };
            IEnumerable<(int, int)> result = RegExpr.Resolution("1920x1080");
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Resolutions_given_2_resolutions_result_2_tuples()
        {
            IEnumerable<(int, int)> expected = new (int, int)[] { (1920, 1080), (1280, 720) };
            IEnumerable<(int, int)> result = RegExpr.Resolution("1920x1080 1280x720");
            Assert.Equal(expected, result);
        }
    }
}

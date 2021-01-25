using System.Collections.Generic;
using Xunit;
using System;

namespace BDSA2018.Assignment02.Tests
{
    public class IteratorsTests
    {
        [Fact]
        public void test()
        {
            string hello = "hello";
            Assert.Equal("hello", hello);
        }

        [Fact]
        public void Flatten_given_1_2_3_and_4_5_6_as_array_result_flattened_array() {
            int[] arr1 = new int[] { 1, 2, 3 };
            int[] arr2 = new int[] { 4, 5, 6 };
            int[][] arr3 = new int[][] { arr1, arr2 };

            IEnumerable<int> result = Helpers.Flatten(arr3);
            List<int> expected = new List<int>(new int[] { 1, 2, 3, 4, 5, 6 });

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Filter_even_numbers_given_1_2_3_4_result_2_4() {
            Predicate<int> isEven = i => i % 2 == 0;
            int[] arr = new int[] { 1, 2, 3, 4 };
            var result = Helpers.Filter(arr, isEven);
            Assert.Equal(new int[] { 2, 4 }, result);
        }
    }
}

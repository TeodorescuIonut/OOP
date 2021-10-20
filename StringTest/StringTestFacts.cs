using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace StringTest
{
    public static class StringTestFacts
    {
        [Fact]
        public static void ReturnNoOfVocalsAndConsonants()
        {
            const string word = " 'aabbbbceitu@";
            (int vocalsNo, int consNo) = GetNoOfVowelsAndConsonants(word);
            Assert.Equal(6, consNo);
            Assert.Equal(5, vocalsNo);
        }

        [Fact]
        public static void ReturnFirstNonRepeatingCharacter()
        {
            const string word = "aabbbbeitu";
            var firstNonRepeatedChar = GetFirstNonRepeatingCharacter(word);
            Assert.Equal('e', firstNonRepeatedChar);
        }

        [Fact]
        public static void ReturnFromStringAnInteger()
        {
            const string numberAsString = "6534";
            var numbersAsInt = GetIntegerFromString(numberAsString);
            Assert.Equal(6534, numbersAsInt);
        }

        [Fact]
        public static void ReturnFromStringCharWithMoreOccurrences()
        {
            const string word = "aaaaaaabstwqeeeertwesl";
            var character = GetCharWithMostOccurrencesInAString(word);
            Assert.Equal('a', character);
        }

        [Fact]
        public static void ReturnPalindromeSubstrings()
        {
            const string word = "aabaac";
            var palindromCombinations = GetSubstringsThatArePalindrome(word);
            Assert.Equal("aba", palindromCombinations[8]);
        }

        [Fact]
        public static void REturnSumOfIntegerValues()
        {
            int[] numbers = { 1, 2, 3 };
            const int k = 3;
            var subArrays = GetSubArraysCombinations(numbers, k);
            Assert.Equal(2, subArrays[2][0]);
            Assert.Equal(3, subArrays[3][0]);
        }

        [Fact]
        public static void REturnAllSumCombinationss()
        {
            const int numberOfElem = 3;
            const int k = 2;
            var subArrays = GetSumCombinations(numberOfElem, k);
            Assert.Equal("+1-2+3=2", subArrays[0]);
        }

        [Fact]
        public static void ReturnPythagoreanTriplets()
        {
            int[] numbers = { 1, 3, 2, 4, 5, 8, 10 };
            var tripletsResult = GetPythagoreanTriplets(numbers);
            Assert.Equal((3, 4, 5), tripletsResult[1]);
        }

        [Fact]
        public static void ReturnProductsThatHaveAtLeastOneFeature()
        {
            var products = new List<Product>
        {
            new Product()
            {
                Name = "Tadpole", Features = new List<Feature>
            {
                new Feature() { Id = 2 },
                new Feature() { Id = 3 },
                new Feature() { Id = 4 }
            }
            },
            new Product()
            {
                Name = "Pinwheel", Features = new List<Feature>
            {
                new Feature() { Id = 1 },
                new Feature() { Id = 5 },
                new Feature() { Id = 6 }
            }
            }
        };
            List<Feature> features = new List<Feature>
            {
                 new Feature() { Id = 1 },
                 new Feature() { Id = 5 },
                 new Feature() { Id = 6 }
            };

            var firstQuery = GetProductsThatHaveAtLeastOneFeature(products, features);

            Assert.Collection(
                firstQuery[0].Features,
                item => Assert.Equal(1, item.Id),
                item => Assert.Equal(5, item.Id),
                item => Assert.Equal(6, item.Id));
        }

        [Fact]
        public static void ReturnProductsThatHaveAllFeatures()
        {
            var products = new List<Product>
        {
            new Product()
            {
                Name = "Tadpole", Features = new List<Feature>
            {
                new Feature() { Id = 2 },
                new Feature() { Id = 3 },
                new Feature() { Id = 4 }
            }
            },
            new Product()
            {
                Name = "Pinwheel", Features = new List<Feature>
            {
                new Feature() { Id = 1 },
                new Feature() { Id = 5 },
                new Feature() { Id = 6 }
            }
            }
        };
            List<Feature> features = new List<Feature>
            {
                 new Feature() { Id = 1 },
                 new Feature() { Id = 5 },
                 new Feature() { Id = 6 }
            };

            var secondQuery = GetProductsThatHaveAllFeatures(products, features);
            Assert.Collection(
                secondQuery[0].Features,
                item => Assert.Equal(1, item.Id),
                item => Assert.Equal(5, item.Id),
                item => Assert.Equal(6, item.Id));
        }

        [Fact]
        public static void ReturnProductsThatDontHaveAnyFeatures()
        {
            var products = new List<Product>
        {
            new Product()
            {
                Name = "Tadpole", Features = new List<Feature>
            {
                new Feature() { Id = 2 },
                new Feature() { Id = 3 },
                new Feature() { Id = 4 }
            }
            },
            new Product()
            {
                Name = "Pinwheel", Features = new List<Feature>
            {
                new Feature() { Id = 1 },
                new Feature() { Id = 5 },
                new Feature() { Id = 6 }
            }
            }
        };
            List<Feature> features = new List<Feature>
            {
                 new Feature() { Id = 1 },
                 new Feature() { Id = 5 },
                 new Feature() { Id = 6 }
            };

            var thirdQuery = GetProductsThatDontHaveAnyFeatures(products, features);
            Assert.Collection(
                thirdQuery[0].Features,
                item => Assert.Equal(2, item.Id),
                item => Assert.Equal(3, item.Id),
                item => Assert.Equal(4, item.Id));
        }

        private static List<Product> GetProductsThatHaveAtLeastOneFeature(List<Product> products, List<Feature> features)
        {
            return products.Where((f, i) => f.Features.Any(c => features[i].Id == c.Id)).ToList();
        }

        private static List<Product> GetProductsThatHaveAllFeatures(List<Product> products, List<Feature> features)
        {
            return products.Where((f, i) => f.Features.Any(c => features[i].Id == c.Id)).ToList();
        }

        private static List<Product> GetProductsThatDontHaveAnyFeatures(List<Product> products, List<Feature> features)
        {
            return products.Where((f, i) => f.Features.All(c => features[i].Id != c.Id)).ToList();
        }

        private static (int a, int b, int c)[] GetPythagoreanTriplets(int[] numbers)
        {
            return numbers.SelectMany(c => numbers.SelectMany(b =>
            numbers.Where(a => a * a + b * b == c * c).Select(a => (a, b, c)))).ToArray();
        }

        private static string[] GetSumCombinations(int elemNo, int targetSum)
        {
            string[] elements = new[] { "" };
            int[] testElem = new[] { 1, 2, 3 };
            elements = Enumerable.Range(0, elemNo).Aggregate(elements, (result, next) => result.SelectMany(str =>
            new[] { str + '+', str + '-' }).ToArray());
            var solutionsArr = elements.Select(str => str.Select((c, i) => c == '+' ? i + 1 : -(i + 1))).Where(arr => arr.Sum() == targetSum);
            return solutionsArr.Select(item => item.Aggregate("", (e, next) => next < 0 ? e + next : e + '+' + next) + '=' + targetSum).ToArray();
        }

        private static int[][] GetSubArraysCombinations(int[] numArray, int targetSum)
        {
            return numArray.SelectMany((x, index) => numArray.Skip(index).Select((i, j) => numArray[index..i])).Where(x => x.Sum() <= targetSum).ToArray();
        }

        private static char GetCharWithMostOccurrencesInAString(string word)
        {
            return word.GroupBy(x => x).Aggregate((max, i) => max.Count() > i.Count() ? max : i).Key;
        }

        private static string[] GetSubstringsThatArePalindrome(string word)
        {
            return Enumerable
    .Range(1, word.Length)
    .SelectMany(size => Enumerable
       .Range(0, word.Length - size + 1)
       .Select(i => word.Substring(i, size)))
    .Where(item => item.SequenceEqual(item.Reverse()))
    .ToArray();
        }

        private static int GetIntegerFromString(string word)
        {
            int sign = 1;
            if (word.StartsWith('-'))
            {
                word = word[1..];
                sign = -1;
            }

            return word.Select(x =>
            char.IsDigit(x) ?
            x - '0' :
            throw new ArgumentException("the character is not a valid integer", nameof(x)))
                .Aggregate((result, x) => result * 10 + x) * sign;
        }

        private static (int vocalsNo, int consNo) GetNoOfVowelsAndConsonants(this string word)
        {
            const string vowels = "aeiou";
            return word.Aggregate((v: 0, c: 0), (total, c) =>
            {
                if (char.IsLetter(c))
                {
                    return vowels.Contains(c) ? (total.v + 1, total.c) : (total.v, total.c + 1);
                }

                return (total.v, total.c);
            });
        }

        private static char GetFirstNonRepeatingCharacter(this string word)
        {
            return word.GroupBy(x => x).First(x => x.Count() == 1).Key;
        }
    }
}

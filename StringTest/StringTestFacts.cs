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
            Assert.Equal<Product>(
                new[]
            {
                products[1]
            }, firstQuery);
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
            Assert.Equal<Product>(
                new[]
            {
                            products[1]
            }, secondQuery);
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
            Assert.Equal<Product>(
                new[]
            {
            products[0]
            }, thirdQuery);
        }

        [Fact]
        public static void ReturnTotalQuanitityForProducts()
        {
            List<Products> firstProducts = new List<Products>
            {
                new Products()
                {
                    Name = "Apples",
                    Quantity = 5
                },

                new Products()
                {
                    Name = "Oranges",
                    Quantity = 5
                },

                new Products()
                {
                    Name = "Pears",
                    Quantity = 5
                }
            };

            List<Products> secondProducts = new List<Products>
            {
                new Products()
                {
                    Name = "Apples",
                    Quantity = 5
                },

                new Products()
                {
                    Name = "Oranges",
                    Quantity = 12
                },

                new Products()
                {
                    Name = "Pears",
                    Quantity = 8
                }
            };

            var combinedProducts = GetTotalQuantityOfEachProduct(firstProducts, secondProducts);
            Assert.Equal<Products>(
                new[]
            {
                new Products()
                {
                    Name = "Apples",
                    Quantity = 10
                },

                new Products()
                {
                    Name = "Oranges",
                    Quantity = 17
                },

                new Products()
                {
                    Name = "Pears",
                    Quantity = 13
                }
            }, combinedProducts);
        }

        [Fact]
        public static void ReturnHighestScore()
        {
            List<TestResults> scoreResults = new List<TestResults>()
            {
                new TestResults()
                {
                    Id = "one",
                    FamilyId = "firstFamily",
                    Score = 10
                },
                new TestResults()
                {
                    Id = "two",
                    FamilyId = "secondFamily",
                    Score = 10
                },
                new TestResults()
                {
                    Id = "one",
                    FamilyId = "firstFamily",
                    Score = 15
                },
                new TestResults()
                {
                    Id = "five",
                    FamilyId = "fifthFamily",
                    Score = 10
                },
                new TestResults()
                {
                    Id = "five",
                    FamilyId = "fifthFamily",
                    Score = 34
                }
            };

            var finalResults = GetHighestScore(scoreResults);
            Assert.Equal<TestResults>(
                new[]
            {
                scoreResults[2],
                scoreResults[1],
                scoreResults[4]
            }, finalResults);
        }

        [Fact]
        public static void ReturnTopWordsUsedInAText()
        {
            const string text = "I felt happy because I saw the others were happy and because I knew I should feel happy, but I wasn’t really happy.";
            const int noOfElem = 2;
            var topWords = GetTopWordOccurrencesInAText(text, noOfElem);
            Assert.Equal(("I", 5), topWords[0]);
        }

        [Fact]
        public static void ValidateSudokuGrid()
        {
            int[,] board = new int[,]
            {
                { 3, 1, 6, 5, 7, 8, 4, 9, 2 },
                { 5, 2, 9, 1, 3, 4, 7, 6, 8 },
                { 4, 8, 7, 6, 2, 9, 5, 3, 1 },
                { 2, 6, 3, 4, 1, 5, 9, 8, 7 },
                { 9, 7, 4, 8, 6, 3, 1, 2, 5 },
                { 8, 5, 1, 7, 9, 2, 6, 4, 3 },
                { 1, 3, 8, 9, 4, 7, 2, 5, 6 },
                { 6, 9, 2, 3, 5, 1, 8, 7, 4 },
                { 7, 4, 5, 2, 8, 6, 3, 1, 9 }
            };

            bool result = CheckIfValidSudokuBoard(board);
            Assert.True(result);
        }

        private static bool CheckIfValidSudokuBoard(int[,] sudokuBoard)
        {
            var upperLimit = sudokuBoard.GetUpperBound(0) + 1;
            var lines = Enumerable.Range(0, upperLimit)
                .Select(x => Enumerable.Range(0, upperLimit).Select(y => sudokuBoard[x, y]));
            var columns = Enumerable.Range(0, upperLimit)
                .Select(x => Enumerable.Range(0, upperLimit).Select(y => sudokuBoard[y, x]));
            var squares = Enumerable.Range(0, 3).SelectMany(y => Enumerable.Range(0, 3).Select(x =>
                 lines.Skip(y * 3).Take(3).SelectMany(row =>
                     row.Skip(x * 3).Take(3))));
            var combinedEnum = lines.Concat(columns).Concat(squares);
            return combinedEnum.All(IsValidBoard);
        }

        private static bool IsValidBoard(IEnumerable<int> board)
        {
            return board.Distinct().Count() == board.Count() &&
                   board.All(x => x > 0 && x <= 9) &&
                   board.Count() == 9;
        }

        private static (string key, int)[] GetTopWordOccurrencesInAText(string text, int number)
        {
            var wordsList = text.Split(".?! ;:,".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            return wordsList.GroupBy(w => w)
                          .Where(w => w.Count() > 1)
                          .OrderByDescending(w => w.Count())
                          .Select(w => (w.Key, w.Count())).Take(number).ToArray();
        }

        private static List<TestResults> GetHighestScore(List<TestResults> scoreResults)
        {
            return scoreResults.GroupBy(s => s.FamilyId).Select(s => s.Aggregate((max, x) => x.Score > max.Score ? x : max)).ToList();
        }

        private static List<Products> GetTotalQuantityOfEachProduct(List<Products> firstProducts, List<Products> secondProducts)
        {
            return firstProducts.Concat(secondProducts).GroupBy(o => new { o.Name })
                .Select(o => new Products()
                {
                    Name = o.Key.Name,
                    Quantity = o.Sum(q => q.Quantity)
                }).ToList();
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

        struct Products
        {
            public string Name;
            public int Quantity;
        }
    }
}

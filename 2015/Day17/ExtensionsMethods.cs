using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day17
{
    public static class ExtensionsMethods
    {
        /// <summary>
        /// Generates combinations with repetitions
        /// </summary>
        /// <typeparam name="T">Type of items to combine.</typeparam>
        /// <param name="items">Array of items. Will not be modified.</param>
        /// <param name="length">Length of combinations, equal to <paramref name="items"/> length if null</param>
        /// <param name="reverse">If changes should begin with array end (high indexes) first</param>
        /// <returns>Combinations of input items.</returns>
        public static IEnumerable<T[]> Combinations<T>(this T[] items, int? length = null, bool reverse = true)
        {
            var itemsLength = items.Length;
            var combinationLength = length ?? itemsLength;
            var indexes = new int[combinationLength];

            var overflow = false;
            while (!overflow)
            {
                var combination = new T[combinationLength];
                for (var i = 0; i < combinationLength; i++)
                    combination[i] = items[indexes[reverse ? combinationLength - i - 1 : i]];
                yield return combination;

                overflow = true;
                for (var i = 0; i < combinationLength && overflow; i++)
                {
                    var index = indexes[i] + 1;
                    overflow = index == itemsLength;
                    indexes[i] = overflow ? 0 : index;
                }
            }
        }

        public static IEnumerable<IEnumerable<T>> CombinationsWithoutRepetition<T>(
            this IEnumerable<T> items,
            int ofLength)
        {
            return (ofLength == 1) ?
                items.Select(item => new[] { item }) :
                items.SelectMany((item, i) => items.Skip(i + 1)
                                                   .CombinationsWithoutRepetition(ofLength - 1)
                                                   .Select(result => new T[] { item }.Concat(result)));
        }

        public static IEnumerable<IEnumerable<T>> CombinationsWithoutRepetition<T>(
            this IEnumerable<T> items,
            int ofLength,
            int upToLength)
        {
            return Enumerable.Range(ofLength, Math.Max(0, upToLength - ofLength + 1))
                             .SelectMany(len => items.CombinationsWithoutRepetition(ofLength: len));
        }
    }
}

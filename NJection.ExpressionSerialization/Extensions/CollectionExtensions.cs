﻿using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace NJection.ExpressionSerialization.Extensions
{
    public static class CollectionExtensions
    {
        public static void ForEach<TSource>(this IEnumerable<TSource> source, int seed, Action<TSource, int> action) {
            foreach (TSource item in source) {
                action(item, seed++);
            }
        }

        public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource, int> action) {
            int count = 0;

            foreach (TSource item in source) {
                action(item, count++);
            }
        }

        public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource> action) {
            foreach (TSource item in source) {
                action(item);
            }
        }

        public static bool All<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> predicate) {
            int count = 0;

            foreach (TSource local in source) {
                if (!predicate(local, count++)) {
                    return false;
                }
            }

            return true;
        }

		public static IEnumerable<TSource> NullCoalescing<TSource>(this IEnumerable<TSource> source) {
            return source.IsNullOrEmpty() ? null : source;
        }

        public static bool IsNullOrEmpty<TSource>(this IEnumerable<TSource> source) {
            if (source == null) {
                return true;
            }

            return !source.Any();
        }

		public static IEnumerable<TSource> Concat<TSource>(this IEnumerable<TSource> source, params TSource[] others) {
            foreach (TSource item in source) {
                yield return item;
            }

            foreach (TSource item in others) {
                yield return item;
            }
        }

        public static IEnumerable<TSource> Distinct<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> predicate) {
            HashSet<TKey> keys = new HashSet<TKey>();

            foreach (TSource element in source) {
                if (keys.Add(predicate(element))) {
                    yield return element;
                }
            }
        }

        public static TResult[] ToArrayOf<TResult>(this IEnumerable source) {
            return source.Cast<TResult>()
                         .ToArray();
        }

        public static List<TResult> ToListOf<TResult>(this IEnumerable source) {
            return source.Cast<TResult>()
                         .ToList();
        }

        public static TSource MaxElement<TSource, TData>(this IEnumerable<TSource> source, Func<TSource, TData> predicate)
            where TData : IComparable<TData> {
            bool firstElement = true;
            TSource result = default(TSource);
            TData maxValue = default(TData);

            foreach (TSource element in source) {
                var candidate = predicate(element);

                if (firstElement || candidate.CompareTo(maxValue) > 0) {
                    firstElement = false;
                    maxValue = candidate;
                    result = element;
                }
            }

            return result;
        }

        public static int IndexOf<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate) {
            int index = -1;
            int count = -1;

            foreach (var item in source) {
                count++;

                if (predicate(item)) {
                    index = count;
                    break;
                }
            }

            return index;
        }

        public static ConcurrentDictionary<TKey, TSource> ToThreadSafeDictionary<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector) {
            return ToThreadSafeDictionary(source, local => keySelector(local), local => local);
        }

        public static ConcurrentDictionary<TKey, TValue> ToThreadSafeDictionary<TSource, TKey, TValue>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TValue> elementSelector) {
            return new ConcurrentDictionary<TKey, TValue>(
                    source.ToDictionary(local => keySelector(local), local => elementSelector(local)));
        }
    }
}
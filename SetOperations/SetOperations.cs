using System.Collections.Generic;
using System.Linq;

namespace SetOperations
{
    public static class SetOperations<T>
    {
        public static IEnumerable<T[]> CrossProduct(IEnumerable<IEnumerable<T>> sets)
        {
            if (sets.All(set => set.Count() > 0))
            {
                IEnumerator<T>[] setEnumerators = new IEnumerator<T>[sets.Count()];
                int largestValidPos = -1;
                do
                {
                    for (int j = largestValidPos + 1; j < sets.Count(); j++)
                        setEnumerators[j] = sets.ElementAt(j).GetEnumerator();
                    if (setEnumerators.Skip(largestValidPos + 1).All(setEnumerator => setEnumerator.MoveNext()))
                    {
                        yield return setEnumerators.Select(setEnumerator => setEnumerator.Current).ToArray();
                        for (largestValidPos = sets.Count() - 1; largestValidPos >= 0 && !setEnumerators[largestValidPos].MoveNext(); largestValidPos--);
                    }
                    else largestValidPos--;
                } while (largestValidPos >= 0);
            }
        }

        private static IEnumerable<List<T>> _SubSets(IEnumerable<T> set, int cardinality)
        {
            if (cardinality == 0)
            {
                yield return new List<T>();
            }
            else if (0 < cardinality && cardinality <= set.Count())
            {
                foreach(var subSet in Enumerable.Range(0, set.Count() - cardinality + 1)
                    .SelectMany(firstIndex => _SubSets(set.Skip(firstIndex + 1), cardinality - 1).Select(tailSubSet => (new List<T>() { set.ElementAt(firstIndex) }).Concat(tailSubSet).ToList())))
                {
                    yield return subSet;
                }
            }
        }

        public static IEnumerable<T[]> SubSets(IReadOnlyCollection<T> set, int cardinality)
        {
            return _SubSets(set, cardinality).Select(subset => subset.ToArray());
        }
    }
}

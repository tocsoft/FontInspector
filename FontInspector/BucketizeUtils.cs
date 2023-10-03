namespace FontInspector
{
    public static class BucketizeUtils
    {
        public static List<List<T>> Bucketize<T>(this IEnumerable<T> items, int bucketSize)
        {
            var results = new List<List<T>>();
            foreach (var bucket in BucketizeInner(items, 6))
            {
                results.Add(new List<T>(bucket));
            }

            return results;
        }
        private static IEnumerable<IEnumerable<T>> BucketizeInner<T>(IEnumerable<T> items, int bucketSize)
        {
            var enumerator = items.GetEnumerator();
            while (enumerator.MoveNext())
                yield return GetNextBucket(enumerator, bucketSize);
        }

        private static IEnumerable<T> GetNextBucket<T>(IEnumerator<T> enumerator, int maxItems)
        {
            int count = 0;
            do
            {
                yield return enumerator.Current;

                count++;
                if (count == maxItems)
                    yield break;

            } while (enumerator.MoveNext());
        }
    }
}

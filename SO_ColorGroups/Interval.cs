namespace ColorGroups
{
    /// <summary>
    /// Represents an interval with integer boundaries (included in the interval).
    /// </summary>
    public class Interval
    {
        public int LowerBound { get; }
        public int UpperBound { get; }
        public bool NonEmpty => LowerBound <= UpperBound;

        public Interval(int lowerBound, int upperBound)
        {
            this.LowerBound = lowerBound;
            this.UpperBound = upperBound;
        }
        public bool Contains(int number) => LowerBound <= number && number <= UpperBound;

        public override string ToString()
        {
            return $"[{LowerBound},{UpperBound}]";
        }
    }
}

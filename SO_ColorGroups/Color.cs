using System.Collections.Generic;
using System.Linq;

namespace ColorGroups
{
    /// <summary>
    /// Represents a set of color points in the form of an ordered array of distinct integers.
    /// </summary>
    public class Color
    {
        private readonly int[] _points;
        public IReadOnlyCollection<int> Points => _points;

        public Interval Distance { get; }

        public string Name { get; }

        public Color(string name, IEnumerable<int> points, Interval distance)
        {
            this.Name = name;
            this._points = points.OrderBy(c => c).Distinct().ToArray();
            this.Distance = distance;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

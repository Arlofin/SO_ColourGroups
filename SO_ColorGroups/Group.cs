using System.Collections.Generic;
using System.Linq;

namespace ColorGroups
{
    /// <summary>
    /// Represents a group of color points.
    /// </summary>
    public class Group
    {
        private readonly ColorPoint[] _elements;
        public IReadOnlyCollection<ColorPoint> Elements => _elements;

        public Group(IEnumerable<ColorPoint> elements)
        {
            this._elements = elements.ToArray();
        }
    }

    public class GroupBuilder
    {
        private List<ColorPoint> _elements = new List<ColorPoint>();
        public IReadOnlyCollection<ColorPoint> Elements => _elements;

        public void Add(ColorPoint element)
        {
            this._elements.Add(element);
        }

        public Group Emit() => new Group(Elements);
    }
}

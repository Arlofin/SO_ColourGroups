using System.Collections.Generic;
using System.Linq;

namespace ColorGroups
{
    /// <summary>
    /// Represents the specification for the colour groups to be constructed.
    /// </summary>
    public class ProblemSpecification
    {
        private readonly Color[] _colors;
        public IReadOnlyCollection<Color> Colors => _colors;

        public double Fraction { get; }

        public ProblemSpecification(IEnumerable<Color> colors, double fraction)
        {
            this._colors = colors.ToArray();
            this.Fraction = fraction;
        }

        public ProblemSpecification CloneWith(IEnumerable<Color> colors = null, IEnumerable<Interval> intervals = null, double? fraction = null)
        {
            return new ProblemSpecification(
                colors ?? this.Colors,
                fraction ?? this.Fraction);
        }
    }
}

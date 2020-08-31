using System;
using System.Collections.Generic;
using System.Linq;

using SetOperations;

namespace ColorGroups
{
    public static class ProblemSolver
    {
        private static bool IsGroupValid(Group group)
        {
            return group.Elements.Zip(group.Elements.Skip(1), (pre, el) => el.Color.Distance.Contains(el.Value - pre.Value)).All(b => b);
        }

        private static IEnumerable<Group> NaiveSolverFull(IEnumerable<Color> colors)
        {
            var colourPointsPerColor = from color in colors
                                       select color.Points.Select(colorValue => new ColorPoint(colorValue, color));
            var groupCandidates = from colorPointCombination in SetOperations<ColorPoint>.CrossProduct(colourPointsPerColor)
                                  select new Group(colorPointCombination);
            return groupCandidates.Where(IsGroupValid);
        }

        public static IEnumerable<Group> NaiveSolver(ProblemSpecification spec)
        {
            int minimalNumberOfColors = MinimalNumberOfColors(spec.Colors.Count, spec.Fraction);
            return Enumerable.Range(minimalNumberOfColors, spec.Colors.Count - minimalNumberOfColors + 1)
                .SelectMany(n => SetOperations<Color>.SubSets(spec.Colors, n)
                    .SelectMany(NaiveSolverFull));
        }

        public static int MinimalNumberOfColors(int nrColors, double fractionOfColorsToUse)
        {
            return (int)Math.Ceiling(fractionOfColorsToUse * nrColors);
        }
    }
}

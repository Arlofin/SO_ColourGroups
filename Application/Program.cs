using System;

using ColorGroups;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            var blue   = new Color("B", new[] { 10, 20, 100, 200 },               new Interval(0, 0));
            var red    = new Color("R", new[] { 50, 105, 150 },                   new Interval(0, 20));
            var green  = new Color("G", new[] { 80, 110, 250 },                   new Interval(0, 25));
            var yellow = new Color("Y", new[] { 42, 62, 82, 102, 122, 142, 162 }, new Interval(0, 25));

            var spec = new ProblemSpecification(new[] { blue, red, green, yellow }, 0.5);

            var groups = ProblemSolver.NaiveSolver(spec);

            Console.WriteLine("*** Color Group Finder ***");
            Console.WriteLine();
            Console.WriteLine("The colors:");
            Console.WriteLine("Blue:   {0}", String.Join(", ",   blue.Points));
            Console.WriteLine("Red:    {0}", String.Join(", ",    red.Points));
            Console.WriteLine("Green:  {0}", String.Join(", ",  green.Points));
            Console.WriteLine("Yellow: {0}", String.Join(", ", yellow.Points));
            Console.WriteLine();
            Console.WriteLine("The distances:");
            Console.WriteLine("Red to blue:    {0}",  red.Distance);
            Console.WriteLine("Green to red:   {0}",  green.Distance);
            Console.WriteLine("Yello to green: {0}", yellow.Distance);
            Console.WriteLine();
            Console.WriteLine("The groups:");
            foreach (var group in groups)
            {
                Console.WriteLine(String.Join(", ", group.Elements));
            }
        }
    }
}

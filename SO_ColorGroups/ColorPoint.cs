namespace ColorGroups
{
    /// <summary>
    /// Represents an element of a color.
    /// </summary>
    public struct ColorPoint
    {
        public int Value { get; }
        public Color Color { get; }

        public ColorPoint(int value, Color color)
        {
            this.Value = value;
            this.Color = color;
        }

        public override string ToString()
        {
            return $"{Color.Name}: {Value}";
        }
    }
}

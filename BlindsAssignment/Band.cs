namespace ResistorEngine
{
    /// <summary>
    /// Base class for bands such as the Significant Figures, Multiplier, and Tolerance.
    /// IsValidColor should be overriden in each derived class, since this tells us whether the specified color is valid for that band.
    /// The BandPosition simply tells us from left to right, the location of the current band from 1 to 4.
    /// </summary>
    public abstract class Band : IBand
    {
        public abstract bool IsValidColor();
        protected ResistorColors Color { get; set; } = ResistorColors.UNDEFINED;
        protected int BandPosition { get; set; }
        public void SetColor(string color)
        {
            Color = ColorMapper.Map(color);
        }

        protected bool IsColorDefined()
        {
            return Color != ResistorColors.UNDEFINED;
        }
    }
}
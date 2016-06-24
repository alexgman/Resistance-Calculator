namespace ResistorEngine
{
    public abstract class Band : IBand
    {
        public abstract bool IsValidColor();

        protected ResistorColors Color { get; set; } = ResistorColors.UNDEFINED;
        protected int BandLocation { get; set; }

        public void SetColor(string color)
        {
            Color = ColorMapper.Map(color);
        }

        protected bool ColorIsDefined()
        {
            return Color != ResistorColors.UNDEFINED;
        }
    }
}
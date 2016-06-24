namespace ResistorEngine
{
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
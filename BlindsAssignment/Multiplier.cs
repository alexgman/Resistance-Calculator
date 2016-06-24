namespace ResistorEngine
{
    internal class Multiplier : Band, IMultiplier
    {
        private const int _bandLocation = 3;

        public int GetValue()
        {
            return ColorBands.Multiplier[Color];
        }

        public Multiplier()
        {
            BandPosition = _bandLocation;
        }

        public override bool IsValidColor()
        {
            if (base.IsColorDefined() && ColorBands.Multiplier.ContainsKey(Color))
            {
                return true;
            }
            return false;
        }
    }
}
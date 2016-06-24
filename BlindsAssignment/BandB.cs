namespace ResistorEngine
{
    /// <summary>
    /// Represents the color of the second figure of component value band.
    /// </summary>
    internal class BandB : Band, IBandB
    {
        private const int _bandLocation = 2;
        public BandB()
        {
            BandPosition = _bandLocation;
        }
        public int GetValue()
        {
            return ColorBands.Sigfig[Color];
        }

        public override bool IsValidColor()
        {
            if (base.IsColorDefined() && ColorBands.Sigfig.ContainsKey(Color))
            {
                return true;
            }

            return false;
        }
    }
}
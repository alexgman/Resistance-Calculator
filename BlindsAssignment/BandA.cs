namespace ResistorEngine
{
    /// <summary>
    /// Represents the color of the first figure of component value band.
    /// </summary>
    internal class BandA : Band, IBandA
    {
        private const int _bandLocation = 1;

        public BandA()
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
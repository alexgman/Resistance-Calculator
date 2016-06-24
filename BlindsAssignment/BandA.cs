namespace ResistorEngine
{
    internal class BandA : Band, IBandA
    {
        private const int _bandLocation = 1;
        public BandA()
        {
            BandLocation = _bandLocation;
        }
        public int GetValue()
        {
            return ColorBands.Sigfig[Color];
        }

        public override bool IsValidColor()
        {
            if (base.ColorIsDefined() && ColorBands.Sigfig.ContainsKey(Color))
            {
                return true;
            }

            return false;
        }
    }
}
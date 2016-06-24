namespace ResistorEngine
{
    internal class BandB : Band, IBandB
    {
        private const int _bandLocation = 2;
        public BandB()
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
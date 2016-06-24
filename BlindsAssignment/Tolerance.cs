namespace ResistorEngine
{
    /// <summary>
    /// This represents the fourth band, which is the tolerance; however, the functionality around it does not yet exist.
    /// </summary>
    internal class Tolerance : Band, ITolerance
    {
        private const int _bandLocation = 4;

        public float GetValue()
        {
            return ColorBands.Tolerance[Color];
        }

        public Tolerance()
        {
            BandPosition = _bandLocation;
        }

        public override bool IsValidColor()
        {
            return base.IsColorDefined() && ColorBands.Tolerance.ContainsKey(Color);
        }
    }
}
﻿namespace ResistorEngine
{
    internal class Tolerance : Band, ITolerance
    {
        private const int _bandLocation = 4;

        public float GetValue()
        {
            return ColorBands.Tolerance[Color];
        }

        public Tolerance()
        {
            BandLocation = _bandLocation;
        }

        public override bool IsValidColor()
        {
            return base.ColorIsDefined() && ColorBands.Tolerance.ContainsKey(Color);
        }
    }
}
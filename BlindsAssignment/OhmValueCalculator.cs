using System;

namespace ResistorEngine
{
    /// <summary>
    /// Calculates the resistance of a specified set of bands.
    /// </summary>
    internal class OhmValueCalculator : IOhmValueCalculator
    {
        private readonly IBandA _bandA;
        private readonly IBandB _bandB;
        private readonly IMultiplier _multiplier;
        private readonly ITolerance _tolerance;

        public OhmValueCalculator(IBandA bandA, IBandB bandB, IMultiplier multiplier, ITolerance tolerance)
        {
            _bandA = bandA;
            _bandB = bandB;
            _multiplier = multiplier;
            _tolerance = tolerance;
        }
        

        public bool AreInputsValid(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            if (string.IsNullOrEmpty(bandAColor))
            {
                return false;
            }

            if (string.IsNullOrEmpty(bandBColor))
            {
                return false;
            }

            if (string.IsNullOrEmpty(bandCColor))
            {
                return false;
            }

            return true;
        }

        private void SetColors(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            _bandA.SetColor(bandAColor);
            _bandB.SetColor(bandBColor);
            _multiplier.SetColor(bandCColor);
            _tolerance.SetColor(bandDColor);
        }

        public int CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            if (!AreInputsValid(bandAColor, bandBColor, bandCColor, bandDColor))
            {
                return 0;
            }

            SetColors(bandAColor, bandBColor, bandCColor, bandDColor);

            if (!_bandA.IsValidColor() || !_bandB.IsValidColor() || !_multiplier.IsValidColor())
            {
                return 0;
            }

            var sigfig1 = _bandA.GetValue();
            var sigfig2 = _bandB.GetValue();
            var multiplier = _multiplier.GetValue();

            var ohms = (sigfig1 * 10 + sigfig2) * Math.Pow (10 , multiplier);

            return Convert.ToInt32(ohms);
        }
    }
}
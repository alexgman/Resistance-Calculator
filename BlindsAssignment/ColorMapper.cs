using System;

namespace ResistorEngine
{
    /// <summary>
    /// Maps a color in the format of a string to an enum value within the ResistorColors enum type.
    /// </summary>
    public static class ColorMapper
    {
        public static ResistorColors Map(string color)
        {
            var colorUpper = color.ToUpper();
            ResistorColors resistorColor;
            if (Enum.TryParse(colorUpper, out resistorColor))
            {
                return resistorColor;
            }
            return ResistorColors.UNDEFINED;
        }
    }

    /// <summary>
    /// The set of all possible colors for all bands.
    /// </summary>
    public enum ResistorColors
    {
        UNDEFINED = 0, BLACK, BROWN, RED, ORANGE, YELLOW, GREEN, BLUE, VIOLET, GRAY, WHITE, GOLD, SILVER
    }
}
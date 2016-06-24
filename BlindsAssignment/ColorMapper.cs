using System;

namespace ResistorEngine
{
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

    public enum ResistorColors
    {
        UNDEFINED = 0, BLACK, BROWN, RED, ORANGE, YELLOW, GREEN, BLUE, VIOLET, GRAY, WHITE, GOLD, SILVER
    }
}
using System.Collections.Generic;

namespace ResistorEngine
{
    public static class ColorBands
    {
        public static Dictionary<ResistorColors, int> Sigfig = new Dictionary<ResistorColors, int>()
        {
            { ResistorColors.BLACK, 0 },
            { ResistorColors.BROWN, 1 },
            { ResistorColors.RED,   2 },
            { ResistorColors.ORANGE,3 },
            { ResistorColors.YELLOW,4 },
            { ResistorColors.GREEN ,5 },
            { ResistorColors.BLUE  ,6 },
            { ResistorColors.VIOLET,7 },
            { ResistorColors.GRAY,  8 },
            { ResistorColors.WHITE ,9 }
        };

        public static Dictionary<ResistorColors, int> Multiplier = new Dictionary<ResistorColors, int>()
        {
            { ResistorColors.BLACK, 0 },
            { ResistorColors.BROWN, 1 },
            { ResistorColors.RED,   2 },
            { ResistorColors.ORANGE,3 },
            { ResistorColors.YELLOW,4 },
            { ResistorColors.GREEN ,5 },
            { ResistorColors.BLUE  ,6 },
            { ResistorColors.VIOLET,7 },
            { ResistorColors.GRAY  ,8 },
            { ResistorColors.WHITE ,9 },
            { ResistorColors.GOLD, -1 },
            { ResistorColors.SILVER,-2 }
        };

        public static Dictionary<ResistorColors, float> Tolerance = new Dictionary<ResistorColors, float>()
        {
            { ResistorColors.BROWN,1 },
            { ResistorColors.RED,2 },
            { ResistorColors.YELLOW,5 },        //(±5%)
            { ResistorColors.GREEN,1F/2 },
            { ResistorColors.BLUE,1F/4 },
            { ResistorColors.VIOLET,1F/10 },
            { ResistorColors.GRAY,5F/100 },        //±0.05% (±10%)
            { ResistorColors.GOLD,5 },
            { ResistorColors.SILVER,10 }
        };
    }
}
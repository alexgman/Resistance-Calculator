using System.ComponentModel;

namespace ResistorUI.Models
{
    public enum BandColor
    {
        Black = 0,
        Brown,
        Red,
        Orange,
        Yellow,
        Green,
        Blue,
        Violet,
        Gray,
        White,
        Gold,
        Silver,
        None
    }

    public class Resistor
    {
        [DisplayName("Band A Color")]
        public BandColor BandAColor { get; set; }

        [DisplayName("Band B Color")]
        public BandColor BandBColor { get; set; }

        [DisplayName("Band C Color")]
        public BandColor BandCColor { get; set; }

        [DisplayName("Band D Color")]
        public BandColor BandDColor { get; set; }

        [DisplayName("Resistor Value in Ohms")]
        public int Value { get; set; }
    }
}
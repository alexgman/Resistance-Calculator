namespace ResistorEngine
{
    internal interface IMultiplier
    {
        int GetValue();
        bool IsValidColor();
        void SetColor(string color);
    }
}
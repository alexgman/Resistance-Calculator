namespace ResistorEngine
{
    internal interface ITolerance
    {
        float GetValue();

        bool IsValidColor();

        void SetColor(string color);
    }
}
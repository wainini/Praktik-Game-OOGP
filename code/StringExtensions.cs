static class StringExtensions
{
    public static string CenterString(this string stringToCenter, int length)
    {
        int leftPad = (length - stringToCenter.Length) / 2 + stringToCenter.Length;

        return stringToCenter.PadLeft(leftPad).PadRight(length);
    }
}
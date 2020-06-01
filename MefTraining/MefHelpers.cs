namespace MefTraining
{
    public static class MefHelpers
    {
        public static string Print(this string message, string name) => $"{name} - {message}";
    }
}
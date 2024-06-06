using System.Text.RegularExpressions;

namespace Match.Core
{
    public static class EnumExtensions
    {
        public static string ToSentenceCase(this Enum condition) => Regex.Replace(condition.ToString(), @"(?<=[a-z])(?=[A-Z])|(?<=\d)(?=\D)|(?<=\D)(?=\d)", " ");
    }
}
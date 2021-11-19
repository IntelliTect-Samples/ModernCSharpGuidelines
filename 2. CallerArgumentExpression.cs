using System.Runtime.CompilerServices;

namespace ModernCSharpGuidelines
{
    public class Guard
    {
        static public string ThrowIfNullEmptyOrWhitespace(
            string value, [CallerArgumentExpression("value")] string? argumentExpression = null!)
        {
            return string.IsNullOrWhiteSpace(value) ? 
                throw new ArgumentException(
                    $"'{argumentExpression}' cannot evaluate to null, empty, or whitespace.", 
                    argumentExpression) : value;
        }

        static public string ThrowIfNull(
            string? value,
            [CallerArgumentExpression("value")] string? argumentExpression = null!) =>
                value ?? throw new ArgumentNullException(argumentExpression);
    }

}

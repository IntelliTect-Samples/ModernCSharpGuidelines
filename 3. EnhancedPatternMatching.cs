namespace ModernCSharpGuidelines;


public class DateFormatter
{
    // GUIDELINE
    // ⛔ AVOID pattern matching when polymorphism is possible instead.
    ///       If you can get custom behavior based on methods in a shared base 
    ///       class or interface implementation, that approach is preferable. 
    ///       Pattern matching should be reserved for situations where polymorphism 
    ///       isn't possible.

    static public bool TryFormatDate(object input, string? format, out string? result)
    {
        // Polymorphism not possible. :(
        result = input switch
        {
            DateTime date => date.ToString(format),
            DateTimeOffset date => date.ToString(format),
            string dateText => DateTime.TryParse(
                dateText, out DateTime dateTime) ?
                    dateTime.ToString(format) : default,
            _ => null,
        };
        // GUIDELINE
        // ❓ CONSIDER using is-null and is-not-null operators when checking for null
        return result is not null;
    }
}

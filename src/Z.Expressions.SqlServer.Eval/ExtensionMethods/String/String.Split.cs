using System;

public static partial class Extensions
{
    public static string[] Split(this string @this, string separator, StringSplitOptions option = StringSplitOptions.None)
    {
        return @this.Split(new[] {separator}, option);
    }

    public static string[] Split(this string @this, params string[] separators)
    {
        return @this.Split(separators, StringSplitOptions.None);
    }
}
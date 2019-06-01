namespace dndCharApi.Extensions
{
    public static class ExtensionMethods
    {
        public static string ToCamelCase(this string str)
        {
            return str.Substring(0, 1).ToLowerInvariant() + str.Substring(1);
        }
    }
}

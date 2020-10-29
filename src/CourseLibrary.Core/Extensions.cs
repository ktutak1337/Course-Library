namespace CourseLibrary.Core
{
    public static class Extensions
    {
        public static bool IsEmpty(this string value) 
            => string.IsNullOrWhiteSpace(value);
    }
}

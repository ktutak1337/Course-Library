namespace CourseLibrary.Core.Types
{
    public static class Role
    {
        public const string User = "user";
        public const string Admin = "admin";

        public static bool IsValid(string role)
        {
            if (role.IsEmpty())
            {
                return false;
            }

            role = role.ToLowerInvariant();

            return role == User || role == Admin;
        }
    }
}

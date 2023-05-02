namespace RestServer.AuthenticateModels
{
    public static class AuthRole
    {
        public const string Admin = "Admin";
        public const string User = "User";
        public enum Ids : int
        {
            Admin = 1,
            User = 2
        }
    }
}

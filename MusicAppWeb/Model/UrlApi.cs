namespace MusicAppWeb.Model 
{
    public static class UrlApi 
    {
        public static class User 
        {
            public const string Authenticate = "/users/login";
            public const string SignUp = "/users";
        }

        public static class Music 
        {
            public const string Upload = "/musics/upload";
            public const string GetAll = "/musics";
        }

    }
}
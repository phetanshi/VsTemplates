namespace $safeprojectname$.Helpers
{
    public static partial class AppConstants
    {
        public static class ErrorMessages
        {
            public const string VIEW_MODEL_IS_NULL = "View model or data cannot be null or empty while saving a page";
        }
        public static class AppConfig
        {
            public const string TOKEN_KEY = "jwt_token";
            public const long MAX_FILE_UPLOAD_SIZE = 1024 * 1024 * 500;
            public const int MAX_ALLOWED_FILES = 3;
        }
    }
}

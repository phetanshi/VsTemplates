﻿namespace BlazorWA.UI.Helpers
{
    public static partial class AppConstants
    {
        public static class ErrorMessages
        {
            public const string ViewModelNullErrorMessage = "data cannot be null or empty while saving a page";
        }
        public static class AppConfig
        {
            public const string TokenKey = "jwt_token";
            public const long MaxFileUploadSize = 1024 * 1024 * 500;
            public const int MaxAllowedFiles = 3;
        }
    }
}

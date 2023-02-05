using System.Text.Json;

namespace PsTest.UI.Helpers
{
    public static class AppExtension
    {
        public static T ToObject<T>(this JsonElement element)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var json = element.GetRawText();
            var dObj = JsonSerializer.Deserialize<T>(json, options);
            return dObj;
        }
    }
}

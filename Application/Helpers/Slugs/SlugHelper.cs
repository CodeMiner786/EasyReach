using System.Text.RegularExpressions;

namespace EasyReach_Application.Helpers.Slugs
{
    public static partial class SlugHelper
    {
        [GeneratedRegex(@"[^a-z0-9\s-]")]
        private static partial Regex InvalidCharsRegex();

        [GeneratedRegex(@"\s+")]
        private static partial Regex MultipleSpacesRegex();

        public static string GenerateSlug(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;

            string slug = text.ToLowerInvariant();

            // স্পেশাল ক্যারেক্টার ফিল্টার
            slug = InvalidCharsRegex().Replace(slug, "");

            // স্পেসকে হাইফেন (-) দিয়ে পরিবর্তন
            slug = MultipleSpacesRegex()
                .Replace(slug, "-")
                .Trim('-');

            return slug;
        }
    }
}
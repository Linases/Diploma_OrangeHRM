using Microsoft.Extensions.Configuration;

namespace TestSettingsConfiguration
{
    public class TestSettings
    {
        private const string TestSettingsJson = "testsettings.json";

        public TestSettings()
        {
            SetDefaultValues();
        }

        private IConfiguration TestConfiguration { get; } = new ConfigurationBuilder().AddJsonFile(TestSettingsJson).Build();

        public static string? AdminUserName { get; set; }
        public static string? AdminUserPassword { get; set; }
        public string? MainUrl { get; set; }

        public void SetDefaultValues()
        {
            MainUrl = TestConfiguration["Settings:Common:MainUrl"];
            AdminUserName = TestConfiguration["Settings:Common:AdminUserName"];
            AdminUserPassword = TestConfiguration["Settings:Common:AdminUserPassword"];
        }
    }
}
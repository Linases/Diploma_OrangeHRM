using TestSettingsConfiguration;

namespace Orange_HRM_Modules
{
    public class User
    {
        public int Id { get; set; }
        public  string? UserName { get; set; }
        public string? Password { get; set; }

        public static User GetAdminUser() =>
            new()
            {
                Id = 1,
                UserName = TestSettings.AdminUserName,
                Password = TestSettings.AdminUserPassword,
            };
    }
}
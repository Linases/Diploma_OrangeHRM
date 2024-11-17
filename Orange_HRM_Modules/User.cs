using Constants;
using Constants.TestSettings;

namespace Orange_HRM_Modules
{
    public class User
    {
        public int Id { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }

        public static User GetAdminUser() =>
            new()
            {
                Id = 1,
                UserName = TestSettings.AdminUserName,
                Password = TestSettings.AdminUserPassword,
            };
    }
}
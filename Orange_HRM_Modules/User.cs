using Constants;

namespace Orange_HRM_Modules
{
    public class User
    {
        public int Id { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }

        public static User Admin
        {
            get

            {
                return new User
                {
                    Id = 1,
                    UserName = ValidCredentials.UserName,
                    Password = ValidCredentials.Password,
                };
            }
        }
    }
}

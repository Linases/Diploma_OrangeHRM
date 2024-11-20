namespace Constants.LeftNavigation
{
    public class LeftNavigationMenuNames
    {
        public const string PIM = "PIM";
        public const string Admin = "Admin";
        public const string Dashboard = "Dashboard";
        public const string Leave = "Leave";
        public const string Time = "Time";
        public const string Recruitment = "Recruitment";
        public const string MyInfo = "My Info";
        public const string Performance = "Performance";
        public const string Directory = "Directory";
        public const string Maintenance = "Maintenance";
        public const string Claim = "Claim";
        public const string Buzz = "Buzz";

        public static List<string> GetAllLeftNavigationMenuNames() => new List<string>
        {
            PIM,
            Admin,
            Dashboard,
            Leave,
            Time,
            Recruitment,
            MyInfo,
            Performance,
            Directory,
            Maintenance,
            Claim,
            Buzz
        };
    }
}
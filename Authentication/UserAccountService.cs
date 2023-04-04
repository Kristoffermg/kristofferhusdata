namespace kristofferhusdata.Authentication
{
    public class UserAccountService
    {
        // should be replaced with a database fetch
        private List<UserAccount> _users;

        public UserAccountService()
        {
            _users = new List<UserAccount>
            {
                new UserAccount{ UserName = "admin", Password = "admin", Role="DiscordModerator"},
                new UserAccount{ UserName = "guest", Password = "123", Role="DiscordModerator"}
            };
        }

        public UserAccount? GetByUsername(string userName)
        {
            return _users.FirstOrDefault(x => x.UserName == userName);
        }
    }
}

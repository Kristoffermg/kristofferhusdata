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
                new UserAccount{ UserName = "kris", Password = "1212", Role="AdminUser"},
                new UserAccount{ UserName = "guest", Password = "123", Role="GuestUser"}
            };
        }

        public UserAccount? GetByUsername(string userName)
        {
            return _users.FirstOrDefault(x => x.UserName == userName);
        }
    }
}

namespace iQuest.VendingMachine.Interfaces
{
    internal interface IAuthenticationService
    {
        public bool IsUserLoggedIn { get; }
        public void Login(string password);
        public void Logout();
    }
}

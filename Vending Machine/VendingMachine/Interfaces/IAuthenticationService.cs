namespace iQuest.VendingMachine.Interfaces
{
    internal interface IAuthenticationService
    {
        public bool UserIsLoggedIn { get; }
        public void Login(string password);
        public void Logout();
    }
}

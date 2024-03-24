namespace VendingMachine_Business.Interfaces
{
    internal interface IAuthenticationService
    {
        public bool IsUserLoggedIn { get; }
        public void Login(string password);
        public void Logout();
    }
}

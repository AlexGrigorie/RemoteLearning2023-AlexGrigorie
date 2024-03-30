namespace VendingMachine_Business.Interfaces
{
    internal class AuthenticationService : IAuthenticationService
    {
        public bool IsUserLoggedIn { get; private set; }

        public void Login(string password)
        {
            if (password == "supercalifragilisticexpialidocious")
                IsUserLoggedIn = true;
            else
                throw new InvalidPasswordException();

        }

        public void Logout()
        {
            IsUserLoggedIn = false;
        }
    }
}

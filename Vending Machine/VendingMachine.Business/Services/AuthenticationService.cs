using VendingMachine.Business.Exceptions;
using VendingMachine.Business.Interfaces;

namespace VendingMachine.Business.Services
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

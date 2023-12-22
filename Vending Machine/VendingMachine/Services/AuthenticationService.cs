using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.Interfaces;

namespace iQuest.VendingMachine.Authentication
{
    internal class AuthenticationService : IAuthenticationService
    {
        public bool UserIsLoggedIn { get; private set; }

        public void Login(string password)
        {
            if (password == "supercalifragilisticexpialidocious")
                UserIsLoggedIn = true;
            else
                throw new InvalidPasswordException();

        }

        public void Logout()
        {
            UserIsLoggedIn = false;
        }
    }
}

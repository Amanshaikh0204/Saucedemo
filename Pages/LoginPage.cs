using Microsoft.Playwright;
using System.Threading.Tasks;

namespace Saucedemoproject.Pages
{
    public class LoginPage
    {
        private IPage _page;
        private readonly ILocator _usernameInput;
        private readonly ILocator _passwordInput;
        private readonly ILocator _loginButton;

        public LoginPage(IPage page)
        {
            _page = page;
            _usernameInput = _page.Locator("#user-name");
            _passwordInput = _page.Locator("#password");
            _loginButton = _page.Locator("#login-button");
        }


        public async Task LoginInput(string url, string username, string password)
        {
            await _page.GotoAsync(url);
            await _usernameInput.FillAsync(username);
            await _passwordInput.FillAsync(password);

        }

        public async Task ClickLogin()
        {
            await _loginButton.ClickAsync();
        }
    }
}

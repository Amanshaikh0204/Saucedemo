using Microsoft.Playwright;
using System.Threading.Tasks;

namespace Saucedemoproject.Pages
{
    public class CheckoutPage
    {
        private IPage _page;
        private readonly ILocator first_nameInput;
        private readonly ILocator last_nameInput;
        private readonly ILocator zip_code;

        private readonly ILocator _continueBtn;

        public CheckoutPage(IPage page)
        {
            _page = page;
            first_nameInput = _page.Locator("#first-name");
            last_nameInput = _page.Locator("#last-name");
            zip_code = _page.Locator("#postal-code");
            _continueBtn = _page.Locator("#continue");
        }


        public async Task Details(string fname, string lname, string postcode)
        {
            await first_nameInput.FillAsync(fname);
            await last_nameInput.FillAsync(lname);
            await zip_code.FillAsync(postcode);
        }


        public async Task Continue()
        {
            await _continueBtn.ClickAsync();
        }
    }
}

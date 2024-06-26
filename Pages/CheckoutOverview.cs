using Microsoft.Playwright;
using System.Threading.Tasks;

namespace Saucedemoproject.Pages
{
    public class CheckoutOverview
    {

        public readonly IPage _page;
        public readonly ILocator finishBtn;

        public readonly ILocator successMsg;

        public CheckoutOverview(IPage page)
        {

            _page = page;
            finishBtn = _page.Locator("#finish");
            successMsg = _page.Locator("xpath=//h2[normalize-space()='Thank you for your order!']");
        }
        public async Task clickFinish()
        {
            await finishBtn.ClickAsync();
        }
        public async Task<string> GetSuccessMsg()
        {
            return await successMsg.InnerTextAsync();
        }
    }
}
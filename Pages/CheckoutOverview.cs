using Microsoft.Playwright;
using System.Threading.Tasks;

namespace Saucedemoproject.Pages
{
    public class CheckoutOverview
    {

        public readonly IPage _page;
        public readonly ILocator finishBtn;

        public readonly ILocator item_name;

        public readonly ILocator successMsg;

        public CheckoutOverview(IPage page)
        {

            _page = page;
            finishBtn = _page.Locator("#finish");
            item_name = _page.Locator("xpath=//div[normalize-space()='Sauce Labs Bike Light']");
            successMsg = _page.Locator("xpath=//h2[normalize-space()='Thank you for your order!']");
        }
        public async Task clickFinish()
        {
            await finishBtn.ClickAsync();
        }

        public async Task<string> GetItemName()
        {
            return await item_name.InnerTextAsync();
        }
        public async Task<string> GetSuccessMsg()
        {
            return await successMsg.InnerTextAsync();
        }
    }
}
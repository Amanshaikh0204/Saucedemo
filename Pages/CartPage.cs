using Microsoft.Playwright;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Saucedemoproject.Pages
{
    public class CartPage
    {

        private readonly IPage _page;
        private readonly ILocator productTitle;

        private readonly ILocator checkoutBtn;


        public CartPage(IPage page)
        {
            _page = page;
            productTitle = _page.Locator("xpath=//div[@class='inventory_item_name']");
            checkoutBtn = _page.Locator("#checkout");
        }

        public async Task<string> GetProductName()
        {
            return await productTitle.InnerTextAsync();


        }

        public async Task NavigateToCheckout()
        {
            await checkoutBtn.ClickAsync();
        }
    }


}
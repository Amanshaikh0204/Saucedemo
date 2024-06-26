using Microsoft.Playwright;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Saucedemoproject.Pages
{
    public class ProductsPage
    {
        private readonly IPage _page;
        private readonly ILocator AddToCartButton1;
        private readonly ILocator AddToCartButton2;
        private readonly ILocator CartCount;

        private readonly ILocator CartIcon;

        private readonly ILocator RemoveButton;

        public ProductsPage(IPage page)
        {
            _page = page;
            AddToCartButton1 = _page.Locator("#add-to-cart-sauce-labs-backpack");
            AddToCartButton2 = _page.Locator("#add-to-cart-sauce-labs-bike-light");
            CartCount = _page.Locator(".shopping_cart_badge");
            CartIcon = _page.Locator("xpath=//a[@class='shopping_cart_link']");
            RemoveButton = _page.Locator("#remove-sauce-labs-backpack");
        }

        public async Task AddFirstTwoItemsToCart()
        {
            await AddToCartButton1.ClickAsync();
            await AddToCartButton2.ClickAsync();
        }

        public async Task<int> GetCartItemCount()
        {
            var count = await CartCount.InnerTextAsync();
            return int.Parse(count);
        }

        public async Task RemoveFirstItemFromCart()
        {
            await RemoveButton.ClickAsync();
        }

        public async Task<int> GetCartItemCount1()
        {
            var count1 = await CartCount.InnerTextAsync();
            return int.Parse(count1);
        }

        public async Task NavigateToCart()
        {
            await CartIcon.ClickAsync();
        }
    }
}

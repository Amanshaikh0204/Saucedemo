using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using Saucedemoproject.Pages;
using System.Threading.Tasks;



namespace Saucedemoproject;

[TestFixture]
public class TestExecution : PageTest
{


    [Test]
    public async Task Execution()
    {
        LoginPage loginPage = new LoginPage(Page);
        ProductsPage productsPage = new ProductsPage(Page);
        CartPage cartPage = new CartPage(Page);
        CheckoutPage checkoutPage = new CheckoutPage(Page);
        CheckoutOverview checkoutOverview = new CheckoutOverview(Page);

        await loginPage.LoginInput("https://www.saucedemo.com/", "standard_user", "secret_sauce");
        await loginPage.ClickLogin();

        await productsPage.AddFirstTwoItemsToCart();
        int exp_value = 2;
        int act_value = await productsPage.GetCartItemCount();
        Assert.That(act_value, Is.EqualTo(exp_value));

        await productsPage.RemoveFirstItemFromCart();

        int expCart_aft_rem = 1;
        int actCart_aft_rem = await productsPage.GetCartItemCount1();
        Assert.That(actCart_aft_rem, Is.EqualTo(expCart_aft_rem));

        await productsPage.NavigateToCart();

        string exp_name = "Sauce Labs Bike Light";

        string act_name = await cartPage.GetProductName();
        Assert.That(act_name, Is.EqualTo(exp_name));

        await cartPage.NavigateToCheckout();
        await checkoutPage.Details("Vivek", "Rai", "abc123");

        await checkoutPage.Continue();
        string actual_name = await checkoutOverview.GetItemName();
        Assert.That(actual_name, Is.EqualTo(exp_name));

        await checkoutOverview.clickFinish();

        string exp_succ_msg = "Thank you for your order!";

        string act_succ_msg = await checkoutOverview.GetSuccessMsg();
        Assert.That(act_succ_msg, Is.EqualTo(exp_succ_msg));




    }
}
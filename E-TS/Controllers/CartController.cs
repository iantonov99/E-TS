using E_TS.Contracts;
using E_TS.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using E_TS.Extensions;
using E_TS.ViewModels.Cart;

namespace E_TS.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService cartService;
        private readonly UserManager<ApplicationUser> userManager;

        public CartController(ICartService cartService, UserManager<ApplicationUser> userManager)
        {
            this.cartService = cartService;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            //var user = await userManager.FindByNameAsync(User.Identity.Name);
            var cartItems = cartService.GetCartViewModels("");

            return View(cartItems);
        }

        public IActionResult Remove(int Id, int Table)
        {
            bool result = cartService.Remove(Id, Table);

            this.ShowNotificationOnUI(result);

            return RedirectToAction("Index", "Cart");
        }

        public IActionResult Buy()
        {
            //var user = await userManager.FindByNameAsync(User.Identity.Name);
            var model = new PaymentViewModel();

            return View(model);
        }

        [HttpPost]
        public IActionResult Buy(PaymentViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            return RedirectToAction("Index", "Cart");
        }
    }
}

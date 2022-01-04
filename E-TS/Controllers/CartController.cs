using E_TS.Contracts;
using E_TS.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using E_TS.Extensions;
using E_TS.ViewModels.Cart;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Index()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var cartItems = cartService.GetCartViewModels(user.Id);

            return View(cartItems);
        }

        public IActionResult Remove(int Id, int Table)
        {
            bool result = cartService.Remove(Id, Table);

            this.ShowNotificationOnUI(result);

            return RedirectToAction("Index", "Cart");
        }

        public IActionResult BuyAll()
        {
            var model = new PaymentViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> BuyAll(PaymentViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await userManager.FindByNameAsync(User.Identity.Name);

            bool result = cartService.BuyAll(user.Id);
            this.ShowNotificationOnUI(result);

            return RedirectToAction("Index", "Cart");
        }

        public IActionResult Buy(int Id, int Table)
        {
            var model = new PaymentViewModel()
            {
                IdOfProduct = Id,
                Table = Table
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Buy(PaymentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await userManager.FindByNameAsync(User.Identity.Name);

            bool result = cartService.Buy(model.IdOfProduct, model.Table, user.Id);
            this.ShowNotificationOnUI(result);

            return RedirectToAction("Index", "Cart");
        }
    }
}

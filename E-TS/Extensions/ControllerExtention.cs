using E_TS.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace E_TS.Extensions
{
    public static class ControllerExtention
    {
        public static void ShowNotificationOnUI<T>(this T controller, bool result ) where T : Controller
        {
            if (result)
            {
                controller.TempData[Constants.Constants.SuccessMessage] = Constants.Constants.Values.SaveOk;
            }
            else
            {
                controller.TempData[Constants.Constants.ErrorMessage] = Constants.Constants.Values.SavedFailed;
            }
        }
    }
}

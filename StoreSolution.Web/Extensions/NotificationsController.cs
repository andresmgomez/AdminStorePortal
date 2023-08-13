using Microsoft.AspNetCore.Mvc;

namespace StoreSolution.Web.Extensions
{
    public enum NotificationType
    {
        Success,
        Error,
        Info
    }

    public class NotificationsController : Controller
    {
        public void CustomNotification(string message, NotificationType type, string position, string title, string iconType = "error", bool toast = false)
        {
            TempData["notification"] = "Swal.fire({" +
                "position:'" + position + "'," +
                "type:'" + type.ToString().ToLower() + "'," +
                "title:'" + title + "'," +
                "text: '" + message + "'," +
                "icon: '" + iconType + "'," +
                "showCancelButton: '" + true + "'," +
                "cancelButtonColor: '" + "#3ea42d" + "'," +
                "showConfirmButton: '" + true + "'," +
                "confirmButtonColor: '" + "#e04e33" + "'," +
                "confirmButtonText: '" + "Yes" + "'," +
                "toast: " + toast.ToString().ToLower() + "," +
                "timer: " + 5000 + "}); ";
        }
    }
}
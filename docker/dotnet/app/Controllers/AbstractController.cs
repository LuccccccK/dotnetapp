using Microsoft.AspNetCore.Mvc;
using NLog;

namespace app.Controllers {
    public class AbstractController : Controller {
        protected static Logger _logger = LogManager.GetCurrentClassLogger ();
    }
}
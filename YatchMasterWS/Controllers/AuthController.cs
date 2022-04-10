using Microsoft.AspNetCore.Mvc;
using YatchMasterWS.BLL;
using YatchMasterWS.Models.Request;
using YatchMasterWS.Utils.Helper;

namespace YatchMasterWS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthBLL bLL = new();

        [HttpPost("UploadImage")]
        public IActionResult UploadImage(IFormFile file)
        {
            var data = bLL.UploadImage(file);
            return ResponseHelper.GetAsyncResult(this, data);
        }

        [HttpPost("SendEmail")]
        public IActionResult SendEmail(MailRequest request)
        {
            var data = bLL.SendEmail(request);
            return ResponseHelper.GetAsyncResult(this, data);
        }
    }
}

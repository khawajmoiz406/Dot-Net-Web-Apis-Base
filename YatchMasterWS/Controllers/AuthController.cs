using Microsoft.AspNetCore.Mvc;
using YatchMasterWS.BLL;
using YatchMasterWS.Utils;

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
    }
}

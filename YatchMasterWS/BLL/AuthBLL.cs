using YatchMasterWS.Models.Response;
using YatchMasterWS.Utils;

namespace YatchMasterWS.BLL
{
    public class AuthBLL
    {

        public BaseResponse UploadImage(IFormFile file)
        {
            return UploadHelper.SaveMedia(file);
        }
    }
}

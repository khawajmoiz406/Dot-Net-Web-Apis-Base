using YatchMasterWS.DAL;
using YatchMasterWS.Models.Response;
using YatchMasterWS.Utils;

namespace YatchMasterWS.BLL
{
    public class AuthBLL
    {

        private readonly AuthDAL dal = new();

        public BaseResponse UploadImage(IFormFile file)
        {
            return UploadHelper.SaveMedia(file);
        }
    }
}

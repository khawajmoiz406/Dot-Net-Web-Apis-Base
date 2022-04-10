using YatchMasterWS.DAL;
using YatchMasterWS.Models.Request;
using YatchMasterWS.Models.Response;
using YatchMasterWS.Utils;
using YatchMasterWS.Utils.Helper;

namespace YatchMasterWS.BLL
{
    public class AuthBLL
    {

        private readonly AuthDAL dal = new();

        public BaseResponse UploadImage(IFormFile file)
        {
            try
            {
                return UploadHelper.SaveMedia(file);
            }
            catch (Exception e)
            {
                return ResponseHelper.GetErrorModel(Constants.SERVER_ERROR, "SERVER ERROR: " + e.Message);
            }
        }

        public BaseResponse SendEmail(MailRequest request)
        {
            try
            {
                var result = AsyncHelper.RunSync(() => MailHelper.SendEmailAsync(request));
                if (result == true)
                    return ResponseHelper.GetOkModel(request, "Email Sent Successfully");
                else return ResponseHelper.GetErrorModel(Constants.SERVER_ERROR, "Cannot sent email");
            }
            catch (Exception e)
            {
                return ResponseHelper.GetErrorModel(Constants.SERVER_ERROR, "SERVER ERROR: " + e.Message);
            }
        }
    }
}

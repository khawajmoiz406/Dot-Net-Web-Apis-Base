using YatchMasterWS.Models.Helper;
using YatchMasterWS.Models.Response;

namespace YatchMasterWS.Utils
{
    public class UploadHelper
    {
        public static BaseResponse SaveMedia(IFormFile file)
        {
            BaseResponse model = new();
            var mFile = new Media();

            try
            {

                string base_location = ConfigHelper.GetAppSettings("BaseStoragePath") + "\\";
                string base_url = ConfigHelper.GetAppSettings("BaseUrlUploads");
                string filePath = base_location + "\\" + file.FileName;

                mFile.Media_path = filePath;
                mFile.Media_url = base_url + '/' + file.FileName;
                mFile.Media_name = file.FileName;

                bool exists = Directory.Exists(@base_location);
                if (!exists) Directory.CreateDirectory(@base_location);

                var result = AsyncHelper.RunSync<dynamic>(() => SaveMediaAsync(filePath, file));

                model.Status = true;
                model.Data = mFile;
                model.Message = "Media saved successfully";
                model.Response_code = Constants.OK;
            }
            catch (Exception ex)
            {
                model = ResponseHelper.GetErrorModel(Constants.SERVER_ERROR, "SERVER ERROR: " + ex.Message.ToString());
            }

            return model;
        }

        private static async Task<dynamic> SaveMediaAsync(string filePath, IFormFile file)
        {
            using (Stream fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return true;
        }
    }
}

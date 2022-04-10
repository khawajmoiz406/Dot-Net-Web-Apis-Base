using Microsoft.AspNetCore.Mvc;
using YatchMasterWS.Models.Response;

namespace YatchMasterWS.Utils.Helper
{
    public class ResponseHelper
    {
        public static ObjectResult GetAsyncResult(ControllerBase controller, BaseResponse data)
        {
            if (data.Response_code == Constants.OK)
            {
                return controller.Ok(data);
            }
            else if (data.Response_code == Constants.FIELDS_REQUIRED || data.Response_code == Constants.BAD_REQUEST)
            {
                return controller.BadRequest(data);
            }
            else if (data.Response_code == Constants.NOT_FOUND)
            {
                return controller.NotFound(data);
            }
            else
            {
                return controller.StatusCode(data.Response_code, data);
            }
        }

        public static BaseResponse GetOkModel(object data, string message)
        {
            return new BaseResponse()
            {
                Data = data,
                Response_code = Constants.OK,
                Message = message,
                Status = true
            };
        }

        public static BaseResponse GetErrorModel(int code, string message)
        {
            return new BaseResponse()
            {
                Data = null,
                Response_code = code,
                Message = message,
                Status = false
            };
        }
    }
}

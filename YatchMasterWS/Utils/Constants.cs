using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YatchMasterWS.Utils
{
    public static class Constants
    {

        #region Response Codes

        public static int FIELDS_REQUIRED = 6;
        public static int NOT_FOUND = 404;
        public static int OK = 200;
        public static int SERVER_ERROR = 500;
        public static int SESSION_EXPIRED = 440;
        public static int BAD_REQUEST = 400;
        public static int UNAUTHORIZED = 401;


        #endregion

        #region Setting Type

        #endregion

        #region Default Values

        public const string DEFAULT_PAGE_SIZE = "10";

        #endregion
    }
}

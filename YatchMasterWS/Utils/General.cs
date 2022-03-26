
using System.Globalization;

namespace YatchMasterWS.Utils
{

    public class GeneralCls
    {

        public static long TimeStampToMilliseconds(string timeStamp, string pattern = null)
        {
            if (pattern == null)
            {
                DateTime dt = DateTime.Parse(timeStamp);
                var utcDateTime = new DateTimeOffset(dt).UtcDateTime;
                return new DateTimeOffset(utcDateTime).ToUnixTimeMilliseconds();
            }
            else
                return new DateTimeOffset(DateTime.ParseExact(timeStamp, pattern, CultureInfo.InvariantCulture))
                    .ToUnixTimeMilliseconds();
        }

        public static int GetInt(string TextVal, int ErrVal)
        {
            if (TextVal.Trim() == "")
                return ErrVal;
            else
            {
                try
                {
                    return int.Parse(TextVal);
                }
                catch
                {
                    return ErrVal;
                }
            }
        }

        public static int GetInt(string TextVal, char seperatedBy = '-')
        {
            if (TextVal.Trim() == "")
                return -1;

            int retVal = -1;
            if (!int.TryParse(TextVal, out retVal))
            {
                retVal = ReturnIDFromString(TextVal, seperatedBy);
            }
            return retVal;
        }

        public static int GetInt(object val, char seperatedBy = '-')
        {
            if (val == null || string.IsNullOrEmpty(val.ToString()))
                return -1;
            else
            {
                try
                {
                    return int.Parse(val.ToString());
                }
                catch
                {
                    return ReturnIDFromString(val.ToString(), seperatedBy);
                }
            }
        }

        public static long GetLong(string TextVal)
        {
            if (TextVal.Trim() == "")
                return -1;
            else
            {
                try
                {
                    return long.Parse(TextVal);
                }
                catch
                {
                    return -1;
                }
            }
        }

        public static double GetDouble(string TextVal)
        {

            if (TextVal.Trim() == "")
                return 0;
            else
            {
                try
                {
                    return double.Parse(TextVal);
                }
                catch
                {
                    return 0;
                }
            }
        }

        public static float GetFloat(string TextVal)
        {

            if (TextVal.Trim() == "")
                return 0;
            else
            {
                try
                {
                    return float.Parse(TextVal);
                }
                catch
                {
                    return 0;
                }
            }
        }

        public static decimal GetDecimal(string TextVal)
        {

            if (TextVal.Trim() == "")
                return 0.0M;
            else
            {
                try
                {
                    return Convert.ToDecimal(TextVal);
                }
                catch
                {
                    return 0.0M;
                }
            }
        }

        public static bool GetBool(string TextVal)
        {
            bool retVal = false;
            if (TextVal != null && (TextVal.Trim().ToLower() == "true" || TextVal.Trim().ToLower() == "1"))
            {
                retVal = true;
            }
            return retVal;
        }

        public static bool GetBool(object val)
        {
            if (val == null) return false;
            else return GetBool(val.ToString());
        }

        public static bool IsNumeric(string str)
        {
            return int.TryParse(str, out int i);
        }

        public static int ReturnIDFromString(string value, char separater)
        {
            try
            {
                if (value != string.Empty && value.Contains(separater.ToString()))
                {
                    return Convert.ToInt32(value.Split(separater)[1]);
                }
                else
                {
                    return -1;
                }
            }
            catch
            {
                return -1;
            }
        }

    }
}

using Microsoft.AspNetCore.Authentication;
using System;
using System.Security.Cryptography;

namespace YatchMasterWS.Utils
{
    public class Helper
    {
        public static bool TryGetBasicCredentials(string authorization, out string clientId, out string clientSecret)
        {
            clientId = string.Empty;
            clientSecret = string.Empty;

            try
            {
                if (!authorization.Contains("BASIC")) return false;

                var clientCredentials = authorization.Replace("BASIC", "").Trim();
                byte[] byteValue = Convert.FromBase64String(clientCredentials);
                var strValue = System.Text.Encoding.Default.GetString(byteValue);
                string[] parsed = strValue.Split(":");

                if (parsed.Length != 2) return false;

                clientId = parsed[0];
                clientSecret = parsed[1];
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public static string GetHash(string input)
        {
            try
            {
                HashAlgorithm hashAlgorithm = new SHA256CryptoServiceProvider();
                byte[] byteValue = System.Text.Encoding.UTF8.GetBytes(input);
                byte[] byteHash = hashAlgorithm.ComputeHash(byteValue);
                return Convert.ToBase64String(byteHash);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static string Serialize(AuthenticationTicket ticket)
        {
            try
            {
                var ticketSerializer = new TicketSerializer();
                var ticketBytes = ticketSerializer.Serialize(ticket);
                return Convert.ToBase64String(ticketBytes);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static AuthenticationTicket DeSerialize(string ticket)
        {
            try
            {
                var ticketSerializer = new TicketSerializer();
                var ticketBytes = Convert.FromBase64String(ticket);
                return ticketSerializer.Deserialize(ticketBytes);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static int? GetPageNo(bool next, int count, string pageNo, string pageSize)
        {
            var requestedPageNo = int.Parse(pageNo ?? "1");
            int? returnPageNo;
            var remainingItems = count - ((requestedPageNo) * int.Parse(pageSize)); 
            if(next)
            {
                if (remainingItems > 0) returnPageNo = requestedPageNo + 1;
                else returnPageNo = null;
            }
            else
            {
                if (int.Parse(pageNo) > 1) returnPageNo = requestedPageNo - 1;
                else returnPageNo = null;
            }
            return returnPageNo;
        }
    }
}

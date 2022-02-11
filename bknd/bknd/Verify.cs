using System.Text.RegularExpressions;

namespace bknd
{
    public class Verify
    {
        public static bool Email(string email)
        {
            string EmailPattern=@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
            var regex = new Regex(EmailPattern);
            if (!regex.IsMatch(email))
                return false;
            return true;
        }
    }
}
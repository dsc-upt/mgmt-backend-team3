using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

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

        public static List<String> GetRolesList(string roles)
        {
            var rolesArr = roles.Split(",");
            return new List<string>(rolesArr);
            
        }

        public static string GetRolesString(List<String> rolesList)
        {
            var roleArr=rolesList.ToArray();
            return String.Join(",",roleArr);
        }

        public static string Roles(string roles)
        {
            roles = roles.Replace(" ", ",");
            if (roles.EndsWith(","))
                roles = roles.Remove(roles.LastIndexOf(","));
            return roles;
        }
    }
}
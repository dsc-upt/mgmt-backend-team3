using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using bknd.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace bknd
{
    public class Verify
    {
        private static DataContext _datacontext;

        public Verify(DataContext dataContext)
        {
            _datacontext = dataContext;
        }

        public static async Task<User> Exists(string id)
        {
            var usr = await _datacontext.users.FirstOrDefaultAsync(x => x.Id == id.ToString());
            if (usr is null) return null;
            return usr;
        }
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
            if (roles.Equals(string.Empty) || !roles.Contains(",")) return roles;
            roles = roles.Replace(" ", ",");
            if (roles.EndsWith(","))
                roles = roles.Remove(roles.LastIndexOf(","));
            if (roles.StartsWith(","))
                roles = roles.Remove(roles.IndexOf(","),1);
            return roles;
        }
    }
}
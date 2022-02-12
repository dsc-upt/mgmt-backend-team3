using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace bknd.Users
{
    
    public class UserAddView
    {
        public string Firstname { get; set; }
       
        public string Lastname { get; set; }
        
        public string Email { get; set; }
        
        
        public string Roles { get; set; }
    }
}
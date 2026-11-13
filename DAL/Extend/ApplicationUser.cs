using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Extend
{
    public class ApplicationUser: IdentityUser
    {
      
            public string FullName { get; set; }

            public string Address { get; set; }

            public bool IsAgree { get; set; }

            public ICollection<Order> Orders { get; set; }= new List<Order>();
        
    }
}

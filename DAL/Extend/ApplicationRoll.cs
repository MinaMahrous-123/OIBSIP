using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Extend
{
    public class ApplicationRoll:IdentityRole
    {
        public ApplicationRoll()
        {
            IsActive = true;
        }
        public bool IsActive { get; set; }
    }
}

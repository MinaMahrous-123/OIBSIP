using DAL.Extend;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataBaseContext
{
    public class BDBContext:IdentityDbContext<ApplicationUser, ApplicationRoll, string>
    {
        public BDBContext(DbContextOptions<BDBContext> options):base(options)
        {
        }
    }
}

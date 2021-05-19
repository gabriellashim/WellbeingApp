using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Design;

namespace Quokka_App.Model
{
    public class ConnectionsString : DbContext
    {
        public ConnectionsString(DbContextOptions<ConnectionsString>options):base(options)
        {

        }
        public DbSet<UserClass> AspNetUsers { get; set; }
    }
}

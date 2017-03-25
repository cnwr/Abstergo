using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Abstergo.Dal
{
    public class AbstergoContext : DbContext
    {
        public AbstergoContext() : base("AbstergoConnection")
        {

        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<StringModel> Strings { get; set; }
    }
}

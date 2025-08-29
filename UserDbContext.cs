using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace UserManagementAPI.data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

    }
}

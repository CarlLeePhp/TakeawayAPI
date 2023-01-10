using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TakeawayAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext() : base() { }
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
    }
}

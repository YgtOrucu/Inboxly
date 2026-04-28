using Inboxly.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Inboxly.Context
{
    public class InboxlyContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public InboxlyContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }
     
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageStatus> MessageStatuses  { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using RapidMeet.Domain.Entities;
using System.Collections.Generic;

namespace RapidMeet.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Meeting> Meetings => Set<Meeting>();
        public DbSet<Participant> Participants => Set<Participant>();
        public DbSet<Message> Messages => Set<Message>();
        public DbSet<UserRole> UserRoles => Set<UserRole>();
        public DbSet<Permission> Permissions => Set<Permission>();
        public DbSet<AuditLog> AuditLogs => Set<AuditLog>();
    }
}

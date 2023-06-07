using Microsoft.EntityFrameworkCore;
using MoneyTransferAPI.Database.Entities;
using System.Text.RegularExpressions;

namespace MoneyTransferAPI.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<MoneyTransfer> MoneyTransfers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Account>()
                        .HasOne(m => m.Owner)
                        .WithMany(m => m.OwnedAccounts)
                        .HasForeignKey(mbox => mbox.OwnerId);

            modelBuilder.Entity<MoneyTransfer>()
                        .HasOne(m => m.Sender)
                        .WithMany(t => t.SentMoneyTransfers)
                        .HasForeignKey(m => m.SenderId)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MoneyTransfer>()
                        .HasOne(m => m.Receiver)
                        .WithMany(t => t.ReceivedMoneyTransfers)
                        .HasForeignKey(m => m.ReceiverId)
                        .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using mssqlProject.Models;
using mssqlProject.Models.DTO;

namespace mssqlProject.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Participant> Participants { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Promoter> Promoters { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Group> Groups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Trip
            modelBuilder.Entity<Trip>()
                .HasKey(p => p.Id);
            modelBuilder.Entity<Trip>()
                .Property(p => p.Title)
                .HasDefaultValue("")
                .IsRequired();
            modelBuilder.Entity<Trip>()
                .Property(p => p.Description)
                .HasDefaultValue("")
                .IsRequired();
            modelBuilder.Entity<Trip>()
                .Property(p => p.Date)
                .HasDefaultValue("")
                .IsRequired();

            //relacje modelu Trip:
            modelBuilder.Entity<Trip>() //one trips to one budget
                .HasOne(e => e.Budget)
                .WithOne()
                .HasForeignKey<Budget>(e => e.TripId)
                .IsRequired();
            modelBuilder.Entity<Trip>() //one trips to one hotel
                .HasOne(e => e.Hotel)
                .WithOne()
                .HasForeignKey<Hotel>(e => e.TripId)
                .IsRequired();
            modelBuilder.Entity<Trip>() //one pormoter to many trips
                .HasOne<Promoter>()
                .WithMany(e => e.Trips)
                .HasForeignKey(e => e.PromoterId)
                .IsRequired();
            modelBuilder.Entity<Trip>() //one trips to many place
                .HasMany(e => e.Places)
                .WithOne()
                .HasForeignKey(e => e.TripId)
                .IsRequired();
            //modelBuilder.Entity<Trip>() //one trips to many participant
            //    .HasMany(e => e.Participants)
            //    .WithOne()
            //    .HasForeignKey(e => e.TripId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .IsRequired();
            modelBuilder.Entity<Trip>() //one trips to many group
                .HasMany(e => e.Groups)
                .WithOne()
                .HasForeignKey(e => e.TripId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .IsRequired();
            #endregion


            #region Promoter
            modelBuilder.Entity<Promoter>()
                .HasKey(p => p.Id);
            modelBuilder.Entity<Promoter>()
                .Property(p => p.Name)
                .HasDefaultValue("")
                .IsRequired();
            modelBuilder.Entity<Promoter>()
                .Property(p => p.Surname)
                .HasDefaultValue("")
                .IsRequired();
            modelBuilder.Entity<Promoter>()
                .Property(p => p.PhoneNumber)
                .HasDefaultValue("")
                .IsRequired();
            modelBuilder.Entity<Promoter>()
                .Property(p => p.Email)
                .HasDefaultValue("")
                .IsRequired();
            #endregion


            #region Budget
            modelBuilder.Entity<Budget>()
                .HasKey(p => p.Id);
            modelBuilder.Entity<Budget>()
                .Property(p => p.ShareHoldersCount)
                .IsRequired();
            modelBuilder.Entity<Budget>()
                .Property(p => p.BankAccunt)
                .IsRequired();
            modelBuilder.Entity<Budget>()
                .Property(p => p.BudgetSize)
                .IsRequired();
            #endregion


            #region Hotel
            modelBuilder.Entity<Hotel>()
                .HasKey(p => p.Id);
            modelBuilder.Entity<Hotel>()
                .Property(p => p.Location)
                .IsRequired();
            modelBuilder.Entity<Hotel>()
                .Property(p => p.Price)
                .IsRequired();
            modelBuilder.Entity<Hotel>()
                .Property(p => p.Designation)
                .IsRequired();
            #endregion


            #region Place
            modelBuilder.Entity<Place>()
                .HasKey(p => p.Id);
            modelBuilder.Entity<Place>()
                .Property(p => p.Location)
                .IsRequired();
            modelBuilder.Entity<Place>()
                .Property(p => p.Description)
                .IsRequired();
            modelBuilder.Entity<Place>()
                .Property(p => p.Name)
                .IsRequired();
            modelBuilder.Entity<Place>() //one place to many comments
                .HasMany(e => e.Comments)
                .WithOne()
                .HasForeignKey(e => e.PlaceId)
                .IsRequired();
            #endregion


            #region Comment
            modelBuilder.Entity<Comment>()
                .HasKey(p => p.Id);
            modelBuilder.Entity<Comment>()
                .Property(p => p.Content)
                .IsRequired();
            modelBuilder.Entity<Comment>()
                .Property(p => p.Author)
                .IsRequired();
            #endregion


            #region Participant
            modelBuilder.Entity<Participant>()
                .HasKey(p => p.Id);
            modelBuilder.Entity<Participant>()
                .Property(p => p.PasswordHash)
                .IsRequired();
            modelBuilder.Entity<Participant>()
                .Property(p => p.PhoneNumber)
                .IsRequired();
            modelBuilder.Entity<Participant>()
                .Property(p => p.Email)
                .IsRequired();
            modelBuilder.Entity<Participant>() //many participants to one trip
                .HasOne<Trip>()
                .WithMany(a => a.Participants)
                .HasForeignKey(e => e.TripId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .IsRequired();
            modelBuilder.Entity<Participant>() //many praticipants to one group
                .HasOne<Group>()
                .WithMany(a => a.Participants)
                .HasForeignKey(e => e.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .IsRequired();
            #endregion


            #region Group
            modelBuilder.Entity<Group>()
                .HasKey(p => p.Id);
            modelBuilder.Entity<Group>()
                .Property(p => p.MaxSize)
                .IsRequired();
            modelBuilder.Entity<Group>()
                .Property(p => p.Name)
                .IsRequired();
            //modelBuilder.Entity<Group>() //one group to many Participants
            //    .HasMany(e => e.Participants)
            //    .WithOne()
            //    .HasForeignKey(e => e.GroupId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .IsRequired();
            #endregion
        }
    }
}

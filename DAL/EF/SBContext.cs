using smart_booking.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace smart_booking.DAL.EF
{
    public class SBContext : DbContext
    {
        static SBContext()
        {
            //Database.SetInitializer<SBContext>(new SmartBookingDbInitializer());
        }
        public SBContext(string connectionString)
            : base(connectionString)
        { }
        public SBContext() { }
        public DbSet<User> Users { get; set; }
        public DbSet<Slot> Slots { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceCategory> ServiceCategories { get; set; }
        public DbSet<Business> Businesses { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<WorkingHour> WorkingHours { get; set; }
        public DbSet<WorkingBreak> WorkingBreaks { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Time_zone> Time_zones { get; set; }
        public DbSet<CalendarSetting> CalendarSettings { get; set; }
        public DbSet<CustomerNotification> CustomerNotifications { get; set; }
        public DbSet<TeamNotification> TeamNotifications { get; set; }
        public DbSet<PageLanguage> PageLanguages { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure Service & Slot entity
            //modelBuilder.Entity<Service>()
            //            .HasOptional(ser => ser.Slot) // Mark Slot property optional in Service entity
            //            .WithRequired(sl => sl.Service); // mark Service property as required in Slot entity. Cannot save Slot without Service
            modelBuilder.Entity<Slot>()
                    .HasRequired(m => m.Employee)
                    .WithMany(t => t.SlotsOwners)
                    .HasForeignKey(m => m.EmployeeId)
                    .WillCascadeOnDelete(false);
            modelBuilder.Entity<Slot>()
                    .HasRequired(m => m.Responsible)
                    .WithMany(t => t.Responsibles)
                    .HasForeignKey(m => m.ResponsibleId)
                    .WillCascadeOnDelete(false);
            //modelBuilder.Entity<Slot>()
            //        .HasRequired<Service>(m => m.Service)
            //        .WithMany(t => t.Slots)
            //        .HasForeignKey(m => m.ServiceId)
            //        .WillCascadeOnDelete(false);

            //---------------------------------------------------

       //     modelBuilder.Entity<CalendarSetting>()
       //     .HasRequired<Employee>(a => a.Employee)
       //     .WithRequiredPrincipal()
       //     .WillCascadeOnDelete(true);

       //     modelBuilder.Entity<CustomerNotification>()
       //    .HasRequired<Employee>(a => a.Employee)
       //    .WithRequiredPrincipal()
       //    .WillCascadeOnDelete(true);

       //     modelBuilder.Entity<TeamNotification>()
       //   .HasRequired<Employee>(a => a.Employee)
       //   .WithRequiredPrincipal()
       //   .WillCascadeOnDelete(true);


       //     modelBuilder.Entity<Permission>()
       //  .HasRequired<Employee>(a => a.Employee)
       //  .WithRequiredPrincipal()
       //  .WillCascadeOnDelete(true);

       //     modelBuilder.Entity<WorkingHour>()
       //.HasRequired<Employee>(a => a.Employee)
       //.WithRequiredPrincipal()
       //.WillCascadeOnDelete(true);



            //modelBuilder.Entity<Employee>()
            //.HasOptional<CalendarSetting>(a => a.CalendarSetting)
            //.WithOptionalDependent()
            //.WillCascadeOnDelete(true);

            //modelBuilder.Entity<Employee>()
            //.HasOptional<CustomerNotification>(a => a.CustomerNotification)
            //.WithOptionalDependent()
            //.WillCascadeOnDelete(true);

            //modelBuilder.Entity<Employee>()
            //.HasOptional<TeamNotification>(a => a.TeamNotification)
            //.WithOptionalDependent()
            //.WillCascadeOnDelete(true);

            //modelBuilder.Entity<Employee>()
            //.HasOptional<Permission>(a => a.Permission)
            //.WithOptionalDependent()
            //.WillCascadeOnDelete(true);

            //modelBuilder.Entity<Employee>()
            //.HasOptional<WorkingHour>(a => a.WorkingHour)
            //.WithOptionalDependent()
            //.WillCascadeOnDelete(true);

            //modelBuilder
            //.Entity<WorkingHour>()
            //.HasMany<WorkingBreak>(v => v.WorkingBreaks)
            //.WithOptional()
            //.WillCascadeOnDelete(true);

            //modelBuilder
            //.Entity<ServiceCategory>()
            //.HasMany<Service>(v => v.Services)
            //.WithOptional()
            //.WillCascadeOnDelete(false);

        }
    }
}
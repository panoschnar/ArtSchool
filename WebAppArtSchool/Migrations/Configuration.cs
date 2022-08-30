namespace WebAppArtSchool.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebAppArtSchool.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebAppArtSchool.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(WebAppArtSchool.Models.ApplicationDbContext context)
        {
            if (!context.Roles.Any(x => x.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole() { Name = "Admin" };
                manager.Create(role);
            }

            if (!context.Roles.Any(x => x.Name == "Student"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole() { Name = "Student" };
                manager.Create(role);
            }

            if (!context.Roles.Any(x => x.Name == "Trainer"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole() { Name = "Trainer" };
                manager.Create(role);
            }

            var PasswordHash = new PasswordHasher();
            if (!context.Users.Any(x => x.UserName == "admin@artschool.gr"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser()
                {
                    UserName = "panoschnar@yahoo.gr",
                    Email = "panoschnar@yahoo.gr",
                    PasswordHash = PasswordHash.HashPassword("Admin1234!"),
                    

                };
                manager.Create(user);
                manager.AddToRole(user.Id, "Admin");
            }

            if (!context.Users.Any(x => x.UserName == "student@gmail.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser()
                {
                    UserName = "student@gmail.com",
                    Email = "student@gmail.com",
                    PasswordHash = PasswordHash.HashPassword("Admin1234!"),

                };
                manager.Create(user);
                manager.AddToRole(user.Id, "Student");
            }

            if (!context.Users.Any(x => x.UserName == "student2@gmail.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser()
                {
                    UserName = "student2@gmail.com",
                    Email = "student@gmail.com",
                    PasswordHash = PasswordHash.HashPassword("Admin1234!"),

                };
                manager.Create(user);
                manager.AddToRole(user.Id, "Student");
            }

            if (!context.Users.Any(x => x.UserName == "trainer@gmail.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser()
                {
                    UserName = "trainer@gmail.com",
                    Email = "trainer@gmail.com",
                    PasswordHash = PasswordHash.HashPassword("Admin1234!"),

                };
                manager.Create(user);
                manager.AddToRole(user.Id, "Trainer");
            }

            if (!context.Users.Any(x => x.UserName == "trainer2@gmail.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser()
                {
                    UserName = "trainer2@gmail.com",
                    Email = "trainer2@gmail.com",
                    PasswordHash = PasswordHash.HashPassword("Admin1234!"),

                };
                manager.Create(user);
                manager.AddToRole(user.Id, "Trainer");
            }
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}

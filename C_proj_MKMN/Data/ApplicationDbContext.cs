using C_proj_MKMN.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace C_proj_MKMN.Data
{
    public class ApplicationDbContext : IdentityDbContext<UserModel>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserModel> UserModels { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //string ADMINROLE_ID = "admin123role";
            //string USERROLE_ID = "user123role";

            //string ADMIN_ID = "eaccdc25-300a-4012-a799-c844ae6e9902";
            //string USER_ID = "67f34799-a67a-40ef-afa0-7d1fc9965c21";

            base.OnModelCreating(builder);

            //IdentityRole adminRole = new IdentityRole() { Id = ADMINROLE_ID, Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "ADMIN" };
            //IdentityRole userRole = new IdentityRole() { Id = USERROLE_ID, Name = "User", ConcurrencyStamp = "2", NormalizedName = "USER" };
            //builder.Entity<IdentityRole>().HasData(adminRole);
            //builder.Entity<IdentityRole>().HasData(userRole);


            //UserModel admin = new UserModel()
            //{
            //    Id = ADMIN_ID,
            //    UserName = "ADMIN",
            //    NormalizedUserName= "ADMIN",
            //    Email = "admin@admin.admin",
            //    NormalizedEmail="ADMIN@ADMIN.ADMIN",
            //    EmailConfirmed=true,
            //};
            //UserModel user = new UserModel()
            //{
            //    Id = USER_ID,
            //    UserName = "USER",
            //    NormalizedUserName = "USER",
            //    Email = "user@user.user",
            //    NormalizedEmail = "USER@USER.USER",
            //    EmailConfirmed = true,
            //};

            //PasswordHasher<UserModel> hash1 = new PasswordHasher<UserModel>();
            //admin.PasswordHash = hash1.HashPassword(admin, "admin");
            //PasswordHasher<UserModel> hash2 = new PasswordHasher<UserModel>();
            //user.PasswordHash = hash2.HashPassword(user, "user");

            //builder.Entity<UserModel>().HasData(admin);
            //builder.Entity<UserModel>().HasData(user);

        /*    builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ADMINROLE_ID,
                UserId = ADMIN_ID
            });
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = USERROLE_ID,
                UserId = USER_ID
            });*/
        }
    }
}
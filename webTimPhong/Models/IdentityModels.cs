using System.Data.Entity;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Services.Description;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using webTimPhong.Models.EF;

namespace webTimPhong.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public int Phone { get; set; }
        public string Role { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public DbSet<CITY> CITies { get; set; }
        public DbSet<DISTRICT> dISTRICTs { get; set; }
        public DbSet<FAQ> fAQs { get; set; }
        public DbSet<PICTURE> PICTUREs { get; set; }

        public DbSet<ROOM> ROOMs { get; set; }
     
        public DbSet<WARD> WARDs { get; set; }
        public DbSet<RoomCategory> ROOMCategories { get; set; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
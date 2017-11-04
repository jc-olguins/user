using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using System.Web;
using User.Entities;

namespace User.EntityFramework
{
    public class ApplicationDbInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            InitializeIdentityForEF(context);
            base.Seed(context);
        }

        private static void InitializeIdentityForEF(ApplicationDbContext db)
        {
            InitializeSecurity(db);
        }

        private static void InitializeSecurity(ApplicationDbContext db)
        {
            const string firstName = "Desarrollo";
            const string lastName = "Loyalty";
            const string userName = "desarrollo";
            const string password = "loyalty";
            const string userEmail = "julio.olguin@ipsos.com";
            string[] roles = { "Administradores", "Usuarios" };
            string[] roleNameDescriptions = { "Acceso total a la aplicación", "Sólo pueden cargar bases de datos" };

            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var roleManager = HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();

            for (int i = 0; i < roles.Length; i++)
            {
                var role = roleManager.FindByName(roles[i]);
                if (role == null)
                {
                    role = new ApplicationRole() { Name = roles[i], Description = roleNameDescriptions[i] };
                    var rolResult = roleManager.Create(role);
                }
            }

            var user = userManager.FindByName(userName);
            if (user == null)
            {
                user = new ApplicationUser() { UserName = userName, Email = userEmail, Profile = new Profile() { FirstName = firstName, LastName = lastName } };
                var userResult = userManager.Create(user, password);
                userResult = userManager.SetLockoutEnabled(user.Id, false);
            }

            var rolesForUser = userManager.GetRoles(user.Id);
            if (!rolesForUser.Contains(roles[0]))
            {
                var result = userManager.AddToRole(user.Id, roles[0]);
            }
        }


    }
}

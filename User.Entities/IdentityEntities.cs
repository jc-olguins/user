using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace User.Entities
{
    // Puede agregar datos del perfil del usuario agregando más propiedades a la clase ApplicationUser. Para más información, visite http://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public virtual Profile Profile { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }
    }

    /// <summary>
    /// Clase POCO para representar datos personalizados de un usuario a través de Identity
    /// </summary>
    public class Profile
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public int LanguageId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        //public virtual Language Language { get; set; }
    }

    /// <summary>
    /// Clase POCO para agregar a un rol su decripción
    /// </summary>
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }
        public ApplicationRole(string name) : base(name) { }
        public string Description { get; set; }
    }
}

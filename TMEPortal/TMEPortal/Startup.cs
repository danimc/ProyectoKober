using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System.Linq;
using TMEPortal.DataContext;
using TMEPortal.Models;

[assembly: OwinStartupAttribute(typeof(TMEPortal.Startup))]
namespace TMEPortal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuthAsync(app);
            users();
        }
        private void users()
        {
            //KoberEntities db = new KoberEntities();


            //var clientes = db.CteEnviarA.ToList().Where(x => x.Contrasena != null).Where(i => i.Contrasena != "").Select(i => new { i.Cliente, i.Contrasena }).Distinct().ToList();

            //var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            //foreach (var item in clientes)
            //{
               
            //    var user = new ApplicationUser();
            //    user.UserName = item.Cliente.Trim();
            //    user.Email = "you400@gmail.com";

            //    UserManager.Create(user, item.Contrasena.Trim());

            //}
        }
    
    }
}

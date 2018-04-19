using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Controlprocesos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Controlprocesos {
    public partial class Startup {
        public void ConfigureRoles() {
            using (IdentityDBContext context = new IdentityDBContext()) {

                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                // Admin role
                if (!roleManager.RoleExists("Manager")) {

                    // Create admin role
                    roleManager.Create(new IdentityRole("Manager"));

                    // Create admin account
                    var user = new ApplicationUser {
                        UserName = "murena@euromobilia.com",
                        Email = "murena@euromobilia.com",
                    };
                    string password = "Fidelitas.18";

                    var createUserTransaction = UserManager.Create(user, password);
                    if (createUserTransaction.Succeeded) {
                        UserManager.AddToRole(user.Id, "Manager");
                    }

                }

                // Mortals role
                if (!roleManager.RoleExists("Employee")) roleManager.Create(new IdentityRole("Employee"));

            }
        }
    }
}
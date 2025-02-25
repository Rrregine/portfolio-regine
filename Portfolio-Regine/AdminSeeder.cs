using Microsoft.AspNetCore.Identity;

namespace Portfolio_Regine
{
    public static class AdminSeeder
    {
        public static async Task SeedAdminAsync(UserManager<IdentityUser> userManager, 
            RoleManager<IdentityRole> roleManager)
        {
            // Create "Admin" Role
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            // Create Admin User
            string adminEmail = "admin@email.com";
            string adminPassword = "Admin123";
            
            var users = userManager.Users.ToList();
            foreach (var user in users)
            {
                await userManager.DeleteAsync(user);
            }

            if (await userManager.FindByEmailAsync(adminEmail) == null)
            {
                var adminUser = new IdentityUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(adminUser, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }
        }
    }
}

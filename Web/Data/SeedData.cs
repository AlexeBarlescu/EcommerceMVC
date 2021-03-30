using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Data
{
    public class SeedData
    {
        private const string AdminUser = "Admin";
        private const string AdminPassword = "Secret123$";

        public static async Task Seed(AppContext ctx, UserManager<IdentityUser> userManager)
        {
            ctx.Database.EnsureCreated();

            //Seed Admin User

            IdentityUser user = await userManager.FindByIdAsync(AdminUser);
            if (user == null)
            {
                user = new IdentityUser("Admin");
                user.Email = "admin@example.com";
                user.PhoneNumber = "555-12345";
                await userManager.CreateAsync(user, AdminPassword);
            }

            if (ctx.Products.Any()) return;
            
            string fruits = "Fruits";
            string vegetables = "Vegetables";
            ctx.Products.AddRange(
                new Product("Apple", fruits, 0.5, null, 20, "~/img/fruit/apple.png"),
                new Product("Avocado", fruits, 0.89, null, 20, "~/img/fruit/avocado.png"),
                new Product("Bananas", fruits, 1.20, 1.10, 20, "~/img/fruit/bananas.png"),
                new Product("Berry", fruits, 2.20, 1.99, 20, "~/img/fruit/berry.png"),
                new Product("Grapes", fruits, 1.39, null, 20, "~/img/fruit/grapes.png"),
                new Product("Kiwi", fruits, 1.20, null, 20, "~/img/fruit/kiwi.png"),
                new Product("Lemon", fruits, 0.40, 0.39, 20, "~/img/fruit/lemon.png"),
                new Product("Mandarin", fruits, 0.35, null, 20, "~/img/fruit/mandarin.png"),
                new Product("Mango", fruits, 0.90, null, 20, "~/img/fruit/mango.png"),
                new Product("Orange", fruits, 0.30, null, 20, "~/img/fruit/orange-juice.png"),
                new Product("Pear", fruits, 0.39, null, 20, "~/img/fruit/pear.png"),
                new Product("Strawberry", fruits, 0.15, 0.13, 20, "~/img/fruit/strawberry.png"),
                new Product("Watermelon", fruits, 4.30, null, 20, "~/img/fruit/watermelon.png"),
                new Product("Green Pepper", vegetables, 0.99, null, 20, "~/img/veg/bell-pepper.png"),
                new Product("Broccoli", vegetables, 1.15, null, 20, "~/img/veg/broccoli.png"),
                new Product("Cabbage", vegetables, 0.99, 0.80, 20, "~/img/veg/cabbage.png"),
                new Product("Carrot", vegetables, 0.10, null, 20, "~/img/veg/carrot.png"),
                new Product("Chilli", vegetables, 0.10, null, 20, "~/img/veg/chilli-pepper.png"),
                new Product("Corn", vegetables, 1.99, 1.70, 20, "~/img/veg/corn.png"),
                new Product("Eggplant", vegetables, 0.60, null, 20, "~/img/veg/eggplant.png"),
                new Product("Green Peas", vegetables, 01.50, 1.20, 20, "~/img/veg/green-pea.png"),
                new Product("Onion", vegetables, 0.10, null, 20, "~/img/veg/onion.png"),
                new Product("Potato", vegetables, 0.20, null, 0, "~/img/veg/potato.png"),
                new Product("Pumpkin", vegetables, 3.30, 2.99, 20, "~/img/veg/pumpkin.png"),
                new Product("Spinach", vegetables, 2.99, null, 20, "~/img/veg/spinach.png")
            );
            ctx.SaveChanges();
        }
    }
}
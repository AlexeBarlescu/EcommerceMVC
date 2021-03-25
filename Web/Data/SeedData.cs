using System.Linq;
using Web.Models;

namespace Web.Data
{
    public class SeedData
    {
        public static void Seed(AppContext ctx)
        {
            ctx.Database.EnsureCreated();

            if (ctx.Products.Any()) return;
            
            string fruits = "Fruits";
            string vegetables = "Vegetables";
            ctx.Products.AddRange(
                new Product("Apple", fruits, 0.5M, null, 20, "img/fruit/apple.png"),
                new Product("Avocado", fruits, 0.89M, null, 20, "img/fruit/avocado.png"),
                new Product("Bananas", fruits, 1.20M, 1.10M, 20, "img/fruit/bananas.png"),
                new Product("Berry", fruits, 2.20M, 1.99M, 20, "img/fruit/berry.png"),
                new Product("Grapes", fruits, 1.39M, null, 20, "img/fruit/grapes.png"),
                new Product("Kiwi", fruits, 1.20M, null, 20, "img/fruit/kiwi.png"),
                new Product("Lemon", fruits, 0.40M, 0.39M, 20, "img/fruit/lemon.png"),
                new Product("Mandarin", fruits, 0.35M, null, 20, "img/fruit/mandarin.png"),
                new Product("Mango", fruits, 0.90M, null, 20, "img/fruit/mango.png"),
                new Product("Orange", fruits, 0.30M, null, 20, "img/fruit/orange-juice.png"),
                new Product("Pear", fruits, 0.39M, null, 20, "img/fruit/pear.png"),
                new Product("Strawberry", fruits, 0.15M, 0.13M, 20, "img/fruit/strawberry.png"),
                new Product("Watermelon", fruits, 4.30M, null, 20, "img/fruit/watermelon.png"),
                new Product("Green Pepper", vegetables, 0.99M, null, 20, "img/veg/bell-pepper.png"),
                new Product("Broccoli", vegetables, 1.15M, null, 20, "img/veg/broccoli.png"),
                new Product("Cabbage", vegetables, 0.99M, 0.80M, 20, "img/veg/cabbage.png"),
                new Product("Carrot", vegetables, 0.10M, null, 20, "img/veg/carrot.png"),
                new Product("Chilli", vegetables, 0.10M, null, 20, "img/veg/chilli-pepper.png"),
                new Product("Corn", vegetables, 1.99M, 1.70M, 20, "img/veg/corn.png"),
                new Product("Eggplant", vegetables, 0.60M, null, 20, "img/veg/eggplant.png"),
                new Product("Green Peas", vegetables, 01.50M, 1.20M, 20, "img/veg/green-pea.png"),
                new Product("Onion", vegetables, 0.10M, null, 20, "img/veg/onion.png"),
                new Product("Potato", vegetables, 0.20M, null, 20, "img/veg/potato.png"),
                new Product("Pumpkin", vegetables, 3.30M, 2.99M, 20, "img/veg/pumpkin.png"),
                new Product("Spinach", vegetables, 2.99M, null, 20, "img/veg/spinach.png")
            );
            ctx.SaveChanges();
        }
    }
}
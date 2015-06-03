using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Web.Http;
using DigiMenuServer.Models;
using Microsoft.WindowsAzure.Mobile.Service;
using digimenuService.DataObjects;

namespace DigiMenuServer
{
    public static class WebApiConfig
    {
        public static void Register()
        {
            // Use this class to set configuration options for your mobile service
            ConfigOptions options = new ConfigOptions();

            // Use this class to set WebAPI configuration options
            HttpConfiguration config = ServiceConfig.Initialize(new ConfigBuilder(options));

            // To display errors in the browser during development, uncomment the following
            // line. Comment it out again when you deploy your service for production use.
            // config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            Database.SetInitializer(new MobileServiceInitializer());
        }
    }

    public class MobileServiceInitializer : CreateDatabaseIfNotExists<MobileServiceContext>
    {
        protected override void Seed(MobileServiceContext context)
        {
            context.Menus.Add(GetNorthAmericanMenu());

            base.Seed(context);
        }

        private Menu GetNorthAmericanMenu()
        {
            Menu result = new Menu
            {
                Id = "1",
                Region = "NORTH_AMERICA",
                Categories = new Collection<MenuCategory>()
            };

            MenuCategory starters = result.AddMenuCategory("Starters", "1");
            starters.AddMenuItem("1", "Golden Calamari", "Marinated calamari breaded and cooked to order. Served with roasted garlic lemon aioli and a spicy Sriracha cocktail sauce.", false, "http://riotranch.com/wp-content/uploads/2014/03/calamari.jpg", 11.34);
            starters.AddMenuItem("2", "Featured Soup", "Ask for today's unique and delicious feature.", true, "http://s3.amazonaws.com/foodspotting-ec2/reviews/3028186/thumb_600.jpg?1358757771", 6.38);

            MenuCategory entrees = result.AddMenuCategory("Entrees", "2");
            entrees.AddMenuItem("3", "The Classic Burger", "A great flame-grilled patty standing alone in all its glory.", false, "http://farm4.static.flickr.com/3266/3106381196_c81b03ffb6.jpg", 11.97);
            entrees.AddMenuItem("4", "Sauced Up Chicken Fingers", "Our legendary Chicken Fingers tossed in your choice of mild, medium or hot Buffalo wing sauce. Served with Yukon Gold fries and dipping sauce.", true, "http://4.bp.blogspot.com/-e7Ff1XxaKpU/TsnGe4dtnRI/AAAAAAAAFRM/nMLFmSfSuqA/s1600/Jack+Astor%2527s+Buffalo+Fingers+4a.jpg", 14.58);
            entrees.AddMenuItem("5", "Pad Thai", "Rice noodles with bean sprouts, caramelized onions, fried egg, red peppers, green onions and crushed peanuts in a tamarind Pad Thai sauce. Topped with your choice of sweet & spicy tofu, chicken or shrimp.", false, "http://4.bp.blogspot.com/_UIXOn06Pz70/SSs924dP3UI/AAAAAAAAFls/6pmRVsoDC4w/s800/Pad+Thai+500.jpg", 17.46);

            MenuCategory desserts = result.AddMenuCategory("Desserts", "3");
            desserts.AddMenuItem("6", "New York Vanilla Cheesecake", "Made with only the finest ingredients! A deliciously rich and smooth cheesecake with a graham cracker crust. Served with your choice of topping: Chocolate, Caramel or Bumbleberry.", false, "http://upload.wikimedia.org/wikipedia/commons/thumb/e/ea/Baked_cheesecake_with_raspberries_and_blueberries.jpg/972px-Baked_cheesecake_with_raspberries_and_blueberries.jpg", 7.27);

            MenuCategory beverages = result.AddMenuCategory("Beverages", "4");
            beverages.AddMenuItem("7", "Freshly Squeezed Sparkling Lemonade", "Also available as Limeade, Orangeade or Cranberry-Lemonade", false, "http://1.bp.blogspot.com/-4NtIzWknO64/T-JLqg5wPeI/AAAAAAAAGGc/w37mdZ_GA0Y/s1600/mango+iceberg.jpg", 2.99);
            beverages.AddMenuItem("8", "Soda", "Coca Cola, Pepsi, Sprite, Mountain Dew", false, "http://images.all-free-download.com/images/graphiclarge/cocacola_logo_28559.jpg", 3.46);

            return result;
        }
    }

    public static class MenuExtensions
    {
        public static MenuCategory AddMenuCategory(this Menu menu, string id, string name)
        {
            var result = new MenuCategory
            {
                Id = id,
                Name = name,
                Items = new Collection<MenuItem>()
            };

            menu.Categories.Add(result);
            return result;
        }

        public static MenuItem AddMenuItem(this MenuCategory category, string id, string name, string description, bool isSpicy, string imageUri, double price)
        {
            var result = new MenuItem
            {
                Id = id,
                Name = name,
                Description = description,
                IsSpicy = isSpicy,
                ImageUri = imageUri,
                Price = price,
                Likes = 0
            };

            category.Items.Add(result);
            return result;
        }
    }
}


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

    public class MobileServiceInitializer : DropCreateDatabaseIfModelChanges<MobileServiceContext>
    {
        protected override void Seed(MobileServiceContext context)
        {
            context.Menus.Add(GetDefaultMenu());
            context.Menus.Add(GetCanadianMenu());

            base.Seed(context);
        }

        private Menu GetDefaultMenu()
        {
            Menu result = new Menu
            {
                Id = "1",
                Region = "DEFAULT",
                Categories = new Collection<MenuCategory>()
            };

            MenuCategory starters = result.AddMenuCategory("1", "Starters");
            MenuCategory entrees = result.AddMenuCategory("2", "Entrees");
            MenuCategory desserts = result.AddMenuCategory("3", "Desserts");
            MenuCategory beverages = result.AddMenuCategory("4", "Beverages");

            starters.AddMenuItem("1", "Dynamite Shrimp", "Crispy shrimp tossed in a zesty sauce.", true, "http://farm5.staticflickr.com/4059/4527167114_dd51ef0473_z.jpg", 11.99);
            starters.AddMenuItem("2", "Crab Wontons", "Crispy wontons filled with a creamy mixture of crab meat, bell peppers and green onions, served with a spicy plum sauce.", false, "http://somecontrast.com/blog/wp-content/uploads/2010/09/P-F-Changs-Crab-Wonton.jpg", 9.49);

            entrees.AddMenuItem("3", "Sesame Chicken", "Tender chicken breast, broccoli, red bell peppers and onions in a spicy sesame sauce", true, "http://culinarycravings.net/wp-content/uploads/2011/09/IMG_8608.jpg", 12.99);
            entrees.AddMenuItem("4", "Sweet & Source Chicken", "Stir-fried with pineapple, bell peppers, onions and candied ginger in a sweet & sour sauce.", false, "http://creolecontessa.com/wp-content/uploads/2014/01/pf-changs-orange-peeled-chicken-252816-2529.jpg", 17.99);

            desserts.AddMenuItem("5", "The Great Wall of Chocolate", "Six rich layers of frosted chocolate cake topped with semi-sweet chocolate chips 12 slices.", false, "http://1.bp.blogspot.com/-I02fm9BVyJ0/UTJaQtlfTmI/AAAAAAAAFUo/RZ6ZdDwxTQI/s1600/great+wall+of+choco.jpg", 12.99);

            beverages.AddMenuItem("6", "Lychee Martini", "Smirnoff vodka, lychee liquor and fresh lemon juice shaken with cranberry juice.", false, "http://www.tablespoon.com/-/media/Images/Articles/Post%20Images/2011/06/week4/2011-06-22-lychee-martini-umbrella-500-2.jpg", 8.99);

            return result;
        }

        private Menu GetCanadianMenu()
        {
            Menu result = new Menu
            {
                Id = "100",
                Region = "CANADA",
                Categories = new Collection<MenuCategory>()
            };

            MenuCategory starters = result.AddMenuCategory("101", "Starters");
            MenuCategory entrees = result.AddMenuCategory("102", "Entrees");
            MenuCategory desserts = result.AddMenuCategory("103", "Desserts");
            MenuCategory beverages = result.AddMenuCategory("104", "Beverages");

            starters.AddMenuItem("101", "Golden Calamari", "Marinated calamari breaded and cooked to order. Served with roasted garlic lemon aioli and a spicy Sriracha cocktail sauce.", false, "http://riotranch.com/wp-content/uploads/2014/03/calamari.jpg", 11.34);
            starters.AddMenuItem("102", "Featured Soup", "Ask for today's unique and delicious feature.", true, "http://s3.amazonaws.com/foodspotting-ec2/reviews/3028186/thumb_600.jpg?1358757771", 6.38);

            entrees.AddMenuItem("103", "The Classic Burger", "A great flame-grilled patty standing alone in all its glory.", false, "http://farm4.static.flickr.com/3266/3106381196_c81b03ffb6.jpg", 11.97);
            entrees.AddMenuItem("104", "Sauced Up Chicken Fingers", "Our legendary Chicken Fingers tossed in your choice of mild, medium or hot Buffalo wing sauce. Served with Yukon Gold fries and dipping sauce.", true, "http://4.bp.blogspot.com/-e7Ff1XxaKpU/TsnGe4dtnRI/AAAAAAAAFRM/nMLFmSfSuqA/s1600/Jack+Astor%2527s+Buffalo+Fingers+4a.jpg", 14.58);
            entrees.AddMenuItem("105", "Pad Thai", "Rice noodles with bean sprouts, caramelized onions, fried egg, red peppers, green onions and crushed peanuts in a tamarind Pad Thai sauce. Topped with your choice of sweet & spicy tofu, chicken or shrimp.", false, "http://4.bp.blogspot.com/_UIXOn06Pz70/SSs924dP3UI/AAAAAAAAFls/6pmRVsoDC4w/s800/Pad+Thai+500.jpg", 17.46);

            desserts.AddMenuItem("106", "New York Vanilla Cheesecake", "Made with only the finest ingredients! A deliciously rich and smooth cheesecake with a graham cracker crust. Served with your choice of topping: Chocolate, Caramel or Bumbleberry.", false, "http://upload.wikimedia.org/wikipedia/commons/thumb/e/ea/Baked_cheesecake_with_raspberries_and_blueberries.jpg/972px-Baked_cheesecake_with_raspberries_and_blueberries.jpg", 7.27);

            beverages.AddMenuItem("107", "Freshly Squeezed Sparkling Lemonade", "Also available as Limeade, Orangeade or Cranberry-Lemonade", false, "http://1.bp.blogspot.com/-4NtIzWknO64/T-JLqg5wPeI/AAAAAAAAGGc/w37mdZ_GA0Y/s1600/mango+iceberg.jpg", 2.99);
            beverages.AddMenuItem("108", "Soda", "Coca Cola, Pepsi, Sprite, Mountain Dew", false, "http://images.all-free-download.com/images/graphiclarge/cocacola_logo_28559.jpg", 3.46);

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


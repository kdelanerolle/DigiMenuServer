using digimenuService.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigiMenuServer.Models
{
    public class MenuManager
    {
        private MobileServiceContext _context;

        public MenuManager(MobileServiceContext context)
        {
            _context = context;
        }

        public virtual Menu GetMenuByCountryName(string country)
        {
            if (string.IsNullOrEmpty(country))
            {
                // santize country
                country = string.Empty;
            }

            Menu result = _context.Menus.FirstOrDefault(menu => menu.Region.ToLower() == country.ToLower());
            if (result == null)
            {
                // country not found - grab default menu
                result = _context.Menus.FirstOrDefault(menu => menu.Region.ToLower() == "default".ToLower());
            }

            return result;
        }

        public virtual void LikeMenuItem(string menuItemId)
        {
            // HACK: quick and dirty
            MenuItem menuItem = null;
            foreach (var menu in _context.Menus.ToList())
            {
                foreach (var category in menu.Categories.ToList())
                {
                    menuItem = category.Items.FirstOrDefault(x => x.Id == menuItemId);
                    if (menuItem != null)
                    {
                        // menu item found - escape
                        menuItem.Likes += 1;
                        _context.SaveChanges();
                        break;
                    }
                }
            }
        }
    }
}
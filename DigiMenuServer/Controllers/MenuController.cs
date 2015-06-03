using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.WindowsAzure.Mobile.Service;
using DigiMenuServer.Models;
using digimenuService.DataObjects;
using DigiMenuServer.DataObjects;

namespace DigiMenuServer.Controllers
{
    public class MenuController : ApiController
    {
        /// <summary>
        /// Gets or sets the user settings
        /// </summary>
        public MenuManager MenuManager { get; set; }

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);

            MenuManager = new MenuManager(new MobileServiceContext());
        }

        // GET api/UserSettings
        /// <summary>
        /// Gets a list of settings for the user
        /// </summary>
        /// <returns>Returns a list of user settings</returns>
        [Route("api/menu")]
        public Menu GetMenu(Location location)
        {
            // TODO: key off the location to retrieve the localized menu
            return MenuManager.GetMenuByRegionName("NORTH_AMERICA");
        }

        [Route("api/like")]
        public void PostLikeMenuItem(MenuItem menuItem)
        {
            MenuManager.LikeMenuItem(menuItem.Id);
        }
    }
}
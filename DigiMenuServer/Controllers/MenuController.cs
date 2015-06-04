using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.WindowsAzure.Mobile.Service;
using DigiMenuServer.Models;
using digimenuService.DataObjects;

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

        /// <summary>
        /// Returns the menu for the given geographical region.
        /// </summary>
        /// <param name="longitude"></param>
        /// <param name="latitude"></param>
        /// <returns></returns>
        [Route("api/menu")]
        [HttpGet]
        public Menu GetMenu(double longitude, double latitude)
        {
            // TODO: key off the location to retrieve the localized menu
            return MenuManager.GetMenuByRegionName("NORTH_AMERICA");
        }

        /// <summary>
        /// Increments the like counter for a menu item.
        /// </summary>
        /// <param name="id"></param>
        [Route("api/like")]
        [HttpPost]
        public void LikeMenuItem(string id)
        {
            MenuManager.LikeMenuItem(id);
        }
    }
}
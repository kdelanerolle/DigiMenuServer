using Microsoft.WindowsAzure.Mobile.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace digimenuService.DataObjects
{
    public class Menu : EntityData
    {
        public string Region { get; set; }
        public virtual ICollection<MenuCategory> Categories { get; set; }
    }
}
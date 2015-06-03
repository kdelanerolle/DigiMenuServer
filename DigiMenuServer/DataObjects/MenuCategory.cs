using Microsoft.WindowsAzure.Mobile.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace digimenuService.DataObjects
{
    public class MenuCategory : EntityData
    {
        public string Name { get; set; }
        public virtual ICollection<MenuItem> Items { get; set; }
    }
}
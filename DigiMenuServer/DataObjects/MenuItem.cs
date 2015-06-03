using Microsoft.WindowsAzure.Mobile.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace digimenuService.DataObjects
{
    public class MenuItem : EntityData
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsSpicy { get; set; }
        public string ImageUri { get; set; }
        public double Price { get; set; }
        public int Likes { get; set; }
    }
}
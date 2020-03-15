using System;
using System.Collections.Generic;
using System.Text;

namespace Source.net.mobile.Models
{
    public enum MenuItemType
    {
        Posts
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}

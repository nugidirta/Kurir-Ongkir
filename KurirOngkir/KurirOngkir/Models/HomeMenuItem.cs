using System;
using System.Collections.Generic;
using System.Text;

namespace KurirOngkir.Models
{
    public enum MenuItemType
    {
        Browse,
        //Kota,
        //Cost,
        About
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}

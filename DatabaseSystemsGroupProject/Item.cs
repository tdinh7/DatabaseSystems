using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatabaseSystemsGroupProject
{
    public class Item
    {
        public int ItemID;
        public string pictureUrl;
        public string name;
        public string price;
        public int quantity;

        public Item(int ItemID, string pictureUrl, string name, string price, int quantity) {
            this.ItemID = ItemID;
            this.pictureUrl = pictureUrl;
            this.name = name;
            this.price = price;
            this.quantity = quantity;
        }
    }
}
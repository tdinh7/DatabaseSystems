using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatabaseSystemsGroupProject
{
    public class Item
    {
        int tempItemID;
        string pictureUrl;
        string name;
        string price;

        public Item(int tempItemID, string pictureUrl, string name, string price) {
            this.tempItemID = tempItemID;
            this.pictureUrl = pictureUrl;
            this.name = name;
            this.price = price;
        }
    }
}
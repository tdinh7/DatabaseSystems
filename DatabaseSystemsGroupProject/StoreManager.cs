using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatabaseSystemsGroupProject
{
    public class StoreManager
    {
        List<Item> itemList;

        public StoreManager() {
            itemList = new List<Item>();
        }

        public Boolean AddItemToList(int tempItemID, string pictureUrl, string name, string price) {
            Item tempItem = new Item(tempItemID, pictureUrl, name, price);
            itemList.Add(tempItem);
            return true;
        }
    }
}
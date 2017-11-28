using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatabaseSystemsGroupProject
{
    public class StoreManager
    {
        public List<Item> itemList;
        public List<OrderRecord> orderRecordList;

        public StoreManager() {
            itemList = new List<Item>();
            orderRecordList = new List<OrderRecord>();
        }

        public Boolean AddItemToList(int tempItemID, string pictureUrl, string name, string price, int quantity) {
            Item tempItem = new Item(tempItemID, pictureUrl, name, price, quantity);
            itemList.Add(tempItem);
            return true;
        }

        public Boolean AddOrderRecordToList(String orderRecordID, String customerID, String dateOrdered, String numberOfItems, String totalPrice) {
            OrderRecord tempOrderRecord = new OrderRecord( orderRecordID,  customerID,  dateOrdered,  numberOfItems,  totalPrice);
            orderRecordList.Add(tempOrderRecord);
            return true;
        }
    }
}
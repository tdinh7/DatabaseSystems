using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatabaseSystemsGroupProject
{
    public class OrderRecord
    {
        String orderRecordID;
        String customerID;
        String dateOrdered;
        String numberOfItems;
        String totalPrice;

        public OrderRecord(String orderRecordID,String customerID,String dateOrdered,String numberOfItems,String totalPrice)
        {
            this.orderRecordID = orderRecordID;
            this.customerID = customerID;
            this.dateOrdered = dateOrdered;
            this.numberOfItems = numberOfItems;
            this.totalPrice = totalPrice;
        }
    }
}
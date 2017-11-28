using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatabaseSystemsGroupProject
{
    public class OrderRecord
    {
       
        public OrderRecord(String orderRecordID,String customerID,String dateOrdered,String numberOfItems,String totalPrice)
        {
            this.orderRecordID = orderRecordID;
            this.customerID = customerID;
            this.dateOrdered = dateOrdered;
            this.numberOfItems = numberOfItems;
            this.totalPrice = totalPrice;
        }

        public String orderRecordID;
        public String customerID;
        public String dateOrdered;
        public String numberOfItems;
        public String totalPrice;

        public String getOrderRecordID() {
            return orderRecordID;
        }

        public void setOrderRecordID(String orderRecordID)
        {
            this.orderRecordID = orderRecordID;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatabaseSystemsGroupProject
{
    public class Employee
    {
        String firstName;
        String LastName;
        String isManager;
        String userName;
        String password;

        public Employee(String fristname, String lastname, String isManger, String userName, String password) {
            this.firstName = firstName;
            this.LastName = lastname;
            this.isManager = isManager;
            this.userName = userName;
            this.password = password;
        }

        public void setFirstName() {

        }
    }
}
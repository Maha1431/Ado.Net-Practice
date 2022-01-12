using System;
using System.Collections.Generic;
using System.Text;

namespace ADO.NET_Practice
{
    class Employee_Model
    {
        public int id { get; set; }
        public string name { get; set; }
        public double salary { get; set; }
        public string start_date { get; set; }
        public string Gender { get; set; }
        public int phone { get; set; }
        public int department { get; set; }
        public string address { get; set; }
        public double basicPay { get; set; }
        public double deduction { get; set; }
        public double taxablePay { get; set; }
        public double incomeTax { get; set; }
        public double netpay { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystemService
{
    public class Contact
    {
        // Contact details....
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public decimal zip { get; set; }
        public decimal phoneNumber { get; set; }
        public string emailId { get; set; }
        public string contactType { get; set; }
        public string addressBookName { get; set; }
    }
}

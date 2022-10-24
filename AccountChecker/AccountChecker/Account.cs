using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountChecker
{
    public class Account
    {
        public string RecordNumber { get; set; }
        public string AccountNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Amount { get; set; }
        public bool IsValid { get; set; }
        public List<string> Errors { get; set; }


        public Account()
        {
            Errors = new List<string>();
        }
    }
}
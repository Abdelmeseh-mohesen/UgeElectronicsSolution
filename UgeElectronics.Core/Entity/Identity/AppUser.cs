using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UgeElectronics.Core.Enums;

namespace UgeElectronics.Core.Identity
{
    public class AppUser:IdentityUser
    {
        public string ?DisplayName { get; set; }
        public UserType UserType { get; set; }
        public Address Address { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ShopName { get; set; }
        public string? ShopUrl { get; set; }
        public string? Street { get; set; }
        public string ?Street2 { get; set; }
        public string? City { get; set; }
        public string ?PostCode { get; set; }
        public string? Country { get; set; }
        public string ?State { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyId { get; set; } 
        public string ?VATNumber { get; set; } 
        public string ?BankName { get; set; } 
        public string? BankIBAN { get; set; } 
        
    }
}

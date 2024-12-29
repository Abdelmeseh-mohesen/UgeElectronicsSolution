using System.ComponentModel.DataAnnotations;
using UgeElectronics.Core.Enums;

namespace UgeElectronics.Dtos.AuthDto
{

    public class RegisterDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public UserType UserType { get; set; }
        public string?DisplayName { get; set; }
        public string ?FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ShopName { get; set; }
        public string ?ShopUrl { get; set; }
        public string ?Street { get; set; }
        public string ?Street2 { get; set; } // يمكن أن يكون اختياريًا
        public string?City { get; set; }
        public string? PostCode { get; set; }
        public string ?Country { get; set; }
        public string ?State { get; set; }
        public string ?CompanyName { get; set; }
        public string? CompanyId { get; set; } // Company ID/EUID Number
        public string? VATNumber { get; set; } // VAT/TAX Number
        public string? BankName { get; set; } // Name of Bank
        public string ?BankIBAN { get; set; } // Bank IBAN
        public string? PhoneNumber { get; set; }


    }

}



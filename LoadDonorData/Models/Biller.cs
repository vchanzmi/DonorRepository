using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoadDonorData.Models
{
    public class Biller
    {
        [Key]
        public int BillerId { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string FirstName { get; set; }
        public string MI { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string LastName { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string AddressLine1 { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string City { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string State { get; set; }
        [Required(AllowEmptyStrings = false)]
        public int ZipCode { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Country { get; set; }
        public string ReceiptMethod { get; set; }
        public string ReceiptFrequency { get; set; }
        public string CreditCard4Digits { get; set; }
        public string CreditCardType { get; set; }
    }
}
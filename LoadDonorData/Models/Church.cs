using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoadDonorData.Models
{
    public class Church
    {
        [Key]
        public int ChurchId { get; set; }
        public string EnglishName { get; set; }
        public string ChineseName { get; set; }
        public string ChurchPhone { get; set; }
        public string ChurchEmail { get; set; }
        public string AddressLine1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string PastorName { get; set; }
        public string PastorPhone { get; set; }
        public string PastorEmail { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
    }
}
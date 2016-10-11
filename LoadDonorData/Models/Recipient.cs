using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoadDonorData.Models
{
    public class Recipient
    {
        [Key]
        public int RecipientId { get; set; }
        public string EnglishName { get; set; }
        public string ChineseName { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Bio { get; set; }
        public virtual ICollection<Donor> MyDonorList { get; set; }
    }
}
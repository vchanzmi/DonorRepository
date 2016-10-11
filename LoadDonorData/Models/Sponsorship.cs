using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LoadDonorData.Models
{
    public class Sponsorship
    {
        [Key, Column(Order = 0)]
        public int DonorId { get; set; }
        [Key, Column(Order = 1)]
        public int RecipientId { get; set; }

        public virtual Donor Donor { get; set; }
        public virtual Recipient Recipient { get; set; }
        public decimal Amount { get; set; }
        public string Frequency { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

    }
}
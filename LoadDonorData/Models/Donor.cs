using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LoadDonorData.Models
{
    public class Donor
    {
        [Key]
        public int DonorId { get; set; }
        public string Title { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string FirstName { get; set; }
        public string MI { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public string ChineseName { get; set; }
        public string Suffix { get; set; }
        public string HomePhone { get; set; }
        public string CellPhone { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public DateTime? DOB { get; set; }
        public DateTime TimeStamp { get; set; }
        public virtual ICollection<ContactMethod> MyContactMethod { get; set; }
        public virtual ICollection<Branch> MyBranch { get; set; }
        public virtual ICollection<Solicitation> MySolicitation { get; set; }
        public string Notes{ get; set; }
        public virtual Biller Payer { get; set; }
        public virtual Church Church { get; set; }
        public virtual ICollection<InterestedProjects> MyProjects { get; set; }
        public virtual ICollection<Recipient> MyRecipientList { get; set; }
    }

    public class InterestedProjects
    {
        public int IdNum { get; set; }
        public string TextName { get; set; }
        public bool CheckedYet { get; set; }
        
    }

    public class ContactMethod {
        public int Id { get; set; }
        public string Method { get; set; }
    }

    public class Branch
    {
        public int Id { get; set; }
        public string BranchOrg { get; set; }
    }

    public class Solicitation {
        public int Id { get; set; }
        public string SolicitationSource { get; set; }
    }
}
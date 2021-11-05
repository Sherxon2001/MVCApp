using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pension.Domain.Models
{
    [Table("pensionDatabase")]
    public class UserModel
    {
        [Key]  
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public DateTime Brithday { get; set; }
        public string MaritalStatus { get; set; }
        public int PINFLNumber { get; set; }
        public string Region { get; set; }
        public string District { get; set; }
        public string Mahalla { get; set; }
        public string PostalAddress { get; set; }
        public string PhysicalAddress { get; set; }
        public string PhoneContact { get; set; }
        public string EmailAddress { get; set; }
        public bool ForTwoYears { get; set; }
        public bool ForFourteenYears { get; set; }
        public bool Support{ get; set; }
        public string Signature { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string OfficialName { get; set; }
        public string OfficialDisignation { get; set; }
        public string OfficialSignatrue { get; set; }
        public DateTime OfficialDate { get; set; } = DateTime.Now;


    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace AdvocacyPro.Models.Base
{
    public abstract class ContactBase : TrackedBase
    {
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string MiddleName { get; set; }
        [MaxLength(50)]
        public string Address { get; set; }
        [MaxLength(50)]
        public string City { get; set; }
        public int? StateId { get; set; }
        [MaxLength(10)]
        public string ZipCode { get; set; }
        [Phone, MaxLength(20)]
        public string HomePhone { get; set; }
        [Phone, MaxLength(20)]
        public string CellPhone { get; set; }
        [Phone, MaxLength(20)]
        public string WorkPhone { get; set; }
        [EmailAddress, MaxLength(50)]
        public string Email { get; set; }
        public DateTime? DOB { get; set; }
        public int? GenderId { get; set; }
        public int? RaceId { get; set; }
        [Range(0, 150)]
        public int? Age { get; set; }
        public int? EthnicityId { get; set; }
    }
}

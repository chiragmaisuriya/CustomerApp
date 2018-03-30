using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerAPP.Model
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string  LastName { get; set; }
        [Required]
        public DateTime BirthDay { get; set; }
        [Required]
        public string  Address { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }

    }
}

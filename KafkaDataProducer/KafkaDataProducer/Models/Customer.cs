using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace KafkaDataProducer.Models
{
    [DataContract]
    [Table("Customers")]
    public class Customer
    {
        [DataMember]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [DataMember]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [DataMember]
        [MaxLength(20)]
        public string LastName { get; set; }

        [DataMember]
        public DateTime CreatedDate { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}

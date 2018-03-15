using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace KafkaDataProducer.Models
{
    [DataContract]
    [Table("Merchants")]
    public class Merchant
    {
        [DataMember]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [DataMember]
        [MaxLength(50)]
        public string TradingName { get; set; }

        [DataMember]
        [MaxLength(50)]
        public string AddressLine1 { get; set; }

        [DataMember]
        [MaxLength(30)]
        public string City { get; set; }


        [DataMember]
        [MaxLength(10)]
        public string Postcode { get; set; }

        [DataMember]
        public DateTime CreatedDate { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
    }
}

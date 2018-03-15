using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace KafkaDataProducer.Models
{
    [DataContract]
    [Table("Transactions")]
    public class Transaction
    {
        [DataMember]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }
        [DataMember]
        public decimal Amount { get; set; }
        [DataMember]
        [ForeignKey("Merchant")]
        public long MerchantId { get; set; }
        [DataMember]
        [ForeignKey("Customer")]
        public long CustomerId { get; set; }

        [DataMember]
        [MaxLength(26)]
        public string CardNumber { get; set; }

        [DataMember]
        public DateTime CreatedDate { get; set; }
    }
}
